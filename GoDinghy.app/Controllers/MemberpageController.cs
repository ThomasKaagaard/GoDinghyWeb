using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoDinghy.app.Classes.Helpers;
using GoDinghy.app.Models;
using umbraco.cms.businesslogic.member;
using Umbraco.Core.Persistence;
using Umbraco.Web;
using Umbraco.Core.Services;

namespace GoDinghy.app.Controllers
{
    public class MemberpageController : MasterController
    {

        // GET: Memberpage
        public ActionResult Memberpage()
        {
            int currentNode = CurrentPage.Id;
            //var memberService = Services.MemberService;
            //var roles = memberService.GetAllRoles();
            //MemberGroup[] memberGroups = MemberGroup.GetAll;


            var model = new MemberpageModel();
            model.Header = CurrentPage.GetPropertyValue<string>("header");
            model.Bodytext = CurrentPage.GetPropertyValue<IHtmlString>("bodytext");
            model.MemberModel = new CreateMemberModel() {MemberGroups = GetMemberGroups(), NodeId = currentNode};

            return View(model);
        }

        private IEnumerable<SelectListItem> GetMemberGroups()
        {
            MemberGroup[] memberGroups = MemberGroup.GetAll;
            IList<SelectListItem> items = new List<SelectListItem>();
            foreach (var group in memberGroups)
            {
                items.Add(new SelectListItem() { Text = group.Text, Value = group.Text });
            }
            return items;
        }
    }
}