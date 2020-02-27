
Partial Class RegionForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegionForm))
      Me._chkRegionsOfInterest = New System.Windows.Forms.CheckBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me.label2 = New System.Windows.Forms.Label()
      Me._chkIncludeRegions = New System.Windows.Forms.CheckBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me._chkExcludeRegions = New System.Windows.Forms.CheckBox()
      Me._btnOK = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me.label4 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      ' 
      ' _chkRegionsOfInterest
      ' 
      Me._chkRegionsOfInterest.AutoSize = True
      Me._chkRegionsOfInterest.Checked = True
      Me._chkRegionsOfInterest.CheckState = System.Windows.Forms.CheckState.Checked
      Me._chkRegionsOfInterest.Location = New System.Drawing.Point(16, 54)
      Me._chkRegionsOfInterest.Name = "_chkRegionsOfInterest"
      Me._chkRegionsOfInterest.Size = New System.Drawing.Size(150, 17)
      Me._chkRegionsOfInterest.TabIndex = 0
      Me._chkRegionsOfInterest.Text = "Select Regions Of Interest"
      Me._chkRegionsOfInterest.UseVisualStyleBackColor = True
      ' 
      ' label1
      ' 
      Me.label1.Location = New System.Drawing.Point(33, 85)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(299, 47)
      Me.label1.TabIndex = 1
      Me.label1.Text = "Use this option to specify areas of the image which contain important features of" & " the form. These areas will be given more weight when the forms unique attribute" & "s are generated."
      ' 
      ' label2
      ' 
      Me.label2.Location = New System.Drawing.Point(33, 176)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(299, 64)
      Me.label2.TabIndex = 3
      Me.label2.Text = resources.GetString("label2.Text")
      ' 
      ' _chkIncludeRegions
      ' 
      Me._chkIncludeRegions.AutoSize = True
      Me._chkIncludeRegions.Location = New System.Drawing.Point(16, 145)
      Me._chkIncludeRegions.Name = "_chkIncludeRegions"
      Me._chkIncludeRegions.Size = New System.Drawing.Size(136, 17)
      Me._chkIncludeRegions.TabIndex = 2
      Me._chkIncludeRegions.Text = "Select Include Regions"
      Me._chkIncludeRegions.UseVisualStyleBackColor = True
      ' 
      ' label3
      ' 
      Me.label3.Location = New System.Drawing.Point(33, 282)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(299, 79)
      Me.label3.TabIndex = 5
      Me.label3.Text = resources.GetString("label3.Text")
      ' 
      ' _chkExcludeRegions
      ' 
      Me._chkExcludeRegions.AutoSize = True
      Me._chkExcludeRegions.Location = New System.Drawing.Point(16, 251)
      Me._chkExcludeRegions.Name = "_chkExcludeRegions"
      Me._chkExcludeRegions.Size = New System.Drawing.Size(139, 17)
      Me._chkExcludeRegions.TabIndex = 4
      Me._chkExcludeRegions.Text = "Select Exclude Regions"
      Me._chkExcludeRegions.UseVisualStyleBackColor = True
      ' 
      ' _btnOK
      ' 
      Me._btnOK.Location = New System.Drawing.Point(92, 378)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(86, 39)
      Me._btnOK.TabIndex = 6
      Me._btnOK.Text = "OK"
      Me._btnOK.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.Location = New System.Drawing.Point(184, 378)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(86, 39)
      Me._btnCancel.TabIndex = 7
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' label4
      ' 
      Me.label4.Location = New System.Drawing.Point(55, 22)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(249, 24)
      Me.label4.TabIndex = 8
      Me.label4.Text = "Check the type of regions you would like to select."
      ' 
      ' RegionForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(364, 433)
      Me.Controls.Add(Me.label4)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOK)
      Me.Controls.Add(Me.label3)
      Me.Controls.Add(Me._chkExcludeRegions)
      Me.Controls.Add(Me.label2)
      Me.Controls.Add(Me._chkIncludeRegions)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me._chkRegionsOfInterest)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.MaximizeBox = False
      Me.Name = "RegionForm"
      Me.Text = "Select Regions"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _chkRegionsOfInterest As System.Windows.Forms.CheckBox
   Private label1 As System.Windows.Forms.Label
   Private label2 As System.Windows.Forms.Label
   Private _chkIncludeRegions As System.Windows.Forms.CheckBox
   Private label3 As System.Windows.Forms.Label
   Private _chkExcludeRegions As System.Windows.Forms.CheckBox
   Private WithEvents _btnOK As System.Windows.Forms.Button
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private label4 As System.Windows.Forms.Label
End Class
