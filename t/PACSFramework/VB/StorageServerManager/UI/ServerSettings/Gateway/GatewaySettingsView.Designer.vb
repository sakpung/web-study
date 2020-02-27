Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class GatewaySettingsView
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
         Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
         Me.label1 = New System.Windows.Forms.Label()
         Me.NumberOfTimesToUseSecondaryServerNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me.GatewaysItemsGridView = New Leadtools.Demos.StorageServer.UI.ItemsGridView()
         Me.RemoteServersItemsGridView = New Leadtools.Demos.StorageServer.UI.ItemsGridView()
         Me.splitContainer1.Panel1.SuspendLayout()
         Me.splitContainer1.Panel2.SuspendLayout()
         Me.splitContainer1.SuspendLayout()
         CType(Me.NumberOfTimesToUseSecondaryServerNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' splitContainer1
         ' 
         Me.splitContainer1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
         Me.splitContainer1.Name = "splitContainer1"
         Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
         ' 
         ' splitContainer1.Panel1
         ' 
         Me.splitContainer1.Panel1.Controls.Add(Me.GatewaysItemsGridView)
         ' 
         ' splitContainer1.Panel2
         ' 
         Me.splitContainer1.Panel2.Controls.Add(Me.RemoteServersItemsGridView)
         Me.splitContainer1.Size = New System.Drawing.Size(672, 481)
         Me.splitContainer1.SplitterDistance = 244
         Me.splitContainer1.TabIndex = 0
         ' 
         ' label1
         ' 
         Me.label1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(3, 486)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(287, 13)
         Me.label1.TabIndex = 1
         Me.label1.Text = "Number of times to use remote server when a previous fails:"
         ' 
         ' NumberOfTimesToUseSecondaryServerNumericUpDown
         ' 
         Me.NumberOfTimesToUseSecondaryServerNumericUpDown.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
         Me.NumberOfTimesToUseSecondaryServerNumericUpDown.Location = New System.Drawing.Point(292, 484)
         Me.NumberOfTimesToUseSecondaryServerNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me.NumberOfTimesToUseSecondaryServerNumericUpDown.Name = "NumberOfTimesToUseSecondaryServerNumericUpDown"
         Me.NumberOfTimesToUseSecondaryServerNumericUpDown.Size = New System.Drawing.Size(58, 20)
         Me.NumberOfTimesToUseSecondaryServerNumericUpDown.TabIndex = 2
         Me.NumberOfTimesToUseSecondaryServerNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
         ' 
         ' GatewaysItemsGridView
         ' 
         Me.GatewaysItemsGridView.CanAdd = True
         Me.GatewaysItemsGridView.DataMember = ""
         Me.GatewaysItemsGridView.DataSource = Nothing
         Me.GatewaysItemsGridView.Dock = System.Windows.Forms.DockStyle.Fill
         Me.GatewaysItemsGridView.Location = New System.Drawing.Point(0, 0)
         Me.GatewaysItemsGridView.Name = "GatewaysItemsGridView"
         Me.GatewaysItemsGridView.Size = New System.Drawing.Size(672, 244)
         Me.GatewaysItemsGridView.TabIndex = 0
         Me.GatewaysItemsGridView.Title = "Gateways"
         ' 
         ' RemoteServersItemsGridView
         ' 
         Me.RemoteServersItemsGridView.CanAdd = True
         Me.RemoteServersItemsGridView.DataMember = ""
         Me.RemoteServersItemsGridView.DataSource = Nothing
         Me.RemoteServersItemsGridView.Dock = System.Windows.Forms.DockStyle.Fill
         Me.RemoteServersItemsGridView.Location = New System.Drawing.Point(0, 0)
         Me.RemoteServersItemsGridView.Name = "RemoteServersItemsGridView"
         Me.RemoteServersItemsGridView.Size = New System.Drawing.Size(672, 233)
         Me.RemoteServersItemsGridView.TabIndex = 1
         Me.RemoteServersItemsGridView.Title = "Remote Servers"
         ' 
         ' GatewaySettingsView
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.NumberOfTimesToUseSecondaryServerNumericUpDown)
         Me.Controls.Add(Me.splitContainer1)
         Me.Name = "GatewaySettingsView"
         Me.Size = New System.Drawing.Size(672, 509)
         Me.splitContainer1.Panel1.ResumeLayout(False)
         Me.splitContainer1.Panel2.ResumeLayout(False)
         Me.splitContainer1.ResumeLayout(False)
         CType(Me.NumberOfTimesToUseSecondaryServerNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private splitContainer1 As System.Windows.Forms.SplitContainer
      Public GatewaysItemsGridView As ItemsGridView
      Public RemoteServersItemsGridView As ItemsGridView
      Private label1 As System.Windows.Forms.Label
      Private NumberOfTimesToUseSecondaryServerNumericUpDown As System.Windows.Forms.NumericUpDown
   End Class
End Namespace
