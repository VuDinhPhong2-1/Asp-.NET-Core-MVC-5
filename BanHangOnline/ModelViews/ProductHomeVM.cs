using BanHangOnline.Models;
using System.Collections.Generic;

namespace BanHangOnline.ModelViews
{
    public class ProductHomeVM
    {
        public Category category { get; set; }
        public List<Product> lsProducts { get; set; }
        public OrderDetail lsOrderDetails { get; set; }
    }
}
