using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace imp_pj
{
    internal class Highpass_Func
    {
        public static Bitmap EdgeCrispen(Bitmap origin, int masksize)
        {
            Bitmap result = new Bitmap(origin);

            int width = origin.Width;
            int height = origin.Height;
            BitmapData originImageData = origin.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData resultImageData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr_ori = originImageData.Scan0;
            IntPtr intPtr_res = resultImageData.Scan0;
            int size = originImageData.Stride * height;
            byte[] originBytes = new byte[size];
            byte[] resultBytes = new byte[size];
            Marshal.Copy(intPtr_ori, originBytes, 0, size);
            Marshal.Copy(intPtr_res, resultBytes, 0, size);
            int total_mask = (int)Math.Pow(masksize, 2);
            int[] mask = new int[total_mask];

            int k = 3;
            for (int y = 0; y < height - (masksize - 1); y++)
            {
                for (int x = 0; x < width - (masksize - 1); x++)
                {
                    int value = 0;
                    mask = MaskSize.getMask(originImageData, originBytes, masksize, x, y);
                    if (masksize == 3)
                    {
                        for (int w = 0; w < total_mask; w++)
                        {
                            value += mask[w];
                            
                        }
                        value = ~value;
                        
                        value = (value + 9 * mask[4]) / 9;
                        value = Math.Abs(value);
                        
                        resultBytes[(y + 1) * resultImageData.Stride + x * k + 3] = (byte)value;
                        resultBytes[(y + 1) * resultImageData.Stride + x * k + 4] = (byte)value;
                        resultBytes[(y + 1) * resultImageData.Stride + x * k + 5] = (byte)value;
                    }
                    else if (masksize == 5)
                    {
                        for (int w = 0; w < total_mask; w++)
                        {
                            value += mask[w];
                            
                        }
                        value = ~value;
                        
                        value = (value + 25 * mask[12]) / 25;
                        value = Math.Abs(value);
                        
                        resultBytes[(y + 2) * resultImageData.Stride + x * k + 6] = (byte)value;
                        resultBytes[(y + 2) * resultImageData.Stride + x * k + 7] = (byte)value;
                        resultBytes[(y + 2) * resultImageData.Stride + x * k + 8] = (byte)value;
                    }
                    else if (masksize == 7)
                    {
                        for (int w = 0; w < total_mask; w++)
                        {
                            value += mask[w];
                            
                        }
                        value = ~value;
                        
                        value = (value + 49 * mask[24]) / 49;
                        value = Math.Abs(value);
                        
                        resultBytes[(y + 3) * resultImageData.Stride + x * k + 9] = (byte)value;
                        resultBytes[(y + 3) * resultImageData.Stride + x * k + 10] = (byte)value;
                        resultBytes[(y + 3) * resultImageData.Stride + x * k + 11] = (byte)value;
                    }
                }
            }
            Marshal.Copy(originBytes, 0, intPtr_ori, size);
            Marshal.Copy(resultBytes, 0, intPtr_res, size);
            origin.UnlockBits(originImageData);
            result.UnlockBits(resultImageData);

            return result;
        }
        public static Bitmap HighBoost(Bitmap origin, int masksize, double alpha)
        {
            Bitmap result = new Bitmap(origin);

            int width = origin.Width;
            int height = origin.Height;
            BitmapData originImageData = origin.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData resultImageData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr_ori = originImageData.Scan0;
            IntPtr intPtr_res = resultImageData.Scan0;
            int size = originImageData.Stride * height;
            byte[] originBytes = new byte[size];
            byte[] resultBytes = new byte[size];
            Marshal.Copy(intPtr_ori, originBytes, 0, size);
            Marshal.Copy(intPtr_res, resultBytes, 0, size);
            int total_mask = (int)Math.Pow(masksize, 2);
            int[] mask = new int[total_mask];

            int k = 3;
            for (int y = 0; y < height - (masksize - 1); y++)
            {
                for (int x = 0; x < width - (masksize - 1); x++)
                {
                    int value = 0;
                    mask = MaskSize.getMask(originImageData, originBytes, masksize, x, y);
                    if (masksize == 3)
                    {
                        for (int w = 0; w < total_mask; w++)
                        {
                            value += mask[w];
                           
                        }
                        value = ~value;
                        
                        value = (int)(value + 9 * alpha * mask[4]) / 9;
                        value = Math.Abs(value);
                        if (value > 255)
                            value = 255;
                        resultBytes[(y + 1) * resultImageData.Stride + x * k + 3] = (byte)value;
                        resultBytes[(y + 1) * resultImageData.Stride + x * k + 4] = (byte)value;
                        resultBytes[(y + 1) * resultImageData.Stride + x * k + 5] = (byte)value;
                    }
                    else if (masksize == 5)
                    {
                        for (int w = 0; w < total_mask; w++)
                        {
                            value += mask[w];
                            
                        }
                        value = ~value;
                        
                        value = (int)(value + 25 * alpha * mask[12]) / 25;
                        value = Math.Abs(value);
                        if (value > 255)
                            value = 255;
                        resultBytes[(y + 2) * resultImageData.Stride + x * k + 6] = (byte)value;
                        resultBytes[(y + 2) * resultImageData.Stride + x * k + 7] = (byte)value;
                        resultBytes[(y + 2) * resultImageData.Stride + x * k + 8] = (byte)value;
                    }
                    else if (masksize == 7)
                    {
                        for (int w = 0; w < total_mask; w++)
                        {
                            value += mask[w];
                            
                        }
                        value = ~value;
                        
                        value = (int)(value + 49 * alpha * mask[24]) / 49;
                        value = Math.Abs(value);
                        if (value > 255)
                            value = 255;
                        resultBytes[(y + 3) * resultImageData.Stride + x * k + 9] = (byte)value;
                        resultBytes[(y + 3) * resultImageData.Stride + x * k + 10] = (byte)value;
                        resultBytes[(y + 3) * resultImageData.Stride + x * k + 11] = (byte)value;
                    }
                }
            }
            Marshal.Copy(originBytes, 0, intPtr_ori, size);
            Marshal.Copy(resultBytes, 0, intPtr_res, size);
            origin.UnlockBits(originImageData);
            result.UnlockBits(resultImageData);

            return result;
        }
        public static Bitmap Prewitt(Bitmap origin, int method_flag)
        {
            Bitmap result = new Bitmap(origin);
            Bitmap XY = new Bitmap(origin);
            int Prewitt_X = 0, Prewitt_Y = 1, Prewitt_XY = 2;
            int width = origin.Width;
            int height = origin.Height;
            BitmapData originImageData = origin.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData resultImageData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr_ori = originImageData.Scan0;
            IntPtr intPtr_res = resultImageData.Scan0;
            int size = originImageData.Stride * height;
            byte[] originBytes = new byte[size];
            byte[] resultBytes = new byte[size];
            Marshal.Copy(intPtr_ori, originBytes, 0, size);
            Marshal.Copy(intPtr_res, resultBytes, 0, size);
            int total_mask = (int)Math.Pow(3, 2);
            int[] mask = new int[total_mask];

            int k = 3;
            if (method_flag == Prewitt_XY)
            {
                Bitmap X = new Bitmap(XY);
                Bitmap Y = new Bitmap(XY);
                Bitmap merge = new Bitmap(XY.Width, XY.Height);
                X = Prewitt(XY, 0);
                Y = Prewitt(XY, 1);
                for (int i = 0; i < X.Height; i++)
                {
                    for (int j = 0; j < X.Width; j++)
                    {
                        Color value_x = X.GetPixel(j, i);
                        Color value_y = Y.GetPixel(j, i);
                        if (value_x.R > 0 || value_y.R > 0)
                        {
                            int merge_pixel = value_x.R + value_y.R;

                            if (merge_pixel < 255)
                            {
                                merge.SetPixel(j, i, Color.FromArgb(merge_pixel, merge_pixel, merge_pixel));
                            }
                            else if (merge_pixel > 255)
                            {
                                merge.SetPixel(j, i, Color.White);
                            }
                        }
                        else
                        {
                            merge.SetPixel(j, i, Color.Black);
                        }
                    }
                }
                return merge;
            }
            else
            {
                for (int y = 0; y < height - 2; y++)
                {
                    for (int x = 0; x < width - 2; x++)
                    {
                        int value = 0;
                        mask = MaskSize.getMask(originImageData, originBytes, 3, x, y);
                        // 1 0 -1
                        // 1 0 -1
                        // 1 0 -1
                        if (method_flag == Prewitt_X)
                        {
                            value = mask[0] * -1 + mask[2] * 1 + mask[3] * -1 + mask[5] * 1 + mask[6] * -1 + mask[8] * 1;
                            value = Math.Abs(value);
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 3] = (byte)value;
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 4] = (byte)value;
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 5] = (byte)value;
                        }
                        //  1  1  1
                        //  0  0  0
                        // -1 -1 -1
                        else if (method_flag == Prewitt_Y)
                        {
                            value = mask[0] * 1 + mask[1] * 1 + mask[2] * 1 + mask[6] * -1 + mask[7] * -1 + mask[8] * -1;
                            value = Math.Abs(value);
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 3] = (byte)value;
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 4] = (byte)value;
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 5] = (byte)value;
                        }
                    }
                }
                Marshal.Copy(originBytes, 0, intPtr_ori, size);
                Marshal.Copy(resultBytes, 0, intPtr_res, size);
                origin.UnlockBits(originImageData);
                result.UnlockBits(resultImageData);
                return result;
            }
        }
        public static Bitmap Soble(Bitmap origin, int method_flag)
        {
            Bitmap result = new Bitmap(origin);
            Bitmap XY = new Bitmap(origin);
            int SOBLE_X = 0, SOBLE_Y = 1, SOBLE_XY = 2;
            int width = origin.Width;
            int height = origin.Height;
            BitmapData originImageData = origin.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData resultImageData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr_ori = originImageData.Scan0;
            IntPtr intPtr_res = resultImageData.Scan0;
            int size = originImageData.Stride * height;
            byte[] originBytes = new byte[size];
            byte[] resultBytes = new byte[size];
            Marshal.Copy(intPtr_ori, originBytes, 0, size);
            Marshal.Copy(intPtr_res, resultBytes, 0, size);
            int total_mask = (int)Math.Pow(3, 2);
            int[] mask = new int[total_mask];

            int k = 3;
            if (method_flag == SOBLE_XY)
            {
                Bitmap X = new Bitmap(XY);
                Bitmap Y = new Bitmap(XY);
                Bitmap merge = new Bitmap(XY.Width,XY.Height);
                X = Soble(XY, 0);
                Y = Soble(XY, 1);
                for (int i = 0; i < X.Height; i++)
                {
                    for (int j = 0; j < X.Width; j++)
                    {
                        Color value_x = X.GetPixel(j, i);
                        Color value_y = Y.GetPixel(j, i);
                        if (value_x.R > 0 || value_y.R > 0)
                        {
                            int merge_pixel = value_x.R + value_y.R;

                            if (merge_pixel < 255)
                            {
                                merge.SetPixel(j, i, Color.FromArgb(merge_pixel, merge_pixel, merge_pixel));
                            }
                            else if (merge_pixel > 255)
                            {
                                merge.SetPixel(j, i, Color.White);
                            }
                        }
                        else
                        {
                            merge.SetPixel(j, i, Color.Black);
                        }
                    }
                }
                return merge;
            }
            else
            {
                for (int y = 0; y < height - 2; y++)
                {
                    for (int x = 0; x < width - 2; x++)
                    {
                        int value = 0;
                        mask = MaskSize.getMask(originImageData, originBytes, 3, x, y);
                        // -1 0 1
                        // -2 0 2
                        // -1 0 1
                        if (method_flag == SOBLE_X)
                        {
                            value = mask[0] * -1 + mask[2] * 1 + mask[3] * -2 + mask[5] * 2 + mask[6] * -1 + mask[8] * 1;
                            value = Math.Abs(value);
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 3] = (byte)value;
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 4] = (byte)value;
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 5] = (byte)value;
                        }
                        //  1  2  1
                        //  0  0  0
                        // -1 -2 -1
                        else if (method_flag == SOBLE_Y)
                        {
                            value = mask[0] * 1 + mask[1] * 2 + mask[2] * 1 + mask[6] * -1 + mask[7] * -2 + mask[8] * -1;
                            value = Math.Abs(value);
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 3] = (byte)value;
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 4] = (byte)value;
                            resultBytes[(y + 1) * resultImageData.Stride + x * k + 5] = (byte)value;
                        }
                    }
                }
                Marshal.Copy(originBytes, 0, intPtr_ori, size);
                Marshal.Copy(resultBytes, 0, intPtr_res, size);
                origin.UnlockBits(originImageData);
                result.UnlockBits(resultImageData);
                return result;
            } 
        }
        public static Bitmap Robert(Bitmap origin, int method_flag)
        {
            Bitmap result = new Bitmap(origin);
            Bitmap XY = new Bitmap(origin);
            int Robert_X = 0, Robert_Y = 1, Robert_XY = 2;
            int width = origin.Width;
            int height = origin.Height;
            BitmapData originImageData = origin.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData resultImageData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr_ori = originImageData.Scan0;
            IntPtr intPtr_res = resultImageData.Scan0;
            int size = originImageData.Stride * height;
            byte[] originBytes = new byte[size];
            byte[] resultBytes = new byte[size];
            Marshal.Copy(intPtr_ori, originBytes, 0, size);
            Marshal.Copy(intPtr_res, resultBytes, 0, size);
            int total_mask = (int)Math.Pow(3, 2);
            int[] mask = new int[total_mask];

            int k = 3;
            if (method_flag == Robert_XY)
            {
                Bitmap X = new Bitmap(XY);
                Bitmap Y = new Bitmap(XY);
                Bitmap merge = new Bitmap(XY.Width, XY.Height);
                X = Robert(XY, 0);
                Y = Robert(XY, 1);
                for (int i = 0; i < X.Height; i++)
                {
                    for (int j = 0; j < X.Width; j++)
                    {
                        Color value_x = X.GetPixel(j, i);
                        Color value_y = Y.GetPixel(j, i);
                        if (value_x.R > 0 || value_y.R > 0)
                        {
                            int merge_pixel = value_x.R + value_y.R;

                            if (merge_pixel < 255)
                            {
                                merge.SetPixel(j, i, Color.FromArgb(merge_pixel, merge_pixel, merge_pixel));
                            }
                            else if (merge_pixel > 255)
                            {
                                merge.SetPixel(j, i, Color.White);
                            }
                        }
                        else
                        {
                            merge.SetPixel(j, i, Color.Black);
                        }
                    }
                }
                return merge;
            }
            else
            {
                for (int y = 0; y < height - 1; y++)
                {
                    for (int x = 0; x < width - 1; x++)
                    {
                        int value = 0;
                        mask = MaskSize.getMask(originImageData, originBytes, 2, x, y);
                        // 1  0
                        // 0 -1 
                        if (method_flag == Robert_X)
                        {
                            value = mask[0] - mask[3];
                            value = Math.Abs(value);
                            resultBytes[y * resultImageData.Stride + x * k ] = (byte)value;
                            resultBytes[y * resultImageData.Stride + x * k + 1] = (byte)value;
                            resultBytes[y * resultImageData.Stride + x * k + 2] = (byte)value;
                        }
                        //  0  1
                        // -1  0  
                        else if (method_flag == Robert_Y)
                        {
                            value = mask[1] - mask[2];
                            value = Math.Abs(value);
                            resultBytes[y * resultImageData.Stride + x * k ] = (byte)value;
                            resultBytes[y * resultImageData.Stride + x * k + 1] = (byte)value;
                            resultBytes[y * resultImageData.Stride + x * k + 2] = (byte)value;
                        }
                    }
                }
                Marshal.Copy(originBytes, 0, intPtr_ori, size);
                Marshal.Copy(resultBytes, 0, intPtr_res, size);
                origin.UnlockBits(originImageData);
                result.UnlockBits(resultImageData);
                return result;
            }
        }
    }
}
