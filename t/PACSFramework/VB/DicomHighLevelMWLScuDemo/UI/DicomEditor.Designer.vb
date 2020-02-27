Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class DicomEditor
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DicomEditor))
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.buttonOK = New System.Windows.Forms.Button()
			Me.buttonCancel = New System.Windows.Forms.Button()
			Me.propertyGridDataset = New System.Windows.Forms.PropertyGrid()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.buttonOK)
			Me.panel1.Controls.Add(Me.buttonCancel)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 462)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(759, 42)
			Me.panel1.TabIndex = 0
			' 
			' buttonOK
			' 
			Me.buttonOK.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.buttonOK.Location = New System.Drawing.Point(591, 7)
			Me.buttonOK.Name = "buttonOK"
			Me.buttonOK.Size = New System.Drawing.Size(75, 23)
			Me.buttonOK.TabIndex = 1
			Me.buttonOK.Text = "OK"
			Me.buttonOK.UseVisualStyleBackColor = True
			' 
			' buttonCancel
			' 
			Me.buttonCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.buttonCancel.Location = New System.Drawing.Point(672, 7)
			Me.buttonCancel.Name = "buttonCancel"
			Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
			Me.buttonCancel.TabIndex = 0
			Me.buttonCancel.Text = "Cancel"
			Me.buttonCancel.UseVisualStyleBackColor = True
			' 
			' propertyGridDataset
			' 
			Me.propertyGridDataset.Dock = System.Windows.Forms.DockStyle.Fill
			Me.propertyGridDataset.Location = New System.Drawing.Point(0, 0)
			Me.propertyGridDataset.Name = "propertyGridDataset"
			Me.propertyGridDataset.PropertySort = System.Windows.Forms.PropertySort.NoSort
			Me.propertyGridDataset.Size = New System.Drawing.Size(759, 462)
			Me.propertyGridDataset.TabIndex = 1
			' 
			' DicomEditor
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(759, 504)
			Me.Controls.Add(Me.propertyGridDataset)
			Me.Controls.Add(Me.panel1)
			Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "DicomEditor"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "DICOM Dataset Editor"
'			Me.Load += New System.EventHandler(Me.DicomEditor_Load);
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.DicomEditor_FormClosing);
			Me.panel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private panel1 As System.Windows.Forms.Panel
		Private buttonOK As System.Windows.Forms.Button
		Private buttonCancel As System.Windows.Forms.Button
		Private propertyGridDataset As System.Windows.Forms.PropertyGrid
	End Class
End Namespace