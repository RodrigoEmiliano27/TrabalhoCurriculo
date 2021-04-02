var formacoes = document.getElementsByClassName("formacao-item").length;
var idiomas = document.getElementsByClassName("idioma-item").length
var habilidades = document.getElementsByClassName("habilidade-item").length;


var idiomaSelecionado = getCookie("Curriculo_Idioma");

divFormacao = document.getElementById("formacao_group");
btFormacao = document.getElementById("btAddFormacao");

btFormacao.onclick = adcionaFormacao;


divIdiomas = document.getElementById("idiomas_group");
btIdiomas = document.getElementById("btAddIdioma");

btIdiomas.onclick = adcionaIdioma;

divHabilidades = document.getElementById("habilidades_group");
btHabilidades = document.getElementById("btAddHabilidade");

btHabilidades.onclick = adcionaHabilidade;

function adcionaFormacao() {

    formacaoDiv = document.createElement("div");
    formacaoDiv.setAttribute("class", `formacao-item ${formacoes}`);


    //id

    idInput = document.createElement("input");
    idInput.setAttribute("type", "text");
    idInput.setAttribute("name", `Formacao[${formacoes}].Id`);
    idInput.setAttribute("class", `form-control hide`);

    formacaoDiv.appendChild(idInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Formacao[${formacoes}].Id`);
    spanValidation.setAttribute("class", "text-danger");

    formacaoDiv.appendChild(spanValidation);
    formacaoDiv.appendChild(document.createElement("br"));
    //id curriculo

    idCurriculoInput = document.createElement("input");
    idCurriculoInput.setAttribute("type", "text");
    idCurriculoInput.setAttribute("name", `Formacao[${formacoes}].IdCurriculo`);
    idCurriculoInput.setAttribute("class", `form-control hide`);

    formacaoDiv.appendChild(idCurriculoInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Formacao[${formacoes}].IdCurriculo`);
    spanValidation.setAttribute("class", "text-danger");

    formacaoDiv.appendChild(spanValidation);
    formacaoDiv.appendChild(document.createElement("br"));

    // instituição


    instituicaoLabel = document.createElement("label")
    instituicaoLabel.setAttribute("for", `Formacao[${formacoes}]`);

    if (idiomaSelecionado == "I") {
        instituicaoLabel.innerHTML = "Institution";
    }
    else {
        instituicaoLabel.innerHTML = "Instituicao";

    }
    instituicaoLabel.setAttribute("class", "control-label");
    formacaoDiv.appendChild(instituicaoLabel);

    instituicaoInput = document.createElement("input");
    instituicaoInput.setAttribute("type", "text");
    instituicaoInput.setAttribute("name", `Formacao[${formacoes}].Instituicao`);
    instituicaoInput.setAttribute("class", `form-control`);

    formacaoDiv.appendChild(instituicaoInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Formacao[${formacoes}].Instituicao`);
    spanValidation.setAttribute("class", "text-danger");

    formacaoDiv.appendChild(spanValidation);
    formacaoDiv.appendChild(document.createElement("br"));


    //descricao
    descricaoLabel = document.createElement("label")
    descricaoLabel.setAttribute("for", `Formacao[${formacoes}].Descricao`);

    if (idiomaSelecionado == "I") {
        descricaoLabel.innerHTML = "Descrição";
    }
    else {
        descricaoLabel.innerHTML = "Description";
    }

    descricaoLabel.setAttribute("class", "control-label");

    formacaoDiv.appendChild(descricaoLabel);

    descricaoInput = document.createElement("input");
    descricaoInput.setAttribute("type", "text");
    descricaoInput.setAttribute("name", `Formacao[${formacoes}].Descricao`);
    descricaoInput.setAttribute("class", `form-control`);
    formacaoDiv.appendChild(descricaoInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Formacao[${formacoes}].Descricao`);
    spanValidation.setAttribute("class", "text-danger");

    formacaoDiv.appendChild(spanValidation);
    formacaoDiv.appendChild(document.createElement("br"));


    //Inicio
    inicioLabel = document.createElement("label")
    inicioLabel.setAttribute("for", `Formacao[${formacoes}].Inicio`);

    if (idiomaSelecionado == "I") {
        inicioLabel.innerHTML = "Start";
    }
    else {
        inicioLabel.innerHTML = "Inicio";
    }
    inicioLabel.setAttribute("class", "control-label");

    formacaoDiv.appendChild(inicioLabel);

    inicioInput = document.createElement("input");
    inicioInput.setAttribute("type", "date");
    inicioInput.setAttribute("name", `Formacao[${formacoes}].Inicio`);
    inicioInput.setAttribute("class", `form-control`);

    formacaoDiv.appendChild(inicioInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Formacao[${formacoes}].Inicio`);
    spanValidation.setAttribute("class", "text-danger");

    formacaoDiv.appendChild(spanValidation);
    formacaoDiv.appendChild(document.createElement("br"));


    //Fim
    fimLabel = document.createElement("label")
    fimLabel.setAttribute("for", `Formacao[${formacoes}].Fim`);

    if (idiomaSelecionado == "I") {
        fimLabel.innerHTML = "End";
    }
    else {
        fimLabel.innerHTML = "Fim";
    }

    fimLabel.setAttribute("class", "control-label");

    formacaoDiv.appendChild(fimLabel);

    fimInput = document.createElement("input");
    fimInput.setAttribute("type", "date");
    fimInput.setAttribute("name", `Formacao[${formacoes}].Fim`);
    fimInput.setAttribute("class", `form-control`);

    formacaoDiv.appendChild(fimInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Formacao[${formacoes}].Fim`);
    spanValidation.setAttribute("class", "text-danger");

    formacaoDiv.appendChild(spanValidation);
    formacaoDiv.appendChild(document.createElement("br"));

    //delete
    buttonRemove = document.createElement("div");
    buttonRemove.setAttribute("id", `btRemoveFormacao ${formacoes}`);
    buttonRemove.setAttribute("onclick", `removeFormacao(this)`);
    buttonRemove.setAttribute("class", `remove`);

    icon = document.createElement("i");
    icon.setAttribute("class", `far fa-trash-alt fa-3x`);

    text = document.createElement("h4");

    if (idiomaSelecionado == "I") {
        text.innerHTML = "Remove";
    }
    else {
        text.innerHTML = "Remover";
    }

    buttonRemove.appendChild(icon);
    buttonRemove.appendChild(text);

    formacaoDiv.appendChild(buttonRemove);

    formacoes++;

    divFormacao.appendChild(formacaoDiv);

}

