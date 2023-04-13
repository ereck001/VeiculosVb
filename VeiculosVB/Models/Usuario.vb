Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class Usuario

    Private Shared ReadOnly _conn As String = WebConfigurationManager.ConnectionStrings("conn").ConnectionString
    Public Property Id As Integer
    Public Property Nome As String
    Public Property Email As String
    Public Property Senha As String
    Public Function Login() As Boolean

        Dim res = False
        Dim sql = $"SELECT * FROM Usuarios WHERE Email = '{Email}'"

        Try
            Using conn As New SqlConnection(_conn)
                conn.Open()
                Using command As New SqlCommand(sql, conn)
                    Using cursor As SqlDataReader = command.ExecuteReader()
                        If cursor.HasRows Then
                            If cursor.Read() Then

                                If Senha = cursor("Senha") Then
                                    Id = Convert.ToInt32(cursor("Id"))
                                    Nome = cursor("Nome").ToString()
                                    res = True
                                End If

                            End If
                        End If
                    End Using
                End Using
            End Using


        Catch ex As Exception
            Console.WriteLine($"Erro: {ex.Message}")
            Return Nothing
        End Try

        Return res

    End Function

End Class
