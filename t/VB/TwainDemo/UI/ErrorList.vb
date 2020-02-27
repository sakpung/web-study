' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Public Class ErrorList
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
   Friend WithEvents _btnCancel As System.Windows.Forms.Button
   Friend WithEvents _btnClear As System.Windows.Forms.Button
   Friend WithEvents _gbErrorList As System.Windows.Forms.GroupBox
   Friend WithEvents _lstError As System.Windows.Forms.ListBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ErrorList))
      Me._btnCancel = New System.Windows.Forms.Button
      Me._btnClear = New System.Windows.Forms.Button
      Me._gbErrorList = New System.Windows.Forms.GroupBox
      Me._lstError = New System.Windows.Forms.ListBox
      Me._gbErrorList.SuspendLayout()
      Me.SuspendLayout()
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(248, 216)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.TabIndex = 5
      Me._btnCancel.Text = "Cancel"
      '
      '_btnClear
      '
      Me._btnClear.Location = New System.Drawing.Point(168, 216)
      Me._btnClear.Name = "_btnClear"
      Me._btnClear.TabIndex = 4
      Me._btnClear.Text = "Clear"
      '
      '_gbErrorList
      '
      Me._gbErrorList.Controls.Add(Me._lstError)
      Me._gbErrorList.Location = New System.Drawing.Point(8, 8)
      Me._gbErrorList.Name = "_gbErrorList"
      Me._gbErrorList.Size = New System.Drawing.Size(472, 200)
      Me._gbErrorList.TabIndex = 3
      Me._gbErrorList.TabStop = False
      '
      '_lstError
      '
      Me._lstError.Location = New System.Drawing.Point(8, 16)
      Me._lstError.Name = "_lstError"
      Me._lstError.Size = New System.Drawing.Size(456, 173)
      Me._lstError.TabIndex = 0
      '
      'ErrorList
      '
      Me.AcceptButton = Me._btnClear
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(490, 248)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnClear)
      Me.Controls.Add(Me._gbErrorList)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ErrorList"
      Me.Text = "TWAIN Error List"
      Me._gbErrorList.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region
   Public _arrayList As ArrayList
   Public _listCleared As Boolean

   Private Sub ErrorList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim i As Integer
      _listCleared = False
      For i = 0 To _arrayList.Count - 1
         _lstError.Items.Add(_arrayList(i))
      Next
   End Sub

   Private Sub _btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnClear.Click
      _arrayList.Clear()
      _lstError.Items.Clear()
      _listCleared = True
      DialogResult = System.Windows.Forms.DialogResult.OK
   End Sub
End Class
