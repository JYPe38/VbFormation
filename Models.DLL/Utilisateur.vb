Public Class Utilisateur

    Public Enum Profils
        ADMIN
        USER
        MANAGER
        RH
        VISITOR
    End Enum

    Public Property Email As String
    Public Property Nom As String
    Public Property Password As String
    Public Property Profil As Profils

    Public Sub New(email As String, nom As String, password As String, profil As Profils)
        Me.Email = email
        Me.Nom = nom
        Me.Password = password
        Me.Profil = profil
    End Sub

    Public Sub New()
    End Sub

    Public Overrides Function ToString() As String
        Return $"Nom: {Nom} Email: {Email} Profil: {Profil}"
    End Function
End Class
