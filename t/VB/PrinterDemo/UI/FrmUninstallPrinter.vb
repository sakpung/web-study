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

Partial Public Class FrmUninstallPrinter : Inherits Form

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUninstallPrinter))
      Me._lblPrinterName = New System.Windows.Forms.Label()
      Me._cmbPrintersList = New System.Windows.Forms.ComboBox()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _lblPrinterName
      ' 
      Me._lblPrinterName.AutoSize = True
      Me._lblPrinterName.Location = New System.Drawing.Point(3, 29)
      Me._lblPrinterName.Name = "_lblPrinterName"
      Me._lblPrinterName.Size = New System.Drawing.Size(68, 13)
      Me._lblPrinterName.TabIndex = 0
      Me._lblPrinterName.Text = "Printer Name"
      ' 
      ' _cmbPrintersList
      ' 
      Me._cmbPrintersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbPrintersList.FormattingEnabled = True
      Me._cmbPrintersList.Location = New System.Drawing.Point(78, 26)
      Me._cmbPrintersList.Name = "_cmbPrintersList"
      Me._cmbPrintersList.Size = New System.Drawing.Size(202, 21)
      Me._cmbPrintersList.TabIndex = 1
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.Location = New System.Drawing.Point(150, 78)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(62, 29)
      Me._btnOk.TabIndex = 7
      Me._btnOk.Text = "Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(218, 78)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(62, 29)
      Me._btnCancel.TabIndex = 8
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' FrmUninstallPrinter
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(292, 116)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._cmbPrintersList)
      Me.Controls.Add(Me._lblPrinterName)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FrmUninstallPrinter"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Uninstall Printer"
      '		 Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.FrmUninstallPrinter_FormClosing);
      '		 Me.Load += New System.EventHandler(Me.FrmUninstallPrinter_Load);
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _lblPrinterName As System.Windows.Forms.Label
   Private _cmbPrintersList As System.Windows.Forms.ComboBox
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
#End Region

#Region "Properties..."
   Public ReadOnly Property PrinterName() As String
      Get
         Return _printerName
      End Get
   End Property
#End Region

#Region "Events..."
   Private Sub FrmUninstallPrinter_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      Try
         FillLeadtoolsPrintersList()
         EnableControls()
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub FrmUninstallPrinter_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
      Try
         _printerName = _cmbPrintersList.Text
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub
#End Region

#Region "Methods..."
   Private Sub FillLeadtoolsPrintersList()
      Try
         _cmbPrintersList.Items.Clear()
         _cmbPrintersList.Items.AddRange(PrintingUtilities.GetLeadtoolsPrintersList())
         _cmbPrintersList.SelectedIndex = 0
         EnableControls()
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub EnableControls()
      Try
         Dim bEnable As Boolean = (_cmbPrintersList.Items.Count > 0)
         _btnOk.Enabled = bEnable
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub
#End Region
End Class
