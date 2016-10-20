using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoDinghy.app.Models
{
    public class FrontpageModel : StandardpageHelperModel
    {
        public IHtmlString Teaser { get; set; }
        public IHtmlString Grid { get; set; } 
    }
}