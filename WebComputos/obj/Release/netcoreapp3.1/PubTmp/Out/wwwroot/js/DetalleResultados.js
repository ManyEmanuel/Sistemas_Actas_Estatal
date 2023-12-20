var datatable;

$(document).ready(function () {
    Resultados();
});

function Resultados() {
    var a = document.getElementById("idacta").value;
    $("#VistaParcial").load(`/admin/TActas/DetalleResultado/${a}`)
}