using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imp_pj
{
    internal class Missalignment
    {
        
        public Bitmap miss_alignment(Bitmap source, int offset)
        {
            int[,] R = new int[source.Width, source.Height];
            int[,] G = new int[source.Width, source.Height];
            int[,] B = new int[source.Width, source.Height];
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++) 
                {
                        R[x, y] = source.GetPixel(x, y).R;
                        G[x, y] = source.GetPixel(x, y).G;
                        B[x, y] = source.GetPixel(x, y).B;
                        //R不偏移
                        if(x < offset && x >= 0)
                        {
                            Color color = Color.FromArgb(R[x, y], 0, 0);
                            source.SetPixel(x, y, color);
                        }
                        //G偏移offset個pixel
                        else if(x < offset * 2 && x >= offset)
                        {
                            Color color = Color.FromArgb(R[x, y], G[x- offset, y], 0);
                            source.SetPixel(x, y, color);
                        }
                        //B偏移2*offset個pixel
                        else
                        {
                            Color color = Color.FromArgb(R[x, y], G[x- offset, y], B[x- offset * 2, y]);
                            source.SetPixel(x, y, color);
                        }
                }
            }
            return source;
        }
    }
}
