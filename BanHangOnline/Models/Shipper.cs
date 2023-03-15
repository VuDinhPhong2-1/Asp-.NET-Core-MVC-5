﻿using BanHangOnline.Areas.Admin.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace BanHangOnline.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
