Public Class NumeroDecroissant
    Implements IComparer(Of CompteBancaire)

    Public Function Compare(x As CompteBancaire, y As CompteBancaire) As Integer Implements IComparer(Of CompteBancaire).Compare
        Return x.Numero.CompareTo(y.Numero) * -1
    End Function
End Class
