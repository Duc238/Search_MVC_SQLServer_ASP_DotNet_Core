using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search_MVC_SQL_Server.Models;

namespace Search_MVC_SQL_Server.Controllers
{
    public class ProductController : Controller
    {
        private readonly SearchAspcoreMvcContext _context;
        public ProductController(SearchAspcoreMvcContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Search(int? categoryId, string productName)
        {
            var query = _context.Products.Include(p => p.IdCategoryNavigation).AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.IdCategory == categoryId.Value);
            }

            if (!string.IsNullOrWhiteSpace(productName))
            {
                query = query.Where(p => p.ProductName.Contains(productName));
            }

            var results = query.ToList();

            return PartialView("_ProductListPartial", results);
        }

    }
}
