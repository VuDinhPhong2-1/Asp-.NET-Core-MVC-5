using BanHangOnline.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BanHangOnline.Areas.Admin.AdminModelViews
{
    public class AdminXemDonHangController
    {
        public Order DonHang { get; set; }
        public List<OrderDetail> ChiTietDonHang { get; set; }
    }
}
