using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace imp_pj
{
    internal class videojim
    {
        //獲取當前壓縮frame和其前一個frame的所有塊，並存在對應的bitmap數組中。
        public void VideoGetPool(Bitmap targetImage, Bitmap referenceImage, out List<Bitmap> CurrentPool, out List<Bitmap> CandidatePool)
        {
            CurrentPool = new List<Bitmap>();
            CandidatePool = new List<Bitmap>();
            int widthT = targetImage.Width;
            int heightT = targetImage.Height;
            int widthR = referenceImage.Width;
            int heightR = referenceImage.Height;
            //Rangeblock和Domainblock的大小(單邊)
            int rangeSize = 8;
            int domainSize = 8;

            //塊數
            int Rx = widthT / rangeSize;
            int Ry = heightT / rangeSize;
            int Dx = widthR / domainSize;
            int Dy = heightR / domainSize;

            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;

            for (int j = 0; j < Ry; j++)
            {
                for (int i = 0; i < Rx; i++)
                {
                    //Console.WriteLine(i + ",  " + j);
                    Bitmap CurrentBlock = targetImage.Clone(new Rectangle(x1, y1, rangeSize, rangeSize), PixelFormat.Format24bppRgb);
                    CurrentPool.Add(CurrentBlock);
                    x1 += rangeSize;
                }
                y1 += rangeSize;
                x1 = 0;
            }
            //256-8+1
            //Dy = 249;
            //Dx = 249;
            for (int j = 0; j < Dy; j++)
            {
                for (int i = 0; i < Dx; i++)
                {
                    Bitmap domainBlock = referenceImage.Clone(new Rectangle(x2, y2, domainSize, domainSize), PixelFormat.Format24bppRgb);
                    CandidatePool.Add(domainBlock);
                    x2 += domainSize;
                    //x2 += 1;
                }
                y2 += domainSize;
                //y2 += 1;
                x2 = 0;
            }
        }

        public double OriginAlgo(Bitmap targetImage, Bitmap referenceImage)
        {
            double sumR = 0;
            double sumD = 0;
            double sum = 0;
            double minus = 0;
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    minus = Math.Abs(targetImage.GetPixel(i, j).R - referenceImage.GetPixel(i, j).R);
                    sum += minus;
                    //sumR += targetImage.GetPixel(i, j).R;
                    //sumD += referenceImage.GetPixel(i, j).R;
                }
            }
            //double s = Math.Abs(sumR - sumD);
            return sum;
        }
        int txtcount = 0;
        public Bitmap VideoEncode(List<Bitmap> CurrentPool, List<Bitmap> CandidatePool)
        {
            double s = 0;
            Bitmap result = new Bitmap(256, 256);
            Dictionary<int, int> MotionVector = new Dictionary<int, int>();
            List<double> ssum = new List<double>();
            //Console.WriteLine(CurrentPool.LongCount());
            //Console.WriteLine(CandidatePool.LongCount());
            for (int k = 0; k < CurrentPool.LongCount(); k++)
            {
                //Console.WriteLine(CalculateMin(CurrentPool[k], CandidatePool[k]));
                if (OriginAlgo(CurrentPool[k], CandidatePool[k]) < 200)
                {
                    MotionVector.Add(k, k);
                }
                else
                {
                    for (int t = 0; t < CandidatePool.LongCount(); t++)
                    {
                        //調用均值計算，對比塊間差距。
                        s = OriginAlgo(CurrentPool[k], CandidatePool[t]);
                        ssum.Add(s);
                    }

                    double min = ssum[0];
                    int motion = 0;
                    for (int n = 0; n < ssum.LongCount(); n++)
                    {
                        if (ssum[n] < min)
                        { //取差距最小的塊，儲存。
                            min = ssum[n];
                            motion = n;
                        }
                        /*if(min < 150)
                        {
                            break;
                        }*/
                    }
                    MotionVector.Add(k, motion);
                    ssum.Clear();
                }
            }

            //將座標偏移寫入文檔存儲，作爲壓縮文件。
            StreamWriter sfile = new StreamWriter(@"C:\Users\qazws\Downloads\ImageProcessing\encode" + txtcount++ + ".txt", true);

            int x = 0;
            int y = 0;
            int currentX = 0;
            int currentY = 0;
            for (int i = 0; i < MotionVector.LongCount(); i++)
            {
                if (i == MotionVector.LongCount() - 1)
                {
                    currentX = (i % 32) * 8;
                    currentY = (i / 32) * 8;
                    x = (MotionVector[i] % 32) * 8;
                    y = (MotionVector[i] / 32) * 8;

                    int curxx = currentX;
                    int curyy = currentY;
                    for (int j = y; j < y + 8; ++j)
                    {
                        for (int k = x; k < x + 8; ++k)
                        {
                            Color pixel = (CandidatePool[MotionVector[i]]).GetPixel(k % 8, j % 8);
                            result.SetPixel(curxx, curyy, pixel);
                            curxx++;
                        }
                        curyy++;
                        curxx = currentX;
                    }
                    //result = videoDecode(CandidatePool, x, y);
                    //Console.WriteLine(x + "," + y + ";" + " end" + "\r\n");
                    sfile.Write("(" + currentX + ", " + currentY + ")" + " -> " + "(" + x + ", " + y + ")" + ";" + "|");
                }
                else
                {
                    currentX = (i % 32) * 8;
                    currentY = (i / 32) * 8;
                    x = (MotionVector[i] % 32) * 8;
                    y = (MotionVector[i] / 32) * 8;
                    int curxx = currentX;
                    int curyy = currentY;
                    for (int j = y; j < y + 8; ++j)
                    {
                        for (int k = x; k < x + 8; ++k)
                        {
                            Color pixel = (CandidatePool[MotionVector[i]]).GetPixel(k % 8, j % 8);
                            result.SetPixel(curxx, curyy, pixel);
                            curxx++;
                        }
                        curyy++;
                        curxx = currentX;
                    }
                    //result = videoDecode(CandidatePool, x, y);
                    Console.WriteLine("(" + currentX + ", " + currentY + ")" + " -> " + "(" + x + ", " + y + ")" + ";");
                    sfile.Write("(" + currentX + ", " + currentY + ")" + " -> " + "(" + x + ", " + y + ")" + ";" + "\r\n");
                }
            }
            sfile.Flush();
            sfile.Close();

            return result;
        }
        int counter = 0;
        Bitmap result = new Bitmap(256, 256);
        public Bitmap videoDecode(List<Bitmap> CandidatePool, int x, int y)
        {

            int number = ((x / 8)) + ((y / 8) * 32);
            int pixel;
            //Console.WriteLine(number);
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    pixel = CandidatePool[number].GetPixel(i, j).R;
                    result.SetPixel(i + (counter % 32) * 8, j + (counter / 32) * 8, Color.FromArgb(pixel, pixel, pixel));
                }
            }
            counter++;
            if (counter == 1024)
                counter = 0;
            return result;
        }
    }

}
