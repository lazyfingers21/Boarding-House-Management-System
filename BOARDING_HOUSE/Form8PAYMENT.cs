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
    public partial class Form8PAYMENT : Form
    {
        String cash, sta, totalA;
        int totalPaid, cash1, tp , ttlA , cashTA;
        string rb, cbnm, lb, res, TAP;

        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\v11.0; Integrated Security= True; database = BoardingHouse");
        int totaldep = 0;
        public Form8PAYMENT(
            string Str0,
            string Str1,
            string Str2,
            string Str3,
            string Str4,
            string Str5,
            string Str6,
            string Str7,
            string Str8,
            string Str9
           )
        {
            InitializeComponent();
            l1.Text = Str0;
          
            l2.Text = Str1;
            l3.Text = Str7;
           label1.Text = Str8;
           
           sta = Str6;
           totalA = Str5;
           
        }
        private void Form8PAYMENT_Load(object sender, EventArgs e)
        {
        
            label19.Text = l1.Text;
            label36.Text = l2.Text;
            label35.Text = totaldep.ToString(); ;
            label31.Text = l3.Text;
            ldep.Text = label1.Text;
        }
        private void OK()
        {
            Result.Visible = true;
            panel2.Visible = false;

        }
        private void SAVE()
        {
            if (MessageBox.Show("Are you sure that you want to Save?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int vta = Int32.Parse(label31.Text);
                ttlA = Int32.Parse(totalA);
                tp = Int32.Parse(sta);
                l3.Text =label31.Text;
             //   cashTA =  Int32.Parse(textBox13.Text);
                label1.Text = label35.Text;

                if (cash1 >= vta)
                {
                    totalPaid = ttlA;
                   
                }
                else
                {
                    totalPaid = cash1 + tp;
                }
            
                lpaid.Text = cash1.ToString();
              
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Update Payments set Balance = '" + label31.Text + "', TotalPaid = '" + totalPaid + "' , Deposit = '" + label1.Text + "', Result = '" + label38.Text + "' where StudentID = '" + label19.Text + "' ");
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //button3.Visible = true;
            //textBox1.Visible = true;


            //String cash = t4.Text.ToString();
            //int cash1 = Int32.Parse(cash);

            //String bal = l3.Text.ToString();
            //int bal1 = Int32.Parse(bal);
            //if (cash1 >= bal1)
            //{
            //    int cal2 = cash1 - bal1;

            //    l5.Text = cal2.ToString();
            //    textBox1.Text = cal2.ToString();
            //    button1.Visible = true;
            //    // button6.Visible = true;
            //}
            //else
            //{

            //    MessageBox.Show("INSUFFICIENT CASH!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    l5.Text = "0";
            //    textBox1.Text = "";
            //}
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
           OK();
           SAVE();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form7PAYMENTUPDATE f7 = new Form7PAYMENTUPDATE();
            f7.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                cash = textBox13.Text.ToString();
                cash1 = Int32.Parse(cash);

                String ta = l3.Text.ToString();
                int ta1 = Int32.Parse(ta);

                if (ta == "0")
                {
                    MessageBox.Show("Already Paid!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox13.Text = "";
                }
                else
                {



                    if (cash1 >= ta1)
                    {
                        int cal2 = cash1 - ta1;
                        lpaid.Text = l3.Text;

                        label25.Text = cal2.ToString();
                        button1.Visible = true;
                        button6.Visible = true;
                        label24.Text = "Change:";
                        label31.Text = "0";
                        label38.Text = "Paid";
                        tdep.Visible = true;
                        label32.Visible = true;
                        lpaid.Text = l3.Text;

                        label25.Visible = true;
                        label24.Visible = true;
                    }
                    else
                    {


                        int cal2 = ta1 - cash1;
                        label24.Text = "Balance:";
                        label25.Text = cal2.ToString();
                        label31.Text = label25.Text;
                        button1.Visible = true;
                        button6.Visible = true;
                        label38.Text = "Unpaid";
                        tdep.Visible = true;
                        label32.Visible = true;
                        lpaid.Text = textBox13.Text;

                        label25.Visible = true;
                        label24.Visible = true;

                    }
                }
            }
            catch
            {
                MessageBox.Show("Input Correct Data!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox13.Text = "";
                textBox13.Focus();
            }
        }

      

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
                        panel3.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                label13.Text = label1.Text;
                ldep.Visible = false;
                //textBox3.Text = "";
                totaldep = Int32.Parse(label13.Text);

                String input = textBox3.Text.ToString();
                int input1 = Int32.Parse(input);

                String dep = label1.Text.ToString();
                int dep1 = Int32.Parse(dep);

                if (dep1 >= input1)
                {
                    int cal2 = dep1 - input1;
                    label13.Text = cal2.ToString();
                    label35.Text = cal2.ToString();
                    label13.Visible = true;
                    label14.Visible = true;
                    ldep.Text = label1.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Amount!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox3.Clear();
                    textBox3.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Input Correct Data!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox3.Text = "";
                textBox3.Focus();
            }

          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                label13.Text = label1.Text;
                label13.Visible = false;
                textBox3.Text = "";
                totaldep = Int32.Parse(ldep.Text);

                String input = tdep.Text.ToString();
                int input1 = Int32.Parse(input);

                String dep = label1.Text.ToString();
                int dep1 = Int32.Parse(dep);


                int cal2 = dep1 + input1;
                ldep.Text = cal2.ToString();
                label35.Text = cal2.ToString();
                label33.Visible = true;
                ldep.Visible = true;
            }
            catch
            {
                MessageBox.Show("Input Correct Data!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tdep.Text = "";
                tdep.Focus();
            }
         
        }


       

        private void label40_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
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
                textBox2.Visible = true;
                label12.Visible = true;
                label30.Visible = true;
                button7.Visible = true;


                button4.BackColor = Color.Teal;
            }
            catch
            {
                MessageBox.Show("Input Correct Data!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBox5.Text = "";
                comboBox5.Focus();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                String cash = textBox2.Text.ToString();
                int cash1 = Int32.Parse(cash);

                String ta = label30.Text.ToString();
                int ta1 = Int32.Parse(ta);
                if (cash1 >= ta1)
                {
                    int cal2 = cash1 - ta1;

                    label10.Text = cal2.ToString();
                    button1.Visible = true;
                    label10.Visible = true;
                    tdep.Visible = true;
                    label11.Visible = true;
                    label9.Visible = true;
                    label8.Visible = true;
                    label7.Visible = true;
                    textBox1.Text = cal2.ToString();
                    textBox1.Visible = true;
                    label6.Visible = true;
                }
                else
                {

                    MessageBox.Show("INSUFFICIENT CASH!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Input Correct Data!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox2.Text = "";
                textBox2.Focus();
            }
        }

        private void button8_Click(object sender, EventArgs e)
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
                    label6.Text = textBox1.Text;
                    label33.Visible = true;
                    ldep.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Input Correct Data!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           panel4.Show();
            comboBox5.Focus();

            cbnm = comboBox5.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel4.Hide();
            comboBox6.Focus();
            TAP = "0";
            cbnm = comboBox6.Text;
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                button9.Visible = true;
            }
            if (textBox3.Text == "")
            {
                button9.Visible = false;
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

        private void ldep_VisibleChanged(object sender, EventArgs e)
        {
            if (ldep.Visible == true)
            {
                button2.Visible = true; 
            }
            if (ldep.Visible == false)
            {
                button2.Visible = false;
            }
        }

        private void label13_VisibleChanged(object sender, EventArgs e)
        {
            if (label13.Visible == true)
            {
                button2.Visible = true;
            }
            if (label13.Visible == false)
            {
                button2.Visible = false;
            }
        }

        private void label25_VisibleChanged(object sender, EventArgs e)
        {
            if (label25.Visible == true)
            {
                button2.Visible = true;
            }
            if (label25.Visible == false)
            {
                button2.Visible = false;
            }
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                button7.Visible = true;
            }
            if (textBox2.Text == "")
            {
                button7.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button8.Visible = true;
            }
            if (textBox1.Text == "")
            {
                button8.Visible = false;
            }
        }

        private void label10_VisibleChanged(object sender, EventArgs e)
        {
            if (label10.Visible == true)
            {
                button13.Visible = true;
            }
            if (label10.Visible == false)
            {
                button13.Visible = false;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2MAIN f2 = new Form2MAIN();
            f2.Show();
        }











    }
}
