using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
//using System.Web;
using System.Web.Mvc;
using GoDinghy.app.Models.Helpers;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace GoDinghy.app.Controllers.Surface
{
    public class ContactformSurfaceController : SurfaceController
    {
        // GET: ContactformSurface
        public JsonResult Contactform(ContactformModel model, string NodeId)
        {
            ContactFormResponseModel resultMessage = new ContactFormResponseModel();

            try
            {
                Dictionary<string, string> dictionary = CreateKeyValueDictionary(model);
                IPublishedContent node = Umbraco.TypedContent(model.NodeId);

                var body = node.GetPropertyValue<string>("emailbody");
                body = dictionary.Aggregate(body, (current, dic) => current.Replace(dic.Key, dic.Value));
                var settings = Umbraco.TypedContent(model.NodeId);
                var fromMail = settings.GetPropertyValue<string>("from");
                var toMail = settings.GetPropertyValue<string>("to");
                var sub = settings.GetPropertyValue<string>("subject");
                if (settings != null && !string.IsNullOrWhiteSpace(toMail) && !string.IsNullOrWhiteSpace(sub))
                {
                    MailAddress from = new MailAddress(fromMail, "GoDinghy"); //Fra UMBRACO
                    MailAddress to = new MailAddress(toMail); //Fra FORMULAREN
                    MailAddress cc = new MailAddress(model.Email, model.Name);

                    //create the mail
                    MailMessage message = new MailMessage(from, to);
                    message.IsBodyHtml = true;
                    message.Subject = sub;
                    message.Body = body;
                    message.CC.Add(cc);
                    SmtpClient smtp = new SmtpClient();
                    smtp.Send(message);
                }
                resultMessage.ErrorCode = "OK";
                return Json(resultMessage);
            }
            catch (Exception ex)
            {
                resultMessage.ErrorCode = "Error";
                resultMessage.ErrorMessage = "Der er desværre sket en fejl - prøv igen, eller kontakt os pr telefon";
                return Json(resultMessage);
            }
        }

        private Dictionary<string, string> CreateKeyValueDictionary(ContactformModel formData)
        {
            var dictionary = new Dictionary<string, string>
            {
                {"##name##", formData.Name},
                {"##company##", formData.Company},
                {"##email##", formData.Email},
                {"##message##", formData.Message.Replace("\n", "<br />")}
            };
            return dictionary;
        }
    }
}