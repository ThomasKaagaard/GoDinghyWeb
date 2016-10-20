using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoDinghy.app.Models;
using Umbraco.Web;

namespace GoDinghy.app.Controllers
{
    public class CustomerListPageController : MasterController
    {
        // GET: CustomerListPage
        public ActionResult CustomerListPage()
        {
            var model = new CustomerListPageModel();
            model.Header = CurrentPage.GetPropertyValue<string>("header");
            model.Bodytext = CurrentPage.GetPropertyValue<IHtmlString>("bodytext");

            return View(model);
        }
    }
}