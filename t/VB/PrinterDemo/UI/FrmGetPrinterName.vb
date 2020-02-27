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

Partial Public Class FrmGetPrinterName : Inherits Form

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGetPrinterName))
      Me._lblSelectActivePrinter = New System.Windows.Forms.Label()
      Me._cmbPrintersList = New System.Windows.Forms.ComboBox()
      Me._btnInstallNewPrinter = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _lblSelectActivePrinter
      ' 
      Me._lblSelectActivePrinter.AutoSize = True
      Me._lblSelectActivePrinter.Location = New System.Drawing.Point(19, 9)
      Me._lblSelectActivePrinter.Name = "_lblSelectActivePrinter"
      Me._lblSelectActivePrinter.Size = New System.Drawing.Size(260, 13)
      Me._lblSelectActivePrinter.TabIndex = 0
      Me._lblSelectActivePrinter.Text = "Please choose the active printer, or create a new one"
      ' 
      ' _cmbPrintersList
      ' 
      Me._cmbPrintersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbPrintersList.FormattingEnabled = True
      Me._cmbPrintersList.Location = New System.Drawing.Point(22, 37)
      Me._cmbPrintersList.Name = "_cmbPrintersList"
      Me._cmbPrintersList.Size = New System.Drawing.Size(282, 21)
      Me._cmbPrintersList.TabIndex = 1
      ' 
      ' _btnInstallNewPrinter
      ' 
      Me._btnInstallNewPrinter.Location = New System.Drawing.Point(22, 87)
      Me._btnInstallNewPrinter.Name = "_btnInstallNewPrinter"
      Me._btnInstallNewPrinter.Size = New System.Drawing.Size(282, 40)
      Me._btnInstallNewPrinter.TabIndex = 2
      Me._btnInstallNewPrinter.Text = "Install New Printer"
      Me._btnInstallNewPrinter.UseVisualStyleBackColor = True
      '		 Me._btnInstallNewPrinter.Click += New System.EventHandler(Me._btnInstallNewPrinter_Click);
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(242, 149)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(62, 29)
      Me._btnCancel.TabIndex = 4
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.Location = New System.Drawing.Point(174, 149)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(62, 29)
      Me._btnOk.TabIndex = 3
      Me._btnOk.Text = "Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' FrmGetPrinterName
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(326, 181)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnInstallNewPrinter)
      Me.Controls.Add(Me._cmbPrintersList)
      Me.Controls.Add(Me._lblSelectActivePrinter)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FrmGetPrinterName"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Get Printer Name"
      '		 Me.FormClosed += New System.Windows.Forms.FormClosedEventHandler(Me.FrmGetPrinterName_FormClosed);
      '		 Me.Load += New System.EventHandler(Me.FrmGetPrinterName_Load);
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _lblSelectActivePrinter As System.Windows.Forms.Label
   Private _cmbPrintersList As System.Windows.Forms.ComboBox
   Private WithEvents _btnInstallNewPrinter As System.Windows.Forms.Button
   Private _btnCancel As System.Windows.Forms.Button
   Private _btnOk As System.Windows.Forms.Button
#End Region

#Region "Constructor..."
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal activePrinter As String)
      InitializeComponent()
      _printerName = activePrinter
   End Sub
#End Region

#Region "Fields..."
   Private _printingUtilities As PrintingUtilities = New PrintingUtilities()
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
   Private Sub FrmGetPrinterName_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      Try
         _cmbPrintersList.Items.Clear()
         _btnInstallNewPrinter.Visible = (_printerName = String.Empty)
         FillLeadtoolsPrintersList()
         EnableControls()
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub FrmGetPrinterName_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
      Try
         If _cmbPrintersList.Items.Count > 0 Then
            _printerName = _cmbPrintersList.Text
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _btnInstallNewPrinter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnInstallNewPrinter.Click
      Try
         Dim frmInstallPrinter As FrmInstallPrinter = New FrmInstallPrinter()
         Dim dialogResult As DialogResult = frmInstallPrinter.ShowDialog()

         If dialogResult = dialogResult.OK Then
            Cursor = Cursors.WaitCursor
            Dim newPrinterName As String = frmInstallPrinter.PrinterName
            Dim newPrinterPassword As String = frmInstallPrinter.PrinterPassword

            PrintingUtilities.InstallNewPrinter(newPrinterName, newPrinterPassword)
            _printerName = newPrinterName
            FillLeadtoolsPrintersList()
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub
#End Region

#Region "Methods..."
   Private ReadOnly Property Is64() As Boolean
      Get
         Return IntPtr.Size = 8
      End Get
   End Property

   Private Sub FillLeadtoolsPrintersList()
      Dim setupPrinter As String = String.Empty

#If LTV20_CONFIG Then
      If (Is64) Then
         setupPrinter = "LEADTOOLS 20 .NET Printer 64-bit"
      Else
         setupPrinter = "LEADTOOLS 20 .NET Printer 32-bit"
      End If
#End If

      Try
         _cmbPrintersList.Items.Clear()
         _cmbPrintersList.Items.AddRange(PrintingUtilities.GetLeadtoolsPrintersList())

         If _cmbPrintersList.Items.Count > 0 Then
            If _printerName <> String.Empty Then
               _cmbPrintersList.Text = _printerName
            Else
               _cmbPrintersList.SelectedIndex = 0
            End If

            If _printerName = String.Empty Then
               Dim i As Integer = 0
               Do While i < _cmbPrintersList.Items.Count
                  If (TryCast(_cmbPrintersList.Items(i), String)).ToLower() = setupPrinter.ToLower() Then
                     _cmbPrintersList.SelectedIndex = i
                  End If
                  i += 1
               Loop
            End If
         Else
            Dim errorMessage As String = "No printers are available."
            MessageBox.Show(errorMessage, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If
         EnableControls()
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub EnableControls()
      Try
         Dim bprinterExist As Boolean = (_cmbPrintersList.Items.Count > 0)
         _btnOk.Enabled = bprinterExist
         _cmbPrintersList.Enabled = bprinterExist
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub
#End Region
End Class
