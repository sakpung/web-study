' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Annotations

''' <summary>
''' Summary description for AnnotationsSaveFormatDialog.
''' </summary>
Public Class AnnotationsSaveFormatDialog : Inherits System.Windows.Forms.Form
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _btnCancel As System.Windows.Forms.Button
   Private _gbNonTiff As System.Windows.Forms.GroupBox
   Private _rbSerialize As System.Windows.Forms.RadioButton
   Private _gbTiff As System.Windows.Forms.GroupBox
   Private WithEvents _rbTiffTags As System.Windows.Forms.RadioButton
   Private WithEvents _rbNoTiffTags As System.Windows.Forms.RadioButton
   Private _gbTag As System.Windows.Forms.GroupBox
   Private _rbTagWang As System.Windows.Forms.RadioButton
   Private _rbTagLEAD As System.Windows.Forms.RadioButton
   Private _rbTagSerialize As System.Windows.Forms.RadioButton
   Private _rbXml As System.Windows.Forms.RadioButton
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.Container = Nothing

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
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._gbNonTiff = New System.Windows.Forms.GroupBox()
      Me._rbXml = New System.Windows.Forms.RadioButton()
      Me._rbSerialize = New System.Windows.Forms.RadioButton()
      Me._gbTiff = New System.Windows.Forms.GroupBox()
      Me._gbTag = New System.Windows.Forms.GroupBox()
      Me._rbTagWang = New System.Windows.Forms.RadioButton()
      Me._rbTagLEAD = New System.Windows.Forms.RadioButton()
      Me._rbTagSerialize = New System.Windows.Forms.RadioButton()
      Me._rbNoTiffTags = New System.Windows.Forms.RadioButton()
      Me._rbTiffTags = New System.Windows.Forms.RadioButton()
      Me._gbNonTiff.SuspendLayout()
      Me._gbTiff.SuspendLayout()
      Me._gbTag.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(480, 24)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 2
      Me._btnOk.Text = "OK"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(480, 56)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 3
      Me._btnCancel.Text = "Cancel"
      ' 
      ' _gbNonTiff
      ' 
      Me._gbNonTiff.Controls.Add(Me._rbXml)
      Me._gbNonTiff.Controls.Add(Me._rbSerialize)
      Me._gbNonTiff.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbNonTiff.Location = New System.Drawing.Point(16, 16)
      Me._gbNonTiff.Name = "_gbNonTiff"
      Me._gbNonTiff.Size = New System.Drawing.Size(448, 100)
      Me._gbNonTiff.TabIndex = 0
      Me._gbNonTiff.TabStop = False
      Me._gbNonTiff.Text = "When saving non TIFF files (Objects are saved in ""FileName"".ann):"
      ' 
      ' _rbXml
      ' 
      Me._rbXml.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbXml.Location = New System.Drawing.Point(24, 55)
      Me._rbXml.Name = "_rbXml"
      Me._rbXml.Size = New System.Drawing.Size(392, 24)
      Me._rbXml.TabIndex = 3
      Me._rbXml.Text = "XML Format (Compatible with LEADTOOLS Win32)"
      ' 
      ' _rbSerialize
      ' 
      Me._rbSerialize.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbSerialize.Location = New System.Drawing.Point(24, 32)
      Me._rbSerialize.Name = "_rbSerialize"
      Me._rbSerialize.Size = New System.Drawing.Size(392, 24)
      Me._rbSerialize.TabIndex = 0
      Me._rbSerialize.Text = "Serialize Format (Not compatible with LEADTOOLS Win32 annotations)"
      ' 
      ' _gbTiff
      ' 
      Me._gbTiff.Controls.Add(Me._gbTag)
      Me._gbTiff.Controls.Add(Me._rbNoTiffTags)
      Me._gbTiff.Controls.Add(Me._rbTiffTags)
      Me._gbTiff.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbTiff.Location = New System.Drawing.Point(16, 131)
      Me._gbTiff.Name = "_gbTiff"
      Me._gbTiff.Size = New System.Drawing.Size(448, 264)
      Me._gbTiff.TabIndex = 1
      Me._gbTiff.TabStop = False
      Me._gbTiff.Text = "When saving TIFF files:"
      ' 
      ' _gbTag
      ' 
      Me._gbTag.Controls.Add(Me._rbTagWang)
      Me._gbTag.Controls.Add(Me._rbTagLEAD)
      Me._gbTag.Controls.Add(Me._rbTagSerialize)
      Me._gbTag.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbTag.Location = New System.Drawing.Point(24, 72)
      Me._gbTag.Name = "_gbTag"
      Me._gbTag.Size = New System.Drawing.Size(408, 128)
      Me._gbTag.TabIndex = 2
      Me._gbTag.TabStop = False
      Me._gbTag.Text = "TIFF tag format:"
      ' 
      ' _rbTagWang
      ' 
      Me._rbTagWang.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbTagWang.Location = New System.Drawing.Point(24, 88)
      Me._rbTagWang.Name = "_rbTagWang"
      Me._rbTagWang.Size = New System.Drawing.Size(368, 24)
      Me._rbTagWang.TabIndex = 2
      Me._rbTagWang.Text = "Wang tag (Compatible with LEADTOOLS Win32)"
      ' 
      ' _rbTagLEAD
      ' 
      Me._rbTagLEAD.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbTagLEAD.Location = New System.Drawing.Point(24, 56)
      Me._rbTagLEAD.Name = "_rbTagLEAD"
      Me._rbTagLEAD.Size = New System.Drawing.Size(368, 24)
      Me._rbTagLEAD.TabIndex = 1
      Me._rbTagLEAD.Text = "LEAD tag (Compatible with LEADTOOLS Win32 annotations)"
      ' 
      ' _rbTagSerialize
      ' 
      Me._rbTagSerialize.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbTagSerialize.Location = New System.Drawing.Point(24, 24)
      Me._rbTagSerialize.Name = "_rbTagSerialize"
      Me._rbTagSerialize.Size = New System.Drawing.Size(368, 24)
      Me._rbTagSerialize.TabIndex = 0
      Me._rbTagSerialize.Text = "Serialize tag (Not compatible with LEADTOOLS Win32 annotations)"
      ' 
      ' _rbNoTiffTags
      ' 
      Me._rbNoTiffTags.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbNoTiffTags.Location = New System.Drawing.Point(24, 224)
      Me._rbNoTiffTags.Name = "_rbNoTiffTags"
      Me._rbNoTiffTags.Size = New System.Drawing.Size(392, 24)
      Me._rbNoTiffTags.TabIndex = 1
      Me._rbNoTiffTags.Text = "Do not save as a TIFF tag (Use the same format as in non TIFF files)"
      ' 
      ' _rbTiffTags
      ' 
      Me._rbTiffTags.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbTiffTags.Location = New System.Drawing.Point(24, 32)
      Me._rbTiffTags.Name = "_rbTiffTags"
      Me._rbTiffTags.Size = New System.Drawing.Size(392, 24)
      Me._rbTiffTags.TabIndex = 0
      Me._rbTiffTags.Text = "Save as a TIFF tag (Objects are embedded in the TIFF file)"
      ' 
      ' AnnotationsSaveFormatDialog
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(570, 408)
      Me.Controls.Add(Me._gbTiff)
      Me.Controls.Add(Me._gbNonTiff)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AnnotationsSaveFormatDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Annotations Save Format"
      Me._gbNonTiff.ResumeLayout(False)
      Me._gbTiff.ResumeLayout(False)
      Me._gbTag.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
#End Region

   Public SaveFormat As AnnCodecsFormat
   Public TiffTags As Boolean
   Public TagFormat As AnnCodecsTagFormat

   Private Sub AnnotationsSaveFormatDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

      _rbSerialize.Checked = (SaveFormat = AnnCodecsFormat.Serialize)
      _rbXml.Checked = (SaveFormat = AnnCodecsFormat.Xml)

      _rbTiffTags.Checked = TiffTags
      _rbNoTiffTags.Checked = Not TiffTags

      _rbTagSerialize.Checked = (TagFormat = AnnCodecsTagFormat.Serialize)
      _rbTagLEAD.Checked = (TagFormat = AnnCodecsTagFormat.Tiff)
      _rbTagWang.Checked = (TagFormat = AnnCodecsTagFormat.Wang)

      UpdateControls()
   End Sub

   Private Sub _rbTiffTags_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _rbTiffTags.CheckedChanged
      UpdateControls()
   End Sub

   Private Sub _rbNoTiffTags_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _rbNoTiffTags.CheckedChanged
      UpdateControls()
   End Sub

   Private Sub UpdateControls()
      _gbTag.Enabled = _rbTiffTags.Checked
   End Sub

   Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
      If _rbSerialize.Checked Then
         SaveFormat = AnnCodecsFormat.Serialize
      ElseIf _rbXml.Checked Then
         SaveFormat = AnnCodecsFormat.Xml
      End If

      TiffTags = _rbTiffTags.Checked

      If _rbTagSerialize.Checked Then
         TagFormat = AnnCodecsTagFormat.Serialize
      ElseIf _rbTagLEAD.Checked Then
         TagFormat = AnnCodecsTagFormat.Tiff
      ElseIf _rbTagWang.Checked Then
         TagFormat = AnnCodecsTagFormat.Wang
      End If
   End Sub
End Class
