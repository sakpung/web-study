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
   ''' Summary description for ContextGroupDlg.
   ''' </summary>
   Public Class ContextGroupDlg : Inherits System.Windows.Forms.Form
      Private label1 As System.Windows.Forms.Label
      Private WithEvents comboBoxID As System.Windows.Forms.ComboBox
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private button1 As System.Windows.Forms.Button
      Private columnHeader1 As System.Windows.Forms.ColumnHeader
      Private columnHeader2 As System.Windows.Forms.ColumnHeader
      Private columnHeader3 As System.Windows.Forms.ColumnHeader
      Private columnHeader4 As System.Windows.Forms.ColumnHeader
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private listViewConcepts As System.Windows.Forms.ListView
      Private textBoxType As System.Windows.Forms.TextBox
      Private textBoxVersion As System.Windows.Forms.TextBox
      Private textBoxName As System.Windows.Forms.TextBox


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
         Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ContextGroupDlg))
         Me.label1 = New System.Windows.Forms.Label()
         Me.comboBoxID = New System.Windows.Forms.ComboBox()
         Me.textBoxName = New System.Windows.Forms.TextBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.textBoxType = New System.Windows.Forms.TextBox()
         Me.label4 = New System.Windows.Forms.Label()
         Me.textBoxVersion = New System.Windows.Forms.TextBox()
         Me.listViewConcepts = New System.Windows.Forms.ListView()
         Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader3 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader4 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
         Me.button1 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(8, 16)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(24, 16)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Id:"
         ' 
         ' comboBoxID
         ' 
         Me.comboBoxID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBoxID.Location = New System.Drawing.Point(8, 32)
         Me.comboBoxID.Name = "comboBoxID"
         Me.comboBoxID.Size = New System.Drawing.Size(184, 21)
         Me.comboBoxID.TabIndex = 1
         '         Me.comboBoxID.SelectedIndexChanged += New System.EventHandler(Me.comboBoxID_SelectedIndexChanged);
         ' 
         ' textBoxName
         ' 
         Me.textBoxName.Location = New System.Drawing.Point(208, 32)
         Me.textBoxName.Name = "textBoxName"
         Me.textBoxName.ReadOnly = True
         Me.textBoxName.Size = New System.Drawing.Size(320, 20)
         Me.textBoxName.TabIndex = 2
         Me.textBoxName.Text = ""
         ' 
         ' label2
         ' 
         Me.label2.Location = New System.Drawing.Point(216, 8)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(100, 16)
         Me.label2.TabIndex = 3
         Me.label2.Text = "Name:"
         ' 
         ' label3
         ' 
         Me.label3.Location = New System.Drawing.Point(8, 64)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(100, 16)
         Me.label3.TabIndex = 4
         Me.label3.Text = "Type:"
         ' 
         ' textBoxType
         ' 
         Me.textBoxType.Location = New System.Drawing.Point(8, 80)
         Me.textBoxType.Name = "textBoxType"
         Me.textBoxType.ReadOnly = True
         Me.textBoxType.Size = New System.Drawing.Size(184, 20)
         Me.textBoxType.TabIndex = 5
         Me.textBoxType.Text = ""
         ' 
         ' label4
         ' 
         Me.label4.Location = New System.Drawing.Point(208, 64)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(100, 16)
         Me.label4.TabIndex = 6
         Me.label4.Text = "Version:"
         ' 
         ' textBoxVersion
         ' 
         Me.textBoxVersion.Location = New System.Drawing.Point(208, 80)
         Me.textBoxVersion.Name = "textBoxVersion"
         Me.textBoxVersion.ReadOnly = True
         Me.textBoxVersion.Size = New System.Drawing.Size(320, 20)
         Me.textBoxVersion.TabIndex = 7
         Me.textBoxVersion.Text = ""
         ' 
         ' listViewConcepts
         ' 
         Me.listViewConcepts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader3, Me.columnHeader4, Me.columnHeader2})
         Me.listViewConcepts.FullRowSelect = True
         Me.listViewConcepts.GridLines = True
         Me.listViewConcepts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewConcepts.Location = New System.Drawing.Point(8, 112)
         Me.listViewConcepts.Name = "listViewConcepts"
         Me.listViewConcepts.Size = New System.Drawing.Size(536, 200)
         Me.listViewConcepts.TabIndex = 8
         Me.listViewConcepts.View = System.Windows.Forms.View.Details
         ' 
         ' columnHeader1
         ' 
         Me.columnHeader1.Text = "Coding Scheme Designator"
         Me.columnHeader1.Width = 150
         ' 
         ' columnHeader3
         ' 
         Me.columnHeader3.Text = "Code Value"
         Me.columnHeader3.Width = 80
         ' 
         ' columnHeader4
         ' 
         Me.columnHeader4.Text = "Code Meaning"
         Me.columnHeader4.Width = 150
         ' 
         ' columnHeader2
         ' 
         Me.columnHeader2.Text = "Coding Scheme Version"
         Me.columnHeader2.Width = 125
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button1.Location = New System.Drawing.Point(244, 320)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 9
         Me.button1.Text = "&Close"
         ' 
         ' ContextGroupDlg
         ' 
         Me.AcceptButton = Me.button1
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.button1
         Me.ClientSize = New System.Drawing.Size(562, 349)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.listViewConcepts)
         Me.Controls.Add(Me.textBoxVersion)
         Me.Controls.Add(Me.textBoxType)
         Me.Controls.Add(Me.textBoxName)
         Me.Controls.Add(Me.label4)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.comboBoxID)
         Me.Controls.Add(Me.label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ContextGroupDlg"
         Me.ShowInTaskbar = False
         Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Context Groups"
         '         Me.Closing += New System.ComponentModel.CancelEventHandler(Me.ContextGroupDlg_Closing);
         '         Me.Load += New System.EventHandler(Me.ContextGroupDlg_Load);
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub ContextGroupDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim group As DicomContextGroup
         Dim g As String = Nothing

         ' DicomContextGroupTable.Instance.Reset()
         ' DicomContextGroupTable.Instance.Load(g)

         group = DicomContextGroupTable.Instance.GetFirst()
         Do While Not group Is Nothing
            comboBoxID.Items.Add(group.ContextIdentifier)
            group = DicomContextGroupTable.Instance.GetNext(group)
         Loop
         If comboBoxID.Items.Count > 0 Then
            comboBoxID.SelectedIndex = 0
         End If
      End Sub

      Private Sub ContextGroupDlg_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
         ' DicomContextGroupTable.Instance.Reset()
      End Sub

      Private Sub comboBoxID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboBoxID.SelectedIndexChanged
         If comboBoxID.SelectedIndex <> -1 Then
            Dim group As DicomContextGroup
            Dim concept As DicomCodedConcept
            Dim cid As DicomContextIdentifierType = CType(comboBoxID.SelectedItem, DicomContextIdentifierType)

            group = DicomContextGroupTable.Instance.Find(cid)
            listViewConcepts.Items.Clear()

            If group.ContextGroupVersion.GetType() Is GetType(DicomDateTimeValue) Then
               Dim [date] As DicomDateTimeValue = CType(group.ContextGroupVersion, DicomDateTimeValue)

               textBoxVersion.Text = [date].Year.ToString("0000") + [date].Month.ToString("00") + [date].Day.ToString()
            Else
               textBoxVersion.Text = ""
            End If

            If group.IsExtensible Then
               textBoxType.Text = "Extensible"
            Else
               textBoxType.Text = "Non Extensible"
            End If
            textBoxName.Text = group.Name

            concept = DicomContextGroupTable.Instance.GetFirstCodedConcept(group)
            Do While Not concept Is Nothing
               Dim item As ListViewItem

               item = listViewConcepts.Items.Add(concept.CodingSchemeDesignator)
               item.SubItems.Add(concept.CodeValue)
               item.SubItems.Add(concept.CodeMeaning)
               item.SubItems.Add(concept.CodingSchemeVersion)
               concept = DicomContextGroupTable.Instance.GetNextCodedConcept(concept)
            Loop
         End If
      End Sub
   End Class
End Namespace
