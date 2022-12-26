using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace imp_pj
{
    public partial class form : Form
    {
        OpenFileDialog dialog = new OpenFileDialog();
        //file_open 只在正確打開PCX檔時為true
        bool file_open = false;
        //click bottom check
        bool crop_Oval_click = false;
        bool crop_Rect_click = false;
        bool crop_Line_click = false;
        bool set_pixel_click = false;
        //textbox press enter check
        bool Positive_rotate = false;
        bool zoom_duplication = false;
        double timer_counter = 0;
        //For Crop
        // mouse-down position
        Point startPos;
        // current mouse position
        Point currentPos;
        // busy drawing
        bool drawing;        
        Bitmap front_image, back_image, alpha_image;
        bool alpha_already = false;
        // demo
        bool demo_mode = false;

        public form()
        {
            SplashStart();
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        public void SplashStart()
        {
            Application.Run(new Splash_screen());
        }
        //---------------UI整理---------------------UI整理---------------------------UI整理------------
        //按鈕打開
        private void Bottom_Usable()
        {
            //file
            Save_ToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            invisibleHeaderToolStripMenuItem.Enabled = true;
            demoDToolStripMenuItem.Enabled = true;
            
            //Editor
            rGBchannelToolStripMenuItem.Enabled = true;
            scalingToolStripMenuItem.Enabled = true;
            rotationToolStripMenuItem.Enabled = true;
            shearToolStripMenuItem.Enabled = true;
            cutToolStripMenuItem.Enabled = true;
            gammaToolStripMenuItem.Enabled = true;
            alphaToolStripMenuItem.Enabled = true;
            missAlignmentToolStripMenuItem.Enabled = true;
            negativeToolStripMenuItem.Enabled = true;
            histogramToolStripMenuItem.Enabled = true;
            thresholdToolStripMenuItem.Enabled=true;
            setPixelToolStripMenuItem.Enabled = true;
            greyToolStripMenuItem.Enabled = true;
            slicingToolStripMenuItem.Enabled = true;
            sNRToolStripMenuItem.Enabled = true;
            magicWandToolStripMenuItem.Enabled = true;
            contrastStretchingToolStripMenuItem.Enabled = true;
            mirrorToolStripMenuItem.Enabled = true;
            noiseToolStripMenuItem.Enabled = true;
            connectComponentToolStripMenuItem.Enabled = true;
            //filter
            lowpassFilterToolStripMenuItem.Enabled = true;
            highpassFilterToolStripMenuItem.Enabled = true;
        }
        //按鈕gray out
        private void Bottom_Disable()
        {
            //file
            Save_ToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            invisibleHeaderToolStripMenuItem.Enabled = false;
            demoDToolStripMenuItem.Enabled = false;
            //Editor
            rGBchannelToolStripMenuItem.Enabled = false;
            scalingToolStripMenuItem.Enabled = false;
            rotationToolStripMenuItem.Enabled = false;
            shearToolStripMenuItem.Enabled = false;
            cutToolStripMenuItem.Enabled = false;
            alphaToolStripMenuItem.Enabled = false;
            gammaToolStripMenuItem.Enabled = false;
            missAlignmentToolStripMenuItem.Enabled = false;
            negativeToolStripMenuItem.Enabled = false;
            histogramToolStripMenuItem.Enabled = false;
            thresholdToolStripMenuItem.Enabled = false;
            setPixelToolStripMenuItem.Enabled = false;
            greyToolStripMenuItem.Enabled = false;
            slicingToolStripMenuItem.Enabled = false;
            sNRToolStripMenuItem.Enabled = false;
            magicWandToolStripMenuItem.Enabled = false;
            contrastStretchingToolStripMenuItem.Enabled = false;
            mirrorToolStripMenuItem.Enabled = false;
            noiseToolStripMenuItem.Enabled = false;
            connectComponentToolStripMenuItem.Enabled = false;
            //filter
            lowpassFilterToolStripMenuItem.Enabled = false;
            highpassFilterToolStripMenuItem.Enabled = false;
        }
        private void Clean_screen()
        {
            //set pixel
            label_R.Visible = false;
            label_G.Visible = false;
            label_B.Visible = false;
            textBox_PixelR.Text = "";
            textBox_PixelR.Visible = false;
            textBox_PixelG.Text = "";
            textBox_PixelG.Visible = false;
            textBox_PixelB.Text = "";
            textBox_PixelB.Visible = false;
            //rotate
            label_RD.Visible = false;
            textBox_RD.Visible = false;
            textBox_RD.Text = "";
            //alpha
            label_Alpha.Visible = false;
            textBox_Alpha.Visible = false;
            textBox_Alpha.Text = "";
            //zoom
            label_Zoom.Visible = false;
            textBox_Zoom.Visible = false;
            textBox_Zoom.Text = "";
            //shear
            label_ShearX.Visible = false;
            textBox_shearX.Visible = false;
            textBox_shearX.Text = "";
            //missalignment
            textBox_MAoffset.Visible = false;
            textBox_MAoffset.Text = "";
            label_MAoffset.Visible = false;
            //others
            label_FilePath.Text = "";
            pictureBox_Result.Image = null;
            pictureBox_Source.Image = null;
            textBox_ShowHeader.Visible = false;
            status_Coordinate_Bar.Visible = false;
            //snr
            label_SNR.Visible = false;
            label_SNR.Text = "";
        }
        //---------------開檔-----------------------開檔---------------------------開檔----------------
        //開檔
        private void FileOpen_Click(object sender, EventArgs e)
        {
            dialog.Title = "請選擇檔案";
            dialog.Filter = "所有檔案(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //source to null
                if(demo_mode == false)
                {
                    pictureBox_Result.Image = null;
                }
                else
                {
                    demo_mode = false;
                }
                /*打開解檔頭的textbox*/
                textBox_ShowHeader.Visible = true;
                /*open file and show path*/
                file_open = true;
                string filename = dialog.FileName;
                label_FilePath.Text = "FileName = " + filename;
                readHeader image = new readHeader(filename);
                textBox_ShowHeader.Text = image.Decode_Header();
                //Show palette
                button_showPalette.Visible = false;
                pictureBox_palette.Image = null;
                pictureBox_palette.Visible = false;
                //invisible snr
                label_SNR.Visible = false;
                label_SNR.Text = "";
                //有使用調色盤
                if (image.ColorPlanes == 1 && image.BitsPerPixel == 8)
                {
                    button_showPalette.Visible = true;
                    Color[] palette = new Color[256];
                    int counter_width = 0, counter_height = 0, counter_step = 0, counter_i = 0;
                    readTailPalette readTailPalette = new readTailPalette(filename);
                    palette = readTailPalette.getPalette();
                    /*foreach(Color c in palette)
                    {
                        Console.WriteLine(c.ToString());
                    }*/
                    //漂亮調色盤 160*160 每個color 10*10
                    Bitmap palettePIC = new Bitmap(160, 160);
                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            for (int k = 0; k < 10; k++)
                            {
                                palettePIC.SetPixel(i + counter_i * 16, counter_step, palette[counter_width]);
                                //Console.WriteLine(i + counter_i * 16 + " " + counter_step + " " + counter_width);
                                counter_step++;

                            }
                            counter_width++;
                        }
                        counter_step = 0;
                        //還不能換顏色10*10那行還沒塗滿
                        if (counter_height < 9)
                        {
                            counter_width -= 16;
                            counter_height++;
                        }
                        //換下一行的下一個顏色
                        else
                        {
                            counter_height = 0;
                        }
                        //下一行
                        if (i == 15 && counter_i < 9)
                        {
                            i = -1;
                            counter_i++;
                        }

                    }
                    pictureBox_palette.Image = palettePIC;
                    //Show_palette(palette);
                }
                //確認是否為PCX file
                if (Check_Vaild() == true)
                {
                    //把按鈕從gray out -> usable
                    Bottom_Usable();
                    byte[] image_byte = File.ReadAllBytes(filename);
                    /*open image to pic_box*/
                    readMidResource PCX_Middle = new readMidResource(filename);
                    PCX_Middle.DecoPcx(image_byte);
                    pictureBox_Source.Image = PCX_Middle.getDecoImage;
                }
            }
        }
        //秀出漂亮手刻調色盤
        private void ShowPalette_Click(object sender, EventArgs e)
        {
            pictureBox_palette.Visible = true;
        }
        //不是PCX檔案 遺憾說聲掰
        private bool Check_Vaild()
        {
            if (textBox_ShowHeader.Text == "This file doesn't a .PCX file")
            {
                file_open = false;
                this.pictureBox_Source.Image = null;
                Bottom_Disable();
                return false;
            }
            else
                return true;
        }
        //---------------Clean menu-----------------Clean menu--------------------Clean menu----------
        //乾乾淨淨 整整齊齊
        private void Clean_Click(object sender, EventArgs e)
        {
            Bottom_Disable();
            Clean_screen();
            file_open = false;
            button_showPalette.Visible = false;
            pictureBox_palette.Visible = false;
        }
        //---------------File menu-------------------File menu-----------------------File menu--------
        //關視窗
        private void Exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        //將result變成source image
        private void Save_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                pictureBox_Source.Image = pictureBox_Result.Image;
                pictureBox_Result.Image = null;
            }
        }
        //儲存成jpeg
        private void Save_as_Click(object sender, EventArgs e)
        {
            //儲存對話框
            SaveFileDialog dialog = new SaveFileDialog();
            //過濾附檔名
            dialog.Filter = "Jpeg File(*.jpeg)|*.jpeg";
            //記憶上次存取的資料夾路徑
            dialog.RestoreDirectory = true;
            //檢查該路徑是否存在
            dialog.CheckPathExists = true;
            string filename = dialog.FileName;
            //預設檔名
            dialog.FileName = Path.GetFileName(filename).Split('.')[0];
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_Source.Image.Save(dialog.FileName, ImageFormat.Jpeg);
            }
        }
        //隱藏大大的header, palette
        private void Invisible_Header_Click(object sender, EventArgs e)
        {
            textBox_ShowHeader.Visible = false;
            button_showPalette.Visible = false;
            pictureBox_palette.Visible = false;
        }
        private void demo_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                pictureBox_Result.Image = pictureBox_Source.Image;
                pictureBox_Source.Image = null;
                file_open = false;
                demo_mode = true;
                Bottom_Disable();
            }
        }
        //---------------Editor menu-------------------Editor menu--------------------Editor menu------
        //---------------Crop--------------------------Crop---------------------------Crop-------------
        //Crop Rect
        private void Crop_Rectangle_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                crop_Rect_click = true;
                crop_Oval_click = false;
                crop_Line_click = false;
            }
        }
        //Crop Oval
        private void Crop_Oval_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                crop_Rect_click = false;
                crop_Oval_click = true;
                crop_Line_click = false;
            }
        }
        //Crop 不規則封閉線
        private void Crop_CloseLine_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
            cutPolygon poly = new cutPolygon(newBitmap);
            poly.Show();
        }
        //抓矩形
        private Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }
        //抓起始點
        private void Crop_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoubleBuffered = true;
            if ((crop_Rect_click == true || crop_Oval_click == true || crop_Line_click == true) && file_open == true)
            {
                currentPos = startPos = e.Location;
                drawing = true;
            }
        }
        //抓終點 show result
        private void Crop_MouseUp(object sender, MouseEventArgs e)
        {
            this.DoubleBuffered = true;
            //crop矩形
            if (drawing && file_open == true && crop_Rect_click == true && crop_Oval_click == false)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                drawing = false;
                var rect1 = getRectangle();
                if ((rect1.Width > 0) && (rect1.Height > 0))
                {
                  Bitmap cropimge = newBitmap.Clone(rect1, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                  pictureBox_Result.Image = cropimge;
                }
            }
            //crop橢圓
            //左上(x0,y0) 右下(x1,y1)
            //a=(x1-x0)/2，b=(y1-y0)/2，X=(x1-x0)/2+x0，Y=(y1-y0)/2+y0
            /*
               ---formula---
               double value = ((x - X) ^2) / (a^2) + ((y - Y) ^2) / b^2; 
               若value <= 1 即該點在在橢圓內 
             */
            if (drawing && file_open == true && crop_Rect_click == false && crop_Oval_click == true)
            {
                int x0, x1, y0, y1;
                double X, Y, a, b;
                double value;
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                Bitmap cropimge;
                Color pixel;
                drawing = false;
                var rect1 = getRectangle();
                if ((rect1.Width > 0) && (rect1.Height > 0))
                {
                    cropimge = new Bitmap(newBitmap.Width, newBitmap.Height);
                    //左上
                    x0 = rect1.Left;
                    y0 = rect1.Top;
                    //右下
                    x1 = rect1.Right;
                    y1 = rect1.Bottom;

                    a = (x1 - x0) / 2;
                    b = (y1 - y0) / 2;
                    X = (x1 - x0) / 2 + x0;
                    Y = (y1 - y0) / 2 + y0;
                    for (int j = y0; j < y1; j++)
                    {
                        for (int i = x0; i < x1; i++)
                        {
                            value = ((i - X) * (i - X)) / (a * a) + ((j - Y) * (j - Y)) / (b * b);
                            //Console.WriteLine(value);
                            if (value <= 1)
                            {
                                pixel = newBitmap.GetPixel(i, j);
                                cropimge.SetPixel(i, j, pixel);
                            }
                        }
                    }
                    pictureBox_Result.Image = cropimge;
                }
            }
            //crop closing line
            if (drawing && file_open == true && crop_Rect_click == false && crop_Oval_click == false && crop_Line_click == true)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                drawing = false;
                
            }
            crop_Rect_click = false;
            crop_Oval_click = false;
            crop_Line_click = false;
            this.Invalidate();

        }
        //畫虛線
        private void OnPaint(object sender, PaintEventArgs e)
        {
            Point[] lines = new Point[100];
            this.DoubleBuffered = true;
            float[] dashValues = { 6, 4, 6, 4 };
            Pen pen = new Pen(Brushes.Red);
            pen.Width = 2.0F;
            pen.DashPattern = dashValues;
            if (drawing && crop_Rect_click == true)
            {
                e.Graphics.DrawRectangle(pen, getRectangle());
                pictureBox_Source.Refresh();
            }
            if (drawing && crop_Oval_click == true)
            {
                e.Graphics.DrawEllipse(pen, startPos.X, startPos.Y, Math.Abs(startPos.X - currentPos.X), Math.Abs(startPos.Y - currentPos.Y));
                pictureBox_Source.Refresh();
            }
            if(drawing && crop_Line_click == true)
            {
                e.Graphics.DrawLines(pen, lines);
            }
            pen.Dispose();
        }
        //status bar + Crop Mousemove
        private void ShowCoordinateAndRGB(object sender, MouseEventArgs e)
        {
            this.DoubleBuffered = true;
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            Bitmap newBitmap;
            Color pixel;
            if (file_open == true)
            {
                status_Coordinate_Bar.Visible = true;
                newBitmap = new Bitmap(pictureBox_Source.Image);
                pixel = newBitmap.GetPixel(coordinates.X, coordinates.Y);
                toolStripStatusLabel1.Text = "(X: " + coordinates.X;
                toolStripStatusLabel2.Text = "Y: " + coordinates.Y + ")";
                toolStripStatusLabel_R.Text = "Red:\t" + pixel.R;
                toolStripStatusLabel_G.Text = "Green:\t" + pixel.G;
                toolStripStatusLabel_B.Text = "Blue:\t" + pixel.B;
            }
            //for crop
            //取得當前鼠標位置
            currentPos = e.Location;
            if (drawing == true && file_open == true && (crop_Rect_click == true || crop_Oval_click == true || crop_Line_click == true))
            {
                //this.Invalidate();
                pictureBox_Source.Refresh();
            }
        }
        //---------------彈跳球---------------------彈跳球-------------------------彈跳球----------------
        private void PlayPool_Click(object sender, EventArgs e)
        {
            //有圖
            if (file_open == true)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                PoolBall poolball = new PoolBall(newBitmap);
                poolball.Show();
            }
            //無圖就開玩
            else
            {
                PoolBall poolball = new PoolBall();
                poolball.Show();
            }

        }
        //---------------Dither---------------------Dither------------------------Dither----------------
        //Dither 沒想法
        private void Dither_Click(object sender, EventArgs e)
        {
            /*待處理*/
        }
        //---------------MagicWand------------------MagicWand---------------------MagicWand--------------
        private void MagicWand_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
            magicwand magicwand = new magicwand(newBitmap);
            magicwand.Show();
        }
        //---------------Rotation------------------Rotation---------------------Rotation----------------
        //正轉 "有空洞"
        private void Positive_Rotation_Click(object sender, EventArgs e)
        {
            Positive_rotate = true;
            label_RD.Visible = true;
            textBox_RD.Visible = true;
            Bitmap newBitmap;
            double degree;
            if (file_open == true && textBox_RD.Text != "")
            {
                degree = Convert.ToDouble(textBox_RD.Text.ToString());
                newBitmap = new Bitmap(pictureBox_Source.Image);
                Rotation rotation = new Rotation();
                newBitmap = rotation.rotateImageDis(newBitmap, degree);
                pictureBox_Result.Image = newBitmap;
            }
        }
        //反轉 "無空洞"
        private void Negative_Rotation_Click(object sender, EventArgs e)
        {
            Positive_rotate = false;
            label_RD.Visible = true;
            textBox_RD.Visible = true;
            Bitmap newBitmap;
            double degree;
            if (file_open == true && textBox_RD.Text != "")
            {
                degree = Convert.ToDouble(textBox_RD.Text.ToString());
                newBitmap = new Bitmap(pictureBox_Source.Image);
                Rotation rotation = new Rotation();
                newBitmap = rotation.rotateImageOri(newBitmap, degree);
                pictureBox_Result.Image = newBitmap;
            }
        }
        //rotation textbox 接收到 enter
        private void Rotaion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Bitmap newBitmap;
                double degree;
                if (file_open == true && textBox_RD.Text != "" && Positive_rotate == false)
                {
                    //防範非法輸入
                    bool vaild = double.TryParse(textBox_RD.Text, out degree);
                    if(vaild == true && degree >=0 && degree <= 360)
                    {
                        newBitmap = new Bitmap(pictureBox_Source.Image);
                        Rotation rotation = new Rotation();
                        newBitmap = rotation.rotateImageOri(newBitmap, degree);
                        pictureBox_Result.Image = newBitmap;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the 0 ~ 360 number");
                    }
                }
                else if (file_open == true && textBox_RD.Text != "" && Positive_rotate == true)
                {
                    //防範非法輸入
                    bool vaild = double.TryParse(textBox_RD.Text, out degree);
                    if (vaild == true && degree >= 0 && degree <= 360)
                    {
                        newBitmap = new Bitmap(pictureBox_Source.Image);
                        Rotation rotation = new Rotation();
                        newBitmap = rotation.rotateImageDis(newBitmap, degree);
                        pictureBox_Result.Image = newBitmap;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the 0~360 number");
                    }
                }
            }
        }
        //---------------SetPixel------------------SetPixel---------------------SetPixel----------------
        //把按鈕叫出來 並把set_pixel_click設為true
        private void SetPixel_Click(object sender, EventArgs e)
        {
            label_R.Visible = true;
            label_G.Visible = true;
            label_B.Visible = true;
            textBox_PixelR.Visible = true;
            textBox_PixelG.Visible = true;
            textBox_PixelB.Visible = true;
            set_pixel_click = true;
        }
        //改鼠標上點的pixel值
        private void Set_Pixel_Method(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            Bitmap newBitmap;
            Color pixel, newpixel;
            int R, G, B;
            if (file_open == true && set_pixel_click == true)
            {
                newBitmap = new Bitmap(pictureBox_Source.Image);
                pixel = newBitmap.GetPixel(coordinates.X, coordinates.Y);
                if (textBox_PixelR.Text != "" && textBox_PixelG.Text != "" && textBox_PixelB.Text != "")
                {
                    //防範非法輸入
                    bool vaildR = int.TryParse(textBox_PixelR.Text, out R);
                    bool vaildG = int.TryParse(textBox_PixelG.Text, out G);
                    bool vaildB = int.TryParse(textBox_PixelB.Text, out B);
                    if(vaildR == true && vaildG == true && vaildB == true && R >= 0 && G >=0 && B >=0 && R <=255 && G <= 255 && B <= 255)
                    {
                        newpixel = Color.FromArgb(R, G, B);
                        newBitmap.SetPixel(coordinates.X, coordinates.Y, newpixel);
                        pictureBox_Source.Image = newBitmap;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the 0 ~ 255 number");
                    }
                }
            }
        }
        //---------------RGBChannel------------------RGBChannel--------------------RGBChannel------------
        //Red_Channel
        private void R_Channel_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap;
            Color pixel, newpixel;
            int R;
            if (file_open == true)
            {
                newBitmap = new Bitmap(pictureBox_Source.Image);
                for (int i = 0; i < newBitmap.Height; i++)
                {
                    for (int j = 0; j < newBitmap.Width; j++)
                    {
                        pixel = newBitmap.GetPixel(i, j);
                        R = pixel.R;
                        newpixel = Color.FromArgb(R, 0, 0);
                        newBitmap.SetPixel(i, j, newpixel);
                    }
                }
                pictureBox_Result.Image = newBitmap;
            }
        }
        //Green_Channel
        private void G_Channel_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap;
            Color pixel, newpixel;
            int G;
            if (file_open == true)
            {
                newBitmap = new Bitmap(pictureBox_Source.Image);
                for (int i = 0; i < newBitmap.Height; i++)
                {
                    for (int j = 0; j < newBitmap.Width; j++)
                    {
                        pixel = newBitmap.GetPixel(i, j);
                        G = pixel.G;
                        newpixel = Color.FromArgb(0, G, 0);
                        newBitmap.SetPixel(i, j, newpixel);
                    }
                }
                pictureBox_Result.Image = newBitmap;
            }
        }
        //Blue_Channel
        private void B_Channel_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap;
            Color pixel, newpixel;
            int B;
            if (file_open == true)
            {
                newBitmap = new Bitmap(pictureBox_Source.Image);
                for (int i = 0; i < newBitmap.Height; i++)
                {
                    for (int j = 0; j < newBitmap.Width; j++)
                    {
                        pixel = newBitmap.GetPixel(i, j);
                        B = pixel.B;
                        newpixel = Color.FromArgb(0, 0, B);
                        newBitmap.SetPixel(i, j, newpixel);
                    }
                }
                pictureBox_Result.Image = newBitmap;
            }
        }
        //---------------Zoom-----------------------Zoom---------------------------Zoom------------------
        //複製(放大)or直接刪除法(縮小)
        private void Zoom_Duplication_Click(object sender, EventArgs e)
        {
            label_Zoom.Visible = true;
            zoom_duplication = true;
            textBox_Zoom.Visible = true;
            Bitmap newBitmap;
            double Ratio;
            if (file_open == true && textBox_Zoom.Text != "")
            {
                Ratio = Convert.ToDouble(textBox_Zoom.Text.ToString());
                newBitmap = new Bitmap(pictureBox_Source.Image);
                newBitmap =  Zoom.zoomInImageNear(newBitmap, Ratio);
                pictureBox_Result.Image = newBitmap;
            }
        }
        //雙線性內插的放大縮小
        private void Zoom_linearInterpolation_Click(object sender, EventArgs e)
        {
            label_Zoom.Visible = true;
            zoom_duplication = false;
            textBox_Zoom.Visible = true;
            Bitmap newBitmap;
            double Ratio;
            if (file_open == true && textBox_Zoom.Text != "")
            {
                Ratio = Convert.ToDouble(textBox_Zoom.Text.ToString());
                newBitmap = new Bitmap(pictureBox_Source.Image);
                newBitmap =  Zoom.zoomInImageLine(newBitmap, Ratio);
                pictureBox_Result.Image = newBitmap;
            }
        }
        //zoom textbox 接收到 enter
        private void Zoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Bitmap newBitmap;
                double Ratio;
                //zoom_duplication 為true為simple duplication
                if (file_open == true && textBox_Zoom.Text != "" && zoom_duplication == true)
                {
                    //防範非法輸入
                    bool vaild = double.TryParse(textBox_Zoom.Text, out Ratio);
                    if(vaild == true && Ratio <= 3 && Ratio >= 0.1)
                    {
                        newBitmap = new Bitmap(pictureBox_Source.Image);
                        newBitmap = Zoom.zoomInImageNear(newBitmap, Ratio);
                        pictureBox_Result.Image = newBitmap;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the 0.1 ~ 3.0 number");
                    }
                }
                //zoom_duplication 為false則為double interpolation
                else if (file_open == true && textBox_Zoom.Text != "" && zoom_duplication == false)
                {
                    bool vaild = double.TryParse(textBox_Zoom.Text, out Ratio);
                    if (vaild == true && Ratio <= 3 && Ratio >= 0.1)
                    {
                        newBitmap = new Bitmap(pictureBox_Source.Image);
                        newBitmap = Zoom.zoomInImageLine(newBitmap, Ratio);
                        pictureBox_Result.Image = newBitmap;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the 0.1 ~ 3 number");
                    }
                }
            }
        }
        //---------------Alpha----------------------Alpha--------------------------Alpha-----------------
        //透明度->先漸層
        private void Alpha_Click(object sender, EventArgs e)
        {
            textBox_Alpha.Visible = true;
            label_Alpha.Visible = true;
            //double counter = 1.0;
            if(file_open == true)
            {
                //開另一個圖層 to 透明度操作
                dialog.Title = "請選擇檔案";
                dialog.Filter = "所有檔案(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filename = dialog.FileName;
                    /*alpha參數值越小 前景比例越多*/
                    /*匯入後景圖*/
                    readHeader image = new readHeader(filename);
                    byte[] image_byte = File.ReadAllBytes(filename);
                    readMidResource PCX_Middle = new readMidResource(filename);
                    PCX_Middle.DecoPcx(image_byte);
                    back_image = PCX_Middle.getDecoImage;
                    front_image = new Bitmap(pictureBox_Source.Image);
                    //reset
                    textBox_Alpha.Text = ""; 
                    alpha_already = true;
                    timer1.Enabled = true;
                    pictureBox_Result.Image = pictureBox_Source.Image;
                }
            }
        }
        //enter alpha值 output
        private void Alpha_KeyDown(object sender, KeyEventArgs e)
        {
            Alpha alpha = new Alpha();
            string filename = dialog.FileName;
            double degree;
            if (e.KeyCode == Keys.Enter)
            {
                if (file_open == true && textBox_Alpha.Text != "")
                {
                    //Result已經有圖
                    if(pictureBox_Result.Image != null)
                    {
                        //防範非法輸入
                        bool vaild = double.TryParse(textBox_Alpha.Text, out degree);
                        if(vaild == true && degree <= 100 && degree >= 0)
                        {
                            alpha_image = alpha.alphaImage(front_image, back_image, degree);
                            pictureBox_Result.Image = alpha_image;
                        }
                        else
                        {
                            MessageBox.Show("Please Enter the 0.0 ~ 100 number");
                        }
                    }
                    //Result沒圖
                    //開另一個圖層 to 透明度操作
                    else
                    {
                        dialog.Title = "請選擇檔案";
                        dialog.Filter = "所有檔案(*.*)|*.*";
                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            //防範非法輸入
                            bool vaild = double.TryParse(textBox_Alpha.Text, out degree);
                            if (vaild == true && degree <= 100 && degree >= 0)
                            {
                                /*alpha參數值越小 前景比例越多*/
                                /*匯入後景圖*/
                                readHeader image = new readHeader(filename);
                                byte[] image_byte = File.ReadAllBytes(filename);
                                readMidResource PCX_Middle = new readMidResource(filename);
                                PCX_Middle.DecoPcx(image_byte);
                                front_image = new Bitmap(pictureBox_Source.Image);
                                back_image = PCX_Middle.getDecoImage;
                                alpha_image = alpha.alphaImage(front_image, back_image, degree);
                                pictureBox_Result.Image = alpha_image;
                            }
                            else
                            {
                                MessageBox.Show("Please Enter the 0.0 ~ 100 number");
                            }
                        }                                  
                    }
                }

            }
        }
        //alpha show漸層
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (file_open == true && alpha_already == true)
            {
                timer_counter += 10;
                Alpha alpha = new Alpha();
                //漸層
                if (timer_counter <= 100)
                {
                    alpha_image = alpha.alphaImage(front_image, back_image, timer_counter);
                    pictureBox_Result.Image = alpha_image;
                }
                //finish reset
                else
                {
                    timer_counter = 0;
                    timer1.Enabled = false;
                    alpha_already = false;
                }
                //textBox_Alpha.Text = timer_counter.ToString();
            }
        }
        //---------------負片----------------------負片---------------------------負片--------------------
        private void RGB_Negative(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                pictureBox_Result.Image = null;
                Bitmap newBitmap, source;
                source = new Bitmap(pictureBox_Source.Image);
                newBitmap = Negative.RGB_Inverse(source);
                pictureBox_Result.Image = newBitmap;
            }
        }
        private void Gray_Negative(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                pictureBox_Result.Image = null;
                Bitmap newBitmap, source;
                source = new Bitmap(pictureBox_Source.Image);
                newBitmap = Negative.Gray_Inverse(source);
                pictureBox_Result.Image = newBitmap;
            }
        }
        //---------------形變,剪切---------------形變,剪切---------------------形變,剪切-------------------
        private void Shear_Click(object sender, EventArgs e)
        {
            textBox_shearX.Text = "";
            label_ShearX.Visible = true;
            textBox_shearX.Visible = true;
        }        
        //shearX textbox 接收到 enter
        private void ShearX_KeyDown(object sender, KeyEventArgs e)
        {
            int shearX = 0;
            Bitmap newBitmap;
            if (e.KeyCode == Keys.Enter)
            {
                if (file_open == true)
                {
                    //防範非法輸入
                    bool vaildX = int.TryParse(textBox_shearX.Text, out shearX);
                    if (vaildX == true && shearX >= 0 && shearX <= 3)
                    {
                        newBitmap = new Bitmap(pictureBox_Source.Image);
                        newBitmap = Shear.Xsharing(newBitmap, shearX);
                        pictureBox_Result.Image = newBitmap;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the 0 ~ 3 number");
                    }
                }

            }
        }
        //---------------Gray level-------------Gray level-------------------Gray level------------------
        //用公式求灰階
        private void Gray_Formula_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap;
            if (file_open == true)
            {
                newBitmap = new Bitmap(pictureBox_Source.Image);
                Gray gray = new Gray();
                newBitmap = gray.RGBtoGray_formula(newBitmap);
                pictureBox_Result.Image = newBitmap;
            }
        }
        //(R+G+B)/3
        private void Gray_Average_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap;
            if (file_open == true)
            {
                newBitmap = new Bitmap(pictureBox_Source.Image);
                Gray gray = new Gray();
                newBitmap = gray.RGBtoGray_average(newBitmap);
                pictureBox_Result.Image = newBitmap;
            }
        }
        //---------------失真----------------------失真---------------------------失真--------------------
        //向右偏移offset個pixel
        private void MissAlignment_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap;
            label_MAoffset.Visible = true;
            textBox_MAoffset.Visible = true;
            missAlignmentToolStripMenuItem.Enabled = true;
            int offset;
            if (file_open == true && textBox_MAoffset.Text != "")
            {
                newBitmap = new Bitmap(pictureBox_Source.Image);
                Missalignment missalignment = new Missalignment();
                offset = int.Parse(textBox_MAoffset.Text);
                newBitmap = missalignment.miss_alignment(newBitmap, offset);
                pictureBox_Result.Image = newBitmap;
            }
        }
        //enter接收offset值
        private void textBox_MAoffset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Bitmap newBitmap;
                int offset;
                if (file_open == true && textBox_MAoffset.Text != "")
                {
                    //防範非法輸入
                    bool vaild = int.TryParse(textBox_MAoffset.Text, out offset);
                    if(vaild == true &&　offset >= 0 && offset <= 255)
                    {
                        newBitmap = new Bitmap(pictureBox_Source.Image);
                        Missalignment missalignment = new Missalignment();
                        offset = int.Parse(textBox_MAoffset.Text);
                        newBitmap = missalignment.miss_alignment(newBitmap, offset);
                        pictureBox_Result.Image = newBitmap;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the 0 ~ 255 number");
                    }
                }
            }
        }
        //---------------Histogram----------------Histogram------------------------Histogram-------------
        //RGB直方圖
        private void Histogram_RGB_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                Histogram_RGB Histo = new Histogram_RGB();
                Histo.Histogram(newBitmap);
                Histo.Show();
            }
        }
        //Gray直方圖 若原圖不是Gray level 會先經過average轉gray level
        private void Histogram_Gray_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                Histogram_GrayAndEqualization Histo = new Histogram_GrayAndEqualization();
                Histo.Histogram(newBitmap);
                Histo.Show();
            }
        }
        //Histogram Equalizition
        private void Histogeam_Equlization_Click(object sender, EventArgs e)
        {
            double[] rate = new double[256];
            if (file_open == true)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                //RGB to Gray
                Gray gray = new Gray();
                newBitmap = gray.RGBtoGray_formula(newBitmap);
                //get rate
                rate = Histogram_GrayAndEqualization.Return_PixelRate(newBitmap);
                //Equalization
                newBitmap = Histogram_GrayAndEqualization.Equalization(newBitmap, rate);
                pictureBox_Result.Image = newBitmap;
            }
        }
        //待處理
        private void Histogram_Specification_Click(object sender, EventArgs e)
        {

        }
        //---------------對比拉伸--------------------對比拉伸--------------------------對比拉伸-------------
        private void CSmanual_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                //灰階處理(公式)
                Gray gray = new Gray();
                newBitmap = gray.RGBtoGray_formula(newBitmap);
                //對比拉伸
                Contrast_Streching contrast = new Contrast_Streching(newBitmap);
                contrast.Show();
            }
        }
        //預設 砍前砍後5%
        private void CSpreset_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
            //灰階處理(公式)
            Gray gray = new Gray();
            newBitmap = gray.RGBtoGray_formula(newBitmap);
            contrastPreset contrast = new contrastPreset(newBitmap);
            contrast.Show();
            newBitmap = contrast.preset(newBitmap);
            pictureBox_Result.Image = newBitmap;
        }
        //---------------Bit Plane--------------------Bit Plane-----------------------Bit Plane------------
        //slicing
        bool gray_code = false;
        private void BitPlaneSlicing_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                gray_code = false;
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                //灰階處理(公式)
                Gray gray = new Gray();
                //用公式 Bit plane 7會全黑
                newBitmap = gray.RGBtoGray_average(newBitmap);
                //Bit plane slicing
                BitPlaneSlicing bitPlaneSlicing = new BitPlaneSlicing(newBitmap, gray_code);
                bitPlaneSlicing.Show();
            }
        }
        //Gray Code
        private void grayCode_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                gray_code = true;
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                //灰階處理(公式)
                Gray gray = new Gray();
                //用公式 Bit plane 7會全黑
                newBitmap = gray.RGBtoGray_average(newBitmap);
                //Bit plane slicing
                gray_code = true;
                BitPlaneSlicing bitPlaneSlicing = new BitPlaneSlicing(newBitmap, gray_code);
                bitPlaneSlicing.Show();
            }

        }
        //浮水印
        private void Watermark_Click(object sender, EventArgs e)
        {
            Bitmap watermarkImg;
            Image waterBMP;
            if (file_open == true)
            {
                //開另一個圖層 to 浮水印
                dialog.Title = "請選擇檔案";
                dialog.Filter = "所有檔案(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //載入浮水印
                    string filename = dialog.FileName;
                    waterBMP = Image.FromFile(filename);
                    watermarkImg = new Bitmap(waterBMP);
                    //pictureBox_Result.Image = watermarkImg;
                    //-----------------------------------------------------
                    Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                    //灰階處理(公式)
                    Gray gray = new Gray();
                    //用公式 Bit plane 7會全黑
                    newBitmap = gray.RGBtoGray_average(newBitmap);
                    watermarkImg = gray.RGBtoGray_average(watermarkImg);
                    //Watermark
                    //pictureBox_Result.Image = watermarkImg;
                    BitPlaneSlicing Watermark = new BitPlaneSlicing(newBitmap, watermarkImg);
                    Watermark.Show();
                    //可供作確認
                    pictureBox_Result.Image = Watermark.Result;
                    pictureBox_Source.Image = newBitmap;
                }
            }
        }
        //---------------Threshold--------------------Threshold-----------------------Threshold------------
        //手動設T值
        private void Threshold_Manual_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                //灰階處理(average)效果較好
                Gray gray = new Gray();
                newBitmap = gray.RGBtoGray_average(newBitmap);
                //二值化
                Threshold Threshold = new Threshold(newBitmap);
                Threshold.Show();
            }
        }

        //Otsu's
        private void Threshold_Otsu_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                //灰階處理(average)效果較好
                Gray gray = new Gray();
                newBitmap = gray.RGBtoGray_average(newBitmap);
                //最佳二值化
                Threshold Threshold = new Threshold(newBitmap);
                Threshold.Thresholding_Otsu();
                Threshold.Show();
                pictureBox_Result.Image = Threshold.Get_Otsu(newBitmap);
            }
        }


        //---------------SNR---------------------------SNR----------------------------SNR------------------
        private void SNR_Click(object sender, EventArgs e)
        {
            if(pictureBox_Result.Image == null)
            {
                MessageBox.Show("You need to have Source and Result image");
            }
            if (file_open == true && pictureBox_Result.Image != null)
            {
                double value;
                Bitmap source, result;
                source = new Bitmap(pictureBox_Source.Image);
                result = new Bitmap(pictureBox_Result.Image);
                value = snr.SNR(source, result);
                if(value == -1)
                {
                    label_SNR.Text = "SNR: error";
                    label_SNR.Visible = true;
                }
                else
                {
                    value = Math.Round(value, 3);
                    label_SNR.Text = "SNR: " + value;
                    label_SNR.Visible = true;
                }
            }
        }

        //--------------Mirror-------------------------Mirror-------------------------Mirror---------------
        //水平翻
        private void xAxis_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap Source = new Bitmap(pictureBox_Source.Image);
                Bitmap Result = new Bitmap(pictureBox_Source.Image);
                for (int i = 0; i < Source.Height; i++)
                {
                    for (int j = 0; j < Source.Width; j++)
                    {
                        //Console.WriteLine("i " + i + "j " + j + " x , y" +(Source.Height - i) + j + "\n");
                        //Console.WriteLine("height, width " + Result.Height + " " + Result.Width);
                        Result.SetPixel(i, Source.Width - j - 1, Source.GetPixel(i, j));
                    }
                }
                pictureBox_Result.Image = Result;
            }
        }
        //垂直翻
        private void yAxis_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap Source = new Bitmap(pictureBox_Source.Image);
                Bitmap Result = new Bitmap(pictureBox_Source.Image);
                for (int i = 0; i < Source.Height; i++)
                {
                    for (int j = 0; j < Source.Width; j++)
                    {
                        Result.SetPixel(Source.Height - i - 1, j, Source.GetPixel(i, j));
                    }
                }
                pictureBox_Result.Image = Result;
            }
        }
        private void diagonal1_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap Source = new Bitmap(pictureBox_Source.Image);
                Bitmap Result1 = new Bitmap(pictureBox_Source.Image);
                Bitmap Result2 = new Bitmap(pictureBox_Source.Image);
                Bitmap Result3 = new Bitmap(pictureBox_Source.Image);
                //先對角翻
                for (int i = 0; i < Source.Height; i++)
                {
                    for (int j = 0; j < Source.Width; j++)
                    {
                        Result1.SetPixel(j, i, Source.GetPixel(i, j));
                    }
                }
                //再水平+垂直翻
                Source = Result1;
                for (int i = 0; i < Source.Height; i++)
                {
                    for (int j = 0; j < Source.Width; j++)
                    {
                        Result2.SetPixel(Source.Height - i - 1, j, Source.GetPixel(i, j));
                    }
                }
                Source = Result2;
                for (int i = 0; i < Source.Height; i++)
                {
                    for (int j = 0; j < Source.Width; j++)
                    {
                        //Console.WriteLine("i " + i + "j " + j + " x , y" +(Source.Height - i) + j + "\n");
                        //Console.WriteLine("height, width " + Source.Height + " " + Source.Width);
                        Result3.SetPixel(i, Source.Width - j - 1, Source.GetPixel(i, j));
                    }
                }
                pictureBox_Result.Image = Result3;
            }
        }
        private void diagonal2_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap Source = new Bitmap(pictureBox_Source.Image);
                Bitmap Result = new Bitmap(pictureBox_Source.Image);
                //正統水平翻
                for (int i = 0; i < Source.Height; i++)
                {
                    for (int j = 0; j < Source.Width; j++)
                    {
                        Result.SetPixel(j, i, Source.GetPixel(i, j));
                    }
                }
                pictureBox_Result.Image = Result;
                
            }
        }

        //---------------Noise-------------------------Noise--------------------------Noise----------------
        private void noise_SaltNPepper_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap source = new Bitmap(pictureBox_Source.Image);
                source = Noise.AddNoise(source);
                pictureBox_Result.Image = source;
            }
        }

        //---------------Lowpass Filter----------------Lowpass Filter-----------------Lowpass Filter-------
        private void lowpassFilter_Click(object sender, EventArgs e)
        {
            if(file_open == true)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                Gray gray = new Gray();
                newBitmap = gray.RGBtoGray_average(newBitmap);
                Lowpass_Filter lowpass = new Lowpass_Filter(newBitmap);
                lowpass.Show();
            }
        }
        //---------------Highpass Filter---------------Highpass Filter----------------Highpass Filter-------
        private void highpassFilter_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                Gray gray = new Gray();
                newBitmap = gray.RGBtoGray_average(newBitmap);
                Highpass_Filter lowpass = new Highpass_Filter(newBitmap);
                lowpass.Show();
            }
        }
        //--------------Gamma----------------------Gamma-----------------------------Gamma---------------
        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
            Gamma gamma = new Gamma(newBitmap);
            gamma.Show();
        }
        //--------------huffman------------------huffman------------------------------huffman-------------
        private void huffmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] pixels_rate = new double[256];
            int[] pixels = new int[256];
            string[] codes = new string[256];
            if (pictureBox_Source.Image != null)
            {
                for (int i = 0; i < 256; i++)
                {
                    pixels[i] = i;
                }
                if (pictureBox_Source.Image != null)
                {
                    Bitmap origin = new Bitmap(pictureBox_Source.Image);
                    pixels_rate = Histogram_GrayAndEqualization.Return_RGBPixelRate(origin);
                    HuffmanTree tree = new HuffmanTree(pixels_rate);

                    tree.Create();
                    tree.printNode();
                    Console.WriteLine(tree.ToString());
                    codes = tree.huffmancode();

                    Huffman_screen huffman = new Huffman_screen(origin, pixels, pixels_rate, codes);
                    huffman.Show();
                }
            }  
        }

        //-----------ConnectedComponent-------------ConnectedComponent-------------ConnectedComponent-------
        private void connectComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file_open == true)
            {
                Bitmap newBitmap = new Bitmap(pictureBox_Source.Image);
                newBitmap = Threshold.Get_Otsu(newBitmap);
                pictureBox_Source.Image = newBitmap;
                newBitmap = ConnectedComponent.Connected(newBitmap, 0);
                pictureBox_Result.Image = newBitmap;
            }
        }
        //--------------Video--------------------Video--------------------------Video----------------
        private void videoVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Video video = new Video();
            video.Show();
        }

    }
}
