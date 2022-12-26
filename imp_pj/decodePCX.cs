using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace imp_pj
{
    class readMidResource
    {
        public Bitmap DecoImage;
        readHeader FileHead;
        int readIndex;
        public readMidResource(String FilePath)
        {
            if (File.Exists(FilePath)) 
            { 
                DecoPcx(File.ReadAllBytes(FilePath)); 
            } 
            else 
            { 
                return; 
            }
        }
     
        public Bitmap getDecoImage { get { return DecoImage; } }

        public void DecoPcx(byte[] FileBytes)
        {
            readIndex = 128;
            FileHead = new readHeader(FileBytes);
            //invaild -> not a pcx file
            if (FileHead.Manufacturer != 10) return;

            DecoImage = new Bitmap(FileHead.Width, FileHead.Height, PixelFormat.Format24bppRgb);
            //24位元全彩 -> RLE encoding
            if (FileHead.ColorPlanes == 3 && FileHead.BitsPerPixel == 8)
            {
                //鎖記憶體 用指標法
                BitmapData DecoImageData = DecoImage.LockBits(new Rectangle(0, 0, FileHead.Width, FileHead.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                //圖片大小也就是圖片位元組是4的整數倍，那麼Stride與Width是相等的，否則Stride就是大於Width的最小4的整數倍。
                //BitmapData才有Stride
                byte[] Size = new byte[DecoImageData.Height * DecoImageData.Stride];
                byte[] RowRGBData = new byte[0];
                //一次傳一列進去讀
                for (int i = 0; i < DecoImageData.Height; i++)
                {
                    RowRGBData = decode24(FileBytes);
                    Array.Copy(RowRGBData, 0, Size, i * DecoImageData.Stride, RowRGBData.Length);
                }
                Marshal.Copy(Size, 0, DecoImageData.Scan0, Size.Length);
                //解鎖
                DecoImage.UnlockBits(DecoImageData);
            }
            //256色 -> 使用尾部調色盤
            else if (FileHead.ColorPlanes == 1 && FileHead.BitsPerPixel == 8)
            {
                DecoImage = decode8(FileBytes);
            }
        }

        //解析8位256色圖像
        private Bitmap decode8(byte[] FileBytes)
        {

            byte[] AllPixelData = new byte[FileHead.Height * FileHead.Width];
            int EndIndex = FileBytes.Length - 769;
            int HaveWriteTo = 0;
            readTailPalette rtp = new readTailPalette(FileBytes);
            Color[] palette = rtp.getPalette();
            Bitmap Image24bit = new Bitmap(FileHead.Width, FileHead.Height, PixelFormat.Format24bppRgb);
            int index = 0;

            while (true)
            {
                //讀到調色盤前終止
                if (readIndex >= EndIndex) 
                    break;
                byte ByteValue = FileBytes[readIndex];
                // C0 -> 1100 0000
                //大於C0(192) 則為記錄數據，紀錄的是下一個數據作為pixel值將在原圖中連續出線的次數
                if (ByteValue > 0xC0)
                {
                    int Count = ByteValue - 0xC0;
                    readIndex++;
                    for (int i = 0; i < Count; i++)
                    {
                        int RGBIndex = i + HaveWriteTo;
                        AllPixelData[RGBIndex] = FileBytes[readIndex];
                    }
                    HaveWriteTo += Count;
                    readIndex++;
                }
                //真實數據，即原圖對應的pixel值
                else
                {
                    int RGBIndex = HaveWriteTo;
                    AllPixelData[RGBIndex] = ByteValue;
                    readIndex++;
                    HaveWriteTo++;
                }
            }
            for (int j = 0; j < Image24bit.Height; j++)
            {
                for (int i = 0; i < Image24bit.Width; i++)
                {
                    Image24bit.SetPixel(i, j, palette[AllPixelData[index]]);
                    index++;
                }
            }
            return Image24bit;
        }

        //解析24位全真彩圖像
        private byte[] decode24(byte[] FileBytes)
        {
            int lineWidth = FileHead.BytesPerLine;
            byte[] RowRGBData = new byte[lineWidth * 3];
            int HaveWriteTo = 0;
            int Color_Channel = 2;
            while (true)
            {
                byte ByteValue = FileBytes[readIndex];
                // C0 -> 1100 0000
                //大於C0(192) 則為記錄數據，紀錄的是下一個數據作為pixel值將在原圖中連續出線的次數
                if (ByteValue > 0xC0)
                {
                    int Count = ByteValue - 0xC0;
                    readIndex++;
                    for (int i = 0; i < Count; i++)
                    {
                        if (HaveWriteTo + i >= lineWidth)
                        {
                            i = 0;
                            HaveWriteTo = 0;
                            Color_Channel--;
                            Count = Count - i;
                            if (Color_Channel == -1) 
                                break;
                        }
                        int RGBIndex = (i + HaveWriteTo) * 3 + Color_Channel;
                        RowRGBData[RGBIndex] = FileBytes[readIndex];
                    }
                    HaveWriteTo += Count;
                    readIndex++;
                }
                //真實數據，即原圖對應的pixel值
                else
                {
                    int RGBIndex = HaveWriteTo * 3 + Color_Channel;
                    RowRGBData[RGBIndex] = ByteValue;
                    readIndex++;
                    HaveWriteTo++;
                }
                if (HaveWriteTo >= lineWidth)
                {
                    HaveWriteTo = 0;
                    Color_Channel--;
                }
                if (Color_Channel == -1) 
                    break;

            }
            return RowRGBData;
        }
    }
    /*
        讀PCX尾部調色盤 
    */
    class readTailPalette
    {
        //256色 768Bytes
        byte[] imageTailPalette = new byte[768];

        public readTailPalette(String FilePath)
        {
            byte[] imageFile = File.ReadAllBytes(FilePath);
            Array.Copy(imageFile, imageFile.Length - 768, imageTailPalette, 0, 768);
        }

        public readTailPalette(byte[] FileBytes)
        {
            Array.Copy(FileBytes, FileBytes.Length - 768, imageTailPalette, 0, 768);
        }

        public byte[] TailPaletee { get { return imageTailPalette; } }
        
        //獲得調色盤顏色數組
        public Color[] getPalette()
        {
            int k = 3;
            Color[] palette = new Color[256];
            Color RGB;
            for (int i = 0; i < 256; i++)
            {
                RGB = Color.FromArgb(imageTailPalette[i * k], imageTailPalette[i * k + 1], imageTailPalette[i * k + 2]);
                palette.SetValue(RGB, i);
            }
            /*foreach (Color c in palette)
            {
                Console.WriteLine(c.ToString());
            }*/
            
            return palette;
        }
    }
}
