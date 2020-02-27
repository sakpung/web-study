Namespace Leadtools.Demos.Workstation.Customized
   Partial Class CustomWindowLevelControl
      ''' <summary> 
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary> 
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         OnDeactivated()

         If disposing AndAlso (Not components Is Nothing) Then
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
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.WindowWidthNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me.WindowCenterNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me.label3 = New System.Windows.Forms.Label()
         Me.PresetComboBox = New System.Windows.Forms.ComboBox()
         Me.AutoWindowLevelButton = New System.Windows.Forms.Button()
         Me.CloseButton = New System.Windows.Forms.Button()
         CType(Me.WindowWidthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.WindowCenterNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(3, 15)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(80, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Window Width:"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(3, 41)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(83, 13)
         Me.label2.TabIndex = 1
         Me.label2.Text = "Window Center:"
         ' 
         ' WindowWidthNumericUpDown
         ' 
         Me.WindowWidthNumericUpDown.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.WindowWidthNumericUpDown.Location = New System.Drawing.Point(89, 13)
         Me.WindowWidthNumericUpDown.Name = "WindowWidthNumericUpDown"
         Me.WindowWidthNumericUpDown.Size = New System.Drawing.Size(120, 20)
         Me.WindowWidthNumericUpDown.TabIndex = 2
         ' 
         ' WindowCenterNumericUpDown
         ' 
         Me.WindowCenterNumericUpDown.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.WindowCenterNumericUpDown.Location = New System.Drawing.Point(89, 39)
         Me.WindowCenterNumericUpDown.Name = "WindowCenterNumericUpDown"
         Me.WindowCenterNumericUpDown.Size = New System.Drawing.Size(120, 20)
         Me.WindowCenterNumericUpDown.TabIndex = 3
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(3, 67)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(40, 13)
         Me.label3.TabIndex = 4
         Me.label3.Text = "Preset:"
         ' 
         ' PresetComboBox
         ' 
         Me.PresetComboBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.PresetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.PresetComboBox.FormattingEnabled = True
         Me.PresetComboBox.Location = New System.Drawing.Point(89, 67)
         Me.PresetComboBox.Name = "PresetComboBox"
         Me.PresetComboBox.Size = New System.Drawing.Size(121, 21)
         Me.PresetComboBox.TabIndex = 5
         ' 
         ' AutoWindowLevelButton
         ' 
         Me.AutoWindowLevelButton.Location = New System.Drawing.Point(6, 99)
         Me.AutoWindowLevelButton.Name = "AutoWindowLevelButton"
         Me.AutoWindowLevelButton.Size = New System.Drawing.Size(75, 23)
         Me.AutoWindowLevelButton.TabIndex = 6
         Me.AutoWindowLevelButton.Text = "Auto"
         Me.AutoWindowLevelButton.UseVisualStyleBackColor = True
         ' 
         ' CloseButton
         ' 
         Me.CloseButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.CloseButton.Location = New System.Drawing.Point(134, 99)
         Me.CloseButton.Name = "CloseButton"
         Me.CloseButton.Size = New System.Drawing.Size(75, 23)
         Me.CloseButton.TabIndex = 7
         Me.CloseButton.Text = "Close"
         Me.CloseButton.UseVisualStyleBackColor = True
         ' 
         ' CustomWindowLevelControl
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.White
         Me.Controls.Add(Me.CloseButton)
         Me.Controls.Add(Me.AutoWindowLevelButton)
         Me.Controls.Add(Me.PresetComboBox)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me.WindowCenterNumericUpDown)
         Me.Controls.Add(Me.WindowWidthNumericUpDown)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.label1)
         Me.ForeColor = System.Drawing.Color.Black
         Me.Name = "CustomWindowLevelControl"
         Me.Size = New System.Drawing.Size(217, 133)
         CType(Me.WindowWidthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.WindowCenterNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private WindowWidthNumericUpDown As System.Windows.Forms.NumericUpDown
      Private WindowCenterNumericUpDown As System.Windows.Forms.NumericUpDown
      Private label3 As System.Windows.Forms.Label
      Private PresetComboBox As System.Windows.Forms.ComboBox
      Private AutoWindowLevelButton As System.Windows.Forms.Button
      Private CloseButton As System.Windows.Forms.Button
   End Class
End Namespace
