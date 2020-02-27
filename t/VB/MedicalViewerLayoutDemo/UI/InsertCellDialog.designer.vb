Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
   Public Partial Class InsertCellDialog
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
		  Me.groupBox1 = New System.Windows.Forms.GroupBox()
		  Me._btnOK = New System.Windows.Forms.Button()
		  Me._btnCancel = New System.Windows.Forms.Button()
		  Me.label1 = New System.Windows.Forms.Label()
		  Me.ltx = New System.Windows.Forms.NumericUpDown()
		  Me.lty = New System.Windows.Forms.NumericUpDown()
		  Me.label2 = New System.Windows.Forms.Label()
		  Me.label4 = New System.Windows.Forms.Label()
		  Me.label5 = New System.Windows.Forms.Label()
		  Me.label3 = New System.Windows.Forms.Label()
		  Me.label6 = New System.Windows.Forms.Label()
		  Me.rby = New System.Windows.Forms.NumericUpDown()
		  Me.rbx = New System.Windows.Forms.NumericUpDown()
		  Me.groupBox1.SuspendLayout()
		  CType(Me.ltx, System.ComponentModel.ISupportInitialize).BeginInit()
		  CType(Me.lty, System.ComponentModel.ISupportInitialize).BeginInit()
		  CType(Me.rby, System.ComponentModel.ISupportInitialize).BeginInit()
		  CType(Me.rbx, System.ComponentModel.ISupportInitialize).BeginInit()
		  Me.SuspendLayout()
		  ' 
		  ' groupBox1
		  ' 
		  Me.groupBox1.Controls.Add(Me.label3)
		  Me.groupBox1.Controls.Add(Me.label6)
		  Me.groupBox1.Controls.Add(Me.rby)
		  Me.groupBox1.Controls.Add(Me.rbx)
		  Me.groupBox1.Controls.Add(Me.label5)
		  Me.groupBox1.Controls.Add(Me.label4)
		  Me.groupBox1.Controls.Add(Me.label2)
		  Me.groupBox1.Controls.Add(Me.lty)
		  Me.groupBox1.Controls.Add(Me.ltx)
		  Me.groupBox1.Controls.Add(Me.label1)
		  Me.groupBox1.Location = New System.Drawing.Point(9, 2)
		  Me.groupBox1.Name = "groupBox1"
		  Me.groupBox1.Size = New System.Drawing.Size(151, 173)
		  Me.groupBox1.TabIndex = 2
		  Me.groupBox1.TabStop = False
		  Me.groupBox1.Text = "&New Cell Position"
		  ' 
		  ' _btnOK
		  ' 
		  Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		  Me._btnOK.Location = New System.Drawing.Point(12, 181)
		  Me._btnOK.Name = "_btnOK"
		  Me._btnOK.Size = New System.Drawing.Size(71, 29)
		  Me._btnOK.TabIndex = 0
		  Me._btnOK.Text = "&OK"
		  Me._btnOK.UseVisualStyleBackColor = True
		  ' 
		  ' _btnCancel
		  ' 
		  Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		  Me._btnCancel.Location = New System.Drawing.Point(89, 181)
		  Me._btnCancel.Name = "_btnCancel"
		  Me._btnCancel.Size = New System.Drawing.Size(71, 29)
		  Me._btnCancel.TabIndex = 1
		  Me._btnCancel.Text = "C&anc&el"
		  Me._btnCancel.UseVisualStyleBackColor = True
		  ' 
		  ' label1
		  ' 
		  Me.label1.AutoSize = True
		  Me.label1.Location = New System.Drawing.Point(7, 20)
		  Me.label1.Name = "label1"
		  Me.label1.Size = New System.Drawing.Size(50, 13)
		  Me.label1.TabIndex = 0
		  Me.label1.Text = "Top Left:"
		  ' 
		  ' ltx
		  ' 
		  Me.ltx.DecimalPlaces = 2
		  Me.ltx.Increment = New Decimal(New Integer() { 5, 0, 0, 131072})
		  Me.ltx.Location = New System.Drawing.Point(46, 36)
		  Me.ltx.Maximum = New Decimal(New Integer() { 1, 0, 0, 0})
		  Me.ltx.Name = "ltx"
		  Me.ltx.Size = New System.Drawing.Size(66, 20)
		  Me.ltx.TabIndex = 0
		  ' 
		  ' lty
		  ' 
		  Me.lty.DecimalPlaces = 2
		  Me.lty.Increment = New Decimal(New Integer() { 5, 0, 0, 131072})
		  Me.lty.Location = New System.Drawing.Point(46, 62)
		  Me.lty.Maximum = New Decimal(New Integer() { 1, 0, 0, 0})
		  Me.lty.Name = "lty"
		  Me.lty.Size = New System.Drawing.Size(66, 20)
		  Me.lty.TabIndex = 1
		  ' 
		  ' label2
		  ' 
		  Me.label2.AutoSize = True
		  Me.label2.Location = New System.Drawing.Point(7, 94)
		  Me.label2.Name = "label2"
		  Me.label2.Size = New System.Drawing.Size(71, 13)
		  Me.label2.TabIndex = 3
		  Me.label2.Text = "Right Bottom:"
		  ' 
		  ' label4
		  ' 
		  Me.label4.AutoSize = True
		  Me.label4.Location = New System.Drawing.Point(23, 43)
		  Me.label4.Name = "label4"
		  Me.label4.Size = New System.Drawing.Size(17, 13)
		  Me.label4.TabIndex = 8
		  Me.label4.Text = "X:"
		  ' 
		  ' label5
		  ' 
		  Me.label5.AutoSize = True
		  Me.label5.Location = New System.Drawing.Point(23, 69)
		  Me.label5.Name = "label5"
		  Me.label5.Size = New System.Drawing.Size(17, 13)
		  Me.label5.TabIndex = 9
		  Me.label5.Text = "Y:"
		  ' 
		  ' label3
		  ' 
		  Me.label3.AutoSize = True
		  Me.label3.Location = New System.Drawing.Point(23, 142)
		  Me.label3.Name = "label3"
		  Me.label3.Size = New System.Drawing.Size(17, 13)
		  Me.label3.TabIndex = 13
		  Me.label3.Text = "Y:"
		  ' 
		  ' label6
		  ' 
		  Me.label6.AutoSize = True
		  Me.label6.Location = New System.Drawing.Point(23, 116)
		  Me.label6.Name = "label6"
		  Me.label6.Size = New System.Drawing.Size(17, 13)
		  Me.label6.TabIndex = 12
		  Me.label6.Text = "X:"
		  ' 
		  ' rby
		  ' 
		  Me.rby.DecimalPlaces = 2
		  Me.rby.Increment = New Decimal(New Integer() { 5, 0, 0, 131072})
		  Me.rby.Location = New System.Drawing.Point(46, 135)
		  Me.rby.Maximum = New Decimal(New Integer() { 1, 0, 0, 0})
		  Me.rby.Name = "rby"
		  Me.rby.Size = New System.Drawing.Size(66, 20)
		  Me.rby.TabIndex = 3
		  ' 
		  ' rbx
		  ' 
		  Me.rbx.DecimalPlaces = 2
		  Me.rbx.Increment = New Decimal(New Integer() { 5, 0, 0, 131072})
		  Me.rbx.Location = New System.Drawing.Point(46, 109)
		  Me.rbx.Maximum = New Decimal(New Integer() { 1, 0, 0, 0})
		  Me.rbx.Name = "rbx"
		  Me.rbx.Size = New System.Drawing.Size(66, 20)
		  Me.rbx.TabIndex = 2
		  ' 
		  ' InsertCellDialog
		  ' 
		  Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		  Me.ClientSize = New System.Drawing.Size(171, 217)
		  Me.Controls.Add(Me._btnCancel)
		  Me.Controls.Add(Me._btnOK)
		  Me.Controls.Add(Me.groupBox1)
		  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		  Me.MaximizeBox = False
		  Me.MinimizeBox = False
		  Me.Name = "InsertCellDialog"
		  Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		  Me.Text = "Insert Cell"
