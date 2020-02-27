
Partial Class TableRulesForm
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
      Me._ch_RowsLineSeparator = New System.Windows.Forms.CheckBox()
      Me._ch_EqualFixedRowHeight = New System.Windows.Forms.CheckBox()
      Me._ch_EqualFixedLineHeight = New System.Windows.Forms.CheckBox()
      Me._ch_MultiPageTableHeaderRepeted = New System.Windows.Forms.CheckBox()
      Me._btn_OK = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _ch_RowsLineSeparator
      ' 
      Me._ch_RowsLineSeparator.AutoSize = True
      Me._ch_RowsLineSeparator.Location = New System.Drawing.Point(13, 13)
      Me._ch_RowsLineSeparator.Name = "_ch_RowsLineSeparator"
      Me._ch_RowsLineSeparator.Size = New System.Drawing.Size(125, 17)
      Me._ch_RowsLineSeparator.TabIndex = 0
      Me._ch_RowsLineSeparator.Text = "Rows Line Separator"
      Me._ch_RowsLineSeparator.UseVisualStyleBackColor = True
      ' 
      ' _ch_EqualFixedRowHeight
      ' 
      Me._ch_EqualFixedRowHeight.AutoSize = True
      Me._ch_EqualFixedRowHeight.Location = New System.Drawing.Point(13, 52)
      Me._ch_EqualFixedRowHeight.Name = "_ch_EqualFixedRowHeight"
      Me._ch_EqualFixedRowHeight.Size = New System.Drawing.Size(139, 17)
      Me._ch_EqualFixedRowHeight.TabIndex = 1
      Me._ch_EqualFixedRowHeight.Text = "Equal Fixed Row Height"
      Me._ch_EqualFixedRowHeight.UseVisualStyleBackColor = True
      ' 
      ' _ch_EqualFixedLineHeight
      ' 
      Me._ch_EqualFixedLineHeight.AutoSize = True
      Me._ch_EqualFixedLineHeight.Location = New System.Drawing.Point(13, 91)
      Me._ch_EqualFixedLineHeight.Name = "_ch_EqualFixedLineHeight"
      Me._ch_EqualFixedLineHeight.Size = New System.Drawing.Size(137, 17)
      Me._ch_EqualFixedLineHeight.TabIndex = 2
      Me._ch_EqualFixedLineHeight.Text = "Equal Fixed Line Height"
      Me._ch_EqualFixedLineHeight.UseVisualStyleBackColor = True
      ' 
      ' _ch_MultiPageTableHeaderRepeted
      ' 
      Me._ch_MultiPageTableHeaderRepeted.AutoSize = True
      Me._ch_MultiPageTableHeaderRepeted.Location = New System.Drawing.Point(13, 130)
      Me._ch_MultiPageTableHeaderRepeted.Name = "_ch_MultiPageTableHeaderRepeted"
      Me._ch_MultiPageTableHeaderRepeted.Size = New System.Drawing.Size(183, 17)
      Me._ch_MultiPageTableHeaderRepeted.TabIndex = 3
      Me._ch_MultiPageTableHeaderRepeted.Text = "MultiPage Table Header Repeted"
      Me._ch_MultiPageTableHeaderRepeted.UseVisualStyleBackColor = True
      ' 
      ' _btn_OK
      ' 
      Me._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btn_OK.Location = New System.Drawing.Point(105, 173)
      Me._btn_OK.Name = "_btn_OK"
      Me._btn_OK.Size = New System.Drawing.Size(75, 23)
      Me._btn_OK.TabIndex = 4
      Me._btn_OK.Text = "Ok"
      Me._btn_OK.UseVisualStyleBackColor = True
      ' 
      ' TableRulesForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(284, 216)
      Me.Controls.Add(Me._btn_OK)
      Me.Controls.Add(Me._ch_MultiPageTableHeaderRepeted)
      Me.Controls.Add(Me._ch_EqualFixedLineHeight)
      Me.Controls.Add(Me._ch_EqualFixedRowHeight)
      Me.Controls.Add(Me._ch_RowsLineSeparator)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.ImeMode = System.Windows.Forms.ImeMode.On
      Me.Name = "TableRulesForm"
      Me.Text = "TableRules"
      AddHandler Me.FormClosing, AddressOf Me.TableRulesForm_FormClosing
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _ch_RowsLineSeparator As System.Windows.Forms.CheckBox
   Private WithEvents _ch_EqualFixedRowHeight As System.Windows.Forms.CheckBox
   Private WithEvents _ch_EqualFixedLineHeight As System.Windows.Forms.CheckBox
   Private WithEvents _ch_MultiPageTableHeaderRepeted As System.Windows.Forms.CheckBox
   Private _btn_OK As System.Windows.Forms.Button
End Class
