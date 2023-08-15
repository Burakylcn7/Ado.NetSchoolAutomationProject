using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ado.NETStudentInformationSystem
{
    public partial class ResultShow : Form
    {
        public ResultShow()
        {
            InitializeComponent();
        }

        SqlConnection _connection = new SqlConnection("Server=DESKTOP-E0RBSNH; Database=ProjeOkulDeneme; integrated security=true;");
        public int _getStudentID;
        public string _getCourseName;
        public int _getCourseID;

        public void ResultList()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Results where StudentID = @studentID and CourseID = @courseID ", _connection);
            cmd.Parameters.AddWithValue("@studentID", _getStudentID);
            cmd.Parameters.AddWithValue("@courseID", _getCourseID);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LblResultCourseName.Tag = Convert.ToInt32(reader["ResultID"].ToString());
            LblResultVisaNot.Text = reader["Visa"].ToString();
            LblResultFinalNot.Text = reader["Final"].ToString();
            LblResultRestNot.Text = reader["Rest"].ToString();
            _connection.Close();

        }
        public void CourseList()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Courses where CourseName = @courseName", _connection);
            cmd.Parameters.AddWithValue("@courseName", _getCourseName);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            _getCourseID = Convert.ToInt32(reader["CourseID"].ToString());
            _connection.Close();
        }

        public void Rating()
        {
            if (!(string.IsNullOrEmpty(LblResultRestNot.Text) || Convert.ToDouble(LblResultRestNot.Text) == 0))
            {
                if (Convert.ToDouble(LblResultRestNot.Text) >= 50)
                {
                    LblResultRating.Text = "GEÇTİ";
                    LblResultRating.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    LblResultRating.Text = "KALDI";
                    LblResultRating.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void ResultShow_Load(object sender, System.EventArgs e)
        {
            CourseList();
            ResultList();
            LblResultCourseName.Text = _getCourseName;
            Rating();
        }

        private void BtnBack_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
