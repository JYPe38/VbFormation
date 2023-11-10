Public Class Homme
    Inherits Humain

    Public Sub New(nom As String, prenom As String)
        MyBase.New(nom, prenom)
    End Sub

    Public Sub New()

    End Sub

    Public Overrides Sub Identite()
        Throw New NotImplementedException()
    End Sub
End Class
