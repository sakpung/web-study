Imports Microsoft.VisualBasic
Imports System
Namespace DicomTranDemo
   Partial Public Class MainForm
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
            Me.groupBox1 = New System.Windows.Forms.GroupBox
            Me.label4 = New System.Windows.Forms.Label
            Me.label3 = New System.Windows.Forms.Label
            Me.label2 = New System.Windows.Forms.Label
            Me.label1 = New System.Windows.Forms.Label
            Me.groupBox2 = New System.Windows.Forms.GroupBox
            Me.cmbTransferSyntax = New System.Windows.Forms.ComboBox
            Me.J2kOptionsBtn = New System.Windows.Forms.Button
            Me.OutFile = New System.Windows.Forms.Button
            Me.InFile = New System.Windows.Forms.Button
            Me.txtQFactor = New System.Windows.Forms.TextBox
            Me.txtOutFile = New System.Windows.Forms.TextBox
            Me.txtInFile = New System.Windows.Forms.TextBox
            Me.label8 = New System.Windows.Forms.Label
            Me.label7 = New System.Windows.Forms.Label
            Me.label6 = New System.Windows.Forms.Label
            Me.label5 = New System.Windows.Forms.Label
            Me.Change = New System.Windows.Forms.Button
            Me.labelYbrFull = New System.Windows.Forms.Label
            Me.checkBoxYbrFull = New System.Windows.Forms.CheckBox
         Me.groupBox1.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.SuspendLayout()
         '
         'groupBox1
         '
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(12, 12)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(636, 157)
         Me.groupBox1.TabIndex = 0
         Me.groupBox1.TabStop = False
         '
         'label4
         '
         Me.label4.Location = New System.Drawing.Point(6, 115)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(614, 34)
         Me.label4.TabIndex = 3
         Me.label4.Text = "DICOM defines a default Transfer Syntax, the DICOM Implicit VR Little Endian Tran" & _
       "sfer Syntax (UID =""1.2.840.10008.1.2""), that shall be supported by every conform" & _
       "ant DICOM Implementation."
         '
         'label3
         '
         Me.label3.Location = New System.Drawing.Point(6, 84)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(614, 31)
         Me.label3.TabIndex = 2
         Me.label3.Text = "For a list of DICOM unique identifiers (UID) please see ""Transfer Syntax Values"" " & _
       "inside the LEADTOOLS DICOM help file or see Annex A (PS 3.6 of the DICOM Standar" & _
       "d)."
         '
         'label2
         '
         Me.label2.Location = New System.Drawing.Point(6, 66)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(614, 18)
         Me.label2.TabIndex = 1
         Me.label2.Text = "For more information about ""Transfer Syntax"", please see Section 10 (PS 3.5 of th" & _
       "e DICOM Standard)."
         '
         'label1
         '
         Me.label1.Location = New System.Drawing.Point(6, 30)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(624, 36)
         Me.label1.TabIndex = 0
         Me.label1.Text = "This is a simple demo, which shows how to change the transfer syntax of a DICOM f" & _
       "ile using LEADTOOLS. Just call the function ""ChangeTransferSyntax"" and pass it t" & _
       "he UID of the desired transfer syntax."
         '
         'groupBox2
         '
         Me.groupBox2.Controls.Add(Me.labelYbrFull)
         Me.groupBox2.Controls.Add(Me.checkBoxYbrFull)
         Me.groupBox2.Controls.Add(Me.cmbTransferSyntax)
         Me.groupBox2.Controls.Add(Me.J2kOptionsBtn)
         Me.groupBox2.Controls.Add(Me.OutFile)
         Me.groupBox2.Controls.Add(Me.InFile)
         Me.groupBox2.Controls.Add(Me.txtQFactor)
         Me.groupBox2.Controls.Add(Me.txtOutFile)
         Me.groupBox2.Controls.Add(Me.txtInFile)
         Me.groupBox2.Controls.Add(Me.label8)
         Me.groupBox2.Controls.Add(Me.label7)
         Me.groupBox2.Controls.Add(Me.label6)
         Me.groupBox2.Controls.Add(Me.label5)
         Me.groupBox2.Location = New System.Drawing.Point(12, 175)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(636, 209)
         Me.groupBox2.TabIndex = 1
         Me.groupBox2.TabStop = False
         '
         'cmbTransferSyntax
         '
         Me.cmbTransferSyntax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.cmbTransferSyntax.FormattingEnabled = True
         Me.cmbTransferSyntax.Location = New System.Drawing.Point(156, 93)
         Me.cmbTransferSyntax.Name = "cmbTransferSyntax"
         Me.cmbTransferSyntax.Size = New System.Drawing.Size(464, 21)
         Me.cmbTransferSyntax.TabIndex = 12
         '
         'J2kOptionsBtn
         '
         Me.J2kOptionsBtn.Location = New System.Drawing.Point(504, 129)
         Me.J2kOptionsBtn.Name = "J2kOptionsBtn"
         Me.J2kOptionsBtn.Size = New System.Drawing.Size(116, 23)
         Me.J2kOptionsBtn.TabIndex = 10
         Me.J2kOptionsBtn.Text = "JPEG 2000 Options"
         Me.J2kOptionsBtn.UseVisualStyleBackColor = True
         '
         'OutFile
         '
         Me.OutFile.Location = New System.Drawing.Point(582, 60)
         Me.OutFile.Name = "OutFile"
         Me.OutFile.Size = New System.Drawing.Size(38, 23)
         Me.OutFile.TabIndex = 9
         Me.OutFile.Text = "..."
         Me.OutFile.UseVisualStyleBackColor = True
         '
         'InFile
         '
         Me.InFile.Location = New System.Drawing.Point(582, 24)
         Me.InFile.Name = "InFile"
         Me.InFile.Size = New System.Drawing.Size(38, 23)
         Me.InFile.TabIndex = 8
         Me.InFile.Text = "..."
         Me.InFile.UseVisualStyleBackColor = True
         '
         'txtQFactor
         '
         Me.txtQFactor.Location = New System.Drawing.Point(444, 129)
         Me.txtQFactor.MaxLength = 3
         Me.txtQFactor.Name = "txtQFactor"
         Me.txtQFactor.Size = New System.Drawing.Size(48, 20)
         Me.txtQFactor.TabIndex = 7
         '
         'txtOutFile
         '
         Me.txtOutFile.Location = New System.Drawing.Point(156, 60)
         Me.txtOutFile.Name = "txtOutFile"
         Me.txtOutFile.Size = New System.Drawing.Size(405, 20)
         Me.txtOutFile.TabIndex = 5
         '
         'txtInFile
         '
         Me.txtInFile.Location = New System.Drawing.Point(156, 27)
         Me.txtInFile.Name = "txtInFile"
         Me.txtInFile.Size = New System.Drawing.Size(405, 20)
         Me.txtInFile.TabIndex = 4
         '
         'label8
         '
         Me.label8.AutoSize = True
         Me.label8.Location = New System.Drawing.Point(6, 134)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(419, 13)
         Me.label8.TabIndex = 3
         Me.label8.Text = "Quality factor:  0 (lossless), 2 (lossy highest quality) to 255 (lossy most compression):"
         '
         'label7
         '
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(6, 101)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(109, 13)
         Me.label7.TabIndex = 2
         Me.label7.Text = "New Transfer Syntax:"
         '
         'label6
         '
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(6, 67)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(87, 13)
         Me.label6.TabIndex = 1
         Me.label6.Text = "Output file name:"
         '
         'label5
         '
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(6, 34)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(79, 13)
         Me.label5.TabIndex = 0
         Me.label5.Text = "Input file name:"
         '
         'Change
         '
         Me.Change.Location = New System.Drawing.Point(194, 400)
         Me.Change.Name = "Change"
         Me.Change.Size = New System.Drawing.Size(299, 47)
         Me.Change.TabIndex = 2
         Me.Change.Text = "Change Transfer Syntax"
         Me.Change.UseVisualStyleBackColor = True
         '
            'labelYbrFull
            '
            Me.labelYbrFull.Location = New System.Drawing.Point(88, 168)
            Me.labelYbrFull.Name = "labelYbrFull"
            Me.labelYbrFull.Size = New System.Drawing.Size(440, 32)
            Me.labelYbrFull.TabIndex = 16
            Me.labelYbrFull.Text = "Check to store pixel data as one luminance (Y) and two chrominance planes (CB and" & _
                " CR).  Valid with uncompressed and RLE compressed transfer syntaxes."
            '
            'checkBoxYbrFull
            '
            Me.checkBoxYbrFull.AutoSize = True
            Me.checkBoxYbrFull.Location = New System.Drawing.Point(6, 168)
            Me.checkBoxYbrFull.Name = "checkBoxYbrFull"
            Me.checkBoxYbrFull.Size = New System.Drawing.Size(80, 17)
            Me.checkBoxYbrFull.TabIndex = 15
            Me.checkBoxYbrFull.Text = "YBR_FULL"
            Me.checkBoxYbrFull.UseVisualStyleBackColor = True
            '
         'MainForm
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(658, 463)
         Me.Controls.Add(Me.Change)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me.groupBox1)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Name = "MainForm"
         Me.Text = "DICOM Dotnet Change Transfer Syntax  Demo"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label4 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label1 As System.Windows.Forms.Label
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private txtQFactor As System.Windows.Forms.TextBox
      Private txtOutFile As System.Windows.Forms.TextBox
      Private txtInFile As System.Windows.Forms.TextBox
      Private label8 As System.Windows.Forms.Label
      Private label7 As System.Windows.Forms.Label
      Private label6 As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private WithEvents cmbTransferSyntax As System.Windows.Forms.ComboBox
      Private WithEvents J2kOptionsBtn As System.Windows.Forms.Button
      Private WithEvents OutFile As System.Windows.Forms.Button
      Private WithEvents InFile As System.Windows.Forms.Button
      Private WithEvents Change As System.Windows.Forms.Button
      Private WithEvents labelYbrFull As System.Windows.Forms.Label
      Private WithEvents checkBoxYbrFull As System.Windows.Forms.CheckBox
   End Class
End Namespace