function adcionaIdioma() {

    idiomaDiv = document.createElement("div")
    idiomaDiv.setAttribute("class", `idioma-item ${idiomas}`);

    //id

    idInput = document.createElement("input");
    idInput.setAttribute("type", "text");
    idInput.setAttribute("name", `Idiomas[${idiomas}].Id`);
    idInput.setAttribute("class", "form-control hide")

    idiomaDiv.appendChild(idInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Idiomas[${idiomas}].Id`);
    spanValidation.setAttribute("class", "text-danger");

    idiomaDiv.appendChild(spanValidation);
    idiomaDiv.appendChild(document.createElement("br"));


    //id curriculo
    idCurriculoInput = document.createElement("input");
    idCurriculoInput = document.createElement("input");
    idCurriculoInput.setAttribute("type", "text");
    idCurriculoInput.setAttribute("name", `Idiomas[${idiomas}].IdCurriculo`);
    idCurriculoInput.setAttribute("class", "form-control hide");

    idiomaDiv.appendChild(idCurriculoInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Idiomas[${idiomas}].IdCurriculo`);
    spanValidation.setAttribute("class", "text-danger");

    idiomaDiv.appendChild(spanValidation);
    idiomaDiv.appendChild(document.createElement("br"));

    // idioma

    idiomaLabel = document.createElement("label")
    idiomaLabel.setAttribute("for", `Idiomas[${idiomas}].Idioma`);

    if (idiomaSelecionado == "I") {
        idiomaLabel.innerHTML = "Language";
    }
    else {
        idiomaLabel.innerHTML = "Idioma";
    }

    idiomaLabel.setAttribute("class", "control-label");

    idiomaDiv.appendChild(idiomaLabel);

    idiomaInput = document.createElement("input");
    idiomaInput.setAttribute("type", "text");
    idiomaInput.setAttribute("name", `Idiomas[${idiomas}].Idioma`);
    idiomaInput.setAttribute("class", "form-control");

    idiomaDiv.appendChild(idiomaInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Idiomas[${idiomas}].Idioma`);
    spanValidation.setAttribute("class", "text-danger");

    idiomaDiv.appendChild(spanValidation);
    idiomaDiv.appendChild(document.createElement("br"));

    // nivel

    nivelLabel = document.createElement("label")
    nivelLabel.setAttribute("for", `Idiomas[${idiomas}].Nivel`);

    if (idiomaSelecionado == "I") {
        nivelLabel.innerHTML = "Level";
    }
    else {
        nivelLabel.innerHTML = "Nivel";
    }

    nivelLabel.setAttribute("class", "control-label");

    idiomaDiv.appendChild(nivelLabel);

    //nivel input
    nivelInput = document.createElement("select");
    nivelInput.setAttribute("name", `Idiomas[${idiomas}].Nivel`);
    nivelInput.setAttribute("value", `Idiomas[${idiomas}].Nivel`);
    nivelInput.setAttribute("class", "form-control");

    let opcoes = ["Iniciante", "Intermediario", "Avançado"];

    if (idiomaSelecionado == "I") {
        opcoes = ["Beginner", "Intermediary", "Advanced"];
    }

    for (count = 0; count < 3; count++) {
        mOption = document.createElement("option");
        mOption.value = opcoes[count];
        mOption.innerHTML = opcoes[count];
        nivelInput.appendChild(mOption);
    }


    idiomaDiv.appendChild(nivelInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Idiomas[${idiomas}].Nivel`);
    spanValidation.setAttribute("class", "text-danger");

    idiomaDiv.appendChild(spanValidation);
    idiomaDiv.appendChild(document.createElement("br"));

    //delete
    buttonRemove = document.createElement("div");
    buttonRemove.setAttribute("id", `btRemoveIdioma ${idiomas}`);
    buttonRemove.setAttribute("onclick", `removeIdioma(this)`);
    buttonRemove.setAttribute("class", `remove`);

    icon = document.createElement("i");
    icon.setAttribute("class", `far fa-trash-alt fa-3x`);

    text = document.createElement("h4");

    if (idiomaSelecionado == "I") {
        text.innerHTML = "Remove";
    }
    else {
        text.innerHTML = "Remover";
    }

    buttonRemove.appendChild(icon);
    buttonRemove.appendChild(text);

    idiomaDiv.appendChild(buttonRemove);

    idiomas++;
    divIdiomas.appendChild(idiomaDiv);

}

