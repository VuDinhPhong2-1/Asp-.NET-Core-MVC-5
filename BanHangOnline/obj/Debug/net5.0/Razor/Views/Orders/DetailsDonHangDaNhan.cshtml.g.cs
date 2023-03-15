#pragma checksum "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5eb442e2d43512f8211d075dec1dbb4ddf37e135"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_DetailsDonHangDaNhan), @"mvc.1.0.view", @"/Views/Orders/DetailsDonHangDaNhan.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\_ViewImports.cshtml"
using BanHangOnline;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\_ViewImports.cshtml"
using BanHangOnline.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5eb442e2d43512f8211d075dec1dbb4ddf37e135", @"/Views/Orders/DetailsDonHangDaNhan.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"813158b098751a6e48bca9b538294fadfac9b9cd", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Orders_DetailsDonHangDaNhan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BanHangOnline.ModelViews.XemDonHang>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var total = Model.ChiTietDonHang.Sum(x => x.TotalMoney).Value.ToString("#,##0");

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3>Thông tin đơn hàng: #");
#nullable restore
#line 9 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
                    Write(Model.DonHang.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<br />\r\n<p>Ngày đặt hàng: ");
#nullable restore
#line 11 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
             Write(Model.DonHang.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Trạng thái đơn hàng: ");
#nullable restore
#line 12 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
                   Write(Model.DonHang.TransactStatus.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Tổng giá trị đơn hàng: <strong> ");
#nullable restore
#line 13 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
                              Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</strong></p>\r\n<p>Ngày ship hàng: ");
#nullable restore
#line 14 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
              Write(Model.DonHang.ShipDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

<div class=""table-responsive"">
    <table class=""table table-bordered table-hover"">
        <tbody>
            <tr>
               <th>#</th>
                <th>Họ và tên</th>
                <th>Số điện thoại</th>
                <th>Sản phẩm</th>
                <th>Số lượng</th>
                <th>Đơn giá</th>
                <th>Thành tiền</th>
            </tr>

");
#nullable restore
#line 29 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
             foreach (var item in Model.ChiTietDonHang)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 32 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
                   Write(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 33 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
                   Write(item.Order.Customer.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 34 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
                   Write(item.Order.Customer.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 35 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
                   Write(item.Product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 36 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
                   Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
                   Write(item.Product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 38 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
                   Write(item.TotalMoney.Value.ToString("#,##0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</td>\r\n                </tr>\r\n");
#nullable restore
#line 40 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Orders\DetailsDonHangDaNhan.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BanHangOnline.ModelViews.XemDonHang> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
