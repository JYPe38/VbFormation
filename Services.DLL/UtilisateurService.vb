Imports Models.DLL
Imports Repositories.DLL

Public Class UtilisateurService
    Implements IUtilisateurService

    'Gestion de la dépendance
    Private Property utilisateurRepository As IUtilisateurRepository

    Public Sub New(utilisateurRepository As IUtilisateurRepository)
        Me.utilisateurRepository = utilisateurRepository
    End Sub

    Public Sub Insert(u As Utilisateur) Implements IUtilisateurService.Insert
        'Hasher le password
        u.Password = HashTool.CrypterPassword(u.Password)
        utilisateurRepository.Insert(u)
    End Sub

    Public Function CheckLogin(loginDto As LoginDto) As LoginReponseDto
        Dim reponseDto As LoginReponseDto = Nothing
        Dim u As Utilisateur = utilisateurRepository.FindByEmail(loginDto.Email)
        If u IsNot Nothing AndAlso HashTool.CrypterPassword(loginDto.Password).Equals(u.Password) Then
            reponseDto = New LoginReponseDto(loginDto.Email, u.Profil)
        End If
        Return reponseDto
    End Function

    Public Sub Update(u As Utilisateur) Implements IUtilisateurService.Update
        'Vérifier si password modifié dans IHM, il sera hashé
        Dim userDB = utilisateurRepository.FindByEmail(u.Email)
        If Not userDB.Password.Equals(u.Password) Then
            u.Password = HashTool.CrypterPassword(u.Password)
        End If
        utilisateurRepository.Update(u)
    End Sub

    Public Sub Delete(email As String) Implements IUtilisateurService.Delete
        utilisateurRepository.Delete(email)
    End Sub

    Public Function GetAll() As List(Of Utilisateur) Implements IUtilisateurService.GetAll
        Return utilisateurRepository.GetAll()
    End Function

    Public Function FindByEmail(email As String) As Utilisateur Implements IUtilisateurService.FindByEmail
        Return utilisateurRepository.FindByEmail(email)
    End Function
End Class
