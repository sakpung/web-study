Imports Microsoft.VisualBasic
Imports System

Partial Public Class WiaVersionForm
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
      Me._lbWiaVersions = New System.Windows.Forms.ListBox()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _lbWiaVersions
      ' 
      Me._lbWiaVersions.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._lbWiaVersions.FormattingEnabled = True
      Me._lbWiaVersions.Location = New System.Drawing.Point(12, 13)
      Me._lbWiaVersions.Name = "_lbWiaVersions"
      Me._lbWiaVersions.Size = New System.Drawing.Size(318, 95)
      Me._lbWiaVersions.TabIndex = 0
      '         Me._lbWiaVersions.DoubleClick += New System.EventHandler(Me._lbWiaVersions_DoubleClick);
      '         Me._lbWiaVersions.SelectedIndexChanged += New System.EventHandler(Me._lbWiaVersions_SelectedIndexChanged);
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.Location = New System.Drawing.Point(174, 114)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 1
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      '         Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(255, 114)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 2
      Me._btnCancel.Text = "&Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' WiaVersionForm
      ' 
      Me.AcceptButton = Me._btnOk
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(342, 149)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._lbWiaVersions)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "WiaVersionForm"
      Me.ShowIcon = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Select WIA Version"
      '         Me.Load += New System.EventHandler(Me.WiaVersionForm_Load);
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _lbWiaVersions As System.Windows.Forms.ListBox
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _btnCancel As System.Windows.Forms.Button
End Class
