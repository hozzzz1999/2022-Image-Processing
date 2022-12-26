using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms.VisualStyles;

namespace imp_pj
{
    class readHeader
    {
        byte[] imageHeader = new byte[128];

        //讀PCX Header部分
        public readHeader(byte[] FileData)
        {
                Array.Copy(FileData, imageHeader, 128);
        }

        public readHeader(String FilePath)
        {
            byte[] imageFile = File.ReadAllBytes(FilePath);
            Array.Copy(imageFile, imageHeader, 128);
        }

        //必須為10 不為10不是PCX
        public byte Manufacturer { get { return imageHeader[0]; } }
        //版本，5代表尾部有256色的palette
        public byte Version { get { return imageHeader[1]; } }
        //Encoding方式，1為RLE壓縮法
        public byte Encoding { get { return imageHeader[2]; } }
        //每個平面的每個pixel有幾位
        public byte BitsPerPixel { get { return imageHeader[3]; } }
        //圖像邊界 通常（0，0）to（X,Y），以pixel為單位，真實長寬+1
        public ushort Xmin { get { return BitConverter.ToUInt16(imageHeader, 4); } }
        public ushort Ymin { get { return BitConverter.ToUInt16(imageHeader, 6); } }
        public ushort Xmax { get { return BitConverter.ToUInt16(imageHeader, 8); } }
        public ushort Ymax { get { return BitConverter.ToUInt16(imageHeader, 10); } }
        //水平分辨率，每英寸點pixel數
        public ushort Hres { get { return BitConverter.ToUInt16(imageHeader, 12); } }
        //垂直分辨率，每英寸點pixel數
        public ushort Vres { get { return BitConverter.ToUInt16(imageHeader, 14); } }
        //默認調色盤
        public byte[] Byte_Palette 
        { 
            get 
            { 
                byte[] palette = new byte[48]; 
                Array.Copy(imageHeader, 16, palette, 0, 48); 
                return palette;
            } 
        }
        //保留
        public byte Reserve { get { return imageHeader[64]; } }
        //顏色平面數 BitsPerPixel = 8 and ColorPlanes = 1 ->有使用調色盤
        public byte ColorPlanes { get { return imageHeader[65]; } }
        //圖片每行byte個數
        public ushort BytesPerLine { get { return BitConverter.ToUInt16(imageHeader, 66); } }
        //調色盤類別，1：彩色or黑白，2：灰階
        public ushort PaletteType { get { return BitConverter.ToUInt16(imageHeader, 68); } }
        //Horizontal screen size in pixels
        public ushort HscreenSize { get { return BitConverter.ToUInt16(imageHeader, 70); } }
        //Vertical screen size in pixels
        public ushort VscreenSize { get { return BitConverter.ToUInt16(imageHeader, 72); } }
        //補0
        public byte[] Byte_Filled 
        { 
            get 
            { 
                byte[] filled = new byte[58]; 
                Array.Copy(imageHeader, 74, filled, 0, 54); 
                return filled; 
            } 
        }
        //寬
        public int Width { get { return Xmax - Xmin + 1; } }
        //長
        public int Height { get { return Ymax - Ymin + 1; } }

        //判斷vaild
        public bool PCX_vaild()
        {
            {
                int vaild_pcx = 10;
                int manufatcurer = Manufacturer;
                if(vaild_pcx == manufatcurer)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
        //回傳header資訊
        public string Decode_Header() 
        {
            string palette = "";
            string filled = "";
            if (PCX_vaild())
            {
                foreach (byte ptr in Byte_Palette) palette += ptr.ToString() + ", ";
                foreach (byte ftr in Byte_Filled) filled += ftr.ToString() + ", ";
                return "Manufacturer:\t" + Manufacturer.ToString() +
                       "\r\nVersion:\t" + Version.ToString() +
                       "\r\nEncodeing:\t" + Encoding.ToString() +
                       "\r\nBitsPerPixel:\t" + BitsPerPixel.ToString() +
                       "\r\nXmin and Xmax:\t" + Xmin.ToString() + ", " + Xmax.ToString() +
                       "\r\nYmin and Ymax:\t" + Ymin.ToString() + ", " + Ymax.ToString() +
                       "\r\nHdpi:\t\t" + Hres.ToString() +
                       "\r\nVdpi:\t\t" + Vres.ToString() +
                       "\r\nColormap:" + palette +
                       "\r\nReserved:\t" + Reserve.ToString() +
                       "\r\nNPlanes:\t" + ColorPlanes.ToString() +
                       "\r\nBytesPerLine:\t" + BytesPerLine.ToString() +
                       "\r\nPaletteInfo:\t" + PaletteType.ToString() +
                       "\r\nHscreenSize:\t" + HscreenSize.ToString() +
                       "\r\nVscreenSize:\t" + VscreenSize.ToString() +
                       "\r\nFiller:" + filled +
                       "\r\nWidth * Height:\t" + Width.ToString() + " * " + Height.ToString();
            }
            else
            {
                return "This file doesn't a .PCX file";
            }
        }
    }
}

