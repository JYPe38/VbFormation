<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.rbRetrait = New System.Windows.Forms.RadioButton()
        Me.rbDepot = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMontant = New System.Windows.Forms.TextBox()
        Me.txtSolde = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaseDeDonnéesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionDesUtilisateursToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnValider)
        Me.GroupBox1.Controls.Add(Me.rbRetrait)
        Me.GroupBox1.Controls.Add(Me.rbDepot)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMontant)
        Me.GroupBox1.Controls.Add(Me.txtSolde)
        Me.GroupBox1.Location = New System.Drawing.Point(226, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(261, 200)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Compte Bancaire:"
        '
        'btnValider
        '
        Me.btnValider.Location = New System.Drawing.Point(98, 157)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(75, 23)
        Me.btnValider.TabIndex = 6
        Me.btnValider.Text = "Valider"
        Me.btnValider.UseVisualStyleBackColor = True
        '
        'rbRetrait
        '
        Me.rbRetrait.AutoSize = True
        Me.rbRetrait.Location = New System.Drawing.Point(167, 125)
        Me.rbRetrait.Name = "rbRetrait"
        Me.rbRetrait.Size = New System.Drawing.Size(56, 17)
        Me.rbRetrait.TabIndex = 5
        Me.rbRetrait.TabStop = True
        Me.rbRetrait.Text = "Retrait"
        Me.rbRetrait.UseVisualStyleBackColor = True
        '
        'rbDepot
        '
        Me.rbDepot.AutoSize = True
        Me.rbDepot.Checked = True
        Me.rbDepot.Location = New System.Drawing.Point(34, 125)
        Me.rbDepot.Name = "rbDepot"
        Me.rbDepot.Size = New System.Drawing.Size(54, 17)
        Me.rbDepot.TabIndex = 4
        Me.rbDepot.TabStop = True
        Me.rbDepot.Text = "Dépôt"
        Me.rbDepot.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(46, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Montant:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Solde:"
        '
        'txtMontant
        '
        Me.txtMontant.Location = New System.Drawing.Point(140, 78)
        Me.txtMontant.Name = "txtMontant"
        Me.txtMontant.Size = New System.Drawing.Size(100, 20)
        Me.txtMontant.TabIndex = 1
        '
        'txtSolde
        '
        Me.txtSolde.Location = New System.Drawing.Point(140, 35)
        Me.txtSolde.Name = "txtSolde"
        Me.txtSolde.Size = New System.Drawing.Size(100, 20)
        Me.txtSolde.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(611, 235)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Test Repository"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.GestionDesUtilisateursToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(807, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BaseDeDonnéesToolStripMenuItem, Me.QuitterToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'BaseDeDonnéesToolStripMenuItem
        '
        Me.BaseDeDonnéesToolStripMenuItem.Name = "BaseDeDonnéesToolStripMenuItem"
        Me.BaseDeDonnéesToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.BaseDeDonnéesToolStripMenuItem.Text = "Base de données"
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'GestionDesUtilisateursToolStripMenuItem
        '
        Me.GestionDesUtilisateursToolStripMenuItem.Name = "GestionDesUtilisateursToolStripMenuItem"
        Me.GestionDesUtilisateursToolStripMenuItem.Size = New System.Drawing.Size(140, 20)
        Me.GestionDesUtilisateursToolStripMenuItem.Text = "Gestion des utilisateurs"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 448)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnValider As Button
    Friend WithEvents rbRetrait As RadioButton
    Friend WithEvents rbDepot As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMontant As TextBox
    Friend WithEvents txtSolde As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BaseDeDonnéesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GestionDesUtilisateursToolStripMenuItem As ToolStripMenuItem
End Class
