' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

''' <summary>
''' Summary description for PdfDPIOptions.
''' </summary>
Public Class PdfDPIOptions : Inherits System.Windows.Forms.Form
   Private label1 As System.Windows.Forms.Label
   Private label2 As System.Windows.Forms.Label
   Private _gpPdfDPI As System.Windows.Forms.GroupBox
   Private _tbYResolution As System.Windows.Forms.TextBox
   Private _tbXResolution As System.Windows.Forms.TextBox
   Private WithEvents _btnOK As System.Windows.Forms.Button
   Private _btnCancel As System.Windows.Forms.Button
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.Container = Nothing
   Private _xResolution As Integer
   Private _yResolution As Integer

   Public ReadOnly Property XResolution() As Integer
      Get
         Return _xResolution
      End Get
   End Property

   Public ReadOnly Property YResolution() As Integer
      Get
         Return _yResolution
      End Get
   End Property


   Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()

      '
      ' TODO: Add any constructor code after InitializeComponent call
      '
   End Sub

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not components Is Nothing Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

#Region "Windows Form Designer generated code"
   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Me._gpPdfDPI = New System.Windows.Forms.GroupBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._tbYResolution = New System.Windows.Forms.TextBox()
      Me._tbXResolution = New System.Windows.Forms.TextBox()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOK = New System.Windows.Forms.Button()
      Me._gpPdfDPI.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _gpPdfDPI
      ' 
      Me._gpPdfDPI.Controls.Add(Me.label2)
      Me._gpPdfDPI.Controls.Add(Me.label1)
      Me._gpPdfDPI.Controls.Add(Me._tbYResolution)
      Me._gpPdfDPI.Controls.Add(Me._tbXResolution)
      Me._gpPdfDPI.Controls.Add(Me._btnCancel)
      Me._gpPdfDPI.Controls.Add(Me._btnOK)
      Me._gpPdfDPI.Location = New System.Drawing.Point(8, 8)
      Me._gpPdfDPI.Name = "_gpPdfDPI"
      Me._gpPdfDPI.Size = New System.Drawing.Size(392, 152)
      Me._gpPdfDPI.TabIndex = 0
      Me._gpPdfDPI.TabStop = False
      Me._gpPdfDPI.Text = "Pdf Resolution"
      ' 
      ' label2
      ' 
      Me.label2.Location = New System.Drawing.Point(216, 48)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(72, 16)
      Me.label2.TabIndex = 5
      Me.label2.Text = "Y Resolution"
      ' 
      ' label1
      ' 
      Me.label1.Location = New System.Drawing.Point(16, 48)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(80, 16)
      Me.label1.TabIndex = 4
      Me.label1.Text = "X Resolution"
      ' 
      ' _tbYResolution
      ' 
      Me._tbYResolution.Location = New System.Drawing.Point(296, 44)
      Me._tbYResolution.Name = "_tbYResolution"
      Me._tbYResolution.Size = New System.Drawing.Size(64, 20)
      Me._tbYResolution.TabIndex = 3
      Me._tbYResolution.Text = ""
      ' 
      ' _tbXResolution
      ' 
      Me._tbXResolution.Location = New System.Drawing.Point(104, 44)
      Me._tbXResolution.Name = "_tbXResolution"
      Me._tbXResolution.Size = New System.Drawing.Size(64, 20)
      Me._tbXResolution.TabIndex = 2
      Me._tbXResolution.Text = ""
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(216, 112)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(88, 24)
      Me._btnCancel.TabIndex = 1
      Me._btnCancel.Text = "Cancel"
      ' 
      ' _btnOK
      ' 
      Me._btnOK.Location = New System.Drawing.Point(88, 112)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(88, 24)
      Me._btnOK.TabIndex = 0
      Me._btnOK.Text = "OK"
      '		 Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
      ' 
      ' PdfDPIOptions
      ' 
      Me.AcceptButton = Me._btnOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(416, 174)
      Me.Controls.Add(Me._gpPdfDPI)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PdfDPIOptions"
      Me.ShowInTaskbar = False
      Me.Text = "Pdf DPI Options"
      '		 Me.Load += New System.EventHandler(Me.PdfDPIOptions_Load);
      Me._gpPdfDPI.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
#End Region

   Private Sub PdfDPIOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      _tbXResolution.Text = "150"
      _tbYResolution.Text = "150"
   End Sub

   Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOK.Click
      Dim nXResolution As Integer = 0
      Dim nYResolution As Integer = 0

      If (Not DialogUtilities.ParseInteger(_tbXResolution, "XResolution", 10, True, 1000, True, True, nXResolution)) Then
         Return
      Else
         _xResolution = nXResolution
      End If

      If (Not DialogUtilities.ParseInteger(_tbYResolution, "YResolution", 10, True, 1000, True, True, nYResolution)) Then
         Return
      Else
         _yResolution = nYResolution
      End If

      DialogResult = System.Windows.Forms.DialogResult.OK
   End Sub


End Class
