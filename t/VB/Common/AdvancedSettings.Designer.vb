Imports Microsoft.VisualBasic
Imports System
Namespace FormsDemo
   Public Partial Class AdvancedSettings
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
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvancedSettings))
		 Me.btnOK = New System.Windows.Forms.Button()
		 Me.btnCancel = New System.Windows.Forms.Button()
		 Me._chkCompareAllPages = New System.Windows.Forms.CheckBox()
		 Me.groupBox2 = New System.Windows.Forms.GroupBox()
		 Me.label4 = New System.Windows.Forms.Label()
		 Me._chkOCRManager = New System.Windows.Forms.CheckBox()
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me._chkDefaultObjectManager = New System.Windows.Forms.CheckBox()
		 Me._chkBarcodeManager = New System.Windows.Forms.CheckBox()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.groupBox2.SuspendLayout()
		 Me.groupBox1.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' btnOK
		 ' 
		 Me.btnOK.Location = New System.Drawing.Point(196, 240)
		 Me.btnOK.Name = "btnOK"
		 Me.btnOK.Size = New System.Drawing.Size(81, 22)
		 Me.btnOK.TabIndex = 3
		 Me.btnOK.Text = "OK"
		 Me.btnOK.UseVisualStyleBackColor = True
'		 Me.btnOK.Click += New System.EventHandler(Me.btnOK_Click);
		 ' 
		 ' btnCancel
		 ' 
		 Me.btnCancel.Location = New System.Drawing.Point(297, 240)
		 Me.btnCancel.Name = "btnCancel"
		 Me.btnCancel.Size = New System.Drawing.Size(81, 22)
		 Me.btnCancel.TabIndex = 4
		 Me.btnCancel.Text = "Cancel"
		 Me.btnCancel.UseVisualStyleBackColor = True
'		 Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click);
		 ' 
		 ' _chkCompareAllPages
		 ' 
		 Me._chkCompareAllPages.AutoSize = True
		 Me._chkCompareAllPages.Checked = True
		 Me._chkCompareAllPages.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkCompareAllPages.Location = New System.Drawing.Point(17, 41)
		 Me._chkCompareAllPages.Name = "_chkCompareAllPages"
		 Me._chkCompareAllPages.Size = New System.Drawing.Size(115, 17)
		 Me._chkCompareAllPages.TabIndex = 3
		 Me._chkCompareAllPages.Text = "Compare All Pages"
		 Me._chkCompareAllPages.UseVisualStyleBackColor = True
		 ' 
		 ' groupBox2
		 ' 
		 Me.groupBox2.Controls.Add(Me.label4)
		 Me.groupBox2.Controls.Add(Me._chkCompareAllPages)
		 Me.groupBox2.Location = New System.Drawing.Point(12, 12)
		 Me.groupBox2.Name = "groupBox2"
		 Me.groupBox2.Size = New System.Drawing.Size(551, 72)
		 Me.groupBox2.TabIndex = 6
		 Me.groupBox2.TabStop = False
		 Me.groupBox2.Text = "Page Comparison Options"
		 ' 
		 ' label4
		 ' 
		 Me.label4.AutoSize = True
		 Me.label4.Location = New System.Drawing.Point(14, 21)
		 Me.label4.Name = "label4"
		 Me.label4.Size = New System.Drawing.Size(530, 13)
		 Me.label4.TabIndex = 6
		 Me.label4.Text = "(Select to compare all pages of multipage forms.  More accurate but slow.  Unsele" & "ct to compare first page only.)"
		 ' 
		 ' _chkOCRManager
		 ' 
		 Me._chkOCRManager.AutoSize = True
		 Me._chkOCRManager.Checked = True
		 Me._chkOCRManager.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkOCRManager.Location = New System.Drawing.Point(17, 42)
		 Me._chkOCRManager.Name = "_chkOCRManager"
		 Me._chkOCRManager.Size = New System.Drawing.Size(128, 17)
		 Me._chkOCRManager.TabIndex = 3
		 Me._chkOCRManager.Text = "OCR Object Manager"
		 Me._chkOCRManager.UseVisualStyleBackColor = True
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me._chkDefaultObjectManager)
		 Me.groupBox1.Controls.Add(Me._chkBarcodeManager)
		 Me.groupBox1.Controls.Add(Me.label1)
		 Me.groupBox1.Controls.Add(Me._chkOCRManager)
		 Me.groupBox1.Location = New System.Drawing.Point(12, 105)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(551, 114)
		 Me.groupBox1.TabIndex = 7
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "Object Manager Options"
		 ' 
		 ' _chkDefaultObjectManager
		 ' 
		 Me._chkDefaultObjectManager.AutoSize = True
		 Me._chkDefaultObjectManager.Checked = True
		 Me._chkDefaultObjectManager.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkDefaultObjectManager.Location = New System.Drawing.Point(17, 88)
		 Me._chkDefaultObjectManager.Name = "_chkDefaultObjectManager"
		 Me._chkDefaultObjectManager.Size = New System.Drawing.Size(300, 17)
		 Me._chkDefaultObjectManager.TabIndex = 8
		 Me._chkDefaultObjectManager.Text = "Default Object Manager (lines, shapes, logos, images, etc)"
		 Me._chkDefaultObjectManager.UseVisualStyleBackColor = True
		 ' 
		 ' _chkBarcodeManager
		 ' 
		 Me._chkBarcodeManager.AutoSize = True
		 Me._chkBarcodeManager.Checked = True
		 Me._chkBarcodeManager.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkBarcodeManager.Location = New System.Drawing.Point(17, 65)
		 Me._chkBarcodeManager.Name = "_chkBarcodeManager"
		 Me._chkBarcodeManager.Size = New System.Drawing.Size(145, 17)
		 Me._chkBarcodeManager.TabIndex = 7
		 Me._chkBarcodeManager.Text = "Barcode Object Manager"
		 Me._chkBarcodeManager.UseVisualStyleBackColor = True
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(14, 21)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(343, 13)
		 Me.label1.TabIndex = 6
		 Me.label1.Text = "Select the object managers to be used when generating form attributes."
		 ' 
		 ' AdvancedSettings
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(575, 274)
		 Me.Controls.Add(Me.groupBox1)
		 Me.Controls.Add(Me.groupBox2)
		 Me.Controls.Add(Me.btnCancel)
		 Me.Controls.Add(Me.btnOK)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		 Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "AdvancedSettings"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Settings"
		 Me.groupBox2.ResumeLayout(False)
		 Me.groupBox2.PerformLayout()
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private WithEvents btnOK As System.Windows.Forms.Button
	  Private WithEvents btnCancel As System.Windows.Forms.Button
	  Private _chkCompareAllPages As System.Windows.Forms.CheckBox
	  Private groupBox2 As System.Windows.Forms.GroupBox
	  Private label4 As System.Windows.Forms.Label
	  Private _chkOCRManager As System.Windows.Forms.CheckBox
	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private label1 As System.Windows.Forms.Label
	  Private _chkDefaultObjectManager As System.Windows.Forms.CheckBox
	  Private _chkBarcodeManager As System.Windows.Forms.CheckBox
   End Class
End Namespace