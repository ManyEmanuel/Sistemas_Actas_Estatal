#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cafd402aaf9bac9a30824a5a51d6d6700b49ba88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TRecepcionPaquetes_ImprimirPys), @"mvc.1.0.view", @"/Areas/Admin/Views/TRecepcionPaquetes/ImprimirPys.cshtml")]
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
#line 1 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\_ViewImports.cshtml"
using WebComputos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\_ViewImports.cshtml"
using WebComputos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cafd402aaf9bac9a30824a5a51d6d6700b49ba88", @"/Areas/Admin/Views/TRecepcionPaquetes/ImprimirPys.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_TRecepcionPaquetes_ImprimirPys : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebComputos.Models.ViewModels.ReporteCausalesVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Imagenes/Logos/PREP.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
  
    ViewData["Title"] = "Reporte";
    Layout = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cafd402aaf9bac9a30824a5a51d6d6700b49ba885426", async() => {
                WriteLiteral("\r\n        <meta charset=\"utf-8\" />\r\n        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cafd402aaf9bac9a30824a5a51d6d6700b49ba885818", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cafd402aaf9bac9a30824a5a51d6d6700b49ba887000", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

        <!--Css todos-->
        <link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css"" />
        <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.css"" />
        <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css"" />
        <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css"" />
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cafd402aaf9bac9a30824a5a51d6d6700b49ba889389", async() => {
                WriteLiteral(@"
        <style>
            header {
                width: auto;
                clear: both;
            }

            .Texto {
                width: auto;
                height: 25px;
                background: #656464;
            }

            .Texto1 {
                text-align: center;
                font-size: 140%;
                font-weight: bold;
                color: white;
            }

            .Texto2 {
                text-align: center;
                font-size: 140%;
                font-weight: bold;
                color: black;
            }

            .TextoCuerpo {
                text-align: center;
                font-size: 160%;
            }

            .TextoFirma {
                text-align: center;
                font-size: 120%;
            }

            .TextoCabecera {
                text-align: center;
                font-size: 120%;
                font-weight: bold;
                margin-bottom: 0px;
       ");
                WriteLiteral(@"         padding-bottom: 0em;
            }

            .color {
                background-color: #F9B9EE;
            }

            .linea {
                color: black;
                font-size: 2;
            }

            .saltopagina {
                display: none;
            }

            .saltopagina {
                display: block;
                page-break-before: always;
            }

            .Derecha {
                text-align: right;
            }

            table td:first-child {
                width: 10%;
            }

            table td:nth-child(2) {
                width: 40%;
            }

            table td:nth-child(3) {
                width: 40%;
            }

            table td:last-child {
                width: 10%;
            }

            table.SinCausal td:first-child {
                width: 10%;
            }

            table.SinCausal td:nth-child(2) {
                width: 45%;
            }

  ");
                WriteLiteral(@"          table.SinCausal td:last-child {
                width: 45%;
            }
        </style>
        <header>
            <div class=""form-group row"">
                <div class=""col-4"">
                    <img src=""/Imagenes/Logos/IEEN200.png"" />
                </div>
                <div class=""col-4"">
                    <p class=""Texto2"">CONSEJO MUNICIPAL ELECTORAL DE ");
#nullable restore
#line 123 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                                                                Write(Model.Municipio.ToUpper());

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"col-4 Derecha\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cafd402aaf9bac9a30824a5a51d6d6700b49ba8812611", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </div>
            </div>
        </header>
        <div class="" Texto"">
            <p class=""Texto1"">
                LISTADO DE CASILLAS CON CAUSALES DE RECUENTO
            </p>
        </div>
        <div class=""form-group row"">
            <div class=""col-12"">
                <p class=""TextoCuerpo"">ELECCIÓN: <b> <u>PRESIDENCIA Y SINDICATURA</u></b></p>
            </div>
        </div>
        <div class=""form-group row"">
            <div class=""col-12"">
                <table class=""table table-bordered"">
                    <thead class=""thead-light"">
                        <tr>
                            <th class=""text-center"" scope=""col"">#</th>
                            <th class=""text-center"" scope=""col"">Número de Sección</th>
                            <th class=""text-center"" scope=""col"">Casilla</th>
                            <th class=""text-center"" scope=""col"">Total de causales</th>
                        </tr>
                    </thead>
");
#nullable restore
#line 151 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                      
                        int num = 0;
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 154 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                     foreach (var row in Model.CCausal)
                    {
                        num = num + 1;

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <th class=\"text-center\" scope=\"col\">");
#nullable restore
#line 158 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                                                           Write(num);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 159 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                                               Write(row.NoSeccionCC);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 160 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                                               Write(row.CasillaCC);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 161 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                                               Write(row.NoCausales);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 165 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </table>
            </div>
        </div>
        <div class=""saltopagina"">
            <header>
                <div class=""form-group row"">
                    <div class=""col-4"">
                        <img src=""/Imagenes/Logos/IEEN200.png"" />
                    </div>
                    <div class=""col-4"">
                        <p class=""Texto2"">CONSEJO MUNICIPAL ELECTORAL DE ");
#nullable restore
#line 176 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                                                                    Write(Model.Municipio.ToUpper());

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"col-4 Derecha\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cafd402aaf9bac9a30824a5a51d6d6700b49ba8818129", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </div>
                </div>
            </header>
        </div>
        <div class="" Texto"">
            <p class=""Texto1"">
                LISTADO DE CASILLAS SIN CAUSALES DE RECUENTO
            </p>
        </div>
        <div class=""form-group row"">
            <div class=""col-12"">
                <p class=""TextoCuerpo"">ELECCIÓN: <b> <u>AYUNTAMIENTOS</u></b></p>
            </div>
        </div>

        <div class=""form-group row"">
            <div class=""col-12"">
                <table class=""table table-bordered SinCausal"">
                    <thead class=""thead-light"">
                        <tr>
                            <th class=""text-center"" scope=""col"">#</th>
                            <th class=""text-center"" scope=""col"">Número de Sección</th>
                            <th class=""text-center"" scope=""col"">Casilla</th>
                        </tr>
                    </thead>
");
#nullable restore
#line 205 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                      
                        int num1 = 0;
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 208 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                     foreach (var row in Model.SCausal)
                    {
                        num1 = num1 + 1;

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <th class=\"text-center\" scope=\"col\">");
#nullable restore
#line 212 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                                                           Write(num1);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 213 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                                               Write(row.NoSeccionSC);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 214 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                                               Write(row.CasillaSC);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 216 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\ImprimirPys.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </table>\r\n            </div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebComputos.Models.ViewModels.ReporteCausalesVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
