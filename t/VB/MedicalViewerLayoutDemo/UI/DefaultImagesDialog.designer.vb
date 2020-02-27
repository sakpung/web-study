Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
   Public Partial Class DefaultImagesDialog
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
		 Me.dontRadio = New System.Windows.Forms.RadioButton()
		 Me.loadRadio = New System.Windows.Forms.RadioButton()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.okButton = New System.Windows.Forms.Button()
		 Me.groupBox1.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me.dontRadio)
		 Me.groupBox1.Controls.Add(Me.loadRadio)
		 Me.groupBox1.Controls.Add(Me.label2)
		 Me.groupBox1.Controls.Add(Me.label1)
		 Me.groupBox1.Location = New System.Drawing.Point(7, 1)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(274, 161)
		 Me.groupBox1.TabIndex = 0
		 Me.groupBox1.TabStop = False
		 ' 
		 ' dontRadio
		 ' 
		 Me.dontRadio.AutoSize = True
		 Me.dontRadio.Location = New System.Drawing.Point(11, 137)
		 Me.dontRadio.Name = "dontRadio"
		 Me.dontRadio.Size = New System.Drawing.Size(145, 17)
		 Me.dontRadio.TabIndex = 3
		 Me.dontRadio.Text = "Don't load sample images"
		 Me.dontRadio.UseVisualStyleBackColor = True
		 ' 
		 ' loadRadio
		 ' 
		 Me.loadRadio.AutoSize = True
		 Me.loadRadio.Checked = True
		 Me.loadRadio.Location = New System.Drawing.Point(11, 111)
		 Me.loadRadio.Name = "loadRadio"
		 Me.loadRadio.Size = New System.Drawing.Size(121, 17)
		 Me.loadRadio.TabIndex = 2
		 Me.loadRadio.TabStop = True
		 Me.loadRadio.Text = "&Load sample images"
		 Me.loadRadio.UseVisualStyleBackColor = True
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(8, 84)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(206, 13)
		 Me.label2.TabIndex = 1
		 Me.label2.Text = "Would you like to load these images now?"
		 ' 
		 ' label1
		 ' 
		 Me.label1.Location = New System.Drawing.Point(6, 14)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(262, 59)
		 Me.label1.TabIndex = 0
		 Me.label1.Text = "The ""Image Viewer Demo"" can load sample DICOM images to demonstrate the capabilit" & "ies of the ""LEADTOOLS Image Viewer Control"""
		 ' 
		 ' okButton
		 ' 
		 Me.okButton.Location = New System.Drawing.Point(103, 170)
		 Me.okButton.Name = "okButton"
		 Me.okButton.Size = New System.Drawing.Size(79, 28)
		 Me.okButton.TabIndex = 1
		 Me.okButton.Text = "OK"
		 Me.okButton.UseVisualStyleBackColor = True
'		 Me.okButton.Click += New System.EventHandler(Me.okButton_Click);
		 ' 
		 ' DefaultImagesDialog
		 ' 
		 Me.AcceptButton = Me.okButton
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(288, 206)
		 Me.Controls.Add(Me.okButton)
		 Me.Controls.Add(Me.groupBox1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "DefaultImagesDialog"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		 Me.Text = "Load sample images"
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private label1 As System.Windows.Forms.Label
	  Private dontRadio As System.Windows.Forms.RadioButton
	  Private loadRadio As System.Windows.Forms.RadioButton
	  Private label2 As System.Windows.Forms.Label
	  Private WithEvents okButton As System.Windows.Forms.Button
   End Class
End Namespace