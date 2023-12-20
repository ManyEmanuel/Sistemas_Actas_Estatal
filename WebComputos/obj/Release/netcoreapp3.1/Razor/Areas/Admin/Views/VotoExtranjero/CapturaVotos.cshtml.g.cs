#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4497a4ac282b4785d03c62481832cadafae11606"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_VotoExtranjero_CapturaVotos), @"mvc.1.0.view", @"/Areas/Admin/Views/VotoExtranjero/CapturaVotos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4497a4ac282b4785d03c62481832cadafae11606", @"/Areas/Admin/Views/VotoExtranjero/CapturaVotos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_VotoExtranjero_CapturaVotos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebComputos.Models.ViewModels.T_Votos_Actas_Extranjero_VM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CapturaVotos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Resultados.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
  
    IEnumerable<T_Partido> Lpar = ViewBag.partido;
    IEnumerable<T_Combinacion> Lcom = ViewBag.combinacion;
    IEnumerable<T_Detalle_Votos_Ext> Lres = ViewBag.Resact;
    IEnumerable<T_Votos_Acta_Ext> Lreg = ViewBag.Registro;
    ViewData["Title"] = "Votos en el Extranjero";
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
        width: 75px;
        height: 75px;
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
                <h3 class=""card");
            WriteLiteral("-title\"> Registro de votos</h3>\r\n            </div>\r\n");
#nullable restore
#line 65 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
             if (Lpar.Count() > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4497a4ac282b4785d03c62481832cadafae116066552", async() => {
                WriteLiteral("\r\n                    <div class=\"card-body\">\r\n                        <div class=\"row\">\r\n");
#nullable restore
#line 70 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                              
                                int contador = 0;
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                             foreach (var Resultado in Model.DetalleVotosExt)
                            {
                                if (Resultado.IdPartido != 0)
                                {
                                    var partido = Lpar.FirstOrDefault(x => x.Id == Resultado.IdPartido && x.Independiente == false);

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <div class=\"col-md-2\">\r\n                                        <div class=\"card externo border\">\r\n                                            <div id=\"centrador\">\r\n                                                <img");
                BeginWriteAttribute("src", " src=\"", 2393, "\"", 2428, 1);
#nullable restore
#line 81 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
WriteAttributeValue("", 2399, Url.Content(partido.LogoURL), 2399, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"imagen\" />\r\n                                            </div>\r\n                                            <div class=\"card-body\">\r\n                                                ");
#nullable restore
#line 84 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                           Write(Html.TextBoxFor(x => x.DetalleVotosExt[contador].Votos, new { @type = "number", @class = "form-control text-center" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                ");
#nullable restore
#line 85 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                           Write(Html.HiddenFor(x => x.DetalleVotosExt[contador].IdPartido));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                ");
#nullable restore
#line 86 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                           Write(Html.HiddenFor(x => x.DetalleVotosExt[contador].Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 90 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                }
                                contador++;
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\r\n                        <br />\r\n                        \r\n");
#nullable restore
#line 96 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                         if (Model.DetalleVotosExt.Where(x => x.IdCoalicion != 0).Count() != 0)
                        {



#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <div class=""card bg-gradient-gray"">
                                <div class=""card-body"">
                                    <h5 class=""card-text text-center"">Coaliciones</h5>
                                </div>
                            </div>
                            <br />
                            <div class=""row"">
");
#nullable restore
#line 107 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                  
                                    int contador1 = 0;
                                

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 111 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                 foreach (var Combi in Model.DetalleVotosExt)
                                {
                                    if (Combi.IdCombinacion != 0)
                                    {
                                        var coalicion = Lcom.FirstOrDefault(x => x.Id == Combi.IdCombinacion);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                        <div class=""col-md-2"">
                                            <div class=""card externo border"">
                                                <div id=""centrador"">
                                                    <img");
                BeginWriteAttribute("src", " src=\"", 4519, "\"", 4556, 1);
#nullable restore
#line 119 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
WriteAttributeValue("", 4525, Url.Content(coalicion.LogoURL), 4525, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"imagenc\" />\r\n                                                </div>\r\n                                                <div class=\"card-body\">\r\n");
                WriteLiteral("                                                    ");
#nullable restore
#line 123 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                               Write(Html.TextBoxFor(x => x.DetalleVotosExt[contador1].Votos, new { @type = "number", @class = "form-control text-center" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    ");
#nullable restore
#line 124 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                               Write(Html.HiddenFor(x => x.DetalleVotosExt[contador1].IdCombinacion));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    ");
#nullable restore
#line 125 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                               Write(Html.HiddenFor(x => x.DetalleVotosExt[contador1].IdCoalicion));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    ");
#nullable restore
#line 126 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                               Write(Html.HiddenFor(x => x.DetalleVotosExt[contador1].Id));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                </div>
                                            </div>


                                            <p class=""text-center"">

                                            </p>
                                            <p class=""text-center"">
                                        </div>
");
#nullable restore
#line 136 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"

                                    }
                                    contador1++;

                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </div>\r\n");
#nullable restore
#line 142 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <br />
                        <div class=""card bg-gradient-gray"">

                        </div>
                        <div class=""row"">
                            <div class=""col-md-2"">
                                <div class=""card border"">
                                    <div class=""card-body"">
                                        <p class=""text-center"">Candidatos no registrados</p>
                                        ");
#nullable restore
#line 152 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                   Write(Html.HiddenFor(x => x.Votos_Ext.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        ");
#nullable restore
#line 153 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                   Write(Html.TextBoxFor(x => x.Votos_Ext.NoRegistrados, new { @type = "number", @class = "form-control text-center" }));

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
#line 162 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                   Write(Html.HiddenFor(x => x.Votos_Ext.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        ");
#nullable restore
#line 163 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                   Write(Html.TextBoxFor(x => x.Votos_Ext.Nulos, new { @type = "number", @class = "form-control text-center" }));

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
#line 172 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                   Write(Html.HiddenFor(x => x.Votos_Ext.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        ");
#nullable restore
#line 173 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
                                   Write(Html.TextBoxFor(x => x.Votos_Ext.Total, new { @type = "number", @class = "form-control text-center" }));

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
                            <input class=""btn btn-success btn-lg rounded"" type=""submit"" value=""Guardar votos"" />


                        </div>
                    </div>
                ");
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 186 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\VotoExtranjero\CapturaVotos.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n<style>\r\n    input[type=number]::-webkit-inner-spin-button, input[type=number]::-webkit-outer-spin-button {\r\n        -webkit-appearance: none;\r\n        margin: 0;\r\n    }\r\n</style>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4497a4ac282b4785d03c62481832cadafae1160621788", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebComputos.Models.ViewModels.T_Votos_Actas_Extranjero_VM> Html { get; private set; }
    }
}
#pragma warning restore 1591
