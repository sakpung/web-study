
Partial Class CLAHEDialog
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
      Me._gbParamerters = New System.Windows.Forms.GroupBox()
      Me._cmbBinsNumber = New System.Windows.Forms.ComboBox()
      Me._numClipLimit = New System.Windows.Forms.NumericUpDown()
      Me._numTiles = New System.Windows.Forms.NumericUpDown()
      Me._numAlpha = New System.Windows.Forms.NumericUpDown()
      Me._cmbFlags = New System.Windows.Forms.ComboBox()
      Me.label5 = New System.Windows.Forms.Label()
      Me.label4 = New System.Windows.Forms.Label()
      Me.label3 = New System.Windows.Forms.Label()
      Me.label2 = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._btnOK = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._gbParamerters.SuspendLayout()
      CType(Me._numClipLimit, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numTiles, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbParamerters
      ' 
      Me._gbParamerters.Controls.Add(Me._cmbBinsNumber)
      Me._gbParamerters.Controls.Add(Me._numClipLimit)
      Me._gbParamerters.Controls.Add(Me._numTiles)
      Me._gbParamerters.Controls.Add(Me._numAlpha)
      Me._gbParamerters.Controls.Add(Me._cmbFlags)
      Me._gbParamerters.Controls.Add(Me.label5)
      Me._gbParamerters.Controls.Add(Me.label4)
      Me._gbParamerters.Controls.Add(Me.label3)
      Me._gbParamerters.Controls.Add(Me.label2)
      Me._gbParamerters.Controls.Add(Me.label1)
      Me._gbParamerters.Location = New System.Drawing.Point(9, 7)
      Me._gbParamerters.Name = "_gbParamerters"
      Me._gbParamerters.Size = New System.Drawing.Size(246, 184)
      Me._gbParamerters.TabIndex = 0
      Me._gbParamerters.TabStop = False
      Me._gbParamerters.Text = "Parameters"
      ' 
      ' _cmbBinsNumber
      ' 
      Me._cmbBinsNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbBinsNumber.FormattingEnabled = True
      Me._cmbBinsNumber.Items.AddRange(New Object() {"2", "4", "8", "16", "32", "64", _
       "128", "256", "512", "1024"})
      Me._cmbBinsNumber.Location = New System.Drawing.Point(125, 143)
      Me._cmbBinsNumber.Name = "_cmbBinsNumber"
      Me._cmbBinsNumber.Size = New System.Drawing.Size(103, 21)
      Me._cmbBinsNumber.TabIndex = 9
      ' 
      ' _numClipLimit
      ' 
      Me._numClipLimit.DecimalPlaces = 3
      Me._numClipLimit.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
      Me._numClipLimit.Location = New System.Drawing.Point(125, 114)
      Me._numClipLimit.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numClipLimit.Name = "_numClipLimit"
      Me._numClipLimit.Size = New System.Drawing.Size(103, 20)
      Me._numClipLimit.TabIndex = 8
      ' 
      ' _numTiles
      ' 
      Me._numTiles.Location = New System.Drawing.Point(125, 85)
      Me._numTiles.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
      Me._numTiles.Name = "_numTiles"
      Me._numTiles.Size = New System.Drawing.Size(103, 20)
      Me._numTiles.TabIndex = 7
      ' 
      ' _numAlpha
      ' 
      Me._numAlpha.DecimalPlaces = 2
      Me._numAlpha.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
      Me._numAlpha.Location = New System.Drawing.Point(125, 56)
      Me._numAlpha.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numAlpha.Name = "_numAlpha"
      Me._numAlpha.Size = New System.Drawing.Size(103, 20)
      Me._numAlpha.TabIndex = 6
      ' 
      ' _cmbFlags
      ' 
      Me._cmbFlags.FormattingEnabled = True
      Me._cmbFlags.Items.AddRange(New Object() {"Normal", "Exponential", "Raylieh", "Sigmoid"})
      Me._cmbFlags.Location = New System.Drawing.Point(125, 26)
      Me._cmbFlags.Name = "_cmbFlags"
      Me._cmbFlags.Size = New System.Drawing.Size(103, 21)
      Me._cmbFlags.TabIndex = 5
      ' 
      ' label5
      ' 
      Me.label5.AutoSize = True
      Me.label5.Location = New System.Drawing.Point(22, 149)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(67, 13)
      Me.label5.TabIndex = 4
      Me.label5.Text = "Bins Number"
      ' 
      ' label4
      ' 
      Me.label4.AutoSize = True
      Me.label4.Location = New System.Drawing.Point(22, 119)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(48, 13)
      Me.label4.TabIndex = 3
      Me.label4.Text = "Clip Limit"
      ' 
      ' label3
      ' 
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(22, 89)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(69, 13)
      Me.label3.TabIndex = 2
      Me.label3.Text = "Tiles Number"
      ' 
      ' label2
      ' 
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(22, 59)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(34, 13)
      Me.label2.TabIndex = 1
      Me.label2.Text = "Alpha"
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(22, 29)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(32, 13)
      Me.label1.TabIndex = 0
      Me.label1.Text = "Flags"
      ' 
      ' _btnOK
      ' 
      Me._btnOK.Location = New System.Drawing.Point(48, 197)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(75, 23)
      Me._btnOK.TabIndex = 1
      Me._btnOK.Text = "OK"
      Me._btnOK.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.Location = New System.Drawing.Point(134, 197)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 2
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' CLAHEDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(265, 240)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOK)
      Me.Controls.Add(Me._gbParamerters)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CLAHEDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "CLAHE"
      Me._gbParamerters.ResumeLayout(False)
      Me._gbParamerters.PerformLayout()
      CType(Me._numClipLimit, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numTiles, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numAlpha, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbParamerters As System.Windows.Forms.GroupBox
   Private _cmbBinsNumber As System.Windows.Forms.ComboBox
   Private _numClipLimit As System.Windows.Forms.NumericUpDown
   Private _numTiles As System.Windows.Forms.NumericUpDown
   Private _numAlpha As System.Windows.Forms.NumericUpDown
   Private WithEvents _cmbFlags As System.Windows.Forms.ComboBox
   Private label5 As System.Windows.Forms.Label
   Private label4 As System.Windows.Forms.Label
   Private label3 As System.Windows.Forms.Label
   Private label2 As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private WithEvents _btnOK As System.Windows.Forms.Button
   Private WithEvents _btnCancel As System.Windows.Forms.Button
End Class