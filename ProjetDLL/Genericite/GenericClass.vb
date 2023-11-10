Public Class GenericClass(Of T)

    Public Property a As T
    Public Property b As T

    Public Sub Swap()
        Dim tmp As T = a
        a = b
        b = tmp
    End Sub

End Class
'On ajouter des conditions au type T
'(Of T as Class) T est une classe
'(Of T as New) T possède le constructeur par defaut
'(Of T as Animal) - T hérite de Animal
'(Of T as IClient) - T implémente l'interface ICLient
'(Of T as {New, Animal}
