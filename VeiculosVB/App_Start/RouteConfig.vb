Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute(
            "VeiculoAlterar",
            "Veiculo/Alterar/:id",
            New With {.controller = "Veiculo", .action = "Alterar", .id = 0}
            )
        routes.MapRoute(
            "VeiculoExcluir",
            "Veiculo/Excluir/:id",
            New With {.controller = "Veiculo", .action = "Excluir", .id = 0}
            )

        routes.MapRoute(
            "VeiculoSalvar",
            "Veiculo/Salvar",
            New With {.controller = "Veiculo", .action = "Salvar"}
            )

        routes.MapRoute(
            "Veiculo",
            "Veiculo/Adicionar",
            New With {.controller = "Veiculo", .action = "Adicionar"}
            )
        'routes.MapRoute(
        '    "Sair",
        '    "Login/Sair",
        '    New With {.controller = "Login", .action = "Sair"}
        '    )

        routes.MapRoute(
            name:="Default",
            url:="{controller}/{action}/{id}",
            defaults:=New With {.controller = "Login", .action = "Index", .id = UrlParameter.Optional}
        )
    End Sub
End Module