function removeHabilidade(e) {
    //recupera o id do container que envolve o elemento a ser excluido
    removeId = e.id.replace("btRemoveHabilidade ", "");

    //recupera a div que forma o containerr
    itemToRemove = document.getElementsByClassName(`habilidade-item ${removeId}`)[0]

    //alterar o id do curriculo
    idCurriculoElement = itemToRemove.getElementsByClassName("form-control hide")[1]
    idCurriculoElement.value = "-1"

    //esconde a habilidade
    itemToRemove.setAttribute("class", "hide");

}

function removeIdioma(e) {
    //recupera o id do container que envolve o elemento a ser excluido
    removeId = e.id.replace("btRemoveIdioma ", "");

    //recupera a div que forma o container
    itemToRemove = document.getElementsByClassName(`idioma-item ${removeId}`)[0]

    //alterar o id do curriculo
    idCurriculoElement = itemToRemove.getElementsByClassName("form-control hide")[1]
    idCurriculoElement.value = "-1"

    //esconde o idioma
    itemToRemove.setAttribute("class", "hide");

}

function removeFormacao(e) {
    //recupera o id do container que envolve o elemento a ser excluido
    removeId = e.id.replace("btRemoveFormacao ", "");

    //recupera a div que forma o container
    itemToRemove = document.getElementsByClassName(`formacao-item ${removeId}`)[0]

    //alterar o id do curriculo
    idCurriculoElement = itemToRemove.getElementsByClassName("form-control hide")[1]
    idCurriculoElement.value = "-1"

    //esconde a formacao
    itemToRemove.setAttribute("class", "hide");

}