'		  Me.Load += New System.EventHandler(Me.InsertCellDialog_Load);
'		  Me.Shown += New System.EventHandler(Me.InsertCellDialog_Shown);
'		  Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.InsertCellDialog_FormClosing);
		  Me.groupBox1.ResumeLayout(False)
		  Me.groupBox1.PerformLayout()
		  CType(Me.ltx, System.ComponentModel.ISupportInitialize).EndInit()
		  CType(Me.lty, System.ComponentModel.ISupportInitialize).EndInit()
		  CType(Me.rby, System.ComponentModel.ISupportInitialize).EndInit()
		  CType(Me.rbx, System.ComponentModel.ISupportInitialize).EndInit()
		  Me.ResumeLayout(False)

	  End Sub

	  #End Region

	   Private groupBox1 As System.Windows.Forms.GroupBox
	  Private _btnOK As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
	   Private label1 As System.Windows.Forms.Label
	   Private label3 As System.Windows.Forms.Label
	   Private label6 As System.Windows.Forms.Label
	   Private rby As System.Windows.Forms.NumericUpDown
	   Private rbx As System.Windows.Forms.NumericUpDown
	   Private label5 As System.Windows.Forms.Label
	   Private label4 As System.Windows.Forms.Label
	   Private label2 As System.Windows.Forms.Label
	   Private lty As System.Windows.Forms.NumericUpDown
	   Private ltx As System.Windows.Forms.NumericUpDown
   End Class
End Namespace