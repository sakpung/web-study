' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.SpecialEffects
Namespace SpecialEffectsDemo
   Partial Public Class TextDialog : Inherits Form
      Public Sub New(ByVal options As TextOptions)
         _options = options

         InitializeComponent()
      End Sub

      Private _options As TextOptions

      Private Sub NewTextDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         Dim items As ArrayList = New ArrayList()

         items.Add(New ComboBoxItem("No 3D Effect", CInt(SpecialEffectsTextStyle.Normal)))
         items.Add(New ComboBoxItem("Inset Light", CInt(SpecialEffectsTextStyle.InsetLight)))
         items.Add(New ComboBoxItem("Inset Extra Light", CInt(SpecialEffectsTextStyle.InsetExtraLight)))
         items.Add(New ComboBoxItem("Inset Heavy", CInt(SpecialEffectsTextStyle.InsetHeavy)))
         items.Add(New ComboBoxItem("Inset Extra Heavy", CInt(SpecialEffectsTextStyle.InsetExtraHeavy)))
         items.Add(New ComboBoxItem("Raised Light", CInt(SpecialEffectsTextStyle.RaisedLight)))
         items.Add(New ComboBoxItem("Raised Extra Light", CInt(SpecialEffectsTextStyle.RaisedExtraLight)))
         items.Add(New ComboBoxItem("Raised Heavy", CInt(SpecialEffectsTextStyle.RaisedHeavy)))
         items.Add(New ComboBoxItem("Raised Extra Heavy", CInt(SpecialEffectsTextStyle.RaisedExtraHeavy)))
         items.Add(New ComboBoxItem("Drop Shadow", CInt(SpecialEffectsTextStyle.DropShadow)))
         items.Add(New ComboBoxItem("Block Shadow", CInt(SpecialEffectsTextStyle.BlockShadow)))
         items.Add(New ComboBoxItem("Outline Block", CInt(SpecialEffectsTextStyle.OutlineBlock)))

         _cmbTextStyle.DataSource = items
         _cmbTextStyle.DisplayMember = "Display"
         _cmbTextStyle.ValueMember = "Value"

         _tbText.Text = _options.Text

         Dim i As Integer = 0
         Do While i < _cmbTextStyle.Items.Count
            Dim item As ComboBoxItem = CType(_cmbTextStyle.Items(i), ComboBoxItem)
            If _options.Style = CType(item.Value, SpecialEffectsTextStyle) Then
               _cmbTextStyle.SelectedIndex = i
            End If
            i += 1
         Loop

         _btnTextColor.BackColor = _options.TextColor
         _btnBorderColor.BackColor = _options.BorderColor
      End Sub

      Private Sub _btnTextColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnTextColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _btnTextColor.BackColor = dlg.Color
         End If
      End Sub

      Private Sub _btnBorderColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBorderColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _btnBorderColor.BackColor = dlg.Color
         End If
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         _options.Text = _tbText.Text

         Dim item As ComboBoxItem = CType(_cmbTextStyle.SelectedItem, ComboBoxItem)
         _options.Style = CType(item.Value, SpecialEffectsTextStyle)

         _options.TextColor = _btnTextColor.BackColor
         _options.BorderColor = _btnBorderColor.BackColor
      End Sub

      Public ReadOnly Property TextOptions() As TextOptions
         Get
            Return _options
         End Get
      End Property
   End Class
End Namespace
