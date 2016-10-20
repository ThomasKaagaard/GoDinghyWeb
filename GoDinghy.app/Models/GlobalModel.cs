using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GoDinghy.app.Models.Helpers;

namespace GoDinghy.app.Models
{
    public class GlobalModel
    {
        public MenuItemModel MenuItems { get; set; }

        public MemberLoginModel MemberLogin { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool LoginPage { get; set; }
    }
    
}