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
    public partial class TeacherLogin : Form
    {
        public TeacherLogin()
        {
            InitializeComponent();
        }

        SqlConnection _connection = new SqlConnection("Server=DESKTOP-E0RBSNH; Database=ProjeOkulDeneme; integrated security=true;");

        private void TeacherLogin_Load(object sender, EventArgs e)
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
            string selectQuery = "select * from Teachers where TeacherTcNo = @tcno";
            string selectArea = "TeacherPassword";
            myPassword.sqlQuery = selectQuery;
            myPassword.sqlArea = selectArea;
            myPassword.Show();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Teachers where TeacherTcNo = @tcno and TeacherPassword = @password", _connection);
            cmd.Parameters.AddWithValue("@tcno", TxtTcNo.Text);
            cmd.Parameters.AddWithValue("@password", TxtPassword.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int rol = Convert.ToInt32(reader["RoleID"].ToString());
                if (rol == 1) 
                {
                    int id = Convert.ToInt32(reader[0].ToString());
                    PrincipalPage principalPage = new PrincipalPage();
                    principalPage._getUserID = id;
                    principalPage.Show();
                    this.Hide();
                }
                if(rol == 2)
                {
                    int id = Convert.ToInt32(reader[0].ToString());
                    TeacherPage teacherPage = new TeacherPage();
                    teacherPage._getUserID = id;
                    teacherPage.Show();
                    this.Hide();
                } 
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız. Lütfen Tekrar Deneyin!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtTcNo.Clear();
                TxtPassword.Clear();
            }
            _connection.Close();
        }
    }
}

