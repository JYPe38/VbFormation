Public Class Chat
    Inherits Animal

    Public Property Couleur As String
    Public Sub New(nom As String, age As Integer, couleur As String)
        'Appel du constructeur de la classe mère
        MyBase.New(nom, age)
        Me.Couleur = couleur
    End Sub

    Public Sub New()

    End Sub

    Public Sub Dormir()

    End Sub

    Public Overrides Sub EmettreSon()
        Console.WriteLine("Miauller.....")
    End Sub
End Class
