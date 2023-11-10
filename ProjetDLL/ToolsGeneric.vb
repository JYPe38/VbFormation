Imports System.IO
Imports System.Reflection
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Json
Imports System.Xml.Serialization

Public Class ToolsGeneric


    'Méthode de sérialisation binaire
    Public Shared Sub ExportBIN(Of T As {New, Class})(chemin As String, lst As List(Of T))
        Dim bin As New BinaryFormatter()
        Dim flux As Stream = New FileStream(chemin, FileMode.Create)
        bin.Serialize(flux, lst)
        flux.Close()
    End Sub

    'Méthode de désérialisation binaire
    Public Shared Function ImportBIN(Of T As {New, Class})(chemin As String) As List(Of T)
        Dim lst As New List(Of T)
        Dim bin As New BinaryFormatter()
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = CType(bin.Deserialize(flux), List(Of T))
        flux.Close()
        Return lst
    End Function

    'Méthode de sérialisation Xml: XmlSerializer

    Public Shared Sub ExportXML(Of T As {New, Class})(chemin As String, lst As List(Of T))
        Dim xml As New XmlSerializer(lst.GetType())
        Dim flux As Stream = New FileStream(chemin, FileMode.Create)
        xml.Serialize(flux, lst)
        flux.Close()
    End Sub

    'Méthode de désérialisation Xml: XmlSerializer

    Public Shared Function ImportXML(Of T As {New, Class})(chemin As String) As List(Of T)
        Dim lst As New List(Of T)
        Dim xml As New XmlSerializer(lst.GetType())
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = CType(xml.Deserialize(flux), List(Of T))
        flux.Close()
        Return lst
    End Function
    'Méthode de sérialisation Json: DataContractJsonSerializer

    Public Shared Sub ExportJSON(Of T As {New, Class})(chemin As String, lst As List(Of T))
        Dim json As New DataContractJsonSerializer(lst.GetType())
        Dim flux As Stream = New FileStream(chemin, FileMode.Create)
        json.WriteObject(flux, lst)
        flux.Close()
    End Sub

    'Méthode de désérialisation Json: DataContractJsonSerializer
    Public Shared Function ImportJSON(Of T As {New, Class})(chemin As String) As List(Of T)
        Dim lst As New List(Of T)
        Dim json As New DataContractJsonSerializer(lst.GetType())
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = CType(json.ReadObject(flux), List(Of T))
        flux.Close()
        Return lst
    End Function

    'Méthode de sérialisation csv
    Public Shared Sub ExportCSV(Of T As {New, Class})(chemin As String, lst As List(Of T), separateur As String)
        Dim sw As New StreamWriter(chemin)
        For Each obj In lst
            'Récupérer toutes les propriétés
            Dim props As PropertyInfo() = GetType(T).GetProperties()
            Dim chaineToInsert As String = ""

            For index = 0 To props.Length - 1
                If Not props(index).GetSetMethod.IsStatic Then
                    If Not chaineToInsert.Equals("") Then
                        chaineToInsert = chaineToInsert & separateur
                    End If
                    chaineToInsert = chaineToInsert & props(index).GetValue(obj).ToString()

                End If

                'Vérifier qu'on a pas atteint la dernière propriété du tableau
                'If index < props.Length - 1 Then
                '    sw.Write(separateur)
                'End If
            Next

            'Passer à la ligne suivante
            sw.WriteLine(chaineToInsert)
        Next
        sw.Close()
    End Sub

    'Méthode de désérialisation csv
    Public Shared Function ImportCSV(Of T As {New, Class})(chemin As String, separateur As String) As List(Of T)
        Dim lst As New List(Of T)
        Dim sr As New StreamReader(chemin)

        While Not sr.EndOfStream

            Dim ligne As String = sr.ReadLine()
            Dim tab() As String = ligne.Split(CChar(separateur))

            'Instancier le type T
            Dim obj As T = CType(Activator.CreateInstance(GetType(T)), T)
            Dim props As PropertyInfo() = GetType(T).GetProperties()

            Dim propsTab As New List(Of PropertyInfo)

            'Supprimer ttes les props static
            For Each pr In props
                If Not pr.GetSetMethod.IsStatic Then
                    propsTab.Add(pr)
                End If
            Next

            Console.WriteLine(">>>>>> " & propsTab.Count)
            If tab.Length = propsTab.Count Then
                For index = 0 To tab.Length - 1
                    propsTab(index).SetValue(obj, Convert.ChangeType(tab(index), propsTab(index).PropertyType))
                Next
            End If

            lst.Add(obj)

        End While

        sr.Close()

        Return lst
    End Function

End Class
