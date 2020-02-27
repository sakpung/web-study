Partial Class DocumentPropertiesDialog
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
      Me._okButton = New System.Windows.Forms.Button()
      Me._tabControl = New System.Windows.Forms.TabControl()
      Me._documentTabPage = New System.Windows.Forms.TabPage()
      Me._documentListView = New System.Windows.Forms.ListView()
      Me._keyColumnHeader = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
      Me._valueColumnHeader = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
      Me._metadataTabPage = New System.Windows.Forms.TabPage()
      Me._metadataListView = New System.Windows.Forms.ListView()
      Me.columnHeader1 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
      Me.columnHeader2 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
      Me._tabControl.SuspendLayout()
      Me._documentTabPage.SuspendLayout()
      Me._metadataTabPage.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _okButton
      ' 
      Me._okButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(392, 370)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 2
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      ' 
      ' _tabControl
      ' 
      Me._tabControl.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._tabControl.Controls.Add(Me._documentTabPage)
      Me._tabControl.Controls.Add(Me._metadataTabPage)
      Me._tabControl.Location = New System.Drawing.Point(12, 12)
      Me._tabControl.Name = "_tabControl"
      Me._tabControl.SelectedIndex = 0
      Me._tabControl.Size = New System.Drawing.Size(459, 356)
      Me._tabControl.TabIndex = 0
      ' 
      ' _documentTabPage
      ' 
      Me._documentTabPage.Controls.Add(Me._documentListView)
      Me._documentTabPage.Location = New System.Drawing.Point(4, 22)
      Me._documentTabPage.Name = "_documentTabPage"
      Me._documentTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._documentTabPage.Size = New System.Drawing.Size(451, 330)
      Me._documentTabPage.TabIndex = 0
      Me._documentTabPage.Text = "Document"
      Me._documentTabPage.UseVisualStyleBackColor = True
      ' 
      ' _documentListView
      ' 
      Me._documentListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._keyColumnHeader, Me._valueColumnHeader})
      Me._documentListView.Dock = System.Windows.Forms.DockStyle.Fill
      Me._documentListView.Location = New System.Drawing.Point(3, 3)
      Me._documentListView.Name = "_documentListView"
      Me._documentListView.Size = New System.Drawing.Size(445, 324)
      Me._documentListView.TabIndex = 0
      Me._documentListView.UseCompatibleStateImageBehavior = False
      Me._documentListView.View = System.Windows.Forms.View.Details
      ' 
      ' _keyColumnHeader
      ' 
      Me._keyColumnHeader.Text = "Key"
      Me._keyColumnHeader.Width = 80
      ' 
      ' _valueColumnHeader
      ' 
      Me._valueColumnHeader.Text = "Value"
      ' 
      ' _metadataTabPage
      ' 
      Me._metadataTabPage.Controls.Add(Me._metadataListView)
      Me._metadataTabPage.Location = New System.Drawing.Point(4, 22)
      Me._metadataTabPage.Name = "_metadataTabPage"
      Me._metadataTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._metadataTabPage.Size = New System.Drawing.Size(451, 330)
      Me._metadataTabPage.TabIndex = 1
      Me._metadataTabPage.Text = "Metadata"
      Me._metadataTabPage.UseVisualStyleBackColor = True
      ' 
      ' _metadataListView
      ' 
      Me._metadataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2})
      Me._metadataListView.Dock = System.Windows.Forms.DockStyle.Fill
      Me._metadataListView.Location = New System.Drawing.Point(3, 3)
      Me._metadataListView.Name = "_metadataListView"
      Me._metadataListView.Size = New System.Drawing.Size(445, 324)
      Me._metadataListView.TabIndex = 1
      Me._metadataListView.UseCompatibleStateImageBehavior = False
      Me._metadataListView.View = System.Windows.Forms.View.Details
      ' 
      ' columnHeader1
      ' 
      Me.columnHeader1.Text = "Key"
      Me.columnHeader1.Width = 80
      ' 
      ' columnHeader2
      ' 
      Me.columnHeader2.Text = "Value"
      ' 
      ' DocumentPropertiesDialog
      ' 
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._okButton
      Me.ClientSize = New System.Drawing.Size(482, 403)
      Me.Controls.Add(Me._tabControl)
      Me.Controls.Add(Me._okButton)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DocumentPropertiesDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Document Properties"
      Me._tabControl.ResumeLayout(False)
      Me._documentTabPage.ResumeLayout(False)
      Me._metadataTabPage.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _okButton As System.Windows.Forms.Button
   Private _tabControl As System.Windows.Forms.TabControl
   Private _documentTabPage As System.Windows.Forms.TabPage
   Private _documentListView As System.Windows.Forms.ListView
   Private _keyColumnHeader As System.Windows.Forms.ColumnHeader
   Private _valueColumnHeader As System.Windows.Forms.ColumnHeader
   Private _metadataTabPage As System.Windows.Forms.TabPage
   Private _metadataListView As System.Windows.Forms.ListView
   Private columnHeader1 As System.Windows.Forms.ColumnHeader
   Private columnHeader2 As System.Windows.Forms.ColumnHeader
End Class
