var datatable;

$(document).ready(function () {
    CargaCasillaReg();    
    IdRegidor();
    $("#llamar").hide();
    Votos();
});

function CargaCasillaReg() {
    $("#SeccionReg").change(function () {
        var url = "/admin/TResultadosActas/CasillaReg";
        var b = document.getElementById("SeccionReg").value;
        $.getJSON(url, { seccion: b }, function (data) {
            var items = '';
            $("#Regidor").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#Regidor").html(items);
            document.getElementById("Regidor").focus();
        })
    });

}

function BloqVista() {
    window.setTimeout(bloqueoVistaPArcial, 1);
}

function checkSubmit() {
    document.getElementById("GVotos").disabled = true;
    document.getElementById("cancelar").disabled = true;

}

function bloqueoVistaPArcial() {
    $('#VistaParcial input').attr('disabled', 'disabled');
    $('#VistaParcial button').attr('disabled', 'disabled');
    $('#VistaParcial select').attr('disabled', 'disabled');
}

function IdRegidor() {
    $("#Regidor").focus(function () {
        var b = document.getElementById("Regidor").value;
        document.getElementById("IdReg").value = b;
        $("#llamar").show();
    });
    $("#Regidor").change(function () {
        var b = document.getElementById("Regidor").value;
        document.getElementById("IdReg").value = b;
        $("#llamar").show();
    });
}

function Votos() {
    $("#llamar").click(function () {
        var a = document.getElementById("IdReg").value;
        var b = document.getElementById("IdReg2").value;
        console.log(b);
        $.ajax({
            type: "GET",
            url: "/admin/TResultadosActas/ResultadosGob",
            data: {
                id: a
            },
            success: function (data) {
                                       
                $("#VistaParcial").load(`Resultados/${a}`)                       
            }
        })
        document.getElementById("llamar").disabled = true
        document.getElementById("SeccionReg").disabled = true
        document.getElementById("Regidor").disabled = true
    })
}

