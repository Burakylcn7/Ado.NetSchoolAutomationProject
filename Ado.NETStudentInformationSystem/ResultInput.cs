using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ado.NETStudentInformationSystem
{
    public partial class ResultInput : Form
    {
        public ResultInput()
        {
            InitializeComponent();
        }

        SqlConnection _connection = new SqlConnection("Server=DESKTOP-E0RBSNH; Database=ProjeOkulDeneme; integrated security=true;");
        public int _getStudentID;
        public int _getCourseID;
        public string _getStudentName;

        public void ResultList()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Results where StudentID = @studentID and CourseID = @courseID ", _connection);
            cmd.Parameters.AddWithValue("@studentID", _getStudentID);
            cmd.Parameters.AddWithValue("@courseID", _getCourseID);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LblResultStudentName.Tag = Convert.ToInt32(reader["ResultID"].ToString());
            TxtResultVisa.Text = reader["Visa"].ToString();
            TxtResultFinal.Text = reader["Final"].ToString();
            LblResultRestNot.Text = reader["Rest"].ToString();
            _connection.Close();
        }
        public void CourseList()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Courses where CourseID = @courseID", _connection);
            cmd.Parameters.AddWithValue("@courseID", _getCourseID);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LblResultCourseName.Text = reader["CourseName"].ToString();
            _connection.Close();
        }
        private void ResultInput_Load(object sender, EventArgs e)
        {
            ResultList();
            LblResultStudentName.Text = _getStudentName.ToUpper();
            CourseList();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnResultAdd_Click(object sender, EventArgs e)
        {
            if (CkbxResultApprove.Checked)
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("Update Results set Visa = @visa, Final = @final, Rest = @rest where ResultID = @resultID", _connection);
                cmd.Parameters.AddWithValue("@resultID", LblResultStudentName.Tag);
                cmd.Parameters.AddWithValue("@visa", TxtResultVisa.Text);
                cmd.Parameters.AddWithValue("@final", TxtResultFinal.Text);
                if (!(string.IsNullOrEmpty(TxtResultFinal.Text)))
                {
                    Double ort = (Convert.ToDouble(TxtResultVisa.Text) * 0.3) + (Convert.ToDouble(TxtResultFinal.Text) * 0.7);
                    cmd.Parameters.AddWithValue("@rest", ort);
                    if (ort >= 50)
                    {
                        LblResultRestNot.BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        LblResultRestNot.BackColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@rest", LblResultRestNot.Text);
                }
                cmd.ExecuteNonQuery();
                _connection.Close();
                ResultList();
                CkbxResultApprove.Checked = false;
            }
            else
            {
                MessageBox.Show("Lütfen Yaptığınız Değişiklikleri Onaylayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
