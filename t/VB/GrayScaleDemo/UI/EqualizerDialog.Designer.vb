﻿
Partial Class EqualizerDialog
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
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
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbOptions = New System.Windows.Forms.GroupBox()
      Me._cbColorSpace = New System.Windows.Forms.ComboBox()
      Me._lblColorSpace = New System.Windows.Forms.Label()
      Me._gbOptions.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(201, 41)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 5
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(201, 11)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 4
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._cbColorSpace)
      Me._gbOptions.Controls.Add(Me._lblColorSpace)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(1, 3)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Size = New System.Drawing.Size(180, 83)
      Me._gbOptions.TabIndex = 3
      Me._gbOptions.TabStop = False
      ' 
      ' _cbColorSpace
      ' 
      Me._cbColorSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbColorSpace.FormattingEnabled = True
      Me._cbColorSpace.Location = New System.Drawing.Point(14, 53)
      Me._cbColorSpace.Margin = New System.Windows.Forms.Padding(2)
      Me._cbColorSpace.Name = "_cbColorSpace"
      Me._cbColorSpace.Size = New System.Drawing.Size(152, 21)
      Me._cbColorSpace.TabIndex = 1
      ' 
      ' _lblColorSpace
      ' 
      Me._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblColorSpace.Location = New System.Drawing.Point(14, 23)
      Me._lblColorSpace.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblColorSpace.Name = "_lblColorSpace"
      Me._lblColorSpace.Size = New System.Drawing.Size(65, 21)
      Me._lblColorSpace.TabIndex = 0
      Me._lblColorSpace.Text = "Color Space"
      Me._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' EqualizerDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(276, 96)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gbOptions)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "EqualizerDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Equalizer"
      Me._gbOptions.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _cbColorSpace As System.Windows.Forms.ComboBox
   Private _lblColorSpace As System.Windows.Forms.Label
End Class