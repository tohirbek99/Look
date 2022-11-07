using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Look.DBContexts.Components
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly DBConnection _context;

        public CategoriesViewComponent(DBConnection context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Categories.ToListAsync());
    }
}
