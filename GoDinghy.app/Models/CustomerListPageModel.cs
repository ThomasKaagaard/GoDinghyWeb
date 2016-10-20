using System.Collections.Generic;
using System.Web;

namespace GoDinghy.app.Models
{
    public class CustomerListPageModel
    {
        public string Header { get; set; }
        public IHtmlString Bodytext { get; set; }
        public IEnumerable<CustomerModel> Customers { get; set; }

    }

    public class CustomerModel
    {
        public string Name { get; set; }
    }
}