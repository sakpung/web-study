// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Leadtools;
using Leadtools.MediaWriter;
using Leadtools.Demos;
using System.Threading;

namespace MediaWriterDemo
{
   public partial class MainForm : Form
	{
      public MainForm()
		{
         InitializeComponent();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
#if LEADTOOLS_V175_OR_LATER
         if (!Support.SetLicense())
            return;
#else
         Support.Unlock(false);
#endif // #if LEADTOOLS_V175_OR_LATER

         if (RasterSupport.IsLocked(RasterSupportType.MediaWriter))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.MediaWriter.ToString()), "Warning");
            return;
         }

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
		}

      MediaWriter gLMediaWriter;
      MediaWriterDrive gBurnerDrive;

      private string _openInitialPath = string.Empty;

      private bool CheckInputPath(String sInputPath)
      {
         FileAttributes attr;
         try
         {
            attr = File.GetAttributes(sInputPath);
         }            
         catch
         {
            MessageBox.Show("The specified file or folder does not exist. Please select valid file or folder.", "Warning", MessageBoxButtons.OK);
            return false;
         }
         if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
         {
            try
            {
               if (Directory.GetFiles(sInputPath, "*", SearchOption.AllDirectories).Length < 1)
               {
                  MessageBox.Show("The specified folder does not contain any files or folders. Please select another folder.", "Warning", MessageBoxButtons.OK);
                  return false;
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show("An error was encountered while checking the specified folder. Please check your folder and try again.  Error details:\n\n" + ex.Message , 
                           "Warning", MessageBoxButtons.OK);
               return false;
            }               
         }
         return true;
      }

		private void _btnBrosweISOFile_Click(object sender, System.EventArgs e)
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog();

				ofd.Title = "Choose ISO File";
				ofd.Filter = "ISO Files (*.iso)|*.iso|" + 
					"All Files (*.*)|*.*";
            ofd.InitialDirectory = _openInitialPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
               _openInitialPath = Path.GetDirectoryName(ofd.FileName);
               _txtInputPath.Text = ofd.FileName;
            }
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
         EnableCtrls();
		}

		private void _btnBrowseDVDFolder_Click(object sender, System.EventArgs e)
		{
			try
			{
				FolderBrowserDialog fbd = new FolderBrowserDialog();

				if (fbd.ShowDialog() == DialogResult.OK)
					_txtInputPath.Text = fbd.SelectedPath;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
         EnableCtrls();
		}

		private void _btnBrowseISOOutputFile_Click(object sender, System.EventArgs e)
		{
			try
			{
				SaveFileDialog sfd = new SaveFileDialog();

				sfd.Title = "Choose ISO File";
				sfd.Filter = "ISO Files (*.iso)|*.iso|" + 
					"All Files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
               _cmbDrive.SelectedIndex = 0;
               _txtISOOutput.Text = sfd.FileName;
            }
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
         EnableCtrls();
		}

      private void _btnCancel_Click(object sender, System.EventArgs e)
		{
			try
			{
            if (gBurnerDrive.State != MediaWriterState.StateIdle)
				{
					if (MessageBox.Show("A disc operation is currently in progress. Are you sure you would like to cancel?", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
						return;

               gBurnerDrive.Cancel();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
         EnableCtrls();
		}

		private void _btnEject_Click(object sender, System.EventArgs e)
		{
			_lblProgress.Text = "";
			progressBar1.Value = 0;

			try
			{
            gBurnerDrive.EjectDisc();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " occurred while ejecting. Operation canceled.");
			} 
			EnableCtrls();
		}

      private void _btnErase_Click(object sender, System.EventArgs e)
		{
			_lblProgress.Text = "";
			progressBar1.Value = 0;

			try
			{
            gBurnerDrive.EraseDisc();
            EnableCtrls();
            while (gBurnerDrive.State == MediaWriterState.StateErasing)
            {
               Application.DoEvents();
            }
         }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " occurred while starting erase. Operation canceled.");
			}
			EnableCtrls();
		}

		private void _btnTest_Click(object sender, System.EventArgs e)
		{
         MediaWriterDisc testDisc = gBurnerDrive.CreateDisc();

         _lblProgress.Text = "";
			progressBar1.Value = 0;

			try
			{
            if (!CheckInputPath(_txtInputPath.Text))
               return;

            testDisc.SourcePathName = _txtInputPath.Text;
            testDisc.OutputPathName = _txtISOOutput.Text;
            testDisc.VolumeName = _txtVolumeName.Text;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " occurred while setting the source. Operation canceled.");
				EnableCtrls();
				return;
			}

			try
			{
            gBurnerDrive.TestBurnDisc(testDisc);

            EnableCtrls();
            while (gBurnerDrive.State == MediaWriterState.StateTestWriting)
            {
               Application.DoEvents();
            }
         }

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " occurred while starting write. Operation canceled.");
			}
			EnableCtrls();
		}

		private void _btnWrite_Click(object sender, System.EventArgs e)
		{
         MediaWriterDisc burnDisc = gBurnerDrive.CreateDisc();
         progressBar1.Value = 0;

			try
			{
            if (!CheckInputPath(_txtInputPath.Text))
               return;
            burnDisc.SourcePathName = _txtInputPath.Text;
            burnDisc.VolumeName = _txtVolumeName.Text;
         }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " occurred while setting the source. Operation canceled.");
				EnableCtrls();
				return;
			}
         
			try
			{
            if (String.Empty != _txtISOOutput.Text)
            {
               burnDisc.OutputPathName = _txtISOOutput.Text;
               gBurnerDrive.CreateISO(burnDisc);
            }
            else
            {
               gBurnerDrive.BurnDisc(burnDisc);
            }
            EnableCtrls();
            while (gBurnerDrive.State == MediaWriterState.StateWriting)
            {
               Application.DoEvents();
            }
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " occurred while starting write. Operation canceled.");
			}
			EnableCtrls();
		}

		private void _chkAutoEject_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
            gBurnerDrive.AutoEject = _chkAutoEject.Checked;
			}
			catch (Exception ex)
			{
            _chkAutoEject.Checked = gBurnerDrive.AutoEject;
				MessageBox.Show(ex.Message + " occurred while setting auto eject. Operation canceled.");
			}
		}

      public void UpdateProgress(Object sender, EventArgs evtargs)
      {
         MediaWriterProgressEventArgs mevtargs = evtargs as MediaWriterProgressEventArgs;
         if (null != mevtargs)
         {
            progressBar1.Value = mevtargs.Complete;
            _lblProgress.Text = mevtargs.Description;
         }
      }

      void gBurnerDrive_OnProgress(object sender, MediaWriterProgressEventArgs e)
      {
         if (this.InvokeRequired)
         {
            this.Invoke(new EventHandler(UpdateProgress),
               new object[] { sender, e });
         }
         else
            UpdateProgress(sender, e);
      }

      private void UpdateDeviceEvent(Object sender, EventArgs evtargs)
      {
         MediaWriterDevNotifyEventArgs mevtargs = evtargs as MediaWriterDevNotifyEventArgs;
         if (null != mevtargs)
         {
            if (mevtargs.State == MediaWriterDeviceState.StateLoaded)
            {
               // new disc was inserted in current drive
            }
            else
            if (mevtargs.State == MediaWriterDeviceState.StateEmpty)
            {
               // disc was ejected from current drive
            }
            else
            if (mevtargs.State == MediaWriterDeviceState.StateUnknown)
            {
               // disc was ejected from current drive
               BuildWriteSpeedList();
            }
         }
         EnableCtrls();
      }

      private void gBurnerDrive_OnDeviceEvent(Object sender, EventArgs evtargs)
      {
         if (this.InvokeRequired)
         {
            this.Invoke(new EventHandler(UpdateDeviceEvent),
               new object[] { sender, evtargs });
         }
         else
            UpdateDeviceEvent(sender, evtargs);
      }

      private void _cmbDrive_SelectedIndexChanged(object sender, System.EventArgs e)
		{
         int lCurrent = gLMediaWriter.CurrentDriveNumber;
         if (gBurnerDrive != null && gBurnerDrive.State != MediaWriterState.StateIdle)
            return;

			try
			{
            gLMediaWriter.CurrentDriveNumber = _cmbDrive.SelectedIndex - 1;
            if (gBurnerDrive != null)
            {
               gBurnerDrive.OnProgress -= gBurnerDrive_OnProgress;
               gBurnerDrive.OnDeviceEvent -= gBurnerDrive_OnDeviceEvent;
            }

            gBurnerDrive = gLMediaWriter.CurrentDrive;
            gBurnerDrive.OnProgress += gBurnerDrive_OnProgress;
            gBurnerDrive.OnDeviceEvent += gBurnerDrive_OnDeviceEvent;

            BuildWriteSpeedList();

            if (_cmbDrive.SelectedIndex > 0)
               _txtISOOutput.Text = string.Empty;

            _lblProgress.Text = "";
            progressBar1.Value = 0;
         }
			catch (Exception ex)
			{
				_cmbDrive.SelectedIndex = lCurrent + 1;
				BuildWriteSpeedList();
				MessageBox.Show(ex.Message + " occurred while selecting drive. Operation canceled.");
			}
         EnableCtrls();
		}

		private void _btnLoad_Click(object sender, System.EventArgs e)
		{
			_lblProgress.Text = "";
			progressBar1.Value = 0;

			try
			{
            gBurnerDrive.LoadDisc();
            //Sleep to allow control to update with drive's status (open or closed)
            Thread.Sleep(2000);
         }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " occurred while loading. Operation canceled.");
			}
			EnableCtrls();
		}

		private void BuildDriveList()
		{
			try
			{
				_cmbDrive.Items.Clear();
            foreach (MediaWriterDrive drive in gLMediaWriter.Drives)
            {
               _cmbDrive.Items.Add(drive.Name);
            }
            _cmbDrive.SelectedIndex = gLMediaWriter.CurrentDriveNumber + 1;
			}
			catch(Exception ex)
			{
            MessageBox.Show(ex.Message);
         }
		}

		private void BuildWriteSpeedList()
		{
			try
			{
            _cmbSpeed.Items.Clear();

            if (_cmbDrive.SelectedIndex > 0 
               && gBurnerDrive != null && gBurnerDrive.Speeds != null)
				{
               foreach (MediaWriterSpeed speed in gBurnerDrive.Speeds)
                  _cmbSpeed.Items.Add(speed.Name);

               if (_cmbSpeed.Items.Count > 0 && gBurnerDrive.CurrentSpeedIndex < _cmbSpeed.Items.Count)
                  _cmbSpeed.SelectedIndex = gBurnerDrive.CurrentSpeedIndex;	
            }
			}
			catch(Exception ex)
			{
            MessageBox.Show(ex.Message);
			}
		}

		private void EnableCtrls()
		{
			bool bEraseable;
			bool bWriteable;
			bool bTestwriteable;
			bool bEjectable;
			bool bLoadable;
         bool bIdle;
			int lDrive;

         bIdle = (gBurnerDrive.State == MediaWriterState.StateIdle);
         bEraseable = gBurnerDrive.Eraseable;
         bWriteable = gBurnerDrive.Writeable;
         bTestwriteable = gBurnerDrive.TestWriteable;
         bEjectable = gBurnerDrive.Ejectable;
         bLoadable = gBurnerDrive.Loadable;

         lDrive = gBurnerDrive.DriveNumber;

			//if we have not specified a drive but have enabled an output iso file then enable write
         if (lDrive < 0 && bIdle 
            && !String.IsNullOrEmpty(_txtISOOutput.Text)) 
		 {
            String sPath = _txtISOOutput.Text;
            sPath = Path.GetDirectoryName(sPath);
            if (Directory.Exists(sPath))
            {
               bWriteable = true;
               bTestwriteable = true;
            }
		 }

         _btnWrite.Enabled = bIdle && bWriteable ? true : false;
         _btnErase.Enabled = bIdle && bEraseable ? true : false;

         _cmbDrive.Enabled = bIdle ? true : false; ;
         _txtVolumeName.Enabled = bIdle ? true : false; ;
         _btnEject.Enabled = bIdle && bEjectable ? true : false;
         _btnLoad.Enabled = bIdle && bLoadable ? true : false;
         _chkAutoEject.Enabled = bIdle ? true : false;
         _btnBrowseDVDFolder.Enabled = bIdle ? true : false;
         _txtISOOutput.Enabled = bIdle ? true : false;
         _btnBrowseISOOutputFile.Enabled = bIdle ? true : false;
         _txtInputPath.Enabled = bIdle ? true : false;
         _btnBrowseISOFile.Enabled = bIdle ? true : false;
         _btnTest.Enabled = bIdle && bTestwriteable ? true : false;
         _cmbSpeed.Enabled = bIdle ? true : false;

         bool bcd = false;
         if (null != gBurnerDrive.CurrentDiscType)
         {
            bcd = gBurnerDrive.CurrentDiscType.Type == MediaWriterDiscTypeCode.DiscTypeCDR ||
               gBurnerDrive.CurrentDiscType.Type == MediaWriterDiscTypeCode.DiscTypeCDROM ||
               gBurnerDrive.CurrentDiscType.Type == MediaWriterDiscTypeCode.DiscTypeCDRW;
         }
         _chkReserveCDTrackOnWriting.Enabled = bIdle && bcd ? true : false;

         try
         {
            if (bIdle)
            {
               double lCapacity;
               double lbytes;
               string sText;
               lCapacity = gBurnerDrive.DiscCapacity;
               lbytes = lCapacity * 2048;
               if (lbytes >= 0x40000000)
               {
                  sText = Convert.ToString(lbytes / 0x40000000);
                  if (sText != string.Empty)
                     sText = (sText.Length > 5 ? sText.Substring(0, 5) : sText) + " GB";
               }
               else if (lbytes >= 0x100000)
               {
                  sText = Convert.ToString(lbytes / 0x100000);
                  if (sText != string.Empty)
                     sText = (sText.Length > 4 ? sText.Substring(0, 4) : sText) + " MB"; 
               }
               else
               {
                  sText = Convert.ToString(lbytes / 0x400);
                  if (sText != string.Empty)
                     sText = (sText.Length > 3 ? sText.Substring(0, 3) : sText) + " KB";
               }
               _lblDiskCapacity.Text = sText;
            }
         }
         catch
         {
            _lblDiskCapacity.Text = "";
         }

         if (null != gBurnerDrive.CurrentDiscType)
            _lblDiscType.Text = gBurnerDrive.CurrentDiscType.Name;
         else
            _lblDiscType.Text = string.Empty;

		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
            if (gBurnerDrive.State != MediaWriterState.StateIdle)
				{
					if (MessageBox.Show("A disc operation is currently in progress. Are you sure you would like to exit?", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
					{
                  e.Cancel = true;
                  gBurnerDrive.Cancel();
                  return;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

      private void _cmbSpeed_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (gBurnerDrive != null)
            gBurnerDrive.CurrentSpeedIndex = _cmbSpeed.SelectedIndex;
      }

      private void _txtISOOutput_TextChanged(object sender, EventArgs e)
      {
         EnableCtrls();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         try
         {
            gLMediaWriter = new MediaWriter();
         }
         catch (Exception ex)
         {
         }

         progressBar1.Minimum = 0;
         progressBar1.Maximum = 10000;

         BuildDriveList();
         BuildWriteSpeedList();
         gBurnerDrive = gLMediaWriter.CurrentDrive;

         _txtVolumeName.Text = "LEAD-IMAGES";
         _txtInputPath.Text = @"C:\InputFiles";
         _chkAutoEject.Checked = gBurnerDrive.AutoEject;
         _chkReserveCDTrackOnWriting.Checked = gBurnerDrive.ReserveCDTrackOnWriting;

         EnableCtrls();
      }

      private void _chkReserveCDTrackOnWriting_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            gBurnerDrive.ReserveCDTrackOnWriting = _chkReserveCDTrackOnWriting.Checked;
         }
         catch (Exception ex)
         {
            _chkReserveCDTrackOnWriting.Checked = gBurnerDrive.ReserveCDTrackOnWriting;
            MessageBox.Show(ex.Message + " occurred while setting reserve cd track on writing. Operation canceled.");
         }
      }
	}
}
