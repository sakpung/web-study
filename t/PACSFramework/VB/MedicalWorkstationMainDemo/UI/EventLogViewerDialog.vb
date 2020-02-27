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
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Leadtools.Demos.Workstation
   Partial Public Class EventLogViewerDialog
	   Inherits Form
	  Public Sub New()
       InitializeComponent()

      Icon = WorkstationUtils.GetApplicationIcon()
	  End Sub
   End Class
End Namespace
