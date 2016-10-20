using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoDinghy.app.Classes.Helpers;
using GoDinghy.app.Models;
using Umbraco.Web;

namespace GoDinghy.app.Controllers
{
    public class TextpageController : MasterController
    {
        // GET: Textpage
        public ActionResult Textpage()
        {
            var model = new TextpageModel();
            model.Banner = MediaHelper.GetMediaUrl(CurrentPage, "bannerImage");
            model.Header = CurrentPage.GetPropertyValue<string>("header");
            model.Grid = CurrentPage.GetGridHtml("grid");

            return View(model);
        }
    }
}