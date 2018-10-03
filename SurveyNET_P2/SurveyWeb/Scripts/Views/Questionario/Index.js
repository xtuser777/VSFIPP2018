$("#btnPesquisar").click(function () {
    var msg = "";
    var chave = $("#txtEmailNovo").val();

    if (chave == "") {
        msg += "Por favor, informe uma palavra chave ou id para buscar.<br />";
    }

    if (msg.length > 0) {
        Mensagem("divAlertaNovoUsuario", msg);
    } else {
        if (isNumber(chave)) {
            ObterQuestionariosPorId(msg);
        } else {
            ObterQuestionariosPorPalavraChave(msg);
        }
    }
});

function PreencherTabela(dados) {
    var txt = '<thead>\
            <tr>\
                <th>#ID</th>\
                <th>Título</th>\
                <th>Início</th>\
                <th>Fim</th>\
                <th>Guid</th>\
                <th>...</th>\
            </tr>\
        </thead >\
        <tbody>';
    $.each(dados, function () {
        txt += '<tr><td>' + this.Id + '</td><td>' + this.Nome + '</td><td>' + FormatarData(this.Inicio) +
            '</td><td>' + FormatarData(this.Fim) + '</td><td>' + this.Guid + '</td><td>\
                <a role="button" class="btn btn-warning" href="javascript:Alterar(' + this.Id + ')">Alterar</a>\
                <a role="button" class="btn btn-danger" href="javascript:Excluir(' + this.Id + ')">Excluir</a>\
                </td></tr>';
    });
    txt += '</tbody>';
    $("#tableQuestionarios").html(txt);
};

function Alterar(id) {

};

function Excluir(id) {

};

function ObterQuestionarios() {
    $("#divLoading").show(300);
    $.getJSON("/Questionario/ObterPorUsuario/" + getCookie("token", 0), function (data) {
        PreencherTabela(data);
    });
    $("#divLoading").hide(300);
};

function ObterQuestionariosPorId(id) {
    $("#divLoading").show(300);
    $.getJSON("/Questionario/ObterPorId/" + getCookie("token", 0) + id, function (data) {
        PreencherTabela(data);
    });
    $("#divLoading").hide(300);
};

function ObterQuestionariosPorPalavraChave(chave) {
    $("#divLoading").show(300);
    $.getJSON("/Questionario/ObterPorPalavraChave/" + getCookie("token", 0) + chave, function (data) {
        PreencherTabela(data);
    });
    $("#divLoading").hide(300);
}

$(document).ready(function () {
    ObterQuestionarios();
});

function LimparFormulario() {
    $("#txtId").val("0");
    $("input[type='text']").val("");
    $("input[type='date']").val("0000-00-00");
    $("textarea").val("");
}