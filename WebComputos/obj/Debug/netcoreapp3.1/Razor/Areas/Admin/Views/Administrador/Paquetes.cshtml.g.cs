#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Administrador\Paquetes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8bbcb76483aa2b6efb269e48b05671d0fb7f3f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Administrador_Paquetes), @"mvc.1.0.view", @"/Areas/Admin/Views/Administrador/Paquetes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8bbcb76483aa2b6efb269e48b05671d0fb7f3f4", @"/Areas/Admin/Views/Administrador/Paquetes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Administrador_Paquetes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Administrador\Paquetes.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    IEnumerable<SelectListItem> Municipio = ViewBag.ListaMunicipio;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8bbcb76483aa2b6efb269e48b05671d0fb7f3f46501", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d8bbcb76483aa2b6efb269e48b05671d0fb7f3f46763", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d8bbcb76483aa2b6efb269e48b05671d0fb7f3f47942", async() => {
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
                <h3 class=""card-title"">Listado de solicitudes de restablecer paquetes en el Estado de Nayarit</h3>
            </div>
            <div class=""card-body"">
                <table id=""tblRecepcion"" class=""table table-hover table-bordered text-center"">
                    <thead>
                        <tr>
                            <th class=""text-center"">Sección</th>
                            <th class=""text-center"">Casilla</th>
                            <th class=""text-center"">Municipio</th>
                            <th class=""text-center"">Usuario Solicitante</th>
                        ");
            WriteLiteral(@"    <th class=""text-center"">Fecha Solicitud</th>
                            <th class=""text-center"">Opciones</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
    <div class=""col-md-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">Historial de solicitudes de restablecer paquetes en el Estado de Nayarit</h3>
            </div>
            <div class=""card-body"">
                <table id=""tblhistorial"" class=""table table-hover table-bordered text-center"">
                    <thead>
                        <tr>
                            <th class=""text-center"">Sección</th>
                            <th class=""text-center"">Casilla</th>
                            <th class=""text-center"">Municipio</th>
                            <th class=""text-center"">Usuario Solicitante</th>
                            <th class=""text-center"">Fecha Solicitud<");
            WriteLiteral(@"/th>
                            <th class=""text-center"">Fecha Resolución</th>
                            <th class=""text-center"">Resolución</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>

</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            CargarDatatable();
            CargarDatatable2();
        });

        function CargarDatatable() {
            dataTable = $(""#tblRecepcion"").DataTable({
                ""responsive"": true,
                ""autoWidth"": false,
                ""ajax"": {
                    ""url"": ""/admin/Administrador/CargarPaquetesModificacion/"",
                    ""type"": ""GET"",
                    ""datatype"": ""json"",
                },
                ""columns"": [
                    { ""data"": ""lCasilla.lSeccion.seccion"", ""width"": ""10%"" },
                    { ""data"": ""lCasilla.nombre"", ""width"": ""10%"" },                  
                    { ""data"": ""lCasilla.lSeccion.lMunicipio.municipio"", ""width"": ""10%"" },
                    {
                        ""data"": null,
                        ""render"": function (data, type, row) {
                            return row.lUsuario.nombres + ' ' + row.lUsuario.apellido_Paterno + ' ' + ro");
                WriteLiteral(@"w.lUsuario.apellido_Materno;
                        }
                    },
                    {
                        ""data"": ""fechaSolicitud"", ""render"": function (data) {
                            return moment(data).format('DD/MM/YYYY HH:mm');
                        }, ""width"": ""20%""
                    },
                    {
                        ""data"": ""paquetes"",
                        ""render"": function (data,type,row) {
                            return `
                            <button type='button' class='btn btn-success text-white' style='cursor:pointer; width:120px;' onclick='Restablecer(${row.paquetes},${row.id})'>
                            Aceptar
                            </button>
                            &nbsp
                            <button type='button' class='btn btn-danger text-white' style='cursor:pointer; width:120px;' onclick='Cancelar(${row.paquetes},${row.id})'>
                            Rechazar
                            </button>");
                WriteLiteral(@"
                            `;
                        }, ""width"": ""30%""
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
                        ""previous"": ""Anter");
                WriteLiteral(@"ior""
                    },
                    ""width"": ""100%""
                }
            });
        }

        function CargarDatatable2() {
            dataTable = $(""#tblhistorial"").DataTable({
                ""responsive"": true,
                ""autoWidth"": false,
                ""ajax"": {
                    ""url"": ""/admin/Administrador/CargarPaquetesHistorial/"",
                    ""type"": ""GET"",
                    ""datatype"": ""json"",
                },
                ""columns"": [
                    { ""data"": ""lCasilla.lSeccion.seccion"", ""width"": ""10%"" },
                    { ""data"": ""lCasilla.nombre"", ""width"": ""10%"" },
                    { ""data"": ""lCasilla.lSeccion.lMunicipio.municipio"", ""width"": ""10%"" },
                    {
                        ""data"": null,
                        ""render"": function (data, type, row) {
                            return row.lUsuario.nombres + ' ' + row.lUsuario.apellido_Paterno + ' ' + row.lUsuario.apellido_Materno;
           ");
                WriteLiteral(@"             }
                    },
                    {
                        ""data"": ""fechaSolicitud"", ""render"": function (data) {
                            return moment(data).format('DD/MM/YYYY HH:mm');
                        }, ""width"": ""15%""
                    },
                    {
                        ""data"": ""fechaAprobacion"", ""render"": function (data) {
                            return moment(data).format('DD/MM/YYYY HH:mm');
                        }, ""width"": ""15%""
                    },
                    {
                        ""data"": ""estatus"",
                        ""render"": function (data, type, row) {
                            if (row.estatus == 1) {
                                return `<button type='button' class='btn  btn-success btn-sm' <a><i class='fas fa-check'></i></a> Aceptada</button>`;
                            } else if(row.estatus == 2) {
                                return `<button type='button' class='btn  btn-danger btn-sm' <a><");
                WriteLiteral(@"i class='fas fa-times'></i></a> Rechazada</button>`;
                            };
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
                        ""next"": ""Si");
                WriteLiteral(@"guiente"",
                        ""previous"": ""Anterior""
                    },
                    ""width"": ""100%""
                }
            });
        }

        function Restablecer(paquete,historial) {
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'mr-2 btn btn-danger'
                },
                buttonsStyling: false,
            })

            swalWithBootstrapButtons.fire({
                title: 'Esta seguro en restablecer el paquete de esta casilla',
                text: ""Una vez aplicado, los cambios se perdera la informacion!"",
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Si, Restablecer!',
                cancelButtonText: 'No, Cancelar!',
                reverseButtons: true
            }).then((result) => {
                if (result.value) {
                    $");
                WriteLiteral(@".ajax({
                        type: 'POST',
                        url: ""/Admin/Administrador/RestablecerPaquete"",
                        data: {
                            idPaquete: paquete,
                            idHistorial: historial
                        },
                        success: function (data) {
                            if (data.success) {
                                toastr.success(data.mensaje);
                                window.setTimeout(Refresco, 2000);
                            } else {
                                toastr.error(data.mensaje);
                            }
                        }
                    })
                }
            })
        }

        function Cancelar(paquete, historial) {
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'mr-2 btn btn-danger'
                },
        ");
                WriteLiteral(@"        buttonsStyling: false,
            })

            swalWithBootstrapButtons.fire({
                title: 'Esta seguro de cancelar la solicitud del Paquete Electoral',
                text: ""Una vez aplicado, el paquete seguira registrado!"",
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Si, Cancelar!',
                cancelButtonText: 'No',
                reverseButtons: true
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        type: 'POST',
                        url: ""/Admin/Administrador/CancelarSolicitudPaquete"",
                        data: {
                            idPaquete: paquete,
                            idHistorial: historial
                        },
                        success: function (data) {
                            if (data.success) {
                                toastr.success(data.mensaje);
               ");
                WriteLiteral(@"                 window.setTimeout(Refresco, 2000);
                            } else {
                                toastr.error(data.mensaje);
                            }
                        }
                    })
                }
            })
        }

        function Refresco() {
            window.location.reload(true);
        }
    </script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8bbcb76483aa2b6efb269e48b05671d0fb7f3f422606", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8bbcb76483aa2b6efb269e48b05671d0fb7f3f423706", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8bbcb76483aa2b6efb269e48b05671d0fb7f3f424806", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8bbcb76483aa2b6efb269e48b05671d0fb7f3f425906", async() => {
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
