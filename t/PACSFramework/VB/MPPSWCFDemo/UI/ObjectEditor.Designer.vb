Imports Microsoft.VisualBasic
Imports System
Namespace MPPSWCFDemo.UI
    Partial Public Class ObjectEditor(Of T As Class)
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
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
            Me.propertyGridEditObject = New System.Windows.Forms.PropertyGrid()
            Me.button1 = New System.Windows.Forms.Button()
            Me.button2 = New System.Windows.Forms.Button()
            Me.labelDescription = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' propertyGridEditObject
            ' 
            Me.propertyGridEditObject.HelpVisible = False
            Me.propertyGridEditObject.Location = New System.Drawing.Point(15, 29)
            Me.propertyGridEditObject.Name = "propertyGridEditObject"
            Me.propertyGridEditObject.PropertySort = System.Windows.Forms.PropertySort.NoSort
            Me.propertyGridEditObject.Size = New System.Drawing.Size(322, 135)
            Me.propertyGridEditObject.TabIndex = 0
            Me.propertyGridEditObject.ToolbarVisible = False
            '		   Me.propertyGridEditObject.PropertyValueChanged += New System.Windows.Forms.PropertyValueChangedEventHandler(Me.propertyGridEditObject_PropertyValueChanged);
            ' 
            ' button1
            ' 
            Me.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.button1.Location = New System.Drawing.Point(262, 170)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(75, 23)
            Me.button1.TabIndex = 1
            Me.button1.Text = "Cancel"
            Me.button1.UseVisualStyleBackColor = True
            ' 
            ' button2
            ' 
            Me.button2.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.button2.Location = New System.Drawing.Point(181, 170)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(75, 23)
            Me.button2.TabIndex = 2
            Me.button2.Text = "OK"
            Me.button2.UseVisualStyleBackColor = True
            ' 
            ' labelDescription
            ' 
            Me.labelDescription.AutoSize = True
            Me.labelDescription.Location = New System.Drawing.Point(12, 13)
            Me.labelDescription.Name = "labelDescription"
            Me.labelDescription.Size = New System.Drawing.Size(96, 13)
            Me.labelDescription.TabIndex = 3
            Me.labelDescription.Text = "Referenced Study:"
            ' 
            ' ObjectEditor
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(349, 205)
            Me.Controls.Add(Me.labelDescription)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.propertyGridEditObject)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ObjectEditor"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Object Editor"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private WithEvents propertyGridEditObject As System.Windows.Forms.PropertyGrid
        Private button1 As System.Windows.Forms.Button
        Private button2 As System.Windows.Forms.Button
        Private labelDescription As System.Windows.Forms.Label
    End Class
End Namespace