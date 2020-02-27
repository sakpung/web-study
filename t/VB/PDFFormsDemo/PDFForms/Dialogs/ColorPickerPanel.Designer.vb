
Namespace PDFFormsDemo
   Partial Class ColorPickerPanel
      ''' <summary> 
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary> 
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Component Designer generated code"

      ''' <summary> 
      ''' Required method for Designer support - do not modify 
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me._openButton = New System.Windows.Forms.Button()
         Me._colorPanel = New System.Windows.Forms.Panel()
         Me._colorPickerDialog = New System.Windows.Forms.ColorDialog()
         Me.SuspendLayout()
         ' 
         ' _openButton
         ' 
         Me._openButton.Dock = System.Windows.Forms.DockStyle.Right
         Me._openButton.Location = New System.Drawing.Point(35, 0)
         Me._openButton.Name = "_openButton"
         Me._openButton.Size = New System.Drawing.Size(35, 25)
         Me._openButton.TabIndex = 0
         Me._openButton.Text = "..."
         Me._openButton.UseVisualStyleBackColor = True
         ' 
         ' _colorPanel
         ' 
         Me._colorPanel.BackColor = System.Drawing.Color.Black
         Me._colorPanel.Dock = System.Windows.Forms.DockStyle.Left
         Me._colorPanel.Location = New System.Drawing.Point(0, 0)
         Me._colorPanel.Name = "_colorPanel"
         Me._colorPanel.Size = New System.Drawing.Size(30, 25)
         Me._colorPanel.TabIndex = 1
         ' 
         ' ColorPickerPanel
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._colorPanel)
         Me.Controls.Add(Me._openButton)
         Me.Name = "ColorPickerPanel"
         Me.Size = New System.Drawing.Size(70, 25)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _openButton As System.Windows.Forms.Button
      Private _colorPanel As System.Windows.Forms.Panel
      Private _colorPickerDialog As System.Windows.Forms.ColorDialog
   End Class
End Namespace