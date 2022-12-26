using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace imp_pj
{
    public partial class Contrast_Streching : Form
    {
        Bitmap Source, Result;
        public Contrast_Streching(Bitmap image)
        {
            InitializeComponent();
            Source = image;
            pictureBox_source.Image = Source;
            //預設
            trackBarR1.Value = 32;
            textBoxR1.Text = trackBarR1.Value.ToString();
            trackBarS1.Value = 64;
            textBoxS1.Text = trackBarS1.Value.ToString();
            trackBarR2.Value = 192;
            textBoxR2.Text = trackBarR2.Value.ToString();
            trackBarS2.Value = 160;
            textBoxS2.Text = trackBarS2.Value.ToString();
            Result = contrastStreching(Source, trackBarR1.Value, trackBarR2.Value, trackBarS1.Value, trackBarS2.Value);
            chart1.Series[0].Points[1].SetValueXY(trackBarR1.Value, trackBarS1.Value);
            chart1.Series[0].Points[2].SetValueXY(trackBarR2.Value, trackBarS2.Value);
            chart1.Refresh();
            chart1.Update();
            pictureBox_result.Image = Result;
        }
        //將原圖 r1 - r2 的區域拉伸到 s1 - s2 的區域
        public Bitmap contrastStreching(Bitmap SourceImage, double r1, double r2, double s1, double s2)
        {
            Bitmap newBitmap = new Bitmap(SourceImage.Width, SourceImage.Height);
            for (int j = 0; j < SourceImage.Height; j++)
            {
                for (int i = 0; i < SourceImage.Width; i++)
                {
                    double newGraylevel = 0;
                    int oldGraylevel = SourceImage.GetPixel(i, j).R;
                    //formula
                    //     old gray level < r1 :  new gray level = (old gray level / r1) * s1
                    //r1 < old gray level < r2 :  new gray level = (old gray level - r1) / (r2  - r1) * (s2 - s1)  + s1
                    //     old gray level > r2 :  new gray level = (old gray level - r2) / (255 - r2) * (255 - s2) + s2
                    if (oldGraylevel < r1)
                    {
                        newGraylevel = (oldGraylevel / r1) * s1;
                    }
                    else if (oldGraylevel <= r2)
                    {
                        newGraylevel = ((oldGraylevel - r1) / (r2 - r1))  * (s2 - s1)  + s1;
                    }
                    else
                    {
                        newGraylevel = ((oldGraylevel - r2) / (255 - r2)) * (255 - s2) + s2;
                    }
                    int pixel = (int)Math.Round(newGraylevel);
                    if (pixel > 255 || pixel < 0)
                        continue;
                    Color newValue = Color.FromArgb(pixel, pixel, pixel);
                    newBitmap.SetPixel(i, j, newValue);
                }
            }
            return newBitmap;
        }

        private void trackBarR1_Scroll(object sender, EventArgs e)
        {
            textBoxR1.Text = trackBarR1.Value.ToString();
            Result = contrastStreching(Source, trackBarR1.Value, trackBarR2.Value, trackBarS1.Value, trackBarS2.Value);
            chart1.Series[0].Points[1].SetValueXY(trackBarR1.Value, trackBarS1.Value);
            chart1.Refresh();
            chart1.Update();
            pictureBox_result.Image = Result;
        }

        private void trackBarS1_Scroll(object sender, EventArgs e)
        {
            textBoxS1.Text = trackBarS1.Value.ToString();
            Result = contrastStreching(Source, trackBarR1.Value, trackBarR2.Value, trackBarS1.Value, trackBarS2.Value);
            chart1.Series[0].Points[1].SetValueXY(trackBarR1.Value, trackBarS1.Value);
            chart1.Refresh();
            chart1.Update();
            pictureBox_result.Image = Result;
        }

        private void trackBarR2_Scroll(object sender, EventArgs e)
        {
            textBoxR2.Text = trackBarR2.Value.ToString();
            Result = contrastStreching(Source, trackBarR1.Value, trackBarR2.Value, trackBarS1.Value, trackBarS2.Value);
            chart1.Series[0].Points[2].SetValueXY(trackBarR2.Value, trackBarS2.Value);
            chart1.Refresh();
            chart1.Update();
            pictureBox_result.Image = Result;
        }

        private void trackBarS2_Scroll(object sender, EventArgs e)
        {
            textBoxS2.Text = trackBarS2.Value.ToString();
            Result = contrastStreching(Source, trackBarR1.Value, trackBarR2.Value, trackBarS1.Value, trackBarS2.Value);
            chart1.Series[0].Points[2].SetValueXY(trackBarR2.Value, trackBarS2.Value);
            chart1.Refresh();
            chart1.Update();
            pictureBox_result.Image = Result;
        }
    }
}
