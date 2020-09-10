using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSalePrep.Web.Data;
using System.Threading.Tasks;

namespace OnSalePrep.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders
                .Include(p => p.User)
                .Include(p => p.OrderDetails)
                .ToListAsync());
        }
    }
}
