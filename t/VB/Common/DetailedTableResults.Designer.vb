<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetailedTableResults
    Inherits System.Windows.Forms.Form

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetailedTableResults))
      Me._btnOk = New System.Windows.Forms.Button()
      Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.panel1 = New System.Windows.Forms.Panel()
      Me._tableResults = New System.Windows.Forms.DataGridView()
      Me.tableLayoutPanel1.SuspendLayout()
      Me.panel1.SuspendLayout()
      CType(Me._tableResults, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _btnOk
      ' 
      Me._btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.Location = New System.Drawing.Point(334, 6)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(52, 23)
      Me._btnOk.TabIndex = 0
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' tableLayoutPanel1
      ' 
      Me.tableLayoutPanel1.ColumnCount = 1
      Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
      Me.tableLayoutPanel1.Controls.Add(Me.panel1, 0, 1)
      Me.tableLayoutPanel1.Controls.Add(Me._tableResults, 0, 0)
      Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
      Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
      Me.tableLayoutPanel1.RowCount = 2
      Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
      Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0F))
      Me.tableLayoutPanel1.Size = New System.Drawing.Size(725, 568)
      Me.tableLayoutPanel1.TabIndex = 1
      ' 
      ' panel1
      ' 
      Me.panel1.Controls.Add(Me._btnOk)
      Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.panel1.Location = New System.Drawing.Point(3, 532)
      Me.panel1.Name = "panel1"
      Me.panel1.Size = New System.Drawing.Size(719, 33)
      Me.panel1.TabIndex = 1
      ' 
      ' _tableResults
      ' 
      Me._tableResults.AllowUserToAddRows = False
      Me._tableResults.AllowUserToDeleteRows = False
      Me._tableResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
      Me._tableResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me._tableResults.Dock = System.Windows.Forms.DockStyle.Fill
      Me._tableResults.Location = New System.Drawing.Point(3, 3)
      Me._tableResults.Name = "_tableResults"
      Me._tableResults.[ReadOnly] = True
      Me._tableResults.Size = New System.Drawing.Size(719, 523)
      Me._tableResults.TabIndex = 2
      ' 
      ' DetailedTableResults
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(725, 568)
      Me.Controls.Add(Me.tableLayoutPanel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "DetailedTableResults"
      Me.Text = "Detailed Table Results"
      Me.tableLayoutPanel1.ResumeLayout(False)
      Me.panel1.ResumeLayout(False)
      CType(Me._tableResults, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _btnOk As System.Windows.Forms.Button
   Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Private panel1 As System.Windows.Forms.Panel
   Private WithEvents _tableResults As System.Windows.Forms.DataGridView
End Class
