#pragma checksum "C:\Projects\EnterpriceApp\App.Admin\Views\Manage\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0362a0f063ee223f0412d842137fa1926c600983"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manage__Layout), @"mvc.1.0.view", @"/Views/Manage/_Layout.cshtml")]
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
#line 1 "C:\Projects\EnterpriceApp\App.Admin\Views\_ViewImports.cshtml"
using App.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\EnterpriceApp\App.Admin\Views\_ViewImports.cshtml"
using App.Infrastructure.CrossCutting.Identity.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\EnterpriceApp\App.Admin\Views\_ViewImports.cshtml"
using App.Infrastructure.CrossCutting.Identity.Models.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\EnterpriceApp\App.Admin\Views\_ViewImports.cshtml"
using App.Infrastructure.CrossCutting.Identity.Models.ManageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\EnterpriceApp\App.Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0362a0f063ee223f0412d842137fa1926c600983", @"/Views/Manage/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d0df6c0c259843b3e9a8a7b548d3ee29c0d7696", @"/Views/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/Manage/_ViewImports.cshtml")]
    public class Views_Manage__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Projects\EnterpriceApp\App.Admin\Views\Manage\_Layout.cshtml"
   
    Layout = "/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Manage your account</h2>\r\n\r\n<div>\r\n    <h4>Change your account settings</h4>\r\n    <hr />\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            ");
#nullable restore
#line 12 "C:\Projects\EnterpriceApp\App.Admin\Views\Manage\_Layout.cshtml"
       Write(await Html.PartialAsync("_ManageNav"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-9\">\r\n            ");
#nullable restore
#line 15 "C:\Projects\EnterpriceApp\App.Admin\Views\Manage\_Layout.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 21 "C:\Projects\EnterpriceApp\App.Admin\Views\Manage\_Layout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("        \r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
