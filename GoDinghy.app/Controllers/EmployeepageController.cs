using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoDinghy.app.Models;
using GoDinghy.app.Classes.Helpers;
using Umbraco.Web;

namespace GoDinghy.app.Controllers
{
    public class EmployeepageController : MasterController
    {
        // GET: Employeepage
        public ActionResult Employeepage()
        {
            var model = new EmployeepageModel();
            model.Image = MediaHelper.GetMediaUrl(CurrentPage, "image");
            model.Name = CurrentPage.GetPropertyValue<string>("employeeName");
            model.Title = CurrentPage.GetPropertyValue<string>("employeeTitle");
            model.Email = CurrentPage.GetPropertyValue<string>("employeeEmail");
            model.Phone = CurrentPage.GetPropertyValue<string>("employeePhone");
            model.Description = CurrentPage.GetPropertyValue<IHtmlString>("employeeDescription");

            return View(model);
        }
    }
}