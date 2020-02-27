' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace DicomAnonymizer.UI.Controls
   Public Class DataGridViewDisableButtonColumn : Inherits DataGridViewButtonColumn
      Public Sub New()
         Me.CellTemplate = New DataGridViewDisableButtonCell()
      End Sub
   End Class
End Namespace
