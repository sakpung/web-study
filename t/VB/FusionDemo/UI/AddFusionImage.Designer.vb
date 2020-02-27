Namespace FusionDemo
	Partial Public Class AddFusionImage
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
		   Me.groupBox1 = New System.Windows.Forms.GroupBox()
		   Me._trackBarWeight = New System.Windows.Forms.TrackBar()
		   Me._btnRemove = New System.Windows.Forms.Button()
		   Me._btnAdd = New System.Windows.Forms.Button()
		   Me._txtWeight = New FusionDemo.NumericTextBox()
		   Me.label1 = New System.Windows.Forms.Label()
		   Me._listFusionImages = New System.Windows.Forms.ListBox()
		   Me.groupBox1.SuspendLayout()
		   CType(Me._trackBarWeight, System.ComponentModel.ISupportInitialize).BeginInit()
		   Me.SuspendLayout()
		   ' 
		   ' _btnOK
		   ' 
		   Me._btnOK.Location = New System.Drawing.Point(345, 279)
		   Me._btnOK.Name = "_btnOK"
		   Me._btnOK.Size = New System.Drawing.Size(72, 26)
		   Me._btnOK.TabIndex = 16
		   Me._btnOK.Text = "&OK"
		   Me._btnOK.UseVisualStyleBackColor = True
		   ' 
		   ' groupBox1
		   ' 
		   Me.groupBox1.Controls.Add(Me._trackBarWeight)
		   Me.groupBox1.Controls.Add(Me._btnRemove)
		   Me.groupBox1.Controls.Add(Me._btnAdd)
		   Me.groupBox1.Controls.Add(Me._txtWeight)
		   Me.groupBox1.Controls.Add(Me.label1)
		   Me.groupBox1.Controls.Add(Me._listFusionImages)
		   Me.groupBox1.Location = New System.Drawing.Point(10, 8)
		   Me.groupBox1.Name = "groupBox1"
		   Me.groupBox1.Size = New System.Drawing.Size(409, 263)
		   Me.groupBox1.TabIndex = 20
		   Me.groupBox1.TabStop = False
		   Me.groupBox1.Text = "&Add/Remove Images"
		   ' 
		   ' _trackBarWeight
		   ' 
		   Me._trackBarWeight.Location = New System.Drawing.Point(354, 68)
		   Me._trackBarWeight.Maximum = 100
		   Me._trackBarWeight.Name = "_trackBarWeight"
		   Me._trackBarWeight.Orientation = System.Windows.Forms.Orientation.Vertical
		   Me._trackBarWeight.Size = New System.Drawing.Size(45, 142)
		   Me._trackBarWeight.TabIndex = 7
		   Me._trackBarWeight.TickFrequency = 100
		   Me._trackBarWeight.TickStyle = System.Windows.Forms.TickStyle.Both
		   ' 
		   ' _btnRemove
		   ' 
		   Me._btnRemove.Location = New System.Drawing.Point(185, 219)
		   Me._btnRemove.Name = "_btnRemove"
		   Me._btnRemove.Size = New System.Drawing.Size(72, 26)
		   Me._btnRemove.TabIndex = 6
		   Me._btnRemove.Text = "&Remove"
		   Me._btnRemove.UseVisualStyleBackColor = True
		   ' 
		   ' _btnAdd
		   ' 
		   Me._btnAdd.Location = New System.Drawing.Point(104, 219)
		   Me._btnAdd.Name = "_btnAdd"
		   Me._btnAdd.Size = New System.Drawing.Size(72, 26)
		   Me._btnAdd.TabIndex = 5
		   Me._btnAdd.Text = "A&dd"
		   Me._btnAdd.UseVisualStyleBackColor = True
		   ' 
		   ' _txtWeight
		   ' 
		   Me._txtWeight.Location = New System.Drawing.Point(349, 42)
		   Me._txtWeight.MaximumAllowed = 100
		   Me._txtWeight.MinimumAllowed = 0
		   Me._txtWeight.Name = "_txtWeight"
		   Me._txtWeight.Size = New System.Drawing.Size(52, 20)
		   Me._txtWeight.TabIndex = 2
		   Me._txtWeight.Text = "0"
		   Me._txtWeight.Value = 0
		   ' 
		   ' label1
		   ' 
		   Me.label1.AutoSize = True
		   Me.label1.Location = New System.Drawing.Point(354, 26)
		   Me.label1.Name = "label1"
		   Me.label1.Size = New System.Drawing.Size(41, 13)
		   Me.label1.TabIndex = 1
		   Me.label1.Text = "Weight"
		   ' 
		   ' _listFusionImages
		   ' 
		   Me._listFusionImages.FormattingEnabled = True
		   Me._listFusionImages.Location = New System.Drawing.Point(17, 24)
		   Me._listFusionImages.Name = "_listFusionImages"
		   Me._listFusionImages.Size = New System.Drawing.Size(319, 186)
		   Me._listFusionImages.TabIndex = 0
		   ' 
		   ' AddFusionImage
		   ' 
		   Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		   Me.ClientSize = New System.Drawing.Size(425, 318)
		   Me.ControlBox = False
		   Me.Controls.Add(Me.groupBox1)
		   Me.Controls.Add(Me._btnOK)
		   Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		   Me.MaximizeBox = False
		   Me.MinimizeBox = False
		   Me.Name = "AddFusionImage"
		   Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		   Me.Text = "Fusion Images"
		   Me.groupBox1.ResumeLayout(False)
		   Me.groupBox1.PerformLayout()
		   CType(Me._trackBarWeight, System.ComponentModel.ISupportInitialize).EndInit()
		   Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents _btnOK As System.Windows.Forms.Button
		Private groupBox1 As System.Windows.Forms.GroupBox
	   Private WithEvents _txtWeight As NumericTextBox
	   Private label1 As System.Windows.Forms.Label
	   Private WithEvents _listFusionImages As System.Windows.Forms.ListBox
	   Private WithEvents _btnRemove As System.Windows.Forms.Button
	   Private WithEvents _btnAdd As System.Windows.Forms.Button
	   Private WithEvents _trackBarWeight As System.Windows.Forms.TrackBar
	End Class
End Namespace