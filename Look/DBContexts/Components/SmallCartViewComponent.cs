using Look.Models;
using Look.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Look.DBContexts.Components
{
    public class SmallCartViewComponent : ViewComponent
    {
      public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            SmallCartViewModel smallCartVN;
            if (cart==null||cart.Count==0)
            {
                smallCartVN = null;
            }
            else
            {
                smallCartVN = new()
                {
                    NumberOfItems = cart.Sum(p => p.Quantity),
                    TotalAmount = cart.Sum(p => p.Quantity * p.Price)
                };
            }
            return View(smallCartVN);
        }
    }
}
