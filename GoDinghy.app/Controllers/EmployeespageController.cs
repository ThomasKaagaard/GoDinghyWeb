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
    public class EmployeespageController : MasterController
    {
        // GET: Employeespage
        public ActionResult Employeespage()
        {
            var model = new EmployeespageModel();
            model.Banner = MediaHelper.GetMediaUrl(CurrentPage, "bannerImage");
            model.Header = CurrentPage.GetPropertyValue<string>("header");
            model.Bodytext = CurrentPage.GetPropertyValue<IHtmlString>("bodytext");
            model.Employees = CurrentPage.Children.Select(employee => new EmployeepageModel()
            {
                Url = employee.Url,
                Image = MediaHelper.GetMediaUrl(employee, "image"),
                Name = employee.GetPropertyValue<string>("employeeName"),
                Title = employee.GetPropertyValue<string>("employeeTitle"),
                Email = employee.GetPropertyValue<string>("employeeEmail"),
                Phone = employee.GetPropertyValue<string>("employeePhone")
        });

            return View(model);
        }
    }
}