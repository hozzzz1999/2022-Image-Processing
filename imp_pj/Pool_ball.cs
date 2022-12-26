using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace imp_pj
{
    public partial class PoolBall : Form
    {
        Random rand = new Random();
        public PoolBall()
        {
            InitializeComponent();
            this.pictureBox_ball.BackColor = Color.Transparent;
            //DoubleBuffered才不會有背景閃爍
            this.DoubleBuffered = true;
        }
        public PoolBall(Bitmap source)
        {
            this.BackgroundImage = source;
            InitializeComponent();
            //調整背景視窗大小
            this.Width = this.BackgroundImage.Width + 13;
            this.Height = this.BackgroundImage.Height + 39;
            //球背景透明
            this.pictureBox_ball.BackColor = Color.Transparent;
            //DoubleBuffered才不會有背景閃爍
            this.DoubleBuffered = true;
            int randX, randY;
            randX = rand.Next() % pictureBox_ball.Width;
            randY = rand.Next() % pictureBox_ball.Height;
            pictureBox_ball.Location = new Point(randX, randY);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | //不擦除背景 ,減少閃爍
               ControlStyles.OptimizedDoubleBuffer | //雙緩衝
                ControlStyles.UserPaint, //使用自定義的重繪事件,減少閃爍
                true);
        }
        //水平和垂直移動距離 訂為5個pixel
        int stepX = 5, stepY = 5;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //(0.0)左上
            //水平方向 若球座標X+球寬度>視窗(右) 或是 球的座標X小於0(左) -> 球超出視窗
            if ((pictureBox_ball.Location.X + pictureBox_ball.Width) > this.ClientSize.Width || pictureBox_ball.Location.X < 0)
            {
                //正轉負，負轉正 -> 轉換方向
                stepX = 0 - stepX;
            }
            //垂直方向 若球座標Y+球高度>視窗(下) 或是 球的Y座標小於0(上) -> 球超出視窗
            if ((pictureBox_ball.Location.Y + pictureBox_ball.Height) > this.ClientSize.Height || pictureBox_ball.Location.Y < 0)
            {
                //正轉負，負轉正 -> 轉換方向
                stepY = 0 - stepY;
            }
            //若無碰到邊就+1個step長度(5pixel)
            pictureBox_ball.Location = new Point(pictureBox_ball.Location.X + stepX, pictureBox_ball.Location.Y + stepY);
        }
    }
}
