Imports System.Runtime.CompilerServices

Module ExtensionModule

    <Extension>
    Public Sub Imprimer(s As String)
        Console.WriteLine(s)
    End Sub

    <Extension>
    Public Sub Replace(tab As Integer(), index As Integer, value As Integer)
        tab(index) = value
    End Sub

    <Extension>
    Public Sub AfficherContenu(tab As Integer())
        For Each e In tab
            Console.WriteLine(e)
        Next
    End Sub

End Module
