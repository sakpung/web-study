
Partial Class KMeansDialog
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
      Me._cbType = New System.Windows.Forms.ComboBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._numClusters = New System.Windows.Forms.NumericUpDown()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me.panel1 = New System.Windows.Forms.Panel()
      CType(Me._numClusters, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panel1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _cbType
      ' 
      Me._cbType.FormattingEnabled = True
      Me._cbType.Items.AddRange(New Object() {"Random", "Uniform"})
      Me._cbType.Location = New System.Drawing.Point(85, 45)
      Me._cbType.Name = "_cbType"
      Me._cbType.Size = New System.Drawing.Size(121, 21)
      Me._cbType.TabIndex = 15
      ' 
      ' label2
      ' 
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(13, 48)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(31, 13)
      Me.label2.TabIndex = 14
      Me.label2.Text = "Type"
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(13, 21)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(44, 13)
      Me.label1.TabIndex = 13
      Me.label1.Text = "Clusters"
      ' 
      ' _numClusters
      ' 
      Me._numClusters.Location = New System.Drawing.Point(85, 19)
      Me._numClusters.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numClusters.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
      Me._numClusters.Name = "_numClusters"
      Me._numClusters.Size = New System.Drawing.Size(120, 20)
      Me._numClusters.TabIndex = 12
      Me._numClusters.Value = New Decimal(New Integer() {5, 0, 0, 0})
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(129, 100)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 11
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.Location = New System.Drawing.Point(48, 100)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 10
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' panel1
      ' 
      Me.panel1.Controls.Add(Me._numClusters)
      Me.panel1.Controls.Add(Me.label2)
      Me.panel1.Controls.Add(Me._cbType)
      Me.panel1.Controls.Add(Me.label1)
      Me.panel1.Location = New System.Drawing.Point(15, 12)
      Me.panel1.Name = "panel1"
      Me.panel1.Size = New System.Drawing.Size(223, 82)
      Me.panel1.TabIndex = 16
      ' 
      ' KMeansDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(253, 134)
      Me.Controls.Add(Me.panel1)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "KMeansDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "KMeans"
      CType(Me._numClusters, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panel1.ResumeLayout(False)
      Me.panel1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _cbType As System.Windows.Forms.ComboBox
   Private label2 As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private _numClusters As System.Windows.Forms.NumericUpDown
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private panel1 As System.Windows.Forms.Panel
End Class