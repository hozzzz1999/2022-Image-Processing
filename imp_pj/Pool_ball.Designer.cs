namespace imp_pj
{
    partial class PoolBall
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
            this.pictureBox_ball = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ball)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_ball
            // 
            this.pictureBox_ball.Image = global::imp_pj.Properties.Resources.ball;
            this.pictureBox_ball.Location = new System.Drawing.Point(58, 85);
            this.pictureBox_ball.Name = "pictureBox_ball";
            this.pictureBox_ball.Size = new System.Drawing.Size(76, 75);
            this.pictureBox_ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ball.TabIndex = 0;
            this.pictureBox_ball.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 45;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PoolBall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(497, 428);
            this.Controls.Add(this.pictureBox_ball);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PoolBall";
            this.ShowIcon = false;
            this.Text = "pool_ball";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ball)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ball;
        private System.Windows.Forms.Timer timer1;
    }
}