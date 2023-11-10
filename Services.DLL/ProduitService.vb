Imports Models.DLL
Imports Repositories.DLL

Public Class ProduitService
    Implements IProduitService

    Private produitRepository As IProduitRepository

    'Injection via le constructeur
    Public Sub New(produitRepository As IProduitRepository)
        Me.produitRepository = produitRepository
    End Sub

    Public Sub Insert(p As Produit) Implements IProduitService.Insert
        'contrôle eventuel.....

        produitRepository.Insert(p)
    End Sub

    Public Sub Update(p As Produit) Implements IProduitService.Update
        produitRepository.Update(p)
    End Sub

    Public Sub Delete(id As Integer) Implements IProduitService.Delete
        produitRepository.Delete(id)
    End Sub

    Public Function GetAll() As List(Of Produit) Implements IProduitService.GetAll
        Return produitRepository.GetAll()
    End Function

    Public Function GetById(id As Integer) As Produit Implements IProduitService.GetById
        Return produitRepository.GetById(id)
    End Function

    Public Function FindByKey(key As String) As List(Of Produit) Implements IProduitService.FindByKey
        Return produitRepository.FindByKey(key)
    End Function

    Public Function ProduitEntrePrixMinAndPrixMax(prixMin As Double, prixMax As Double) As List(Of Produit)
        Dim prods As New List(Of Produit)
        Dim all = produitRepository.GetAll()
        For Each p In all
            If p.Prix >= prixMin And p.Prix <= prixMax Then
                prods.Add(p)
            End If
        Next
        Return prods
    End Function
End Class
