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
    public partial class Form10FORGOTPASS : Form
    {
        public Form10FORGOTPASS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                lblField.Show();
            }
            if (textBox2.Text == "")
            {
                lblField2.Show();
            }
            if (textBox1.Text != "1" || textBox2.Text != "2")
            {
                MessageBox.Show("One or more of your answers is incorrect! Please try again.");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }

            if (textBox1.Text == "1" && textBox2.Text == "2")
            {
                MessageBox.Show("Account Successfully Verified!");
                Form3CREATEACC frm3 = new Form3CREATEACC();
                frm3.Show();
                this.Hide();
            }



        }
    }
}
