using System;
using System.Diagnostics.CodeAnalysis;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace test.epi.forms
{
    [TemplateDescriptor(Inherited = true)]
    public class DefaultPageController : PageController<PageData>
    {
        public ActionResult Index(PageData currentContent)
        {
            var originalType = currentContent.GetOriginalType();
            var pageName = originalType.Name;
            var viewPath = $"~{GetRelativePathFromType(originalType)}/{pageName}.cshtml";
            return View(viewPath, currentContent);
        }

        public static string GetRelativePathFromType([DisallowNull]Type type)
        {
            var namespaceWithoutAssembly = type.Namespace.Replace(type.Assembly.GetName().Name, string.Empty);
            return namespaceWithoutAssembly.Replace('.', '/');
        }
    }
}