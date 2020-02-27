Namespace OcrDemo.DocumentInfoControl
   Partial Class DocumentInfoControl
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

#Region "Component Designer generated code"

      ''' <summary> 
      ''' Required method for Designer support - do not modify 
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Dim listViewItem1 As New System.Windows.Forms.ListViewItem(New String() {"Type", "None"}, -1)
         Dim listViewItem2 As New System.Windows.Forms.ListViewItem(New String() {"Pages Count", "0"}, -1)
         Me._titleLabel = New System.Windows.Forms.Label()
         Me.columnHeaderProperty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me.columnHeaderValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._lvOcrDocumentInfo = New System.Windows.Forms.ListView()
         Me.SuspendLayout()
         ' 
         ' _titleLabel
         ' 
         Me._titleLabel.Dock = System.Windows.Forms.DockStyle.Top
         Me._titleLabel.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me._titleLabel.Location = New System.Drawing.Point(0, 0)
         Me._titleLabel.Name = "_titleLabel"
         Me._titleLabel.Size = New System.Drawing.Size(180, 13)
         Me._titleLabel.TabIndex = 2
         Me._titleLabel.Text = "OCR Document Information"
         Me._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' columnHeaderProperty
         ' 
         Me.columnHeaderProperty.Text = "Property"
         Me.columnHeaderProperty.Width = 108
         ' 
         ' columnHeaderValue
         ' 
         Me.columnHeaderValue.Text = "Value"
         Me.columnHeaderValue.Width = 67
         ' 
         ' _lvOcrDocumentInfo
         ' 
         Me._lvOcrDocumentInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeaderProperty, Me.columnHeaderValue})
         Me._lvOcrDocumentInfo.Dock = System.Windows.Forms.DockStyle.Fill
         Me._lvOcrDocumentInfo.FullRowSelect = True
         Me._lvOcrDocumentInfo.GridLines = True
         Me._lvOcrDocumentInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
         Me._lvOcrDocumentInfo.Items.AddRange(New System.Windows.Forms.ListViewItem() {listViewItem1, listViewItem2})
         Me._lvOcrDocumentInfo.Location = New System.Drawing.Point(0, 13)
         Me._lvOcrDocumentInfo.Name = "_lvOcrDocumentInfo"
         Me._lvOcrDocumentInfo.Size = New System.Drawing.Size(180, 339)
         Me._lvOcrDocumentInfo.TabIndex = 3
         Me._lvOcrDocumentInfo.UseCompatibleStateImageBehavior = False
         Me._lvOcrDocumentInfo.View = System.Windows.Forms.View.Details
         ' 
         ' DocumentInfoControl
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._lvOcrDocumentInfo)
         Me.Controls.Add(Me._titleLabel)
         Me.Name = "DocumentInfoControl"
         Me.Size = New System.Drawing.Size(180, 352)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _titleLabel As System.Windows.Forms.Label
      Private columnHeaderProperty As System.Windows.Forms.ColumnHeader
      Private columnHeaderValue As System.Windows.Forms.ColumnHeader
      Private _lvOcrDocumentInfo As System.Windows.Forms.ListView
   End Class
End Namespace