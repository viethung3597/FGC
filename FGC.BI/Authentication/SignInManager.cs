using FGC.BI.Data.Sys;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FGC.BI.Authentication
{
    public class SignInManager
    {
        private readonly SysDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public SignInManager(SysDbContext context, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        public async Task<bool> SigninAsync(string userName, string password, bool rememberMe)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            User user = null;

            if (CheckRootSignin(userName, password))
            {
                user = new User
                {
                    UserName = "root",
                    DisplayName = "root",
                    Admin = 1
                };
            }
            else
            {
                user = await _context.Users
                    .FirstOrDefaultAsync(x => x.UserName == userName);

                if (user == null)
                {
                    return false;
                }
                var hashed = MD5Hash(user.UserName.ToUpper() + password + user.Key);
                if (hashed != user.HashedPassword.Trim())
                {
                    return false;
                }
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("DisplayName", user.DisplayName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                IsPersistent = rememberMe,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return true;
        }


        private bool CheckRootSignin(string userName, string password)
        {
            var rootUserName = _configuration.GetValue<string>("Authentication:MasterUser");
            var rootPassword = _configuration.GetValue<string>("Authentication:MasterPassword");

            return rootUserName == userName && rootPassword == password;
        }

        private static string MD5Hash(string input)
        {
            using MD5 md5 = MD5.Create();
            return string.Join(string.Empty, md5.ComputeHash(Encoding.UTF8.GetBytes(input)).Select(b => b.ToString("x2")));
        }
    }
}
