Namespace DicomDemo
   Partial Friend Class OptionsDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsDialog))
         Me.panel1 = New System.Windows.Forms.Panel()
         Me.OkButton = New System.Windows.Forms.Button()
         Me.OptionsCancelButton = New System.Windows.Forms.Button()
         Me.DicomTab = New System.Windows.Forms.TabPage()
         Me._groupBoxClient = New System.Windows.Forms.GroupBox()
         Me._textBoxTimeout = New System.Windows.Forms.TextBox()
         Me._textBoxClientAE = New System.Windows.Forms.TextBox()
         Me._labelTimeout = New System.Windows.Forms.Label()
         Me._labelClientAE = New System.Windows.Forms.Label()
         Me._groupBoxServer = New System.Windows.Forms.GroupBox()
         Me.VerifyButton = New System.Windows.Forms.Button()
         Me._textBoxServerIP = New System.Windows.Forms.TextBox()
         Me._textBoxServerPort = New System.Windows.Forms.TextBox()
         Me._textBoxServerAE = New System.Windows.Forms.TextBox()
         Me._labelServerPort = New System.Windows.Forms.Label()
         Me._labelServerIP = New System.Windows.Forms.Label()
         Me._labelServerAE = New System.Windows.Forms.Label()
         Me.tabControl1 = New System.Windows.Forms.TabControl()
         Me.panel1.SuspendLayout()
         Me.DicomTab.SuspendLayout()
         Me._groupBoxClient.SuspendLayout()
         Me._groupBoxServer.SuspendLayout()
         Me.tabControl1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' panel1
         ' 
         Me.panel1.Controls.Add(Me.OkButton)
         Me.panel1.Controls.Add(Me.OptionsCancelButton)
         resources.ApplyResources(Me.panel1, "panel1")
         Me.panel1.Name = "panel1"
         ' 
         ' OkButton
         ' 
         Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
         resources.ApplyResources(Me.OkButton, "OkButton")
         Me.OkButton.Name = "OkButton"
         Me.OkButton.UseVisualStyleBackColor = True
         ' 
         ' OptionsCancelButton
         ' 
         Me.OptionsCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         resources.ApplyResources(Me.OptionsCancelButton, "OptionsCancelButton")
         Me.OptionsCancelButton.Name = "OptionsCancelButton"
         Me.OptionsCancelButton.UseVisualStyleBackColor = True
         ' 
         ' DicomTab
         ' 
         Me.DicomTab.Controls.Add(Me._groupBoxClient)
         Me.DicomTab.Controls.Add(Me._groupBoxServer)
         resources.ApplyResources(Me.DicomTab, "DicomTab")
         Me.DicomTab.Name = "DicomTab"
         Me.DicomTab.UseVisualStyleBackColor = True
         ' 
         ' _groupBoxClient
         ' 
         Me._groupBoxClient.Controls.Add(Me._textBoxTimeout)
         Me._groupBoxClient.Controls.Add(Me._textBoxClientAE)
         Me._groupBoxClient.Controls.Add(Me._labelTimeout)
         Me._groupBoxClient.Controls.Add(Me._labelClientAE)
         resources.ApplyResources(Me._groupBoxClient, "_groupBoxClient")
         Me._groupBoxClient.Name = "_groupBoxClient"
         Me._groupBoxClient.TabStop = False
         ' 
         ' _textBoxTimeout
         ' 
         resources.ApplyResources(Me._textBoxTimeout, "_textBoxTimeout")
         Me._textBoxTimeout.Name = "_textBoxTimeout"
         ' 
         ' _textBoxClientAE
         ' 
         resources.ApplyResources(Me._textBoxClientAE, "_textBoxClientAE")
         Me._textBoxClientAE.Name = "_textBoxClientAE"
         ' 
         ' _labelTimeout
         ' 
         resources.ApplyResources(Me._labelTimeout, "_labelTimeout")
         Me._labelTimeout.Name = "_labelTimeout"
         ' 
         ' _labelClientAE
         ' 
         resources.ApplyResources(Me._labelClientAE, "_labelClientAE")
         Me._labelClientAE.Name = "_labelClientAE"
         ' 
         ' _groupBoxServer
         ' 
         Me._groupBoxServer.Controls.Add(Me.VerifyButton)
         Me._groupBoxServer.Controls.Add(Me._textBoxServerIP)
         Me._groupBoxServer.Controls.Add(Me._textBoxServerPort)
         Me._groupBoxServer.Controls.Add(Me._textBoxServerAE)
         Me._groupBoxServer.Controls.Add(Me._labelServerPort)
         Me._groupBoxServer.Controls.Add(Me._labelServerIP)
         Me._groupBoxServer.Controls.Add(Me._labelServerAE)
         resources.ApplyResources(Me._groupBoxServer, "_groupBoxServer")
         Me._groupBoxServer.Name = "_groupBoxServer"
         Me._groupBoxServer.TabStop = False
         ' 
         ' VerifyButton
         ' 
         resources.ApplyResources(Me.VerifyButton, "VerifyButton")
         Me.VerifyButton.Name = "VerifyButton"
         Me.VerifyButton.UseVisualStyleBackColor = True
         ' 
         ' _textBoxServerIP
         ' 
         resources.ApplyResources(Me._textBoxServerIP, "_textBoxServerIP")
         Me._textBoxServerIP.Name = "_textBoxServerIP"
         ' 
         ' _textBoxServerPort
         ' 
         resources.ApplyResources(Me._textBoxServerPort, "_textBoxServerPort")
         Me._textBoxServerPort.Name = "_textBoxServerPort"
         ' 
         ' _textBoxServerAE
         ' 
         resources.ApplyResources(Me._textBoxServerAE, "_textBoxServerAE")
         Me._textBoxServerAE.Name = "_textBoxServerAE"
         ' 
         ' _labelServerPort
         ' 
         resources.ApplyResources(Me._labelServerPort, "_labelServerPort")
         Me._labelServerPort.Name = "_labelServerPort"
         ' 
         ' _labelServerIP
         ' 
         resources.ApplyResources(Me._labelServerIP, "_labelServerIP")
         Me._labelServerIP.Name = "_labelServerIP"
         ' 
         ' _labelServerAE
         ' 
         resources.ApplyResources(Me._labelServerAE, "_labelServerAE")
         Me._labelServerAE.Name = "_labelServerAE"
         ' 
         ' tabControl1
         ' 
         Me.tabControl1.Controls.Add(Me.DicomTab)
         resources.ApplyResources(Me.tabControl1, "tabControl1")
         Me.tabControl1.Name = "tabControl1"
         Me.tabControl1.SelectedIndex = 0
         ' 
         ' OptionsDialog
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.tabControl1)
         Me.Controls.Add(Me.panel1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "OptionsDialog"
         Me.panel1.ResumeLayout(False)
         Me.DicomTab.ResumeLayout(False)
         Me._groupBoxClient.ResumeLayout(False)
         Me._groupBoxClient.PerformLayout()
         Me._groupBoxServer.ResumeLayout(False)
         Me._groupBoxServer.PerformLayout()
         Me.tabControl1.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private panel1 As System.Windows.Forms.Panel
      Private OkButton As System.Windows.Forms.Button
      Private OptionsCancelButton As System.Windows.Forms.Button
      Private DicomTab As System.Windows.Forms.TabPage
      Private _groupBoxClient As System.Windows.Forms.GroupBox
      Public _textBoxTimeout As System.Windows.Forms.TextBox
      Public _textBoxClientAE As System.Windows.Forms.TextBox
      Private _labelTimeout As System.Windows.Forms.Label
      Private _labelClientAE As System.Windows.Forms.Label
      Private _groupBoxServer As System.Windows.Forms.GroupBox
      Private WithEvents VerifyButton As System.Windows.Forms.Button
      Public WithEvents _textBoxServerIP As System.Windows.Forms.TextBox
      Public WithEvents _textBoxServerPort As System.Windows.Forms.TextBox
      Public _textBoxServerAE As System.Windows.Forms.TextBox
      Private _labelServerPort As System.Windows.Forms.Label
      Private _labelServerIP As System.Windows.Forms.Label
      Private _labelServerAE As System.Windows.Forms.Label
      Private tabControl1 As System.Windows.Forms.TabControl
   End Class
End Namespace