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
    public partial class Form7PAYMENTUPDATE : Form
    {

        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection con = new SqlConnection(@"Data Source =  (LocalDB)\v11.0; Integrated Security= True; database =  BoardingHouse");
        //SqlCommandBuilder scb;
        DataTable dt;

        public Form7PAYMENTUPDATE()
        {
            InitializeComponent();
        }
        private void disp_data()
        {

            sda = new SqlDataAdapter("select StudentID as [Student ID] ,  Name , MonthlyPayment As [Monthly Payment], NumberofMonth As [Number of Month], Monthh As [Month], TotalAmount As [Total Amount], TotalPaid As [Total Paid], Balance, Deposit, Dte As [Date Registered] from Payments Order by StudentID desc", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
          

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 64, 64);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void Form7PAYMENTUPDATE_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow.Index != -1)
            {
                string vt, vt1;
             Form8PAYMENT f8 = new Form8PAYMENT
                (
                dataGridView1.CurrentRow.Cells[0].Value.ToString(),
                dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                dataGridView1.CurrentRow.Cells[2].Value.ToString(),
                dataGridView1.CurrentRow.Cells[3].Value.ToString(),
                dataGridView1.CurrentRow.Cells[4].Value.ToString(),
                dataGridView1.CurrentRow.Cells[5].Value.ToString(),
                dataGridView1.CurrentRow.Cells[6].Value.ToString(),
                dataGridView1.CurrentRow.Cells[7].Value.ToString(),
                dataGridView1.CurrentRow.Cells[8].Value.ToString(),
                dataGridView1.CurrentRow.Cells[9].Value.ToString()
               
                );
             vt = dataGridView1.CurrentRow.Cells[7].Value.ToString();
             vt1 = dataGridView1.CurrentRow.Cells[2].Value.ToString();

             if (vt == "0")
             {
                 if (MessageBox.Show("Already Paid! Do you want to proceed?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                 {

                         f8.ShowDialog();
                         this.Close();
                 }
             }
             else if (vt1 == "")
             {

             }
             else
             {
                 f8.ShowDialog();
                 this.Close();
                 // this.Close(); this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
             }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "STUDENT ID")
            {
              

                sda = new SqlDataAdapter("select StudentID as [Student ID] ,  Name , MonthlyPayment As [Monthly Payment], NumberofMonth As [Number of Month], Monthh As [Month], TotalAmount As [Total Amount], TotalPaid As [Total Paid], Balance, Deposit, Dte As [Date Registered] from Payments where StudentID LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "NAME")
            {


                sda = new SqlDataAdapter("select Name , StudentID as [Student ID] ,   MonthlyPayment As [Monthly Payment], NumberofMonth As [Number of Month], Monthh As [Month], TotalAmount As [Total Amount], TotalPaid As [Total Paid], Balance, Deposit, Dte As [Date Registered] from Payments where Name LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "MONTH")
            {

                sda = new SqlDataAdapter("select Monthh As [Month], StudentID as [Student ID] ,  Name , MonthlyPayment As [Monthly Payment], NumberofMonth As [Number of Month],  TotalAmount As [Total Amount], TotalPaid As [Total Paid], Balance, Deposit, Dte As [Date Registered] from Payments Order by StudentID desc", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox1.Text = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboBox2.Text == "STUDENT ID")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select StudentID from Payments order by StudentID asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["StudentID"].ToString());
                }
                con.Close();

                sda = new SqlDataAdapter("select StudentID as [Student ID] ,  Name , MonthlyPayment As [Monthly Payment], NumberofMonth As [Number of Month], Monthh As [Month], TotalAmount As [Total Amount], TotalPaid As [Total Paid], Balance, Deposit, Dte As [Date Registered] from Payments where StudentID LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "NAME")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select Name from Payments order by StudentID asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Name"].ToString());
                }
                con.Close();

                sda = new SqlDataAdapter("select Name , StudentID as [Student ID] ,   MonthlyPayment As [Monthly Payment], NumberofMonth As [Number of Month], Monthh As [Month], TotalAmount As [Total Amount], TotalPaid As [Total Paid], Balance, Deposit, Dte As [Date Registered] from Payments where Name LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "MONTH")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select Monthh from Payments order by StudentID asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Month"].ToString());
                }
                con.Close();

                sda = new SqlDataAdapter("select Month As [Month], StudentID as [Student ID] , Name ,  MonthlyPayment As [Monthly Payment], NumberofMonth As [Number of Month],  TotalAmount As [Total Amount], TotalPaid As [Total Paid], Balance, Deposit, Dte As [Date Registered] from Payments where Name LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

           

            //if (comboBox2.Text == "SURNAME")
            //{
            //    comboBox1.Items.Clear();
            //    con.Open();
            //    cmd = con.CreateCommand();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = ("Select StudentID from Payments order by StudentID asc");
            //    cmd.ExecuteNonQuery();
            //    DataTable dt1 = new DataTable();
            //    SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
            //    sda1.Fill(dt1);
            //    foreach (DataRow dr in dt1.Rows)
            //    {
            //        comboBox1.Items.Add(dr["StudentID"].ToString());
            //    }
            //    con.Close();

            //    SqlDataAdapter sda = new SqlDataAdapter("select TransNum as [Transction Number], StudentID as [Student ID] , Name , MonthlyPayment As [Monthly Payment], PaymentMethod As [Payment Method], NumberofMonth As [Number of Month], TotalAmount As [Total Amount], Balance, Cash, Change, Dte As [Date] from Payments where STUDENTID LIKE '" + textBox1.Text + "%'", con);
            //    DataTable dt = new DataTable();
            //    sda.Fill(dt);
            //    dataGridView1.DataSource = dt;
            //}
            //if (comboBox2.Text == "DATE")
            //{
            //    comboBox1.Items.Clear();
            //    con.Open();
            //    cmd = con.CreateCommand();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = ("Select StudentID from Payments order by StudentID asc");
            //    cmd.ExecuteNonQuery();
            //    DataTable dt1 = new DataTable();
            //    SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
            //    sda1.Fill(dt1);
            //    foreach (DataRow dr in dt1.Rows)
            //    {
            //        comboBox1.Items.Add(dr["StudentID"].ToString());
            //    }
            //    con.Close();

            //    SqlDataAdapter sda = new SqlDataAdapter("select TransNum as [Transction Number], StudentID as [Student ID] , Name , MonthlyPayment As [Monthly Payment], PaymentMethod As [Payment Method], NumberofMonth As [Number of Month], TotalAmount As [Total Amount], Balance, Cash, Change, Dte As [Date] from Payments where Dte LIKE '" + textBox1.Text + "%'", con);
            //    DataTable dt = new DataTable();
            //    sda.Fill(dt);
            //    dataGridView1.DataSource = dt;
            //}

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2MAIN f2 = new Form2MAIN();
            f2.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2MAIN f2 = new Form2MAIN();
            f2.Show();
        }

      

       

       
    }
}
