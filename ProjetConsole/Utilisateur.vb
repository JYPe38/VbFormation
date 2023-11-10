Public Class Utilisateur
    Inherits Object

    'Attributs d'instance
    Public Nom As String
    Public Age As Integer

    'Attribut de classe: attribut global (partagé par l'ensemble des objets)
    Public Shared Profil As String = "Admin"

    'Constructeur
    Public Sub New(nom As String, age As Integer)
        'Me: mot clé qui pointe vers l'objet en cours d'utilisation
        Me.Nom = nom
        Me.Age = age
    End Sub

    Public Sub New()
    End Sub

    'Méthodes
    Public Sub AfficherDetail()
        Console.WriteLine("Nom: " & Nom)
    End Sub

    Public Shared Sub ChangerProfil(newProfil As String)
        Profil = newProfil
    End Sub

    'Overrides: redéfinition de méthodes: pouvoir redéfinir une méthode déjà définie dans la classe supérieure
    'ToString(): permet de personnaliser l'affichage d'un objet
    Public Overrides Function ToString() As String
        Return $"Nom: {Nom} - Age: {Age}"
    End Function
End Class
