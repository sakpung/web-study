Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class Page4
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

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
      Private Sub InitializeComponent()
         Me.label1 = New System.Windows.Forms.Label()
         Me.panelTreeView = New System.Windows.Forms.Panel()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label4 = New System.Windows.Forms.Label()
         Me.txtElementValue = New System.Windows.Forms.TextBox()
         Me.txtSelectedWorklist = New System.Windows.Forms.TextBox()
         Me.txtModality = New System.Windows.Forms.TextBox()
         Me.btnSelectImage = New System.Windows.Forms.Button()
         Me.label5 = New System.Windows.Forms.Label()
         Me.rasterImageViewer = New Leadtools.Controls.ImageViewer
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(16, 16)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(550, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Select a Modality Work List Item below, click ""Select Image"" to select an image t" & "o associate with resulting dataset, "
         ' 
         ' panelTreeView
         ' 
         Me.panelTreeView.Location = New System.Drawing.Point(19, 64)
         Me.panelTreeView.Name = "panelTreeView"
         Me.panelTreeView.Size = New System.Drawing.Size(580, 248)
         Me.panelTreeView.TabIndex = 1
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(16, 331)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(75, 13)
         Me.label2.TabIndex = 0
         Me.label2.Text = "Element Value"
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(16, 358)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(90, 13)
         Me.label3.TabIndex = 1
         Me.label3.Text = "Selected Worklist"
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(16, 385)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(46, 13)
         Me.label4.TabIndex = 2
         Me.label4.Text = "Modality"
         ' 
         ' txtElementValue
         ' 
         Me.txtElementValue.Location = New System.Drawing.Point(109, 328)
         Me.txtElementValue.Name = "txtElementValue"
         Me.txtElementValue.ReadOnly = True
         Me.txtElementValue.Size = New System.Drawing.Size(331, 20)
         Me.txtElementValue.TabIndex = 3
         Me.txtElementValue.TabStop = False
         ' 
         ' txtSelectedWorklist
         ' 
         Me.txtSelectedWorklist.Location = New System.Drawing.Point(109, 355)
         Me.txtSelectedWorklist.Name = "txtSelectedWorklist"
         Me.txtSelectedWorklist.ReadOnly = True
         Me.txtSelectedWorklist.Size = New System.Drawing.Size(331, 20)
         Me.txtSelectedWorklist.TabIndex = 4
         Me.txtSelectedWorklist.TabStop = False
         ' 
         ' txtModality
         ' 
         Me.txtModality.Location = New System.Drawing.Point(109, 382)
         Me.txtModality.Name = "txtModality"
         Me.txtModality.ReadOnly = True
         Me.txtModality.Size = New System.Drawing.Size(331, 20)
         Me.txtModality.TabIndex = 5
         Me.txtModality.TabStop = False
         ' 
         ' btnSelectImage
         ' 
         Me.btnSelectImage.Location = New System.Drawing.Point(338, 409)
         Me.btnSelectImage.Name = "btnSelectImage"
         Me.btnSelectImage.Size = New System.Drawing.Size(102, 23)
         Me.btnSelectImage.TabIndex = 6
         Me.btnSelectImage.Text = "Select Image..."
         Me.btnSelectImage.UseVisualStyleBackColor = True
         '			Me.btnSelectImage.Click += New System.EventHandler(Me.btnSelectImage_Click);
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(16, 32)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(85, 13)
         Me.label5.TabIndex = 8
         Me.label5.Text = "and click ""Next"""
         ' 
         ' rasterImageViewer
         Me.rasterImageViewer.AutoDisposeImages = True
         Me.rasterImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.rasterImageViewer.AutoScroll = False
         Me.rasterImageViewer.Floater = Nothing
         Me.rasterImageViewer.Image = Nothing
         Me.rasterImageViewer.Location = New System.Drawing.Point(461, 328)
         Me.rasterImageViewer.AutoScroll = True
         Me.rasterImageViewer.Name = "rasterImageViewer"
         Me.rasterImageViewer.Zoom(Leadtools.Controls.ControlSizeMode.None, 1, Me.rasterImageViewer.DefaultZoomOrigin)
         Me.rasterImageViewer.ScrollOffset = New Leadtools.LeadPoint(0, 0)
         Me.rasterImageViewer.Size = New System.Drawing.Size(138, 104)
         Me.rasterImageViewer.Zoom(Leadtools.Controls.ControlSizeMode.Fit, 1, Me.rasterImageViewer.DefaultZoomOrigin)
         Me.rasterImageViewer.AutoScrollMinSize = New System.Drawing.Size(20, 20)
         Me.rasterImageViewer.SetBounds(0, 0, 0, 0)
         Me.rasterImageViewer.TabIndex = 0
         Me.rasterImageViewer.TabStop = False
         Me.rasterImageViewer.Text = "rasterImageViewer1"
         Me.rasterImageViewer.UseDpi = False
         Me.rasterImageViewer.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Near
         Me.rasterImageViewer.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Near
         ' 
         ' Page4
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.rasterImageViewer)
         Me.Controls.Add(Me.label5)
         Me.Controls.Add(Me.txtModality)
         Me.Controls.Add(Me.btnSelectImage)
         Me.Controls.Add(Me.txtSelectedWorklist)
         Me.Controls.Add(Me.txtElementValue)
         Me.Controls.Add(Me.label4)
         Me.Controls.Add(Me.panelTreeView)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.label2)
         Me.Name = "Page4"
         Me.Size = New System.Drawing.Size(618, 452)
         '			Me.VisibleChanged += New System.EventHandler(Me.Page4_VisibleChanged);
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private panelTreeView As System.Windows.Forms.Panel
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents btnSelectImage As System.Windows.Forms.Button
		Private label5 As System.Windows.Forms.Label
		Public txtElementValue As System.Windows.Forms.TextBox
		Public txtSelectedWorklist As System.Windows.Forms.TextBox
		Public txtModality As System.Windows.Forms.TextBox
      Private rasterImageViewer As Leadtools.Controls.ImageViewer

	End Class
End Namespace
