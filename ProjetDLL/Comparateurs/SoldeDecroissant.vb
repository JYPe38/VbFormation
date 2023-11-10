Public Class SoldeDecroissant
    Implements IComparer(Of CompteBancaire)

    Public Function Compare(x As CompteBancaire, y As CompteBancaire) As Integer Implements IComparer(Of CompteBancaire).Compare
        If x.Solde = y.Solde Then
            Return 0
        ElseIf x.Solde > y.Solde Then
            Return -1
        Else
            Return 1
        End If
    End Function
End Class
