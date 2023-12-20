var datatable;

$(document).ready(function () {
    CargaCasillaRegRP();  
    IdRegidorRP();
    $("#llamar").hide();
    Votos();
});

function checkSubmit() {
    document.getElementById("GVotos").disabled = true;
    document.getElementById("cancelar").disabled = true;

}

function CargaCasillaRegRP() {
    $("#SeccionRegRP").change(function () {
        var url = "/admin/TResultadosActas/CasillaRegRP";
        var b = document.getElementById("SeccionRegRP").value;
        $.getJSON(url, {  seccion: b }, function (data) {
            var items = '';
            $("#RegidorRP").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#RegidorRP").html(items);
            document.getElementById("RegidorRP").focus();
            
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

function IdRegidorRP() {
    $("#RegidorRP").focus(function () {
        var b = document.getElementById("RegidorRP").value;
        document.getElementById("IdReg").value = b;
        $("#llamar").show();
    });
    $("#RegidorRP").change(function () {
        var b = document.getElementById("RegidorRP").value;
        document.getElementById("IdReg").value = b;
        $("#llamar").show();
    });
}

function Votos() {
    $("#llamar").click(function () {
        var a = document.getElementById("IdReg").value;    
            $.ajax({
                type: "GET",
                url: "/admin/TResultadosActas/ResultadosRP",
                data: {
                    id: a
                },
                success: function (data) {
                    //if (data.Error == false) {                          
                    $("#VistaParcial").load(`ResultadosCRP/${a}`)                       //}
                }
            })
        document.getElementById("llamar").disabled = true
        document.getElementById("SeccionGob").disabled = true
        document.getElementById("Gobernador").disabled = true
    })
}
