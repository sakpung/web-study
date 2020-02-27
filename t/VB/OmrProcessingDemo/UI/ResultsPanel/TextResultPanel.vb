Imports System
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Forms.Processing.Omr.Fields

Friend Class TextResultPanel
   Inherits UserControl

   Private cell As DataGridViewCell
   Private txtConfidence As TextBox
   Private lblConfidence As Label
   Private riv As ImageViewer
   Private isIdentifierCell As Boolean = False

   Public Event TextUpdated As EventHandler

   Public Sub New()
      InitializeComponent()
      riv = New ImageViewer()
      spltMain.Panel1.Controls.Add(riv)
      riv.Dock = DockStyle.Fill
      riv.AutoDisposeImages = False
      AddHandler Me.txtActual.TextChanged, AddressOf Me.txtActual_TextChanged
   End Sub

   Public Sub Populate(ByVal image As RasterImage, ByVal cell As DataGridViewCell, ByVal value As String, Optional ByVal confidence As Integer = -1)
      Me.cell = cell
      isIdentifierCell = False

      If TypeOf cell.Tag Is OmrField Then
         Dim f As OmrField = TryCast(cell.Tag, OmrField)
         isIdentifierCell = cell.Tag IsNot Nothing AndAlso TypeOf f.Tag Is Boolean AndAlso CBool(f.Tag)
      End If

      txtExpected.Text = value
      txtActual.Text = CStr(cell.Value)

      If confidence >= 0 Then
         txtConfidence.Text = String.Format("{0}%", confidence)
      Else
         txtConfidence.Visible = False
         lblConfidence.Visible = False
      End If

      riv.Image = image
      riv.Zoom(ControlSizeMode.FitAlways, 1, LeadPoint.Empty)
   End Sub

   Private Sub txtActual_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
      cell.Value = txtActual.Text

      If TextUpdatedEvent IsNot Nothing AndAlso isIdentifierCell Then
         RaiseEvent TextUpdated(Me, EventArgs.Empty)
      End If
   End Sub

   Private spltMain As SplitContainer
   Private txtActual As TextBox
   Private lblActual As Label
   Private txtExpected As TextBox
   Private lblExpected As Label

   Private Sub InitializeComponent()
      Me.spltMain = New System.Windows.Forms.SplitContainer()
      Me.txtConfidence = New System.Windows.Forms.TextBox()
      Me.lblConfidence = New System.Windows.Forms.Label()
      Me.txtActual = New System.Windows.Forms.TextBox()
      Me.lblActual = New System.Windows.Forms.Label()
      Me.txtExpected = New System.Windows.Forms.TextBox()
      Me.lblExpected = New System.Windows.Forms.Label()
      CType(Me.spltMain, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.spltMain.Panel2.SuspendLayout()
      Me.spltMain.SuspendLayout()
      Me.SuspendLayout()
      Me.spltMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.spltMain.Location = New System.Drawing.Point(0, 0)
      Me.spltMain.Name = "spltMain"
      Me.spltMain.Orientation = System.Windows.Forms.Orientation.Horizontal
      Me.spltMain.Panel2.Controls.Add(Me.txtConfidence)
      Me.spltMain.Panel2.Controls.Add(Me.lblConfidence)
      Me.spltMain.Panel2.Controls.Add(Me.txtActual)
      Me.spltMain.Panel2.Controls.Add(Me.lblActual)
      Me.spltMain.Panel2.Controls.Add(Me.txtExpected)
      Me.spltMain.Panel2.Controls.Add(Me.lblExpected)
      Me.spltMain.Size = New System.Drawing.Size(300, 436)
      Me.spltMain.SplitterDistance = 130
      Me.spltMain.TabIndex = 0
      Me.txtConfidence.Enabled = False
      Me.txtConfidence.Location = New System.Drawing.Point(138, 79)
      Me.txtConfidence.Name = "txtConfidence"
      Me.txtConfidence.Size = New System.Drawing.Size(121, 20)
      Me.txtConfidence.TabIndex = 8
      Me.lblConfidence.AutoSize = True
      Me.lblConfidence.Location = New System.Drawing.Point(30, 82)
      Me.lblConfidence.Name = "lblConfidence"
      Me.lblConfidence.Size = New System.Drawing.Size(64, 13)
      Me.lblConfidence.TabIndex = 7
      Me.lblConfidence.Text = "Confidence:"
      Me.txtActual.Location = New System.Drawing.Point(138, 37)
      Me.txtActual.Name = "txtActual"
      Me.txtActual.Size = New System.Drawing.Size(121, 20)
      Me.txtActual.TabIndex = 6
      Me.lblActual.AutoSize = True
      Me.lblActual.Location = New System.Drawing.Point(30, 41)
      Me.lblActual.Name = "lblActual"
      Me.lblActual.Size = New System.Drawing.Size(87, 13)
      Me.lblActual.TabIndex = 5
      Me.lblActual.Text = "Actual Selection:"
      Me.txtExpected.Location = New System.Drawing.Point(138, 11)
      Me.txtExpected.Name = "txtExpected"
      Me.txtExpected.[ReadOnly] = True
      Me.txtExpected.Size = New System.Drawing.Size(121, 20)
      Me.txtExpected.TabIndex = 4
      Me.lblExpected.AutoSize = True
      Me.lblExpected.Location = New System.Drawing.Point(30, 14)
      Me.lblExpected.Name = "lblExpected"
      Me.lblExpected.Size = New System.Drawing.Size(102, 13)
      Me.lblExpected.TabIndex = 3
      Me.lblExpected.Text = "Expected Selection:"
      Me.Controls.Add(Me.spltMain)
      Me.Name = "TextResultPanel"
      Me.Size = New System.Drawing.Size(300, 436)
      Me.spltMain.Panel2.ResumeLayout(False)
      Me.spltMain.Panel2.PerformLayout()
      CType(Me.spltMain, System.ComponentModel.ISupportInitialize).EndInit()
      Me.spltMain.ResumeLayout(False)
      Me.ResumeLayout(False)
   End Sub
End Class
