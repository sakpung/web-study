Namespace Leadtools.Dicom.Server.Manager.Dialogs
    Partial Public Class AssociationDialog
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.labelAssociation = New System.Windows.Forms.Label()
            Me.textBoxAssociation = New System.Windows.Forms.TextBox()
            Me.buttonOK = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            ' 
            ' labelAssociation
            ' 
            Me.labelAssociation.AutoSize = True
            Me.labelAssociation.Location = New System.Drawing.Point(13, 13)
            Me.labelAssociation.Name = "labelAssociation"
            Me.labelAssociation.Size = New System.Drawing.Size(64, 13)
            Me.labelAssociation.TabIndex = 0
            Me.labelAssociation.Text = "Association:"
            ' 
            ' textBoxAssociation
            ' 
            Me.textBoxAssociation.Location = New System.Drawing.Point(16, 29)
            Me.textBoxAssociation.Multiline = True
            Me.textBoxAssociation.Name = "textBoxAssociation"
            Me.textBoxAssociation.ReadOnly = True
            Me.textBoxAssociation.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.textBoxAssociation.Size = New System.Drawing.Size(502, 329)
            Me.textBoxAssociation.TabIndex = 1
            Me.textBoxAssociation.WordWrap = False
            ' 
            ' buttonOK
            ' 
            Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.buttonOK.Location = New System.Drawing.Point(443, 373)
            Me.buttonOK.Name = "buttonOK"
            Me.buttonOK.Size = New System.Drawing.Size(75, 23)
            Me.buttonOK.TabIndex = 2
            Me.buttonOK.Text = "OK"
            Me.buttonOK.UseVisualStyleBackColor = True
            ' 
            ' AssociationDialog
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.buttonOK
            Me.ClientSize = New System.Drawing.Size(530, 408)
            Me.Controls.Add(Me.buttonOK)
            Me.Controls.Add(Me.textBoxAssociation)
            Me.Controls.Add(Me.labelAssociation)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AssociationDialog"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "AssociationDialog"
            '			Me.Load += New System.EventHandler(Me.AssociationDialog_Load);
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private textBoxAssociation As System.Windows.Forms.TextBox
        Private buttonOK As System.Windows.Forms.Button
        Private labelAssociation As System.Windows.Forms.Label
    End Class
End Namespace