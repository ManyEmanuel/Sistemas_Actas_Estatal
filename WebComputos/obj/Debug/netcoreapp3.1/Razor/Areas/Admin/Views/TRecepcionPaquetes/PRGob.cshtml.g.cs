#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\PRGob.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b14b9b45f94c50b3ba6db4c854b01bc5eefdac44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TRecepcionPaquetes_PRGob), @"mvc.1.0.view", @"/Areas/Admin/Views/TRecepcionPaquetes/PRGob.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b14b9b45f94c50b3ba6db4c854b01bc5eefdac44", @"/Areas/Admin/Views/TRecepcionPaquetes/PRGob.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_TRecepcionPaquetes_PRGob : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/PRGob.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\PRGob.cshtml"
  
    ViewData["Title"] = "Causales";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                <h3 class=\"card-title\"> Puntos de recuento de la elección de Gobernador del municipio de ");
#nullable restore
#line 12 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\PRGob.cshtml"
                                                                                                    Write(ViewBag.Municipio);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
            </div>
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-md-2 text-center"">
                        <dl>
                            <dt> Casillas de Recuento</dt>
                            <dd id=""causal""> ");
#nullable restore
#line 19 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\PRGob.cshtml"
                                        Write(ViewBag.Causal);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</dd>
                        </dl>
                    </div>
                    <div class=""col-md-2 text-center"">
                        <dl>
                            <dt>Grupos de trabajo</dt>
                            <dd> <input type=""number"" id=""grupos"" class=""text-center""/></dd>
                        </dl>
                    </div>
                    <div class=""col-md-2 text-center"">
                        <dl>
                            <dt> Horas de captura </dt>
                            <dd> <input type=""number"" id=""horas"" class=""text-center"" /> </dd>
                        </dl>
                    </div>
                    <div class=""col-md-2 text-center"">
                        <dl>
                            <dt> Segmentos disponibles</dt>
                            <dd> Segmentos cada 30 minutos disponibles </dd>
                        </dl>
                    </div>
                    <div class=""col-md-1""></div>
                    <div class=""");
            WriteLiteral(@"col-md-2 text-center"">
                        <dl>
                            <dt> </dt>
                            <dd><input type=""button"" value=""Calcular"" class=""btn btn-primary form-control"" id=""calcular""/></dd>
                        </dl>
                    </div>
                    <div class=""col-md-1""></div>
                </div>
                <br />
                <br />
                <div class=""row"">                   
                    <div class=""col-md-6 text-center"">
                        <dl>
                            <dt><h1 id=""total""></h1></dt>
                            <dd><h5 id=""textotal""></h5></dd>
                        </dl>
                    </div>
                    <div class=""col-md-6 text-center"">
                        <dl>
                            <dt> <h1 id=""redondeo""></h1></dt>
                            <dd> <h5 id=""texredondeo""> </h5></dd>
                        </dl>
                    </div>
                </div>
 ");
            WriteLiteral(@"               <div class=""row"">
                    <div class=""col-md-12 text-center"" id=""ver"">
                        <div class=""alert alert-default-primary alert-dismissible"">                
                            <h1><i class=""icon fas fa-info""></i><strong>INFORMACIÓN</strong> </h1>
                            <h1 id=""Mensaje""></h1>
                            
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div class=""row"">

                    <div class=""col-md-3""></div>
                    <div class=""col-md-3 text-center"">
                        <table id=""tbcausal"" class=""table table-hover table-bordered text-center"" style=""display:none"">
                            <thead>
                                <tr>
                                    <th class=""text-center"">Grupo de trabajo</th>
                                    <th class=""text-center"">Puntos de recuento</th>
  ");
            WriteLiteral(@"                                  <th class=""text-center"">Casillas a capturar</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                    <div class=""col-md-1""></div>
                    <div class=""col-md-2 text-center"">
                        <h6 id=""textoc""></h6>
                        <select id=""tipo"" class=""form-control text-center"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b14b9b45f94c50b3ba6db4c854b01bc5eefdac449656", async() => {
                WriteLiteral("Propuesta");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b14b9b45f94c50b3ba6db4c854b01bc5eefdac4410846", async() => {
                WriteLiteral("Ensayo Definitivo");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </select>\r\n                        <br />\r\n                        <input type=\"button\" value=\"Guardar\" id=\"aray\" class=\"btn btn-primary form-control\" />\r\n                        <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 4579, "\"", 4608, 1);
#nullable restore
#line 100 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\PRGob.cshtml"
WriteAttributeValue("", 4587, ViewBag.Comprobacion, 4587, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"Comprobacion\" />\r\n                    </div>                  \r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b14b9b45f94c50b3ba6db4c854b01bc5eefdac4412935", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
