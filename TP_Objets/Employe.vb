''' <summary>
''' Classes filles: Vendeur, Représentant, Technicien, Manutentionnaire
''' </summary>
Public MustInherit Class Employe

    Public Property Nom As String
    Public Property Prenom As String
    Public Property DateEntree As String
    Public Property Age As Integer

    Public MustOverride Function CalculerSalaire() As Double
    Public Overridable Function GetNom() As String
        Return $"L'employé {Nom} {Prenom}"
    End Function

    Protected Sub New(nom As String, prenom As String, dateEntree As String, age As Integer)
        Me.Nom = nom
        Me.Prenom = prenom
        Me.DateEntree = dateEntree
        Me.Age = age
    End Sub
End Class
