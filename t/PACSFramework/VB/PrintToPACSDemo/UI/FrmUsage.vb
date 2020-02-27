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

Namespace PrintToPACSDemo
   Partial Public Class FrmUsage : Inherits Form
   Public Sub New()
   InitializeComponent()
   End Sub

   Private Sub FrmUsage2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
   richTextBox1.Rtf = RTFConstants.RtfFiles(5)
   End Sub

   Private Sub label_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles label17.MouseLeave, label15.MouseLeave, label7.MouseLeave, label5.MouseLeave, label4.MouseLeave
   richTextBox1.Rtf = RTFConstants.RtfFiles(5)
   End Sub

   Private Sub label_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles label17.MouseEnter, label15.MouseEnter, label7.MouseEnter, label5.MouseEnter, label4.MouseEnter
   Dim iList As Integer = Integer.Parse((CType(sender, Control)).Tag.ToString())
   richTextBox1.Rtf = RTFConstants.RtfFiles(iList)
   End Sub
   End Class

   Friend Class RTFConstants

   Public Shared RtfFiles As List(Of String) = New List(Of String)()
   Private Sub New()
   End Sub
   Shared Sub New()
   RtfFiles.Add("{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}{\f2\fnil\fcharset2 Symbol;}}" & ControlChars.CrLf & "\viewkind4\uc1\pard\sl360\slmult1\lang9\b\f0\fs24 Capture Options: \f1\fs22\par" & ControlChars.CrLf & "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sl276\slmult1 Virtual Printer Driver \b0 - capture the print output from any Windows application \par" & ControlChars.CrLf & "\b{\pntext\f2\'B7\tab}Twain\b0 - scan images from TWAIN device \par" & ControlChars.CrLf & "\b{\pntext\f2\'B7\tab}WIA \b0 - capture images from digital devices and media using WIA interface \par" & ControlChars.CrLf & "\b{\pntext\f2\'B7\tab}Screen Capture \b0 - Capture any object or Windows or selected area or full screen \par" & ControlChars.CrLf & "\b{\pntext\f2\'B7\tab}File Interface\b0 - Import from over 150+ image file formats or PDF \par" & ControlChars.CrLf & "\b{\pntext\f2\'B7\tab}Manually Entry\b0 - manually enter the required information  \par" & ControlChars.CrLf & "}" & ControlChars.CrLf & "")
   RtfFiles.Add("{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}{\f2\fnil\fcharset2 Symbol;}}" & ControlChars.CrLf & "{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sl360\slmult1\lang9\b\f0\fs24 Output DICOM Storage Object Options as: \f1\fs22\par" & ControlChars.CrLf & "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sl276\slmult1\b0 Secondary Capture Image Storage   \par" & ControlChars.CrLf & "{\pntext\f2\'B7\tab}Multi-frame  Secondary Capture Grayscale Byte Image Storage \par" & ControlChars.CrLf & "{\pntext\f2\'B7\tab}Multi-frame  Secondary Capture True Color Image Storage\par" & ControlChars.CrLf & "{\pntext\f2\'B7\tab}DICOM Encapsulated PDF \b\par" & ControlChars.CrLf & "}" & ControlChars.CrLf & " ")

   RtfFiles.Add("{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}{\f2\fnil\fcharset2 Symbol;}}" & ControlChars.CrLf & "{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sl360\slmult1\lang9\b\f0\fs24 DICOM patient/study Metadata collection options:\f1\fs22\par" & ControlChars.CrLf & "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sl276\slmult1 Modality Work-list (MWL) \b0 - Query work-list server for scheduled work item and patient/study information. \par" & ControlChars.CrLf & "\b{\pntext\f2\'B7\tab}Query PACS \b0\endash  query for existing studies on PACS and associate the newly captured image(s) to existing patient or study. \par" & ControlChars.CrLf & "{\pntext\f2\'B7\tab}Import the patient/study information from \b existing local DICOM file \b0 on disk    DICOM Encapsulated PDF \b\par" & ControlChars.CrLf & "}" & ControlChars.CrLf & " ")
   RtfFiles.Add("{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}{\f2\fnil\fcharset2 Symbol;}}" & ControlChars.CrLf & "{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sl360\slmult1\lang9\b\f0\fs24 Compression Option:\b0\f1\fs22\par" & ControlChars.CrLf & "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sl276\slmult1 Lossy JPEG   \b\par" & ControlChars.CrLf & "\b0{\pntext\f2\'B7\tab}Lossless JPEG \b\par" & ControlChars.CrLf & "\b0{\pntext\f2\'B7\tab}Lossless JPEG 2000 \b\par" & ControlChars.CrLf & "\b0{\pntext\f2\'B7\tab}Lossy JPEG 2000 \b\par" & ControlChars.CrLf & "\b0{\pntext\f2\'B7\tab}Uncompressed\b\par" & ControlChars.CrLf & "\pard\li90\sl276\slmult1\par" & ControlChars.CrLf & "\i Note: This configuration is under the option dialog.\i0\par" & ControlChars.CrLf & "}" & ControlChars.CrLf & " ")
   RtfFiles.Add("{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}{\f2\fnil\fcharset2 Symbol;}}" & ControlChars.CrLf & "{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sl360\slmult1\lang9\b\f0\fs24 Export Options:\b0\f1\fs22\par" & ControlChars.CrLf & "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sl276\slmult1 Save to local folder as DICOM file. \b\par" & ControlChars.CrLf & "\b0{\pntext\f2\'B7\tab}Store to PACS via DICOM message \b\par" & ControlChars.CrLf & "}" & ControlChars.CrLf & " ")
   RtfFiles.Add("{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\froman\fprq2\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}}" & ControlChars.CrLf & "{\colortbl ;\red0\green77\blue187;}" & ControlChars.CrLf & "{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\ul\b\f0\fs28 PrintToPACS:\par" & ControlChars.CrLf & "\par" & ControlChars.CrLf & "\pard\li270\ulnone\b0\f1\fs24 This utility allows user to capture images and documents in many different ways, associate the captured data to studies on PACS and store the data to PACS as secondary capture or DICOM Encapsulated PDF. \f0\par" & ControlChars.CrLf & "\f1\par" & ControlChars.CrLf & "\pard\sa200\sl276\slmult1 Note: Move the mouse over the \cf1\b\i blue labels\i0  \cf0\b0 for viewing the underline features.\lang9\fs22\par" & ControlChars.CrLf & "}" & ControlChars.CrLf & " ")
   End Sub
   End Class
End Namespace
