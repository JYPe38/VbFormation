Imports Models.DLL

Public Interface IUtilisateurService

    Function GetAll() As List(Of Utilisateur)
    Sub Insert(u As Utilisateur)
    Sub Update(u As Utilisateur)
    Sub Delete(email As String)
    Function FindByEmail(email As String) As Utilisateur


End Interface
