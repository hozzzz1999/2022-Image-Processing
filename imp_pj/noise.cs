using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace imp_pj
{
    internal class Noise
    {
        public static Bitmap AddNoise(Bitmap source)
        {
            Random rnd = new Random();
            int noise_chance = 10;
            for (int y = 3; y < source.Height - 3; y++)
            {
                for (int x = 3; x < source.Width - 3; x++)
                {
                    //100
                    int max = (int)(1000 / noise_chance);
                    //產生的亂數將會是tmp為0~100
                    int tmp = rnd.Next(max + 1);
                    //Console.WriteLine("tmp: " + tmp);

                    //RGB共三次
                    for (int j = 0; j < 3; j++)
                    {
                        if (tmp == 0 || tmp == max)
                        {
                            //sorp非0即1  0=>pepper 1=>salt
                            int sorp = tmp / max;
                            Color color = Color.FromArgb((byte)(sorp * 255), (byte)(sorp * 255), (byte)(sorp * 255));
                            source.SetPixel(x, y, color);
                        }
                    }
                }
            }
            return source;
        }
    }
}
