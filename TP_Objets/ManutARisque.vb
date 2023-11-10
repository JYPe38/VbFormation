Public Class ManutARisque
    Inherits Manutentionnaire

    Public Shared Property PRIME As Double = 200
    Public Sub New(nom As String, prenom As String, dateEntree As String, age As Integer, heures As Double)
        MyBase.New(nom, prenom, dateEntree, age, heures)
    End Sub

    Public Overrides Function CalculerSalaire() As Double
        Return MyBase.CalculerSalaire() + PRIME
    End Function
End Class
