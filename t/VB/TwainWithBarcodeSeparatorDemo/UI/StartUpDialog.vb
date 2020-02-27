' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.Win32

Namespace TwainWithBarcodeSeparatorDemo
   Partial Public Class StartUpDialog : Inherits Form
      Private WithEvents _cbDntShowAgain As System.Windows.Forms.CheckBox
      Private WithEvents _btnClose As System.Windows.Forms.Button
      Private _lblDemoDesciption As System.Windows.Forms.Label
      Private components As System.ComponentModel.IContainer = Nothing

      Private strKey As String = Registry.CurrentUser.ToString() & "\SOFTWARE\LEAD Technologies, Inc.\17\VBTwainWithBarcodeSeperatorDemo17"
      Private _showStartUpDlg As Boolean

      Public Sub New()
         InitializeComponent()

         ReadDataFromRegistry()
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me._cbDntShowAgain = New System.Windows.Forms.CheckBox()
         Me._btnClose = New System.Windows.Forms.Button()
         Me._lblDemoDesciption = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' _cbDntShowAgain
         ' 
         Me._cbDntShowAgain.AutoSize = True
         Me._cbDntShowAgain.Location = New System.Drawing.Point(12, 137)
         Me._cbDntShowAgain.Name = "_cbDntShowAgain"
         Me._cbDntShowAgain.Size = New System.Drawing.Size(176, 17)
         Me._cbDntShowAgain.TabIndex = 1
         Me._cbDntShowAgain.Text = "Don't show this message again."
         Me._cbDntShowAgain.UseVisualStyleBackColor = True
         '		 Me._cbDntShowAgain.CheckedChanged += New System.EventHandler(Me._cbDntShowAgain_CheckedChanged);
         ' 
         ' _btnClose
         ' 
         Me._btnClose.Location = New System.Drawing.Point(263, 134)
         Me._btnClose.Name = "_btnClose"
         Me._btnClose.Size = New System.Drawing.Size(75, 23)
         Me._btnClose.TabIndex = 1
         Me._btnClose.Text = "Close"
         Me._btnClose.UseVisualStyleBackColor = True
         '		 Me._btnClose.Click += New System.EventHandler(Me._btnClose_Click);
         ' 
         ' _lblDemoDesciption
         ' 
         Me._lblDemoDesciption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._lblDemoDesciption.Location = New System.Drawing.Point(12, 9)
         Me._lblDemoDesciption.Name = "_lblDemoDesciption"
         Me._lblDemoDesciption.Size = New System.Drawing.Size(326, 112)
         Me._lblDemoDesciption.TabIndex = 0
         ' 
         ' StartUpDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(356, 165)
         Me.Controls.Add(Me._btnClose)
         Me.Controls.Add(Me._cbDntShowAgain)
         Me.Controls.Add(Me._lblDemoDesciption)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
         Me.Name = "StartUpDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "TwainWithBarcodeSeperator Demo"
         '		 Me.Load += New System.EventHandler(Me.StartUpDialog_Load);
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Public ReadOnly Property ShowStartUpDialog() As Boolean
         Get
            Return _showStartUpDlg
         End Get
      End Property

      Private Sub StartUpDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Me._lblDemoDesciption.Text = "This demo scans pages from a Twain source and saves the acquired pages to multi-page TIFF files." & Constants.vbLf & "During scanning, the LEADTOOLS barcode engine is used to search for Code128 barcodes on the page." & Constants.vbLf & "If a user-specified barcode string is detected, the separator is saved to a new TIFF file, " & "which is appended with all subsequent pages until a new separator is detected."
      End Sub

      Private Sub SaveInRegistry()
         Dim szkey As RegistryKey = Registry.CurrentUser.OpenSubKey(strKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

         If szkey Is Nothing Then
            _showStartUpDlg = True
            szkey = Registry.CurrentUser.CreateSubKey(strKey)
         End If

         szkey.SetValue("ShowStartUpMsg", _showStartUpDlg)
      End Sub

      Private Sub ReadDataFromRegistry()
         Try
            Dim szkey As RegistryKey = Registry.CurrentUser.OpenSubKey(strKey)
            If Not szkey Is Nothing Then
               _showStartUpDlg = Boolean.Parse(szkey.GetValue("ShowStartUpMsg").ToString())
            Else
               'if Key not exist; Create it
               SaveInRegistry()
            End If
         Catch
         End Try
      End Sub

      Private Sub _cbDntShowAgain_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbDntShowAgain.CheckedChanged
         _showStartUpDlg = Not (TryCast(sender, CheckBox)).Checked
      End Sub

      Private Sub _btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnClose.Click
         SaveInRegistry()
         Me.DialogResult = DialogResult.OK
      End Sub
   End Class
End Namespace
