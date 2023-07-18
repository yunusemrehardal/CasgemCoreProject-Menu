using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresentationLayer.ViewComponents.Default
{
    public class _FeaturePartial: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            ViewBag.title1 = "Hergün Pizza Yiyin!";
            ViewBag.title2 = "Sevdiğiniz Pizzaları Paylaşın!";
            return View(); 
        }
}
}
