#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5d96cbab72c453fd050a970dbfa80083baf414b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_MenuPR_Default), @"mvc.1.0.view", @"/Views/Shared/Components/MenuPR/Default.cshtml")]
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
#line 1 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\_ViewImports.cshtml"
using WebComputos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\_ViewImports.cshtml"
using WebComputos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5d96cbab72c453fd050a970dbfa80083baf414b", @"/Views/Shared/Components/MenuPR/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_MenuPR_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebComputos.Models.ViewModels.MenuDinamicoVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "TRecepcionPaquetes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PRDip", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PRReg", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
 if (Model.LDistrito.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <li class=""nav-item has-treeview"">
        <a class=""nav-link"" href=""#"">
            <i class=""far fa-building nav-icon""></i>
            <p>Diputaciones</p>
            <i class=""right fas fa-angle-left""></i>
        </a>
        <ul class=""nav nav-treeview"">
");
#nullable restore
#line 12 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
             foreach (var item in Model.LDistrito)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"nav-item\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e5d96cbab72c453fd050a970dbfa80083baf414b5714", async() => {
                WriteLiteral("\r\n                        <i class=\"far fa-dot-circle nav-icon\"></i>\r\n                        <p>Distrito ");
#nullable restore
#line 17 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
                               Write(item.Value);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
                                                                                                                  WriteLiteral(item.Value);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 20 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>      \r\n    </li>\r\n");
#nullable restore
#line 23 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 25 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
 if (Model.LDemarcaciones.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <li class=""nav-item has-treeview"">
        <a class=""nav-link"" href=""#"">
            <i class=""far fa-building nav-icon""></i>
            <p>Regidurías</p>
            <i class=""right fas fa-angle-left""></i>
        </a>
        <ul class=""nav nav-treeview"">
");
#nullable restore
#line 34 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
             foreach (var item in Model.LDemarcaciones)
            {
                var secciones = Model.Lsecciones.Where(x => x.DemarcacionId == item.Id).ToList();
                if (secciones.Count > 0)
                {

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e5d96cbab72c453fd050a970dbfa80083baf414b10483", async() => {
                WriteLiteral("\r\n                        <i class=\"far fa-dot-circle nav-icon\"></i>\r\n                        <p>");
#nullable restore
#line 44 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
                      Write(item.Nombre);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
                                                                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 47 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </li>\r\n");
#nullable restore
#line 50 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Views\Shared\Components\MenuPR\Default.cshtml"
 }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebComputos.Models.ViewModels.MenuDinamicoVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
