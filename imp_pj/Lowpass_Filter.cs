using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imp_pj
{
    public partial class Lowpass_Filter : Form
    {
        public int filter_flag = 1, size_flag = 2, method_flag = 3;
        
        public Lowpass_Filter(Bitmap origin_image)
        {
            InitializeComponent();
            pictureBox_Source.Image = origin_image;
        }

        private void pictureBox_botton_AddNoise_Click(object sender, EventArgs e)
        {
            Bitmap noise_image = new Bitmap(pictureBox_Source.Image);
            if(pictureBox_AddNoise.Image != null)
            {
                noise_image = Noise.AddNoise((Bitmap)pictureBox_AddNoise.Image);
                pictureBox_AddNoise.Image = noise_image;
            }
            else
            {
                noise_image = Noise.AddNoise(noise_image);
                pictureBox_AddNoise.Image = noise_image;
            }
            double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_AddNoise.Image);
            snr_value = Math.Round(snr_value,3);
            label_noiseSNR.Text = "SNR: " + snr_value.ToString();
            label_addnoise.Visible = true;
            label_noiseSNR.Visible = true;
        }

        private void pictureBox_clickOK_Click(object sender, EventArgs e)
        {
            Bitmap Source;
            if(pictureBox_AddNoise.Image != null)
            {
                Source = new Bitmap(pictureBox_AddNoise.Image);
            }
            else
            {
                Source = new Bitmap(pictureBox_Source.Image);
            }
            
            if(filter_botton_seletion(filter_flag) == default && filter_botton_seletion(size_flag) == default)
            {
                MessageBox.Show("Please select radio buttons");
            }
            else
            {
                label_resultimg.Visible = true;
                label_resultSNR.Visible = true;
            }
            int mask3x3 = 3, mask5x5 = 5, mask7x7 = 7;
            //Outlier
            if (radioButton_Outlier.Checked)
            {
                Bitmap Result = new Bitmap(pictureBox_Source.Image);
                int T = trackBar1.Value;
                label_T.Text = "T:" + trackBar1.Value.ToString();
                // 3x3 mask
                if (radioButton_mask3.Checked)
                {
                    pictureBox_Result.Image = Lowpass_Func.OutlierFilter(Source, mask3x3, T);
                    double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_Result.Image);
                    snr_value = Math.Round(snr_value, 3);
                    label_resultSNR.Text = "SNR: " + snr_value.ToString();
                }
                // 5x5 mask
                else if (radioButton_mask5.Checked)
                {
                    pictureBox_Result.Image = Lowpass_Func.OutlierFilter(Source, mask5x5, T);
                    double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_Result.Image);
                    snr_value = Math.Round(snr_value, 3);
                    label_resultSNR.Text = "SNR: " + snr_value.ToString();
                }
                // 7x7 mask
                else if (radioButton_mask7.Checked)
                {
                    pictureBox_Result.Image = Lowpass_Func.OutlierFilter(Source, mask7x7, T);
                    double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_Result.Image);
                    snr_value = Math.Round(snr_value, 3);
                    label_resultSNR.Text = "SNR: " + snr_value.ToString();
                }
            }
            //Average
            if (radioButton_Average.Checked)
            {
                Bitmap Result = new Bitmap(pictureBox_Source.Image);
                // 3x3 mask
                if (radioButton_mask3.Checked)
                {
                    pictureBox_Result.Image = Lowpass_Func.AverageFilter(Source, mask3x3);
                    double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_Result.Image);
                    snr_value = Math.Round(snr_value, 3);
                    label_resultSNR.Text = "SNR: " + snr_value.ToString();
                }
                // 5x5 mask
                else if (radioButton_mask5.Checked)
                {
                    pictureBox_Result.Image = Lowpass_Func.AverageFilter(Source, mask5x5);
                    double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_Result.Image);
                    snr_value = Math.Round(snr_value, 3);
                    label_resultSNR.Text = "SNR: " + snr_value.ToString();
                }
                // 7x7 mask
                else if (radioButton_mask7.Checked)
                {
                    pictureBox_Result.Image = Lowpass_Func.AverageFilter(Source, mask7x7);
                    double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_Result.Image);
                    snr_value = Math.Round(snr_value, 3);
                    label_resultSNR.Text = "SNR: " + snr_value.ToString();
                }
            }
            //Median
            if (radioButton_Median.Checked)
            {
                int method = 0;
                Bitmap Result = new Bitmap(pictureBox_Source.Image);
                if (radioButton_Square.Checked)
                {
                    method = 0;
                    if (radioButton_mask3.Checked)
                    {
                        pictureBox_Result.Image = Lowpass_Func.MedianFilter(Source, mask3x3, method);
                        double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_Result.Image);
                        snr_value = Math.Round(snr_value, 3);
                        label_resultSNR.Text = "SNR: " + snr_value.ToString();
                    }
                    // 5x5 mask
                    else if (radioButton_mask5.Checked)
                    {
                        pictureBox_Result.Image = Lowpass_Func.MedianFilter(Source, mask5x5, method);
                        double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_Result.Image);
                        snr_value = Math.Round(snr_value, 3);
                        label_resultSNR.Text = "SNR: " + snr_value.ToString();
                    }
                    // 7x7 mask
                    else if (radioButton_mask7.Checked)
                    {
                        pictureBox_Result.Image = Lowpass_Func.MedianFilter(Source, mask7x7, method);
                        double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_Result.Image);
                        snr_value = Math.Round(snr_value, 3);
                        label_resultSNR.Text = "SNR: " + snr_value.ToString();
                    }               
                    
                }
                else if (radioButton_Cross.Checked)
                {
                    method = 1;
                    pictureBox_Result.Image = Lowpass_Func.MedianFilter(Source, mask3x3, method);
                    double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_Result.Image);
                    snr_value = Math.Round(snr_value, 3);
                    label_resultSNR.Text = "SNR: " + snr_value.ToString();
                }
                else if (radioButton_Pseudo.Checked)
                {
                    method = 2;
                    pictureBox_Result.Image = Lowpass_Func.MedianFilter(Source, mask3x3, method);
                    double snr_value = snr.SNR((Bitmap)pictureBox_Source.Image, (Bitmap)pictureBox_Result.Image);
                    snr_value = Math.Round(snr_value, 3);
                    label_resultSNR.Text = "SNR: " + snr_value.ToString();
                }
            }
        }

        private RadioButton filter_botton_seletion(int flag)
        {
            var filter_buttoms = groupBox_filter.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            var size_buttoms = groupBox_size.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            var method_buttoms = groupBox_method.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            if (flag == filter_flag)
                return filter_buttoms;
            else if (flag == size_flag)
                return size_buttoms;
            else if (flag == method_flag)
                return method_buttoms;
            else
                return default;
        }
        //==================================Filter radio buttom click=======================================
        private void radioButton_Outlier_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_size.Visible = true;
            groupBox_method.Visible = false;
            trackBar1.Visible = true;
            label_T.Visible = true;
        }
        //for outlier
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_T.Text = "T:" + trackBar1.Value.ToString();
        }

        private void radioButton_Average_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_method.Visible = false;
            groupBox_size.Visible = true;
            trackBar1.Visible = false;
            label_T.Visible = false;
        }   

        private void radioButton_Median_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_method.Visible = true;
            groupBox_size.Visible = false;
            trackBar1.Visible = false;
            label_T.Visible = false;
        }
        //==================================Mask_Size radio buttom click=======================================

        //==================================Method radio buttom click=========================================
        private void radioButton_Square_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_size.Visible = true;
        }
        private void radioButton_Cross_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_size.Visible = false;
            /*if (radioButton_Square.Checked)
                groupBox_size.Visible = true;
            else
                groupBox_size.Visible = false;*/
        }
        private void radioButton_Pseudo_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_size.Visible = false;
            /*if (radioButton_Square.Checked)
                groupBox_size.Visible = true;
            else
                groupBox_size.Visible = false;*/
        }
    }
}
