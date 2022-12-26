namespace imp_pj
{
    partial class Video
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox_source = new System.Windows.Forms.PictureBox();
            this.pictureBox_nextimg = new System.Windows.Forms.PictureBox();
            this.pictureBox_motionvector = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motionVectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getfirstvectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oSAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tDLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_nextimg = new System.Windows.Forms.Button();
            this.button_increase = new System.Windows.Forms.Button();
            this.button_beforeimg = new System.Windows.Forms.Button();
            this.button_decrease = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox_Cblock = new System.Windows.Forms.PictureBox();
            this.pictureBox_Tblock = new System.Windows.Forms.PictureBox();
            this.label_frame = new System.Windows.Forms.Label();
            this.label_Cblock = new System.Windows.Forms.Label();
            this.label_Tblock = new System.Windows.Forms.Label();
            this.timer_motion = new System.Windows.Forms.Timer(this.components);
            this.chart_PSNR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer_full = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_nextimg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_motionvector)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Cblock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Tblock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PSNR)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_source
            // 
            this.pictureBox_source.Location = new System.Drawing.Point(37, 61);
            this.pictureBox_source.Name = "pictureBox_source";
            this.pictureBox_source.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_source.TabIndex = 0;
            this.pictureBox_source.TabStop = false;
            this.pictureBox_source.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_source_Paint);
            // 
            // pictureBox_nextimg
            // 
            this.pictureBox_nextimg.Location = new System.Drawing.Point(474, 61);
            this.pictureBox_nextimg.Name = "pictureBox_nextimg";
            this.pictureBox_nextimg.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_nextimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_nextimg.TabIndex = 5;
            this.pictureBox_nextimg.TabStop = false;
            this.pictureBox_nextimg.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_nextimg_Paint);
            // 
            // pictureBox_motionvector
            // 
            this.pictureBox_motionvector.Location = new System.Drawing.Point(37, 381);
            this.pictureBox_motionvector.Name = "pictureBox_motionvector";
            this.pictureBox_motionvector.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_motionvector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_motionvector.TabIndex = 6;
            this.pictureBox_motionvector.TabStop = false;
            this.pictureBox_motionvector.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_motionvector_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.motionVectorToolStripMenuItem,
            this.timeStopToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fileToolStripMenuItem.Image = global::imp_pj.Properties.Resources.folder;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.fileToolStripMenuItem.Text = "File(&F)";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.openToolStripMenuItem.Image = global::imp_pj.Properties.Resources.open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Open(&P)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.open_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.exitToolStripMenuItem.Image = global::imp_pj.Properties.Resources.logout__1_;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit(&E)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit_Click);
            // 
            // motionVectorToolStripMenuItem
            // 
            this.motionVectorToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.motionVectorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getfirstvectorToolStripMenuItem,
            this.fullscreenToolStripMenuItem,
            this.oSAToolStripMenuItem,
            this.tSSToolStripMenuItem,
            this.tDLToolStripMenuItem});
            this.motionVectorToolStripMenuItem.Enabled = false;
            this.motionVectorToolStripMenuItem.Name = "motionVectorToolStripMenuItem";
            this.motionVectorToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.motionVectorToolStripMenuItem.Text = "Motion Vector(&M)";
            this.motionVectorToolStripMenuItem.Click += new System.EventHandler(this.motionVectorToolStripMenuItem_Click);
            // 
            // getfirstvectorToolStripMenuItem
            // 
            this.getfirstvectorToolStripMenuItem.Name = "getfirstvectorToolStripMenuItem";
            this.getfirstvectorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.getfirstvectorToolStripMenuItem.Text = "block";
            this.getfirstvectorToolStripMenuItem.Click += new System.EventHandler(this.getfirstvectorToolStripMenuItem_Click);
            // 
            // fullscreenToolStripMenuItem
            // 
            this.fullscreenToolStripMenuItem.Name = "fullscreenToolStripMenuItem";
            this.fullscreenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fullscreenToolStripMenuItem.Text = "full_screen";
            this.fullscreenToolStripMenuItem.Click += new System.EventHandler(this.fullscreenToolStripMenuItem_Click);
            // 
            // oSAToolStripMenuItem
            // 
            this.oSAToolStripMenuItem.Name = "oSAToolStripMenuItem";
            this.oSAToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.oSAToolStripMenuItem.Text = "OSA";
            this.oSAToolStripMenuItem.Click += new System.EventHandler(this.oSAToolStripMenuItem_Click);
            // 
            // tSSToolStripMenuItem
            // 
            this.tSSToolStripMenuItem.Name = "tSSToolStripMenuItem";
            this.tSSToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tSSToolStripMenuItem.Text = "TSS";
            this.tSSToolStripMenuItem.Click += new System.EventHandler(this.tSSToolStripMenuItem_Click);
            // 
            // tDLToolStripMenuItem
            // 
            this.tDLToolStripMenuItem.Name = "tDLToolStripMenuItem";
            this.tDLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tDLToolStripMenuItem.Text = "TDL";
            this.tDLToolStripMenuItem.Click += new System.EventHandler(this.tDLToolStripMenuItem_Click);
            // 
            // timeStopToolStripMenuItem
            // 
            this.timeStopToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.timeStopToolStripMenuItem.Name = "timeStopToolStripMenuItem";
            this.timeStopToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.timeStopToolStripMenuItem.Text = "Time Stop(&T)";
            // 
            // button_nextimg
            // 
            this.button_nextimg.BackColor = System.Drawing.Color.Lavender;
            this.button_nextimg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_nextimg.Image = global::imp_pj.Properties.Resources.play_pause;
            this.button_nextimg.Location = new System.Drawing.Point(190, 323);
            this.button_nextimg.Name = "button_nextimg";
            this.button_nextimg.Size = new System.Drawing.Size(52, 52);
            this.button_nextimg.TabIndex = 9;
            this.button_nextimg.UseVisualStyleBackColor = false;
            this.button_nextimg.Visible = false;
            this.button_nextimg.Click += new System.EventHandler(this.button_nextimg_Click);
            // 
            // button_increase
            // 
            this.button_increase.BackColor = System.Drawing.Color.Lavender;
            this.button_increase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_increase.Image = global::imp_pj.Properties.Resources.forward;
            this.button_increase.Location = new System.Drawing.Point(241, 323);
            this.button_increase.Name = "button_increase";
            this.button_increase.Size = new System.Drawing.Size(52, 52);
            this.button_increase.TabIndex = 10;
            this.button_increase.UseVisualStyleBackColor = false;
            this.button_increase.Visible = false;
            this.button_increase.Click += new System.EventHandler(this.button_increase_Click);
            // 
            // button_beforeimg
            // 
            this.button_beforeimg.BackColor = System.Drawing.Color.Lavender;
            this.button_beforeimg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_beforeimg.Image = global::imp_pj.Properties.Resources.pause_play;
            this.button_beforeimg.Location = new System.Drawing.Point(88, 323);
            this.button_beforeimg.Name = "button_beforeimg";
            this.button_beforeimg.Size = new System.Drawing.Size(52, 52);
            this.button_beforeimg.TabIndex = 11;
            this.button_beforeimg.UseVisualStyleBackColor = false;
            this.button_beforeimg.Visible = false;
            this.button_beforeimg.Click += new System.EventHandler(this.button_beforeimg_Click);
            // 
            // button_decrease
            // 
            this.button_decrease.BackColor = System.Drawing.Color.Lavender;
            this.button_decrease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_decrease.Image = global::imp_pj.Properties.Resources.rewind;
            this.button_decrease.Location = new System.Drawing.Point(37, 323);
            this.button_decrease.Name = "button_decrease";
            this.button_decrease.Size = new System.Drawing.Size(52, 52);
            this.button_decrease.TabIndex = 12;
            this.button_decrease.UseVisualStyleBackColor = false;
            this.button_decrease.Visible = false;
            this.button_decrease.Click += new System.EventHandler(this.button_decrease_Click);
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.Lavender;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Image = global::imp_pj.Properties.Resources.play__2_;
            this.button_start.Location = new System.Drawing.Point(139, 323);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(52, 52);
            this.button_start.TabIndex = 13;
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Visible = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Info;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(894, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(108, 17);
            this.toolStripStatusLabel1.Text = "(Height, Width)  =";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabel2.Text = "(x, y)";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel3.Text = "Speed = 1x";
            // 
            // pictureBox_Cblock
            // 
            this.pictureBox_Cblock.Location = new System.Drawing.Point(314, 253);
            this.pictureBox_Cblock.Name = "pictureBox_Cblock";
            this.pictureBox_Cblock.Size = new System.Drawing.Size(64, 64);
            this.pictureBox_Cblock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Cblock.TabIndex = 15;
            this.pictureBox_Cblock.TabStop = false;
            this.pictureBox_Cblock.Visible = false;
            // 
            // pictureBox_Tblock
            // 
            this.pictureBox_Tblock.Location = new System.Drawing.Point(753, 253);
            this.pictureBox_Tblock.Name = "pictureBox_Tblock";
            this.pictureBox_Tblock.Size = new System.Drawing.Size(64, 64);
            this.pictureBox_Tblock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Tblock.TabIndex = 16;
            this.pictureBox_Tblock.TabStop = false;
            this.pictureBox_Tblock.Visible = false;
            // 
            // label_frame
            // 
            this.label_frame.AutoSize = true;
            this.label_frame.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_frame.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label_frame.Location = new System.Drawing.Point(33, 39);
            this.label_frame.Name = "label_frame";
            this.label_frame.Size = new System.Drawing.Size(171, 19);
            this.label_frame.TabIndex = 46;
            this.label_frame.Text = "Current Frame: x/X";
            this.label_frame.Visible = false;
            // 
            // label_Cblock
            // 
            this.label_Cblock.AutoSize = true;
            this.label_Cblock.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Cblock.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label_Cblock.Location = new System.Drawing.Point(310, 231);
            this.label_Cblock.Name = "label_Cblock";
            this.label_Cblock.Size = new System.Drawing.Size(144, 19);
            this.label_Cblock.TabIndex = 47;
            this.label_Cblock.Text = "Candidate block";
            this.label_Cblock.Visible = false;
            // 
            // label_Tblock
            // 
            this.label_Tblock.AutoSize = true;
            this.label_Tblock.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tblock.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label_Tblock.Location = new System.Drawing.Point(749, 231);
            this.label_Tblock.Name = "label_Tblock";
            this.label_Tblock.Size = new System.Drawing.Size(117, 19);
            this.label_Tblock.TabIndex = 48;
            this.label_Tblock.Text = "Target block";
            this.label_Tblock.Visible = false;
            // 
            // timer_motion
            // 
            this.timer_motion.Interval = 10;
            this.timer_motion.Tick += new System.EventHandler(this.timer_motion_Tick);
            // 
            // chart_PSNR
            // 
            chartArea1.AxisX.Title = "Frame";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisY.Title = "PSNR";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chart_PSNR.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_PSNR.Legends.Add(legend1);
            this.chart_PSNR.Location = new System.Drawing.Point(474, 381);
            this.chart_PSNR.Name = "chart_PSNR";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.DarkOrange;
            series1.Legend = "Legend1";
            series1.Name = "PSNR";
            this.chart_PSNR.Series.Add(series1);
            this.chart_PSNR.Size = new System.Drawing.Size(392, 256);
            this.chart_PSNR.TabIndex = 50;
            this.chart_PSNR.Text = "chart2";
            this.chart_PSNR.Visible = false;
            // 
            // timer_full
            // 
            this.timer_full.Interval = 50;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Video
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(894, 672);
            this.Controls.Add(this.chart_PSNR);
            this.Controls.Add(this.label_Tblock);
            this.Controls.Add(this.label_Cblock);
            this.Controls.Add(this.label_frame);
            this.Controls.Add(this.pictureBox_Tblock);
            this.Controls.Add(this.pictureBox_Cblock);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_decrease);
            this.Controls.Add(this.button_beforeimg);
            this.Controls.Add(this.button_increase);
            this.Controls.Add(this.button_nextimg);
            this.Controls.Add(this.pictureBox_motionvector);
            this.Controls.Add(this.pictureBox_nextimg);
            this.Controls.Add(this.pictureBox_source);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Video";
            this.Text = "Video";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_nextimg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_motionvector)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Cblock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Tblock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PSNR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox_source;
        private System.Windows.Forms.PictureBox pictureBox_nextimg;
        private System.Windows.Forms.PictureBox pictureBox_motionvector;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button button_nextimg;
        private System.Windows.Forms.Button button_increase;
        private System.Windows.Forms.Button button_beforeimg;
        private System.Windows.Forms.Button button_decrease;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.PictureBox pictureBox_Cblock;
        private System.Windows.Forms.PictureBox pictureBox_Tblock;
        private System.Windows.Forms.Label label_frame;
        private System.Windows.Forms.Label label_Cblock;
        private System.Windows.Forms.Label label_Tblock;
        private System.Windows.Forms.ToolStripMenuItem motionVectorToolStripMenuItem;
        private System.Windows.Forms.Timer timer_motion;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_PSNR;
        private System.Windows.Forms.ToolStripMenuItem getfirstvectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullscreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oSAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tSSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tDLToolStripMenuItem;
        private System.Windows.Forms.Timer timer_full;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem timeStopToolStripMenuItem;
    }
}