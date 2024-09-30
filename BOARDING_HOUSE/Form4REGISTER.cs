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
    public partial class Form4REGISTER : Form
    {
        public Form4REGISTER()
        {
            InitializeComponent();
        }


        string rb, cbnm, lb, res, TAP;
        int fdep;
        // SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection con = new SqlConnection(@"Data Source =  (LocalDB)\v11.0; Integrated Security= True; database =  BoardingHouse");
        // SqlCommandBuilder scb;
        DataTable dt;

        private void Form4REGISTER_Load(object sender, EventArgs e)
        {
            int nm, nm1, num1 = 1;
            sda = new SqlDataAdapter("Select Max(NumberMem) from NB", con);
            dt = new DataTable();
            sda.Fill(dt);
            nm = Convert.ToInt32(dt.Rows[0][0]);

            nm1 = nm + num1;
            label31.Text = nm1.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                String mp = textBox11.Text.ToString();
                int mp1 = Int32.Parse(mp);

                String nm = comboBox5.Text.ToString();
                int nm1 = Int32.Parse(nm);

                int cal = mp1 * nm1;

                label30.Text = cal.ToString();
                button3.Visible = true;
                textBox13.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                label25.Visible = true;
                button4.Visible = true;


                button4.BackColor = Color.Teal;
            }
            catch
            {
                MessageBox.Show("Input Correct Data!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBox5.Text = "";
                comboBox5.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String cash = textBox13.Text.ToString();
                int cash1 = Int32.Parse(cash);

                String ta = label30.Text.ToString();
                int ta1 = Int32.Parse(ta);
                if (cash1 >= ta1)
                {
                    int cal2 = cash1 - ta1;

                    label25.Text = cal2.ToString();
                    button1.Visible = true;
                    button6.Visible = true;

                    tdep.Visible = true;
                    label32.Visible = true;

                    tdep.Text = cal2.ToString();
                }
                else
                {

                    MessageBox.Show("INSUFFICIENT CASH!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox13.Text = "";
                    textBox13.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Input Correct Data!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox13.Text = "";
                textBox13.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure that you want to Deposit?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    //String inputdep = textBox14.Text.ToString();
                    //int inp = Int32.Parse(inputdep);
                    //String change = label25.Text.ToString();
                    //int ch1 = Int32.Parse(change);
                    //String dep = label34.Text.ToString();
                    //int dep1 = Int32.Parse(dep);

                    //if (inp <= ch1)
                    //{
                    //    int cal = ch1 - inp;
                    //    label25.Text = cal.ToString();
                    //    button1.Visible = true;
                    //    button6.Visible = true;
                    //    textBox14.Visible = true;
                    //    label32.Visible = true;
                    //    label33.Visible = true;
                    //    label34.Visible = true;
                    //    button7.Visible = true;

                    //    dep1 = dep1 + inp;
                    //    label34.Text = dep1.ToString();
                    //    fdep = dep1;
                    //    textBox14.Focus();
                    //    textBox14.Text = "";
                    //}
                    //else
                    //{
                    //    MessageBox.Show("INSUFFICIENT!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    textBox14.Text = "";
                    //    textBox14.Focus();
                    //}
                    ldep.Text = tdep.Text;
                    label33.Visible = true;
                    ldep.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Input Correct Data!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tdep.Text = "";
                tdep.Focus();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            String Inpdep = tdep.Text.ToString();
            int Inpdep1 = Int32.Parse(Inpdep);
            String change = label25.Text.ToString();
            int change1 = Int32.Parse(change);
            String dep = ldep.Text.ToString();
            int dep1 = Int32.Parse(dep);

            if (Inpdep1 <= dep1)
            {
                int cal2 = change1 + Inpdep1;
                label25.Text = cal2.ToString();
                button1.Visible = true;
                button6.Visible = true;
                tdep.Visible = true;
                label32.Visible = true;
                dep1 = dep1 - Inpdep1;
                ldep.Text = dep1.ToString();
                tdep.Text = "";
                tdep.Focus();
                fdep = dep1;
            }
            else
            {
                MessageBox.Show("INSUFFICIENT!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tdep.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string mon;
                mon = comboBox9.Text + " - " + comboBox10.Text;

                if (textBox1.Text == "" ||
               textBox2.Text == "" ||
               textBox3.Text == "" ||
               dateTimePicker1.Text == "" ||
               textBox5.Text == "" ||
               textBox6.Text == "" ||
              comboBox7.Text == "" ||
               comboBox8.Text == "" ||
               textBox9.Text == "" ||
               textBox10.Text == "" ||
               textBox12.Text == "" ||
               comboBox4.Text == "" ||
               comboBox1.Text == "" ||
               comboBox2.Text == "" ||
               comboBox3.Text == "")
                {

                    MessageBox.Show("Please fill up all information needed!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    if (MessageBox.Show("Are you sure that you want to Save?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        if (radioButton1.Checked)
                        {
                            cbnm = comboBox5.Text;
                            lb = "0";
                            rb = "Cash";
                            res = "Paid";
                            TAP = label30.Text;
                        }
                        if (radioButton2.Checked)
                        {
                            cbnm = comboBox6.Text;
                            rb = "Credit";
                            lb = label28.Text;
                            label30.Text = label28.Text;
                            textBox13.Text = "0";
                            res = "Unpaid";
                            TAP = "0";

                        }

                        //try
                        //{


                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into Register values('" + textBox1.Text + "','" + label31.Text + "','" + transNum.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox12.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + comboBox3.Text + "','" + comboBox7.Text + "','" + comboBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + comboBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "' )"; //
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "insert into Payments values('" + textBox1.Text + "','" + transNum.Text + "','" + textBox2.Text + "','" + textBox11.Text + "','" + rb + "','" + cbnm + "', '" + mon + "', '" + label30.Text + "','" + lb + "','" + textBox13.Text + "','" + label25.Text + "','" + TAP + "','" + res + "','" + ldep.Text + "','" + dateTimePicker2.Text + "' )";
                        cmd2.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        SqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandType = CommandType.Text;
                        cmd3.CommandText = "insert into NB values('" + label31.Text + "')";
                        cmd3.ExecuteNonQuery();
                        con.Close();





                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        dateTimePicker1.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        comboBox7.Text = "";
                        comboBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox12.Text = "";
                        comboBox4.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        comboBox3.Text = "";


                        label28.Text = "0";
                        textBox13.Text = "";
                        label25.Text = "0";
                        label30.Text = "0";
                        comboBox6.Text = "";
                        comboBox5.Text = "";
                        label30.Text = "0";
                        textBox13.Text = "";


                        button6.Visible = false;
                        tdep.Visible = false;
                        label23.Visible = false;
                        label24.Visible = false;
                        label25.Visible = false;
                        textBox13.Visible = false;
                        label33.Visible = false;
                        ldep.Visible = false;
                        label32.Visible = false;
                        //}
                        //catch
                        //{
                        //    MessageBox.Show("PLEASE FILL UP ALL INFORNATION!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    this.Show();

                        //}
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            MessageBox.Show("New Account Registered", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Check if Student ID Number is already taken.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Text = "";
                textBox1.Focus();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2MAIN f2 = new Form2MAIN();
            f2.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2MAIN f2 = new Form2MAIN();
            f2.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Hide();
            comboBox6.Focus();
            TAP = "0";
            cbnm = comboBox6.Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Show();
            comboBox5.Focus();

            cbnm = comboBox5.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String mp = textBox11.Text.ToString();
            int mp1 = Int32.Parse(mp);

            String nm = comboBox6.Text.ToString();
            int nm1 = Int32.Parse(nm);

            int cal = mp1 * nm1;

            label28.Text = cal.ToString();

            button1.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                button4.Visible = true;
            }
            if (comboBox5.Text == "")
            {
                button4.Visible = false;
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text != "")
            {
                button3.Visible = true;
            }
            if (textBox13.Text == "")
            {
                button3.Visible = false;
            }
        }

        private void tdep_TextChanged(object sender, EventArgs e)
        {
            if (tdep.Text != "")
            {
                button6.Visible = true;
            }
            if (tdep.Text == "")
            {
                button6.Visible = false;
            }
        }

        private void label25_VisibleChanged(object sender, EventArgs e)
        {
            if (label25.Visible == true)
            {
                button1.Visible = true;
            }
            if (label25.Visible == false)
            {
                button1.Visible = false;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                comboBox4.Items.Add(comboBox4.Text);
                MessageBox.Show("New School Year Added!", "Add School Year", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox4.Text = "";
                comboBox4.Focus();
            }
            else
            {
                MessageBox.Show("Invalid Input!", "Add School Year", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime From = dateTimePicker1.Value;
            DateTime To = DateTime.Now;
            TimeSpan TSpan = To - From;
            Double Days = TSpan.TotalDays;
            textBox5.Text = (Days / 365).ToString("0");
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox12.Focus();
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox4.Focus();
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox7.Focus();
            }
        }

        private void comboBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox8.Focus();
            }
        }

        private void comboBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox10.Focus();
            }
        }

        private void comboBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox10.Focus();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form2MAIN f2 = new Form2MAIN();
            f2.Show();
        }





       













    }
}
