Public Class LoginReponseDto

    Public Property Email As String
    Public Property Profil As Utilisateur.Profils

    Public Sub New(email As String, profil As Utilisateur.Profils)
        Me.Email = email
        Me.Profil = profil
    End Sub

End Class
