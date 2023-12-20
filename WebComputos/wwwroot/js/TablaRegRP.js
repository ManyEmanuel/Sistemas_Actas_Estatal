var datatable;

$(document).ready(function () {
    CargarDatatable();
});
function CargarDatatable() {
    dataTable = $("#tblActasReg").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": "/admin/TResultadosActas/CargaTabRegRP",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "seccion", "width": "10%" },
            { "data": "casilla", "width": "10%" },
            { "data": "idreg", "width": "10%", "visible": false  },
            
            {
                "data": "idreg",
                "render": function (data) {

                    return `<div class="text-center">
                            <a href='/Admin/TResultadosActas/DetalleResultadoRP/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
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