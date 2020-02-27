
Partial Class AnisotropicDiffusionDialog
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

#Region "Windows Form Designer generated code"

   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Me._lblIterations = New System.Windows.Forms.Label()
      Me._lblSmoothing = New System.Windows.Forms.Label()
      Me._lblTimeStep = New System.Windows.Forms.Label()
      Me._lblMinVariation = New System.Windows.Forms.Label()
      Me._lblMaxVariation = New System.Windows.Forms.Label()
      Me._lblEdgeHeight = New System.Windows.Forms.Label()
      Me._lblUpdate = New System.Windows.Forms.Label()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._numUpdate = New System.Windows.Forms.NumericUpDown()
      Me._numEdgeHeight = New System.Windows.Forms.NumericUpDown()
      Me._numMaxVariation = New System.Windows.Forms.NumericUpDown()
      Me._numMinVariation = New System.Windows.Forms.NumericUpDown()
      Me._numTimeStep = New System.Windows.Forms.NumericUpDown()
      Me._numSmoothing = New System.Windows.Forms.NumericUpDown()
      Me._numIterations = New System.Windows.Forms.NumericUpDown()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me.groupBox1.SuspendLayout()
      CType(Me._numUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numEdgeHeight, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numMaxVariation, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numMinVariation, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numTimeStep, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numSmoothing, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numIterations, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _lblIterations
      ' 
      Me._lblIterations.AutoSize = True
      Me._lblIterations.Location = New System.Drawing.Point(16, 25)
      Me._lblIterations.Name = "_lblIterations"
      Me._lblIterations.Size = New System.Drawing.Size(56, 13)
      Me._lblIterations.TabIndex = 0
      Me._lblIterations.Text = "Iterations :"
      ' 
      ' _lblSmoothing
      ' 
      Me._lblSmoothing.AutoSize = True
      Me._lblSmoothing.Location = New System.Drawing.Point(16, 55)
      Me._lblSmoothing.Name = "_lblSmoothing"
      Me._lblSmoothing.Size = New System.Drawing.Size(63, 13)
      Me._lblSmoothing.TabIndex = 1
      Me._lblSmoothing.Text = "Smoothing :"
      ' 
      ' _lblTimeStep
      ' 
      Me._lblTimeStep.AutoSize = True
      Me._lblTimeStep.Location = New System.Drawing.Point(16, 85)
      Me._lblTimeStep.Name = "_lblTimeStep"
      Me._lblTimeStep.Size = New System.Drawing.Size(58, 13)
      Me._lblTimeStep.TabIndex = 2
      Me._lblTimeStep.Text = "TimeStep :"
      ' 
      ' _lblMinVariation
      ' 
      Me._lblMinVariation.AutoSize = True
      Me._lblMinVariation.Location = New System.Drawing.Point(16, 115)
      Me._lblMinVariation.Name = "_lblMinVariation"
      Me._lblMinVariation.Size = New System.Drawing.Size(71, 13)
      Me._lblMinVariation.TabIndex = 3
      Me._lblMinVariation.Text = "MinVariation :"
      ' 
      ' _lblMaxVariation
      ' 
      Me._lblMaxVariation.AutoSize = True
      Me._lblMaxVariation.Location = New System.Drawing.Point(16, 145)
      Me._lblMaxVariation.Name = "_lblMaxVariation"
      Me._lblMaxVariation.Size = New System.Drawing.Size(74, 13)
      Me._lblMaxVariation.TabIndex = 4
      Me._lblMaxVariation.Text = "MaxVariation :"
      ' 
      ' _lblEdgeHeight
      ' 
      Me._lblEdgeHeight.AutoSize = True
      Me._lblEdgeHeight.Location = New System.Drawing.Point(16, 175)
      Me._lblEdgeHeight.Name = "_lblEdgeHeight"
      Me._lblEdgeHeight.Size = New System.Drawing.Size(69, 13)
      Me._lblEdgeHeight.TabIndex = 5
      Me._lblEdgeHeight.Text = "EdgeHeight :"
      ' 
      ' _lblUpdate
      ' 
      Me._lblUpdate.AutoSize = True
      Me._lblUpdate.Location = New System.Drawing.Point(16, 205)
      Me._lblUpdate.Name = "_lblUpdate"
      Me._lblUpdate.Size = New System.Drawing.Size(48, 13)
      Me._lblUpdate.TabIndex = 6
      Me._lblUpdate.Text = "Update :"
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.Add(Me._numUpdate)
      Me.groupBox1.Controls.Add(Me._numEdgeHeight)
      Me.groupBox1.Controls.Add(Me._numMaxVariation)
      Me.groupBox1.Controls.Add(Me._numMinVariation)
      Me.groupBox1.Controls.Add(Me._numTimeStep)
      Me.groupBox1.Controls.Add(Me._numSmoothing)
      Me.groupBox1.Controls.Add(Me._numIterations)
      Me.groupBox1.Controls.Add(Me._lblUpdate)
      Me.groupBox1.Controls.Add(Me._lblEdgeHeight)
      Me.groupBox1.Controls.Add(Me._lblMaxVariation)
      Me.groupBox1.Controls.Add(Me._lblMinVariation)
      Me.groupBox1.Controls.Add(Me._lblTimeStep)
      Me.groupBox1.Controls.Add(Me._lblSmoothing)
      Me.groupBox1.Controls.Add(Me._lblIterations)
      Me.groupBox1.Location = New System.Drawing.Point(10, 3)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(234, 246)
      Me.groupBox1.TabIndex = 7
      Me.groupBox1.TabStop = False
      ' 
      ' _numUpdate
      ' 
      Me._numUpdate.Location = New System.Drawing.Point(100, 203)
      Me._numUpdate.Margin = New System.Windows.Forms.Padding(2)
      Me._numUpdate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numUpdate.Name = "_numUpdate"
      Me._numUpdate.Size = New System.Drawing.Size(116, 20)
      Me._numUpdate.TabIndex = 13
      Me._numUpdate.Value = New Decimal(New Integer() {1, 0, 0, 0})
      ' 
      ' _numEdgeHeight
      ' 
      Me._numEdgeHeight.Location = New System.Drawing.Point(100, 173)
      Me._numEdgeHeight.Margin = New System.Windows.Forms.Padding(2)
      Me._numEdgeHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numEdgeHeight.Name = "_numEdgeHeight"
      Me._numEdgeHeight.Size = New System.Drawing.Size(116, 20)
      Me._numEdgeHeight.TabIndex = 12
      Me._numEdgeHeight.Value = New Decimal(New Integer() {100, 0, 0, 0})
      ' 
      ' _numMaxVariation
      ' 
      Me._numMaxVariation.DecimalPlaces = 2
      Me._numMaxVariation.Location = New System.Drawing.Point(100, 143)
      Me._numMaxVariation.Margin = New System.Windows.Forms.Padding(2)
      Me._numMaxVariation.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
      Me._numMaxVariation.Name = "_numMaxVariation"
      Me._numMaxVariation.Size = New System.Drawing.Size(116, 20)
      Me._numMaxVariation.TabIndex = 11
      Me._numMaxVariation.Value = New Decimal(New Integer() {100, 0, 0, 0})
      ' 
      ' _numMinVariation
      ' 
      Me._numMinVariation.DecimalPlaces = 2
      Me._numMinVariation.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
      Me._numMinVariation.Location = New System.Drawing.Point(100, 113)
      Me._numMinVariation.Margin = New System.Windows.Forms.Padding(2)
      Me._numMinVariation.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
      Me._numMinVariation.Name = "_numMinVariation"
      Me._numMinVariation.Size = New System.Drawing.Size(116, 20)
      Me._numMinVariation.TabIndex = 10
      Me._numMinVariation.Value = New Decimal(New Integer() {1, 0, 0, 0})
      ' 
      ' _numTimeStep
      ' 
      Me._numTimeStep.DecimalPlaces = 2
      Me._numTimeStep.Location = New System.Drawing.Point(100, 83)
      Me._numTimeStep.Margin = New System.Windows.Forms.Padding(2)
      Me._numTimeStep.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
      Me._numTimeStep.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
      Me._numTimeStep.Name = "_numTimeStep"
      Me._numTimeStep.Size = New System.Drawing.Size(116, 20)
      Me._numTimeStep.TabIndex = 9
      Me._numTimeStep.Value = New Decimal(New Integer() {100, 0, 0, 0})
      ' 
      ' _numSmoothing
      ' 
      Me._numSmoothing.Location = New System.Drawing.Point(100, 53)
      Me._numSmoothing.Margin = New System.Windows.Forms.Padding(2)
      Me._numSmoothing.Name = "_numSmoothing"
      Me._numSmoothing.Size = New System.Drawing.Size(116, 20)
      Me._numSmoothing.TabIndex = 8
      Me._numSmoothing.Value = New Decimal(New Integer() {100, 0, 0, 0})
      ' 
      ' _numIterations
      ' 
      Me._numIterations.Location = New System.Drawing.Point(100, 23)
      Me._numIterations.Margin = New System.Windows.Forms.Padding(2)
      Me._numIterations.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numIterations.Name = "_numIterations"
      Me._numIterations.Size = New System.Drawing.Size(116, 20)
      Me._numIterations.TabIndex = 7
      Me._numIterations.Value = New Decimal(New Integer() {1, 0, 0, 0})
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(134, 260)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 13
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(53, 260)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 12
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' AnisotropicDiffusionDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(255, 295)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me.groupBox1)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AnisotropicDiffusionDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Anisotropic Diffusion"
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      CType(Me._numUpdate, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numEdgeHeight, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numMaxVariation, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numMinVariation, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numTimeStep, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numSmoothing, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numIterations, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _lblIterations As System.Windows.Forms.Label
   Private _lblSmoothing As System.Windows.Forms.Label
   Private _lblTimeStep As System.Windows.Forms.Label
   Private _lblMinVariation As System.Windows.Forms.Label
   Private _lblMaxVariation As System.Windows.Forms.Label
   Private _lblEdgeHeight As System.Windows.Forms.Label
   Private _lblUpdate As System.Windows.Forms.Label
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private WithEvents _numIterations As System.Windows.Forms.NumericUpDown
   Private _numUpdate As System.Windows.Forms.NumericUpDown
   Private _numEdgeHeight As System.Windows.Forms.NumericUpDown
   Private _numMaxVariation As System.Windows.Forms.NumericUpDown
   Private _numMinVariation As System.Windows.Forms.NumericUpDown
   Private _numTimeStep As System.Windows.Forms.NumericUpDown
   Private _numSmoothing As System.Windows.Forms.NumericUpDown

End Class