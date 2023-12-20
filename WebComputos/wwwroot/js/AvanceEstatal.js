var dataTable;

$(document).ready(function () {  
    CargarDatatable2();
    CargarDatatable();
    
});



function CargarDatatable() {
    dataTable = $("#tblEstatal").DataTable({
        "responsive": true,
        "autoWidth": false, 
        "ajax": {
            "url": "/admin/TActas/CargarAvanceEstatal",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idMunicipio", "width": "3%" },
            { "data": "municipio", "width": "9%" },
            {
                "render":
                    function (data, type, row) {
                        return (row.tpaquete + `<br> <hr>` + ` <p> ${row.gpaquete} %</p><div class='progress'>
                  <div class='progress-bar bg-primary progress-bar-striped' role='progressbar'
                       aria-valuenow='${row.gpaquete}' aria-valuemin='0' aria-valuemax='100' style='width: ${row.gpaquete}%'>
                  </div>
                </div>`);
                    }, "width" : "16%"  
            },
            {
                "render":
                    function (data, type, row) {
                        return (row.tgobernador + `<br> <hr>` + ` <p> ${row.ggobernador} %</p><div class='progress'>
                  <div class='progress-bar bg-primary progress-bar-striped' role='progressbar'
                       aria-valuenow='${row.ggobernador}' aria-valuemin='0' aria-valuemax='100' style='width: ${row.ggobernador}%'>
                  </div>
                </div>`);
                    }, "width": "16%"
            },
            {
                "render":
                    function (data, type, row) {
                        return (row.tpys + `<br> <hr>` + ` <p> ${row.gpys} %</p><div class='progress'>
                  <div class='progress-bar bg-primary progress-bar-striped' role='progressbar'
                       aria-valuenow='${row.gpys}' aria-valuemin='0' aria-valuemax='100' style='width: ${row.gpys}%'>
                  </div>
                </div>`);
                    }, "width": "16%"
            },
            {
                "render":
                    function (data, type, row) {
                        return (row.tdiputado + `<br> <hr>` + ` <p> ${row.gdiputado} %</p><div class='progress'>
                  <div class='progress-bar bg-primary progress-bar-striped' role='progressbar'
                       aria-valuenow='${row.gdiputado}' aria-valuemin='0' aria-valuemax='100' style='width: ${row.gdiputado}%'>
                  </div>
                </div>`);
                    }, "width": "16%"
            },
            {
                "render":
                    function (data, type, row) {
                        return (row.tregidor + `<br> <hr>` + ` <p> ${row.gregidor} %</p><div class='progress'>
                  <div class='progress-bar bg-primary progress-bar-striped' role='progressbar'
                       aria-valuenow='${row.gregidor}' aria-valuemin='0' aria-valuemax='100' style='width: ${row.gregidor}%'>
                  </div>
                </div>`);
                    }, "width": "16%"
            },           
            {   "data": "idMunicipio",
                "render": function (data, type, row) {
                   
                        return `<div class="text-center">
                            <a href='/Admin/TActas/EntregaDetalle/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-list'></i> Detalle
                            </a>`;
                    
                }, "width": "5%" }            
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

function CargarDatatable2() {
    dataTable = $("#tblavance").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": "/admin/TActas/AvanceDocumentosEstatal",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idMunicipio", "width": "10%", "visible": false },
            { "data": "municipio", "width": "10%" },
            { "data": "total", "width": "10%" },
            { "data": "recibidos", "width": "10%" },
            { "data": "faltantes", "width": "10%" },
            {
                "data": "porcentaje",
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





