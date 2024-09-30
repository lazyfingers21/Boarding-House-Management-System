using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOARDING_HOUSE
{
    public partial class Form11ATTEMPTS : Form
    {
        public Form11ATTEMPTS()
        {
            InitializeComponent();
        }

        int timer = 15;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer > 0)
            {
                timer = timer - 1;
                lbltimer.Text = timer + " seconds...";
            }
            else
            {
                timer1.Stop();
                Form1LOGIN frm1 = new Form1LOGIN();
                frm1.Show();
                this.Hide();
            }
        }







    }
}
