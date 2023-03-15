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


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BanHangOnline.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly BanHangOnlineContext _context;
        public INotyfService _notyfService { get; }
        public AccountsController(BanHangOnlineContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [Route("tai-khoan-cua-toi.html", Name = "Dashboard")]
        public IActionResult Dashboard()
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    var lsDonHang = _context.Orders
                        .Include(x => x.TransactStatus)
                        .AsNoTracking()
                        .Where(x => x.CustomerId == khachhang.CustomerId)
                        .OrderByDescending(x => x.OrderDate)
                        .ToList();
                    ViewBag.DonHang = lsDonHang;
                    return View(khachhang);
                }

            }
            return RedirectToAction("Index","Accounts");
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "DangKy")]
        public IActionResult DangkyTaiKhoan()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "DangKy")]
        public async Task<IActionResult> DangkyTaiKhoan(RegisterViewModel taikhoan)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var khachhang1 = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == taikhoan.Email);
                    if (khachhang1 != null)
                    {
                        _notyfService.Warning("Email đã tồn tại");
                        return RedirectToAction("DangkyTaiKhoan");
                    }
                    var khachhang2 = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Phone.Trim() == taikhoan.Phone);
                    if (khachhang2 != null)
                    {
                        _notyfService.Warning("Số điện thoại đã tồn tại");
                        return RedirectToAction("DangkyTaiKhoan");
                    }
                    string salt = Utilities.GetRandomKey();
                    Customer khachhang = new Customer
                    {
                        FullName = taikhoan.FullName,
                        Phone = taikhoan.Phone.Trim().ToLower(),
                        Email = taikhoan.Email.Trim().ToLower(),
                        Password = (taikhoan.Password + salt.Trim()).ToMD5(),
                        Active = true,
                        Salt = salt,
                        RoleId = 2,
                        CreateDate = DateTime.Now
                    };
                    try
                    {
                        _context.Add(khachhang);
                        await _context.SaveChangesAsync();
                        //Lưu Session MaKh
                        HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("CustomerId");

                        //Identity
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,khachhang.FullName),
                            new Claim("CustomerId", khachhang.CustomerId.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng ký thành công");
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                    catch
                    {
                        return RedirectToAction("DangkyTaiKhoan", "Accounts");
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



        [HttpGet]
        [AllowAnonymous]
        [Route("dang-ky-admin.html", Name = "DangKyAdmin")]
        public IActionResult DangkyTaiKhoanAdmin()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("dang-ky-admin.html", Name = "DangKyAdmin")]
        public async Task<IActionResult> DangkyTaiKhoanAdmin(RegisterViewModel taikhoan)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var khachhang1 = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == taikhoan.Email);
                    if (khachhang1 != null)
                    {
                        _notyfService.Warning("Email đã tồn tại");
                        return RedirectToAction("DangKyAdmin");
                    }
                    var khachhang2 = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Phone.Trim() == taikhoan.Phone);
                    if (khachhang2 != null)
                    {
                        _notyfService.Warning("Số điện thoại đã tồn tại");
                        return RedirectToAction("DangKyAdmin");
                    }
                    string salt = Utilities.GetRandomKey();
                    Customer khachhang = new Customer
                    {
                        FullName = taikhoan.FullName,
                        Phone = taikhoan.Phone.Trim().ToLower(),
                        Email = taikhoan.Email.Trim().ToLower(),
                        Password = (taikhoan.Password + salt.Trim()).ToMD5(),
                        Active = true,
                        Salt = salt,
                        RoleId = 1,
                        CreateDate = DateTime.Now
                    };
                    try
                    {
                        _context.Add(khachhang);
                        await _context.SaveChangesAsync();
                        //Lưu Session MaKh
                        HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("CustomerId");

                        //Identity
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,khachhang.FullName),
                            new Claim("CustomerId", khachhang.CustomerId.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng ký thành công");
                        return Redirect("/Admin/Home/Index");
                    }
                    catch
                    {
                        return RedirectToAction("DangKyAdmin", "Accounts");
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
        [Route("dang-nhap.html", Name = "DangNhap")]
        public IActionResult Login(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                return RedirectToAction("Dashboard", "Accounts");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "DangNhap")]
        public async Task<IActionResult> Login(LoginViewModel customer, string returnUrl)
        {
            try
            {
                var checkrolesShipper = _context.Customers.AsNoTracking().SingleOrDefault(m => m.Email.Trim() == customer.UserName.Trim() && m.RoleId == 3);
                var checkroles = _context.Customers.AsNoTracking().SingleOrDefault(m => m.Email.Trim() == customer.UserName.Trim() && m.RoleId == 1);
                if (checkroles != null) // check admin
                {
                    if (ModelState.IsValid)
                    {

                        bool isEmail = Utilities.IsValidEmail(customer.UserName);
                        if (!isEmail) return View(customer);

                        var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);

                        if (khachhang == null) return RedirectToAction("DangkyTaiKhoanAdmin");
                        string pass = (customer.Password + khachhang.Salt.Trim()).ToMD5();
                        if (khachhang.Password != pass)
                        {
                            _notyfService.Success("Thông tin đăng nhập chưa chính xác");
                            return View(customer);
                        }
                        //kiem tra xem account co bi disable hay khong

                        if (khachhang.Active == false)
                        {
                            return RedirectToAction("ThongBao", "Accounts");
                        }

                        //Luu Session MaKh
                        HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("CustomerId");

                        //Identity
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, khachhang.FullName),
                        new Claim("CustomerId", khachhang.CustomerId.ToString())
                    };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng nhập thành công");
                        if (string.IsNullOrEmpty(returnUrl))
                        {


                            return Redirect("/Admin/Home/Index");
                        }
                        else
                        {
                            return Redirect(returnUrl);
                        }
                    }
                }
                else if (checkrolesShipper != null)
                {
                    if (ModelState.IsValid)
                    {

                        bool isEmail = Utilities.IsValidEmail(customer.UserName);
                        if (!isEmail) return View(customer);

                        var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);

                        if (khachhang == null) return RedirectToAction("DangkyTaiKhoan");
                        string pass = (customer.Password + khachhang.Salt.Trim()).ToMD5();
                        if (khachhang.Password != pass)
                        {
                            _notyfService.Success("Thông tin đăng nhập chưa chính xác");
                            return View(customer);
                        }
                        //kiem tra xem account co bi disable hay khong

                        if (khachhang.Active == false)
                        {
                            return RedirectToAction("ThongBao", "Accounts");
                        }

                        //Luu Session MaKh
                        HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("CustomerId");

                        //Identity
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, khachhang.FullName),
                        new Claim("CustomerId", khachhang.CustomerId.ToString())
                    };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng nhập thành công");
                        if (string.IsNullOrEmpty(returnUrl))
                        {
                            return RedirectToAction("ShipperDashboard", "Accounts");
                        }
                        else
                        {
                            return Redirect(returnUrl);
                        }
                    }
                }
                {
                    if (ModelState.IsValid)
                    {

                        bool isEmail = Utilities.IsValidEmail(customer.UserName);
                        if (!isEmail) return View(customer);

                        var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);

                        if (khachhang == null) return RedirectToAction("DangkyTaiKhoan");
                        string pass = (customer.Password + khachhang.Salt.Trim()).ToMD5();
                        if (khachhang.Password != pass)
                        {
                            _notyfService.Success("Thông tin đăng nhập chưa chính xác");
                            return View(customer);
                        }
                        //kiem tra xem account co bi disable hay khong

                        if (khachhang.Active == false)
                        {
                            return RedirectToAction("ThongBao", "Accounts");
                        }

                        //Luu Session MaKh
                        HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("CustomerId");

                        //Identity
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, khachhang.FullName),
                        new Claim("CustomerId", khachhang.CustomerId.ToString())
                    };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng nhập thành công");
                        if (string.IsNullOrEmpty(returnUrl))
                        {


                            return RedirectToAction("Dashboard", "Accounts");
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
                return RedirectToAction("DangkyTaiKhoan", "Accounts");
            }
            return View(customer);
        }
        [HttpGet]
        [Route("dang-xuat.html", Name = "DangXuat")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("CustomerId");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("CustomerId");
                if (taikhoanID == null)
                {
                    return RedirectToAction("Login", "Accounts");
                }
                if (ModelState.IsValid)
                {
                    var taikhoan = _context.Customers.Find(Convert.ToInt32(taikhoanID));
                    if (taikhoan == null) return RedirectToAction("Login", "Accounts");
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
                        return RedirectToAction("Dashboard", "Accounts");
                    }

                }
            }
            catch
            {
                _notyfService.Success("Thay đổi mật khẩu không thành công");
                return RedirectToAction("Dashboard", "Accounts");
            }
            _notyfService.Success("Thay đổi mật khẩu không thành công");
            return RedirectToAction("Dashboard", "Accounts");
        }
    }
}
