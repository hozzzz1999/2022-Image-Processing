using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace imp_pj
{
    internal class MaskSize
    {
        public static int[] getMask(BitmapData image,byte[] originBytes, int size, int x, int y)
        {
            int k = 3;
            int mask_size = (int)Math.Pow(size, 2);
            int[] mask = new int[mask_size];
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int index = i * size + j;
                    //Console.WriteLine("index: " + index);
                    mask[index] = originBytes[(y + i) * image.Stride + x * k + 3 * j];
                }
            }
            return mask;
        }
    }
}
