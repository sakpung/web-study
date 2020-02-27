Namespace VBCustomizingWorklistDAL
   Partial Class Form1
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
         Me.panel1 = New System.Windows.Forms.Panel()
         Me.UpdateDatabaseButton = New System.Windows.Forms.Button()
         Me.dicomTags1 = New VBCustomizingWorklistDAL.UI.DicomTags()
         Me.worklistUpdate1 = New VBCustomizingWorklistDAL.UI.WorklistUpdate()
         Me.dicomQuery1 = New VBCustomizingWorklistDAL.UI.DICOMQuery()
         Me.databaseStatus1 = New VBCustomizingWorklistDAL.UI.DatabaseStatus()
         Me.panel1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' panel1
         ' 
         Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.panel1.Controls.Add(Me.UpdateDatabaseButton)
         Me.panel1.Controls.Add(Me.dicomTags1)
         Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
         Me.panel1.Location = New System.Drawing.Point(0, 60)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(1246, 121)
         Me.panel1.TabIndex = 3
         ' 
         ' UpdateDatabaseButton
         ' 
         Me.UpdateDatabaseButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.UpdateDatabaseButton.Location = New System.Drawing.Point(1111, 33)
         Me.UpdateDatabaseButton.Name = "UpdateDatabaseButton"
         Me.UpdateDatabaseButton.Size = New System.Drawing.Size(122, 37)
         Me.UpdateDatabaseButton.TabIndex = 4
         Me.UpdateDatabaseButton.Text = "Update Database"
         Me.UpdateDatabaseButton.UseVisualStyleBackColor = True
         ' 
         ' dicomTags1
         ' 
         Me.dicomTags1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.dicomTags1.Location = New System.Drawing.Point(0, 0)
         Me.dicomTags1.Name = "dicomTags1"
         Me.dicomTags1.Size = New System.Drawing.Size(1105, 119)
         Me.dicomTags1.TabIndex = 3
         ' 
         ' worklistUpdate1
         ' 
         Me.worklistUpdate1.AutoScroll = True
         Me.worklistUpdate1.AutoSize = True
         Me.worklistUpdate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.worklistUpdate1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.worklistUpdate1.Location = New System.Drawing.Point(0, 181)
         Me.worklistUpdate1.Name = "worklistUpdate1"
         Me.worklistUpdate1.Size = New System.Drawing.Size(1246, 323)
         Me.worklistUpdate1.TabIndex = 7
         ' 
         ' dicomQuery1
         ' 
         Me.dicomQuery1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.dicomQuery1.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.dicomQuery1.Location = New System.Drawing.Point(0, 504)
         Me.dicomQuery1.Name = "dicomQuery1"
         Me.dicomQuery1.Size = New System.Drawing.Size(1246, 297)
         Me.dicomQuery1.TabIndex = 6
         ' 
         ' databaseStatus1
         ' 
         Me.databaseStatus1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.databaseStatus1.ConnectionString = ""
         Me.databaseStatus1.Dock = System.Windows.Forms.DockStyle.Top
         Me.databaseStatus1.Location = New System.Drawing.Point(0, 0)
         Me.databaseStatus1.Name = "databaseStatus1"
         Me.databaseStatus1.ProviderName = ""
         Me.databaseStatus1.Size = New System.Drawing.Size(1246, 60)
         Me.databaseStatus1.TabIndex = 0
         ' 
         ' Form1
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(1246, 801)
         Me.Controls.Add(Me.worklistUpdate1)
         Me.Controls.Add(Me.dicomQuery1)
         Me.Controls.Add(Me.panel1)
         Me.Controls.Add(Me.databaseStatus1)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.Name = "Form1"
         Me.Text = "Customize Modality Work-list Database"
         Me.panel1.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private databaseStatus1 As VBCustomizingWorklistDAL.UI.DatabaseStatus
      Private panel1 As System.Windows.Forms.Panel
      Private UpdateDatabaseButton As System.Windows.Forms.Button
      Private dicomTags1 As VBCustomizingWorklistDAL.UI.DicomTags
      Private dicomQuery1 As VBCustomizingWorklistDAL.UI.DICOMQuery
      Private worklistUpdate1 As VBCustomizingWorklistDAL.UI.WorklistUpdate
   End Class
End Namespace

