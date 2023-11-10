Imports System.Data.SqlClient
Imports Models.DLL

Public Class UtilisateurRepository
    Implements IUtilisateurRepository

    Public Sub Insert(u As Utilisateur) Implements IUtilisateurRepository.Insert
        Dim cnx = ConnexionSQL.GetConnexion()
        Dim sql = "INSERT INTO utilisateur(email,nom,password,profil) values (@email,@nom,@password,@profil)"
        Dim cmd As New SqlCommand(sql, cnx)
        cmd.Parameters.AddWithValue("@email", u.Email)
        cmd.Parameters.AddWithValue("@nom", u.Nom)
        cmd.Parameters.AddWithValue("@password", u.Password)
        cmd.Parameters.AddWithValue("@profil", u.Profil)

        cmd.ExecuteNonQuery()
        cnx.Close()
    End Sub

    Public Sub Update(u As Utilisateur) Implements IUtilisateurRepository.Update
        Dim cnx = ConnexionSQL.GetConnexion()
        Dim sql = "UPDATE utilisateur SET nom=@nom,password=@password,profil=@profil WHERE email=@email"
        Dim cmd As New SqlCommand(sql, cnx)

        cmd.Parameters.AddWithValue("@nom", u.Nom)
        cmd.Parameters.AddWithValue("@password", u.Password)
        cmd.Parameters.AddWithValue("@profil", u.Profil)
        cmd.Parameters.AddWithValue("@email", u.Email)

        cmd.ExecuteNonQuery()
        cnx.Close()
    End Sub

    Public Sub Delete(email As String) Implements IUtilisateurRepository.Delete
        Dim cnx = ConnexionSQL.GetConnexion()
        Dim sql = "Delete From utilisateur WHERE email=@email"
        Dim cmd As New SqlCommand(sql, cnx)

        cmd.Parameters.AddWithValue("@email", email)

        cmd.ExecuteNonQuery()
        cnx.Close()
    End Sub

    Public Function GetAll() As List(Of Utilisateur) Implements IUtilisateurRepository.GetAll
        Dim lst As New List(Of Utilisateur)
        Dim cnx = ConnexionSQL.GetConnexion()
        Dim sql = "Select * From utilisateur"
        Dim cmd As New SqlCommand(sql, cnx)

        Dim reader As SqlDataReader = cmd.ExecuteReader()

        While reader.Read()

            Dim u As New Utilisateur(reader.GetString(0), reader.GetString(1), reader.GetString(2), CType(reader.GetByte(3), Utilisateur.Profils))
            lst.Add(u)
        End While

        reader.Close()
        cnx.Close()

        Return lst
    End Function

    Public Function FindByEmail(email As String) As Utilisateur Implements IUtilisateurRepository.FindByEmail
        Dim u As Utilisateur = Nothing
        Dim cnx = ConnexionSQL.GetConnexion()
        Dim sql = "Select * From utilisateur Where email=@email"
        Dim cmd As New SqlCommand(sql, cnx)
        cmd.Parameters.AddWithValue("@email", email)

        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            u = New Utilisateur(reader.GetString(0), reader.GetString(1), reader.GetString(2), CType(reader.GetByte(3), Utilisateur.Profils))
        End If

        reader.Close()
        cnx.Close()

        Return u
    End Function
End Class
