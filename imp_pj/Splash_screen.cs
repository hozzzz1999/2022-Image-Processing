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
    public partial class Splash_screen : Form
    {
        public Splash_screen()
        {
            InitializeComponent();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            int counter = progressBar1.Value;
            progressBar1.Value += 1;
            label_CopyRight.BackColor = Color.Transparent;
            label_ImageProcessing.BackColor = Color.Transparent;
            label_ImageProcessing.ForeColor = Color.FromArgb(255 - 2 * counter, 255 - 2 * counter, 255 - 2 * counter);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                this.Close();
            }
        }
        
    }
}
