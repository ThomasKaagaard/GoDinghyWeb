using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GoDinghy.app.Classes.Helpers;
using GoDinghy.app.Models;
using GoDinghy.app.Models.Helpers;
using Umbraco.Web.Mvc;

namespace GoDinghy.app.Controllers.Surface
{
    public class MemberSurfaceController : SurfaceController
    {
        private string GetCurrentMenber()
        {
            var username = "";
            var currentMember = Members.GetCurrentMember();
            if (currentMember != null)
            {
                username = currentMember.Name;
            }
            return username;
        }
        // The MemberLogout Action signs out the user and redirects to the site home page:
        [HttpPost]
        public ActionResult MemberLogout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            LogfileHelper.MemberLog(GetCurrentMenber(), "Log out at");
            return Redirect("/");
        }

        // The MemberLoginPost Action checks the entered credentials using the standard Asp Net membership provider and redirects the user to the same page. Either as logged in, or with a message set in the TempData dictionary:
        [HttpPost]
        [ActionName("Login")]
        public ActionResult MemberLogin(MemberLoginModel model)
        {
            if (Membership.ValidateUser(model.Username, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Username, true);
                LogfileHelper.MemberLog(model.Username, "Log in at");
                return RedirectToCurrentUmbracoPage();
            }
            else
            {
                LogfileHelper.MemberLog(model.Username, "Failed log in at");
                return RedirectToCurrentUmbracoPage();
            }
        }

        [HttpPost]
        public JsonResult SignUp(CreateMemberModel model, int nodeId)
        {
            ApplyFormResponse resultMessage = new ApplyFormResponse();

            if (!ModelState.IsValid) {
                resultMessage.ErrorMessage = "Der er desværre sket en fejl - prøv igen";
                return Json(resultMessage);
            }
            var memberService = Services.MemberService;
            if (memberService.GetByEmail(model.Email) != null)
            {
                resultMessage.ErrorCode = "Member already exists";
                return Json(resultMessage);
            }
            var member = memberService.CreateMemberWithIdentity(model.Username, model.Email, model.Name, "Member");
            memberService.Save(member);
            memberService.AssignRole(member.Id, model.SelectedGroup);
            memberService.SavePassword(member, model.Password);
            resultMessage.ErrorCode = "OK";
            return Json(resultMessage);
        }
        public class ApplyFormResponse
        {
            public string ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
        }
        [HttpPost]
        public JsonResult OpenLogFile()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/Logs";
            var path = Path.Combine(dir, "Login-out-log.txt");
            System.Diagnostics.Process.Start(path);
            return Json("OK");
        }
    }
}