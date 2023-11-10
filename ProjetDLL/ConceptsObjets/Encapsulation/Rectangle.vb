Public Class Rectangle

    'Private _hauteur As Double

    'Public Property Hauteur() As Double
    '    Get
    '        Return _hauteur
    '    End Get
    '    Set(value As Double)
    '        If value > 0 Then
    '            _hauteur = value
    '        Else
    '            Console.WriteLine("Hauteur doit être positive")
    '        End If
    '    End Set
    'End Property

    ' Propriété full: si contraintes à gérer

    Private _hauteur As Double
    Public Property Hauteur() As Double
        Get
            Return _hauteur
        End Get
        Set(ByVal value As Double)
            If value > 0 Then
                _hauteur = value
            Else
                Console.WriteLine("Hauteur doit être positive")
            End If

        End Set
    End Property

    'Propriété automatique: pas de contraintes à géréer
    Public Property Largeur As Double
    Public ReadOnly Property Nom As String 'Pas d'accès en écriture

    Private _age As Integer
    Public Property Age() As Integer
        Get
            Return _age
        End Get
        Set(ByVal value As Integer)
            _age = value
        End Set
    End Property

    Public Function Surface() As Double
        Return hauteur * largeur
    End Function

End Class
