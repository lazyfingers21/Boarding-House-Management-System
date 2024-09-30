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
    public partial class Form1LOGIN : Form
    {
        public Form1LOGIN()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source =  (LocalDB)\v11.0; Integrated Security= True; database =  BoardingHouse");
        
        public void create()      // code
        {
             
        }

        int attempts = 5;

        public void login()      //code login
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Accounts where Username = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1" && attempts > 1)
                {
                    MessageBox.Show("Login Successfull. Welcome " + textBox1.Text + "!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2MAIN f2 = new Form2MAIN();
                    f2.Show();
                    this.Hide();
                }
                if (textBox1.Text != "" && textBox2.Text != "" && dt.Rows[0][0].ToString() != "1" && attempts > 1)
                {
                    attempts--;
                    MessageBox.Show("Wrong Username or Password! You have " + attempts + " attempt(s) remaining.", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
                if (textBox1.Text != "" && textBox2.Text != "" && dt.Rows[0][0].ToString() != "1" && attempts == 1)
                {
                    Form11ATTEMPTS frm11 = new Form11ATTEMPTS();
                    frm11.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Please Check your Username or/and Password");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            login();
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
            Form3CREATEACC f3 = new Form3CREATEACC();
            f3.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form10FORGOTPASS frm10 = new Form10FORGOTPASS();
            frm10.Show();
            this.Hide();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            label6.Show();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            label6.Hide();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            label7.Show();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            label7.Hide();
        }


    }
}
