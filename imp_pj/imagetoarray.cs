using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace imp_pj
{
    internal class imagetoarray
    {
        public static byte[,] getArray(Bitmap image)
        {
            byte[,] pixel_array = new byte[256, 256];
            Color color;
            for(int j = 0; j < 256; j++)
            {
                for(int i = 0; i < 256; i++)
                {
                    color = image.GetPixel(i, j);
                    pixel_array[i, j] = color.R;
                }
            }
            return pixel_array; 
        }
        public static byte[,] getBlock(byte[,] array, int X, int Y)
        {
            byte[,] block = new byte[8, 8];
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    block[i, j] = array[i+X, j+Y];
                }
            }
            return block;
        }
        public static int arrayMinus(byte[,] candidateBlock, byte[,] targetBlock)
        {
            int answer = 0;
            int temp = 0;
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    temp = candidateBlock[i, j] - targetBlock[i, j];
                    answer += Math.Abs(temp);
                }
            }
            return answer;
        }
    }
}
