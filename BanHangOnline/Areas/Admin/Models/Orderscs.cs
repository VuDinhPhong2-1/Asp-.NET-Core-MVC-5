using BanHangOnline.Models;
using System.Collections.Generic;
using System;

namespace BanHangOnline.Areas.Admin.Models
{

        public partial class Orderscs
        {
            public Orderscs()
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

            public virtual Customer Customer { get; set; }
            public virtual TransactStatus TransactStatus { get; set; }
            public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        }
}
