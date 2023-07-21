using Microsoft.AspNetCore.Mvc;
using Pizzapan.BusinessLayer.Abstract;
using Pizzapan.EntityLayer.Concrete;
using System;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.TGetList();
            return View(values);
        }

        public IActionResult MessageDetailsContact(int id)
        {
            var values = _contactService.TGetByID(id);
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult GetMessageByTesekkur()
        {
            var values = _contactService.TGetContactBySubjectWithTesekkur();
            return View(values);
        }
        [HttpGet]
        public IActionResult GetContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetContact(Contact contact)
        {
            contact.SendDateMessage = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _contactService.TInsert(contact);
            return RedirectToAction("Index", "Default");
        }
    }
}