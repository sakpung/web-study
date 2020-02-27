' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Pdf

Namespace PDFFileDemo
   Partial Public Class SecurityOptionsControl : Inherits UserControl
      Private _compatibilityLevel As PDFCompatibilityLevel

      Public Sub New()
         InitializeComponent()

         ' -1 to leave space for the null terminated character
         _ownerPasswordTextBox.MaxLength = PDFDocument.MaximumPasswordLength - 1
         _userPasswordTextBox.MaxLength = PDFDocument.MaximumPasswordLength - 1

         For Each mode As PDFEncryptionMode In System.Enum.GetValues(GetType(PDFEncryptionMode))
            _ecnryptionModeComboBox.Items.Add(mode)
         Next mode
      End Sub
      Public Sub SetCompatibilityLevel(ByVal CompatibilityLevel As PDFCompatibilityLevel)
         _compatibilityLevel = CompatibilityLevel
         UpdateUIState()
      End Sub

      Public Sub SetSecurityOptions(ByVal securityOptions As PDFSecurityOptions)
         _ownerPasswordTextBox.Text = securityOptions.OwnerPassword
         _userPasswordTextBox.Text = securityOptions.UserPassword
         _printEnabledCheckBox.Checked = securityOptions.PrintEnabled
         _highQualityPrintEnabledCheckBox.Checked = securityOptions.HighQualityPrintEnabled
         _copyEnabledCheckBox.Checked = securityOptions.CopyEnabled
         _editEnabledCheckBox.Checked = securityOptions.EditEnabled
         _annotationsEnabledCheckBox.Checked = securityOptions.AnnotationsEnabled
         _assemblyEnabledCheckBox.Checked = securityOptions.AssemblyEnabled
         _ecnryptionModeComboBox.SelectedItem = securityOptions.EncryptionMode

         UpdateUIState()
      End Sub

      Public Sub UpdateSecurityOptions(ByVal securityOptions As PDFSecurityOptions)
         securityOptions.OwnerPassword = _ownerPasswordTextBox.Text
         securityOptions.UserPassword = _userPasswordTextBox.Text
         securityOptions.PrintEnabled = _printEnabledCheckBox.Checked
         securityOptions.HighQualityPrintEnabled = _highQualityPrintEnabledCheckBox.Checked
         securityOptions.CopyEnabled = _copyEnabledCheckBox.Checked
         securityOptions.EditEnabled = _editEnabledCheckBox.Checked
         securityOptions.AnnotationsEnabled = _annotationsEnabledCheckBox.Checked
         securityOptions.AssemblyEnabled = _assemblyEnabledCheckBox.Checked
         securityOptions.EncryptionMode = CType(_ecnryptionModeComboBox.SelectedItem, PDFEncryptionMode)
      End Sub

      Private Sub _ecnryptionModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _ecnryptionModeComboBox.SelectedIndexChanged
         UpdateUIState()
      End Sub

      Private Sub UpdateUIState()
         Dim highQualityPrintEnabled As Boolean = True
         If _compatibilityLevel = PDFCompatibilityLevel.PDF12 OrElse _compatibilityLevel = PDFCompatibilityLevel.PDF13 Then
            _ecnryptionModeComboBox.Items.Remove(PDFEncryptionMode.RC128Bit)
            _ecnryptionModeComboBox.SelectedIndex = 0
         ElseIf (Not _ecnryptionModeComboBox.Items.Contains(PDFEncryptionMode.RC128Bit)) Then
            _ecnryptionModeComboBox.Items.Add(PDFEncryptionMode.RC128Bit)
         End If

         If Not _ecnryptionModeComboBox.SelectedItem Is Nothing Then
            Dim encryptionMode As PDFEncryptionMode = CType(_ecnryptionModeComboBox.SelectedItem, PDFEncryptionMode)
            highQualityPrintEnabled = (encryptionMode = PDFEncryptionMode.RC128Bit)
         End If

         If (Not _printEnabledCheckBox.Checked) Then
            highQualityPrintEnabled = False
         End If

         _highQualityPrintEnabledCheckBox.Enabled = highQualityPrintEnabled

         If _editEnabledCheckBox.Checked Then
            _assemblyEnabledCheckBox.Checked = True
            _assemblyEnabledCheckBox.Enabled = False
         Else
            _assemblyEnabledCheckBox.Enabled = True
         End If
      End Sub

      Private Sub _printEnabledCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _printEnabledCheckBox.CheckedChanged
         UpdateUIState()
      End Sub

      Private Sub _editEnabledCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _editEnabledCheckBox.CheckedChanged
         UpdateUIState()
      End Sub
   End Class
End Namespace
