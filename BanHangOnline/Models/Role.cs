using System;
using System.Collections.Generic;

#nullable disable

namespace BanHangOnline.Models
{
    public partial class Role
    {
        public Role()
        {
            Customer = new HashSet<Customer>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
