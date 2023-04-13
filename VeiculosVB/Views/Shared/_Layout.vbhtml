<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="~/favicon.png" type="image/x-icon">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css">
    <title>@ViewBag.Title - Meu Aplicativo ASP.NET</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <div id="fundo-imagem" onclick="EsconderImagem()" ><figure><img id="arq-img" src=""/></figure></div>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                @If Not IsNothing(Session("Autorizado")) Then
                    @<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                End If
                @Html.ActionLink("Nome do aplicativo", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    @If Not IsNothing(Session("Autorizado")) Then
                        @<li>@Html.ActionLink("Início", "Index", "Home")</li>
                        @<li>@Html.ActionLink("Veículos", "Veiculos", "Home")</li>
                        @<li>@Html.ActionLink("Contato", "Contact", "Home")</li>
                        @<li>@Html.ActionLink("Sair", "Sair", "Logout")</li>
                    End If

                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Meu Aplicativo ASP.NET</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
<script>
    var image = $("#fundo-imagem")
    image.hide()

    function EsconderImagem() {        
        image.hide() 
    }
</script>
