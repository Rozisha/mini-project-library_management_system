using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-L5RCT9N\\SQLEXPRESS; database = library; integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;   
            con.Open();

            cmd = new SqlCommand("select bName from NewBook",con);
            SqlDataReader Sdr = cmd.ExecuteReader();    

            while(Sdr.Read())
            {
                for(int i = 0; i < Sdr.FieldCount; i++)
                {
                    ComboBoxBooks.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            con.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtRollNo.Text !="" )
            {
                String eid=txtRollNo.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-L5RCT9N\\SQLEXPRESS; database = library; integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where sRollNo = '" + eid + "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);


                
                //======================================================================================
                //code to count the number of books issued to that particular student roll number
                cmd.CommandText = "select count(std_rollno) from IRBook where std_rollno = '" + eid + "' and book_return_date is null";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA.Fill(DS1);

                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());
                //====================================================================================
                


                if (DS.Tables[0].Rows.Count != 0 )
                {
                    txtName.Text = DS.Tables[0].Rows[0][1].ToString(); 
                    txtenrollyr.Text = DS.Tables[0].Rows[0][3].ToString();
                    txtProgram.Text = DS.Tables[0].Rows[0][4].ToString();
                    txtPhoneNo.Text = DS.Tables[0].Rows[0][5].ToString();   

                }
                else
                {
                    txtName.Clear();
                    txtenrollyr.Clear();        
                    txtProgram.Clear();
                    txtPhoneNo.Clear();
                    MessageBox.Show("Invalid Roll Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void bynIssue_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="")
            {
                if(ComboBoxBooks.SelectedIndex != -1 && count <=1) 
                {
                    Int64 rollno= Int64.Parse(txtRollNo.Text);
                    String sname= txtName.Text;
                    String enrollyr = txtenrollyr.Text;
                    String program = txtProgram.Text;
                    Int64 contact = Int64.Parse(txtPhoneNo.Text);
                    String bookname = ComboBoxBooks.Text;
                    String bookIssueDate = btnIssueDate.Text;
                   

                    String eid = txtRollNo.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = DESKTOP-L5RCT9N\\SQLEXPRESS; database = library; integrated security= True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = cmd.CommandText = "insert into IRBook (std_rollno, std_name, std_enrollyr, std_program, std_contact, book_name, book_issue_date) values ("+rollno+",'"+sname+"',"+enrollyr+",'"+ program +"',"+contact+",'"+bookname+"','"+bookIssueDate+"' )";
                  
                    con.Close();

                    MessageBox.Show("Book Issued.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Select Book OR Maximum number of book has been issued", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
