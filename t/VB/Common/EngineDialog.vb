' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Diagnostics
Imports Leadtools.Document

Public Class EngineDialog
   Inherits System.Windows.Forms.Form

   Private _code As RasterDocumentExceptionCode

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      DialogUtilities.RunFPU()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents _lbEngine As System.Windows.Forms.LinkLabel
   Friend WithEvents _btnOk As System.Windows.Forms.Button
   Friend WithEvents _lblLine2 As System.Windows.Forms.Label
   Friend WithEvents _lblLine1 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me._lblLine2 = New System.Windows.Forms.Label
      Me._lbEngine = New System.Windows.Forms.LinkLabel
      Me._lblLine1 = New System.Windows.Forms.Label
      Me._btnOk = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      '_lblLine2
      '
      Me._lblLine2.Location = New System.Drawing.Point(23, 39)
      Me._lblLine2.Name = "_lblLine2"
      Me._lblLine2.Size = New System.Drawing.Size(424, 23)
      Me._lblLine2.TabIndex = 1
      Me._lblLine2.Text = "Please download and install the OCR engine from the following address:"
      Me._lblLine2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lbEngine
      '
      Me._lbEngine.Location = New System.Drawing.Point(20, 71)
      Me._lbEngine.Name = "_lbEngine"
      Me._lbEngine.Size = New System.Drawing.Size(427, 23)
      Me._lbEngine.TabIndex = 3
      Me._lbEngine.TabStop = True
      Me._lbEngine.Text = "https://www.leadtools.com/RD/v150/LEADTOOLSOCRRuntime.exe"
      Me._lbEngine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lblLine1
      '
      Me._lblLine1.Location = New System.Drawing.Point(67, 15)
      Me._lblLine1.Name = "_lblLine1"
      Me._lblLine1.Size = New System.Drawing.Size(326, 23)
      Me._lblLine1.TabIndex = 0
      Me._lblLine1.Text = "The OCR engine is missing."
      Me._lblLine1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_btnOk
      '
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnOk.Location = New System.Drawing.Point(196, 111)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 2
      Me._btnOk.Text = "OK"
      '
      'EngineDialog
      '
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me._btnOk
      Me.ClientSize = New System.Drawing.Size(466, 149)
      Me.Controls.Add(Me._lblLine2)
      Me.Controls.Add(Me._lbEngine)
      Me.Controls.Add(Me._lblLine1)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "EngineDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Missing LEADTOOLS for .NET OCR Engine"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub _lbEngine_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles _lbEngine.LinkClicked
      Process.Start(_lbEngine.Text)
   End Sub

   Private Sub EngineDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim caption As String
      Dim line1 As String
      Dim line2 As String
      Dim engineLink As String

#If LEADTOOLS_V16_OR_LATER Then
      caption = "Missing LEADTOOLS OCR Engine"
      line1 = "The Plus OCR engine is missing."
      line2 = "Please download and install the OCR engine from the following address:"
      engineLink = "https://www.leadtools.com/downloads?category=main"

      Select Case _code
         Case RasterDocumentExceptionCode.IcrModuleMissing
            caption = "Missing LEADTOOLS ICR Module"
            line1 = "The Plus ICR module is missing."
            line2 = "Please download and install the ICR module from the following address:"
            engineLink = "https://www.leadtools.com/downloads?category=main"

         Case RasterDocumentExceptionCode.OmrModuleMissing
            caption = "Missing LEADTOOLS OMR Module"
            line1 = "The Plus OMR module is missing."
            line2 = "Please download and install the OMR module from the following address:"
            engineLink = "https://www.leadtools.com/downloads?category=main"

         Case RasterDocumentExceptionCode.LanguagesMissing
            caption = "Missing LEADTOOLS More Languages"
            line1 = "Plus More Languages are missing."
            line2 = "Please download and install more languages from the following address:"
            engineLink = "https://www.leadtools.com/downloads?category=main"

         Case RasterDocumentExceptionCode.InitializeEngine
            caption = "Missing LEADTOOLS OCR Engine"
            line1 = "The Plus OCR engine is missing."
            line2 = "Please download and install the OCR engine from the following address:"
            engineLink = "https://www.leadtools.com/downloads?category=main"
      End Select
#Else
      caption = "Missing LEADTOOLS OCR Engine"
      line1 = "The Plus OCR engine is missing."
      line2 = "Please download and install the OCR engine from the following address:"
      engineLink = "https://www.leadtools.com/downloads?category=main"
#End If

      Me.Text = caption
      Me._lblLine1.Text = line1
      Me._lblLine2.Text = line2
      Me._lbEngine.Text = engineLink
   End Sub

   Public Property Code() As RasterDocumentExceptionCode
      Get
         Return _code
      End Get

      Set(ByVal Value As RasterDocumentExceptionCode)
         _code = Value
      End Set
   End Property
End Class

Public NotInheritable Class OcrEngineMessage

   Public Shared Function CheckOcrError(ByVal owner As IWin32Window, ByVal code As RasterDocumentExceptionCode) As RasterDocumentExceptionCode
      If code = RasterDocumentExceptionCode.InitializeEngine Or _
         code = RasterDocumentExceptionCode.IcrModuleMissing Or _
         code = RasterDocumentExceptionCode.OmrModuleMissing Or _
         code = RasterDocumentExceptionCode.LanguagesMissing Then
         Dim dlg As EngineDialog = New EngineDialog()
         dlg.Code = code
         dlg.ShowDialog(owner)
         Return RasterDocumentExceptionCode.Success
      Else
         Return code
      End If
   End Function
End Class
