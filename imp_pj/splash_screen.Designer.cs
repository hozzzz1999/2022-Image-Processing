namespace imp_pj
{
    partial class Splash_screen
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_CopyRight = new System.Windows.Forms.Label();
            this.label_ImageProcessing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 222);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(490, 3);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // label_CopyRight
            // 
            this.label_CopyRight.AutoSize = true;
            this.label_CopyRight.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CopyRight.Location = new System.Drawing.Point(378, 207);
            this.label_CopyRight.Name = "label_CopyRight";
            this.label_CopyRight.Size = new System.Drawing.Size(112, 15);
            this.label_CopyRight.TabIndex = 1;
            this.label_CopyRight.Text = "Copyright @ Hoz";
            // 
            // label_ImageProcessing
            // 
            this.label_ImageProcessing.AutoSize = true;
            this.label_ImageProcessing.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ImageProcessing.Location = new System.Drawing.Point(25, 90);
            this.label_ImageProcessing.Name = "label_ImageProcessing";
            this.label_ImageProcessing.Size = new System.Drawing.Size(440, 56);
            this.label_ImageProcessing.TabIndex = 2;
            this.label_ImageProcessing.Text = "Image Processing";
            // 
            // splash_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::imp_pj.Properties.Resources.splashscreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(490, 225);
            this.Controls.Add(this.label_ImageProcessing);
            this.Controls.Add(this.label_CopyRight);
            this.Controls.Add(this.progressBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "splash_screen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "splash_screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_CopyRight;
        private System.Windows.Forms.Label label_ImageProcessing;
    }
}