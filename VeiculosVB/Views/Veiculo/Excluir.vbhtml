@Code
    Dim veiculo = ViewBag.Veiculo
End Code
<h2>@ViewBag.Title</h2>
<h3 class="badge bg-secondary" >@ViewBag.Message</h3>

<form action="/veiculo/Deletar" method="post">
    <div class="row">
        <input type="hidden" name="Id" value="@veiculo.Id" />

        <label class="col-sm-2 col-form-label" for="nome">Marca / Modelo: </label>
        <div class="col-sm-4">
            <input class="form-control" type="text" name="nome" id="nome" value="@veiculo.Nome" />
        </div>
    </div>
    <div class="row">
        <label class="col-sm-2 col-form-label" for="modelo">Especificações: </label>
        <div class="col-sm-4">
            <input class="form-control" type="text" name="modelo" id="modelo" value="@veiculo.Modelo" />
        </div>
    </div>
    <div class="row">
        <label class="col-sm-2 col-form-label" for="fabricacao">Ano: </label>
        <div class="col-sm-4">
            <input class="form-control" type="text" name="fabricacao" id="fabricacao" value="@veiculo.Fabricacao" />
        </div>
    </div>
    <div class="row">
        <label class="col-sm-2 col-form-label" for="cor">Cor: </label>
        <div class="col-sm-4">
            <input class="form-control" type="text" name="cor" id="cor" value="@veiculo.Cor" />
        </div>
    </div>
    <div class="row">
        <label class="col-sm-2 col-form-label" for="combustivel">Combustível: </label>
        <div class="col-sm-4">
            <input class="form-control" type="text" name="combustivel" id="combustivel" value="@veiculo.Combustivel" />
        </div>
    </div>
    <div class="row">
        <label class="col-sm-2 col-form-label" for="automatico">Automatico: </label>
        <div class="col-sm-4">
            <input class="form-control" type="text" name="automatico" id="automatico" value="@veiculo.Automatico" />
        </div>
    </div>
    <div class="row">
        <label class="col-sm-2 col-form-label" for="valor">Valor: </label>
        <div class="col-sm-4">
            <input class="form-control" type="text" name="valor" id="valor" value="@veiculo.Valor" />
        </div>
    </div>
    <div>

        <p class="comfirm">Deseja realmente excluir o registro?</p>
        <button class="btn btn-danger" type="submit">Sim</button>
        <a href="/Home/Veiculos"><div class="button btn btn-default">Não</div></a>

    </div>


</form>



