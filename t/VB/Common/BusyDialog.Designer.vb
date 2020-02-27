Imports Microsoft.VisualBasic
Imports System
Namespace FormsDemo
   Public Partial Class BusyDialog
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
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BusyDialog))
		 Me._lblFormName = New System.Windows.Forms.Label()
		 Me._lblLabel1 = New System.Windows.Forms.Label()
		 Me._lblLabel2 = New System.Windows.Forms.Label()
		 Me._progressBar = New System.Windows.Forms.ProgressBar()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me.SuspendLayout()
		 ' 
		 ' _lblFormName
		 ' 
		 Me._lblFormName.AutoSize = True
		 Me._lblFormName.Location = New System.Drawing.Point(12, 9)
		 Me._lblFormName.Name = "_lblFormName"
		 Me._lblFormName.Size = New System.Drawing.Size(0, 13)
		 Me._lblFormName.TabIndex = 0
		 ' 
		 ' _lblLabel1
		 ' 
		 Me._lblLabel1.AutoSize = True
		 Me._lblLabel1.Location = New System.Drawing.Point(12, 33)
		 Me._lblLabel1.Name = "_lblLabel1"
		 Me._lblLabel1.Size = New System.Drawing.Size(0, 13)
		 Me._lblLabel1.TabIndex = 1
		 ' 
		 ' _lblLabel2
		 ' 
		 Me._lblLabel2.AutoSize = True
		 Me._lblLabel2.Location = New System.Drawing.Point(12, 57)
		 Me._lblLabel2.Name = "_lblLabel2"
		 Me._lblLabel2.Size = New System.Drawing.Size(0, 13)
		 Me._lblLabel2.TabIndex = 2
		 ' 
		 ' _progressBar
		 ' 
		 Me._progressBar.Location = New System.Drawing.Point(4, 87)
		 Me._progressBar.Name = "_progressBar"
		 Me._progressBar.Size = New System.Drawing.Size(511, 23)
		 Me._progressBar.TabIndex = 3
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnOk.Location = New System.Drawing.Point(231, 116)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(57, 25)
		 Me._btnOk.TabIndex = 4
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
		 Me._btnOk.Visible = False
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(231, 116)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(57, 25)
		 Me._btnCancel.TabIndex = 5
		 Me._btnCancel.Text = "Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 Me._btnCancel.Visible = False
'		 Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		 ' 
		 ' BusyDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(517, 150)
		 Me.ControlBox = False
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._progressBar)
		 Me.Controls.Add(Me._lblLabel2)
		 Me.Controls.Add(Me._lblLabel1)
		 Me.Controls.Add(Me._lblFormName)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "BusyDialog"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Recognizing and Processing..."
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _lblFormName As System.Windows.Forms.Label
	  Private _lblLabel1 As System.Windows.Forms.Label
	  Private _lblLabel2 As System.Windows.Forms.Label
	  Private _progressBar As System.Windows.Forms.ProgressBar
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
   End Class
End Namespace