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
    public partial class ForgotMyPassword : Form
    {
        public ForgotMyPassword()
        {
            InitializeComponent();
        }

        SqlConnection _connection = new SqlConnection("Server=DESKTOP-E0RBSNH; Database=ProjeOkulDeneme; integrated security=true;");
        public string sqlQuery;
        public string sqlArea;
        Random _random = new Random();
        public void SecurityCode()
        {
            int security = _random.Next(100000, 1000000);
            TxtRandomShow.Text = security.ToString();
        }

        public void ForgetPasswordQuery(string sql, string area) 
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand(sql, _connection);
            cmd.Parameters.AddWithValue("@tcno", TxtTcNo.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string pass = reader[area].ToString();
                MessageBox.Show(pass,"ŞİFRENİZ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                TxtTcNo.Clear();
                TxtSecurity.Clear();
                SecurityCode();

            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız. Lütfen Tekrar Deneyin!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtTcNo.Clear();
                TxtSecurity.Clear();
                SecurityCode();
            }
            _connection.Close();
        }

        private void ForgotMyPassword_Load(object sender, EventArgs e)
        {
            SecurityCode();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnVerify_Click(object sender, EventArgs e)
        {
            if (TxtSecurity.Text == TxtRandomShow.Text)
            {
                ForgetPasswordQuery(sqlQuery, sqlArea);
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız. Lütfen Tekrar Deneyin!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtTcNo.Clear();
                TxtSecurity.Clear();
                SecurityCode();
            }
        }

        private void BtnRandomChange_Click(object sender, EventArgs e)
        {
            SecurityCode();
        }
    }
}
