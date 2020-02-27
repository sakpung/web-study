Imports Microsoft.VisualBasic
Imports System

Partial Public Class MainForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
      Me._miFile = New System.Windows.Forms.ToolStripMenuItem()
      Me._miFileExit = New System.Windows.Forms.ToolStripMenuItem()
      Me._miHelp = New System.Windows.Forms.ToolStripMenuItem()
      Me._miHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
      Me._gbSettings = New System.Windows.Forms.GroupBox()
      Me._lblMessage1 = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._lblMessage2 = New System.Windows.Forms.Label()
      Me._ocrEngineSettings = New OcrEngineSettingsControl()
      Me.menuStrip1.SuspendLayout()
      Me._gbSettings.SuspendLayout()
      Me.SuspendLayout()
      '
      'menuStrip1
      '
      Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFile, Me._miHelp})
      Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.menuStrip1.Name = "menuStrip1"
      Me.menuStrip1.Size = New System.Drawing.Size(632, 24)
      Me.menuStrip1.TabIndex = 0
      Me.menuStrip1.Text = "_msMain"
      '
      '_miFile
      '
      Me._miFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFileExit})
      Me._miFile.Name = "_miFile"
      Me._miFile.Size = New System.Drawing.Size(37, 20)
      Me._miFile.Text = "&File"
      '
      '_miFileExit
      '
      Me._miFileExit.Name = "_miFileExit"
      Me._miFileExit.Size = New System.Drawing.Size(92, 22)
      Me._miFileExit.Text = "E&xit"
      '
      '_miHelp
      '
      Me._miHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miHelpAbout})
      Me._miHelp.Name = "_miHelp"
      Me._miHelp.Size = New System.Drawing.Size(44, 20)
      Me._miHelp.Text = "&Help"
      '
      '_miHelpAbout
      '
      Me._miHelpAbout.Name = "_miHelpAbout"
      Me._miHelpAbout.Size = New System.Drawing.Size(116, 22)
      Me._miHelpAbout.Text = "&About..."
      '
      '_gbSettings
      '
      Me._gbSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbSettings.Controls.Add(Me._ocrEngineSettings)
      Me._gbSettings.Location = New System.Drawing.Point(12, 79)
      Me._gbSettings.Name = "_gbSettings"
      Me._gbSettings.Size = New System.Drawing.Size(608, 294)
      Me._gbSettings.TabIndex = 5
      Me._gbSettings.TabStop = False
      Me._gbSettings.Text = "Engine Settings:"
      '
      '_lblMessage1
      '
      Me._lblMessage1.AutoSize = True
      Me._lblMessage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me._lblMessage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lblMessage1.ForeColor = System.Drawing.Color.Blue
      Me._lblMessage1.Location = New System.Drawing.Point(48, 37)
      Me._lblMessage1.Margin = New System.Windows.Forms.Padding(0)
      Me._lblMessage1.Name = "_lblMessage1"
      Me._lblMessage1.Size = New System.Drawing.Size(549, 13)
      Me._lblMessage1.TabIndex = 6
      Me._lblMessage1.Text = "This demo shows how to browse, read and write the values of the specific settings" & _
    " for a LEADTOOLS OCR engine."
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.label1.ForeColor = System.Drawing.Color.Blue
      Me.label1.Location = New System.Drawing.Point(12, 37)
      Me.label1.Margin = New System.Windows.Forms.Padding(0)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(38, 13)
      Me.label1.TabIndex = 7
      Me.label1.Text = "Note:"
      '
      '_lblMessage2
      '
      Me._lblMessage2.AutoSize = True
      Me._lblMessage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me._lblMessage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lblMessage2.ForeColor = System.Drawing.Color.Blue
      Me._lblMessage2.Location = New System.Drawing.Point(48, 54)
      Me._lblMessage2.Margin = New System.Windows.Forms.Padding(0)
      Me._lblMessage2.Name = "_lblMessage2"
      Me._lblMessage2.Size = New System.Drawing.Size(529, 13)
      Me._lblMessage2.TabIndex = 8
      Me._lblMessage2.Text = "To see how these setting effects the OCR engine, run the OcrMainDemo and click th" & _
    "e Engine->Settings menu."
      '
      '_ocrEngineSettings
      '
      Me._ocrEngineSettings.Location = New System.Drawing.Point(39, 19)
      Me._ocrEngineSettings.Name = "_ocrEngineSettings"
      Me._ocrEngineSettings.Size = New System.Drawing.Size(510, 266)
      Me._ocrEngineSettings.TabIndex = 0
      '
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(632, 385)
      Me.Controls.Add(Me._lblMessage2)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me._lblMessage1)
      Me.Controls.Add(Me._gbSettings)
      Me.Controls.Add(Me.menuStrip1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MainMenuStrip = Me.menuStrip1
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MainForm"
      Me.menuStrip1.ResumeLayout(False)
      Me.menuStrip1.PerformLayout()
      Me._gbSettings.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private menuStrip1 As System.Windows.Forms.MenuStrip
   Private _miFile As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFileExit As System.Windows.Forms.ToolStripMenuItem
   Private _miHelp As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miHelpAbout As System.Windows.Forms.ToolStripMenuItem
   Private _gbSettings As System.Windows.Forms.GroupBox
   Private _lblMessage1 As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private _lblMessage2 As System.Windows.Forms.Label
   Friend WithEvents _ocrEngineSettings As OcrEngineSettingsControl
End Class