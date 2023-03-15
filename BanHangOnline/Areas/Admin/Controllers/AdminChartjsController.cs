using Microsoft.AspNetCore.Mvc;
using System;
using BanHangOnline.Models;
using BanHangOnline.Areas.Admin.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BanHangOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminChartjsController : Controller
    {
        private readonly BanHangOnlineContext _context;
        public INotyfService _notyfService { get; }

        public AdminChartjsController(BanHangOnlineContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bar(int year)
        {
            var order = _context.Orders.AsNoTracking().Count();
            ViewBag.a = order;
            if(order >= 0)
            {
                ViewBag.b = 0;
            }
            else
            {
                ViewBag.b = 100;
            }
            var sales = _context.Orders.AsNoTracking().Where(m => m.Paid == true);
            return View();
        }

    }
}
