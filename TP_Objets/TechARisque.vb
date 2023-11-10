Public Class TechARisque
    Inherits Technicien

    Public Shared Property PRIME As Double = 200

    Public Sub New(nom As String, prenom As String, dateEntree As String, age As Integer, unites As Double)
        MyBase.New(nom, prenom, dateEntree, age, unites)
    End Sub

    Public Overrides Function CalculerSalaire() As Double
        Return MyBase.CalculerSalaire() + PRIME
    End Function
End Class
