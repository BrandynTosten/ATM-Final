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

namespace ATMSystem
{
    public partial class TrustyBank : Form
    {
        public TrustyBank()
        {
            InitializeComponent();
        }

        private void TrustyBank_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=localhost;database=ATM;UID=sa;password=123456789;");
            SqlCommand cmd = new SqlCommand("select * from Userlogins where UserName=@UserName and Password =@Password", con);
            cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();

            con.Close();
            if (dt.Rows.Count > 0)
            {

                MessageBox.Show("Welcome");  
                WelcomePage settingsForm = new WelcomePage();

                this.Hide();
                settingsForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter Correct Username and Password");
            }
        }
    }
}
