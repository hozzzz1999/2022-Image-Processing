namespace imp_pj
{
    partial class magicwand
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
            this.pictureBox_source = new System.Windows.Forms.PictureBox();
            this.pictureBox_result = new System.Windows.Forms.PictureBox();
            this.label_source = new System.Windows.Forms.Label();
            this.label_result = new System.Windows.Forms.Label();
            this.label_point = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_result)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_source
            // 
            this.pictureBox_source.Location = new System.Drawing.Point(55, 62);
            this.pictureBox_source.Name = "pictureBox_source";
            this.pictureBox_source.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_source.TabIndex = 7;
            this.pictureBox_source.TabStop = false;
            this.pictureBox_source.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_source_Paint);
            this.pictureBox_source.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_source_MouseClick);
            this.pictureBox_source.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_source_MouseDown);
            this.pictureBox_source.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_source_MouseMove);
            this.pictureBox_source.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_source_MouseUp);
            // 
            // pictureBox_result
            // 
            this.pictureBox_result.Location = new System.Drawing.Point(474, 62);
            this.pictureBox_result.Name = "pictureBox_result";
            this.pictureBox_result.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_result.TabIndex = 8;
            this.pictureBox_result.TabStop = false;
            // 
            // label_source
            // 
            this.label_source.AutoSize = true;
            this.label_source.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_source.Location = new System.Drawing.Point(121, 40);
            this.label_source.Name = "label_source";
            this.label_source.Size = new System.Drawing.Size(117, 19);
            this.label_source.TabIndex = 14;
            this.label_source.Text = "Origin image";
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_result.Location = new System.Drawing.Point(549, 40);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(117, 19);
            this.label_result.TabIndex = 15;
            this.label_result.Text = "Result image";
            // 
            // label_point
            // 
            this.label_point.AutoSize = true;
            this.label_point.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_point.Location = new System.Drawing.Point(51, 333);
            this.label_point.Name = "label_point";
            this.label_point.Size = new System.Drawing.Size(117, 38);
            this.label_point.TabIndex = 16;
            this.label_point.Text = "start point:\r\nend point:";
            // 
            // magicwand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_point);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.label_source);
            this.Controls.Add(this.pictureBox_result);
            this.Controls.Add(this.pictureBox_source);
            this.Name = "magicwand";
            this.Text = "magicwand";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_source;
        private System.Windows.Forms.PictureBox pictureBox_result;
        private System.Windows.Forms.Label label_source;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.Label label_point;
    }
}