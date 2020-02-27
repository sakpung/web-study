' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Controls

Namespace ScreenCaptureDemo
   Partial Public Class CapturedImageForm : Inherits Form
      Public Sub New()
         InitializeComponent()

         InitClass()
      End Sub

      ' a raster image viewer that holds the image
      Private _viewer As ImageViewer

      ' boolean variable to check if the image is saved or not
      Private _isImageNotSaved As Boolean

      ' instance of MainForm
      Private _mainForm As MainForm

      Private Sub InitClass()
         ' Initialize the _viewer object
         _viewer = New ImageViewer()
         _viewer.Dock = DockStyle.Fill
         _viewer.BackColor = Color.DarkGray
         Controls.Add(_viewer)
         _viewer.BringToFront()
      End Sub

      Public ReadOnly Property Viewer() As ImageViewer
         Get
            Return _viewer
         End Get
      End Property

      Public Property IsImageNotSaved() As Boolean
         Get
            Return _isImageNotSaved
         End Get
         Set(value As Boolean)
            _isImageNotSaved = Value
         End Set
      End Property


      Private Sub CapturedImageForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         ' make sure the viewer interactive mode is set to none
         _viewer.InteractiveModes.Clear()

         ' the image is not saved as a start
         _isImageNotSaved = True

         ' get instance of main form
         _mainForm = TryCast(ParentForm, MainForm)
      End Sub

      Private Sub CapturedImageForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         _mainForm.CountOfOpenedImages -= 1

         If _mainForm.CountOfOpenedImages >= 1 Then
            _mainForm.EnableSaveAs = True
            _mainForm.EnableCut = True
            _mainForm.EnableCopy = True
         Else
            _mainForm.EnableSaveAs = False
            _mainForm.EnableCut = False
            _mainForm.EnableCopy = False
         End If
      End Sub
   End Class
End Namespace
