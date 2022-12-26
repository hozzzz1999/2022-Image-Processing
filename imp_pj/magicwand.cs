using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imp_pj
{
    public partial class magicwand : Form
    {
        Bitmap source;
        Bitmap result;
        public magicwand(Bitmap origin)
        {
            InitializeComponent();
            pictureBox_source.Image = origin;
            pictureBox_result.Image = origin;
            source = new Bitmap(pictureBox_source.Image);
            result = new Bitmap(pictureBox_source.Image);
            click_point();
        }
        private void click_point()
        {

        }
        int count = 0;
        Point start, end;
        bool draw = false;
        bool cando = false;
        bool candraw = false;
        private void pictureBox_source_MouseClick(object sender, MouseEventArgs e)
        {
            
            if(count == 0)
            {
                count++;
                start = e.Location;
                label_point.Text = "start point: " + start.X + ", " + start.Y + "\n" +
                                   "end point: ";
            }
            else if(count == 1)
            {
                count++;
                draw = true;
                end = e.Location;
                label_point.Text = "start point: " + start.X + ", " + start.Y + "\n" +
                                   "end point: " + end.X + ", " + end.Y ;
            }
            else
            {
                
            }
        }
        int X, Y;

        private void pictureBox_source_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (draw == true && cando == true)
                {
                    Point current = e.Location;
                    Point offset;
                    X = current.X - start.X + end.X;
                    Y = current.Y - start.Y + end.Y;

                    Color[] color = new Color[9];
                    if (candraw)
                    {
                        color[0] = source.GetPixel(current.X - 1, current.Y - 1);
                        color[1] = source.GetPixel(current.X, current.Y - 1);
                        color[2] = source.GetPixel(current.X + 1, current.Y - 1);
                        color[3] = source.GetPixel(current.X - 1, current.Y);
                        color[4] = source.GetPixel(current.X, current.Y);
                        color[5] = source.GetPixel(current.X + 1, current.Y);
                        color[6] = source.GetPixel(current.X - 1, current.Y + 1);
                        color[7] = source.GetPixel(current.X, current.Y + 1);
                        color[8] = source.GetPixel(current.X + 1, current.Y + 1);

                        result.SetPixel(X - 1, Y - 1, color[0]);
                        result.SetPixel(X, Y - 1, color[1]);
                        result.SetPixel(X + 1, Y - 1, color[2]);
                        result.SetPixel(X - 1, Y, color[3]);
                        result.SetPixel(X, Y, color[4]);
                        result.SetPixel(X + 1, Y, color[5]);
                        result.SetPixel(X - 1, Y + 1, color[6]);
                        result.SetPixel(X, Y + 1, color[7]);
                        result.SetPixel(X + 1, Y + 1, color[8]);
                        pictureBox_result.Image = result;
                        pictureBox_result.Refresh();
                    }  
                }
            }
            catch (Exception)
            {
                throw;
            }


        }
    
        private void pictureBox_source_MouseUp(object sender, MouseEventArgs e)
        {
            candraw = false;
            if(count > 2)
            {
                draw = false;
                cando = false;
            }
        }

        private void pictureBox_source_MouseDown(object sender, MouseEventArgs e)
        {
            if(draw == true)
            {
                Point current = e.Location;
                Point offset;
                X = current.X - start.X + end.X;
                Y = current.Y - start.Y + end.Y;
                Console.WriteLine("X, Y: " + X + ", " + Y);
                /*offset.X = current.X - start.X + end.X;
                offset.Y = current.Y - start.Y + end.Y;*/
                cando = true;
                candraw = true;
            }
        }

        private void pictureBox_source_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
