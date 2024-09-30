using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace BOARDING_HOUSE
{
    public partial class Form12NOTE : Form
    {
        PrintDocument document = new PrintDocument();
        PrintDialog dialog = new PrintDialog();

        public Form12NOTE()
        {
            InitializeComponent();
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
        }

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtbxnote1.Text, new Font("Segoe UI", 20, FontStyle.Regular), Brushes.Black, 20, 20);
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            Form2MAIN frm2 = new Form2MAIN();
            frm2.Show();
            this.Hide();
        }

        private void txtbxnote1_TextChanged(object sender, EventArgs e)
        {
            if (txtbxnote1.Text == "")
            {
                btnSave.Enabled = false; btnDelete.Enabled = false;
            }
            if (txtbxnote1.Text != "")
            {
                btnSave.Enabled = true; btnDelete.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtbxnote1.Text != "")
            {
                DialogResult Result1 = MessageBox.Show("Are you sure you want to delete this note?", "Delete Note", MessageBoxButtons.YesNo);
                if (Result1 == DialogResult.Yes)
                {
                    txtbxnote1.Text = ""; txtbxtitle1.Clear();
                    btnUploadtoFiles.Enabled = false; button2.Enabled = false;
                }
                else
                {
                    panel1.Focus();
                }
            }
            else if (txtbxnote1.Text == "")
            {
                MessageBox.Show("Note is blank! Please input data.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtbxnote1.Text != "")
            {
                txtbxtitle1.Show(); txtbxnote1.Show();
                MessageBox.Show("Note 1 Saved!");

                btnUploadtoFiles.Enabled = true; button2.Enabled = true;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            dialog.Document = document;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void label44_Click(object sender, EventArgs e)
        {
            this.Close();
        }





















    }
}
