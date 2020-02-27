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

Imports Leadtools.DicomDemos
Imports Leadtools.Dicom

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for ElementTagDlg.
   ''' </summary>
   Public Class ElementTagDlg : Inherits System.Windows.Forms.Form
      Private listViewTag As System.Windows.Forms.ListView
      Private columnHeader1 As System.Windows.Forms.ColumnHeader
      Private button1 As System.Windows.Forms.Button
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private columnHeader2 As System.Windows.Forms.ColumnHeader
      Private columnHeader3 As System.Windows.Forms.ColumnHeader
      Private columnHeader4 As System.Windows.Forms.ColumnHeader
      Private columnHeader5 As System.Windows.Forms.ColumnHeader
      Private columnHeader6 As System.Windows.Forms.ColumnHeader


      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

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
         Me.listViewTag = New System.Windows.Forms.ListView()
         Me.columnHeader6 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader3 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader4 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader5 = New System.Windows.Forms.ColumnHeader()
         Me.button1 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' listViewTag
         ' 
         Me.listViewTag.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader6, Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4, Me.columnHeader5})
         Me.listViewTag.FullRowSelect = True
         Me.listViewTag.GridLines = True
         Me.listViewTag.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewTag.Location = New System.Drawing.Point(8, 8)
         Me.listViewTag.Name = "listViewTag"
         Me.listViewTag.Size = New System.Drawing.Size(600, 264)
         Me.listViewTag.TabIndex = 0
         Me.listViewTag.View = System.Windows.Forms.View.Details
         ' 
         ' columnHeader6
         ' 
         Me.columnHeader6.Text = "Name"
         Me.columnHeader6.Width = 250
         ' 
         ' columnHeader1
         ' 
         Me.columnHeader1.Text = "Code"
         Me.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
         Me.columnHeader1.Width = 65
         ' 
         ' columnHeader2
         ' 
         Me.columnHeader2.Text = "Mask"
         ' 
         ' columnHeader3
         ' 
         Me.columnHeader3.Text = "MinVM"
         Me.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
         ' 
         ' columnHeader4
         ' 
         Me.columnHeader4.Text = "MaxVM"
         Me.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
         ' 
         ' columnHeader5
         ' 
         Me.columnHeader5.Text = "DivideVM"
         Me.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button1.Location = New System.Drawing.Point(272, 280)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 1
         Me.button1.Text = "&Close"
         ' 
         ' ElementTagDlg
         ' 
         Me.AcceptButton = Me.button1
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.button1
         Me.ClientSize = New System.Drawing.Size(618, 309)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.listViewTag)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ElementTagDlg"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Element Tags"
         '         Me.Load += New System.EventHandler(Me.ElementTagDlg_Load);
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub ElementTagDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim tag As DicomTag = DicomTagTable.Instance.GetFirst()

         Do While Not tag Is Nothing
            Dim item As ListViewItem

            item = listViewTag.Items.Add(tag.Name)
            item.SubItems.Add(String.Format("{0:x4}:{1:x4}", Utils.GetGroup(CLng(tag.Code)), Utils.GetElement(CLng(tag.Code))))
            item.SubItems.Add(tag.Mask.ToString("X"))
            item.SubItems.Add(tag.MinVM.ToString())
            item.SubItems.Add(tag.MaxVM.ToString())
            item.SubItems.Add(tag.VMDivider.ToString())
            tag = DicomTagTable.Instance.GetNext(tag)
         Loop
      End Sub
   End Class
End Namespace
