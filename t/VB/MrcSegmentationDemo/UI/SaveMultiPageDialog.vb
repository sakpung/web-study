' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections.Generic

Imports Leadtools
Imports Leadtools.Mrc

Namespace MrcSegmentationDemo
   ''' <summary>
   ''' Summary description for SaveMultiPageDialog.
   ''' </summary>
   Public Class SaveMultiPageDialog : Inherits System.Windows.Forms.Form
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnSave As System.Windows.Forms.Button
      Private _cbSaveFormat As System.Windows.Forms.ComboBox
      Private _lstFilesName As System.Windows.Forms.ListBox
      Private WithEvents _btnUp As System.Windows.Forms.Button
      Private WithEvents _btnDown As System.Windows.Forms.Button
      Private _lblSaveFormat As System.Windows.Forms.Label
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New(ByVal mainForm As MainForm)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         _mainForm = mainForm
         InitClass()
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
         Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SaveMultiPageDialog))
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnSave = New System.Windows.Forms.Button()
         Me._cbSaveFormat = New System.Windows.Forms.ComboBox()
         Me._lstFilesName = New System.Windows.Forms.ListBox()
         Me._btnUp = New System.Windows.Forms.Button()
         Me._btnDown = New System.Windows.Forms.Button()
         Me._lblSaveFormat = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(96, 144)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.TabIndex = 6
         Me._btnCancel.Text = "&Cancel"
         ' 
         ' _btnSave
         ' 
         Me._btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnSave.Location = New System.Drawing.Point(8, 144)
         Me._btnSave.Name = "_btnSave"
         Me._btnSave.TabIndex = 5
         Me._btnSave.Text = "&Save"
         ' 
         ' _cbSaveFormat
         ' 
         Me._cbSaveFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbSaveFormat.Location = New System.Drawing.Point(84, 109)
         Me._cbSaveFormat.Name = "_cbSaveFormat"
         Me._cbSaveFormat.Size = New System.Drawing.Size(100, 21)
         Me._cbSaveFormat.TabIndex = 4
         ' 
         ' _lstFilesName
         ' 
         Me._lstFilesName.HorizontalScrollbar = True
         Me._lstFilesName.Location = New System.Drawing.Point(8, 8)
         Me._lstFilesName.Name = "_lstFilesName"
         Me._lstFilesName.Size = New System.Drawing.Size(128, 95)
         Me._lstFilesName.TabIndex = 0
         ' 
         ' _btnUp
         ' 
         Me._btnUp.BackgroundImage = (CType(resources.GetObject("_btnUp.BackgroundImage"), System.Drawing.Image))
         Me._btnUp.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnUp.Location = New System.Drawing.Point(144, 24)
         Me._btnUp.Name = "_btnUp"
         Me._btnUp.Size = New System.Drawing.Size(48, 24)
         Me._btnUp.TabIndex = 1
         Me._btnUp.Text = "&Up"
         ' 
         ' _btnDown
         ' 
         Me._btnDown.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnDown.Location = New System.Drawing.Point(144, 64)
         Me._btnDown.Name = "_btnDown"
         Me._btnDown.Size = New System.Drawing.Size(48, 24)
         Me._btnDown.TabIndex = 2
         Me._btnDown.Text = "&Down"
         ' 
         ' _lblSaveFormat
         ' 
         Me._lblSaveFormat.Location = New System.Drawing.Point(8, 112)
         Me._lblSaveFormat.Name = "_lblSaveFormat"
         Me._lblSaveFormat.Size = New System.Drawing.Size(72, 16)
         Me._lblSaveFormat.TabIndex = 3
         Me._lblSaveFormat.Text = "Save &Format"
         ' 
         ' SaveMultiPageDialog
         ' 
         Me.AcceptButton = Me._btnSave
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(202, 175)
         Me.Controls.Add(Me._lblSaveFormat)
         Me.Controls.Add(Me._btnDown)
         Me.Controls.Add(Me._btnUp)
         Me.Controls.Add(Me._lstFilesName)
         Me.Controls.Add(Me._cbSaveFormat)
         Me.Controls.Add(Me._btnSave)
         Me.Controls.Add(Me._btnCancel)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SaveMultiPageDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Save Multi Page"
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private _mainForm As MainForm
      Private _mdiChildren As ViewerForm()
      Private _imageCollection As List(Of RasterImage)

      Private _mrcSegmenterCollection As List(Of MrcSegmenter)

      Public ReadOnly Property SegmenterCollection() As List(Of MrcSegmenter)
         Get
            Return _mrcSegmenterCollection
         End Get
      End Property

      Public ReadOnly Property ImageCollection() As List(Of RasterImage)
         Get
            Return _imageCollection
         End Get
      End Property

      Public ReadOnly Property SaveType() As Integer
         Get
            Return _cbSaveFormat.SelectedIndex
         End Get
      End Property

      Private Sub InitClass()
         _mdiChildren = New ViewerForm(_mainForm.MdiChildren.Length - 1) {}
         Dim index As Integer
         index = 0
         Do While index < _mainForm.MdiChildren.Length
            _mdiChildren(index) = CType(_mainForm.MdiChildren(index), ViewerForm)
            _lstFilesName.Items.Add(_mdiChildren(index).Text)
            index += 1
         Loop

         _cbSaveFormat.Items.Add("Standard Mrc")
         _cbSaveFormat.Items.Add("LEAD Mrc")
         _cbSaveFormat.Items.Add("PDF")
         _cbSaveFormat.SelectedIndex = 0
         _lstFilesName.SelectedIndex = index - 1
         _imageCollection = New List(Of RasterImage)()
         _mrcSegmenterCollection = New List(Of MrcSegmenter)()
      End Sub

      Private Sub _btnUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnUp.Click
         Dim currentIndex As Integer = _lstFilesName.SelectedIndex

         If currentIndex = 0 Then
            Return
         End If

         Dim tempString As String = _lstFilesName.Items(_lstFilesName.SelectedIndex).ToString()

         _lstFilesName.Items.RemoveAt(currentIndex)
         _lstFilesName.Items.Insert(currentIndex - 1, tempString)
         _lstFilesName.SelectedIndex = currentIndex - 1

         RearrangeFormsArray(currentIndex, currentIndex - 1)
      End Sub

      Private Sub _btnDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnDown.Click
         Dim currentIndex As Integer = _lstFilesName.SelectedIndex

         If currentIndex = _lstFilesName.Items.Count - 1 Then
            Return
         End If

         Dim tempString As String = _lstFilesName.Items(_lstFilesName.SelectedIndex).ToString()

         _lstFilesName.Items.RemoveAt(currentIndex)
         _lstFilesName.Items.Insert(currentIndex + 1, tempString)
         _lstFilesName.SelectedIndex = currentIndex + 1
      End Sub

      Private Sub _btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnSave.Click
         Dim index As Integer
         index = 0
         Do While index < _lstFilesName.Items.Count
            _imageCollection.Add(_mdiChildren(index).Image)
            If _mdiChildren(index).ViewerSegmenter Is Nothing Then
               _mrcSegmenterCollection.Add(_mdiChildren(index).GetNewSegmenter())
            Else
               _mrcSegmenterCollection.Add(_mdiChildren(index).ViewerSegmenter)
            End If
            index += 1
         Loop
      End Sub

      Private Sub RearrangeFormsArray(ByVal firstIndex As Integer, ByVal secondIndex As Integer)
         Dim tempViwerForm As ViewerForm = _mdiChildren(secondIndex)

         _mdiChildren(secondIndex) = _mdiChildren(firstIndex)

         _mdiChildren(firstIndex) = tempViwerForm
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
         Close()
      End Sub
   End Class
End Namespace
