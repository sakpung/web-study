namespace Leadtools.Ccow.Dialogs
{
    partial class ParticipantDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParticipantDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.listViewContext = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewParticipants = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.buttonOK = new System.Windows.Forms.Button();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Context:";
            // 
            // listViewContext
            // 
            this.listViewContext.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewContext.FullRowSelect = true;
            this.listViewContext.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewContext.Location = new System.Drawing.Point(12, 25);
            this.listViewContext.Name = "listViewContext";
            this.listViewContext.Size = new System.Drawing.Size(438, 153);
            this.listViewContext.TabIndex = 1;
            this.listViewContext.UseCompatibleStateImageBehavior = false;
            this.listViewContext.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Participants:";
            // 
            // listViewParticipants
            // 
            this.listViewParticipants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewParticipants.FullRowSelect = true;
            this.listViewParticipants.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewParticipants.Location = new System.Drawing.Point(12, 197);
            this.listViewParticipants.Name = "listViewParticipants";
            this.listViewParticipants.Size = new System.Drawing.Size(438, 153);
            this.listViewParticipants.TabIndex = 3;
            this.listViewParticipants.UseCompatibleStateImageBehavior = false;
            this.listViewParticipants.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Application";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Coupon";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Suspended";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 75;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(374, 357);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Secure";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ParticipantDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 392);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listViewParticipants);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewContext);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParticipantDialog";
            this.Text = "Current Participants";
            this.Load += new System.EventHandler(this.ParticipantDialog_Load);
            this.VisibleChanged += new System.EventHandler(this.ParticipantDialog_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParticipantDialog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewContext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewParticipants;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}