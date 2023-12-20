var datatable;

$(document).ready(function () {
    //CargarDatatable();
    Administrador();
    AdministradorDem();
    VerTabla();
});

function VerTabla() {
    var tablA = document.getElementById("tblActasReg");
    tablA.style.visibility = "hidden";

}


function CargarDatatable() {
    dataTable = $("#tblActasReg").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": "/admin/TResultadosActas/CargaTabReg",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "seccion", "width": "10%" },
            { "data": "casilla", "width": "10%" },
            { "data": "idreg", "width": "10%", "visible": false },

            {
                "data": "idreg",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/TResultadosActas/DetalleResultado/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-list'></i> Ver detalle
                            </a>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "decimal": ",",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 de 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            },
            "width": "100%"
        }
    });
}

function Administrador() {
    $("#Municipios").change(function () {

        var url = "/admin/TResultadosActas/DemarcacionAdmin";
        var b = document.getElementById("Municipios").value;
        $.getJSON(url, { demarcacion: b }, function (data) {
            var items = '';
            $("#Demarcaciones").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#Demarcaciones").html(items);
            document.getElementById("Demarcaciones").focus();
            var a = document.getElementById("Demarcaciones").value;
            table = $('#tblActasReg').DataTable();
            table.destroy();
            var tablA = document.getElementById("tblActasReg");
            tablA.style.visibility = "visible";
            dataTable = $("#tblActasReg").DataTable({
                "responsive": true,
                "autoWidth": false,
                "ajax": {
                    "url": "/admin/TResultadosActas/CargaTabRegAdmin",
                    "type": "GET",
                    "datatype": "json",
                    "data": { id: a }
                },
                "columns": [
                    { "data": "seccion", "width": "10%" },
                    { "data": "casilla", "width": "10%" },
                    { "data": "idreg", "width": "10%", "visible": false },

                    {
                        "data": "idreg",
                        "render": function (data) {
                            return `<div class="text-center">
                            <a href='/Admin/TResultadosActas/DetalleResultado/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-list'></i> Ver detalle
                            </a>`;
                        }, "width": "30%"
                    }
                ],
                "language": {
                    "decimal": ",",
                    "emptyTable": "No hay registros",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 de 0 Entradas",
                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    },
                    "width": "100%"
                }
            });
        })
    });
}

function AdministradorDem() {
    $("#Demarcaciones").change(function () {
        var a = document.getElementById("Demarcaciones").value;
        table = $('#tblActasReg').DataTable();
        table.destroy();
        dataTable = $("#tblActasReg").DataTable({
            "responsive": true,
            "autoWidth": false,
            "ajax": {
                "url": "/admin/TResultadosActas/CargaTabRegAdmin",
                "type": "GET",
                "datatype": "json",
                "data": { id: a }
            },
            "columns": [
                { "data": "seccion", "width": "10%" },
                { "data": "casilla", "width": "10%" },
                { "data": "idreg", "width": "10%", "visible": false },

                {
                    "data": "idreg",
                    "render": function (data) {
                        return `<div class="text-center">
                            <a href='/Admin/TResultadosActas/DetalleResultado/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-list'></i> Ver detalle
                            </a>`;
                    }, "width": "30%"
                }
            ],
            "language": {
                "decimal": ",",
                "emptyTable": "No hay registros",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                "infoEmpty": "Mostrando 0 de 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar:",
                "zeroRecords": "Sin resultados encontrados",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                },
                "width": "100%"
            }
        });

    });
}


function CargaCasillaReg() {
    $("#SeccionGob").change(function () {
        var url = "/admin/TResultadosActas/CasillaGob";
        var b = document.getElementById("SeccionGob").value;
        $.getJSON(url, { seccion: b }, function (data) {
            var items = '';
            $("#Gobernador").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#Gobernador").html(items);
            document.getElementById("Gobernador").focus();

        })
    });

}