@ModelType VeiculoViewModel

<h2>@ViewBag.Title</h2>
<h3 class="badge bg-secondary">@ViewBag.Message</h3>
@Using Html.BeginForm("Salvar", "Veiculo", FormMethod.Post, New With {.enctype = "multipart/form-data", .id = "formAlterarVeiculo", .name = "formAlterarVeiculo"})

    @<div Class="row">
        @Html.LabelFor(Function(x) x.Nome, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Nome, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(x) x.Nome, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<div Class="row">
        @Html.LabelFor(Function(x) x.Modelo, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Modelo, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(x) x.Modelo, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<div Class="row">
        @Html.LabelFor(Function(x) x.Fabricacao, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Fabricacao, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(x) x.Fabricacao, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<div Class="row">
        @Html.LabelFor(Function(x) x.Cor, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Cor, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(x) x.Cor, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<div Class="row">
        @Html.LabelFor(Function(x) x.Combustivel, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.DropDownListFor(Function(x) x.Combustivel,
                                                                        New SelectList([Enum].GetValues(GetType(CombustivelEnum))), "Selecione o Combustível", New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(x) x.Combustivel, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<div Class="row">
        @Html.LabelFor(Function(x) x.Automatico, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">           
            @Html.DropDownListFor(Function(x) x.Automatico,
                                                                   New SelectList([Enum].GetValues(GetType(CambioEnum))), "Selecione o Cambio", New With {.class = "form-control"})
          
        </div>
    </div>
    @<div Class="row">
        @Html.LabelFor(Function(x) x.Valor, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Valor, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(x) x.Valor, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<div Class="row">
        @Html.LabelFor(Function(x) x.Proprietario.Nome, New With {.class = "col-sm-2 col-form-label"})
        <div Class="col-sm-4">
            @Html.TextBoxFor(Function(x) x.Proprietario.Nome, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(x) x.Proprietario.Nome, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<br />

    @<div class="row">
        @Html.LabelFor(Function(x) x.Imagem, New With {.class = "col-sm-2 col-form-label"})
         <div>
             <input type="file" onchange="mostrar()" name="imagemfile" id="imagemfile" class="btn btn-primary" accept="image/png, image/jpeg, image/jpg"  />
         </div>
    </div>

    @<div Class="button comfirm">
        <Button Class="btn btn-primary" type="submit">Salvar</Button>
    </div>


End Using
