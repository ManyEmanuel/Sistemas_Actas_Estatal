var dataTable;

$(document).ready(function () {
    document.getElementById("ver").style.display = "none";
    Inicio();
    CalcularPR();
    
    $("#aray").hide();
    $("#tipo").hide();
    $("#aray").click(function () {
        Caldatos();   
        location.reload();
        Actualizar();
    });   
});


function Inicio() {
    var a = document.getElementById("causal").textContent;
    var b = document.getElementById("Comprobacion").value;
    if (b != 0) {
        document.getElementById("ver").style.display = "block";
        document.getElementById("Mensaje").textContent = "El ejercicio final ha sido generado, para cualquier modificación consultar con los administradores del sistema";
        document.getElementById("grupos").disabled = true
        document.getElementById("horas").disabled = true
        document.getElementById("calcular").disabled = true
    }
    else {
        if (a <= 20) {
            document.getElementById("ver").style.display = "block";
            document.getElementById("Mensaje").textContent = "Se requieren más de 20 casillas con causales para calcular los puntos de recuento";
            document.getElementById("grupos").disabled = true
            document.getElementById("horas").disabled = true
            document.getElementById("calcular").disabled = true
        }
    }   
}

function Actualizar() {
    location.reload();
}

function CalcularPR() {
    $("#calcular").click(function () {
        LimpiarTabla();
        LimpiarMensajes();
        document.getElementById("ver").style.display = "none";
        document.getElementById("Mensaje").textContent = "";

        var a = document.getElementById("causal").textContent;
        //console.log(a);
        if (a != 0) {
            var b = document.getElementById("grupos").value;
            //console.log(b);
            if (b != "" && b != 0) {
                var h = document.getElementById("horas").value;
                if (h != "" && h != 0) {
                    var p = h / 0.5;
                    //console.log(p);
                    var c = (a / b) / p;
                    //console.log(c);
                    var d = Math.round(c);
                    var enter = Math.floor(c);
                    var decimal = c - Math.floor(c);
                    //console.log(decimal);
                    //console.log(enter);
                    if (decimal >= 0.30) {
                        var entero = enter + 1;
                    } else {
                        var entero = enter;
                    }
                    //console.log(entero);
                    document.getElementById("total").textContent = c;
                    document.getElementById("textotal").textContent = "Puntos de recuento";
                    document.getElementById("redondeo").textContent = entero;
                    document.getElementById("texredondeo").textContent = "Puntos de recuento aplicando decimales mayor a 0.30";
                    document.getElementById("tbcausal").style.display = "block";
                    var table = document.getElementById("tbcausal").getElementsByTagName("tbody")[0]; {
                        //var divi = a / b;
                        var cont = 0;
                        var casicau = a;
                        var grucau = b;
                        for (var i = 0; i < b; i++) {
                            var numcau = casicau / grucau;
                            var entercau = Math.floor(numcau);
                            var decimalcau = numcau - Math.floor(numcau);
                            if (decimalcau > 0.0) {
                                entercau = entercau + 1
                                var zc = entero;
                                var za = entercau;
                                for (var j = 0; j < entero; j++) {

                                    var rest = za / zc;
                                    var enterest = Math.floor(rest);
                                    var decimalrest = rest - Math.floor(rest);
                                    if (decimalrest > 0.0) {
                                        enterest = enterest + 1;
                                        var row = table.insertRow(cont);
                                        var cell1 = row.insertCell(0);
                                        var cell2 = row.insertCell(1);
                                        var cell3 = row.insertCell(2);
                                        cell1.innerHTML = i + 1;
                                        cell2.innerHTML = j + 1;
                                        cell3.innerHTML = enterest;
                                        za = za - enterest;
                                        zc = zc - 1;
                                        cont++;
                                    }
                                    else {
                                        var row = table.insertRow(cont);
                                        var cell1 = row.insertCell(0);
                                        var cell2 = row.insertCell(1);
                                        var cell3 = row.insertCell(2);
                                        cell1.innerHTML = i + 1;
                                        cell2.innerHTML = j + 1;
                                        cell3.innerHTML = enterest;
                                        za = za - enterest;
                                        zc = zc - 1;
                                        cont++;
                                    }

                                }

                            }
                            else {
                                var zc = entero;
                                var za = entercau;
                                for (var j = 0; j < entero; j++) {

                                    var rest = za / zc;
                                    var enterest = Math.floor(rest);
                                    var decimalrest = rest - Math.floor(rest);
                                    if (decimalrest > 0.0) {
                                        enterest = enterest + 1;
                                        var row = table.insertRow(cont);
                                        var cell1 = row.insertCell(0);
                                        var cell2 = row.insertCell(1);
                                        var cell3 = row.insertCell(2);
                                        cell1.innerHTML = i + 1;
                                        cell2.innerHTML = j + 1;
                                        cell3.innerHTML = enterest;
                                        za = za - enterest;
                                        zc = zc - 1;
                                        cont++;
                                    }
                                    else {
                                        var row = table.insertRow(cont);
                                        var cell1 = row.insertCell(0);
                                        var cell2 = row.insertCell(1);
                                        var cell3 = row.insertCell(2);
                                        cell1.innerHTML = i + 1;
                                        cell2.innerHTML = j + 1;
                                        cell3.innerHTML = enterest;
                                        za = za - enterest;
                                        zc = zc - 1;
                                        cont++;
                                    }
                                }
                            }

                            casicau = casicau - entercau;
                            grucau = grucau - 1;

                        }


                    }
                    $("#aray").show();
                    $("#tipo").show();

                    document.getElementById("textoc").textContent = "Selecciona el tipo de ejercicio";
                }
                else {
                    document.getElementById("ver").style.display = "block";
                    document.getElementById("Mensaje").textContent = "Registre las horas a emplear";
                }
            }
            else {
                document.getElementById("ver").style.display = "block";
                document.getElementById("Mensaje").textContent = "Registre el número de grupos de trabajo";
            }
        }
        else {
            document.getElementById("ver").style.display = "block";
            document.getElementById("Mensaje").textContent = "No se tienen casillas con causales";
        }


    });

}

