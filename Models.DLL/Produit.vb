<Serializable>
Public Class Produit

    Public Property Id As Integer
    Public Property Description As String
    Public Property Prix As Double
    Public Property Quantite As Integer

    Public Sub New(id As Integer, description As String, prix As Double, quantite As Integer)
        Me.Id = id
        Me.Description = description
        Me.Prix = prix
        Me.Quantite = quantite
    End Sub

    Public Sub New()
    End Sub

    Public Sub New(description As String, prix As Double, quantite As Integer)
        Me.Description = description
        Me.Prix = prix
        Me.Quantite = quantite
    End Sub

    Public Overrides Function ToString() As String
        Return $"Description: {Description} Prix: {Prix} Quantité: {Quantite}"
    End Function
End Class
