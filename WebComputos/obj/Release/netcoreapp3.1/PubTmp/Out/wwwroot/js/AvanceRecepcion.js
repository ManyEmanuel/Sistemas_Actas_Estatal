var dataTable;

$(document).ready(function () {  
    CargarDatatable();
});



function CargarDatatable() {
    dataTable = $("#tblavance").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": "/admin/TRecepcionPaquetes/CargarAvance",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idMunicipio", "width": "3%" },
            { "data": "municipio", "width": "10%" },
            { "data": "total", "width": "9%" },
            { "data": "recibidos", "width": "9%" },
            { "data": "faltantes", "width": "9%"},
            { "data": "porcentaje",
                "render": function (data, type, row) {
                    return `<p> ${data} %</p>

                <div class='progress'>
                  <div class='progress-bar bg-primary progress-bar-striped' role='progressbar'
                       aria-valuenow='${data}' aria-valuemin='0' aria-valuemax='100' style='width: ${data}%'>
                  </div>
                </div>`;
                },
                "width": "50%"
            },

            {
                "data": "idMunicipio",
                "render": function (data, type, row) {
                    return `<div class="text-center">
                        <a href='/Admin/TRecepcionPaquetes/DetalleAvance/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
                        <i class='fas fa-list'></i> Detalle
                        </a>`;               
                }, "width": "10%"

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





