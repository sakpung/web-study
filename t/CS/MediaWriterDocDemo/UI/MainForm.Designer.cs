using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWriterDemo
{
   partial class MainForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._txtVolumeName = new System.Windows.Forms.TextBox();
         this._txtInputPath = new System.Windows.Forms.TextBox();
         this._txtISOOutput = new System.Windows.Forms.TextBox();
         this._cmbSpeed = new System.Windows.Forms.ComboBox();
         this._cmbDrive = new System.Windows.Forms.ComboBox();
         this._chkAutoEject = new System.Windows.Forms.CheckBox();
         this._lblVolumeName = new System.Windows.Forms.Label();
         this._lblInputPath = new System.Windows.Forms.Label();
         this._lblProgress = new System.Windows.Forms.Label();
         this._lblDiskCapacity = new System.Windows.Forms.Label();
         this._lblDrive = new System.Windows.Forms.Label();
         this._lblDiscType = new System.Windows.Forms.Label();
         this._lblISOOutput = new System.Windows.Forms.Label();
         this._lblWritingSpeed = new System.Windows.Forms.Label();
         this._btnBrowseDVDFolder = new System.Windows.Forms.Button();
         this._btnBrowseISOFile = new System.Windows.Forms.Button();
         this._btnBrowseISOOutputFile = new System.Windows.Forms.Button();
         this.progressBar1 = new System.Windows.Forms.ProgressBar();
         this._btnEject = new System.Windows.Forms.Button();
         this._btnLoad = new System.Windows.Forms.Button();
         this._btnErase = new System.Windows.Forms.Button();
         this._btnTest = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnWrite = new System.Windows.Forms.Button();
         this._lblDiscTypeStatic = new System.Windows.Forms.Label();
         this._lblDiskCapacityStatic = new System.Windows.Forms.Label();
         this._lblProgressStatic = new System.Windows.Forms.Label();
         this._chkReserveCDTrackOnWriting = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // _txtVolumeName
         // 
         this._txtVolumeName.Location = new System.Drawing.Point(133, 11);
         this._txtVolumeName.Name = "_txtVolumeName";
         this._txtVolumeName.Size = new System.Drawing.Size(96, 20);
         this._txtVolumeName.TabIndex = 0;
         // 
         // _txtInputPath
         // 
         this._txtInputPath.Location = new System.Drawing.Point(133, 48);
         this._txtInputPath.Name = "_txtInputPath";
         this._txtInputPath.Size = new System.Drawing.Size(203, 20);
         this._txtInputPath.TabIndex = 1;
         // 
         // _txtISOOutput
         // 
         this._txtISOOutput.Location = new System.Drawing.Point(133, 199);
         this._txtISOOutput.Name = "_txtISOOutput";
         this._txtISOOutput.Size = new System.Drawing.Size(203, 20);
         this._txtISOOutput.TabIndex = 2;
         this._txtISOOutput.TextChanged += new System.EventHandler(this._txtISOOutput_TextChanged);
         // 
         // _cmbSpeed
         // 
         this._cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbSpeed.Location = new System.Drawing.Point(133, 116);
         this._cmbSpeed.Name = "_cmbSpeed";
         this._cmbSpeed.Size = new System.Drawing.Size(203, 21);
         this._cmbSpeed.TabIndex = 3;
         this._cmbSpeed.SelectedIndexChanged += new System.EventHandler(this._cmbSpeed_SelectedIndexChanged);
         // 
         // _cmbDrive
         // 
         this._cmbDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbDrive.Location = new System.Drawing.Point(133, 88);
         this._cmbDrive.Name = "_cmbDrive";
         this._cmbDrive.Size = new System.Drawing.Size(203, 21);
         this._cmbDrive.TabIndex = 4;
         this._cmbDrive.SelectedIndexChanged += new System.EventHandler(this._cmbDrive_SelectedIndexChanged);
         // 
         // _chkAutoEject
         // 
         this._chkAutoEject.Location = new System.Drawing.Point(133, 149);
         this._chkAutoEject.Name = "_chkAutoEject";
         this._chkAutoEject.Size = new System.Drawing.Size(96, 16);
         this._chkAutoEject.TabIndex = 5;
         this._chkAutoEject.Text = "Auto Eject";
         this._chkAutoEject.CheckedChanged += new System.EventHandler(this._chkAutoEject_CheckedChanged);
         // 
         // _lblVolumeName
         // 
         this._lblVolumeName.AutoSize = true;
         this._lblVolumeName.Location = new System.Drawing.Point(8, 16);
         this._lblVolumeName.Name = "_lblVolumeName";
         this._lblVolumeName.Size = new System.Drawing.Size(76, 13);
         this._lblVolumeName.TabIndex = 6;
         this._lblVolumeName.Text = "Volume Name:";
         // 
         // _lblInputPath
         // 
         this._lblInputPath.AutoSize = true;
         this._lblInputPath.Location = new System.Drawing.Point(8, 52);
         this._lblInputPath.Name = "_lblInputPath";
         this._lblInputPath.Size = new System.Drawing.Size(119, 13);
         this._lblInputPath.TabIndex = 7;
         this._lblInputPath.Text = "Image Folder / ISO File:";
         // 
         // _lblProgress
         // 
         this._lblProgress.Location = new System.Drawing.Point(128, 293);
         this._lblProgress.Name = "_lblProgress";
         this._lblProgress.Size = new System.Drawing.Size(208, 16);
         this._lblProgress.TabIndex = 8;
         // 
         // _lblDiskCapacity
         // 
         this._lblDiskCapacity.Location = new System.Drawing.Point(128, 268);
         this._lblDiskCapacity.Name = "_lblDiskCapacity";
         this._lblDiskCapacity.Size = new System.Drawing.Size(208, 16);
         this._lblDiskCapacity.TabIndex = 9;
         // 
         // _lblDrive
         // 
         this._lblDrive.AutoSize = true;
         this._lblDrive.Location = new System.Drawing.Point(8, 96);
         this._lblDrive.Name = "_lblDrive";
         this._lblDrive.Size = new System.Drawing.Size(35, 13);
         this._lblDrive.TabIndex = 10;
         this._lblDrive.Text = "Drive:";
         // 
         // _lblDiscType
         // 
         this._lblDiscType.Location = new System.Drawing.Point(128, 243);
         this._lblDiscType.Name = "_lblDiscType";
         this._lblDiscType.Size = new System.Drawing.Size(144, 18);
         this._lblDiscType.TabIndex = 11;
         // 
         // _lblISOOutput
         // 
         this._lblISOOutput.AutoSize = true;
         this._lblISOOutput.Location = new System.Drawing.Point(8, 207);
         this._lblISOOutput.Name = "_lblISOOutput";
         this._lblISOOutput.Size = new System.Drawing.Size(82, 13);
         this._lblISOOutput.TabIndex = 12;
         this._lblISOOutput.Text = "ISO Output File:";
         // 
         // _lblWritingSpeed
         // 
         this._lblWritingSpeed.AutoSize = true;
         this._lblWritingSpeed.Location = new System.Drawing.Point(8, 124);
         this._lblWritingSpeed.Name = "_lblWritingSpeed";
         this._lblWritingSpeed.Size = new System.Drawing.Size(77, 13);
         this._lblWritingSpeed.TabIndex = 13;
         this._lblWritingSpeed.Text = "Writing Speed:";
         // 
         // _btnBrowseDVDFolder
         // 
         this._btnBrowseDVDFolder.Location = new System.Drawing.Point(344, 48);
         this._btnBrowseDVDFolder.Name = "_btnBrowseDVDFolder";
         this._btnBrowseDVDFolder.Size = new System.Drawing.Size(88, 20);
         this._btnBrowseDVDFolder.TabIndex = 14;
         this._btnBrowseDVDFolder.Text = "Browse Folders";
         this._btnBrowseDVDFolder.Click += new System.EventHandler(this._btnBrowseDVDFolder_Click);
         // 
         // _btnBrowseISOFile
         // 
         this._btnBrowseISOFile.Location = new System.Drawing.Point(344, 72);
         this._btnBrowseISOFile.Name = "_btnBrowseISOFile";
         this._btnBrowseISOFile.Size = new System.Drawing.Size(88, 20);
         this._btnBrowseISOFile.TabIndex = 15;
         this._btnBrowseISOFile.Text = "Browse ISO";
         this._btnBrowseISOFile.Click += new System.EventHandler(this._btnBrosweISOFile_Click);
         // 
         // _btnBrowseISOOutputFile
         // 
         this._btnBrowseISOOutputFile.Location = new System.Drawing.Point(344, 199);
         this._btnBrowseISOOutputFile.Name = "_btnBrowseISOOutputFile";
         this._btnBrowseISOOutputFile.Size = new System.Drawing.Size(88, 20);
         this._btnBrowseISOOutputFile.TabIndex = 16;
         this._btnBrowseISOOutputFile.Text = "Browse ISO";
         this._btnBrowseISOOutputFile.Click += new System.EventHandler(this._btnBrowseISOOutputFile_Click);
         // 
         // progressBar1
         // 
         this.progressBar1.Location = new System.Drawing.Point(11, 334);
         this.progressBar1.Name = "progressBar1";
         this.progressBar1.Size = new System.Drawing.Size(421, 16);
         this.progressBar1.TabIndex = 17;
         // 
         // _btnEject
         // 
         this._btnEject.Location = new System.Drawing.Point(8, 358);
         this._btnEject.Name = "_btnEject";
         this._btnEject.Size = new System.Drawing.Size(64, 20);
         this._btnEject.TabIndex = 18;
         this._btnEject.Text = "Eject";
         this._btnEject.Click += new System.EventHandler(this._btnEject_Click);
         // 
         // _btnLoad
         // 
         this._btnLoad.Location = new System.Drawing.Point(80, 358);
         this._btnLoad.Name = "_btnLoad";
         this._btnLoad.Size = new System.Drawing.Size(64, 20);
         this._btnLoad.TabIndex = 19;
         this._btnLoad.Text = "Load";
         this._btnLoad.Click += new System.EventHandler(this._btnLoad_Click);
         // 
         // _btnErase
         // 
         this._btnErase.Location = new System.Drawing.Point(152, 358);
         this._btnErase.Name = "_btnErase";
         this._btnErase.Size = new System.Drawing.Size(64, 20);
         this._btnErase.TabIndex = 20;
         this._btnErase.Text = "Erase";
         this._btnErase.Click += new System.EventHandler(this._btnErase_Click);
         // 
         // _btnTest
         // 
         this._btnTest.Location = new System.Drawing.Point(224, 358);
         this._btnTest.Name = "_btnTest";
         this._btnTest.Size = new System.Drawing.Size(64, 20);
         this._btnTest.TabIndex = 21;
         this._btnTest.Text = "Test";
         this._btnTest.Click += new System.EventHandler(this._btnTest_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.Location = new System.Drawing.Point(368, 358);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(64, 20);
         this._btnCancel.TabIndex = 23;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnWrite
         // 
         this._btnWrite.Location = new System.Drawing.Point(296, 358);
         this._btnWrite.Name = "_btnWrite";
         this._btnWrite.Size = new System.Drawing.Size(64, 20);
         this._btnWrite.TabIndex = 22;
         this._btnWrite.Text = "Write";
         this._btnWrite.Click += new System.EventHandler(this._btnWrite_Click);
         // 
         // _lblDiscTypeStatic
         // 
         this._lblDiscTypeStatic.AutoSize = true;
         this._lblDiscTypeStatic.Location = new System.Drawing.Point(8, 243);
         this._lblDiscTypeStatic.Name = "_lblDiscTypeStatic";
         this._lblDiscTypeStatic.Size = new System.Drawing.Size(58, 13);
         this._lblDiscTypeStatic.TabIndex = 26;
         this._lblDiscTypeStatic.Text = "Disc Type:";
         // 
         // _lblDiskCapacityStatic
         // 
         this._lblDiskCapacityStatic.AutoSize = true;
         this._lblDiskCapacityStatic.Location = new System.Drawing.Point(8, 268);
         this._lblDiskCapacityStatic.Name = "_lblDiskCapacityStatic";
         this._lblDiskCapacityStatic.Size = new System.Drawing.Size(75, 13);
         this._lblDiskCapacityStatic.TabIndex = 25;
         this._lblDiskCapacityStatic.Text = "Disc Capacity:";
         // 
         // _lblProgressStatic
         // 
         this._lblProgressStatic.AutoSize = true;
         this._lblProgressStatic.Location = new System.Drawing.Point(8, 293);
         this._lblProgressStatic.Name = "_lblProgressStatic";
         this._lblProgressStatic.Size = new System.Drawing.Size(51, 13);
         this._lblProgressStatic.TabIndex = 24;
         this._lblProgressStatic.Text = "Progress:";
         // 
         // _chkReserveCDTrackOnWriting
         // 
         this._chkReserveCDTrackOnWriting.Location = new System.Drawing.Point(133, 171);
         this._chkReserveCDTrackOnWriting.Name = "_chkReserveCDTrackOnWriting";
         this._chkReserveCDTrackOnWriting.Size = new System.Drawing.Size(170, 18);
         this._chkReserveCDTrackOnWriting.TabIndex = 27;
         this._chkReserveCDTrackOnWriting.Text = "Reserve CD Track On Writing";
         this._chkReserveCDTrackOnWriting.CheckedChanged += new System.EventHandler(this._chkReserveCDTrackOnWriting_CheckedChanged);
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(440, 385);
         this.Controls.Add(this._chkReserveCDTrackOnWriting);
         this.Controls.Add(this._lblDiscTypeStatic);
         this.Controls.Add(this._lblDiskCapacityStatic);
         this.Controls.Add(this._lblProgressStatic);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnWrite);
         this.Controls.Add(this._btnTest);
         this.Controls.Add(this._btnErase);
         this.Controls.Add(this._btnLoad);
         this.Controls.Add(this._btnEject);
         this.Controls.Add(this.progressBar1);
         this.Controls.Add(this._btnBrowseISOOutputFile);
         this.Controls.Add(this._btnBrowseISOFile);
         this.Controls.Add(this._btnBrowseDVDFolder);
         this.Controls.Add(this._lblWritingSpeed);
         this.Controls.Add(this._lblISOOutput);
         this.Controls.Add(this._lblDiscType);
         this.Controls.Add(this._lblDrive);
         this.Controls.Add(this._lblDiskCapacity);
         this.Controls.Add(this._lblProgress);
         this.Controls.Add(this._lblInputPath);
         this.Controls.Add(this._lblVolumeName);
         this.Controls.Add(this._chkAutoEject);
         this.Controls.Add(this._cmbDrive);
         this.Controls.Add(this._cmbSpeed);
         this.Controls.Add(this._txtISOOutput);
         this.Controls.Add(this._txtInputPath);
         this.Controls.Add(this._txtVolumeName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.Text = "Image Disk Burner";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox _txtVolumeName;
      private System.Windows.Forms.TextBox _txtInputPath;
      private System.Windows.Forms.TextBox _txtISOOutput;
      private System.Windows.Forms.ComboBox _cmbSpeed;
      private System.Windows.Forms.ComboBox _cmbDrive;
      private System.Windows.Forms.CheckBox _chkAutoEject;
      private System.Windows.Forms.Label _lblVolumeName;
      private System.Windows.Forms.Label _lblInputPath;
      private System.Windows.Forms.Label _lblProgress;
      private System.Windows.Forms.Label _lblDiskCapacity;
      private System.Windows.Forms.Label _lblDrive;
      private System.Windows.Forms.Label _lblDiscType;
      private System.Windows.Forms.Label _lblISOOutput;
      private System.Windows.Forms.Label _lblWritingSpeed;
      private System.Windows.Forms.Button _btnBrowseDVDFolder;
      private System.Windows.Forms.ProgressBar progressBar1;
      private System.Windows.Forms.Button _btnEject;
      private System.Windows.Forms.Button _btnLoad;
      private System.Windows.Forms.Button _btnErase;
      private System.Windows.Forms.Button _btnTest;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnWrite;
      private System.Windows.Forms.Button _btnBrowseISOFile;
      private System.Windows.Forms.Button _btnBrowseISOOutputFile;
      private System.Windows.Forms.Label _lblDiscTypeStatic;
      private System.Windows.Forms.Label _lblDiskCapacityStatic;
      private System.Windows.Forms.Label _lblProgressStatic;
      private System.Windows.Forms.CheckBox _chkReserveCDTrackOnWriting;
   }
}


