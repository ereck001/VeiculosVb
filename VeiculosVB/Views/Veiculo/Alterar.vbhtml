@ModelType VeiculoViewModel
@Code
    Dim veiculo = ViewBag.Veiculo
End Code
<h2>@ViewBag.Title</h2>
<h3 class="badge bg-secondary">@ViewBag.Message</h3>

@Using Html.BeginForm("Salvar", "Veiculo", FormMethod.Post, New With {.enctype = "multipart/form-data", .id = "formAlterarVeiculo", .name = "formAlterarVeiculo"})

    @<div Class="row">
        <input type="hidden" name="Id" value="@veiculo.Id" />
        @Html.LabelFor(Function(x) x.Nome, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Nome, New With {.class = "form-control", .Value = veiculo.Nome})
            @Html.ValidationMessageFor(Function(x) x.Nome, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<div Class="row">
        @Html.LabelFor(Function(x) x.Modelo, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Modelo, New With {.class = "form-control", .Value = veiculo.Modelo})
            @Html.ValidationMessageFor(Function(x) x.Modelo, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<div Class="row">
        @Html.LabelFor(Function(x) x.Fabricacao, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Fabricacao, New With {.class = "form-control", .Value = veiculo.Fabricacao})
            @Html.ValidationMessageFor(Function(x) x.Fabricacao, "", New With {.class = "text-danger"})
        </div>
    </div>

    @<div Class="row">
        @Html.LabelFor(Function(x) x.Cor, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Cor, New With {.class = "form-control", .Value = veiculo.Cor})
            @Html.ValidationMessageFor(Function(x) x.Cor, "", New With {.class = "text-danger"})
        </div>
    </div>

    @<div Class="row">
        @Html.LabelFor(Function(x) x.Combustivel, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.DropDownListFor(Function(x) x.Combustivel,
                                                                          New SelectList([Enum].GetValues(GetType(CombustivelEnum)), veiculo.Combustivel), New With {.Class = "form-control"})
            @Html.ValidationMessageFor(Function(x) x.Combustivel, "", New With {.class = "text-danger"})
        </div>
    </div>

    @<div Class="row">
        @Html.LabelFor(Function(x) x.Automatico, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @*@Html.TextBoxFor(Function(x) x.Automatico, New With {.class = "form-control", .Value = veiculo.Automatico})*@
            @Html.DropDownListFor(Function(x) x.Automatico,
                                                                               New SelectList([Enum].GetValues(GetType(CambioEnum)), veiculo.Automatico), New With {.Class = "form-control"})
            @Html.ValidationMessageFor(Function(x) x.Automatico, "", New With {.class = "text-danger"})
        </div>
    </div>

    @<div Class="row">
        @Html.LabelFor(Function(x) x.Valor, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Valor, New With {.class = "form-control", .Value = veiculo.Valor.ToString().Replace(".00", "")})
            @Html.ValidationMessageFor(Function(x) x.Valor, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<div Class="row">
        @Html.LabelFor(Function(x) x.Proprietario.Nome, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Proprietario.Nome, New With {.class = "form-control", .Value = veiculo.Proprietario.Nome})
            @Html.ValidationMessageFor(Function(x) x.Proprietario.Nome, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<br />
    @<div Class="row">
        <div>
            <figure class="figure">
                <img class="img-veiculo" src="@veiculo.Imagem" >
            </figure>
        </div>
    </div>

    @<div class="row">
        @Html.LabelFor(Function(x) x.Imagem, New With {.class = "col-sm-2 col-form-label"})
        <div>
            <input type="file" onchange="mostrar()" name="imagemfile" id="imagemfile" class="btn btn-primary" accept="image/png, image/jpeg, image/jpg" />
        </div>
    </div>

    @<div class="button comfirm">
        <button class="btn btn-primary" type="submit">Salvar</button>
    </div>

End Using
