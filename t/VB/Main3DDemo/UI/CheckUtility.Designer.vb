Namespace Main3DDemo
   Partial Class CheckUtilityDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckUtilityDialog))
         Me._btnOK = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._lblDepthOperation = New Main3DDemo.CheckLabel()
         Me._lblBlending = New Main3DDemo.CheckLabel()
         Me._lblBackBuffer = New Main3DDemo.CheckLabel()
         Me._lblTexturing = New Main3DDemo.CheckLabel()
         Me._lblHardwareShaderAvailable = New Main3DDemo.CheckLabel()
         Me._lblPixelShaderAvailable = New Main3DDemo.CheckLabel()
         Me._lblVertexShaderAvailable = New Main3DDemo.CheckLabel()
         Me._lblDirectXVersionAvailable = New Main3DDemo.CheckLabel()
         Me.label10 = New System.Windows.Forms.Label()
         Me._label9 = New System.Windows.Forms.Label()
         Me.label8 = New System.Windows.Forms.Label()
         Me.label7 = New System.Windows.Forms.Label()
         Me.label6 = New System.Windows.Forms.Label()
         Me.label5 = New System.Windows.Forms.Label()
         Me.label4 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.label22 = New System.Windows.Forms.Label()
         Me.label23 = New System.Windows.Forms.Label()
         Me.label24 = New System.Windows.Forms.Label()
         Me._lblMaximum3D = New System.Windows.Forms.Label()
         Me.label25 = New System.Windows.Forms.Label()
         Me._lblMaximum2D = New System.Windows.Forms.Label()
         Me.label34 = New System.Windows.Forms.Label()
         Me._lblSharedGPU = New System.Windows.Forms.Label()
         Me._lblDirectXVersion = New System.Windows.Forms.Label()
         Me._lblDedicatedGPU = New System.Windows.Forms.Label()
         Me.label18 = New System.Windows.Forms.Label()
         Me.label17 = New System.Windows.Forms.Label()
         Me.label16 = New System.Windows.Forms.Label()
         Me.label14 = New System.Windows.Forms.Label()
         Me.label12 = New System.Windows.Forms.Label()
         Me.label9 = New System.Windows.Forms.Label()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me._lblVertexShaderSuccess = New Main3DDemo.CheckLabel()
         Me._lblPixelShaderSuccess = New Main3DDemo.CheckLabel()
         Me._lblDirectXVersionSuccess = New Main3DDemo.CheckLabel()
         Me.groupBox1.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         resources.ApplyResources(Me._btnOK, "_btnOK")
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._lblDepthOperation)
         Me.groupBox1.Controls.Add(Me._lblBlending)
         Me.groupBox1.Controls.Add(Me._lblBackBuffer)
         Me.groupBox1.Controls.Add(Me._lblTexturing)
         Me.groupBox1.Controls.Add(Me._lblHardwareShaderAvailable)
         Me.groupBox1.Controls.Add(Me._lblPixelShaderAvailable)
         Me.groupBox1.Controls.Add(Me._lblVertexShaderAvailable)
         Me.groupBox1.Controls.Add(Me._lblDirectXVersionAvailable)
         Me.groupBox1.Controls.Add(Me.label10)
         Me.groupBox1.Controls.Add(Me._label9)
         Me.groupBox1.Controls.Add(Me.label8)
         Me.groupBox1.Controls.Add(Me.label7)
         Me.groupBox1.Controls.Add(Me.label6)
         Me.groupBox1.Controls.Add(Me.label5)
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me.label3)
         resources.ApplyResources(Me.groupBox1, "groupBox1")
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.TabStop = False
         ' 
         ' _lblDepthOperation
         ' 
         Me._lblDepthOperation.BackColor = System.Drawing.SystemColors.Control
         Me._lblDepthOperation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblDepthOperation.Checked = False
         resources.ApplyResources(Me._lblDepthOperation, "_lblDepthOperation")
         Me._lblDepthOperation.Name = "_lblDepthOperation"
         ' 
         ' _lblBlending
         ' 
         Me._lblBlending.BackColor = System.Drawing.SystemColors.Control
         Me._lblBlending.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblBlending.Checked = False
         resources.ApplyResources(Me._lblBlending, "_lblBlending")
         Me._lblBlending.Name = "_lblBlending"
         ' 
         ' _lblBackBuffer
         ' 
         Me._lblBackBuffer.BackColor = System.Drawing.SystemColors.Control
         Me._lblBackBuffer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblBackBuffer.Checked = False
         resources.ApplyResources(Me._lblBackBuffer, "_lblBackBuffer")
         Me._lblBackBuffer.Name = "_lblBackBuffer"
         ' 
         ' _lblTexturing
         ' 
         Me._lblTexturing.BackColor = System.Drawing.SystemColors.Control
         Me._lblTexturing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblTexturing.Checked = False
         resources.ApplyResources(Me._lblTexturing, "_lblTexturing")
         Me._lblTexturing.Name = "_lblTexturing"
         ' 
         ' _lblHardwareShaderAvailable
         ' 
         Me._lblHardwareShaderAvailable.BackColor = System.Drawing.SystemColors.Control
         Me._lblHardwareShaderAvailable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblHardwareShaderAvailable.Checked = False
         resources.ApplyResources(Me._lblHardwareShaderAvailable, "_lblHardwareShaderAvailable")
         Me._lblHardwareShaderAvailable.Name = "_lblHardwareShaderAvailable"
         ' 
         ' _lblPixelShaderAvailable
         ' 
         Me._lblPixelShaderAvailable.BackColor = System.Drawing.SystemColors.Control
         Me._lblPixelShaderAvailable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblPixelShaderAvailable.Checked = False
         resources.ApplyResources(Me._lblPixelShaderAvailable, "_lblPixelShaderAvailable")
         Me._lblPixelShaderAvailable.Name = "_lblPixelShaderAvailable"
         ' 
         ' _lblVertexShaderAvailable
         ' 
         Me._lblVertexShaderAvailable.BackColor = System.Drawing.SystemColors.Control
         Me._lblVertexShaderAvailable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblVertexShaderAvailable.Checked = False
         resources.ApplyResources(Me._lblVertexShaderAvailable, "_lblVertexShaderAvailable")
         Me._lblVertexShaderAvailable.Name = "_lblVertexShaderAvailable"
         ' 
         ' _lblDirectXVersionAvailable
         ' 
         Me._lblDirectXVersionAvailable.BackColor = System.Drawing.SystemColors.Control
         Me._lblDirectXVersionAvailable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblDirectXVersionAvailable.Checked = False
         resources.ApplyResources(Me._lblDirectXVersionAvailable, "_lblDirectXVersionAvailable")
         Me._lblDirectXVersionAvailable.Name = "_lblDirectXVersionAvailable"
         ' 
         ' label10
         ' 
         resources.ApplyResources(Me.label10, "label10")
         Me.label10.Name = "label10"
         ' 
         ' _label9
         ' 
         resources.ApplyResources(Me._label9, "_label9")
         Me._label9.Name = "_label9"
         ' 
         ' label8
         ' 
         resources.ApplyResources(Me.label8, "label8")
         Me.label8.Name = "label8"
         ' 
         ' label7
         ' 
         resources.ApplyResources(Me.label7, "label7")
         Me.label7.Name = "label7"
         ' 
         ' label6
         ' 
         resources.ApplyResources(Me.label6, "label6")
         Me.label6.Name = "label6"
         ' 
         ' label5
         ' 
         resources.ApplyResources(Me.label5, "label5")
         Me.label5.Name = "label5"
         ' 
         ' label4
         ' 
         resources.ApplyResources(Me.label4, "label4")
         Me.label4.Name = "label4"
         ' 
         ' label3
         ' 
         resources.ApplyResources(Me.label3, "label3")
         Me.label3.Name = "label3"
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me.label22)
         Me.groupBox2.Controls.Add(Me.label23)
         Me.groupBox2.Controls.Add(Me.label24)
         Me.groupBox2.Controls.Add(Me._lblMaximum3D)
         Me.groupBox2.Controls.Add(Me.label25)
         Me.groupBox2.Controls.Add(Me._lblMaximum2D)
         Me.groupBox2.Controls.Add(Me.label34)
         Me.groupBox2.Controls.Add(Me._lblSharedGPU)
         Me.groupBox2.Controls.Add(Me._lblDirectXVersion)
         Me.groupBox2.Controls.Add(Me._lblDedicatedGPU)
         resources.ApplyResources(Me.groupBox2, "groupBox2")
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.TabStop = False
         ' 
         ' label22
         ' 
         resources.ApplyResources(Me.label22, "label22")
         Me.label22.Name = "label22"
         ' 
         ' label23
         ' 
         resources.ApplyResources(Me.label23, "label23")
         Me.label23.Name = "label23"
         ' 
         ' label24
         ' 
         resources.ApplyResources(Me.label24, "label24")
         Me.label24.Name = "label24"
         ' 
         ' _lblMaximum3D
         ' 
         Me._lblMaximum3D.BackColor = System.Drawing.SystemColors.Control
         Me._lblMaximum3D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         resources.ApplyResources(Me._lblMaximum3D, "_lblMaximum3D")
         Me._lblMaximum3D.Name = "_lblMaximum3D"
         ' 
         ' label25
         ' 
         resources.ApplyResources(Me.label25, "label25")
         Me.label25.Name = "label25"
         ' 
         ' _lblMaximum2D
         ' 
         Me._lblMaximum2D.BackColor = System.Drawing.SystemColors.Control
         Me._lblMaximum2D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         resources.ApplyResources(Me._lblMaximum2D, "_lblMaximum2D")
         Me._lblMaximum2D.Name = "_lblMaximum2D"
         ' 
         ' label34
         ' 
         resources.ApplyResources(Me.label34, "label34")
         Me.label34.Name = "label34"
         ' 
         ' _lblSharedGPU
         ' 
         Me._lblSharedGPU.BackColor = System.Drawing.SystemColors.Control
         Me._lblSharedGPU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         resources.ApplyResources(Me._lblSharedGPU, "_lblSharedGPU")
         Me._lblSharedGPU.Name = "_lblSharedGPU"
         ' 
         ' _lblDirectXVersion
         ' 
         Me._lblDirectXVersion.BackColor = System.Drawing.SystemColors.Control
         Me._lblDirectXVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         resources.ApplyResources(Me._lblDirectXVersion, "_lblDirectXVersion")
         Me._lblDirectXVersion.Name = "_lblDirectXVersion"
         ' 
         ' _lblDedicatedGPU
         ' 
         Me._lblDedicatedGPU.BackColor = System.Drawing.SystemColors.Control
         Me._lblDedicatedGPU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         resources.ApplyResources(Me._lblDedicatedGPU, "_lblDedicatedGPU")
         Me._lblDedicatedGPU.Name = "_lblDedicatedGPU"
         ' 
         ' label18
         ' 
         Me.label18.BackColor = System.Drawing.SystemColors.Control
         Me.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         resources.ApplyResources(Me.label18, "label18")
         Me.label18.Name = "label18"
         ' 
         ' label17
         ' 
         Me.label17.BackColor = System.Drawing.SystemColors.Control
         Me.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         resources.ApplyResources(Me.label17, "label17")
         Me.label17.Name = "label17"
         ' 
         ' label16
         ' 
         Me.label16.BackColor = System.Drawing.SystemColors.Control
         Me.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         resources.ApplyResources(Me.label16, "label16")
         Me.label16.Name = "label16"
         ' 
         ' label14
         ' 
         resources.ApplyResources(Me.label14, "label14")
         Me.label14.Name = "label14"
         ' 
         ' label12
         ' 
         resources.ApplyResources(Me.label12, "label12")
         Me.label12.Name = "label12"
         ' 
         ' label9
         ' 
         resources.ApplyResources(Me.label9, "label9")
         Me.label9.Name = "label9"
         ' 
         ' groupBox3
         ' 
         Me.groupBox3.Controls.Add(Me._lblVertexShaderSuccess)
         Me.groupBox3.Controls.Add(Me._lblPixelShaderSuccess)
         Me.groupBox3.Controls.Add(Me._lblDirectXVersionSuccess)
         Me.groupBox3.Controls.Add(Me.label9)
         Me.groupBox3.Controls.Add(Me.label12)
         Me.groupBox3.Controls.Add(Me.label14)
         Me.groupBox3.Controls.Add(Me.label16)
         Me.groupBox3.Controls.Add(Me.label17)
         Me.groupBox3.Controls.Add(Me.label18)
         resources.ApplyResources(Me.groupBox3, "groupBox3")
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.TabStop = False
         ' 
         ' _lblVertexShaderSuccess
         ' 
         Me._lblVertexShaderSuccess.BackColor = System.Drawing.SystemColors.Control
         Me._lblVertexShaderSuccess.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblVertexShaderSuccess.Checked = False
         resources.ApplyResources(Me._lblVertexShaderSuccess, "_lblVertexShaderSuccess")
         Me._lblVertexShaderSuccess.Name = "_lblVertexShaderSuccess"
         ' 
         ' _lblPixelShaderSuccess
         ' 
         Me._lblPixelShaderSuccess.BackColor = System.Drawing.SystemColors.Control
         Me._lblPixelShaderSuccess.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblPixelShaderSuccess.Checked = False
         resources.ApplyResources(Me._lblPixelShaderSuccess, "_lblPixelShaderSuccess")
         Me._lblPixelShaderSuccess.Name = "_lblPixelShaderSuccess"
         ' 
         ' _lblDirectXVersionSuccess
         ' 
         Me._lblDirectXVersionSuccess.BackColor = System.Drawing.SystemColors.Control
         Me._lblDirectXVersionSuccess.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblDirectXVersionSuccess.Checked = False
         resources.ApplyResources(Me._lblDirectXVersionSuccess, "_lblDirectXVersionSuccess")
         Me._lblDirectXVersionSuccess.Name = "_lblDirectXVersionSuccess"
         ' 
         ' CheckUtilityDialog
         ' 
         Me.AcceptButton = Me._btnOK
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnOK
         Me.Controls.Add(Me.groupBox3)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "CheckUtilityDialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox3.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _btnOK As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label10 As System.Windows.Forms.Label
      Private _label9 As System.Windows.Forms.Label
      Private label8 As System.Windows.Forms.Label
      Private label7 As System.Windows.Forms.Label
      Private label6 As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private _lblDirectXVersionAvailable As CheckLabel
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private label22 As System.Windows.Forms.Label
      Private label23 As System.Windows.Forms.Label
      Private label24 As System.Windows.Forms.Label
      Private label25 As System.Windows.Forms.Label
      Private label34 As System.Windows.Forms.Label
      Private _lblBlending As CheckLabel
      Private _lblBackBuffer As CheckLabel
      Private _lblTexturing As CheckLabel
      Private _lblHardwareShaderAvailable As CheckLabel
      Private _lblPixelShaderAvailable As CheckLabel
      Private _lblVertexShaderAvailable As CheckLabel
      Private _lblDepthOperation As CheckLabel
      Private _lblMaximum3D As System.Windows.Forms.Label
      Private _lblMaximum2D As System.Windows.Forms.Label
      Private _lblSharedGPU As System.Windows.Forms.Label
      Private _lblDirectXVersion As System.Windows.Forms.Label
      Private _lblDedicatedGPU As System.Windows.Forms.Label
      Private label18 As System.Windows.Forms.Label
      Private label17 As System.Windows.Forms.Label
      Private label16 As System.Windows.Forms.Label
      Private label14 As System.Windows.Forms.Label
      Private label12 As System.Windows.Forms.Label
      Private label9 As System.Windows.Forms.Label
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private _lblDirectXVersionSuccess As CheckLabel
      Private _lblVertexShaderSuccess As CheckLabel
      Private _lblPixelShaderSuccess As CheckLabel
   End Class
End Namespace