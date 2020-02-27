Namespace VBCustomizingWorklistDAL.UI
   Partial Class DicomTags
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
         Me.label1 = New System.Windows.Forms.Label()
         Me.ColumnTagsListView = New System.Windows.Forms.ListView()
         Me.TableColumnHeader = New System.Windows.Forms.ColumnHeader()
         Me.TableColumnColumnHeader = New System.Windows.Forms.ColumnHeader()
         Me.TagColumnHeader = New System.Windows.Forms.ColumnHeader()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(3, 6)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(445, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "The following columns will be added to the database to map the corresponding DICO" & "M Tags:"
         ' 
         ' ColumnTagsListView
         ' 
         Me.ColumnTagsListView.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.ColumnTagsListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TableColumnHeader, Me.TableColumnColumnHeader, Me.TagColumnHeader})
         Me.ColumnTagsListView.Location = New System.Drawing.Point(6, 25)
         Me.ColumnTagsListView.Name = "ColumnTagsListView"
         Me.ColumnTagsListView.Size = New System.Drawing.Size(439, 125)
         Me.ColumnTagsListView.TabIndex = 1
         Me.ColumnTagsListView.UseCompatibleStateImageBehavior = False
         Me.ColumnTagsListView.View = System.Windows.Forms.View.Details
         ' 
         ' TableColumnHeader
         ' 
         Me.TableColumnHeader.Text = "Table Name"
         Me.TableColumnHeader.Width = 156
         ' 
         ' TableColumnColumnHeader
         ' 
         Me.TableColumnColumnHeader.Text = "Column"
         Me.TableColumnColumnHeader.Width = 151
         ' 
         ' TagColumnHeader
         ' 
         Me.TagColumnHeader.Text = "DICOM Tag"
         Me.TagColumnHeader.Width = 121
         ' 
         ' DicomTags
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.ColumnTagsListView)
         Me.Controls.Add(Me.label1)
         Me.Name = "DicomTags"
         Me.Size = New System.Drawing.Size(455, 159)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private label1 As System.Windows.Forms.Label
      Private ColumnTagsListView As System.Windows.Forms.ListView
      Private TableColumnHeader As System.Windows.Forms.ColumnHeader
      Private TableColumnColumnHeader As System.Windows.Forms.ColumnHeader
      Private TagColumnHeader As System.Windows.Forms.ColumnHeader
   End Class
End Namespace
