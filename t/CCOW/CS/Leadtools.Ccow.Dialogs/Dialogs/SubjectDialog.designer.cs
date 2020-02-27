namespace Leadtools.Ccow.Dialogs
{
    partial class SubjectDialog
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
            this.SubjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Secure = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewApplications = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonItemDelete = new System.Windows.Forms.Button();
            this.buttonItemAdd = new System.Windows.Forms.Button();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewDependents = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.buttonDependentDelete = new System.Windows.Forms.Button();
            this.buttonDependentAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSecurityType = new System.Windows.Forms.ComboBox();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SubjectName
            // 
            this.SubjectName.Location = new System.Drawing.Point(12, 27);
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.Size = new System.Drawing.Size(430, 20);
            this.SubjectName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // Secure
            // 
            this.Secure.AutoSize = true;
            this.Secure.Location = new System.Drawing.Point(11, 232);
            this.Secure.Name = "Secure";
            this.Secure.Size = new System.Drawing.Size(60, 17);
            this.Secure.TabIndex = 4;
            this.Secure.Text = "Secure";
            this.Secure.UseVisualStyleBackColor = true;
            this.Secure.CheckedChanged += new System.EventHandler(this.Secure_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(11, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 1);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Allowed Applications:";
            // 
            // listViewApplications
            // 
            this.listViewApplications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.listViewApplications.FullRowSelect = true;
            this.listViewApplications.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewApplications.HideSelection = false;
            this.listViewApplications.Location = new System.Drawing.Point(11, 311);
            this.listViewApplications.Name = "listViewApplications";
            this.listViewApplications.Size = new System.Drawing.Size(431, 119);
            this.listViewApplications.TabIndex = 7;
            this.listViewApplications.UseCompatibleStateImageBehavior = false;
            this.listViewApplications.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 226;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(367, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(286, 436);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 435);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 10;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(174, 436);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonItemDelete
            // 
            this.buttonItemDelete.Location = new System.Drawing.Point(90, 184);
            this.buttonItemDelete.Name = "buttonItemDelete";
            this.buttonItemDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonItemDelete.TabIndex = 15;
            this.buttonItemDelete.Text = "Delete";
            this.buttonItemDelete.UseVisualStyleBackColor = true;
            this.buttonItemDelete.Click += new System.EventHandler(this.buttonItemDelete_Click);
            // 
            // buttonItemAdd
            // 
            this.buttonItemAdd.Location = new System.Drawing.Point(9, 184);
            this.buttonItemAdd.Name = "buttonItemAdd";
            this.buttonItemAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonItemAdd.TabIndex = 14;
            this.buttonItemAdd.Text = "Add";
            this.buttonItemAdd.UseVisualStyleBackColor = true;
            this.buttonItemAdd.Click += new System.EventHandler(this.buttonItemAdd_Click);
            // 
            // listViewItems
            // 
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewItems.HideSelection = false;
            this.listViewItems.Location = new System.Drawing.Point(8, 75);
            this.listViewItems.MultiSelect = false;
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(197, 103);
            this.listViewItems.TabIndex = 13;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 226;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Items:";
            // 
            // listViewDependents
            // 
            this.listViewDependents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewDependents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDependents.HideSelection = false;
            this.listViewDependents.Location = new System.Drawing.Point(245, 75);
            this.listViewDependents.MultiSelect = false;
            this.listViewDependents.Name = "listViewDependents";
            this.listViewDependents.Size = new System.Drawing.Size(197, 103);
            this.listViewDependents.TabIndex = 16;
            this.listViewDependents.UseCompatibleStateImageBehavior = false;
            this.listViewDependents.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 226;
            // 
            // buttonDependentDelete
            // 
            this.buttonDependentDelete.Location = new System.Drawing.Point(328, 184);
            this.buttonDependentDelete.Name = "buttonDependentDelete";
            this.buttonDependentDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDependentDelete.TabIndex = 18;
            this.buttonDependentDelete.Text = "Delete";
            this.buttonDependentDelete.UseVisualStyleBackColor = true;
            this.buttonDependentDelete.Click += new System.EventHandler(this.buttonDependentDelete_Click);
            // 
            // buttonDependentAdd
            // 
            this.buttonDependentAdd.Location = new System.Drawing.Point(245, 184);
            this.buttonDependentAdd.Name = "buttonDependentAdd";
            this.buttonDependentAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonDependentAdd.TabIndex = 17;
            this.buttonDependentAdd.Text = "Add";
            this.buttonDependentAdd.UseVisualStyleBackColor = true;
            this.buttonDependentAdd.Click += new System.EventHandler(this.buttonDependentAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Dependent Subjects:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Security Type:";
            // 
            // comboBoxSecurityType
            // 
            this.comboBoxSecurityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSecurityType.FormattingEnabled = true;
            this.comboBoxSecurityType.Items.AddRange(new object[] {
            "SetGet",
            "Set"});
            this.comboBoxSecurityType.Location = new System.Drawing.Point(12, 272);
            this.comboBoxSecurityType.Name = "comboBoxSecurityType";
            this.comboBoxSecurityType.Size = new System.Drawing.Size(107, 21);
            this.comboBoxSecurityType.TabIndex = 21;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Security";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(93, 435);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 22;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // SubjectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 470);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.comboBoxSecurityType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDependentDelete);
            this.Controls.Add(this.buttonDependentAdd);
            this.Controls.Add(this.listViewDependents);
            this.Controls.Add(this.buttonItemDelete);
            this.Controls.Add(this.buttonItemAdd);
            this.Controls.Add(this.listViewItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewApplications);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Secure);
            this.Controls.Add(this.SubjectName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubjectDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Subject";
            this.Load += new System.EventHandler(this.SubjectDialog_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubjectDialog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SubjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Secure;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewApplications;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonItemDelete;
        private System.Windows.Forms.Button buttonItemAdd;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewDependents;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonDependentDelete;
        private System.Windows.Forms.Button buttonDependentAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSecurityType;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonEdit;
    }
}