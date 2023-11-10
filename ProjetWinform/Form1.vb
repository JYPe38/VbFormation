Imports Models.DLL
Imports Repositories.DLL
Imports Services.DLL

Public Class Form1

    Private produitService As New ProduitService(New ProduitRepository())
    Public Property bd As New BD()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnValider_Click(sender As Object, e As EventArgs) Handles btnValider.Click

        Dim solde As Double = CDbl(txtSolde.Text)
        Dim montant As Double = CDbl(txtMontant.Text)

        If rbDepot.Checked Then
            solde += montant
            txtSolde.Text = solde.ToString()
        Else
            If solde >= montant Then
                solde -= montant
                txtSolde.Text = solde.ToString()
            Else
                MessageBox.Show("Solde insuffisant.......")
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim repo As New ProduitRepository()
        'repo.Insert(New Produit("PC Dell", 1200, 10))

        Dim service As New UtilisateurService(New UtilisateurRepository())
        service.Insert(New Utilisateur("admin@dawan.fr", "admin", "admin", Utilisateur.Profils.ADMIN))
        service.Insert(New Utilisateur("user@dawan.fr", "user", "user", Utilisateur.Profils.USER))
        MessageBox.Show("Utilisateurs insérés........")
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub BaseDeDonnéesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BaseDeDonnéesToolStripMenuItem.Click
        ' bd = New BD()
        bd.ShowDialog() ' affiche une fen^tre bloquante
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class
