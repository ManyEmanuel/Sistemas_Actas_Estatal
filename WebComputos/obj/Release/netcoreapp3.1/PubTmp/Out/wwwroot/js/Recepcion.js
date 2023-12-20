var dataTable;

$(document).ready(function () {
    
    CargarDatatable();
    CargarDatatable2();
    ListaCasilla();
    IdCasilla(); 
    Sobre();
    Paquete();
    Observaciones();
    Fecha();
    Administrador();
    busqueda();

    //CombinaTodo();
});

$(function busqueda() {
    $("#Seccion").selectpicker();
});


function fmensaje() {
    toastr.options = {
        closeButton: true,
        progressBar: true,
        showMethod: 'slideDown',
        timeOut: 5000
    };
}

function Administrador() {
    $("#Municipios").change(function () {
        var a = document.getElementById("Municipios").value;
        table = $('#tblRecepcion').DataTable();
        table.destroy();
        document.getElementById("Mens").style.visibility = "hidden";
        dataTable = $("#tblRecepcion").DataTable({
            "responsive": true,
            "autoWidth": false,
            "ajax": {
                "url": "/admin/TRecepcionPaquetes/CargarDatosAdmin/",
                "type": "GET",
                "datatype": "json",
                "data": {id:a}

            },
            "columns": [
                { "data": "seccion", "width": "20%" },
                { "data": "casilla", "width": "20%" },
                { "data": "recep", "width": "20%" },
                { "data": "idr", "width": "10%", "visible": false },
                {
                    "data": "idr",
                    "render": function (data) {
                        return `<div class="text-center">
                            <a href='/Admin/TRecepcionPaquetes/Detalle/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-list'></i> Ver Detalle
                            </a>
                            &nbsp;
                             
                            <a href='/Admin/TRecepcionPaquetes/ImprimirDetalle/${data}' target='_blank' class='btn btn-success text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-print'></i> Imprimir
                            </a>`;
                    }, "width": "40%"
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

function CargarDatatable() {
    dataTable = $("#tblRecepcion").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": "/admin/TRecepcionPaquetes/CargarDa",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "seccion", "width": "20%" },
            { "data": "casilla", "width": "20%" },
            { "data": "recep", "width": "20%" },
            { "data": "idr", "width": "10%", "visible": false },
            {
                "data": "idr",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/TRecepcionPaquetes/Detalle/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-list'></i> Ver Detalle
                            </a>
                            &nbsp;
                             
                            <a href='/Admin/TRecepcionPaquetes/ImprimirDetalle/${data}' target='_blank' class='btn btn-success text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-print'></i> Imprimir
                            </a>`;
                }, "width": "40%"
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
    dataTable = $("#tblRecepcionLectura").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": "/admin/TRecepcionPaquetes/CargarDa",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "seccion", "width": "20%" },
            { "data": "casilla", "width": "20%" },
            { "data": "recep", "width": "20%" },
            { "data": "idr", "width": "10%", "visible": false },
            {
                "data": "idr",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/TRecepcionPaquetes/Detalle/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-list'></i> Ver Detalle
                            </a>`;
                }, "width": "40%"
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


function FechaInicial() {
    var hoy = new Date();
    var dd = hoy.getDate();
    var MM = hoy.getMonth() + 1;
    var yyyy = hoy.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }
    if (MM < 10) {
        MM = '0' + MM;
    }
    hoy = yyyy + '/' + MM + '/' + dd ;
    document.getElementById("fini").value = hoy;
}

function ListaCasilla() {
    $("#Seccion").change(function () {
        var url = "/admin/TRecepcionPaquetes/Casillaid";
        var ddlsourse = "#Seccion";
        $.getJSON(url, { id: $(ddlsourse).val() }, function (data) {
            var items = '';
            $("#casid").empty();
            $.each(data, function (i, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#casid").html(items);
            document.getElementById("casid").focus();
        })
    });
}



function IdCasilla(){
    $("#casid").focus(function () {
        var a = document.getElementById("casid").value;
        document.getElementById("idcas").value = a;
        console.log(document.getElementById("idcas").value);
    });

    $("#casid").change(function () {
        var a = document.getElementById("casid").value;
        document.getElementById("idcas").value = a;
        console.log(document.getElementById("idcas").value);
    });
}

function Registrar() {
    bloqueo();
    if (Validar() == true) {
       
        var items = {};
        items["HoraRecepcion"] = $("#hora").val();
        items["FechaRecepcion"] = $("#fini").val();
        items["Nombre_Entrega"] = $("#Entrega").val();
        items["Cargo_Entrega"] = $("#Cargo").val();
        items["Lugar_Entrega"] = $("#Lugar").val();
        items["Cargo_Recibe"] = $("#Recibe").val();
        items["Medio_Entrega"] = $("#Medio").val();
        items["Firma"] = $('input:radio[name=Firma]:checked').val();
        items["Alteracion"] = $('input:radio[name=Alteracion]:checked').val();
        items["Cinta"] = $('input:radio[name=Cinta]:checked').val();
        items["PaqueteElec"] = $('input:radio[name=Paquete]:checked').val();
        items["SobrePrep"] = $('input:radio[name=Sobre]:checked').val();
        items["IdCasilla"] = $("#idcas").val();


        $.ajax({
            url: '/admin/TRecepcionPaquetes/Create',
            type: 'POST',
            data: {
                item: items
            },
            success: function (data) {
                if (data.success) {
                    toastr.success(data.mensaje, {
                        closeButton: true,
                        progressBar: true,
                        showMethod: 'slideDown',
                    });
                    window.setTimeout(Refresco, 3000);
                    
                }
                else {
                    desbloqueo();
                    toastr.error(data.mensaje);                   
                }
            },

        })
    }
    
    else {

    }

}

function Refresco() {
    window.location.reload(true);
}
function bloqueo() {
    $('#RecepcionPaquete input').attr('disabled', 'disabled');
    $('#RecepcionPaquete button').attr('disabled', 'disabled');
    $('#RecepcionPaquete select').attr('disabled', 'disabled');
}

function desbloqueo() {
    $('#RecepcionPaquete input').removeAttr('disabled');
    $('#RecepcionPaquete button').removeAttr('disabled');
    $('#RecepcionPaquete select').removeAttr('disabled');
}

    function Validar() {
        var form = $('#RecepcionPaquete');
        $.validator.unobtrusive.parse(form);
        var validate = form.validate().form();
        var unobtrusiveValidation = form.data('unobtrusiveValidation');
        return validate;
    }


    function Sobre() {
        $("input[name=Sobre]").click(function () {
            var sobre = $('input:radio[name=Sobre]:checked').val();
            document.getElementById("sobrePrep").value = sobre;
        });
    }

    function Paquete() {
        $("input[name=Paquete]").click(function () {
            var paq = $('input:radio[name=Paquete]:checked').val();
            document.getElementById("PaqPrep").value = paq;
        });
    }

    function Observaciones() {
        $("input[name=obs]").click(function () {
            var obs = $('input:radio[name=obs]:checked').val();
            document.getElementById("Resob").value = obs;
        });
    }

    function Fecha() {
        $("#Guardar").click(function () {
            var hoy = new Date();
            var dd = hoy.getDate();
            var MM = hoy.getMonth() + 1;
            var yyyy = hoy.getFullYear();

            if (dd < 10) {
                dd = '0' + dd;
            }
            if (MM < 10) {
                MM = '0' + MM;
            }
            hoy = dd + '/' + MM + '/' + yyyy;
            document.getElementById("Fecsis").value = hoy;

            var hor = new Date();
            var hh = hor.getHours();
            var min = hor.getMinutes();
            hor = hh + ':' + min;
            document.getElementById("Horsis").value = hor;

        });
    }





