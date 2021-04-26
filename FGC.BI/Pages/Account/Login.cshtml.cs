using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FGC.BI.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FGC.BI.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SignInManager _signInManager;

        public LoginModel(SignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public LoginInput Input { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var res = await _signInManager.SigninAsync(Input.UserName, Input.Password, Input.RememberMe);
            if (!res)
            {
                ModelState.AddModelError("InvalidLogin", "Sai tên đăng nhập hoặc mật khẩu");
                return Page();
            }
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToPage("/Index");
            }
            return Redirect(returnUrl);
        }
    }

    public class LoginInput
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}