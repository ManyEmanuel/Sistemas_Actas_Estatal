#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\CreatePysAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f81badfd87527c6705697d55bb1628d685b5531"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TRecepcionPaquetes_CreatePysAdmin), @"mvc.1.0.view", @"/Areas/Admin/Views/TRecepcionPaquetes/CreatePysAdmin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f81badfd87527c6705697d55bb1628d685b5531", @"/Areas/Admin/Views/TRecepcionPaquetes/CreatePysAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_TRecepcionPaquetes_CreatePysAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/AdminCausalesPys.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\CreatePysAdmin.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Views/Shared/_Layout.cshtml";
    IEnumerable<SelectListItem> Municipio = ViewBag.ListaMunicipio;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card card-purple"">
            <div class=""card-header"">
                <h3 class=""card-title"">Registro de las causales de la elección de Presidencia y Sindicatura en el Estado de Nayarit</h3>
            </div>
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-md-2"">
                        <label for=""Municipios"">Municipio</label>
                        ");
#nullable restore
#line 19 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\TRecepcionPaquetes\CreatePysAdmin.cshtml"
                   Write(Html.DropDownList("Municipio", Municipio, "-Seleccione un Municipio-", new { @class = "form-control", @id = "Municipios" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
                    </div>
                   
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"" id=""Prueba"">
    <div class=""card card-purple"">
        <div class=""card-header"">
            <h3 class=""card-title"">Lista de causales en la elección de Presidencia y Sindicatura</h3>
        </div>
        <div class=""card-body"">
            <table id=""tblcaulectura"" class=""table table-hover table-bordered text-center"">
                <thead>
                    <tr>
                        <th class=""text-center"">Sección</th>
                        <th class=""text-center"">Casilla</th>
                        <th class=""text-center"">Causal No. 1</th>
                        <th class=""text-center"">Causal No. 2</th>
                        <th class=""text-center"">Causal No. 3</th>
                        <th class=""text-center"">Causal No. 4</th>
                        <th class=""text-center"">Causal No. 5</th>
                        <th cl");
            WriteLiteral(@"ass=""text-center"">Causal No. 6</th>
                        <th class=""text-center"">Causal No. 7</th>
                        <th class=""text-center"">Causal No. 8</th>
                        <th class=""text-center"">Causal No. 9</th>
                        <th class=""text-center"">Causal No. 10</th>
                        <th class=""text-center"">Causal No. 11</th>
                        <th class=""text-center"">Número de Causales</th>
                        <th class=""text-center"">Id</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</div>
<div id=""VistaParcial"" class=""col-md-12"">

</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f81badfd87527c6705697d55bb1628d685b55316873", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
