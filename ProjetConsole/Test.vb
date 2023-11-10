Public Class Test

    'y est une variable globalee (de classe):pas besoin de l'initialiser car elle possède une valeur par defaut
    'Types numériques: 0 par defuat
    'Type bool: false
    'Type complèxes: Nothing null
    Dim y As Integer
    Public Sub m1()
        'x variable locale qui doit être initialisée
        Dim x As Integer = 0
    End Sub

    Public Shared Sub m2()

    End Sub

End Class
