<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DemoOverViewDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DemoOverViewDialog))
Me.chkShowDlg = New System.Windows.Forms.CheckBox
Me.btnOK = New System.Windows.Forms.Button
Me.groupBox1 = New System.Windows.Forms.GroupBox
Me.richTextBox1 = New System.Windows.Forms.RichTextBox
Me.SuspendLayout()
'
'chkShowDlg
'
Me.chkShowDlg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
Me.chkShowDlg.AutoSize = True
Me.chkShowDlg.Checked = True
Me.chkShowDlg.CheckState = System.Windows.Forms.CheckState.Checked
Me.chkShowDlg.Location = New System.Drawing.Point(2, 235)
Me.chkShowDlg.Name = "chkShowDlg"
Me.chkShowDlg.Size = New System.Drawing.Size(196, 21)
Me.chkShowDlg.TabIndex = 7
Me.chkShowDlg.Text = "Show this dialog on startup"
Me.chkShowDlg.UseVisualStyleBackColor = True
'
'btnOK
'
Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
Me.btnOK.Location = New System.Drawing.Point(464, 234)
Me.btnOK.Name = "btnOK"
Me.btnOK.Size = New System.Drawing.Size(75, 29)
Me.btnOK.TabIndex = 6
Me.btnOK.Text = "OK"
Me.btnOK.UseVisualStyleBackColor = True
'
'groupBox1
'
Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.groupBox1.Location = New System.Drawing.Point(-8, 225)
Me.groupBox1.Name = "groupBox1"
Me.groupBox1.Size = New System.Drawing.Size(563, 3)
Me.groupBox1.TabIndex = 5
Me.groupBox1.TabStop = False
'
'richTextBox1
'
Me.richTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.richTextBox1.Location = New System.Drawing.Point(2, 4)
Me.richTextBox1.Name = "richTextBox1"
Me.richTextBox1.ReadOnly = True
Me.richTextBox1.Size = New System.Drawing.Size(537, 215)
Me.richTextBox1.TabIndex = 4
Me.richTextBox1.Text = resources.GetString("richTextBox1.Text")
'
'DemoOverViewDialog
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(546, 267)
Me.Controls.Add(Me.chkShowDlg)
Me.Controls.Add(Me.btnOK)
Me.Controls.Add(Me.groupBox1)
Me.Controls.Add(Me.richTextBox1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "DemoOverViewDialog"
Me.ShowIcon = False
Me.ShowInTaskbar = False
Me.Text = "JPIP Client Demo Overview"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Private WithEvents chkShowDlg As System.Windows.Forms.CheckBox
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
End Class
