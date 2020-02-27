Imports Microsoft.VisualBasic
Imports System

Partial Public Class CaptureStillImagesForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaptureStillImagesForm))
      Me._btnTakePicture = New System.Windows.Forms.Button()
      Me._btnLoadPictures = New System.Windows.Forms.Button()
      Me._btnClose = New System.Windows.Forms.Button()
      Me.label1 = New System.Windows.Forms.Label()
      Me._pnlBrowser = New System.Windows.Forms.Panel()
      Me._pnlVideoPreview = New System.Windows.Forms.Panel()
      Me.SuspendLayout()
      ' 
      ' _btnTakePicture
      ' 
      Me._btnTakePicture.Anchor = System.Windows.Forms.AnchorStyles.Bottom
      Me._btnTakePicture.Location = New System.Drawing.Point(71, 227)
      Me._btnTakePicture.Name = "_btnTakePicture"
      Me._btnTakePicture.Size = New System.Drawing.Size(96, 23)
      Me._btnTakePicture.TabIndex = 4
      Me._btnTakePicture.Text = "&Take Picture"
      Me._btnTakePicture.UseVisualStyleBackColor = True
      '         Me._btnTakePicture.Click += New System.EventHandler(Me._btnTakePicture_Click);
      ' 
      ' _btnLoadPictures
      ' 
      Me._btnLoadPictures.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._btnLoadPictures.Location = New System.Drawing.Point(236, 227)
      Me._btnLoadPictures.Name = "_btnLoadPictures"
      Me._btnLoadPictures.Size = New System.Drawing.Size(96, 23)
      Me._btnLoadPictures.TabIndex = 5
      Me._btnLoadPictures.Text = "&Load Pictures"
      Me._btnLoadPictures.UseVisualStyleBackColor = True
      '         Me._btnLoadPictures.Click += New System.EventHandler(Me._btnLoadPictures_Click);
      ' 
      ' _btnClose
      ' 
      Me._btnClose.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnClose.Location = New System.Drawing.Point(338, 227)
      Me._btnClose.Name = "_btnClose"
      Me._btnClose.Size = New System.Drawing.Size(96, 23)
      Me._btnClose.TabIndex = 6
      Me._btnClose.Text = "&Close"
      Me._btnClose.UseVisualStyleBackColor = True
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(12, 9)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(371, 13)
      Me.label1.TabIndex = 0
      Me.label1.Text = "Click the ""Take Picture"" button to capture a picture from the streaming video."
      ' 
      ' _pnlBrowser
      ' 
      Me._pnlBrowser.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._pnlBrowser.BackColor = System.Drawing.Color.Bisque
      Me._pnlBrowser.Location = New System.Drawing.Point(258, 47)
      Me._pnlBrowser.Name = "_pnlBrowser"
      Me._pnlBrowser.Size = New System.Drawing.Size(176, 158)
      Me._pnlBrowser.TabIndex = 3
      ' 
      ' _pnlVideoPreview
      ' 
      Me._pnlVideoPreview.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._pnlVideoPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._pnlVideoPreview.Location = New System.Drawing.Point(12, 47)
      Me._pnlVideoPreview.Name = "_pnlVideoPreview"
      Me._pnlVideoPreview.Size = New System.Drawing.Size(239, 158)
      Me._pnlVideoPreview.TabIndex = 2
      '         Me._pnlVideoPreview.SizeChanged += New System.EventHandler(Me._pnlVideoPreview_SizeChanged);
      ' 
      ' CaptureStillImagesForm
      ' 
      Me.AcceptButton = Me._btnTakePicture
      Me.CancelButton = Me._btnClose
      Me.ClientSize = New System.Drawing.Size(446, 262)
      Me.Controls.Add(Me._btnTakePicture)
      Me.Controls.Add(Me._btnLoadPictures)
      Me.Controls.Add(Me._btnClose)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me._pnlBrowser)
      Me.Controls.Add(Me._pnlVideoPreview)
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.MinimumSize = New System.Drawing.Size(454, 296)
      Me.Name = "CaptureStillImagesForm"
      Me.ShowInTaskbar = False
      Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Capture Still Images From Streaming Video"
      '         Me.FormClosed += New System.Windows.Forms.FormClosedEventHandler(Me.CaptureStillImagesForm_FormClosed);
      '         Me.Load += New System.EventHandler(Me.CaptureStillImagesForm_Load);
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _btnTakePicture As System.Windows.Forms.Button
   Private WithEvents _btnLoadPictures As System.Windows.Forms.Button
   Private _btnClose As System.Windows.Forms.Button
   Private label1 As System.Windows.Forms.Label
   Private _pnlBrowser As System.Windows.Forms.Panel
   Private WithEvents _pnlVideoPreview As System.Windows.Forms.Panel
End Class
