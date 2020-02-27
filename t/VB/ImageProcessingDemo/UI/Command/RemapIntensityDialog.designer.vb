Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class RemapIntensityDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RemapIntensityDialog))
            Me._cmbChannel = New System.Windows.Forms.ComboBox
            Me._lblChannel = New System.Windows.Forms.Label
            Me._lblGraph = New System.Windows.Forms.Label
            Me._gbIntensity = New System.Windows.Forms.GroupBox
            Me._lblY = New System.Windows.Forms.Label
            Me._lblYVal = New System.Windows.Forms.Label
            Me._lblXVal = New System.Windows.Forms.Label
            Me._lblX = New System.Windows.Forms.Label
            Me._lblMapping = New System.Windows.Forms.Label
            Me._cmbMapping = New System.Windows.Forms.ComboBox
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbIntensity.SuspendLayout()
            Me.SuspendLayout()
            '
            '_cmbChannel
            '
            Me._cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbChannel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbChannel.FormattingEnabled = True
            Me._cmbChannel.Location = New System.Drawing.Point(252, 37)
            Me._cmbChannel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me._cmbChannel.Name = "_cmbChannel"
            Me._cmbChannel.Size = New System.Drawing.Size(119, 21)
            Me._cmbChannel.TabIndex = 0
            '
            '_lblChannel
            '
            Me._lblChannel.AutoSize = True
            Me._lblChannel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblChannel.Location = New System.Drawing.Point(250, 15)
            Me._lblChannel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me._lblChannel.Name = "_lblChannel"
            Me._lblChannel.Size = New System.Drawing.Size(46, 13)
            Me._lblChannel.TabIndex = 2
            Me._lblChannel.Text = "Channel"
            '
            '_lblGraph
            '
            Me._lblGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._lblGraph.Cursor = System.Windows.Forms.Cursors.Cross
            Me._lblGraph.Location = New System.Drawing.Point(5, 15)
            Me._lblGraph.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me._lblGraph.Name = "_lblGraph"
            Me._lblGraph.Size = New System.Drawing.Size(220, 208)
            Me._lblGraph.TabIndex = 3
            '
            '_gbIntensity
            '
            Me._gbIntensity.Controls.Add(Me._lblY)
            Me._gbIntensity.Controls.Add(Me._lblYVal)
            Me._gbIntensity.Controls.Add(Me._lblXVal)
            Me._gbIntensity.Controls.Add(Me._lblX)
            Me._gbIntensity.Controls.Add(Me._lblMapping)
            Me._gbIntensity.Controls.Add(Me._cmbMapping)
            Me._gbIntensity.Controls.Add(Me._lblGraph)
            Me._gbIntensity.Controls.Add(Me._lblChannel)
            Me._gbIntensity.Controls.Add(Me._cmbChannel)
            Me._gbIntensity.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbIntensity.Location = New System.Drawing.Point(10, 20)
            Me._gbIntensity.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me._gbIntensity.Name = "_gbIntensity"
            Me._gbIntensity.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me._gbIntensity.Size = New System.Drawing.Size(380, 259)
            Me._gbIntensity.TabIndex = 4
            Me._gbIntensity.TabStop = False
            Me._gbIntensity.Text = "Intensity"
            '
            '_lblY
            '
            Me._lblY.AutoSize = True
            Me._lblY.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblY.Location = New System.Drawing.Point(94, 231)
            Me._lblY.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me._lblY.Name = "_lblY"
            Me._lblY.Size = New System.Drawing.Size(17, 13)
            Me._lblY.TabIndex = 13
            Me._lblY.Text = "Y:"
            '
            '_lblYVal
            '
            Me._lblYVal.Location = New System.Drawing.Point(118, 230)
            Me._lblYVal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me._lblYVal.Name = "_lblYVal"
            Me._lblYVal.Size = New System.Drawing.Size(56, 19)
            Me._lblYVal.TabIndex = 12
            '
            '_lblXVal
            '
            Me._lblXVal.Location = New System.Drawing.Point(25, 231)
            Me._lblXVal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me._lblXVal.Name = "_lblXVal"
            Me._lblXVal.Size = New System.Drawing.Size(56, 19)
            Me._lblXVal.TabIndex = 11
            '
            '_lblX
            '
            Me._lblX.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblX.Location = New System.Drawing.Point(6, 230)
            Me._lblX.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me._lblX.Name = "_lblX"
            Me._lblX.Size = New System.Drawing.Size(19, 19)
            Me._lblX.TabIndex = 10
            Me._lblX.Text = "X:"
            '
            '_lblMapping
            '
            Me._lblMapping.AutoSize = True
            Me._lblMapping.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblMapping.Location = New System.Drawing.Point(250, 76)
            Me._lblMapping.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me._lblMapping.Name = "_lblMapping"
            Me._lblMapping.Size = New System.Drawing.Size(92, 13)
            Me._lblMapping.TabIndex = 5
            Me._lblMapping.Text = "Mapping Function"
            '
            '_cmbMapping
            '
            Me._cmbMapping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbMapping.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbMapping.FormattingEnabled = True
            Me._cmbMapping.Location = New System.Drawing.Point(250, 94)
            Me._cmbMapping.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me._cmbMapping.Name = "_cmbMapping"
            Me._cmbMapping.Size = New System.Drawing.Size(119, 21)
            Me._cmbMapping.TabIndex = 4
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(247, 300)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(86, 22)
            Me._btnCancel.TabIndex = 10
            Me._btnCancel.Text = "Cancel"
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(79, 300)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(86, 22)
            Me._btnOk.TabIndex = 9
            Me._btnOk.Text = "OK"
            '
            'RemapIntensityDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(400, 333)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbIntensity)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "RemapIntensityDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Remap Intensity"
            Me._gbIntensity.ResumeLayout(False)
            Me._gbIntensity.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _cmbChannel As System.Windows.Forms.ComboBox
	  Private _lblChannel As System.Windows.Forms.Label
	  Private WithEvents _lblGraph As System.Windows.Forms.Label
	  Private _gbIntensity As System.Windows.Forms.GroupBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _lblMapping As System.Windows.Forms.Label
	  Private WithEvents _cmbMapping As System.Windows.Forms.ComboBox
	  Private _lblY As System.Windows.Forms.Label
	  Private _lblYVal As System.Windows.Forms.Label
	  Private _lblXVal As System.Windows.Forms.Label
	  Private _lblX As System.Windows.Forms.Label
   End Class
End Namespace