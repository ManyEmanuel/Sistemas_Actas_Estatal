#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3be7965a05aaa8196dc5b37f256dea97744c1c3b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TResultadosActas_ResultadosCRP), @"mvc.1.0.view", @"/Areas/Admin/Views/TResultadosActas/ResultadosCRP.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3be7965a05aaa8196dc5b37f256dea97744c1c3b", @"/Areas/Admin/Views/TResultadosActas/ResultadosCRP.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_TResultadosActas_ResultadosCRP : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebComputos.Models.ViewModels.T_Votos_Actas_RP_VM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CapturaVotosRP", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onKeypress", new global::Microsoft.AspNetCore.Html.HtmlString("if(event.keyCode == 13) event.returnValue = false;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("checkSubmit();"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Resultados.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
  
    IEnumerable<T_Partido> Lpar = ViewBag.partido;
    IEnumerable<T_Detalle_Votos_Acta_RP> Lres = ViewBag.Resact;
    IEnumerable<T_Votos_Acta_RP> Lreg = ViewBag.Registro;
    Layout = "";

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
                <h3 class=""card-title""> Registro de votos");
            WriteLiteral("</h3>\r\n            </div>\r\n");
#nullable restore
#line 60 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
             if (Lpar.Count() > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3be7965a05aaa8196dc5b37f256dea97744c1c3b7156", async() => {
                WriteLiteral("\r\n                    <div class=\"card-body\">\r\n                        <div class=\"row\">\r\n");
#nullable restore
#line 65 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                              
                                int contador = 0;
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                             foreach (var Resultado in Model.DetalleVotosActasRPList)
                            {
                                if (Resultado.IdPartido != 0)
                                {
                                    var partido = Lpar.FirstOrDefault(x => x.Id == Resultado.IdPartido && x.Independiente == false);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    <div class=""col-md-2"">
                                        <div class=""card externo border"">
                                            <div id=""centrador"">                                             
                                                <img");
                BeginWriteAttribute("src", " src=\"", 2368, "\"", 2403, 1);
#nullable restore
#line 76 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
WriteAttributeValue("", 2374, Url.Content(partido.LogoURL), 2374, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"imagen\" />                                              \r\n                                            </div>\r\n                                            <div class=\"card-body\">\r\n                                                ");
#nullable restore
#line 79 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                                           Write(Html.TextBoxFor(x => x.DetalleVotosActasRPList[contador].Votos, new { @type = "number", @class = "form-control text-center" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                ");
#nullable restore
#line 80 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                                           Write(Html.HiddenFor(x => x.DetalleVotosActasRPList[contador].IdPartido));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                ");
#nullable restore
#line 81 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                                           Write(Html.HiddenFor(x => x.DetalleVotosActasRPList[contador].IdDetalleVotosActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 85 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                                }
                                contador++;
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </div>
                        <br />
                        <div class=""row"">
                            <div class=""col-md-2"">
                                <div class=""card border"">
                                    <div class=""card-body"">
                                        <p class=""text-center"">Candidatos no registrados</p>
                                        ");
#nullable restore
#line 95 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                                   Write(Html.HiddenFor(x => x.Votos_Acta.IdRegistroVotosRP));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        ");
#nullable restore
#line 96 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                                   Write(Html.HiddenFor(x => x.Votos_Acta.IdActaDetalle));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        ");
#nullable restore
#line 97 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                                   Write(Html.TextBoxFor(x => x.Votos_Acta.NoRegistrados, new { @type = "number", @class = "form-control text-center" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </div>
                                </div>
                            </div>

                            <div class=""col-md-2"">
                                <div class=""card border"">
                                    <div class=""card-body"">
                                        <p class=""text-center"">Votos Nulos</p>
                                        ");
#nullable restore
#line 106 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                                   Write(Html.HiddenFor(x => x.Votos_Acta.IdRegistroVotosRP));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        ");
#nullable restore
#line 107 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                                   Write(Html.TextBoxFor(x => x.Votos_Acta.Nulos, new { @type = "number", @class = "form-control text-center" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                                    </div>
                                </div>
                            </div>
                            <div class=""col-md-2"">
                                <div class=""card border"">
                                    <div class=""card-body"">
                                        <p class=""text-center"">Total de Votos</p>
                                        ");
#nullable restore
#line 116 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                                   Write(Html.HiddenFor(x => x.Votos_Acta.IdRegistroVotosRP));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        ");
#nullable restore
#line 117 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                                   Write(Html.TextBoxFor(x => x.Votos_Acta.Total, new { @type = "number", @class = "form-control text-center" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class=""text-right"">
                            <input class=""btn btn-success btn-lg rounded"" type=""submit"" value=""Guardar votos"" id=""GVotos"" />
                            
");
#nullable restore
#line 126 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                             if (ViewBag.Eleccion == 3)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <input id=\"cancelar\" class=\"btn btn-danger btn-lg rounded\" type=\"button\" value=\"Cancelar\" style=\"width:auto;\"");
                BeginWriteAttribute("onclick", " onclick=\"", 5824, "\"", 5896, 3);
                WriteAttributeValue("", 5834, "location.href=\'", 5834, 15, true);
#nullable restore
#line 128 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
WriteAttributeValue("", 5849, Url.Action("CreateDipRP", "TResultadosActas"), 5849, 46, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 5895, "\'", 5895, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 129 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 130 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                             if (ViewBag.Eleccion == 4)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <input id=\"cancelar\" class=\"btn btn-danger btn-lg rounded\" type=\"button\" value=\"Cancelar\" style=\"width:auto;\"");
                BeginWriteAttribute("onclick", " onclick=\"", 6162, "\"", 6234, 3);
                WriteAttributeValue("", 6172, "location.href=\'", 6172, 15, true);
#nullable restore
#line 132 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
WriteAttributeValue("", 6187, Url.Action("CreateRegRP", "TResultadosActas"), 6187, 46, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6233, "\'", 6233, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 133 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 138 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TResultadosActas\ResultadosCRP.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n<style>\r\n    input[type=number]::-webkit-inner-spin-button, input[type=number]::-webkit-outer-spin-button {\r\n        -webkit-appearance: none;\r\n        margin: 0;\r\n    }\r\n</style>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3be7965a05aaa8196dc5b37f256dea97744c1c3b20442", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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