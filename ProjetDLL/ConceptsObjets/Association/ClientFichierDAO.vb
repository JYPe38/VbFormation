Public Class ClientFichierDAO
    Implements IClient

    Public Sub Insert(c As Client) Implements IClient.Insert
        Throw New NotImplementedException()
        'Lecture/Ecriture de fichiers
    End Sub

    Public Sub Delete(c As Client) Implements IClient.Delete
        Throw New NotImplementedException()
    End Sub

    Public Sub Update(c As Client) Implements IClient.Update
        Throw New NotImplementedException()
    End Sub

    Public Function GetAll() As List(Of Client) Implements IClient.GetAll
        Throw New NotImplementedException()
    End Function
End Class
