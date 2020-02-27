Imports Microsoft.VisualBasic
Imports System

Partial Public Class OcrEngineSettingsControl
   ''' <summary>
   ''' Required designer variable.
   '''</summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   '''</summary>
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
   '''</summary>
   Private Sub InitializeComponent()
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(OcrEngineSettingsControl))
      Me._pnlSettings = New System.Windows.Forms.Panel()
      Me._tvCategories = New System.Windows.Forms.TreeView()
      Me._btnLoad = New System.Windows.Forms.Button()
      Me._btnSave = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      ' _pnlSettings
      '
      resources.ApplyResources(Me._pnlSettings, "_pnlSettings")
      Me._pnlSettings.Name = "_pnlSettings"
      '
      ' _tvCategories
      '
      resources.ApplyResources(Me._tvCategories, "_tvCategories")
      Me._tvCategories.HideSelection = False
      Me._tvCategories.Name = "_tvCategories"
      AddHandler Me._tvCategories.AfterSelect, AddressOf Me._tvCategories_AfterSelect
      '
      ' _btnLoad
      '
      resources.ApplyResources(Me._btnLoad, "_btnLoad")
      Me._btnLoad.Name = "_btnLoad"
      Me._btnLoad.UseVisualStyleBackColor = True
      AddHandler Me._btnLoad.Click, AddressOf Me._btnLoad_Click
      '
      ' _btnSave
      '
      resources.ApplyResources(Me._btnSave, "_btnSave")
      Me._btnSave.Name = "_btnSave"
      Me._btnSave.UseVisualStyleBackColor = True
      AddHandler Me._btnSave.Click, AddressOf Me._btnSave_Click
      '
      ' OcrEngineSettingsControl
      '
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._btnSave)
      Me.Controls.Add(Me._btnLoad)
      Me.Controls.Add(Me._pnlSettings)
      Me.Controls.Add(Me._tvCategories)
      Me.Name = "OcrEngineSettingsControl"
      AddHandler Me.Resize, AddressOf Me.OcrEngineSettingsControl_Resize
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _pnlSettings As System.Windows.Forms.Panel
   Private _tvCategories As System.Windows.Forms.TreeView
   Private _btnLoad As System.Windows.Forms.Button
   Private _btnSave As System.Windows.Forms.Button
End Class
