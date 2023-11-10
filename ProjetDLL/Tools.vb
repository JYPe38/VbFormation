Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Json
Imports System.Xml.Serialization

Public Class Tools

    Public Shared Sub Afficher()
        Console.WriteLine("Méthode du projet dll.....")
    End Sub

    'Méthode d'écriture dans un fichier
    ''' <summary>
    ''' Si le fichier n'existe pas, il est crée
    ''' </summary>
    ''' <param name="chemin">Chemin absolut du fichier</param>
    ''' <param name="contenu">Contenu à insérer dans le fichier</param>
    Public Shared Sub EcritureFichier(chemin As String, contenu As String)
        Dim sw As New StreamWriter(chemin)
        sw.Write(contenu)
        sw.Close()
    End Sub

    'Méthode de lecture d'un fichier
    ''' <summary>
    ''' Si le chemin n'est pas valide, la méthode génère une exception
    ''' </summary>
    ''' <param name="chemin">Chemin absolut du fichier</param>
    ''' <returns>Contenu du fichier</returns>
    Public Shared Function LectureFichier(chemin As String) As String
        Dim contenu As String = String.Empty
        Dim sr As New StreamReader(chemin)
        contenu = sr.ReadToEnd()
        sr.Close()
        Return contenu
    End Function

    'Méthode de sérialisation binaire
    Public Shared Sub ExportBIN(chemin As String, lst As List(Of CompteBancaire))
        Dim bin As New BinaryFormatter()
        Dim flux As Stream = New FileStream(chemin, FileMode.Create)
        bin.Serialize(flux, lst)
        flux.Close()
    End Sub

    'Méthode de désérialisation binaire
    Public Shared Function ImportBIN(chemin As String) As List(Of CompteBancaire)
        Dim lst As New List(Of CompteBancaire)
        Dim bin As New BinaryFormatter()
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = CType(bin.Deserialize(flux), List(Of CompteBancaire))
        flux.Close()
        Return lst
    End Function

    'Méthode de sérialisation Xml: XmlSerializer

    Public Shared Sub ExportXML(chemin As String, lst As List(Of CompteBancaire))
        Dim xml As New XmlSerializer(lst.GetType())
        Dim flux As Stream = New FileStream(chemin, FileMode.Create)
        xml.Serialize(flux, lst)
        flux.Close()
    End Sub

    'Méthode de désérialisation Xml: XmlSerializer

    Public Shared Function ImportXML(chemin As String) As List(Of CompteBancaire)
        Dim lst As New List(Of CompteBancaire)
        Dim xml As New XmlSerializer(lst.GetType())
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = CType(xml.Deserialize(flux), List(Of CompteBancaire))
        flux.Close()
        Return lst
    End Function
    'Méthode de sérialisation Json: DataContractJsonSerializer

    Public Shared Sub ExportJSON(chemin As String, lst As List(Of CompteBancaire))
        Dim json As New DataContractJsonSerializer(lst.GetType())
        Dim flux As Stream = New FileStream(chemin, FileMode.Create)
        json.WriteObject(flux, lst)
        flux.Close()
    End Sub

    'Méthode de désérialisation Json: DataContractJsonSerializer
    Public Shared Function ImportJSON(chemin As String) As List(Of CompteBancaire)
        Dim lst As New List(Of CompteBancaire)
        Dim json As New DataContractJsonSerializer(lst.GetType())
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = CType(json.ReadObject(flux), List(Of CompteBancaire))
        flux.Close()
        Return lst
    End Function

    'Méthode de sérialisation csv
    Public Shared Sub ExportCSV(chemin As String, lst As List(Of CompteBancaire), separateur As String)
        Dim sw As New StreamWriter(chemin)
        For Each cp In lst
            sw.WriteLine(cp.Numero & separateur & cp.Solde)
        Next
        sw.Close()
    End Sub

    'Méthode de désérialisation csv
    Public Shared Function ImportCSV(chemin As String, separateur As String) As List(Of CompteBancaire)
        Dim lst As New List(Of CompteBancaire)
        Dim sr As New StreamReader(chemin)

        While Not sr.EndOfStream

            'lire la ligne en cours, la convertir en compte et insérer le compte dans la liste
            Dim ligne As String = sr.ReadLine()
            Dim tab() As String = ligne.Split(CChar(separateur))
            Dim cpte As New CompteBancaire(tab(0), Convert.ToDouble(tab(1)))
            lst.Add(cpte)

        End While

        sr.Close()

        Return lst
    End Function

End Class
