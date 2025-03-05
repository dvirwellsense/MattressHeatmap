namespace MattressHeatmap
{
    partial class frmSampling
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.numRate = new System.Windows.Forms.NumericUpDown();
            this.comboRate = new System.Windows.Forms.ComboBox();
            this.checkIncludePressures = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.radioRate = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl1.Location = new System.Drawing.Point(30, 57);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(145, 25);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Sampling Rate:";
            // 
            // numRate
            // 
            this.numRate.DecimalPlaces = 1;
            this.numRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numRate.Location = new System.Drawing.Point(274, 55);
            this.numRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRate.Name = "numRate";
            this.numRate.Size = new System.Drawing.Size(112, 30);
            this.numRate.TabIndex = 1;
            this.numRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboRate
            // 
            this.comboRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboRate.FormattingEnabled = true;
            this.comboRate.Items.AddRange(new object[] {
            "Seconds",
            "Minutes"});
            this.comboRate.Location = new System.Drawing.Point(406, 54);
            this.comboRate.Name = "comboRate";
            this.comboRate.Size = new System.Drawing.Size(146, 33);
            this.comboRate.TabIndex = 2;
            // 
            // checkIncludePressures
            // 
            this.checkIncludePressures.AutoSize = true;
            this.checkIncludePressures.Checked = true;
            this.checkIncludePressures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkIncludePressures.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkIncludePressures.Location = new System.Drawing.Point(35, 146);
            this.checkIncludePressures.Name = "checkIncludePressures";
            this.checkIncludePressures.Size = new System.Drawing.Size(190, 29);
            this.checkIncludePressures.TabIndex = 4;
            this.checkIncludePressures.Text = "Include Pressures";
            this.checkIncludePressures.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnStart.Image = global::MattressHeatmap.Properties.Resources.sample;
            this.btnStart.Location = new System.Drawing.Point(195, 208);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(191, 75);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // radioRate
            // 
            this.radioRate.AutoSize = true;
            this.radioRate.Checked = true;
            this.radioRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioRate.Location = new System.Drawing.Point(181, 55);
            this.radioRate.Name = "radioRate";
            this.radioRate.Size = new System.Drawing.Size(83, 29);
            this.radioRate.TabIndex = 7;
            this.radioRate.TabStop = true;
            this.radioRate.Text = "Every";
            this.radioRate.UseVisualStyleBackColor = true;
            this.radioRate.CheckedChanged += new System.EventHandler(this.radios_CheckedChanged);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioAll.Location = new System.Drawing.Point(181, 91);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(126, 29);
            this.radioAll.TabIndex = 8;
            this.radioAll.Text = "All Frames";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radios_CheckedChanged);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblArea.Location = new System.Drawing.Point(30, 9);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(0, 25);
            this.lblArea.TabIndex = 9;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCount.Location = new System.Drawing.Point(307, 150);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 25);
            this.lblCount.TabIndex = 10;
            this.lblCount.Visible = false;
            // 
            // frmSampling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(598, 303);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.radioAll);
            this.Controls.Add(this.radioRate);
            this.Controls.Add(this.checkIncludePressures);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.comboRate);
            this.Controls.Add(this.numRate);
            this.Controls.Add(this.lbl1);
            this.Name = "frmSampling";
            this.Text = "Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSampling_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSampling_FormClosed);
            this.Load += new System.EventHandler(this.frmSampling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.NumericUpDown numRate;
        private System.Windows.Forms.ComboBox comboRate;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox checkIncludePressures;
        private System.Windows.Forms.RadioButton radioRate;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblCount;
    }
}