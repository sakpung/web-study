Imports Microsoft.VisualBasic
Imports System

Namespace DocumentCleanupDemo
   Partial Public Class HistogramDlg
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer
      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         Try
            If disposing AndAlso components IsNot Nothing Then
               components.Dispose()
            End If
         Finally
            MyBase.Dispose(disposing)
         End Try
      End Sub

     

      'NOTE: The following procedure is required by the Windows Form Designer
      'It can be modified using the Windows Form Designer.  
      'Do not modify it using the code editor.
      <System.Diagnostics.DebuggerStepThrough()> _
      Private Sub InitializeComponent()
         Me.label4 = New System.Windows.Forms.Label()
         Me._numRangeMin = New System.Windows.Forms.NumericUpDown()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._gbGrayScaleRange = New System.Windows.Forms.GroupBox()
         Me._numRangeMax = New System.Windows.Forms.NumericUpDown()
         Me.label3 = New System.Windows.Forms.Label()
         Me._btnDraw = New System.Windows.Forms.Button()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me._cmbChanel = New System.Windows.Forms.ComboBox()
         Me._numClipping = New System.Windows.Forms.NumericUpDown()
         Me._lblClipping = New System.Windows.Forms.Label()
         Me._lblPercentil = New System.Windows.Forms.Label()
         Me._lblMedian = New System.Windows.Forms.Label()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._lblMean = New System.Windows.Forms.Label()
         Me._lblToltalPixels = New System.Windows.Forms.Label()
         Me._lblMin = New System.Windows.Forms.Label()
         Me._lblMax = New System.Windows.Forms.Label()
         Me._lblCount = New System.Windows.Forms.Label()
         Me._lblLevel = New System.Windows.Forms.Label()
         Me._pnlHistogram = New System.Windows.Forms.Panel()
         CType(Me._numRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._gbGrayScaleRange.SuspendLayout()
         CType(Me._numRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numClipping, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         '
         'label4
         '
         Me.label4.AutoSize = True
         Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.label4.Location = New System.Drawing.Point(399, 72)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(52, 13)
         Me.label4.TabIndex = 23
         Me.label4.Text = "Channel: "
         '
         '_numRangeMin
         '
         Me._numRangeMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._numRangeMin.Location = New System.Drawing.Point(6, 45)
         Me._numRangeMin.Name = "_numRangeMin"
         Me._numRangeMin.Size = New System.Drawing.Size(61, 20)
         Me._numRangeMin.TabIndex = 21
         Me._numRangeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
         '
         '_btnOk
         '
         Me._btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._btnOk.Location = New System.Drawing.Point(215, 123)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(75, 27)
         Me._btnOk.TabIndex = 0
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         '
         '_gbGrayScaleRange
         '
         Me._gbGrayScaleRange.Controls.Add(Me._numRangeMin)
         Me._gbGrayScaleRange.Controls.Add(Me._numRangeMax)
         Me._gbGrayScaleRange.Controls.Add(Me.label3)
         Me._gbGrayScaleRange.Controls.Add(Me._btnDraw)
         Me._gbGrayScaleRange.Controls.Add(Me.label1)
         Me._gbGrayScaleRange.Controls.Add(Me.label2)
         Me._gbGrayScaleRange.Location = New System.Drawing.Point(231, 9)
         Me._gbGrayScaleRange.Name = "_gbGrayScaleRange"
         Me._gbGrayScaleRange.Size = New System.Drawing.Size(162, 99)
         Me._gbGrayScaleRange.TabIndex = 22
         Me._gbGrayScaleRange.TabStop = False
         '
         '_numRangeMax
         '
         Me._numRangeMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._numRangeMax.Location = New System.Drawing.Point(94, 45)
         Me._numRangeMax.Name = "_numRangeMax"
         Me._numRangeMax.Size = New System.Drawing.Size(61, 20)
         Me._numRangeMax.TabIndex = 13
         Me._numRangeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
         '
         'label3
         '
         Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.label3.Location = New System.Drawing.Point(5, 27)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(54, 23)
         Me.label3.TabIndex = 15
         Me.label3.Text = "min value"
         '
         '_btnDraw
         '
         Me._btnDraw.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._btnDraw.Location = New System.Drawing.Point(53, 68)
         Me._btnDraw.Name = "_btnDraw"
         Me._btnDraw.Size = New System.Drawing.Size(51, 28)
         Me._btnDraw.TabIndex = 13
         Me._btnDraw.Text = "Draw"
         Me._btnDraw.UseVisualStyleBackColor = True
         '
         'label1
         '
         Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.label1.Location = New System.Drawing.Point(56, 15)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(45, 20)
         Me.label1.TabIndex = 7
         Me.label1.Text = "Range"
         '
         'label2
         '
         Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.label2.Location = New System.Drawing.Point(99, 27)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(56, 23)
         Me.label2.TabIndex = 14
         Me.label2.Text = "max value"
         '
         '_cmbChanel
         '
         Me._cmbChanel.FormattingEnabled = True
         Me._cmbChanel.Items.AddRange(New Object() {"Master", "Red", "Green", "Blue"})
         Me._cmbChanel.Location = New System.Drawing.Point(445, 69)
         Me._cmbChanel.Name = "_cmbChanel"
         Me._cmbChanel.Size = New System.Drawing.Size(63, 21)
         Me._cmbChanel.TabIndex = 24
         '
         '_numClipping
         '
         Me._numClipping.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._numClipping.Location = New System.Drawing.Point(445, 33)
         Me._numClipping.Name = "_numClipping"
         Me._numClipping.Size = New System.Drawing.Size(63, 20)
         Me._numClipping.TabIndex = 20
         Me._numClipping.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
         '
         '_lblClipping
         '
         Me._lblClipping.AutoSize = True
         Me._lblClipping.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._lblClipping.Location = New System.Drawing.Point(399, 35)
         Me._lblClipping.Name = "_lblClipping"
         Me._lblClipping.Size = New System.Drawing.Size(50, 13)
         Me._lblClipping.TabIndex = 19
         Me._lblClipping.Text = "Clipping: "
         '
         '_lblPercentil
         '
         Me._lblPercentil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._lblPercentil.Location = New System.Drawing.Point(104, 62)
         Me._lblPercentil.Name = "_lblPercentil"
         Me._lblPercentil.Size = New System.Drawing.Size(123, 23)
         Me._lblPercentil.TabIndex = 18
         Me._lblPercentil.Text = "percentil"
         '
         '_lblMedian
         '
         Me._lblMedian.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._lblMedian.Location = New System.Drawing.Point(10, 85)
         Me._lblMedian.Name = "_lblMedian"
         Me._lblMedian.Size = New System.Drawing.Size(89, 23)
         Me._lblMedian.TabIndex = 17
         Me._lblMedian.Text = "Median"
         '
         'groupBox1
         '
         Me.groupBox1.Controls.Add(Me._cmbChanel)
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me._btnOk)
         Me.groupBox1.Controls.Add(Me._gbGrayScaleRange)
         Me.groupBox1.Controls.Add(Me._numClipping)
         Me.groupBox1.Controls.Add(Me._lblClipping)
         Me.groupBox1.Controls.Add(Me._lblPercentil)
         Me.groupBox1.Controls.Add(Me._lblMedian)
         Me.groupBox1.Controls.Add(Me._lblMean)
         Me.groupBox1.Controls.Add(Me._lblToltalPixels)
         Me.groupBox1.Controls.Add(Me._lblMin)
         Me.groupBox1.Controls.Add(Me._lblMax)
         Me.groupBox1.Controls.Add(Me._lblCount)
         Me.groupBox1.Controls.Add(Me._lblLevel)
         Me.groupBox1.Location = New System.Drawing.Point(4, 217)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(514, 156)
         Me.groupBox1.TabIndex = 14
         Me.groupBox1.TabStop = False
         '
         '_lblMean
         '
         Me._lblMean.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._lblMean.Location = New System.Drawing.Point(10, 62)
         Me._lblMean.Name = "_lblMean"
         Me._lblMean.Size = New System.Drawing.Size(89, 23)
         Me._lblMean.TabIndex = 16
         Me._lblMean.Text = "Mean:"
         '
         '_lblToltalPixels
         '
         Me._lblToltalPixels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._lblToltalPixels.Location = New System.Drawing.Point(104, 85)
         Me._lblToltalPixels.Name = "_lblToltalPixels"
         Me._lblToltalPixels.Size = New System.Drawing.Size(123, 23)
         Me._lblToltalPixels.TabIndex = 13
         Me._lblToltalPixels.Text = "Total Pixels"
         '
         '_lblMin
         '
         Me._lblMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._lblMin.Location = New System.Drawing.Point(10, 39)
         Me._lblMin.Name = "_lblMin"
         Me._lblMin.Size = New System.Drawing.Size(89, 23)
         Me._lblMin.TabIndex = 6
         Me._lblMin.Text = "Min"
         '
         '_lblMax
         '
         Me._lblMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._lblMax.Location = New System.Drawing.Point(10, 16)
         Me._lblMax.Name = "_lblMax"
         Me._lblMax.Size = New System.Drawing.Size(89, 23)
         Me._lblMax.TabIndex = 5
         Me._lblMax.Text = "Max"
         '
         '_lblCount
         '
         Me._lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._lblCount.Location = New System.Drawing.Point(104, 39)
         Me._lblCount.Name = "_lblCount"
         Me._lblCount.Size = New System.Drawing.Size(123, 23)
         Me._lblCount.TabIndex = 4
         Me._lblCount.Text = "Count"
         '
         '_lblLevel
         '
         Me._lblLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._lblLevel.Location = New System.Drawing.Point(104, 16)
         Me._lblLevel.Name = "_lblLevel"
         Me._lblLevel.Size = New System.Drawing.Size(123, 23)
         Me._lblLevel.TabIndex = 2
         Me._lblLevel.Text = "Level"
         '
         '_pnlHistogram
         '
         Me._pnlHistogram.BackColor = System.Drawing.SystemColors.Control
         Me._pnlHistogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._pnlHistogram.Location = New System.Drawing.Point(11, 11)
         Me._pnlHistogram.Name = "_pnlHistogram"
         Me._pnlHistogram.Size = New System.Drawing.Size(500, 200)
         Me._pnlHistogram.TabIndex = 13
         '
         'HistogramDlg
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(523, 384)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me._pnlHistogram)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "HistogramDlg"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Histogram"
         CType(Me._numRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
         Me._gbGrayScaleRange.ResumeLayout(False)
         CType(Me._numRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numClipping, System.ComponentModel.ISupportInitialize).EndInit()
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub
      Private WithEvents label4 As System.Windows.Forms.Label
      Private WithEvents _numRangeMin As System.Windows.Forms.NumericUpDown
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private WithEvents _gbGrayScaleRange As System.Windows.Forms.GroupBox
      Private WithEvents _numRangeMax As System.Windows.Forms.NumericUpDown
      Private WithEvents label3 As System.Windows.Forms.Label
      Private WithEvents _btnDraw As System.Windows.Forms.Button
      Private WithEvents label1 As System.Windows.Forms.Label
      Private WithEvents label2 As System.Windows.Forms.Label
      Private WithEvents _cmbChanel As System.Windows.Forms.ComboBox
      Private WithEvents _numClipping As System.Windows.Forms.NumericUpDown
      Private WithEvents _lblClipping As System.Windows.Forms.Label
      Private WithEvents _lblPercentil As System.Windows.Forms.Label
      Private WithEvents _lblMedian As System.Windows.Forms.Label
      Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents _lblMean As System.Windows.Forms.Label
      Private WithEvents _lblToltalPixels As System.Windows.Forms.Label
      Private WithEvents _lblMin As System.Windows.Forms.Label
      Private WithEvents _lblMax As System.Windows.Forms.Label
      Private WithEvents _lblCount As System.Windows.Forms.Label
      Private WithEvents _lblLevel As System.Windows.Forms.Label
      Private WithEvents _pnlHistogram As System.Windows.Forms.Panel
   End Class
End Namespace