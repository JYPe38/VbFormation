
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class ConnexionSQL

    Public Shared Function GetConnexion() As SqlConnection

        Dim cnx As SqlConnection = Nothing
        'Chaine de connexion:
        'Pour manipuler le fichier app.config, utilisez la classe ConfigurationManager
        'Dim chaine As String = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=formation;Integrated Security=True;"

        Dim chaine As String = ConfigurationManager.ConnectionStrings("sql").ConnectionString
        cnx = New SqlConnection(chaine)
        cnx.Open()
        Return cnx

    End Function

End Class
' Dans un projet DLL: 
' Clic droit sur projet - ajouter nouvel élément - choisir fichier de configuration de l'application (app.config)