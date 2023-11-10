Public Class CompteDao
    Implements IDao(Of CompteBancaire)

    Public Sub Insert(o As CompteBancaire) Implements IDao(Of CompteBancaire).Insert
        Throw New NotImplementedException()
    End Sub

    Public Sub Delete(o As CompteBancaire) Implements IDao(Of CompteBancaire).Delete
        Throw New NotImplementedException()
    End Sub

    Public Sub Update(o As CompteBancaire) Implements IDao(Of CompteBancaire).Update
        Throw New NotImplementedException()
    End Sub

    Public Function GetAll() As List(Of CompteBancaire) Implements IDao(Of CompteBancaire).GetAll
        Throw New NotImplementedException()
    End Function


End Class
