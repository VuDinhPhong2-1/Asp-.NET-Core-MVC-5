﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BanHangOnline.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int TransactStatusId { get; set; }
        public bool Deleted { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int TotalMoney { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
        public int? ShipperId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual TransactStatus TransactStatus { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Shipper Shipper { get; set; }
    }
}
