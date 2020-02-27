Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class PaletteDialog
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
		 Me._lblPaletteInfo = New System.Windows.Forms.Label()
		 Me._lblCurrentColor = New System.Windows.Forms.Label()
		 Me._btnClose = New System.Windows.Forms.Button()
		 Me._pnlPalette = New System.Windows.Forms.Panel()
		 Me.SuspendLayout()
		 ' 
		 ' _lblPaletteInfo
		 ' 
		 Me._lblPaletteInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		 Me._lblPaletteInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblPaletteInfo.Location = New System.Drawing.Point(15, 9)
		 Me._lblPaletteInfo.Name = "_lblPaletteInfo"
		 Me._lblPaletteInfo.Size = New System.Drawing.Size(615, 27)
		 Me._lblPaletteInfo.TabIndex = 0
		 Me._lblPaletteInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		 ' 
		 ' _lblCurrentColor
		 ' 
		 Me._lblCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		 Me._lblCurrentColor.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblCurrentColor.Location = New System.Drawing.Point(15, 46)
		 Me._lblCurrentColor.Name = "_lblCurrentColor"
		 Me._lblCurrentColor.Size = New System.Drawing.Size(615, 27)
		 Me._lblCurrentColor.TabIndex = 1
		 Me._lblCurrentColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		 ' 
		 ' _btnClose
		 ' 
		 Me._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnClose.Location = New System.Drawing.Point(278, 600)
		 Me._btnClose.Name = "_btnClose"
		 Me._btnClose.Size = New System.Drawing.Size(90, 27)
		 Me._btnClose.TabIndex = 3
		 Me._btnClose.Text = "Close"
		 Me._btnClose.UseVisualStyleBackColor = True
		 ' 
		 ' _pnlPalette
		 ' 
		 Me._pnlPalette.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		 Me._pnlPalette.Location = New System.Drawing.Point(14, 83)
		 Me._pnlPalette.Name = "_pnlPalette"
		 Me._pnlPalette.Size = New System.Drawing.Size(615, 489)
		 Me._pnlPalette.TabIndex = 2
'		 Me._pnlPalette.MouseMove += New System.Windows.Forms.MouseEventHandler(Me._pnlPalette_MouseMove);
'		 Me._pnlPalette.Paint += New System.Windows.Forms.PaintEventHandler(Me._pnlPalette_Paint);
		 ' 
		 ' PaletteDialog
		 ' 
		 Me.AcceptButton = Me._btnClose
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnClose
		 Me.ClientSize = New System.Drawing.Size(643, 638)
		 Me.Controls.Add(Me._pnlPalette)
		 Me.Controls.Add(Me._btnClose)
		 Me.Controls.Add(Me._lblCurrentColor)
		 Me.Controls.Add(Me._lblPaletteInfo)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "PaletteDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Palette"
'		 Me.Load += New System.EventHandler(Me.PaletteDialog_Load);
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _lblPaletteInfo As System.Windows.Forms.Label
	  Private _lblCurrentColor As System.Windows.Forms.Label
	  Private _btnClose As System.Windows.Forms.Button
	  Private WithEvents _pnlPalette As System.Windows.Forms.Panel
   End Class
End Namespace