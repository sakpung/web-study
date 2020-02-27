Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Public Partial Class SupportedCapabilitiesForm
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
		 Me._btnClose = New System.Windows.Forms.Button()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me._lvCapabilities = New System.Windows.Forms.ListView()
		 Me._lblCapabilitiesCount = New System.Windows.Forms.Label()
		 Me.SuspendLayout()
		 ' 
		 ' _btnClose
		 ' 
		 Me._btnClose.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnClose.Location = New System.Drawing.Point(588, 454)
		 Me._btnClose.Name = "_btnClose"
		 Me._btnClose.Size = New System.Drawing.Size(75, 23)
		 Me._btnClose.TabIndex = 0
		 Me._btnClose.Text = "&Close"
		 Me._btnClose.UseVisualStyleBackColor = True
		 ' 
		 ' label1
		 ' 
		 Me.label1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(12, 459)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(118, 13)
		 Me.label1.TabIndex = 1
		 Me.label1.Text = "WIA Capabilities Count:"
		 ' 
		 ' _lvCapabilities
		 ' 
		 Me._lvCapabilities.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._lvCapabilities.FullRowSelect = True
		 Me._lvCapabilities.GridLines = True
		 Me._lvCapabilities.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		 Me._lvCapabilities.Location = New System.Drawing.Point(15, 12)
		 Me._lvCapabilities.MultiSelect = False
		 Me._lvCapabilities.Name = "_lvCapabilities"
		 Me._lvCapabilities.Size = New System.Drawing.Size(648, 436)
		 Me._lvCapabilities.TabIndex = 2
		 Me._lvCapabilities.UseCompatibleStateImageBehavior = False
		 Me._lvCapabilities.View = System.Windows.Forms.View.Details
'		 Me._lvCapabilities.MouseDoubleClick += New System.Windows.Forms.MouseEventHandler(Me._lvCapabilities_MouseDoubleClick);
		 ' 
		 ' _lblCapabilitiesCount
		 ' 
		 Me._lblCapabilitiesCount.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
		 Me._lblCapabilitiesCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		 Me._lblCapabilitiesCount.Location = New System.Drawing.Point(136, 458)
		 Me._lblCapabilitiesCount.Name = "_lblCapabilitiesCount"
		 Me._lblCapabilitiesCount.Size = New System.Drawing.Size(47, 18)
		 Me._lblCapabilitiesCount.TabIndex = 3
		 Me._lblCapabilitiesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		 ' 
		 ' SupportedCapabilitiesForm
		 ' 
		 Me.AcceptButton = Me._btnClose
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnClose
		 Me.ClientSize = New System.Drawing.Size(675, 489)
		 Me.Controls.Add(Me._lblCapabilitiesCount)
		 Me.Controls.Add(Me._lvCapabilities)
		 Me.Controls.Add(Me.label1)
		 Me.Controls.Add(Me._btnClose)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.MinimumSize = New System.Drawing.Size(338, 315)
		 Me.Name = "SupportedCapabilitiesForm"
		 Me.ShowInTaskbar = False
		 Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "WIA Supported Capabilities"
'		 Me.Load += New System.EventHandler(Me.SupportedCapabilitiesForm_Load);
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _btnClose As System.Windows.Forms.Button
	  Private label1 As System.Windows.Forms.Label
	  Private WithEvents _lvCapabilities As System.Windows.Forms.ListView
	  Private _lblCapabilitiesCount As System.Windows.Forms.Label
   End Class
End Namespace