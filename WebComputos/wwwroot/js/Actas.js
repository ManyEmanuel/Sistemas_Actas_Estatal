var dataTable;

$(document).ready(function () {
    CargarDatatable2(); 
    Administrador();
});
function CargarDatatable2() {
    dataTable = $("#tblActasReg").DataTable({
        "responsive": true,
        "autoWidth":false,
        "ajax": {
            "url": "/admin/TActas/CargarReg",
            "type": "GET",
            "datatype": "json",
            "data": 1
        },
        "columns": [
            { "data": "lActaDetalle.lCasilla.lSeccion.seccion"},
            { "data": "lActaDetalle.lCasilla.nombre"},
            {
                "data": "idActa",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/TActas/Detalle/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-list'></i> Ver detalle
                            </a>`;
                },          
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
        var a = document.getElementById("Municipios").value;
        table = $('#tblActasReg').DataTable();
        table.destroy();
        document.getElementById("Mens").style.visibility = "hidden";
        dataTable = $("#tblActasReg").DataTable({
            "responsive": true,
            "autoWidth": false,
            "ajax": {
                "url": "/admin/TActas/CargarRegAdmin",
                "type": "GET",
                "datatype": "json",
                "data": { id: a }
            },
            "columns": [
                { "data": "lActaDetalle.lCasilla.lSeccion.seccion" },
                { "data": "lActaDetalle.lCasilla.nombre" },
                { "data": "lActaDetalle.lTipoEleccion.nombre" },
                {
                    "data": "idActa",
                    "render": function (data) {
                        return `<div class="text-center">
                            <a href='/Admin/TActas/Detalle/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-list'></i> Ver detalle
                            </a>`;
                    },
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




