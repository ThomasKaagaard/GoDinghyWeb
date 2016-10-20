using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoDinghy.app.Mapper;
using GoDinghy.app.Models;
using GoDinghy.app.Models.Helpers;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace GoDinghy.app.Controllers
{
    public class MasterController : RenderMvcController
    {
        // GET: Master
        protected override ViewResult View(IView view, object model)
        {
            var rootNode = CurrentPage.AncestorOrSelf(1);
            var currentMember = Members.GetCurrentMember();
            var children = MenuItemMapper.Map<MenuItemModel>(rootNode.Children, CurrentPage,  Umbraco).ToList();

            var global = new GlobalModel();
            global.MenuItems = new MenuItemModel() { Children = children, Url = rootNode.Url, Name = rootNode.Name };
            global.MemberLogin = new MemberLoginModel();
            global.IsLoggedIn = false;
            if (currentMember != null)
            {
                global.IsLoggedIn = true;
                global.MemberLogin = new MemberLoginModel()
                {
                    Username = currentMember.Name
                };

            }
            global.LoginPage = CurrentPage.Id == 1092 ? true : false;
            ViewBag.Global = global;

            return base.View(view, model);
        }
        protected new ViewResult View(object model)
        {
            return this.View(view: null, model: model);
        }

    }
}