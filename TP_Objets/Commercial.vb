Public MustInherit Class Commercial
    Inherits Employe


    Public Property ChiffreAffaire As Double

    Protected Sub New(nom As String, prenom As String, dateEntree As String, age As Integer, chiffreAffaire As Double)
        MyBase.New(nom, prenom, dateEntree, age)
        Me.ChiffreAffaire = chiffreAffaire
    End Sub


End Class
