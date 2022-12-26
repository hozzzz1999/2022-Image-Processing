namespace imp_pj
{
    partial class contrastPreset
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox_result = new System.Windows.Forms.PictureBox();
            this.pictureBox_source = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_source)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(508, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "After";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(116, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "Before";
            // 
            // pictureBox_result
            // 
            this.pictureBox_result.Location = new System.Drawing.Point(425, 48);
            this.pictureBox_result.Name = "pictureBox_result";
            this.pictureBox_result.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_result.TabIndex = 17;
            this.pictureBox_result.TabStop = false;
            // 
            // pictureBox_source
            // 
            this.pictureBox_source.Location = new System.Drawing.Point(33, 46);
            this.pictureBox_source.Name = "pictureBox_source";
            this.pictureBox_source.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_source.TabIndex = 16;
            this.pictureBox_source.TabStop = false;
            // 
            // contrastPreset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(713, 331);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox_result);
            this.Controls.Add(this.pictureBox_source);
            this.Name = "contrastPreset";
            this.Text = "contrastPreset";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_source)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox_result;
        private System.Windows.Forms.PictureBox pictureBox_source;
    }
}