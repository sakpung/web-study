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
Imports Leadtools.ImageProcessing.Core

Namespace DocumentCleanupDemo
   Partial Public Class BorderRemoveDialog : Inherits Form

      '' The BorderRemoveCommand Class is part of LEAD Document Clean-up functions. This class will remove the black borders in a 1-bit black and white image.
      '' This dialog will update the following members of this class:
      '' BorderRemoveCommand.Border Flag, this flag will indicate which border to remove 
      '' BorderRemoveCommand.Flags, this member will determine the behavior of the border removal process. 
      '' BorderRemoveCommand.Percent, this member will set the percent of the image dimension in which the border will be found.  
      '' BorderRemoveCommand.Variance, this member will set the amount of variance tolerated in the border.  
      '' BorderRemoveCommand.WhiteNoiseLength, this member will set the amount of white noise tolerated when determining the border.  

      Private _BorderRemoveCommand As BorderRemoveCommand
      Private Flags As BorderRemoveCommandFlags

      Public Sub New()
         InitializeComponent()
         _BorderRemoveCommand = New BorderRemoveCommand()
         InitializeUI()
      End Sub

      Public Sub New(ByVal borderRemoveCommand1 As BorderRemoveCommand)
         InitializeComponent()
         _BorderRemoveCommand = borderRemoveCommand1
         InitializeUI()
      End Sub
      Public Property BorderRemoveCommand() As BorderRemoveCommand
         Get
            UpdateCommand()
            Return _BorderRemoveCommand
         End Get
         Set(ByVal value As BorderRemoveCommand)
            _BorderRemoveCommand = value
            InitializeUI()
         End Set
      End Property
      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         UpdateCommand()
         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = Windows.Forms.DialogResult.Cancel
      End Sub
      Private Sub InitializeUI()
         '' Initialize the BorderRemove Dialog with default values
         If (_BorderRemoveCommand.Border And BorderRemoveBorderFlags.All) = BorderRemoveBorderFlags.All Then
            _cbLeftBorder.Checked = True
            _cbRightBorder.Checked = True
            _cbTopBorder.Checked = True
            _cbBottomBorder.Checked = True
         Else
            '' Use the BorderRemoveCommand.Border flag to determine which border will be removed.
            If (_BorderRemoveCommand.Border And BorderRemoveBorderFlags.Bottom) = BorderRemoveBorderFlags.Bottom Then
               _cbBottomBorder.Checked = True
            End If
            If (_BorderRemoveCommand.Border And BorderRemoveBorderFlags.Top) = BorderRemoveBorderFlags.Top Then
               _cbTopBorder.Checked = True
            End If
            If (_BorderRemoveCommand.Border And BorderRemoveBorderFlags.Left) = BorderRemoveBorderFlags.Left Then
               _cbLeftBorder.Checked = True
            End If
            If (_BorderRemoveCommand.Border And BorderRemoveBorderFlags.Right) = BorderRemoveBorderFlags.Right Then
               _cbRightBorder.Checked = True
            End If
         End If
         _bBorderPercent.Text = _BorderRemoveCommand.Percent.ToString()
         _tnVariance.Text = _BorderRemoveCommand.Variance.ToString()
         _tbWhiteNoiseLength.Text = _BorderRemoveCommand.WhiteNoiseLength.ToString()
      End Sub
      Private Sub UpdateCommand()

         '' Determine how the BorderRemoveCommand will work by setting the values to its members and flags
         _BorderRemoveCommand.Border = BorderRemoveBorderFlags.None
         _BorderRemoveCommand.Border = CType(IIf(_cbBottomBorder.Checked, BorderRemoveBorderFlags.Bottom, BorderRemoveBorderFlags.None), BorderRemoveBorderFlags) _
         Or CType(IIf(_cbLeftBorder.Checked, BorderRemoveBorderFlags.Left, BorderRemoveBorderFlags.None), BorderRemoveBorderFlags) _
         Or CType(IIf(_cbRightBorder.Checked, BorderRemoveBorderFlags.Right, BorderRemoveBorderFlags.None), BorderRemoveBorderFlags) _
         Or CType(IIf(_cbTopBorder.Checked, BorderRemoveBorderFlags.Top, BorderRemoveBorderFlags.None), BorderRemoveBorderFlags)

         If _BorderRemoveCommand.Border = BorderRemoveBorderFlags.None Then
            _BorderRemoveCommand.Border = (New BorderRemoveCommand()).Border
         End If

         Flags = BorderRemoveCommandFlags.None
         '' Check the flag that will determine how the BorderRemoveCommand will process.
         If _cbImageUnchanged.Checked Then
            Flags = Flags Or BorderRemoveCommandFlags.ImageUnchanged
         End If
         If _cbUseVariance.Checked Then
            Flags = Flags Or BorderRemoveCommandFlags.UseVariance
         End If

         _BorderRemoveCommand.Flags = Flags
         '' Set the value of the Percent property
         If _bBorderPercent.Text <> "" Then
            _BorderRemoveCommand.Percent = Convert.ToInt32(_bBorderPercent.Text)
         End If
         '' Set the value of the Variance property 
         If _tnVariance.Text <> "" Then
            _BorderRemoveCommand.Variance = Convert.ToInt32(_tnVariance.Text)
         End If
         '' Set the value of the WhiteNoiseLength property
         If _tbWhiteNoiseLength.Text <> "" Then
            _BorderRemoveCommand.WhiteNoiseLength = Convert.ToInt32(_tbWhiteNoiseLength.Text)
         End If
      End Sub

      Private Sub _cbUseVariance_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbUseVariance.CheckedChanged
         _lblVariance.Enabled = _cbUseVariance.Checked
         _tnVariance.Enabled = _cbUseVariance.Checked
      End Sub

      Private Sub _bBorderPercent_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _bBorderPercent.TextChanged
         _bBorderPercent.Text = MainForm.IsValidNumber(_bBorderPercent.Text, 1, 100)
      End Sub

      Private Sub _tbWhiteNoiseLength_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbWhiteNoiseLength.TextChanged
         _tbWhiteNoiseLength.Text = MainForm.IsValidNumber(_tbWhiteNoiseLength.Text, 0, 10)
      End Sub

      Private Sub _tnVariance_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tnVariance.TextChanged
         _tnVariance.Text = MainForm.IsValidNumber(_tnVariance.Text, 0, 10)
      End Sub
   End Class
End Namespace
