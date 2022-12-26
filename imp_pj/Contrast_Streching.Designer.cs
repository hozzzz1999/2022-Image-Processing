namespace imp_pj
{
    partial class Contrast_Streching
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(255D, 255D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.pictureBox_source = new System.Windows.Forms.PictureBox();
            this.pictureBox_result = new System.Windows.Forms.PictureBox();
            this.trackBarR1 = new System.Windows.Forms.TrackBar();
            this.labelR1 = new System.Windows.Forms.Label();
            this.labelR2 = new System.Windows.Forms.Label();
            this.labelS1 = new System.Windows.Forms.Label();
            this.labelS2 = new System.Windows.Forms.Label();
            this.trackBarS1 = new System.Windows.Forms.TrackBar();
            this.trackBarR2 = new System.Windows.Forms.TrackBar();
            this.trackBarS2 = new System.Windows.Forms.TrackBar();
            this.textBoxR1 = new System.Windows.Forms.TextBox();
            this.textBoxS1 = new System.Windows.Forms.TextBox();
            this.textBoxR2 = new System.Windows.Forms.TextBox();
            this.textBoxS2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_source
            // 
            this.pictureBox_source.Location = new System.Drawing.Point(12, 26);
            this.pictureBox_source.Name = "pictureBox_source";
            this.pictureBox_source.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_source.TabIndex = 0;
            this.pictureBox_source.TabStop = false;
            // 
            // pictureBox_result
            // 
            this.pictureBox_result.Location = new System.Drawing.Point(434, 26);
            this.pictureBox_result.Name = "pictureBox_result";
            this.pictureBox_result.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_result.TabIndex = 1;
            this.pictureBox_result.TabStop = false;
            // 
            // trackBarR1
            // 
            this.trackBarR1.BackColor = System.Drawing.Color.Peru;
            this.trackBarR1.Location = new System.Drawing.Point(60, 310);
            this.trackBarR1.Maximum = 255;
            this.trackBarR1.Name = "trackBarR1";
            this.trackBarR1.Size = new System.Drawing.Size(590, 45);
            this.trackBarR1.TabIndex = 2;
            this.trackBarR1.Scroll += new System.EventHandler(this.trackBarR1_Scroll);
            // 
            // labelR1
            // 
            this.labelR1.AutoSize = true;
            this.labelR1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR1.Location = new System.Drawing.Point(20, 320);
            this.labelR1.Name = "labelR1";
            this.labelR1.Size = new System.Drawing.Size(34, 24);
            this.labelR1.TabIndex = 3;
            this.labelR1.Text = "R1";
            // 
            // labelR2
            // 
            this.labelR2.AutoSize = true;
            this.labelR2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR2.Location = new System.Drawing.Point(20, 420);
            this.labelR2.Name = "labelR2";
            this.labelR2.Size = new System.Drawing.Size(34, 24);
            this.labelR2.TabIndex = 4;
            this.labelR2.Text = "R2";
            // 
            // labelS1
            // 
            this.labelS1.AutoSize = true;
            this.labelS1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS1.Location = new System.Drawing.Point(20, 370);
            this.labelS1.Name = "labelS1";
            this.labelS1.Size = new System.Drawing.Size(34, 24);
            this.labelS1.TabIndex = 4;
            this.labelS1.Text = "S1";
            // 
            // labelS2
            // 
            this.labelS2.AutoSize = true;
            this.labelS2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS2.Location = new System.Drawing.Point(20, 470);
            this.labelS2.Name = "labelS2";
            this.labelS2.Size = new System.Drawing.Size(34, 24);
            this.labelS2.TabIndex = 5;
            this.labelS2.Text = "S2";
            // 
            // trackBarS1
            // 
            this.trackBarS1.BackColor = System.Drawing.Color.Peru;
            this.trackBarS1.Location = new System.Drawing.Point(60, 360);
            this.trackBarS1.Maximum = 255;
            this.trackBarS1.Name = "trackBarS1";
            this.trackBarS1.Size = new System.Drawing.Size(590, 45);
            this.trackBarS1.TabIndex = 6;
            this.trackBarS1.Scroll += new System.EventHandler(this.trackBarS1_Scroll);
            // 
            // trackBarR2
            // 
            this.trackBarR2.BackColor = System.Drawing.Color.Peru;
            this.trackBarR2.Location = new System.Drawing.Point(60, 410);
            this.trackBarR2.Maximum = 255;
            this.trackBarR2.Name = "trackBarR2";
            this.trackBarR2.Size = new System.Drawing.Size(590, 45);
            this.trackBarR2.TabIndex = 7;
            this.trackBarR2.Scroll += new System.EventHandler(this.trackBarR2_Scroll);
            // 
            // trackBarS2
            // 
            this.trackBarS2.BackColor = System.Drawing.Color.Peru;
            this.trackBarS2.Location = new System.Drawing.Point(60, 460);
            this.trackBarS2.Maximum = 255;
            this.trackBarS2.Name = "trackBarS2";
            this.trackBarS2.Size = new System.Drawing.Size(590, 45);
            this.trackBarS2.TabIndex = 8;
            this.trackBarS2.Scroll += new System.EventHandler(this.trackBarS2_Scroll);
            // 
            // textBoxR1
            // 
            this.textBoxR1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxR1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxR1.Location = new System.Drawing.Point(655, 320);
            this.textBoxR1.Name = "textBoxR1";
            this.textBoxR1.Size = new System.Drawing.Size(40, 26);
            this.textBoxR1.TabIndex = 9;
            this.textBoxR1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxS1
            // 
            this.textBoxS1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxS1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxS1.Location = new System.Drawing.Point(655, 370);
            this.textBoxS1.Name = "textBoxS1";
            this.textBoxS1.Size = new System.Drawing.Size(40, 26);
            this.textBoxS1.TabIndex = 10;
            this.textBoxS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxR2
            // 
            this.textBoxR2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxR2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxR2.Location = new System.Drawing.Point(655, 420);
            this.textBoxR2.Name = "textBoxR2";
            this.textBoxR2.Size = new System.Drawing.Size(40, 26);
            this.textBoxR2.TabIndex = 11;
            this.textBoxR2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxS2
            // 
            this.textBoxS2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxS2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxS2.Location = new System.Drawing.Point(655, 470);
            this.textBoxS2.Name = "textBoxS2";
            this.textBoxS2.Size = new System.Drawing.Size(40, 26);
            this.textBoxS2.TabIndex = 12;
            this.textBoxS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(95, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Before";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(539, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "After";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chart1.BorderlineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.Interval = 32D;
            chartArea1.AxisX.Maximum = 256D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Input intensit level (r)";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Interval = 32D;
            chartArea1.AxisY.Maximum = 256D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Output intensit level (s)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(726, 26);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.RoyalBlue;
            series1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Pixel";
            dataPoint1.IsValueShownAsLabel = false;
            dataPoint1.Label = "";
            dataPoint2.Label = "(r1, s1)";
            dataPoint2.LabelBackColor = System.Drawing.Color.Transparent;
            dataPoint2.LabelForeColor = System.Drawing.Color.Black;
            dataPoint3.Label = "(r2, s2)";
            dataPoint4.IsValueShownAsLabel = false;
            dataPoint4.Label = "";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(479, 479);
            this.chart1.TabIndex = 16;
            this.chart1.Text = "chart1";
            title1.BackColor = System.Drawing.Color.Orange;
            title1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Transform";
            this.chart1.Titles.Add(title1);
            // 
            // Contrast_Streching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1217, 515);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxS2);
            this.Controls.Add(this.textBoxR2);
            this.Controls.Add(this.textBoxS1);
            this.Controls.Add(this.textBoxR1);
            this.Controls.Add(this.trackBarS2);
            this.Controls.Add(this.trackBarR2);
            this.Controls.Add(this.trackBarS1);
            this.Controls.Add(this.labelS2);
            this.Controls.Add(this.labelS1);
            this.Controls.Add(this.labelR2);
            this.Controls.Add(this.labelR1);
            this.Controls.Add(this.trackBarR1);
            this.Controls.Add(this.pictureBox_result);
            this.Controls.Add(this.pictureBox_source);
            this.Name = "Contrast_Streching";
            this.Text = "Contrast_Streching";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_source;
        private System.Windows.Forms.PictureBox pictureBox_result;
        private System.Windows.Forms.TrackBar trackBarR1;
        private System.Windows.Forms.Label labelR1;
        private System.Windows.Forms.Label labelR2;
        private System.Windows.Forms.Label labelS1;
        private System.Windows.Forms.Label labelS2;
        private System.Windows.Forms.TrackBar trackBarS1;
        private System.Windows.Forms.TrackBar trackBarR2;
        private System.Windows.Forms.TrackBar trackBarS2;
        private System.Windows.Forms.TextBox textBoxR1;
        private System.Windows.Forms.TextBox textBoxS1;
        private System.Windows.Forms.TextBox textBoxR2;
        private System.Windows.Forms.TextBox textBoxS2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}