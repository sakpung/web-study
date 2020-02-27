' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs

Namespace FeedLoadDemo
   ''' <summary>
   ''' Summary description for MainForm.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private _mainMenu As System.Windows.Forms.MainMenu
      Private _menuItemFile As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemFileExit As System.Windows.Forms.MenuItem
      Private _menuItemHelp As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemHelpAbout As System.Windows.Forms.MenuItem
      Private _pnlControls As System.Windows.Forms.Panel
      Private _lblUrl As System.Windows.Forms.Label
      Private WithEvents _tbUrl As System.Windows.Forms.TextBox
      Private WithEvents _cbSizeMode As System.Windows.Forms.ComboBox
      Private WithEvents _btnZoomIn As System.Windows.Forms.Button
      Private WithEvents _btnZoomOut As System.Windows.Forms.Button
      Private WithEvents _btnZoomNone As System.Windows.Forms.Button
      Private WithEvents _btnUrl As System.Windows.Forms.Button
      Private _lblFileName As System.Windows.Forms.Label
      Private WithEvents _tbFileName As System.Windows.Forms.TextBox
      Private WithEvents _btnFileName As System.Windows.Forms.Button
      Private WithEvents _btnBrowse As System.Windows.Forms.Button
      Private _lblMessage As System.Windows.Forms.Label
      Private components As IContainer

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         InitClass()
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            CleanUp()

            If Not components Is Nothing Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"
      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._mainMenu = New System.Windows.Forms.MainMenu(Me.components)
         Me._menuItemFile = New System.Windows.Forms.MenuItem()
         Me._menuItemFileExit = New System.Windows.Forms.MenuItem()
         Me._menuItemHelp = New System.Windows.Forms.MenuItem()
         Me._menuItemHelpAbout = New System.Windows.Forms.MenuItem()
         Me._pnlControls = New System.Windows.Forms.Panel()
         Me._lblMessage = New System.Windows.Forms.Label()
         Me._btnBrowse = New System.Windows.Forms.Button()
         Me._btnFileName = New System.Windows.Forms.Button()
         Me._tbFileName = New System.Windows.Forms.TextBox()
         Me._lblFileName = New System.Windows.Forms.Label()
         Me._btnZoomNone = New System.Windows.Forms.Button()
         Me._btnZoomOut = New System.Windows.Forms.Button()
         Me._btnZoomIn = New System.Windows.Forms.Button()
         Me._cbSizeMode = New System.Windows.Forms.ComboBox()
         Me._btnUrl = New System.Windows.Forms.Button()
         Me._tbUrl = New System.Windows.Forms.TextBox()
         Me._lblUrl = New System.Windows.Forms.Label()
         Me._pnlControls.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _mainMenu
         ' 
         Me._mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFile, Me._menuItemHelp})
         ' 
         ' _menuItemFile
         ' 
         Me._menuItemFile.Index = 0
         Me._menuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFileExit})
         Me._menuItemFile.Text = "&File"
         ' 
         ' _menuItemFileExit
         ' 
         Me._menuItemFileExit.Index = 0
         Me._menuItemFileExit.Text = "E&xit"
         ' 
         ' _menuItemHelp
         ' 
         Me._menuItemHelp.Index = 1
         Me._menuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemHelpAbout})
         Me._menuItemHelp.Text = "&Help"
         ' 
         ' _menuItemHelpAbout
         ' 
         Me._menuItemHelpAbout.Index = 0
         Me._menuItemHelpAbout.Text = "&About..."
         ' 
         ' _pnlControls
         ' 
         Me._pnlControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._pnlControls.Controls.Add(Me._lblMessage)
         Me._pnlControls.Controls.Add(Me._btnBrowse)
         Me._pnlControls.Controls.Add(Me._btnFileName)
         Me._pnlControls.Controls.Add(Me._tbFileName)
         Me._pnlControls.Controls.Add(Me._lblFileName)
         Me._pnlControls.Controls.Add(Me._btnZoomNone)
         Me._pnlControls.Controls.Add(Me._btnZoomOut)
         Me._pnlControls.Controls.Add(Me._btnZoomIn)
         Me._pnlControls.Controls.Add(Me._cbSizeMode)
         Me._pnlControls.Controls.Add(Me._btnUrl)
         Me._pnlControls.Controls.Add(Me._tbUrl)
         Me._pnlControls.Controls.Add(Me._lblUrl)
         Me._pnlControls.Dock = System.Windows.Forms.DockStyle.Top
         Me._pnlControls.Location = New System.Drawing.Point(0, 0)
         Me._pnlControls.Name = "_pnlControls"
         Me._pnlControls.Size = New System.Drawing.Size(616, 144)
         Me._pnlControls.TabIndex = 0
         ' 
         ' _lblMessage
         ' 
         Me._lblMessage.Location = New System.Drawing.Point(8, 8)
         Me._lblMessage.Name = "_lblMessage"
         Me._lblMessage.Size = New System.Drawing.Size(584, 32)
         Me._lblMessage.TabIndex = 11
         Me._lblMessage.Text = "Enter a URL to an image file (for example http://www.website.com/image.jpg) or th" & "e name of a valid file in your machine then click Go to load the file using Feed" & " Load mechanism."
         Me._lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _btnBrowse
         ' 
         Me._btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnBrowse.Location = New System.Drawing.Point(368, 80)
         Me._btnBrowse.Name = "_btnBrowse"
         Me._btnBrowse.Size = New System.Drawing.Size(35, 23)
         Me._btnBrowse.TabIndex = 5
         Me._btnBrowse.Text = "..."
         ' 
         ' _btnFileName
         ' 
         Me._btnFileName.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnFileName.Location = New System.Drawing.Point(408, 80)
         Me._btnFileName.Name = "_btnFileName"
         Me._btnFileName.Size = New System.Drawing.Size(75, 23)
         Me._btnFileName.TabIndex = 6
         Me._btnFileName.Text = "Go"
         ' 
         ' _tbFileName
         ' 
         Me._tbFileName.Location = New System.Drawing.Point(80, 80)
         Me._tbFileName.Name = "_tbFileName"
         Me._tbFileName.Size = New System.Drawing.Size(288, 20)
         Me._tbFileName.TabIndex = 4
         ' 
         ' _lblFileName
         ' 
         Me._lblFileName.Location = New System.Drawing.Point(8, 80)
         Me._lblFileName.Name = "_lblFileName"
         Me._lblFileName.Size = New System.Drawing.Size(64, 23)
         Me._lblFileName.TabIndex = 3
         Me._lblFileName.Text = "File Name:"
         Me._lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _btnZoomNone
         ' 
         Me._btnZoomNone.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnZoomNone.Location = New System.Drawing.Point(232, 112)
         Me._btnZoomNone.Name = "_btnZoomNone"
         Me._btnZoomNone.Size = New System.Drawing.Size(32, 23)
         Me._btnZoomNone.TabIndex = 10
         Me._btnZoomNone.Text = "1:1"
         ' 
         ' _btnZoomOut
         ' 
         Me._btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnZoomOut.Location = New System.Drawing.Point(200, 112)
         Me._btnZoomOut.Name = "_btnZoomOut"
         Me._btnZoomOut.Size = New System.Drawing.Size(32, 23)
         Me._btnZoomOut.TabIndex = 9
         Me._btnZoomOut.Text = "-"
         ' 
         ' _btnZoomIn
         ' 
         Me._btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnZoomIn.Location = New System.Drawing.Point(168, 112)
         Me._btnZoomIn.Name = "_btnZoomIn"
         Me._btnZoomIn.Size = New System.Drawing.Size(32, 23)
         Me._btnZoomIn.TabIndex = 8
         Me._btnZoomIn.Text = "+"
         ' 
         ' _cbSizeMode
         ' 
         Me._cbSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbSizeMode.Location = New System.Drawing.Point(8, 112)
         Me._cbSizeMode.Name = "_cbSizeMode"
         Me._cbSizeMode.Size = New System.Drawing.Size(152, 21)
         Me._cbSizeMode.TabIndex = 7
         ' 
         ' _btnUrl
         ' 
         Me._btnUrl.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnUrl.Location = New System.Drawing.Point(408, 48)
         Me._btnUrl.Name = "_btnUrl"
         Me._btnUrl.Size = New System.Drawing.Size(75, 23)
         Me._btnUrl.TabIndex = 2
         Me._btnUrl.Text = "Go"
         ' 
         ' _tbUrl
         ' 
         Me._tbUrl.Location = New System.Drawing.Point(80, 48)
         Me._tbUrl.Name = "_tbUrl"
         Me._tbUrl.Size = New System.Drawing.Size(328, 20)
         Me._tbUrl.TabIndex = 1
         ' 
         ' _lblUrl
         ' 
         Me._lblUrl.Location = New System.Drawing.Point(8, 48)
         Me._lblUrl.Name = "_lblUrl"
         Me._lblUrl.Size = New System.Drawing.Size(32, 23)
         Me._lblUrl.TabIndex = 0
         Me._lblUrl.Text = "Url:"
         Me._lblUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' MainForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(616, 459)
         Me.Controls.Add(Me._pnlControls)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.KeyPreview = True
         Me.Menu = Me._mainMenu
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "MainForm"
         Me._pnlControls.ResumeLayout(False)
         Me._pnlControls.PerformLayout()
         Me.ResumeLayout(False)

      End Sub
