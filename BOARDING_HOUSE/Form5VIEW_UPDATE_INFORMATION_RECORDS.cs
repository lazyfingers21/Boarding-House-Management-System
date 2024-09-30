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
    public partial class Form5VIEW_UPDATE_INFORMATION_RECORDS : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection con = new SqlConnection(@"Data Source =  (LocalDB)\v11.0; Integrated Security= True; database =  BoardingHouse");
       SqlCommandBuilder scb;
        DataTable dt;

        public Form5VIEW_UPDATE_INFORMATION_RECORDS()
        {
            InitializeComponent();
        }
        private void disp_data()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register Order by StudentID  asc", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

          

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 64, 64);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void Form5VIEW_UPDATE_INFORMATION_RECORDS_Load(object sender, EventArgs e)
        {
            disp_data();
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow.Index != -1)
            {
                String vt;
                Form6UPDATE_DELETE f6 = new Form6UPDATE_DELETE
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
                 dataGridView1.CurrentRow.Cells[9].Value.ToString(),
                 dataGridView1.CurrentRow.Cells[10].Value.ToString(),
                 dataGridView1.CurrentRow.Cells[11].Value.ToString(),
                 dataGridView1.CurrentRow.Cells[12].Value.ToString(),
                 dataGridView1.CurrentRow.Cells[13].Value.ToString(),
                 dataGridView1.CurrentRow.Cells[14].Value.ToString(),
                 dataGridView1.CurrentRow.Cells[15].Value.ToString()

                 );
               vt = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                if (vt == "")
                {

                }
                else
                {
                    f6.ShowDialog();
                    this.Close();
                }

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            Form2MAIN f2 = new Form2MAIN();
            f2.Show();
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form2MAIN f2 = new Form2MAIN();
            f2.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
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
                cmd.CommandText = ("Select StudentID from Register order by StudentID asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["StudentID"].ToString());
                }
                con.Close();

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where StudentID LIKE '" + textBox1.Text + "%'", con);
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
                cmd.CommandText = ("Select Name from Register order by StudentID asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Name"].ToString());
                }
                con.Close();

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Name LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "MIDDLE NAME")
            {

                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select MiddleName from Register order by MiddleName asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["MiddleName"].ToString());
                }
                con.Close();

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Middlename LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "SURNAME")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select SurName from Register order by SurName asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Surname"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Surname LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "ADDRESS")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select Addre from Register order by Addre asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Addre"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Addre LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "BIRHDATE")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select Bdate from Register order by Bdate asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Bdate"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Bdate LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "AGE")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select Age from Register order by Age asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Age"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Age LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "GENDER")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select Gender from Register order by Gender asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Gender"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Gender  LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "COURSE")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select Course from Register order by Course asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Course"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Course LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "MAJOR")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select Major from Register order by Major asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Major"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Major LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "CONTACT NUMBER")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select ContactNUm from Register order by ContactNum asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["ContactNUm"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where ContactNum LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            if (comboBox2.Text == "PARENTS NUMBER")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select ParentNum from Register order by ParentNum asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["ParentNUm"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where ParentNum LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "SCHOOL YEAR")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select SchoolYear from Register order by SchoolYear asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["SchoolYear"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where SchoolYear LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "SEMESTER")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select Semester from Register order by Semester asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Semester"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Semester LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "YEAR LEVEL")
            {
                comboBox1.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Select Yearlevelfrom Register order by Yearlevel asc");
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["Yearlevel"].ToString());
                }
                con.Close();
                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Yearlevel LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "STUDENT ID")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where StudentID LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "NAME")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Name LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "MIDDLE NAME")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where MiddleName LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "SURNAME")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Surname LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "ADDRESS")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Addre LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "BIRHDATE")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Bdate LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "AGE")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Age LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "GENDER")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Gender LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "COURSE")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Course LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "MAJOR")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Major LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "CONTACT NUMBER")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where ContactNum LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            if (comboBox2.Text == "PARENTS NUMBER")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where ParentNum LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "SCHOOL YEAR")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where SchoolYear LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "SEMESTER")
            {

                sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where SemesterLIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "YEAR LEVEL")
            {

                SqlDataAdapter sda = new SqlDataAdapter("select StudentID as [Student ID] , NumMem As [No# of Boarder(s)], Name , MiddleName As [Middle Name], Surname, Addre As [Address], Bdate As [BirthDate], Age, Gender, Course, Major, ContactNum As [Contact Number], ParentNum As [Parents Number], SchoolYear As [School Year], Semester, Yearlevel As [Year Level] from Register where Yearlevel LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void label18_Click(object sender, EventArgs e)
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
