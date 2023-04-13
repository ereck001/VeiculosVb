Imports System.IO
Imports System.Web.Mvc

Namespace Controllers
    Public Class VeiculoController
        Inherits Controller

        ' GET: Veiculo
        Function Adicionar() As ActionResult
            ViewBag.Title = "Cadastro de Veículos"
            ViewBag.Message = "Adicionar"

            If Not IsNothing(Session("Autorizado")) Then

                Return View()
            Else
                Return Redirect("/Login/Index")
            End If
        End Function
        Function Alterar(id As Integer) As ActionResult
            ViewBag.Title = "Cadastro de Veículos"
            ViewBag.Message = "Alterar"

            If Not IsNothing(Session("Autorizado")) Then

                Dim veiculo As Veiculo = New Veiculo()
                veiculo.GetVeiculo(id)
                ViewBag.Veiculo = veiculo

                Return View()

            Else
                Return Redirect("/Login/Index")
            End If

        End Function

        Function Excluir(id As Integer) As ActionResult
            ViewBag.Title = "Cadastro de Veículos"
            ViewBag.Message = "Excluir"

            If Not IsNothing(Session("Autorizado")) Then

                Dim veiculo As Veiculo = New Veiculo()
                veiculo.GetVeiculo(id)
                ViewBag.Veiculo = veiculo
                Return View()

            Else
                Return Redirect("/Login/Index")
            End If

        End Function

        <HttpPost>
        Function Salvar(veiculoView As VeiculoViewModel) As ActionResult

            Dim nomeArq = Guid.NewGuid().ToString().Substring(0, 8)
            ' Verificar se o arquivo foi enviado
            If Request.Files.Count > 0 Then
                ' Obter o arquivo enviado
                Dim arquivo As HttpPostedFileBase = Request.Files(0)

                ' Verificar se o arquivo é válido
                If arquivo IsNot Nothing AndAlso arquivo.ContentLength > 0 Then
                    ' Ler o conteúdo do arquivo
                    Dim stream As New MemoryStream
                    arquivo.InputStream.CopyTo(stream)
                    Dim fileBytes As Byte() = stream.ToArray()

                    ' Converter para base64
                    Dim base64String As String = Convert.ToBase64String(fileBytes)

                    Dim imageBytes As Byte() = Convert.FromBase64String(base64String)

                    IO.File.WriteAllBytes(Server.MapPath($"../Images/{nomeArq}.jpg"), imageBytes)

                End If
            End If



            Dim veiculo = New Veiculo()

            veiculo.Id = veiculoView.Id
            veiculo.Nome = veiculoView.Nome
            veiculo.Modelo = veiculoView.Modelo
            veiculo.Fabricacao = veiculoView.Fabricacao
            veiculo.Ano = veiculoView.Ano
            veiculo.Cor = veiculoView.Cor
            veiculo.Combustivel = veiculoView.Combustivel
            veiculo.Automatico = veiculoView.Automatico
            veiculo.Valor = veiculoView.Valor
            veiculo.Proprietario = veiculoView.Proprietario
            veiculo.Imagem = $"/Images/{nomeArq}.jpg"

            If veiculo.Proprietario.Id = 0 Then
                veiculo.Proprietario.CreateProprietario()
            End If


            If ModelState.IsValid Then

                veiculo.Salvar()
                Return Redirect("/Home/Veiculos")

            Else

                ViewBag.Title = "Cadastro de Veículos"
                ViewBag.Message = "Adicionar"

                Return View("Adicionar")

            End If

            Return Redirect("/Home/Veiculos")

        End Function

        <HttpPost>
        Function Deletar() As ActionResult

            Dim veiculo As New Veiculo()
            veiculo.Id = Convert.ToInt32(Request("Id"))

            veiculo.Excluir(veiculo.Id)

            Return Redirect("/Home/Veiculos")

        End Function


    End Class

End Namespace