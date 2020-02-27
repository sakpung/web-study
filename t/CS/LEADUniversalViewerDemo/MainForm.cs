// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Resources;
using System.Diagnostics;
using System.Reflection;
using LEADUniversalViewer.Properties;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Controls;
using Leadtools.Multimedia;
using Leadtools.Drawing;
using Leadtools.Demos.Dialogs;

namespace LEADUniversalViewer
{
   public partial class MainForm : Form
   {
      RasterCodecs _codecs = null;
      ImageViewerPanZoomInteractiveMode _panZoomInteractiveMode = null;
      int _currentPageNum = 1;
      string _fileName = "";
      string _logFileName = "";
      string _folderName = "";
      //Flag to cancel the browsing process when the user presses Escape button
      bool _cancelBrowse = false;
      //Recent Folders Queue
      Queue _mrulist = new Queue();
      //Load File Writer
      System.IO.StreamWriter _logFileWriter = null;
      //Loading resolution dialog
      LoadingResolutionDialog _loadingResolutionDialog = null;
      //
      TableLayoutPanelCellPosition _tempImageViewerCellInTableLayout;
      //
      Panel _fullScreenPanel = new Panel();
      //
      FormBorderStyle _mainFormBorderDefaultStyle;
      //
      Color _imageViewerDefaultBackColor;
      //
      private Leadtools.Multimedia.PlayCtrl _playCtrl1;
      //
      bool _pauseAnimation;
      //
      RasterImage _animatedImage;
      //
      bool _isPlayingGif = false;

      public ImageViewerPanZoomInteractiveMode PanZoomInteractiveMode
      {
         get
         {
            return _panZoomInteractiveMode;
         }
         set
         {
            value = _panZoomInteractiveMode;
         }
      }

      public MainForm()
      {
         InitializeComponent();

         //Set LEADTOOLS license before deploying your application
         if (!Support.SetLicense())
            return;
         _codecs = new RasterCodecs();

         _panZoomInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         _panZoomInteractiveMode.AutoItemMode = ImageViewerAutoItemMode.AutoSet;
         _panZoomInteractiveMode.DoubleTapSizeMode = _imageViewer1.SizeMode;
         _panZoomInteractiveMode.EnablePan = true;
         _panZoomInteractiveMode.EnablePinchZoom = false;
         _panZoomInteractiveMode.EnableZoom = false;

         _tableLayoutPanel1.SetRowSpan(_filesNamesListBox, 2);

         _trkPosition.SetRange(0, 10000);
         _loadingResolutionDialog = new LoadingResolutionDialog();
         _tempImageViewerCellInTableLayout = new TableLayoutPanelCellPosition();
         _fullScreenPanel.Visible = false;
      }

