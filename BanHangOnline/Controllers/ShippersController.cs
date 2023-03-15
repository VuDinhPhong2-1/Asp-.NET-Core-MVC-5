using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BanHangOnline.Extension;
using BanHangOnline.Helpper;
using BanHangOnline.Models;
using BanHangOnline.ModelViews;
using AspNetCoreHero.ToastNotification.Notyf;

namespace BanHangOnline.Controllers
{
    [Authorize]
    public class ShippersController : Controller
    {
        private readonly BanHangOnlineContext _context;
        public INotyfService _notyfService { get; }

        public ShippersController(BanHangOnlineContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [Route("tai-khoan-cua-shipper.html", Name = "ShipperDashboard")]
        public IActionResult ShipperDashboard()
        {
            var taikhoanID = HttpContext.Session.GetString("ShipperId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Shippers.AsNoTracking().SingleOrDefault(x => x.ShipperId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    var lsDonHang = _context.Orders
                        .Include(x => x.TransactStatus)
                        .Include(a => a.Customer)
                        .AsNoTracking()
                        .Where(x => x.TransactStatusId == 2)
                        .OrderByDescending(x => x.OrderDate)
                        .ToList();
                    ViewBag.DonHang = lsDonHang;

                    var shippersID = HttpContext.Session.GetString("ShipperId");
                    var lsDonHangDaNhan = _context.Orders
                       .Include(x => x.TransactStatus)
                       .Include(a => a.Customer)
                       .AsNoTracking()
                       .Where(x => x.TransactStatusId == 3 && x.ShipperId == Convert.ToInt32(shippersID))
                       .OrderByDescending(x => x.OrderDate)
                       .ToList();
                    ViewBag.DonHangDaNhan = lsDonHangDaNhan;
                    return View(khachhang);
                }


            }
            return RedirectToAction("LoginShipper");
        }



        [HttpGet]
        [AllowAnonymous]
        [Route("dang-ky-shipper.html", Name = "DangkyTaiKhoanShipper")]
        public IActionResult DangkyTaiKhoanShipper()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("dang-ky-shipper.html", Name = "DangkyTaiKhoanShipper")]
        public async Task<IActionResult> DangkyTaiKhoanShipper(RegisterShipperViewModel taikhoan)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var khachhang1 = _context.Shippers.AsNoTracking().SingleOrDefault(x => x.Phone.Trim() == taikhoan.Phone);
                    if (khachhang1 != null)
                    {
                        _notyfService.Warning("Số điện thoại đã tồn tại");
                        return RedirectToAction("DangkyTaiKhoan");
                    }
                    string salt = Utilities.GetRandomKey();
                    Shipper khachhang = new Shipper
                    {
                        ShipperName = taikhoan.ShipperName,
                        Phone = taikhoan.Phone.Trim().ToLower(),
                        Password = (taikhoan.Password + salt.Trim()).ToMD5(),
                        Company = taikhoan.Company,
                        Active = true,
                        Salt = salt
                    };
                    try
                    {
                        _context.Add(khachhang);
                        await _context.SaveChangesAsync();
                        //Lưu Session MaKh
                        HttpContext.Session.SetString("ShipperId", khachhang.ShipperId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("ShipperId");

                        //Identity
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,khachhang.ShipperName),
                            new Claim("ShipperId", khachhang.ShipperId.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "LoginShipper");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng ký thành công");
                        return RedirectToAction("ShipperDashboard", "Shippers");
                    }
                    catch
                    {
                        return RedirectToAction("DangkyTaiKhoanShipper", "Shippers");
                    }
                }
                else
                {
                    return View(taikhoan);
                }
            }
            catch
            {
                return View(taikhoan);
            }
        }




        [AllowAnonymous]
        [Route("dang-nhap-shipper.html", Name = "DangNhapShipper")]
        public IActionResult LoginShipper(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("ShipperId");
            if (taikhoanID != null)
            {
                return RedirectToAction("ShipperDashboard", "Shippers");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap-shipper.html", Name = "DangNhapShipper")]
        public async Task<IActionResult> LoginShipper(LoginShipperViewModel shipper, string returnUrl)
        {
            try
            {
                var checkroles = _context.Shippers.AsNoTracking().SingleOrDefault(m => m.Phone.Trim() == shipper.Phone.Trim());
                if (checkroles != null)
                {
                    if (ModelState.IsValid)
                    {
                        var khachhang = _context.Shippers.AsNoTracking().SingleOrDefault(x => x.Phone.Trim() == shipper.Phone);

                        if (khachhang == null) return RedirectToAction("DangkyTaiKhoanShipper");
                        string pass = (shipper.Password + khachhang.Salt.Trim()).ToMD5();
                        if (khachhang.Password != pass)
                        {
                            _notyfService.Success("Thông tin đăng nhập chưa chính xác");
                            return View(shipper);
                        }
                        //kiem tra xem account co bi disable hay khong

                        if (khachhang.Active == false)
                        {
                            return RedirectToAction("ThongBao", "Shippers");
                        }

                        //Luu Session MaKh
                        HttpContext.Session.SetString("ShipperId", khachhang.ShipperId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("ShipperId");

                        //Identity
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, khachhang.Phone),
                        new Claim("ShipperId", khachhang.ShipperId.ToString())
                    };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "LoginShipper");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng nhập thành công");
                        if (string.IsNullOrEmpty(returnUrl))
                        {


                            return RedirectToAction("ShipperDashboard", "Shippers");
                        }
                        else
                        {
                            return Redirect(returnUrl);
                        }
                    }
                }

            }
            catch
            {
                return RedirectToAction("DangkyTaiKhoanShipper", "Shippers");
            }
            return View(shipper);
        }
        [HttpGet]
        [Route("dang-xuat-shipper.html", Name = "LogoutShipper")]
        public IActionResult LogoutShipper()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("ShipperId");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("ShipperId");
                if (taikhoanID == null)
                {
                    return RedirectToAction("LoginShipper", "Shippers");
                }
                if (ModelState.IsValid)
                {
                    var taikhoan = _context.Shippers.Find(Convert.ToInt32(taikhoanID));
                    if (taikhoan == null) return RedirectToAction("LoginShipper", "Shippers");
                    var pass = (model.PasswordNow.Trim() + taikhoan.Salt.Trim()).ToMD5();
                    if (taikhoan.Password != pass)
                    {
                        _notyfService.Success("Mật khẩu hiện tại chưa chính xác");
                        return View(model);
                    }
                    else
                    {
                        string passnew = (model.Password.Trim() + taikhoan.Salt.Trim()).ToMD5();
                        taikhoan.Password = passnew;
                        _context.Update(taikhoan);
                        _context.SaveChanges();
                        _notyfService.Success("Đổi mật khẩu thành công");
                        return RedirectToAction("ShipperDashboard", "Shippers");
                    }

                }
            }
            catch
            {
                _notyfService.Success("Thay đổi mật khẩu không thành công");
                return RedirectToAction("ShipperDashboard", "Shippers");
            }
            _notyfService.Success("Thay đổi mật khẩu không thành công");
            return RedirectToAction("ShipperDashboard", "Shippers");
        }



    }

}
