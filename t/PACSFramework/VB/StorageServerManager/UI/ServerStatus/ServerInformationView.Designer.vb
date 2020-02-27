Namespace Leadtools.Demos.StorageServer.UI
    Partial Friend Class ServerInformationView
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServerInformationView))
            Me.ServiceDisplayNameLabel = New System.Windows.Forms.Label()
            Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.buttonExit = New System.Windows.Forms.Button()
            Me.buttonStop = New System.Windows.Forms.Button()
            Me.buttonAbout = New System.Windows.Forms.Button()
            Me.buttonSettings = New System.Windows.Forms.Button()
            Me.buttonStart = New System.Windows.Forms.Button()
            Me.ServerStatusPictureBox = New System.Windows.Forms.PictureBox()
            Me.panel1 = New Leadtools.Demos.StorageServer.UI.DoubleBufferedPanel()
            Me.labelStatus = New System.Windows.Forms.Label()
            Me.label5 = New System.Windows.Forms.Label()
            Me.PortLabel = New System.Windows.Forms.Label()
            Me.IpAddressLabel = New System.Windows.Forms.Label()
            Me.AETitleLabel = New System.Windows.Forms.Label()
            Me.label2 = New System.Windows.Forms.Label()
            Me.label1 = New System.Windows.Forms.Label()
            Me.label3 = New System.Windows.Forms.Label()
            Me.pictureBoxSecure1 = New System.Windows.Forms.PictureBox()
            CType(Me.ServerStatusPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panel1.SuspendLayout()
            CType(Me.pictureBoxSecure1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ServiceDisplayNameLabel
            '
            Me.ServiceDisplayNameLabel.AutoSize = True
            Me.ServiceDisplayNameLabel.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ServiceDisplayNameLabel.Location = New System.Drawing.Point(121, 29)
            Me.ServiceDisplayNameLabel.Name = "ServiceDisplayNameLabel"
            Me.ServiceDisplayNameLabel.Size = New System.Drawing.Size(150, 22)
            Me.ServiceDisplayNameLabel.TabIndex = 11
            Me.ServiceDisplayNameLabel.Text = "Storage Server"
            '
            'buttonExit
            '
            Me.buttonExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.buttonExit.BackgroundImage = CType(resources.GetObject("buttonExit.BackgroundImage"), System.Drawing.Image)
            Me.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand
            Me.buttonExit.FlatAppearance.BorderSize = 0
            Me.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(178, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(232, Byte), Integer))
            Me.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.buttonExit.Location = New System.Drawing.Point(568, 91)
            Me.buttonExit.Name = "buttonExit"
            Me.buttonExit.Size = New System.Drawing.Size(64, 36)
            Me.buttonExit.TabIndex = 2
            Me.toolTip.SetToolTip(Me.buttonExit, "Exit Application")
            Me.buttonExit.UseVisualStyleBackColor = True
            '
            'buttonStop
            '
            Me.buttonStop.BackColor = System.Drawing.Color.Transparent
            Me.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.buttonStop.Cursor = System.Windows.Forms.Cursors.Hand
            Me.buttonStop.Enabled = False
            Me.buttonStop.FlatAppearance.BorderSize = 0
            Me.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.buttonStop.Image = Global.My.Resources.ServiceStop
            Me.buttonStop.Location = New System.Drawing.Point(61, 104)
            Me.buttonStop.Name = "buttonStop"
            Me.buttonStop.Size = New System.Drawing.Size(25, 25)
            Me.buttonStop.TabIndex = 14
            Me.buttonStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.toolTip.SetToolTip(Me.buttonStop, "Stop Storage Service")
            Me.buttonStop.UseVisualStyleBackColor = False
            '
            'buttonAbout
            '
            Me.buttonAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.buttonAbout.BackgroundImage = CType(resources.GetObject("buttonAbout.BackgroundImage"), System.Drawing.Image)
            Me.buttonAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.buttonAbout.Cursor = System.Windows.Forms.Cursors.Hand
            Me.buttonAbout.FlatAppearance.BorderSize = 0
            Me.buttonAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(178, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(232, Byte), Integer))
            Me.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.buttonAbout.Location = New System.Drawing.Point(568, 49)
            Me.buttonAbout.Name = "buttonAbout"
            Me.buttonAbout.Size = New System.Drawing.Size(64, 36)
            Me.buttonAbout.TabIndex = 1
            Me.toolTip.SetToolTip(Me.buttonAbout, "About")
            Me.buttonAbout.UseVisualStyleBackColor = True
            '
            'buttonSettings
            '
            Me.buttonSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.buttonSettings.Cursor = System.Windows.Forms.Cursors.Hand
            Me.buttonSettings.FlatAppearance.BorderSize = 0
            Me.buttonSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(178, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(232, Byte), Integer))
            Me.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.buttonSettings.Image = CType(resources.GetObject("buttonSettings.Image"), System.Drawing.Image)
            Me.buttonSettings.Location = New System.Drawing.Point(568, 7)
            Me.buttonSettings.Name = "buttonSettings"
            Me.buttonSettings.Size = New System.Drawing.Size(64, 36)
            Me.buttonSettings.TabIndex = 0
            Me.toolTip.SetToolTip(Me.buttonSettings, "Settings")
            Me.buttonSettings.UseVisualStyleBackColor = True
            '
            'buttonStart
            '
            Me.buttonStart.BackColor = System.Drawing.Color.Transparent
            Me.buttonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand
            Me.buttonStart.FlatAppearance.BorderSize = 0
            Me.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.buttonStart.Image = CType(resources.GetObject("buttonStart.Image"), System.Drawing.Image)
            Me.buttonStart.Location = New System.Drawing.Point(31, 104)
            Me.buttonStart.Name = "buttonStart"
            Me.buttonStart.Size = New System.Drawing.Size(25, 25)
            Me.buttonStart.TabIndex = 13
            Me.buttonStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.toolTip.SetToolTip(Me.buttonStart, "Start Storage Service")
            Me.buttonStart.UseVisualStyleBackColor = False
            '
            'ServerStatusPictureBox
            '
            Me.ServerStatusPictureBox.Image = Global.My.Resources._1313685426_Symbol_Error
            Me.ServerStatusPictureBox.Location = New System.Drawing.Point(12, 29)
            Me.ServerStatusPictureBox.Name = "ServerStatusPictureBox"
            Me.ServerStatusPictureBox.Size = New System.Drawing.Size(100, 76)
            Me.ServerStatusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.ServerStatusPictureBox.TabIndex = 7
            Me.ServerStatusPictureBox.TabStop = False
            Me.toolTip.SetToolTip(Me.ServerStatusPictureBox, "Server is stopped")
            '
            'panel1
            '
            Me.panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.panel1.Controls.Add(Me.pictureBoxSecure1)
            Me.panel1.Controls.Add(Me.labelStatus)
            Me.panel1.Controls.Add(Me.label5)
            Me.panel1.Controls.Add(Me.PortLabel)
            Me.panel1.Controls.Add(Me.IpAddressLabel)
            Me.panel1.Controls.Add(Me.AETitleLabel)
            Me.panel1.Controls.Add(Me.label2)
            Me.panel1.Controls.Add(Me.label1)
            Me.panel1.Controls.Add(Me.label3)
            Me.panel1.Location = New System.Drawing.Point(118, 54)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(318, 77)
            Me.panel1.TabIndex = 10
            '
            'labelStatus
            '
            Me.labelStatus.AutoSize = True
            Me.labelStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.labelStatus.ForeColor = System.Drawing.Color.Red
            Me.labelStatus.Location = New System.Drawing.Point(125, 59)
            Me.labelStatus.Name = "labelStatus"
            Me.labelStatus.Size = New System.Drawing.Size(25, 14)
            Me.labelStatus.TabIndex = 14
            Me.labelStatus.Text = "805"
            '
            'label5
            '
            Me.label5.AutoSize = True
            Me.label5.Location = New System.Drawing.Point(4, 59)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(41, 14)
            Me.label5.TabIndex = 13
            Me.label5.Text = "Status:"
            '
            'PortLabel
            '
            Me.PortLabel.AutoSize = True
            Me.PortLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.PortLabel.Location = New System.Drawing.Point(125, 41)
            Me.PortLabel.Name = "PortLabel"
            Me.PortLabel.Size = New System.Drawing.Size(25, 14)
            Me.PortLabel.TabIndex = 12
            Me.PortLabel.Text = "805"
            '
            'IpAddressLabel
            '
            Me.IpAddressLabel.AutoSize = True
            Me.IpAddressLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.IpAddressLabel.Location = New System.Drawing.Point(125, 23)
            Me.IpAddressLabel.Name = "IpAddressLabel"
            Me.IpAddressLabel.Size = New System.Drawing.Size(76, 14)
            Me.IpAddressLabel.TabIndex = 11
            Me.IpAddressLabel.Text = "192.168.0.151"
            '
            'AETitleLabel
            '
            Me.AETitleLabel.AutoSize = True
            Me.AETitleLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AETitleLabel.Location = New System.Drawing.Point(125, 5)
            Me.AETitleLabel.Name = "AETitleLabel"
            Me.AETitleLabel.Size = New System.Drawing.Size(67, 14)
            Me.AETitleLabel.TabIndex = 10
            Me.AETitleLabel.Text = "MI_SERVER"
            '
            'label2
            '
            Me.label2.AutoSize = True
            Me.label2.Location = New System.Drawing.Point(4, 23)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(107, 14)
            Me.label2.TabIndex = 8
            Me.label2.Text = "Host/Address Name:"
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(4, 5)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(46, 14)
            Me.label1.TabIndex = 7
            Me.label1.Text = "AE Title:"
            '
            'label3
            '
            Me.label3.AutoSize = True
            Me.label3.Location = New System.Drawing.Point(4, 41)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(29, 14)
            Me.label3.TabIndex = 9
            Me.label3.Text = "Port:"
            '
            'pictureBoxSecure1
            '
            Me.pictureBoxSecure1.Image = Global.My.Resources.lock
            Me.pictureBoxSecure1.Location = New System.Drawing.Point(110, 2)
            Me.pictureBoxSecure1.Name = "pictureBoxSecure1"
            Me.pictureBoxSecure1.Size = New System.Drawing.Size(16, 16)
            Me.pictureBoxSecure1.TabIndex = 15
            Me.pictureBoxSecure1.TabStop = False
            '
            'ServerInformationView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.ServerStatusPictureBox)
            Me.Controls.Add(Me.buttonExit)
            Me.Controls.Add(Me.buttonStop)
            Me.Controls.Add(Me.buttonAbout)
            Me.Controls.Add(Me.buttonSettings)
            Me.Controls.Add(Me.ServiceDisplayNameLabel)
            Me.Controls.Add(Me.buttonStart)
            Me.Controls.Add(Me.panel1)
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MinimumSize = New System.Drawing.Size(360, 134)
            Me.Name = "ServerInformationView"
            Me.Size = New System.Drawing.Size(635, 134)
            CType(Me.ServerStatusPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panel1.ResumeLayout(False)
            Me.panel1.PerformLayout()
            CType(Me.pictureBoxSecure1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private ServerStatusPictureBox As System.Windows.Forms.PictureBox
        Private panel1 As Leadtools.Demos.StorageServer.UI.DoubleBufferedPanel 'xxx 
        Private PortLabel As System.Windows.Forms.Label
        Private IpAddressLabel As System.Windows.Forms.Label
        Private AETitleLabel As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private label1 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label
        Private ServiceDisplayNameLabel As System.Windows.Forms.Label
        Private WithEvents buttonExit As System.Windows.Forms.Button
        Private WithEvents buttonAbout As System.Windows.Forms.Button
        Private WithEvents buttonSettings As System.Windows.Forms.Button
        Private toolTip As System.Windows.Forms.ToolTip
        Private WithEvents buttonStart As System.Windows.Forms.Button
        Private WithEvents buttonStop As System.Windows.Forms.Button
        Private labelStatus As System.Windows.Forms.Label
        Private label5 As System.Windows.Forms.Label
        Private pictureBoxSecure As System.Windows.Forms.PictureBox
        Friend WithEvents pictureBoxSecure1 As System.Windows.Forms.PictureBox
    End Class
End Namespace
