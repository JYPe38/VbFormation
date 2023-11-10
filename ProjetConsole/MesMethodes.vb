''' <summary>
''' Classe qui propose un certain nombre de fonctions intéressantes
''' </summary>
Public Class MesMethodes

    'Visibilité [Shared] Sub-Function Nom_Fonction(args) as Type_Retour (si fonction)
    'Dans une classe on peut avoir 2 types de méthodes:
    'Méthode d'instance: appelée via une instance de la classe
    'Méthode de classe: appelée via le nom de la classe

    Private Shared Function IsPositif(x As Integer) As Boolean
        Return x > 0
    End Function

    'Méthode d'instance
    Public Sub Afficher()
        Console.WriteLine("Méthode afficher.....")
    End Sub

    'Méthode de classe:
    Public Shared Sub Print()
        Console.WriteLine("méthode print.....")
    End Sub

    ''' <summary>
    ''' Fonction qui calcule la somme de 2 entiers
    ''' </summary>
    ''' <param name="x">est un entier</param>
    ''' <param name="y">est un entier</param>
    ''' <returns>somme de x et y</returns>
    Public Shared Function Somme(x As Integer, y As Integer) As Integer
        If IsPositif(x) And IsPositif(y) Then
            Return x + y
        Else
            Return 0
        End If

    End Function

    'Surcharger une méthode: c'est pouvoir définir la mm méthode dans la mm classe en modifiant ses params soit en nombre
    ' soit  en type

    Public Shared Function Somme(x As Integer, y As Integer, z As Integer) As Integer
        Return x + y + z
    End Function

    Public Shared Function Somme(x As Double, y As Double) As Double
        Return x + y
    End Function

    'Méthode avec des params optionnels: possèdent des valeurs par defaut et sont définis à la fin de la liste des params
    Public Shared Sub Afficher(x As Integer, Optional y As Integer = 15, Optional z As Integer = 11)
        Console.WriteLine($"x = {x} - y = {y} - z = {z}")
    End Sub

    Public Shared Function PrixTTC(prixHT As Double, Optional tva As Double = 0.2) As Double
        Return prixHT * (1 + tva)
    End Function

    'Passage de params par réferences: ByRef dans une méthode ne concerne que les types simples. les types complèxes par
    ' définition sont de stypes réfercenes
    Public Shared Sub Permuter(ByRef x As Integer, ByRef y As Integer)
        Dim tmp = x
        x = y
        y = tmp
    End Sub

    'Params en sortie d'une méthode
    Public Shared Function Calculs(x As Integer, y As Integer, ByRef prod As Integer) As Integer
        prod = x * y
        Return x + y

    End Function

    'Public Shared Function Soustraction(x As Integer, y As Integer) As Integer
    '    Return x - y
    'End Function

    'Public Shared Function Soustraction(x As Integer, y As Integer, z As Integer) As Integer
    '    Return x - y - z
    'End Function

    'Fonction avec un nombre variable de params
    Public Shared Function Soustraction(ParamArray p() As Integer) As Integer
        'p est un tableau à taille variable
        Dim s = 0
        For Each e In p
            s -= e
        Next
        Return s
    End Function

    Public Shared Sub Afficher(tab As Integer())
        For Each e In tab
            Console.WriteLine(e)
        Next
    End Sub

    'Méthode qui renvoie la somme des éléments d'un tableau d'entiers

    Public Shared Function SommeTab(tab As Integer()) As Integer
        Dim s = 0
        For Each e In tab
            s += e
        Next

        Return s
    End Function

    'Méthode qui renvoie la moyenne des éléments d'un tableau d'entiers

    Public Shared Function MoyenneTab(tab As Integer()) As Double
        Return SommeTab(tab) / tab.Length
    End Function

    'Méthode qui renvoie l'élément le plus petit d'un tableau d'entiers

    Public Shared Function MinTab(tab As Integer()) As Integer
        Dim min = tab(0)
        For index = 1 To tab.Length - 1
            If tab(index) < min Then
                min = tab(index)
            End If
        Next
        Return min
    End Function


End Class
