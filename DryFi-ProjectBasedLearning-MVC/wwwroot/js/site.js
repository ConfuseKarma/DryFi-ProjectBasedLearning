// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function aplicaFiltroConsultaAvancada() {
    var vDescricao = document.getElementById('nome').value;
    var vDataInicial = document.getElementById('cargo').value;
    $.ajax({
        url: "/funcionario/ObtemDadosConsultaAvancada",
        data: { nome: vNome, cargo: vCargo },
        success: function (dados) {
            if (dados.erro != undefined) {
                alert(dados.msg);
            }
            else {
                document.getElementById('resultadoConsulta').innerHTML = dados;
            }
        },
    });

}
