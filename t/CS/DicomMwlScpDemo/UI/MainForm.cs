// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

using Leadtools;
using Leadtools.Demos;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using System.Security.Principal;
using System.Diagnostics;

namespace DicomDemo
{
   public partial class MainForm : Form
   {
      private Server dicomServer = new Server();
      public string m_strDBFileName;
      public string DB_FILENAME = "MWLSCP.db";

      public MainForm()
      {
         InitializeComponent();
      }

      /// The main entry point for the application.
      [STAThread]
      static void Main(string[] args)
      {
         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.DicomCommunication))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning");
            return;
         }

         if (DemosGlobal.MustRestartElevated())
         {
            DemosGlobal.TryRestartElevated(args);
            return;
         }

         Utils.EngineStartup();
         Utils.DicomNetStartup();

         Application.Run(new MainForm());
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         Close();
      }

      /*
       * Loads settings from the registry.
       */
      private void LoadSettings()
      {
         try
         {
            RegistryKey user = Registry.CurrentUser;

#if LTV20_CONFIG
            RegistryKey settings = user.OpenSubKey(@"SOFTWARE\LEAD Technologies, Inc.\20\CSharp_DicomMwlScp20", true);
#elif LTV19_CONFIG
            RegistryKey settings = user.OpenSubKey(@"SOFTWARE\LEAD Technologies, Inc.\19\CSharp_DicomMwlScp19", true);
#endif

            if (settings == null)
            {
               // We haven't saved any setting yet.  Use defaults
               txtCalledAE.Text = "LEAD_SERVER";
               txtPort.Text = "104";
               txtConcurrentConnections.Text = "5";

               m_strDBFileName = "";
               return;
            }

            txtCalledAE.Text = Convert.ToString(settings.GetValue("CalledAE"));
            txtPort.Text = Convert.ToString(settings.GetValue("Port"));
            txtConcurrentConnections.Text = Convert.ToString(settings.GetValue("MaxConcurrentConnections"));

            m_strDBFileName = Convert.ToString(settings.GetValue("strDBFileName"));
            settings.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error loading settings from registry:\r\n\r\n" + ex.ToString());
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

#if LTV20_CONFIG
            const string subKey = @"SOFTWARE\LEAD Technologies, Inc.\20\CSharp_DicomMwlScp20";
#elif LTV19_CONFIG
            const string subKey = @"SOFTWARE\LEAD Technologies, Inc.\19\CSharp_DicomMwlScp19";
#endif

            RegistryKey settings = user.OpenSubKey(subKey, true);
            if (settings == null)
            {

               settings = user.CreateSubKey(subKey);

            }

            settings.SetValue("CalledAE", txtCalledAE.Text);
            settings.SetValue("Port", Convert.ToInt32(txtPort.Text), RegistryValueKind.DWord);
            settings.SetValue("MaxConcurrentConnections", Convert.ToInt32(txtConcurrentConnections.Text), RegistryValueKind.DWord);

            settings.SetValue("strDBFileName", m_strDBFileName);

            settings.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error xaving xettings to registry:\r\n\r\n" + ex.ToString());
         }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         // Save settings to registry
         SaveSettings();
         Utils.DicomNetShutdown();
         Utils.EngineShutdown();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         // Try to get settings from registry
         LoadSettings();

         dicomServer.mf = this;

         if (!PrepareDatabase())
         {
            MessageBox.Show("The application couldn't be started because no database could be found.");
            Close();
         }

         if (!PopulateDatabaseList())
         {
            MessageBox.Show("The application couldn't be started because the database seems to be incompatible.");
            Close();
         }
      }

      /*
       * Adds a client to the ListView
       */
      private void btnAddClient_Click(object sender, EventArgs e)
      {
         if (txtCallingAE.Text == "")
         {
            MessageBox.Show("You must enter a name for the client");
         }
         else
         {
            try
            {
               string[] newClient = new string[] {
                        txtCallingAE.Text,
                        IPAddress.Parse(txtIP.Text).ToString() // This may look redundant, but it checks
                                                               // to make sure the IP address is valid
                    };
               lstClients.Items.Add(new ListViewItem(newClient));
               txtCallingAE.Text = "";
               txtIP.Text = "";
            }
            catch (FormatException ex)
            {
               if (ex.Message == "An invalid IP address was specified.")
               {
                  MessageBox.Show("The specified IP address is invalid.");
               }
               else
               {
                  MessageBox.Show("Error:\r\n\r\n" + ex.ToString());
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error:\r\n\r\n" + ex.ToString());
            }
         }
      }

      /*
       * Deletes a client from the ListView
       */
      private void btnDeleteClient_Click(object sender, EventArgs e)
      {
         if (lstClients.SelectedIndices.Count > 0)
            lstClients.Items.RemoveAt(lstClients.SelectedIndices[0]);
      }

      /*
       * Starts the server
       */
      private void btnStart_Click(object sender, EventArgs e)
      {
         DicomExceptionCode ret;

         try
         {
            dicomServer.CalledAE = txtCalledAE.Text;
            dicomServer.Port = Convert.ToInt32(txtPort.Text);
            dicomServer.Peers = Convert.ToInt32(txtConcurrentConnections.Text);

            ret = dicomServer.Listen();
            if (ret == DicomExceptionCode.Success)
            {
               EnableControls(true);
               Log("Server Started...\r\n");
               tabControl1.SelectedIndex = 2;
            }
            else
            {
               Log("Error starting server: " + ret.ToString() + "\r\n");
            }
         }
         catch (Exception ex)
         {
            Log("Error starting server:\r\n\r\n" + ex.ToString());
         }
      }

      /*
       * Stops the server
       */
      private void btnStop_Click(object sender, EventArgs e)
      {
         try
         {
            dicomServer.Close();
            EnableControls(false);
            Log("Server Stopped...\r\n");
         }
         catch (Exception ex)
         {
            Log("Error stopping server:\r\n\r\n" + ex.ToString());
         }
      }

      /*
       * Adds a string to the textbox on the log tab
       */
      public delegate void LogDelegate(string str);
      public void Log(string str)
      {
         if (this.InvokeRequired)
         {
            this.Invoke(new LogDelegate(Log), new object[] { str });
         }
         else
         {
            txtLog.Text += str;
         }
      }

      /*
       * Enables or disables controls based on whether the server is running
       */
      private void EnableControls(bool serverStarted)
      {
         txtCalledAE.Enabled = !serverStarted;
         txtCallingAE.Enabled = !serverStarted;
         txtConcurrentConnections.Enabled = !serverStarted;
         txtIP.Enabled = !serverStarted;
         txtPort.Enabled = !serverStarted;
         btnAddClient.Enabled = !serverStarted;
         btnDeleteClient.Enabled = !serverStarted;
         lstClients.Enabled = !serverStarted;
         btnStart.Enabled = !serverStarted;
         btnStop.Enabled = serverStarted;
      }

      /*
       * Clears the log
       */
      private void btnClearAll_Click(object sender, EventArgs e)
      {
         txtLog.Text = "";
      }

      /*
       * Attempts to find the database file referred to in the registry settings.  If it cannot find it, then
       *   look for it in the <LEADTOOLS>\Images\ directory.  If it cannot find it, then prompt the user.
       * 
       * Returns true if successful, false otherwise.
       */
      private bool PrepareDatabase()
      {
         string strAppFolder = "";
         string strLEADTOOLSFolder = "";
         string strNewDBFileName = "";
         string strExistingDBFileName = "";
         string strMessage = "";

         try
         {
            // Check the existance of the file saved in registry 
            if (File.Exists(m_strDBFileName))
               return true;

            strAppFolder = Application.StartupPath;

            strNewDBFileName = strAppFolder + "\\" + DB_FILENAME;

            // At first, we will assume that the application is running from the "Bin" subfolder of
            // the folder where LEADTOOLS is installed.
            if (strAppFolder != "")
            {
               strLEADTOOLSFolder = DemosGlobal.ImagesFolder;
            }

            // Locate the database file
            strExistingDBFileName = strLEADTOOLSFolder + "\\" + DB_FILENAME;

            if (!File.Exists(strExistingDBFileName))
            {
               //Locate the database file
               // Prompt the user to locate the file
               strMessage = "Failed to locate file (DB) used by this demo. " +
                            "Do you want to locate it yourself?\r\n\r\n" +
                            "Note: A Simple DB file is located under the LEADTOOLS Images directory created by LEADTOOLS \r\n" +
                            "If your system is on the C:\\ drive, the path for the database would be: \r\n" +
                            "<for windows XP>\r\n" +
                            "  C:\\Documents and Settings\\UserProfile\\My Documents\\LEADTOOLS Images\\" + DB_FILENAME + "\r\n" +
                            "<for windows VISTA>\r\n" +
                            "  C:\\Users\\UserProfile\\Documents\\LEADTOOLS Images\\" + DB_FILENAME;

               if (MessageBox.Show(strMessage, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                  //Allow the user to select a file
                  OpenFileDialog ofd = new OpenFileDialog();
                  ofd.FileName = DB_FILENAME;
                  ofd.Filter = "SQLite Databases (*.db)|*.db|All Files (*.*)|*.*";
                  //txt files (*.txt)|*.txt|All files (*.*)|*.*
                  ofd.Title = "Locate DB File";
                  ofd.CheckFileExists = true;

                  if (ofd.ShowDialog() == DialogResult.OK)
                  {
                     strExistingDBFileName = ofd.FileName;
                  }
                  else
                  {
                     return false;
                  }
               }
               else
               {
                  return false;
               }
            }

            // Copy the existing database file
            try
            {
               File.Copy(strExistingDBFileName, strNewDBFileName, false);
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error copying file: \r\n\r\n" + ex.ToString());
               return false;
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error initializing database:\r\n\r\n" + ex.ToString());
            return false;
         }

         m_strDBFileName = strNewDBFileName;
         return true;
      }

      /*
       * Queries the entire database and populates the ListView
       */
      private bool PopulateDatabaseList()
      {
         try
         {
            // Query database
            SQLiteConnection SqlConn = new SQLiteConnection();
            SqlConn.ConnectionString = String.Format("Data Source={0};New=False;Version=3", m_strDBFileName);
            SqlConn.Open();

            string strSQLQuery = "SELECT " +
                                 "TAG_ACCESSION_NUMBER as [Accession Number]," +
                                 "TAG_MODALITY  as [Modality]," +
                                 "TAG_INSTITUTION_NAME as [Institution Name]," +
                                 "TAG_REFERRING_PHYSICIAN_NAME as [Referring Physician Name]," +
                                 "TAG_PATIENT_NAME as [Patient Name]," +
                                 "TAG_PATIENT_ID as [Patient ID]," +
                                 "TAG_PATIENT_BIRTH_DATE as [Patient Birth Date]," +
                                 "TAG_PATIENT_SEX as [Patient Sex]," +
                                 "TAG_PATIENT_WEIGHT as [Patient Weight]," +
                                 "TAG_STUDY_INSTANCE_UID AS [Study Instance UID]," +
                                 "TAG_REQUESTING_PHYSICIAN AS [Requesting Physician]," +
                                 "TAG_REQUESTED_PROCEDURE_DESCRIPTION AS [Requested Procedure Description]," +
                                 "TAG_ADMISSION_ID AS [Admission ID]," +
                                 "TAG_SCHEDULED_STATION_AE_TITLE AS [Scheduled Station AE Title]," +
                                 "TAG_SCHEDULED_PROCEDURE_STEP_START_DATE AS [Scheduled Procedure Step Start Date]," +
                                 "TAG_SCHEDULED_PROCEDURE_STEP_START_TIME AS [Scheduled Procedure Step Start Time]," +
                                 "TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME AS [Scheduled Performing Physician Name]," +
                                 "TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION AS [Scheduled Procedure Step Description]," +
                                 "TAG_SCHEDULED_PROCEDURE_STEP_ID AS [Scheduled Procedure Step ID]," +
                                 "TAG_SCHEDULED_PROCEDURE_STEP_LOCATION AS [Scheduled Procedure Step Location]," +
                                 "TAG_REQUESTED_PROCEDURE_ID AS [Requested Procedure ID]," +
                                 "TAG_REASON_FOR_THE_REQUESTED_PROCEDURE AS [Reason for the Requested Procedure]," +
                                 "TAG_REQUESTED_PROCEDURE_PRIORITY AS [Requested Procedure Priority]," +
                                 "Item_ID  " +
                                 "FROM MwlSCPTbl ORDER BY Item_ID;";

            SQLiteCommand cmd = SqlConn.CreateCommand();
            cmd.CommandText = strSQLQuery;
            SQLiteDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            // Create the columns
            ColumnHeader[] columnHeaders = new ColumnHeader[reader.FieldCount - 1]; //one less field because we don't care about displaying the Item_ID
            Graphics g = lstDatabase.CreateGraphics();
            for (int i = 0; i < columnHeaders.Length; i++)
            {
               columnHeaders[i] = new ColumnHeader();
               columnHeaders[i].Text = reader.GetName(i);
               columnHeaders[i].Width = Convert.ToInt32((g.MeasureString(columnHeaders[i].Text, lstDatabase.Font)).Width) + 10;
            }
            lstDatabase.Columns.AddRange(columnHeaders);

            // Create the rows
            while (reader.Read())
            {
               string[] items = new string[reader.FieldCount]; // We use all fields here, but Item_ID is hidden

               for (int i = 0; i < reader.FieldCount; i++)
               {
                  // SQLite stores dates as strings, so avoid the internal conversion
                  if (reader.GetFieldType(i).ToString() == "System.DateTime")
                     items[i] = reader.GetString(i);
                  else
                     items[i] = reader.GetValue(i).ToString();
               }

               lstDatabase.Items.Add(new ListViewItem(items));
            }

            SqlConn.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error populating listbox with database:\r\n\r\n" + ex.ToString());
            return false;
         }

         return true;
      }

      /*
       * Adds a record to the database and its corresponding ListViewItem
       */
      private void btnAddRecord_Click(object sender, EventArgs e)
      {
         MwlItemDialog itemDlg = new MwlItemDialog(true);
         if (itemDlg.ShowDialog(this) == DialogResult.OK)
         {
            try
            {
               // Add the new item into the database
               SQLiteConnection SqlConn = new SQLiteConnection();
               SqlConn.ConnectionString = String.Format("Data Source={0};New=False;Version=3", m_strDBFileName);
               SqlConn.Open();

               SQLiteCommand cmd = SqlConn.CreateCommand();
               cmd.CommandText = itemDlg.m_strSqlQuery;
               cmd.ExecuteNonQuery();

               // Get the Item_ID of the record we just added and update the string array for creating the ListViewItem
               cmd = SqlConn.CreateCommand();
               cmd.CommandText = "SELECT last_insert_rowid()";
               itemDlg.m_strItemValues[23] = Convert.ToString(cmd.ExecuteScalar());

               SqlConn.Close();

               // Add the new ListViewItem
               lstDatabase.Items.Add(new ListViewItem(itemDlg.m_strItemValues));
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error adding record to database:\r\n\r\n" + ex.ToString());
            }
         }
      }

      /*
       * Modifys a record from the database and its corresponding ListViewItem
       */
      private void btnEditRecord_Click(object sender, EventArgs e)
      {
         if (lstDatabase.SelectedItems.Count > 0)
         {
            MwlItemDialog itemDlg = new MwlItemDialog(false);
            if (itemDlg.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  // Update the item in the database
                  SQLiteConnection SqlConn = new SQLiteConnection();
                  SqlConn.ConnectionString = String.Format("Data Source={0};New=False;Version=3", m_strDBFileName);
                  SqlConn.Open();

                  SQLiteCommand cmd = SqlConn.CreateCommand();
                  cmd.CommandText = itemDlg.m_strSqlQuery;
                  cmd.ExecuteNonQuery();

                  SqlConn.Close();

                  // Update the ListViewItem
                  lstDatabase.Items[lstDatabase.SelectedIndices[0]] = new ListViewItem(itemDlg.m_strItemValues);
               }
               catch (Exception ex)
               {
                  MessageBox.Show("Error modifying record in database:\r\n\r\n" + ex.ToString());
               }
            }
         }
         else
         {
            MessageBox.Show("Please select an item to edit");
         }
      }

      /*
       * Deletes a record from the database and its corresponding ListViewItem
       */
      private void btnDeleteRecord_Click(object sender, EventArgs e)
      {
         if (lstDatabase.SelectedItems.Count > 0)
         {
            try
            {
               // Delete the item from the database
               string strSQLQuery = "DELETE FROM MwlSCPTbl WHERE Item_ID='" + lstDatabase.SelectedItems[0].SubItems[23].Text + "'";
               SQLiteConnection SqlConn = new SQLiteConnection();
               SqlConn.ConnectionString = String.Format("Data Source={0};New=False;Version=3", m_strDBFileName);
               SqlConn.Open();

               SQLiteCommand cmd = SqlConn.CreateCommand();
               cmd.CommandText = strSQLQuery;
               cmd.ExecuteNonQuery();

               SqlConn.Close();

               // Delete the corresponding ListViewItem
               lstDatabase.Items.RemoveAt(lstDatabase.SelectedIndices[0]);

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error removing record from database:\r\n\r\n" + ex.ToString());
            }
         }
         else
         {
            MessageBox.Show("Please select an item to delete");
         }
      }
   }
}
