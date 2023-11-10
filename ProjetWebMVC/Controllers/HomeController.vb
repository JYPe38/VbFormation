Imports Models.DLL

Public Class HomeController
    Inherits System.Web.Mvc.Controller
    'un ctrl est une classe qui herite de asp.net qui contient des methodes (appelées action)
    'une vue possède le même nom que la méthode qui renvoie cette vue
    Function Index() As ActionResult
        '2 options possibles pour envoyer des données à la vue
        'Option1:utiliser les 2 dictionnaires fournis par asp.net - pratique pour les types simples

        ViewData("cle") = "Données du viewData" 'détruit en memoire une fois la réponse renvoyée
        Session.Timeout = 30 'session d'une durée de trente minutes
        Session("cle") = "Données de session" 'objet disponible en mémoir tant que l'appli est en cours, par defaut entre 25 et 30 minute

        'option 2 : renvoyer des données via les params de la fonction View(model) pour les types complexes
        Dim u As New Utilisateur("JY@gmail.com", "admin", "pass", Utilisateur.Profils.ADMIN)
        'pour envoyer plusieurs types d'objets, on utilise les DTO

        Return View(u)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
