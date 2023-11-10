
'Pour créer des excpetions personnalisées:
'1- Hériter de la classe Exception
'2- Appeler le constrcuteur de la classe Exception et lui fournir un merssage personnalisé
Public Class SoldeException
    Inherits Exception

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

End Class
