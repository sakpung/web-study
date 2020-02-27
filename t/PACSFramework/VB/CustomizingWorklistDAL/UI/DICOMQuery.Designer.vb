Namespace VBCustomizingWorklistDAL.UI
   Partial Class DICOMQuery
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
         Me.QueryButton = New System.Windows.Forms.Button()
         Me.WorklistItemsListView = New System.Windows.Forms.ListView()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' QueryButton
         ' 
         Me.QueryButton.Location = New System.Drawing.Point(12, 27)
         Me.QueryButton.Name = "QueryButton"
         Me.QueryButton.Size = New System.Drawing.Size(160, 37)
         Me.QueryButton.TabIndex = 2
         Me.QueryButton.Text = "Simulate DICOM MWL Query"
         Me.QueryButton.UseVisualStyleBackColor = True
         ' 
         ' WorklistItemsListView
         ' 
         Me.WorklistItemsListView.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.WorklistItemsListView.FullRowSelect = True
         Me.WorklistItemsListView.GridLines = True
         Me.WorklistItemsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.WorklistItemsListView.Location = New System.Drawing.Point(11, 87)
         Me.WorklistItemsListView.MultiSelect = False
         Me.WorklistItemsListView.Name = "WorklistItemsListView"
         Me.WorklistItemsListView.Size = New System.Drawing.Size(726, 323)
         Me.WorklistItemsListView.TabIndex = 3
         Me.WorklistItemsListView.UseCompatibleStateImageBehavior = False
         Me.WorklistItemsListView.View = System.Windows.Forms.View.Details
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(11, 71)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(76, 13)
         Me.label2.TabIndex = 4
         Me.label2.Text = "Worklist Items:"
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(11, 9)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(710, 13)
         Me.label1.TabIndex = 5
         Me.label1.Text = "Click on Simulate DICOM Query to do a Modality Work-list C-Find Request, this wil" & "l request the new DICOM Tags in the query DataSet to be returned."
         ' 
         ' DICOMQuery
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.WorklistItemsListView)
         Me.Controls.Add(Me.QueryButton)
         Me.Name = "DICOMQuery"
         Me.Size = New System.Drawing.Size(743, 419)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private QueryButton As System.Windows.Forms.Button
      Private WorklistItemsListView As System.Windows.Forms.ListView
      Private label2 As System.Windows.Forms.Label
      Private label1 As System.Windows.Forms.Label
   End Class
End Namespace
