Imports Microsoft.VisualBasic
Imports System
Partial Public Class ProgressForm
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
      Me._lblInformation = New System.Windows.Forms.Label()
      Me._progress = New System.Windows.Forms.ProgressBar()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _lblInformation
      ' 
      Me._lblInformation.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._lblInformation.Location = New System.Drawing.Point(12, 9)
      Me._lblInformation.Name = "_lblInformation"
      Me._lblInformation.Size = New System.Drawing.Size(356, 70)
      Me._lblInformation.TabIndex = 0
      ' 
      ' _progress
      ' 
      Me._progress.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._progress.Location = New System.Drawing.Point(12, 83)
      Me._progress.Name = "_progress"
      Me._progress.Size = New System.Drawing.Size(356, 20)
      Me._progress.TabIndex = 1
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(293, 111)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 2
      Me._btnCancel.Text = "&Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '         Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
      ' 
      ' ProgressForm
      ' 
      Me.AcceptButton = Me._btnCancel
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(380, 146)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._progress)
      Me.Controls.Add(Me._lblInformation)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "ProgressForm"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _lblInformation As System.Windows.Forms.Label
   Private _progress As System.Windows.Forms.ProgressBar
   Private WithEvents _btnCancel As System.Windows.Forms.Button
End Class