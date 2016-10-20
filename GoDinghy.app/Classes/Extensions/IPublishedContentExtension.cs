using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace GoDinghy.app.Classes.Extensions
{
    public enum PublishedContentType
    {
        Content,
        Media,
        Member
    }

    public static class IPublishedContentExtension
    {
        public static T GetPropertyValue<T>(this IPublishedContent prop, string alias, bool recursive)
        {
            return prop.GetPropertyValue<T>(alias, recursive, default(T));
        }

        public static T GetPropertyValue<T>(this IPublishedContent prop, string alias, PublishedContentType type)
            where T : IPublishedContent
        {
            var umbraco = new UmbracoHelper(UmbracoContext.Current);
            var property = prop.GetPropertyValue<int>(alias);
            switch (type)
            {
                case PublishedContentType.Content:
                    return (T)umbraco.TypedContent(property);
                case PublishedContentType.Media:
                    return (T)umbraco.TypedMedia(property);
                case PublishedContentType.Member:
                    return (T)umbraco.TypedMember(property);
            }
            throw new NotImplementedException("Passed PublishedContentType is not implemented");
        }


        /// <summary>
        /// Returns the url or an empty string for a given contentNode.
        /// </summary>
        /// <param name="content">The contentNode.</param>
        /// <returns>Returns the url if any can be found or an empty string.</returns>
        public static string GetUrlOrEmpty(this IPublishedContent content)
        {
            return content != null ? content.Url : string.Empty;
        }

        /// <summary>
        /// Tests if the contentNode have a template.
        /// </summary>
        /// <param name="content">The contentNode to test.</param>
        /// <returns>True if the node have a template.</returns>
        public static bool HasTemplate(this IPublishedContent content)
        {
            return content.TemplateId != default(int);
        }

        /// <summary>
        /// Get Umbraco mediaItems url based on the propertyname for the MediaItem. If none picked it is an empty string.
        /// </summary>
        /// <param name="content">The contentNode with the property</param>
        /// <param name="propertyName">The propertyname with a mediaItem.</param>
        /// <param name="helper">The UmbracoHelper. This is usually just "Umbraco".</param>
        /// <returns>The url for the mediaItem or an empty string.</returns>
        public static string GetMediaUrlOrEmpty(this IPublishedContent content, string propertyName, UmbracoHelper helper)
        {
            if (content != null)
            {
                var mediaId = content.GetPropertyValue<string>(propertyName);
                if (!string.IsNullOrWhiteSpace(mediaId))
                {
                    return helper.TypedMedia(mediaId).GetUrlOrEmpty();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Get Umbraco contentNode url based on the propertyname for the contentNode. If none picked it is an empty string.
        /// </summary>
        /// <param name="content">The contentNode with the property</param>
        /// <param name="propertyName">The propertyname with a contentNode.</param>
        /// <param name="helper">The UmbracoHelper. This is usually just "Umbraco".</param>
        /// <returns>The url for the contentNode or an empty string.</returns>
        public static string GetContentUrlOrEmpty(this IPublishedContent content, string propertyName, UmbracoHelper helper)
        {
            if (content != null)
            {
                var contentId = content.GetPropertyValue<string>(propertyName);
                if (!string.IsNullOrWhiteSpace(contentId))
                {
                    return helper.TypedContent(contentId).GetUrlOrEmpty();
                }
            }
            return string.Empty;
        }
    }
}