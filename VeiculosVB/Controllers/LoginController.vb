Imports System.Web.Mvc

Namespace Controllers
    Public Class LoginController
        Inherits Controller

        ' GET: Login
        Function Index() As ActionResult

            ViewBag.Title = "Login"
            ViewBag.message = "Página de Login"

            Return View()

        End Function

        <HttpPost>
        Public Function Entrar() As ActionResult

            Dim usuario = New Usuario()
            usuario.Email = Request("Usuario").Trim()
            usuario.Senha = Request("Senha")

            If usuario.Login() Then

                Session("Autorizado") = "OK"
                Return Redirect("/Home/Index")
            Else
                Session("Erro") = "Usuário ou Senha inválidos"
                Session("Autorizado") = Nothing

                Return Redirect("/Login/Index")
            End If

        End Function

    End Class
End Namespace