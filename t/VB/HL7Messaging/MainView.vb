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
Imports System.IO
Imports System.Xml
Imports Leadtools.Medical.HL7.V2x.MLP
Imports System.Reflection
Imports System

Namespace HL7Messaging
   Partial Public Class MainView
      Inherits Form
      Private Model As New MessageModel()
      Private _initialPath As String = String.Empty

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub OnError(ex As Exception)
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
      End Sub

      Private Sub loadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles loadToolStripMenuItem.Click
         Try
            openFileDialog1.InitialDirectory = _initialPath
            If DialogResult.OK <> openFileDialog1.ShowDialog() Then
               Return
            End If
            _initialPath = Path.GetDirectoryName(openFileDialog1.FileName)
            Model.LoadPipeMessageFile(openFileDialog1.FileName)
         Catch ex As System.Exception
            OnError(ex)
         End Try
      End Sub

      Private Function GetNodesSettingsFileName() As String
         Dim codeBase As String = Assembly.GetExecutingAssembly().CodeBase
         Dim uri__1 As New UriBuilder(codeBase)
         Dim path__2 As String = Uri.UnescapeDataString(uri__1.Path)
         Return Path.Combine(Path.GetDirectoryName(path__2), "HL7Messaging.xml")
      End Function

      Private Sub MainView_Load(sender As Object, e As EventArgs) Handles Me.Load
         comboBox1.SelectedIndex = 0

         AddHandler Model.MessageChanged, AddressOf Model_MessageChanged

         Model.MessageFromStruct("ORU_R01", "V26")

         Try
            ConnectionNodes.Instance().Load(GetNodesSettingsFileName())
            'ignored
         Catch
         End Try
      End Sub

      Private Sub MainView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
         RemoveHandler Model.MessageChanged, AddressOf Model_MessageChanged

         Try
            ConnectionNodes.Instance().Save(GetNodesSettingsFileName())
            'ignored
         Catch
         End Try
      End Sub

      Private Sub Model_MessageChanged(sender As Object, e As EventArgs)
         UpdateView()
      End Sub

      Private Sub UpdateView()
         Try
            Dim tvc As NodeItemView = Nothing

            Select Case comboBox1.SelectedIndex
               Case 0
                  tvc = Model.BuildViewCtrl_Populated(True)
                  Exit Select

               Case 1
                  tvc = Model.BuildViewCtrl_Populated(False)
                  Exit Select

               Case 2
                  tvc = Model.BuildViewCtrl_Schema()
                  Exit Select

               Case 3
                  tvc = Model.BuildViewCtrl_All()
                  Exit Select
               Case Else

                  Throw New Exception()
            End Select

            propertyGrid1.PropertySort = PropertySort.NoSort
            propertyGrid1.SelectedObject = New NodeItemViewWrapper(tvc)
         Catch ex As System.Exception
            OnError(ex)
         End Try

         Try
            textBox1.Text = Model.PipeMessage
         Catch ex As System.Exception
            OnError(ex)
         End Try
      End Sub

      Private Sub newToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles newToolStripMenuItem.Click
         Try
            Dim MessageView As New CreateMessageView()

            If DialogResult.OK = MessageView.ShowDialog() Then
               Model.MessageFromStruct(MessageView.SelectedMessage, MessageView.SelectedVersion)
            End If
         Catch ex As System.Exception
            OnError(ex)
         End Try
      End Sub

      Private Sub comboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBox1.SelectedIndexChanged
         UpdateView()
      End Sub

      Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
         Try
            Model.LoadPipeMessage(textBox1.Text)
         Catch ex As System.Exception
            OnError(ex)
         End Try
      End Sub

      Private Sub addMWLItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles addMWLItemToolStripMenuItem.Click
         Try
            Dim MWLView As New AddMWLView()

            If DialogResult.OK = MWLView.ShowDialog() Then
               Model.ADTA01Message(MWLView.ID, MWLView.FirstName, MWLView.MiddleName, MWLView.LastName)

               Dim SendView As New SendHl7MessageView()
               SendView.Model = Model
               SendView.PreferredNode = "MWL"

               If DialogResult.OK = SendView.ShowDialog() Then
                  Try
                     Cursor.Current = Cursors.WaitCursor
                     'Model.SendMessage(SendView.IP, int.Parse(SendView.Port));
                     MessageBox.Show("HL7 Message was sent successfully")
                  Finally
                     Cursor.Current = Cursors.[Default]
                  End Try
               End If
            End If
         Catch ex As System.Exception
            OnError(ex)
         End Try
      End Sub

      Private Sub updatePatientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles updatePatientToolStripMenuItem.Click
         Try
            Dim PatientUpdateView As New PatientUpdateView()

            If DialogResult.OK = PatientUpdateView.ShowDialog() Then
               Model.ADTA01MessagePatientUpdate(PatientUpdateView.ID, PatientUpdateView.Sex, PatientUpdateView.FirstName, PatientUpdateView.LastName)

               Dim SendView As New SendHl7MessageView()
               SendView.Model = Model
               SendView.PreferredNode = "PatientUpdate"

               If DialogResult.OK = SendView.ShowDialog() Then
                  Try
                     Cursor.Current = Cursors.WaitCursor
                     'Model.SendMessage(SendView.IP, int.Parse(SendView.Port));
                     MessageBox.Show("HL7 Message was sent successfully")
                  Finally
                     Cursor.Current = Cursors.[Default]
                  End Try
               End If
            End If
         Catch ex As System.Exception
            OnError(ex)
         End Try
      End Sub

      Private Sub saveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles saveToolStripMenuItem.Click
         Try
            saveFileDialog1.InitialDirectory = _initialPath
            If DialogResult.OK <> saveFileDialog1.ShowDialog() Then
               Return
            End If
            _initialPath = Path.GetDirectoryName(saveFileDialog1.FileName)
            Using file As StreamWriter = New StreamWriter(saveFileDialog1.FileName)
               file.Write(Model.PipeMessage)
            End Using
         Catch ex As System.Exception
            OnError(ex)
         End Try
      End Sub


      Private Sub sendMessageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles sendMessageToolStripMenuItem.Click
         Dim SendView As New SendHl7MessageView()
         SendView.Model = Model
         SendView.ShowDialog()
      End Sub

      Private Sub openFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles openFileDialog1.FileOk

      End Sub

   End Class
End Namespace
