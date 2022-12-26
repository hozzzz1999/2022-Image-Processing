using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace imp_pj
{
    public partial class BitPlaneSlicing : Form
    {
        Bitmap GrayImg;
        Bitmap Watermark_Img;
        public Bitmap Result;
        public BitPlaneSlicing(Bitmap image, bool gray_code)
        {
            InitializeComponent();
            GrayImg = new Bitmap(image.Width, image.Height);
            GrayImg = image;
            pictureBox_source.Image = GrayImg;
            label_SNR.Visible = false;
            if (gray_code == false)
                Slicing();
            else
                grayCodeSlicing();

        }
        public BitPlaneSlicing(Bitmap image, Bitmap watermark)
        {
            InitializeComponent();
            label_SNR.Visible = true;
            GrayImg = new Bitmap(image.Width, image.Height);
            Watermark_Img = new Bitmap(watermark);
            //pictureBox_merge.Image = Watermark_Img;
            GrayImg = image;
            pictureBox_source.Image = GrayImg;
            Result = new Bitmap(Watermark());
        }
        public void Slicing()
        {
            int width = GrayImg.Width;
            int height = GrayImg.Height;

            //8個圖層
            Bitmap level1 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level2 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level3 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level4 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level5 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level6 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level7 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level8 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap reco_img = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            //鎖記憶體
            BitmapData level1Data = level1.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level2Data = level2.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level3Data = level3.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level4Data = level4.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level5Data = level5.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level6Data = level6.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level7Data = level7.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level8Data = level8.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData GrayImgData = GrayImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData RecoImgData = reco_img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //圖片大小也就是圖片位元組是4的整數倍，那麼Stride與Width是相等的，否則Stride就是大於Width的最小4的整數倍
            //BitmapData才有Stride
            int size = GrayImgData.Stride * GrayImgData.Height;

            //指向每個level的第一位
            IntPtr intPtr = GrayImgData.Scan0;
            IntPtr intPtr1 = level1Data.Scan0;
            IntPtr intPtr2 = level2Data.Scan0;
            IntPtr intPtr3 = level3Data.Scan0;
            IntPtr intPtr4 = level4Data.Scan0;
            IntPtr intPtr5 = level5Data.Scan0;
            IntPtr intPtr6 = level6Data.Scan0;
            IntPtr intPtr7 = level7Data.Scan0;
            IntPtr intPtr8 = level8Data.Scan0;
            IntPtr recoPtr = RecoImgData.Scan0;

            //陣列->指標法
            byte[] GrayImgBytes = new byte[size];
            byte[] level1Bytes = new byte[size];
            byte[] level2Bytes = new byte[size];
            byte[] level3Bytes = new byte[size];
            byte[] level4Bytes = new byte[size];
            byte[] level5Bytes = new byte[size];
            byte[] level6Bytes = new byte[size];
            byte[] level7Bytes = new byte[size];
            byte[] level8Bytes = new byte[size];
            byte[] Recovery = new byte[size];

            //array 和 pointer之間的內容複製
            Marshal.Copy(intPtr, GrayImgBytes, 0, size);
            Marshal.Copy(intPtr1, level1Bytes, 0, size);
            Marshal.Copy(intPtr2, level2Bytes, 0, size);
            Marshal.Copy(intPtr3, level3Bytes, 0, size);
            Marshal.Copy(intPtr4, level4Bytes, 0, size);
            Marshal.Copy(intPtr5, level5Bytes, 0, size);
            Marshal.Copy(intPtr6, level6Bytes, 0, size);
            Marshal.Copy(intPtr7, level7Bytes, 0, size);
            Marshal.Copy(intPtr8, level8Bytes, 0, size);
            Marshal.Copy(recoPtr, Recovery, 0, size);

            int k = 3;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    //指標法依序取得每個pixel的graylevel值 (RGB一組 k=3)
                    byte R = GrayImgBytes[i * GrayImgData.Stride + j * k];
                    //Console.WriteLine("i" + i.ToString() + "Stride" + GrayImgData.Stride.ToString() + "j" + j.ToString() + "k" + k.ToString());
                    //Console.WriteLine(i * GrayImgData.Stride + j * k);
                    // 0000 000X 若第n位是1 做and完則會=and值->為255(黑)即1代表黑點 不是則為0(白)
                    int[] label = new int[8];
                    for(int x = 0; x < 8; x++)
                    {
                        label[x] = R & (int)Math.Pow(2,x);
                        if (label[x] != 0)
                            label[x] = 255;
                        else
                            label[x] = 0;
                    }
                    //Console.WriteLine(R + ": " + L1  + " "+ L2 + " " + L3 + " " + L4 + " " + L5 + " " + L6 + " " + L7 + " " + L8 + " ");
                    //gray level R==G==Blabel[0]
                    level1Bytes[i * GrayImgData.Stride + j * k] = (byte)label[0];
                    level1Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[0];
                    level1Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[0];
                    level2Bytes[i * GrayImgData.Stride + j * k] = (byte)label[1];
                    level2Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[1];
                    level2Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[1];
                    level3Bytes[i * GrayImgData.Stride + j * k] = (byte)label[2];
                    level3Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[2];
                    level3Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[2];
                    level4Bytes[i * GrayImgData.Stride + j * k] = (byte)label[3];
                    level4Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[3];
                    level4Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[3];
                    level5Bytes[i * GrayImgData.Stride + j * k] = (byte)label[4];
                    level5Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[4];
                    level5Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[4];
                    level6Bytes[i * GrayImgData.Stride + j * k] = (byte)label[5];
                    level6Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[5];
                    level6Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[5];
                    level7Bytes[i * GrayImgData.Stride + j * k] = (byte)label[6];
                    level7Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[6];
                    level7Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[6];
                    level8Bytes[i * GrayImgData.Stride + j * k] = (byte)label[7];
                    level8Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[7];
                    level8Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[7];
                    //recovery 乘回去
                    //1100 0011 -> 128+64+2+1 = 195label[0]
                    for(int x = 0; x < 8; x++)
                    {
                        if (label[x] != 0)
                        {
                            label[x] = 1;
                        }
                    }
                    int total = label[0] * 1 + label[1] * 2 + label[2] * 4 + label[3] * 8 + label[4] * 16 + label[5] * 32 + label[6] * 64 + label[7] * 128;
                    Recovery[i * GrayImgData.Stride + j * k] = (byte)total;
                    Recovery[i * GrayImgData.Stride + j * k + 1] = (byte)total;
                    Recovery[i * GrayImgData.Stride + j * k + 2] = (byte)total;
                }
            }
            /*destinationType: System.Byte[]要複製到其中的陣列。
              startIndexType: System.Int32複製應該在此處開始之目的地陣列中以零起始的索引。
              sourceType: System.IntPtr要複製的來源記憶體指標。
              lengthType: System.Int32要複製的陣列元素數目。*/
            //array 和 pointer之間的內容複製
            Marshal.Copy(level1Bytes, 0, intPtr1, level1Bytes.Length);
            Marshal.Copy(level2Bytes, 0, intPtr2, level2Bytes.Length);
            Marshal.Copy(level3Bytes, 0, intPtr3, level3Bytes.Length);
            Marshal.Copy(level4Bytes, 0, intPtr4, level4Bytes.Length);
            Marshal.Copy(level5Bytes, 0, intPtr5, level5Bytes.Length);
            Marshal.Copy(level6Bytes, 0, intPtr6, level6Bytes.Length);
            Marshal.Copy(level7Bytes, 0, intPtr7, level7Bytes.Length);
            Marshal.Copy(level8Bytes, 0, intPtr8, level8Bytes.Length);
            Marshal.Copy(Recovery, 0, recoPtr, Recovery.Length);
            //解鎖
            level1.UnlockBits(level1Data);
            level2.UnlockBits(level2Data);
            level3.UnlockBits(level3Data);
            level4.UnlockBits(level4Data);
            level5.UnlockBits(level5Data);
            level6.UnlockBits(level6Data);
            level7.UnlockBits(level7Data);
            level8.UnlockBits(level8Data);
            GrayImg.UnlockBits(GrayImgData);
            reco_img.UnlockBits(RecoImgData);

            label10.Visible = false;
            pictureBox_source.Location = new Point(18, 325);
            label9.Location = new Point(78, 584);
            pictureBox_merge.Visible = true;
            label_Result.Visible = true;
            pictureBox_bitplane0.Image = level1;
            pictureBox_bitplane1.Image = level2;
            pictureBox_bitplane2.Image = level3;
            pictureBox_bitplane3.Image = level4;
            pictureBox_bitplane4.Image = level5;
            pictureBox_bitplane5.Image = level6;
            pictureBox_bitplane6.Image = level7;
            pictureBox_bitplane7.Image = level8;
            //合併還原回去
            pictureBox_merge.Image = reco_img;
            label_Result.Text = "Merge Image";
        }
        public Bitmap Watermark()
        {
            int width = GrayImg.Width;
            int height = GrayImg.Height;

            //8個圖層
            Bitmap level1 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level2 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level3 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level4 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level5 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level6 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level7 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level8 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap reco_img = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            //鎖記憶體
            BitmapData level1Data = level1.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level2Data = level2.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level3Data = level3.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level4Data = level4.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level5Data = level5.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level6Data = level6.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level7Data = level7.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level8Data = level8.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData GrayImgData = GrayImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData WatermarkImgData = Watermark_Img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData RecoImgData = reco_img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //圖片大小也就是圖片位元組是4的整數倍，那麼Stride與Width是相等的，否則Stride就是大於Width的最小4的整數倍。
            //BitmapData才有Stride
            int size = GrayImgData.Stride * GrayImgData.Height;

            //指向每個level的第一位
            IntPtr intPtr = GrayImgData.Scan0;
            IntPtr intPtr1 = level1Data.Scan0;
            IntPtr intPtr2 = level2Data.Scan0;
            IntPtr intPtr3 = level3Data.Scan0;
            IntPtr intPtr4 = level4Data.Scan0;
            IntPtr intPtr5 = level5Data.Scan0;
            IntPtr intPtr6 = level6Data.Scan0;
            IntPtr intPtr7 = level7Data.Scan0;
            IntPtr intPtr8 = level8Data.Scan0;
            IntPtr recoPtr = RecoImgData.Scan0;
            IntPtr watermarkPtr = WatermarkImgData.Scan0;


            byte[] GrayImgBytes = new byte[size];
            byte[] level1Bytes = new byte[size];
            byte[] level2Bytes = new byte[size];
            byte[] level3Bytes = new byte[size];
            byte[] level4Bytes = new byte[size];
            byte[] level5Bytes = new byte[size];
            byte[] level6Bytes = new byte[size];
            byte[] level7Bytes = new byte[size];
            byte[] level8Bytes = new byte[size];
            byte[] Recovery = new byte[size];
            byte[] watermarkBytes = new byte[size];

            Marshal.Copy(intPtr, GrayImgBytes, 0, size);
            Marshal.Copy(intPtr1, level1Bytes, 0, size);
            Marshal.Copy(intPtr2, level2Bytes, 0, size);
            Marshal.Copy(intPtr3, level3Bytes, 0, size);
            Marshal.Copy(intPtr4, level4Bytes, 0, size);
            Marshal.Copy(intPtr5, level5Bytes, 0, size);
            Marshal.Copy(intPtr6, level6Bytes, 0, size);
            Marshal.Copy(intPtr7, level7Bytes, 0, size);
            Marshal.Copy(intPtr8, level8Bytes, 0, size);
            Marshal.Copy(recoPtr, Recovery, 0, size);
            Marshal.Copy(watermarkPtr, watermarkBytes, 0, size);

            int k = 3;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    //指標法依序取得每個pixel的graylevel值 (RGB一組 k=3)
                    byte R = GrayImgBytes[i * GrayImgData.Stride + j * k];
                    //get watermark pixel
                    byte mark = watermarkBytes[i * GrayImgData.Stride + j * k];

                    //Console.WriteLine("i" + i.ToString() + "Stride" + GrayImgData.Stride.ToString() + "j" + j.ToString() + "k" + k.ToString());
                    //Console.WriteLine(i * GrayImgData.Stride + j * k);
                    // 0000 000X 若第n位是1 做and完則會=and值->為255(白)即1代表白點 不是則為0(黑)
                    int[] label = new int[8];
                    label[0] = mark;
                    for (int x = 0; x < 8; x++)
                    {
                        label[x] = R & (int)Math.Pow(2, x);
                        if (label[x] != 0)
                            label[x] = 255;
                        else
                            label[x] = 0;
                    }
                    //Console.WriteLine(R + ": " + L1 + " " + L2 + " " + L3 + " " + L4 + " " + L5 + " " + L6 + " " + L7 + " " + L8 + " ");
                    level1Bytes[i * GrayImgData.Stride + j * k] = (byte)label[0];
                    level1Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[0];
                    level1Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[0];
                    level2Bytes[i * GrayImgData.Stride + j * k] = (byte)label[1];
                    level2Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[1];
                    level2Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[1];
                    level3Bytes[i * GrayImgData.Stride + j * k] = (byte)label[2];
                    level3Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[2];
                    level3Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[2];
                    level4Bytes[i * GrayImgData.Stride + j * k] = (byte)label[3];
                    level4Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[3];
                    level4Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[3];
                    level5Bytes[i * GrayImgData.Stride + j * k] = (byte)label[4];
                    level5Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[4];
                    level5Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[4];
                    level6Bytes[i * GrayImgData.Stride + j * k] = (byte)label[5];
                    level6Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[5];
                    level6Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[5];
                    level7Bytes[i * GrayImgData.Stride + j * k] = (byte)label[6];
                    level7Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[6];
                    level7Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[6];
                    level8Bytes[i * GrayImgData.Stride + j * k] = (byte)label[7];
                    level8Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)label[7];
                    level8Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)label[7];
                    //recovery 合併回去
                    if (mark != 0) { mark = 1; }
                    for (int x = 1; x < 8; x++)
                    {
                        if (label[x] != 0)
                        {
                            label[x] = 1;
                        }
                    }
                    int total = mark * 1 + label[1] * 2 + label[2] * 4 + label[3] * 8 + label[4] * 16 + label[5] * 32 + label[6] * 64 + label[7] * 128;
                    Recovery[i * GrayImgData.Stride + j * k] = (byte)total;
                    Recovery[i * GrayImgData.Stride + j * k + 1] = (byte)total;
                    Recovery[i * GrayImgData.Stride + j * k + 2] = (byte)total;
                }
            }
            /*destinationType: System.Byte[]要複製到其中的陣列。
              startIndexType: System.Int32複製應該在此處開始之目的地陣列中以零起始的索引。
              sourceType: System.IntPtr要複製的來源記憶體指標。
              lengthType: System.Int32要複製的陣列元素數目。*/
            Marshal.Copy(level1Bytes, 0, intPtr1, level1Bytes.Length);
            Marshal.Copy(level2Bytes, 0, intPtr2, level2Bytes.Length);
            Marshal.Copy(level3Bytes, 0, intPtr3, level3Bytes.Length);
            Marshal.Copy(level4Bytes, 0, intPtr4, level4Bytes.Length);
            Marshal.Copy(level5Bytes, 0, intPtr5, level5Bytes.Length);
            Marshal.Copy(level6Bytes, 0, intPtr6, level6Bytes.Length);
            Marshal.Copy(level7Bytes, 0, intPtr7, level7Bytes.Length);
            Marshal.Copy(level8Bytes, 0, intPtr8, level8Bytes.Length);
            Marshal.Copy(Recovery, 0, recoPtr, Recovery.Length);
            Marshal.Copy(watermarkBytes, 0, watermarkPtr, watermarkBytes.Length);
            //解鎖
            level1.UnlockBits(level1Data);
            level2.UnlockBits(level2Data);
            level3.UnlockBits(level3Data);
            level4.UnlockBits(level4Data);
            level5.UnlockBits(level5Data);
            level6.UnlockBits(level6Data);
            level7.UnlockBits(level7Data);
            level8.UnlockBits(level8Data);
            GrayImg.UnlockBits(GrayImgData);
            reco_img.UnlockBits(RecoImgData);
            Watermark_Img.UnlockBits(WatermarkImgData);

            label10.Visible = false;
            pictureBox_bitplane0.Image = level1;
            pictureBox_bitplane1.Image = level2;
            pictureBox_bitplane2.Image = level3;
            pictureBox_bitplane3.Image = level4;
            pictureBox_bitplane4.Image = level5;
            pictureBox_bitplane5.Image = level6;
            pictureBox_bitplane6.Image = level7;
            pictureBox_bitplane7.Image = level8;
            pictureBox_merge.Image = reco_img;
            label_Result.Text = "Add Watermark";
            double value;
            value = snr.SNR(GrayImg, reco_img);
            if (value == -1)
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
            return reco_img;
        }

        public void grayCodeSlicing()
        {
            int width = GrayImg.Width;
            int height = GrayImg.Height;

            Bitmap level1 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level2 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level3 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level4 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level5 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level6 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level7 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap level8 = new Bitmap(width, height, PixelFormat.Format24bppRgb);


            BitmapData level1Data = level1.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level2Data = level2.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level3Data = level3.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level4Data = level4.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level5Data = level5.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level6Data = level6.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level7Data = level7.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData level8Data = level8.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData GrayImgData = GrayImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int size = GrayImgData.Stride * GrayImgData.Height;

            IntPtr intPtr = GrayImgData.Scan0;
            IntPtr intPtr1 = level1Data.Scan0;
            IntPtr intPtr2 = level2Data.Scan0;
            IntPtr intPtr3 = level3Data.Scan0;
            IntPtr intPtr4 = level4Data.Scan0;
            IntPtr intPtr5 = level5Data.Scan0;
            IntPtr intPtr6 = level6Data.Scan0;
            IntPtr intPtr7 = level7Data.Scan0;
            IntPtr intPtr8 = level8Data.Scan0;


            byte[] GrayImgBytes = new byte[size];
            byte[] level1Bytes = new byte[size];
            byte[] level2Bytes = new byte[size];
            byte[] level3Bytes = new byte[size];
            byte[] level4Bytes = new byte[size];
            byte[] level5Bytes = new byte[size];
            byte[] level6Bytes = new byte[size];
            byte[] level7Bytes = new byte[size];
            byte[] level8Bytes = new byte[size];

            Marshal.Copy(intPtr, GrayImgBytes, 0, size);
            Marshal.Copy(intPtr1, level1Bytes, 0, size);
            Marshal.Copy(intPtr2, level2Bytes, 0, size);
            Marshal.Copy(intPtr3, level3Bytes, 0, size);
            Marshal.Copy(intPtr4, level4Bytes, 0, size);
            Marshal.Copy(intPtr5, level5Bytes, 0, size);
            Marshal.Copy(intPtr6, level6Bytes, 0, size);
            Marshal.Copy(intPtr7, level7Bytes, 0, size);
            Marshal.Copy(intPtr8, level8Bytes, 0, size);

            //RGB
            int k = 3;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    byte R = GrayImgBytes[i * GrayImgData.Stride + j * k];

                    int[] label = new int[8];
                    int[] graycode = new int[8];
                    for (int x = 0; x < 8; x++)
                    {
                        label[x] = R & (int)Math.Pow(2, x);
                        if (label[x] != 0)
                            label[x] = 255;
                        else
                            label[x] = 0;
                        // n ^ (n >> 1)
                        if (x == 7)
                            graycode[x] = label[x];
                        else
                            graycode[x] = label[x + 1] ^ label[x];
                        if (graycode[x] != 0)
                            graycode[x] = 255;
                    }

                    level1Bytes[i * GrayImgData.Stride + j * k] = (byte)graycode[0];
                    level1Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)graycode[0];
                    level1Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)graycode[0];
                    level2Bytes[i * GrayImgData.Stride + j * k] = (byte)graycode[1];
                    level2Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)graycode[1];
                    level2Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)graycode[1];
                    level3Bytes[i * GrayImgData.Stride + j * k] = (byte)graycode[2];
                    level3Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)graycode[2];
                    level3Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)graycode[2];
                    level4Bytes[i * GrayImgData.Stride + j * k] = (byte)graycode[3];
                    level4Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)graycode[3];
                    level4Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)graycode[3];
                    level5Bytes[i * GrayImgData.Stride + j * k] = (byte)graycode[4];
                    level5Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)graycode[4];
                    level5Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)graycode[4];
                    level6Bytes[i * GrayImgData.Stride + j * k] = (byte)graycode[5];
                    level6Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)graycode[5];
                    level6Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)graycode[5];
                    level7Bytes[i * GrayImgData.Stride + j * k] = (byte)graycode[6];
                    level7Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)graycode[6];
                    level7Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)graycode[6];
                    level8Bytes[i * GrayImgData.Stride + j * k] = (byte)graycode[7];
                    level8Bytes[i * GrayImgData.Stride + j * k + 1] = (byte)graycode[7];
                    level8Bytes[i * GrayImgData.Stride + j * k + 2] = (byte)graycode[7];
                }
            }
            Marshal.Copy(level1Bytes, 0, intPtr1, level1Bytes.Length);
            Marshal.Copy(level2Bytes, 0, intPtr2, level2Bytes.Length);
            Marshal.Copy(level3Bytes, 0, intPtr3, level3Bytes.Length);
            Marshal.Copy(level4Bytes, 0, intPtr4, level4Bytes.Length);
            Marshal.Copy(level5Bytes, 0, intPtr5, level5Bytes.Length);
            Marshal.Copy(level6Bytes, 0, intPtr6, level6Bytes.Length);
            Marshal.Copy(level7Bytes, 0, intPtr7, level7Bytes.Length);
            Marshal.Copy(level8Bytes, 0, intPtr8, level8Bytes.Length);

            level1.UnlockBits(level1Data);
            level2.UnlockBits(level2Data);
            level3.UnlockBits(level3Data);
            level4.UnlockBits(level4Data);
            level5.UnlockBits(level5Data);
            level6.UnlockBits(level6Data);
            level7.UnlockBits(level7Data);
            level8.UnlockBits(level8Data);
            GrayImg.UnlockBits(GrayImgData);

            pictureBox_source.Location = new Point(171, 347);
            label9.Location = new Point(239, 606);
            pictureBox_merge.Visible = false;
            label_Result.Visible = false;
            pictureBox_bitplane0.Image = level1;
            pictureBox_bitplane1.Image = level2;
            pictureBox_bitplane2.Image = level3;
            pictureBox_bitplane3.Image = level4;
            pictureBox_bitplane4.Image = level5;
            pictureBox_bitplane5.Image = level6;
            pictureBox_bitplane6.Image = level7;
            pictureBox_bitplane7.Image = level8;
        }
    }
}
