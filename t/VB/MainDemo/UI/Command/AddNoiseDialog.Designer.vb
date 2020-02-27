Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Effects

Namespace MainDemo
   Public Partial Class AddNoiseDialog
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
         Me._gbOptions = New System.Windows.Forms.GroupBox
         Me._lblRange = New System.Windows.Forms.Label
         Me._cbChannel = New System.Windows.Forms.ComboBox
         Me._numRange = New System.Windows.Forms.NumericUpDown
         Me._lblChannel = New System.Windows.Forms.Label
         Me._btnOk = New System.Windows.Forms.Button
         Me._btnCancel = New System.Windows.Forms.Button
         Me._gbOptions.SuspendLayout()
         CType(Me._numRange, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         '_gbOptions
         '
         Me._gbOptions.Controls.Add(Me._lblRange)
         Me._gbOptions.Controls.Add(Me._cbChannel)
         Me._gbOptions.Controls.Add(Me._numRange)
         Me._gbOptions.Controls.Add(Me._lblChannel)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(8, 7)
         Me._gbOptions.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbOptions.Size = New System.Drawing.Size(208, 76)
         Me._gbOptions.TabIndex = 0
         Me._gbOptions.TabStop = False
         '
         '_lblRange
         '
         Me._lblRange.AutoSize = True
         Me._lblRange.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblRange.Location = New System.Drawing.Point(14, 15)
         Me._lblRange.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblRange.Name = "_lblRange"
         Me._lblRange.Size = New System.Drawing.Size(38, 13)
         Me._lblRange.TabIndex = 0
         Me._lblRange.Text = "Range"
         '
         '_cbChannel
         '
         Me._cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbChannel.FormattingEnabled = True
         Me._cbChannel.Location = New System.Drawing.Point(86, 45)
         Me._cbChannel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._cbChannel.Name = "_cbChannel"
         Me._cbChannel.Size = New System.Drawing.Size(110, 21)
         Me._cbChannel.TabIndex = 3
         '
         '_numRange
         '
         Me._numRange.Location = New System.Drawing.Point(86, 15)
         Me._numRange.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._numRange.Name = "_numRange"
         Me._numRange.Size = New System.Drawing.Size(108, 20)
         Me._numRange.TabIndex = 1
         Me._numRange.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '
         '_lblChannel
         '
         Me._lblChannel.AutoSize = True
         Me._lblChannel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblChannel.Location = New System.Drawing.Point(14, 45)
         Me._lblChannel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblChannel.Name = "_lblChannel"
         Me._lblChannel.Size = New System.Drawing.Size(46, 13)
         Me._lblChannel.TabIndex = 2
         Me._lblChannel.Text = "Channel"
         '
         '_btnOk
         '
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(238, 15)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(68, 22)
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         '
         '_btnCancel
         '
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(238, 45)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(68, 22)
         Me._btnCancel.TabIndex = 1
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         'AddNoiseDialog
         '
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(316, 94)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._gbOptions)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "AddNoiseDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "AddNoiseDialog"
         Me._gbOptions.ResumeLayout(False)
         Me._gbOptions.PerformLayout()
         CType(Me._numRange, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

	  #End Region

	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _cbChannel As System.Windows.Forms.ComboBox
	  Private WithEvents _numRange As System.Windows.Forms.NumericUpDown
	  Private _lblChannel As System.Windows.Forms.Label
	  Private _lblRange As System.Windows.Forms.Label
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
   End Class
End Namespace