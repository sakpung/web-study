namespace JPXDemo
{
   partial class AnimationSettings
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimationSettings));
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._nudDelay = new System.Windows.Forms.NumericUpDown();
         this._lblMilliSecond = new System.Windows.Forms.Label();
         this._grpDelay = new System.Windows.Forms.GroupBox();
         this._grpRender = new System.Windows.Forms.GroupBox();
         this._nudRenderHeight = new System.Windows.Forms.NumericUpDown();
         this._lblRenderHeight = new System.Windows.Forms.Label();
         this._nudRenderWidth = new System.Windows.Forms.NumericUpDown();
         this._lblRenderWidth = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this._nudDelay)).BeginInit();
         this._grpDelay.SuspendLayout();
         this._grpRender.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudRenderHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudRenderWidth)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Location = new System.Drawing.Point(150, 12);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 0;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(150, 42);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 1;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _nudDelay
         // 
         this._nudDelay.Location = new System.Drawing.Point(10, 19);
         this._nudDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._nudDelay.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this._nudDelay.Name = "_nudDelay";
         this._nudDelay.Size = new System.Drawing.Size(59, 20);
         this._nudDelay.TabIndex = 3;
         this._nudDelay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // _lblMilliSecond
         // 
         this._lblMilliSecond.AutoSize = true;
         this._lblMilliSecond.Location = new System.Drawing.Point(75, 21);
         this._lblMilliSecond.Name = "_lblMilliSecond";
         this._lblMilliSecond.Size = new System.Drawing.Size(58, 13);
         this._lblMilliSecond.TabIndex = 4;
         this._lblMilliSecond.Text = "millisecond";
         // 
         // _grpDelay
         // 
         this._grpDelay.Controls.Add(this._nudDelay);
         this._grpDelay.Controls.Add(this._lblMilliSecond);
         this._grpDelay.Location = new System.Drawing.Point(5, 84);
         this._grpDelay.Name = "_grpDelay";
         this._grpDelay.Size = new System.Drawing.Size(139, 48);
         this._grpDelay.TabIndex = 5;
         this._grpDelay.TabStop = false;
         this._grpDelay.Text = "&Delay";
         // 
         // _grpRender
         // 
         this._grpRender.Controls.Add(this._nudRenderHeight);
         this._grpRender.Controls.Add(this._lblRenderHeight);
         this._grpRender.Controls.Add(this._nudRenderWidth);
         this._grpRender.Controls.Add(this._lblRenderWidth);
         this._grpRender.Location = new System.Drawing.Point(5, 5);
         this._grpRender.Name = "_grpRender";
         this._grpRender.Size = new System.Drawing.Size(139, 73);
         this._grpRender.TabIndex = 6;
         this._grpRender.TabStop = false;
         this._grpRender.Text = "&Render";
         // 
         // _nudRenderHeight
         // 
         this._nudRenderHeight.Location = new System.Drawing.Point(58, 43);
         this._nudRenderHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._nudRenderHeight.Name = "_nudRenderHeight";
         this._nudRenderHeight.Size = new System.Drawing.Size(59, 20);
         this._nudRenderHeight.TabIndex = 5;
         // 
         // _lblRenderHeight
         // 
         this._lblRenderHeight.AutoSize = true;
         this._lblRenderHeight.Location = new System.Drawing.Point(7, 45);
         this._lblRenderHeight.Name = "_lblRenderHeight";
         this._lblRenderHeight.Size = new System.Drawing.Size(38, 13);
         this._lblRenderHeight.TabIndex = 6;
         this._lblRenderHeight.Text = "&Height";
         // 
         // _nudRenderWidth
         // 
         this._nudRenderWidth.Location = new System.Drawing.Point(58, 19);
         this._nudRenderWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._nudRenderWidth.Name = "_nudRenderWidth";
         this._nudRenderWidth.Size = new System.Drawing.Size(59, 20);
         this._nudRenderWidth.TabIndex = 3;
         // 
         // _lblRenderWidth
         // 
         this._lblRenderWidth.AutoSize = true;
         this._lblRenderWidth.Location = new System.Drawing.Point(7, 21);
         this._lblRenderWidth.Name = "_lblRenderWidth";
         this._lblRenderWidth.Size = new System.Drawing.Size(35, 13);
         this._lblRenderWidth.TabIndex = 4;
         this._lblRenderWidth.Text = "&Width";
         // 
         // AnimationSettings
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(230, 138);
         this.Controls.Add(this._grpRender);
         this.Controls.Add(this._grpDelay);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AnimationSettings";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Animation Settings";
         ((System.ComponentModel.ISupportInitialize)(this._nudDelay)).EndInit();
         this._grpDelay.ResumeLayout(false);
         this._grpDelay.PerformLayout();
         this._grpRender.ResumeLayout(false);
         this._grpRender.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudRenderHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudRenderWidth)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.NumericUpDown _nudDelay;
      private System.Windows.Forms.Label _lblMilliSecond;
      private System.Windows.Forms.GroupBox _grpDelay;
      private System.Windows.Forms.GroupBox _grpRender;
      private System.Windows.Forms.NumericUpDown _nudRenderWidth;
      private System.Windows.Forms.Label _lblRenderWidth;
      private System.Windows.Forms.NumericUpDown _nudRenderHeight;
      private System.Windows.Forms.Label _lblRenderHeight;
   }
}