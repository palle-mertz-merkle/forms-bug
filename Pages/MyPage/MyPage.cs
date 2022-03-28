using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace test.epi.forms.Pages.MyPage
{
    [ContentType(DisplayName = "My Page",
        GUID = "{1F205BE8-32C8-45BF-97B7-0439D54AC63F}",
        AvailableInEditMode = true)]
    public class MyPage : PageData
    {
        public virtual string Headline { get; set; }

        public virtual XhtmlString Body { get; set; }
        public virtual ContentArea ContentArea { get; set; }
    }
}