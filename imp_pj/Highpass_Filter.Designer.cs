namespace imp_pj
{
    partial class Highpass_Filter
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
            this.pictureBox_clickOK = new System.Windows.Forms.PictureBox();
            this.pictureBox_NegativeClick = new System.Windows.Forms.PictureBox();
            this.groupBox_method = new System.Windows.Forms.GroupBox();
            this.radioButton_Roberts = new System.Windows.Forms.RadioButton();
            this.radioButton_Prewitt = new System.Windows.Forms.RadioButton();
            this.radioButton_Sobel = new System.Windows.Forms.RadioButton();
            this.groupBox_size = new System.Windows.Forms.GroupBox();
            this.radioButton_mask7 = new System.Windows.Forms.RadioButton();
            this.radioButton_mask5 = new System.Windows.Forms.RadioButton();
            this.radioButton_mask3 = new System.Windows.Forms.RadioButton();
            this.groupBox_filter = new System.Windows.Forms.GroupBox();
            this.radioButton_gradient = new System.Windows.Forms.RadioButton();
            this.radioButton_highboost = new System.Windows.Forms.RadioButton();
            this.radioButton_edge = new System.Windows.Forms.RadioButton();
            this.label_light = new System.Windows.Forms.Label();
            this.label_Result = new System.Windows.Forms.Label();
            this.label_originimg = new System.Windows.Forms.Label();
            this.pictureBox_negative = new System.Windows.Forms.PictureBox();
            this.pictureBox_Result = new System.Windows.Forms.PictureBox();
            this.pictureBox_Source = new System.Windows.Forms.PictureBox();
            this.label_alphavalue = new System.Windows.Forms.Label();
            this.textBox_alpha = new System.Windows.Forms.TextBox();
            this.groupBox_XorY = new System.Windows.Forms.GroupBox();
            this.radioButton_sobelXY = new System.Windows.Forms.RadioButton();
            this.radioButton_sobleY = new System.Windows.Forms.RadioButton();
            this.radioButton_sobelX = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_clickOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NegativeClick)).BeginInit();
            this.groupBox_method.SuspendLayout();
            this.groupBox_size.SuspendLayout();
            this.groupBox_filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_negative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Source)).BeginInit();
            this.groupBox_XorY.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_clickOK
            // 
            this.pictureBox_clickOK.Image = global::imp_pj.Properties.Resources.ok;
            this.pictureBox_clickOK.Location = new System.Drawing.Point(581, 491);
            this.pictureBox_clickOK.Name = "pictureBox_clickOK";
            this.pictureBox_clickOK.Size = new System.Drawing.Size(42, 39);
            this.pictureBox_clickOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_clickOK.TabIndex = 54;
            this.pictureBox_clickOK.TabStop = false;
            this.pictureBox_clickOK.Click += new System.EventHandler(this.pictureBox_clickOK_Click);
            // 
            // pictureBox_NegativeClick
            // 
            this.pictureBox_NegativeClick.Image = global::imp_pj.Properties.Resources.lightbulb;
            this.pictureBox_NegativeClick.Location = new System.Drawing.Point(281, 283);
            this.pictureBox_NegativeClick.Name = "pictureBox_NegativeClick";
            this.pictureBox_NegativeClick.Size = new System.Drawing.Size(42, 39);
            this.pictureBox_NegativeClick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_NegativeClick.TabIndex = 51;
            this.pictureBox_NegativeClick.TabStop = false;
            this.pictureBox_NegativeClick.Visible = false;
            this.pictureBox_NegativeClick.Click += new System.EventHandler(this.pictureBox_Negative_Click);
            // 
            // groupBox_method
            // 
            this.groupBox_method.Controls.Add(this.radioButton_Roberts);
            this.groupBox_method.Controls.Add(this.radioButton_Prewitt);
            this.groupBox_method.Controls.Add(this.radioButton_Sobel);
            this.groupBox_method.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_method.ForeColor = System.Drawing.Color.Orange;
            this.groupBox_method.Location = new System.Drawing.Point(367, 422);
            this.groupBox_method.Name = "groupBox_method";
            this.groupBox_method.Size = new System.Drawing.Size(256, 62);
            this.groupBox_method.TabIndex = 50;
            this.groupBox_method.TabStop = false;
            this.groupBox_method.Text = "Method";
            this.groupBox_method.Visible = false;
            // 
            // radioButton_Roberts
            // 
            this.radioButton_Roberts.AutoSize = true;
            this.radioButton_Roberts.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Roberts.Location = new System.Drawing.Point(163, 22);
            this.radioButton_Roberts.Name = "radioButton_Roberts";
            this.radioButton_Roberts.Size = new System.Drawing.Size(90, 23);
            this.radioButton_Roberts.TabIndex = 34;
            this.radioButton_Roberts.TabStop = true;
            this.radioButton_Roberts.Text = "Roberts";
            this.radioButton_Roberts.UseVisualStyleBackColor = true;
            this.radioButton_Roberts.CheckedChanged += new System.EventHandler(this.radioButton_Roberts_CheckedChanged);
            // 
            // radioButton_Prewitt
            // 
            this.radioButton_Prewitt.AutoSize = true;
            this.radioButton_Prewitt.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Prewitt.Location = new System.Drawing.Point(76, 22);
            this.radioButton_Prewitt.Name = "radioButton_Prewitt";
            this.radioButton_Prewitt.Size = new System.Drawing.Size(90, 23);
            this.radioButton_Prewitt.TabIndex = 33;
            this.radioButton_Prewitt.TabStop = true;
            this.radioButton_Prewitt.Text = "Prewitt";
            this.radioButton_Prewitt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton_Prewitt.UseVisualStyleBackColor = true;
            this.radioButton_Prewitt.CheckedChanged += new System.EventHandler(this.radioButton_Prewitt_CheckedChanged);
            // 
            // radioButton_Sobel
            // 
            this.radioButton_Sobel.AutoSize = true;
            this.radioButton_Sobel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Sobel.Location = new System.Drawing.Point(7, 22);
            this.radioButton_Sobel.Name = "radioButton_Sobel";
            this.radioButton_Sobel.Size = new System.Drawing.Size(72, 23);
            this.radioButton_Sobel.TabIndex = 32;
            this.radioButton_Sobel.TabStop = true;
            this.radioButton_Sobel.Text = "Sobel";
            this.radioButton_Sobel.UseVisualStyleBackColor = true;
            this.radioButton_Sobel.CheckedChanged += new System.EventHandler(this.radioButton_Sobel_CheckedChanged);
            // 
            // groupBox_size
            // 
            this.groupBox_size.Controls.Add(this.radioButton_mask7);
            this.groupBox_size.Controls.Add(this.radioButton_mask5);
            this.groupBox_size.Controls.Add(this.radioButton_mask3);
            this.groupBox_size.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_size.ForeColor = System.Drawing.Color.Orange;
            this.groupBox_size.Location = new System.Drawing.Point(367, 348);
            this.groupBox_size.Name = "groupBox_size";
            this.groupBox_size.Size = new System.Drawing.Size(256, 62);
            this.groupBox_size.TabIndex = 49;
            this.groupBox_size.TabStop = false;
            this.groupBox_size.Text = "Size";
            this.groupBox_size.Visible = false;
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
            this.radioButton_mask5.Location = new System.Drawing.Point(89, 25);
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
            // groupBox_filter
            // 
            this.groupBox_filter.Controls.Add(this.radioButton_gradient);
            this.groupBox_filter.Controls.Add(this.radioButton_highboost);
            this.groupBox_filter.Controls.Add(this.radioButton_edge);
            this.groupBox_filter.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_filter.ForeColor = System.Drawing.Color.Orange;
            this.groupBox_filter.Location = new System.Drawing.Point(67, 348);
            this.groupBox_filter.Name = "groupBox_filter";
            this.groupBox_filter.Size = new System.Drawing.Size(256, 178);
            this.groupBox_filter.TabIndex = 48;
            this.groupBox_filter.TabStop = false;
            this.groupBox_filter.Text = "Filter";
            // 
            // radioButton_gradient
            // 
            this.radioButton_gradient.AutoSize = true;
            this.radioButton_gradient.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_gradient.Location = new System.Drawing.Point(28, 135);
            this.radioButton_gradient.Name = "radioButton_gradient";
            this.radioButton_gradient.Size = new System.Drawing.Size(99, 23);
            this.radioButton_gradient.TabIndex = 33;
            this.radioButton_gradient.TabStop = true;
            this.radioButton_gradient.Text = "Gradient";
            this.radioButton_gradient.UseVisualStyleBackColor = true;
            this.radioButton_gradient.CheckedChanged += new System.EventHandler(this.radioButton_gradient_CheckedChanged);
            // 
            // radioButton_highboost
            // 
            this.radioButton_highboost.AutoSize = true;
            this.radioButton_highboost.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_highboost.Location = new System.Drawing.Point(28, 80);
            this.radioButton_highboost.Name = "radioButton_highboost";
            this.radioButton_highboost.Size = new System.Drawing.Size(108, 23);
            this.radioButton_highboost.TabIndex = 32;
            this.radioButton_highboost.TabStop = true;
            this.radioButton_highboost.Text = "Highboost";
            this.radioButton_highboost.UseVisualStyleBackColor = true;
            this.radioButton_highboost.CheckedChanged += new System.EventHandler(this.radioButton_highboost_CheckedChanged);
            // 
            // radioButton_edge
            // 
            this.radioButton_edge.AutoSize = true;
            this.radioButton_edge.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_edge.Location = new System.Drawing.Point(28, 25);
            this.radioButton_edge.Name = "radioButton_edge";
            this.radioButton_edge.Size = new System.Drawing.Size(162, 23);
            this.radioButton_edge.TabIndex = 31;
            this.radioButton_edge.TabStop = true;
            this.radioButton_edge.Text = "Edge Crispening";
            this.radioButton_edge.UseVisualStyleBackColor = true;
            this.radioButton_edge.CheckedChanged += new System.EventHandler(this.radioButton_edge_CheckedChanged);
            // 
            // label_light
            // 
            this.label_light.AutoSize = true;
            this.label_light.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_light.ForeColor = System.Drawing.Color.Orange;
            this.label_light.Location = new System.Drawing.Point(727, 283);
            this.label_light.Name = "label_light";
            this.label_light.Size = new System.Drawing.Size(135, 19);
            this.label_light.TabIndex = 47;
            this.label_light.Text = "Negative image";
            this.label_light.Visible = false;
            // 
            // label_Result
            // 
            this.label_Result.AutoSize = true;
            this.label_Result.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Result.ForeColor = System.Drawing.Color.Orange;
            this.label_Result.Location = new System.Drawing.Point(446, 283);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(117, 19);
            this.label_Result.TabIndex = 46;
            this.label_Result.Text = "Result image";
            this.label_Result.Visible = false;
            // 
            // label_originimg
            // 
            this.label_originimg.AutoSize = true;
            this.label_originimg.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_originimg.ForeColor = System.Drawing.Color.Orange;
            this.label_originimg.Location = new System.Drawing.Point(128, 283);
            this.label_originimg.Name = "label_originimg";
            this.label_originimg.Size = new System.Drawing.Size(117, 19);
            this.label_originimg.TabIndex = 45;
            this.label_originimg.Text = "Origin Image";
            // 
            // pictureBox_negative
            // 
            this.pictureBox_negative.Location = new System.Drawing.Point(667, 24);
            this.pictureBox_negative.Name = "pictureBox_negative";
            this.pictureBox_negative.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_negative.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_negative.TabIndex = 44;
            this.pictureBox_negative.TabStop = false;
            // 
            // pictureBox_Result
            // 
            this.pictureBox_Result.Location = new System.Drawing.Point(367, 24);
            this.pictureBox_Result.Name = "pictureBox_Result";
            this.pictureBox_Result.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Result.TabIndex = 43;
            this.pictureBox_Result.TabStop = false;
            // 
            // pictureBox_Source
            // 
            this.pictureBox_Source.Location = new System.Drawing.Point(67, 24);
            this.pictureBox_Source.Name = "pictureBox_Source";
            this.pictureBox_Source.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Source.TabIndex = 42;
            this.pictureBox_Source.TabStop = false;
            // 
            // label_alphavalue
            // 
            this.label_alphavalue.AutoSize = true;
            this.label_alphavalue.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_alphavalue.ForeColor = System.Drawing.Color.Orange;
            this.label_alphavalue.Location = new System.Drawing.Point(370, 493);
            this.label_alphavalue.Name = "label_alphavalue";
            this.label_alphavalue.Size = new System.Drawing.Size(63, 19);
            this.label_alphavalue.TabIndex = 55;
            this.label_alphavalue.Text = "Alpha:";
            this.label_alphavalue.Visible = false;
            // 
            // textBox_alpha
            // 
            this.textBox_alpha.BackColor = System.Drawing.Color.Lavender;
            this.textBox_alpha.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_alpha.Location = new System.Drawing.Point(433, 493);
            this.textBox_alpha.MaxLength = 4;
            this.textBox_alpha.Name = "textBox_alpha";
            this.textBox_alpha.Size = new System.Drawing.Size(49, 26);
            this.textBox_alpha.TabIndex = 56;
            this.textBox_alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_alpha.Visible = false;
            // 
            // groupBox_XorY
            // 
            this.groupBox_XorY.Controls.Add(this.radioButton_sobelXY);
            this.groupBox_XorY.Controls.Add(this.radioButton_sobleY);
            this.groupBox_XorY.Controls.Add(this.radioButton_sobelX);
            this.groupBox_XorY.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_XorY.ForeColor = System.Drawing.Color.Orange;
            this.groupBox_XorY.Location = new System.Drawing.Point(667, 348);
            this.groupBox_XorY.Name = "groupBox_XorY";
            this.groupBox_XorY.Size = new System.Drawing.Size(256, 62);
            this.groupBox_XorY.TabIndex = 57;
            this.groupBox_XorY.TabStop = false;
            this.groupBox_XorY.Text = "X or Y";
            this.groupBox_XorY.Visible = false;
            // 
            // radioButton_sobelXY
            // 
            this.radioButton_sobelXY.AutoSize = true;
            this.radioButton_sobelXY.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_sobelXY.Location = new System.Drawing.Point(169, 25);
            this.radioButton_sobelXY.Name = "radioButton_sobelXY";
            this.radioButton_sobelXY.Size = new System.Drawing.Size(72, 23);
            this.radioButton_sobelXY.TabIndex = 34;
            this.radioButton_sobelXY.TabStop = true;
            this.radioButton_sobelXY.Text = "X + Y";
            this.radioButton_sobelXY.UseVisualStyleBackColor = true;
            this.radioButton_sobelXY.CheckedChanged += new System.EventHandler(this.radioButton_sobelXY_CheckedChanged);
            // 
            // radioButton_sobleY
            // 
            this.radioButton_sobleY.AutoSize = true;
            this.radioButton_sobleY.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_sobleY.ForeColor = System.Drawing.Color.Orange;
            this.radioButton_sobleY.Location = new System.Drawing.Point(89, 25);
            this.radioButton_sobleY.Name = "radioButton_sobleY";
            this.radioButton_sobleY.Size = new System.Drawing.Size(36, 23);
            this.radioButton_sobleY.TabIndex = 33;
            this.radioButton_sobleY.TabStop = true;
            this.radioButton_sobleY.Text = "Y";
            this.radioButton_sobleY.UseVisualStyleBackColor = true;
            // 
            // radioButton_sobelX
            // 
            this.radioButton_sobelX.AutoSize = true;
            this.radioButton_sobelX.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_sobelX.Location = new System.Drawing.Point(11, 25);
            this.radioButton_sobelX.Name = "radioButton_sobelX";
            this.radioButton_sobelX.Size = new System.Drawing.Size(36, 23);
            this.radioButton_sobelX.TabIndex = 32;
            this.radioButton_sobelX.TabStop = true;
            this.radioButton_sobelX.Text = "X";
            this.radioButton_sobelX.UseVisualStyleBackColor = true;
            // 
            // Highpass_Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(991, 555);
            this.Controls.Add(this.groupBox_XorY);
            this.Controls.Add(this.textBox_alpha);
            this.Controls.Add(this.label_alphavalue);
            this.Controls.Add(this.pictureBox_clickOK);
            this.Controls.Add(this.pictureBox_NegativeClick);
            this.Controls.Add(this.groupBox_method);
            this.Controls.Add(this.groupBox_size);
            this.Controls.Add(this.groupBox_filter);
            this.Controls.Add(this.label_light);
            this.Controls.Add(this.label_Result);
            this.Controls.Add(this.label_originimg);
            this.Controls.Add(this.pictureBox_negative);
            this.Controls.Add(this.pictureBox_Result);
            this.Controls.Add(this.pictureBox_Source);
            this.Name = "Highpass_Filter";
            this.Text = "Highpass_Filter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_clickOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NegativeClick)).EndInit();
            this.groupBox_method.ResumeLayout(false);
            this.groupBox_method.PerformLayout();
            this.groupBox_size.ResumeLayout(false);
            this.groupBox_size.PerformLayout();
            this.groupBox_filter.ResumeLayout(false);
            this.groupBox_filter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_negative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Source)).EndInit();
            this.groupBox_XorY.ResumeLayout(false);
            this.groupBox_XorY.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_clickOK;
        private System.Windows.Forms.PictureBox pictureBox_NegativeClick;
        private System.Windows.Forms.GroupBox groupBox_method;
        private System.Windows.Forms.RadioButton radioButton_Roberts;
        private System.Windows.Forms.RadioButton radioButton_Prewitt;
        private System.Windows.Forms.RadioButton radioButton_Sobel;
        private System.Windows.Forms.GroupBox groupBox_size;
        private System.Windows.Forms.RadioButton radioButton_mask7;
        private System.Windows.Forms.RadioButton radioButton_mask5;
        private System.Windows.Forms.RadioButton radioButton_mask3;
        private System.Windows.Forms.GroupBox groupBox_filter;
        private System.Windows.Forms.RadioButton radioButton_gradient;
        private System.Windows.Forms.RadioButton radioButton_highboost;
        private System.Windows.Forms.RadioButton radioButton_edge;
        private System.Windows.Forms.Label label_light;
        private System.Windows.Forms.Label label_Result;
        private System.Windows.Forms.Label label_originimg;
        private System.Windows.Forms.PictureBox pictureBox_negative;
        private System.Windows.Forms.PictureBox pictureBox_Result;
        private System.Windows.Forms.PictureBox pictureBox_Source;
        private System.Windows.Forms.Label label_alphavalue;
        private System.Windows.Forms.TextBox textBox_alpha;
        private System.Windows.Forms.GroupBox groupBox_XorY;
        private System.Windows.Forms.RadioButton radioButton_sobelXY;
        private System.Windows.Forms.RadioButton radioButton_sobleY;
        private System.Windows.Forms.RadioButton radioButton_sobelX;
    }
}