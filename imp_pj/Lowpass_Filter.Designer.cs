using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace imp_pj
{
    partial class Lowpass_Filter
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
            this.pictureBox_Source = new System.Windows.Forms.PictureBox();
            this.pictureBox_AddNoise = new System.Windows.Forms.PictureBox();
            this.pictureBox_Result = new System.Windows.Forms.PictureBox();
            this.label_originimg = new System.Windows.Forms.Label();
            this.label_addnoise = new System.Windows.Forms.Label();
            this.label_resultimg = new System.Windows.Forms.Label();
            this.groupBox_filter = new System.Windows.Forms.GroupBox();
            this.label_T = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.radioButton_Average = new System.Windows.Forms.RadioButton();
            this.radioButton_Median = new System.Windows.Forms.RadioButton();
            this.radioButton_Outlier = new System.Windows.Forms.RadioButton();
            this.groupBox_size = new System.Windows.Forms.GroupBox();
            this.radioButton_mask7 = new System.Windows.Forms.RadioButton();
            this.radioButton_mask5 = new System.Windows.Forms.RadioButton();
            this.radioButton_mask3 = new System.Windows.Forms.RadioButton();
            this.groupBox_method = new System.Windows.Forms.GroupBox();
            this.radioButton_Pseudo = new System.Windows.Forms.RadioButton();
            this.radioButton_Cross = new System.Windows.Forms.RadioButton();
            this.radioButton_Square = new System.Windows.Forms.RadioButton();
            this.pictureBox_Button_AddNoise = new System.Windows.Forms.PictureBox();
            this.label_noiseSNR = new System.Windows.Forms.Label();
            this.label_resultSNR = new System.Windows.Forms.Label();
            this.pictureBox_clickOK = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AddNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Result)).BeginInit();
            this.groupBox_filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox_size.SuspendLayout();
            this.groupBox_method.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Button_AddNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_clickOK)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Source
            // 
            this.pictureBox_Source.Location = new System.Drawing.Point(30, 45);
            this.pictureBox_Source.Name = "pictureBox_Source";
            this.pictureBox_Source.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Source.TabIndex = 5;
            this.pictureBox_Source.TabStop = false;
            // 
            // pictureBox_AddNoise
            // 
            this.pictureBox_AddNoise.Location = new System.Drawing.Point(330, 45);
            this.pictureBox_AddNoise.Name = "pictureBox_AddNoise";
            this.pictureBox_AddNoise.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_AddNoise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_AddNoise.TabIndex = 6;
            this.pictureBox_AddNoise.TabStop = false;
            // 
            // pictureBox_Result
            // 
            this.pictureBox_Result.Location = new System.Drawing.Point(630, 45);
            this.pictureBox_Result.Name = "pictureBox_Result";
            this.pictureBox_Result.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Result.TabIndex = 7;
            this.pictureBox_Result.TabStop = false;
            // 
            // label_originimg
            // 
            this.label_originimg.AutoSize = true;
            this.label_originimg.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_originimg.ForeColor = System.Drawing.Color.Orange;
            this.label_originimg.Location = new System.Drawing.Point(91, 304);
            this.label_originimg.Name = "label_originimg";
            this.label_originimg.Size = new System.Drawing.Size(117, 19);
            this.label_originimg.TabIndex = 26;
            this.label_originimg.Text = "Origin Image";
            // 
            // label_addnoise
            // 
            this.label_addnoise.AutoSize = true;
            this.label_addnoise.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_addnoise.ForeColor = System.Drawing.Color.Orange;
            this.label_addnoise.Location = new System.Drawing.Point(409, 304);
            this.label_addnoise.Name = "label_addnoise";
            this.label_addnoise.Size = new System.Drawing.Size(90, 19);
            this.label_addnoise.TabIndex = 27;
            this.label_addnoise.Text = "Add Noise";
            this.label_addnoise.Visible = false;
            // 
            // label_resultimg
            // 
            this.label_resultimg.AutoSize = true;
            this.label_resultimg.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_resultimg.ForeColor = System.Drawing.Color.Orange;
            this.label_resultimg.Location = new System.Drawing.Point(701, 304);
            this.label_resultimg.Name = "label_resultimg";
            this.label_resultimg.Size = new System.Drawing.Size(117, 19);
            this.label_resultimg.TabIndex = 28;
            this.label_resultimg.Text = "Result Image";
            this.label_resultimg.Visible = false;
            // 
            // groupBox_filter
            // 
            this.groupBox_filter.Controls.Add(this.label_T);
            this.groupBox_filter.Controls.Add(this.trackBar1);
            this.groupBox_filter.Controls.Add(this.radioButton_Average);
            this.groupBox_filter.Controls.Add(this.radioButton_Median);
            this.groupBox_filter.Controls.Add(this.radioButton_Outlier);
            this.groupBox_filter.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_filter.ForeColor = System.Drawing.Color.Orange;
            this.groupBox_filter.Location = new System.Drawing.Point(30, 369);
            this.groupBox_filter.Name = "groupBox_filter";
            this.groupBox_filter.Size = new System.Drawing.Size(256, 178);
            this.groupBox_filter.TabIndex = 29;
            this.groupBox_filter.TabStop = false;
            this.groupBox_filter.Text = "Filter";
            // 
            // label_T
            // 
            this.label_T.AutoSize = true;
            this.label_T.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_T.ForeColor = System.Drawing.Color.Orange;
            this.label_T.Location = new System.Drawing.Point(202, 143);
            this.label_T.Name = "label_T";
            this.label_T.Size = new System.Drawing.Size(35, 15);
            this.label_T.TabIndex = 35;
            this.label_T.Text = "T:XX";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(205, 14);
            this.trackBar1.Maximum = 127;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 137);
            this.trackBar1.TabIndex = 34;
            this.trackBar1.TickFrequency = 16;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // radioButton_Average
            // 
            this.radioButton_Average.AutoSize = true;
            this.radioButton_Average.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Average.Location = new System.Drawing.Point(28, 135);
            this.radioButton_Average.Name = "radioButton_Average";
            this.radioButton_Average.Size = new System.Drawing.Size(90, 23);
            this.radioButton_Average.TabIndex = 33;
            this.radioButton_Average.TabStop = true;
            this.radioButton_Average.Text = "Average";
            this.radioButton_Average.UseVisualStyleBackColor = true;
            this.radioButton_Average.CheckedChanged += new System.EventHandler(this.radioButton_Average_CheckedChanged);
            // 
            // radioButton_Median
            // 
            this.radioButton_Median.AutoSize = true;
            this.radioButton_Median.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Median.Location = new System.Drawing.Point(28, 80);
            this.radioButton_Median.Name = "radioButton_Median";
            this.radioButton_Median.Size = new System.Drawing.Size(81, 23);
            this.radioButton_Median.TabIndex = 32;
            this.radioButton_Median.TabStop = true;
            this.radioButton_Median.Text = "Median";
            this.radioButton_Median.UseVisualStyleBackColor = true;
            this.radioButton_Median.CheckedChanged += new System.EventHandler(this.radioButton_Median_CheckedChanged);
            // 
            // radioButton_Outlier
            // 
            this.radioButton_Outlier.AutoSize = true;
            this.radioButton_Outlier.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Outlier.Location = new System.Drawing.Point(28, 25);
            this.radioButton_Outlier.Name = "radioButton_Outlier";
            this.radioButton_Outlier.Size = new System.Drawing.Size(90, 23);
            this.radioButton_Outlier.TabIndex = 31;
            this.radioButton_Outlier.TabStop = true;
            this.radioButton_Outlier.Text = "Outlier";
            this.radioButton_Outlier.UseVisualStyleBackColor = true;
            this.radioButton_Outlier.CheckedChanged += new System.EventHandler(this.radioButton_Outlier_CheckedChanged);
            // 
            // groupBox_size
            // 
            this.groupBox_size.Controls.Add(this.radioButton_mask7);
            this.groupBox_size.Controls.Add(this.radioButton_mask5);
            this.groupBox_size.Controls.Add(this.radioButton_mask3);
            this.groupBox_size.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_size.ForeColor = System.Drawing.Color.Orange;
            this.groupBox_size.Location = new System.Drawing.Point(330, 369);
            this.groupBox_size.Name = "groupBox_size";
            this.groupBox_size.Size = new System.Drawing.Size(256, 62);
            this.groupBox_size.TabIndex = 30;
            this.groupBox_size.TabStop = false;
            this.groupBox_size.Text = "Size";
            // 
            // radioButton_mask7
            // 
            this.radioButton_mask7.AutoSize = true;
            this.radioButton_mask7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_mask7.Location = new System.Drawing.Point(169, 25);
            this.radioButton_mask7.Name = "radioButton_mask7";
            this.radioButton_mask7.Size = new System.Drawing.Size(72, 23);
            this.radioButton_mask7.TabIndex = 34;
            this.radioButton_mask7.TabStop = true;
            this.radioButton_mask7.Text = "7 x 7";
            this.radioButton_mask7.UseVisualStyleBackColor = true;
            // 
            // radioButton_mask5
            // 
            this.radioButton_mask5.AutoSize = true;
            this.radioButton_mask5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_mask5.ForeColor = System.Drawing.Color.Orange;
            this.radioButton_mask5.Location = new System.Drawing.Point(91, 25);
            this.radioButton_mask5.Name = "radioButton_mask5";
            this.radioButton_mask5.Size = new System.Drawing.Size(72, 23);
            this.radioButton_mask5.TabIndex = 33;
            this.radioButton_mask5.TabStop = true;
            this.radioButton_mask5.Text = "5 x 5";
            this.radioButton_mask5.UseVisualStyleBackColor = true;
            // 
            // radioButton_mask3
            // 
            this.radioButton_mask3.AutoSize = true;
            this.radioButton_mask3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_mask3.Location = new System.Drawing.Point(11, 25);
            this.radioButton_mask3.Name = "radioButton_mask3";
            this.radioButton_mask3.Size = new System.Drawing.Size(72, 23);
            this.radioButton_mask3.TabIndex = 32;
            this.radioButton_mask3.TabStop = true;
            this.radioButton_mask3.Text = "3 x 3";
            this.radioButton_mask3.UseVisualStyleBackColor = true;
            // 
            // groupBox_method
            // 
            this.groupBox_method.Controls.Add(this.radioButton_Pseudo);
            this.groupBox_method.Controls.Add(this.radioButton_Cross);
            this.groupBox_method.Controls.Add(this.radioButton_Square);
            this.groupBox_method.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_method.ForeColor = System.Drawing.Color.Orange;
            this.groupBox_method.Location = new System.Drawing.Point(330, 443);
            this.groupBox_method.Name = "groupBox_method";
            this.groupBox_method.Size = new System.Drawing.Size(256, 62);
            this.groupBox_method.TabIndex = 37;
            this.groupBox_method.TabStop = false;
            this.groupBox_method.Text = "Method";
            this.groupBox_method.Visible = false;
            // 
            // radioButton_Pseudo
            // 
            this.radioButton_Pseudo.AutoSize = true;
            this.radioButton_Pseudo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Pseudo.Location = new System.Drawing.Point(169, 22);
            this.radioButton_Pseudo.Name = "radioButton_Pseudo";
            this.radioButton_Pseudo.Size = new System.Drawing.Size(81, 23);
            this.radioButton_Pseudo.TabIndex = 34;
            this.radioButton_Pseudo.TabStop = true;
            this.radioButton_Pseudo.Text = "Pseudo";
            this.radioButton_Pseudo.UseVisualStyleBackColor = true;
            this.radioButton_Pseudo.CheckedChanged += new System.EventHandler(this.radioButton_Pseudo_CheckedChanged);
            // 
            // radioButton_Cross
            // 
            this.radioButton_Cross.AutoSize = true;
            this.radioButton_Cross.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Cross.Location = new System.Drawing.Point(91, 22);
            this.radioButton_Cross.Name = "radioButton_Cross";
            this.radioButton_Cross.Size = new System.Drawing.Size(72, 23);
            this.radioButton_Cross.TabIndex = 33;
            this.radioButton_Cross.TabStop = true;
            this.radioButton_Cross.Text = "Cross";
            this.radioButton_Cross.UseVisualStyleBackColor = true;
            this.radioButton_Cross.CheckedChanged += new System.EventHandler(this.radioButton_Cross_CheckedChanged);
            // 
            // radioButton_Square
            // 
            this.radioButton_Square.AutoSize = true;
            this.radioButton_Square.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Square.Location = new System.Drawing.Point(11, 22);
            this.radioButton_Square.Name = "radioButton_Square";
            this.radioButton_Square.Size = new System.Drawing.Size(81, 23);
            this.radioButton_Square.TabIndex = 32;
            this.radioButton_Square.TabStop = true;
            this.radioButton_Square.Text = "Square";
            this.radioButton_Square.UseVisualStyleBackColor = true;
            this.radioButton_Square.CheckedChanged += new System.EventHandler(this.radioButton_Square_CheckedChanged);
            // 
            // pictureBox_Button_AddNoise
            // 
            this.pictureBox_Button_AddNoise.Image = global::imp_pj.Properties.Resources.salt_and_pepper__3_;
            this.pictureBox_Button_AddNoise.Location = new System.Drawing.Point(244, 304);
            this.pictureBox_Button_AddNoise.Name = "pictureBox_Button_AddNoise";
            this.pictureBox_Button_AddNoise.Size = new System.Drawing.Size(42, 39);
            this.pictureBox_Button_AddNoise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Button_AddNoise.TabIndex = 38;
            this.pictureBox_Button_AddNoise.TabStop = false;
            this.pictureBox_Button_AddNoise.Click += new System.EventHandler(this.pictureBox_botton_AddNoise_Click);
            // 
            // label_noiseSNR
            // 
            this.label_noiseSNR.AutoSize = true;
            this.label_noiseSNR.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_noiseSNR.ForeColor = System.Drawing.Color.Orange;
            this.label_noiseSNR.Location = new System.Drawing.Point(502, 324);
            this.label_noiseSNR.Name = "label_noiseSNR";
            this.label_noiseSNR.Size = new System.Drawing.Size(84, 15);
            this.label_noiseSNR.TabIndex = 39;
            this.label_noiseSNR.Text = "SNR: XX.XXX";
            this.label_noiseSNR.Visible = false;
            // 
            // label_resultSNR
            // 
            this.label_resultSNR.AutoSize = true;
            this.label_resultSNR.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_resultSNR.ForeColor = System.Drawing.Color.Orange;
            this.label_resultSNR.Location = new System.Drawing.Point(802, 324);
            this.label_resultSNR.Name = "label_resultSNR";
            this.label_resultSNR.Size = new System.Drawing.Size(84, 15);
            this.label_resultSNR.TabIndex = 40;
            this.label_resultSNR.Text = "SNR: XX.XXX";
            this.label_resultSNR.Visible = false;
            // 
            // pictureBox_clickOK
            // 
            this.pictureBox_clickOK.Image = global::imp_pj.Properties.Resources.ok;
            this.pictureBox_clickOK.Location = new System.Drawing.Point(544, 512);
            this.pictureBox_clickOK.Name = "pictureBox_clickOK";
            this.pictureBox_clickOK.Size = new System.Drawing.Size(42, 39);
            this.pictureBox_clickOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_clickOK.TabIndex = 41;
            this.pictureBox_clickOK.TabStop = false;
            this.pictureBox_clickOK.Click += new System.EventHandler(this.pictureBox_clickOK_Click);
            // 
            // Lowpass_Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.pictureBox_clickOK);
            this.Controls.Add(this.label_resultSNR);
            this.Controls.Add(this.label_noiseSNR);
            this.Controls.Add(this.pictureBox_Button_AddNoise);
            this.Controls.Add(this.groupBox_method);
            this.Controls.Add(this.groupBox_size);
            this.Controls.Add(this.groupBox_filter);
            this.Controls.Add(this.label_resultimg);
            this.Controls.Add(this.label_addnoise);
            this.Controls.Add(this.label_originimg);
            this.Controls.Add(this.pictureBox_Result);
            this.Controls.Add(this.pictureBox_AddNoise);
            this.Controls.Add(this.pictureBox_Source);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Lowpass_Filter";
            this.Text = "Lowpass_Filter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AddNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Result)).EndInit();
            this.groupBox_filter.ResumeLayout(false);
            this.groupBox_filter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox_size.ResumeLayout(false);
            this.groupBox_size.PerformLayout();
            this.groupBox_method.ResumeLayout(false);
            this.groupBox_method.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Button_AddNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_clickOK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Source;
        private System.Windows.Forms.PictureBox pictureBox_AddNoise;
        private System.Windows.Forms.PictureBox pictureBox_Result;
        private System.Windows.Forms.Label label_originimg;
        private System.Windows.Forms.Label label_addnoise;
        private System.Windows.Forms.Label label_resultimg;
        private System.Windows.Forms.GroupBox groupBox_filter;
        private System.Windows.Forms.RadioButton radioButton_Average;
        private System.Windows.Forms.RadioButton radioButton_Median;
        private System.Windows.Forms.RadioButton radioButton_Outlier;
        private System.Windows.Forms.GroupBox groupBox_size;
        private System.Windows.Forms.RadioButton radioButton_mask7;
        private System.Windows.Forms.RadioButton radioButton_mask5;
        private System.Windows.Forms.RadioButton radioButton_mask3;
        private System.Windows.Forms.GroupBox groupBox_method;
        private System.Windows.Forms.RadioButton radioButton_Pseudo;
        private System.Windows.Forms.RadioButton radioButton_Cross;
        private System.Windows.Forms.RadioButton radioButton_Square;
        private Label label_T;
        private TrackBar trackBar1;
        private PictureBox pictureBox_Button_AddNoise;
        private Label label_noiseSNR;
        private Label label_resultSNR;
        private PictureBox pictureBox_clickOK;
    }
}