      private void MainForm_KeyDown(object sender, KeyEventArgs e)
      {
         if ((e.KeyCode == Keys.Escape))
         {
            if (_cancelBrowse != true && _fullScreenPanel.Visible != true)
            {
               _cancelBrowse = true;
               MessageBox.Show("Browsing has been canceled");
            }

            if (_isPlayingGif)
            {
               _pauseAnimation = true;
            }

            ExitFullScreenMode(_fullScreenPanel.Visible);
         }
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         try
         {
            this._playCtrl1 = new Leadtools.Multimedia.PlayCtrl();
            ((System.ComponentModel.ISupportInitialize)(this._playCtrl1)).BeginInit();
            // playCtrl1
            this._playCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._playCtrl1.Location = new System.Drawing.Point(0, 0);
            this._playCtrl1.Name = "playCtrl1";
            this._playCtrl1.OcxState = null;
            this._playCtrl1.Size = new System.Drawing.Size(1046, 713);
            this._playCtrl1.SourceFile = null;
            this._playCtrl1.TabIndex = 0;
            this._playCtrl1.Text = "playCtrl1";
            this._playCtrl1.DoubleClick += new System.EventHandler(this.playCtrl1_DoubleClick);
            this._playCtrl1.TrackingPositionChanged += new Leadtools.Multimedia.TrackingPositionChangedEventHandler(this.playCtrl1_TrackingPositionChanged);
            ((System.ComponentModel.ISupportInitialize)(this._playCtrl1)).EndInit();

            this._playerPanel.Controls.Add(this._playCtrl1);
            this._playerPanel.Controls.Add(this._imageViewer1);

            _imageViewer1.Visible = _playCtrl1.Visible = false;

            this.MaximumSize = this.Size;
            this.MinimumSize = new System.Drawing.Size(this.Size.Width - 70, this.Size.Height - 10);

            _pauseAnimation = false;

            _animatedImage = null;
         }
         catch (Exception)
         {
            DialogResult MsgBoxRes = MessageBox.Show(this, "LEADTOOLS Multimedia SDK is not installed. Please download and install it to continue using this demo.\nDo you want to download LEADTOOLS Multimedia SDK?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (MsgBoxRes == System.Windows.Forms.DialogResult.Yes)
               System.Diagnostics.Process.Start("https://www.leadtools.com/downloads?category=mm");
            else
               return;
         }

         this.KeyPreview = true;

         _logFileName = System.Environment.CurrentDirectory + "\\LeadUniversalViewerLog.txt";

         // First line in the Log file
         string strLogStart = "Start logging...\n\n";

         try
         {
            WriteToLogFile(_logFileName, strLogStart);

            //Load the text file that contains the names of the recent folders
            LoadRecentList();

            foreach (string item in _mrulist)
            {
               //populating menu
               ToolStripMenuItem fileRecent = new ToolStripMenuItem(item);
               //Add the files in the selected folder
               fileRecent.MouseUp += new MouseEventHandler(fileRecent_MouseUp);
               //add the menu to "recent" menu
               _recentToolStripMenuItem.DropDownItems.Add(fileRecent);
            }

            string FileDuration = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                            0,
                            0,
                            0,
                            0);

            string FileCurrentPosition = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                            0,
                            0,
                            0,
                            0);

            _lbltrkPosition.Text = string.Format(" {0} / {1}", FileCurrentPosition, FileDuration);

            //Set the default loading resolutions
            _codecs.Options.RasterizeDocument.Load.XResolution = 150;
            _codecs.Options.RasterizeDocument.Load.YResolution = 150;

            InfoDialog UserInfoDialog = new InfoDialog();
            UserInfoDialog.Show(this);
            _mainFormBorderDefaultStyle = this.FormBorderStyle;
            _imageViewerDefaultBackColor = _imageViewer1.BackColor;
         }
         catch (Exception ex)
         {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);
            MethodBase currentMethodName = sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", currentMethodName, ex.Message));
         }
      }

      private void ExitFullScreenMode(bool IsVisible)
      {
         if (IsVisible)
         {
            _imageViewer1.Parent = _playerPanel;
            _tableLayoutPanel1.SetCellPosition(_imageViewer1, _tempImageViewerCellInTableLayout);
            _fullScreenPanel.Dock = DockStyle.None;

            _imageViewer1.Dock = DockStyle.Fill;

            _imageViewer1.Visible = true;

            _tableLayoutPanel1.Show();

            _menuStrip1.Show();

            _imageViewer1.BackColor = _imageViewerDefaultBackColor;

            this.FormBorderStyle = _mainFormBorderDefaultStyle;
            _fullScreenPanel.Visible = false;
         }
      }
      void BtnExitFullScreenMode_MouseClick(object sender, MouseEventArgs e)
      {
         ExitFullScreenMode(_fullScreenPanel.Visible);
      }

      private void trkPosition_Scroll(object sender, System.EventArgs e)
      {
         try
         {
            _playCtrl1.CurrentTrackingPosition = _trkPosition.Value;

            SetSeekingButtonsState();

            TimeSpan t = TimeSpan.FromSeconds(_playCtrl1.Duration);

            string FileDuration = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);

            t = TimeSpan.FromSeconds(_playCtrl1.CurrentPosition);

            string FileCurrentPosition = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);

            _lbltrkPosition.Text = string.Format(" {0} / {1}", FileCurrentPosition, FileDuration);

            _lbltrkPosition.Refresh();
            _trkPosition.Refresh();
         }
         catch (Exception ex)
         {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);
            MethodBase currentMethodName = sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", currentMethodName, ex.Message));
         }
      }

      private string FormatPosition(double ts)
      {
         string h = null;
         string m = null;
         string s = null;
         h = ((int)(ts / 3600)).ToString();
         ts = ts % 3600;
         m = ((int)(ts / 60)).ToString();
         ts = ts % 60;
         s = ts.ToString("00.000");
         if (h.Length < 2)
         {
            h = "0" + h;
         }
         if (m.Length < 2)
         {
            m = "0" + m;
         }
         if (s.Length < 2)
         {
            s = "0" + s;
         }
         return h + ":" + m + ":" + s;
      }

      private void SetSeekingButtonsState()
      {
         PlaySeeking caps = 0;

         caps = _playCtrl1.CheckSeekingCapabilities(PlaySeeking.Forward | PlaySeeking.Backward | PlaySeeking.FrameForward | PlaySeeking.FrameBackward);
         _trkPosition.Enabled = (caps != 0);
      }

      private void ChangePlayerSizeMode()
      {
         //Toggle between normal and fit size modes of the player control
         if (_playCtrl1.VideoWindowSizeMode == Leadtools.Multimedia.SizeMode.Fit)
         {
            _playCtrl1.VideoWindowSizeMode = Leadtools.Multimedia.SizeMode.Normal;
            _imageViewer1.Cursor = Cursors.Hand;
         }
         else
         {
            _playCtrl1.VideoWindowSizeMode = Leadtools.Multimedia.SizeMode.Fit;
            _imageViewer1.Cursor = Cursors.Default;
         }
      }

      private void ChangeViewerSizeMode()
      {
         //Toggle between ActualSize and fit size modes of the imageViewer control
         if (_imageViewer1.SizeMode == ControlSizeMode.Fit)
         {
            _imageViewer1.Zoom(ControlSizeMode.ActualSize, 1, _imageViewer1.DefaultZoomOrigin);
            _imageViewer1.Cursor = Cursors.Hand;
         }
         else
         {
            _imageViewer1.Zoom(ControlSizeMode.Fit, 1, _imageViewer1.DefaultZoomOrigin);
            _imageViewer1.Cursor = Cursors.Default;
         }
      }

      private void imageViewer1_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         //change the imageViewer's size mode when you double click the viewer
         try
         {
            if (_imageViewer1.Image != null)
               ChangeViewerSizeMode();

            _imageViewer1.Refresh();
         }
         catch (Exception ex)
         {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);
            MethodBase currentMethodName = sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", currentMethodName, ex.Message));
         }
      }

      void fileRecent_MouseUp(object sender, MouseEventArgs e)
      {
         string _currentFolder = sender.ToString();
         ToolStripMenuItem _currentToolStripMenu = sender as ToolStripMenuItem;

         _toolTip.IsBalloon = false;

         if (Directory.Exists(_currentFolder))
         {
            //Change the application's Cursor
            Cursor _tempCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            foreach (ToolStripMenuItem _tempStripMenu in _recentToolStripMenuItem.DropDownItems)
               _tempStripMenu.Checked = false;

            _currentToolStripMenu.Checked = true;
            _cancelBrowse = false;

            _menuStrip1.Enabled = false;

            AddFileToList(_currentFolder);
            _cancelBrowse = true;

            _menuStrip1.Enabled = true;

            this.Cursor = _tempCursor;
         }
      }

      private void WriteToLogFile(string LogFileName, string TextToWrite)
      {
         if (_logFileWriter == null)
         {
            _logFileWriter = new System.IO.StreamWriter(_logFileName);
            _logFileWriter.AutoFlush = true;
         }
         else if (System.IO.File.Exists(LogFileName))
            _logFileWriter = new System.IO.StreamWriter(LogFileName, true);

         _logFileWriter.WriteLine(TextToWrite);
         _logFileWriter.Close();
      }

      private void playMoreFilesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            //Browse the folder that contains your images and media files
            using (FolderBrowserDialog _browserDialog = new FolderBrowserDialog())
            {

               if (_browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  _folderName = _browserDialog.SelectedPath;

                  //Change the application's Cursor
                  Cursor _tempCursor = this.Cursor;
                  this.Cursor = Cursors.WaitCursor;

                  _toolTip.IsBalloon = false;
                  _cancelBrowse = false;

                  _menuStrip1.Enabled = false;

                  AddFileToList(_folderName);
                  _cancelBrowse = true;

                  _menuStrip1.Enabled = true;

                  ToolStripMenuItem _fileRecent = new ToolStripMenuItem(_folderName);


                  if (!(_mrulist.Contains(_fileRecent.Text))) //prevent duplication on recent list
                  {
                     while (_mrulist.Count >= 5)
                     {
                        _mrulist.Dequeue();
                     }

                     _mrulist.Enqueue(_folderName);

                     _recentToolStripMenuItem.DropDownItems.Clear();

                     foreach (string _item in _mrulist)
                     {
                        ToolStripMenuItem _itemToAdd = new ToolStripMenuItem(_item);
                        _itemToAdd.MouseUp += new MouseEventHandler(fileRecent_MouseUp);
                        _recentToolStripMenuItem.DropDownItems.Add(_itemToAdd);
                     }

                     _menuStrip1.Refresh();
                  }

                  //Reset the application's Cursor to the default
                  this.Cursor = _tempCursor;
               }
            }
         }
         catch (Exception ex)
         {
            StackTrace _st = new StackTrace();
            StackFrame _sf = _st.GetFrame(0);
            MethodBase _currentMethodName = _sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", _currentMethodName, ex.Message));
         }
      }

      private void AddRasterImageToList(string fileName)
      {
         //try loading the current file
         using (RasterImage TempImage = _codecs.Load(fileName, 1))
         {
            string strShortname = _fileName.Substring(fileName.LastIndexOf("\\"));
            strShortname = strShortname.TrimStart(("\\").ToCharArray());
            //Add the current file to the list-box
            MyListItem ItemToAdd = new MyListItem(fileName, strShortname, 1);//1 - Image File
            _filesNamesListBox.Items.Add(ItemToAdd);
            Invoke((MethodInvoker)delegate { Application.DoEvents(); });
         }
      }

      //Add the valid file names to the list-box
      private void AddFileToList(string selectedFolder)
      {
         try
         {
            //Get all files in the selected folder
            string[] _filePaths = Directory.GetFiles(selectedFolder);

            if (_filePaths.Length == 0)
            {
               MessageBox.Show(string.Format("{0} <{1}>", "No files found in", selectedFolder));
               return;
            }

            _filesNamesListBox.DisplayMember = "FileShortName";
            _filesNamesListBox.ValueMember = "FileType";


            _filesNamesListBox.Items.Clear();
            Thread.Sleep(500);
            _filesNamesListBox.Invalidate(true);


            string _fileDuration = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                            0,
                            0,
                            0,
                            0);

            string _fileCurrentPosition = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                            0,
                            0,
                            0,
                            0);

            _lbltrkPosition.Text = string.Format(" {0} / {1}", _fileCurrentPosition, _fileDuration);

            _codecs.Options.Load.AllPages = false;
            _codecs.Options.Txt.Load.Enabled = _optionsSupportLoadingTEXTFilesToolStripMenuItem.Checked;

            if(_filePaths.Length > 0)
            {
               if (_playCtrl1.State == PlayState.Running)
                  _playCtrl1.Stop();
               _playCtrl1.Visible = _imageViewer1.Visible = false;
            }
            //Loop through the files
            for (int index = 0; index < _filePaths.Length; index++)
            {
               if (_cancelBrowse)
               {
                  _cancelBrowse = false;
                  return;
               }

               Invoke((MethodInvoker)delegate { Application.DoEvents(); });

               //MediaInfo: provides detailed information about the source media file
               using (Leadtools.Multimedia.MediaInfo mediaInfo = new Leadtools.Multimedia.MediaInfo())
               {
                  _fileName = _filePaths[index];

                  mediaInfo.SourceFile = _fileName;

                  if ((mediaInfo.SourceFormat == Leadtools.Multimedia.SourceFormatType.Unknown) || (mediaInfo.SourceFormat == Leadtools.Multimedia.SourceFormatType.Still))
                  //if the current file is image of any non-media file
                  {
                     try
                     {
                        using (CodecsImageInfo info = _codecs.GetInformation(_fileName, false))
                        {
                           if (info.Format != RasterImageFormat.Unknown)
                           {
                              if (_cancelBrowse)
                              {
                                 _cancelBrowse = false;
                                 return;
                              }

                              mediaInfo.ResetSource();

                              AddRasterImageToList(_fileName);

                              Invoke((MethodInvoker)delegate { Application.DoEvents(); });
                           }
                        }
                     }
                     catch (Exception)
                     {
                        try
                        {
                           //Declare a temporary player control, and pass it to the Leadtools.Multimedia.PlayCtrl constructor
                           using (Leadtools.Multimedia.PlayCtrl TempPlayer = new Leadtools.Multimedia.PlayCtrl(true))
                           {
                              if (_cancelBrowse)
                              {
                                 _cancelBrowse = false;
                                 return;
                              }

                              TempPlayer.AutoStart = false;
                              TempPlayer.SourceFile = _fileName;

                              string strShortname = _fileName.Substring(_fileName.LastIndexOf("\\"));
                              strShortname = strShortname.TrimStart(("\\").ToCharArray());

                              MyListItem ItemToAdd = new MyListItem(_fileName, strShortname, 2);//2 - Media File (Video or Audio)
                              _filesNamesListBox.Items.Add(ItemToAdd);

                              TempPlayer.ResetSource();
                           }
                        }
                        catch (Exception ex2)
                        {
                           Invoke((MethodInvoker)delegate { Application.DoEvents(); });

                           StackTrace st = new StackTrace();
                           StackFrame sf = st.GetFrame(0);
                           MethodBase currentMethodName = sf.GetMethod();

                           WriteToLogFile(_logFileName, string.Format("{0} \t {1} \t {2} \n", currentMethodName, _fileName, ex2.Message));

                           continue;
                        }
                     }
                  }
                  else
                  {
                     try
                     {
                        if (mediaInfo.OutputStreams == 0)
                        {
                           mediaInfo.ResetSource();
                           AddRasterImageToList(_fileName);
                        }
                        else
                        {
                           //Declare a temporary player control, and pass it to the Leadtools.Multimedia.PlayCtrl constructor
                           using (Leadtools.Multimedia.PlayCtrl TempPlayer = new Leadtools.Multimedia.PlayCtrl(true))
                           {
                              if (_cancelBrowse)
                              {
                                 _cancelBrowse = false;
                                 return;
                              }

                              TempPlayer.AutoStart = false;
                              TempPlayer.SourceFile = _fileName;

                              string strShortname = _fileName.Substring(_fileName.LastIndexOf("\\"));
                              strShortname = strShortname.TrimStart(("\\").ToCharArray());

                              MyListItem ItemToAdd = new MyListItem(_fileName, strShortname, 2);//2 - Media File (Video or Audio)
                              _filesNamesListBox.Items.Add(ItemToAdd);

                              TempPlayer.ResetSource();
                           }
                           Invoke((MethodInvoker)delegate { Application.DoEvents(); });
                        }
                     }
                     catch (Exception ex)
                     {
                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();

                        WriteToLogFile(_logFileName, string.Format("{0} \t {1} \t {2} \n", currentMethodName, _fileName, ex.Message));

                        continue;
                     }
                  }
               }

               if (_cancelBrowse)
               {
                  _cancelBrowse = false;
                  return;
               }
            }

            _btnNext.Visible = true;
            _btnNext.Enabled = true;

            _btnPrev.Visible = true;
            _btnPrev.Enabled = true;

         }
         catch (Exception ex)
         {
            StackTrace _st = new StackTrace();
            StackFrame _sf = _st.GetFrame(0);
            MethodBase _currentMethodName = _sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", _currentMethodName, ex.Message));
         }
      }

      private void SaveRecentFile(string path)
      {
         try
         {
            //keep list number not exceeded the given value
            while (_mrulist.Count > 5)
            {
               _mrulist.Dequeue();
            }

            //create file called "Recent.txt" located on app folder
            string RectFileName = System.Environment.CurrentDirectory + "\\Recent.txt";

            using (StreamWriter stringToWrite = new StreamWriter(RectFileName))
            {

               foreach (string item in _mrulist)
               {
                  stringToWrite.WriteLine(item); //write list to stream
               }

               stringToWrite.Flush(); //write stream to file
               stringToWrite.Close(); //close the stream and reclaim memory
            }

            //clear all recent list from menu
            _recentToolStripMenuItem.DropDownItems.Clear();
         }
         catch (Exception ex)
         {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);
            MethodBase currentMethodName = sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", currentMethodName, ex.Message));
         }
      }

      private void LoadRecentList()
      {
         //try to load file. If file isn't found, do nothing
         try
         {
            string RectFileName = System.Environment.CurrentDirectory + "\\Recent.txt";

            StreamReader listToRead = null;

            if (File.Exists(RectFileName))
            {
               //read file stream
               listToRead = new StreamReader(System.Environment.CurrentDirectory + "\\Recent.txt");
            }
            else
               return;

            string line;

            if (_mrulist.Count > 0)
               _mrulist.Clear();

            while ((line = listToRead.ReadLine()) != null) //read each line until end of file
               _mrulist.Enqueue(line); //insert to list

            listToRead.Close(); //close the stream

            if (listToRead != null)
               listToRead.Dispose();

         }
         catch (Exception ex)
         {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);
            MethodBase currentMethodName = sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", currentMethodName, ex.Message));
         }
      }

      private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (_filesNamesListBox.SelectedIndex != -1)
            {
               MyListItem _selectedListItem = _filesNamesListBox.SelectedItem as MyListItem;

               if (_selectedListItem != null)
               {
                  //if the selected file is an image, load it and then display it in the viewer
                  if ((_selectedListItem.FileType == 1))
                  {
                     // set the codecs.Options.Load.AllPages property to True to support loading all pages of the image file
                     _codecs.Options.Load.AllPages = _optionsLoadAllPagesToolStripMenuItem.Checked;

                     //Add the panning feature to the image viewer control
                     _imageViewer1.InteractiveModes.Add(PanZoomInteractiveMode);
                     PanZoomInteractiveMode.IsEnabled = true;

                     //Stop animating any playing GIF image
                     _isPlayingGif = false;
                     _pauseAnimation = true;

                     Invoke((MethodInvoker)delegate { Application.DoEvents(); });

                     if (_imageViewer1.Image != null)
                     {
                        _imageViewer1.Image.Page = 1;
                     }

                     //Load the image to the Viewer
                     _imageViewer1.Image = _codecs.Load(_selectedListItem.FileFullName);


                     _currentPageNum = 1;

                     _imageViewer1.Image.Page = _currentPageNum;

                     _numericUpDown.Maximum = _imageViewer1.Image.PageCount;
                     _numericUpDown.Value = _currentPageNum;

                     //Change Visible and Enabled properties for some button and controls
                     _btnFwd.Visible = true;
                     _btnRew.Visible = true;

                     _numericUpDown.Visible = true;

                     if (_imageViewer1.Image.PageCount > 1)
                     {
                        _numericUpDown.Enabled = true;
                        _btnFwd.Enabled = true;
                        _btnRew.Enabled = true;
                     }
                     else
                     {
                        _numericUpDown.Enabled = false;
                        _btnFwd.Enabled = false;
                        _btnRew.Enabled = false;
                     }

                     _btnPlay.Visible = false;
                     _btnStop.Visible = false;
                     _btnPause.Visible = false;
                     _trkPosition.Visible = false;
                     _lbltrkPosition.Visible = false;
                     //Show the imageViewer control
                     _imageViewer1.Visible = true;
                     _imageViewer1.Dock = DockStyle.Fill;
                     _imageViewer1.Zoom(ControlSizeMode.Fit, 1, _imageViewer1.DefaultZoomOrigin);

                     //Hide the player control
                     _playCtrl1.Visible = false;
                     _playCtrl1.Dock = DockStyle.None;
                     _playCtrl1.ResetSource();
                     _playCtrl1.Stop();

                     Invoke((MethodInvoker)delegate { Application.DoEvents(); });

                     using (CodecsImageInfo ImageInfo = _codecs.GetInformation(_selectedListItem.FileFullName, true))
                     {
                        if (ImageInfo.Format == RasterImageFormat.Gif)
                        {
                           if (_optionsLoadAllPagesToolStripMenuItem.Checked)
                           {
                              _btnPlay.Visible = true;

                              if (_optionsPlaybackMediaFilesToolStripMenuItem.Checked)
                              {
                                 if (_imageViewer1.Image != null)
                                 {
                                    using (_animatedImage = _codecs.Load(_selectedListItem.FileFullName))
                                    {
                                       _isPlayingGif = true;
                                       _pauseAnimation = false;
                                       PlayGifFile(sender, e);
                                       _isPlayingGif = false;
                                    }
                                 }
                              }
                           }
                        }
                     }
                  }
                  else if (_selectedListItem.FileType == 2)
                  {
                     //Hide the imageViewer control
                     _imageViewer1.Visible = false;
                     _imageViewer1.Image = null;
                     _imageViewer1.Dock = DockStyle.None;

                     //Show the player control
                     _playCtrl1.Location = new Point(0, 0);
                     _playCtrl1.Dock = DockStyle.Fill;
                     _playCtrl1.Visible = true;

                     Leadtools.Multimedia.PlaySeeking _playSeeking = _playCtrl1.CheckSeekingCapabilities(Leadtools.Multimedia.PlaySeeking.Forward | Leadtools.Multimedia.PlaySeeking.Backward);

                     if (_playSeeking == (Leadtools.Multimedia.PlaySeeking.Backward | Leadtools.Multimedia.PlaySeeking.Forward))
                        _playCtrl1.CurrentTrackingPosition = 0;


                     _playerPanel.Visible = true;

                     _playCtrl1.AutoStart = _optionsPlaybackMediaFilesToolStripMenuItem.Checked;
                     _playCtrl1.SourceFile = _selectedListItem.FileFullName;

                     _trkPosition.Visible = true;
                     _lbltrkPosition.Visible = true;

                     TimeSpan _t = TimeSpan.FromSeconds(_playCtrl1.Duration);

                     string FileDuration = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                                     _t.Hours,
                                     _t.Minutes,
                                     _t.Seconds,
                                     _t.Milliseconds);

                     _t = TimeSpan.FromSeconds(0);

                     string FileCurrentPosition = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                                     _t.Hours,
                                     _t.Minutes,
                                     _t.Seconds,
                                     _t.Milliseconds);

                     _lbltrkPosition.Text = string.Format(" {0} / {1}", FileCurrentPosition, FileDuration);

                     if (_playCtrl1.RenderedStreams == Leadtools.Multimedia.StreamFormatType.Audio)
                     {
                        //If the selected file is an Audio file, show the AudioFile image from resources in the image viewer
                        ResourceManager rm = Resources.ResourceManager;
                        Image AudioImage = (Bitmap)rm.GetObject("AudioFile");

                        _imageViewer1.Image = Leadtools.Drawing.RasterImageConverter.ConvertFromImage(AudioImage, Leadtools.Drawing.ConvertFromImageOptions.None);
                        _imageViewer1.Dock = DockStyle.Fill;
                        _playCtrl1.Hide();
                        _imageViewer1.Visible = true;
                        _imageViewer1.Show();
                     }

                     _numericUpDown.Enabled = false;
                     _btnFwd.Enabled = true;
                     _btnRew.Enabled = true;

                     _btnFwd.Visible = true;
                     _btnRew.Visible = true;
                     _numericUpDown.Visible = false;
                     _btnPlay.Visible = true;
                     _btnStop.Visible = true;
                     _btnPause.Visible = true;

                     _playCtrl1.Refresh();

                     _filesNamesListBox.Focus();
                  }
                  else
                  {
                     //If the selected file is not valid or not supported, show the NotSupportedFormat image from resources in the image viewer
                     ResourceManager _rm = Resources.ResourceManager;
                     Image _notSupportedFormatImage = (Bitmap)_rm.GetObject("NotSupportedFormat");

                     _imageViewer1.Image = Leadtools.Drawing.RasterImageConverter.ConvertFromImage(_notSupportedFormatImage, Leadtools.Drawing.ConvertFromImageOptions.None);
                     _imageViewer1.Dock = DockStyle.Fill;
                     _playCtrl1.Hide();
                     _imageViewer1.Visible = true;
                     _imageViewer1.Show();
                  }
               }

               this.Refresh();

               _imageViewer1.Cursor = Cursors.Default;

               if (_imageViewer1.Visible)
                  _imageViewer1.Focus();

               if (_playCtrl1.Visible)
                  _playCtrl1.Focus();
            }
         }
         catch (Exception ex)
         {
            StackTrace _st = new StackTrace();
            StackFrame _sf = _st.GetFrame(0);
            MethodBase _currentMethodName = _sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", _currentMethodName, ex.Message));

            if (_imageViewer1.Visible)
               _imageViewer1.Focus();

            if (_playCtrl1.Visible)
               _playCtrl1.Focus();
         }
      }

      private void btnRew_Click(object sender, EventArgs e)
      {
         try
         {
            //Get the selected item from the list-box
            MyListItem _selectedItem = _filesNamesListBox.SelectedItem as MyListItem;

            //If the selected file is multi-page file, show the Previous page
            if (_selectedItem.FileType == 1)
            {
               if (_imageViewer1.Visible && _imageViewer1.HasImage)
               {
                  ShowPreviousPage();
                  _imageViewer1.Focus();
               }
            }
            //If the selected file is a media file, change the playback rate
            else if (_selectedItem.FileType == 2)
               if (_playCtrl1.Rate > 0.5)
               {
                  _playCtrl1.Rate = _playCtrl1.Rate / 2;
                  _playCtrl1.Focus();
               }
         }
         catch (Exception ex)
         {
            StackTrace _st = new StackTrace();
            StackFrame _sf = _st.GetFrame(0);
            MethodBase _currentMethodName = _sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", _currentMethodName, ex.Message));
         }
      }

      private void btnFwd_Click(object sender, EventArgs e)
      {
         try
         {
            //Get the selected item from the list-box
            MyListItem _selectedItem = _filesNamesListBox.SelectedItem as MyListItem;

            //If the selected file is multi-page file, show the next page
            if (_selectedItem.FileType == 1)
            {
               if (_imageViewer1.Visible && _imageViewer1.HasImage)
               {
                  ShowNextPage();
                  _imageViewer1.Focus();
               }
            }

            //If the selected file is a media file, change the playback rate
            else if (_selectedItem.FileType == 2)
            {
               if (_playCtrl1.Rate < 2)
                  _playCtrl1.Rate = _playCtrl1.Rate * 2;

               _playCtrl1.Focus();
            }
         }
         catch (Exception ex)
         {
            StackTrace _st = new StackTrace();
            StackFrame _sf = _st.GetFrame(0);
            MethodBase _currentMethodName = _sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", _currentMethodName, ex.Message));
         }
      }

      private void btnNext_Click(object sender, EventArgs e)
      {
         //Show the next file in the list-box
         int NextIndex = -1;

         if (_filesNamesListBox.Items.Count > 1)
         {
            MyListItem SelectedItem = _filesNamesListBox.SelectedItem as MyListItem;

            if (SelectedItem != null)
            {
               if (_filesNamesListBox.Items.IndexOf(SelectedItem) != (_filesNamesListBox.Items.Count - 1))
               {
                  NextIndex = _filesNamesListBox.Items.IndexOf(SelectedItem) + 1;

                  if (_filesNamesListBox.Items[NextIndex] != null)
                  {
                     if (_imageViewer1.Visible)
                        _imageViewer1.Focus();

                     if (_playCtrl1.Visible)
                        _playCtrl1.Focus();

                     _filesNamesListBox.SelectedIndex = NextIndex;
                  }
               }
            }
         }


      }

      //Show previous page in multi-page image
      private void ShowPreviousPage()
      {
         if (_currentPageNum == 1)
            _currentPageNum = 1;
         else
            _currentPageNum--;

         _imageViewer1.Image.Page = _currentPageNum;

         _numericUpDown.Maximum = _imageViewer1.Image.PageCount;

         _numericUpDown.Value = _currentPageNum;

         _imageViewer1.Refresh();
      }

      //Show next page in multi-page image
      private void ShowNextPage()
      {
         if (_currentPageNum == _imageViewer1.Image.PageCount)
            _currentPageNum = _imageViewer1.Image.PageCount;
         else
            _currentPageNum++;

         _imageViewer1.Image.Page = _currentPageNum;
         _numericUpDown.Maximum = _imageViewer1.Image.PageCount;
         _numericUpDown.Value = _currentPageNum;

         _imageViewer1.Refresh();
      }

      private void btnPrev_Click(object sender, EventArgs e)
      {
         //Show the next file in the list-box
         int PrevIndex = -1;

         if (_filesNamesListBox.Items.Count > 1)
         {
            MyListItem SelectedItem = _filesNamesListBox.SelectedItem as MyListItem;
            if (SelectedItem != null)
            {
               if (_filesNamesListBox.Items.IndexOf(SelectedItem) != 0)
               {
                  PrevIndex = _filesNamesListBox.Items.IndexOf(SelectedItem) - 1;

                  if (_filesNamesListBox.Items[PrevIndex] != null)
                  {
                     if (_imageViewer1.Visible)
                        _imageViewer1.Focus();

                     if (_playCtrl1.Visible)
                        _playCtrl1.Focus();

                     _filesNamesListBox.SelectedIndex = PrevIndex;
                  }
               }
            }
         }
      }

      //Change the current page using the numericUpDown control
      private void numericUpDown1_ValueChanged(object sender, EventArgs e)
      {
         if (_imageViewer1.Image != null)
         {
            if (((int)_numericUpDown.Value >= 1) && ((int)_numericUpDown.Value <= _imageViewer1.Image.PageCount))
            {
               _imageViewer1.Image.Page = (int)_numericUpDown.Value;
            }
         }
      }

      //Play animated GIF image
      private void PlayGifFile(object sender, EventArgs e)
      {
         try
         {
            if (_isPlayingGif)
            {
               // Create the target image, we want it to be in the animated image size
               RasterImage _targetImage = new RasterImage(
                  RasterMemoryFlags.Conventional,
                  _animatedImage.AnimationGlobalSize.Width,
                  _animatedImage.AnimationGlobalSize.Height,
                  _animatedImage.BitsPerPixel,
                  _animatedImage.Order,
                  _animatedImage.ViewPerspective,
                  null,
                  IntPtr.Zero,
                  0);

               // Copy the palette from the animated image to this newly created image
               _animatedImage.CopyPaletteTo(_targetImage);

               // Create the RasterImageAnimator object
               RasterImageAnimator _animator = new RasterImageAnimator(_targetImage, _animatedImage);
               // Animate it
               // Use GDI+ paint engine to support transparent colors
               RasterPaintProperties props = _imageViewer1.PaintProperties;
               props.PaintEngine = RasterPaintEngine.GdiPlus;

               if (_isPlayingGif)
                  _imageViewer1.Image = _targetImage;

               using (RasterImageGdiPlusGraphicsContainer _gdiPlusGraphics = new RasterImageGdiPlusGraphicsContainer(_imageViewer1.Image))
               {
                  Graphics g = _gdiPlusGraphics.Graphics;
                  RasterImageAnimatorState state;

                  do
                  {
                     LeadRect srcRect = new LeadRect(0, 0, _targetImage.ImageWidth, _targetImage.ImageHeight);
                     LeadRect updateRect;
                     LeadRect destRect;

                     state = _animator.Process();

                     switch (state)
                     {
                        case RasterImageAnimatorState.WaitDelay:
                        case RasterImageAnimatorState.WaitInputDelay:
                           //If the current GIF frame has delay info, force the animation to delay in the animation
                           Stopwatch s = new Stopwatch();
                           s.Start();
                           while (s.Elapsed < TimeSpan.FromMilliseconds(_animator.Delay))
                           {
                              if (_isPlayingGif & !_pauseAnimation)
                                 Invoke((MethodInvoker)delegate { Application.DoEvents(); });
                              else
                                 break;
                           }
                           s.Stop();
                           _animator.CancelWait();
                           break;
                        case RasterImageAnimatorState.Render:
                           // Continue processing
                           break;
                        case RasterImageAnimatorState.WaitInput:
                           // In case the animated image has the "wait for user input" flags,
                           // cancel the waiting
                           _animator.CancelWait();
                           break;
                        case RasterImageAnimatorState.PostClear:
                        case RasterImageAnimatorState.PostRender:
                           // Get the area in the target image that has changed
                           updateRect = _animator.GetUpdateRectangle(true);
                           destRect = new LeadRect(0, 0, _targetImage.ImageWidth, _targetImage.ImageHeight);
                           // Paint it
                           RasterImagePainter.Paint(_targetImage, g, srcRect, updateRect, destRect, destRect, props);
                           break;
                        case RasterImageAnimatorState.End:
                           break;
                        default:
                           break;
                     }

                     if (_pauseAnimation)
                     {
                        _isPlayingGif = false;
                        break;
                     }

                     Invoke((MethodInvoker)delegate
                     {
                        if (_isPlayingGif)
                        {
                           Application.DoEvents();
                           _imageViewer1.Invalidate(true);
                        }
                     });

                  }
                  while (_isPlayingGif);

                  if (!_isPlayingGif & _pauseAnimation)
                  {
                     //This is the case when stop playing GIF file by pressing Escape
                     MyListItem _selectedListItem = _filesNamesListBox.SelectedItem as MyListItem;
                     _imageViewer1.Image = _codecs.Load(_selectedListItem.FileFullName);
                  }
                  if (!_isPlayingGif & !_pauseAnimation)
                     //This is the case when selecting a different image's file name in the list
                     ListBox1_SelectedValueChanged(sender, e);

                  _animator.Dispose();
                  _targetImage.Dispose();
               }
            }
         }
         catch (Exception ex)
         {
            StackTrace _st = new StackTrace();
            StackFrame _sf = _st.GetFrame(0);
            MethodBase _currentMethodName = _sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", _currentMethodName, ex.Message));
         }
      }

      //Play button
      private void btnPlay_Click(object sender, EventArgs e)
      {
         MyListItem _selectedListItem = _filesNamesListBox.SelectedItem as MyListItem;

         if (_selectedListItem != null)
         {
            if (_selectedListItem.FileType == 1)
            {
               using (CodecsImageInfo _imageInfo = _codecs.GetInformation(_selectedListItem.FileFullName, true))
               {
                  if (_imageInfo.Format == RasterImageFormat.Gif)
                  {
                     if (_optionsLoadAllPagesToolStripMenuItem.Checked)
                     {
                        _btnPlay.Visible = true;

                        if (_imageViewer1.Image != null)
                        {
                           using (_animatedImage = _codecs.Load(_selectedListItem.FileFullName))
                           {
                              _isPlayingGif = true;
                              _pauseAnimation = false;
                              _imageViewer1.Focus();
                              PlayGifFile(sender, e);
                              _isPlayingGif = false;
                           }
                        }
                     }
                  }
               }
            }
            else if (_selectedListItem.FileType == 2)
               _playCtrl1.Run();
         }
      }

      //Pause button
      private void btnPause_Click(object sender, EventArgs e)
      {
         _playCtrl1.Pause();
      }
      //Stop button
      private void btnStop_Click(object sender, EventArgs e)
      {
         _playCtrl1.Stop();
      }

      //Enable or disable loading all pages
      private void loadAllPagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _optionsLoadAllPagesToolStripMenuItem.Checked = !_optionsLoadAllPagesToolStripMenuItem.Checked;

         ListBox1_SelectedValueChanged(sender, e);
      }

      //Enable or disable Instant playback of selected media files
      private void playbackMediaFilesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _optionsPlaybackMediaFilesToolStripMenuItem.Checked = !_optionsPlaybackMediaFilesToolStripMenuItem.Checked;
         ListBox1_SelectedValueChanged(sender, e);
      }

      //Change the player's control size mode when the use double clicks the control
      private void playCtrl1_DoubleClick(object sender, EventArgs e)
      {
         try
         {
            if (_playCtrl1.SourceFile != null)
               ChangePlayerSizeMode();
         }
         catch (Exception ex)
         {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);
            MethodBase currentMethodName = sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", currentMethodName, ex.Message));
         }
      }

      private void playCtrl1_TrackingPositionChanged(object sender, TrackingPositionChangedEventArgs e)
      {
         try
         {
            _trkPosition.Value = e.position;
            SetSeekingButtonsState();

            TimeSpan t = TimeSpan.FromSeconds(_playCtrl1.Duration);

            string FileDuration = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                           t.Hours,
                           t.Minutes,
                           t.Seconds,
                           t.Milliseconds);

            t = TimeSpan.FromSeconds(_playCtrl1.CurrentPosition);

            string FileCurrentPosition = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);

            _lbltrkPosition.Text = string.Format(" {0} / {1}", FileCurrentPosition, FileDuration);

            _lbltrkPosition.Refresh();
            _trkPosition.Refresh();
         }
         catch (Exception ex)
         {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);
            MethodBase currentMethodName = sf.GetMethod();

            WriteToLogFile(_logFileName, string.Format("{0} \t {1} \n", currentMethodName, ex.Message));
         }
      }

      private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _recentToolStripMenuItem.DropDownItems.Clear();
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         string RectFileName = System.Environment.CurrentDirectory + "\\Recent.txt";
         SaveRecentFile(RectFileName);
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void listBox1_MouseMove(object sender, MouseEventArgs e)
      {
         Point point = _filesNamesListBox.PointToClient(Cursor.Position);

         //Get the index of the current listbox item
         int index = _filesNamesListBox.IndexFromPoint(point);

         if (index < 0) return;

         //Get the listbox item in the selected index
         MyListItem SelectedListItem = _filesNamesListBox.Items[index] as MyListItem;

         //Get the current text of the toolTip
         string strTool = _toolTip.GetToolTip(_filesNamesListBox);

         //If the text of the toolTip does not equal the text of the selected item, show the text of the item
         if (strTool != SelectedListItem.FileShortName)
         {
            if (SelectedListItem != null)
               _toolTip.SetToolTip(_filesNamesListBox, SelectedListItem.FileShortName);
         }
      }

      private void changeloadingOrRasterizingResolutionToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _loadingResolutionDialog.ShowDialog();

         _codecs.Options.RasterizeDocument.Load.XResolution = _loadingResolutionDialog.LoadingResolution;
         _codecs.Options.RasterizeDocument.Load.YResolution = _loadingResolutionDialog.LoadingResolution;
         _loadingResolutionDialog.Hide();
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Universal Viewer", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void ShowViewerInFullScreen(bool IsVisible)
      {
         if (IsVisible == false)
         {
            _tempImageViewerCellInTableLayout = _tableLayoutPanel1.GetCellPosition(_imageViewer1);
            _fullScreenPanel.Width = this.Width;
            _fullScreenPanel.Height = this.Height;
            _fullScreenPanel.Dock = DockStyle.Fill;

            _imageViewer1.Parent = _fullScreenPanel;
            _imageViewer1.Dock = DockStyle.Fill;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            this.Controls.Add(_fullScreenPanel);
            _fullScreenPanel.BringToFront();
            _tableLayoutPanel1.Hide();

            _menuStrip1.Hide();

            _imageViewer1.Zoom(ControlSizeMode.ActualSize, 1, _imageViewer1.DefaultZoomOrigin);

            _imageViewer1.BackColor = Color.Black;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            _fullScreenPanel.Visible = true;

            this.Refresh();
            _fullScreenPanel.Refresh();

            _imageViewer1.Refresh();
         }
      }
      private void btnFullScreen_Click(object sender, EventArgs e)
      {
         if (_imageViewer1.Visible)
            ShowViewerInFullScreen(_fullScreenPanel.Visible);
         else if (_playCtrl1.Visible)
            _playCtrl1.ToggleFullScreenMode();
      }

      private void supportLoadingTEXTFilesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _optionsSupportLoadingTEXTFilesToolStripMenuItem.Checked = !_optionsSupportLoadingTEXTFilesToolStripMenuItem.Checked;
      }

      private void btnFwd_MouseHover(object sender, EventArgs e)
      {
         MyListItem _selectedItem = _filesNamesListBox.SelectedItem as MyListItem;

         if (_selectedItem != null)
            if (_selectedItem.FileType == 1)
            {
               _toolTip.SetToolTip(_btnFwd, "Next page");
            }
            else if (_selectedItem.FileType == 2)
            {
               _toolTip.SetToolTip(_btnFwd, "Double Speed");
            }
      }

      private void btnRew_MouseHover(object sender, EventArgs e)
      {
         MyListItem _selectedItem = _filesNamesListBox.SelectedItem as MyListItem;

         if (_selectedItem != null)
         {
            if (_selectedItem.FileType == 1)
            {
               _toolTip.SetToolTip(_btnRew, "Previous page");
            }
            else if (_selectedItem.FileType == 2)
            {
               _toolTip.SetToolTip(_btnRew, "Half Speed");
            }
         }
      }
   }
}
