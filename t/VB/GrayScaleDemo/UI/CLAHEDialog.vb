' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.ImageProcessing.Core
Imports System

Partial Public Class CLAHEDialog
   Inherits Form
   Public AlphaFactor As Single
   Public BinNumber As Integer
   Public Flags As CLAHECommandFlags
   Public TileHistClipLimit As Single
   Public TilesNumber As Integer

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      AlphaFactor = CSng(_numAlpha.Value)
      BinNumber = Integer.Parse(_cmbBinsNumber.Text)
      TileHistClipLimit = CSng(_numClipLimit.Value)
      TilesNumber = CInt(_numTiles.Value)

      Select Case _cmbFlags.SelectedIndex
         Case 0
            Flags = CLAHECommandFlags.ApplyNormalDistribution
            Exit Select
         Case 1
            Flags = CLAHECommandFlags.ApplyExponentialDistribution
            Exit Select
         Case 2
            Flags = CLAHECommandFlags.ApplyRayliehDistribution
            Exit Select
         Case 3
            Flags = CLAHECommandFlags.ApplySigmoidDistribution
            Exit Select
      End Select

      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub CLAHEDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      _cmbFlags.SelectedIndex = 0
      _cmbBinsNumber.SelectedIndex = 6
      _numTiles.Value = 6
      _numAlpha.Value = CDec(0.65)
      _numClipLimit.Value = CDec(0.08)
      _numAlpha.Enabled = False
   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub


   Private Sub _cmbFlags_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbFlags.SelectedIndexChanged
      Select Case _cmbFlags.SelectedIndex
         Case 0
            _numAlpha.Enabled = False
            Exit Select
         Case 1
            _numAlpha.Enabled = True
            _numAlpha.Maximum = 1D
            Exit Select
         Case 2
            _numAlpha.Enabled = True
            _numAlpha.Maximum = 1D
            Exit Select
         Case 3
            _numAlpha.Enabled = True
            _numAlpha.Maximum = 5D
            Exit Select
      End Select
   End Sub


End Class
