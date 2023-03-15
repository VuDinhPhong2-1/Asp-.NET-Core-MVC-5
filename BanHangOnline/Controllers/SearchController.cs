using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BanHangOnline.Models;
using BanHangOnline.ModelViews;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BanHangOnline.Controllers
{
    public class SearchController : Controller
    {
        private readonly BanHangOnlineContext _context;

        public SearchController(BanHangOnlineContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        //[HttpPost]
        //public IActionResult FindProduct(string keyword)
        //{
        //    List<Product> ls = new List<Product>();
        //    if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
        //    {
        //        return PartialView("ListProductsSearchPartial", null);
        //    }
        //    ls = _context.Products.AsNoTracking()
        //                          .Where(x => x.ProductName.Contains(keyword))
        //                          .OrderByDescending(x => x.ProductName)
        //                          .ToList();
        //    if (ls == null)
        //    {
        //        return PartialView("ListProductsSearchPartial", null);
        //    }
        //    else
        //    {
        //        return PartialView("ListProductsSearchPartial", ls);
        //    }
        //}

    }
}
