var datatable;

$(document).ready(function () {
    Cargar();
    var tablA = document.getElementById("Prueba");
    tablA.style.visibility = "hidden";

});
function Cargar(){
    $("#Distritos").change(function () {
        var tablA = document.getElementById("Prueba");
        tablA.style.visibility = "visible";
        var a = document.getElementById("Distritos").value;                                     
        $("#VistaParcial").load(`CausalesDipAdmin/${a}`)
        table = $('#tblcaulectura').DataTable();
        table.destroy();
        dataTable = $("#tblcaulectura").DataTable({
            "responsive": true,
            "autoWidth": false,
            "ajax": {
                "url": `/admin/TRecepcionPaquetes/CargarCauDipAdmin`,
                "type": "GET",
                "datatype": "json",
                "data": { id: a }
            },
            "columns": [
                { "data": "seccion", "width": "10%" },
                { "data": "casilla", "width": "10%" },
                {
                    "data": "cau1",
                    "render": function (data, type, row) {
                        if (row.cau1 == false) {
                            return `<button type='button' class='btn  btn-success btn-sm' data-toggle="tooltip" data-placement="top" title="El paquete electoral fue entregado con el AEC" > <a><i class='fas fa-check'></i></a></button>`;
                        } else {
                            return `<button type='button' class='btn  btn-danger btn-sm' data-toggle="tooltip" data-placement="top" title="El paquete electoral fue entregado sin el AEC" ><a><i class='fas fa-times'></i></a></button>`;
                        }
                    }, "width": "5%"
                },
                {
                    "data": "cau2",
                    "render": function (data, type, row) {
                        if (row.cau2 == false) {
                            return `<button type='button' class='btn  btn-success btn-sm' data-toggle="tooltip" data-placement="top" title="Votos nulos menor a la diferencia entre el 1er y 2do lugar"> <a><i class='fas fa-check'></i></a></button>`;
                        } else {
                            return `<button type='button' class='btn  btn-danger btn-sm' data-toggle="tooltip" data-placement="top" title="Votos nulos mayor a la diferencia entre el 1er y 2do lugar"><a><i class='fas fa-times'></i></a></button>`;
                        }
                    }, "width": "5%"
                },
                {
                    "data": "cau3",
                    "render": function (data, type, row) {
                        if (row.cau3 == false) {
                            return `<button type='button' class='btn  btn-success btn-sm' data-toggle="tooltip" data-placement="top" title="Total de votos del sistema menor a las boletas entregadas"> <a><i class='fas fa-check'></i></a></button>`;
                        } else {
                            return `<button type='button' class='btn  btn-danger btn-sm' data-toggle="tooltip" data-placement="top" title="Total de votos del sistema mayor a las boletas entregadas"><a><i class='fas fa-times'></i></a></button>`;
                        }
                    }, "width": "5%"
                },
                {
                    "data": "cau4",
                    "render": function (data, type, row) {
                        if (row.cau4 == false) {
                            return `<button type='button' class='btn  btn-success btn-sm' data-toggle="tooltip" data-placement="top" title="Total de votos del sistema igual al total de votos del AEC"> <a><i class='fas fa-check'></i></a></button>`;
                        } else {
                            return `<button type='button' class='btn  btn-danger btn-sm' data-toggle="tooltip" data-placement="top" title="Total del votos del sistema diferente al total de votos del AEC"><a><i class='fas fa-times'></i></a></button>`;
                        }
                    }, "width": "5%"
                },
                {
                    "data": "cau5",
                    "render": function (data, type, row) {
                        if (row.cau5 == false) {
                            return `<button type='button' class='btn  btn-success btn-sm' data-toggle="tooltip" data-placement="top" title="Votos por mas de un partido politivo, coalición o candidato independiente"> <a><i class='fas fa-check'></i></a></button>`;
                        } else {
                            return `<button type='button' class='btn  btn-danger btn-sm' data-toggle="tooltip" data-placement="top" title="Votos por un solo partido politico, coalición o candidato independiente"><a><i class='fas fa-times'></i></a></button>`;
                        }
                    }, "width": "5%"
                },
                {
                    "data": "cau6",
                    "render": function (data, type, row) {
                        if (row.cau6 == false) {
                            return `<button type='button' class='btn  btn-success btn-sm' data-toggle="tooltip" data-placement="top" title="Acta legible"> <a><i class='fas fa-check'></i></a></button>`;
                        } else {
                            return `<button type='button' class='btn  btn-danger btn-sm' data-toggle="tooltip" data-placement="top" title="Acta Ilegible"><a><i class='fas fa-times'></i></a></button>`;
                        }
                    }, "width": "5%"
                },
                {
                    "data": "cau7",
                    "render": function (data, type, row) {
                        if (row.cau7 == false) {
                            return `<button type='button' class='btn  btn-success btn-sm' data-toggle="tooltip" data-placement="top" title="Acta sin alteraciones"> <a><i class='fas fa-check'></i></a></button>`;
                        } else {
                            return `<button type='button' class='btn  btn-danger btn-sm' data-toggle="tooltip" data-placement="top" title="Acta con alteraciones"><a><i class='fas fa-times'></i></a></button>`;
                        }
                    }, "width": "5%"
                },
                {
                    "data": "cau8",
                    "render": function (data, type, row) {
                        if (row.cau8 == false) {
                            return `<button type='button' class='btn  btn-success btn-sm' data-toggle="tooltip" data-placement="top" title="Paquete sin muestras de alteraciones"> <a><i class='fas fa-check'></i></a></button>`;
                        } else {
                            return `<button type='button' class='btn  btn-danger btn-sm' data-toggle="tooltip" data-placement="top" title="Paquete con muestras de alteraciones"><a><i class='fas fa-times'></i></a></button>`;
                        }
                    }, "width": "5%"
                },
                {
                    "data": "cau9",
                    "render": function (data, type, row) {
                        if (row.cau9 == false) {
                            return `<button type='button' class='btn  btn-success btn-sm' data-toggle="tooltip" data-placement="top" title="Ciudadanos que votaron igual al total de votos del sistema"> <a><i class='fas fa-check'></i></a></button>`;
                        } else {
                            return `<button type='button' class='btn  btn-danger btn-sm' data-toggle="tooltip" data-placement="top" title="Ciudadanos que votaron diferente al total de votos del sistema"><a><i class='fas fa-times'></i></a></button>`;
                        }
                    }, "width": "5%"
                },
                {
                    "data": "cau10",
                    "render": function (data, type, row) {
                        if (row.cau10 == false) {
                            return `<button type='button' class='btn  btn-success btn-sm' data-toggle="tooltip" data-placement="top" title="Boletas sobrantes mas ciudadanos que votaron menor a boletas entregadas"> <a><i class='fas fa-check'></i></a></button>`;
                        } else {
                            return `<button type='button' class='btn  btn-danger btn-sm' data-toggle="tooltip" data-placement="top" title="Boletas sobrantes mas ciudadanos que votaron mayor a boletas entregadas"><a><i class='fas fa-times'></i></a></button>`;
                        }
                    }, "width": "5%"
                },
                {
                    "data": "cau11",
                    "render": function (data, type, row) {
                        if (row.cau11 == false) {
                            return `<button type='button' class='btn  btn-success btn-sm' data-toggle="tooltip" data-placement="top" title="Boletas sobrantes mas total de votos del sistema menor a boletas entregadas"> <a><i class='fas fa-check'></i></a></button>`;
                        } else {
                            return `<button type='button' class='btn  btn-danger btn-sm' data-toggle="tooltip" data-placement="top" title="Boletas sobrantes mas total de votos del sistema mayor a boletas entregadas"><a><i class='fas fa-times'></i></a></button>`;
                        }
                    }, "width": "5%"
                },
                { "data": "numcau", "width": "10%", "name": "Numero" },
                { "data": "idcau", "width": "10%", "visible": false }

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
}


