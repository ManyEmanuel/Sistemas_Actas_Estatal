var datatable;

$(document).ready(function () {
    CargaCasillaDip();   
    IdDiputado();
    $("#llamar").hide();
    Votos();
});

function CargaCasillaDip() {
    $("#SeccionDip").change(function () {
        var url = "/admin/TResultadosActas/CasillaDip";
        var b = document.getElementById("SeccionDip").value;
        $.getJSON(url, { seccion: b }, function (data) {
            var items = '';
            $("#Diputado").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#Diputado").html(items);
            document.getElementById("Diputado").focus();
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


function IdDiputado() {
    $("#Diputado").focus(function () {
        var b = document.getElementById("Diputado").value;
        document.getElementById("IdDip").value = b;
        $("#llamar").show();
    });
    $("#Diputado").change(function () {
        var b = document.getElementById("Diputado").value;
        document.getElementById("IdDip").value = b;
        $("#llamar").show();
    });
}

function Votos() {
    $("#llamar").click(function () {
        var a = document.getElementById("IdDip").value;
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
        document.getElementById("SeccionDip").disabled = true
        document.getElementById("Diputado").disabled = true
    })
}
