''' <summary>
''' Le numéro d'un compte bancaire doit contenir au minimum 6 caracètres
''' </summary>
<Serializable>
Public Class CompteBancaire
    Implements IComparable(Of CompteBancaire)

#Region "Attributs+Propriétés"

    'Numéro avec contrainte: propriété full

    Private _numero As String
    Public Property Numero() As String
        Get
            Return _numero
        End Get
        Set(ByVal value As String)
            If value.Length >= 6 Then
                _numero = value
            Else
                'Console.WriteLine("Numéro doit contenir au min 6 char")
                Throw New AttributException("Numéro doit contenir au min 6 char")
            End If

        End Set
    End Property

    'Solde sans contraintes: propriété automatique
    Public Property Solde As Double

    'Mise en place d'un système d'nevoie de notifs
    '1-Définir un evenement dans le publisher (le sujet - l'objet observé)
    '2-Déclencher l'event et notifier les abonnés

    Public Event OnSoldeNegatif(cpt As CompteBancaire)

    Public Shared Property Banque As String = "BNP"

#End Region

#Region "Constructeurs"
    Public Sub New(numero As String, solde As Double)
        Me.Numero = numero
        Me.Solde = solde
    End Sub

    Public Sub New()
    End Sub


#End Region

#Region "Méthodes"

    Public Sub Depot(montant As Double)
        Solde += montant
    End Sub

    ''' <summary>
    ''' Si le solde est insuffisant, la méthode génère une excpetion
    ''' </summary>
    ''' <param name="montant"></param>
    ''' <exception cref="SoldeException"></exception>
    Public Sub Retrait(montant As Double)
        If Solde >= montant Then
            Solde -= montant
        Else
            'Console.WriteLine("Solde insuffisant......")
            'Throw New SoldeException("Solde insuffisant pour effectuer un retrait de: " & montant)
            Solde -= montant
            RaiseEvent OnSoldeNegatif(New CompteBancaire(Numero, Solde))
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return $"Numéro: {Numero} - Solde: {Solde}"
    End Function

    Public Shared Sub ChangerBanque(nomBanque As String)
        Banque = nomBanque
    End Sub

    'Destructeur: méthod eexécutée lors du passage du GC
    Protected Overrides Sub Finalize()
        Console.WriteLine("Objet compte bancaire détruit")
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim bancaire = TryCast(obj, CompteBancaire)
        Return bancaire IsNot Nothing AndAlso
               Numero = bancaire.Numero
    End Function



    'Dans classe objet: on doit générer les 2 méthodes (Equals + GetHashCode)
    ' GetHshCode: complète la méthode Equels - garantie l'égalité parfaite des objets


    Public Function SoldeInfCinqCent() As Boolean
        Return Solde < 5000
    End Function

    Public Function CompareTo(other As CompteBancaire) As Integer Implements IComparable(Of CompteBancaire).CompareTo
        If Me.Solde = other.Solde Then
            Return 0
        ElseIf Me.Solde > other.Solde Then
            Return 1
        Else
            Return -1
        End If
    End Function

    Public Overrides Function GetHashCode() As Integer
        Dim hashCode As Long = -1608181971
        hashCode = (hashCode * -1521134295 + EqualityComparer(Of String).Default.GetHashCode(Numero)).GetHashCode()
        Return CType(hashCode, Integer)
    End Function


#End Region

End Class
