
Namespace HL7Messaging
   Partial Class MainView
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainView))
         Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
         Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
         Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.loadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.addMWLItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.updatePatientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.sendMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.comboBox1 = New System.Windows.Forms.ComboBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
         Me.textBox1 = New System.Windows.Forms.TextBox()
         Me.button1 = New System.Windows.Forms.Button()
         Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
         Me.menuStrip1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' openFileDialog1
         ' 
         Me.openFileDialog1.Filter = "HL7 files|*.hl7|Text files|*.txt|All files (*.*)|*.*"
         ' 
         ' menuStrip1
         ' 
         Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.toolsToolStripMenuItem})
         Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
         Me.menuStrip1.Name = "menuStrip1"
         Me.menuStrip1.Size = New System.Drawing.Size(818, 24)
         Me.menuStrip1.TabIndex = 4
         Me.menuStrip1.Text = "menuStrip1"
         ' 
         ' fileToolStripMenuItem
         ' 
         Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripMenuItem, Me.loadToolStripMenuItem, Me.saveToolStripMenuItem})
         Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
         Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me.fileToolStripMenuItem.Text = "&File"
         ' 
         ' newToolStripMenuItem
         ' 
         Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
         Me.newToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me.newToolStripMenuItem.Text = "&New..."
         ' 
         ' loadToolStripMenuItem
         ' 
         Me.loadToolStripMenuItem.Name = "loadToolStripMenuItem"
         Me.loadToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me.loadToolStripMenuItem.Text = "&Load..."
         ' 
         ' saveToolStripMenuItem
         ' 
         Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
         Me.saveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me.saveToolStripMenuItem.Text = "&Save..."
         ' 
         ' toolsToolStripMenuItem
         ' 
         Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.addMWLItemToolStripMenuItem, Me.updatePatientToolStripMenuItem, Me.sendMessageToolStripMenuItem})
         Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
         Me.toolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
         Me.toolsToolStripMenuItem.Text = "&Tools"
         ' 
         ' addMWLItemToolStripMenuItem
         ' 
         Me.addMWLItemToolStripMenuItem.Name = "addMWLItemToolStripMenuItem"
         Me.addMWLItemToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
         Me.addMWLItemToolStripMenuItem.Text = "Add M&WL Item"
         ' 
         ' updatePatientToolStripMenuItem
         ' 
         Me.updatePatientToolStripMenuItem.Name = "updatePatientToolStripMenuItem"
         Me.updatePatientToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
         Me.updatePatientToolStripMenuItem.Text = "&Update Patient"
         ' 
         ' sendMessageToolStripMenuItem
         ' 
         Me.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem"
         Me.sendMessageToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
         Me.sendMessageToolStripMenuItem.Text = "&Send Message"
         ' 
         ' comboBox1
         ' 
         Me.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBox1.FormattingEnabled = True
         Me.comboBox1.Items.AddRange(New Object() {"Contents", "Contents + Empty Fields", "Schema", "All"})
         Me.comboBox1.Location = New System.Drawing.Point(56, 42)
         Me.comboBox1.Name = "comboBox1"
         Me.comboBox1.Size = New System.Drawing.Size(151, 21)
         Me.comboBox1.TabIndex = 7
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(13, 45)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(37, 13)
         Me.label2.TabIndex = 6
         Me.label2.Text = "Show:"
         ' 
         ' propertyGrid1
         ' 
         Me.propertyGrid1.Location = New System.Drawing.Point(13, 72)
         Me.propertyGrid1.Name = "propertyGrid1"
         Me.propertyGrid1.Size = New System.Drawing.Size(792, 594)
         Me.propertyGrid1.TabIndex = 9
         ' 
         ' textBox1
         ' 
         Me.textBox1.Font = New System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me.textBox1.Location = New System.Drawing.Point(13, 676)
         Me.textBox1.Multiline = True
         Me.textBox1.Name = "textBox1"
         Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
         Me.textBox1.Size = New System.Drawing.Size(792, 158)
         Me.textBox1.TabIndex = 10
         Me.textBox1.WordWrap = False
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(13, 841)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(72, 23)
         Me.button1.TabIndex = 11
         Me.button1.Text = "&Parse"
         Me.button1.UseVisualStyleBackColor = True
         ' 
         ' saveFileDialog1
         ' 
         Me.saveFileDialog1.DefaultExt = "hl7"
         Me.saveFileDialog1.Filter = "HL7 files|*.hl7|Text files|*.txt"
         ' 
         ' MainView
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(818, 871)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.textBox1)
         Me.Controls.Add(Me.propertyGrid1)
         Me.Controls.Add(Me.comboBox1)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.menuStrip1)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.Name = "MainView"
         Me.Text = "HL7 Messaging"
         Me.menuStrip1.ResumeLayout(False)
         Me.menuStrip1.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
      Private menuStrip1 As System.Windows.Forms.MenuStrip
      Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents loadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents newToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents comboBox1 As System.Windows.Forms.ComboBox
      Private label2 As System.Windows.Forms.Label
      Private propertyGrid1 As System.Windows.Forms.PropertyGrid
      Private textBox1 As System.Windows.Forms.TextBox
      Private WithEvents button1 As System.Windows.Forms.Button
      Private toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents addMWLItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents updatePatientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog
      Private WithEvents saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents sendMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   End Class
End Namespace

