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
Imports System

Namespace HL7Messaging
   Partial Public Class SendHl7MessageView
      Inherits Form
      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub BuildView()
         Dim nodes As New List(Of String)()

         Dim i As Integer = 0
         For Each node As ConnectionNode In ConnectionNodes.Instance().Nodes
            If Not String.IsNullOrEmpty(node.Name) Then
               nodes.Add(node.Name)
            Else
               nodes.Add("(Unnamed) - " & (System.Threading.Interlocked.Increment(i)))
            End If
         Next
         comboBox1.Items.Clear()
         comboBox1.Items.AddRange(nodes.ToArray())
         If comboBox1.Items.Count > 0 Then
            comboBox1.SelectedIndex = 0
         End If
      End Sub

      Private Sub UpdateView()
         button1.Enabled = (comboBox1.Items.Count > 0)
         button4.Enabled = (comboBox1.Items.Count > 0)
         button5.Enabled = (comboBox1.Items.Count > 0)
      End Sub

      Private Sub SendHl7MessageView_Load(sender As Object, e As EventArgs) Handles Me.Load
         ConnectionNodes.Instance().AddDefaults()
         BuildView()
         If Not String.IsNullOrEmpty(PreferredNode) Then
            For index As Integer = 0 To comboBox1.Items.Count - 1
               If comboBox1.Items(index).ToString().ToLower().Contains(PreferredNode.ToLower()) Then
                  comboBox1.SelectedIndex = index
                  Exit For
               End If
            Next
         End If
         UpdateView()
      End Sub

      Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
         Try
            Cursor.Current = Cursors.WaitCursor
            Dim node As ConnectionNode = ConnectionNodes.Instance().Nodes(SelectedNode)
            Model.SendMessage(node)
            MessageBox.Show("HL7 Message was sent successfully")
         Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
         Finally
            Cursor.Current = Cursors.[Default]
         End Try
      End Sub

      Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
         Me.DialogResult = DialogResult.Cancel
         Me.Close()
      End Sub

      Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click
         Dim nc As New NodeConfig()
         ConnectionNodeBuilder.Defaults(nc.Node)
         If nc.ShowDialog() = DialogResult.OK Then
            ConnectionNodes.Instance().Add(nc.Node)
            BuildView()
            If comboBox1.Items.Count > 0 Then
               comboBox1.SelectedIndex = comboBox1.Items.Count - 1
            End If
            UpdateView()
         End If
      End Sub

      Private Sub button4_Click(sender As Object, e As EventArgs) Handles button4.Click
         ConnectionNodes.Instance().Remove(comboBox1.SelectedIndex)
         BuildView()
         UpdateView()
      End Sub

      Private Sub button5_Click(sender As Object, e As EventArgs) Handles button5.Click
         Dim nc As New NodeConfig()
         Dim selectedNode__1 As Integer = SelectedNode
         nc.Node = ConnectionNodes.Instance().Nodes(selectedNode__1)
         If nc.ShowDialog() = DialogResult.OK Then
            BuildView()
            If comboBox1.Items.Count > 0 Then
               comboBox1.SelectedIndex = selectedNode__1
            End If
            UpdateView()
         End If
      End Sub

      Public ReadOnly Property SelectedNode() As Integer
         Get
            If comboBox1.Items.Count > 0 Then
               Return comboBox1.SelectedIndex
            Else
               Return -1
            End If
         End Get
      End Property
      Public Property Model() As MessageModel
         Get
            Return m_Model
         End Get
         Set(value As MessageModel)
            m_Model = Value
         End Set
      End Property
      Private m_Model As MessageModel
      Public Property PreferredNode() As String
         Get
            Return m_PreferredNode
         End Get
         Set(value As String)
            m_PreferredNode = Value
         End Set
      End Property
      Private m_PreferredNode As String
   End Class
End Namespace
