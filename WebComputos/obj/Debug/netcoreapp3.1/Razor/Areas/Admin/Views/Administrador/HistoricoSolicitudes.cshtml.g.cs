#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Administrador\HistoricoSolicitudes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ae97b2e851f5e1a296c0add81f48195e3a75661"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Administrador_HistoricoSolicitudes), @"mvc.1.0.view", @"/Areas/Admin/Views/Administrador/HistoricoSolicitudes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ae97b2e851f5e1a296c0add81f48195e3a75661", @"/Areas/Admin/Views/Administrador/HistoricoSolicitudes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Administrador_HistoricoSolicitudes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-responsive/css/responsive.bootstrap4.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables/jquery.dataTables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-responsive/js/dataTables.responsive.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-responsive/js/responsive.bootstrap4.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Administrador\HistoricoSolicitudes.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ae97b2e851f5e1a296c0add81f48195e3a756616504", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2ae97b2e851f5e1a296c0add81f48195e3a756616766", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2ae97b2e851f5e1a296c0add81f48195e3a756617945", async() => {
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
                WriteLiteral("\r\n");
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
            WriteLiteral(@"
<br />
<style>
    .centrar {
        justify-content: center;
        align-items: center;
    }

    .centrar {
        justify-content: center;
        align-items: center;
    }

    table.dataTable tbody td {
        vertical-align: middle;
    }
</style>
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">Listado de solicitudes de restauración de causales</h3>
            </div>
            <div class=""card-body"">
                <table id=""tblSolicitud"" class=""table table-hover table-bordered text-center"">
                    <thead>
                        <tr>
                            <th class=""text-center"">Sección</th>
                            <th class=""text-center"">Casilla</th>
                            <th class=""text-center"">Elección</th>
                            <th class=""text-center"">Fecha de Solicitud</th>
                            <th class=""text-ce");
            WriteLiteral(@"nter"">Opciones</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>

<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">Listado Historico de casillas restablecidas</h3>
            </div>
            <div class=""card-body"">
                <table id=""tblhistorico"" class=""table table-hover table-bordered text-center"">
                    <thead>
                        <tr>
                            <th class=""text-center"">Sección</th>
                            <th class=""text-center"">Casilla</th>
                            <th class=""text-center"">Elección</th>
                            <th class=""text-center"">Fecha Solicitud</th>
                            <th class=""text-center"">Fecha Resolución</th>
                            <th class=""text-center"">Resolución</th>

                       ");
            WriteLiteral(" </tr>\r\n                    </thead>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            CargarDatatable();
            CargarDatatable2();
        });

        function Aceptar(id) {
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'mr-2 btn btn-danger'
                },
                buttonsStyling: false,
            })

            swalWithBootstrapButtons.fire({
                title: 'Esta seguro de restablecer las causales a esta casilla',
                text: ""Una vez aplicado, la casilla mostrara las causales previas a subsanarlas"",
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Si, Restablecer!',
                cancelButtonText: 'No, Cancelar!',
                reverseButtons: true
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        t");
                WriteLiteral(@"ype: 'POST',
                        url: ""/Admin/Administrador/AceptarSolicitud"",
                        data: {
                            id: id
                        },
                        success: function (data) {
                            if (data.success) {
                                toastr.success(data.mensaje);
                                window.setTimeout(Refresco, 3000);
                            } else {
                                toastr.error(data.mensaje);
                            }
                        }
                    })
                }
            })
        }

        function Rechazar(id) {
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'mr-2 btn btn-danger'
                },
                buttonsStyling: false,
            })

            swalWithBootstrapButtons.fire({
                title:");
                WriteLiteral(@" 'Esta seguro de rechazar la solicitud de esta casilla',
                text: ""Una vez rechazado, la casilla mantendra la misma configuración"",
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Si!',
                cancelButtonText: 'No!',
                reverseButtons: true
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        type: 'POST',
                        url: ""/Admin/Administrador/CancelarSolicitud"",
                        data: {
                            id: id
                        },
                        success: function (data) {
                            if (data.success) {
                                toastr.success(data.mensaje);
                                window.setTimeout(Refresco, 3000);
                            } else {
                                toastr.error(data.mensaje);
                            }
       ");
                WriteLiteral(@"                 }
                    })
                }
            })
        }


        function VerCausal() {
            var a = arguments[0];
            $(""#VistaParcial"").load('VistaHistoria/?id=' + a , function () {
                $(""#ModalDetalle"").modal({ show: true, backdrop: 'static', keyboard: false })
            });
        }

        function CargarDatatable() {
            dataTable = $(""#tblhistorico"").DataTable({
                ""responsive"": true,
                ""autoWidth"": false,
                ""ajax"": {
                    ""url"": ""/admin/Administrador/CargarHistorico/"",
                    ""type"": ""GET"",
                    ""datatype"": ""json"",
                },
                ""columns"": [
                    { ""data"": ""lCasilla.lSeccion.seccion"", ""width"": ""15%"" },
                    { ""data"": ""lCasilla.nombre"", ""width"": ""15%"" },
                    { ""data"": ""lTipo_Eleccion.nombre"", ""width"": ""15%"" },
                    { ""data"": ""fechaHora"",
     ");
                WriteLiteral(@"                   ""render"": function (data) {
                            return moment(data).format('DD/MM/YYYY HH:mm');
                        },
                        ""width"": ""20%""
                    },
                    {
                        ""data"": ""fechaHoraRespuesta"",
                        ""render"": function (data) {
                            return moment(data).format('DD/MM/YYYY HH:mm');
                        }, ""width"": ""20%""
                    },
                    {
                        ""data"": ""estatus"",
                        ""render"": function (data, type, row) {
                            if (row.estatus == true) {
                                return `<button type='button' class='btn  btn-success btn-sm' <a><i class='fas fa-check'></i></a> Aceptada</button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' <a><i class='fas fa-times'></i></a> Rechazada</button>`;
     ");
                WriteLiteral(@"                       };
                        }, ""width"": ""15%""
                    }
                ],
                ""language"": {
                    ""decimal"": "","",
                    ""emptyTable"": ""No hay registros"",
                    ""info"": ""Mostrando _START_ a _END_ de _TOTAL_ Entradas"",
                    ""infoEmpty"": ""Mostrando 0 de 0 Entradas"",
                    ""infoFiltered"": ""(Filtrado de _MAX_ total entradas)"",
                    ""infoPostFix"": """",
                    ""thousands"": "","",
                    ""lengthMenu"": ""Mostrar _MENU_ Entradas"",
                    ""loadingRecords"": ""Cargando..."",
                    ""processing"": ""Procesando..."",
                    ""search"": ""Buscar:"",
                    ""zeroRecords"": ""Sin resultados encontrados"",
                    ""paginate"": {
                        ""first"": ""Primero"",
                        ""last"": ""Ultimo"",
                        ""next"": ""Siguiente"",
                        ""previous"": ""Anterior""
");
                WriteLiteral(@"                    },
                    ""width"": ""100%""
                }
            });
        }

        function CargarDatatable2() {
            dataTable = $(""#tblSolicitud"").DataTable({
                ""responsive"": true,
                ""autoWidth"": false,
                ""ajax"": {
                    ""url"": ""/admin/Administrador/CargarSolicitudes/"",
                    ""type"": ""GET"",
                    ""datatype"": ""json"",
                },
                ""columns"": [
                    { ""data"": ""lCasilla.lSeccion.seccion"", ""width"": ""20%"" },
                    { ""data"": ""lCasilla.nombre"", ""width"": ""20%"" },
                    { ""data"": ""lTipo_Eleccion.nombre"", ""width"": ""20%"" },
                    {
                        ""data"": ""fechaHora_Solicitud"",
                        ""render"": function (data) {
                            return moment(data).format('DD/MM/YYYY HH:mm');
                        },
                        ""width"": ""20%""
                    },
                WriteLiteral(@"
                    {
                        ""data"": ""id"",
                        ""render"": function (data) {
                            return `                            
                             <button type='button' class='btn btn-success text-white' style='cursor:pointer; width:120px;' onclick='Aceptar(${data})'>
                                Aceptar
                                </button>
                                &nbsp
                                <button type='button' class='btn btn-danger text-white' style='cursor:pointer; width:120px;' onclick='Rechazar(${data})'>
                                Rechazar
                                </button>`;

                        }, ""width"": ""40%""
                    }
                ],
                ""language"": {
                    ""decimal"": "","",
                    ""emptyTable"": ""No hay registros"",
                    ""info"": ""Mostrando _START_ a _END_ de _TOTAL_ Entradas"",
                    ""infoEmpty"": ""Mo");
                WriteLiteral(@"strando 0 de 0 Entradas"",
                    ""infoFiltered"": ""(Filtrado de _MAX_ total entradas)"",
                    ""infoPostFix"": """",
                    ""thousands"": "","",
                    ""lengthMenu"": ""Mostrar _MENU_ Entradas"",
                    ""loadingRecords"": ""Cargando..."",
                    ""processing"": ""Procesando..."",
                    ""search"": ""Buscar:"",
                    ""zeroRecords"": ""Sin resultados encontrados"",
                    ""paginate"": {
                        ""first"": ""Primero"",
                        ""last"": ""Ultimo"",
                        ""next"": ""Siguiente"",
                        ""previous"": ""Anterior""
                    },
                    ""width"": ""100%""
                }
            });
        }



        function Refresco() {
            window.location.reload(true);
        }

    </script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ae97b2e851f5e1a296c0add81f48195e3a7566121926", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ae97b2e851f5e1a296c0add81f48195e3a7566123026", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ae97b2e851f5e1a296c0add81f48195e3a7566124126", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ae97b2e851f5e1a296c0add81f48195e3a7566125226", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
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