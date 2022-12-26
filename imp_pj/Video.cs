using imp_pj.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Timer = System.Windows.Forms.Timer;
using System.Windows.Forms.DataVisualization.Charting;

namespace imp_pj
{
    public partial class Video : Form
    {
        List<Image> imageList = new List<Image>();
        int Count = 1, start_flag = 0;
        Timer timer;
        double speed = 1;
        int flag = 0; //0 停止 , 1 開始
        double psnr;
        int motion_vector_flag = 0;

        public Video()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //  if (Count < list.Images.Count) //所有圖片播放完後count計數歸零循環播放

            if (Count < imageList.Count)
            {
                //source
                pictureBox_source.Image = imageList[Count];
                //next img
                //pictureBox_nextimg.Image = imageList[(Count + 1) % imageList.Count];
                //到列表中按序列取出圖片
                Count++;
            }
            else
            {
                Count = 1;
            }
            /*psnr = snr.PSNR((Bitmap)pictureBox_source.Image, (Bitmap)pictureBox_nextimg.Image);
            label_frame.Text = "Current Frame: " + Count +  "/" + imageList.Count; 
            psnr = Math.Round(psnr, 3);
            toolStripStatusLabel4.Text = "PSNR: " + psnr;*/
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new Timer() { Interval = 100, Enabled = false };//啟動一個Timer
            timer.Tick += new EventHandler(timer1_Tick);
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            start_flag++;
            if(start_flag % 2 == 1)
            {
                //開始
                timer.Enabled = true;
                button_start.Image = Resources.pause__1_;
                button_nextimg.Enabled = false;
                button_beforeimg.Enabled = false;
            }
            else
            {
                //停止
                timer.Enabled = false;
                button_start.Image = Resources.play__2_;
                button_nextimg.Enabled = true;
                button_beforeimg.Enabled = true;
            }

        }    

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Multiselect = true;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                MemoryStream MS = null;
                foreach (string item in OpenFile.FileNames)
                //把所有選擇的圖片放到列表中
                {
                    MS = new MemoryStream(File.ReadAllBytes(item));
                    imageList.Add(Image.FromStream(MS));
                    MS.Close();
                }
            }
            //show buttom
            button_start.Visible = true;
            button_nextimg.Visible = true;
            button_beforeimg.Visible = true;
            button_increase.Visible = true;
            button_decrease.Visible = true;
            button_nextimg.Enabled = false;
            button_beforeimg.Enabled = false;
            motionVectorToolStripMenuItem.Enabled = true;
            label_frame.Visible = true;
            //放第一張預覽圖
            if(imageList.Count > 0)
            {
                pictureBox_source.Image = imageList[0];
                //status label
                toolStripStatusLabel2.Text = "(" + imageList[0].Height.ToString() + ", " + imageList[0].Width.ToString() + ")";
                statusStrip1.Visible = true;
                label_frame.Text = "Current Frame: " + Count + "/" + imageList.Count;
            }    
        }
        private void exit_Click(object sender, EventArgs e)
        {
            //結束
            this.Close();
        }
        //下一張
        private void button_nextimg_Click(object sender, EventArgs e)
        {
            Count++;
            if (Count < imageList.Count)
            {
                pictureBox_source.Image = imageList[Count];
                //pictureBox_nextimg.Image = imageList[(Count + 1) % imageList.Count];
            }
            else
            {
                Count = 1;
            }
            label_frame.Text = "Current Frame: " + Count + "/" + imageList.Count;
        }
        //上一張
        private void button_beforeimg_Click(object sender, EventArgs e)
        {
            //要判斷count小於1
            Count--;
            if (Count < imageList.Count && Count > 1)
            {
                pictureBox_source.Image = imageList[Count];
                //pictureBox_nextimg.Image = imageList[(Count + 1) % imageList.Count];
            }
            else
            {
                Count = imageList.Count;
            }
            label_frame.Text = "Current Frame: " + Count + "/" + imageList.Count;
        }
        //加速
        private void button_increase_Click(object sender, EventArgs e)
        {
            double value = timer.Interval;
            value /= 1.25;
            speed *= 1.25;
            speed = Math.Round(speed, 3);
            timer.Interval = (int)value;
            Console.WriteLine(timer.Interval.ToString());
            toolStripStatusLabel3.Text = "Speed = " + speed.ToString() + "x"; 
        }
        //減速
        private void button_decrease_Click(object sender, EventArgs e)
        {
            double value = timer.Interval;
            value *= 1.25;
            speed /= 1.25;
            speed = Math.Round(speed, 3);
            timer.Interval = (int)value;

            Console.WriteLine(timer.Interval.ToString());
            toolStripStatusLabel3.Text = "Speed = " + speed.ToString() + "x";
        }

        private void motionVectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label_Tblock.Visible = true;
            label_Cblock.Visible = true;
            pictureBox_Cblock.Visible = true;
            pictureBox_Tblock.Visible = true;
            chart_PSNR.Visible = true;
        }
        int currentCntY = 0, currentCntX = 0;
        int resultCntY = 0, resultCntX = 0;
        int endX, endY;
        byte[,] target_array = new byte[256, 256];
        byte[,] refernce_array = new byte[256, 256];
        byte[,] compareBlockArray = new byte[8, 8];
        byte[,] targetBlockArray = new byte[8, 8];
        Bitmap candidateBlock = new Bitmap(64, 64);
        Bitmap targetBlock = new Bitmap(64, 64);
        Bitmap motion_vector = new Bitmap(256, 256);
        Bitmap img = new Bitmap(256, 256);
        int T;
        int min = 9999;
        bool candraw = false;
        Point start;
        Point end;
        Point tmp;
        List<Point> start_v = new List<Point>();
        List<int> T_array = new List<int>();
        List<Point> MotionVector = new List<Point>();
        private void timer_motion_Tick(object sender, EventArgs e)
        {
            Bitmap target_img = new Bitmap(pictureBox_source.Image);
            Bitmap reference_img = new Bitmap(pictureBox_nextimg.Image);
            
            if (motion_vector_flag == 1)
            {
                button_decrease.Enabled = false;
                button_increase.Enabled = false;                
                //Console.WriteLine("x: " + counterX + ",y: " + counterY);
                if (resultCntX < reference_img.Height && resultCntX < reference_img.Width)
                {
                    target_array = imagetoarray.getArray(target_img);
                    refernce_array = imagetoarray.getArray(reference_img);
                    //比同位置
                    compareBlockArray = imagetoarray.getBlock(target_array, resultCntX, resultCntY);
                    targetBlockArray = imagetoarray.getBlock(refernce_array, resultCntX, resultCntY);
                    T = imagetoarray.arrayMinus(compareBlockArray, targetBlockArray);
                    //Console.WriteLine("T: " + T);
                    //Console.WriteLine("currentCntX, currentCntY" + currentCntX + " " + currentCntY);
                    //Console.WriteLine("resultCntX, resultCntY" + resultCntX + " " + resultCntY);
                    //next
                    if (T < 600)
                    {
                        start = new Point(resultCntX, resultCntY);
                        end = new Point(resultCntX, resultCntY);
                        tmp = new Point(end.X - start.X, end.Y - start.Y);
                        //記vector
                        MotionVector.Add(tmp);
                        start_v.Add(start);
                        Console.WriteLine("start(x, y): " + start.X + " " + start.Y + " " + "vector: " + tmp.X + " " + tmp.Y);
                        candraw = true;
                        resultCntX += 8;
                        if(resultCntX == 256)
                        {
                            resultCntX = 0;
                            resultCntY += 8;
                            if(resultCntY == 256)
                            {
                                Count++;
                                pictureBox_nextimg.Image = imageList[Count];
                                pictureBox_nextimg.Refresh();
                                //pictureBox_source.Image = 解碼後
                                resultCntX = 0;
                                resultCntY = 0;
                            }
                        }
                        currentCntX = resultCntX;
                        currentCntY = resultCntY;
                    }
                    //換最小T
                    else
                    {
                        int motion = 0;
                        motion = compare(target_img, reference_img);
                        start = new Point(motion % 256, motion / 256);
                        end = new Point(resultCntX, resultCntY);
                        /*tmp = new Point(end.X - start.X, end.Y - start.Y);
                        start_v.Add(start);
                        MotionVector.Add(tmp);*/
                    }
                }
                //類迴圈
                if (currentCntY < target_img.Height && currentCntX < target_img.Width)
                {
                    endX = (currentCntX + 8);
                    if (endX == 256)
                    {
                        currentCntX = 0;
                        endY = (currentCntY + 8);
                        if (endY == 256)
                        {
                            endX = 0;
                            endY = 0;
                            currentCntX = 0;
                            currentCntY = 0;
                        }
                        else
                            currentCntY += 1;
                    }
                    else
                        currentCntX += 1;
                }
                Graphics graphic = Graphics.FromImage(candidateBlock);
                //將被切割的圖片畫在新圖片上面，第一個參數是被切割的原圖片
                graphic.DrawImage(target_img,
                //dst
                //指定繪製影像的位置和大小，基本上是同pic大小
                new Rectangle(0, 0, candidateBlock.Width, candidateBlock.Height),
                //src
                new Rectangle(currentCntX, currentCntY, 8, 8),
                //指定被切割的圖片要繪製的部分
                GraphicsUnit.Pixel);
                //測量單位，這邊是pixel
                pictureBox_source.Refresh();
                pictureBox_Cblock.Image = candidateBlock;

                Graphics graphic_next = Graphics.FromImage(targetBlock);

                graphic_next.DrawImage(reference_img,
                new Rectangle(0, 0, targetBlock.Width, targetBlock.Height),
                new Rectangle(resultCntX, resultCntY, 8, 8),
                GraphicsUnit.Pixel);

                pictureBox_nextimg.Refresh();
                pictureBox_Tblock.Image = targetBlock;

                Graphics g = Graphics.FromImage(motion_vector);
                g.DrawImage(motion_vector, start);
                pictureBox_motionvector.Image = motion_vector;
                pictureBox_motionvector.Refresh();
            }
        }
        private int compare(Bitmap target_img, Bitmap reference_img)
        {
            int motion = 0;
            timer_full.Stop();
            for (int j = 0; j < 249; j++)
            {
                for (int i = 0; i < 249; i++)
                {
                    currentCntX = i;
                    currentCntY = j;
                    target_array = imagetoarray.getArray(target_img);
                    refernce_array = imagetoarray.getArray(reference_img);
                    compareBlockArray = imagetoarray.getBlock(target_array, currentCntX, currentCntY);
                    targetBlockArray = imagetoarray.getBlock(refernce_array, resultCntX, resultCntY);
                    T = imagetoarray.arrayMinus(compareBlockArray, targetBlockArray);
                    if (T < 600)
                    {
                        start = new Point(currentCntX, currentCntY);
                        end = new Point(resultCntX, resultCntY);
                        tmp = new Point(end.X - start.X, end.Y - start.Y);
                        Console.WriteLine("start(x, y): " + start.X + " " + start.Y + " " + "vector: " + tmp.X + " " + tmp.Y);
                        start_v.Add(start);
                        MotionVector.Add(tmp);
                        candraw = true;
                        resultCntX += 8;
                        if (resultCntX == 256)
                        {
                            resultCntX = 0;
                            resultCntY += 8;
                            if (resultCntY == 256)
                            {
                                Count++;
                                pictureBox_motionvector.Image.Save(@"C:\Users\qazws\Downloads\ImageProcessing\motionvector" + ".txt");
                                pictureBox_nextimg.Image = imageList[Count];
                                //pictureBox_source.Image = 解碼後
                                resultCntX = 0;
                                resultCntY = 0;
                            }
                        }
                        motion = i + j * 256;
                        currentCntX = resultCntX;
                        currentCntY = resultCntY;
                        //記vector
                        timer_full.Start();
                        return motion;
                    }
                    //Console.WriteLine("T: " + T);
                    //T_array.Add(T);
                    Graphics graphic = Graphics.FromImage(candidateBlock);
                    //將被切割的圖片畫在新圖片上面，第一個參數是被切割的原圖片
                    graphic.DrawImage(target_img,
                    //dst
                    //指定繪製影像的位置和大小，基本上是同pic大小
                    new Rectangle(0, 0, candidateBlock.Width, candidateBlock.Height),
                    //src
                    new Rectangle(currentCntX, currentCntY, 8, 8),
                    //指定被切割的圖片要繪製的部分
                    GraphicsUnit.Pixel);
                    //測量單位，這邊是pixel
                    pictureBox_source.Refresh();
                    pictureBox_Cblock.Image = candidateBlock;
                    pictureBox_Cblock.Refresh();
                }
            }
            int min_T = T_array[0];
            for (int n = 0; n < T_array.LongCount(); n++)
            {
                if (T_array[n] < min)
                { //取差距最小的塊，儲存。
                    min = T_array[n];
                    motion = n;
                }
            }
            T_array.Clear();
            timer_full.Start();
            return motion;
        }
        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox_source.Image != null)
            {
                motion_vector_flag = 1;
                label_Tblock.Visible = true;
                label_Cblock.Visible = true;
                pictureBox_Cblock.Visible = true;
                pictureBox_Tblock.Visible = true;
                timer_motion.Enabled = true;
                //初始化圖片state
                pictureBox_source.Image = imageList[0];
                pictureBox_nextimg.Image = imageList[1];
                Count = 1;
                for (int i = 0; i < 256; i++)
                {
                    for (int j = 0; j < 256; j++)
                    {
                        motion_vector.SetPixel(j, i, Color.White);
                    }
                }
                /*psnr = snr.PSNR((Bitmap)pictureBox_source.Image, (Bitmap)pictureBox_nextimg.Image);
                label_frame.Text = "Current Frame: " + Count + "/" + imageList.Count;
                psnr = Math.Round(psnr, 3);
                toolStripStatusLabel4.Text = "PSNR: " + psnr;*/
            }
        }
        private void pictureBox_motionvector_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox_source.Image != null && motion_vector_flag == 1)
            {
                for(int i = 0; i < MotionVector.Count; i++)
                {
                    Pen pen = new Pen(Color.Red, 1);
                    SolidBrush brush = new SolidBrush(Color.Blue);
                    pen.StartCap = LineCap.NoAnchor;
                    pen.EndCap = LineCap.ArrowAnchor;
                    if (MotionVector[i].X == 0 && MotionVector[i].Y == 0)
                    {
                        e.Graphics.FillRectangle(brush, new Rectangle(start_v[i].X + 3, start_v[i].Y + 3, 2, 2));
                    }
                    else
                    {
                        e.Graphics.DrawLine(pen, start_v[i].X, start_v[i].Y, start_v[i].X + MotionVector[i].X, start_v[i].Y + MotionVector[i].Y);
                    }   
                    brush.Dispose();
                    pen.Dispose();
                }
            }
            candraw = false;
        }

        private void getfirstvectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Bitmap> currentblock = new List<Bitmap>();
            List<Bitmap> candidateblock = new List<Bitmap>();
            List<Bitmap> image = new List<Bitmap>();
            for(int i = 0; i < imageList.Count; i++)
            {
                image.Add(new Bitmap(imageList[i]));
            }
            //Console.WriteLine(image.Count);
            Bitmap result = new Bitmap(256, 256); 
            Bitmap target = new Bitmap(image[0]);
            target.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "pic" + 0 + ".jpeg", ImageFormat.Jpeg);
            Bitmap reference = new Bitmap(image[1]);
            videojim v = new videojim();
            for(int i = 1; i < imageList.Count - 1; i++)
            {
                //target(current)  reference
                //P0 P1
                //d0 P2
                //d1 P3
                //.. ..
                if(i < imageList.Count - 1)
                {
                    v.VideoGetPool(target, reference, out currentblock, out candidateblock);
                    result = v.VideoEncode(currentblock, candidateblock);
                    result.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "pic" + i + ".jpeg", ImageFormat.Jpeg);
                }
                else if (i == imageList.Count - 1)
                {
                    v.VideoGetPool(target, reference, out currentblock, out candidateblock);
                    result = v.VideoEncode(currentblock, candidateblock);
                    result.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "pic" + i + ".jpeg", ImageFormat.Jpeg);
                    break;
                }
                target = result;
                reference = image[i + 1];
                pictureBox_source.Image = target;
                pictureBox_nextimg.Image = reference;
                pictureBox_nextimg.Refresh();
                pictureBox_source.Refresh();
            }
            //v.VideoGetPool(next, current, out currentblock, out candidateblock);
            //result = v.VideoEncode(currentblock, candidateblock);
            //pictureBox_nextimg.Image = result;
        }
        int output_counter = 0;
        private void tSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap target = new Bitmap(imageList[0]);
            List<Bitmap> CandidatePool = new List<Bitmap>();
            pictureBox_source.Image = target;
            target.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "pic" + output_counter++ + ".jpeg", ImageFormat.Jpeg);
            Bitmap reference = new Bitmap(imageList[1]);
            pictureBox_nextimg.Image = reference;
            label_Tblock.Visible = true;
            label_Cblock.Visible = true;
            pictureBox_Cblock.Visible = true;
            pictureBox_Tblock.Visible = true;
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    motion_vector.SetPixel(j, i, Color.White);
                }
            }
            pictureBox_motionvector.Image = motion_vector;
            pictureBox_motionvector.Refresh();

            for (int i = 1; i < imageList.Count; i++)
            {
                TSScoding(target, reference);
                //target切小塊
                VideoGetPool(target, out CandidatePool);
                target = videoDecode(CandidatePool, points);
                target.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "pic" + output_counter + ".jpeg", ImageFormat.Jpeg);
                pictureBox_source.Image = target;
                if(i < imageList.Count - 1)
                {
                    reference = (Bitmap)imageList[i + 1];
                    pictureBox_nextimg.Image = reference;
                    pictureBox_source.Refresh();
                    pictureBox_nextimg.Refresh();
                    pictureBox_motionvector.Refresh();
                }
                else
                {
                    pictureBox_source.Refresh();
                }
                psnr = snr.PSNR(target, (Bitmap)imageList[i]);
                label_frame.Text = "Current Frame: " + Count++ + "/" + imageList.Count;
                psnr = Math.Round(psnr, 3);
                Console.WriteLine(psnr);
                chart_PSNR.Series[0].Points.AddXY(i, psnr);
                chart_PSNR.Update();

                pictureBox_motionvector.Image.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "motionvector" + output_counter + ".jpeg", ImageFormat.Jpeg);
                MotionVector.Clear();
                start_v.Clear();
                output_counter++;
            }

        }

        int Tx, Ty, Cx, Cy;
        Point minlocation;
        List<Point> points = new List<Point>();

        int txtcount = 0;

        private void tDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap target = new Bitmap(imageList[0]);
            List<Bitmap> CandidatePool = new List<Bitmap>();
            pictureBox_source.Image = target;
            target.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "pic" + output_counter++ + ".jpeg", ImageFormat.Jpeg);
            Bitmap reference = new Bitmap(imageList[1]);
            pictureBox_nextimg.Image = reference;

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    motion_vector.SetPixel(j, i, Color.White);
                }
            }
            pictureBox_motionvector.Image = motion_vector;
            pictureBox_motionvector.Refresh();

            for (int i = 1; i < imageList.Count; i++)
            {
                TDLcoding(target, reference);
                //target切小塊
                VideoGetPool(target, out CandidatePool);
                target = videoDecode(CandidatePool, points);
                target.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "pic" + output_counter + ".jpeg", ImageFormat.Jpeg);
                pictureBox_source.Image = target;
                if (i < imageList.Count - 1)
                {
                    reference = (Bitmap)imageList[i + 1];
                    pictureBox_nextimg.Image = reference;
                    pictureBox_source.Refresh();
                    pictureBox_nextimg.Refresh();
                    pictureBox_motionvector.Refresh();
                }
                else
                {
                    pictureBox_source.Refresh();
                }
                psnr = snr.PSNR(target, (Bitmap)imageList[i]);
                label_frame.Text = "Current Frame: " + Count++ + "/" + imageList.Count;
                psnr = Math.Round(psnr, 3);
                Console.WriteLine(psnr);
                chart_PSNR.Series[0].Points.AddXY(i, psnr);
                chart_PSNR.Update();

                pictureBox_motionvector.Image.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "motionvector" + output_counter + ".jpeg", ImageFormat.Jpeg);
                MotionVector.Clear();
                start_v.Clear();
                output_counter++;
            }
        }

        void TDLcoding(Bitmap bmp, Bitmap aftbmp)
        {
            Bitmap source = new Bitmap(bmp);
            Bitmap result = new Bitmap(aftbmp);
            motion_vector_flag = 1;
            points.Clear();
            StreamWriter sfile = new StreamWriter(@"C:\Users\qazws\Downloads\ImageProcessing\encode" + txtcount++ + ".txt", true);
            BitmapData bmpdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData aftbmpdata = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bmpdata.Scan0;
            IntPtr intPtraft = aftbmpdata.Scan0;
            int size = bmpdata.Stride * bmpdata.Height;
            int size2 = aftbmpdata.Stride * aftbmpdata.Height;
            byte[] bmpBytes = new byte[size];
            byte[] aftBytes = new byte[size2];
            Marshal.Copy(intPtr, bmpBytes, 0, size);
            Marshal.Copy(intPtraft, aftBytes, 0, size2);

            //target
            int k = 3;
            int min, sum, x, y;
            int line_cout = 0;
            for (Ty = 0; Ty < pictureBox_nextimg.Image.Height; Ty += 8)
            {
                for (Tx = 0; Tx < pictureBox_nextimg.Image.Width; Tx += 8)
                {
                    resultCntX = Tx;
                    resultCntY = Ty;
                    //candidate
                    Point C = new Point(Tx, Ty);//中心點
                    Cx = C.X; Cy = C.Y;
                    Point minP = new Point(Tx, Ty);//中心點  minP ->目前5點最小值
                    sum = 0;
                    for (y = 0; y < 8; y++)
                    {
                        for (x = 0; x < 8; x++)
                        {
                            sum += Math.Abs(aftBytes[(Ty + y) * aftbmpdata.Stride + (Tx + x) * k] - bmpBytes[(Ty + y) * bmpdata.Stride + (Tx + x) * k]);
                        }
                    }
                    min = sum;
                    int S = 8;//d
                    while (S > 1)
                    {
                        //比上下左右
                        //左
                        if (C.X - S >= 0 && C.X - S + 8 < pictureBox_source.Width && C.Y >= 0 && C.Y - S + 8 < pictureBox_source.Height)
                        {
                            if (Math.Pow(Math.Abs((C.X - S) - Tx), 2) + Math.Pow(Math.Abs((C.Y) - Ty), 2) <= 256)//可能移動範圍不超過16
                            {
                                Cx = C.X - S; Cy = C.Y;
                                currentCntY = Cy;
                                currentCntX = Cx;
                                Point L = new Point(C.X - S, C.Y);
                                sum = 0;
                                for (y = 0; y < 8; y++)
                                {
                                    for (x = 0; x < 8; x++)
                                    {
                                        sum += Math.Abs(aftBytes[(Ty + y) * aftbmpdata.Stride + (Tx + x) * k] - bmpBytes[(L.X + y) * bmpdata.Stride + (L.Y + x) * k]);
                                        if (sum >= min)
                                            break;
                                    }
                                }
                                if (sum < min)
                                {
                                    min = sum;
                                    minP = L;
                                }
                            }
                        }
                        //上
                        if (C.X >= 0 && C.X + 8 < pictureBox_source.Width && C.Y + S >= 0 && C.Y + S + 8 < pictureBox_source.Height)
                        {
                            if (Math.Pow(Math.Abs((C.X) - Tx), 2) + Math.Pow(Math.Abs((C.Y + S) - Ty), 2) <= 256)
                            {
                                Cx = C.X; Cy = C.Y + S;
                                currentCntY = Cy;
                                currentCntX = Cx;
                                Point U = new Point(C.X, C.Y + S);
                                sum = 0;
                                for (y = 0; y < 8; y++)
                                {
                                    for (x = 0; x < 8; x++)
                                    {
                                        sum += Math.Abs(aftBytes[(Ty + y) * aftbmpdata.Stride + (Tx + x) * k] - bmpBytes[(U.X + y) * bmpdata.Stride + (U.Y + x) * k]);
                                        if (sum >= min)
                                            break;
                                    }
                                }
                                if (sum < min)
                                {
                                    min = sum;
                                    minP = U;
                                }
                            }
                        }
                        //右
                        if (C.X + S >= 0 && C.X + S + 8 < pictureBox_source.Width && C.Y >= 0 && C.Y + 8 < pictureBox_source.Height)
                        {
                            if (Math.Pow(Math.Abs((C.X + S) - Tx), 2) + Math.Pow(Math.Abs((C.Y) - Ty), 2) <= 256)
                            {
                                Cx = C.X + S; Cy = C.Y;
                                currentCntY = Cy;
                                currentCntX = Cx;
                                Point R = new Point(C.X + S, C.Y);
                                sum = 0;
                                for (y = 0; y < 8; y++)
                                {
                                    for (x = 0; x < 8; x++)
                                    {
                                        sum += Math.Abs(aftBytes[(Ty + y) * aftbmpdata.Stride + (Tx + x) * k] - bmpBytes[(R.X + y) * bmpdata.Stride + (R.Y + x) * k]);
                                        if (sum >= min)
                                            break;
                                    }
                                }
                                if (sum < min)
                                {
                                    min = sum;
                                    minP = R;
                                }
                            }
                        }
                        //下
                        if (C.X >= 0 && C.X + 8 < pictureBox_source.Width && C.Y - S >= 0 && C.Y - S + 8 < pictureBox_source.Height)
                        {
                            if (Math.Pow(Math.Abs((C.X) - Tx), 2) + Math.Pow(Math.Abs((C.Y - S) - Ty), 2) <= 256)
                            {
                                Cx = C.X; Cy = C.Y - S;
                                currentCntY = Cy;
                                currentCntX = Cx;
                                Point D = new Point(C.X, C.Y - S);
                                sum = 0;
                                for (y = 0; y < 8; y++)
                                    for (x = 0; x < 8; x++)
                                    {
                                        sum += Math.Abs(aftBytes[(Ty + y) * aftbmpdata.Stride + (Tx + x) * k] - bmpBytes[(D.X + y) * bmpdata.Stride + (D.Y + x) * k]);
                                        if (sum >= min) break;
                                    }
                                if (sum < min)
                                {
                                    min = sum;
                                    minP = D;
                                }
                            }
                        }
                        //中間最小 S/2 但S!=1
                        if (minP == C)
                        {
                            S /= 2;
                        }
                        //最小值為上個中心點
                        C = minP;
                    }
                    if (S == 1)//9宮格比
                    {
                        min = int.MaxValue;
                        for (int y1 = -1; y1 <= 1; y1++)
                        {
                            for (int x1 = -1; x1 <= 1; x1++)
                            {
                                sum = 0;
                                if (C.X + x1 >= 0 && C.X + x1 + 8 < pictureBox_source.Width && C.Y + y1 >= 0 && C.Y + y1 + 8 < pictureBox_source.Height)
                                {
                                    Cx = C.X + x1; Cy = C.Y + y1;
                                    currentCntY = Cy;
                                    currentCntX = Cx;
                                    for (y = 0; y < 8; y++)
                                    {
                                        for (x = 0; x < 8; x++)
                                        {
                                            sum += Math.Abs(aftBytes[(Ty + y) * aftbmpdata.Stride + (Tx + x) * k] - bmpBytes[((C.Y + y1) + y) * bmpdata.Stride + ((C.X + x1) + x) * k]);
                                            if (sum >= min)
                                                break;
                                        }
                                    }
                                    if (sum < min)
                                    {
                                        min = sum;
                                        minlocation = new Point(C.X + x1, C.Y + y1);
                                    }
                                }
                            }
                        }
                    }
                    //Console.WriteLine("cur XY" + currentCntX + " " + currentCntY + "res XY" + resultCntX + " " + resultCntY);

                    Point start = new Point(line_cout % 32 * 8, line_cout / 32 * 8);
                    //Console.WriteLine(start.X + " " + start.Y);
                    start_v.Add(start);
                    Point tmp = new Point(minlocation.X - line_cout % 32 * 8, minlocation.Y - line_cout / 32 * 8);
                    //Console.WriteLine("motion vector: " + "x: " + tmp.X + " y: " + tmp.Y);
                    MotionVector.Add(tmp);

                    Graphics graphic = Graphics.FromImage(candidateBlock);
                    //將被切割的圖片畫在新圖片上面，第一個參數是被切割的原圖片
                    graphic.DrawImage(bmp,
                    //dst
                    //指定繪製影像的位置和大小，基本上是同pic大小
                    new Rectangle(0, 0, candidateBlock.Width, candidateBlock.Height),
                    //src
                    new Rectangle(currentCntX, currentCntY, 8, 8),
                    //指定被切割的圖片要繪製的部分
                    GraphicsUnit.Pixel);
                    //測量單位，這邊是pixel
                    pictureBox_Cblock.Image = candidateBlock;
                    pictureBox_Cblock.Refresh();

                    Graphics graphic_next = Graphics.FromImage(targetBlock);

                    graphic_next.DrawImage(aftbmp,
                    new Rectangle(0, 0, targetBlock.Width, targetBlock.Height),
                    new Rectangle(resultCntX, resultCntY, 8, 8),
                    GraphicsUnit.Pixel);

                    pictureBox_Tblock.Image = targetBlock;
                    pictureBox_Tblock.Refresh();
                    refresh();

                    Graphics g = Graphics.FromImage(motion_vector);
                    g.DrawImage(motion_vector, start);
                    pictureBox_motionvector.Image = motion_vector;
                    pictureBox_motionvector.Refresh();

                    sfile.Write(line_cout.ToString() + ":  " + minlocation.X + " " + minlocation.Y + "\r\n");
                    line_cout++;
                    //Console.WriteLine("location(x, y): " + minlocation.X + " " + minlocation.Y);
                    points.Add(minlocation);
                }
            }
            source.UnlockBits(bmpdata);
            result.UnlockBits(aftbmpdata);
            sfile.Flush();
            sfile.Close();
            line_cout = 0;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
        private void refresh()
        {
            label_Tblock.Visible = true;
            label_Cblock.Visible = true;
            pictureBox_Cblock.Visible = true;
            pictureBox_Tblock.Visible = true;
            pictureBox_nextimg.Refresh();
            pictureBox_source.Refresh();
        }


        void TSScoding(Bitmap bmp, Bitmap aftbmp)
        {
            Bitmap source = new Bitmap(bmp);
            Bitmap result = new Bitmap(aftbmp);
            motion_vector_flag = 1;
            points.Clear();
            StreamWriter sfile = new StreamWriter(@"C:\Users\qazws\Downloads\ImageProcessing\encode" + txtcount++ + ".txt", true);
            BitmapData bmpdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData aftbmpdata = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bmpdata.Scan0;
            IntPtr intPtraft = aftbmpdata.Scan0;
            int size = bmpdata.Stride * bmpdata.Height;
            int size2 = aftbmpdata.Stride * aftbmpdata.Height;
            byte[] bmpBytes = new byte[size];
            byte[] aftBytes = new byte[size2];
            Marshal.Copy(intPtr, bmpBytes, 0, size);
            Marshal.Copy(intPtraft, aftBytes, 0, size2);

            //target
            int k = 3;
            int min, sum, x, y;
            int line_cout = 0;
            for (Ty = 0; Ty < pictureBox_nextimg.Image.Height; Ty += 8)
            {
                
                for (Tx = 0; Tx < pictureBox_nextimg.Image.Width; Tx += 8)
                {
                    //candidate
                    Point C = new Point(Tx, Ty);//中心點
                    Cx = C.X; Cy = C.Y;
                    Point minP = C;//minP ->目前9點最小值
                    resultCntX = Tx;
                    resultCntY = Ty;
                    int S = 3;//d
                    while (S > 1)
                    {
                        min = int.MaxValue;
                        for (int y1 = -S; y1 <= S; y1 += S)
                        {
                            for (int x1 = -S; x1 <= S; x1 += S)
                            {
                                sum = 0;
                                if (C.X + x1 >= 0 && C.X + x1 + 8 < pictureBox_source.Width && C.Y + y1 >= 0 && C.Y + y1 + 8 < pictureBox_source.Height)
                                {
                                    Cx = C.X + x1; Cy = C.Y + y1;
                                    currentCntY = Cy;
                                    currentCntX = Cx;
                                    for (y = 0; y < 8; y++)
                                    {
                                        for (x = 0; x < 8; x++)
                                        {
                                            sum += Math.Abs(aftBytes[(Ty + y) * aftbmpdata.Stride + (Tx + x) * k] - bmpBytes[((C.Y + y1) + y) * bmpdata.Stride + ((C.X + x1) + x) * k]);
                                            if (sum >= min) break;
                                        }
                                    }
                                    if (sum < min)
                                    {
                                        min = sum;
                                        minP = new Point(C.X + x1, C.Y + y1);
                                    }
                                }
                            }
                        }            
                        C = minP;//最小為下個中心
                        S--;
                    }
                    if (S == 1)//9宮格比
                    {
                        min = int.MaxValue;
                        for (int y1 = -1; y1 <= 1; y1++)
                            for (int x1 = -1; x1 <= 1; x1++)
                            {
                                sum = 0;
                                if (C.X + x1 >= 0 && C.X + x1 + 8 < pictureBox_source.Width && C.Y + y1 >= 0 && C.Y + y1 + 8 < pictureBox_source.Height)
                                {
                                    Cx = C.X + x1; Cy = C.Y + y1;
                                    currentCntY = Cy;
                                    currentCntX = Cx;
                                    for (y = 0; y < 8; y++)
                                        for (x = 0; x < 8; x++)
                                        {
                                            sum += Math.Abs(aftBytes[(Ty + y) * aftbmpdata.Stride + (Tx + x) * k] - bmpBytes[((C.Y + y1) + y) * bmpdata.Stride + ((C.X + x1) + x) * k]);
                                            if (sum >= min) break;
                                        }
                                    if (sum < min)
                                    {
                                        min = sum;
                                        minlocation = new Point(C.X + x1, C.Y + y1);
                                    }
                                }
                            }
                    }
                    //Console.WriteLine("cur XY" + currentCntX + " " + currentCntY + "res XY" + resultCntX + " " + resultCntY);

                    Point start = new Point(line_cout % 32 * 8, line_cout / 32 * 8);
                    //Console.WriteLine(start.X + " " + start.Y);
                    start_v.Add(start);
                    Point tmp = new Point(minlocation.X - line_cout % 32 * 8, minlocation.Y - line_cout / 32 * 8);
                    //Console.WriteLine("motion vector: " + "x: " + tmp.X + " y: " + tmp.Y);
                    MotionVector.Add(tmp);

                    Graphics graphic = Graphics.FromImage(candidateBlock);
                    //將被切割的圖片畫在新圖片上面，第一個參數是被切割的原圖片
                    graphic.DrawImage(bmp,
                    //dst
                    //指定繪製影像的位置和大小，基本上是同pic大小
                    new Rectangle(0, 0, candidateBlock.Width, candidateBlock.Height),
                    //src
                    new Rectangle(currentCntX, currentCntY, 8, 8),
                    //指定被切割的圖片要繪製的部分
                    GraphicsUnit.Pixel);
                    //測量單位，這邊是pixel
                    pictureBox_Cblock.Image = candidateBlock;
                    pictureBox_Cblock.Refresh();
                    refresh();

                    Graphics graphic_next = Graphics.FromImage(targetBlock);

                    graphic_next.DrawImage(aftbmp,
                    new Rectangle(0, 0, targetBlock.Width, targetBlock.Height),
                    new Rectangle(resultCntX, resultCntY, 8, 8),
                    GraphicsUnit.Pixel);

                    pictureBox_Tblock.Image = targetBlock;
                    pictureBox_Tblock.Refresh();

                    Graphics g = Graphics.FromImage(motion_vector);
                    g.DrawImage(motion_vector, start);
                    pictureBox_motionvector.Image = motion_vector;
                    pictureBox_motionvector.Refresh();

                    sfile.Write(line_cout.ToString() + ":  " + minlocation.X + " " + minlocation.Y + "\r\n");
                    line_cout++;
                    //Console.WriteLine("location(x, y): " + minlocation.X + " " + minlocation.Y);
                    points.Add(minlocation);

                }
            }
            //Console.WriteLine("count: " + points.Count);
            source.UnlockBits(bmpdata);
            result.UnlockBits(aftbmpdata);
            sfile.Flush();
            sfile.Close();
            line_cout = 0;
        }
        private void oSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap target = new Bitmap(imageList[0]);
            List<Bitmap> CandidatePool = new List<Bitmap>();
            pictureBox_source.Image = target;
            target.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "pic" + output_counter++ + ".jpeg", ImageFormat.Jpeg);
            Bitmap reference = new Bitmap(imageList[1]);
            pictureBox_nextimg.Image = reference;

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    motion_vector.SetPixel(j, i, Color.White);
                }
            }
            pictureBox_motionvector.Image = motion_vector;
            pictureBox_motionvector.Refresh();

            for (int i = 1; i < imageList.Count; i++)
            {
                OSAcoding(target, reference);
                //target切小塊
                VideoGetPool(target, out CandidatePool);
                target = videoDecode(CandidatePool, points);
                target.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "pic" + output_counter + ".jpeg", ImageFormat.Jpeg);
                pictureBox_source.Image = target;
                if (i < imageList.Count - 1)
                {
                    reference = (Bitmap)imageList[i + 1];
                    pictureBox_nextimg.Image = reference;
                    pictureBox_source.Refresh();
                    pictureBox_nextimg.Refresh();
                    pictureBox_motionvector.Refresh();
                }
                else
                {
                    pictureBox_source.Refresh();
                }
                psnr = snr.PSNR(target, (Bitmap)imageList[i]);
                label_frame.Text = "Current Frame: " + Count++ + "/" + imageList.Count;
                psnr = Math.Round(psnr, 3);
                Console.WriteLine(psnr);
                chart_PSNR.Series[0].Points.AddXY(i, psnr);
                chart_PSNR.Update();

                pictureBox_motionvector.Image.Save("C:\\Users\\qazws\\Downloads\\ImageProcessing\\" + "motionvector" + output_counter + ".jpeg", ImageFormat.Jpeg);
                MotionVector.Clear();
                start_v.Clear();
                output_counter++;
            }
        }
        void OSAcoding(Bitmap bmp, Bitmap aftbmp)
        {
            Bitmap source = new Bitmap(bmp);
            Bitmap result = new Bitmap(aftbmp);
            motion_vector_flag = 1;
            points.Clear();
            StreamWriter sfile = new StreamWriter(@"C:\Users\qazws\Downloads\ImageProcessing\encode" + txtcount++ + ".txt", true);
            BitmapData bmpdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData aftbmpdata = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bmpdata.Scan0;
            IntPtr intPtraft = aftbmpdata.Scan0;
            int size = bmpdata.Stride * bmpdata.Height;
            int size2 = aftbmpdata.Stride * aftbmpdata.Height;
            byte[] bmpBytes = new byte[size];
            byte[] aftBytes = new byte[size2];
            Marshal.Copy(intPtr, bmpBytes, 0, size);
            Marshal.Copy(intPtraft, aftBytes, 0, size2);

            //target
            int line_cout = 0;
            int k = 3;
            int min, sum, x, y;
            for (Ty = 0; Ty < pictureBox_nextimg.Image.Height; Ty += 8)
            {
                for (Tx = 0; Tx < pictureBox_nextimg.Image.Width; Tx += 8)
                {
                    resultCntX = Tx;
                    resultCntY = Ty;
                    //candidate
                    Point C = new Point(Tx, Ty);//中心點
                    Cx = C.X; Cy = C.Y;
                    Point minP = C;//minP ->目前最小值

                    int S = 4;//d
                    while (S >= 1)
                    {
                        min = int.MaxValue;
                        for (int x1 = -S; x1 <= S; x1 += S)//水平
                        {
                            sum = 0;
                            if (C.X + x1 >= 0 && C.X + x1 + 8 < pictureBox_source.Width && C.Y >= 0 && C.Y + 8 < pictureBox_source.Height)
                            {
                                Cx = C.X + x1; Cy = C.Y;
                                currentCntY = Cy;
                                currentCntX = Cx;
                                for (y = 0; y < 8; y++)
                                {
                                    for (x = 0; x < 8; x++)
                                    {
                                        sum += Math.Abs(aftBytes[(Ty + y) * aftbmpdata.Stride + (Tx + x) * k] - bmpBytes[((C.Y) + y) * bmpdata.Stride + ((C.X + x1) + x) * k]);
                                        if (sum >= min) break;
                                    }
                                }
                                if (sum < min)
                                {
                                    min = sum;
                                    minP = new Point(C.X + x1, C.Y);
                                }
                            }
                        }
                        C = minP;//水平算完最小當中心換算垂直
                        min = int.MaxValue;
                        for (int y1 = -S; y1 <= S; y1 += S)//垂直
                        {
                            sum = 0;
                            if (C.X >= 0 && C.X + 8 < pictureBox_source.Width && C.Y + y1 >= 0 && C.Y + y1 + 8 < pictureBox_source.Height)
                            {
                                Cx = C.X; Cy = C.Y + y1;
                                currentCntY = Cy;
                                currentCntX = Cx;
                                for (y = 0; y < 8; y++)
                                    for (x = 0; x < 8; x++)
                                    {
                                        sum += Math.Abs(aftBytes[(Ty + y) * aftbmpdata.Stride + (Tx + x) * k] - bmpBytes[((C.Y + y1) + y) * bmpdata.Stride + ((C.X) + x) * k]);
                                        if (sum >= min) break;
                                    }
                                if (sum < min)
                                {
                                    min = sum;
                                    minP = new Point(C.X, C.Y + y1);
                                    if (S == 1) minlocation = minP;
                                }
                            }
                        }
                        C = minP;//算垂直算完換下個水平中心
                        S = S / 2;
                    }
                    //Console.WriteLine("cur XY" + currentCntX + " " + currentCntY + "res XY" + resultCntX + " " + resultCntY);
                    Point start = new Point(line_cout % 32 * 8, line_cout / 32 * 8);
                    //Console.WriteLine(start.X + " " + start.Y);
                    start_v.Add(start);
                    Point tmp = new Point(minlocation.X - line_cout % 32 * 8, minlocation.Y - line_cout / 32 * 8);
                    //Console.WriteLine("motion vector: " + "x: " + tmp.X + " y: " + tmp.Y);
                    MotionVector.Add(tmp);

                    Graphics graphic = Graphics.FromImage(candidateBlock);
                    //將被切割的圖片畫在新圖片上面，第一個參數是被切割的原圖片
                    graphic.DrawImage(bmp,
                    //dst
                    //指定繪製影像的位置和大小，基本上是同pic大小
                    new Rectangle(0, 0, candidateBlock.Width, candidateBlock.Height),
                    //src
                    new Rectangle(currentCntX, currentCntY, 8, 8),
                    //指定被切割的圖片要繪製的部分
                    GraphicsUnit.Pixel);
                    //測量單位，這邊是pixel
                    pictureBox_Cblock.Image = candidateBlock;
                    pictureBox_Cblock.Refresh();

                    Graphics graphic_next = Graphics.FromImage(targetBlock);

                    graphic_next.DrawImage(aftbmp,
                    new Rectangle(0, 0, targetBlock.Width, targetBlock.Height),
                    new Rectangle(resultCntX, resultCntY, 8, 8),
                    GraphicsUnit.Pixel);

                    pictureBox_Tblock.Image = targetBlock;
                    pictureBox_Tblock.Refresh();
                    refresh();

                    Graphics g = Graphics.FromImage(motion_vector);
                    g.DrawImage(motion_vector, start);
                    pictureBox_motionvector.Image = motion_vector;
                    pictureBox_motionvector.Refresh();

                    sfile.Write(line_cout.ToString() + ":  " + minlocation.X + " " + minlocation.Y + "\r\n");
                    line_cout++;
                    //Console.WriteLine("location(x, y): " + minlocation.X + " " + minlocation.Y);
                    points.Add(minlocation);
                }
            }
            source.UnlockBits(bmpdata);
            result.UnlockBits(aftbmpdata);
            sfile.Flush();
            sfile.Close();
            line_cout = 0;
        }

        //畫左邊
        private void pictureBox_source_Paint(object sender, PaintEventArgs e)
        {
            if(pictureBox_source.Image != null && motion_vector_flag == 1)
            {
                Pen Pen = new Pen(Brushes.Red);
                //Console.WriteLine("x: " + counterX + ",y: " + counterY);
                Rectangle rect = new Rectangle(currentCntX, currentCntY, 8, 8);
                //Console.WriteLine("左上" + rect.Location.X + " " + rect.Location.Y);
                Pen.Width = 2.0F;
                e.Graphics.DrawRectangle(Pen, rect);
            }
        }
        //畫右邊
        private void pictureBox_nextimg_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox_source.Image != null && motion_vector_flag == 1 && pictureBox_nextimg.Image != null)
            {
                Pen Pen = new Pen(Brushes.Red);
                //Console.WriteLine("x: " + counterX + ",y: " + counterY);
                Rectangle rect = new Rectangle(resultCntX, resultCntY, 8, 8);
                //Console.WriteLine("左上" + rect.Location.X + " " + rect.Location.Y);
                Pen.Width = 2.0F;
                e.Graphics.DrawRectangle(Pen, rect);
            }
        }       

        public void VideoGetPool(Bitmap referenceImage, out List<Bitmap> CandidatePool)
        {
            CandidatePool = new List<Bitmap>();
            int widthR = referenceImage.Width;
            int heightR = referenceImage.Height;
            //Rangeblock和Domainblock的大小(單邊)
            int domainSize = 8;

            //塊數
            int Dx = widthR / domainSize;
            int Dy = heightR / domainSize;

            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;

            //256-8+1
            //Dy = 249;
            //Dx = 249;
            for (int j = 0; j < 249; j++)
            {
                for (int i = 0; i < 249; i++)
                {
                    Bitmap domainBlock = referenceImage.Clone(new Rectangle(x2, y2, domainSize, domainSize), PixelFormat.Format24bppRgb);
                    CandidatePool.Add(domainBlock);
                    //x2 += domainSize;
                    x2 += 1;
                }
                //y2 += domainSize;
                y2 += 1;
                x2 = 0;
            }
        }
        //target(current)  reference
        //P0 P1
        //d0 P2
        //d1 P3
        //.. ..
        public Bitmap videoDecode(List<Bitmap> CandidatePool, List<Point> vector)
        {
            int counter = 0;
            Bitmap result = new Bitmap(256, 256);
            int pixel;
            for(int i = 0; i < vector.Count; i++)
            {
                int number = vector[i].X + vector[i].Y * 249;
                for (int y = 0; y < 8; y++)
                {
                    for(int x = 0; x < 8; x++)
                    {
                        pixel = CandidatePool[number].GetPixel(x, y).R;
                        result.SetPixel(x + (i % 32) * 8, y + (i / 32) * 8, Color.FromArgb(pixel, pixel, pixel));
                    }
                }
            }
            return result;
        }

    }
}
