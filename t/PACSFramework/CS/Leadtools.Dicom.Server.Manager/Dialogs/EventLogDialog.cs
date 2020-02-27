// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlServerCe;
using System.Diagnostics;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Configuration.Logging;

namespace Leadtools.Dicom.Server.Manager.Dialogs
{
   public partial class EventLogDialog : Form
   {
      public const string LogDatabaseName = "Logging.sdf";

      public EventLogDialog(DicomService activeService )
      {
         InitializeComponent();

         ActiveService = activeService;
         UpdateService();
      }

      public DicomService ActiveService
      {
         get;
         set;
      }
      
      public string ServiceDirectory
      {
         get
         {
            if (ActiveService != null && ActiveService.ServiceDirectory != null)
               return ActiveService.ServiceDirectory;
            return string.Empty;
         }
      }

      public string ServiceName
      {
         get
         {
            if (ActiveService != null && ActiveService.ServiceName != null)
               return ActiveService.ServiceName;
            return string.Empty;
         }
      }
      
      public string GetLogDatabaseFullPath()
      {
         Debug.Assert(!string.IsNullOrEmpty(ServiceDirectory));
         string startPath = ServiceDirectory;
         string LogDatabaseFullPath = Path.Combine(startPath, LogDatabaseName);
         return LogDatabaseFullPath;
      }

      public string GetLogDatasetsFolder()
      {
         string startPath = ServiceDirectory;
         string LogDatasetsFolder = Path.Combine(startPath, "log\\Datasets");
         return LogDatasetsFolder.Trim();
      }

      public string GetConnectionString()
      {
         string LogDatabaseFullPath = GetLogDatabaseFullPath();
         string ConnectionString = "Data Source='" + LogDatabaseFullPath + "'";
         return ConnectionString;
      }

      private void EventLogDialog_Load(object sender, EventArgs e)
      {
         UpdateUI();
         numericUpDownLastLogs.Value = 100;
         SizeColumns(listViewEventLog);
      }

      private static void SizeColumns(ListView listview)
      {
         listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      }
      
      public void Clear()
      {
         listViewEventLog.Items.Clear();
      }
      
      private static string GetPortString(object o)
      {
         string sRet = string.Empty;
          int nServerPort =  Convert.ToInt32(o);
          if (nServerPort != -1) 
          sRet = nServerPort.ToString();
          return sRet;
      }

