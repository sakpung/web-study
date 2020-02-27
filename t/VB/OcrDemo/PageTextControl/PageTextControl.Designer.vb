Namespace OcrDemo.PageTextControl
    Partial Class PageTextControl
        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me._titleLabel = New System.Windows.Forms.Label()
            Me._tbPageText = New System.Windows.Forms.RichTextBox()
            Me.SuspendLayout()
            ' 
            ' _titleLabel
            ' 
            Me._titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._titleLabel.Dock = System.Windows.Forms.DockStyle.Top
            Me._titleLabel.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
            Me._titleLabel.Location = New System.Drawing.Point(0, 0)
            Me._titleLabel.Name = "_titleLabel"
            Me._titleLabel.Size = New System.Drawing.Size(395, 18)
            Me._titleLabel.TabIndex = 1
            Me._titleLabel.Text = "Page Text"
            Me._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' _tbPageText
            ' 
            Me._tbPageText.BackColor = System.Drawing.Color.White
            Me._tbPageText.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me._tbPageText.Dock = System.Windows.Forms.DockStyle.Fill
            Me._tbPageText.Font = New System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
            Me._tbPageText.Location = New System.Drawing.Point(0, 18)
            Me._tbPageText.Name = "_tbPageText"
            Me._tbPageText.ReadOnly = True
            Me._tbPageText.Size = New System.Drawing.Size(395, 127)
            Me._tbPageText.TabIndex = 3
            Me._tbPageText.Text = ""
            ' 
            ' PageTextControl
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Controls.Add(Me._tbPageText)
            Me.Controls.Add(Me._titleLabel)
            Me.Name = "PageTextControl"
            Me.Size = New System.Drawing.Size(395, 145)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private _titleLabel As System.Windows.Forms.Label
        Private _tbPageText As System.Windows.Forms.RichTextBox
    End Class
End Namespace