#pragma checksum "C:\Projects\EnterpriceApp\App.Admin\Views\Shared\_Control_Sidebar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62929d435fd4a8d49835b8c2ddd52d52bf0d1b19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Control_Sidebar), @"mvc.1.0.view", @"/Views/Shared/_Control_Sidebar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62929d435fd4a8d49835b8c2ddd52d52bf0d1b19", @"/Views/Shared/_Control_Sidebar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d0df6c0c259843b3e9a8a7b548d3ee29c0d7696", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Control_Sidebar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<aside class=""control-sidebar control-sidebar-dark"">
    <!-- Create the tabs -->
    <ul class=""nav nav-tabs nav-justified control-sidebar-tabs"">
        <li class=""active""><a href=""#control-sidebar-home-tab"" data-toggle=""tab""><i class=""fa fa-home""></i></a></li>
        <li><a href=""#control-sidebar-settings-tab"" data-toggle=""tab""><i class=""fa fa-gears""></i></a></li>
    </ul>
    <!-- Tab panes -->
    <div class=""tab-content"">
        <!-- Home tab content -->
        <div class=""tab-pane active"" id=""control-sidebar-home-tab"">
            <h3 class=""control-sidebar-heading"">Recent Activity</h3>
            <ul class=""control-sidebar-menu"">
                <li>
                    <a href=""javascript:;"">
                        <i class=""menu-icon fa fa-birthday-cake bg-red""></i>
                        <div class=""menu-info"">
                            <h4 class=""control-sidebar-subheading"">Langdon's Birthday</h4>
                            <p>Will be 23 on April 24th</p>
              ");
            WriteLiteral(@"          </div>
                    </a>
                </li>
            </ul>
            <!-- /.control-sidebar-menu -->
            <h3 class=""control-sidebar-heading"">Tasks Progress</h3>
            <ul class=""control-sidebar-menu"">
                <li>
                    <a href=""javascript:;"">
                        <h4 class=""control-sidebar-subheading"">
                            Custom Template Design
                            <span class=""pull-right-container"">
                                <span class=""label label-danger pull-right"">70%</span>
                            </span>
                        </h4>
                        <div class=""progress progress-xxs"">
                            <div class=""progress-bar progress-bar-danger"" style=""width: 70%""></div>
                        </div>
                    </a>
                </li>
            </ul>
            <!-- /.control-sidebar-menu -->
        </div>
        <!-- /.tab-pane -->
        <!-- Stats t");
            WriteLiteral("ab content -->\r\n        <div class=\"tab-pane\" id=\"control-sidebar-stats-tab\">Stats Tab Content</div>\r\n        <!-- /.tab-pane -->\r\n        <!-- Settings tab content -->\r\n        <div class=\"tab-pane\" id=\"control-sidebar-settings-tab\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "62929d435fd4a8d49835b8c2ddd52d52bf0d1b196585", async() => {
                WriteLiteral(@"
                <h3 class=""control-sidebar-heading"">General Settings</h3>
                <div class=""form-group"">
                    <label class=""control-sidebar-subheading"">
                        Report panel usage
                        <input type=""checkbox"" class=""pull-right"" checked>
                    </label>
                    <p>
                        Some information about this general settings option
                    </p>
                </div>
                <!-- /.form-group -->
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <!-- /.tab-pane -->\r\n    </div>\r\n\r\n</aside>");
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
