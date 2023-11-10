Imports System.Web.Mvc
Imports Models.DLL
Imports Repositories.DLL
Imports Services.DLL

Namespace Controllers
    Public Class ProduitController
        Inherits Controller

        Private prodService As New ProduitService(New ProduitRepository())

        ' GET: Produit
        Function Index() As ActionResult
            Dim prods As List(Of Produit) = prodService.GetAll()

            Return View(prods)
        End Function
        <HttpGet>
        Function Create() As ActionResult

            Return View()
        End Function
        <HttpPost>
        Function Create(p As Produit) As ActionResult
            prodService.Insert(p)
            Return RedirectToAction("Index")
        End Function
        <HttpGet>
        Function Edit(Id As Integer) As ActionResult
            Dim p As Produit = prodService.GetById(Id)
            Return View(p)
        End Function
        <HttpPost>
        Function Edit(p As Produit) As ActionResult
            prodService.Update(p)
            Return RedirectToAction("Index")
        End Function
        <HttpGet>
        Function Details(Id As Integer) As ActionResult
            Dim p As Produit = prodService.GetById(Id)
            Return View(p)
        End Function
        <HttpGet>
        Function Delete(Id As Integer) As ActionResult
            Dim p As Produit = prodService.GetById(Id)
            Return View(p)
        End Function
        <HttpPost, ActionName("Delete")>
        Function DeleteConfirm(Id As Integer) As ActionResult
            prodService.Delete(Id)
            Return View("Index")
        End Function

    End Class
End Namespace