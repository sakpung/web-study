' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the ResizeCommand

   Partial Public Class ResizeCommandDialog : Inherits Form
      Private _ResizeCommand As ResizeCommand
      Private RasImage As RasterImage

      Public ImageWidth As Integer
      Public ImageHeight As Integer

      Public Sub New()
         InitializeComponent()
         _ResizeCommand = New ResizeCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Sub New(ByVal TempImage As RasterImage)
         InitializeComponent()
         _ResizeCommand = New ResizeCommand()
         RasImage = TempImage
         InitializeUI()
      End Sub

      Public Property ResizeCommand() As ResizeCommand
         Get
            'Update command values
            UpdateCommand()
            Return _ResizeCommand
         End Get
         Set(ByVal value As ResizeCommand)
            _ResizeCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()

         Dim names As String()
         names = System.Enum.GetNames(GetType(RasterSizeFlags))
         For Each name As String In names
            _cmbResizeType.Items.Add(name)
         Next name
         _cmbResizeType.SelectedIndex = 0

         ImageWidth = RasImage.Width
         ImageHeight = RasImage.Height

         _numWidth.Value = ImageWidth
         _numHeight.Value = ImageHeight
      End Sub

      Private Sub UpdateCommand()
         ImageWidth = Convert.ToInt32(_numWidth.Value)
         ImageHeight = Convert.ToInt32(_numHeight.Value)

         _ResizeCommand.Flags = TranslateType()

      End Sub


      Public Function TranslateType() As RasterSizeFlags
         Select Case _cmbResizeType.SelectedIndex
            Case 0
               Return RasterSizeFlags.None
            Case 1
               Return RasterSizeFlags.FavorBlack Or RasterSizeFlags.Resample
            Case 2
               Return RasterSizeFlags.Resample
            Case 3
               Return RasterSizeFlags.Bicubic
            Case Else
               Return RasterSizeFlags.None
         End Select
      End Function

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         InitializeUI()
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Private Sub _cmbResizeType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbResizeType.SelectedIndexChanged
         If _cmbResizeType.SelectedItem.ToString() = "FavorBlack" Then
            MessageBox.Show("FavorBlack Flag: Preserve black objects when making the image smaller. This option affects only 1-bit, black-and-white images, where it prevents the disappearance of thin lines. You can use a bitwise OR ( | ) to combine this flag with another one. For example, Resample | FavorBlack causes color images to be resampled, but applies the favor-black option to 1-bit, black-and-white images.If you apply this flag to an image that has more than 1 bit per pixel, then the behavior is undefined.")
         End If
      End Sub
   End Class
End Namespace
