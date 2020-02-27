Namespace MainDemo
   Partial Public Class KMeansDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KMeansDialog))
         Me.label1 = New System.Windows.Forms.Label()
         Me._numClusters = New System.Windows.Forms.NumericUpDown()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me.label2 = New System.Windows.Forms.Label()
         Me._cbType = New System.Windows.Forms.ComboBox()
         CType(Me._numClusters, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         resources.ApplyResources(Me.label1, "label1")
         Me.label1.Name = "label1"
         ' 
         ' _numClusters
         ' 
         resources.ApplyResources(Me._numClusters, "_numClusters")
         Me._numClusters.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
         Me._numClusters.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
         Me._numClusters.Name = "_numClusters"
         Me._numClusters.Value = New Decimal(New Integer() {5, 0, 0, 0})
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         resources.ApplyResources(Me._btnCancel, "_btnCancel")
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         resources.ApplyResources(Me._btnOk, "_btnOk")
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.UseVisualStyleBackColor = True
         ' 
         ' label2
         ' 
         resources.ApplyResources(Me.label2, "label2")
         Me.label2.Name = "label2"
         ' 
         ' _cbType
         ' 
         Me._cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbType.FormattingEnabled = True
         Me._cbType.Items.AddRange(New Object() {resources.GetString("_cbType.Items"), resources.GetString("_cbType.Items1")})
         resources.ApplyResources(Me._cbType, "_cbType")
         Me._cbType.Name = "_cbType"
         ' 
         ' KMeansDialog
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._cbType)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me._numClusters)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "KMeansDialog"
         Me.ShowIcon = False
         CType(Me._numClusters, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private label1 As System.Windows.Forms.Label
      Private _numClusters As System.Windows.Forms.NumericUpDown
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private label2 As System.Windows.Forms.Label
      Private _cbType As System.Windows.Forms.ComboBox
   End Class
End Namespace