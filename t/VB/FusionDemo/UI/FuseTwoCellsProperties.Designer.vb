Namespace FusionDemo
   Partial Public Class FuseTwoCellsProperties
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
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me._btnOK = New System.Windows.Forms.Button()
		 Me._numStart = New System.Windows.Forms.NumericUpDown()
		 Me._numEnd = New System.Windows.Forms.NumericUpDown()
		 Me._chkBestAligned = New System.Windows.Forms.CheckBox()
		 CType(Me._numStart, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numEnd, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(40, 24)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(48, 13)
		 Me.label1.TabIndex = 0
		 Me.label1.Text = "Strat at:"
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(40, 50)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(42, 13)
		 Me.label2.TabIndex = 0
		 Me.label2.Text = "End at:"
		 ' 
		 ' _btnOK
		 ' 
		 Me._btnOK.Location = New System.Drawing.Point(69, 97)
		 Me._btnOK.Name = "_btnOK"
		 Me._btnOK.Size = New System.Drawing.Size(75, 23)
		 Me._btnOK.TabIndex = 2
		 Me._btnOK.Text = "OK"
		 Me._btnOK.UseVisualStyleBackColor = True
		 ' 
		 ' _numStart
		 ' 
		 Me._numStart.Location = New System.Drawing.Point(94, 22)
		 Me._numStart.Name = "_numStart"
		 Me._numStart.Size = New System.Drawing.Size(78, 20)
		 Me._numStart.TabIndex = 3
		 ' 
		 ' _numEnd
		 ' 
		 Me._numEnd.Location = New System.Drawing.Point(94, 48)
		 Me._numEnd.Name = "_numEnd"
		 Me._numEnd.Size = New System.Drawing.Size(78, 20)
		 Me._numEnd.TabIndex = 4
		 ' 
		 ' _chkBestAligned
		 ' 
		 Me._chkBestAligned.AutoSize = True
		 Me._chkBestAligned.Checked = True
		 Me._chkBestAligned.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkBestAligned.Location = New System.Drawing.Point(43, 74)
		 Me._chkBestAligned.Name = "_chkBestAligned"
		 Me._chkBestAligned.Size = New System.Drawing.Size(106, 17)
		 Me._chkBestAligned.TabIndex = 5
		 Me._chkBestAligned.Text = "Use Best Aligned"
		 Me._chkBestAligned.UseVisualStyleBackColor = True
		 ' 
		 ' FuseTwoCellsProperties
		 ' 
		 Me.AcceptButton = Me._btnOK
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(212, 134)
		 Me.ControlBox = False
		 Me.Controls.Add(Me._chkBestAligned)
		 Me.Controls.Add(Me._numEnd)
		 Me.Controls.Add(Me._numStart)
		 Me.Controls.Add(Me._btnOK)
		 Me.Controls.Add(Me.label2)
		 Me.Controls.Add(Me.label1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		 Me.Name = "FuseTwoCellsProperties"
		 Me.Text = "FuseTwoCellsProperties"
		 CType(Me._numStart, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numEnd, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private label1 As System.Windows.Forms.Label
	  Private label2 As System.Windows.Forms.Label
	  Private WithEvents _btnOK As System.Windows.Forms.Button
	  Private _numStart As System.Windows.Forms.NumericUpDown
	  Private _numEnd As System.Windows.Forms.NumericUpDown
	  Private _chkBestAligned As System.Windows.Forms.CheckBox
   End Class
End Namespace