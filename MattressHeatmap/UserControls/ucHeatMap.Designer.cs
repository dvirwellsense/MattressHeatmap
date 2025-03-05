namespace MattressHeatmap
{
    partial class ucHeatMap
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
            this.picHeatMap = new System.Windows.Forms.PictureBox();
            this.timerRedraw = new System.Windows.Forms.Timer(this.components);
            this.timerRepaint = new System.Windows.Forms.Timer(this.components);
            this.picHeatmapPressure = new System.Windows.Forms.PictureBox();
            this.timerDoubleClick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picHeatMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeatmapPressure)).BeginInit();
            this.SuspendLayout();
            // 
            // picHeatMap
            // 
            this.picHeatMap.BackColor = System.Drawing.Color.White;
            this.picHeatMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHeatMap.Location = new System.Drawing.Point(0, 0);
            this.picHeatMap.Name = "picHeatMap";
            this.picHeatMap.Size = new System.Drawing.Size(337, 317);
            this.picHeatMap.TabIndex = 5;
            this.picHeatMap.TabStop = false;
            this.picHeatMap.Paint += new System.Windows.Forms.PaintEventHandler(this.picHeatMap_Paint);
            this.picHeatMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picHeatMap_MouseDoubleClick);
            this.picHeatMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHeatMap_MouseDown);
            this.picHeatMap.MouseLeave += new System.EventHandler(this.picHeatMap_MouseLeave);
            this.picHeatMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picHeatMap_MouseMove);
            this.picHeatMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picHeatMap_MouseUp);
            this.picHeatMap.Resize += new System.EventHandler(this.picHeatMap_Resize);
            // 
            // timerRedraw
            // 
            this.timerRedraw.Tick += new System.EventHandler(this.timerRedraw_Tick);
            // 
            // timerRepaint
            // 
            this.timerRepaint.Enabled = true;
            this.timerRepaint.Tick += new System.EventHandler(this.timerRepaint_Tick);
            // 
            // picHeatmapPressure
            // 
            this.picHeatmapPressure.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picHeatmapPressure.BackColor = System.Drawing.Color.White;
            this.picHeatmapPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHeatmapPressure.Location = new System.Drawing.Point(343, 3);
            this.picHeatmapPressure.Name = "picHeatmapPressure";
            this.picHeatmapPressure.Size = new System.Drawing.Size(362, 314);
            this.picHeatmapPressure.TabIndex = 6;
            this.picHeatmapPressure.TabStop = false;
            this.picHeatmapPressure.MouseLeave += new System.EventHandler(this.picHeatmapPressure_MouseLeave);
            this.picHeatmapPressure.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picHeatMapPressure_MouseMove);
            // 
            // timerDoubleClick
            // 
            this.timerDoubleClick.Enabled = true;
            this.timerDoubleClick.Interval = 1000;
            this.timerDoubleClick.Tick += new System.EventHandler(this.timerDoubleClick_Tick);
            // 
            // ucHeatMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picHeatmapPressure);
            this.Controls.Add(this.picHeatMap);
            this.Name = "ucHeatMap";
            this.Size = new System.Drawing.Size(708, 345);
            this.Load += new System.EventHandler(this.ucHeatMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHeatMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeatmapPressure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picHeatMap;
        private System.Windows.Forms.Timer timerRedraw;
        private System.Windows.Forms.Timer timerRepaint;
        private System.Windows.Forms.PictureBox picHeatmapPressure;
        private System.Windows.Forms.Timer timerDoubleClick;
    }
}
