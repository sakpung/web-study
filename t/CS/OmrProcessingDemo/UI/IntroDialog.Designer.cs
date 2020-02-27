namespace OmrProcessingDemo.UI
{
   partial class IntroDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroDialog));
         this.rdbtnCreateNewTemplate = new System.Windows.Forms.RadioButton();
         this.rdbtnLoadTemplate = new System.Windows.Forms.RadioButton();
         this.rdbtnLoadWorkspace = new System.Windows.Forms.RadioButton();
         this.grpTask = new System.Windows.Forms.GroupBox();
         this.rdbtnLoadAutosave = new System.Windows.Forms.RadioButton();
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.lblDescCreateNewTemplate = new System.Windows.Forms.Label();
         this.lblDescLoadSavedTemplate = new System.Windows.Forms.Label();
         this.lblDescLoadSavedWorkspace = new System.Windows.Forms.Label();
         this.lblDescAutoRecover = new System.Windows.Forms.Label();
         this.grpTask.SuspendLayout();
         this.SuspendLayout();
         // 
         // rdbtnCreateNewTemplate
         // 
         this.rdbtnCreateNewTemplate.AutoSize = true;
         this.rdbtnCreateNewTemplate.Location = new System.Drawing.Point(6, 19);
         this.rdbtnCreateNewTemplate.Name = "rdbtnCreateNewTemplate";
         this.rdbtnCreateNewTemplate.Size = new System.Drawing.Size(128, 17);
         this.rdbtnCreateNewTemplate.TabIndex = 0;
         this.rdbtnCreateNewTemplate.TabStop = true;
         this.rdbtnCreateNewTemplate.Text = "&Create New Template";
         this.rdbtnCreateNewTemplate.UseVisualStyleBackColor = true;
         this.rdbtnCreateNewTemplate.CheckedChanged += new System.EventHandler(this.rdbtnCreateNewTemplate_CheckedChanged);
         // 
         // rdbtnLoadTemplate
         // 
         this.rdbtnLoadTemplate.AutoSize = true;
         this.rdbtnLoadTemplate.Location = new System.Drawing.Point(6, 83);
         this.rdbtnLoadTemplate.Name = "rdbtnLoadTemplate";
         this.rdbtnLoadTemplate.Size = new System.Drawing.Size(130, 17);
         this.rdbtnLoadTemplate.TabIndex = 1;
         this.rdbtnLoadTemplate.TabStop = true;
         this.rdbtnLoadTemplate.Text = "Load Saved &Template";
         this.rdbtnLoadTemplate.UseVisualStyleBackColor = true;
         this.rdbtnLoadTemplate.CheckedChanged += new System.EventHandler(this.rdbtnLoadTemplate_CheckedChanged);
         // 
         // rdbtnLoadWorkspace
         // 
         this.rdbtnLoadWorkspace.AutoSize = true;
         this.rdbtnLoadWorkspace.Location = new System.Drawing.Point(6, 132);
         this.rdbtnLoadWorkspace.Name = "rdbtnLoadWorkspace";
         this.rdbtnLoadWorkspace.Size = new System.Drawing.Size(141, 17);
         this.rdbtnLoadWorkspace.TabIndex = 2;
         this.rdbtnLoadWorkspace.TabStop = true;
         this.rdbtnLoadWorkspace.Text = "Load Saved &Workspace";
         this.rdbtnLoadWorkspace.UseVisualStyleBackColor = true;
         this.rdbtnLoadWorkspace.CheckedChanged += new System.EventHandler(this.rdbtnLoadWorkspace_CheckedChanged);
         // 
         // grpTask
         // 
         this.grpTask.Controls.Add(this.lblDescAutoRecover);
         this.grpTask.Controls.Add(this.lblDescLoadSavedWorkspace);
         this.grpTask.Controls.Add(this.lblDescLoadSavedTemplate);
         this.grpTask.Controls.Add(this.lblDescCreateNewTemplate);
         this.grpTask.Controls.Add(this.rdbtnLoadAutosave);
         this.grpTask.Controls.Add(this.rdbtnCreateNewTemplate);
         this.grpTask.Controls.Add(this.rdbtnLoadWorkspace);
         this.grpTask.Controls.Add(this.rdbtnLoadTemplate);
         this.grpTask.Location = new System.Drawing.Point(12, 12);
         this.grpTask.Name = "grpTask";
         this.grpTask.Size = new System.Drawing.Size(401, 278);
         this.grpTask.TabIndex = 3;
         this.grpTask.TabStop = false;
         this.grpTask.Text = "Choose a Task";
         // 
         // rdbtnLoadAutosave
         // 
         this.rdbtnLoadAutosave.AutoSize = true;
         this.rdbtnLoadAutosave.Location = new System.Drawing.Point(6, 207);
         this.rdbtnLoadAutosave.Name = "rdbtnLoadAutosave";
         this.rdbtnLoadAutosave.Size = new System.Drawing.Size(152, 17);
         this.rdbtnLoadAutosave.TabIndex = 4;
         this.rdbtnLoadAutosave.TabStop = true;
         this.rdbtnLoadAutosave.Text = "Load &Recovered Template";
         this.rdbtnLoadAutosave.UseVisualStyleBackColor = true;
         this.rdbtnLoadAutosave.CheckedChanged += new System.EventHandler(this.rdbtnLoadAutosave_CheckedChanged);
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(257, 296);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 4;
         this.btnOK.Text = "&OK";
         this.btnOK.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(338, 296);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 5;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // lblDescCreateNewTemplate
         // 
         this.lblDescCreateNewTemplate.AutoSize = true;
         this.lblDescCreateNewTemplate.Location = new System.Drawing.Point(68, 39);
         this.lblDescCreateNewTemplate.Name = "lblDescCreateNewTemplate";
         this.lblDescCreateNewTemplate.Size = new System.Drawing.Size(315, 39);
         this.lblDescCreateNewTemplate.TabIndex = 5;
         this.lblDescCreateNewTemplate.Text = "Select to create a new template in the Template Editor from an\r\n existing image. " +
    " The next step will be choosing the existing image\r\n to use as a base for the te" +
    "mplate.";
         // 
         // lblDescLoadSavedTemplate
         // 
         this.lblDescLoadSavedTemplate.AutoSize = true;
         this.lblDescLoadSavedTemplate.Location = new System.Drawing.Point(68, 103);
         this.lblDescLoadSavedTemplate.Name = "lblDescLoadSavedTemplate";
         this.lblDescLoadSavedTemplate.Size = new System.Drawing.Size(324, 26);
         this.lblDescLoadSavedTemplate.TabIndex = 6;
         this.lblDescLoadSavedTemplate.Text = "Select to load a previously-saved template into the Template Editor.\r\nThe next st" +
    "ep will be choosing the template to load.";
         // 
         // lblDescLoadSavedWorkspace
         // 
         this.lblDescLoadSavedWorkspace.AutoSize = true;
         this.lblDescLoadSavedWorkspace.Location = new System.Drawing.Point(68, 152);
         this.lblDescLoadSavedWorkspace.Name = "lblDescLoadSavedWorkspace";
         this.lblDescLoadSavedWorkspace.Size = new System.Drawing.Size(324, 52);
         this.lblDescLoadSavedWorkspace.TabIndex = 7;
         this.lblDescLoadSavedWorkspace.Text = resources.GetString("lblDescLoadSavedWorkspace.Text");
         // 
         // lblDescAutoRecover
         // 
         this.lblDescAutoRecover.AutoSize = true;
         this.lblDescAutoRecover.Location = new System.Drawing.Point(68, 227);
         this.lblDescAutoRecover.Name = "lblDescAutoRecover";
         this.lblDescAutoRecover.Size = new System.Drawing.Size(317, 39);
         this.lblDescAutoRecover.TabIndex = 8;
         this.lblDescAutoRecover.Text = "The application did not shut down correctly.  The template in\r\nthe template edito" +
    "r has been recovered.  Select this option to load\r\nthe recovered template into t" +
    "he Template Editor.";
         // 
         // IntroDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(422, 328);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.grpTask);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "IntroDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Welcome";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IntroDialog_FormClosed);
         this.grpTask.ResumeLayout(false);
         this.grpTask.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.RadioButton rdbtnCreateNewTemplate;
      private System.Windows.Forms.RadioButton rdbtnLoadTemplate;
      private System.Windows.Forms.RadioButton rdbtnLoadWorkspace;
      private System.Windows.Forms.GroupBox grpTask;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.RadioButton rdbtnLoadAutosave;
      private System.Windows.Forms.Label lblDescAutoRecover;
      private System.Windows.Forms.Label lblDescLoadSavedWorkspace;
      private System.Windows.Forms.Label lblDescLoadSavedTemplate;
      private System.Windows.Forms.Label lblDescCreateNewTemplate;
   }
}