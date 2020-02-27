Imports Microsoft.VisualBasic
Imports System
Partial Public Class ImageFileLoaderPagesDialog
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
      Me._tbFirstPage = New System.Windows.Forms.TextBox()
      Me._lblInfo = New System.Windows.Forms.Label()
      Me._gbPages = New System.Windows.Forms.GroupBox()
      Me._tbLastPage = New System.Windows.Forms.TextBox()
      Me._lblLastPage = New System.Windows.Forms.Label()
      Me._lblFirstPage = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._rbLoadSinglePage = New System.Windows.Forms.RadioButton()
      Me._rbLoadMultiPages = New System.Windows.Forms.RadioButton()
      Me._tbPageNumber = New System.Windows.Forms.TextBox()
      Me._lblPageNumber = New System.Windows.Forms.Label()
      Me._gbPages.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _tbFirstPage
      ' 
      Me._tbFirstPage.Location = New System.Drawing.Point(115, 149)
      Me._tbFirstPage.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._tbFirstPage.Name = "_tbFirstPage"
      Me._tbFirstPage.Size = New System.Drawing.Size(91, 20)
      Me._tbFirstPage.TabIndex = 2
      ' 
      ' _lblInfo
      ' 
      Me._lblInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblInfo.Location = New System.Drawing.Point(14, 23)
      Me._lblInfo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblInfo.Name = "_lblInfo"
      Me._lblInfo.Size = New System.Drawing.Size(216, 30)
      Me._lblInfo.TabIndex = 0
      Me._lblInfo.Text = "This file has ### total pages.  Select the $$$ you want to load:"
      ' 
      ' _gbPages
      ' 
      Me._gbPages.Controls.Add(Me._tbPageNumber)
      Me._gbPages.Controls.Add(Me._lblPageNumber)
      Me._gbPages.Controls.Add(Me._rbLoadMultiPages)
      Me._gbPages.Controls.Add(Me._rbLoadSinglePage)
      Me._gbPages.Controls.Add(Me._tbLastPage)
      Me._gbPages.Controls.Add(Me._lblLastPage)
      Me._gbPages.Controls.Add(Me._tbFirstPage)
      Me._gbPages.Controls.Add(Me._lblInfo)
      Me._gbPages.Controls.Add(Me._lblFirstPage)
      Me._gbPages.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbPages.Location = New System.Drawing.Point(9, 10)
      Me._gbPages.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._gbPages.Name = "_gbPages"
      Me._gbPages.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._gbPages.Size = New System.Drawing.Size(244, 208)
      Me._gbPages.TabIndex = 3
      Me._gbPages.TabStop = False
      ' 
      ' _tbLastPage
      ' 
      Me._tbLastPage.Location = New System.Drawing.Point(115, 176)
      Me._tbLastPage.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._tbLastPage.Name = "_tbLastPage"
      Me._tbLastPage.Size = New System.Drawing.Size(91, 20)
      Me._tbLastPage.TabIndex = 4
      ' 
      ' _lblLastPage
      ' 
      Me._lblLastPage.AutoSize = True
      Me._lblLastPage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblLastPage.Location = New System.Drawing.Point(36, 179)
      Me._lblLastPage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblLastPage.Name = "_lblLastPage"
      Me._lblLastPage.Size = New System.Drawing.Size(58, 13)
      Me._lblLastPage.TabIndex = 3
      Me._lblLastPage.Text = "Last Page:"
      Me._lblLastPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _lblFirstPage
      ' 
      Me._lblFirstPage.AutoSize = True
      Me._lblFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblFirstPage.Location = New System.Drawing.Point(36, 152)
      Me._lblFirstPage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblFirstPage.Name = "_lblFirstPage"
      Me._lblFirstPage.Size = New System.Drawing.Size(59, 13)
      Me._lblFirstPage.TabIndex = 1
      Me._lblFirstPage.Text = "First Page:"
      Me._lblFirstPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(262, 47)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 5
      Me._btnCancel.Text = "Cancel"
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(262, 17)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 4
      Me._btnOk.Text = "OK"
      ' 
      ' _rbLoadSinglePage
      ' 
      Me._rbLoadSinglePage.AutoSize = True
      Me._rbLoadSinglePage.Location = New System.Drawing.Point(14, 65)
      Me._rbLoadSinglePage.Name = "_rbLoadSinglePage"
      Me._rbLoadSinglePage.Size = New System.Drawing.Size(105, 17)
      Me._rbLoadSinglePage.TabIndex = 6
      Me._rbLoadSinglePage.Text = "Load &single page"
      Me._rbLoadSinglePage.UseVisualStyleBackColor = True
      ' 
      ' _rbLoadMultiPages
      ' 
      Me._rbLoadMultiPages.AutoSize = True
      Me._rbLoadMultiPages.Location = New System.Drawing.Point(14, 123)
      Me._rbLoadMultiPages.Name = "_rbLoadMultiPages"
      Me._rbLoadMultiPages.Size = New System.Drawing.Size(106, 17)
      Me._rbLoadMultiPages.TabIndex = 7
      Me._rbLoadMultiPages.Text = "Load &multi-pages"
      Me._rbLoadMultiPages.UseVisualStyleBackColor = True
      ' 
      ' _tbPageNumber
      ' 
      Me._tbPageNumber.Location = New System.Drawing.Point(115, 89)
      Me._tbPageNumber.Margin = New System.Windows.Forms.Padding(2)
      Me._tbPageNumber.Name = "_tbPageNumber"
      Me._tbPageNumber.Size = New System.Drawing.Size(91, 20)
      Me._tbPageNumber.TabIndex = 9
      ' 
      ' _lblPageNumber
      ' 
      Me._lblPageNumber.AutoSize = True
      Me._lblPageNumber.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblPageNumber.Location = New System.Drawing.Point(36, 92)
      Me._lblPageNumber.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblPageNumber.Name = "_lblPageNumber"
      Me._lblPageNumber.Size = New System.Drawing.Size(75, 13)
      Me._lblPageNumber.TabIndex = 8
      Me._lblPageNumber.Text = "Page Number:"
      Me._lblPageNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' ImageFileLoaderPagesDialog
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(338, 230)
      Me.Controls.Add(Me._gbPages)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ImageFileLoaderPagesDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Load Pages"
      Me._gbPages.ResumeLayout(False)
      Me._gbPages.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _tbFirstPage As System.Windows.Forms.TextBox
   Private _lblInfo As System.Windows.Forms.Label
   Private _gbPages As System.Windows.Forms.GroupBox
   Private WithEvents _tbLastPage As System.Windows.Forms.TextBox
   Private _lblLastPage As System.Windows.Forms.Label
   Private _lblFirstPage As System.Windows.Forms.Label
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _tbPageNumber As System.Windows.Forms.TextBox
   Private _lblPageNumber As System.Windows.Forms.Label
   Private WithEvents _rbLoadMultiPages As System.Windows.Forms.RadioButton
   Private WithEvents _rbLoadSinglePage As System.Windows.Forms.RadioButton
End Class
