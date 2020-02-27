Partial Class ObjectPropertiesDialog
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
      Me._closeButton = New System.Windows.Forms.Button()
      Me._propertyGrid = New System.Windows.Forms.PropertyGrid()
      Me.SuspendLayout()
      ' 
      ' _closeButton
      ' 
      Me._closeButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
      Me._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._closeButton.Location = New System.Drawing.Point(12, 250)
      Me._closeButton.Name = "_closeButton"
      Me._closeButton.Size = New System.Drawing.Size(75, 23)
      Me._closeButton.TabIndex = 1
      Me._closeButton.Text = "Close"
      Me._closeButton.UseVisualStyleBackColor = True
      ' 
      ' _propertyGrid
      ' 
      Me._propertyGrid.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._propertyGrid.Location = New System.Drawing.Point(13, 13)
      Me._propertyGrid.Name = "_propertyGrid"
      Me._propertyGrid.Size = New System.Drawing.Size(393, 231)
      Me._propertyGrid.TabIndex = 0
      ' 
      ' ObjectPropertiesDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._closeButton
      Me.ClientSize = New System.Drawing.Size(418, 285)
      Me.Controls.Add(Me._propertyGrid)
      Me.Controls.Add(Me._closeButton)
      Me.MinimizeBox = False
      Me.Name = "ObjectPropertiesDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "ObjectPropertiesDialog"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _closeButton As System.Windows.Forms.Button
   Private _propertyGrid As System.Windows.Forms.PropertyGrid

End Class
