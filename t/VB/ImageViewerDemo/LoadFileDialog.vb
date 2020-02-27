' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Windows.Forms
Imports System

Partial Public Class LoadFileDialog
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   ' File name
   Public Property ImageFileName() As String
      Get
         Return m_ImageFileName
      End Get
      Set(value As String)
         m_ImageFileName = value
      End Set
   End Property
   Private m_ImageFileName As String

   ' Options
   Public Property DemoOptions() As DemoOptions
      Get
         Return m_DemoOptions
      End Get
      Set(value As DemoOptions)
         m_DemoOptions = value
      End Set
   End Property
   Private m_DemoOptions As DemoOptions

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         _fileNameTextBox.Text = Me.ImageFileName
         _virtualizerUseCheckBox.Checked = Me.DemoOptions.UseVirtiualizer
         _svgUseCheckBox.Checked = Me.DemoOptions.UseSVG

         UpdateUIState()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub UpdateUIState()
      ' We must have a file name
      _okButton.Enabled = Not String.IsNullOrEmpty(_fileNameTextBox.Text)
   End Sub

   Private Sub _fileNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles _fileNameTextBox.TextChanged
      UpdateUIState()
   End Sub

   Private Sub _fileNameBrowseButton_Click(sender As Object, e As EventArgs) Handles _fileNameBrowseButton.Click
      ' Browse for a file
      Using dlg As OpenFileDialog = New OpenFileDialog()
         dlg.Title = "Select Image File"
         dlg.Filter = "All files|*.*"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _fileNameTextBox.Text = dlg.FileName
         End If
      End Using
   End Sub

   Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
      ' Collect the info
      Me.ImageFileName = _fileNameTextBox.Text.Trim()
      Me.DemoOptions.UseVirtiualizer = _virtualizerUseCheckBox.Checked
      Me.DemoOptions.UseSVG = _svgUseCheckBox.Checked
   End Sub
End Class
