using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace imp_pj
{
    internal class snr
    {
        public const int Default = -1;
        public static double SNR(Bitmap Origin, Bitmap Result)
        {
            double value = 0;
            double top = 0;
            double bottom = 0;
            //Color pixel1, pixel2;
            //長寬不同
            if(Origin.Height != Result.Height || Origin.Width != Result.Width)
            {
                return Default;
            }

            for (int i = 0; i < Origin.Height; i++)
            {
                for(int j = 0; j < Origin.Width; j++)
                {
                    var pixel1 = Origin.GetPixel(i, j);
                    var pixel2 = Result.GetPixel(i, j);
                    top += Math.Pow(pixel1.R, 2);
                    bottom += Math.Pow(pixel1.R - pixel2.R, 2);
                }
            }
            value = 10 * Math.Log10(top / bottom);
            return value;
        }
        public static double PSNR(Bitmap Origin, Bitmap Result)
        {
            double value = 0;
            double top = 0;
            double bottom = 0;

            for(int i = 0; i < Origin.Height; i++)
            {
                for (int j = 0; j < Origin.Width; j++)
                {
                    var pixel1 = Origin.GetPixel(i, j);
                    var pixel2 = Result.GetPixel(i, j);
                    bottom += Math.Pow(pixel1.R - pixel2.R, 2);
                }
            }
            top = Math.Pow(255, 2);
            bottom /= Origin.Height * Origin.Width;
            value = 10 * Math.Log10(top / bottom);
            return value;
        }
    }
}
