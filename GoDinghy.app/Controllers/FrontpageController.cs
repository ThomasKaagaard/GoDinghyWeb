using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoDinghy.app.Models;
using GoDinghy.app.Classes.Helpers;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace GoDinghy.app.Controllers
{
    public class FrontpageController : MasterController
    {
        // GET: Frontpage
        public ActionResult Frontpage()
        {
            var model = new FrontpageModel();
            model.Banner = MediaHelper.GetMediaUrl(CurrentPage, "bannerImage");
            model.Header = CurrentPage.GetPropertyValue<string>("header");
            model.Teaser = CurrentPage.GetPropertyValue<IHtmlString>("teaser");
            model.Grid = CurrentPage.GetGridHtml("grid");
            return View(model);
        }
    }

    //public string GetUrlOrEmpty(IPublishedContent content)
        //{
        //    return content != null ? content.Url : string.Empty;
        //}
    //}
}

