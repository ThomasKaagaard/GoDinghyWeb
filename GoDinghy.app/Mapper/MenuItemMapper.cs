using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoDinghy.app.Models.Helpers;
using umbraco;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Security;

namespace GoDinghy.app.Mapper
{
    public static class MenuItemMapper
    {

        // Check if a member is logged in or not
        private static bool MemberLoggedIn()
        {
            var msHelper = new MembershipHelper(UmbracoContext.Current);
            var currentMember = msHelper.GetCurrentMember();
            return currentMember != null ? true : false;
        }
        // Get memberGroup from logged in member
        private static bool GetMemberAdminGroup()
        {
            var msHelper = new MembershipHelper(UmbracoContext.Current);
            List<string> groupList = new List<string>() {"AdminGroup"};
            if (msHelper.IsMemberAuthorized(allowGroups: groupList))
            {
                return true;
            }
            return false;
        }
        // An array for all the DocTypes you dont want listed in the navigation anywhere when not logged in.
        private static readonly string[] NoNavDocTypes = new string[] { "Standard404" };
        // An array for all the DocTypes you want listed in the navigation when logged in.
        private static readonly string[] MemberPages = new string[] { "customerListPage", "memberpage" };
        // An array for all the DocTypes you want listed in the navigation when logged in as AdminGroup.
        private static readonly string[] AdminMemberPages = new string[] { "memberpage" };

        // Check if current page from list must be visible or not in navigation
        private static bool ProcessTypedContent(IPublishedContent content)
        {
            if (MemberLoggedIn())
            {
                if (GetMemberAdminGroup())
                {
                    return content.IsVisible() && !NoNavDocTypes.Any(content.IsDocumentType);
                }
                else
                {
                    return content.IsVisible() && !NoNavDocTypes.Any(content.IsDocumentType) && !AdminMemberPages.Any(content.IsDocumentType);
                }
            }
            else
            {
                return content.IsVisible() && !NoNavDocTypes.Any(content.IsDocumentType) && !MemberPages.Any(content.IsDocumentType);
            }
        }
        // publish model with data from CMS
        public static T Map<T>(IPublishedContent content, IPublishedContent currentNode, UmbracoHelper helper, T model = default(T))
            where T : MenuItemModel, new()
        {
            if (content == null) return null;
            if (model == null) model = new T();
            
            model.Active = content.IsAncestorOrSelf(currentNode);
            model.Name = content.Name;
            model.Url = content.Url;
            model.Children = content.Children.Where("HasAccess")
                .Where(ProcessTypedContent)
                .Select(publishedContent => (T)Map<T>(publishedContent, currentNode, helper)).ToList();
            return model;
        }
        // publish a list of model with data from CMS
        public static IEnumerable<T> Map<T>(IEnumerable<IPublishedContent> content, IPublishedContent currentNode, UmbracoHelper helper)
            where T : MenuItemModel, new()
        {
            return content.Where(ProcessTypedContent).Select(x => (T)Map<T>(x, currentNode, helper)).WhereNotNull();
        }
    }
}