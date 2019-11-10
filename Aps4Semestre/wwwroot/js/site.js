


function inputarDados() {
    var texto = $('#inputar').val();
    var btnInputar = $('#btnInputar');

    var regexDoInput = /[\d\s]/;

    if (regexDoInput.test(texto) || texto == '') {
        btnInputar.attr("disabled", true)
    } else {
        btnInputar.attr("disabled", false);
    }
    
}

function addATabela() {
    inputarDados();


    var texto = document.getElementById('inputar').value;
    let tr = document.createElement(`tr`);
    let tabela = document.getElementById('tabelaInputs');

    let td = document.createElement(`td`)
    td.classList.add(`dadoDaTabela`);
    td.textContent = texto;
    tr.appendChild(td);
    tabela.appendChild(tr);

    document.getElementById('inputar').value = ''
}

function montaTabelaComDados(resposta) {
    let tempoDecorrido = resposta.elapsed;
    let listaDeResultados = resposta.lista;

    let campoTemp = document.getElementById('tempoDecorrido');
    let tabela = document.getElementById('tabelaResultados');

    campoTemp.textContent = tempoDecorrido;

    for (let i = 0; i < listaDeResultados.length; i++) {
        let tr = document.createElement(`tr`);
        let td = document.createElement('td');
        td.textContent = listaDeResultados[i];
        tr.appendChild(td);
        tabela.appendChild(tr);
    }

}

function addTabelaDeDados(lista) {


}

function pegaOsdadosDaTabela() {
    let dados = [];
    let arrayDeDados = document.getElementById('tabelaInputs').querySelectorAll('.dadoDaTabela');
    for (let i = 0; i < arrayDeDados.length; i++) {
        let valor = arrayDeDados[i].textContent;

        if (valor == null || valor == '') {
            continue
        }
       dados.push(valor);
    }
    return dados;
}

function OrdenacaoPorInsercaoAjax() {

    let lista  = pegaOsdadosDaTabela()
    $.ajax({
        method: "POST",
        url: "/home/OrdenacaoPorInsercao",
        data: JSON.stringify(lista),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function (response) {
        limpaTabelaresultados()
        montaTabelaComDados(response);
        });
}

function OrdenacaoPorSelecaoAjax() {

    let lista = pegaOsdadosDaTabela()
    $.ajax({
        method: "POST",
        url: "/home/OrdenacaoPorSelecao",
        data: JSON.stringify(lista),
        contentType: "application/json; charset=utf-8",
	    dataType: "json"
    }).done(function (response) {
        limpaTabelaresultados()
        montaTabelaComDados(response);
    });
}

function OrdenacaoPorFundicaoAjax() {

    let lista = pegaOsdadosDaTabela()
    $.ajax({
        method: "POST",
        url: "/home/OrdenacaoPorFundicao",
        data: JSON.stringify(lista),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function (response) {
        limpaTabelaresultados()
        montaTabelaComDados(response);
    });
}

function limpaTabelaresultados() {
    document.getElementById(`tabelaResultados`).innerHTML = ``;
} 

function limparImputs() {
    document.getElementById('tabelaInputs').innerHTML = '';

}
