namespace imp_pj
{
    partial class Threshold
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
            this.pictureBox_Result = new System.Windows.Forms.PictureBox();
            this.trackBar_Threshing = new System.Windows.Forms.TrackBar();
            this.label_Ori = new System.Windows.Forms.Label();
            this.label_Result = new System.Windows.Forms.Label();
            this.label_T = new System.Windows.Forms.Label();
            this.textBox_Threshing = new System.Windows.Forms.TextBox();
            this.label_mode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threshing)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Source
            // 
            this.pictureBox_Source.Location = new System.Drawing.Point(47, 46);
            this.pictureBox_Source.Name = "pictureBox_Source";
            this.pictureBox_Source.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Source.TabIndex = 0;
            this.pictureBox_Source.TabStop = false;
            // 
            // pictureBox_Result
            // 
            this.pictureBox_Result.Location = new System.Drawing.Point(450, 46);
            this.pictureBox_Result.Name = "pictureBox_Result";
            this.pictureBox_Result.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Result.TabIndex = 1;
            this.pictureBox_Result.TabStop = false;
            // 
            // trackBar_Threshing
            // 
            this.trackBar_Threshing.Location = new System.Drawing.Point(43, 362);
            this.trackBar_Threshing.Maximum = 255;
            this.trackBar_Threshing.Name = "trackBar_Threshing";
            this.trackBar_Threshing.Size = new System.Drawing.Size(663, 45);
            this.trackBar_Threshing.TabIndex = 2;
            this.trackBar_Threshing.Scroll += new System.EventHandler(this.trackBar_Threshing_Scroll);
            // 
            // label_Ori
            // 
            this.label_Ori.AutoSize = true;
            this.label_Ori.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ori.Location = new System.Drawing.Point(106, 305);
            this.label_Ori.Name = "label_Ori";
            this.label_Ori.Size = new System.Drawing.Size(130, 22);
            this.label_Ori.TabIndex = 3;
            this.label_Ori.Text = "Origin Image";
            // 
            // label_Result
            // 
            this.label_Result.AutoSize = true;
            this.label_Result.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Result.Location = new System.Drawing.Point(522, 305);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(130, 22);
            this.label_Result.TabIndex = 4;
            this.label_Result.Text = "Result Image";
            // 
            // label_T
            // 
            this.label_T.AutoSize = true;
            this.label_T.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_T.Location = new System.Drawing.Point(17, 362);
            this.label_T.Name = "label_T";
            this.label_T.Size = new System.Drawing.Size(22, 24);
            this.label_T.TabIndex = 5;
            this.label_T.Text = "T";
            // 
            // textBox_Threshing
            // 
            this.textBox_Threshing.BackColor = System.Drawing.Color.Lavender;
            this.textBox_Threshing.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Threshing.Location = new System.Drawing.Point(709, 358);
            this.textBox_Threshing.Name = "textBox_Threshing";
            this.textBox_Threshing.Size = new System.Drawing.Size(40, 26);
            this.textBox_Threshing.TabIndex = 6;
            // 
            // label_mode
            // 
            this.label_mode.AutoSize = true;
            this.label_mode.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mode.Location = new System.Drawing.Point(276, 9);
            this.label_mode.Name = "label_mode";
            this.label_mode.Size = new System.Drawing.Size(0, 22);
            this.label_mode.TabIndex = 7;
            // 
            // Threshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(761, 422);
            this.Controls.Add(this.label_mode);
            this.Controls.Add(this.textBox_Threshing);
            this.Controls.Add(this.label_T);
            this.Controls.Add(this.label_Result);
            this.Controls.Add(this.label_Ori);
            this.Controls.Add(this.trackBar_Threshing);
            this.Controls.Add(this.pictureBox_Result);
            this.Controls.Add(this.pictureBox_Source);
            this.Name = "Threshold";
            this.Text = "Threshold";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threshing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Source;
        private System.Windows.Forms.PictureBox pictureBox_Result;
        private System.Windows.Forms.TrackBar trackBar_Threshing;
        private System.Windows.Forms.Label label_Ori;
        private System.Windows.Forms.Label label_Result;
        private System.Windows.Forms.Label label_T;
        private System.Windows.Forms.TextBox textBox_Threshing;
        private System.Windows.Forms.Label label_mode;
    }
}