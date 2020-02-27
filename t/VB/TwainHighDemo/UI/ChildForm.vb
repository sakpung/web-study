' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Controls

Public Class ChildForm
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ChildForm))
      '
      'ChildForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ChildForm"
      Me.Text = "ChildForm"

   End Sub

#End Region
   Public viewer As ImageViewer

   Public Sub InsertImage(ByVal img As RasterImage, ByVal imageName As String)
      ' initialize the viewer object
      viewer = New ImageViewer
      viewer.Dock = DockStyle.Fill
      viewer.BackColor = Color.DarkGray
      Controls.Add(viewer)
      viewer.BringToFront()

      viewer.Image = img
      Text = imageName
   End Sub

   Private Sub ChildForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      Dim parentForm As MainForm = CType(MdiParent, MainForm)
      If parentForm.MdiChildren.Length = 1 Then
         parentForm.EnableMenuItems(False)
      End If
   End Sub
End Class
