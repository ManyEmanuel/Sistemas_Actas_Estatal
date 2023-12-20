#pragma checksum "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Administrador\CausalesDiputado.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "409eb4825ee3f4b2ec60550d7bc909a90dfacf18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Administrador_CausalesDiputado), @"mvc.1.0.view", @"/Areas/Admin/Views/Administrador/CausalesDiputado.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"409eb4825ee3f4b2ec60550d7bc909a90dfacf18", @"/Areas/Admin/Views/Administrador/CausalesDiputado.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Administrador_CausalesDiputado : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Administrador\CausalesDiputado.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Views/Shared/_Layout.cshtml";
    IEnumerable<SelectListItem> Distrito = ViewBag.ListaDistrito;
   


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
<div class=""row"" id=""ParaBloq"">
    <div class=""col-md-12"">
        <div class=""card card-purple"">
            <div class=""card-header"">
                <h3 class=""card-title"">Registro de las causales de la elección de Diputaciones en el Estado de Nayarit</h3>
            </div>
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-md-2"">
                        <label for=""Municipios"">Distrito</label>
                        ");
#nullable restore
#line 20 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Administrador\CausalesDiputado.cshtml"
                   Write(Html.DropDownList("Distrito", Distrito, "-Seleccione un Distrito-", new { @class = "form-control", @id = "Distritos" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    </div>\r\n                   \r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"row\" id=\"Prueba\">\r\n");
#nullable restore
#line 29 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Administrador\CausalesDiputado.cshtml"
     if (User.IsInRole("Admin"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""card card-purple"">
            <div class=""card-header"">
                <h3 class=""card-title"">Lista de causales en la elección de Diputaciones</h3>
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
                            <th class=""text-center"">Causal No. 6</th>
                            <th class=""text-center"">Causal No. 7</th>
         ");
            WriteLiteral(@"                   <th class=""text-center"">Causal No. 8</th>
                            <th class=""text-center"">Causal No. 9</th>
                            <th class=""text-center"">Causal No. 10</th>
                            <th class=""text-center"">Causal No. 11</th>
                            <th class=""text-center"">Número de Causales</th>
                            <th class=""text-center"">Opciones</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
");
#nullable restore
#line 59 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Administrador\CausalesDiputado.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Administrador\CausalesDiputado.cshtml"
     if (User.IsInRole("IEEN"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""card card-purple"">
            <div class=""card-header"">
                <h3 class=""card-title"">Lista de causales en la elección de Diputaciones</h3>
            </div>
            <div class=""card-body"">
                <table id=""tblcauIEEN"" class=""table table-hover table-bordered text-center"">
                    <thead>
                        <tr>
                            <th class=""text-center"">Sección</th>
                            <th class=""text-center"">Casilla</th>
                            <th class=""text-center"">Causal No. 1</th>
                            <th class=""text-center"">Causal No. 2</th>
                            <th class=""text-center"">Causal No. 3</th>
                            <th class=""text-center"">Causal No. 4</th>
                            <th class=""text-center"">Causal No. 5</th>
                            <th class=""text-center"">Causal No. 6</th>
                            <th class=""text-center"">Causal No. 7</th>
            ");
            WriteLiteral(@"                <th class=""text-center"">Causal No. 8</th>
                            <th class=""text-center"">Causal No. 9</th>
                            <th class=""text-center"">Causal No. 10</th>
                            <th class=""text-center"">Causal No. 11</th>
                            <th class=""text-center"">Número de Causales</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
");
#nullable restore
#line 89 "C:\Users\PC-INFORMATICA\Documents\GitHub\Sistema_Actas\WebComputos\Areas\Admin\Views\Administrador\CausalesDiputado.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<div id=\"VistaParcial\" class=\"col-md-12\">\r\n\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
    var datatable;

    $(document).ready(function () {
        Cargar();
        Cargar2();
        var tablA = document.getElementById(""Prueba"");
        tablA.style.visibility = ""hidden"";

    });

    function Seleccionar(id) {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'mr-2 btn btn-danger'
            },
            buttonsStyling: false,
        })

        swalWithBootstrapButtons.fire({
            title: 'Esta seguro en subsanar las causales de esta casilla',
            text: ""Una vez aplicado, los cambios afectan a Computos!"",
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Si, Subsanar!',
            cancelButtonText: 'No, Cancelar!',
            reverseButtons: true
        }).then((result) => {
            if (result.value) {
                bloqueo();
                $.ajax({
           ");
                WriteLiteral(@"         type: 'POST',
                    url: ""/Admin/Administrador/SubsanarCausal"",
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

    function Refresco() {
        window.location.reload(true);
    }

    function bloqueo() {
        $('#ParaBloq button').attr('disabled', 'disabled');
    }

    function Cargar() {
        $(""#Distritos"").change(function () {
            var tablA = document.getElementById(""Prueba"");
            tablA.style.visibility = ""visible"";
            var a = document.getElementById(""Distritos"").value;
            $(""#Vista");
                WriteLiteral(@"Parcial"").load(`CausalesDipAdmin/${a}`)
            table = $('#tblcaulectura').DataTable();
            table.destroy();
            dataTable = $(""#tblcaulectura"").DataTable({
                ""responsive"": true,
                ""autoWidth"": false,
                ""ajax"": {
                    ""url"": `/admin/Administrador/CargarCauDipAdmin`,
                    ""type"": ""GET"",
                    ""datatype"": ""json"",
                    ""data"": { id: a }
                },
                ""columns"": [
                    { ""data"": ""seccion"", ""width"": ""10%"" },
                    { ""data"": ""casilla"", ""width"": ""10%"" },
                    {
                        ""data"": ""cau1"",
                        ""render"": function (data, type, row) {
                            if (row.cau1 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""El paquete electoral fue entregado con el AEC"" > <a><i clas");
                WriteLiteral(@"s='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""El paquete electoral fue entregado sin el AEC"" ><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau2"",
                        ""render"": function (data, type, row) {
                            if (row.cau2 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Votos nulos menor a la diferencia entre el 1er y 2do lugar""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" tit");
                WriteLiteral(@"le=""Votos nulos mayor a la diferencia entre el 1er y 2do lugar""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau3"",
                        ""render"": function (data, type, row) {
                            if (row.cau3 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Total de votos del sistema menor a las boletas entregadas""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Total de votos del sistema mayor a las boletas entregadas""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    ");
                WriteLiteral(@"},
                    {
                        ""data"": ""cau4"",
                        ""render"": function (data, type, row) {
                            if (row.cau4 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Total de votos del sistema igual al total de votos del AEC""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Total del votos del sistema diferente al total de votos del AEC""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau5"",
                        ""render"": function (data, type, row) {
                            if (row.cau5 == false) {
            ");
                WriteLiteral(@"                    return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Votos por mas de un partido politivo, coalición o candidato independiente""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Votos por un solo partido politico, coalición o candidato independiente""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau6"",
                        ""render"": function (data, type, row) {
                            if (row.cau6 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Acta legible""> <a><i class='fas fa-check'><");
                WriteLiteral(@"/i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Acta Ilegible""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau7"",
                        ""render"": function (data, type, row) {
                            if (row.cau7 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Acta sin alteraciones""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Acta con alteraciones""><a><i class='fas fa-times'></i></a></button>`;
             ");
                WriteLiteral(@"               }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau8"",
                        ""render"": function (data, type, row) {
                            if (row.cau8 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Paquete sin muestras de alteraciones""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Paquete con muestras de alteraciones""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau9"",
                        ""render"": function (data, type, row) {
                            if (row");
                WriteLiteral(@".cau9 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Ciudadanos que votaron igual al total de votos del sistema""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Ciudadanos que votaron diferente al total de votos del sistema""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau10"",
                        ""render"": function (data, type, row) {
                            if (row.cau10 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Boletas sobrantes mas ciudadanos q");
                WriteLiteral(@"ue votaron menor a boletas entregadas""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Boletas sobrantes mas ciudadanos que votaron mayor a boletas entregadas""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau11"",
                        ""render"": function (data, type, row) {
                            if (row.cau11 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Boletas sobrantes mas total de votos del sistema menor a boletas entregadas""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<butt");
                WriteLiteral(@"on type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Boletas sobrantes mas total de votos del sistema mayor a boletas entregadas""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    { ""data"": ""numcau"", ""width"": ""10%"", ""name"": ""Numero"" },
                    {
                        ""data"": ""idcau"",
                        ""render"": function (data, type, row) {
                            if (row.numcau != 0) {
                                return `<div class=""text-center"">
                             <button type='button' class='btn btn-info text-white' style='cursor:pointer; width:120px;' onclick='Seleccionar(${data})'>
                            Subsanar
                            </button>`;
                            }
                            else {
                                return `<div class=""text-center"">
             ");
                WriteLiteral(@"               <p class=""text-center"">Sin causales</p> </div>`;
                            }
                        },

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
                        ""next"": ""Sig");
                WriteLiteral(@"uiente"",
                        ""previous"": ""Anterior""
                    },
                    ""width"": ""100%""
                }
            });

        })
    }


    function Cargar2() {
        $(""#Distritos"").change(function () {
            var tablA = document.getElementById(""Prueba"");
            tablA.style.visibility = ""visible"";
            var a = document.getElementById(""Distritos"").value;
            $(""#VistaParcial"").load(`CausalesDipAdmin/${a}`)
            table = $('#tblcauIEEN').DataTable();
            table.destroy();
            dataTable = $(""#tblcauIEEN"").DataTable({
                ""responsive"": true,
                ""autoWidth"": false,
                ""ajax"": {
                    ""url"": `/admin/Administrador/CargarCauDipAdmin`,
                    ""type"": ""GET"",
                    ""datatype"": ""json"",
                    ""data"": { id: a }
                },
                ""columns"": [
                    { ""data"": ""seccion"", ""width"": ""10%"" },
    ");
                WriteLiteral(@"                { ""data"": ""casilla"", ""width"": ""10%"" },
                    {
                        ""data"": ""cau1"",
                        ""render"": function (data, type, row) {
                            if (row.cau1 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""El paquete electoral fue entregado con el AEC"" > <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""El paquete electoral fue entregado sin el AEC"" ><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau2"",
                        ""render"": function (data, type, row) {
                            if (row.cau2 ==");
                WriteLiteral(@" false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Votos nulos menor a la diferencia entre el 1er y 2do lugar""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Votos nulos mayor a la diferencia entre el 1er y 2do lugar""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau3"",
                        ""render"": function (data, type, row) {
                            if (row.cau3 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Total de votos del sistema menor a las boletas e");
                WriteLiteral(@"ntregadas""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Total de votos del sistema mayor a las boletas entregadas""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau4"",
                        ""render"": function (data, type, row) {
                            if (row.cau4 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Total de votos del sistema igual al total de votos del AEC""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""");
                WriteLiteral(@"tooltip"" data-placement=""top"" title=""Total del votos del sistema diferente al total de votos del AEC""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau5"",
                        ""render"": function (data, type, row) {
                            if (row.cau5 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Votos por mas de un partido politivo, coalición o candidato independiente""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Votos por un solo partido politico, coalición o candidato independiente""><a><i class='fas fa-times'></i></a></button>`;
                         ");
                WriteLiteral(@"   }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau6"",
                        ""render"": function (data, type, row) {
                            if (row.cau6 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Acta legible""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Acta Ilegible""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau7"",
                        ""render"": function (data, type, row) {
                            if (row.cau7 == false) {
                                return `");
                WriteLiteral(@"<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Acta sin alteraciones""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Acta con alteraciones""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau8"",
                        ""render"": function (data, type, row) {
                            if (row.cau8 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Paquete sin muestras de alteraciones""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button ");
                WriteLiteral(@"type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Paquete con muestras de alteraciones""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau9"",
                        ""render"": function (data, type, row) {
                            if (row.cau9 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Ciudadanos que votaron igual al total de votos del sistema""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Ciudadanos que votaron diferente al total de votos del sistema""><a><i class='fas fa-times'></i></a></button>`;
                  ");
                WriteLiteral(@"          }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau10"",
                        ""render"": function (data, type, row) {
                            if (row.cau10 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Boletas sobrantes mas ciudadanos que votaron menor a boletas entregadas""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Boletas sobrantes mas ciudadanos que votaron mayor a boletas entregadas""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    {
                        ""data"": ""cau11"",
                        ""render");
                WriteLiteral(@""": function (data, type, row) {
                            if (row.cau11 == false) {
                                return `<button type='button' class='btn  btn-success btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Boletas sobrantes mas total de votos del sistema menor a boletas entregadas""> <a><i class='fas fa-check'></i></a></button>`;
                            } else {
                                return `<button type='button' class='btn  btn-danger btn-sm' data-toggle=""tooltip"" data-placement=""top"" title=""Boletas sobrantes mas total de votos del sistema mayor a boletas entregadas""><a><i class='fas fa-times'></i></a></button>`;
                            }
                        }, ""width"": ""5%""
                    },
                    { ""data"": ""numcau"", ""width"": ""10%"", ""name"": ""Numero"" },
                  
                ],
                ""language"": {
                    ""decimal"": "","",
                    ""emptyTable"": ""No hay registros"",
                    ""in");
                WriteLiteral(@"fo"": ""Mostrando _START_ a _END_ de _TOTAL_ Entradas"",
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
                    },
                    ""width"": ""100%""
                }
            });

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