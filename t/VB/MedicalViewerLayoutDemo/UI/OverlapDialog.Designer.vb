Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
	Public Partial Class OverlapDialog
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.listBoxCells = New System.Windows.Forms.ListBox()
			Me.buttonMoveDown = New System.Windows.Forms.Button()
			Me.buttonMoveUp = New System.Windows.Forms.Button()
			Me.button3 = New System.Windows.Forms.Button()
			Me.button4 = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(13, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(32, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Cells:"
			' 
			' listBoxCells
			' 
			Me.listBoxCells.FormattingEnabled = True
			Me.listBoxCells.Location = New System.Drawing.Point(16, 30)
			Me.listBoxCells.Name = "listBoxCells"
			Me.listBoxCells.Size = New System.Drawing.Size(244, 277)
			Me.listBoxCells.TabIndex = 1
'			Me.listBoxCells.SelectedIndexChanged += New System.EventHandler(Me.listBoxCells_SelectedIndexChanged);
			' 
			' buttonMoveDown
			' 
			Me.buttonMoveDown.Enabled = False
            Me.buttonMoveDown.Image = Global.Resources.arrow_down
			Me.buttonMoveDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.buttonMoveDown.Location = New System.Drawing.Point(267, 60)
			Me.buttonMoveDown.Name = "buttonMoveDown"
			Me.buttonMoveDown.Size = New System.Drawing.Size(75, 23)
			Me.buttonMoveDown.TabIndex = 3
			Me.buttonMoveDown.Text = "Down"
			Me.buttonMoveDown.UseVisualStyleBackColor = True
'			Me.buttonMoveDown.Click += New System.EventHandler(Me.buttonMoveDown_Click);
			' 
			' buttonMoveUp
			' 
			Me.buttonMoveUp.Enabled = False
            Me.buttonMoveUp.Image = Global.Resources.arrow_up
			Me.buttonMoveUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.buttonMoveUp.Location = New System.Drawing.Point(267, 30)
			Me.buttonMoveUp.Name = "buttonMoveUp"
			Me.buttonMoveUp.Size = New System.Drawing.Size(75, 23)
			Me.buttonMoveUp.TabIndex = 2
			Me.buttonMoveUp.Text = "Up"
			Me.buttonMoveUp.UseVisualStyleBackColor = True
'			Me.buttonMoveUp.Click += New System.EventHandler(Me.buttonMoveUp_Click);
			' 
			' button3
			' 
			Me.button3.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.button3.Location = New System.Drawing.Point(266, 254)
			Me.button3.Name = "button3"
			Me.button3.Size = New System.Drawing.Size(75, 23)
			Me.button3.TabIndex = 4
			Me.button3.Text = "OK"
			Me.button3.UseVisualStyleBackColor = True
			' 
			' button4
			' 
			Me.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.button4.Location = New System.Drawing.Point(267, 283)
			Me.button4.Name = "button4"
			Me.button4.Size = New System.Drawing.Size(75, 23)
			Me.button4.TabIndex = 5
			Me.button4.Text = "Cancel"
			Me.button4.UseVisualStyleBackColor = True
			' 
			' OverlapDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(354, 318)
			Me.Controls.Add(Me.button4)
			Me.Controls.Add(Me.button3)
			Me.Controls.Add(Me.buttonMoveDown)
			Me.Controls.Add(Me.buttonMoveUp)
			Me.Controls.Add(Me.listBoxCells)
			Me.Controls.Add(Me.label1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "OverlapDialog"
			Me.RightToLeftLayout = True
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Overlap Priority"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.OverlapDialog_FormClosing);
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private WithEvents listBoxCells As System.Windows.Forms.ListBox
		Private WithEvents buttonMoveUp As System.Windows.Forms.Button
		Private WithEvents buttonMoveDown As System.Windows.Forms.Button
		Private button3 As System.Windows.Forms.Button
		Private button4 As System.Windows.Forms.Button
	End Class
End Namespace