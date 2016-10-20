using System.Web;
using System.Web.Mvc;
using GoDinghy.app.Classes.Helpers;
using GoDinghy.app.Models;
using Umbraco.Web;

namespace GoDinghy.app.Controllers
{
    public class Standard404Controller : MasterController
    {
        // GET: ErrorPage
        public ActionResult Standard404()
        {
            var model = new ErrorPageModel()
            {
                Banner = MediaHelper.GetMediaUrl(CurrentPage, "bannerImage"),
                Header = CurrentPage.GetPropertyValue<string>("header"),
                Bodytext = CurrentPage.GetPropertyValue<IHtmlString>("bodytext")
            };


            return View(model);
        }
    }
}