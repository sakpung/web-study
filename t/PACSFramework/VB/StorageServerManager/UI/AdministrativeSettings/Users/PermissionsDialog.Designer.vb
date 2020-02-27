Namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
   Partial Friend Class PermissionsDialog
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
         Me.panel1 = New System.Windows.Forms.Panel()
         Me.button2 = New System.Windows.Forms.Button()
         Me.button1 = New System.Windows.Forms.Button()
         Me.label1 = New System.Windows.Forms.Label()
         Me.listViewPermissions = New System.Windows.Forms.ListView()
         Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
         Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
         Me.panel1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' panel1
         ' 
         Me.panel1.Controls.Add(Me.button2)
         Me.panel1.Controls.Add(Me.button1)
         Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.panel1.Location = New System.Drawing.Point(0, 213)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(451, 49)
         Me.panel1.TabIndex = 0
         ' 
         ' button2
         ' 
         Me.button2.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.button2.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button2.Location = New System.Drawing.Point(283, 14)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(75, 23)
         Me.button2.TabIndex = 1
         Me.button2.Text = "OK"
         Me.button2.UseVisualStyleBackColor = True
         ' 
         ' button1
         ' 
         Me.button1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.button1.Location = New System.Drawing.Point(364, 14)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(75, 23)
         Me.button1.TabIndex = 0
         Me.button1.Text = "Cancel"
         Me.button1.UseVisualStyleBackColor = True
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(13, 13)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(124, 13)
         Me.label1.TabIndex = 1
         Me.label1.Text = "Modify User Permissions:"
         ' 
         ' listViewPermissions
         ' 
         Me.listViewPermissions.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.listViewPermissions.CheckBoxes = True
         Me.listViewPermissions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2})
         Me.listViewPermissions.FullRowSelect = True
         Me.listViewPermissions.Location = New System.Drawing.Point(16, 30)
         Me.listViewPermissions.Name = "listViewPermissions"
         Me.listViewPermissions.Size = New System.Drawing.Size(423, 177)
         Me.listViewPermissions.TabIndex = 2
         Me.listViewPermissions.UseCompatibleStateImageBehavior = False
         Me.listViewPermissions.View = System.Windows.Forms.View.Details
         ' 
         ' columnHeader1
         ' 
         Me.columnHeader1.Text = "Permission"
         ' 
         ' columnHeader2
         ' 
         Me.columnHeader2.Text = "Description"
         ' 
         ' PermissionsDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(451, 262)
         Me.Controls.Add(Me.listViewPermissions)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.panel1)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "PermissionsDialog"
         Me.ShowIcon = False
         Me.Text = "Edit Permissions"
         Me.panel1.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private panel1 As System.Windows.Forms.Panel
      Private button2 As System.Windows.Forms.Button
      Private button1 As System.Windows.Forms.Button
      Private label1 As System.Windows.Forms.Label
      Private listViewPermissions As System.Windows.Forms.ListView
      Private columnHeader1 As System.Windows.Forms.ColumnHeader
      Private columnHeader2 As System.Windows.Forms.ColumnHeader
   End Class
End Namespace
