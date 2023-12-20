var datatable;

$(document).ready(function () {
    CargaCasillaGob();  
    IdGobernador();
    $("#llamar").hide();
    Votos();
});

function checkSubmit() {
    document.getElementById("GVotos").disabled = true;
    document.getElementById("cancelar").disabled = true;
   
}

function CargaCasillaGob() {
    $("#SeccionGob").change(function () {
        var url = "/admin/TResultadosActas/CasillaGob";
        var b = document.getElementById("SeccionGob").value;
        $.getJSON(url, {  seccion: b }, function (data) {
            var items = '';
            $("#Gobernador").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#Gobernador").html(items);
            document.getElementById("Gobernador").focus();
            
        })
    });

}



function BloqVista() {
    window.setTimeout(bloqueoVistaPArcial, 2);
}

function bloqueoVistaPArcial() {
    $('#VistaParcial input').attr('disabled', 'disabled');
    $('#VistaParcial button').attr('disabled', 'disabled');
    $('#VistaParcial select').attr('disabled', 'disabled');
}

function IdGobernador() {
    $("#Gobernador").focus(function () {
        var b = document.getElementById("Gobernador").value;
        document.getElementById("IdGob").value = b;
        $("#llamar").show();
    });
    $("#Gobernador").change(function () {
        var b = document.getElementById("Gobernador").value;
        document.getElementById("IdGob").value = b;
        $("#llamar").show();
    });
}

function Votos() {
    $("#llamar").click(function () {
        var a = document.getElementById("IdGob").value;    
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
        document.getElementById("SeccionGob").disabled = true
        document.getElementById("Gobernador").disabled = true
    })
}
