Namespace OcrScreenCaptureDemo
   Partial Class MainForm
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
         Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._splitContainer = New System.Windows.Forms.SplitContainer()
         Me._richTextBox = New System.Windows.Forms.RichTextBox()
         Me.mainPanel = New System.Windows.Forms.Panel()
         Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._tsUseHotkey = New System.Windows.Forms.ToolStripButton()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
         Me._tsDrawingChoice = New System.Windows.Forms.ToolStripDropDownButton()
         Me.penToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.highlighterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._tsCaptureBtn = New System.Windows.Forms.ToolStripSplitButton()
         Me.freehandArea = New System.Windows.Forms.ToolStripMenuItem()
         Me.rectangleArea = New System.Windows.Forms.ToolStripMenuItem()
         Me.windowCapture = New System.Windows.Forms.ToolStripMenuItem()
         Me.fullscreenCapture = New System.Windows.Forms.ToolStripMenuItem()
         Me._tsOCROptionsBtn = New System.Windows.Forms.ToolStripButton()
         Me._tsCopyAndSaveDropDown = New System.Windows.Forms.ToolStripDropDownButton()
         Me._tsCopyTextBtn = New System.Windows.Forms.ToolStripMenuItem()
         Me._tsSaveTextBtn = New System.Windows.Forms.ToolStripMenuItem()
         Me._tsCopyImageBtn = New System.Windows.Forms.ToolStripMenuItem()
         Me._tsSaveImageBtn = New System.Windows.Forms.ToolStripMenuItem()
         Me._splitContainer.Panel2.SuspendLayout()
         Me._splitContainer.SuspendLayout()
         Me.mainPanel.SuspendLayout()
         Me.toolStrip1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _splitContainer
         ' 
         Me._splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer.Location = New System.Drawing.Point(0, 39)
         Me._splitContainer.Name = "_splitContainer"
         Me._splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
         ' 
         ' _splitContainer.Panel2
         ' 
         Me._splitContainer.Panel2.Controls.Add(Me._richTextBox)
         Me._splitContainer.Size = New System.Drawing.Size(827, 377)
         Me._splitContainer.SplitterDistance = 218
         Me._splitContainer.TabIndex = 8
         ' 
         ' _richTextBox
         ' 
         Me._richTextBox.Dock = System.Windows.Forms.DockStyle.Fill
         Me._richTextBox.Location = New System.Drawing.Point(0, 0)
         Me._richTextBox.Name = "_richTextBox"
         Me._richTextBox.Size = New System.Drawing.Size(825, 153)
         Me._richTextBox.TabIndex = 0
         Me._richTextBox.Text = ""
         ' 
         ' mainPanel
         ' 
         Me.mainPanel.Controls.Add(Me._splitContainer)
         Me.mainPanel.Controls.Add(Me.toolStrip1)
         Me.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me.mainPanel.Location = New System.Drawing.Point(0, 0)
         Me.mainPanel.Name = "mainPanel"
         Me.mainPanel.Size = New System.Drawing.Size(827, 416)
         Me.mainPanel.TabIndex = 0
         ' 
         ' toolStrip1
         ' 

         Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._tsCaptureBtn, Me.toolStripSeparator1, Me._tsUseHotkey, Me.toolStripSeparator3, Me._tsOCROptionsBtn, Me.toolStripSeparator2, _
          Me._tsCopyAndSaveDropDown, Me.toolStripSeparator4, Me._tsDrawingChoice})
         Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
         Me.toolStrip1.Name = "toolStrip1"
         Me.toolStrip1.Size = New System.Drawing.Size(827, 39)
         Me.toolStrip1.TabIndex = 0
         Me.toolStrip1.Text = "toolStrip1"
         ' 
         ' toolStripSeparator1
         ' 
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 39)
         ' 
         ' _tsUseHotkey
         ' 
         Me._tsUseHotkey.CheckOnClick = True
         Me._tsUseHotkey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
         Me._tsUseHotkey.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._tsUseHotkey.Name = "_tsUseHotkey"
         Me._tsUseHotkey.Size = New System.Drawing.Size(97, 36)
         Me._tsUseHotkey.Text = "Use &Hotkey(F11)"
         ' 
         ' toolStripSeparator3
         ' 
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 39)
         ' 
         ' toolStripSeparator2
         ' 
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 39)
         ' 
         ' toolStripSeparator4
         ' 
         Me.toolStripSeparator4.Name = "toolStripSeparator4"
         Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 39)
         ' 
         ' _tsDrawingChoice
         ' 
         Me._tsDrawingChoice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
         Me._tsDrawingChoice.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.penToolStripMenuItem, Me.highlighterToolStripMenuItem})
         Me._tsDrawingChoice.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._tsDrawingChoice.Name = "_tsDrawingChoice"
         Me._tsDrawingChoice.Size = New System.Drawing.Size(102, 36)
         Me._tsDrawingChoice.Text = "Draw On Image"
         ' 
         ' penToolStripMenuItem
         ' 
         Me.penToolStripMenuItem.Checked = True
         Me.penToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
         Me.penToolStripMenuItem.Name = "penToolStripMenuItem"
         Me.penToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
         Me.penToolStripMenuItem.Text = "&Pen"
         ' 
         ' highlighterToolStripMenuItem
         ' 
         Me.highlighterToolStripMenuItem.Name = "highlighterToolStripMenuItem"
         Me.highlighterToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
         Me.highlighterToolStripMenuItem.Text = "&Highlighter"
         ' 
         ' _tsCaptureBtn
         ' 
         Me._tsCaptureBtn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.freehandArea, Me.rectangleArea, Me.windowCapture, Me.fullscreenCapture})
         Me._tsCaptureBtn.Image = Global.OcrScreenCaptureDemo.Resources.OCR_SCREEN32
         Me._tsCaptureBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._tsCaptureBtn.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._tsCaptureBtn.Name = "_tsCaptureBtn"
         Me._tsCaptureBtn.Size = New System.Drawing.Size(97, 36)
         Me._tsCaptureBtn.Text = "&Capture"
         ' 
         ' freehandArea
         ' 
         Me.freehandArea.Name = "freehandArea"
         Me.freehandArea.Size = New System.Drawing.Size(164, 22)
         Me.freehandArea.Text = "Freehand Area"
         ' 
         ' rectangleArea
         ' 
         Me.rectangleArea.Name = "rectangleArea"
         Me.rectangleArea.Size = New System.Drawing.Size(164, 22)
         Me.rectangleArea.Text = "Rectangular Area"
         ' 
         ' windowCapture
         ' 
         Me.windowCapture.Name = "windowCapture"
         Me.windowCapture.Size = New System.Drawing.Size(164, 22)
         Me.windowCapture.Text = "Window"
         ' 
         ' fullscreenCapture
         ' 
         Me.fullscreenCapture.Name = "fullscreenCapture"
         Me.fullscreenCapture.Size = New System.Drawing.Size(164, 22)
         Me.fullscreenCapture.Text = "Full-screen"
         ' 
         ' _tsOCROptionsBtn
         ' 
         Me._tsOCROptionsBtn.Image = Global.OcrScreenCaptureDemo.Resources.settings
         Me._tsOCROptionsBtn.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._tsOCROptionsBtn.Name = "_tsOCROptionsBtn"
         Me._tsOCROptionsBtn.Size = New System.Drawing.Size(96, 36)
         Me._tsOCROptionsBtn.Text = "&OCR Options"
         ' 
         ' _tsCopyAndSaveDropDown
         ' 
         Me._tsCopyAndSaveDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
         Me._tsCopyAndSaveDropDown.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._tsCopyTextBtn, Me._tsSaveTextBtn, Me._tsCopyImageBtn, Me._tsSaveImageBtn})
         Me._tsCopyAndSaveDropDown.Image = DirectCast(resources.GetObject("_tsCopyAndSaveDropDown.Image"), System.Drawing.Image)
         Me._tsCopyAndSaveDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._tsCopyAndSaveDropDown.Name = "_tsCopyAndSaveDropDown"
         Me._tsCopyAndSaveDropDown.Size = New System.Drawing.Size(98, 36)
         Me._tsCopyAndSaveDropDown.Text = "Copy and Save"
         ' 
         ' _tsCopyTextBtn
         ' 
         Me._tsCopyTextBtn.Image = Global.OcrScreenCaptureDemo.Resources.copy_text
         Me._tsCopyTextBtn.Name = "_tsCopyTextBtn"
         Me._tsCopyTextBtn.Size = New System.Drawing.Size(152, 22)
         Me._tsCopyTextBtn.Text = "Copy Text"
         ' 
         ' _tsSaveTextBtn
         ' 
         Me._tsSaveTextBtn.Image = Global.OcrScreenCaptureDemo.Resources.save_text
         Me._tsSaveTextBtn.Name = "_tsSaveTextBtn"
         Me._tsSaveTextBtn.Size = New System.Drawing.Size(152, 22)
         Me._tsSaveTextBtn.Text = "Save Text"
         ' 
         ' _tsCopyImageBtn
         ' 
         Me._tsCopyImageBtn.Image = Global.OcrScreenCaptureDemo.Resources.copy_image
         Me._tsCopyImageBtn.Name = "_tsCopyImageBtn"
         Me._tsCopyImageBtn.Size = New System.Drawing.Size(152, 22)
         Me._tsCopyImageBtn.Text = "Copy Image"
         ' 
         ' _tsSaveImageBtn
         ' 
         Me._tsSaveImageBtn.Image = Global.OcrScreenCaptureDemo.Resources.save_image
         Me._tsSaveImageBtn.Name = "_tsSaveImageBtn"
         Me._tsSaveImageBtn.Size = New System.Drawing.Size(152, 22)
         Me._tsSaveImageBtn.Text = "Save Image"
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(827, 416)
         Me.Controls.Add(Me.mainPanel)
         Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.KeyPreview = True
         Me.Name = "MainForm"
         Me._splitContainer.Panel2.ResumeLayout(False)
         Me._splitContainer.ResumeLayout(False)
         Me.mainPanel.ResumeLayout(False)
         Me.mainPanel.PerformLayout()
         Me.toolStrip1.ResumeLayout(False)
         Me.toolStrip1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _splitContainer As System.Windows.Forms.SplitContainer
      Private _richTextBox As System.Windows.Forms.RichTextBox
      Private mainPanel As System.Windows.Forms.Panel
      Private toolStrip1 As System.Windows.Forms.ToolStrip
      Private WithEvents _tsCaptureBtn As System.Windows.Forms.ToolStripSplitButton
      Private WithEvents freehandArea As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents rectangleArea As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents windowCapture As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents fullscreenCapture As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _tsOCROptionsBtn As System.Windows.Forms.ToolStripButton
      Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private _tsDrawingChoice As System.Windows.Forms.ToolStripDropDownButton
      Private WithEvents penToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents highlighterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private _tsUseHotkey As System.Windows.Forms.ToolStripButton
      Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
      Private _tsCopyAndSaveDropDown As System.Windows.Forms.ToolStripDropDownButton
      Private WithEvents _tsCopyTextBtn As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _tsSaveTextBtn As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _tsCopyImageBtn As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _tsSaveImageBtn As System.Windows.Forms.ToolStripMenuItem
   End Class
End Namespace