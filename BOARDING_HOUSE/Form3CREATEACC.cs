using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BOARDING_HOUSE
{
    public partial class Form3CREATEACC : Form
    {
        public Form3CREATEACC()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source =  (LocalDB)\v11.0; Integrated Security= True; database =  BoardingHouse");
        
        public void save()
        {
            try
            {
                if ((textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("")))
                {
                    MessageBox.Show("Please complete the needed information!", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (textBox2.Text.Equals(textBox3.Text))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Accounts values('" + textBox1.Text + "','" + textBox2.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();


                    MessageBox.Show("Added New Account!");
                    this.Close();
                    Form1LOGIN f1 = new Form1LOGIN();
                    f1.Show();

                }
                else
                {
                    MessageBox.Show("Passwords do not match!", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                textBox1.Clear();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
            }
            catch
            {

                textBox1.Clear();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1LOGIN f1 = new Form1LOGIN();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                lblexclamationpoint.Show();
                lblpassdonotmatch.Show();
            }
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                lblexclamationpoint.Hide();
                lblpassdonotmatch.Hide();
            }
            else if (textBox2.Text == textBox3.Text)
            {
                lblexclamationpoint.Hide();
                lblpassdonotmatch.Hide();
                button1.Enabled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                lblexclamationpoint.Show();
                lblpassdonotmatch.Show();
            }
            if (textBox3.Text == "")
            {
                lblexclamationpoint.Hide();
                lblpassdonotmatch.Hide();
            }
            else if (textBox2.Text == textBox3.Text)
            {
                lblexclamationpoint.Hide();
                lblpassdonotmatch.Hide();
                button1.Enabled = true;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            btnShow.Hide();
            btnHide.Show();
            textBox2.Focus();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            btnShow.Show();
            btnHide.Hide();
            textBox2.Focus();
        }

        private void btnShow2_Click(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = false;
            btnShow2.Hide();
            btnHide2.Show();
            textBox3.Focus();
        }

        private void btnHide2_Click(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
            btnShow2.Show();
            btnHide2.Hide();
            textBox3.Focus();
        }










    }
}
