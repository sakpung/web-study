Imports Microsoft.VisualBasic
Imports System

Partial Public Class DetailedCharacterResults
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetailedCharacterResults))
      Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.panel1 = New System.Windows.Forms.Panel()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._charResults = New System.Windows.Forms.DataGridView()
      Me._firstGuess = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me._secondGuess = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me._fontStyle = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me._fontSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me._boundingRect = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tableLayoutPanel1.SuspendLayout()
      Me.panel1.SuspendLayout()
      CType(Me._charResults, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' tableLayoutPanel1
      ' 
      Me.tableLayoutPanel1.ColumnCount = 1
      Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
      Me.tableLayoutPanel1.Controls.Add(Me.panel1, 0, 1)
      Me.tableLayoutPanel1.Controls.Add(Me._charResults, 0, 0)
      Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
      Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
      Me.tableLayoutPanel1.RowCount = 2
      Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
      Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0F))
      Me.tableLayoutPanel1.Size = New System.Drawing.Size(538, 365)
      Me.tableLayoutPanel1.TabIndex = 0
      ' 
      ' panel1
      ' 
      Me.panel1.Controls.Add(Me._btnOk)
      Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.panel1.Location = New System.Drawing.Point(3, 333)
      Me.panel1.Name = "panel1"
      Me.panel1.Size = New System.Drawing.Size(532, 29)
      Me.panel1.TabIndex = 1
      ' 
      ' _btnOk
      ' 
      Me._btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me._btnOk.Location = New System.Drawing.Point(241, 6)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(52, 23)
      Me._btnOk.TabIndex = 0
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      '		  Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
      ' 
      ' _charResults
      ' 
      Me._charResults.AllowUserToAddRows = False
      Me._charResults.AllowUserToDeleteRows = False
      Me._charResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
      Me._charResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me._charResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me._firstGuess, Me._secondGuess, Me._fontStyle, Me._fontSize, Me._boundingRect})
      Me._charResults.Dock = System.Windows.Forms.DockStyle.Fill
      Me._charResults.Location = New System.Drawing.Point(3, 3)
      Me._charResults.Name = "_charResults"
      Me._charResults.ReadOnly = True
      Me._charResults.Size = New System.Drawing.Size(532, 324)
      Me._charResults.TabIndex = 2
      ' 
      ' _firstGuess
      ' 
      Me._firstGuess.HeaderText = "Character"
      Me._firstGuess.Name = "_firstGuess"
      Me._firstGuess.ReadOnly = True
      Me._firstGuess.Width = 78
      ' 
      ' _secondGuess
      ' 
      Me._secondGuess.HeaderText = "Second Guess"
      Me._secondGuess.Name = "_secondGuess"
      Me._secondGuess.ReadOnly = True
      Me._secondGuess.Width = 94
      ' 
      ' _fontStyle
      ' 
      Me._fontStyle.HeaderText = "Font Style"
      Me._fontStyle.Name = "_fontStyle"
      Me._fontStyle.ReadOnly = True
      Me._fontStyle.Width = 73
      ' 
      ' _fontSize
      ' 
      Me._fontSize.HeaderText = "Font Size"
      Me._fontSize.Name = "_fontSize"
      Me._fontSize.ReadOnly = True
      Me._fontSize.Width = 70
      ' 
      ' _boundingRect
      ' 
      Me._boundingRect.HeaderText = "Bounding Rectangle"
      Me._boundingRect.Name = "_boundingRect"
      Me._boundingRect.ReadOnly = True
      Me._boundingRect.Width = 118
      ' 
      ' DetailedCharacterResults
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(538, 365)
      Me.Controls.Add(Me.tableLayoutPanel1)
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.MinimizeBox = False
      Me.Name = "DetailedCharacterResults"
      Me.Text = "Detailed Character Results"
      Me.tableLayoutPanel1.ResumeLayout(False)
      Me.panel1.ResumeLayout(False)
      CType(Me._charResults, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private panel1 As System.Windows.Forms.Panel
   Private _charResults As System.Windows.Forms.DataGridView
   Private _firstGuess As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _secondGuess As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _fontStyle As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _fontSize As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _boundingRect As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
