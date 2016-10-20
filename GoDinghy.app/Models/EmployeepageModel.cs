using System.Web;

namespace GoDinghy.app.Models
{
    public class EmployeepageModel
    {
        public string Url { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IHtmlString Description { get; set; }
    }
}