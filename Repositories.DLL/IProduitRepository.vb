Imports Models.DLL

Public Interface IProduitRepository

    Function GetAll() As List(Of Produit)
    Sub Insert(p As Produit)
    Sub Update(p As Produit)
    Sub Delete(id As Integer)
    Function GetById(id As Integer) As Produit
    Function FindByKey(key As String) As List(Of Produit)

End Interface
