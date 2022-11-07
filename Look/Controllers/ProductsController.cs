using Look.DBContexts;
using Look.Models;
using Microsoft.AspNetCore.Mvc;

namespace Look.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DBConnection _context;

        public ProductsController(DBConnection context)
        {
            _context = context;
        }
        public IActionResult Index(int pg = 1)
        {  

            List<Product> products = _context.Products.ToList();
            const int pageSize = 3;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = products.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recsSkip = (pg - 1) * pageSize;
            var data = products.Skip(recsSkip).Take(pageSize).ToList();
            this.ViewBag.Pager=pager;

            return View(data);
        }
    }
}
