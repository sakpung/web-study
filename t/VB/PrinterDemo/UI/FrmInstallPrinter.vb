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

Partial Public Class FrmInstallPrinter : Inherits Form

#Region "Windows Form Designer generated code"
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInstallPrinter))
      Me._lblPrinterName = New System.Windows.Forms.Label()
      Me._lblPrinterPassword = New System.Windows.Forms.Label()
      Me._txtBoxPrinterName = New System.Windows.Forms.TextBox()
      Me._txtBoxPrinterPassword = New System.Windows.Forms.TextBox()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _lblPrinterName
      ' 
      Me._lblPrinterName.AutoSize = True
      Me._lblPrinterName.Location = New System.Drawing.Point(12, 20)
      Me._lblPrinterName.Name = "_lblPrinterName"
      Me._lblPrinterName.Size = New System.Drawing.Size(68, 13)
      Me._lblPrinterName.TabIndex = 0
      Me._lblPrinterName.Text = "Printer Name"
      ' 
      ' _lblPrinterPassword
      ' 
      Me._lblPrinterPassword.AutoSize = True
      Me._lblPrinterPassword.Location = New System.Drawing.Point(13, 63)
      Me._lblPrinterPassword.Name = "_lblPrinterPassword"
      Me._lblPrinterPassword.Size = New System.Drawing.Size(86, 13)
      Me._lblPrinterPassword.TabIndex = 2
      Me._lblPrinterPassword.Text = "Printer Password"
      ' 
      ' _txtBoxPrinterName
      ' 
      Me._txtBoxPrinterName.Location = New System.Drawing.Point(115, 17)
      Me._txtBoxPrinterName.Name = "_txtBoxPrinterName"
      Me._txtBoxPrinterName.Size = New System.Drawing.Size(215, 20)
      Me._txtBoxPrinterName.TabIndex = 1
      '		 Me._txtBoxPrinterName.TextChanged += New System.EventHandler(Me._txtBoxPrinterName_TextChanged);
      ' 
      ' _txtBoxPrinterPassword
      ' 
      Me._txtBoxPrinterPassword.Location = New System.Drawing.Point(115, 60)
      Me._txtBoxPrinterPassword.Name = "_txtBoxPrinterPassword"
      Me._txtBoxPrinterPassword.PasswordChar = "*"c
      Me._txtBoxPrinterPassword.Size = New System.Drawing.Size(215, 20)
      Me._txtBoxPrinterPassword.TabIndex = 3
      Me._txtBoxPrinterPassword.UseSystemPasswordChar = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.Enabled = False
      Me._btnOk.Location = New System.Drawing.Point(200, 101)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(62, 29)
      Me._btnOk.TabIndex = 5
      Me._btnOk.Text = "Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(268, 101)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(62, 29)
      Me._btnCancel.TabIndex = 6
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' FrmInstallPrinter
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(341, 132)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._txtBoxPrinterPassword)
      Me.Controls.Add(Me._txtBoxPrinterName)
      Me.Controls.Add(Me._lblPrinterPassword)
      Me.Controls.Add(Me._lblPrinterName)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FrmInstallPrinter"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Install Printer"
      '		 Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.FrmInstallPrinter_FormClosing);
      '		 Me.Load += New System.EventHandler(Me.FrmInstallPrinter_Load);
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _lblPrinterName As System.Windows.Forms.Label
   Private _lblPrinterPassword As System.Windows.Forms.Label
   Private WithEvents _txtBoxPrinterName As System.Windows.Forms.TextBox
   Private _txtBoxPrinterPassword As System.Windows.Forms.TextBox
   Private _btnOk As System.Windows.Forms.Button
   Private _btnCancel As System.Windows.Forms.Button
#End Region

#Region "Constructor..."
   Public Sub New()
      InitializeComponent()
   End Sub
#End Region

#Region "Fields..."
   Private _printerName As String = String.Empty
   Private _printerPassword As String = String.Empty
#End Region

#Region "Properties..."
   Public ReadOnly Property PrinterName() As String
      Get
         Return _printerName
      End Get
   End Property

   Public ReadOnly Property PrinterPassword() As String
      Get
         Return _printerPassword
      End Get
   End Property
#End Region

#Region "Events..."
   Private Sub FrmInstallPrinter_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      Try
         EnableControls()
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub FrmInstallPrinter_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
      Try
         _printerName = _txtBoxPrinterName.Text
         _printerPassword = _txtBoxPrinterPassword.Text
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _txtBoxPrinterName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtBoxPrinterName.TextChanged
      Try
         EnableControls()
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub
#End Region

#Region "Methods..."
   Private Sub EnableControls()
      Try
         Dim bEnable As Boolean = (_txtBoxPrinterName.Text <> String.Empty)
         _btnOk.Enabled = bEnable
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub
#End Region
End Class
