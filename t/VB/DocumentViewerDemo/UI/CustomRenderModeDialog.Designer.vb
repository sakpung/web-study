Partial Class CustomRenderModeDialog
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (Not components Is Nothing) Then
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomRenderModeDialog))
      Me._okButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._descriptionLabel = New System.Windows.Forms.Label()
      Me._visibleObjectsLabel = New System.Windows.Forms.Label()
      Me._visibleObjectsListBox = New System.Windows.Forms.ListBox()
      Me._invisibleObjectsListBox = New System.Windows.Forms.ListBox()
      Me._invisibleObjectsLabel = New System.Windows.Forms.Label()
      Me._moveToInvisibleButton = New System.Windows.Forms.Button()
      Me._moveToVisibleButton = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _okButton
      ' 
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(425, 117)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 7
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      ' 
      ' _cancelButton
      ' 
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(425, 146)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 8
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      ' 
      ' _descriptionLabel
      ' 
      Me._descriptionLabel.Location = New System.Drawing.Point(13, 13)
      Me._descriptionLabel.Name = "_descriptionLabel"
      Me._descriptionLabel.Size = New System.Drawing.Size(406, 69)
      Me._descriptionLabel.TabIndex = 0
      Me._descriptionLabel.Text = resources.GetString("_descriptionLabel.Text")
      ' 
      ' _visibleObjectsLabel
      ' 
      Me._visibleObjectsLabel.AutoSize = True
      Me._visibleObjectsLabel.Location = New System.Drawing.Point(10, 98)
      Me._visibleObjectsLabel.Name = "_visibleObjectsLabel"
      Me._visibleObjectsLabel.Size = New System.Drawing.Size(77, 13)
      Me._visibleObjectsLabel.TabIndex = 1
      Me._visibleObjectsLabel.Text = "&Visible objects:"
      ' 
      ' _visibleObjectsListBox
      ' 
      Me._visibleObjectsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
      Me._visibleObjectsListBox.FormattingEnabled = True
      Me._visibleObjectsListBox.Location = New System.Drawing.Point(13, 117)
      Me._visibleObjectsListBox.Name = "_visibleObjectsListBox"
      Me._visibleObjectsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
      Me._visibleObjectsListBox.Size = New System.Drawing.Size(200, 290)
      Me._visibleObjectsListBox.Sorted = True
      Me._visibleObjectsListBox.TabIndex = 2
      ' 
      ' _invisibleObjectsListBox
      ' 
      Me._invisibleObjectsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
      Me._invisibleObjectsListBox.FormattingEnabled = True
      Me._invisibleObjectsListBox.Location = New System.Drawing.Point(219, 117)
      Me._invisibleObjectsListBox.Name = "_invisibleObjectsListBox"
      Me._invisibleObjectsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
      Me._invisibleObjectsListBox.Size = New System.Drawing.Size(200, 290)
      Me._invisibleObjectsListBox.Sorted = True
      Me._invisibleObjectsListBox.TabIndex = 5
      ' 
      ' _invisibleObjectsLabel
      ' 
      Me._invisibleObjectsLabel.AutoSize = True
      Me._invisibleObjectsLabel.Location = New System.Drawing.Point(216, 98)
      Me._invisibleObjectsLabel.Name = "_invisibleObjectsLabel"
      Me._invisibleObjectsLabel.Size = New System.Drawing.Size(85, 13)
      Me._invisibleObjectsLabel.TabIndex = 4
      Me._invisibleObjectsLabel.Text = "&Invisible objects:"
      ' 
      ' _moveToInvisibleButton
      ' 
      Me._moveToInvisibleButton.Location = New System.Drawing.Point(138, 413)
      Me._moveToInvisibleButton.Name = "_moveToInvisibleButton"
      Me._moveToInvisibleButton.Size = New System.Drawing.Size(75, 23)
      Me._moveToInvisibleButton.TabIndex = 3
      Me._moveToInvisibleButton.Text = ">>"
      Me._moveToInvisibleButton.UseVisualStyleBackColor = True      ' 
      ' _moveToVisibleButton
      ' 
      Me._moveToVisibleButton.Location = New System.Drawing.Point(219, 413)
      Me._moveToVisibleButton.Name = "_moveToVisibleButton"
      Me._moveToVisibleButton.Size = New System.Drawing.Size(75, 23)
      Me._moveToVisibleButton.TabIndex = 6
      Me._moveToVisibleButton.Text = "<<"
      Me._moveToVisibleButton.UseVisualStyleBackColor = True      ' 
      ' CustomRenderModeDialog
      ' 
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(509, 445)
      Me.Controls.Add(Me._moveToVisibleButton)
      Me.Controls.Add(Me._moveToInvisibleButton)
      Me.Controls.Add(Me._invisibleObjectsListBox)
      Me.Controls.Add(Me._invisibleObjectsLabel)
      Me.Controls.Add(Me._visibleObjectsListBox)
      Me.Controls.Add(Me._visibleObjectsLabel)
      Me.Controls.Add(Me._descriptionLabel)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CustomRenderModeDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Customize Render Mode"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _cancelButton As System.Windows.Forms.Button
   Private _descriptionLabel As System.Windows.Forms.Label
   Private _visibleObjectsLabel As System.Windows.Forms.Label
   Private WithEvents _visibleObjectsListBox As System.Windows.Forms.ListBox
   Private WithEvents _invisibleObjectsListBox As System.Windows.Forms.ListBox
   Private _invisibleObjectsLabel As System.Windows.Forms.Label
   Private WithEvents _moveToInvisibleButton As System.Windows.Forms.Button
   Private WithEvents _moveToVisibleButton As System.Windows.Forms.Button
End Class
