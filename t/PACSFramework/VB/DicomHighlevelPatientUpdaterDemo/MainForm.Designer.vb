Imports DicomDemo.DicomDemo.Utils.PatientUpdaterSeries

Namespace DicomDemo
   Partial Friend Class MainForm
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me.PatientIdLabel = New System.Windows.Forms.Label()
         Me.textBoxPatientId = New System.Windows.Forms.TextBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.textBoxPatientName = New System.Windows.Forms.TextBox()
         Me.SearchButton = New System.Windows.Forms.Button()
         Me.SearchGroupBox = New System.Windows.Forms.GroupBox()
         Me.DeleteSeriesButton = New System.Windows.Forms.Button()
         Me.EditSeriesButton = New System.Windows.Forms.Button()
         Me.DeletePatientButton = New System.Windows.Forms.Button()
         Me.EditPatientButton = New System.Windows.Forms.Button()
         Me.listViewSeries = New NoFlashListView()
         Me.SeriesDescriptionColumn = New System.Windows.Forms.ColumnHeader()
         Me.SeriesDateColumn = New System.Windows.Forms.ColumnHeader()
         Me.SeriesTimeColumn = New System.Windows.Forms.ColumnHeader()
         Me.SeriesModalityColumn = New System.Windows.Forms.ColumnHeader()
         Me.StudyInstanceColumn = New System.Windows.Forms.ColumnHeader()
         Me.SeriesLabel = New System.Windows.Forms.Label()
         Me.listViewPatients = New NoFlashListView()
         Me.PatientNameColumn = New System.Windows.Forms.ColumnHeader()
         Me.PatientIdColumn = New System.Windows.Forms.ColumnHeader()
         Me.SexColumn = New System.Windows.Forms.ColumnHeader()
         Me.BirthColumn = New System.Windows.Forms.ColumnHeader()
         Me.PatientLabel = New System.Windows.Forms.Label()
         Me.menuStripMain = New System.Windows.Forms.MenuStrip()
         Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
         Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.hToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.SearchForGroupBox = New System.Windows.Forms.GroupBox()
         Me.SearchGroupBox.SuspendLayout()
         Me.menuStripMain.SuspendLayout()
         Me.SearchForGroupBox.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' PatientIdLabel
         ' 
         resources.ApplyResources(Me.PatientIdLabel, "PatientIdLabel")
         Me.PatientIdLabel.ForeColor = System.Drawing.SystemColors.ControlText
         Me.PatientIdLabel.Name = "PatientIdLabel"
         ' 
         ' textBoxPatientId
         ' 
         resources.ApplyResources(Me.textBoxPatientId, "textBoxPatientId")
         Me.textBoxPatientId.Name = "textBoxPatientId"
         ' 
         ' label1
         ' 
         resources.ApplyResources(Me.label1, "label1")
         Me.label1.ForeColor = System.Drawing.SystemColors.ControlText
         Me.label1.Name = "label1"
         ' 
         ' textBoxPatientName
         ' 
         resources.ApplyResources(Me.textBoxPatientName, "textBoxPatientName")
         Me.textBoxPatientName.Name = "textBoxPatientName"
         ' 
         ' SearchButton
         ' 
         resources.ApplyResources(Me.SearchButton, "SearchButton")
         Me.SearchButton.Name = "SearchButton"
         Me.SearchButton.UseVisualStyleBackColor = True
         ' 
         ' SearchGroupBox
         ' 
         Me.SearchGroupBox.Controls.Add(Me.DeleteSeriesButton)
         Me.SearchGroupBox.Controls.Add(Me.EditSeriesButton)
         Me.SearchGroupBox.Controls.Add(Me.DeletePatientButton)
         Me.SearchGroupBox.Controls.Add(Me.EditPatientButton)
         Me.SearchGroupBox.Controls.Add(Me.listViewSeries)
         Me.SearchGroupBox.Controls.Add(Me.SeriesLabel)
         Me.SearchGroupBox.Controls.Add(Me.listViewPatients)
         Me.SearchGroupBox.Controls.Add(Me.PatientLabel)
         Me.SearchGroupBox.ForeColor = System.Drawing.Color.Blue
         resources.ApplyResources(Me.SearchGroupBox, "SearchGroupBox")
         Me.SearchGroupBox.Name = "SearchGroupBox"
         Me.SearchGroupBox.TabStop = False
         ' 
         ' DeleteSeriesButton
         ' 
         resources.ApplyResources(Me.DeleteSeriesButton, "DeleteSeriesButton")
         Me.DeleteSeriesButton.ForeColor = System.Drawing.SystemColors.ControlText
         Me.DeleteSeriesButton.Name = "DeleteSeriesButton"
         Me.DeleteSeriesButton.UseVisualStyleBackColor = True
         ' 
         ' EditSeriesButton
         ' 
         resources.ApplyResources(Me.EditSeriesButton, "EditSeriesButton")
         Me.EditSeriesButton.ForeColor = System.Drawing.SystemColors.ControlText
         Me.EditSeriesButton.Name = "EditSeriesButton"
         Me.EditSeriesButton.UseVisualStyleBackColor = True
         ' 
         ' DeletePatientButton
         ' 
         resources.ApplyResources(Me.DeletePatientButton, "DeletePatientButton")
         Me.DeletePatientButton.ForeColor = System.Drawing.SystemColors.ControlText
         Me.DeletePatientButton.Name = "DeletePatientButton"
         Me.DeletePatientButton.UseVisualStyleBackColor = True
         ' 
         ' EditPatientButton
         ' 
         resources.ApplyResources(Me.EditPatientButton, "EditPatientButton")
         Me.EditPatientButton.ForeColor = System.Drawing.SystemColors.ControlText
         Me.EditPatientButton.Name = "EditPatientButton"
         Me.EditPatientButton.UseVisualStyleBackColor = True
         ' 
         ' listViewSeries
         ' 
         Me.listViewSeries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.SeriesDescriptionColumn, Me.SeriesDateColumn, Me.SeriesTimeColumn, Me.SeriesModalityColumn, Me.StudyInstanceColumn})
         Me.listViewSeries.FullRowSelect = True
         Me.listViewSeries.GridLines = True
         Me.listViewSeries.HideSelection = False
         resources.ApplyResources(Me.listViewSeries, "listViewSeries")
         Me.listViewSeries.MultiSelect = False
         Me.listViewSeries.Name = "listViewSeries"
         Me.listViewSeries.UseCompatibleStateImageBehavior = False
         Me.listViewSeries.View = System.Windows.Forms.View.Details
         ' 
         ' SeriesDescriptionColumn
         ' 
         resources.ApplyResources(Me.SeriesDescriptionColumn, "SeriesDescriptionColumn")
         ' 
         ' SeriesDateColumn
         ' 
         resources.ApplyResources(Me.SeriesDateColumn, "SeriesDateColumn")
         ' 
         ' SeriesTimeColumn
         ' 
         resources.ApplyResources(Me.SeriesTimeColumn, "SeriesTimeColumn")
         ' 
         ' SeriesModalityColumn
         ' 
         resources.ApplyResources(Me.SeriesModalityColumn, "SeriesModalityColumn")
         ' 
         ' StudyInstanceColumn
         ' 
         resources.ApplyResources(Me.StudyInstanceColumn, "StudyInstanceColumn")
         ' 
         ' SeriesLabel
         ' 
         resources.ApplyResources(Me.SeriesLabel, "SeriesLabel")
         Me.SeriesLabel.ForeColor = System.Drawing.SystemColors.ControlText
         Me.SeriesLabel.Name = "SeriesLabel"
         ' 
         ' listViewPatients
         ' 
         Me.listViewPatients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PatientNameColumn, Me.PatientIdColumn, Me.SexColumn, Me.BirthColumn})
         Me.listViewPatients.FullRowSelect = True
         Me.listViewPatients.GridLines = True
         Me.listViewPatients.HideSelection = False
         resources.ApplyResources(Me.listViewPatients, "listViewPatients")
         Me.listViewPatients.MultiSelect = False
         Me.listViewPatients.Name = "listViewPatients"
         Me.listViewPatients.UseCompatibleStateImageBehavior = False
         Me.listViewPatients.View = System.Windows.Forms.View.Details
         ' 
         ' PatientNameColumn
         ' 
         resources.ApplyResources(Me.PatientNameColumn, "PatientNameColumn")
         ' 
         ' PatientIdColumn
         ' 
         resources.ApplyResources(Me.PatientIdColumn, "PatientIdColumn")
         ' 
         ' SexColumn
         ' 
         resources.ApplyResources(Me.SexColumn, "SexColumn")
         ' 
         ' BirthColumn
         ' 
         resources.ApplyResources(Me.BirthColumn, "BirthColumn")
         ' 
         ' PatientLabel
         ' 
         resources.ApplyResources(Me.PatientLabel, "PatientLabel")
         Me.PatientLabel.ForeColor = System.Drawing.SystemColors.ControlText
         Me.PatientLabel.Name = "PatientLabel"
         ' 
         ' menuStripMain
         ' 
         Me.menuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.hToolStripMenuItem})
         resources.ApplyResources(Me.menuStripMain, "menuStripMain")
         Me.menuStripMain.Name = "menuStripMain"
         ' 
         ' fileToolStripMenuItem
         ' 
         Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.optionsToolStripMenuItem, Me.toolStripMenuItem1, Me.exitToolStripMenuItem})
         Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
         resources.ApplyResources(Me.fileToolStripMenuItem, "fileToolStripMenuItem")
         ' 
         ' optionsToolStripMenuItem
         ' 
         Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
         resources.ApplyResources(Me.optionsToolStripMenuItem, "optionsToolStripMenuItem")
         ' 
         ' toolStripMenuItem1
         ' 
         Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
         resources.ApplyResources(Me.toolStripMenuItem1, "toolStripMenuItem1")
         ' 
         ' exitToolStripMenuItem
         ' 
         Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
         resources.ApplyResources(Me.exitToolStripMenuItem, "exitToolStripMenuItem")
         ' 
         ' hToolStripMenuItem
         ' 
         Me.hToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem})
         Me.hToolStripMenuItem.Name = "hToolStripMenuItem"
         resources.ApplyResources(Me.hToolStripMenuItem, "hToolStripMenuItem")
         ' 
         ' aboutToolStripMenuItem
         ' 
         Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
         resources.ApplyResources(Me.aboutToolStripMenuItem, "aboutToolStripMenuItem")
         ' 
         ' SearchForGroupBox
         ' 
         Me.SearchForGroupBox.Controls.Add(Me.PatientIdLabel)
         Me.SearchForGroupBox.Controls.Add(Me.label1)
         Me.SearchForGroupBox.Controls.Add(Me.textBoxPatientId)
         Me.SearchForGroupBox.Controls.Add(Me.textBoxPatientName)
         Me.SearchForGroupBox.ForeColor = System.Drawing.Color.Blue
         resources.ApplyResources(Me.SearchForGroupBox, "SearchForGroupBox")
         Me.SearchForGroupBox.Name = "SearchForGroupBox"
         Me.SearchForGroupBox.TabStop = False
         ' 
         ' MainForm
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.SearchForGroupBox)
         Me.Controls.Add(Me.SearchGroupBox)
         Me.Controls.Add(Me.SearchButton)
         Me.Controls.Add(Me.menuStripMain)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MainMenuStrip = Me.menuStripMain
         Me.MaximizeBox = False
         Me.Name = "MainForm"
         Me.SearchGroupBox.ResumeLayout(False)
         Me.SearchGroupBox.PerformLayout()
         Me.menuStripMain.ResumeLayout(False)
         Me.menuStripMain.PerformLayout()
         Me.SearchForGroupBox.ResumeLayout(False)
         Me.SearchForGroupBox.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private PatientIdLabel As System.Windows.Forms.Label
      Private WithEvents textBoxPatientId As System.Windows.Forms.TextBox
      Private label1 As System.Windows.Forms.Label
      Private WithEvents textBoxPatientName As System.Windows.Forms.TextBox
      Private WithEvents SearchButton As System.Windows.Forms.Button
      Private SearchGroupBox As System.Windows.Forms.GroupBox
      Private WithEvents listViewSeries As NoFlashListView
      Private SeriesLabel As System.Windows.Forms.Label
      Private WithEvents listViewPatients As NoFlashListView
      Private PatientLabel As System.Windows.Forms.Label
      Private WithEvents DeleteSeriesButton As System.Windows.Forms.Button
      Private WithEvents EditSeriesButton As System.Windows.Forms.Button
      Private WithEvents DeletePatientButton As System.Windows.Forms.Button
      Private WithEvents EditPatientButton As System.Windows.Forms.Button
      Private PatientIdColumn As System.Windows.Forms.ColumnHeader
      Private PatientNameColumn As System.Windows.Forms.ColumnHeader
      Private menuStripMain As System.Windows.Forms.MenuStrip
      Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
      Private SexColumn As System.Windows.Forms.ColumnHeader
      Private BirthColumn As System.Windows.Forms.ColumnHeader
      Private SeriesDescriptionColumn As System.Windows.Forms.ColumnHeader
      Private SeriesDateColumn As System.Windows.Forms.ColumnHeader
      Private SeriesModalityColumn As System.Windows.Forms.ColumnHeader
      Private SearchForGroupBox As System.Windows.Forms.GroupBox
      Private StudyInstanceColumn As System.Windows.Forms.ColumnHeader
      Private SeriesTimeColumn As System.Windows.Forms.ColumnHeader
      Private hToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   End Class
End Namespace

