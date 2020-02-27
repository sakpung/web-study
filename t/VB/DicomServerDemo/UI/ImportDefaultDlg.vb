' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections.Specialized

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for ImportDefaultDlg.
   ''' </summary>
   Public Class ImportDefaultDlg : Inherits System.Windows.Forms.Form
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private listBoxLEAD As System.Windows.Forms.ListBox
      Private label3 As System.Windows.Forms.Label
      Private textBoxDir As System.Windows.Forms.TextBox
      Private WithEvents buttonDir As System.Windows.Forms.Button
      Private button1 As System.Windows.Forms.Button
      Private button2 As System.Windows.Forms.Button
      Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public AdditionalDir As String = ""

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportDefaultDlg))
Me.label1 = New System.Windows.Forms.Label
Me.label2 = New System.Windows.Forms.Label
Me.listBoxLEAD = New System.Windows.Forms.ListBox
Me.label3 = New System.Windows.Forms.Label
Me.textBoxDir = New System.Windows.Forms.TextBox
Me.buttonDir = New System.Windows.Forms.Button
Me.button1 = New System.Windows.Forms.Button
Me.button2 = New System.Windows.Forms.Button
Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
Me.SuspendLayout()
'
'label1
'
Me.label1.Location = New System.Drawing.Point(8, 0)
Me.label1.Name = "label1"
Me.label1.Size = New System.Drawing.Size(507, 64)
Me.label1.TabIndex = 0
Me.label1.Text = resources.GetString("label1.Text")
'
'label2
'
Me.label2.Location = New System.Drawing.Point(8, 80)
Me.label2.Name = "label2"
Me.label2.Size = New System.Drawing.Size(184, 16)
Me.label2.TabIndex = 1
Me.label2.Text = "LEAD Installed Images:"
'
'listBoxLEAD
'
Me.listBoxLEAD.Location = New System.Drawing.Point(8, 96)
Me.listBoxLEAD.Name = "listBoxLEAD"
Me.listBoxLEAD.Size = New System.Drawing.Size(507, 95)
Me.listBoxLEAD.TabIndex = 2
'
'label3
'
Me.label3.Location = New System.Drawing.Point(8, 200)
Me.label3.Name = "label3"
Me.label3.Size = New System.Drawing.Size(344, 16)
Me.label3.TabIndex = 3
Me.label3.Text = "Additional directory of images to import:"
'
'textBoxDir
'
Me.textBoxDir.Location = New System.Drawing.Point(8, 216)
Me.textBoxDir.Name = "textBoxDir"
Me.textBoxDir.Size = New System.Drawing.Size(468, 20)
Me.textBoxDir.TabIndex = 4
'
'buttonDir
'
Me.buttonDir.Location = New System.Drawing.Point(482, 216)
Me.buttonDir.Name = "buttonDir"
Me.buttonDir.Size = New System.Drawing.Size(24, 20)
Me.buttonDir.TabIndex = 5
Me.buttonDir.Text = "..."
'
'button1
'
Me.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.button1.Location = New System.Drawing.Point(424, 256)
Me.button1.Name = "button1"
Me.button1.Size = New System.Drawing.Size(75, 23)
Me.button1.TabIndex = 6
Me.button1.Text = "Cancel"
'
'button2
'
Me.button2.DialogResult = System.Windows.Forms.DialogResult.OK
Me.button2.Location = New System.Drawing.Point(344, 256)
Me.button2.Name = "button2"
Me.button2.Size = New System.Drawing.Size(75, 23)
Me.button2.TabIndex = 7
Me.button2.Text = "OK"
'
'ImportDefaultDlg
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(532, 285)
Me.Controls.Add(Me.button2)
Me.Controls.Add(Me.button1)
Me.Controls.Add(Me.buttonDir)
Me.Controls.Add(Me.textBoxDir)
Me.Controls.Add(Me.label3)
Me.Controls.Add(Me.listBoxLEAD)
Me.Controls.Add(Me.label2)
Me.Controls.Add(Me.label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "ImportDefaultDlg"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Import Files"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
#End Region

      Public Sub FillFileList(ByVal files As StringCollection)
         For Each file As String In files
            listBoxLEAD.Items.Add(file)
         Next file
      End Sub

      Private Sub buttonDir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonDir.Click
         If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            textBoxDir.Text = folderBrowserDialog1.SelectedPath
         End If
      End Sub

      Private Sub ImportDefaultDlg_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
         AdditionalDir = textBoxDir.Text
      End Sub
   End Class
End Namespace