      private void DoQuery()
      {
         string sQuery = "SELECT * FROM [DICOMServerEventLog]";
         decimal nCount = numericUpDownLastLogs.Value;
         if (checkBoxLastLogs.Checked)
         {
            sQuery = string.Format("SELECT TOP ({0}) * FROM [DICOMServerEventLog]", nCount);
         }

         bool bAnd = false;
         if (checkBoxServerAeTitle.Checked)
         {
            string sSearchValue = textBoxServerAeTitle.Text.Trim();
            sSearchValue = sSearchValue.Replace("*", string.Empty);
            string sAppend = string.Format(" {0} ServerAETitle like '{1}%'", bAnd ? "AND" : "WHERE", sSearchValue);
            sQuery = sQuery + sAppend;
            bAnd = true;
         }

         if (checkBoxClientAeTitle.Checked)
         {
            string sSearchValue = textBoxClientAeTitle.Text.Trim();
            sSearchValue = sSearchValue.Replace("*", string.Empty);
            string sAppend = string.Format(" {0} ClientAETitle like '{1}%'", bAnd ? "AND" : "WHERE", sSearchValue);
            sQuery = sQuery + sAppend;
            bAnd = true;
         }

         sQuery = string.Concat(sQuery, " ORDER BY EventID");

         listViewEventLog.Items.Clear();
         string connectionString = GetConnectionString();
         using (SqlCeConnection connection = new SqlCeConnection(connectionString))
         {
            connection.Open();
            using (SqlCeCommand com = new SqlCeCommand(sQuery, connection))
            {
               SqlCeDataReader reader = com.ExecuteReader();
               while (reader.Read())
               {
                  try
                  {
                     object id                     =  reader["EventID"];
                     int    nEventId               = Convert.ToInt32(id);
                     string serverAeTitle          = (string)reader["ServerAETitle"].ToString();
                     string serverIpAddress        = (string)reader["ServerIPAddress"].ToString();
                     
                     string serverPort             = GetPortString(reader["ServerPort"]);
                     string clientAeTitle          = (string)reader["ClientAETitle"].ToString();
                     string clientHostAddress      = (string)reader["ClientHostAddress"].ToString();
                     string clientPort             = GetPortString(reader["ClientPort"]);
                     string command                = (string)reader["Command"].ToString();
                     string eventDateTime          = (string)reader["EventDateTime"].ToString();
                     // string logType                = (string)reader["Type"].ToString();
                     string messageDirection       = (string)reader["MessageDirection"].ToString();
                     string datasetPath            = (string)reader["DatasetPath"].ToString();
                     string description            = (string)reader["Description"].ToString();
                     // CustomInformation

                     if (string.Compare(command, "Undefined", true) == 0)
                     {
                        command = string.Empty;
                     }
                     
                     if (string.Compare(messageDirection, "None", true) == 0)
                     {
                        messageDirection = string.Empty;
                     }


                     ListViewItem item = listViewEventLog.Items.Add(serverAeTitle);
                     item.Tag = new EventLogItem(nEventId, datasetPath);
                     if (item != null)
                     {
                        item.SubItems.Add(serverIpAddress);             // 1
                        item.SubItems.Add(serverPort);                  // 2
                        item.SubItems.Add(clientAeTitle);               // 3
                        item.SubItems.Add(clientHostAddress);           // 4
                        item.SubItems.Add(clientPort.ToString());       // 5
                        item.SubItems.Add(command);                     // 6
                        item.SubItems.Add(eventDateTime);               // 7
                        // item.SubItems.Add(logType);
                        item.SubItems.Add(messageDirection);            // 8
                        item.SubItems.Add(description);                 // 9
                        item.SubItems.Add(datasetPath);                 // 10
                     }

                  }
                  catch (Exception ex)
                  {
                     MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
               }
            }
         }
      }

      private void buttonQuery_Click(object sender, EventArgs e)
      {
         DoQuery();
         SizeColumns(listViewEventLog);
      }

      private void UpdateUI()
      {
         // LastLogs checkbox
         bool enabledLastLogs = checkBoxLastLogs.Checked;
         numericUpDownLastLogs.Enabled = enabledLastLogs;
         labelLastLogs.Enabled = enabledLastLogs;

         // Server AE checkbox
         textBoxServerAeTitle.Enabled = checkBoxServerAeTitle.Checked;

         // Client AE checkbox
         textBoxClientAeTitle.Enabled = checkBoxClientAeTitle.Checked;

         int nSelectedCount = listViewEventLog.SelectedItems.Count;
         buttonDetail.Enabled = (nSelectedCount == 1);
         buttonDeleteSelected.Enabled = (nSelectedCount > 0);
      }

      public void UpdateService()
      {
         Text = @"Event Log - " + ServiceName;
         ConfigurationLoggingSession.ServerDirectory = ServiceDirectory;
         checkBoxEnableLogging.Text = string.Format("Enable Logging ({0})", ServiceName);

         bool logDicomDataset;
         checkBoxEnableLogging.Checked = ConfigurationLoggingSession.ReadSettings(out logDicomDataset);
         checkBoxLogDatasets.Checked = logDicomDataset;
      }

      private void buttonClear_Click(object sender, EventArgs e)
      {
         DialogResult dr = MessageBox.Show(@"You are about to permanently remove all log messages.  Do you want to continue?", @"Delete All", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
         if (dr == DialogResult.Yes)
         {
            // Delete any existing datasets
            DeleteAllDatasets();

            listViewEventLog.Items.Clear();
            SizeColumns(listViewEventLog);
            string connectionString = GetConnectionString();
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
               connection.Open();
               using (SqlCeCommand com = new SqlCeCommand("DELETE FROM DICOMServerEventLog", connection))
               {
                  com.ExecuteNonQuery();
               }
            }
         }
      }
      
      public string GetDeleteSelectedQuery()
      {
         string sQuery = "DELETE FROM DICOMServerEventLog";
         bool bFirst = true;
         
         foreach (ListViewItem lvi in listViewEventLog.SelectedItems)
         {
            EventLogItem eventLogItem = lvi.Tag as EventLogItem;

            int eventId = eventLogItem.EventId;
            if (bFirst)
            {
               sQuery = sQuery + string.Format(" WHERE EventId = '{0}' ", eventId);
               bFirst = false;
            }
            else
            {
               sQuery = sQuery + string.Format(" OR EventId = '{0}' ", eventId);
            }
         }
         
         return sQuery;
      }

      public void DeleteSelectedDatasets()
      {
         foreach (ListViewItem lvi in listViewEventLog.SelectedItems)
         {
            EventLogItem eventLogItem = lvi.Tag as EventLogItem;

            string file = eventLogItem.DatasetPath;
            if (File.Exists(file))
            {
               try
               {
                  File.Delete(file);
               }
               catch (Exception)
               {
               }
            }
         }
      }

      public void DeleteAllDatasets()
      {
         string LogDatasetsFolder = GetLogDatasetsFolder();
         if (!string.IsNullOrEmpty(LogDatasetsFolder))
         {
            DirectoryInfo directoryInfo = new DirectoryInfo(LogDatasetsFolder);
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
               // Just a precaution, but only delete files that have pattern xxxxxxxx.xxx
               if (file.Name.Length == 12 && file.Name[8] == '.')
               {
                  try
                  {
                     file.Delete();
                  }
                  catch (Exception)
                  {
                  }
               }
            }
         }

      }
      
