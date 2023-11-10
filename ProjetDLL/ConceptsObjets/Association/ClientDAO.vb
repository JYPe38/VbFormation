Public Class ClientDAO
    Implements IClient

    Public Sub Insert(c As Client) Implements IClient.Insert
        Throw New NotImplementedException()
        'sql
    End Sub

    Public Sub Delete(c As Client) Implements IClient.Delete
        Throw New NotImplementedException()
        'sql
    End Sub

    Public Sub Update(c As Client) Implements IClient.Update
        Throw New NotImplementedException()
    End Sub

    Public Function GetAll() As List(Of Client) Implements IClient.GetAll
        Throw New NotImplementedException()
    End Function
End Class
