Public Class Technicien
    Inherits Employe


    Public Property Unites As Double
    Public Shared Property FACTEUR_UNITE As Double = 5

    Public Overrides Function CalculerSalaire() As Double
        Return Unites * FACTEUR_UNITE
    End Function

    Public Sub New(nom As String, prenom As String, dateEntree As String, age As Integer, unites As Double)
        MyBase.New(nom, prenom, dateEntree, age)
        Me.Unites = unites
    End Sub

    Public Overrides Function GetNom() As String
        Return $"Le technicien {Nom} {Prenom}"
    End Function
End Class
