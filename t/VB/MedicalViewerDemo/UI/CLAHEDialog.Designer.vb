Namespace MedicalViewerDemo
   Partial Class CLAHEDialog
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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._cbBinsNumber = New System.Windows.Forms.ComboBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me._numClipLimit = New System.Windows.Forms.NumericUpDown()
         Me.label4 = New System.Windows.Forms.Label()
         Me._numTilesNumber = New System.Windows.Forms.NumericUpDown()
         Me.label3 = New System.Windows.Forms.Label()
         Me._numAlpha = New System.Windows.Forms.NumericUpDown()
         Me._cbFlags = New System.Windows.Forms.ComboBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me._btnApply = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         CType(Me._numClipLimit, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numTilesNumber, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.Location = New System.Drawing.Point(108, 228)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 0
         Me._btnOK.Text = "OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(204, 228)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 1
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._cbBinsNumber)
         Me.groupBox1.Controls.Add(Me.label5)
         Me.groupBox1.Controls.Add(Me._numClipLimit)
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me._numTilesNumber)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me._numAlpha)
         Me.groupBox1.Controls.Add(Me._cbFlags)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Location = New System.Drawing.Point(12, 12)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(268, 202)
         Me.groupBox1.TabIndex = 2
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Parameters"
         ' 
         ' _cbBinsNumber
         ' 
         Me._cbBinsNumber.AutoCompleteCustomSource.AddRange(New String() {"2", "4", "8", "16", "32", "64", "128", "256", "512", "1024"})
         Me._cbBinsNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbBinsNumber.FormattingEnabled = True
         Me._cbBinsNumber.Items.AddRange(New Object() {"2", "4", "8", "16", "32", "64", "128", "256", "512", "1024"})
         Me._cbBinsNumber.Location = New System.Drawing.Point(130, 163)
         Me._cbBinsNumber.Name = "_cbBinsNumber"
         Me._cbBinsNumber.Size = New System.Drawing.Size(121, 21)
         Me._cbBinsNumber.TabIndex = 12
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(25, 166)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(66, 13)
         Me.label5.TabIndex = 11
         Me.label5.Text = "Bins Number"
         ' 
         ' _numClipLimit
         ' 
         Me._numClipLimit.DecimalPlaces = 3
         Me._numClipLimit.Increment = New Decimal(New Integer() {5, 0, 0, 196608})
         Me._numClipLimit.Location = New System.Drawing.Point(131, 130)
         Me._numClipLimit.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numClipLimit.Name = "_numClipLimit"
         Me._numClipLimit.Size = New System.Drawing.Size(120, 20)
         Me._numClipLimit.TabIndex = 10
         Me._numClipLimit.Value = New Decimal(New Integer() {8, 0, 0, 131072})
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(25, 133)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(48, 13)
         Me.label4.TabIndex = 9
         Me.label4.Text = "Clip Limit"
         ' 
         ' _numTilesNumber
         ' 
         Me._numTilesNumber.Location = New System.Drawing.Point(131, 97)
         Me._numTilesNumber.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
         Me._numTilesNumber.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numTilesNumber.Name = "_numTilesNumber"
         Me._numTilesNumber.Size = New System.Drawing.Size(120, 20)
         Me._numTilesNumber.TabIndex = 8
         Me._numTilesNumber.Value = New Decimal(New Integer() {25, 0, 0, 0})
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(25, 100)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(68, 13)
         Me.label3.TabIndex = 7
         Me.label3.Text = "Tiles Number"
         ' 
         ' _numAlpha
         ' 
         Me._numAlpha.DecimalPlaces = 2
         Me._numAlpha.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
         Me._numAlpha.Location = New System.Drawing.Point(131, 64)
         Me._numAlpha.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numAlpha.Name = "_numAlpha"
         Me._numAlpha.Size = New System.Drawing.Size(120, 20)
         Me._numAlpha.TabIndex = 6
         Me._numAlpha.Value = New Decimal(New Integer() {65, 0, 0, 131072})
         ' 
         ' _cbFlags
         ' 
         Me._cbFlags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbFlags.FormattingEnabled = True
         Me._cbFlags.Items.AddRange(New Object() {"Normal", "Exponential", "Raylieh", "Sigmoid"})
         Me._cbFlags.Location = New System.Drawing.Point(131, 21)
         Me._cbFlags.Name = "_cbFlags"
         Me._cbFlags.Size = New System.Drawing.Size(121, 21)
         Me._cbFlags.TabIndex = 5
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(25, 24)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(32, 13)
         Me.label1.TabIndex = 3
         Me.label1.Text = "Flags"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(25, 67)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(34, 13)
         Me.label2.TabIndex = 4
         Me.label2.Text = "Alpha"
         ' 
         ' _btnApply
         ' 
         Me._btnApply.Location = New System.Drawing.Point(12, 228)
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.Size = New System.Drawing.Size(75, 23)
         Me._btnApply.TabIndex = 3
         Me._btnApply.Text = "Apply"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' CLAHEDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(292, 265)
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "CLAHEDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "CLAHE Dialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         CType(Me._numClipLimit, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numTilesNumber, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numAlpha, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private WithEvents _numAlpha As System.Windows.Forms.NumericUpDown
      Private WithEvents _cbFlags As System.Windows.Forms.ComboBox
      Private WithEvents _btnApply As System.Windows.Forms.Button
      Private WithEvents _numTilesNumber As System.Windows.Forms.NumericUpDown
      Private label3 As System.Windows.Forms.Label
      Private WithEvents _cbBinsNumber As System.Windows.Forms.ComboBox
      Private label5 As System.Windows.Forms.Label
      Private WithEvents _numClipLimit As System.Windows.Forms.NumericUpDown
      Private label4 As System.Windows.Forms.Label
   End Class
End Namespace
