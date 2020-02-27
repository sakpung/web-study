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
Imports Leadtools.Medical.HL7.V2x.Models
Imports System

Namespace HL7Messaging
   Partial Public Class CreateMessageView
      Inherits Form
      Public Property SelectedMessage() As String
         Get
            Return m_SelectedMessage
         End Get
         Set(value As String)
            m_SelectedMessage = Value
         End Set
      End Property
      Private m_SelectedMessage As String
      Public Property SelectedVersion() As String
         Get
            Return m_SelectedVersion
         End Get
         Set(value As String)
            m_SelectedVersion = Value
         End Set
      End Property
      Private m_SelectedVersion As String

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Function GetSelectedVersion() As String
         Return comboBox1.SelectedItem.ToString()
      End Function

      Private Sub BuildVersion()
         comboBox1.Items.Clear()
         comboBox1.Items.AddRange(HL7Package.EnumV2xVersions())
         comboBox1.SelectedIndex = comboBox1.Items.Count - 1
      End Sub

      Private Sub BuildView()
         treeView1.SuspendLayout()
         treeView1.Nodes.Clear()

         Dim all As String() = HL7Package.EnumMessages(GetSelectedVersion())
         For Each msg As String In all
            Dim node As New TreeNode()

            node.ImageIndex = 0
            node.SelectedImageIndex = 0
            node.Name = msg.Substring(msg.LastIndexOf("."c) + 1)
            node.Text = msg.Substring(msg.LastIndexOf("."c) + 1)
            node.Tag = "message"

            treeView1.Nodes.Add(node)
         Next
      End Sub

      Private Sub CreateMessageView_Load(sender As Object, e As EventArgs) Handles Me.Load
         BuildVersion()
         BuildView()
      End Sub

      Private Sub ReadMessage()
         If treeView1.SelectedNode Is Nothing Then
            Throw New Exception("Please select a message first")
         End If

         SelectedMessage = treeView1.SelectedNode.Name
         SelectedVersion = comboBox1.SelectedItem.ToString()

         If String.IsNullOrEmpty(SelectedMessage) Then
            Throw New Exception("Invalid message selected")
         End If
      End Sub

      Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
         Me.DialogResult = DialogResult.None
         Try
            ReadMessage()
            Me.DialogResult = DialogResult.OK
            Me.Close()
         Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
         End Try
      End Sub

      Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
         Me.DialogResult = DialogResult.Cancel
         Me.Close()
      End Sub

      Private Sub comboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBox1.SelectedIndexChanged
         BuildView()
      End Sub
   End Class
End Namespace
