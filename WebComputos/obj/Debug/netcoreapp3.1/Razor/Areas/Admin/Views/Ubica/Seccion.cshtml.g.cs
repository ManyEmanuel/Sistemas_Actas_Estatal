#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9bb36d1de7b46997369b03830a63bf770cf46ccc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Ubica_Seccion), @"mvc.1.0.view", @"/Areas/Admin/Views/Ubica/Seccion.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bb36d1de7b46997369b03830a63bf770cf46ccc", @"/Areas/Admin/Views/Ubica/Seccion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Ubica_Seccion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebComputos.Models.ViewModels.UbicaCasillaVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
  
    ViewData["Title"] = "Reporte";
    Layout = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9bb36d1de7b46997369b03830a63bf770cf46ccc4950", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9bb36d1de7b46997369b03830a63bf770cf46ccc5330", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9bb36d1de7b46997369b03830a63bf770cf46ccc6508", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9bb36d1de7b46997369b03830a63bf770cf46ccc8869", async() => {
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
            padding-bottom: 0em;
        }

        .color {
            background-color: #F9B9EE;
        }

        .linea {
           ");
                WriteLiteral(@" color: black;
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
            width: 5%;
        }

        table td:nth-child(2) {
            width: 5%;
        }

        table td:nth-child(3) {
            width: 5%;
        }

        table td:nth-child(4) {
            width: 5%;
        }

        table td:nth-child(5) {
            width: 5%;
        }

        table td:nth-child(6) {
            width: 5%;
        }

        table td:nth-child(7) {
            width: 20%;
        }

        table td:nth-child(8) {
            width: 20%;
        }

        table td:nth-child(9) {
            width: 20%;
        }

        table td:last-child {
            width: 10%;
        }
    </style>
    <header>
     ");
                WriteLiteral("   <div class=\"form-group row\">\r\n            <div class=\"col-4\">\r\n                <img src=\"/Imagenes/Logos/IEEN200.png\" />\r\n            </div>\r\n            <div class=\"col-4\">\r\n                <p class=\"Texto2\">LISTADO GENERAL DE CASILLAS DE LA SECCIÓN ");
#nullable restore
#line 134 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                                                       Write(Model.Secc);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <br /> DEL MUNICIPIO DE ");
#nullable restore
#line 134 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                                                                                           Write(Model.Mun.ToUpper());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
            </div>
        </div>
    </header>

    <div class=""form-group row"">
        <div class=""col-12"">
            <table class=""table table-bordered"">
                <thead class=""thead-light"">
                    <tr>
                        <th class=""text-center"" scope=""col"">#</th>
                        <th class=""text-center"" scope=""col"">No. de Sección</th>
                        <th class=""text-center"" scope=""col"">Tipo de Sección</th>
                        <th class=""text-center"" scope=""col"">Padrón Electoral</th>
                        <th class=""text-center"" scope=""col"">Lista Nominal</th>
                        <th class=""text-center"" scope=""col"">Tipo de Casilla</th>
                        <th class=""text-center"" scope=""col"">Domicilio</th>
                        <th class=""text-center"" scope=""col"">Ubicación</th>
                        <th class=""text-center"" scope=""col"">Referencia</th>
                        <th class=""text-center"" scope=""col"">Tipo de Lugar</");
                WriteLiteral("th>\r\n\r\n                    </tr>\r\n                </thead>\r\n");
#nullable restore
#line 157 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                  
                    int num = 0;
                    string lugar = "";
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 161 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                 foreach (var row in Model.ReporteCasilla)
                {
                    num = num + 1;
                    if (row.Lugar == "1")
                    {
                        lugar = "Edificio";
                    }
                    else if (row.Lugar == "2")
                    {
                        lugar = "Oficina Pública";
                    }
                    else if (row.Lugar == "3")
                    {
                        lugar = "Lugar Público";
                    }
                    else if (row.Lugar == "4")
                    {
                        lugar = "Particular";
                    }
                    else if (row.Lugar == "5")
                    {
                        lugar = "Escuela";
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <th class=\"text-center\" scope=\"col\">");
#nullable restore
#line 185 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                                       Write(num);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 186 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                           Write(row.NoSeccion);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 187 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                           Write(row.TipoSeccion);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 188 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                           Write(row.Padron);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 189 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                           Write(row.Lista);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 190 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                           Write(row.TipoCasilla);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 191 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                           Write(row.Domicilio);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 192 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                           Write(row.Ubicacion);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 193 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                           Write(row.Referencia);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 194 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                           Write(lugar);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 198 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </table>
        </div>
    </div>
    <div class=""form-group row"">
        <div class=""col-4"">
            <table class=""table table-bordered Si"">
                <thead class=""thead-light"">
                    <tr>
                        <th class=""text-center"" scope=""col"">Tipo de Casilla </th>
                        <th class=""text-center"" scope=""col"">Total</th>

                    </tr>
                </thead>
                <tr>
                    <td class=""text-center"">Basica</td>
                    <td class=""text-center"">");
#nullable restore
#line 214 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                       Write(Model.Basica);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-center\">Contigua</td>\r\n                    <td class=\"text-center\">");
#nullable restore
#line 218 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                       Write(Model.Contigua);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-center\">Extraordinaria</td>\r\n                    <td class=\"text-center\">");
#nullable restore
#line 222 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                       Write(Model.Extra);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-center\">Extraordinaria Contigua</td>\r\n                    <td class=\"text-center\">");
#nullable restore
#line 226 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                       Write(Model.ExtraCon);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-center\">Especial</td>\r\n                    <td class=\"text-center\">");
#nullable restore
#line 230 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                       Write(Model.Especial);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-center\">Total de Casillas</td>\r\n                    <td class=\"text-center\">");
#nullable restore
#line 234 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Ubica\Seccion.cshtml"
                                       Write(Model.Total);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
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
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebComputos.Models.ViewModels.UbicaCasillaVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
