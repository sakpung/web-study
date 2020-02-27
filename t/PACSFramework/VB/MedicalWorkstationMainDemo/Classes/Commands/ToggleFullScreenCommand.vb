' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Workstation.Commands


Namespace Leadtools.Demos.Workstation
   Friend Class ToggleFullScreenCommand
	   Implements ICommand
	  Public Sub New(ByVal container As Control)
		 _container = container
		 _parentForm = container.FindForm ()
	  End Sub

     Public Sub Execute() Implements ICommand.Execute
       Try
         If (Not CanExecute()) Then
            Return
         End If

         If _parentForm.FormBorderStyle = FormBorderStyle.None Then
            _parentForm.FormBorderStyle = FormBorderStyle.Sizable

            AutoHidePanel.ExpandTopLevelPanels()
         Else
            _parentForm.SuspendLayout()
            _parentForm.FormBorderStyle = FormBorderStyle.None

            _parentForm.WindowState = FormWindowState.Normal
            _parentForm.WindowState = FormWindowState.Maximized

            AutoHidePanel.CollapseTopLevelPanels()

            _parentForm.ResumeLayout()

         End If

         OnCommandExecuted()
       Catch exception As Exception
         System.Diagnostics.Debug.Assert(False, exception.Message)

         Throw
       End Try
     End Sub

	  Private Sub OnCommandExecuted()
		 If Nothing IsNot CommandExecutedEvent Then
			RaiseEvent CommandExecuted(Me, EventArgs.Empty)
		 End If
	  End Sub

	  Public Event CommandExecuted As EventHandler

     Public Function CanExecute() As Boolean Implements ICommand.CanExecute
       Return _parentForm IsNot Nothing
     End Function

	  Public ReadOnly Property FullScreen() As Boolean
		 Get
			If _parentForm Is Nothing Then
			   Return False
			End If

			If _parentForm.FormBorderStyle = FormBorderStyle.None Then
			   Return True
			Else
			   Return False
			End If
		 End Get
	  End Property

	  Private _container As Control
	  Private _parentForm As Form
   End Class
End Namespace
