namespace DocumentCleanupDemo
{
   partial class HolePunchRemoveDialog
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbLocation = new System.Windows.Forms.GroupBox();
         this._rbButtonBottom = new System.Windows.Forms.RadioButton();
         this._rbButtonRight = new System.Windows.Forms.RadioButton();
         this._rbButtonTop = new System.Windows.Forms.RadioButton();
         this._rbButtonLeft = new System.Windows.Forms.RadioButton();
         this._gbFlags = new System.Windows.Forms.GroupBox();
         this._cbUseSize = new System.Windows.Forms.CheckBox();
         this._cbUseDpi = new System.Windows.Forms.CheckBox();
         this._cbUseLocation = new System.Windows.Forms.CheckBox();
         this._cbUseCount = new System.Windows.Forms.CheckBox();
         this._cbImageUnchanged = new System.Windows.Forms.CheckBox();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._numMaxHeight = new System.Windows.Forms.NumericUpDown();
         this._numMaxWidth = new System.Windows.Forms.NumericUpDown();
         this._numMaxCount = new System.Windows.Forms.NumericUpDown();
         this._numMinHeight = new System.Windows.Forms.NumericUpDown();
         this._numMinCount = new System.Windows.Forms.NumericUpDown();
         this._numMinWidth = new System.Windows.Forms.NumericUpDown();
         this._lblUnitsMaxHeight = new System.Windows.Forms.Label();
         this._lblUnitsMaxWidth = new System.Windows.Forms.Label();
         this._lblMaxHeight = new System.Windows.Forms.Label();
         this._lblUnitsMinHeight = new System.Windows.Forms.Label();
         this._lblMaxWidth = new System.Windows.Forms.Label();
         this._lblUnitsMinWidth = new System.Windows.Forms.Label();
         this._lblMaxCount = new System.Windows.Forms.Label();
         this._lblMinHeight = new System.Windows.Forms.Label();
         this._lblMinCount = new System.Windows.Forms.Label();
         this._lblMinWidth = new System.Windows.Forms.Label();
         this._lblUnits = new System.Windows.Forms.Label();
         this._gbLocation.SuspendLayout();
         this._gbFlags.SuspendLayout();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxWidth)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxCount)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinCount)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinWidth)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(260, 45);
         this._btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(68, 22);
         this._btnCancel.TabIndex = 4;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(260, 15);
         this._btnOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(68, 22);
         this._btnOk.TabIndex = 3;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _gbLocation
         // 
         this._gbLocation.Controls.Add(this._rbButtonBottom);
         this._gbLocation.Controls.Add(this._rbButtonRight);
         this._gbLocation.Controls.Add(this._rbButtonTop);
         this._gbLocation.Controls.Add(this._rbButtonLeft);
         this._gbLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbLocation.Location = new System.Drawing.Point(152, 7);
         this._gbLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._gbLocation.Name = "_gbLocation";
         this._gbLocation.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._gbLocation.Size = new System.Drawing.Size(86, 165);
         this._gbLocation.TabIndex = 1;
         this._gbLocation.TabStop = false;
         this._gbLocation.Text = "Location";
         // 
         // _rbButtonBottom
         // 
         this._rbButtonBottom.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonBottom.Location = new System.Drawing.Point(14, 107);
         this._rbButtonBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._rbButtonBottom.Name = "_rbButtonBottom";
         this._rbButtonBottom.Size = new System.Drawing.Size(65, 22);
         this._rbButtonBottom.TabIndex = 3;
         this._rbButtonBottom.TabStop = true;
         this._rbButtonBottom.Text = "Bottom";
         this._rbButtonBottom.UseVisualStyleBackColor = true;
         // 
         // _rbButtonRight
         // 
         this._rbButtonRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonRight.Location = new System.Drawing.Point(14, 79);
         this._rbButtonRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._rbButtonRight.Name = "_rbButtonRight";
         this._rbButtonRight.Size = new System.Drawing.Size(65, 22);
         this._rbButtonRight.TabIndex = 2;
         this._rbButtonRight.TabStop = true;
         this._rbButtonRight.Text = "Right";
         this._rbButtonRight.UseVisualStyleBackColor = true;
         // 
         // _rbButtonTop
         // 
         this._rbButtonTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonTop.Location = new System.Drawing.Point(14, 50);
         this._rbButtonTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._rbButtonTop.Name = "_rbButtonTop";
         this._rbButtonTop.Size = new System.Drawing.Size(65, 22);
         this._rbButtonTop.TabIndex = 1;
         this._rbButtonTop.TabStop = true;
         this._rbButtonTop.Text = "Top";
         this._rbButtonTop.UseVisualStyleBackColor = true;
         // 
         // _rbButtonLeft
         // 
         this._rbButtonLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbButtonLeft.Location = new System.Drawing.Point(14, 23);
         this._rbButtonLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._rbButtonLeft.Name = "_rbButtonLeft";
         this._rbButtonLeft.Size = new System.Drawing.Size(65, 22);
         this._rbButtonLeft.TabIndex = 0;
         this._rbButtonLeft.TabStop = true;
         this._rbButtonLeft.Text = "Left";
         this._rbButtonLeft.UseVisualStyleBackColor = true;
         // 
         // _gbFlags
         // 
         this._gbFlags.Controls.Add(this._cbUseSize);
         this._gbFlags.Controls.Add(this._cbUseDpi);
         this._gbFlags.Controls.Add(this._cbUseLocation);
         this._gbFlags.Controls.Add(this._cbUseCount);
         this._gbFlags.Controls.Add(this._cbImageUnchanged);
         this._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbFlags.Location = new System.Drawing.Point(8, 7);
         this._gbFlags.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._gbFlags.Name = "_gbFlags";
         this._gbFlags.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._gbFlags.Size = new System.Drawing.Size(136, 165);
         this._gbFlags.TabIndex = 0;
         this._gbFlags.TabStop = false;
         this._gbFlags.Text = "Flags";
         // 
         // _cbUseSize
         // 
         this._cbUseSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbUseSize.Location = new System.Drawing.Point(14, 135);
         this._cbUseSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._cbUseSize.Name = "_cbUseSize";
         this._cbUseSize.Size = new System.Drawing.Size(108, 22);
         this._cbUseSize.TabIndex = 4;
         this._cbUseSize.Text = "Use Size";
         this._cbUseSize.UseVisualStyleBackColor = true;
         this._cbUseSize.CheckedChanged += new System.EventHandler(this._cbUseSize_CheckedChanged);
         // 
         // _cbUseDpi
         // 
         this._cbUseDpi.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbUseDpi.Location = new System.Drawing.Point(14, 107);
         this._cbUseDpi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._cbUseDpi.Name = "_cbUseDpi";
         this._cbUseDpi.Size = new System.Drawing.Size(108, 22);
         this._cbUseDpi.TabIndex = 3;
         this._cbUseDpi.Text = "Use Dpi";
         this._cbUseDpi.UseVisualStyleBackColor = true;
         this._cbUseDpi.CheckedChanged += new System.EventHandler(this._cbUseDpi_CheckedChanged);
         // 
         // _cbUseLocation
         // 
         this._cbUseLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbUseLocation.Location = new System.Drawing.Point(14, 79);
         this._cbUseLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._cbUseLocation.Name = "_cbUseLocation";
         this._cbUseLocation.Size = new System.Drawing.Size(108, 22);
         this._cbUseLocation.TabIndex = 2;
         this._cbUseLocation.Text = "Use Location";
         this._cbUseLocation.UseVisualStyleBackColor = true;
         this._cbUseLocation.CheckedChanged += new System.EventHandler(this._cbUseLocation_CheckedChanged);
         // 
         // _cbUseCount
         // 
         this._cbUseCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbUseCount.Location = new System.Drawing.Point(14, 50);
         this._cbUseCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._cbUseCount.Name = "_cbUseCount";
         this._cbUseCount.Size = new System.Drawing.Size(108, 22);
         this._cbUseCount.TabIndex = 1;
         this._cbUseCount.Text = "Use Count";
         this._cbUseCount.UseVisualStyleBackColor = true;
         this._cbUseCount.CheckedChanged += new System.EventHandler(this._cbUseCount_CheckedChanged);
         // 
         // _cbImageUnchanged
         // 
         this._cbImageUnchanged.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbImageUnchanged.Location = new System.Drawing.Point(14, 23);
         this._cbImageUnchanged.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._cbImageUnchanged.Name = "_cbImageUnchanged";
         this._cbImageUnchanged.Size = new System.Drawing.Size(108, 22);
         this._cbImageUnchanged.TabIndex = 0;
         this._cbImageUnchanged.Text = "Image Unchanged";
         this._cbImageUnchanged.UseVisualStyleBackColor = true;
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._numMaxHeight);
         this._gbOptions.Controls.Add(this._numMaxWidth);
         this._gbOptions.Controls.Add(this._numMaxCount);
         this._gbOptions.Controls.Add(this._numMinHeight);
         this._gbOptions.Controls.Add(this._numMinCount);
         this._gbOptions.Controls.Add(this._numMinWidth);
         this._gbOptions.Controls.Add(this._lblUnitsMaxHeight);
         this._gbOptions.Controls.Add(this._lblUnitsMaxWidth);
         this._gbOptions.Controls.Add(this._lblMaxHeight);
         this._gbOptions.Controls.Add(this._lblUnitsMinHeight);
         this._gbOptions.Controls.Add(this._lblMaxWidth);
         this._gbOptions.Controls.Add(this._lblUnitsMinWidth);
         this._gbOptions.Controls.Add(this._lblMaxCount);
         this._gbOptions.Controls.Add(this._lblMinHeight);
         this._gbOptions.Controls.Add(this._lblMinCount);
         this._gbOptions.Controls.Add(this._lblMinWidth);
         this._gbOptions.Controls.Add(this._lblUnits);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptions.Location = new System.Drawing.Point(8, 180);
         this._gbOptions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._gbOptions.Size = new System.Drawing.Size(316, 240);
         this._gbOptions.TabIndex = 2;
         this._gbOptions.TabStop = false;
         this._gbOptions.Text = "Options";
         // 
         // _numMaxHeight
         // 
         this._numMaxHeight.Location = new System.Drawing.Point(116, 202);
         this._numMaxHeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._numMaxHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMaxHeight.Name = "_numMaxHeight";
         this._numMaxHeight.Size = new System.Drawing.Size(100, 20);
         this._numMaxHeight.TabIndex = 15;
         this._numMaxHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMaxHeight.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numMaxWidth
         // 
         this._numMaxWidth.Location = new System.Drawing.Point(116, 172);
         this._numMaxWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._numMaxWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMaxWidth.Name = "_numMaxWidth";
         this._numMaxWidth.Size = new System.Drawing.Size(100, 20);
         this._numMaxWidth.TabIndex = 12;
         this._numMaxWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMaxWidth.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numMaxCount
         // 
         this._numMaxCount.Location = new System.Drawing.Point(116, 83);
         this._numMaxCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._numMaxCount.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
         this._numMaxCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this._numMaxCount.Name = "_numMaxCount";
         this._numMaxCount.Size = new System.Drawing.Size(100, 20);
         this._numMaxCount.TabIndex = 4;
         this._numMaxCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this._numMaxCount.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numMinHeight
         // 
         this._numMinHeight.Location = new System.Drawing.Point(116, 142);
         this._numMinHeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._numMinHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMinHeight.Name = "_numMinHeight";
         this._numMinHeight.Size = new System.Drawing.Size(100, 20);
         this._numMinHeight.TabIndex = 9;
         this._numMinHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMinHeight.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numMinCount
         // 
         this._numMinCount.Location = new System.Drawing.Point(116, 53);
         this._numMinCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._numMinCount.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
         this._numMinCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this._numMinCount.Name = "_numMinCount";
         this._numMinCount.Size = new System.Drawing.Size(100, 20);
         this._numMinCount.TabIndex = 2;
         this._numMinCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this._numMinCount.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numMinWidth
         // 
         this._numMinWidth.Location = new System.Drawing.Point(116, 112);
         this._numMinWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this._numMinWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMinWidth.Name = "_numMinWidth";
         this._numMinWidth.Size = new System.Drawing.Size(100, 20);
         this._numMinWidth.TabIndex = 6;
         this._numMinWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMinWidth.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblUnitsMaxHeight
         // 
         this._lblUnitsMaxHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblUnitsMaxHeight.Location = new System.Drawing.Point(224, 202);
         this._lblUnitsMaxHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblUnitsMaxHeight.Name = "_lblUnitsMaxHeight";
         this._lblUnitsMaxHeight.Size = new System.Drawing.Size(58, 21);
         this._lblUnitsMaxHeight.TabIndex = 16;
         this._lblUnitsMaxHeight.Text = "Pixels";
         this._lblUnitsMaxHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblUnitsMaxWidth
         // 
         this._lblUnitsMaxWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblUnitsMaxWidth.Location = new System.Drawing.Point(224, 172);
         this._lblUnitsMaxWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblUnitsMaxWidth.Name = "_lblUnitsMaxWidth";
         this._lblUnitsMaxWidth.Size = new System.Drawing.Size(58, 21);
         this._lblUnitsMaxWidth.TabIndex = 13;
         this._lblUnitsMaxWidth.Text = "Pixels";
         this._lblUnitsMaxWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblMaxHeight
         // 
         this._lblMaxHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblMaxHeight.Location = new System.Drawing.Point(14, 202);
         this._lblMaxHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblMaxHeight.Name = "_lblMaxHeight";
         this._lblMaxHeight.Size = new System.Drawing.Size(94, 21);
         this._lblMaxHeight.TabIndex = 14;
         this._lblMaxHeight.Text = "Maximum Height";
         this._lblMaxHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblUnitsMinHeight
         // 
         this._lblUnitsMinHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblUnitsMinHeight.Location = new System.Drawing.Point(224, 142);
         this._lblUnitsMinHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblUnitsMinHeight.Name = "_lblUnitsMinHeight";
         this._lblUnitsMinHeight.Size = new System.Drawing.Size(58, 21);
         this._lblUnitsMinHeight.TabIndex = 10;
         this._lblUnitsMinHeight.Text = "Pixels";
         this._lblUnitsMinHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblMaxWidth
         // 
         this._lblMaxWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblMaxWidth.Location = new System.Drawing.Point(14, 172);
         this._lblMaxWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblMaxWidth.Name = "_lblMaxWidth";
         this._lblMaxWidth.Size = new System.Drawing.Size(94, 21);
         this._lblMaxWidth.TabIndex = 11;
         this._lblMaxWidth.Text = "Maximum Width";
         this._lblMaxWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblUnitsMinWidth
         // 
         this._lblUnitsMinWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblUnitsMinWidth.Location = new System.Drawing.Point(224, 112);
         this._lblUnitsMinWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblUnitsMinWidth.Name = "_lblUnitsMinWidth";
         this._lblUnitsMinWidth.Size = new System.Drawing.Size(58, 21);
         this._lblUnitsMinWidth.TabIndex = 7;
         this._lblUnitsMinWidth.Text = "Pixels";
         this._lblUnitsMinWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblMaxCount
         // 
         this._lblMaxCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblMaxCount.Location = new System.Drawing.Point(14, 83);
         this._lblMaxCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblMaxCount.Name = "_lblMaxCount";
         this._lblMaxCount.Size = new System.Drawing.Size(94, 21);
         this._lblMaxCount.TabIndex = 3;
         this._lblMaxCount.Text = "Maximum Count";
         this._lblMaxCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblMinHeight
         // 
         this._lblMinHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblMinHeight.Location = new System.Drawing.Point(14, 142);
         this._lblMinHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblMinHeight.Name = "_lblMinHeight";
         this._lblMinHeight.Size = new System.Drawing.Size(94, 21);
         this._lblMinHeight.TabIndex = 8;
         this._lblMinHeight.Text = "Minimum Height";
         this._lblMinHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblMinCount
         // 
         this._lblMinCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblMinCount.Location = new System.Drawing.Point(14, 53);
         this._lblMinCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblMinCount.Name = "_lblMinCount";
         this._lblMinCount.Size = new System.Drawing.Size(94, 21);
         this._lblMinCount.TabIndex = 1;
         this._lblMinCount.Text = "Minimum Count";
         this._lblMinCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblMinWidth
         // 
         this._lblMinWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblMinWidth.Location = new System.Drawing.Point(14, 112);
         this._lblMinWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblMinWidth.Name = "_lblMinWidth";
         this._lblMinWidth.Size = new System.Drawing.Size(94, 21);
         this._lblMinWidth.TabIndex = 5;
         this._lblMinWidth.Text = "Minimum Width";
         this._lblMinWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblUnits
         // 
         this._lblUnits.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblUnits.Location = new System.Drawing.Point(14, 23);
         this._lblUnits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblUnits.Name = "_lblUnits";
         this._lblUnits.Size = new System.Drawing.Size(223, 21);
         this._lblUnits.TabIndex = 0;
         this._lblUnits.Text = "Units of 1/1000 inch means 1000 is an inch.";
         this._lblUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // HolePunchRemoveDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(334, 430);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._gbFlags);
         this.Controls.Add(this._gbLocation);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "HolePunchRemoveDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Hole Punch Remove";
         this.Load += new System.EventHandler(this.HolePunchRemoveDialog_Load);
         this._gbLocation.ResumeLayout(false);
         this._gbFlags.ResumeLayout(false);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numMaxHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxWidth)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxCount)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinCount)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinWidth)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbLocation;
      private System.Windows.Forms.GroupBox _gbFlags;
      private System.Windows.Forms.CheckBox _cbUseSize;
      private System.Windows.Forms.CheckBox _cbUseDpi;
      private System.Windows.Forms.CheckBox _cbUseLocation;
      private System.Windows.Forms.CheckBox _cbUseCount;
      private System.Windows.Forms.CheckBox _cbImageUnchanged;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.RadioButton _rbButtonLeft;
      private System.Windows.Forms.RadioButton _rbButtonBottom;
      private System.Windows.Forms.RadioButton _rbButtonRight;
      private System.Windows.Forms.RadioButton _rbButtonTop;
      private System.Windows.Forms.NumericUpDown _numMaxHeight;
      private System.Windows.Forms.NumericUpDown _numMaxWidth;
      private System.Windows.Forms.NumericUpDown _numMinHeight;
      private System.Windows.Forms.NumericUpDown _numMinWidth;
      private System.Windows.Forms.Label _lblUnitsMaxHeight;
      private System.Windows.Forms.Label _lblUnitsMaxWidth;
      private System.Windows.Forms.Label _lblMaxHeight;
      private System.Windows.Forms.Label _lblUnitsMinHeight;
      private System.Windows.Forms.Label _lblMaxWidth;
      private System.Windows.Forms.Label _lblUnitsMinWidth;
      private System.Windows.Forms.Label _lblMinHeight;
      private System.Windows.Forms.Label _lblMinWidth;
      private System.Windows.Forms.Label _lblUnits;
      private System.Windows.Forms.NumericUpDown _numMaxCount;
      private System.Windows.Forms.NumericUpDown _numMinCount;
      private System.Windows.Forms.Label _lblMaxCount;
      private System.Windows.Forms.Label _lblMinCount;
   }
}