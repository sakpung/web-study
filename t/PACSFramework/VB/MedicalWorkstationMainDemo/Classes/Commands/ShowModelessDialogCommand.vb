' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Workstation.Commands


Namespace Leadtools.Demos.Workstation
   Friend Class ShowModelessDialogCommand
	   Implements ICommand
	  Private _parent As IWin32Window
	  Private _dialog As Form

	  Public Sub New(ByVal parent As IWin32Window, ByVal dialog As Form)
		 _parent = parent
		 _dialog = dialog
	  End Sub

     Public Sub Execute() Implements ICommand.Execute
       If _dialog.Visible Then
         _dialog.Focus()
       Else
         _dialog.Show(_parent)
       End If
     End Sub

     Public Function CanExecute() As Boolean Implements ICommand.CanExecute
       Return (_dialog IsNot Nothing)
     End Function
   End Class
End Namespace
