using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imp_pj
{
    internal class ConnectedComponent
    {
        public static Bitmap Connected(Bitmap image, int flag)
        {
            Bitmap result = new Bitmap(image);
            int width = image.Width;
            int height = image.Height;
            int[,] label = new int[height, width];
            int LabelCount = 1;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int PIC = image.GetPixel(x, y).R;
                    //if white
                    if (PIC != 0)
                    {
                        if (x == 0 && y == 0) // (0, 0)
                        {
                            label[x, y] = LabelCount;
                            LabelCount++;
                        }
                        //top line
                        else if (y == 0 && x != 0) 
                        {
                            if (label[x - 1, y] != 0)
                                label[x, y] = label[x - 1, y];
                            else
                                label[x, y] = LabelCount; LabelCount++;

                        }
                        //left line
                        else if (x == 0 && y != 0) 
                        {
                            if (label[x, y - 1] != 0)
                                label[x, y] = label[x, y - 1];
                            else
                                label[x, y] = LabelCount; LabelCount++;
                        }
                        else
                        {
                            //Top!= 0 
                            if (label[x, y - 1] != 0 && label[x - 1, y] == 0)
                                label[x, y] = label[x, y - 1];
                            //left!=0
                            else if (label[x - 1, y] != 0 && label[x, y - 1] == 0)
                                label[x, y] = label[x - 1, y];
                            //left!=0 & Top!= 0 
                            else if (label[x - 1, y] != 0 && label[x, y - 1] != 0)
                            {
                                label[x, y] = label[x, y - 1];
                                int TOPLabel = label[x, y - 1];
                                int LeftLabel = label[x - 1, y];
                                //left!=top
                                if (TOPLabel != LeftLabel) 
                                {
                                    for (int i = 0; i < height; i++)
                                    {
                                        for (int j = 0; j < width; j++)
                                        {
                                            if (label[i, j] == LeftLabel)
                                                label[i, j] = TOPLabel;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                label[x, y] = LabelCount;
                                LabelCount++;
                            }
                        }
                    }
                    //black(後景)
                    else
                        label[x, y] = 0;
                }
            }
            //標籤 標準化
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (label[x, y] != 0)
                        label[x, y] = (label[x, y] % 10) + 1;
                    else
                        label[x, y] = 0;
                }
            }
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color[] draw = new Color[10];
                    draw[0] = Color.Red;
                    draw[1] = Color.Green;
                    draw[2] = Color.Blue;
                    draw[3] = Color.Orange;
                    draw[4] = Color.Yellow;
                    draw[5] = Color.DarkBlue;
                    draw[6] = Color.Purple;
                    draw[7] = Color.Pink;
                    draw[8] = Color.Brown;
                    draw[9] = Color.Magenta;
                    if (label[x, y] == 0)
                        result.SetPixel(x, y, Color.Black);
                    else
                    {
                        result.SetPixel(x, y, draw[label[x, y] % 10]);
                    }
                }
            }
            return result;
        }
    }
}
