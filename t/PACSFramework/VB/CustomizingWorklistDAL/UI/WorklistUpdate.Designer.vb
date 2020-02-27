Namespace VBCustomizingWorklistDAL.UI
   Partial Class WorklistUpdate
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

#Region "Component Designer generated code"

      ''' <summary> 
      ''' Required method for Designer support - do not modify 
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me.QueryButton = New System.Windows.Forms.Button()
         Me.UpdateButton = New System.Windows.Forms.Button()
         Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
         Me.label1 = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' QueryButton
         ' 
         Me.QueryButton.Location = New System.Drawing.Point(3, 23)
         Me.QueryButton.Name = "QueryButton"
         Me.QueryButton.Size = New System.Drawing.Size(122, 37)
         Me.QueryButton.TabIndex = 1
         Me.QueryButton.Text = "Query"
         Me.QueryButton.UseVisualStyleBackColor = True
         ' 
         ' UpdateButton
         ' 
         Me.UpdateButton.Location = New System.Drawing.Point(131, 24)
         Me.UpdateButton.Name = "UpdateButton"
         Me.UpdateButton.Size = New System.Drawing.Size(122, 37)
         Me.UpdateButton.TabIndex = 2
         Me.UpdateButton.Text = "Update"
         Me.UpdateButton.UseVisualStyleBackColor = True
         ' 
         ' tableLayoutPanel1
         ' 
         Me.tableLayoutPanel1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.tableLayoutPanel1.AutoScroll = True
         Me.tableLayoutPanel1.ColumnCount = 1
         Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
         Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
         Me.tableLayoutPanel1.Location = New System.Drawing.Point(3, 66)
         Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
         Me.tableLayoutPanel1.RowCount = 2
         Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F))
         Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F))
         Me.tableLayoutPanel1.Size = New System.Drawing.Size(946, 184)
         Me.tableLayoutPanel1.TabIndex = 3
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(4, 4)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(945, 13)
         Me.label1.TabIndex = 4
         Me.label1.Text = "Click ""Query"" to display the database tables where the columns that holds the new" & " DICOM Tags values. You can edit the values from the grid view and click ""Update" & """ to store them into the database."
         ' 
         ' WorklistUpdate
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.AutoSize = True
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.tableLayoutPanel1)
         Me.Controls.Add(Me.UpdateButton)
         Me.Controls.Add(Me.QueryButton)
         Me.Name = "WorklistUpdate"
         Me.Size = New System.Drawing.Size(952, 253)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private QueryButton As System.Windows.Forms.Button
      Private UpdateButton As System.Windows.Forms.Button
      Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
      Private label1 As System.Windows.Forms.Label

   End Class
End Namespace
