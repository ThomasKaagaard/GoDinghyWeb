using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoDinghy.app.Models.Helpers
{
    public class MenuItemModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public IEnumerable<MenuItemModel> Children { get; set; }
    }
}