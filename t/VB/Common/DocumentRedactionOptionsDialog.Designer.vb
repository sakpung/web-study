' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Partial Class DocumentRedactionOptionsDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me._okButton = New System.Windows.Forms.Button()
      Me._tabControl = New System.Windows.Forms.TabControl()
      Me._viewRedactionTabPage = New System.Windows.Forms.TabPage()
      Me._noteTextBox = New System.Windows.Forms.TextBox()
      Me._viewRedactionOptionsControl = New DocumentRedactionOptionsControl()
      Me._convertRedactionTabPage = New System.Windows.Forms.TabPage()
      Me._convertRedactionOptionsControl = New DocumentRedactionOptionsControl()
      Me._tabControl.SuspendLayout()
      Me._viewRedactionTabPage.SuspendLayout()
      Me._convertRedactionTabPage.SuspendLayout()
      Me.SuspendLayout()
      Me._okButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles))
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(236, 172)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 2
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      Me._tabControl.Anchor = (CType(((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles))
      Me._tabControl.Controls.Add(Me._viewRedactionTabPage)
      Me._tabControl.Controls.Add(Me._convertRedactionTabPage)
      Me._tabControl.Location = New System.Drawing.Point(12, 12)
      Me._tabControl.Name = "_tabControl"
      Me._tabControl.SelectedIndex = 0
      Me._tabControl.Size = New System.Drawing.Size(303, 154)
      Me._tabControl.TabIndex = 0
      Me._viewRedactionTabPage.Controls.Add(Me._noteTextBox)
      Me._viewRedactionTabPage.Controls.Add(Me._viewRedactionOptionsControl)
      Me._viewRedactionTabPage.Location = New System.Drawing.Point(4, 22)
      Me._viewRedactionTabPage.Name = "_viewRedactionTabPage"
      Me._viewRedactionTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._viewRedactionTabPage.Size = New System.Drawing.Size(295, 128)
      Me._viewRedactionTabPage.TabIndex = 0
      Me._viewRedactionTabPage.Text = "View"
      Me._viewRedactionTabPage.UseVisualStyleBackColor = True
      Me._noteTextBox.BackColor = System.Drawing.SystemColors.Window
      Me._noteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me._noteTextBox.Location = New System.Drawing.Point(7, 86)
      Me._noteTextBox.Multiline = True
      Me._noteTextBox.Name = "_noteTextBox"
      Me._noteTextBox.[ReadOnly] = True
      Me._noteTextBox.Size = New System.Drawing.Size(282, 39)
      Me._noteTextBox.TabIndex = 0
      Me._noteTextBox.Text = "Changes made to this option will cause saving the document to cache then reload i" & "t."
      Me._viewRedactionOptionsControl.Location = New System.Drawing.Point(7, 7)
      Me._viewRedactionOptionsControl.Name = "_viewRedactionOptionsControl"
      Me._viewRedactionOptionsControl.Size = New System.Drawing.Size(282, 96)
      Me._viewRedactionOptionsControl.TabIndex = 0
      Me._convertRedactionTabPage.Controls.Add(Me._convertRedactionOptionsControl)
      Me._convertRedactionTabPage.Location = New System.Drawing.Point(4, 22)
      Me._convertRedactionTabPage.Name = "_convertRedactionTabPage"
      Me._convertRedactionTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._convertRedactionTabPage.Size = New System.Drawing.Size(295, 158)
      Me._convertRedactionTabPage.TabIndex = 1
      Me._convertRedactionTabPage.Text = "Convert"
      Me._convertRedactionTabPage.UseVisualStyleBackColor = True
      Me._convertRedactionOptionsControl.Location = New System.Drawing.Point(7, 7)
      Me._convertRedactionOptionsControl.Name = "_convertRedactionOptionsControl"
      Me._convertRedactionOptionsControl.Size = New System.Drawing.Size(282, 96)
      Me._convertRedactionOptionsControl.TabIndex = 0
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._okButton
      Me.ClientSize = New System.Drawing.Size(327, 207)
      Me.Controls.Add(Me._tabControl)
      Me.Controls.Add(Me._okButton)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DocumentRedactionOptionsDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Document Redaction Options"
      Me._tabControl.ResumeLayout(False)
      Me._viewRedactionTabPage.ResumeLayout(False)
      Me._viewRedactionTabPage.PerformLayout()
      Me._convertRedactionTabPage.ResumeLayout(False)
      Me.ResumeLayout(False)
   End Sub

   Private _okButton As System.Windows.Forms.Button
   Private _tabControl As System.Windows.Forms.TabControl
   Private _viewRedactionTabPage As System.Windows.Forms.TabPage
   Private _convertRedactionTabPage As System.Windows.Forms.TabPage
   Private _viewRedactionOptionsControl As DocumentRedactionOptionsControl
   Private _convertRedactionOptionsControl As DocumentRedactionOptionsControl
   Private _noteTextBox As System.Windows.Forms.TextBox
End Class
