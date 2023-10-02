using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtRollNo.Clear();  
            txtEnrollYear.Clear();
            txtProgram.Clear();
            txtPhoneNo.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="" && txtRollNo.Text!="" && txtEnrollYear.Text!="" && txtProgram.Text!="" && txtPhoneNo.Text!="")
            {
                String name = txtName.Text;
                Int64 rollno = Int64.Parse(txtRollNo.Text);
                Int64 enrollyr = Int64.Parse(txtEnrollYear.Text);
                String program = txtProgram.Text;
                Int64 phoneno = Int64.Parse(txtPhoneNo.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-L5RCT9N\\SQLEXPRESS; database = library; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent(sName,sRollNo,sEnrollYr,sProgram,sPhoneNo) values ( '" + name + "', " + rollno + ", " + enrollyr + ", '" + program + "', " + phoneno + " )";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please fill the empty fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
