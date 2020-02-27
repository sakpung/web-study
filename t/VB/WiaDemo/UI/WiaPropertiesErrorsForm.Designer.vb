Imports Microsoft.VisualBasic
Imports System

Partial Public Class WiaPropertiesErrorsForm
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
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnClear = New System.Windows.Forms.Button()
      Me._lvErrors = New System.Windows.Forms.ListView()
      Me.SuspendLayout()
      ' 
      ' _btnOk
      ' 
      Me._btnOk.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnOk.Location = New System.Drawing.Point(484, 349)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 2
      Me._btnOk.Text = "&OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _btnClear
      ' 
      Me._btnClear.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._btnClear.Location = New System.Drawing.Point(403, 349)
      Me._btnClear.Name = "_btnClear"
      Me._btnClear.Size = New System.Drawing.Size(75, 23)
      Me._btnClear.TabIndex = 1
      Me._btnClear.Text = "&Clear"
      Me._btnClear.UseVisualStyleBackColor = True
      '         Me._btnClear.Click += New System.EventHandler(Me._btnClear_Click);
      ' 
      ' _lvErrors
      ' 
      Me._lvErrors.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._lvErrors.FullRowSelect = True
      Me._lvErrors.GridLines = True
      Me._lvErrors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      Me._lvErrors.Location = New System.Drawing.Point(12, 12)
      Me._lvErrors.Name = "_lvErrors"
      Me._lvErrors.Size = New System.Drawing.Size(547, 331)
      Me._lvErrors.TabIndex = 0
      Me._lvErrors.UseCompatibleStateImageBehavior = False
      Me._lvErrors.View = System.Windows.Forms.View.Details
      ' 
      ' WiaPropertiesErrorsForm
      ' 
      Me.AcceptButton = Me._btnOk
      Me.CancelButton = Me._btnOk
      Me.ClientSize = New System.Drawing.Size(572, 382)
      Me.Controls.Add(Me._lvErrors)
      Me.Controls.Add(Me._btnClear)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "WiaPropertiesErrorsForm"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "WIA Supported Formats"
      '         Me.Load += New System.EventHandler(Me.WiaPropertiesErrorsForm_Load);
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _btnOk As System.Windows.Forms.Button
   Private WithEvents _btnClear As System.Windows.Forms.Button
   Private _lvErrors As System.Windows.Forms.ListView


End Class
