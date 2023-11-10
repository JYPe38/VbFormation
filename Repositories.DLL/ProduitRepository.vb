Imports System.Data.SqlClient
Imports Models.DLL

Public Class ProduitRepository
    Implements IProduitRepository

    Public Sub Insert(p As Produit) Implements IProduitRepository.Insert
        'Se connecter à la BD
        Dim cnx As SqlConnection = ConnexionSQL.GetConnexion()

        'Commande SQL: commande paramètrée (précompilée, chargée en mémoire en attente de params) - protection contre les injections SQl
        Dim sql = "INSERT INTO produit(description,prix,quantite) values (@description,@prix,@quantite)"

        Dim cmd As New SqlCommand(sql, cnx)
        cmd.Parameters.AddWithValue("@description", p.Description)
        cmd.Parameters.AddWithValue("@prix", p.Prix)
        cmd.Parameters.AddWithValue("@quantite", p.Quantite)
        cmd.ExecuteNonQuery()
        cnx.Close()
    End Sub

    Public Sub Update(p As Produit) Implements IProduitRepository.Update
        'Se connecter à la BD
        Dim cnx As SqlConnection = ConnexionSQL.GetConnexion()

        'Commande SQL: commande paramètrée (précompilée, chargée en mémoire en attente de params) - protection contre les injections SQl
        Dim sql = "UPDATE produit SET description=@description,prix=@prix,quantite=@quantite WHERE id=@id"

        Dim cmd As New SqlCommand(sql, cnx)
        cmd.Parameters.AddWithValue("@description", p.Description)
        cmd.Parameters.AddWithValue("@prix", p.Prix)
        cmd.Parameters.AddWithValue("@quantite", p.Quantite)
        cmd.Parameters.AddWithValue("@id", p.Id)
        cmd.ExecuteNonQuery()
        cnx.Close()
    End Sub

    Public Sub Delete(id As Integer) Implements IProduitRepository.Delete
        'Se connecter à la BD
        Dim cnx As SqlConnection = ConnexionSQL.GetConnexion()

        'Commande SQL: commande paramètrée (précompilée, chargée en mémoire en attente de params) - protection contre les injections SQl
        Dim sql = "DELETE FROM produit WHERE id=@id"

        Dim cmd As New SqlCommand(sql, cnx)
        cmd.Parameters.AddWithValue("@id", id)
        cmd.ExecuteNonQuery()
        cnx.Close()
    End Sub

    Public Function GetAll() As List(Of Produit) Implements IProduitRepository.GetAll
        Dim lst As New List(Of Produit)
        Dim cnx As SqlConnection = ConnexionSQL.GetConnexion()
        Dim sql = "SELECT * FROM produit"

        Dim cmd As New SqlCommand(sql, cnx)
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            Dim p As New Produit(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3))
            lst.Add(p)
        End While

        reader.Close()
        cnx.Close()
        Return lst

    End Function

    Public Function GetById(id As Integer) As Produit Implements IProduitRepository.GetById
        Dim p As Produit = Nothing
        Dim cnx As SqlConnection = ConnexionSQL.GetConnexion()
        Dim sql = "SELECT * FROM produit WHERE id=@id"

        Dim cmd As New SqlCommand(sql, cnx)
        cmd.Parameters.AddWithValue("@id", id)

        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            p = New Produit(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3))
        End If

        reader.Close()
        cnx.Close()
        Return p

    End Function

    Public Function FindByKey(key As String) As List(Of Produit) Implements IProduitRepository.FindByKey
        Dim lst As New List(Of Produit)
        Dim cnx As SqlConnection = ConnexionSQL.GetConnexion()
        Dim sql = "SELECT * FROM produit WHERE description Like @key"

        Dim cmd As New SqlCommand(sql, cnx)

        cmd.Parameters.AddWithValue("@key", "%" & key & "%")

        Dim reader As SqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            Dim p As New Produit(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3))
            lst.Add(p)
        End While

        reader.Close()
        cnx.Close()
        Return lst
    End Function

End Class
