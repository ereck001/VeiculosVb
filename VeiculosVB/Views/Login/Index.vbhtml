@Code

End Code

<h2 class="comfirm"><br /> @ViewBag.Title</h2>


<form action="/Login/entrar" method="post">
    <div class="row comfirm">
        <label class="col-sm-2 col-form-label" for="usuario">Usuário: </label>
        <div class="col-sm-4">
            <input class="input-dados-carro" type="email" name="usuario" id="usuario" placeholder="exemplo@exemplo.com" trim onchange="limpar()" onfocus="limpar()" />
        </div>
    </div>
    <div class="row comfirm">
        <label class="col-sm-2 col-form-label" for="senha">Senha: </label>
        <div class="col-sm-4">
            <input class="input-dados-carro" type="password" name="senha" id="senha" placeholder="***********************" />
        </div>
    </div>
    <p class="comfirm text-danger ">@Session("Erro")</p>
    <div class="button comfirm">
        <button class="btn btn-primary" type="submit">Entrar</button>
    </div>
    <p class="comfirm"><br /></p>

</form>

<script>
    function limpar() {
        debugger
        var textoUsuario = $("#usuario")        

        textoUsuario.val(textoUsuario.val().trim())        
    }    
    
</script>