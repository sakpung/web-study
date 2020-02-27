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
   ''' Summary description for UniqueIdentifierDlg.
   ''' </summary>
   Public Class UniqueIdentifierDlg : Inherits System.Windows.Forms.Form
      Private button1 As System.Windows.Forms.Button
      Private columnHeader1 As System.Windows.Forms.ColumnHeader
      Private columnHeader2 As System.Windows.Forms.ColumnHeader
      Private columnHeader3 As System.Windows.Forms.ColumnHeader
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private listViewUID As System.Windows.Forms.ListView


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
         Me.button1 = New System.Windows.Forms.Button()
         Me.listViewUID = New System.Windows.Forms.ListView()
         Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader3 = New System.Windows.Forms.ColumnHeader()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button1.Location = New System.Drawing.Point(289, 272)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(72, 24)
         Me.button1.TabIndex = 1
         Me.button1.Text = "&Close"
         ' 
         ' listViewUID
         ' 
         Me.listViewUID.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3})
         Me.listViewUID.FullRowSelect = True
         Me.listViewUID.GridLines = True
         Me.listViewUID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewUID.Location = New System.Drawing.Point(12, 8)
         Me.listViewUID.Name = "listViewUID"
         Me.listViewUID.Size = New System.Drawing.Size(628, 256)
         Me.listViewUID.TabIndex = 2
         Me.listViewUID.View = System.Windows.Forms.View.Details
         ' 
         ' columnHeader1
         ' 
         Me.columnHeader1.Text = "Code"
         Me.columnHeader1.Width = 180
         ' 
         ' columnHeader2
         ' 
         Me.columnHeader2.Text = "Name"
         Me.columnHeader2.Width = 320
         ' 
         ' columnHeader3
         ' 
         Me.columnHeader3.Text = "Type"
         Me.columnHeader3.Width = 100
         ' 
         ' UniqueIdentifierDlg
         ' 
         Me.AcceptButton = Me.button1
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.button1
         Me.ClientSize = New System.Drawing.Size(650, 301)
         Me.Controls.Add(Me.listViewUID)
         Me.Controls.Add(Me.button1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "UniqueIdentifierDlg"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Unique IdentifierDlg (UID)"
         '         Me.Load += New System.EventHandler(Me.UniqueIdentifierDlg_Load);
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub UniqueIdentifierDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim uid As DicomUid = Nothing

         uid = DicomUidTable.Instance.GetFirst()
         Do While Not uid Is Nothing
            Dim item As ListViewItem

            item = listViewUID.Items.Add(uid.Code)
            item.SubItems.Add(uid.Name)
            item.SubItems.Add(uid.Type.ToString())
            uid = DicomUidTable.Instance.GetNext(uid)
         Loop
      End Sub

      Private Function GetUIDType(ByVal type As Integer) As String
         'DicomUIDTypes uid = (DicomUIDTypes)type;
         'string t;

         't = uid.ToString();
         't = t.Remove(0,t.LastIndexOf("_")+1);

         'return t;
         Return ""
      End Function
   End Class
End Namespace