      private void buttonDeleteSelected_Click(object sender, EventArgs e)
      {
         string sMsg = string.Format("You are about to permanently remove {0} selected log messages.  Do you want to continue?", listViewEventLog.SelectedItems.Count);
         DialogResult dr = MessageBox.Show(sMsg, @"Delete Selected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
         if (dr == DialogResult.Yes)
         {
            SizeColumns(listViewEventLog);
            string connectionString = GetConnectionString();
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
               connection.Open();
               string sQuery = GetDeleteSelectedQuery();
               using (SqlCeCommand com = new SqlCeCommand(sQuery, connection))
               {
                  com.ExecuteNonQuery();
               }
            }

            // Now delete any existing datasets
            DeleteSelectedDatasets();
            
            // Now remove selected items from ListView
            foreach (ListViewItem itemSelected in listViewEventLog.SelectedItems)
            {
               listViewEventLog.Items.Remove(itemSelected);
            }
         }
      }

      private void checkBoxLastLogs_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUI();
      }

      private void listViewEventLog_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
      {
         UpdateUI();
      }

      private void checkBoxServerAeTitle_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUI();
      }

      private void checkBoxClientAeTitle_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUI();
      }

      private void buttonClose_Click(object sender, EventArgs e)
      {
         Close();
      }
      
      private void ShowDetails()
      {
         if (listViewEventLog.SelectedItems.Count == 1)
         {
            ListViewItem item = listViewEventLog.SelectedItems[0];
            EventLogDetailDialog dlg = new EventLogDetailDialog();
            
            // string sNotUsed         = item.SubItems[1].Name;
            dlg.ServerAeTitle          = item.Text;
            dlg.ServerIpAddress        = item.SubItems[1].Text;
            dlg.ServerPort             = item.SubItems[2].Text;
            dlg.ClientAeTitle          = item.SubItems[3].Text;
            dlg.ClientIpAddress        = item.SubItems[4].Text;
            dlg.ClientPort             = item.SubItems[5].Text;
            dlg.Command                = item.SubItems[6].Text;
            dlg.EventDateTime          = item.SubItems[7].Text;
            // dlg.MessageDirection    = item.SubItems[8].Text;
            dlg.Description            = item.SubItems[9].Text;
            dlg.DatasetPath            = item.SubItems[10].Text;
            
            dlg.ShowDialog();
         }
      }

      private void buttonDetail_Click(object sender, EventArgs e)
      {
         ShowDetails();
      }

      private void listViewEventLog_DoubleClick(object sender, EventArgs e)
      {
         ShowDetails();
      }

      private void UpdateSettings()
      {
         ConfigurationLoggingSession.ServerDirectory = ServiceDirectory;

         try
         {
            ConfigurationLoggingSession.WriteSettings(checkBoxEnableLogging.Checked, checkBoxLogDatasets.Checked);
            if (ActiveService != null && ActiveService.Status == System.ServiceProcess.ServiceControllerStatus.Running)
            {
               ActiveService.SendMessage(MyDicomLoggingChannel.SettingsChanged);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void checkBoxEnableLogging_CheckedChanged(object sender, EventArgs e)
      {
         UpdateSettings();
      }

      private void checkBoxLogDatasets_CheckedChanged(object sender, EventArgs e)
      {
         UpdateSettings();
      }


   }

   public class EventLogItem
   {

      public EventLogItem(int eventId, string datasetPath)
      {
         _eventId = eventId;
         _datasetPath = datasetPath;
      }

      private int _eventId;

      public int EventId
      {
         get { return _eventId; }
         set { _eventId = value; }
      }
      private string _datasetPath;

      public string DatasetPath
      {
         get { return _datasetPath; }
         set { _datasetPath = value; }
      }
   }
}
