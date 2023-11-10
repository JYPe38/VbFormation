Imports Models.DLL
Imports Repositories.DLL
Imports Services.DLL

Public Class Authentification

    Private utilisateurService As New UtilisateurService(New UtilisateurRepository())
    Private Sub btnConnexion_Click(sender As Object, e As EventArgs) Handles btnConnexion.Click
        Dim loginDto As New LoginDto(txtEmail.Text, txtPassword.Text)
        Dim reponseDto As LoginReponseDto = utilisateurService.CheckLogin(loginDto)

        If reponseDto IsNot Nothing Then
            'Afficher form1 et fermer fenêtre login
            Dim f1 As New Form1()
            Me.Visible = False
            'Seul l'Admin peut faire des modifs

            If Not reponseDto.Profil = Utilisateur.Profils.ADMIN Then
                'Désactiver des fonctionnalités dans form1
                f1.bd.btnAjouter.Enabled = False
                f1.bd.btnSupprimer.Enabled = False
                f1.bd.btnEditer.Enabled = False
            End If

            f1.ShowDialog()

        Else
            lblErreur.Text = "Echec connexion....."
        End If
    End Sub
End Class