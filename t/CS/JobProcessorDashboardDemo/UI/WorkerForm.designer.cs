namespace JobProcessorDashboardDemo
{
   partial class WorkerForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerForm));
         this._btnStart = new System.Windows.Forms.Button();
         this._btnStop = new System.Windows.Forms.Button();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this._lvLogging = new System.Windows.Forms.ListView();
         this._clmMessage = new System.Windows.Forms.ColumnHeader();
         this._clmSource = new System.Windows.Forms.ColumnHeader();
         this._clmType = new System.Windows.Forms.ColumnHeader();
         this._btnClearLog = new System.Windows.Forms.Button();
         this._btnExportLog = new System.Windows.Forms.Button();
         this._clmLogTime = new System.Windows.Forms.ColumnHeader();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnStart
         // 
         this._btnStart.Location = new System.Drawing.Point(24, 31);
         this._btnStart.Name = "_btnStart";
         this._btnStart.Size = new System.Drawing.Size(102, 46);
         this._btnStart.TabIndex = 1;
         this._btnStart.Text = "Start Service";
         this._btnStart.UseVisualStyleBackColor = true;
         this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
         // 
         // _btnStop
         // 
         this._btnStop.Location = new System.Drawing.Point(153, 31);
         this._btnStop.Name = "_btnStop";
         this._btnStop.Size = new System.Drawing.Size(102, 46);
         this._btnStop.TabIndex = 2;
         this._btnStop.Text = "Stop Service";
         this._btnStop.UseVisualStyleBackColor = true;
         this._btnStop.Click += new System.EventHandler(this._btnStop_Click);
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
         this.splitContainer1.IsSplitterFixed = true;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this._lvLogging);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this._btnExportLog);
         this.splitContainer1.Panel2.Controls.Add(this._btnClearLog);
         this.splitContainer1.Panel2.Controls.Add(this._btnStop);
         this.splitContainer1.Panel2.Controls.Add(this._btnStart);
         this.splitContainer1.Size = new System.Drawing.Size(857, 510);
         this.splitContainer1.SplitterDistance = 402;
         this.splitContainer1.TabIndex = 3;
         // 
         // _lvLogging
         // 
         this._lvLogging.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._clmLogTime,
            this._clmMessage,
            this._clmSource,
            this._clmType});
         this._lvLogging.Dock = System.Windows.Forms.DockStyle.Fill;
         this._lvLogging.FullRowSelect = true;
         this._lvLogging.Location = new System.Drawing.Point(0, 0);
         this._lvLogging.Name = "_lvLogging";
         this._lvLogging.Size = new System.Drawing.Size(857, 402);
         this._lvLogging.TabIndex = 0;
         this._lvLogging.UseCompatibleStateImageBehavior = false;
         this._lvLogging.View = System.Windows.Forms.View.Details;
         // 
         // _clmMessage
         // 
         this._clmMessage.Text = "Message";
         this._clmMessage.Width = 306;
         // 
         // _clmSource
         // 
         this._clmSource.Text = "Source";
         this._clmSource.Width = 258;
         // 
         // _clmType
         // 
         this._clmType.Text = "Type";
         this._clmType.Width = 156;
         // 
         // _btnClearLog
         // 
         this._btnClearLog.Location = new System.Drawing.Point(282, 31);
         this._btnClearLog.Name = "_btnClearLog";
         this._btnClearLog.Size = new System.Drawing.Size(102, 46);
         this._btnClearLog.TabIndex = 3;
         this._btnClearLog.Text = "Clear Log";
         this._btnClearLog.UseVisualStyleBackColor = true;
         this._btnClearLog.Click += new System.EventHandler(this._btnClearLog_Click);
         // 
         // _btnExportLog
         // 
         this._btnExportLog.Location = new System.Drawing.Point(411, 31);
         this._btnExportLog.Name = "_btnExportLog";
         this._btnExportLog.Size = new System.Drawing.Size(102, 46);
         this._btnExportLog.TabIndex = 4;
         this._btnExportLog.Text = "Export Log";
         this._btnExportLog.UseVisualStyleBackColor = true;
         this._btnExportLog.Click += new System.EventHandler(this._btnExportLog_Click);
         // 
         // _clmLogTime
         // 
         this._clmLogTime.Text = "Date / Time";
         this._clmLogTime.Width = 129;
         // 
         // WorkerForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(857, 510);
         this.Controls.Add(this.splitContainer1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "WorkerForm";
         this.Text = "Worker";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Worker_FormClosing);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnStart;
      private System.Windows.Forms.Button _btnStop;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Button _btnClearLog;
      private System.Windows.Forms.ListView _lvLogging;
      private System.Windows.Forms.ColumnHeader _clmMessage;
      private System.Windows.Forms.ColumnHeader _clmSource;
      private System.Windows.Forms.ColumnHeader _clmType;
      private System.Windows.Forms.Button _btnExportLog;
      private System.Windows.Forms.ColumnHeader _clmLogTime;
   }
}