// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

using Leadtools;
using Leadtools.Demos;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using System.Collections;


namespace DicomDemo
{
   public partial class MainForm : Form
   {
      private int _currentPage;
      private Globals _globals;
      private String[] _pageTitles = new string[] {
            "Step 1: Set the maximum timeout",
            "Step 2: Configure Modality Work List Server",
            "Step 3: Choose Query Type",
            "Step 4: Query the Modality Work List Server",
            "Step 5: Construct the Data Set",
            "Step 6: Specify Values for Required Elements",
            "Step 7: Store the Data Set",
            "Thank You!"};

#if LTV20_CONFIG
      const string subKey = @"SOFTWARE\LEAD Technologies, Inc.\20\CSharp_DicomMwlScu20";
#elif LTV19_CONFIG
      const string subKey = @"SOFTWARE\LEAD Technologies, Inc.\19\CSharp_DicomMwlScu19";
#endif

      public MainForm()
      {
         InitializeComponent();

         //
         _globals = new Globals();
      }

      ArrayList _pages = new ArrayList();

      private void MainForm_Load(object sender, EventArgs e)
      {
         // Try to get settings from registry
         LoadSettings();

         _pages.Add(new Page0(ref _globals));
         _pages.Add(new Page1(ref _globals));
         _pages.Add(new Page2(ref _globals));
         _pages.Add(new Page3(ref _globals));
         _pages.Add(new Page4(ref _globals));
         _pages.Add(new Page5(ref _globals));
         _pages.Add(new Page6(ref _globals));
         _pages.Add(new Page7());

         foreach (UserControl page in _pages)
         {
            panel1.Controls.Add(page);
         }


         for (int i = 0; i < panel1.Controls.Count; i++)
         {
            panel1.Controls[i].Visible = false;
            panel1.Controls[i].Dock = DockStyle.Fill;
         }

         _currentPage = 0;
         SetTitleAndButtons();
         panel1.Visible = true;
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            Globals._closing = true;

            foreach (UserControl page in _pages)
            {
               page.Dispose();
            }

            DicomNet.Shutdown();
            SaveSettings();
         }
         catch (Exception)
         {
         }
      }

