namespace MPPSWCFDemo.UI
{
   partial class PatientForm
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
         this.components = new System.ComponentModel.Container();
         this.textBoxComments = new System.Windows.Forms.TextBox();
         this.label10 = new System.Windows.Forms.Label();
         this.textBoxSpecialNeeds = new System.Windows.Forms.TextBox();
         this.label9 = new System.Windows.Forms.Label();
         this.comboBoxSex = new System.Windows.Forms.ComboBox();
         this.label8 = new System.Windows.Forms.Label();
         this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
         this.label7 = new System.Windows.Forms.Label();
         this.groupBoxName = new System.Windows.Forms.GroupBox();
         this.textBoxSuffix = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.textBoxFamily = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.textBoxGiven = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.textBoxPrefix = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.textBoxIssuerOfPatientId = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.textBoxPatientId = new System.Windows.Forms.TextBox();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.groupBoxName.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.SuspendLayout();
         // 
         // textBoxComments
         // 
         this.textBoxComments.Location = new System.Drawing.Point(15, 183);
         this.textBoxComments.Multiline = true;
         this.textBoxComments.Name = "textBoxComments";
         this.textBoxComments.Size = new System.Drawing.Size(524, 80);
         this.textBoxComments.TabIndex = 27;
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(12, 167);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(59, 13);
         this.label10.TabIndex = 28;
         this.label10.Text = "Comments:";
         // 
         // textBoxSpecialNeeds
         // 
         this.textBoxSpecialNeeds.Location = new System.Drawing.Point(277, 144);
         this.textBoxSpecialNeeds.Name = "textBoxSpecialNeeds";
         this.textBoxSpecialNeeds.Size = new System.Drawing.Size(259, 20);
         this.textBoxSpecialNeeds.TabIndex = 26;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(277, 127);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(79, 13);
         this.label9.TabIndex = 23;
         this.label9.Text = "Special Needs:";
         // 
         // comboBoxSex
         // 
         this.comboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxSex.FormattingEnabled = true;
         this.comboBoxSex.Items.AddRange(new object[] {
            "M",
            "F",
            "O"});
         this.comboBoxSex.Location = new System.Drawing.Point(153, 143);
         this.comboBoxSex.Name = "comboBoxSex";
         this.comboBoxSex.Size = new System.Drawing.Size(121, 21);
         this.comboBoxSex.TabIndex = 25;
         this.comboBoxSex.Tag = "required";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(150, 127);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(28, 13);
         this.label8.TabIndex = 21;
         this.label8.Text = "Sex:";
         // 
         // dateTimePickerBirth
         // 
         this.dateTimePickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerBirth.Location = new System.Drawing.Point(15, 144);
         this.dateTimePickerBirth.Name = "dateTimePickerBirth";
         this.dateTimePickerBirth.ShowCheckBox = true;
         this.dateTimePickerBirth.Size = new System.Drawing.Size(132, 20);
         this.dateTimePickerBirth.TabIndex = 24;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(12, 128);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(52, 13);
         this.label7.TabIndex = 20;
         this.label7.Text = "Birthdate:";
         // 
         // groupBoxName
         // 
         this.groupBoxName.BackColor = System.Drawing.SystemColors.Control;
         this.groupBoxName.Controls.Add(this.textBoxSuffix);
         this.groupBoxName.Controls.Add(this.label6);
         this.groupBoxName.Controls.Add(this.textBoxFamily);
         this.groupBoxName.Controls.Add(this.label5);
         this.groupBoxName.Controls.Add(this.textBoxGiven);
         this.groupBoxName.Controls.Add(this.label3);
         this.groupBoxName.Controls.Add(this.textBoxPrefix);
         this.groupBoxName.Controls.Add(this.label4);
         this.groupBoxName.Location = new System.Drawing.Point(15, 52);
         this.groupBoxName.Name = "groupBoxName";
         this.groupBoxName.Size = new System.Drawing.Size(524, 73);
         this.groupBoxName.TabIndex = 19;
         this.groupBoxName.TabStop = false;
         this.groupBoxName.Tag = "Required";
         this.groupBoxName.Text = "Name";
         // 
         // textBoxSuffix
         // 
         this.textBoxSuffix.Location = new System.Drawing.Point(447, 42);
         this.textBoxSuffix.Name = "textBoxSuffix";
         this.textBoxSuffix.Size = new System.Drawing.Size(74, 20);
         this.textBoxSuffix.TabIndex = 7;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(444, 26);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(36, 13);
         this.label6.TabIndex = 3;
         this.label6.Text = "Suffix:";
         // 
         // textBoxFamily
         // 
         this.textBoxFamily.BackColor = System.Drawing.SystemColors.Window;
         this.textBoxFamily.Location = new System.Drawing.Point(265, 42);
         this.textBoxFamily.Name = "textBoxFamily";
         this.textBoxFamily.Size = new System.Drawing.Size(180, 20);
         this.textBoxFamily.TabIndex = 6;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(262, 26);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(39, 13);
         this.label5.TabIndex = 2;
         this.label5.Text = "Family:";
         // 
         // textBoxGiven
         // 
         this.textBoxGiven.BackColor = System.Drawing.SystemColors.Window;
         this.textBoxGiven.Location = new System.Drawing.Point(83, 42);
         this.textBoxGiven.Name = "textBoxGiven";
         this.textBoxGiven.Size = new System.Drawing.Size(180, 20);
         this.textBoxGiven.TabIndex = 5;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(80, 26);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(38, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "Given:";
         // 
         // textBoxPrefix
         // 
         this.textBoxPrefix.Location = new System.Drawing.Point(7, 42);
         this.textBoxPrefix.Name = "textBoxPrefix";
         this.textBoxPrefix.Size = new System.Drawing.Size(74, 20);
         this.textBoxPrefix.TabIndex = 4;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(4, 26);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(36, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Prefix:";
         // 
         // textBoxIssuerOfPatientId
         // 
         this.textBoxIssuerOfPatientId.BackColor = System.Drawing.SystemColors.Window;
         this.textBoxIssuerOfPatientId.Location = new System.Drawing.Point(280, 26);
         this.textBoxIssuerOfPatientId.Name = "textBoxIssuerOfPatientId";
         this.textBoxIssuerOfPatientId.Size = new System.Drawing.Size(259, 20);
         this.textBoxIssuerOfPatientId.TabIndex = 18;
         this.textBoxIssuerOfPatientId.Tag = "Required";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(277, 9);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(102, 13);
         this.label2.TabIndex = 22;
         this.label2.Text = "Issuer Of Patient ID:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(21, 13);
         this.label1.TabIndex = 17;
         this.label1.Text = "ID:";
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(460, 270);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 29;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(379, 270);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 30;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         // 
         // textBoxPatientId
         // 
         this.textBoxPatientId.Location = new System.Drawing.Point(15, 26);
         this.textBoxPatientId.Name = "textBoxPatientId";
         this.textBoxPatientId.Size = new System.Drawing.Size(263, 20);
         this.textBoxPatientId.TabIndex = 31;
         // 
         // errorProvider
         // 
         this.errorProvider.ContainerControl = this;
         // 
         // PatientForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(550, 305);
         this.Controls.Add(this.textBoxPatientId);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.textBoxComments);
         this.Controls.Add(this.label10);
         this.Controls.Add(this.textBoxSpecialNeeds);
         this.Controls.Add(this.label9);
         this.Controls.Add(this.comboBoxSex);
         this.Controls.Add(this.label8);
         this.Controls.Add(this.dateTimePickerBirth);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.groupBoxName);
         this.Controls.Add(this.textBoxIssuerOfPatientId);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PatientForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "PatientForm";
         this.Load += new System.EventHandler(this.PatientForm_Load);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.PatientForm_Paint);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PatientForm_FormClosing);
         this.groupBoxName.ResumeLayout(false);
         this.groupBoxName.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBoxComments;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.TextBox textBoxSpecialNeeds;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.ComboBox comboBoxSex;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.DateTimePicker dateTimePickerBirth;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.GroupBox groupBoxName;
      private System.Windows.Forms.TextBox textBoxSuffix;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox textBoxFamily;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox textBoxGiven;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox textBoxPrefix;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox textBoxIssuerOfPatientId;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.TextBox textBoxPatientId;
      private System.Windows.Forms.ErrorProvider errorProvider;
   }
}