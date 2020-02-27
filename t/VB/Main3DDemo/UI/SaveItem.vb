' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools.Medical3D
Imports Leadtools.MedicalViewer

Namespace Main3DDemo
   Partial Public Class SaveItemialog : Inherits Form
      Private _dialog As Histogram3DDialog
      Private _combobox As ComboBox

      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub New(ByVal dialog As Histogram3DDialog, ByVal count As Integer, ByVal combobox As ComboBox)
         InitializeComponent()

         _dialog = dialog

         _combobox = combobox


         GetNextName(count)

      End Sub

      Private Sub GetNextName(ByVal count As Integer)
         _txtItemName.Text = String.Format("Item {0}", count + 1)
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         _dialog.ItemName = ""
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click

         For Each item As Object In _combobox.Items
            If _txtItemName.Text = item.ToString() Then
               MessageBox.Show("The name is already used", "Duplicated Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return
            End If
         Next item

         _dialog.ItemName = _txtItemName.Text



         Me.Close()
      End Sub
   End Class
End Namespace
