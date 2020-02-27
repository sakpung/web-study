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
   ''' Summary description for ValueRepresentationDlg.
   ''' </summary>
   Public Class ValueRepresentationDlg : Inherits System.Windows.Forms.Form
      Private button1 As System.Windows.Forms.Button
      Private columnHeader1 As System.Windows.Forms.ColumnHeader
      Private columnHeader2 As System.Windows.Forms.ColumnHeader
      Private columnHeader3 As System.Windows.Forms.ColumnHeader
      Private columnHeader4 As System.Windows.Forms.ColumnHeader
      Private columnHeader5 As System.Windows.Forms.ColumnHeader
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private listViewVR As System.Windows.Forms.ListView

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
         Me.listViewVR = New System.Windows.Forms.ListView()
         Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader3 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader4 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader5 = New System.Windows.Forms.ColumnHeader()
         Me.button1 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' listViewVR
         ' 
         Me.listViewVR.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4, Me.columnHeader5})
         Me.listViewVR.FullRowSelect = True
         Me.listViewVR.GridLines = True
         Me.listViewVR.Location = New System.Drawing.Point(8, 8)
         Me.listViewVR.Name = "listViewVR"
         Me.listViewVR.Size = New System.Drawing.Size(408, 216)
         Me.listViewVR.TabIndex = 0
         Me.listViewVR.UseCompatibleStateImageBehavior = False
         Me.listViewVR.View = System.Windows.Forms.View.Details
         ' 
         ' columnHeader1
         ' 
         Me.columnHeader1.Text = "Code"
         Me.columnHeader1.Width = 50
         ' 
         ' columnHeader2
         ' 
         Me.columnHeader2.Text = "Name"
         Me.columnHeader2.Width = 120
         ' 
         ' columnHeader3
         ' 
         Me.columnHeader3.Text = "Length"
         Me.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
         Me.columnHeader3.Width = 72
         ' 
         ' columnHeader4
         ' 
         Me.columnHeader4.Text = "Unit Size"
         Me.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
         Me.columnHeader4.Width = 72
         ' 
         ' columnHeader5
         ' 
         Me.columnHeader5.Text = "Restriction"
         Me.columnHeader5.Width = 72
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button1.Location = New System.Drawing.Point(176, 232)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(75, 23)
         Me.button1.TabIndex = 1
         Me.button1.Text = "&Close"
         ' 
         ' ValueRepresentationDlg
         ' 
         Me.AcceptButton = Me.button1
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.button1
         Me.ClientSize = New System.Drawing.Size(426, 263)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.listViewVR)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ValueRepresentationDlg"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Value Respresentation (VR)"
         '            Me.Load += New System.EventHandler(Me.ValueRepresentationDlg_Load);
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub ValueRepresentationDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim vr As DicomVR = Nothing

         vr = DicomVRTable.Instance.GetFirst()
         Do While Not vr Is Nothing
            Dim item As ListViewItem

            item = listViewVR.Items.Add(vr.Code.ToString())
            item.SubItems.Add(vr.Name)
            item.SubItems.Add(vr.Length.ToString())
            item.SubItems.Add(vr.UnitSize.ToString())
            item.SubItems.Add(vr.Restriction.ToString())
            vr = DicomVRTable.Instance.GetNext(vr)
         Loop
      End Sub
   End Class
End Namespace
