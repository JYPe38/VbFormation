Imports System.Security.Cryptography

Public Class HashTool

    Public Shared Function CrypterPassword(Texte As String) As String

        Dim md5 As New MD5CryptoServiceProvider
        Dim TexteEnBit() As Byte
        Dim TexteHache() As Byte

        ' Récupération de la valeur en bit du texte à hacher
        TexteEnBit = System.Text.Encoding.UTF8.GetBytes(Texte)

        ' Hachage
        TexteHache = md5.ComputeHash(TexteEnBit)

        'Libération des ressources
        md5.Clear()

        ' Renvoi
        CrypterPassword = Convert.ToBase64String(TexteHache)

    End Function

End Class
