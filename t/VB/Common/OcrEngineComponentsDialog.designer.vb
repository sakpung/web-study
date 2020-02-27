Imports Microsoft.VisualBasic
Imports System

Partial Public Class OcrEngineComponentsDialog
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
      Me._btnClose = New System.Windows.Forms.Button()
      Me._tabMain = New System.Windows.Forms.TabControl()
      Me._tpPages = New System.Windows.Forms.TabPage()
      Me._gbAdditionalLanguages = New System.Windows.Forms.GroupBox()
      Me._lbAdditionalLanguages = New System.Windows.Forms.ListBox()
      Me._lblNoAdditionalLanguages = New System.Windows.Forms.Label()
      Me._gbInstalledLanguages = New System.Windows.Forms.GroupBox()
      Me._lbInstalledLanguages = New System.Windows.Forms.ListBox()
      Me._tpDictionaries = New System.Windows.Forms.TabPage()
      Me._advantageEngineDictionariesNoteLabel = New System.Windows.Forms.Label()
      Me._gpAdditionalDictionaries = New System.Windows.Forms.GroupBox()
      Me._lbAdditionalDictionaries = New System.Windows.Forms.ListBox()
      Me._gpInstalledDictionaries = New System.Windows.Forms.GroupBox()
      Me._lbInstalledDictionaries = New System.Windows.Forms.ListBox()
      Me._tpEngineFormats = New System.Windows.Forms.TabPage()
      Me._gpAdditionalEngineFormats = New System.Windows.Forms.GroupBox()
      Me._lbAdditionalEngineFormats = New System.Windows.Forms.ListBox()
      Me._gbInstalledEngineFormats = New System.Windows.Forms.GroupBox()
      Me._lbInstalledEngineFormats = New System.Windows.Forms.ListBox()
      Me._lblWebSite = New System.Windows.Forms.Label()
      Me._lbDownload = New System.Windows.Forms.LinkLabel()
      Me._lblMessage = New System.Windows.Forms.Label()
      Me._tabMain.SuspendLayout()
      Me._tpPages.SuspendLayout()
      Me._gbAdditionalLanguages.SuspendLayout()
      Me._gbInstalledLanguages.SuspendLayout()
      Me._tpDictionaries.SuspendLayout()
      Me._gpAdditionalDictionaries.SuspendLayout()
      Me._gpInstalledDictionaries.SuspendLayout()
      Me._tpEngineFormats.SuspendLayout()
      Me._gpAdditionalEngineFormats.SuspendLayout()
      Me._gbInstalledEngineFormats.SuspendLayout()
      Me.SuspendLayout()
      '
      '_btnClose
      '
      Me._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnClose.Location = New System.Drawing.Point(230, 372)
      Me._btnClose.Name = "_btnClose"
      Me._btnClose.Size = New System.Drawing.Size(75, 23)
      Me._btnClose.TabIndex = 4
      Me._btnClose.Text = "Close"
      Me._btnClose.UseVisualStyleBackColor = True
      '
      '_tabMain
      '
      Me._tabMain.Controls.Add(Me._tpPages)
      Me._tabMain.Controls.Add(Me._tpDictionaries)
      Me._tabMain.Controls.Add(Me._tpEngineFormats)
      Me._tabMain.Location = New System.Drawing.Point(11, 44)
      Me._tabMain.Name = "_tabMain"
      Me._tabMain.SelectedIndex = 0
      Me._tabMain.Size = New System.Drawing.Size(522, 260)
      Me._tabMain.TabIndex = 1
      '
      '_tpPages
      '
      Me._tpPages.Controls.Add(Me._gbAdditionalLanguages)
      Me._tpPages.Controls.Add(Me._gbInstalledLanguages)
      Me._tpPages.Location = New System.Drawing.Point(4, 22)
      Me._tpPages.Name = "_tpPages"
      Me._tpPages.Padding = New System.Windows.Forms.Padding(3)
      Me._tpPages.Size = New System.Drawing.Size(514, 234)
      Me._tpPages.TabIndex = 0
      Me._tpPages.Text = "Languages"
      Me._tpPages.UseVisualStyleBackColor = True
      '
      '_gbAdditionalLanguages
      '
      Me._gbAdditionalLanguages.Controls.Add(Me._lbAdditionalLanguages)
      Me._gbAdditionalLanguages.Controls.Add(Me._lblNoAdditionalLanguages)
      Me._gbAdditionalLanguages.Location = New System.Drawing.Point(267, 7)
      Me._gbAdditionalLanguages.Name = "_gbAdditionalLanguages"
      Me._gbAdditionalLanguages.Size = New System.Drawing.Size(240, 218)
      Me._gbAdditionalLanguages.TabIndex = 1
      Me._gbAdditionalLanguages.TabStop = False
      Me._gbAdditionalLanguages.Text = "Additional Languages:"
      '
      '_lbAdditionalLanguages
      '
      Me._lbAdditionalLanguages.FormattingEnabled = True
      Me._lbAdditionalLanguages.Location = New System.Drawing.Point(6, 19)
      Me._lbAdditionalLanguages.Name = "_lbAdditionalLanguages"
      Me._lbAdditionalLanguages.Size = New System.Drawing.Size(228, 186)
      Me._lbAdditionalLanguages.TabIndex = 3
      '
      '_lblNoAdditionalLanguages
      '
      Me._lblNoAdditionalLanguages.Location = New System.Drawing.Point(6, 19)
      Me._lblNoAdditionalLanguages.Name = "_lblNoAdditionalLanguages"
      Me._lblNoAdditionalLanguages.Size = New System.Drawing.Size(228, 186)
      Me._lblNoAdditionalLanguages.TabIndex = 2
      Me._lblNoAdditionalLanguages.Text = "You have all the available languages for this OCR engine currently installed on y" & _
    "our system"
      '
      '_gbInstalledLanguages
      '
      Me._gbInstalledLanguages.Controls.Add(Me._lbInstalledLanguages)
      Me._gbInstalledLanguages.Location = New System.Drawing.Point(7, 7)
      Me._gbInstalledLanguages.Name = "_gbInstalledLanguages"
      Me._gbInstalledLanguages.Size = New System.Drawing.Size(240, 218)
      Me._gbInstalledLanguages.TabIndex = 0
      Me._gbInstalledLanguages.TabStop = False
      Me._gbInstalledLanguages.Text = "Installed Languages:"
      '
      '_lbInstalledLanguages
      '
      Me._lbInstalledLanguages.FormattingEnabled = True
      Me._lbInstalledLanguages.Location = New System.Drawing.Point(6, 19)
      Me._lbInstalledLanguages.Name = "_lbInstalledLanguages"
      Me._lbInstalledLanguages.Size = New System.Drawing.Size(228, 186)
      Me._lbInstalledLanguages.TabIndex = 0
      '
      '_tpDictionaries
      '
      Me._tpDictionaries.Controls.Add(Me._advantageEngineDictionariesNoteLabel)
      Me._tpDictionaries.Controls.Add(Me._gpAdditionalDictionaries)
      Me._tpDictionaries.Controls.Add(Me._gpInstalledDictionaries)
      Me._tpDictionaries.Location = New System.Drawing.Point(4, 22)
      Me._tpDictionaries.Name = "_tpDictionaries"
      Me._tpDictionaries.Size = New System.Drawing.Size(514, 234)
      Me._tpDictionaries.TabIndex = 3
      Me._tpDictionaries.Text = "Dictionaries"
      Me._tpDictionaries.UseVisualStyleBackColor = True
      '
      '_advantageEngineDictionariesNoteLabel
      '
      Me._advantageEngineDictionariesNoteLabel.Location = New System.Drawing.Point(13, 188)
      Me._advantageEngineDictionariesNoteLabel.Name = "_advantageEngineDictionariesNoteLabel"
      Me._advantageEngineDictionariesNoteLabel.Size = New System.Drawing.Size(494, 38)
      Me._advantageEngineDictionariesNoteLabel.TabIndex = 7
      Me._advantageEngineDictionariesNoteLabel.Text = "Select OCR/Spell CheckEngine for the Hunspell spell check engine additional d" & _
    "ictionaries support."
      '
      '_gpAdditionalDictionaries
      '
      Me._gpAdditionalDictionaries.Controls.Add(Me._lbAdditionalDictionaries)
      Me._gpAdditionalDictionaries.Location = New System.Drawing.Point(267, 9)
      Me._gpAdditionalDictionaries.Name = "_gpAdditionalDictionaries"
      Me._gpAdditionalDictionaries.Size = New System.Drawing.Size(240, 176)
      Me._gpAdditionalDictionaries.TabIndex = 6
      Me._gpAdditionalDictionaries.TabStop = False
      Me._gpAdditionalDictionaries.Text = "Additional Dictionaries and Spell Languages:"
      '
      '_lbAdditionalDictionaries
      '
      Me._lbAdditionalDictionaries.FormattingEnabled = True
      Me._lbAdditionalDictionaries.Location = New System.Drawing.Point(6, 19)
      Me._lbAdditionalDictionaries.Name = "_lbAdditionalDictionaries"
      Me._lbAdditionalDictionaries.Size = New System.Drawing.Size(228, 147)
      Me._lbAdditionalDictionaries.TabIndex = 3
      '
      '_gpInstalledDictionaries
      '
      Me._gpInstalledDictionaries.Controls.Add(Me._lbInstalledDictionaries)
      Me._gpInstalledDictionaries.Location = New System.Drawing.Point(7, 9)
      Me._gpInstalledDictionaries.Name = "_gpInstalledDictionaries"
      Me._gpInstalledDictionaries.Size = New System.Drawing.Size(240, 176)
      Me._gpInstalledDictionaries.TabIndex = 5
      Me._gpInstalledDictionaries.TabStop = False
      Me._gpInstalledDictionaries.Text = "Installed Dictionaries and Spell Languages:"
      '
      '_lbInstalledDictionaries
      '
      Me._lbInstalledDictionaries.FormattingEnabled = True
      Me._lbInstalledDictionaries.Location = New System.Drawing.Point(6, 19)
      Me._lbInstalledDictionaries.Name = "_lbInstalledDictionaries"
      Me._lbInstalledDictionaries.Size = New System.Drawing.Size(228, 147)
      Me._lbInstalledDictionaries.TabIndex = 0
      '
      '_tpEngineFormats
      '
      Me._tpEngineFormats.Controls.Add(Me._gpAdditionalEngineFormats)
      Me._tpEngineFormats.Controls.Add(Me._gbInstalledEngineFormats)
      Me._tpEngineFormats.Location = New System.Drawing.Point(4, 22)
      Me._tpEngineFormats.Name = "_tpEngineFormats"
      Me._tpEngineFormats.Size = New System.Drawing.Size(514, 234)
      Me._tpEngineFormats.TabIndex = 4
      Me._tpEngineFormats.Text = "Engine native formats"
      Me._tpEngineFormats.UseVisualStyleBackColor = True
      '
      '_gpAdditionalEngineFormats
      '
      Me._gpAdditionalEngineFormats.Controls.Add(Me._lbAdditionalEngineFormats)
      Me._gpAdditionalEngineFormats.Location = New System.Drawing.Point(267, 8)
      Me._gpAdditionalEngineFormats.Name = "_gpAdditionalEngineFormats"
      Me._gpAdditionalEngineFormats.Size = New System.Drawing.Size(240, 218)
      Me._gpAdditionalEngineFormats.TabIndex = 5
      Me._gpAdditionalEngineFormats.TabStop = False
      Me._gpAdditionalEngineFormats.Text = "Additional Engine Formats:"
      '
      '_lbAdditionalEngineFormats
      '
      Me._lbAdditionalEngineFormats.FormattingEnabled = True
      Me._lbAdditionalEngineFormats.Location = New System.Drawing.Point(6, 19)
      Me._lbAdditionalEngineFormats.Name = "_lbAdditionalEngineFormats"
      Me._lbAdditionalEngineFormats.Size = New System.Drawing.Size(228, 186)
      Me._lbAdditionalEngineFormats.TabIndex = 3
      '
      '_gbInstalledEngineFormats
      '
      Me._gbInstalledEngineFormats.Controls.Add(Me._lbInstalledEngineFormats)
      Me._gbInstalledEngineFormats.Location = New System.Drawing.Point(7, 8)
      Me._gbInstalledEngineFormats.Name = "_gbInstalledEngineFormats"
      Me._gbInstalledEngineFormats.Size = New System.Drawing.Size(240, 218)
      Me._gbInstalledEngineFormats.TabIndex = 4
      Me._gbInstalledEngineFormats.TabStop = False
      Me._gbInstalledEngineFormats.Text = "Installed Engine Formats:"
      '
      '_lbInstalledEngineFormats
      '
      Me._lbInstalledEngineFormats.FormattingEnabled = True
      Me._lbInstalledEngineFormats.Location = New System.Drawing.Point(6, 19)
      Me._lbInstalledEngineFormats.Name = "_lbInstalledEngineFormats"
      Me._lbInstalledEngineFormats.Size = New System.Drawing.Size(228, 186)
      Me._lbInstalledEngineFormats.TabIndex = 0
      '
      '_lblWebSite
      '
      Me._lblWebSite.Location = New System.Drawing.Point(14, 316)
      Me._lblWebSite.Name = "_lblWebSite"
      Me._lblWebSite.Size = New System.Drawing.Size(517, 30)
      Me._lblWebSite.TabIndex = 2
      Me._lblWebSite.Text = "You can download the additional components from the following address:"
      Me._lblWebSite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lbDownload
      '
      Me._lbDownload.AutoSize = True
      Me._lbDownload.Location = New System.Drawing.Point(131, 346)
      Me._lbDownload.Name = "_lbDownload"
      Me._lbDownload.Size = New System.Drawing.Size(282, 13)
      Me._lbDownload.TabIndex = 3
      Me._lbDownload.TabStop = True
      Me._lbDownload.Text = "https://www.leadtools.com/downloads?category=main"
      Me._lbDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lblMessage
      '
      Me._lblMessage.Location = New System.Drawing.Point(12, 9)
      Me._lblMessage.Name = "_lblMessage"
      Me._lblMessage.Size = New System.Drawing.Size(520, 32)
      Me._lblMessage.TabIndex = 0
      Me._lblMessage.Text = "Click on the various pages below to show the installed and additional components " & _
    "avaliable with the current LEADTOOLS OCR engine"
      '
      'OcrEngineComponentsDialog
      '
      Me.AcceptButton = Me._btnClose
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnClose
      Me.ClientSize = New System.Drawing.Size(544, 406)
      Me.Controls.Add(Me._lblMessage)
      Me.Controls.Add(Me._lbDownload)
      Me.Controls.Add(Me._lblWebSite)
      Me.Controls.Add(Me._tabMain)
      Me.Controls.Add(Me._btnClose)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OcrEngineComponentsDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "OCR Engine Components"
      Me._tabMain.ResumeLayout(False)
      Me._tpPages.ResumeLayout(False)
      Me._gbAdditionalLanguages.ResumeLayout(False)
      Me._gbInstalledLanguages.ResumeLayout(False)
      Me._tpDictionaries.ResumeLayout(False)
      Me._gpAdditionalDictionaries.ResumeLayout(False)
      Me._gpInstalledDictionaries.ResumeLayout(False)
      Me._tpEngineFormats.ResumeLayout(False)
      Me._gpAdditionalEngineFormats.ResumeLayout(False)
      Me._gbInstalledEngineFormats.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _btnClose As System.Windows.Forms.Button
   Private _tabMain As System.Windows.Forms.TabControl
   Private _tpPages As System.Windows.Forms.TabPage
   Private _lblWebSite As System.Windows.Forms.Label
   Private WithEvents _lbDownload As System.Windows.Forms.LinkLabel
   Private _gbInstalledLanguages As System.Windows.Forms.GroupBox
   Private _gbAdditionalLanguages As System.Windows.Forms.GroupBox
   Private _lblMessage As System.Windows.Forms.Label
   Private _lblNoAdditionalLanguages As System.Windows.Forms.Label
   Private _lbAdditionalLanguages As System.Windows.Forms.ListBox
   Private _lbInstalledLanguages As System.Windows.Forms.ListBox
   Friend WithEvents _tpDictionaries As System.Windows.Forms.TabPage
   Private WithEvents _advantageEngineDictionariesNoteLabel As System.Windows.Forms.Label
   Private WithEvents _gpAdditionalDictionaries As System.Windows.Forms.GroupBox
   Private WithEvents _lbAdditionalDictionaries As System.Windows.Forms.ListBox
   Private WithEvents _gpInstalledDictionaries As System.Windows.Forms.GroupBox
   Private WithEvents _lbInstalledDictionaries As System.Windows.Forms.ListBox
   Friend WithEvents _tpEngineFormats As System.Windows.Forms.TabPage
   Private WithEvents _gpAdditionalEngineFormats As System.Windows.Forms.GroupBox
   Private WithEvents _lbAdditionalEngineFormats As System.Windows.Forms.ListBox
   Private WithEvents _gbInstalledEngineFormats As System.Windows.Forms.GroupBox
   Private WithEvents _lbInstalledEngineFormats As System.Windows.Forms.ListBox
End Class
