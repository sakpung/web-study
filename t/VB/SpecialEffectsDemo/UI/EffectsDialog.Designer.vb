Namespace SpecialEffectsDemo
   Partial Class EffectsDialog
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
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._lblEffectStyle = New System.Windows.Forms.Label()
         Me._cmbEffectStyle = New System.Windows.Forms.ComboBox()
         Me._gbEffect = New System.Windows.Forms.GroupBox()
         Me._lblWand = New System.Windows.Forms.Label()
         Me._lblPasses = New System.Windows.Forms.Label()
         Me._lblGrain = New System.Windows.Forms.Label()
         Me._lblDelay = New System.Windows.Forms.Label()
         Me._numWand = New System.Windows.Forms.NumericUpDown()
         Me._numPasses = New System.Windows.Forms.NumericUpDown()
         Me._numGrain = New System.Windows.Forms.NumericUpDown()
         Me._numDelay = New System.Windows.Forms.NumericUpDown()
         Me._gbEffect.SuspendLayout()
         CType(Me._numWand, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numPasses, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numGrain, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numDelay, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOK.Location = New System.Drawing.Point(116, 129)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 1
         Me._btnOK.Text = "OK" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(197, 129)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _lblEffectStyle
         ' 
         Me._lblEffectStyle.AutoSize = True
         Me._lblEffectStyle.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblEffectStyle.Location = New System.Drawing.Point(8, 20)
         Me._lblEffectStyle.Name = "_lblEffectStyle"
         Me._lblEffectStyle.Size = New System.Drawing.Size(67, 13)
         Me._lblEffectStyle.TabIndex = 0
         Me._lblEffectStyle.Text = "Effect &Style :"
         ' 
         ' _cmbEffectStyle
         ' 
         Me._cmbEffectStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbEffectStyle.FormattingEnabled = True
         Me._cmbEffectStyle.Location = New System.Drawing.Point(79, 16)
         Me._cmbEffectStyle.Name = "_cmbEffectStyle"
         Me._cmbEffectStyle.Size = New System.Drawing.Size(293, 21)
         Me._cmbEffectStyle.TabIndex = 1
         ' 
         ' _gbEffect
         ' 
         Me._gbEffect.Controls.Add(Me._lblWand)
         Me._gbEffect.Controls.Add(Me._lblPasses)
         Me._gbEffect.Controls.Add(Me._lblGrain)
         Me._gbEffect.Controls.Add(Me._lblDelay)
         Me._gbEffect.Controls.Add(Me._numWand)
         Me._gbEffect.Controls.Add(Me._numPasses)
         Me._gbEffect.Controls.Add(Me._numGrain)
         Me._gbEffect.Controls.Add(Me._numDelay)
         Me._gbEffect.Controls.Add(Me._cmbEffectStyle)
         Me._gbEffect.Controls.Add(Me._lblEffectStyle)
         Me._gbEffect.Location = New System.Drawing.Point(5, 3)
         Me._gbEffect.Name = "_gbEffect"
         Me._gbEffect.Size = New System.Drawing.Size(378, 115)
         Me._gbEffect.TabIndex = 0
         Me._gbEffect.TabStop = False
         ' 
         ' _lblWand
         ' 
         Me._lblWand.AutoSize = True
         Me._lblWand.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblWand.Location = New System.Drawing.Point(241, 84)
         Me._lblWand.Name = "_lblWand"
         Me._lblWand.Size = New System.Drawing.Size(42, 13)
         Me._lblWand.TabIndex = 8
         Me._lblWand.Text = "&Wand :"
         ' 
         ' _lblPasses
         ' 
         Me._lblPasses.AutoSize = True
         Me._lblPasses.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblPasses.Location = New System.Drawing.Point(241, 58)
         Me._lblPasses.Name = "_lblPasses"
         Me._lblPasses.Size = New System.Drawing.Size(47, 13)
         Me._lblPasses.TabIndex = 6
         Me._lblPasses.Text = "&Passes :"
         ' 
         ' _lblGrain
         ' 
         Me._lblGrain.AutoSize = True
         Me._lblGrain.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblGrain.Location = New System.Drawing.Point(34, 84)
         Me._lblGrain.Name = "_lblGrain"
         Me._lblGrain.Size = New System.Drawing.Size(38, 13)
         Me._lblGrain.TabIndex = 4
         Me._lblGrain.Text = "&Grain :"
         ' 
         ' _lblDelay
         ' 
         Me._lblDelay.AutoSize = True
         Me._lblDelay.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblDelay.Location = New System.Drawing.Point(33, 58)
         Me._lblDelay.Name = "_lblDelay"
         Me._lblDelay.Size = New System.Drawing.Size(40, 13)
         Me._lblDelay.TabIndex = 2
         Me._lblDelay.Text = "&Delay :"
         ' 
         ' _numWand
         ' 
         Me._numWand.Location = New System.Drawing.Point(294, 82)
         Me._numWand.Name = "_numWand"
         Me._numWand.Size = New System.Drawing.Size(77, 20)
         Me._numWand.TabIndex = 9
         ' 
         ' _numPasses
         ' 
         Me._numPasses.Location = New System.Drawing.Point(294, 56)
         Me._numPasses.Name = "_numPasses"
         Me._numPasses.Size = New System.Drawing.Size(77, 20)
         Me._numPasses.TabIndex = 7
         ' 
         ' _numGrain
         ' 
         Me._numGrain.Location = New System.Drawing.Point(79, 82)
         Me._numGrain.Name = "_numGrain"
         Me._numGrain.Size = New System.Drawing.Size(77, 20)
         Me._numGrain.TabIndex = 5
         ' 
         ' _numDelay
         ' 
         Me._numDelay.Location = New System.Drawing.Point(79, 56)
         Me._numDelay.Name = "_numDelay"
         Me._numDelay.Size = New System.Drawing.Size(77, 20)
         Me._numDelay.TabIndex = 3
         ' 
         ' EffectsDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(388, 164)
         Me.Controls.Add(Me._gbEffect)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "EffectsDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Effects Dialog"
         Me._gbEffect.ResumeLayout(False)
         Me._gbEffect.PerformLayout()
         CType(Me._numWand, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numPasses, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numGrain, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numDelay, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private _lblEffectStyle As System.Windows.Forms.Label
      Private _cmbEffectStyle As System.Windows.Forms.ComboBox
      Private _gbEffect As System.Windows.Forms.GroupBox
      Private _numDelay As System.Windows.Forms.NumericUpDown
      Private _numPasses As System.Windows.Forms.NumericUpDown
      Private _numGrain As System.Windows.Forms.NumericUpDown
      Private _numWand As System.Windows.Forms.NumericUpDown
      Private _lblWand As System.Windows.Forms.Label
      Private _lblPasses As System.Windows.Forms.Label
      Private _lblGrain As System.Windows.Forms.Label
      Private _lblDelay As System.Windows.Forms.Label
   End Class
End Namespace
