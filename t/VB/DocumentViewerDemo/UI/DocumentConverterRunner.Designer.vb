Partial Class DocumentConverterRunner
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
      Me.components = New System.ComponentModel.Container()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._outputWindow = New DocumentViewerDemo.OutputWindow()
      Me.SuspendLayout()
      ' 
      ' _cancelButton
      ' 
      Me._cancelButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(420, 271)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 1
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      ' 
      ' _outputWindow
      ' 
      Me._outputWindow.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._outputWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._outputWindow.Font = New System.Drawing.Font("Consolas", 8.0F)
      Me._outputWindow.Location = New System.Drawing.Point(12, 12)
      Me._outputWindow.Name = "_outputWindow"
      Me._outputWindow.Size = New System.Drawing.Size(483, 253)
      Me._outputWindow.TabIndex = 0
      Me._outputWindow.Text = ""
      ' 
      ' DocumentConverterRunner
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(507, 306)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._outputWindow)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DocumentConverterRunner"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Convert Document"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _outputWindow As OutputWindow
   Private WithEvents _cancelButton As System.Windows.Forms.Button
End Class
