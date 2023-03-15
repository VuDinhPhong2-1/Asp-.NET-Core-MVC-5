using System;
using System.Collections.Generic;
using BanHangOnline.Models;

namespace BanHangOnline.ModelViews
{
    public class XemDonHang
    {
        public Order DonHang { get; set; }
        public List<OrderDetail> ChiTietDonHang { get; set; }
    }
}
