Public Class Manutentionnaire
    Inherits Employe


    Public Property Heures As Double
    Public Shared Property TAUX_HORAIRE As Double = 65

    Public Overrides Function CalculerSalaire() As Double
        Return Heures * TAUX_HORAIRE
    End Function

    Public Sub New(nom As String, prenom As String, dateEntree As String, age As Integer, heures As Double)
        MyBase.New(nom, prenom, dateEntree, age)
        Me.Heures = heures
    End Sub
    Public Overrides Function GetNom() As String
        Return $"Le manutentionnaire {Nom} {Prenom}"
    End Function
End Class
