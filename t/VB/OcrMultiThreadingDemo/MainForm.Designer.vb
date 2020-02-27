Namespace OcrMultiThreadingDemo
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._msMain = New System.Windows.Forms.MenuStrip()
         Me._miFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._miFileExit = New System.Windows.Forms.ToolStripMenuItem()
         Me._miHelp = New System.Windows.Forms.ToolStripMenuItem()
         Me._miHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
         Me._gatherInformationControl = New OcrMultiThreadingDemo.GatherInformationControl()
         Me._conversionControl = New OcrMultiThreadingDemo.ConversionControl()
         Me._msMain.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _msMain
         ' 
         Me._msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFile, Me._miHelp})
         Me._msMain.Location = New System.Drawing.Point(0, 0)
         Me._msMain.Name = "_msMain"
         Me._msMain.Size = New System.Drawing.Size(934, 24)
         Me._msMain.TabIndex = 0
         Me._msMain.Text = "_msMain"
         ' 
         ' _miFile
         ' 
         Me._miFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFileExit})
         Me._miFile.Name = "_miFile"
         Me._miFile.Size = New System.Drawing.Size(37, 20)
         Me._miFile.Text = "&File"
         ' 
         ' _miFileExit
         ' 
         Me._miFileExit.Name = "_miFileExit"
         Me._miFileExit.Size = New System.Drawing.Size(92, 22)
         Me._miFileExit.Text = "E&xit"
         ' 
         ' _miHelp
         ' 
         Me._miHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miHelpAbout})
         Me._miHelp.Name = "_miHelp"
         Me._miHelp.Size = New System.Drawing.Size(44, 20)
         Me._miHelp.Text = "&Help"
         ' 
         ' _miHelpAbout
         ' 
         Me._miHelpAbout.Name = "_miHelpAbout"
         Me._miHelpAbout.Size = New System.Drawing.Size(116, 22)
         Me._miHelpAbout.Text = "&About..."
         ' 
         ' _gatherInformationControl
         ' 
         Me._gatherInformationControl.Dock = System.Windows.Forms.DockStyle.Fill
         Me._gatherInformationControl.Location = New System.Drawing.Point(0, 24)
         Me._gatherInformationControl.Name = "_gatherInformationControl"
         Me._gatherInformationControl.Size = New System.Drawing.Size(934, 424)
         Me._gatherInformationControl.TabIndex = 1
         ' 
         ' _conversionControl
         ' 
         Me._conversionControl.Dock = System.Windows.Forms.DockStyle.Fill
         Me._conversionControl.Location = New System.Drawing.Point(0, 24)
         Me._conversionControl.Name = "_conversionControl"
         Me._conversionControl.Size = New System.Drawing.Size(934, 424)
         Me._conversionControl.TabIndex = 2
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(934, 448)
         Me.Controls.Add(Me._conversionControl)
         Me.Controls.Add(Me._gatherInformationControl)
         Me.Controls.Add(Me._msMain)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MainMenuStrip = Me._msMain
         Me.Name = "MainForm"
         Me.Text = "MainForm"
         Me._msMain.ResumeLayout(False)
         Me._msMain.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _msMain As System.Windows.Forms.MenuStrip
      Private _miFile As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miFileExit As System.Windows.Forms.ToolStripMenuItem
      Private _miHelp As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miHelpAbout As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _gatherInformationControl As GatherInformationControl
      Private WithEvents _conversionControl As ConversionControl
   End Class
End Namespace
