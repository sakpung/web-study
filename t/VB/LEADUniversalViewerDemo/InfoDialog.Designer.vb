Namespace VBLEADUniversalViewer
   Partial Class InfoDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfoDialog))
         Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
         Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
         Me.tableLayoutPanel1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' tableLayoutPanel1
         ' 
         Me.tableLayoutPanel1.ColumnCount = 1
         Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me.tableLayoutPanel1.Controls.Add(Me.richTextBox1, 0, 0)
         Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
         Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
         Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
         Me.tableLayoutPanel1.RowCount = 1
         Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 114.0F))
         Me.tableLayoutPanel1.Size = New System.Drawing.Size(514, 149)
         Me.tableLayoutPanel1.TabIndex = 0
         ' 
         ' richTextBox1
         ' 
         Me.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.richTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.richTextBox1.Location = New System.Drawing.Point(4, 4)
         Me.richTextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
         Me.richTextBox1.Name = "richTextBox1"
         Me.richTextBox1.ReadOnly = True
         Me.richTextBox1.Size = New System.Drawing.Size(506, 141)
         Me.richTextBox1.TabIndex = 0
         Me.richTextBox1.Text = resources.GetString("richTextBox1.Text")
         ' 
         ' InfoDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 15.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(514, 147)
         Me.Controls.Add(Me.tableLayoutPanel1)
         Me.Font = New System.Drawing.Font("Segoe UI", 9.0F)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
         Me.MaximizeBox = False
         Me.Name = "InfoDialog"
         Me.Text = "Before using the universal viewer demo"
         Me.tableLayoutPanel1.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
      Private richTextBox1 As System.Windows.Forms.RichTextBox
   End Class
End Namespace