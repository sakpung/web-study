
Partial Class DocumentFormatSelector
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentFormatSelector))
      Me._formatComboBox = New System.Windows.Forms.ComboBox()
      Me._formatOptionsButton = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _formatComboBox
      ' 
      Me._formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._formatComboBox.FormattingEnabled = True
      resources.ApplyResources(Me._formatComboBox, "_formatComboBox")
      Me._formatComboBox.Name = "_formatComboBox"
      ' 
      ' _formatOptionsButton
      ' 
      resources.ApplyResources(Me._formatOptionsButton, "_formatOptionsButton")
      Me._formatOptionsButton.Name = "_formatOptionsButton"
      Me._formatOptionsButton.UseVisualStyleBackColor = True
      ' 
      ' DocumentFormatSelector
      ' 
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._formatOptionsButton)
      Me.Controls.Add(Me._formatComboBox)
      Me.Name = "DocumentFormatSelector"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _formatComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _formatOptionsButton As System.Windows.Forms.Button
End Class
