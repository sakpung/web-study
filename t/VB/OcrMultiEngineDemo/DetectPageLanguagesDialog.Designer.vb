Imports Microsoft.VisualBasic
Imports System

Partial Public Class DetectPageLanguagesDialog
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
      Me._gbInstalledLanguages = New System.Windows.Forms.GroupBox()
      Me._lbSuggestedLanguages = New System.Windows.Forms.ListBox()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._lbPageLanguages = New System.Windows.Forms.ListBox()
      Me._btnClose = New System.Windows.Forms.Button()
      Me._btnDetectLanguages = New System.Windows.Forms.Button()
      Me._gbInstalledLanguages.SuspendLayout()
      Me.groupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      '_gbInstalledLanguages
      '
      Me._gbInstalledLanguages.Controls.Add(Me._lbSuggestedLanguages)
      Me._gbInstalledLanguages.Location = New System.Drawing.Point(12, 12)
      Me._gbInstalledLanguages.Name = "_gbInstalledLanguages"
      Me._gbInstalledLanguages.Size = New System.Drawing.Size(217, 319)
      Me._gbInstalledLanguages.TabIndex = 1
      Me._gbInstalledLanguages.TabStop = False
      Me._gbInstalledLanguages.Text = "Languages to choose from:"
      '
      '_lbSuggestedLanguages
      '
      Me._lbSuggestedLanguages.FormattingEnabled = True
      Me._lbSuggestedLanguages.HorizontalScrollbar = True
      Me._lbSuggestedLanguages.Location = New System.Drawing.Point(6, 19)
      Me._lbSuggestedLanguages.Name = "_lbSuggestedLanguages"
      Me._lbSuggestedLanguages.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
      Me._lbSuggestedLanguages.Size = New System.Drawing.Size(204, 290)
      Me._lbSuggestedLanguages.TabIndex = 0
      '
      'groupBox1
      '
      Me.groupBox1.Controls.Add(Me._lbPageLanguages)
      Me.groupBox1.Location = New System.Drawing.Point(364, 12)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(217, 290)
      Me.groupBox1.TabIndex = 2
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Detected page Languages"
      '
      '_lbPageLanguages
      '
      Me._lbPageLanguages.FormattingEnabled = True
      Me._lbPageLanguages.Location = New System.Drawing.Point(6, 19)
      Me._lbPageLanguages.Name = "_lbPageLanguages"
      Me._lbPageLanguages.Size = New System.Drawing.Size(204, 264)
      Me._lbPageLanguages.TabIndex = 0
      '
      '_btnClose
      '
      Me._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnClose.Location = New System.Drawing.Point(507, 308)
      Me._btnClose.Name = "_btnClose"
      Me._btnClose.Size = New System.Drawing.Size(75, 23)
      Me._btnClose.TabIndex = 5
      Me._btnClose.Text = "&Close"
      Me._btnClose.UseVisualStyleBackColor = True
      '
      '_btnDetectLanguages
      '
      Me._btnDetectLanguages.Location = New System.Drawing.Point(236, 153)
      Me._btnDetectLanguages.Name = "_btnDetectLanguages"
      Me._btnDetectLanguages.Size = New System.Drawing.Size(122, 36)
      Me._btnDetectLanguages.TabIndex = 3
      Me._btnDetectLanguages.Text = "&Detect languages"
      Me._btnDetectLanguages.UseVisualStyleBackColor = True
      '
      'DetectPageLanguagesDialog
      '
      Me.AcceptButton = Me._btnClose
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnClose
      Me.ClientSize = New System.Drawing.Size(594, 343)
      Me.Controls.Add(Me._btnClose)
      Me.Controls.Add(Me._btnDetectLanguages)
      Me.Controls.Add(Me.groupBox1)
      Me.Controls.Add(Me._gbInstalledLanguages)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "DetectPageLanguagesDialog"
      Me.Text = "Detect Page Languages"
      Me._gbInstalledLanguages.ResumeLayout(False)
      Me.groupBox1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbInstalledLanguages As System.Windows.Forms.GroupBox
   Private WithEvents _lbSuggestedLanguages As System.Windows.Forms.ListBox
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private _lbPageLanguages As System.Windows.Forms.ListBox
   Private WithEvents _btnDetectLanguages As System.Windows.Forms.Button
   Private _btnClose As System.Windows.Forms.Button
End Class