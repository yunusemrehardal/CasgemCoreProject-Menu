using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzapan.BusinessLayer.Abstract;
using Pizzapan.DataAccessLayer.Concrete;
using Pizzapan.EntityLayer.Concrete;
using System.Linq;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly Context _context;

        public CategoryController(ICategoryService categoryService, Context context )
        {
            _categoryService = categoryService;
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }
        public IActionResult CategoryProduct()
        {
            var values = _context.Categories.Include(x=>x.Products).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.TInsert(category);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
