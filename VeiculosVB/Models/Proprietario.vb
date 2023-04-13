Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.ComponentModel.DataAnnotations
Public Class Proprietario

    Private Shared ReadOnly _conn As String = WebConfigurationManager.ConnectionStrings("conn").ConnectionString
    Public Sub New()

    End Sub
    Public Sub New(id As Integer)
        GetProprietarioById(id)
    End Sub

    Public Sub New(name As String)
        GetProprietarioByName(name)
    End Sub
    Public Property Id As Integer
    <Display(Name:="Proprietário:")>
    <Required(ErrorMessage:="O nome do proprietário é obrigatório")>
    Public Property Nome As String


    Public Sub GetProprietarioById(id As Integer)

        Dim sql = $"SELECT * FROM Proprietarios WHERE Id = {id}"

        Try
            Using conn As New SqlConnection(_conn)
                conn.Open()
                Using command As New SqlCommand(sql, conn)
                    Using cursor As SqlDataReader = command.ExecuteReader()
                        If cursor.HasRows Then
                            If cursor.Read() Then
                                Me.Id = Convert.ToInt32(cursor("Id"))
                                Nome = cursor("Nome").ToString()
                            End If
                        End If
                    End Using
                End Using
            End Using


        Catch ex As Exception
            Console.WriteLine($"Erro: {ex.Message}")
        End Try

    End Sub

    Public Sub GetProprietarioByName(name As String)

        Dim sql = $"SELECT * FROM Proprietarios  WHERE Nome = '{name}'"

        Try
            Using conn As New SqlConnection(_conn)
                conn.Open()
                Using command As New SqlCommand(sql, conn)
                    Using cursor As SqlDataReader = command.ExecuteReader()
                        If cursor.HasRows Then
                            If cursor.Read() Then
                                Me.Id = Convert.ToInt32(cursor("Id"))
                                Nome = cursor("Nome").ToString()
                            End If
                        End If
                    End Using
                End Using
            End Using


        Catch ex As Exception
            Console.WriteLine($"Erro: {ex.Message}")
        End Try

    End Sub

    Public Sub CreateProprietario()
        Dim sql = "INSERT INTO Proprietarios(Nome) VALUES(@nome); SELECT SCOPE_IDENTITY();"
        Try
            Using conn As New SqlConnection(_conn)
                conn.Open()
                Using command As New SqlCommand(Sql, conn)
                    command.Parameters.AddWithValue("@nome", Me.Nome.ToUpper())

                    Me.Id = Convert.ToInt32(command.ExecuteScalar())
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine($"Erro: {ex.Message}")
        End Try
    End Sub
End Class
