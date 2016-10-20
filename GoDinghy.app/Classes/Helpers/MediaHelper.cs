using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace GoDinghy.app.Classes.Helpers
{
    public class MediaHelper
    {
        public static string GetMediaUrl(IPublishedContent content, string propertyName)
        {
            if (content != null)
            {
                var umbraco = new UmbracoHelper(UmbracoContext.Current);
                var mediaId = content.GetPropertyValue<string>(propertyName);
                if (!string.IsNullOrWhiteSpace(mediaId))
                {
                    return umbraco.TypedMedia(mediaId).Url;
                }
            }
            return string.Empty;
        }
    }
}