#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\GobernadorMunicipioAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f95889a332a425c576de63b4f1a72a0675504c69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ConsultaResultados_GobernadorMunicipioAdmin), @"mvc.1.0.view", @"/Areas/Admin/Views/ConsultaResultados/GobernadorMunicipioAdmin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f95889a332a425c576de63b4f1a72a0675504c69", @"/Areas/Admin/Views/ConsultaResultados/GobernadorMunicipioAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_ConsultaResultados_GobernadorMunicipioAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\GobernadorMunicipioAdmin.cshtml"
  
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
#line 19 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\GobernadorMunicipioAdmin.cshtml"
                   Write(Html.DropDownList("Municipio", Municipio, "-Seleccione un Municipio-", new { @class = "form-control", @id = "Municipios" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div id=\"VistaParcial\" class=\"col-md-12\">\r\n\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            Cargar();
        });

        function Cargar() {
            $(""#Municipios"").change(function () {
                var a = document.getElementById(""Municipios"").value;
                $(""#VistaParcial"").load(`VistaGobernadorAdminMunicipio/${a}`)

            })
        }

    </script>

");
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
