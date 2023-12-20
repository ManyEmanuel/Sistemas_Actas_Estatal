var datatable;

$(document).ready(function () {
    CargaCasillaDipRP();  
    IdDiputadoRP();
    $("#llamar").hide();
    Votos();
});

function checkSubmit() {
    document.getElementById("GVotos").disabled = true;
    document.getElementById("cancelar").disabled = true;

}

function CargaCasillaDipRP() {
    $("#SeccionDipRP").change(function () {
        var url = "/admin/TResultadosActas/CasillaDipRP";
        var b = document.getElementById("SeccionDipRP").value;
        $.getJSON(url, {  seccion: b }, function (data) {
            var items = '';
            $("#DiputadoRP").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#DiputadoRP").html(items);
            document.getElementById("DiputadoRP").focus();
            
        })
    });

}
function BloqVista() {
    window.setTimeout(bloqueoVistaPArcial, 50);
}

function bloqueoVistaPArcial() {
    $('#VistaParcial input').attr('disabled', 'disabled');
    $('#VistaParcial button').attr('disabled', 'disabled');
    $('#VistaParcial select').attr('disabled', 'disabled');
}


function IdDiputadoRP() {
    $("#DiputadoRP").focus(function () {
        var b = document.getElementById("DiputadoRP").value;
        document.getElementById("IdDip").value = b;
        $("#llamar").show();
    });
    $("#DiputadoRP").change(function () {
        var b = document.getElementById("DiputadoRP").value;
        document.getElementById("IdDip").value = b;
        $("#llamar").show();
    });
}

function Votos() {
    $("#llamar").click(function () {
        var a = document.getElementById("IdDip").value;    
            $.ajax({
                type: "GET",
                url: "/admin/TResultadosActas/ResultadosRP",
                data: {
                    id: a
                },
                success: function (data) {
                                           
                    $("#VistaParcial").load(`ResultadosCRP/${a}`)                       
                }
            })
        document.getElementById("llamar").disabled = true
        document.getElementById("SeccionDipRP").disabled = true
        document.getElementById("DiputadoRP").disabled = true
    })
}
