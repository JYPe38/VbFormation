Public Class Vendeur
    Inherits Commercial


    Public Shared Property POURCENT_VEDEUR As Double = 0.2
    Public Shared Property PRIME_VENDEUR As Double = 400

    Public Overrides Function CalculerSalaire() As Double
        Return ChiffreAffaire * POURCENT_VEDEUR + PRIME_VENDEUR
    End Function

    Public Sub New(nom As String, prenom As String, dateEntree As String, age As Integer, chiffreAffaire As Double)
        MyBase.New(nom, prenom, dateEntree, age, chiffreAffaire)

    End Sub

    Public Overrides Function GetNom() As String
        Return $"Le vendeur {Nom} {Prenom}"
    End Function
End Class
