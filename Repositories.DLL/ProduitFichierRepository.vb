Imports Models.DLL

Public Class ProduitFichierRepository
    Implements IProduitRepository

    Public Sub Insert(p As Produit) Implements IProduitRepository.Insert
        Throw New NotImplementedException()
    End Sub

    Public Sub Update(p As Produit) Implements IProduitRepository.Update
        Throw New NotImplementedException()
    End Sub

    Public Sub Delete(id As Integer) Implements IProduitRepository.Delete
        Throw New NotImplementedException()
    End Sub

    Public Function GetAll() As List(Of Produit) Implements IProduitRepository.GetAll
        Throw New NotImplementedException()
    End Function

    Public Function GetById(id As Integer) As Produit Implements IProduitRepository.GetById
        Throw New NotImplementedException()
    End Function

    Public Function FindByKey(key As String) As List(Of Produit) Implements IProduitRepository.FindByKey
        Throw New NotImplementedException()
    End Function
End Class
