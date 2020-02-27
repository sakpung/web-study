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

Namespace Ocr2SharePointDemo
   Public Partial Class WizardControl : Inherits TabControl
	  Public Sub New()
		 InitializeComponent()
	  End Sub

	  Protected Overrides Sub WndProc(ByRef m As Message)
		 Const TCM_ADJUSTRECT As Integer = &H1328
		 If (Not DesignMode) AndAlso m.Msg = TCM_ADJUSTRECT Then
			m.Result = CType(1, IntPtr)
		 Else
			MyBase.WndProc(m)
		 End If
	  End Sub
   End Class
End Namespace
