' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Namespace Leadtools.Demos.StorageServer.UI
   Friend Class ThemesManager
      Public Shared Sub ApplyTheme(ByVal control As Control)
         control.BackColor = Color.FromArgb(237, 239, 244)

         If TypeOf control Is GroupBox Then
            control.ForeColor = Color.DarkBlue
         Else
            control.ForeColor = Color.Black
         End If

         If TypeOf control Is Button Then
            CType(control, Button).FlatStyle = FlatStyle.Flat
         End If

         If TypeOf control Is DataGridView Then
            Dim grdView As DataGridView = CType(control, DataGridView)

            grdView.BackgroundColor = Color.SlateGray
            grdView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
         End If

         For Each child As Control In control.Controls
            ApplyTheme(child)
         Next child
      End Sub
   End Class
End Namespace
