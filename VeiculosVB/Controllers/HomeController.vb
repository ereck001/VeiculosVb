Public Class HomeController
    Inherits Controller

    Function Index() As ActionResult

        If Not IsNothing(Session("Autorizado")) Then

            Return View()
        Else
            Return Redirect("/Login/Index")
        End If

    End Function

    Function Veiculos() As ActionResult

        ViewBag.Title = "Catálogo"
        ViewBag.Message = "Relação de Veículos"

        If Not IsNothing(Session("Autorizado")) Then
            Dim lista As List(Of Veiculo) = Veiculo.GetVeiculos()
            ViewBag.Lista = lista

            Return View()
        Else
            Return Redirect("/Login/Index")
        End If

    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Contact page."

        Return View()
    End Function
End Class