      /// The main entry point for the application.
      [STAThread]
      static void Main()
      {

         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.DicomCommunication))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning");
            return;
         }


         Utils.EngineStartup();
         Utils.DicomNetStartup();

         Application.Run(new MainForm());
      }

      private void btnNext_Click(object sender, EventArgs e)
      {
         HandleNext();
         SetTitleAndButtons();
      }

      private void btnBack_Click(object sender, EventArgs e)
      {
         _currentPage--;
         SetTitleAndButtons();
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      /*
       * This function handles the next button and executes the necessary code for the 
       *   current page
       */
      private void HandleNext()
      {
         try
         {
            switch (_currentPage)
            {
               case 0:
                  // Set necessary global properties and save registry settings
                  _globals.m_nTimerMax = Convert.ToInt32(((Page0)panel1.Controls[_currentPage]).txtTimeout.Text);
                  SaveSettings();
                  break;
               case 1:
                  // Save registry settings
                  // We don't set any globals here because it is done in the Verify button
                  SaveSettings();
                  break;
               case 2:
                  // Set necessary global properties
                  if (((Page2)panel1.Controls[_currentPage]).radBroad.Checked)
                     _globals.m_nQueryType = 1;
                  else
                     _globals.m_nQueryType = 2;

                  _globals.m_bCheckScheduledDate = ((Page2)panel1.Controls[_currentPage]).chkScheduledDate.Checked;
                  _globals.m_bCheckModality = ((Page2)panel1.Controls[_currentPage]).chkModality.Checked;
                  _globals.m_strModality = _globals.m_ModalityTable[((Page2)panel1.Controls[_currentPage]).cboModality.SelectedIndex].m_strValue;
                  _globals.m_ScheduledDate = ((Page2)panel1.Controls[_currentPage]).dtpScheduledDate.Value;

                  _globals.m_strAccessionNumber = ((Page2)panel1.Controls[_currentPage]).txtAccessionNumber.Text;
                  _globals.m_strPatientID = ((Page2)panel1.Controls[_currentPage]).txtPatientID.Text;
                  _globals.m_strPatientName = ((Page2)panel1.Controls[_currentPage]).txtPatientName.Text;
                  _globals.m_strRequestedProcedureID = ((Page2)panel1.Controls[_currentPage]).txtRequestedProcedureID.Text;

                  // Save settings to registry
                  SaveSettings();
                  break;
               case 3:
                  // nothing to do
                  break;
               case 4:
                  switch (((Page4)panel1.Controls[_currentPage]).CreateDataset())
                  {
                     case Page4.CreateDatasetReturn.Success:
                        break;
                     case Page4.CreateDatasetReturn.ModalityNotFound:
                        MessageBox.Show("Modality not supported, creating dataset using modality SC", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                     case Page4.CreateDatasetReturn.GeneralError:
                        MessageBox.Show("Could not create dataset", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnBack.PerformClick();
                        break;
                     case Page4.CreateDatasetReturn.NoItemSelected:
                        MessageBox.Show("Please select a modality worklist item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnBack.PerformClick();
                        break;
                  }
                  break;
               case 5:
                  // nothing to do
                  if (!_globals.m_bMandatoryElementsFilled)
                  {
                     if (MessageBox.Show("You have not filled out all of the empty mandatory elements.  " +
                         "If you attempt to store this dataset onto a server in the next step, " +
                         "the server might reject it.  If this occurs, press the Back button and fill all elements.\r\n\r\n" +
                         "Do you want to proceed?",
                         "Warning",
                         MessageBoxButtons.YesNo) == DialogResult.No)
                     {
                        btnBack.PerformClick();
                     }
                  }
                  break;
               case 6:
                  // Update settings
                  _globals.m_StorageServer.AETitle = ((Page6)panel1.Controls[_currentPage]).txtServerAE.Text;
                  _globals.m_StorageServer.Address = IPAddress.Parse(((Page6)panel1.Controls[_currentPage]).txtServerIP.Text);
                  _globals.m_StorageServer.Port = Convert.ToInt32(((Page6)panel1.Controls[_currentPage]).txtServerPort.Text);
                  _globals.m_strStorageClientAE = ((Page6)panel1.Controls[_currentPage]).txtClientAE.Text;

                  // Save settings to registry
                  SaveSettings();
                  break;
               case 7:
                  // Finish button
                  Close();
                  break;
            }

            _currentPage++;

         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      /*
       * Correctly set the title and the Next and Back buttons based on the current page.
       */
      private void SetTitleAndButtons()
      {
         try
         {
            switch (_currentPage)
            {
               case 0:
                  btnBack.Enabled = false;
                  btnNext.Enabled = true;
                  panel1.Controls[_currentPage + 1].Visible = false;
                  break;
               case 1:
               case 2:
               case 3:
               case 4:
               case 5:
               case 6:
                  btnNext.Enabled = _globals.bMWLServerValid;
                  btnBack.Enabled = true;
                  panel1.Controls[_currentPage - 1].Visible = false;
                  panel1.Controls[_currentPage + 1].Visible = false;
                  break;
               case 7:
                  panel1.Controls[_currentPage - 1].Visible = false;
                  btnBack.Enabled = false;
                  btnNext.Text = "Finished";
                  break;
               case 8:
                  return;
            }
            this.Text = _pageTitles[_currentPage];
            panel1.Controls[_currentPage].Visible = true;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      /*
       * Loads settings from the registry.
       */
      private void LoadSettings()
      {
         try
         {
            RegistryKey user = Registry.CurrentUser;

            RegistryKey settings = user.OpenSubKey(subKey, true);

            if (settings == null)
            {
               // We haven't saved any setting yet.  Use defaultsp

               return;
            }

            // PAGE 0
            _globals.m_nTimerMax = Convert.ToInt32(settings.GetValue("ServerTimeout"));

            // PAGE 1
            _globals.m_MWLServer.AETitle = Convert.ToString(settings.GetValue("MWLServerAE"));
            _globals.m_MWLServer.Port = Convert.ToInt32(settings.GetValue("MWLServerPort"));
            _globals.m_MWLServer.Address = IPAddress.Parse(Convert.ToString(settings.GetValue("MWLServerAddress")));
            _globals.m_strMWLClientAE = Convert.ToString(settings.GetValue("MWLClientAE"));


            // PAGE 2
            _globals.m_nQueryType = Convert.ToInt32(settings.GetValue("nQueryType"));
            _globals.m_strAccessionNumber = Convert.ToString(settings.GetValue("strAccessionNumber"));
            _globals.m_strModality = Convert.ToString(settings.GetValue("strModality"));
            _globals.m_strPatientID = Convert.ToString(settings.GetValue("strPatientID"));
            _globals.m_strPatientName = Convert.ToString(settings.GetValue("strPatientName"));
            _globals.m_strRequestedProcedureID = Convert.ToString(settings.GetValue("strRequestedProcedureID"));
            _globals.m_ScheduledDate = DateTime.Parse(Convert.ToString(settings.GetValue("ScheduledDate")));
            _globals.m_bCheckModality = Convert.ToBoolean(settings.GetValue("bCheckModality"));
            _globals.m_bCheckScheduledDate = Convert.ToBoolean(settings.GetValue("bCheckScheduledDate"));

            // PAGE 6
            _globals.m_StorageServer.AETitle = Convert.ToString(settings.GetValue("StorageServerAE"));
            _globals.m_StorageServer.Port = Convert.ToInt32(settings.GetValue("StorageServerPort"));
            _globals.m_StorageServer.Address = IPAddress.Parse(Convert.ToString(settings.GetValue("StorageServerAddress")));
            _globals.m_strStorageClientAE = Convert.ToString(settings.GetValue("StorageClientAE"));
            _globals.m_bStoreOnServer = Convert.ToBoolean(settings.GetValue("bStoreOnServer"));

            settings.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      /*
       * Saves settings to the registry
       */
      private void SaveSettings()
      {
         try
         {
            RegistryKey user = Registry.CurrentUser;

            RegistryKey settings = user.OpenSubKey(subKey, true);
            if (settings == null)
            {

               settings = user.CreateSubKey(subKey);

            }

            // PAGE 0
            settings.SetValue("ServerTimeout", _globals.m_nTimerMax.ToString(), RegistryValueKind.DWord);

            // PAGE 1
            settings.SetValue("MWLServerAE", _globals.m_MWLServer.AETitle.ToString());
            settings.SetValue("MWLServerPort", _globals.m_MWLServer.Port.ToString(), RegistryValueKind.DWord);
            settings.SetValue("MWLServerAddress", _globals.m_MWLServer.Address.ToString());
            settings.SetValue("MWLClientAE", _globals.m_strMWLClientAE.ToString());

            // PAGE 2
            settings.SetValue("nQueryType", _globals.m_nQueryType, RegistryValueKind.DWord);
            settings.SetValue("strAccessionNumber", _globals.m_strAccessionNumber);
            settings.SetValue("strModality", _globals.m_strModality);
            settings.SetValue("strPatientID", _globals.m_strPatientID);
            settings.SetValue("strPatientName", _globals.m_strPatientName);
            settings.SetValue("strRequestedProcedureID", _globals.m_strRequestedProcedureID);
            settings.SetValue("ScheduledDate", _globals.m_ScheduledDate);
            settings.SetValue("bCheckModality", _globals.m_bCheckModality, RegistryValueKind.DWord);
            settings.SetValue("bCheckScheduledDate", _globals.m_bCheckScheduledDate, RegistryValueKind.DWord);

            // PAGE 6
            settings.SetValue("StorageServerAE", _globals.m_StorageServer.AETitle.ToString());
            settings.SetValue("StorageServerPort", _globals.m_StorageServer.Port.ToString(), RegistryValueKind.DWord);
            settings.SetValue("StorageServerAddress", _globals.m_StorageServer.Address.ToString());
            settings.SetValue("StorageClientAE", _globals.m_strStorageClientAE.ToString());
            settings.SetValue("bStoreOnServer", _globals.m_bStoreOnServer, RegistryValueKind.DWord);

            settings.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }
   }
}
