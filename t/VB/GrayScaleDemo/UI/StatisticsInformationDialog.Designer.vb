
Partial Class ImageInformationDialog
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
      Dim listViewItem85 As New System.Windows.Forms.ListViewItem("Original Format:")
      Dim listViewItem86 As New System.Windows.Forms.ListViewItem("Size:")
      Dim listViewItem87 As New System.Windows.Forms.ListViewItem("Resolution:")
      Dim listViewItem88 As New System.Windows.Forms.ListViewItem("Bits/Pixel:")
      Dim listViewItem89 As New System.Windows.Forms.ListViewItem("Bytes/Line:")
      Dim listViewItem90 As New System.Windows.Forms.ListViewItem("Data Size:")
      Dim listViewItem91 As New System.Windows.Forms.ListViewItem("View Perspective:")
      Dim listViewItem92 As New System.Windows.Forms.ListViewItem("Order:")
      Dim listViewItem93 As New System.Windows.Forms.ListViewItem("Has Region:")
      Dim listViewItem94 As New System.Windows.Forms.ListViewItem("Compression:")
      Dim listViewItem95 As New System.Windows.Forms.ListViewItem("Memory:")
      Dim listViewItem96 As New System.Windows.Forms.ListViewItem("Signed:")
      Dim listViewItem97 As New System.Windows.Forms.ListViewItem("Gray Scale Mode:")
      Dim listViewItem98 As New System.Windows.Forms.ListViewItem("Low Bit:")
      Dim listViewItem99 As New System.Windows.Forms.ListViewItem("High Bit:")
      Dim listViewItem100 As New System.Windows.Forms.ListViewItem("Mean:")
      Dim listViewItem101 As New System.Windows.Forms.ListViewItem("Standard Deviation:")
      Dim listViewItem102 As New System.Windows.Forms.ListViewItem("Median:")
      Dim listViewItem103 As New System.Windows.Forms.ListViewItem("Minimum:")
      Dim listViewItem104 As New System.Windows.Forms.ListViewItem("Maximum")
      Dim listViewItem105 As New System.Windows.Forms.ListViewItem("Pixel Count:")
      Me._btnOK = New System.Windows.Forms.Button()
      Me._lvInfo = New System.Windows.Forms.ListView()
      Me._chItem = New System.Windows.Forms.ColumnHeader()
      Me._chValue = New System.Windows.Forms.ColumnHeader()
      Me._btnPageNext = New System.Windows.Forms.Button()
      Me._btnPageLast = New System.Windows.Forms.Button()
      Me._btnPageFirst = New System.Windows.Forms.Button()
      Me._btnPagePrevious = New System.Windows.Forms.Button()
      Me._lblPage = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      ' 
      ' _btnOK
      ' 
      Me._btnOK.Location = New System.Drawing.Point(116, 375)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(69, 22)
      Me._btnOK.TabIndex = 1
      Me._btnOK.Text = "OK"
      Me._btnOK.UseVisualStyleBackColor = True
      ' 
      ' _lvInfo
      ' 
      Me._lvInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._chItem, Me._chValue})
      Me._lvInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me._lvInfo.Items.AddRange(New System.Windows.Forms.ListViewItem() {listViewItem85, listViewItem86, listViewItem87, listViewItem88, listViewItem89, listViewItem90, _
       listViewItem91, listViewItem92, listViewItem93, listViewItem94, listViewItem95, listViewItem96, _
       listViewItem97, listViewItem98, listViewItem99, listViewItem100, listViewItem101, listViewItem102, _
       listViewItem103, listViewItem104, listViewItem105})
      Me._lvInfo.Location = New System.Drawing.Point(10, 69)
      Me._lvInfo.Margin = New System.Windows.Forms.Padding(2)
      Me._lvInfo.Name = "_lvInfo"
      Me._lvInfo.Size = New System.Drawing.Size(280, 286)
      Me._lvInfo.TabIndex = 6
      Me._lvInfo.UseCompatibleStateImageBehavior = False
      Me._lvInfo.View = System.Windows.Forms.View.Details
      ' 
      ' _chItem
      ' 
      Me._chItem.Text = "Item"
      Me._chItem.Width = 114
      ' 
      ' _chValue
      ' 
      Me._chValue.Text = "Value"
      Me._chValue.Width = 192
      ' 
      ' _btnPageNext
      ' 
      Me._btnPageNext.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnPageNext.Location = New System.Drawing.Point(233, 36)
      Me._btnPageNext.Margin = New System.Windows.Forms.Padding(2)
      Me._btnPageNext.Name = "_btnPageNext"
      Me._btnPageNext.Size = New System.Drawing.Size(28, 22)
      Me._btnPageNext.TabIndex = 10
      Me._btnPageNext.Text = ">"
      Me._btnPageNext.UseVisualStyleBackColor = True
      ' 
      ' _btnPageLast
      ' 
      Me._btnPageLast.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnPageLast.Location = New System.Drawing.Point(262, 36)
      Me._btnPageLast.Margin = New System.Windows.Forms.Padding(2)
      Me._btnPageLast.Name = "_btnPageLast"
      Me._btnPageLast.Size = New System.Drawing.Size(28, 22)
      Me._btnPageLast.TabIndex = 11
      Me._btnPageLast.Text = ">|"
      Me._btnPageLast.UseVisualStyleBackColor = True
      ' 
      ' _btnPageFirst
      ' 
      Me._btnPageFirst.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnPageFirst.Location = New System.Drawing.Point(10, 36)
      Me._btnPageFirst.Margin = New System.Windows.Forms.Padding(2)
      Me._btnPageFirst.Name = "_btnPageFirst"
      Me._btnPageFirst.Size = New System.Drawing.Size(28, 22)
      Me._btnPageFirst.TabIndex = 7
      Me._btnPageFirst.Text = "|<"
      Me._btnPageFirst.UseVisualStyleBackColor = True
      ' 
      ' _btnPagePrevious
      ' 
      Me._btnPagePrevious.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnPagePrevious.Location = New System.Drawing.Point(38, 36)
      Me._btnPagePrevious.Margin = New System.Windows.Forms.Padding(2)
      Me._btnPagePrevious.Name = "_btnPagePrevious"
      Me._btnPagePrevious.Size = New System.Drawing.Size(28, 22)
      Me._btnPagePrevious.TabIndex = 8
      Me._btnPagePrevious.Text = "<"
      Me._btnPagePrevious.UseVisualStyleBackColor = True
      ' 
      ' _lblPage
      ' 
      Me._lblPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblPage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblPage.Location = New System.Drawing.Point(66, 36)
      Me._lblPage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblPage.Name = "_lblPage"
      Me._lblPage.Size = New System.Drawing.Size(166, 22)
      Me._lblPage.TabIndex = 9
      Me._lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      ' 
      ' StatisticsInformationDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(300, 409)
      Me.Controls.Add(Me._btnPageNext)
      Me.Controls.Add(Me._btnPageLast)
      Me.Controls.Add(Me._btnPageFirst)
      Me.Controls.Add(Me._btnPagePrevious)
      Me.Controls.Add(Me._lblPage)
      Me.Controls.Add(Me._lvInfo)
      Me.Controls.Add(Me._btnOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "StatisticsInformationDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Image Information"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _btnOK As System.Windows.Forms.Button
   Private _lvInfo As System.Windows.Forms.ListView
   Private _chItem As System.Windows.Forms.ColumnHeader
   Private _chValue As System.Windows.Forms.ColumnHeader
   Private WithEvents _btnPageNext As System.Windows.Forms.Button
   Private WithEvents _btnPageLast As System.Windows.Forms.Button
   Private WithEvents _btnPageFirst As System.Windows.Forms.Button
   Private WithEvents _btnPagePrevious As System.Windows.Forms.Button
   Private _lblPage As System.Windows.Forms.Label
End Class