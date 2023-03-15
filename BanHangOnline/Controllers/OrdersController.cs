using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BanHangOnline.Models;
using BanHangOnline.Areas.Admin.AdminModelViews;
using Microsoft.AspNetCore.Authorization;
using BanHangOnline.ModelViews;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;

namespace BanHangOnline.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly BanHangOnlineContext _context;

        public INotyfService _notyfService { get; }

        public OrdersController(BanHangOnlineContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;

        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var banHangOnlineContext = _context.Orders.Include(o => o.Customer).Include(o => o.TransactStatus);
            return View(await banHangOnlineContext.ToListAsync());
        }

        [Route("detail-don-hang-shipper.html", Name = "XemDonHangShipper")]
        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var donhang = await _context.Orders
                    .Include(x => x.TransactStatus)
                    .FirstOrDefaultAsync(m => m.OrderId == id);
                if (donhang == null) return NotFound();

                var chitietdonhang = _context.OrderDetails
                    .Include(x => x.Product)
                    .Include(a => a.Order.Customer)
                    .AsNoTracking()
                    .Where(x => x.OrderId == id)
                    .OrderBy(x => x.OrderDetailId)
                    .ToList();
                XemDonHang donHang = new XemDonHang();
                donHang.DonHang = donhang;
                donHang.ChiTietDonHang = chitietdonhang;
                return PartialView("Details", donHang);

            }
            catch
            {
                return NotFound();
            }
        }


        public async Task<IActionResult> DetailsUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var donhang = await _context.Orders
                    .Include(x => x.TransactStatus)
                    .FirstOrDefaultAsync(m => m.OrderId == id);
                if (donhang == null) return NotFound();

                var chitietdonhang = _context.OrderDetails
                    .Include(x => x.Product)
                    .Include(a => a.Order.Customer)
                    .AsNoTracking()
                    .Where(x => x.OrderId == id)
                    .OrderBy(x => x.OrderDetailId)
                    .ToList();
                XemDonHang donHang = new XemDonHang();
                donHang.DonHang = donhang;
                donHang.ChiTietDonHang = chitietdonhang;
                return PartialView("DetailsUser", donHang);

            }
            catch
            {
                return NotFound();
            }
        }
        [Route("detail-don-hang-da-nhan-shipper.html", Name = "XemDonHangDaNhanShipper")]
        public async Task<IActionResult> DetailsDonHangDaNhan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var taikhoanID = HttpContext.Session.GetString("ShipperId");
                if (string.IsNullOrEmpty(taikhoanID)) return RedirectToAction("ShipperDashboard", "Shippers");
                var khachhang = _context.Shippers.AsNoTracking().SingleOrDefault(x => x.ShipperId == Convert.ToInt32(taikhoanID));
                if (khachhang == null) return NotFound();
                var donhang = await _context.Orders
                    .Include(x => x.TransactStatus)
                    .FirstOrDefaultAsync(m => m.OrderId == id && Convert.ToInt32(taikhoanID) == m.ShipperId);
                if (donhang == null) return NotFound();

                var chitietdonhang = _context.OrderDetails
                    .Include(x => x.Product)
                    .Include(a => a.Order.Customer)
                    .AsNoTracking()
                    .Where(x => x.OrderId == id)
                    .OrderBy(x => x.OrderDetailId)
                    .ToList();
                XemDonHang donHang = new XemDonHang();
                donHang.DonHang = donhang;
                donHang.ChiTietDonHang = chitietdonhang;
                return PartialView("DetailsDonHangDaNhan", donHang);

            }
            catch
            {
                return NotFound();
            }
        }
        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            //var laydonhang = _context.TransactStatuses.Where(x => x.TransactStatusId == 3);
            //ViewBag.laydonhang = laydonhang;
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["TransactStatusId"] = new SelectList(_context.TransactStatuses.Where(x=>x.TransactStatusId==3), "TransactStatusId", "Status", order.TransactStatusId);
            return View(order);
        }
 
        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,OrderDate,ShipDate,TransactStatusId,Deleted,Paid,PaymentDate,TotalMoney,Note,Address")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var taikhoanID = HttpContext.Session.GetString("ShipperId");
                    order.ShipperId = Int32.Parse(taikhoanID);
                    _notyfService.Success("Cập nhật thành công");
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("index");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["TransactStatusId"] = new SelectList(_context.TransactStatuses, "TransactStatusId", "TransactStatusId", order.TransactStatusId);
            return View(order);
        }


        public async Task<IActionResult> EditUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["TransactStatusId"] = new SelectList(_context.TransactStatuses.Where(x => x.TransactStatusId == 4), "TransactStatusId", "Status", order.TransactStatusId);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, [Bind("OrderId,CustomerId,OrderDate,ShipDate,TransactStatusId,Deleted,Paid,PaymentDate,TotalMoney,Note,Address")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var taikhoanID = HttpContext.Session.GetString("CustomerId");
                    order.CustomerId = Int32.Parse(taikhoanID);
                    _notyfService.Success("Cập nhật thành công");
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Dashboard", "Accounts");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["TransactStatusId"] = new SelectList(_context.TransactStatuses, "TransactStatusId", "TransactStatusId", order.TransactStatusId);
            return View(order);
        }
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
