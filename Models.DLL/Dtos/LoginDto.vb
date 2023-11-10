Public Class LoginDto

    Public Property Email As String
    Public Property Password As String

    Public Sub New(email As String, password As String)
        Me.Email = email
        Me.Password = password
    End Sub
End Class
