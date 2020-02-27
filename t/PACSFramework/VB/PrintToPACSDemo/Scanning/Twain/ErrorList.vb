' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace PrintToPACSDemo
   ''' <summary>
   ''' Summary description for ErrorList.
   ''' </summary>
   Public Class ErrorList : Inherits System.Windows.Forms.Form
	  Private WithEvents _btnClear As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
	  Private _lstError As System.Windows.Forms.ListBox
	  Private _gbErrorList As System.Windows.Forms.GroupBox
	  ''' <summary>
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.Container = Nothing

	  Public Sub New()
		 '
		 ' Required for Windows Form Designer support
		 '
		 InitializeComponent()

		 '
		 ' TODO: Add any constructor code after InitializeComponent call
		 '
	  End Sub

	  ''' <summary>
	  ''' Clean up any resources being used.
	  ''' </summary>
	  Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
		 If disposing Then
			If Not components Is Nothing Then
			   components.Dispose()
			End If
		 End If
		 MyBase.Dispose(disposing)
	  End Sub

	  #Region "Windows Form Designer generated code"
	  ''' <summary>
	  ''' Required method for Designer support - do not modify
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
		 Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ErrorList))
		 Me._gbErrorList = New System.Windows.Forms.GroupBox()
		 Me._lstError = New System.Windows.Forms.ListBox()
		 Me._btnClear = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._gbErrorList.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _gbErrorList
		 ' 
		 Me._gbErrorList.Controls.Add(Me._lstError)
		 Me._gbErrorList.Location = New System.Drawing.Point(8, 8)
		 Me._gbErrorList.Name = "_gbErrorList"
		 Me._gbErrorList.Size = New System.Drawing.Size(472, 200)
		 Me._gbErrorList.TabIndex = 0
		 Me._gbErrorList.TabStop = False
		 ' 
		 ' _lstError
		 ' 
		 Me._lstError.Location = New System.Drawing.Point(8, 16)
		 Me._lstError.Name = "_lstError"
		 Me._lstError.Size = New System.Drawing.Size(456, 173)
		 Me._lstError.TabIndex = 0
		 ' 
		 ' _btnClear
		 ' 
		 Me._btnClear.Location = New System.Drawing.Point(168, 216)
		 Me._btnClear.Name = "_btnClear"
		 Me._btnClear.TabIndex = 1
		 Me._btnClear.Text = "Clear"
'		 Me._btnClear.Click += New System.EventHandler(Me._btnClear_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(248, 216)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.TabIndex = 2
		 Me._btnCancel.Text = "Cancel"
		 ' 
		 ' ErrorList
		 ' 
		 Me.AcceptButton = Me._btnClear
		 Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(490, 248)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnClear)
		 Me.Controls.Add(Me._gbErrorList)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "ErrorList"
		 Me.Text = "TWAIN Error List"
'		 Me.Load += New System.EventHandler(Me.ErrorList_Load);
		 Me._gbErrorList.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub
	  #End Region
	  Public _arrayList As ArrayList
	  Public _listCleared As Boolean

	  Private Sub ErrorList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		 _listCleared = False
		 Dim i As Integer = 0
		 Do While i < _arrayList.Count
			_lstError.Items.Add(_arrayList(i))
			 i += 1
		 Loop
	  End Sub

	  Private Sub _btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnClear.Click
		 _arrayList.Clear()
		 _lstError.Items.Clear()
		 _listCleared = True
		 DialogResult = DialogResult.OK
	  End Sub
   End Class
End Namespace
