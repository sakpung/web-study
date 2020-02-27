Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class ImageInformationDialog
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
         Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Original Format:")
         Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Size:")
         Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Image Size:")
         Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Resolution:")
         Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Bits/Pixel:")
         Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Bytes/Line:")
         Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Data Size:")
         Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("View Perspective:")
         Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Order:")
         Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Has Region:")
         Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Compression:")
         Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Memory:")
         Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Signed:")
         Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Gray Scale Mode:")
         Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Low Bit:")
         Dim ListViewItem16 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("High Bit:")
         Me._btnOk = New System.Windows.Forms.Button
         Me._lblPage = New System.Windows.Forms.Label
         Me._btnPagePrevious = New System.Windows.Forms.Button
         Me._btnPageFirst = New System.Windows.Forms.Button
         Me._btnPageLast = New System.Windows.Forms.Button
         Me._btnPageNext = New System.Windows.Forms.Button
         Me._lvInfo = New System.Windows.Forms.ListView
         Me._chItem = New System.Windows.Forms.ColumnHeader
         Me._chValue = New System.Windows.Forms.ColumnHeader
         Me._btnPalette = New System.Windows.Forms.Button
         Me.SuspendLayout()
         '
         '_btnOk
         '
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(316, 15)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(68, 22)
         Me._btnOk.TabIndex = 7
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         '
         '_lblPage
         '
         Me._lblPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblPage.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblPage.Location = New System.Drawing.Point(64, 15)
         Me._lblPage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblPage.Name = "_lblPage"
         Me._lblPage.Size = New System.Drawing.Size(166, 22)
         Me._lblPage.TabIndex = 2
         Me._lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         '_btnPagePrevious
         '
         Me._btnPagePrevious.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnPagePrevious.Location = New System.Drawing.Point(36, 15)
         Me._btnPagePrevious.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnPagePrevious.Name = "_btnPagePrevious"
         Me._btnPagePrevious.Size = New System.Drawing.Size(28, 22)
         Me._btnPagePrevious.TabIndex = 1
         Me._btnPagePrevious.Text = "<"
         Me._btnPagePrevious.UseVisualStyleBackColor = True
         '
         '_btnPageFirst
         '
         Me._btnPageFirst.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnPageFirst.Location = New System.Drawing.Point(8, 15)
         Me._btnPageFirst.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnPageFirst.Name = "_btnPageFirst"
         Me._btnPageFirst.Size = New System.Drawing.Size(28, 22)
         Me._btnPageFirst.TabIndex = 0
         Me._btnPageFirst.Text = "|<"
         Me._btnPageFirst.UseVisualStyleBackColor = True
         '
         '_btnPageLast
         '
         Me._btnPageLast.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnPageLast.Location = New System.Drawing.Point(260, 15)
         Me._btnPageLast.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnPageLast.Name = "_btnPageLast"
         Me._btnPageLast.Size = New System.Drawing.Size(28, 22)
         Me._btnPageLast.TabIndex = 4
         Me._btnPageLast.Text = ">|"
         Me._btnPageLast.UseVisualStyleBackColor = True
         '
         '_btnPageNext
         '
         Me._btnPageNext.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnPageNext.Location = New System.Drawing.Point(231, 15)
         Me._btnPageNext.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnPageNext.Name = "_btnPageNext"
         Me._btnPageNext.Size = New System.Drawing.Size(28, 22)
         Me._btnPageNext.TabIndex = 3
         Me._btnPageNext.Text = ">"
         Me._btnPageNext.UseVisualStyleBackColor = True
         '
         '_lvInfo
         '
         Me._lvInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._chItem, Me._chValue})
         Me._lvInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
         Me._lvInfo.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15, ListViewItem16})
         Me._lvInfo.Location = New System.Drawing.Point(10, 41)
         Me._lvInfo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._lvInfo.Name = "_lvInfo"
         Me._lvInfo.Size = New System.Drawing.Size(278, 206)
         Me._lvInfo.TabIndex = 5
         Me._lvInfo.UseCompatibleStateImageBehavior = False
         Me._lvInfo.View = System.Windows.Forms.View.Details
         '
         '_chItem
         '
         Me._chItem.Text = "Item"
         Me._chItem.Width = 114
         '
         '_chValue
         '
         Me._chValue.Text = "Value"
         Me._chValue.Width = 192
         '
         '_btnPalette
         '
         Me._btnPalette.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnPalette.Location = New System.Drawing.Point(12, 253)
         Me._btnPalette.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnPalette.Name = "_btnPalette"
         Me._btnPalette.Size = New System.Drawing.Size(100, 21)
         Me._btnPalette.TabIndex = 6
         Me._btnPalette.Text = "Palette..."
         Me._btnPalette.UseVisualStyleBackColor = True
         '
         'ImageInformationDialog
         '
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnOk
         Me.ClientSize = New System.Drawing.Size(393, 281)
         Me.Controls.Add(Me._btnPalette)
         Me.Controls.Add(Me._lvInfo)
         Me.Controls.Add(Me._btnPageNext)
         Me.Controls.Add(Me._btnPageLast)
         Me.Controls.Add(Me._btnPageFirst)
         Me.Controls.Add(Me._btnPagePrevious)
         Me.Controls.Add(Me._lblPage)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ImageInformationDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Image Information"
         Me.ResumeLayout(False)

      End Sub

	  #End Region

	  Private _btnOk As System.Windows.Forms.Button
	  Private _lblPage As System.Windows.Forms.Label
	  Private WithEvents _btnPagePrevious As System.Windows.Forms.Button
	  Private WithEvents _btnPageFirst As System.Windows.Forms.Button
	  Private WithEvents _btnPageLast As System.Windows.Forms.Button
	  Private WithEvents _btnPageNext As System.Windows.Forms.Button
	  Private _lvInfo As System.Windows.Forms.ListView
	  Private WithEvents _btnPalette As System.Windows.Forms.Button
	  Private _chItem As System.Windows.Forms.ColumnHeader
	  Private _chValue As System.Windows.Forms.ColumnHeader
   End Class
End Namespace