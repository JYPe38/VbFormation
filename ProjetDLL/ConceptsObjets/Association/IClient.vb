Public Interface IClient

    'c'est peudo classe abstraite qui ne contient que des méthodes abstraites
    Function GetAll() As List(Of Client)
    Sub Insert(c As Client)
    Sub Delete(c As Client)
    Sub Update(c As Client)

End Interface
