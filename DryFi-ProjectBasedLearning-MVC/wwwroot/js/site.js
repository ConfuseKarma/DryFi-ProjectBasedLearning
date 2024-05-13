// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function aplicaFiltroConsultaAvancada() {
    var vDescricao = document.getElementById('nome').value;
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
