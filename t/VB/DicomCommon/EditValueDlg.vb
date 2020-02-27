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

Namespace Leadtools.DicomDemos
   ''' <summary>
   ''' Summary description for EditValueDlg.
   ''' </summary>
   Public Class EditValueDlg : Inherits System.Windows.Forms.Form
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private labelVR As System.Windows.Forms.Label
      Private labelFormat As System.Windows.Forms.Label
      Private label1 As System.Windows.Forms.Label
      Public WithEvents listBoxValues As System.Windows.Forms.ListBox
      Private textBoxValue As System.Windows.Forms.TextBox
      Private WithEvents buttonBefore As System.Windows.Forms.Button
      Private WithEvents buttonAfter As System.Windows.Forms.Button
      Private WithEvents buttonDelete As System.Windows.Forms.Button
      Private WithEvents buttonModify As System.Windows.Forms.Button
      Private buttonOK As System.Windows.Forms.Button
      Private buttonCancel As System.Windows.Forms.Button

      Private ds As DicomDataSet
      Private element As DicomElement

      Public Sub New(ByVal ds As DicomDataSet, ByVal element As DicomElement)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         Me.ds = ds
         Me.element = element
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
         Me.labelVR = New System.Windows.Forms.Label()
         Me.labelFormat = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.listBoxValues = New System.Windows.Forms.ListBox()
         Me.textBoxValue = New System.Windows.Forms.TextBox()
         Me.buttonBefore = New System.Windows.Forms.Button()
         Me.buttonAfter = New System.Windows.Forms.Button()
         Me.buttonDelete = New System.Windows.Forms.Button()
         Me.buttonModify = New System.Windows.Forms.Button()
         Me.buttonOK = New System.Windows.Forms.Button()
         Me.buttonCancel = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' labelVR
         ' 
         Me.labelVR.Location = New System.Drawing.Point(8, 8)
         Me.labelVR.Name = "labelVR"
         Me.labelVR.Size = New System.Drawing.Size(392, 16)
         Me.labelVR.TabIndex = 0
         Me.labelVR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' labelFormat
         ' 
         Me.labelFormat.Location = New System.Drawing.Point(8, 24)
         Me.labelFormat.Name = "labelFormat"
         Me.labelFormat.Size = New System.Drawing.Size(392, 48)
         Me.labelFormat.TabIndex = 1
         Me.labelFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(8, 72)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(100, 16)
         Me.label1.TabIndex = 2
         Me.label1.Text = "Values:"
         ' 
         ' listBoxValues
         ' 
         Me.listBoxValues.Location = New System.Drawing.Point(8, 88)
         Me.listBoxValues.Name = "listBoxValues"
         Me.listBoxValues.Size = New System.Drawing.Size(296, 238)
         Me.listBoxValues.TabIndex = 3
         '         Me.listBoxValues.SelectedIndexChanged += New System.EventHandler(Me.listBoxValues_SelectedIndexChanged);
         ' 
         ' textBoxValue
         ' 
         Me.textBoxValue.Location = New System.Drawing.Point(8, 336)
         Me.textBoxValue.Name = "textBoxValue"
         Me.textBoxValue.Size = New System.Drawing.Size(296, 20)
         Me.textBoxValue.TabIndex = 4
         Me.textBoxValue.Text = ""
         ' 
         ' buttonBefore
         ' 
         Me.buttonBefore.Location = New System.Drawing.Point(312, 88)
         Me.buttonBefore.Name = "buttonBefore"
         Me.buttonBefore.Size = New System.Drawing.Size(80, 23)
         Me.buttonBefore.TabIndex = 5
         Me.buttonBefore.Text = "Insert Before"
         '         Me.buttonBefore.Click += New System.EventHandler(Me.buttonBefore_Click);
         ' 
         ' buttonAfter
         ' 
         Me.buttonAfter.Location = New System.Drawing.Point(312, 120)
         Me.buttonAfter.Name = "buttonAfter"
         Me.buttonAfter.Size = New System.Drawing.Size(80, 23)
         Me.buttonAfter.TabIndex = 6
         Me.buttonAfter.Text = "Insert After"
         '         Me.buttonAfter.Click += New System.EventHandler(Me.buttonAfter_Click);
         ' 
         ' buttonDelete
         ' 
         Me.buttonDelete.Enabled = False
         Me.buttonDelete.Location = New System.Drawing.Point(312, 152)
         Me.buttonDelete.Name = "buttonDelete"
         Me.buttonDelete.Size = New System.Drawing.Size(80, 23)
         Me.buttonDelete.TabIndex = 7
         Me.buttonDelete.Text = "Delete"
         ' 
         ' buttonModify
         ' 
         Me.buttonModify.Enabled = False
         Me.buttonModify.Location = New System.Drawing.Point(312, 184)
         Me.buttonModify.Name = "buttonModify"
         Me.buttonModify.Size = New System.Drawing.Size(80, 23)
         Me.buttonModify.TabIndex = 8
         Me.buttonModify.Text = "Modify"
         '         Me.buttonModify.Click += New System.EventHandler(Me.buttonModify_Click);
         ' 
         ' buttonOK
         ' 
         Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.buttonOK.Location = New System.Drawing.Point(312, 303)
         Me.buttonOK.Name = "buttonOK"
         Me.buttonOK.Size = New System.Drawing.Size(80, 23)
         Me.buttonOK.TabIndex = 9
         Me.buttonOK.Text = "&OK"
         ' 
         ' buttonCancel
         ' 
         Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.buttonCancel.Location = New System.Drawing.Point(312, 333)
         Me.buttonCancel.Name = "buttonCancel"
         Me.buttonCancel.Size = New System.Drawing.Size(80, 23)
         Me.buttonCancel.TabIndex = 10
         Me.buttonCancel.Text = "&Cancel"
         ' 
         ' EditValueDlg
         ' 
         Me.AcceptButton = Me.buttonOK
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.buttonCancel
         Me.ClientSize = New System.Drawing.Size(402, 367)
         Me.Controls.Add(Me.buttonCancel)
         Me.Controls.Add(Me.buttonOK)
         Me.Controls.Add(Me.buttonModify)
         Me.Controls.Add(Me.buttonDelete)
         Me.Controls.Add(Me.buttonAfter)
         Me.Controls.Add(Me.buttonBefore)
         Me.Controls.Add(Me.textBoxValue)
         Me.Controls.Add(Me.listBoxValues)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.labelFormat)
         Me.Controls.Add(Me.labelVR)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "EditValueDlg"
         Me.ShowInTaskbar = False
         Me.Text = "Edit Value"
         '         Me.Load += New System.EventHandler(Me.EditValueDlg_Load);
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub EditValueDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Init()
      End Sub

      Private Sub Init()
         Dim strInfo As String
         Dim values As String() = Nothing
         Dim vr As DicomVR
         Dim tag As DicomTag

         strInfo = ds.GetConvertValue(element)
         If Not strInfo Is Nothing Then
            values = strInfo.Split("\"c)
            If Not values Is Nothing Then
               If values.GetLength(0) > 0 Then
                  For Each value As String In values
                     listBoxValues.Items.Add(value)
                  Next value

                  If listBoxValues.Items.Count > 0 Then
                     listBoxValues.SelectedIndex = 0
                  End If
               End If
            End If
         End If

         vr = DicomVRTable.Instance.Find(element.VR)
         tag = DicomTagTable.Instance.Find(element.Tag)

         strInfo = "Value Representation: " & vr.Name
         labelVR.Text = strInfo

         Select Case element.VR
            Case DicomVRType.OB, DicomVRType.UN
               strInfo = "Hexadecimal"

            Case DicomVRType.SS, DicomVRType.US, DicomVRType.OW, DicomVRType.SL, DicomVRType.IS, DicomVRType.UL
               strInfo = "Integer"

            Case DicomVRType.AT
               strInfo = "Group:Element" & Constants.vbCrLf & "(Group and Element should be hexadecimal words)"

            Case DicomVRType.FD, DicomVRType.FL, DicomVRType.DS
               strInfo = "Float"

            Case DicomVRType.CS, DicomVRType.SH, DicomVRType.LO, DicomVRType.AE, DicomVRType.LT, DicomVRType.ST, DicomVRType.UI, DicomVRType.UT, DicomVRType.PN
               strInfo = "String"

            Case DicomVRType.AS
               strInfo = "Number Reference" & Constants.vbCrLf & "(Reference = 'days' or 'weeks' or 'months' or 'years')"

            Case DicomVRType.DA
               strInfo = "MM/DD/YYYY" & Constants.vbCrLf & "(MM=Month, DD=Day, YYYY=Year)"

            Case DicomVRType.DT
               strInfo = "CC MM/DD/YYYY HH:MM:SS.FFFFFF&OOOO" & Constants.vbCrLf & "(CC=Centry, MM=Month, DD=Day, YYYY=Year)" & Constants.vbCrLf & "(HH=Hours, MM=Minutes,SS=Seconds, "
               strInfo &= "FFFFFF=Fractional Second, OOOO=Offset from Coordinated Universial Time)"

            Case DicomVRType.TM
               strInfo = "HH:MM:SS.FFFF" & Constants.vbCrLf & "(HH=Hours, MM=Minutes, SS=Seconds, FFFF=Fractional Second)"

            Case Else
               strInfo = ""

         End Select

         If Not tag Is Nothing Then
            buttonBefore.Enabled = tag.MaxVM >= 1 OrElse tag.MaxVM = -1
            buttonAfter.Enabled = tag.MaxVM >= 1 OrElse tag.MaxVM = -1
         Else
            textBoxValue.Enabled = False
            buttonBefore.Enabled = False
            buttonAfter.Enabled = False
            buttonDelete.Enabled = False
            buttonModify.Enabled = False
            buttonOK.Enabled = False
            buttonCancel.Enabled = True
         End If

         labelFormat.Text = strInfo
      End Sub

      Private Sub buttonBefore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonBefore.Click
         If textBoxValue.Text.Length > 0 Then
            If listBoxValues.SelectedIndex = -1 Then
               listBoxValues.Items.Add(textBoxValue.Text)
            Else
               listBoxValues.Items.Insert(listBoxValues.SelectedIndex, textBoxValue.Text)
            End If
         End If
      End Sub

      Private Sub buttonAfter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonAfter.Click
         If textBoxValue.Text.Length > 0 Then
            If listBoxValues.SelectedIndex = -1 Then
               listBoxValues.Items.Add(textBoxValue.Text)
            Else
               listBoxValues.Items.Insert(listBoxValues.SelectedIndex + 1, textBoxValue.Text)
            End If
         End If
      End Sub

      Private Sub buttonDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonDelete.Click,buttonDelete.Click
         Try
            If listBoxValues.Items.Count > 0 AndAlso (listBoxValues.SelectedIndex <> -1) Then
               listBoxValues.Items.RemoveAt(listBoxValues.SelectedIndex)
            End If
         Catch
         End Try
      End Sub

      Private Sub buttonModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonModify.Click
         If textBoxValue.Enabled = False Then
            MessageBox.Show("The value for this element can't be edited.")
            Exit Sub
         End If
         listBoxValues.Items(listBoxValues.SelectedIndex) = textBoxValue.Text
      End Sub

      Private Sub listBoxValues_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBoxValues.SelectedIndexChanged
         If Not listBoxValues.SelectedItem Is Nothing Then
            textBoxValue.Text = listBoxValues.SelectedItem.ToString()
         Else
            textBoxValue.Text = ""
         End If

         buttonModify.Enabled = (Not listBoxValues.SelectedItem Is Nothing)
         buttonDelete.Enabled = (Not listBoxValues.SelectedItem Is Nothing)
      End Sub
   End Class
End Namespace
