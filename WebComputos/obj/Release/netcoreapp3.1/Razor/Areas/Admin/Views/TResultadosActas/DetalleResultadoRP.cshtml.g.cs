#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b52bf35214303fd9f4f4cd5bb6249e27e62d1a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TResultadosActas_DetalleResultadoRP), @"mvc.1.0.view", @"/Areas/Admin/Views/TResultadosActas/DetalleResultadoRP.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b52bf35214303fd9f4f4cd5bb6249e27e62d1a0", @"/Areas/Admin/Views/TResultadosActas/DetalleResultadoRP.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_TResultadosActas_DetalleResultadoRP : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebComputos.Models.ViewModels.T_Votos_Actas_RP_VM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
  
    IEnumerable<T_Partido> Lpar = ViewBag.partido;
    IEnumerable<T_Detalle_Votos_Acta_RP> Lres = ViewBag.votos;
    IEnumerable<T_Votos_Acta_RP> Lreg = ViewBag.resultado;

    ViewData["Title"] = "Create";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .externo {
        align-items: center;
        display: flex;
        justify-content: center;
    }

    #centrador {
        position: relative;
        width: 100px;
        height: 80px;
        background-color: white;
    }

    #imagen {
        position: absolute;
        width: 50px;
        height: 50px;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        margin: auto;
    }

    #imagenx {
        position: absolute;
        width: 50px;
        height: 25px;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        margin: auto;
    }

    #imagenc {
        position: absolute;
        width: 100px;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        margin: auto;
    }
</style>
<br />
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card card-secondary"">
            <div class=""card-header"">
                <h3 class=""card-title"">Votos registrado");
            WriteLiteral("s en la elección de ");
#nullable restore
#line 61 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                                                                      Write(ViewBag.Eleccion);

#line default
#line hidden
#nullable disable
            WriteLiteral(" en la casilla ");
#nullable restore
#line 61 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                                                                                                      Write(ViewBag.Casilla);

#line default
#line hidden
#nullable disable
            WriteLiteral(" de la sección ");
#nullable restore
#line 61 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                                                                                                                                     Write(ViewBag.Seccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            </div>\r\n            <div class=\"card-body\">\r\n");
#nullable restore
#line 64 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                 if (Lpar.Count() > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""card bg-gradient-gray"">
                        <div class=""card-body"">
                            <h5 class=""card-text text-center"">Partidos</h5>
                        </div>
                    </div>
                    <div class=""row"">
");
#nullable restore
#line 72 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                          
                            int contador = 0;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                         foreach (var Resultado in Model.DetalleVotosActasRPList)
                        {
                            if (Resultado.IdPartido != 0)
                            {
                                var partido = Lpar.FirstOrDefault(x => x.Id == Resultado.IdPartido && x.Independiente == false);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col-md-2\">\r\n                                    <div class=\"card externo border\">\r\n                                        <div id=\"centrador\">\r\n");
#nullable restore
#line 83 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                                             if (partido.Siglas == "MORENA")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <img");
            BeginWriteAttribute("src", " src=\"", 2651, "\"", 2686, 1);
#nullable restore
#line 85 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
WriteAttributeValue("", 2657, Url.Content(partido.LogoURL), 2657, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"imagenx\" />\r\n");
#nullable restore
#line 86 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <img");
            BeginWriteAttribute("src", " src=\"", 2901, "\"", 2936, 1);
#nullable restore
#line 89 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
WriteAttributeValue("", 2907, Url.Content(partido.LogoURL), 2907, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"imagen\" />\r\n");
#nullable restore
#line 90 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </div>\r\n                                        <div class=\"card-body\">\r\n                                            ");
#nullable restore
#line 93 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                                       Write(Html.TextBoxFor(x => x.DetalleVotosActasRPList[contador].Votos, new { @type = "number", @style = "text-align:center; form-control", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 97 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"


                            }
                            contador++;
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>                   
                    <div class=""row"">
                        <div class=""col-md-2"">
                            <div class=""card border"">
                                <div class=""card-body text-center"">
                                    <p class=""text-center""><strong>Candidatos no registrados</strong></p>
                                    <br />
                                    ");
#nullable restore
#line 109 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                               Write(Html.TextBoxFor(x => x.Votos_Acta.NoRegistrados, new { @type = "number", @style = "text-align:center; form-control", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 110 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                               Write(Html.HiddenFor(x => x.Votos_Acta.IdRegistroVotosRP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 111 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                               Write(Html.HiddenFor(x => x.Votos_Acta.IdActaDetalle));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                        <div class=""col-md-2"">
                            <div class=""card border"">
                                <div class=""card-body text-center"">
                                    <p class=""text-center""><strong>Votos nulos</strong></p>
                                    <br />
                                    ");
#nullable restore
#line 120 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                               Write(Html.TextBoxFor(x => x.Votos_Acta.Nulos, new { @type = "number", @style = "text-align:center; form-control", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 121 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                               Write(Html.HiddenFor(x => x.Votos_Acta.IdRegistroVotosRP));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                        <div class=""col-md-2"">
                            <div class=""card border"">
                                <div class=""card-body text-center"">
                                    <p class=""text-center""><strong>Total de Votos</strong></p>
                                    <br />
                                    ");
#nullable restore
#line 130 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                               Write(Html.TextBoxFor(x => x.Votos_Acta.Total, new { @type = "number", @style = "text-align:center; form-control", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 131 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                               Write(Html.HiddenFor(x => x.Votos_Acta.IdRegistroVotosRP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 136 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"text-right\">\r\n                    <button type=\"button\" class=\"btn btn-danger btn-lg rounded\" style=\"width:auto;\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b52bf35214303fd9f4f4cd5bb6249e27e62d1a015991", async() => {
                WriteLiteral("Volver al listado");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 139 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\DetalleResultadoRP.cshtml"
                          WriteLiteral(ViewBag.Index);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n        \r\n\r\n\r\n\r\n    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebComputos.Models.ViewModels.T_Votos_Actas_RP_VM> Html { get; private set; }
    }
}
#pragma warning restore 1591
