$("#btnPesquisar").click(function () {
    if ($("#txtPalavraChave").val() == "") {
        ObterQuestionarios();
    }
    else {
        //$("#divLoading").show(300);
        $.ajax({
            type: 'POST',
            url: '/Questionario/ObterPorPalavraChave',
            data: { Chave: $("#txtPalavraChave").val(), IdUsuario: getCookie("token", 0) },
            success: function (result) {
                if (result != null && result.length > 0) {
                    PreencherTabela(result);
                }
                else {
                    bootbox.alert("Nenhum questionário encontrado.");
                }
                //$("#divLoading").hide(300);
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                //$("#divLoading").hide(300);
            }
        });
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
    //$("#divLoading").show(300);
    $.ajax({
        type: 'POST',
        url: '/Questionario/ObterPorId',
        data: { Id: id, IdUsuario: getCookie("token", 0) },
        success: function (result) {
            if (Object.keys(result).length > 0) {
                $("#divLoading").hide(300);
                $.fancybox.open({
                    src: '#formAltQuestionario',
                    type: 'inline'
                });
                $("#txtIdAlt").val(result.Id);
                $("#txtTituloAlt").val(result.Nome);
                $("#txtDataInicioAlt").val(FormatarDataIso(result.Inicio));
                $("#txtDataFimAlt").val(FormatarDataIso(result.Fim));
                $("#txtFeedbackAlt").val(result.MsgFeedback);
                $("#txtGuidAlt").val(result.Guid);
            }
            else {
                //$("#divLoading").hide(300);
            }
        },
        error: function (XMLHttpRequest, txtStatus, errorThrown) {
            alert("Status: " + txtStatus); alert("Error: " + errorThrown);
            //$("#divLoading").hide(300);
        }
    });
};

function Excluir(id) {
    bootbox.confirm({
        message: "Confirma a exclusão deste registro?",
        buttons: {
            confirm: {
                label: 'Sim',
                className: 'btn-success'
            },
            cancel: {
                label: 'Não',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: '/Questionario/Excluir',
                    data: { Id: id },
                    success: function (result) {
                        if (result == "") {
                            ObterQuestionarios();
                        }
                        else {
                            Mensagem("divAlerta", result);
                        }
                    },
                    error: function (XMLHttpRequest, txtStatus, errorThrown) {
                        alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                        $("#divLoading").hide(300);
                    }
                });
            }
        }
    });
};

$("#btnConfirmarNovo").click(function () {
    var msg = "";
    var id = $("#txtIdNovo").val();
    var titulo = $("#txtTituloNovo").val();
    var inicio = $("#txtDataInicioNovo").val();
    var fim = $("#txtDataFimNovo").val();
    var feedback = $("#txtFeedbackNovo").val();
    var guid = $("#txtGuidNovo").val();
    var arquivos = document.getElementById("fuImagemNovo");

    var formData = new FormData();
    formData.append("Id", id);
    formData.append("Nome", titulo);
    formData.append("Inicio", inicio);
    formData.append("Fim", fim);
    formData.append("FeedBack", feedback);
    formData.append("Guid", guid);
    formData.append("Imagem", arquivos.files[0]);

    if (titulo == "") {
        msg += "Por favor, informe um título para o questionário.<br />";
    }
    if (inicio == "") {
        msg += "Por favor, informe a data para início do questionário.<br />";
    }
    if (fim == "") {
        msg += "Por favor, informe a data para fechamento do questionário.<br />";
    }
    if (guid == "") {
        msg += "Por favor, informe a Guid (URL) para o questionário.<br />";
    }
    if (msg.length > 0) {
        Mensagem("divAlertaNovoQuestionario", msg);
    }
    else {
        //$("#divLoading").show(300);
        $.ajax({
            type: 'POST',
            url: '/Questionario/Gravar',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (result) {
                //$("#divLoading").hide(300);
                if (result.length > 0) {
                    Mensagem("divAlertaNovoQuestionario", result);
                }
                else {
                    LimparFormulario();
                    $.fancybox.close();
                    ObterQuestionarios();
                }
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                //$("#divLoading").hide(300);
            }
        });
    }
});

$("#btnConfirmarAlt").click(function () {
    var msg = "";
    var id = $("#txtIdAlt").val();
    var titulo = $("#txtTituloAlt").val();
    var inicio = $("#txtDataInicioAlt").val();
    var fim = $("#txtDataFimAlt").val();
    var feedback = $("#txtFeedbackAlt").val();
    var guid = $("#txtGuidAlt").val();
    var arquivos = document.getElementById("fuImagemAlt");

    var formData = new FormData();
    formData.append("Id", id);
    formData.append("Nome", titulo);
    formData.append("Inicio", inicio);
    formData.append("Fim", fim);
    formData.append("FeedBack", feedback);
    formData.append("Guid", guid);
    formData.append("Imagem", arquivos.files[0]);

    if (titulo == "") {
        msg += "Por favor, informe um título para o questionário.<br />";
    }
    if (inicio == "") {
        msg += "Por favor, informe a data para início do questionário.<br />";
    }
    if (fim == "") {
        msg += "Por favor, informe a data para fechamento do questionário.<br />";
    }
    if (guid == "") {
        msg += "Por favor, informe a Guid (URL) para o questionário.<br />";
    }
    if (msg != "") {
        Mensagem("divAlertaAltQuestionario", msg);
    }
    else {
        //$("#divLoading").show(300);
        $.ajax({
            type: 'POST',
            url: '/Questionario/Alterar',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (result) {
                //$("#divLoading").hide(300);
                if (result != "") {
                    $("#divAlertaAltQuestionario").html(result);
                    $("#divAlertaAltQuestionario").show(300);
                    $("#divAlertaAltQuestionario").delay(5000);
                    $("#divAlertaAltQuestionario").hide(300);
                }
                else {
                    LimparFormulario();
                    $.fancybox.close();
                    ObterQuestionarios();
                }
            },
            error: function (error) {
                alert(error);
                //$("#divLoading").hide(300);
            }
        });
    }
});

function ObterQuestionarios() {
    //$("#divLoading").show(300);
    $.getJSON("/Questionario/ObterPorUsuario/" + getCookie("token", 0), function (data) {
        PreencherTabela(data);
    });
    //$("#divLoading").hide(300);
};

$(document).ready(function () {
    ObterQuestionarios();
});

function LimparFormulario() {
    $("#txtId").val("0");
    $("input[type='text']").val("");
    $("input[type='date']").val("0000-00-00");
    $("textarea").val("");
}