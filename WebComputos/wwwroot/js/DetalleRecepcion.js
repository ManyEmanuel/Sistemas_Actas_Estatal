var dataTable;
$(document).ready(function () {  
    CargarDatatable();
});
function CargarDatatable() {
    var id = document.getElementById("mun").value;
    dataTable = $("#tblAvance").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": `/admin/TRecepcionPaquetes/CargarDetalle/${id}`,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "seccion", "width": "10%" },
            { "data": "casilla", "width": "10%" },
            { "data": "fecha", "width": "10%" },
            { "data": "hora", "width": "10%"},
            { "data": "estatus", "width" : "10%"}
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





