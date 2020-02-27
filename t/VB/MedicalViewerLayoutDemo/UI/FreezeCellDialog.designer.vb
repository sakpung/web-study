Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
   Partial Public Class FreezeCellDialog
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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.cellIndexText = New MedicalViewerLayoutDemo.NumericTextBox()
         Me.cellIndexLabel = New System.Windows.Forms.Label()
         Me.applyToSingleRadio = New System.Windows.Forms.RadioButton()
         Me.applyToSelectedRadio = New System.Windows.Forms.RadioButton()
         Me.applyToAllRadio = New System.Windows.Forms.RadioButton()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.freezeCombo = New System.Windows.Forms.ComboBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.applyButton = New System.Windows.Forms.Button()
         Me.cancelButton = New System.Windows.Forms.Button()
         Me.okButton = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me.cellIndexText)
         Me.groupBox1.Controls.Add(Me.cellIndexLabel)
         Me.groupBox1.Controls.Add(Me.applyToSingleRadio)
         Me.groupBox1.Controls.Add(Me.applyToSelectedRadio)
         Me.groupBox1.Controls.Add(Me.applyToAllRadio)
         Me.groupBox1.Location = New System.Drawing.Point(6, 3)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(189, 129)
         Me.groupBox1.TabIndex = 0
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "&Freezing option"
         ' 
         ' cellIndexText
         ' 
         Me.cellIndexText.Enabled = False
         Me.cellIndexText.Location = New System.Drawing.Point(71, 94)
         Me.cellIndexText.MaximumAllowed = 1000
         Me.cellIndexText.MinimumAllowed = -1000
         Me.cellIndexText.Name = "cellIndexText"
         Me.cellIndexText.Size = New System.Drawing.Size(47, 20)
         Me.cellIndexText.TabIndex = 4
         ' 
         ' cellIndexLabel
         ' 
         Me.cellIndexLabel.AutoSize = True
         Me.cellIndexLabel.Enabled = False
         Me.cellIndexLabel.Location = New System.Drawing.Point(13, 97)
         Me.cellIndexLabel.Name = "cellIndexLabel"
         Me.cellIndexLabel.Size = New System.Drawing.Size(52, 13)
         Me.cellIndexLabel.TabIndex = 3
         Me.cellIndexLabel.Text = "&Cell index"
         ' 
         ' applyToSingleRadio
         ' 
         Me.applyToSingleRadio.AutoSize = True
         Me.applyToSingleRadio.Location = New System.Drawing.Point(16, 65)
         Me.applyToSingleRadio.Name = "applyToSingleRadio"
         Me.applyToSingleRadio.Size = New System.Drawing.Size(121, 17)
         Me.applyToSingleRadio.TabIndex = 2
         Me.applyToSingleRadio.TabStop = True
         Me.applyToSingleRadio.Text = "App&ly to a single cell"
         Me.applyToSingleRadio.UseVisualStyleBackColor = True
         '		 Me.applyToSingleRadio.CheckedChanged += New System.EventHandler(Me.applyToSingleRadio_CheckedChanged);
         ' 
         ' applyToSelectedRadio
         ' 
         Me.applyToSelectedRadio.AutoSize = True
         Me.applyToSelectedRadio.Location = New System.Drawing.Point(16, 41)
         Me.applyToSelectedRadio.Name = "applyToSelectedRadio"
         Me.applyToSelectedRadio.Size = New System.Drawing.Size(136, 17)
         Me.applyToSelectedRadio.TabIndex = 1
         Me.applyToSelectedRadio.TabStop = True
         Me.applyToSelectedRadio.Text = "A&pply to selected cell(s)"
         Me.applyToSelectedRadio.UseVisualStyleBackColor = True
         ' 
         ' applyToAllRadio
         ' 
         Me.applyToAllRadio.AutoSize = True
         Me.applyToAllRadio.Location = New System.Drawing.Point(16, 19)
         Me.applyToAllRadio.Name = "applyToAllRadio"
         Me.applyToAllRadio.Size = New System.Drawing.Size(100, 17)
         Me.applyToAllRadio.TabIndex = 0
         Me.applyToAllRadio.TabStop = True
         Me.applyToAllRadio.Text = "&Apply to all cells"
         Me.applyToAllRadio.UseVisualStyleBackColor = True
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me.freezeCombo)
         Me.groupBox2.Controls.Add(Me.label2)
         Me.groupBox2.Location = New System.Drawing.Point(6, 133)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(189, 60)
         Me.groupBox2.TabIndex = 1
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "&Freeze/Unfreeze"
         ' 
         ' freezeCombo
         ' 
         Me.freezeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.freezeCombo.FormattingEnabled = True
         Me.freezeCombo.Items.AddRange(New Object() {"Freeze", "Unfreeze"})
         Me.freezeCombo.Location = New System.Drawing.Point(63, 24)
         Me.freezeCombo.Name = "freezeCombo"
         Me.freezeCombo.Size = New System.Drawing.Size(99, 21)
         Me.freezeCombo.TabIndex = 1
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(13, 27)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(37, 13)
         Me.label2.TabIndex = 0
         Me.label2.Text = "&Action"
         ' 
         ' applyButton
         ' 
         Me.applyButton.Location = New System.Drawing.Point(137, 201)
         Me.applyButton.Name = "applyButton"
         Me.applyButton.Size = New System.Drawing.Size(58, 29)
         Me.applyButton.TabIndex = 14
         Me.applyButton.Text = "App&ly"
         Me.applyButton.UseVisualStyleBackColor = True
         '		 Me.applyButton.Click += New System.EventHandler(Me.applyButton_Click);
         ' 
         ' cancelButton
         ' 
         Me.cancelButton.Location = New System.Drawing.Point(72, 201)
         Me.cancelButton.Name = "cancelButton"
         Me.cancelButton.Size = New System.Drawing.Size(58, 29)
         Me.cancelButton.TabIndex = 13
         Me.cancelButton.Text = "Canc&el"
         Me.cancelButton.UseVisualStyleBackColor = True
         ' 
         ' okButton
         ' 
         Me.okButton.Location = New System.Drawing.Point(6, 201)
         Me.okButton.Name = "okButton"
         Me.okButton.Size = New System.Drawing.Size(58, 29)
         Me.okButton.TabIndex = 12
         Me.okButton.Text = "&OK"
         Me.okButton.UseVisualStyleBackColor = True
         '		 Me.okButton.Click += New System.EventHandler(Me.okButton_Click);
         ' 
         ' FreezeCellDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(203, 238)
         Me.Controls.Add(Me.applyButton)
         Me.Controls.Add(Me.cancelButton)
         Me.Controls.Add(Me.okButton)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "FreezeCellDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Freeze Cell"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private groupBox1 As System.Windows.Forms.GroupBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private WithEvents applyToSingleRadio As System.Windows.Forms.RadioButton
      Private applyToSelectedRadio As System.Windows.Forms.RadioButton
      Private applyToAllRadio As System.Windows.Forms.RadioButton
      Private WithEvents applyButton As System.Windows.Forms.Button
      Private cancelButton As System.Windows.Forms.Button
      Private WithEvents okButton As System.Windows.Forms.Button
      Private cellIndexText As NumericTextBox
      Private cellIndexLabel As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private freezeCombo As System.Windows.Forms.ComboBox
   End Class
End Namespace