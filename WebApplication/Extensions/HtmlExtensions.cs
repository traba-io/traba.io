using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Extensions
{
    public static class HtmlExtensions
    {
        public static bool IsMenuActive(this IHtmlHelper htmlHelper, string menuItemUrl)
        {
            var viewContext = htmlHelper.ViewContext;
            var currentPageUrl = viewContext.ViewData["ActiveMenu"] as string ?? viewContext.HttpContext.Request.Path;
            return currentPageUrl.StartsWith(menuItemUrl, StringComparison.OrdinalIgnoreCase);
        }
    }
}