#End Region

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()
         
         If Not Support.SetLicense() Then
            Return
         End If

         Application.EnableVisualStyles()
         Application.DoEvents()

         Application.Run(New MainForm())
      End Sub

      Private _viewer As ImageViewer
      Private _pictureBox As RasterPictureBox
      Private _isGif As Boolean
      Private _codecs As RasterCodecs

      Private Sub InitClass()
         Messager.Caption = "LEADTOOLS VB Feed Load Demo"
         Text = Messager.Caption

         _viewer = New ImageViewer()
         _viewer.Dock = DockStyle.Fill
         _viewer.BackColor = Color.DarkCyan
         _viewer.InteractiveModes.Add(New ImageViewerAutoPanInteractiveMode())
         Controls.Add(_viewer)
         _viewer.BringToFront()
         _pictureBox = New RasterPictureBox()
         _pictureBox.AnimationMode = RasterPictureBoxAnimationMode.Infinite
         _pictureBox.SizeMode = RasterPictureBoxSizeMode.Fit
         _pictureBox.Dock = DockStyle.Fill
         _pictureBox.BackColor = Color.DarkCyan
         Controls.Add(_pictureBox)
         _pictureBox.Visible = False
         _isGif = False
         _viewer.Zoom(ControlSizeMode.ActualSize, 1, _viewer.DefaultZoomOrigin)

         Dim a As Array = System.Enum.GetValues(GetType(ControlSizeMode))
         For Each i As ControlSizeMode In a
            If Not i = ControlSizeMode.None Then
               _cbSizeMode.Items.Add(i)
            End If
            If i = _viewer.SizeMode Then
               _cbSizeMode.SelectedItem = i
            End If
         Next i

         'temp image so the nag window will be displayed in this main thread
         Dim temp As RasterImage = New RasterImage(RasterMemoryFlags.Conventional, 1, 1, 1, RasterByteOrder.Bgr, RasterViewPerspective.TopLeft, Nothing, IntPtr.Zero, 0)
         temp.Dispose()

         _codecs = New RasterCodecs()

         _tbFileName.Text = DemosGlobal.ImagesFolder & "\image1.cmp"
         _tbUrl.Text = "https://www.leadtools.com/images/page_graphics/leadlogo.png"
         SetTheImage(_tbFileName.Text, False)
         UpdateButtons()
      End Sub

      Private Sub CleanUp()
      End Sub

      Private Sub _cbSizeMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbSizeMode.SelectedIndexChanged
         _viewer.Zoom(CType(_cbSizeMode.SelectedItem, ControlSizeMode), 1.0, New LeadPoint(0, 0))
      End Sub

      Private Sub _btnZoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnZoomNone.Click, _btnZoomOut.Click, _btnZoomIn.Click
         Const minimumScaleFactor As Double = 0.05F
         Const maximumScaleFactor As Double = 11.0F
         Const factor As Double = 1.2F

         Dim scaleFactor As Double = _viewer.ScaleFactor

         If sender Is _btnZoomIn Then
            scaleFactor *= factor
         ElseIf sender Is _btnZoomOut Then
            scaleFactor /= factor
         Else
            scaleFactor = 1
         End If

         scaleFactor = Math.Max(minimumScaleFactor, Math.Min(maximumScaleFactor, scaleFactor))
         If (sender Is _btnZoomIn) OrElse (sender Is _btnZoomOut) Then
            _viewer.Zoom(ControlSizeMode.None, scaleFactor, New LeadPoint(0, 0))
         Else
            _viewer.Zoom(CType(_cbSizeMode.SelectedItem, ControlSizeMode), scaleFactor, New LeadPoint(0, 0))
         End If
      End Sub

      Private Sub _menuItemFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileExit.Click
         Close()
      End Sub

      Private Sub _menuItemHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemHelpAbout.Click
         Using aboutDialog As New AboutDialog("Feed Load", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub


      Private Sub _tbUrl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _tbUrl.TextChanged
         UpdateButtons()
      End Sub

      Private Sub _tbFileName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _tbFileName.TextChanged
         UpdateButtons()
      End Sub

      Private Sub UpdateButtons()
         _btnUrl.Enabled = _tbUrl.Text.Trim() <> String.Empty
         _btnFileName.Enabled = _tbFileName.Text.Trim() <> String.Empty
         _cbSizeMode.Enabled = Not _isGif
         _btnZoomIn.Enabled = Not _isGif
         _btnZoomOut.Enabled = Not _isGif
         _btnZoomNone.Enabled = Not _isGif
      End Sub

      Private Sub _btnBrowse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnBrowse.Click
         Dim dlg As OpenFileDialog = New OpenFileDialog()
         dlg.Filter = "All Files|*.*"
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _tbFileName.Text = dlg.FileName
         End If
      End Sub

      Private Sub SetTheImage(ByVal str As String, ByVal isUrl As Boolean)
         _isGif = str.ToLower().EndsWith("gif")

         Dim dlg As FeedLoadDialog
         If isUrl Then
            dlg = New FeedLoadDialog(_codecs, str, Nothing)
         Else
            dlg = New FeedLoadDialog(_codecs, Nothing, str)
         End If
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            If _isGif = True Then
               _pictureBox.Image = dlg.Image
               Dim x As Integer = 1
               Do While x <= _pictureBox.Image.PageCount
                  _pictureBox.Image.Page = x
                  If _pictureBox.Image.AnimationDelay = 0 Then
                     _pictureBox.Image.AnimationDelay = 100
                  End If
                  x += 1
               Loop
               dlg.Image.Page = 1
               _pictureBox.BringToFront()
               _pictureBox.Visible = True
               _pictureBox.PlayAnimation()
            Else
               _viewer.Image = dlg.Image
               _viewer.BringToFront()
            End If
            UpdateButtons()
         End If
      End Sub

      Private Sub _btnUrl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnUrl.Click
         SetTheImage(_tbUrl.Text, True)
      End Sub

      Private Sub _btnFileName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnFileName.Click
         SetTheImage(_tbFileName.Text, False)
      End Sub

      Private Sub MainForm_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
         If e.KeyCode = Keys.Escape Then
            _pictureBox.PauseAnimation()
         End If
      End Sub

   End Class
End Namespace
