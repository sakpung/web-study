Imports Microsoft.VisualBasic
Imports System
Namespace OcrZonesRubberBandDemo
   Public Partial Class SetResolution
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
		 Me._gbSetRes = New System.Windows.Forms.GroupBox()
		 Me._txtYRes = New System.Windows.Forms.TextBox()
		 Me._lblYRes = New System.Windows.Forms.Label()
		 Me._txtXRes = New System.Windows.Forms.TextBox()
		 Me._lblXRes = New System.Windows.Forms.Label()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._gbSetRes.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _gbSetRes
		 ' 
		 Me._gbSetRes.Controls.Add(Me._txtYRes)
		 Me._gbSetRes.Controls.Add(Me._lblYRes)
		 Me._gbSetRes.Controls.Add(Me._txtXRes)
		 Me._gbSetRes.Controls.Add(Me._lblXRes)
		 Me._gbSetRes.Location = New System.Drawing.Point(12, 12)
		 Me._gbSetRes.Name = "_gbSetRes"
		 Me._gbSetRes.Size = New System.Drawing.Size(200, 78)
		 Me._gbSetRes.TabIndex = 0
		 Me._gbSetRes.TabStop = False
		 ' 
		 ' _txtYRes
		 ' 
		 Me._txtYRes.Location = New System.Drawing.Point(82, 43)
		 Me._txtYRes.Name = "_txtYRes"
		 Me._txtYRes.Size = New System.Drawing.Size(100, 20)
		 Me._txtYRes.TabIndex = 4
'		 Me._txtYRes.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._txtYRes_KeyPress);
'		 Me._txtYRes.TextChanged += New System.EventHandler(Me._txtYRes_TextChanged);
		 ' 
		 ' _lblYRes
		 ' 
		 Me._lblYRes.AutoSize = True
		 Me._lblYRes.Location = New System.Drawing.Point(6, 43)
		 Me._lblYRes.Name = "_lblYRes"
		 Me._lblYRes.Size = New System.Drawing.Size(70, 13)
		 Me._lblYRes.TabIndex = 4
		 Me._lblYRes.Text = "Y Resolution:"
		 ' 
		 ' _txtXRes
		 ' 
		 Me._txtXRes.Location = New System.Drawing.Point(82, 14)
		 Me._txtXRes.Name = "_txtXRes"
		 Me._txtXRes.Size = New System.Drawing.Size(100, 20)
		 Me._txtXRes.TabIndex = 3
'		 Me._txtXRes.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._txtXRes_KeyPress);
'		 Me._txtXRes.TextChanged += New System.EventHandler(Me._txtXRes_TextChanged);
		 ' 
		 ' _lblXRes
		 ' 
		 Me._lblXRes.AutoSize = True
		 Me._lblXRes.Location = New System.Drawing.Point(6, 19)
		 Me._lblXRes.Name = "_lblXRes"
		 Me._lblXRes.Size = New System.Drawing.Size(70, 13)
		 Me._lblXRes.TabIndex = 3
		 Me._lblXRes.Text = "X Resolution:"
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.Location = New System.Drawing.Point(218, 26)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(75, 23)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(218, 50)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(75, 23)
		 Me._btnCancel.TabIndex = 2
		 Me._btnCancel.Text = "Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' SetResolution
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(303, 107)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._gbSetRes)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "SetResolution"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Load Resolution"
'		 Me.Load += New System.EventHandler(Me.SetResolution_Load);
		 Me._gbSetRes.ResumeLayout(False)
		 Me._gbSetRes.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _gbSetRes As System.Windows.Forms.GroupBox
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
	  Private _lblYRes As System.Windows.Forms.Label
	  Private _lblXRes As System.Windows.Forms.Label
	  Private WithEvents _txtYRes As System.Windows.Forms.TextBox
	  Private WithEvents _txtXRes As System.Windows.Forms.TextBox
   End Class
End Namespace