Public Class Adresse

    Public Property Num As Integer
    Public Property Street As String

    Public Sub New(num As Integer, street As String)
        Me.Num = num
        Me.Street = street
    End Sub

    Public Sub New()
    End Sub
End Class
