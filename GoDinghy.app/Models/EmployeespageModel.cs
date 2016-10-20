using System.Collections.Generic;
using System.Web;

namespace GoDinghy.app.Models
{
    public class EmployeespageModel : StandardpageHelperModel
    {
        public IHtmlString Bodytext { get; set; }
        public IEnumerable<EmployeepageModel> Employees { get; set; }
    }
}