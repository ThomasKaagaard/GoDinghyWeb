using System.Web;

namespace GoDinghy.app.Models
{
    public class ErrorPageModel : StandardpageHelperModel
    {
        public IHtmlString Bodytext { get; set; }
    }
}