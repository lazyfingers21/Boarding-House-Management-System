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
    public partial class Form6UPDATE_DELETE : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =  (LocalDB)\v11.0; Integrated Security= True; database =  BoardingHouse");
       
       

        public Form6UPDATE_DELETE(
            string StudentId,
            string Nb,
            string Name,
            string Mname,
            string Surname,
            string Add,
            string Bdate,
            string Age,
            string Gen,
            string Cour,
            string Maj,
            string Cn,
            string Pn,
            string Sy,
            string Sem,
            string Yl)
        {
            InitializeComponent();
            textBox1.Text = StudentId;
            textBox2.Text = Name;
            textBox3.Text = Mname;
            textBox4.Text = Surname;
            textBox5.Text = Add;
            textBox6.Text = Bdate;
            textBox7.Text = Age;
            comboBox3.Text = Gen;
            comboBox5.Text = Cour;
            comboBox6.Text = Maj;
            textBox10.Text = Cn;
            textBox12.Text = Pn;
            comboBox4.Text = Sy;
            comboBox1.Text = Sem;
            comboBox2.Text = Yl;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to Update?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {



                String id = textBox1.Text.ToString();
                String name = textBox2.Text.ToString();
                String mn = textBox3.Text.ToString();
                String sn = textBox4.Text.ToString();
                String add = textBox5.Text.ToString();
                String bdate = textBox6.Text.ToString();
                String age = textBox7.Text.ToString();
                int iage = Int32.Parse(age);
                String gender = comboBox3.Text.ToString();
                String course = comboBox5.Text.ToString();
                String maj = comboBox6.Text.ToString();
                String cn = textBox10.Text.ToString();
                //  long cnum = Int64.Parse(cn);
                String pn = comboBox6.Text.ToString();
                // long pnum = Int64.Parse(pn);
                String sy = comboBox4.Text.ToString();
                String sem = comboBox1.Text.ToString();
                String yl = comboBox2.Text.ToString();

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Update Register set StudentID = '" + id + "', Name = '" + name + "', MiddleName = '" + mn + "', SurName = '" + sn + "', Addre = '" + add + "', Bdate = '" + bdate + "', Age = '" + iage + "', Gender = '" + gender + "', Course = '" + course + "', Major = '" + maj + "', ContactNum = '" + cn + "', ParentNum = '" + pn + "', SchoolYear = '" + sy + "', Semester = '" + sem + "', Yearlevel = '" + yl + "' where StudentID = '" + textBox1.Text + "' ");
                cmd.ExecuteNonQuery();
                con.Close();
            }
            this.Close();
            Form5VIEW_UPDATE_INFORMATION_RECORDS f5 = new Form5VIEW_UPDATE_INFORMATION_RECORDS();
            f5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to Delete it?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Register where StudentID = '" + textBox1.Text + "' ";
                cmd.ExecuteNonQuery();
                con.Close();

                Form5VIEW_UPDATE_INFORMATION_RECORDS f5 = new Form5VIEW_UPDATE_INFORMATION_RECORDS();
                f5.Show();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5VIEW_UPDATE_INFORMATION_RECORDS f5 = new Form5VIEW_UPDATE_INFORMATION_RECORDS();
            f5.Show();
            this.Close();
        }


        private void label18_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