function LimpiarTabla() {
    var nFilas = document.getElementById("tbcausal").getElementsByTagName("tbody")[0].getElementsByTagName("tr");
    var a = nFilas.length
    console.log(a);
    if (nFilas != 0) {

        for (var i = 0; i < a; i++) {
            var table = document.getElementById("tbcausal").getElementsByTagName("tbody")[0];
            table.deleteRow(0);
        }
    }
}

function LimpiarMensajes() {
    document.getElementById("total").textContent = "";
    document.getElementById("textotal").textContent = "";
    document.getElementById("redondeo").textContent = "";
    document.getElementById("texredondeo").textContent = "";
    document.getElementById("tbcausal").style.display = "none";
    document.getElementById("tipo").style.display = "none";
    document.getElementById("aray").style.display = "none";
    document.getElementById("textoc").textContent = "";

}

function Caldatos() {
    
        var nFilas = document.getElementById("tbcausal").getElementsByTagName("tbody")[0].getElementsByTagName("tr");
        var a = nFilas.length;
        var arraymulti = new Array(a);
        var cont = 0;
        for (var i = 1; i <= a; i++) {
            var res = document.getElementById("tbcausal").rows[i].cells[0].innerText;
            var res1 = document.getElementById("tbcausal").rows[i].cells[1].innerText;
            var res2 = document.getElementById("tbcausal").rows[i].cells[2].innerText;
            arraymulti[cont] = new Array(5);
            arraymulti[cont][0] = res;
            arraymulti[cont][1] = res1;
            arraymulti[cont][2] = res2;
            arraymulti[cont][3] = 4;
            arraymulti[cont][4] = document.getElementById("tipo").value;
            arraymulti[cont][5] = document.getElementById("Demarcacion").value;
            arraymulti[cont][6] = 0;
            cont = cont + 1;
        }
        var z = ["0", "1", "2"];
        console.log(arraymulti);
        $.ajax({
            url: '/admin/TRecepcionPaquetes/PuntosRecuentos',
            data: { data: arraymulti },
            type: 'POST'
        });

        location.reload();
}