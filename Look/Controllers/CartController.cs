using Look.DBContexts;
using Look.Models;
using Look.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Look.Controllers
{
    public class CartController : Controller
    {
        private readonly DBConnection _context;

        public CartController(DBConnection context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(p => p.Quantity * p.Price)
            };

            return View(cartVM);
        }
        public async Task<IActionResult> Add(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = cart.Where(p => p.CartId == id).FirstOrDefault();
            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cart);
            TempData["Success"] = "The product hes been added!";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            CartItem cartItem = cart.Where(c => c.CartId == id).FirstOrDefault();
            if (cartItem.Quantity > 0)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.CartId == id);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Success"] = "The product hes been Removed!";

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
             cart.RemoveAll(p => p.CartId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Success"] = "The product hes been Removed!";

            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            
            return RedirectToAction("Index");
        }

    }
}
