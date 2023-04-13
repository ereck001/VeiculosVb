Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.ComponentModel.DataAnnotations

Public Class Veiculo
    Public Sub New()
        Me.Proprietario = New Proprietario()
    End Sub

    Public Sub New(id As Integer, nome As String, modelo As String, ano As Short, fabricacao As Short, cor As String, combustivel As CombustivelEnum, automatico As CambioEnum, valor As Decimal, ativo As Boolean)

        Me.Id = id
        Me.Nome = nome
        Me.Modelo = modelo
        Me.Ano = ano
        Me.Fabricacao = fabricacao
        Me.Cor = cor
        Me.Combustivel = combustivel
        Me.Automatico = automatico
        Me.Valor = valor
        Me.Ativo = ativo

    End Sub

    Public Sub New(id As Integer, nome As String, modelo As String, ano As Short, fabricacao As Short, cor As String, combustivel As CombustivelEnum, automatico As CambioEnum, valor As Decimal, ativo As Boolean, proprietario As Proprietario, imagem As String)

        Me.Id = id
        Me.Nome = nome
        Me.Modelo = modelo
        Me.Ano = ano
        Me.Fabricacao = fabricacao
        Me.Cor = cor
        Me.Combustivel = combustivel
        Me.Automatico = automatico
        Me.Valor = valor
        Me.Ativo = ativo
        Me.Proprietario = proprietario
        Me.Imagem = imagem

    End Sub

    Public Sub New(nome As String, modelo As String, ano As Short, fabricacao As Short, cor As String, combustivel As CombustivelEnum, automatico As CambioEnum, valor As Decimal, ativo As Boolean, proprietarioNome As String)
        Me.Nome = nome
        Me.Modelo = modelo
        Me.Ano = ano
        Me.Fabricacao = fabricacao
        Me.Cor = cor
        Me.Combustivel = combustivel
        Me.Automatico = automatico
        Me.Valor = valor
        Me.Ativo = ativo

        Dim proprietario = New Proprietario(proprietarioNome)

        If proprietario.Nome = Nothing Then
            proprietario.CreateProprietario()
        End If

        Me.Proprietario = proprietario

    End Sub

    Private Shared ReadOnly _conn As String = WebConfigurationManager.ConnectionStrings("conn").ConnectionString
    Public Property Id As Integer

    <Display(Name:="Marca / Modelo:")>
    <Required(ErrorMessage:="O campo Marca / Modelo é obrigatório")>
    Public Property Nome As String

    <Display(Name:="Especificações:")>
    <Required(ErrorMessage:="O campo Especificações é obrigatório")>
    Public Property Modelo As String

    Public Property Ano As Short

    <Display(Name:="Ano:")>
    <Required(ErrorMessage:="O campo Ano é obrigatório")>
    <Range(1900, 2050, ErrorMessage:="O ano deve estar entre {1} e {2}")>
    Public Property Fabricacao As Short

    <Display(Name:="Cor:")>
    <Required(ErrorMessage:="O campo Cor é obrigatório")>
    Public Property Cor As String

    <Display(Name:="Combustível:")>
    <Range(1, 5, ErrorMessage:="O Combustível deve estar entre {1} e {2}")>
    <Required(ErrorMessage:="O campo Combustível é obrigatório")>
    Public Property Combustivel As CombustivelEnum

    <Display(Name:="Automático:")>
    <Required(ErrorMessage:="O campo Automático é obrigatório")>
    Public Property Automatico As CambioEnum

    <Display(Name:="Valor:")>
    <Required(ErrorMessage:="O campo Valor é obrigatório")>
    Public Property Valor As Decimal

    <Display(Name:="Ativo:")>
    Public Property Ativo As Boolean
    Public Property Imagem As String

    Public Property Proprietario As Proprietario
    Public Shared Function GetVeiculos() As List(Of Veiculo)

        Dim listaCarros As New List(Of Veiculo)()
        Dim sql = "SELECT * FROM tb_Veiculos"

        Try
            Using conn As New SqlConnection(_conn)
                conn.Open()
                Using command As New SqlCommand(sql, conn)
                    Using cursor As SqlDataReader = command.ExecuteReader()
                        If cursor.HasRows Then
                            While cursor.Read()

                                Dim veiculo As New Veiculo(id:=Convert.ToInt32(cursor("Id")),
                                                           nome:=cursor("Nome").ToString(),
                                                           modelo:=cursor("Modelo").ToString(),
                                                           ano:=Convert.ToInt16(cursor("Ano")),
                                                           fabricacao:=Convert.ToInt16(cursor("Fabricacao")),
                                                           cor:=cursor("Cor").ToString(),
                                                           combustivel:=Convert.ToByte(cursor("Combustivel")),
                                                           automatico:=IIf(cursor("Automatico"), 1, 0),
                                                           valor:=Convert.ToDecimal(cursor("Valor")),
                                                           ativo:=Convert.ToBoolean(cursor("Ativo")),
                                                           proprietario:=New Proprietario(Convert.ToInt32(cursor("Proprietario"))),
                                                           imagem:=cursor("Imagem"))

                                listaCarros.Add(veiculo)

                            End While
                        End If
                    End Using
                End Using
            End Using

            Return listaCarros
        Catch ex As Exception
            Console.WriteLine($"Erro: {ex.Message}")
            Return listaCarros
        End Try

    End Function

    Public Sub GetVeiculo(id As Integer)


        Dim sql = $"SELECT * FROM tb_Veiculos WHERE Id = {id}"

        Try
            Using conn As New SqlConnection(_conn)
                conn.Open()
                Using command As New SqlCommand(sql, conn)
                    Using cursor As SqlDataReader = command.ExecuteReader()
                        If cursor.HasRows Then
                            If cursor.Read() Then
                                Me.Id = Convert.ToInt32(cursor("Id"))
                                Nome = cursor("Nome").ToString()
                                Modelo = cursor("Modelo").ToString()
                                Ano = Convert.ToInt16(cursor("Ano"))
                                Fabricacao = Convert.ToInt16(cursor("Fabricacao"))
                                Cor = cursor("Cor").ToString()
                                Combustivel = Convert.ToByte(cursor("Combustivel"))
                                Automatico = IIf(cursor("Automatico"), 1, 0)
                                Valor = Convert.ToDecimal(cursor("Valor"))
                                Ativo = Convert.ToBoolean(cursor("Ativo"))
                                Proprietario = New Proprietario(Convert.ToByte(cursor("Proprietario")))
                                Imagem = cursor("Imagem")

                            End If
                        End If
                    End Using
                End Using
            End Using


        Catch ex As Exception
            Console.WriteLine($"Erro: {ex.Message}")
        End Try

    End Sub

    Public Sub Salvar()

        Proprietario.GetProprietarioByName(Proprietario.Nome.ToUpper())

        If Me.Proprietario.Id = Nothing Then
            Proprietario.CreateProprietario()
        End If

        Dim sql As String
        If Me.Id = 0 Then

            sql = "INSERT INTO tb_veiculos("
            sql &= "Nome, "
            sql &= "Modelo , "
            sql &= "Ano, "
            sql &= "Fabricacao, "
            sql &= "Cor, "
            sql &= "Combustivel, "
            sql &= "Automatico, "
            sql &= "Valor, "
            sql &= "Ativo, "
            sql &= "Proprietario, "
            sql &= "Imagem ) "
            sql &= "VALUES("
            sql &= "@nome, "
            sql &= "@modelo, "
            sql &= "@ano, "
            sql &= "@fabricacao, "
            sql &= "@cor, "
            sql &= "@combustivel, "
            sql &= "@automatico, "
            sql &= "@valor, "
            sql &= "@ativo, "
            sql &= "@proprietario, "
            sql &= "@imagem ) "
        Else
            sql = "UPDATE tb_veiculos SET "
            sql &= "Nome = @nome, "
            sql &= "Modelo = @modelo, "
            sql &= "Ano = @ano, "
            sql &= "Fabricacao = @fabricacao, "
            sql &= "Cor = @cor, "
            sql &= "Combustivel = @combustivel, "
            sql &= "Automatico = @automatico, "
            sql &= "Valor = @valor, "
            sql &= "Ativo = @ativo,  "
            sql &= "Imagem = @imagem,  "
            sql &= "Proprietario = @proprietario "
            sql &= $"WHERE Id =@id"

        End If


        Try
            Using conn As New SqlConnection(_conn)
                conn.Open()
                Using command As New SqlCommand(sql, conn)
                    command.Parameters.AddRange(New SqlParameter() {
                        New SqlParameter("@id", Me.Id),
                        New SqlParameter("@nome", Me.Nome.ToUpper()),
                        New SqlParameter("@modelo", Me.Modelo.ToUpper()),
                        New SqlParameter("@ano", Me.Fabricacao),
                        New SqlParameter("@fabricacao", Me.Fabricacao),
                        New SqlParameter("@cor", Me.Cor.ToUpper()),
                        New SqlParameter("@combustivel", Me.Combustivel),
                        New SqlParameter("@automatico", Me.Automatico),
                        New SqlParameter("@valor", Me.Valor),
                        New SqlParameter("@ativo", Me.Ativo),
                        New SqlParameter("@imagem", Me.Imagem),
                        New SqlParameter("@proprietario", Me.Proprietario.Id)
                    })
                    command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine($"Erro: {ex.Message}")
        End Try

    End Sub
    Public Sub Excluir(id As Integer)
        Dim Sql = $"DELETE tb_Veiculos WHERE Id = {id}"

        Try
            Using conn As New SqlConnection(_conn)
                conn.Open()
                Using command As New SqlCommand(Sql, conn)
                    command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine($"Erro: {ex.Message}")
        End Try
    End Sub

End Class
