using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FGC.BI.Data.Sys
{
    [Table("userinfo2")]
    public class User
    {
        [Column("id")]
        public decimal Id { get; set; }
        [Column("name")]
        public string UserName { get; set; }
        [Column("comment")]
        public string DisplayName { get; set; }
        [Column("password")]
        public string HashedPassword { get; set; }
        [Column("keys")]
        public string Key { get; set; }
        [Column("admin")]
        public byte Admin { get; set; }
        public bool IsAdmin { get { return Admin == 1; } }
    }
}
