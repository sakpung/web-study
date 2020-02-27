Imports Microsoft.VisualBasic
Imports System

Partial Public Class AboutDialog
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutDialog))
      Me._tb1 = New System.Windows.Forms.TextBox()
      Me._pb1 = New System.Windows.Forms.PictureBox()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._lblWebSite = New System.Windows.Forms.LinkLabel()
      CType(Me._pb1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      '_tb1
      '
      Me._tb1.AcceptsReturn = True
      Me._tb1.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me._tb1.Location = New System.Drawing.Point(47, 20)
      Me._tb1.Multiline = True
      Me._tb1.Name = "_tb1"
      Me._tb1.ReadOnly = True
      Me._tb1.Size = New System.Drawing.Size(331, 91)
      Me._tb1.TabIndex = 12
      Me._tb1.TabStop = False
      Me._tb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      '_pb1
      '
      Me._pb1.Image = CType(resources.GetObject("_pb1.Image"), System.Drawing.Image)
      Me._pb1.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._pb1.Location = New System.Drawing.Point(87, 117)
      Me._pb1.Name = "_pb1"
      Me._pb1.Size = New System.Drawing.Size(250, 58)
      Me._pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me._pb1.TabIndex = 13
      Me._pb1.TabStop = False
      '
      '_btnOk
      '
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._btnOk.Location = New System.Drawing.Point(175, 209)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 11
      Me._btnOk.Text = "OK"
      '
      '_lblWebSite
      '
      Me._lblWebSite.AutoSize = True
      Me._lblWebSite.Location = New System.Drawing.Point(147, 187)
      Me._lblWebSite.Name = "_lblWebSite"
      Me._lblWebSite.Size = New System.Drawing.Size(130, 13)
      Me._lblWebSite.TabIndex = 14
      Me._lblWebSite.TabStop = True
      Me._lblWebSite.Text = "https://www.leadtools.com"
      '
      'AboutDialog
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(424, 246)
      Me.Controls.Add(Me._lblWebSite)
      Me.Controls.Add(Me._tb1)
      Me.Controls.Add(Me._pb1)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AboutDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "About"
      CType(Me._pb1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _tb1 As System.Windows.Forms.TextBox
   Private WithEvents _pb1 As System.Windows.Forms.PictureBox
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Friend WithEvents _lblWebSite As System.Windows.Forms.LinkLabel
#End Region

End Class
