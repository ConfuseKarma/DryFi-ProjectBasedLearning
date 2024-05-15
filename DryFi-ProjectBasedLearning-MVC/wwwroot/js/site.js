// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function aplicaFiltroConsultaAvancadaFuncionario() {
    var vNome = document.getElementById('nome').value;
    var vCargo = document.getElementById('cargo').value;
    $.ajax({
        url: "/Funcionario/ObtemDadosConsultaAvancada",
        data: { nome: vNome, cargo: vCargo },
        success: function (dados) {
            if (dados.erro != undefined) {
                alert(dados.msg);
            }
            else {
                console.log("cheguei");
                document.getElementById('resultadoConsulta').innerHTML = dados;
            }
        },
    });
}

function aplicaFiltroConsultaAvancadaCliente() {
    var vNome = document.getElementById('nomeCliente').value;
    var vCnpj = document.getElementById('cnpj').value;
    var vTipo = document.getElementById('tipo').value;
    $.ajax({
        url: "/Cliente/ObtemDadosConsultaAvancada",
        data: { nomeCliente: vNome, cnpj: vCnpj, tipo: vTipo },
        success: function (dados) {
            console.log(dados);
            if (dados.erro != undefined) {
                alert(dados.msg);
            }
            else {
                console.log("cheguei");
                document.getElementById('resultadoConsulta').innerHTML = dados;
            }
        },
    });
}