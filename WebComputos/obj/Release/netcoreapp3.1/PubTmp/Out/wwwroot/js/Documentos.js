                                             var dataTable;

$(document).ready(function () {
    CargarDatatable();
    CargarDatatable2();
});
function CargarDatatable() {
    dataTable = $("#tbldoc").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": "/admin/TActas/CargarDoc",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "seccion", "width": "10%" },
            { "data": "casilla", "width": "20%" },
            { "data": "paquetes",
                "render": function (data, type, row) {
                    if (row.paquetes == "Si") {
                        return `<button type='button' class='btn  btn-success btn-sm'> <a><i class='fas fa-check'></i></a></button>`;
                    } else {
                        return `<button type='button' class='btn  btn-danger btn-sm'><a><i class='fas fa-times'></i></a></button>`;
                    }
                },"width": "10%"
            },
            { "data": "gobernador",
                "render": function (data, type, row)
                {
                    if (row.gobernador == "Si")
                    {
                        return `<button type='button' class='btn  btn-success btn-sm'> <a><i class='fas fa-check'></i></a></button>`;
                    } else
                    {
                        return `<button type='button' class='btn  btn-danger btn-sm'><a><i class='fas fa-times'></i></a></button>`;
                    }              
                },"width": "10%"
                
            },
            {
                "data": "pys",
                "render": function (data, type, row) {
                    if (row.pys == "Si") {
                        return `<button type='button' class='btn  btn-success btn-sm'> <a><i class='fas fa-check'></i></a></button>`;
                    } else {
                        return `<button type='button' class='btn  btn-danger btn-sm'><a><i class='fas fa-times'></i></a></button>`;
                    }
                }, "width": "10%"

            },
            {
                "data": "diputado",
                "render": function (data, type, row) {
                    if (row.diputado == "Si") {
                        return `<button type='button' class='btn  btn-success btn-sm'> <a><i class='fas fa-check'></i></a></button>`;
                    } else {
                        return `<button type='button' class='btn  btn-danger btn-sm'><a><i class='fas fa-times'></i></a></button>`;
                    }
                }, "width": "10%"

            },
            {
                "data": "regidor",
                "render": function (data, type, row) {
                    if (row.regidor == "Si") {
                        return `<button type='button' class='btn  btn-success btn-sm'> <a><i class='fas fa-check'></i></a></button>`;
                    } else {
                        return `<button type='button' class='btn  btn-danger btn-sm'><a><i class='fas fa-times'></i></a></button>`;
                    }
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

function CargarDatatable2() {
    dataTable = $("#tbldocavance").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": "/admin/TActas/AvanceDocumentos",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idMunicipio", "width": "10%", "visible" :false },
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