
Partial Class OcrEngineSelectDialog
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OcrEngineSelectDialog))
      Me._tcMain = New System.Windows.Forms.TabControl()
      Me._tpNoEnginesFound = New System.Windows.Forms.TabPage()
      Me._lblNoEnginesFound = New System.Windows.Forms.Label()
      Me._tpSelectEngine = New System.Windows.Forms.TabPage()
      Me._cbEngineSelection = New System.Windows.Forms.ComboBox()
      Me._lblSelectEngine = New System.Windows.Forms.Label()
      Me._tpStartEngine = New System.Windows.Forms.TabPage()
      Me._lblStatus = New System.Windows.Forms.Label()
      Me._lblStartEngine = New System.Windows.Forms.Label()
      Me._lbDownload = New System.Windows.Forms.LinkLabel()
      Me._lblAllowNoOcr = New System.Windows.Forms.Label()
      Me._lblDownload = New System.Windows.Forms.Label()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._tcMain.SuspendLayout()
      Me._tpNoEnginesFound.SuspendLayout()
      Me._tpSelectEngine.SuspendLayout()
      Me._tpStartEngine.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _tcMain
      ' 
      Me._tcMain.Controls.Add(Me._tpNoEnginesFound)
      Me._tcMain.Controls.Add(Me._tpSelectEngine)
      Me._tcMain.Controls.Add(Me._tpStartEngine)
      resources.ApplyResources(Me._tcMain, "_tcMain")
      Me._tcMain.Name = "_tcMain"
      Me._tcMain.SelectedIndex = 0
      ' 
      ' _tpNoEnginesFound
      ' 
      Me._tpNoEnginesFound.Controls.Add(Me._lblNoEnginesFound)
      resources.ApplyResources(Me._tpNoEnginesFound, "_tpNoEnginesFound")
      Me._tpNoEnginesFound.Name = "_tpNoEnginesFound"
      Me._tpNoEnginesFound.UseVisualStyleBackColor = True
      ' 
      ' _lblNoEnginesFound
      ' 
      resources.ApplyResources(Me._lblNoEnginesFound, "_lblNoEnginesFound")
      Me._lblNoEnginesFound.Name = "_lblNoEnginesFound"
      ' 
      ' _tpSelectEngine
      ' 
      Me._tpSelectEngine.Controls.Add(Me._cbEngineSelection)
      Me._tpSelectEngine.Controls.Add(Me._lblSelectEngine)
      resources.ApplyResources(Me._tpSelectEngine, "_tpSelectEngine")
      Me._tpSelectEngine.Name = "_tpSelectEngine"
      Me._tpSelectEngine.UseVisualStyleBackColor = True
      ' 
      ' _cbEngineSelection
      ' 
      Me._cbEngineSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbEngineSelection.FormattingEnabled = True
      resources.ApplyResources(Me._cbEngineSelection, "_cbEngineSelection")
      Me._cbEngineSelection.Name = "_cbEngineSelection"
      ' 
      ' _lblSelectEngine
      ' 
      resources.ApplyResources(Me._lblSelectEngine, "_lblSelectEngine")
      Me._lblSelectEngine.Name = "_lblSelectEngine"
      ' 
      ' _tpStartEngine
      ' 
      Me._tpStartEngine.Controls.Add(Me._lblStatus)
      Me._tpStartEngine.Controls.Add(Me._lblStartEngine)
      resources.ApplyResources(Me._tpStartEngine, "_tpStartEngine")
      Me._tpStartEngine.Name = "_tpStartEngine"
      Me._tpStartEngine.UseVisualStyleBackColor = True
      ' 
      ' _lblStatus
      ' 
      Me._lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
      resources.ApplyResources(Me._lblStatus, "_lblStatus")
      Me._lblStatus.Name = "_lblStatus"
      ' 
      ' _lblStartEngine
      ' 
      resources.ApplyResources(Me._lblStartEngine, "_lblStartEngine")
      Me._lblStartEngine.Name = "_lblStartEngine"
      ' 
      ' _lbDownload
      ' 
      resources.ApplyResources(Me._lbDownload, "_lbDownload")
      Me._lbDownload.Name = "_lbDownload"
      Me._lbDownload.TabStop = True
      ' 
      ' _lblAllowNoOcr
      ' 
      resources.ApplyResources(Me._lblAllowNoOcr, "_lblAllowNoOcr")
      Me._lblAllowNoOcr.Name = "_lblAllowNoOcr"
      ' 
      ' _lblDownload
      ' 
      resources.ApplyResources(Me._lblDownload, "_lblDownload")
      Me._lblDownload.Name = "_lblDownload"
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      resources.ApplyResources(Me._btnOk, "_btnOk")
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      resources.ApplyResources(Me._btnCancel, "_btnCancel")
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' OcrEngineSelectDialog
      ' 
      Me.AcceptButton = Me._btnOk
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._lblAllowNoOcr)
      Me.Controls.Add(Me._lblDownload)
      Me.Controls.Add(Me._lbDownload)
      Me.Controls.Add(Me._tcMain)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OcrEngineSelectDialog"
      Me._tcMain.ResumeLayout(False)
      Me._tpNoEnginesFound.ResumeLayout(False)
      Me._tpSelectEngine.ResumeLayout(False)
      Me._tpSelectEngine.PerformLayout()
      Me._tpStartEngine.ResumeLayout(False)
      Me._tpStartEngine.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _tcMain As System.Windows.Forms.TabControl
   Private _tpNoEnginesFound As System.Windows.Forms.TabPage
   Private _tpSelectEngine As System.Windows.Forms.TabPage
   Private _lblNoEnginesFound As System.Windows.Forms.Label
   Private WithEvents _lbDownload As System.Windows.Forms.LinkLabel
   Private _lblAllowNoOcr As System.Windows.Forms.Label
   Private _lblDownload As System.Windows.Forms.Label
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _btnCancel As System.Windows.Forms.Button
   Private _lblSelectEngine As System.Windows.Forms.Label
   Private _cbEngineSelection As System.Windows.Forms.ComboBox
   Private _tpStartEngine As System.Windows.Forms.TabPage
   Private _lblStartEngine As System.Windows.Forms.Label
   Private _lblStatus As System.Windows.Forms.Label


End Class
