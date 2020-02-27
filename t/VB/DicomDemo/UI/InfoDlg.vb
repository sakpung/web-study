' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools.Dicom

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for InfoDialog.
   ''' </summary>
   Public Class InfoDlg : Inherits System.Windows.Forms.Form
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private button1 As System.Windows.Forms.Button
      Private textBoxMetaHeader As System.Windows.Forms.TextBox
      Private textBoxTransfer As System.Windows.Forms.TextBox
      Private textBoxVR As System.Windows.Forms.TextBox
      Private textBoxClass As System.Windows.Forms.TextBox
      Private textBoxPreamble As System.Windows.Forms.TextBox
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Private ds As DicomDataSet

      Public Sub New(ByVal ds As DicomDataSet)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         Me.ds = ds
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
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label4 = New System.Windows.Forms.Label()
         Me.label5 = New System.Windows.Forms.Label()
         Me.button1 = New System.Windows.Forms.Button()
         Me.textBoxMetaHeader = New System.Windows.Forms.TextBox()
         Me.textBoxTransfer = New System.Windows.Forms.TextBox()
         Me.textBoxVR = New System.Windows.Forms.TextBox()
         Me.textBoxClass = New System.Windows.Forms.TextBox()
         Me.textBoxPreamble = New System.Windows.Forms.TextBox()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(16, 16)
         Me.label1.Name = "label1"
         Me.label1.TabIndex = 0
         Me.label1.Text = "Meta-Header:"
         ' 
         ' label2
         ' 
         Me.label2.Location = New System.Drawing.Point(16, 48)
         Me.label2.Name = "label2"
         Me.label2.TabIndex = 1
         Me.label2.Text = "Transfer Syntax:"
         ' 
         ' label3
         ' 
         Me.label3.Location = New System.Drawing.Point(16, 80)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(120, 23)
         Me.label3.TabIndex = 2
         Me.label3.Text = "Value Representation:"
         ' 
         ' label4
         ' 
         Me.label4.Location = New System.Drawing.Point(16, 112)
         Me.label4.Name = "label4"
         Me.label4.TabIndex = 3
         Me.label4.Text = "Class:"
         ' 
         ' label5
         ' 
         Me.label5.Location = New System.Drawing.Point(16, 144)
         Me.label5.Name = "label5"
         Me.label5.TabIndex = 4
         Me.label5.Text = "Preamble:"
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button1.Location = New System.Drawing.Point(204, 256)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 5
         Me.button1.Text = "&Close"
         ' 
         ' textBoxMetaHeader
         ' 
         Me.textBoxMetaHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.textBoxMetaHeader.Location = New System.Drawing.Point(136, 16)
         Me.textBoxMetaHeader.Name = "textBoxMetaHeader"
         Me.textBoxMetaHeader.ReadOnly = True
         Me.textBoxMetaHeader.Size = New System.Drawing.Size(336, 20)
         Me.textBoxMetaHeader.TabIndex = 6
         Me.textBoxMetaHeader.Text = ""
         ' 
         ' textBoxTransfer
         ' 
         Me.textBoxTransfer.Location = New System.Drawing.Point(136, 48)
         Me.textBoxTransfer.Name = "textBoxTransfer"
         Me.textBoxTransfer.ReadOnly = True
         Me.textBoxTransfer.Size = New System.Drawing.Size(336, 20)
         Me.textBoxTransfer.TabIndex = 7
         Me.textBoxTransfer.Text = ""
         ' 
         ' textBoxVR
         ' 
         Me.textBoxVR.Location = New System.Drawing.Point(136, 80)
         Me.textBoxVR.Name = "textBoxVR"
         Me.textBoxVR.ReadOnly = True
         Me.textBoxVR.Size = New System.Drawing.Size(336, 20)
         Me.textBoxVR.TabIndex = 8
         Me.textBoxVR.Text = ""
         ' 
         ' textBoxClass
         ' 
         Me.textBoxClass.Location = New System.Drawing.Point(136, 112)
         Me.textBoxClass.Name = "textBoxClass"
         Me.textBoxClass.ReadOnly = True
         Me.textBoxClass.Size = New System.Drawing.Size(336, 20)
         Me.textBoxClass.TabIndex = 9
         Me.textBoxClass.Text = ""
         ' 
         ' textBoxPreamble
         ' 
         Me.textBoxPreamble.Location = New System.Drawing.Point(136, 144)
         Me.textBoxPreamble.Multiline = True
         Me.textBoxPreamble.Name = "textBoxPreamble"
         Me.textBoxPreamble.ReadOnly = True
         Me.textBoxPreamble.Size = New System.Drawing.Size(336, 104)
         Me.textBoxPreamble.TabIndex = 10
         Me.textBoxPreamble.Text = ""
         ' 
         ' InfoDlg
         ' 
         Me.AcceptButton = Me.button1
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.button1
         Me.ClientSize = New System.Drawing.Size(482, 287)
         Me.Controls.Add(Me.textBoxPreamble)
         Me.Controls.Add(Me.textBoxClass)
         Me.Controls.Add(Me.textBoxVR)
         Me.Controls.Add(Me.textBoxTransfer)
         Me.Controls.Add(Me.textBoxMetaHeader)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.label5)
         Me.Controls.Add(Me.label4)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "InfoDlg"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Dataset Info"
         '         Me.Load += New System.EventHandler(Me.InfoDlg_Load);
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub InfoDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim iod As DicomIod

         If (ds.InformationFlags And DicomDataSetFlags.LittleEndian) = DicomDataSetFlags.LittleEndian Then
            textBoxTransfer.Text = "Little-Endian"
         Else
            textBoxTransfer.Text = "Big-Endian"
         End If
         If (ds.InformationFlags And DicomDataSetFlags.ExplicitVR) = DicomDataSetFlags.ExplicitVR Then
            textBoxVR.Text = "Explicit"
         Else
            textBoxVR.Text = "Implicit"
         End If

         iod = DicomIodTable.Instance.FindClass(ds.InformationClass)
         If iod Is Nothing Then
            textBoxClass.Text = String.Format("Unknown class {0}", ds.InformationClass)
         Else
            textBoxClass.Text = iod.Name
         End If

         If (ds.InformationFlags And DicomDataSetFlags.MetaHeaderPresent) = DicomDataSetFlags.MetaHeaderPresent Then
            Dim enc As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding()

            textBoxMetaHeader.Text = "Present"
            Dim preamble As Byte() = ds.GetPreamble(255)
            textBoxPreamble.Text = enc.GetString(preamble)
         Else
            textBoxMetaHeader.Text = "Absent"
         End If
      End Sub
   End Class
End Namespace
