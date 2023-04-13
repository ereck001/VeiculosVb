Imports System.Web.Mvc

Namespace Controllers
    Public Class LogoutController
        Inherits Controller

        ' GET: Logout
        Function Sair() As ActionResult
            Session.Abandon()
            Return Redirect("/Login/Index")
        End Function
    End Class
End Namespace