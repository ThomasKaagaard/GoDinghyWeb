using System.Web;
using GoDinghy.app.Models.Helpers;

namespace GoDinghy.app.Models
{
    public class ContactpageModel : StandardpageHelperModel
    {
        public IHtmlString CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public ContactformModel Contactform { get; set; }
        public string ThanksHeader { get; set; }
        public IHtmlString ThanksBodytext { get; set; }
    }
}