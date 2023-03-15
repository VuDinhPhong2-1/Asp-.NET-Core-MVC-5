using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BanHangOnline.Models;

namespace BanHangOnline.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly BanHangOnlineContext _context;

        public OrderDetailsController(BanHangOnlineContext context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            var banHangOnlineContext = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product);
            return View(await banHangOnlineContext.ToListAsync());
        }

        // GET: OrderDetails/Details/5
        [Route("/orders/{OrderDetailId}", Name = "ChiTietDonHang")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }
    }
}
