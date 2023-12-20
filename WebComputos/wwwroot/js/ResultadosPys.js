var datatable;

$(document).ready(function () {
    CargaCasillaPys();  
    IdPys();
    $("#llamar").hide();
    Votos();
});

function CargaCasillaPys() {
    $("#SeccionPys").change(function () {
        var url = "/admin/TResultadosActas/CasillaPys";
        var b = document.getElementById("SeccionPys").value;
        $.getJSON(url, { seccion: b }, function (data) {
            var items = '';
            $("#Pys").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#Pys").html(items);
            document.getElementById("Pys").focus();
        })
    });

}

function checkSubmit() {
    document.getElementById("GVotos").disabled = true;
    document.getElementById("cancelar").disabled = true;

}

function BloqVista() {
    window.setTimeout(bloqueoVistaPArcial, 1);
}

function bloqueoVistaPArcial() {
    $('#VistaParcial input').attr('disabled', 'disabled');
    $('#VistaParcial button').attr('disabled', 'disabled');
    $('#VistaParcial select').attr('disabled', 'disabled');
}

function IdPys() {
    $("#Pys").focus(function () {
        var b = document.getElementById("Pys").value;
        document.getElementById("IdPys").value = b;
        $("#llamar").show();
    });
    $("#Pys").change(function () {
        var b = document.getElementById("Pys").value;
        document.getElementById("IdPys").value = b;
        $("#llamar").show();
    });
}

function Votos() {
    $("#llamar").click(function () {
        var a = document.getElementById("IdPys").value;
        $.ajax({
            type: "GET",
            url: "/admin/TResultadosActas/ResultadosGob",
            data: {
                id: a
            },
            success: function (data) {
                //if (data.Error == false) {                          
                $("#VistaParcial").load(`Resultados/${a}`)                       //}
            }
        })
        document.getElementById("llamar").disabled = true
        document.getElementById("SeccionPys").disabled = true
        document.getElementById("Pys").disabled = true
    })
}