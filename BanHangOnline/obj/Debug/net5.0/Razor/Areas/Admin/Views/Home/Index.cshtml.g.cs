#pragma checksum "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e53cb3d978a0ed68a0eaca0c7da0ff196a0321b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
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
#line 1 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\_ViewImports.cshtml"
using BanHangOnline;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\_ViewImports.cshtml"
using BanHangOnline.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e53cb3d978a0ed68a0eaca0c7da0ff196a0321b", @"/Areas/Admin/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"813158b098751a6e48bca9b538294fadfac9b9cd", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BanHangOnline.ModelViews.HomeViewVM>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Admin Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";
    List<Product> allProduct = ViewBag.AllProducts;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-6 col-lg-3"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""media align-items-center"">
                    <div class=""avatar avatar-icon avatar-lg avatar-blue"">
                        <i class=""anticon anticon-dollar""></i>
                    </div>
                    <div class=""m-l-15"">
                        <h2 class=""m-b-0"">");
#nullable restore
#line 17 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\Home\Index.cshtml"
                                     Write(ViewBag.c);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" VND</h2>
                        <p class=""m-b-0 text-muted"">Profit</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-md-6 col-lg-3"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""media align-items-center"">
                    <div class=""avatar avatar-icon avatar-lg avatar-gold"">
                        <i class=""anticon anticon-profile""></i>
                    </div>
                    <div class=""m-l-15"">
                        <h2 class=""m-b-0"">");
#nullable restore
#line 32 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\Home\Index.cshtml"
                                     Write(ViewBag.b);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                        <p class=""m-b-0 text-muted"">Orders</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-md-6 col-lg-3"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""media align-items-center"">
                    <div class=""avatar avatar-icon avatar-lg avatar-purple"">
                        <i class=""anticon anticon-user""></i>
                    </div>
                    <div class=""m-l-15"">
                        <h2 class=""m-b-0"">");
#nullable restore
#line 47 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\Home\Index.cshtml"
                                     Write(ViewBag.e);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                        <p class=""m-b-0 text-muted"">Customers</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-md-12 col-lg-12"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""d-flex justify-content-between align-items-center"">
                    <h5>Top Product</h5>
                </div>
                <div class=""tab-content"" id=""myTabContent"">
                    <div class=""tab-pane fade show active"" id=""all-items"" role=""tabpanel"" aria-labelledby=""all-items-tab"">
                        ");
#nullable restore
#line 62 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\Home\Index.cshtml"
                   Write(await Html.PartialAsync("_ListProductPartialView", allProduct));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 64 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\Home\Index.cshtml"
                     foreach (var item in Model.Products)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"tab-pane fade\"");
            BeginWriteAttribute("id", " id=\"", 2695, "\"", 2720, 1);
#nullable restore
#line 66 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\Home\Index.cshtml"
WriteAttributeValue("", 2700, item.category.Alias, 2700, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"tabpanel\" aria-labelledby=\"fresh-fruits-tab\">\r\n                            ");
#nullable restore
#line 67 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\Home\Index.cshtml"
                       Write(await Html.PartialAsync("_ListProductPartialView", item.lsProducts));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 69 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Areas\Admin\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BanHangOnline.ModelViews.HomeViewVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
