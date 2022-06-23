using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;

namespace test.epi.forms.Components.MainNavigation
{
    public class MainNavigationViewComponent : ViewComponent
    {
        private readonly IUrlResolver _urlResolver;
        private readonly IContentLoader _contentLoader;

        public MainNavigationViewComponent(IUrlResolver urlResolver, IContentLoader contentLoader)
        {
            _urlResolver = urlResolver;
            _contentLoader = contentLoader;
        }

        public IViewComponentResult Invoke(PageData content)
        {
            var home = _contentLoader.Get<PageData>(ContentReference.StartPage, content.Language);
            var children = _contentLoader.GetChildren<IContent>(content.ContentLink, content.Language);

            var navigationItems = children.OfType<PageData>()
                .Select(c => new NavigationItem { Url = _urlResolver.GetUrl(c), Text = c.Name }).ToList();
            
            navigationItems.Insert(0, new NavigationItem { Url = _urlResolver.GetUrl(home), Text = home.Name});

            return View("~/Components/MainNavigation/MainNavigation.cshtml", navigationItems);
        }
    }
}