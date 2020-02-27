Imports Microsoft.VisualBasic
Imports System

Namespace MainDemo
   Partial Public Class MatchHistogramDialog

      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If (disposing AndAlso (Not (Me.components) Is Nothing)) Then
            Me.components.Dispose()
         End If

         MyBase.Dispose(disposing)
      End Sub
#Region "Windows Form Designer generated code"

      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MatchHistogramDialog))
         Me._btnCancel = New System.Windows.Forms.Button
         Me._btnOk = New System.Windows.Forms.Button
         Me._tsbtnNormal = New System.Windows.Forms.ToolStripButton
         Me._tsbtnFit = New System.Windows.Forms.ToolStripButton
         Me._pbProgress = New System.Windows.Forms.ProgressBar
         Me._tsZoomLevel = New System.Windows.Forms.ToolStrip
         Me._lblREF = New System.Windows.Forms.Label
         Me._lblDST = New System.Windows.Forms.Label
         Me._lblseparator1 = New System.Windows.Forms.Label
         Me._lblseparator2 = New System.Windows.Forms.Label
         Me._lblREFlabel = New System.Windows.Forms.Label
         Me._lblDSTlabel = New System.Windows.Forms.Label
         Me._cmbREFImage = New System.Windows.Forms.ComboBox
         Me._tsZoomLevel.SuspendLayout()
         Me.SuspendLayout()
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
         ' _tsbtnNormal
         ' 
         Me._tsbtnNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         resources.ApplyResources(Me._tsbtnNormal, "_tsbtnNormal")
         Me._tsbtnNormal.Name = "_tsbtnNormal"
         ' 
         ' _tsbtnFit
         ' 
         Me._tsbtnFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         resources.ApplyResources(Me._tsbtnFit, "_tsbtnFit")
         Me._tsbtnFit.Name = "_tsbtnFit"
         ' 
         ' _pbProgress
         ' 
         resources.ApplyResources(Me._pbProgress, "_pbProgress")
         Me._pbProgress.Name = "_pbProgress"
         ' 
         ' _tsZoomLevel
         ' 
         Me._tsZoomLevel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._tsbtnNormal, Me._tsbtnFit})
         resources.ApplyResources(Me._tsZoomLevel, "_tsZoomLevel")
         Me._tsZoomLevel.Name = "_tsZoomLevel"
         Me._tsZoomLevel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
         ' 
         ' _lblREF
         ' 
         Me._lblREF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         resources.ApplyResources(Me._lblREF, "_lblREF")
         Me._lblREF.Name = "_lblREF"
         ' 
         ' _lblDST
         ' 
         Me._lblDST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         resources.ApplyResources(Me._lblDST, "_lblDST")
         Me._lblDST.Name = "_lblDST"
         ' 
         ' _lblseparator1
         ' 
         Me._lblseparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         resources.ApplyResources(Me._lblseparator1, "_lblseparator1")
         Me._lblseparator1.Name = "_lblseparator1"
         ' 
         ' _lblseparator2
         ' 
         Me._lblseparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         resources.ApplyResources(Me._lblseparator2, "_lblseparator2")
         Me._lblseparator2.Name = "_lblseparator2"
         ' 
         ' _lblREFlabel
         ' 
         resources.ApplyResources(Me._lblREFlabel, "_lblREFlabel")
         Me._lblREFlabel.Name = "_lblREFlabel"
         ' 
         ' _lblDSTlabel
         ' 
         resources.ApplyResources(Me._lblDSTlabel, "_lblDSTlabel")
         Me._lblDSTlabel.Name = "_lblDSTlabel"
         ' 
         ' _cmbREFImage
         ' 
         Me._cmbREFImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbREFImage.FormattingEnabled = True
         resources.ApplyResources(Me._cmbREFImage, "_cmbREFImage")
         Me._cmbREFImage.Name = "_cmbREFImage"
         ' 
         ' MatchHistogramDialog
         ' 
         resources.ApplyResources(Me, "$this")
         Me.Controls.Add(Me._cmbREFImage)
         Me.Controls.Add(Me._lblREFlabel)
         Me.Controls.Add(Me._lblDSTlabel)
         Me.Controls.Add(Me._lblseparator2)
         Me.Controls.Add(Me._lblseparator1)
         Me.Controls.Add(Me._pbProgress)
         Me.Controls.Add(Me._tsZoomLevel)
         Me.Controls.Add(Me._lblREF)
         Me.Controls.Add(Me._lblDST)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "MatchHistogramDialog"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         AddHandler Load, AddressOf Me.MatchHistogramDialog_Load
         Me._tsZoomLevel.ResumeLayout(False)
         Me._tsZoomLevel.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()
      End Sub
#End Region

      Private _btnCancel As System.Windows.Forms.Button

      Private WithEvents _btnOk As System.Windows.Forms.Button

      Private WithEvents _tsbtnNormal As System.Windows.Forms.ToolStripButton

      Private WithEvents _tsbtnFit As System.Windows.Forms.ToolStripButton

      Private _pbProgress As System.Windows.Forms.ProgressBar

      Private _tsZoomLevel As System.Windows.Forms.ToolStrip

      Private _lblREF As System.Windows.Forms.Label

      Private _lblDST As System.Windows.Forms.Label

      Private _lblseparator1 As System.Windows.Forms.Label

      Private _lblseparator2 As System.Windows.Forms.Label

      Private _lblREFlabel As System.Windows.Forms.Label

      Private _lblDSTlabel As System.Windows.Forms.Label

      Private WithEvents _cmbREFImage As System.Windows.Forms.ComboBox
   End Class
End Namespace