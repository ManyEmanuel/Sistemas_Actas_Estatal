$(document).ready(function () {
    TipoBusqueda();
    MunDis();
    DemSec();
});

function TipoBusqueda() {
    $("#Opciones").change(function () {
        var a = document.getElementById("Opciones").value;
        document.getElementById("Tipo").value = a;
        switch (a) {
            case "1":
                document.getElementById("Municipio").style.display = "none"
                document.getElementById("mun").style.display = "none"
                document.getElementById("Distrito").style.display = "none"
                document.getElementById("dis").style.display = "none"
                document.getElementById("Demarcacion").style.display = "none"
                document.getElementById("dem").style.display = "none"
                document.getElementById("Seccion").style.display = "none"
                document.getElementById("sec").style.display = "none"
                break;
            case "2":
                document.getElementById("Municipio").style.display = "block"
                document.getElementById("mun").style.display = "block"
                document.getElementById("Distrito").style.display = "none"
                document.getElementById("dis").style.display = "none"
                document.getElementById("Demarcacion").style.display = "none"
                document.getElementById("dem").style.display = "none"
                document.getElementById("Seccion").style.display = "none"
                document.getElementById("sec").style.display = "none"
                break;
            case "3":
                document.getElementById("Municipio").style.display = "none"
                document.getElementById("mun").style.display = "none"
                document.getElementById("Distrito").style.display = "block"
                document.getElementById("dis").style.display = "block"
                document.getElementById("Demarcacion").style.display = "none"
                document.getElementById("dem").style.display = "none"
                document.getElementById("Seccion").style.display = "none"
                document.getElementById("sec").style.display = "none"
                break;
            case "4":
                document.getElementById("Municipio").style.display = "block"
                document.getElementById("mun").style.display = "block"
                document.getElementById("Distrito").style.display = "none"
                document.getElementById("dis").style.display = "none"
                document.getElementById("Demarcacion").style.display = "block"
                document.getElementById("dem").style.display = "block"
                document.getElementById("Seccion").style.display = "none"
                document.getElementById("sec").style.display = "none"
                break;
            case "5":
                document.getElementById("Municipio").style.display = "block"
                document.getElementById("mun").style.display = "block"
                document.getElementById("Distrito").style.display = "none"
                document.getElementById("dis").style.display = "none"
                document.getElementById("Demarcacion").style.display = "none"
                document.getElementById("dem").style.display = "none"
                document.getElementById("Seccion").style.display = "block"
                document.getElementById("sec").style.display = "block"
                break;
        }
    });
}

function MunDis() {
    $("#Municipio").change(function () {
        var a = document.getElementById("Municipio").value;
        document.getElementById("Primer").value = a;
        var url = "/admin/Ubica/CargarDem";
        $.getJSON(url, { id: a }, function (data) {
            var items = '';
            $("#Demarcacion").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#Demarcacion").html(items);
            document.getElementById("Demarcacion").focus();
        })
        var url = "/admin/Ubica/CargarSec";
        $.getJSON(url, { id: a }, function (data) {
            var items = '';
            $("#Seccion").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#Seccion").html(items);
            document.getElementById("Seccion").focus();
        })
    });

    $("#Distrito").change(function () {
        var a = document.getElementById("Distrito").value;
        document.getElementById("Primer").value = a;
    });
}

function DemSec() {
    $("#Demarcacion").change(function () {
        var a = document.getElementById("Demarcacion").value;
        document.getElementById("Segundo").value = a;
    });

    $("#Seccion").change(function () {
        var a = document.getElementById("Seccion").value;
        document.getElementById("Segundo").value = a;
    });
}