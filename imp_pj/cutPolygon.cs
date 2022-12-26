using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imp_pj
{
    public partial class cutPolygon : Form
    {
        Bitmap origin;
        List<Point> points = new List<Point>();
        bool draw = false;
        public cutPolygon(Bitmap image)
        {
            InitializeComponent();
            origin = new Bitmap(image);
            pictureBox_source.Image = origin;

        }
        int counter = 0;
        private void pictureBox_source_Paint(object sender, PaintEventArgs e)
        {
            Pen Pen = new Pen(Color.Red, 3);
            if (draw == true)
            {
                /*if (points.Count > 1)
                {
                    e.Graphics.DrawLine(Pen, points[counter - 2], points[counter - 1]);
                }*/
                for(int i = 0; i < points.Count - 1; i++)
                {
                    if (points.Count > 1)
                    {
                        e.Graphics.DrawLine(Pen, points[i], points[i + 1]);
                    }
                    if (counter > 2)
                    {
                        value = Math.Abs(points[0].X - points[points.Count - 1].X) + Math.Abs(points[0].Y - points[points.Count - 1].Y);
                        if (value < 20)
                        {
                            points.RemoveAt(counter - 1);
                            e.Graphics.DrawLine(Pen, points[0], points[points.Count - 1]);
                            draw = false;
                            cutpoly();
                        }
                    }
                }

            }

        }
        public bool PositionPnpoly(int testx, int testy)
        {
            int i, j, c = 0;
            for (i = 0, j = points.Count - 1; i < points.Count; j = i++)
            {
                if (((points[i].Y > testy) != (points[j].Y > testy)) && (testx < (points[j].X - points[i].X) * (testy - points[i].Y) / (points[j].Y - points[i].Y) + points[i].X))
                {
                    c++;
                }
            }
            if (c % 2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void cutpoly()
        {
            Color color;
            Bitmap result = new Bitmap(origin.Width, origin.Height);
            for(int j = 0; j < origin.Height; j++)
            {
                for(int i = 0; i < origin.Width; i++)
                {
                    if(PositionPnpoly(i, j) == true)
                    {
                        color = origin.GetPixel(i, j);
                        result.SetPixel(i, j, color);
                    }
                }
            }
            pictureBox_result.Image = result;
        }
        int value;
        private void pictureBox_source_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            counter++;
            points.Add(e.Location);
            Console.WriteLine(points[points.Count - 1].X + " " +  points[points.Count - 1].Y);
            pictureBox_source.Refresh();
        }

        private void pictureBox_source_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
