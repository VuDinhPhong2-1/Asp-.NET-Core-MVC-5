#pragma checksum "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Shared\Components\NumberCart\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8276b6fc2358cb377e9e89ff82af83762c039c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_NumberCart_Default), @"mvc.1.0.view", @"/Views/Shared/Components/NumberCart/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8276b6fc2358cb377e9e89ff82af83762c039c8", @"/Views/Shared/Components/NumberCart/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"813158b098751a6e48bca9b538294fadfac9b9cd", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_NumberCart_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BanHangOnline.ModelViews.CartItem>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Shared\Components\NumberCart\Default.cshtml"
 if (Model != null && Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"minicart-wrap me-3 me-lg-0\">\n        <a href=\"#miniCart\" class=\"minicart-btn toolbar-btn\">\n            <i class=\"pe-7s-shopbag\"></i>\n            <span class=\"quantity\">");
#nullable restore
#line 7 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Shared\Components\NumberCart\Default.cshtml"
                              Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n        </a>\n    </li>\n");
#nullable restore
#line 10 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Shared\Components\NumberCart\Default.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"minicart-wrap me-3 me-lg-0\">\n        <a href=\"#miniCart\" class=\"toolbar-btn\">\n            <i class=\"pe-7s-shopbag\"></i>\n            <span class=\"quantity\">0</span>\n        </a>\n    </li>\n");
#nullable restore
#line 19 "D:\TestDuAn3\BanHangOnline\BanHangOnline\Views\Shared\Components\NumberCart\Default.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BanHangOnline.ModelViews.CartItem>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