function adcionaHabilidade() {

    habilidadeDiv = document.createElement("div")
    habilidadeDiv.setAttribute("class", `habilidade-item ${habilidades}`);

    //id

    idInput = document.createElement("input");
    idInput.setAttribute("type", "text");
    idInput.setAttribute("name", `Habilidades[${habilidades}].Id`);
    idInput.setAttribute("class", "form-control hide");

    habilidadeDiv.appendChild(idInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Habilidades[${habilidades}].Id`);
    spanValidation.setAttribute("class", "text-danger");

    habilidadeDiv.appendChild(spanValidation);
    habilidadeDiv.appendChild(document.createElement("br"));


    //id curriculo

    idCurriculoInput = document.createElement("input");
    idCurriculoInput.setAttribute("type", "text");
    idCurriculoInput.setAttribute("name", `Habilidades[${habilidades}].IdCurriculo`);
    idCurriculoInput.setAttribute("class", "form-control hide");

    habilidadeDiv.appendChild(idCurriculoInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Habilidades[${habilidades}].IdCurriculo`);
    spanValidation.setAttribute("class", "text-danger");

    habilidadeDiv.appendChild(spanValidation);
    habilidadeDiv.appendChild(document.createElement("br"));

    // descricao

    descricaoLabel = document.createElement("label")
    descricaoLabel.setAttribute("for", `Habilidades[${habilidades}].Descricao`);

    if (idiomaSelecionado == "I") {
        descricaoLabel.innerHTML = "Description";
    }
    else {
        descricaoLabel.innerHTML = "Descrição";
    }

    descricaoLabel.setAttribute("class", "control-label");

    habilidadeDiv.appendChild(descricaoLabel);

    descricaoInput = document.createElement("input");
    descricaoInput.setAttribute("type", "text");
    descricaoInput.setAttribute("name", `Habilidades[${habilidades}].Descricao`);
    descricaoInput.setAttribute("class", "form-control");

    habilidadeDiv.appendChild(descricaoInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Habilidades[${habilidades}].Descricao`);
    spanValidation.setAttribute("class", "text-danger");

    habilidadeDiv.appendChild(spanValidation);
    habilidadeDiv.appendChild(document.createElement("br"));

    // nivel

    nivelLabel = document.createElement("label")
    nivelLabel.setAttribute("for", `Habilidades[${habilidades}].Nivel`);

    if (idiomaSelecionado == "I") {
        nivelLabel.innerHTML = "Level";
    }
    else {
        nivelLabel.innerHTML = "Nivel";
    }

    nivelLabel.setAttribute("class", "control-label");

    habilidadeDiv.appendChild(nivelLabel);
    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Habilidades[${habilidades}].Nivel`);
    spanValidation.setAttribute("class", "text-danger");

    habilidadeDiv.appendChild(spanValidation);
    habilidadeDiv.appendChild(document.createElement("br"));


    //nivel input
    nivelInput = document.createElement("select");
    nivelInput.setAttribute("name", `Habilidades[${habilidades}].Nivel`);
    nivelInput.setAttribute("value", `Habilidades[${habilidades}].Nivel`);
    nivelInput.setAttribute("class", "form-control");

    let opcoes = ["Iniciante", "Intermediario", "Avançado"];

    if (idiomaSelecionado == "I") {
        opcoes = ["Beginner", "Intermediary", "Advanced"];
    }


    for (count = 0; count < 3; count++) {
        mOption = document.createElement("option");
        mOption.value = count;
        mOption.innerHTML = opcoes[count];
        nivelInput.appendChild(mOption);
    }

    habilidadeDiv.appendChild(nivelInput);

    //validation
    spanValidation = document.createElement("span");
    spanValidation.setAttribute("asp-validation-for", `Habilidades[${habilidades}].Nivel`);
    spanValidation.setAttribute("class", "text-danger");

    habilidadeDiv.appendChild(spanValidation);
    habilidadeDiv.appendChild(document.createElement("br"));


    //remove
    buttonRemove = document.createElement("div");
    buttonRemove.setAttribute("id", `btRemoveHabilidade ${habilidades}`);
    buttonRemove.setAttribute("onclick", `removeHabilidade(this)`);
    buttonRemove.setAttribute("class", `remove`);

    icon = document.createElement("i");
    icon.setAttribute("class", `far fa-trash-alt fa-3x`);

    text = document.createElement("h4");

    if (idiomaSelecionado == "I") {
        text.innerHTML = "Remove";
    }
    else {
        text.innerHTML = "Remover";
    }

    buttonRemove.appendChild(icon);
    buttonRemove.appendChild(text);


    habilidadeDiv.appendChild(buttonRemove);

    habilidades++;

    divHabilidades.appendChild(habilidadeDiv);
}

function exibirImagem() {
    var oFReader = new FileReader();
    oFReader.readAsDataURL(document.getElementById("Imagem").files[0]);
    oFReader.onload = function (oFREvent) {
        document.getElementById("imgPreview").src = oFREvent.target.result;
    };

    //exibe botão de remover imagem
    btRemoveImg = document.getElementById("btRemoveImage");
    btRemoveImg.className = "remove shadow";

    //indica ao controller que a imagem vai ser editada
    document.getElementById("editarImg").value = "Editar";

}

function removeImage() {


    document.getElementById("Imagem").value = "";

    //clear image preview
    document.getElementById("imgPreview").src = "";

    //hide delete button
    buttonRemoveImg = document.getElementById("btRemoveImage");
    buttonRemoveImg.setAttribute("class", "hide");

    //remover quaisquer indicações de edição
    document.getElementById("editarImg").value = "Editar";
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}