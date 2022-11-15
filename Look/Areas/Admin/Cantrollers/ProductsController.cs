using Look.DBContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Look.Areas.Admin.Cantrollers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly DBConnection _context;

        public ProductsController(DBConnection context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int currentpage, int p = 1)
        {

            ViewBag.CurrentPages = currentpage + 1;
            int pagesSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pagesSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pagesSize);

            return View(await _context.Products.OrderByDescending(p => p.ProductId)
                                                                 .Include(p => p.Category)
                                                                 .Skip((p - 1) * pagesSize)
                                                                 .Take(pagesSize)
                                                                 .ToListAsync());

        }
    }
}
