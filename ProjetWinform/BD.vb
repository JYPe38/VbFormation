Imports Models.DLL
Imports Repositories.DLL
Imports Services.DLL

Public Class BD
    Private produitService As New ProduitService(New ProduitRepository())
    Private Sub BD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim prods As List(Of Produit) = produitService.GetAll()
        'gridProduits.AutoGenerateColumns = False 'Désactiver la génération automatique des colonnes
        'gridProduits.DataSource = False ' réinitiliation la grille
        'gridProduits.DataSource = prods ' affecter la produits à la grille
        Remplir(produitService.GetAll())
    End Sub

    Private Sub Remplir(lst As List(Of Produit))
        gridProduits.AutoGenerateColumns = False 'Désactiver la génération automatique des colonnes
        gridProduits.DataSource = False ' réinitiliation la grille
        gridProduits.DataSource = lst ' affecter la produits à la grille
        gridProduits.ClearSelection()
    End Sub

    Private Sub Reset()
        txtId.Clear()
        txtDescription.Clear()
        txtPrix.Clear()
        txtQuantite.Clear()
        btnAjouter.Text = "Ajouter"
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click
        Dim p As New Produit(txtDescription.Text, CDbl(txtPrix.Text), CInt(txtQuantite.Text))

        If btnAjouter.Text.Equals("Ajouter") Then
            produitService.Insert(p)
        Else
            p.Id = CInt(txtId.Text)
            produitService.Update(p)
        End If

        Remplir(produitService.GetAll())
        Reset()
    End Sub

    Private Sub btnRechercher_Click(sender As Object, e As EventArgs) Handles btnRechercher.Click
        Remplir(produitService.FindByKey(txtMotCle.Text))
    End Sub

    Private Sub btnSupprimer_Click(sender As Object, e As EventArgs) Handles btnSupprimer.Click
        Dim id As Integer = CInt(gridProduits.CurrentRow.Cells("id").Value)
        If MessageBox.Show("Etes-vous sûr de vouloir supprimer le produit?", "Suppression d'un produit",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            produitService.Delete(id)
            Remplir(produitService.GetAll())
        End If

    End Sub

    Private Sub btnEditer_Click(sender As Object, e As EventArgs) Handles btnEditer.Click
        Dim id As Integer = CInt(gridProduits.CurrentRow.Cells("id").Value)
        Dim p As Produit = produitService.GetById(id)
        txtId.Text = p.Id.ToString()
        txtDescription.Text = p.Description
        txtPrix.Text = p.Prix.ToString()
        txtQuantite.Text = p.Quantite.ToString()
        btnAjouter.Text = "Modifier"
    End Sub
End Class