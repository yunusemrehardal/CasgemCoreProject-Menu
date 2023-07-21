using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresentationLayer.ViewComponents.Default
{
    public class _DomainPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
