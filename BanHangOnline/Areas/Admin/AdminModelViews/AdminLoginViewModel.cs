using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BanHangOnline.Areas.Admin.AdminModelViews
{
    public class AdminLoginViewModel
    {

        [Key]
        [MaxLength(100)]
        [Required(ErrorMessage = ("Vui lòng nhập Email dưới 100 ký tự"))]
        [Display(Name = "Địa chỉ Email")]
        [EmailAddress(ErrorMessage = "Sai định dạng Email")]
        public string AdminUserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 ký tự")]
        public string AdminPassword { get; set; }
    }
}

