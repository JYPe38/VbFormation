Public Class Personnel
    Implements IEmploye

    Public Property Employes As New List(Of Employe)

    Public Sub AjouterEmploye(e As Employe) Implements IEmploye.AjouterEmploye
        Employes.Add(e)
    End Sub

    Public Sub AfficherSalaire() Implements IEmploye.AfficherSalaire
        For Each e In Employes
            Console.WriteLine($"{e.GetNom()} gagne {e.CalculerSalaire} euros.")
        Next
    End Sub

    Public Function SalaireMoyen() As Double Implements IEmploye.SalaireMoyen
        Dim somme = 0
        For Each e In Employes
            somme += e.CalculerSalaire()
        Next
        Return somme / Employes.Count
    End Function
End Class
