using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BanHangOnline.Areas.Admin.Controllers;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification.Abstractions;
using BanHangOnline.Models;
using System.Linq;
using BanHangOnline.Areas.Admin.AdminModelViews;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using BanHangOnline.ModelViews;

namespace BanHangOnline.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly BanHangOnlineContext _context;
        public INotyfService _notyfService { get; }

        public HomeController(BanHangOnlineContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;

        }
        [Area("Admin")]
        public IActionResult Index()
        {
            //var getSalesProduct = from pro in _context.Products
            //                      join od in _context.OrderDetails on pro.ProductId equals od.ProductId
            //                      select new
            //                      {
            //                          pro.ProductName
            //                      };

            var order = _context.Orders.AsNoTracking().Count();
            ViewBag.a = order;
            if (ViewBag.a > 0)
            {
                ViewBag.b = ViewBag.a;
            }
            else
            {
                ViewBag.b = 0;
            }
            var SumToltalMonyey = _context.Orders.AsNoTracking().Sum(a => a.TotalMoney);
            ViewBag.c = (float)SumToltalMonyey;

            var countMemberUser = _context.Customers.AsNoTracking().Count();
            ViewBag.d = countMemberUser;
            if (ViewBag.d > 0)
            {
                ViewBag.e = ViewBag.d;
            }
            else
            {
                ViewBag.e = 0;
            }

            //var getorderdate = _context.Orders.AsNoTracking().Select(a => a.OrderDate);
            //var tesst = from ord in _context.Orders
            //            join od in _context.OrderDetails on ord.OrderId equals od.OrderId
            //            join pro in _context.Products on od.ProductId equals pro.ProductId
            //            where orderdate == ord.OrderDate
            //            group ord by ord.OrderDate into g 
            //            select new
            //            {


            //            };
            
            HomeViewVM model = new HomeViewVM();

            List<ProductHomeVM> lsProductView = new List<ProductHomeVM>();

            var lsOrderDetail = _context.OrderDetails.AsNoTracking().ToList();
            var lsProducts= _context.Products.AsNoTracking().ToList();

            foreach (var item in lsOrderDetail)
            {
                ProductHomeVM productHome = new ProductHomeVM();
                productHome.lsProducts = lsProducts.Where(x => x.ProductId == item.ProductId).ToList();

                model.Products = lsProductView;
                ViewBag.AllProducts = lsProducts;
            }
            return View(model);
        }
    }
}
