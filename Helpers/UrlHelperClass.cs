using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Web.Mvc;

namespace CMSWebsite.Helpers
{
    public static class UrlHelperClass
    {
        public static string IsActive(this IHtmlHelper htmlHelper, string controller, string action)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = routeData.Values["action"].ToString();
            var routeController = routeData.Values["controller"].ToString();

            var returnActive = (controller == routeController && action == routeAction);

            return returnActive ? "Active" : "";
        }
    }
}
