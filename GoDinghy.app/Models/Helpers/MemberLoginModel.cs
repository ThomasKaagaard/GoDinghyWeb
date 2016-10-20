using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoDinghy.app.Models.Helpers
{
    public class MemberLoginModel
    {
        [Required, Display(Name = "Brugernavn")]
        public string Username { get; set; }

        [Required, Display(Name = "Kodeord"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}