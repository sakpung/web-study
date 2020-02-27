Imports Microsoft.VisualBasic
Namespace SpecialEffectsDemo
   Partial Class TransitionDialog
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
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._gbTransition = New System.Windows.Forms.GroupBox()
         Me._lblWand = New System.Windows.Forms.Label()
         Me._lblPasses = New System.Windows.Forms.Label()
         Me._lblGrain = New System.Windows.Forms.Label()
         Me._lblDelay = New System.Windows.Forms.Label()
         Me._numWand = New System.Windows.Forms.NumericUpDown()
         Me._numPasses = New System.Windows.Forms.NumericUpDown()
         Me._numGrain = New System.Windows.Forms.NumericUpDown()
         Me._numDelay = New System.Windows.Forms.NumericUpDown()
         Me._btnEffect = New System.Windows.Forms.Button()
         Me._btnBackColor = New System.Windows.Forms.Button()
         Me._lblBackColor = New System.Windows.Forms.Label()
         Me._btnForeColor = New System.Windows.Forms.Button()
         Me._lblForeColor = New System.Windows.Forms.Label()
         Me._cmbTransitionStyle = New System.Windows.Forms.ComboBox()
         Me._lblEffectStyle = New System.Windows.Forms.Label()
         Me._gbTransition.SuspendLayout()
         CType(Me._numWand, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numPasses, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numGrain, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numDelay, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(149, 217)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOK.Location = New System.Drawing.Point(68, 217)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 1
         Me._btnOK.Text = "OK" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _gbTransition
         ' 
         Me._gbTransition.Controls.Add(Me._lblWand)
         Me._gbTransition.Controls.Add(Me._lblPasses)
         Me._gbTransition.Controls.Add(Me._lblGrain)
         Me._gbTransition.Controls.Add(Me._lblDelay)
         Me._gbTransition.Controls.Add(Me._numWand)
         Me._gbTransition.Controls.Add(Me._numPasses)
         Me._gbTransition.Controls.Add(Me._numGrain)
         Me._gbTransition.Controls.Add(Me._numDelay)
         Me._gbTransition.Controls.Add(Me._btnEffect)
         Me._gbTransition.Controls.Add(Me._btnBackColor)
         Me._gbTransition.Controls.Add(Me._lblBackColor)
         Me._gbTransition.Controls.Add(Me._btnForeColor)
         Me._gbTransition.Controls.Add(Me._lblForeColor)
         Me._gbTransition.Controls.Add(Me._cmbTransitionStyle)
         Me._gbTransition.Controls.Add(Me._lblEffectStyle)
         Me._gbTransition.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbTransition.Location = New System.Drawing.Point(6, 1)
         Me._gbTransition.Name = "_gbTransition"
         Me._gbTransition.Size = New System.Drawing.Size(299, 205)
         Me._gbTransition.TabIndex = 0
         Me._gbTransition.TabStop = False
         ' 
         ' _lblWand
         ' 
         Me._lblWand.AutoSize = True
         Me._lblWand.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblWand.Location = New System.Drawing.Point(182, 174)
         Me._lblWand.Name = "_lblWand"
         Me._lblWand.Size = New System.Drawing.Size(42, 13)
         Me._lblWand.TabIndex = 13
         Me._lblWand.Text = "&Wand :"
         ' 
         ' _lblPasses
         ' 
         Me._lblPasses.AutoSize = True
         Me._lblPasses.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblPasses.Location = New System.Drawing.Point(182, 148)
         Me._lblPasses.Name = "_lblPasses"
         Me._lblPasses.Size = New System.Drawing.Size(47, 13)
         Me._lblPasses.TabIndex = 11
         Me._lblPasses.Text = "&Passes :"
         ' 
         ' _lblGrain
         ' 
         Me._lblGrain.AutoSize = True
         Me._lblGrain.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblGrain.Location = New System.Drawing.Point(11, 174)
         Me._lblGrain.Name = "_lblGrain"
         Me._lblGrain.Size = New System.Drawing.Size(38, 13)
         Me._lblGrain.TabIndex = 9
         Me._lblGrain.Text = "&Grain :"
         ' 
         ' _lblDelay
         ' 
         Me._lblDelay.AutoSize = True
         Me._lblDelay.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblDelay.Location = New System.Drawing.Point(10, 148)
         Me._lblDelay.Name = "_lblDelay"
         Me._lblDelay.Size = New System.Drawing.Size(40, 13)
         Me._lblDelay.TabIndex = 7
         Me._lblDelay.Text = "&Delay :"
         ' 
         ' _numWand
         ' 
         Me._numWand.Location = New System.Drawing.Point(236, 172)
         Me._numWand.Name = "_numWand"
         Me._numWand.Size = New System.Drawing.Size(50, 20)
         Me._numWand.TabIndex = 14
         ' 
         ' _numPasses
         ' 
         Me._numPasses.Location = New System.Drawing.Point(236, 146)
         Me._numPasses.Name = "_numPasses"
         Me._numPasses.Size = New System.Drawing.Size(50, 20)
         Me._numPasses.TabIndex = 12
         ' 
         ' _numGrain
         ' 
         Me._numGrain.Location = New System.Drawing.Point(71, 172)
         Me._numGrain.Name = "_numGrain"
         Me._numGrain.Size = New System.Drawing.Size(50, 20)
         Me._numGrain.TabIndex = 10
         ' 
         ' _numDelay
         ' 
         Me._numDelay.Location = New System.Drawing.Point(71, 146)
         Me._numDelay.Name = "_numDelay"
         Me._numDelay.Size = New System.Drawing.Size(50, 20)
         Me._numDelay.TabIndex = 8
         ' 
         ' _btnEffect
         ' 
         Me._btnEffect.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnEffect.Location = New System.Drawing.Point(195, 76)
         Me._btnEffect.Name = "_btnEffect"
         Me._btnEffect.Size = New System.Drawing.Size(91, 23)
         Me._btnEffect.TabIndex = 6
         Me._btnEffect.Text = "&Effect..."
         Me._btnEffect.UseVisualStyleBackColor = True
         ' 
         ' _btnBackColor
         ' 
         Me._btnBackColor.ForeColor = System.Drawing.SystemColors.ControlText
         Me._btnBackColor.Location = New System.Drawing.Point(72, 107)
         Me._btnBackColor.Name = "_btnBackColor"
         Me._btnBackColor.Size = New System.Drawing.Size(75, 23)
         Me._btnBackColor.TabIndex = 5
         Me._btnBackColor.Text = Constants.vbCrLf
         Me._btnBackColor.UseVisualStyleBackColor = False
         ' 
         ' _lblBackColor
         ' 
         Me._lblBackColor.AutoSize = True
         Me._lblBackColor.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblBackColor.Location = New System.Drawing.Point(8, 112)
         Me._lblBackColor.Name = "_lblBackColor"
         Me._lblBackColor.Size = New System.Drawing.Size(65, 13)
         Me._lblBackColor.TabIndex = 4
         Me._lblBackColor.Text = "&Back Color :"
         ' 
         ' _btnForeColor
         ' 
         Me._btnForeColor.ForeColor = System.Drawing.Color.Black
         Me._btnForeColor.Location = New System.Drawing.Point(72, 74)
         Me._btnForeColor.Name = "_btnForeColor"
         Me._btnForeColor.Size = New System.Drawing.Size(75, 23)
         Me._btnForeColor.TabIndex = 3
         Me._btnForeColor.UseVisualStyleBackColor = False
         ' 
         ' _lblForeColor
         ' 
         Me._lblForeColor.AutoSize = True
         Me._lblForeColor.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblForeColor.Location = New System.Drawing.Point(8, 79)
         Me._lblForeColor.Name = "_lblForeColor"
         Me._lblForeColor.Size = New System.Drawing.Size(61, 13)
         Me._lblForeColor.TabIndex = 2
         Me._lblForeColor.Text = "&Fore Color :"
         ' 
         ' _cmbTransitionStyle
         ' 
         Me._cmbTransitionStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbTransitionStyle.FormattingEnabled = True
         Me._cmbTransitionStyle.Location = New System.Drawing.Point(5, 32)
         Me._cmbTransitionStyle.Name = "_cmbTransitionStyle"
         Me._cmbTransitionStyle.Size = New System.Drawing.Size(281, 21)
         Me._cmbTransitionStyle.TabIndex = 1
         ' 
         ' _lblEffectStyle
         ' 
         Me._lblEffectStyle.AutoSize = True
         Me._lblEffectStyle.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblEffectStyle.Location = New System.Drawing.Point(5, 16)
         Me._lblEffectStyle.Name = "_lblEffectStyle"
         Me._lblEffectStyle.Size = New System.Drawing.Size(100, 13)
         Me._lblEffectStyle.TabIndex = 0
         Me._lblEffectStyle.Text = "Transition Fill &Style :"
         ' 
         ' TransitionDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(311, 250)
         Me.Controls.Add(Me._gbTransition)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "TransitionDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Transition Dialog"
         Me._gbTransition.ResumeLayout(False)
         Me._gbTransition.PerformLayout()
         CType(Me._numWand, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numPasses, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numGrain, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numDelay, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _gbTransition As System.Windows.Forms.GroupBox
      Private _cmbTransitionStyle As System.Windows.Forms.ComboBox
      Private _lblEffectStyle As System.Windows.Forms.Label
      Private WithEvents _btnBackColor As System.Windows.Forms.Button
      Private _lblBackColor As System.Windows.Forms.Label
      Private WithEvents _btnForeColor As System.Windows.Forms.Button
      Private _lblForeColor As System.Windows.Forms.Label
      Private WithEvents _btnEffect As System.Windows.Forms.Button
      Private _lblWand As System.Windows.Forms.Label
      Private _lblPasses As System.Windows.Forms.Label
      Private _lblGrain As System.Windows.Forms.Label
      Private _lblDelay As System.Windows.Forms.Label
      Private _numWand As System.Windows.Forms.NumericUpDown
      Private _numPasses As System.Windows.Forms.NumericUpDown
      Private _numGrain As System.Windows.Forms.NumericUpDown
      Private _numDelay As System.Windows.Forms.NumericUpDown

   End Class
End Namespace
