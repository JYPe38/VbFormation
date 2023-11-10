Public Class Form1
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        WindowState = FormWindowState.Minimized

    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        MenuPanel.Visible = Not MenuPanel.Visible
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenForm(New InscriptionForm())
    End Sub

    Dim activForm As Form = Nothing
    Private Sub OpenForm(f As Form)

        If activForm IsNot Nothing Then
            activForm.Close()
        End If
        activForm = f

        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        MainPanel.Controls.Add(f)

        f.Show()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenForm(New UsersForm())
    End Sub
End Class
