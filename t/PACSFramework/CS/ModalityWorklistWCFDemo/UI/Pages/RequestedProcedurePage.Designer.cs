namespace ModalityWorklistWCFDemo.UI.Pages
{
    partial class RequestedProcedurePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
           this.components = new System.ComponentModel.Container();
           this.textBoxStudyInstanceUID = new System.Windows.Forms.TextBox();
           this.label10 = new System.Windows.Forms.Label();
           this.label1 = new System.Windows.Forms.Label();
           this.textBoxDescription = new System.Windows.Forms.TextBox();
           this.label2 = new System.Windows.Forms.Label();
           this.textBoxComments = new System.Windows.Forms.TextBox();
           this.label3 = new System.Windows.Forms.Label();
           this.label4 = new System.Windows.Forms.Label();
           this.label5 = new System.Windows.Forms.Label();
           this.comboBoxPriority = new System.Windows.Forms.ComboBox();
           this.propertyGridRequestedProcedure = new System.Windows.Forms.PropertyGrid();
           this.label6 = new System.Windows.Forms.Label();
           this.buttonAddRPCS = new System.Windows.Forms.Button();
           this.buttonDeleteRPCS = new System.Windows.Forms.Button();
           this.label7 = new System.Windows.Forms.Label();
           this.listViewReferencedStudy = new System.Windows.Forms.ListView();
           this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
           this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
           this.buttonAddRS = new System.Windows.Forms.Button();
           this.buttonEditRS = new System.Windows.Forms.Button();
           this.buttonDeleteRS = new System.Windows.Forms.Button();
           this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
           this.buttonAddVisit = new System.Windows.Forms.Button();
           this.buttonEditVisit = new System.Windows.Forms.Button();
           this.toolTip = new System.Windows.Forms.ToolTip(this.components);
           this.buttonDeleteVisit = new System.Windows.Forms.Button();
           this.buttonNewUID = new System.Windows.Forms.Button();
           this.comboBoxRequestedId = new System.Windows.Forms.ComboBox();
           this.textBoxAdmissionId = new System.Windows.Forms.TextBox();
           this.TopBannerPanel.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
           this.SuspendLayout();
           // 
           // TitleDescriptionLabel
           // 
           this.TitleDescriptionLabel.Size = new System.Drawing.Size(429, 32);
           this.TitleDescriptionLabel.Text = "Edit an existing requested procedure or add a new one to the modality work list d" +
               "atabase.";
           // 
           // TitleLabel
           // 
           this.TitleLabel.Text = "Requested Procedure";
           // 
           // IconPictureBox
           // 
           this.IconPictureBox.Image = global::ModalityWorklistWCFDemo.Properties.Resources.Logo;
           this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
           // 
           // textBoxStudyInstanceUID
           // 
           this.textBoxStudyInstanceUID.BackColor = System.Drawing.SystemColors.Window;
           this.textBoxStudyInstanceUID.Location = new System.Drawing.Point(287, 105);
           this.textBoxStudyInstanceUID.Name = "textBoxStudyInstanceUID";
           this.textBoxStudyInstanceUID.Size = new System.Drawing.Size(226, 20);
           this.textBoxStudyInstanceUID.TabIndex = 1;
           this.textBoxStudyInstanceUID.Tag = "Required";
           // 
           // label10
           // 
           this.label10.AutoSize = true;
           this.label10.Location = new System.Drawing.Point(284, 89);
           this.label10.Name = "label10";
           this.label10.Size = new System.Drawing.Size(103, 13);
           this.label10.TabIndex = 15;
           this.label10.Text = "Study Instance UID:";
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(19, 89);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(21, 13);
           this.label1.TabIndex = 13;
           this.label1.Text = "ID:";
           // 
           // textBoxDescription
           // 
           this.textBoxDescription.BackColor = System.Drawing.SystemColors.Window;
           this.textBoxDescription.Location = new System.Drawing.Point(287, 144);
           this.textBoxDescription.Multiline = true;
           this.textBoxDescription.Name = "textBoxDescription";
           this.textBoxDescription.Size = new System.Drawing.Size(259, 40);
           this.textBoxDescription.TabIndex = 3;
           this.textBoxDescription.Tag = "Required";
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(287, 128);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(63, 13);
           this.label2.TabIndex = 19;
           this.label2.Text = "Description:";
           // 
           // textBoxComments
           // 
           this.textBoxComments.Location = new System.Drawing.Point(22, 144);
           this.textBoxComments.Multiline = true;
           this.textBoxComments.Name = "textBoxComments";
           this.textBoxComments.Size = new System.Drawing.Size(259, 40);
           this.textBoxComments.TabIndex = 2;
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(19, 128);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(59, 13);
           this.label3.TabIndex = 17;
           this.label3.Text = "Comments:";
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(287, 187);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(71, 13);
           this.label4.TabIndex = 23;
           this.label4.Text = "Admission ID:";
           // 
           // label5
           // 
           this.label5.AutoSize = true;
           this.label5.Location = new System.Drawing.Point(19, 187);
           this.label5.Name = "label5";
           this.label5.Size = new System.Drawing.Size(41, 13);
           this.label5.TabIndex = 21;
           this.label5.Text = "Priority:";
           // 
           // comboBoxPriority
           // 
           this.comboBoxPriority.FormattingEnabled = true;
           this.comboBoxPriority.Items.AddRange(new object[] {
            "",
            "STAT",
            "HIGH",
            "ROUTINE",
            "MEDIUM",
            "LOW"});
           this.comboBoxPriority.Location = new System.Drawing.Point(22, 204);
           this.comboBoxPriority.Name = "comboBoxPriority";
           this.comboBoxPriority.Size = new System.Drawing.Size(259, 21);
           this.comboBoxPriority.TabIndex = 4;
           // 
           // propertyGridRequestedProcedure
           // 
           this.propertyGridRequestedProcedure.CommandsVisibleIfAvailable = false;
           this.propertyGridRequestedProcedure.HelpVisible = false;
           this.propertyGridRequestedProcedure.Location = new System.Drawing.Point(22, 244);
           this.propertyGridRequestedProcedure.Name = "propertyGridRequestedProcedure";
           this.propertyGridRequestedProcedure.Size = new System.Drawing.Size(259, 78);
           this.propertyGridRequestedProcedure.TabIndex = 9;
           this.propertyGridRequestedProcedure.ToolbarVisible = false;
           // 
           // label6
           // 
           this.label6.AutoSize = true;
           this.label6.Location = new System.Drawing.Point(19, 228);
           this.label6.Name = "label6";
           this.label6.Size = new System.Drawing.Size(194, 13);
           this.label6.TabIndex = 27;
           this.label6.Text = "Requested Procedure Code Sequence:";
           // 
           // buttonAddRPCS
           // 
           this.buttonAddRPCS.Location = new System.Drawing.Point(22, 328);
           this.buttonAddRPCS.Name = "buttonAddRPCS";
           this.buttonAddRPCS.Size = new System.Drawing.Size(75, 23);
           this.buttonAddRPCS.TabIndex = 10;
           this.buttonAddRPCS.Text = "Add";
           this.buttonAddRPCS.UseVisualStyleBackColor = true;
           this.buttonAddRPCS.Click += new System.EventHandler(this.buttonAddRPCS_Click);
           // 
           // buttonDeleteRPCS
           // 
           this.buttonDeleteRPCS.Location = new System.Drawing.Point(103, 328);
           this.buttonDeleteRPCS.Name = "buttonDeleteRPCS";
           this.buttonDeleteRPCS.Size = new System.Drawing.Size(75, 23);
           this.buttonDeleteRPCS.TabIndex = 11;
           this.buttonDeleteRPCS.Text = "Delete";
           this.buttonDeleteRPCS.UseVisualStyleBackColor = true;
           this.buttonDeleteRPCS.Click += new System.EventHandler(this.buttonDeleteRPCS_Click);
           // 
           // label7
           // 
           this.label7.AutoSize = true;
           this.label7.Location = new System.Drawing.Point(287, 228);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(148, 13);
           this.label7.TabIndex = 30;
           this.label7.Text = "Referenced Study Sequence:";
           // 
           // listViewReferencedStudy
           // 
           this.listViewReferencedStudy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
           this.listViewReferencedStudy.FullRowSelect = true;
           this.listViewReferencedStudy.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
           this.listViewReferencedStudy.HideSelection = false;
           this.listViewReferencedStudy.Location = new System.Drawing.Point(290, 245);
           this.listViewReferencedStudy.MultiSelect = false;
           this.listViewReferencedStudy.Name = "listViewReferencedStudy";
           this.listViewReferencedStudy.Size = new System.Drawing.Size(256, 77);
           this.listViewReferencedStudy.TabIndex = 12;
           this.listViewReferencedStudy.UseCompatibleStateImageBehavior = false;
           this.listViewReferencedStudy.View = System.Windows.Forms.View.Details;
           // 
           // columnHeader1
           // 
           this.columnHeader1.Text = "Referenced SOP Class UID";
           this.columnHeader1.Width = 98;
           // 
           // columnHeader2
           // 
           this.columnHeader2.Text = "Referenced Instance UID";
           this.columnHeader2.Width = 94;
           // 
           // buttonAddRS
           // 
           this.buttonAddRS.Location = new System.Drawing.Point(290, 328);
           this.buttonAddRS.Name = "buttonAddRS";
           this.buttonAddRS.Size = new System.Drawing.Size(75, 23);
           this.buttonAddRS.TabIndex = 13;
           this.buttonAddRS.Text = "Add";
           this.buttonAddRS.UseVisualStyleBackColor = true;
           this.buttonAddRS.Click += new System.EventHandler(this.buttonAddRS_Click);
           // 
           // buttonEditRS
           // 
           this.buttonEditRS.Location = new System.Drawing.Point(371, 328);
           this.buttonEditRS.Name = "buttonEditRS";
           this.buttonEditRS.Size = new System.Drawing.Size(75, 23);
           this.buttonEditRS.TabIndex = 14;
           this.buttonEditRS.Text = "Edit";
           this.buttonEditRS.UseVisualStyleBackColor = true;
           this.buttonEditRS.Click += new System.EventHandler(this.buttonEditRS_Click);
           // 
           // buttonDeleteRS
           // 
           this.buttonDeleteRS.Location = new System.Drawing.Point(452, 328);
           this.buttonDeleteRS.Name = "buttonDeleteRS";
           this.buttonDeleteRS.Size = new System.Drawing.Size(75, 23);
           this.buttonDeleteRS.TabIndex = 15;
           this.buttonDeleteRS.Text = "Delete";
           this.buttonDeleteRS.UseVisualStyleBackColor = true;
           this.buttonDeleteRS.Click += new System.EventHandler(this.buttonDeleteRS_Click);
           // 
           // errorProvider
           // 
           this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
           this.errorProvider.ContainerControl = this;
           // 
           // buttonAddVisit
           // 
           this.buttonAddVisit.Image = global::ModalityWorklistWCFDemo.Properties.Resources.Add;
           this.buttonAddVisit.Location = new System.Drawing.Point(453, 203);
           this.buttonAddVisit.Name = "buttonAddVisit";
           this.buttonAddVisit.Size = new System.Drawing.Size(31, 20);
           this.buttonAddVisit.TabIndex = 6;
           this.toolTip.SetToolTip(this.buttonAddVisit, "Add Visit");
           this.buttonAddVisit.UseVisualStyleBackColor = true;
           this.buttonAddVisit.Click += new System.EventHandler(this.buttonAddVisit_Click);
           // 
           // buttonEditVisit
           // 
           this.buttonEditVisit.Image = global::ModalityWorklistWCFDemo.Properties.Resources.Edit;
           this.buttonEditVisit.Location = new System.Drawing.Point(484, 203);
           this.buttonEditVisit.Name = "buttonEditVisit";
           this.buttonEditVisit.Size = new System.Drawing.Size(31, 20);
           this.buttonEditVisit.TabIndex = 7;
           this.toolTip.SetToolTip(this.buttonEditVisit, "Edit Visit");
           this.buttonEditVisit.UseVisualStyleBackColor = true;
           this.buttonEditVisit.Click += new System.EventHandler(this.buttonEditVisit_Click);
           // 
           // buttonDeleteVisit
           // 
           this.buttonDeleteVisit.Image = global::ModalityWorklistWCFDemo.Properties.Resources.Delete;
           this.buttonDeleteVisit.Location = new System.Drawing.Point(514, 203);
           this.buttonDeleteVisit.Name = "buttonDeleteVisit";
           this.buttonDeleteVisit.Size = new System.Drawing.Size(31, 20);
           this.buttonDeleteVisit.TabIndex = 8;
           this.toolTip.SetToolTip(this.buttonDeleteVisit, "Delete Visit");
           this.buttonDeleteVisit.UseVisualStyleBackColor = true;
           this.buttonDeleteVisit.Click += new System.EventHandler(this.buttonDeleteVisit_Click);
           // 
           // buttonNewUID
           // 
           this.buttonNewUID.Image = global::ModalityWorklistWCFDemo.Properties.Resources.Add;
           this.buttonNewUID.Location = new System.Drawing.Point(514, 106);
           this.buttonNewUID.Name = "buttonNewUID";
           this.buttonNewUID.Size = new System.Drawing.Size(31, 20);
           this.buttonNewUID.TabIndex = 2;
           this.toolTip.SetToolTip(this.buttonNewUID, "Generate new UID");
           this.buttonNewUID.UseVisualStyleBackColor = true;
           this.buttonNewUID.Click += new System.EventHandler(this.buttonNewUID_Click);
           // 
           // comboBoxRequestedId
           // 
           this.comboBoxRequestedId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
           this.comboBoxRequestedId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
           this.comboBoxRequestedId.FormattingEnabled = true;
           this.comboBoxRequestedId.Location = new System.Drawing.Point(22, 106);
           this.comboBoxRequestedId.Name = "comboBoxRequestedId";
           this.comboBoxRequestedId.Size = new System.Drawing.Size(259, 21);
           this.comboBoxRequestedId.TabIndex = 0;
           this.comboBoxRequestedId.Tag = "Required";
           this.comboBoxRequestedId.SelectedIndexChanged += new System.EventHandler(this.comboBoxRequestedId_SelectedIndexChanged);
           // 
           // textBoxAdmissionId
           // 
           this.textBoxAdmissionId.Location = new System.Drawing.Point(290, 204);
           this.textBoxAdmissionId.Name = "textBoxAdmissionId";
           this.textBoxAdmissionId.ReadOnly = true;
           this.textBoxAdmissionId.Size = new System.Drawing.Size(163, 20);
           this.textBoxAdmissionId.TabIndex = 5;
           // 
           // RequestedProcedurePage
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Controls.Add(this.textBoxAdmissionId);
           this.Controls.Add(this.comboBoxRequestedId);
           this.Controls.Add(this.buttonDeleteVisit);
           this.Controls.Add(this.buttonEditVisit);
           this.Controls.Add(this.buttonAddVisit);
           this.Controls.Add(this.buttonDeleteRS);
           this.Controls.Add(this.buttonNewUID);
           this.Controls.Add(this.buttonEditRS);
           this.Controls.Add(this.buttonAddRS);
           this.Controls.Add(this.listViewReferencedStudy);
           this.Controls.Add(this.label7);
           this.Controls.Add(this.buttonDeleteRPCS);
           this.Controls.Add(this.buttonAddRPCS);
           this.Controls.Add(this.label6);
           this.Controls.Add(this.propertyGridRequestedProcedure);
           this.Controls.Add(this.comboBoxPriority);
           this.Controls.Add(this.label4);
           this.Controls.Add(this.label5);
           this.Controls.Add(this.textBoxDescription);
           this.Controls.Add(this.label2);
           this.Controls.Add(this.textBoxComments);
           this.Controls.Add(this.label3);
           this.Controls.Add(this.textBoxStudyInstanceUID);
           this.Controls.Add(this.label10);
           this.Controls.Add(this.label1);
           this.Name = "RequestedProcedurePage";
           this.Size = new System.Drawing.Size(571, 397);
           this.Paint += new System.Windows.Forms.PaintEventHandler(this.RequestedProcedurePage_Paint);
           this.Controls.SetChildIndex(this.label1, 0);
           this.Controls.SetChildIndex(this.label10, 0);
           this.Controls.SetChildIndex(this.textBoxStudyInstanceUID, 0);
           this.Controls.SetChildIndex(this.label3, 0);
           this.Controls.SetChildIndex(this.textBoxComments, 0);
           this.Controls.SetChildIndex(this.label2, 0);
           this.Controls.SetChildIndex(this.textBoxDescription, 0);
           this.Controls.SetChildIndex(this.label5, 0);
           this.Controls.SetChildIndex(this.label4, 0);
           this.Controls.SetChildIndex(this.comboBoxPriority, 0);
           this.Controls.SetChildIndex(this.propertyGridRequestedProcedure, 0);
           this.Controls.SetChildIndex(this.label6, 0);
           this.Controls.SetChildIndex(this.buttonAddRPCS, 0);
           this.Controls.SetChildIndex(this.buttonDeleteRPCS, 0);
           this.Controls.SetChildIndex(this.label7, 0);
           this.Controls.SetChildIndex(this.listViewReferencedStudy, 0);
           this.Controls.SetChildIndex(this.buttonAddRS, 0);
           this.Controls.SetChildIndex(this.buttonEditRS, 0);
           this.Controls.SetChildIndex(this.buttonNewUID, 0);
           this.Controls.SetChildIndex(this.buttonDeleteRS, 0);
           this.Controls.SetChildIndex(this.buttonAddVisit, 0);
           this.Controls.SetChildIndex(this.buttonEditVisit, 0);
           this.Controls.SetChildIndex(this.buttonDeleteVisit, 0);
           this.Controls.SetChildIndex(this.comboBoxRequestedId, 0);
           this.Controls.SetChildIndex(this.textBoxAdmissionId, 0);
           this.Controls.SetChildIndex(this.TopBannerPanel, 0);
           this.TopBannerPanel.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStudyInstanceUID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.PropertyGrid propertyGridRequestedProcedure;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddRPCS;
        private System.Windows.Forms.Button buttonDeleteRPCS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listViewReferencedStudy;
        private System.Windows.Forms.Button buttonAddRS;
        private System.Windows.Forms.Button buttonEditRS;
        private System.Windows.Forms.Button buttonDeleteRS;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button buttonEditVisit;
        private System.Windows.Forms.Button buttonAddVisit;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox comboBoxRequestedId;
        private System.Windows.Forms.TextBox textBoxAdmissionId;
        private System.Windows.Forms.Button buttonDeleteVisit;
        private System.Windows.Forms.Button buttonNewUID;
    }
}
