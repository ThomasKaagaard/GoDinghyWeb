using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoDinghy.app.Classes.Helpers;
using GoDinghy.app.Models;
using GoDinghy.app.Models.Helpers;
using Umbraco.Web;

namespace GoDinghy.app.Controllers
{
    public class ContactpageController : MasterController
    {
        // GET: Contactpage
        public ActionResult Contactpage()
        {
            var model = new ContactpageModel();
            model.Banner = MediaHelper.GetMediaUrl(CurrentPage, "bannerImage");
            model.Header = CurrentPage.GetPropertyValue<string>("header");
            model.CompanyAddress = CurrentPage.GetPropertyValue<IHtmlString>("companyAddress");
            model.CompanyPhone = CurrentPage.GetPropertyValue<string>("companyPhone");
            model.CompanyEmail = CurrentPage.GetPropertyValue<string>("companyEmail");

            model.Contactform = new ContactformModel() {NodeId = CurrentPage.Id};
            model.ThanksHeader = CurrentPage.GetPropertyValue<string>("thanksHeader");
            model.ThanksBodytext = CurrentPage.GetPropertyValue<IHtmlString>("thanksMessage");

            return View(model);
        }
    }
}