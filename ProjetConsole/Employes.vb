Public Class Employes

    Public Property Nom As String
    Public Property Prenom As String

    Public Sub New(nom As String, prenom As String)
        Me.Nom = nom
        Me.Prenom = prenom
    End Sub

    Public Sub New()
    End Sub

    Public Sub Afficher()
        Console.WriteLine($"Nom: {Nom} - Prénom: {Prenom}")
    End Sub
End Class
