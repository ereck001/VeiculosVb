@Code

End Code

<h2>@ViewBag.Title</h2>
<h3 class="badge bg-secondary">@ViewBag.Message</h3>

<p class="text-left"><a class="btn btn-primary" href="/veiculo/adicionar"><i style="padding-right:3px;" class="bi bi-plus-circle-fill"></i>Adicionar</a></p>
<br />


<table class="table table-success table-striped">
    <tr>
        <th>Marca / Modelo</th>
        <th>Especificações</th>
        <th>Fabricacao</th>
        <th>Cor</th>
        <th>Combustivel</th>
        <th>Automatico</th>
        <th>Valor</th>
        <th>Proprietário</th>
        <th>Imagem</th>
        <th>Alterar</th>
        <th>Excluir</th>
    </tr>
    @For Each item In ViewBag.Lista

        @<tr>
            <td class="text-left">@item.Nome</td>
            <td class="text-left">@item.Modelo</td>
            <td>@item.Fabricacao</td>
            <td>@item.Cor</td>
            <td>@item.Combustivel</td>
            <td>@item.Automatico</td>
            <td>@item.Valor</td>
            <td>@item.Proprietario.Nome</td>
            <td><a href="#fundo-imagem" onclick="MostarImagem('@item.Imagem')" ><i class="bi bi-file-richtext"></i></a></td>
            <td><a href="/veiculo/alterar/@item.Id"><i class="bi bi-pencil"></i></a></td>
            <td><a href="/veiculo/Excluir/@item.Id"><i class="bi bi-x-circle"></i></a></td>
        </tr>
    Next
</table>
<script>
    
    function MostarImagem(imgSrc) {
        //alert(imgSrc)    
        var mainImage = $("#arq-img")
        //mainImage.val(imgSrc)
        mainImage.attr('src', imgSrc)        
        image.show()
    }
</script>





