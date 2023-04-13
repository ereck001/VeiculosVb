
Imports System.ComponentModel.DataAnnotations
Public Class VeiculoViewModel
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
    Public Property Imagem As Byte()
    Public Property Proprietario As Proprietario

End Class
