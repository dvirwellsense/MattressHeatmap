namespace MattressHeatmap
{
    partial class frmSerialConnection
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRequest0 = new System.Windows.Forms.Label();
            this.lblRequest1 = new System.Windows.Forms.Label();
            this.lblRequest2 = new System.Windows.Forms.Label();
            this.lblRequest3 = new System.Windows.Forms.Label();
            this.lblRequest4 = new System.Windows.Forms.Label();
            this.lblRequest9 = new System.Windows.Forms.Label();
            this.lblRequest8 = new System.Windows.Forms.Label();
            this.lblRequest7 = new System.Windows.Forms.Label();
            this.lblRequest6 = new System.Windows.Forms.Label();
            this.lblRequest5 = new System.Windows.Forms.Label();
            this.progressBarSequence = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelSteps = new System.Windows.Forms.Panel();
            this.timerFinished = new System.Windows.Forms.Timer(this.components);
            this.timerStarted = new System.Windows.Forms.Timer(this.components);
            this.panelSteps.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(156, 539);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "▣ Test";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(156, 499);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "□ Test";
            this.label2.Visible = false;
            // 
            // lblRequest0
            // 
            this.lblRequest0.AutoSize = true;
            this.lblRequest0.Enabled = false;
            this.lblRequest0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRequest0.Location = new System.Drawing.Point(7, 10);
            this.lblRequest0.Name = "lblRequest0";
            this.lblRequest0.Size = new System.Drawing.Size(202, 25);
            this.lblRequest0.TabIndex = 2;
            this.lblRequest0.Tag = "0";
            this.lblRequest0.Text = "□ Ready request sent.";
            // 
            // lblRequest1
            // 
            this.lblRequest1.AutoSize = true;
            this.lblRequest1.Enabled = false;
            this.lblRequest1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRequest1.Location = new System.Drawing.Point(7, 44);
            this.lblRequest1.Name = "lblRequest1";
            this.lblRequest1.Size = new System.Drawing.Size(263, 25);
            this.lblRequest1.TabIndex = 3;
            this.lblRequest1.Tag = "1";
            this.lblRequest1.Text = "□ Power Config request sent.";
            // 
            // lblRequest2
            // 
            this.lblRequest2.AutoSize = true;
            this.lblRequest2.Enabled = false;
            this.lblRequest2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRequest2.Location = new System.Drawing.Point(7, 78);
            this.lblRequest2.Name = "lblRequest2";
            this.lblRequest2.Size = new System.Drawing.Size(262, 25);
            this.lblRequest2.TabIndex = 4;
            this.lblRequest2.Tag = "2";
            this.lblRequest2.Text = "□ Power Status request sent.";
            // 
            // lblRequest3
            // 
            this.lblRequest3.AutoSize = true;
            this.lblRequest3.Enabled = false;
            this.lblRequest3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRequest3.Location = new System.Drawing.Point(7, 114);
            this.lblRequest3.Name = "lblRequest3";
            this.lblRequest3.Size = new System.Drawing.Size(224, 25);
            this.lblRequest3.TabIndex = 5;
            this.lblRequest3.Tag = "3";
            this.lblRequest3.Text = "□ Self Test request sent.";
            // 
            // lblRequest4
            // 
            this.lblRequest4.AutoSize = true;
            this.lblRequest4.Enabled = false;
            this.lblRequest4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRequest4.Location = new System.Drawing.Point(7, 148);
            this.lblRequest4.Name = "lblRequest4";
            this.lblRequest4.Size = new System.Drawing.Size(369, 25);
            this.lblRequest4.TabIndex = 6;
            this.lblRequest4.Tag = "4";
            this.lblRequest4.Text = "□ Get Hwc Params At Once request sent.";
            // 
            // lblRequest9
            // 
            this.lblRequest9.AutoSize = true;
            this.lblRequest9.Enabled = false;
            this.lblRequest9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRequest9.Location = new System.Drawing.Point(7, 320);
            this.lblRequest9.Name = "lblRequest9";
            this.lblRequest9.Size = new System.Drawing.Size(187, 25);
            this.lblRequest9.TabIndex = 11;
            this.lblRequest9.Tag = "9";
            this.lblRequest9.Text = "□ Start request sent.";
            // 
            // lblRequest8
            // 
            this.lblRequest8.AutoSize = true;
            this.lblRequest8.Enabled = false;
            this.lblRequest8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRequest8.Location = new System.Drawing.Point(7, 286);
            this.lblRequest8.Name = "lblRequest8";
            this.lblRequest8.Size = new System.Drawing.Size(322, 25);
            this.lblRequest8.TabIndex = 10;
            this.lblRequest8.Tag = "8";
            this.lblRequest8.Text = "□ Got Overlay Params request sent.";
            // 
            // lblRequest7
            // 
            this.lblRequest7.AutoSize = true;
            this.lblRequest7.Enabled = false;
            this.lblRequest7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRequest7.Location = new System.Drawing.Point(7, 250);
            this.lblRequest7.Name = "lblRequest7";
            this.lblRequest7.Size = new System.Drawing.Size(286, 25);
            this.lblRequest7.TabIndex = 9;
            this.lblRequest7.Tag = "7";
            this.lblRequest7.Text = "□ Get Lut At Once request sent.";
            // 
            // lblRequest6
            // 
            this.lblRequest6.AutoSize = true;
            this.lblRequest6.Enabled = false;
            this.lblRequest6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRequest6.Location = new System.Drawing.Point(7, 216);
            this.lblRequest6.Name = "lblRequest6";
            this.lblRequest6.Size = new System.Drawing.Size(367, 25);
            this.lblRequest6.TabIndex = 8;
            this.lblRequest6.Tag = "6";
            this.lblRequest6.Text = "□ Get Ovc Params At Once request sent.";
            // 
            // lblRequest5
            // 
            this.lblRequest5.AutoSize = true;
            this.lblRequest5.Enabled = false;
            this.lblRequest5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRequest5.Location = new System.Drawing.Point(7, 182);
            this.lblRequest5.Name = "lblRequest5";
            this.lblRequest5.Size = new System.Drawing.Size(319, 25);
            this.lblRequest5.TabIndex = 7;
            this.lblRequest5.Tag = "5";
            this.lblRequest5.Text = "□ Got All Hwc Params request sent.";
            // 
            // progressBarSequence
            // 
            this.progressBarSequence.Location = new System.Drawing.Point(27, 385);
            this.progressBarSequence.Maximum = 10;
            this.progressBarSequence.Name = "progressBarSequence";
            this.progressBarSequence.Size = new System.Drawing.Size(377, 38);
            this.progressBarSequence.Step = 1;
            this.progressBarSequence.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancel.Location = new System.Drawing.Point(143, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 45);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelSteps
            // 
            this.panelSteps.Controls.Add(this.lblRequest9);
            this.panelSteps.Controls.Add(this.lblRequest8);
            this.panelSteps.Controls.Add(this.lblRequest7);
            this.panelSteps.Controls.Add(this.lblRequest6);
            this.panelSteps.Controls.Add(this.lblRequest5);
            this.panelSteps.Controls.Add(this.lblRequest4);
            this.panelSteps.Controls.Add(this.lblRequest3);
            this.panelSteps.Controls.Add(this.lblRequest2);
            this.panelSteps.Controls.Add(this.lblRequest1);
            this.panelSteps.Controls.Add(this.lblRequest0);
            this.panelSteps.Location = new System.Drawing.Point(15, 11);
            this.panelSteps.Name = "panelSteps";
            this.panelSteps.Size = new System.Drawing.Size(404, 354);
            this.panelSteps.TabIndex = 14;
            // 
            // timerFinished
            // 
            this.timerFinished.Interval = 1000;
            this.timerFinished.Tick += new System.EventHandler(this.timerFinished_Tick);
            // 
            // timerStarted
            // 
            this.timerStarted.Enabled = true;
            this.timerStarted.Interval = 1000;
            this.timerStarted.Tick += new System.EventHandler(this.timerStarted_Tick);
            // 
            // frmSerialConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 495);
            this.Controls.Add(this.panelSteps);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressBarSequence);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSerialConnection";
            this.Text = "Connecting to Serial";
            this.Load += new System.EventHandler(this.frmSerialConnection_Load);
            this.panelSteps.ResumeLayout(false);
            this.panelSteps.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRequest0;
        private System.Windows.Forms.Label lblRequest1;
        private System.Windows.Forms.Label lblRequest2;
        private System.Windows.Forms.Label lblRequest3;
        private System.Windows.Forms.Label lblRequest4;
        private System.Windows.Forms.Label lblRequest9;
        private System.Windows.Forms.Label lblRequest8;
        private System.Windows.Forms.Label lblRequest7;
        private System.Windows.Forms.Label lblRequest6;
        private System.Windows.Forms.Label lblRequest5;
        private System.Windows.Forms.ProgressBar progressBarSequence;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelSteps;
        private System.Windows.Forms.Timer timerFinished;
        private System.Windows.Forms.Timer timerStarted;
    }
}