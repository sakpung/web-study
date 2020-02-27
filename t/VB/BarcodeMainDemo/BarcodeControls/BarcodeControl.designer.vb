
Partial Class BarcodeControl
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

#Region "Component Designer generated code"

   ''' <summary> 
   ''' Required method for Designer support - do not modify 
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BarcodeControl))
      Me._titleGroupBox = New System.Windows.Forms.GroupBox()
      Me._barcodesListView = New System.Windows.Forms.ListView()
      Me._symbologyColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me._locationColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me._valueColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me._bottomPanel = New System.Windows.Forms.Panel()
      Me._zoomToButton = New System.Windows.Forms.Button()
      Me._deleteButton = New System.Windows.Forms.Button()
      Me._aamvaButton = New System.Windows.Forms.Button()
      Me._titleGroupBox.SuspendLayout()
      Me._bottomPanel.SuspendLayout()
      Me.SuspendLayout()
      '
      '_titleGroupBox
      '
      Me._titleGroupBox.Controls.Add(Me._barcodesListView)
      Me._titleGroupBox.Controls.Add(Me._bottomPanel)
      resources.ApplyResources(Me._titleGroupBox, "_titleGroupBox")
      Me._titleGroupBox.Name = "_titleGroupBox"
      Me._titleGroupBox.TabStop = False
      '
      '_barcodesListView
      '
      Me._barcodesListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._symbologyColumnHeader, Me._locationColumnHeader, Me._valueColumnHeader})
      resources.ApplyResources(Me._barcodesListView, "_barcodesListView")
      Me._barcodesListView.FullRowSelect = True
      Me._barcodesListView.HideSelection = False
      Me._barcodesListView.MultiSelect = False
      Me._barcodesListView.Name = "_barcodesListView"
      Me._barcodesListView.UseCompatibleStateImageBehavior = False
      Me._barcodesListView.View = System.Windows.Forms.View.Details
      '
      '_symbologyColumnHeader
      '
      resources.ApplyResources(Me._symbologyColumnHeader, "_symbologyColumnHeader")
      '
      '_locationColumnHeader
      '
      resources.ApplyResources(Me._locationColumnHeader, "_locationColumnHeader")
      '
      '_valueColumnHeader
      '
      resources.ApplyResources(Me._valueColumnHeader, "_valueColumnHeader")
      '
      '_bottomPanel
      '
      Me._bottomPanel.Controls.Add(Me._aamvaButton)
      Me._bottomPanel.Controls.Add(Me._zoomToButton)
      Me._bottomPanel.Controls.Add(Me._deleteButton)
      resources.ApplyResources(Me._bottomPanel, "_bottomPanel")
      Me._bottomPanel.Name = "_bottomPanel"
      '
      '_zoomToButton
      '
      resources.ApplyResources(Me._zoomToButton, "_zoomToButton")
      Me._zoomToButton.Name = "_zoomToButton"
      Me._zoomToButton.UseVisualStyleBackColor = True
      '
      '_deleteButton
      '
      resources.ApplyResources(Me._deleteButton, "_deleteButton")
      Me._deleteButton.Name = "_deleteButton"
      Me._deleteButton.UseVisualStyleBackColor = True
      '
      '_aamvaButton
      '
      resources.ApplyResources(Me._aamvaButton, "_aamvaButton")
      Me._aamvaButton.Name = "_aamvaButton"
      Me._aamvaButton.UseVisualStyleBackColor = True
      '
      'BarcodeControl
      '
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._titleGroupBox)
      Me.Name = "BarcodeControl"
      Me._titleGroupBox.ResumeLayout(False)
      Me._bottomPanel.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _titleGroupBox As System.Windows.Forms.GroupBox
   Private _bottomPanel As System.Windows.Forms.Panel
   Private WithEvents _deleteButton As System.Windows.Forms.Button
   Private WithEvents _barcodesListView As System.Windows.Forms.ListView
   Private _symbologyColumnHeader As System.Windows.Forms.ColumnHeader
   Private _locationColumnHeader As System.Windows.Forms.ColumnHeader
   Private _valueColumnHeader As System.Windows.Forms.ColumnHeader
   Private WithEvents _zoomToButton As System.Windows.Forms.Button
   Friend WithEvents _aamvaButton As System.Windows.Forms.Button
End Class
