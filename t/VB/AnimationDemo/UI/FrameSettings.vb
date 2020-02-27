' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools
Imports System

#If Not LEADTOOLS_V17_OR_LATER Then
Imports LeadPoint = System.Drawing.Point
Imports LeadSize = System.Drawing.Size
Imports LeadRect = System.Drawing.Rectangle
#End If

Namespace AnimationDemo
   Partial Public Class FrameSettings
      Inherits Form
      Private _image As RasterImage
      Public Property Image() As RasterImage
         Get
            Return _image
         End Get
         Set(value As RasterImage)
            _image = value
         End Set
      End Property

      Private offset As Point = Point.Empty

      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub New(image As RasterImage)
         InitializeComponent()

         _image = image
         _tbDelay.Text = image.AnimationDelay.ToString()
         _chkWaitForUserInput.Checked = image.AnimationWaitUserInput
         _tbTop.Text = image.AnimationOffset.Y.ToString()
         _tbLeft.Text = image.AnimationOffset.X.ToString()

         _cmbDisposalMethod.Items.Clear()
         _cmbDisposalMethod.Items.Add("None")
         _cmbDisposalMethod.Items.Add("Leave")
         _cmbDisposalMethod.Items.Add("Restore Background")
         _cmbDisposalMethod.Items.Add("Restore Previous")

         Select Case image.AnimationDisposalMethod
            Case RasterImageAnimationDisposalMethod.Leave
               If True Then
                  _cmbDisposalMethod.SelectedIndex = 1
                  Exit Select
               End If

            Case RasterImageAnimationDisposalMethod.RestoreBackground
               If True Then
                  _cmbDisposalMethod.SelectedIndex = 2
                  Exit Select
               End If

            Case RasterImageAnimationDisposalMethod.RestorePrevious
               If True Then
                  _cmbDisposalMethod.SelectedIndex = 3
                  Exit Select
               End If
            Case Else

               If True Then
                  _cmbDisposalMethod.SelectedIndex = 0
                  Exit Select
               End If
         End Select
      End Sub

      Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
         If _chkApplyToAll.Checked Then
            For i As Integer = 0 To _image.PageCount - 1
               _image.Page = i + 1

               _image.AnimationDelay = Convert.ToInt32(_tbDelay.Text)
               _image.AnimationWaitUserInput = _chkWaitForUserInput.Checked
               _image.AnimationOffset = New LeadPoint(Convert.ToInt32(_tbLeft.Text), Convert.ToInt32(_tbTop.Text))

               _image.Transparent = True
               _image.TransparentColor = Leadtools.Demos.Converters.FromGdiPlusColor(_pnlColor.BackColor)

               Dim value As String = _cmbDisposalMethod.SelectedItem.ToString()

               Dim index As Integer = value.IndexOf(" ")
               If index >= 0 Then
                  value = value.Remove(index, 1)
               End If
               _image.AnimationDisposalMethod = CType([Enum].Parse(GetType(RasterImageAnimationDisposalMethod), value), RasterImageAnimationDisposalMethod)
            Next
         Else
            _image.AnimationDelay = Convert.ToInt32(_tbDelay.Text)
            _image.AnimationWaitUserInput = _chkWaitForUserInput.Checked
            _image.AnimationOffset = New LeadPoint(Convert.ToInt32(_tbLeft.Text), Convert.ToInt32(_tbTop.Text))

            _image.Transparent = _chkTransparentColor.Checked
            _image.TransparentColor = Leadtools.Demos.Converters.FromGdiPlusColor(_pnlColor.BackColor)
         End If

         _image.Page = 1
      End Sub

      Private Sub _btnChooseColor_Click(sender As Object, e As EventArgs) Handles _btnChooseColor.Click
         If _image.BitsPerPixel <= 8 Then
            Dim colorDialog As ChooseColorDialog = New AnimationDemo.ChooseColorDialog(_image, False)

            If colorDialog.ShowDialog() = DialogResult.OK Then
               _pnlColor.BackColor = colorDialog.SelectedColor
            End If
         Else
            Dim colorDialog As New System.Windows.Forms.ColorDialog()

            If colorDialog.ShowDialog() = DialogResult.OK Then
               _pnlColor.BackColor = colorDialog.Color
            End If
         End If
      End Sub

      Private Sub _tbDelay_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _tbDelay.KeyPress
         If Not e.Handled Then
            If Not [Char].IsControl(e.KeyChar) AndAlso Not [Char].IsDigit(e.KeyChar) Then
               e.Handled = True
            End If
         End If
      End Sub

      Private Sub _tbLeft_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _tbLeft.KeyPress
         If Not e.Handled Then
            If Not [Char].IsControl(e.KeyChar) AndAlso Not [Char].IsDigit(e.KeyChar) Then
               e.Handled = True
            End If
         End If
      End Sub

      Private Sub _tbTop_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _tbTop.KeyPress
         If Not e.Handled Then
            If Not [Char].IsControl(e.KeyChar) AndAlso Not [Char].IsDigit(e.KeyChar) Then
               e.Handled = True
            End If
         End If
      End Sub
   End Class
End Namespace
