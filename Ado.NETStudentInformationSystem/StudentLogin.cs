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

namespace Ado.NETStudentInformationSystem
{
    public partial class StudentLogin : Form
    {
        public StudentLogin()
        {
            InitializeComponent();
        }

        SqlConnection _connection = new SqlConnection("Server=DESKTOP-E0RBSNH; Database=ProjeOkulDeneme; integrated security=true;");

        private void StudentLogin_Load(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void TxtUserName_Click(object sender, EventArgs e)
        {
            TxtTcNo.BackColor = Color.White;
            PnlUserName.BackColor = Color.White;
            TxtPassword.BackColor = SystemColors.Control;
            PnlPassword.BackColor = SystemColors.Control;
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {
            TxtTcNo.BackColor = SystemColors.Control;
            PnlUserName.BackColor = SystemColors.Control;
            TxtPassword.BackColor = Color.White;
            PnlPassword.BackColor = Color.White;
        }

        private void PcbxPasswordIcon_MouseDown(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = false;
        }

        private void PcbxPasswordIcon_MouseUp(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = true;
        }

        private void BtnToForget_Click(object sender, EventArgs e)
        {
            ForgotMyPassword myPassword = new ForgotMyPassword();
            string selectQuery = "select * from Students where StudentTcNo = @tcno";
            string selectArea = "StudentPassword";
            myPassword.sqlQuery = selectQuery;
            myPassword.sqlArea = selectArea;
            myPassword.Show();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Students where StudentTcNo = @tcno and StudentPassword = @password", _connection);
            cmd.Parameters.AddWithValue("@tcno", TxtTcNo.Text);
            cmd.Parameters.AddWithValue("@password", TxtPassword.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id =Convert.ToInt32(reader[0].ToString());
                StudentPage studentPage = new StudentPage();
                studentPage._getUserID = id;
                studentPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız. Lütfen Tekrar Deneyin!","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                TxtTcNo.Clear();
                TxtPassword.Clear();
            }
            _connection.Close();
        }
    }
}
