Public Class NumeroCroissant
    Implements IComparer(Of CompteBancaire)

    Public Function Compare(x As CompteBancaire, y As CompteBancaire) As Integer Implements IComparer(Of CompteBancaire).Compare
        Return x.Numero.CompareTo(y.Numero)
    End Function
End Class
