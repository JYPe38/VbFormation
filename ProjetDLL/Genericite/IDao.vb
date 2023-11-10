Public Interface IDao(Of T As Class)

    Function GetAll() As List(Of T)
    Sub Insert(o As T)
    Sub Delete(o As T)
    Sub Update(o As T)

End Interface
