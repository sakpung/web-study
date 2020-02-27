namespace MPPSWCFDemo.UI.Pages
{
    partial class SequencesPage
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
            this.buttonDeleteReasonCode = new System.Windows.Forms.Button();
            this.buttonEditReasonCode = new System.Windows.Forms.Button();
            this.buttonAddReasonCode = new System.Windows.Forms.Button();
            this.listViewReasonCode = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDeleteProtocol = new System.Windows.Forms.Button();
            this.listViewProtocol = new System.Windows.Forms.ListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.buttonEditProtocol = new System.Windows.Forms.Button();
            this.buttonAddProtocol = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDeleteCodeSequence = new System.Windows.Forms.Button();
            this.listViewCodeSequence = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.buttonEditCodeSequence = new System.Windows.Forms.Button();
            this.buttonAddCodeSequence = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TopBannerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TopBannerPanel
            // 
            this.TopBannerPanel.Size = new System.Drawing.Size(549, 87);
            // 
            // TitleDescriptionLabel
            // 
            this.TitleDescriptionLabel.Location = new System.Drawing.Point(7, 40);
            this.TitleDescriptionLabel.Size = new System.Drawing.Size(385, 32);
            this.TitleDescriptionLabel.Text = "Edit the sequences that are include as part of the modality performed procedure s" +
                "tep instance.";
            // 
            // TitleLabel
            // 
            this.TitleLabel.Location = new System.Drawing.Point(7, 9);
            this.TitleLabel.Size = new System.Drawing.Size(372, 31);
            this.TitleLabel.Text = "Modality Peformed Procedure Step (Step 2)";
            // 
            // IconPictureBox
            // 
            this.IconPictureBox.Image = global::MPPSWCFDemo.Properties.Resources.Logo;
            this.IconPictureBox.Location = new System.Drawing.Point(415, 9);
            this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // buttonDeleteReasonCode
            // 
            this.buttonDeleteReasonCode.Location = new System.Drawing.Point(459, 159);
            this.buttonDeleteReasonCode.Name = "buttonDeleteReasonCode";
            this.buttonDeleteReasonCode.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteReasonCode.TabIndex = 39;
            this.buttonDeleteReasonCode.Text = "Delete";
            this.buttonDeleteReasonCode.UseVisualStyleBackColor = true;
            this.buttonDeleteReasonCode.Click += new System.EventHandler(this.buttonDeleteReasonCode_Click);
            // 
            // buttonEditReasonCode
            // 
            this.buttonEditReasonCode.Location = new System.Drawing.Point(459, 132);
            this.buttonEditReasonCode.Name = "buttonEditReasonCode";
            this.buttonEditReasonCode.Size = new System.Drawing.Size(75, 23);
            this.buttonEditReasonCode.TabIndex = 38;
            this.buttonEditReasonCode.Text = "Edit";
            this.buttonEditReasonCode.UseVisualStyleBackColor = true;
            this.buttonEditReasonCode.Click += new System.EventHandler(this.buttonEditReasonCode_Click);
            // 
            // buttonAddReasonCode
            // 
            this.buttonAddReasonCode.Location = new System.Drawing.Point(459, 105);
            this.buttonAddReasonCode.Name = "buttonAddReasonCode";
            this.buttonAddReasonCode.Size = new System.Drawing.Size(75, 23);
            this.buttonAddReasonCode.TabIndex = 37;
            this.buttonAddReasonCode.Text = "Add";
            this.buttonAddReasonCode.UseVisualStyleBackColor = true;
            this.buttonAddReasonCode.Click += new System.EventHandler(this.buttonAddReasonCode_Click);
            // 
            // listViewReasonCode
            // 
            this.listViewReasonCode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewReasonCode.FullRowSelect = true;
            this.listViewReasonCode.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewReasonCode.HideSelection = false;
            this.listViewReasonCode.Location = new System.Drawing.Point(10, 105);
            this.listViewReasonCode.Name = "listViewReasonCode";
            this.listViewReasonCode.Size = new System.Drawing.Size(446, 77);
            this.listViewReasonCode.TabIndex = 36;
            this.listViewReasonCode.UseCompatibleStateImageBehavior = false;
            this.listViewReasonCode.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Code Value";
            this.columnHeader1.Width = 73;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Code Scheme Designator";
            this.columnHeader2.Width = 139;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Code Meaning";
            this.columnHeader3.Width = 94;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Code Scheme Version";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Order Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Peformed Procedure Step Discontinuation Reason Code Sequence:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Peformed Protocol Code Sequence:";
            // 
            // buttonDeleteProtocol
            // 
            this.buttonDeleteProtocol.Location = new System.Drawing.Point(459, 351);
            this.buttonDeleteProtocol.Name = "buttonDeleteProtocol";
            this.buttonDeleteProtocol.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteProtocol.TabIndex = 49;
            this.buttonDeleteProtocol.Text = "Delete";
            this.buttonDeleteProtocol.UseVisualStyleBackColor = true;
            this.buttonDeleteProtocol.Click += new System.EventHandler(this.buttonDeleteProtocol_Click);
            // 
            // listViewProtocol
            // 
            this.listViewProtocol.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.listViewProtocol.FullRowSelect = true;
            this.listViewProtocol.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewProtocol.HideSelection = false;
            this.listViewProtocol.Location = new System.Drawing.Point(10, 297);
            this.listViewProtocol.Name = "listViewProtocol";
            this.listViewProtocol.Size = new System.Drawing.Size(446, 77);
            this.listViewProtocol.TabIndex = 46;
            this.listViewProtocol.UseCompatibleStateImageBehavior = false;
            this.listViewProtocol.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Code Value";
            this.columnHeader11.Width = 73;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Code Scheme Designator";
            this.columnHeader12.Width = 139;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Code Meaning";
            this.columnHeader13.Width = 94;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Code Scheme Version";
            this.columnHeader14.Width = 120;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Order Number";
            // 
            // buttonEditProtocol
            // 
            this.buttonEditProtocol.Location = new System.Drawing.Point(459, 324);
            this.buttonEditProtocol.Name = "buttonEditProtocol";
            this.buttonEditProtocol.Size = new System.Drawing.Size(75, 23);
            this.buttonEditProtocol.TabIndex = 48;
            this.buttonEditProtocol.Text = "Edit";
            this.buttonEditProtocol.UseVisualStyleBackColor = true;
            this.buttonEditProtocol.Click += new System.EventHandler(this.buttonEditProtocol_Click);
            // 
            // buttonAddProtocol
            // 
            this.buttonAddProtocol.Location = new System.Drawing.Point(459, 297);
            this.buttonAddProtocol.Name = "buttonAddProtocol";
            this.buttonAddProtocol.Size = new System.Drawing.Size(75, 23);
            this.buttonAddProtocol.TabIndex = 47;
            this.buttonAddProtocol.Text = "Add";
            this.buttonAddProtocol.UseVisualStyleBackColor = true;
            this.buttonAddProtocol.Click += new System.EventHandler(this.buttonAddProtocol_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Procedure Code Sequence";
            // 
            // buttonDeleteCodeSequence
            // 
            this.buttonDeleteCodeSequence.Location = new System.Drawing.Point(459, 255);
            this.buttonDeleteCodeSequence.Name = "buttonDeleteCodeSequence";
            this.buttonDeleteCodeSequence.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteCodeSequence.TabIndex = 44;
            this.buttonDeleteCodeSequence.Text = "Delete";
            this.buttonDeleteCodeSequence.UseVisualStyleBackColor = true;
            this.buttonDeleteCodeSequence.Click += new System.EventHandler(this.buttonDeleteCodeSequence_Click);
            // 
            // listViewCodeSequence
            // 
            this.listViewCodeSequence.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listViewCodeSequence.FullRowSelect = true;
            this.listViewCodeSequence.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewCodeSequence.HideSelection = false;
            this.listViewCodeSequence.Location = new System.Drawing.Point(10, 201);
            this.listViewCodeSequence.Name = "listViewCodeSequence";
            this.listViewCodeSequence.Size = new System.Drawing.Size(446, 77);
            this.listViewCodeSequence.TabIndex = 41;
            this.listViewCodeSequence.UseCompatibleStateImageBehavior = false;
            this.listViewCodeSequence.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Code Value";
            this.columnHeader6.Width = 73;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Code Scheme Designator";
            this.columnHeader7.Width = 139;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Code Meaning";
            this.columnHeader8.Width = 94;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Code Scheme Version";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Order Number";
            // 
            // buttonEditCodeSequence
            // 
            this.buttonEditCodeSequence.Location = new System.Drawing.Point(459, 228);
            this.buttonEditCodeSequence.Name = "buttonEditCodeSequence";
            this.buttonEditCodeSequence.Size = new System.Drawing.Size(75, 23);
            this.buttonEditCodeSequence.TabIndex = 43;
            this.buttonEditCodeSequence.Text = "Edit";
            this.buttonEditCodeSequence.UseVisualStyleBackColor = true;
            this.buttonEditCodeSequence.Click += new System.EventHandler(this.buttonEditCodeSequence_Click);
            // 
            // buttonAddCodeSequence
            // 
            this.buttonAddCodeSequence.Location = new System.Drawing.Point(459, 201);
            this.buttonAddCodeSequence.Name = "buttonAddCodeSequence";
            this.buttonAddCodeSequence.Size = new System.Drawing.Size(75, 23);
            this.buttonAddCodeSequence.TabIndex = 42;
            this.buttonAddCodeSequence.Text = "Add";
            this.buttonAddCodeSequence.UseVisualStyleBackColor = true;
            this.buttonAddCodeSequence.Click += new System.EventHandler(this.buttonAddCodeSequence_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(10, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(524, 32);
            this.label4.TabIndex = 50;
            this.label4.Text = "Note:  The MPPS instance has additional optional sequence items.  This demo only " +
                "provides a subset of the available  sequence items.  Please refer to the documen" +
                "tation to see what is available.";
            // 
            // SequencesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAddProtocol);
            this.Controls.Add(this.listViewReasonCode);
            this.Controls.Add(this.buttonEditReasonCode);
            this.Controls.Add(this.buttonEditProtocol);
            this.Controls.Add(this.buttonAddCodeSequence);
            this.Controls.Add(this.buttonAddReasonCode);
            this.Controls.Add(this.buttonDeleteCodeSequence);
            this.Controls.Add(this.listViewProtocol);
            this.Controls.Add(this.listViewCodeSequence);
            this.Controls.Add(this.buttonDeleteReasonCode);
            this.Controls.Add(this.buttonDeleteProtocol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonEditCodeSequence);
            this.Name = "SequencesPage";
            this.Size = new System.Drawing.Size(549, 453);
            this.Controls.SetChildIndex(this.buttonEditCodeSequence, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.buttonDeleteProtocol, 0);
            this.Controls.SetChildIndex(this.buttonDeleteReasonCode, 0);
            this.Controls.SetChildIndex(this.listViewCodeSequence, 0);
            this.Controls.SetChildIndex(this.listViewProtocol, 0);
            this.Controls.SetChildIndex(this.buttonDeleteCodeSequence, 0);
            this.Controls.SetChildIndex(this.buttonAddReasonCode, 0);
            this.Controls.SetChildIndex(this.buttonAddCodeSequence, 0);
            this.Controls.SetChildIndex(this.buttonEditProtocol, 0);
            this.Controls.SetChildIndex(this.buttonEditReasonCode, 0);
            this.Controls.SetChildIndex(this.listViewReasonCode, 0);
            this.Controls.SetChildIndex(this.buttonAddProtocol, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.TopBannerPanel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.TopBannerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDeleteReasonCode;
        private System.Windows.Forms.Button buttonEditReasonCode;
        private System.Windows.Forms.Button buttonAddReasonCode;
        private System.Windows.Forms.ListView listViewReasonCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDeleteProtocol;
        private System.Windows.Forms.ListView listViewProtocol;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.Button buttonEditProtocol;
        private System.Windows.Forms.Button buttonAddProtocol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDeleteCodeSequence;
        private System.Windows.Forms.ListView listViewCodeSequence;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Button buttonEditCodeSequence;
        private System.Windows.Forms.Button buttonAddCodeSequence;
        private System.Windows.Forms.Label label4;
    }
}
