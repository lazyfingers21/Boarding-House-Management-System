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
    public partial class Form2MAIN : Form
    {
        public Form2MAIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4REGISTER f4 = new Form4REGISTER();
            f4.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7PAYMENTUPDATE f7 = new Form7PAYMENTUPDATE();
            f7.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5VIEW_UPDATE_INFORMATION_RECORDS f5 = new Form5VIEW_UPDATE_INFORMATION_RECORDS();
            f5.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1LOGIN f1 = new Form1LOGIN();
            f1.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12NOTE frm12 = new Form12NOTE();
            frm12.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4REGISTER f4 = new Form4REGISTER();
            f4.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5VIEW_UPDATE_INFORMATION_RECORDS f5 = new Form5VIEW_UPDATE_INFORMATION_RECORDS();
            f5.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form7PAYMENTUPDATE f7 = new Form7PAYMENTUPDATE();
            f7.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form12NOTE frm12 = new Form12NOTE();
            frm12.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1LOGIN frm1 = new Form1LOGIN();
            frm1.Show();
            this.Close();
        }


        
        
        





    }
}
