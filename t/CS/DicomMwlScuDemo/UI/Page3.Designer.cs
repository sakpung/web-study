using Leadtools.DicomDemos;
using Leadtools.DicomDemos.Scu.CFind;
namespace DicomDemo
{
    partial class Page3
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
            if (disposing)
            {
               if (components != null)
                  components.Dispose();

               cfind.CloseForced(true);
               if(cfind.workThread != null)
                  cfind.workThread.Abort();
               cfind.Status -= new StatusEventHandler(cfind_Status);
               cfind.FindComplete -= new FindCompleteEventHandler(cfind_FindComplete);
               cfind.Dispose();

            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnQueryServer = new System.Windows.Forms.Button();
            this.btnSaveDS = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEditValue = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTreeView = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(584, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click the \"Query MWL Server\" button, wait for response.  Optionally click the \"Sa" +
                "ve Selected\" button to save the selected";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(19, 64);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(580, 80);
            this.txtQuery.TabIndex = 1;
            this.txtQuery.TabStop = false;
            // 
            // btnQueryServer
            // 
            this.btnQueryServer.Location = new System.Drawing.Point(19, 152);
            this.btnQueryServer.Name = "btnQueryServer";
            this.btnQueryServer.Size = new System.Drawing.Size(113, 23);
            this.btnQueryServer.TabIndex = 2;
            this.btnQueryServer.Text = "Query MWL Server";
            this.btnQueryServer.UseVisualStyleBackColor = true;
            this.btnQueryServer.Click += new System.EventHandler(this.btnQueryServer_Click);
            // 
            // btnSaveDS
            // 
            this.btnSaveDS.Enabled = false;
            this.btnSaveDS.Location = new System.Drawing.Point(138, 152);
            this.btnSaveDS.Name = "btnSaveDS";
            this.btnSaveDS.Size = new System.Drawing.Size(113, 23);
            this.btnSaveDS.TabIndex = 3;
            this.btnSaveDS.Text = "Save Selected";
            this.btnSaveDS.UseVisualStyleBackColor = true;
            this.btnSaveDS.Click += new System.EventHandler(this.btnSaveDS_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Element Value";
            // 
            // txtEditValue
            // 
            this.txtEditValue.Location = new System.Drawing.Point(97, 321);
            this.txtEditValue.Name = "txtEditValue";
            this.txtEditValue.ReadOnly = true;
            this.txtEditValue.Size = new System.Drawing.Size(502, 20);
            this.txtEditValue.TabIndex = 6;
            this.txtEditValue.TabStop = false;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(19, 356);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(580, 80);
            this.txtLog.TabIndex = 7;
            this.txtLog.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "data set.  Click \"Next\" to proceed.";
            // 
            // panelTreeView
            // 
            this.panelTreeView.Location = new System.Drawing.Point(19, 184);
            this.panelTreeView.Name = "panelTreeView";
            this.panelTreeView.Size = new System.Drawing.Size(580, 128);
            this.panelTreeView.TabIndex = 10;
            // 
            // Page3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTreeView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtEditValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveDS);
            this.Controls.Add(this.btnQueryServer);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label1);
            this.Name = "Page3";
            this.Size = new System.Drawing.Size(618, 452);
            this.VisibleChanged += new System.EventHandler(this.Page3_VisibleChanged);
            this.Load += new System.EventHandler(this.Page3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnQueryServer;
        private System.Windows.Forms.Button btnSaveDS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEditValue;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelTreeView;
    }
}
