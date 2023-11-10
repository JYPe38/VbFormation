Public Class Representant
    Inherits Commercial

    Public Shared Property POURCENT_REPRESENTANT As Double = 0.2
    Public Shared Property PRIME_REPRESENTANT As Double = 800

    Public Overrides Function CalculerSalaire() As Double
        Return ChiffreAffaire * POURCENT_REPRESENTANT + PRIME_REPRESENTANT
    End Function


    Public Sub New(nom As String, prenom As String, dateEntree As String, age As Integer, chiffreAffaire As Double)
        MyBase.New(nom, prenom, dateEntree, age, chiffreAffaire)

    End Sub
    Public Overrides Function GetNom() As String
        Return $"Le représentant {Nom} {Prenom}"
    End Function


End Class
