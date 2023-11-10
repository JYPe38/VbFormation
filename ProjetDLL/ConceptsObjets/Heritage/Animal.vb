Public Class Animal
    Inherits Object

    Public Property Nom As String
    Public Property Age As Integer

    Public Sub New(nom As String, age As Integer)
        Me.Nom = nom
        Me.Age = age
    End Sub

    Public Sub New()
    End Sub

    Public Overridable Sub EmettreSon()
        Console.WriteLine("Son de l'animal")
    End Sub

    Private Sub Test()

    End Sub
End Class
