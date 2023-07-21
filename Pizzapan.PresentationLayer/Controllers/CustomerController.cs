using Microsoft.AspNetCore.Mvc;
using Pizzapan.BusinessLayer.Abstract;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IContactService _contactService;

        public CustomerController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.TGetList();
            return View(values);
        }
    }
}
