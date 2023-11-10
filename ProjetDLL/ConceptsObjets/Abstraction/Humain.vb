Public MustInherit Class Humain

    Public Property Nom As String
    Public Property Prenom As String

    Public Sub New(nom As String, prenom As String)
        Me.Nom = nom
        Me.Prenom = prenom
    End Sub

    Public Sub New()
    End Sub

    'Méthode abstraite: méthode non implémentée

    Public MustOverride Sub Identite()

End Class
