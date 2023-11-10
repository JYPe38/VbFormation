Imports System.Web.Mvc
Imports Models.DLL
Imports Repositories.DLL
Imports Services.DLL

Namespace Controllers
    Public Class AccountController
        Inherits Controller

        Private userservice As New UtilisateurService(New UtilisateurRepository)

        ' GET: Account
        Function Login() As ActionResult
            Return View()
        End Function
        <HttpPost>
        Function Login(LoginSto As LoginDto) As ActionResult
            Dim reponseDto As LoginReponseDto = userservice.CheckLogin(LoginSto)
            If reponseDto IsNot Nothing Then
                Session("email") = reponseDto.Email
                Session("profil") = reponseDto.Profil
                Return RedirectToAction("Index", "Home")
            End If
            ViewData("Erreur") = "echec !!"
            Return View()
        End Function
        Function Logout() As ActionResult
            Session.RemoveAll()
            Return RedirectToAction("Login")

        End Function

    End Class
End Namespace