Namespace Leadtools.Demos.Workstation.Customized
   Partial Class WorkstastionFeaturesEventsView
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
         Me.EventsListView = New System.Windows.Forms.ListView()
         Me.FeatureIdColumnHeader = New System.Windows.Forms.ColumnHeader()
         Me.PublisherColumnHeader = New System.Windows.Forms.ColumnHeader()
         Me.StartButton = New System.Windows.Forms.Button()
         Me.StopButton = New System.Windows.Forms.Button()
         Me.CloseButton = New System.Windows.Forms.Button()
         Me.ClearButton = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' EventsListView
         ' 
         Me.EventsListView.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.EventsListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FeatureIdColumnHeader, Me.PublisherColumnHeader})
         Me.EventsListView.Location = New System.Drawing.Point(5, 5)
         Me.EventsListView.MultiSelect = False
         Me.EventsListView.Name = "EventsListView"
         Me.EventsListView.Size = New System.Drawing.Size(547, 376)
         Me.EventsListView.TabIndex = 0
         Me.EventsListView.UseCompatibleStateImageBehavior = False
         Me.EventsListView.View = System.Windows.Forms.View.Details
         ' 
         ' FeatureIdColumnHeader
         ' 
         Me.FeatureIdColumnHeader.Text = "Feature ID"
         Me.FeatureIdColumnHeader.Width = 186
         ' 
         ' PublisherColumnHeader
         ' 
         Me.PublisherColumnHeader.Text = "Publisher"
         Me.PublisherColumnHeader.Width = 346
         ' 
         ' StartButton
         ' 
         Me.StartButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
         Me.StartButton.Location = New System.Drawing.Point(5, 387)
         Me.StartButton.Name = "StartButton"
         Me.StartButton.Size = New System.Drawing.Size(75, 23)
         Me.StartButton.TabIndex = 1
         Me.StartButton.Text = "Start"
         Me.StartButton.UseVisualStyleBackColor = True
         ' 
         ' StopButton
         ' 
         Me.StopButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
         Me.StopButton.Location = New System.Drawing.Point(86, 387)
         Me.StopButton.Name = "StopButton"
         Me.StopButton.Size = New System.Drawing.Size(75, 23)
         Me.StopButton.TabIndex = 2
         Me.StopButton.Text = "Stop"
         Me.StopButton.UseVisualStyleBackColor = True
         ' 
         ' CloseButton
         ' 
         Me.CloseButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.CloseButton.Location = New System.Drawing.Point(473, 387)
         Me.CloseButton.Name = "CloseButton"
         Me.CloseButton.Size = New System.Drawing.Size(75, 23)
         Me.CloseButton.TabIndex = 3
         Me.CloseButton.Text = "Close"
         Me.CloseButton.UseVisualStyleBackColor = True
         ' 
         ' ClearButton
         ' 
         Me.ClearButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
         Me.ClearButton.Location = New System.Drawing.Point(167, 387)
         Me.ClearButton.Name = "ClearButton"
         Me.ClearButton.Size = New System.Drawing.Size(75, 23)
         Me.ClearButton.TabIndex = 4
         Me.ClearButton.Text = "Clear"
         Me.ClearButton.UseVisualStyleBackColor = True
         ' 
         ' WorkstastionFeaturesEventsView
         ' 
         Me.AcceptButton = Me.CloseButton
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(557, 416)
         Me.Controls.Add(Me.ClearButton)
         Me.Controls.Add(Me.CloseButton)
         Me.Controls.Add(Me.StopButton)
         Me.Controls.Add(Me.StartButton)
         Me.Controls.Add(Me.EventsListView)
         Me.Name = "WorkstastionFeaturesEventsView"
         Me.ShowIcon = False
         Me.Text = "Workstastion Features Events"
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private EventsListView As System.Windows.Forms.ListView
      Private StartButton As System.Windows.Forms.Button
      Private StopButton As System.Windows.Forms.Button
      Private CloseButton As System.Windows.Forms.Button
      Private ClearButton As System.Windows.Forms.Button
      Private FeatureIdColumnHeader As System.Windows.Forms.ColumnHeader
      Private PublisherColumnHeader As System.Windows.Forms.ColumnHeader
   End Class
End Namespace