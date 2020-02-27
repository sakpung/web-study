
Partial Class TDAFilterDialog
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
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me.label4 = New System.Windows.Forms.Label()
      Me._numIterations = New System.Windows.Forms.NumericUpDown()
      Me.label3 = New System.Windows.Forms.Label()
      Me.label2 = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._numLambda = New System.Windows.Forms.NumericUpDown()
      Me._numKappa = New System.Windows.Forms.NumericUpDown()
      Me._cbFlux = New System.Windows.Forms.ComboBox()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOK = New System.Windows.Forms.Button()
      Me.groupBox1.SuspendLayout()
      CType(Me._numIterations, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numLambda, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numKappa, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.Add(Me.label4)
      Me.groupBox1.Controls.Add(Me._numIterations)
      Me.groupBox1.Controls.Add(Me.label3)
      Me.groupBox1.Controls.Add(Me.label2)
      Me.groupBox1.Controls.Add(Me.label1)
      Me.groupBox1.Controls.Add(Me._numLambda)
      Me.groupBox1.Controls.Add(Me._numKappa)
      Me.groupBox1.Controls.Add(Me._cbFlux)
      Me.groupBox1.Location = New System.Drawing.Point(14, 12)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(271, 148)
      Me.groupBox1.TabIndex = 5
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Parameters"
      ' 
      ' label4
      ' 
      Me.label4.AutoSize = True
      Me.label4.Location = New System.Drawing.Point(31, 26)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(50, 13)
      Me.label4.TabIndex = 10
      Me.label4.Text = "Iterations"
      ' 
      ' _numIterations
      ' 
      Me._numIterations.Location = New System.Drawing.Point(119, 19)
      Me._numIterations.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
      Me._numIterations.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numIterations.Name = "_numIterations"
      Me._numIterations.Size = New System.Drawing.Size(120, 20)
      Me._numIterations.TabIndex = 9
      Me._numIterations.Value = New Decimal(New Integer() {10, 0, 0, 0})
      ' 
      ' label3
      ' 
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(31, 111)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(26, 13)
      Me.label3.TabIndex = 8
      Me.label3.Text = "Flux"
      ' 
      ' label2
      ' 
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(31, 82)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(38, 13)
      Me.label2.TabIndex = 7
      Me.label2.Text = "Kappa"
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(31, 53)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(45, 13)
      Me.label1.TabIndex = 6
      Me.label1.Text = "Lambda"
      ' 
      ' _numLambda
      ' 
      Me._numLambda.Location = New System.Drawing.Point(119, 46)
      Me._numLambda.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
      Me._numLambda.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numLambda.Name = "_numLambda"
      Me._numLambda.Size = New System.Drawing.Size(120, 20)
      Me._numLambda.TabIndex = 3
      Me._numLambda.Value = New Decimal(New Integer() {14, 0, 0, 0})
      ' 
      ' _numKappa
      ' 
      Me._numKappa.Location = New System.Drawing.Point(119, 75)
      Me._numKappa.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numKappa.Name = "_numKappa"
      Me._numKappa.Size = New System.Drawing.Size(120, 20)
      Me._numKappa.TabIndex = 4
      Me._numKappa.Value = New Decimal(New Integer() {30, 0, 0, 0})
      ' 
      ' _cbFlux
      ' 
      Me._cbFlux.FormattingEnabled = True
      Me._cbFlux.Items.AddRange(New Object() {"Exponetial", "Quadratic"})
      Me._cbFlux.Location = New System.Drawing.Point(119, 108)
      Me._cbFlux.Name = "_cbFlux"
      Me._cbFlux.Size = New System.Drawing.Size(120, 21)
      Me._cbFlux.TabIndex = 5
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(152, 166)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 4
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOK
      ' 
      Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOK.Location = New System.Drawing.Point(71, 166)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(75, 23)
      Me._btnOK.TabIndex = 3
      Me._btnOK.Text = "OK"
      Me._btnOK.UseVisualStyleBackColor = True
      ' 
      ' TDAFilterDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(298, 205)
      Me.Controls.Add(Me.groupBox1)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "TDAFilterDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "TAD Anistropic"
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      CType(Me._numIterations, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numLambda, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numKappa, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private groupBox1 As System.Windows.Forms.GroupBox
   Private label4 As System.Windows.Forms.Label
   Private _numIterations As System.Windows.Forms.NumericUpDown
   Private label3 As System.Windows.Forms.Label
   Private label2 As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private _numLambda As System.Windows.Forms.NumericUpDown
   Private _numKappa As System.Windows.Forms.NumericUpDown
   Private _cbFlux As System.Windows.Forms.ComboBox
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOK As System.Windows.Forms.Button
End Class