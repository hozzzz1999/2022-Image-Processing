using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace imp_pj
{
    internal class Lowpass_Func
    {
        public static Bitmap OutlierFilter(Bitmap originImage, int masksize, int threshold)
        {
            int width = originImage.Width;
            int height = originImage.Height;
            BitmapData originImageData = originImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = originImageData.Scan0;
            int size = originImageData.Stride * height;
            byte[] originBytes = new byte[size];
            Marshal.Copy(intPtr, originBytes, 0, size);
            int total_mask = (int)Math.Pow(masksize, 2);
            int[] mask = new int[total_mask];
            //Console.WriteLine("total_len: " + total_mask + "ignore: " + ignore);

            int k = 3;
            //masksize-1 == to ignore
            for (int y = 0; y < height - (masksize-1); y++)
            {
                for (int x = 0; x < width - (masksize - 1); x++)
                {
                    int mean = 0;
                    mask = MaskSize.getMask(originImageData, originBytes, masksize, x, y);
                    //取mask，然後將除最中間的Pixel外的8個Pixel取平均值
                    //均值與最中間的pixel值差值若大於某一個threshold，那麼就用平均值替代最中間值的pixel。
                    //3*3
                    if (masksize == 3)
                    {
                        for (int w = 0; w < total_mask; w++)
                        {
                            mean += mask[w];
                        }
                        mean = (mean - mask[4]) / 8;
                        //加絕對值
                        //改中值
                        if (Math.Abs(mask[4] - mean) > threshold)
                        {
                            originBytes[(y + 1) * originImageData.Stride + x * k + 3] = (byte)mean;
                            originBytes[(y + 1) * originImageData.Stride + x * k + 4] = (byte)mean;
                            originBytes[(y + 1) * originImageData.Stride + x * k + 5] = (byte)mean;
                        }
                        //Console.WriteLine("mean: " + mean);
                    }
                    //5*5
                    else if (masksize == 5)
                    {
                        for(int w = 0; w < total_mask; w++)
                        {
                            mean += mask[w];
                        }
                        mean = (mean - mask[12]) / 24;

                        //改中值
                        if (Math.Abs(mask[12] - mean) > threshold)
                        {
                            originBytes[(y + 2) * originImageData.Stride + x * k + 6] = (byte)mean;
                            originBytes[(y + 2) * originImageData.Stride + x * k + 7] = (byte)mean;
                            originBytes[(y + 2) * originImageData.Stride + x * k + 8] = (byte)mean;
                        }
                    }
                    //7*7
                    else if (masksize == 7)
                    {
                        for (int w = 0; w < total_mask; w++)
                        {
                            mean += mask[w];
                        }
                        mean = (mean - mask[24]) / 48;
                        //改中值
                        if (Math.Abs(mask[24] - mean) > threshold)
                        {
                            originBytes[(y + 3) * originImageData.Stride + x * k + 9] = (byte)mean;
                            originBytes[(y + 3) * originImageData.Stride + x * k + 10] = (byte)mean;
                            originBytes[(y + 3) * originImageData.Stride + x * k + 11] = (byte)mean;
                        }
                    }
                    else
                    {
                        return default;
                    }
                }
            }
            Marshal.Copy(originBytes, 0, intPtr, size);
            originImage.UnlockBits(originImageData);
            return originImage;
        }
        public static Bitmap AverageFilter(Bitmap originImage, int masksize)
        {
            int width = originImage.Width;
            int height = originImage.Height;
            BitmapData originImageData = originImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = originImageData.Scan0;
            int size = originImageData.Stride * height;
            byte[] originBytes = new byte[size];
            Marshal.Copy(intPtr, originBytes, 0, size);
            int total_mask = (int)Math.Pow(masksize, 2);
            int[] mask = new int[total_mask];

            int k = 3;
            for (int y = 0; y < height - (masksize - 1); y++)
            {
                for (int x = 0; x < width - (masksize - 1); x++)
                {
                    int mean = 0;
                    mask = MaskSize.getMask(originImageData, originBytes, masksize, x, y);
                    if (masksize == 3)
                    {
                        for (int w = 0; w < total_mask; w++)
                        {
                            mean += mask[w];
                        }
                        mean = mean / 9;
                        //加絕對值
                        //Console.WriteLine("mean: " + mean);
                        originBytes[(y + 1) * originImageData.Stride + x * k + 3] = (byte)mean;
                        originBytes[(y + 1) * originImageData.Stride + x * k + 4] = (byte)mean;
                        originBytes[(y + 1) * originImageData.Stride + x * k + 5] = (byte)mean;  
                    }
                    if (masksize == 5)
                    {
                        for (int w = 0; w < total_mask; w++)
                        {
                            mean += mask[w];
                        }
                        mean = mean / 25;
                        //加絕對值
                        //Console.WriteLine("mean: " + mean);
                        originBytes[(y + 2) * originImageData.Stride + x * k + 6] = (byte)mean;
                        originBytes[(y + 2) * originImageData.Stride + x * k + 7] = (byte)mean;
                        originBytes[(y + 2) * originImageData.Stride + x * k + 8] = (byte)mean;
                    }
                    if (masksize == 7)
                    {
                        for (int w = 0; w < total_mask; w++)
                        {
                            mean += mask[w];
                        }
                        mean = mean / 49;
                        //加絕對值
                        //Console.WriteLine("mean: " + mean);
                        originBytes[(y + 3) * originImageData.Stride + x * k + 9] = (byte)mean;
                        originBytes[(y + 3) * originImageData.Stride + x * k + 10] = (byte)mean;
                        originBytes[(y + 3) * originImageData.Stride + x * k + 11] = (byte)mean;
                    }
                }
            }
            Marshal.Copy(originBytes, 0, intPtr, size);
            originImage.UnlockBits(originImageData);


            return originImage;
        }
        public static int Min(int a, int b, int c)
        {
            int result1, result2;
            result1 = Math.Min(a, b);
            result2 = Math.Min(a, c);
            result1 = Math.Min(result1, result2);
            return result1;
        }
        public static int Max(int a, int b, int c)
        {
            int result1, result2;
            result1 = Math.Max(a, b);
            result2 = Math.Max(a, c);
            result1 = Math.Max(result1, result2);
            return result1;
        }
        public static Bitmap MedianFilter(Bitmap originImage, int masksize, int method)
        {
            int SQUARE = 0, CROSS = 1, PSEUDO = 2;
            int width = originImage.Width;
            int height = originImage.Height;
            BitmapData originImageData = originImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = originImageData.Scan0;
            int size = originImageData.Stride * height;
            byte[] originBytes = new byte[size];
            Marshal.Copy(intPtr, originBytes, 0, size);
            int total_mask = (int)Math.Pow(masksize, 2);
            int[] mask = new int[total_mask];

            int k = 3;

            if (method == CROSS)
            {
                // X X 0 X X
                // X X 1 X X
                // 2 3 4 5 6
                // X X 7 X X
                // X X 8 X X

                //呼略前後2pixel
                for (int y = 2; y < height - 2; y++)
                {
                    for (int x = 2; x < width - 2; x++)
                    {
                        mask[0] = originBytes[(y - 2) * originImageData.Stride + x * k];
                        mask[1] = originBytes[(y - 1) * originImageData.Stride + x * k];

                        mask[2] = originBytes[y * originImageData.Stride + x * k - 6];
                        mask[3] = originBytes[y * originImageData.Stride + x * k - 3];
                        mask[4] = originBytes[y * originImageData.Stride + x * k];
                        mask[5] = originBytes[y * originImageData.Stride + x * k + 3];
                        mask[6] = originBytes[y * originImageData.Stride + x * k + 6];

                        mask[7] = originBytes[(y + 1) * originImageData.Stride + x * k];
                        mask[8] = originBytes[(y + 2) * originImageData.Stride + x * k];

                        Array.Sort(mask);
                        int median = mask[4];
                        originBytes[y * originImageData.Stride + x * k] = (byte)median;
                        originBytes[y * originImageData.Stride + x * k + 1] = (byte)median;
                        originBytes[y * originImageData.Stride + x * k + 2] = (byte)median;
                    }
                }
            }
            else if (method == PSEUDO)
            {
                int[] cross = new int[5];
                //  X 0 X 
                //  1 2 3 
                //  X 4 X 
                for (int y = 1; y < height - 1; y++)
                {
                    for (int x = 1; x < width - 1; x++)
                    {
                        cross[0] = originBytes[(y - 1) * originImageData.Stride + x * k];
                        cross[1] = originBytes[y * originImageData.Stride + x * k - 3];
                        cross[2] = originBytes[y * originImageData.Stride + x * k];
                        cross[3] = originBytes[y * originImageData.Stride + x * k + 3];
                        cross[4] = originBytes[(y + 1) * originImageData.Stride + x * k];

                        int max = Max(Min(cross[0], cross[1], cross[2]), Min(cross[1], cross[2], cross[3]), Min(cross[2], cross[3], cross[4]));
                        int min = Min(Max(cross[0], cross[1], cross[2]), Max(cross[1], cross[2], cross[3]), Max(cross[2], cross[3], cross[4]));
                        //Console.WriteLine("cross: " + cross[0] + " " + cross[1] + " " + cross[2] + " " + cross[3] + " " + cross[4]);
                        //Console.WriteLine("max: " + max + "min: " + min);
                        int median = max / 2 + min / 2;

                        originBytes[y * originImageData.Stride + x * k] = (byte)median;
                        originBytes[y * originImageData.Stride + x * k + 1] = (byte)median;
                        originBytes[y * originImageData.Stride + x * k + 2] = (byte)median;
                    }
                }
            }
            //
            else if (method == SQUARE)
            {
                for (int y = 0; y < height - (masksize - 1); y++)
                {
                    for (int x = 0; x < width - (masksize - 1); x++)
                    {
                        mask = MaskSize.getMask(originImageData, originBytes, masksize, x, y);
                        if (masksize == 3)
                        {
                            Array.Sort(mask);
                            int median = mask[4];
                            originBytes[(y + 1) * originImageData.Stride + x * k + 3] = (byte)median;
                            originBytes[(y + 1) * originImageData.Stride + x * k + 4] = (byte)median;
                            originBytes[(y + 1) * originImageData.Stride + x * k + 5] = (byte)median;
                        }
                        else if (masksize == 5)
                        {
                            Array.Sort(mask);
                            int median = mask[12];
                            originBytes[(y + 2) * originImageData.Stride + x * k + 6] = (byte)median;
                            originBytes[(y + 2) * originImageData.Stride + x * k + 7] = (byte)median;
                            originBytes[(y + 2) * originImageData.Stride + x * k + 8] = (byte)median;
                        }
                        else if (masksize == 7)
                        {
                            Array.Sort(mask);
                            int median = mask[24];
                            originBytes[(y + 3) * originImageData.Stride + x * k + 9] = (byte)median;
                            originBytes[(y + 3) * originImageData.Stride + x * k + 10] = (byte)median;
                            originBytes[(y + 3) * originImageData.Stride + x * k + 11] = (byte)median;
                        }

                    }
                }
            }
            Marshal.Copy(originBytes, 0, intPtr, size);
            originImage.UnlockBits(originImageData);

            return originImage;
        }
    }
}
