// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.HL7.V2x.Models;
using System.IO;
using System.Xml;
using Leadtools.Medical.HL7.V2x.MLP;
using System.Reflection;

namespace HL7Messaging
{
   public partial class MainView : Form
   {
      MessageModel Model = new MessageModel();
      private string _initialPath = string.Empty;

      public MainView()
      {
         InitializeComponent();
      }
      
      void OnError(Exception ex)
      {
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      private void loadToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            openFileDialog1.InitialDirectory = _initialPath;
            if (DialogResult.OK != openFileDialog1.ShowDialog())
            {
               return;
            }
            _initialPath = Path.GetDirectoryName(openFileDialog1.FileName);
            Model.LoadPipeMessageFile(openFileDialog1.FileName);
         }
         catch (System.Exception ex)
         {
            OnError(ex);
         }
      }

      private string GetNodesSettingsFileName()
      {
         string codeBase = Assembly.GetExecutingAssembly().CodeBase;
         UriBuilder uri = new UriBuilder(codeBase);
         string path = Uri.UnescapeDataString(uri.Path);
         return Path.Combine(Path.GetDirectoryName(path), @"HL7Messaging.xml");
      }

      private void MainView_Load(object sender, EventArgs e)
      {
         comboBox1.SelectedIndex = 0;

         Model.MessageChanged += new EventHandler(Model_MessageChanged);

         Model.MessageFromStruct("ORU_R01", "V26");

         try
         {
            ConnectionNodes.Instance().Load(GetNodesSettingsFileName());
         }
         catch
         {
            //ignored
         }
      }

      private void MainView_FormClosing(object sender, FormClosingEventArgs e)
      {
         Model.MessageChanged -= new EventHandler(Model_MessageChanged);

         try
         {
            ConnectionNodes.Instance().Save(GetNodesSettingsFileName());
         }
         catch
         {
         	//ignored
         }
      }

      private void Model_MessageChanged(object sender, EventArgs e)
      {
         UpdateView();
      }
      
      private void UpdateView()
      {
         try
         {
            NodeItemView tvc = null;

            switch(comboBox1.SelectedIndex)
            {
               case 0: 
                  tvc = Model.BuildViewCtrl_Populated(true);
                  break;
                  
               case 1: 
                  tvc = Model.BuildViewCtrl_Populated(false);
                  break;

               case 2:
                  tvc = Model.BuildViewCtrl_Schema();
                  break;

               case 3:
                  tvc = Model.BuildViewCtrl_All();
                  break;

               default:
                  throw new Exception();
            }  
            
            propertyGrid1.PropertySort = PropertySort.NoSort;
            propertyGrid1.SelectedObject = new NodeItemViewWrapper(tvc);            
         }
         catch (System.Exception ex)
         {
            OnError(ex);
         }

         try
         {
            textBox1.Text = Model.PipeMessage;
         }
         catch (System.Exception ex)
         {
         	OnError(ex);
         }
      }
            
      private void newToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            CreateMessageView MessageView = new CreateMessageView();
            
            if (DialogResult.OK == MessageView.ShowDialog())
            {
               Model.MessageFromStruct(MessageView.SelectedMessage, MessageView.SelectedVersion);
            }
         }
         catch (System.Exception ex)
         {
            OnError(ex);
         }
      }

      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateView();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         try
         {
            Model.LoadPipeMessage(textBox1.Text);
         }
         catch (System.Exception ex)
         {
            OnError(ex);
         }
      }

      private void addMWLItemToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            AddMWLView MWLView = new AddMWLView();

            if (DialogResult.OK == MWLView.ShowDialog())
            {
               Model.ADTA01Message(MWLView.ID, MWLView.FirstName, MWLView.MiddleName, MWLView.LastName);

               SendHl7MessageView SendView = new SendHl7MessageView();
               SendView.Model = Model;
               SendView.PreferredNode = "MWL";

               if (DialogResult.OK == SendView.ShowDialog())
               {
                  try
                  {
                     Cursor.Current = Cursors.WaitCursor;
                     //Model.SendMessage(SendView.IP, int.Parse(SendView.Port));
                     MessageBox.Show("HL7 Message was sent successfully");
                  }
                  finally
                  {
                     Cursor.Current = Cursors.Default;
                  }
               }               
            }
         }
         catch (System.Exception ex)
         {
            OnError(ex);
         }
      }

      private void updatePatientToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            PatientUpdateView PatientUpdateView = new PatientUpdateView();

            if (DialogResult.OK == PatientUpdateView.ShowDialog())
            {
               Model.ADTA01MessagePatientUpdate(PatientUpdateView.ID, PatientUpdateView.Sex, PatientUpdateView.FirstName, PatientUpdateView.LastName);

               SendHl7MessageView SendView = new SendHl7MessageView();
               SendView.Model = Model;
               SendView.PreferredNode = "PatientUpdate";

               if (DialogResult.OK == SendView.ShowDialog())
               {
                  try
                  {
                     Cursor.Current = Cursors.WaitCursor;
                     //Model.SendMessage(SendView.IP, int.Parse(SendView.Port));
                     MessageBox.Show("HL7 Message was sent successfully");
                  }
                  finally
                  {
                     Cursor.Current = Cursors.Default;
                  }
               }
            }
         }
         catch (System.Exception ex)
         {
            OnError(ex);
         }
      }

      private void saveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            saveFileDialog1.InitialDirectory = _initialPath;
            if (DialogResult.OK != saveFileDialog1.ShowDialog())
            {
               return;
            }
            _initialPath = Path.GetDirectoryName(saveFileDialog1.FileName);
            using (var file = new StreamWriter(saveFileDialog1.FileName))
            {
               file.Write(Model.PipeMessage);
            }
         }
         catch (System.Exception ex)
         {
            OnError(ex);
         }
      }
            

      private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SendHl7MessageView SendView = new SendHl7MessageView();
         SendView.Model = Model;
         SendView.ShowDialog();
      }

      private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
      {

      }

   }
}
