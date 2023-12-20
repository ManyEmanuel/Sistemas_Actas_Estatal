#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a8ce1d0d20e886c511a72093d4952d8722d8c6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ConsultaResultados_RegidorMunicipio), @"mvc.1.0.view", @"/Areas/Admin/Views/ConsultaResultados/RegidorMunicipio.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a8ce1d0d20e886c511a72093d4952d8722d8c6a", @"/Areas/Admin/Views/ConsultaResultados/RegidorMunicipio.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_ConsultaResultados_RegidorMunicipio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
  
    ViewData["Title"] = "Causales";
    Layout = "~/Views/Shared/_Layout.cshtml";
    IEnumerable<T_Partido> Lpar = ViewBag.Partido;
    IEnumerable<T_Combinacion> Lcom = ViewBag.Combinacion;
    //IEnumerable<T_Coalicion> Lcoa = ViewBag.Coalicion;
    List<ElementosListas> LResActa = ViewBag.ResultadosActas;
    //List<ElementosListas> LResActor = ViewBag.ResultadosActor;
    IEnumerable<T_Votos_Acta> Lreg = ViewBag.ResultadosCabecera;
    //IEnumerable<T_Detalle_Votos_Acta_Partido> LrePar = ViewBag.ResultadosDistribucion;
    //int resli = 0;
    //if (LrePar == null)
    //{
    //    resli = 0;
    //}
    //else
    //{
    //    resli = LrePar.Count();
    //}

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
                <h3 class=""card-title""> Resultados de l");
            WriteLiteral("a elección de Regidor del municipio de ");
#nullable restore
#line 73 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                                                                                         Write(ViewBag.Municipio);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n            </div>\r\n            <div class=\"card-body\">\r\n");
#nullable restore
#line 76 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                 if (LResActa.Count != 0)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""card bg-gradient-gray"">
                        <div class=""card-body"">
                            <h5 class=""card-text text-center"">Distribución total de votos</h5>
                        </div>
                    </div>
");
            WriteLiteral("                    <div class=\"row\">\r\n");
#nullable restore
#line 86 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                         foreach (var actas in LResActa)
                        {
                            if (actas.Partido != 0)
                            {
                                var partido = Lpar.FirstOrDefault(x => x.Id == actas.Partido);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col-md-2\">\r\n                                    <div class=\"card externo border\">\r\n                                        <div id=\"centrador\">\r\n");
#nullable restore
#line 94 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                                             if (partido.Siglas == "MORENA")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <img");
            BeginWriteAttribute("src", " src=\"", 2846, "\"", 2881, 1);
#nullable restore
#line 96 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
WriteAttributeValue("", 2852, Url.Content(partido.LogoURL), 2852, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"imagenx\" />\r\n");
#nullable restore
#line 97 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <img");
            BeginWriteAttribute("src", " src=\"", 3096, "\"", 3131, 1);
#nullable restore
#line 100 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
WriteAttributeValue("", 3102, Url.Content(partido.LogoURL), 3102, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"imagen\" />\r\n");
#nullable restore
#line 101 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </div>\r\n                                        <div class=\"card-body\">\r\n                                            ");
#nullable restore
#line 105 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                                       Write(Html.TextBox(actas.Votos.ToString(), actas.Votos, new { @type = "number", @class = "form-control text-center", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 109 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"

                            }
                            else if (actas.Independiente != 0)
                            {
                                var partido = Lpar.FirstOrDefault(x => x.Independiente == true && x.Id == actas.Independiente);



#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col-md-2\">\r\n                                    <div class=\"card externo border\">\r\n                                        <div id=\"centrador\">\r\n                                            <img");
            BeginWriteAttribute("src", " src=\"", 4124, "\"", 4159, 1);
#nullable restore
#line 119 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
WriteAttributeValue("", 4130, Url.Content(partido.LogoURL), 4130, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"imagen\" />\r\n                                        </div>\r\n                                        <div class=\"card-body\">\r\n                                            ");
#nullable restore
#line 122 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                                       Write(Html.TextBox(actas.Votos.ToString(), actas.Votos, new { @type = "number", @class = "form-control text-center", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 126 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                            }
                            else if (actas.Coalicion != 0)
                            {
                                var com = Lcom.FirstOrDefault(x => x.Id == actas.Combinacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col-md-2\">\r\n                                    <div class=\"card externo border\">\r\n                                        <div id=\"centrador\">\r\n                                            <img");
            BeginWriteAttribute("src", " src=\"", 5060, "\"", 5091, 1);
#nullable restore
#line 133 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
WriteAttributeValue("", 5066, Url.Content(com.LogoURL), 5066, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"imagenc\" />\r\n                                        </div>\r\n                                        <div class=\"card-body\">\r\n                                            ");
#nullable restore
#line 136 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                                       Write(Html.TextBox(actas.Votos.ToString(), actas.Votos, new { @type = "number", @class = "form-control text-center", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 140 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"

                            }

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"row\">\r\n");
#nullable restore
#line 147 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                         foreach (var resa in Lreg)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""col-md-2"">
                                <div class=""card border"">
                                    <div class=""card-body"">
                                        <p class=""text-center""> Candidatos no registrados </p>
                                        ");
#nullable restore
#line 153 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                                   Write(Html.TextBox(resa.NoRegistrados.ToString(), resa.NoRegistrados, new { @type = "number", @class = " form-control text-center", @readonly = "readonly" }));

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
                                        <p class=""text-center""> Votos Nulos </p>
                                        ");
#nullable restore
#line 161 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                                   Write(Html.TextBox(resa.Nulos.ToString(), resa.Nulos, new { @type = "number", @class = " form-control text-center", @readonly = "readonly" }));

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
                                        <p class=""text-center""> Total de votos</p>
                                        ");
#nullable restore
#line 169 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                                   Write(Html.TextBox(resa.Total.ToString(), resa.Total, new { @type = "number", @class = "form-control text-center", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 173 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <br />\r\n");
#nullable restore
#line 355 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                       
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""alert alert-info alert-dismissible"">
                        <h5><i class=""icon fas fa-info""></i> Sin Resultados</h5>
                        Por el momento no se cuenta con los registros de resultados de esta elección
                    </div>
");
#nullable restore
#line 363 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\ConsultaResultados\RegidorMunicipio.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
