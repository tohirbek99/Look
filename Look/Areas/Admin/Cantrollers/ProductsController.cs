using Look.DBContexts;
using Look.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace Look.Areas.Admin.Cantrollers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly DBConnection _context;
        private readonly IWebHostEnvironment _webHost;

        public ProductsController(DBConnection context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
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

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.Category);
            if (ModelState.IsValid)
            {
                product.Slug = product.ProductName.ToLower().Replace("", "-");
                var slug = _context.Products.OrderByDescending(p => p.Slug == product.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The product already exists");
                    return View(product);
                }

                if (product.ImageUploud != null)
                {
                    string uploudsDir = Path.Combine(_webHost.WebRootPath, "/images/image");
                    string ImageName = Guid.NewGuid().ToString() + "-" + product.ImageUploud;

                    string filePath = Path.Combine(uploudsDir, ImageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUploud.CopyToAsync(fs);
                    fs.Close();

                    product.Image = ImageName;
                }

                _context.Add(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The product has been created";

                return RedirectToAction("Index");
            }

            return View(product);

        }
    }
}
