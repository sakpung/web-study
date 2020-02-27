' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports MS.WindowsAPICodePack.Internal
Imports System.Diagnostics

Namespace DicomDemo.Utils
   Public Class TaskDialogHelper
      Public Const APPLICATION_TITLE As String = "LEADTOOLS High Level DICOM Patient Updater Demo"

      ''' <summary>
      ''' Display "Vista-style" Task Dialog or fallback MessageBox() on pre-Vista machines.
      ''' </summary>
      ''' <param name="owner"></param>
      ''' <param name="dialogTitle"></param>
      ''' <param name="instruction"></param>
      ''' <param name="body"></param>
      ''' <param name="footer"></param>
      ''' <param name="buttons"></param>
      ''' <param name="mainIcon"></param>
      ''' <param name="footerIcon"></param>
      ''' <returns></returns>
      Private Sub New()
      End Sub
      Public Shared Function ShowMessageBox(ByVal owner As IWin32Window, ByVal dialogTitle As String, ByVal instruction As String, ByVal body As String, ByVal footer As String, ByVal buttons As TaskDialogStandardButtons, ByVal mainIcon As TaskDialogStandardIcon, ByVal footerIcon As Nullable(Of TaskDialogStandardIcon)) As TaskDialogResult
         Dim result As TaskDialogResult = TaskDialogResult.Ok
         If CoreHelpers.RunningOnVista Then ' or greater
            Dim dialog As TaskDialog = New TaskDialog()

            dialog.Cancelable = True
            dialog.Caption = dialogTitle
            If footerIcon.HasValue Then
               dialog.FooterIcon = footerIcon.Value
            End If
            dialog.FooterText = footer
            dialog.HyperlinksEnabled = True
            AddHandler dialog.HyperlinkClick, AddressOf dialog_HyperlinkClick
            dialog.Icon = mainIcon
            dialog.InstructionText = instruction
            dialog.StandardButtons = buttons
            dialog.Text = body
            dialog.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandContent
            dialog.StartupLocation = TaskDialogStartupLocation.CenterOwner
            If Not owner Is Nothing Then
               dialog.OwnerWindowHandle = owner.Handle
            End If

            Return dialog.Show()
         End If

         ' XP or less
         Dim stdButtons As MessageBoxButtons = MessageBoxButtons.OK
         If (buttons And (TaskDialogStandardButtons.Yes Or TaskDialogStandardButtons.No)) = (TaskDialogStandardButtons.Yes Or TaskDialogStandardButtons.No) Then
            stdButtons = MessageBoxButtons.YesNo
         ElseIf (buttons And (TaskDialogStandardButtons.Yes Or TaskDialogStandardButtons.No Or TaskDialogStandardButtons.Cancel)) = (TaskDialogStandardButtons.Yes Or TaskDialogStandardButtons.No Or TaskDialogStandardButtons.Cancel) Then
            stdButtons = MessageBoxButtons.YesNoCancel
         ElseIf (buttons And (TaskDialogStandardButtons.Ok Or TaskDialogStandardButtons.Cancel)) = (TaskDialogStandardButtons.Ok Or TaskDialogStandardButtons.Cancel) Then
            stdButtons = MessageBoxButtons.OKCancel
         ElseIf (buttons And (TaskDialogStandardButtons.Ok Or TaskDialogStandardButtons.Close)) = (TaskDialogStandardButtons.Ok Or TaskDialogStandardButtons.Close) Then
            stdButtons = MessageBoxButtons.OK
         ElseIf (buttons And (TaskDialogStandardButtons.Retry Or TaskDialogStandardButtons.Cancel)) = (TaskDialogStandardButtons.Retry Or TaskDialogStandardButtons.Cancel) Then
            stdButtons = MessageBoxButtons.RetryCancel
         End If

         Dim stdIcon As MessageBoxIcon = MessageBoxIcon.None

         If mainIcon = TaskDialogStandardIcon.Information Then
            stdIcon = MessageBoxIcon.Information
         ElseIf mainIcon = TaskDialogStandardIcon.Error Then
            stdIcon = MessageBoxIcon.Error
         ElseIf mainIcon = TaskDialogStandardIcon.Warning Then
            stdIcon = MessageBoxIcon.Warning
         ElseIf mainIcon = TaskDialogStandardIcon.None Then
            stdIcon = MessageBoxIcon.None
         End If

         Dim stdResult As DialogResult = MessageBox.Show(owner, instruction & Environment.NewLine & body, APPLICATION_TITLE & " - " & dialogTitle, stdButtons, stdIcon)

         If stdResult = System.Windows.Forms.DialogResult.OK Then
            result = TaskDialogResult.Ok
         ElseIf stdResult = DialogResult.Yes Then
            result = TaskDialogResult.Yes
         ElseIf stdResult = DialogResult.No Then
            result = TaskDialogResult.No
         ElseIf stdResult = DialogResult.Cancel Then
            result = TaskDialogResult.Cancel
         ElseIf stdResult = DialogResult.Retry Then
            result = TaskDialogResult.Retry
         End If

         Return result
      End Function

      Private Shared Sub dialog_HyperlinkClick(ByVal sender As Object, ByVal e As TaskDialogHyperlinkClickedEventArgs)
         Try
            ' Launch the application associated with http links
            Process.Start(e.LinkText)
         Catch e1 As Exception
            ShowMessageBox(Nothing, "Error", "Could not activate link", "Could not activate hyperlink, if this is a URL, try visiting the website manually.", Nothing, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, Nothing)
         End Try
      End Sub
   End Class
End Namespace
