using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imp_pj
{
    public partial class Highpass_Filter : Form
    {
        public Highpass_Filter(Bitmap origin_image)
        {
            InitializeComponent();
            pictureBox_Source.Image = origin_image;
        }

        
        //click 燈泡
        private void pictureBox_Negative_Click(object sender, EventArgs e)
        {
            if(pictureBox_Result.Image != null)
            {
                Bitmap source = new Bitmap(pictureBox_Result.Image);
                //提升亮度，過閥值就加70，否則0
                for(int i = 0; i < source.Height; i++)
                {
                    for(int j = 0; j < source.Width; j++)
                    {
                        Color value  = source.GetPixel(j, i);
                        if (value.R > 15)
                        {
                            if (value.R + 70 > 255)
                                source.SetPixel(j, i, Color.White);
                            else if (value.R + 70 < 255)
                                source.SetPixel(j, i, Color.FromArgb(value.R + 70, value.R + 70, value.R + 70));
                        }     
                        else
                            source.SetPixel(j, i, Color.Black);
                    }
                }
                pictureBox_negative.Image = source;
                label_light.Visible = true;
            }
            
        }

        private void radioButton_edge_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_XorY.Location = new Point(667, 348);
            pictureBox_negative.Visible = true;
            pictureBox_NegativeClick.Visible = true;
            groupBox_size.Visible = true;
            groupBox_method.Visible = false;
            label_alphavalue.Visible = false;
            textBox_alpha.Visible = false;
            groupBox_XorY.Visible = false;
        }

        private void radioButton_highboost_CheckedChanged(object sender, EventArgs e)
        {
            label_light.Visible = false;
            pictureBox_negative.Visible = false;
            groupBox_XorY.Location = new Point(667, 348);
            pictureBox_NegativeClick.Visible = false;
            groupBox_size.Visible = true;
            groupBox_method.Visible = false;
            label_alphavalue.Visible = true;
            textBox_alpha.Visible = true;
            groupBox_XorY.Visible = false;
        }

        private void radioButton_gradient_CheckedChanged(object sender, EventArgs e)
        {
            label_light.Visible = false;
            pictureBox_negative.Visible = false;
            groupBox_XorY.Location = new Point(367, 348);
            pictureBox_NegativeClick.Visible = false;
            groupBox_size.Visible = false;
            groupBox_method.Visible = true;
            label_alphavalue.Visible = false;
            textBox_alpha.Visible = false;
            groupBox_XorY.Visible = true;
        }

        private void pictureBox_clickOK_Click(object sender, EventArgs e)
        {
            Bitmap Result = new Bitmap(pictureBox_Source.Image);
            int mask33 = 3, mask55 = 5, mask77 = 7;
            label_Result.Visible = true;
            if (radioButton_edge.Checked)
            {
                groupBox_XorY.Location = new Point(667, 348);
                if (radioButton_mask3.Checked)
                {
                    Result = Highpass_Func.EdgeCrispen(Result, mask33);
                    pictureBox_Result.Image = Result;
                }
                else if (radioButton_mask5.Checked)
                {
                    Result = Highpass_Func.EdgeCrispen(Result, mask55);
                    pictureBox_Result.Image = Result;
                }
                else if (radioButton_mask7.Checked)
                {
                    Result = Highpass_Func.EdgeCrispen(Result, mask77);
                    pictureBox_Result.Image = Result;
                }
            }
            else if (radioButton_highboost.Checked)
            {
                groupBox_XorY.Location = new Point(667, 348);
                double alpha;
                if (radioButton_mask3.Checked && textBox_alpha.Text != null)
                {
                    alpha = double.Parse(textBox_alpha.Text.ToString());
                    Result = Highpass_Func.HighBoost(Result, mask33, alpha);
                    pictureBox_Result.Image = Result;
                }
                else if (radioButton_mask5.Checked && textBox_alpha.Text != null)
                {
                    alpha = double.Parse(textBox_alpha.Text.ToString());
                    Result = Highpass_Func.HighBoost(Result, mask55, alpha);
                    pictureBox_Result.Image = Result;
                }
                else if (radioButton_mask7.Checked && textBox_alpha.Text != null)
                {
                    alpha = double.Parse(textBox_alpha.Text.ToString());
                    Result = Highpass_Func.HighBoost(Result, mask77, alpha);
                    pictureBox_Result.Image = Result;
                }
            }
            else if (radioButton_gradient.Checked)
            {
                groupBox_XorY.Location = new Point(367, 348);
                if (radioButton_Sobel.Checked)
                {
                    int SOBLE_X = 0, SOBLE_Y = 1, SOBLE_XY = 2;
                    if (radioButton_sobelX.Checked)
                    {
                        Result = Highpass_Func.Soble(Result, SOBLE_X);
                        pictureBox_Result.Image = Result;
                    }
                    if (radioButton_sobleY.Checked)
                    {
                        Result = Highpass_Func.Soble(Result, SOBLE_Y);
                        pictureBox_Result.Image = Result;
                    }
                    if (radioButton_sobelXY.Checked)
                    {
                        Result = Highpass_Func.Soble(Result, SOBLE_XY);
                        pictureBox_Result.Image = Result;
                    }
                }
                if (radioButton_Prewitt.Checked)
                {
                    int PREWITT_X = 0, PREWITT_Y = 1, PREWITT_XY = 2;
                    if (radioButton_sobelX.Checked)
                    {
                        Result = Highpass_Func.Prewitt(Result, PREWITT_X);
                        pictureBox_Result.Image = Result;
                    }
                    if (radioButton_sobleY.Checked)
                    {
                        Result = Highpass_Func.Prewitt(Result, PREWITT_Y);
                        pictureBox_Result.Image = Result;
                    }
                    if (radioButton_sobelXY.Checked)
                    {
                        Result = Highpass_Func.Prewitt(Result, PREWITT_XY);
                        pictureBox_Result.Image = Result;
                    }
                }
                if (radioButton_Roberts.Checked)
                {
                    int ROBERT_X = 0, ROBERT_Y = 1, ROBERT_XY = 2;
                    if (radioButton_sobelX.Checked)
                    {
                        Result = Highpass_Func.Robert(Result, ROBERT_X);
                        pictureBox_Result.Image = Result;
                    }
                    if (radioButton_sobleY.Checked)
                    {
                        Result = Highpass_Func.Robert(Result, ROBERT_Y);
                        pictureBox_Result.Image = Result;
                    }
                    if (radioButton_sobelXY.Checked)
                    {
                        Result = Highpass_Func.Robert(Result, ROBERT_XY);
                        pictureBox_Result.Image = Result;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an filter");
            }
            
        }
        //method
        private void radioButton_Sobel_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_XorY.Visible = true;
        }

        private void radioButton_Prewitt_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_XorY.Visible = true;
        }
        private void radioButton_Roberts_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_XorY.Visible = true;
        }

        private void radioButton_sobelXY_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
