Public Class Abonne

    'Subscriber: contient une propriété de type publisher (l'objet observé)

    Public WithEvents Compte As CompteBancaire

    Public Sub New(compte As CompteBancaire)
        Me.Compte = compte
    End Sub



    'La signature de cette doit être public sub et e prend en params les params envoyés par le publisher
    Public Sub Email_Notif(cpt As CompteBancaire) Handles Compte.OnSoldeNegatif
        Console.WriteLine("Notif: Votre solde est négatif, il est de : " & cpt.Solde)
        Console.WriteLine("Voulez vous effecter un dépôt? (oui/non)")
        Dim rep = Console.ReadLine()
        If rep.Equals("oui") Then
            Console.WriteLine("Montant à déposer: ")
            Dim montant As Double = CDbl(Console.ReadLine())
            cpt.Depot(montant)
            Console.WriteLine("Votre nouveau solde est de: " & cpt.Solde)
        Else
            Console.WriteLine("Attention, vous avez 48h pour régulariser votre situation.")
        End If
    End Sub

End Class
