Namespace Leadtools.Demos.Workstation.Customized
   Partial Class TranslatedCinePlayer
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
         Me.CinePlayerGroupBox.SuspendLayout()
         Me.FramesGroupBox.SuspendLayout()
         Me.ExtendedParametersGroupBox.SuspendLayout()
         Me.PlayerGroupBox.SuspendLayout()
         CType(Me.SpeedTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.FramePerSecondNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.JumpFramesNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' CinePlayerGroupBox
         ' 
         Me.CinePlayerGroupBox.Size = New System.Drawing.Size(600, 246)
         Me.CinePlayerGroupBox.Text = "Reproductor de Cine"
         ' 
         ' FramesGroupBox
         ' 
         Me.FramesGroupBox.Location = New System.Drawing.Point(240, 93)
         Me.FramesGroupBox.Size = New System.Drawing.Size(352, 143)
         Me.FramesGroupBox.Text = "&Imagenes"
         ' 
         ' ToEndCheckBox
         ' 
         Me.ToEndCheckBox.Size = New System.Drawing.Size(79, 17)
         Me.ToEndCheckBox.Text = "Hasta &Final"
         ' 
         ' FramesToLabel
         ' 
         Me.FramesToLabel.Size = New System.Drawing.Size(35, 13)
         Me.FramesToLabel.Text = "&Hasta"
         ' 
         ' FramesFromLabel
         ' 
         Me.FramesFromLabel.Size = New System.Drawing.Size(38, 13)
         Me.FramesFromLabel.Text = "Desde"
         ' 
         ' JumpFramesLabel
         ' 
         Me.JumpFramesLabel.Location = New System.Drawing.Point(198, 21)
         Me.JumpFramesLabel.Size = New System.Drawing.Size(53, 13)
         Me.JumpFramesLabel.Text = "Imagenes"
         ' 
         ' FramesLabel
         ' 
         Me.FramesLabel.Size = New System.Drawing.Size(53, 13)
         Me.FramesLabel.Text = "&Imagenes"
         ' 
         ' FramesComboBox
         ' 
         Me.FramesComboBox.Location = New System.Drawing.Point(65, 18)
         ' 
         ' ExtendedParametersGroupBox
         ' 
         Me.ExtendedParametersGroupBox.Size = New System.Drawing.Size(227, 143)
         ' 
         ' ShowAnnotationChcekBox
         ' 
         Me.ShowAnnotationChcekBox.Size = New System.Drawing.Size(112, 17)
         Me.ShowAnnotationChcekBox.Text = "Mostrar A&notación"
         ' 
         ' ShowRegionCheckBox
         ' 
         Me.ShowRegionCheckBox.Size = New System.Drawing.Size(98, 17)
         Me.ShowRegionCheckBox.Text = "&Mostrar Región"
         ' 
         ' AnimateAllSubCellsCheckBox
         ' 
         Me.AnimateAllSubCellsCheckBox.Size = New System.Drawing.Size(142, 17)
         Me.AnimateAllSubCellsCheckBox.Text = "&Animar Todas las Celdas"
         ' 
         ' InterpolationComboBox
         ' 
         Me.InterpolationComboBox.Location = New System.Drawing.Point(113, 49)
         ' 
         ' InterpolationLabel
         ' 
         Me.InterpolationLabel.Size = New System.Drawing.Size(68, 13)
         Me.InterpolationLabel.Text = "&Interpolación"
         ' 
         ' PlayModeLabel
         ' 
         Me.PlayModeLabel.Size = New System.Drawing.Size(104, 13)
         Me.PlayModeLabel.Text = "&Modo de Reproducir"
         ' 
         ' PlayerGroupBox
         ' 
         Me.PlayerGroupBox.Size = New System.Drawing.Size(585, 59)
         Me.PlayerGroupBox.Text = "&Reproductor"
         ' 
         ' FastSpeedLabel
         ' 
         Me.FastSpeedLabel.Location = New System.Drawing.Point(460, 28)
         Me.FastSpeedLabel.Size = New System.Drawing.Size(41, 13)
         Me.FastSpeedLabel.Text = "Rápido"
         ' 
         ' SlowSpeedLabel
         ' 
         Me.SlowSpeedLabel.Size = New System.Drawing.Size(34, 13)
         Me.SlowSpeedLabel.Text = "Lento"
         ' 
         ' SpeedTrackBar
         ' 
         Me.SpeedTrackBar.Size = New System.Drawing.Size(312, 39)
         ' 
         ' CloseDlgButton
         ' 
         Me.CloseDlgButton.Location = New System.Drawing.Point(584, 0)
         ' 
         ' FramePerSecondLabel
         ' 
         Me.FramePerSecondLabel.Location = New System.Drawing.Point(552, 28)
         Me.FramePerSecondLabel.Size = New System.Drawing.Size(22, 13)
         Me.FramePerSecondLabel.Text = "I/S"
         ' 
         ' FramePerSecondNumericUpDown
         ' 
         Me.FramePerSecondNumericUpDown.Location = New System.Drawing.Point(508, 25)
         ' 
         ' AdvancedChcekBox
         ' 
         Me.AdvancedChcekBox.Checked = True
         Me.AdvancedChcekBox.CheckState = System.Windows.Forms.CheckState.Checked
         Me.AdvancedChcekBox.Location = New System.Drawing.Point(496, 10)
         Me.AdvancedChcekBox.Size = New System.Drawing.Size(74, 17)
         Me.AdvancedChcekBox.Text = "Avanzado"
         ' 
         ' JumpFramesNumericUpDown
         ' 
         Me.JumpFramesNumericUpDown.Location = New System.Drawing.Point(157, 19)
         ' 
         ' PlayModeComboBox
         ' 
         Me.PlayModeComboBox.Location = New System.Drawing.Point(113, 21)
         ' 
         ' TranslatedCinePlayer
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(600, 246)
         Me.Name = "TranslatedCinePlayer"
         Me.Text = "TranslatedCinePlayer"
         Me.CinePlayerGroupBox.ResumeLayout(False)
         Me.CinePlayerGroupBox.PerformLayout()
         Me.FramesGroupBox.ResumeLayout(False)
         Me.FramesGroupBox.PerformLayout()
         Me.ExtendedParametersGroupBox.ResumeLayout(False)
         Me.ExtendedParametersGroupBox.PerformLayout()
         Me.PlayerGroupBox.ResumeLayout(False)
         Me.PlayerGroupBox.PerformLayout()
         CType(Me.SpeedTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.FramePerSecondNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.JumpFramesNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region
   End Class
End Namespace