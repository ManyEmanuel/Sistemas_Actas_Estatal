#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipioAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "088ca52ee9c9563adcea63058e7b7b50b4f6776a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ConsultaResultados_RegidorMunicipioAdmin), @"mvc.1.0.view", @"/Areas/Admin/Views/ConsultaResultados/RegidorMunicipioAdmin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"088ca52ee9c9563adcea63058e7b7b50b4f6776a", @"/Areas/Admin/Views/ConsultaResultados/RegidorMunicipioAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_ConsultaResultados_RegidorMunicipioAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Demarcaciones"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "Demarcacion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipioAdmin.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Views/Shared/_Layout.cshtml";
    IEnumerable<SelectListItem> Municipio = ViewBag.ListaMunicipio;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card card-secondary"">
            <div class=""card-header"">
                <h3 class=""card-title"">Resultados de la elección de Gubernatura en el Estado de Nayarit</h3>
            </div>
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-md-2"">
                        <label for=""Municipios"">Municipio</label>
                        ");
#nullable restore
#line 19 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipioAdmin.cshtml"
                   Write(Html.DropDownList("Municipio", Municipio, "-Seleccione un Municipio-", new { @class = "form-control", @id = "Municipios" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    </div>\r\n                    <div class=\"col-md-2\">\r\n                        <label for=\"Demarcacion\">Demarcación:</label>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "088ca52ee9c9563adcea63058e7b7b50b4f6776a5829", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 23 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipioAdmin.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(string.Empty,"value","text"));

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div id=\"VistaParcial\" class=\"col-md-12\">\r\n\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            Cargar();
            CargarB();
        });

        function Cargar() {
            $(""#Municipios"").change(function () {
                var url = ""/admin/TResultadosActas/DemarcacionAdmin"";
                var b = document.getElementById(""Municipios"").value;
                $.getJSON(url, { demarcacion: b }, function (data) {
                    var items = '';
                    $(""#Demarcaciones"").empty();
                    $.each(data, function (j, row) {
                        items += ""<option value='"" + row.value + ""'>"" + row.text + ""</option>"";
                    });
                    $(""#Demarcaciones"").html(items);
                    var a = document.getElementById(""Demarcaciones"").value;
                    $(""#VistaParcial"").load(`VistaRegidorAdminMunicipio/${a}`)


                })
            })
        }

        function CargarB() {
            $(""#Demarcaciones"").change(function () {
   ");
                WriteLiteral("             \r\n            var a = document.getElementById(\"Demarcaciones\").value;\r\n            $(\"#VistaParcial\").load(`VistaRegidorAdminMunicipio/${a}`)\r\n\r\n\r\n                \r\n            })\r\n        }\r\n\r\n    </script>\r\n\r\n");
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