Imports Microsoft.VisualBasic
Imports System
Namespace DocumentCleanupDemo
   Public Partial Class SmoothTextDialog
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
		  Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SmoothTextDialog))
		  Me._gb1 = New System.Windows.Forms.GroupBox()
		  Me._rbShort = New System.Windows.Forms.RadioButton()
		  Me._rbLong = New System.Windows.Forms.RadioButton()
		  Me._tbLength = New System.Windows.Forms.TextBox()
		  Me._lblBumpNickLength = New System.Windows.Forms.Label()
		  Me._btnOk = New System.Windows.Forms.Button()
		  Me._btnCancel = New System.Windows.Forms.Button()
		  Me._gb1.SuspendLayout()
		  Me.SuspendLayout()
		  ' 
		  ' _gb1
		  ' 
		  Me._gb1.Controls.Add(Me._rbShort)
		  Me._gb1.Controls.Add(Me._rbLong)
		  Me._gb1.Controls.Add(Me._tbLength)
		  Me._gb1.Controls.Add(Me._lblBumpNickLength)
		  Me._gb1.Location = New System.Drawing.Point(12, 12)
		  Me._gb1.Name = "_gb1"
		  Me._gb1.Size = New System.Drawing.Size(213, 105)
		  Me._gb1.TabIndex = 0
		  Me._gb1.TabStop = False
		  Me._gb1.Text = "Smooth Options"
		  ' 
		  ' _rbShort
		  ' 
		  Me._rbShort.AutoSize = True
		  Me._rbShort.Location = New System.Drawing.Point(22, 75)
		  Me._rbShort.Name = "_rbShort"
		  Me._rbShort.Size = New System.Drawing.Size(147, 17)
		  Me._rbShort.TabIndex = 3
		  Me._rbShort.TabStop = True
		  Me._rbShort.Text = "Favor Short Bumps/Nicks"
		  Me._rbShort.UseVisualStyleBackColor = True
		  ' 
		  ' _rbLong
		  ' 
		  Me._rbLong.AutoSize = True
		  Me._rbLong.Location = New System.Drawing.Point(22, 52)
		  Me._rbLong.Name = "_rbLong"
		  Me._rbLong.Size = New System.Drawing.Size(146, 17)
		  Me._rbLong.TabIndex = 2
		  Me._rbLong.TabStop = True
		  Me._rbLong.Text = "Favor Long Bumps/Nicks"
		  Me._rbLong.UseVisualStyleBackColor = True
		  ' 
		  ' _tbLength
		  ' 
		  Me._tbLength.Location = New System.Drawing.Point(122, 21)
		  Me._tbLength.MaxLength = 5
		  Me._tbLength.Name = "_tbLength"
		  Me._tbLength.Size = New System.Drawing.Size(76, 20)
		  Me._tbLength.TabIndex = 1
'		  Me._tbLength.TextChanged += New System.EventHandler(Me._tbLength_TextChanged);
		  ' 
		  ' _lblBumpNickLength
		  ' 
		  Me._lblBumpNickLength.AutoSize = True
		  Me._lblBumpNickLength.Location = New System.Drawing.Point(19, 28)
		  Me._lblBumpNickLength.Name = "_lblBumpNickLength"
		  Me._lblBumpNickLength.Size = New System.Drawing.Size(97, 13)
		  Me._lblBumpNickLength.TabIndex = 0
		  Me._lblBumpNickLength.Text = "Bump/Nick Length"
		  ' 
		  ' _btnOk
		  ' 
		  Me._btnOk.Location = New System.Drawing.Point(231, 12)
		  Me._btnOk.Name = "_btnOk"
		  Me._btnOk.Size = New System.Drawing.Size(75, 23)
		  Me._btnOk.TabIndex = 1
		  Me._btnOk.Text = "OK"
		  Me._btnOk.UseVisualStyleBackColor = True
'		  Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		  ' 
		  ' _btnCancel
		  ' 
		  Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		  Me._btnCancel.Location = New System.Drawing.Point(231, 41)
		  Me._btnCancel.Name = "_btnCancel"
		  Me._btnCancel.Size = New System.Drawing.Size(75, 23)
		  Me._btnCancel.TabIndex = 2
		  Me._btnCancel.Text = "Cancel"
		  Me._btnCancel.UseVisualStyleBackColor = True
'		  Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		  ' 
		  ' SmoothTextDialog
		  ' 
		  Me.AcceptButton = Me._btnOk
		  Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		  Me.CancelButton = Me._btnCancel
		  Me.ClientSize = New System.Drawing.Size(315, 128)
		  Me.Controls.Add(Me._btnCancel)
		  Me.Controls.Add(Me._btnOk)
		  Me.Controls.Add(Me._gb1)
		  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		  Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		  Me.MaximizeBox = False
		  Me.MinimizeBox = False
		  Me.Name = "SmoothTextDialog"
		  Me.Text = "Smooth Text "
		  Me._gb1.ResumeLayout(False)
		  Me._gb1.PerformLayout()
		  Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _gb1 As System.Windows.Forms.GroupBox
	  Private _rbShort As System.Windows.Forms.RadioButton
	  Private _rbLong As System.Windows.Forms.RadioButton
	  Private WithEvents _tbLength As System.Windows.Forms.TextBox
	  Private _lblBumpNickLength As System.Windows.Forms.Label
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
   End Class
End Namespace