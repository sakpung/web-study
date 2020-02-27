Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Partial Public Class FrmOperation
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
   Me._btnCancelOperation = New System.Windows.Forms.Button()
   Me._lblCaption = New System.Windows.Forms.Label()
   Me.SuspendLayout()
   ' 
   ' _btnCancelOperation
   ' 
   Me._btnCancelOperation.Location = New System.Drawing.Point(126, 71)
   Me._btnCancelOperation.Name = "_btnCancelOperation"
   Me._btnCancelOperation.Size = New System.Drawing.Size(120, 23)
   Me._btnCancelOperation.TabIndex = 0
   Me._btnCancelOperation.Text = "_btnCancelOperation"
   Me._btnCancelOperation.UseVisualStyleBackColor = True
'		 Me._btnCancelOperation.Click += New System.EventHandler(Me._btnCancelOperation_Click);
   ' 
   ' _lblCaption
   ' 
   Me._lblCaption.AutoSize = True
   Me._lblCaption.Location = New System.Drawing.Point(12, 9)
   Me._lblCaption.Name = "_lblCaption"
   Me._lblCaption.Size = New System.Drawing.Size(59, 13)
   Me._lblCaption.TabIndex = 1
   Me._lblCaption.Text = "_lblCaption"
   ' 
   ' FrmOperation
   ' 
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.ClientSize = New System.Drawing.Size(380, 102)
   Me.ControlBox = False
   Me.Controls.Add(Me._lblCaption)
   Me.Controls.Add(Me._btnCancelOperation)
   Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
   Me.MaximizeBox = False
   Me.MinimizeBox = False
   Me.Name = "FrmOperation"
   Me.ShowIcon = False
   Me.ShowInTaskbar = False
   Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
   Me.Text = " Processing Operation"
   Me.TopMost = True
   Me.ResumeLayout(False)
   Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _btnCancelOperation As System.Windows.Forms.Button
   Private _lblCaption As System.Windows.Forms.Label
   End Class
End Namespace