using Look.DBContexts;
using Look.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Look.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DBConnection _context;

        public ProductsController(DBConnection context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string categorySlug = "", int p = 1)
        {
             int pageSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.CategorySlug = categorySlug;

             if (categorySlug == "")
            {
                ViewBag.TotalPage= (int)Math.Ceiling((double)_context.Products.Count()/pageSize);
                return View(await _context.Products.OrderByDescending(p=>p.ProductId).Skip((p-1)*pageSize).Take(pageSize).ToListAsync());
            }
            Category category = await _context.Categories.Where(c => c.Slug == categorySlug).FirstOrDefaultAsync();
            if (category == null)
                return RedirectToAction("Index");
            var productByCategory = _context.Products.Where(p => p.CategoryId == category.CategoryId);
            ViewBag.TotalPage = (int)Math.Ceiling((double)productByCategory.Count() / pageSize);
            return View(await productByCategory.OrderByDescending(p => p.ProductId).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());
        }
    }
}
