Namespace SvgDemo
   Partial Class DocumentInfo
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
         Dim listViewItem1 As New System.Windows.Forms.ListViewItem("File Name:")
         Dim listViewItem2 As New System.Windows.Forms.ListViewItem("Page Number:")
         Dim listViewItem3 As New System.Windows.Forms.ListViewItem("Total Pages:")
         Dim listViewItem4 As New System.Windows.Forms.ListViewItem("Is Flat:")
         Dim listViewItem5 As New System.Windows.Forms.ListViewItem("Is Render Optimized:")
         Dim listViewItem6 As New System.Windows.Forms.ListViewItem("")
         Dim listViewItem7 As New System.Windows.Forms.ListViewItem("Bounds:")
         Dim listViewItem8 As New System.Windows.Forms.ListViewItem("Is Valid:")
         Dim listViewItem9 As New System.Windows.Forms.ListViewItem("Is Trimmed:")
         Dim listViewItem10 As New System.Windows.Forms.ListViewItem("Resolution:")
         Dim listViewItem11 As New System.Windows.Forms.ListViewItem("Bounds:")
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentInfo))
         Me._closeButton = New System.Windows.Forms.Button()
         Me._documentInfo = New System.Windows.Forms.ListView()
         Me._chItems = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._chValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me.SuspendLayout()
         ' 
         ' _closeButton
         ' 
         Me._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._closeButton.Location = New System.Drawing.Point(134, 234)
         Me._closeButton.Name = "_closeButton"
         Me._closeButton.Size = New System.Drawing.Size(75, 23)
         Me._closeButton.TabIndex = 1
         Me._closeButton.Text = "Close"
         Me._closeButton.UseVisualStyleBackColor = True
         ' 
         ' _documentInfo
         ' 
         Me._documentInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._chItems, Me._chValue})
         Me._documentInfo.Items.AddRange(New System.Windows.Forms.ListViewItem() {listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, _
          listViewItem7, listViewItem8, listViewItem9, listViewItem10, listViewItem11})
         Me._documentInfo.Location = New System.Drawing.Point(10, 12)
         Me._documentInfo.Name = "_documentInfo"
         Me._documentInfo.Size = New System.Drawing.Size(322, 211)
         Me._documentInfo.TabIndex = 2
         Me._documentInfo.UseCompatibleStateImageBehavior = False
         Me._documentInfo.View = System.Windows.Forms.View.Details
         ' 
         ' _chItems
         ' 
         Me._chItems.Text = "Items"
         Me._chItems.Width = 118
         ' 
         ' _chValue
         ' 
         Me._chValue.Text = "Value"
         Me._chValue.Width = 200
         ' 
         ' DocumentInfo
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._closeButton
         Me.ClientSize = New System.Drawing.Size(342, 266)
         Me.Controls.Add(Me._documentInfo)
         Me.Controls.Add(Me._closeButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "DocumentInfo"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Svg Document Information"
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _closeButton As System.Windows.Forms.Button
      Private _documentInfo As System.Windows.Forms.ListView
      Private _chItems As System.Windows.Forms.ColumnHeader
      Private _chValue As System.Windows.Forms.ColumnHeader
   End Class
End Namespace
