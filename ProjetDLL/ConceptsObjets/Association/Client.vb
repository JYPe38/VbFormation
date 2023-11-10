Public Class Client

    Public Property Nom As String
    Public Property Adresse As Adresse
    'Un objet de tyoe Adresse fait partie des attributs d'un objet de type client
    'Association - composition d'objets
    Public Sub New(nom As String, adresse As Adresse)
        Me.Nom = nom
        Me.Adresse = adresse
    End Sub

    Public Sub New()
    End Sub
End Class
