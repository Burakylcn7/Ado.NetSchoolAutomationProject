using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ado.NETStudentInformationSystem
{
    public partial class CourseSelection : Form
    {
        public CourseSelection()
        {
            InitializeComponent();
        }

        SqlConnection _connection = new SqlConnection("Server=DESKTOP-E0RBSNH; Database=ProjeOkulDeneme; integrated security=true;");
        public int _getStudentID;
        public string _getStudentName;
        public string _getDepartmentName;

        public void DepartmentCourseList()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("select DepartmentCourse.DepartmentCourseID AS [ID], DepartmentName As [BÖLÜM] , CourseName as [DERS], TeacherNameSurname as [ÖGRETMEN] from DepartmentCourse FULL JOIN Departments on DepartmentCourse.DepartmentID = Departments.DepartmentID FULL JOIN Courses on DepartmentCourse.CourseID = Courses.CourseID FULL JOIN Teachers on DepartmentCourse.TeacherID = Teachers.TeacherID where Departments.DepartmentName = @departmentName", _connection);
            cmd.Parameters.AddWithValue("@departmentName", _getDepartmentName);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvCourseSelection.DataSource = dt;
            _connection.Close();
        }
        public void CourseID()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Courses where CourseName = @courseName", _connection);
            cmd.Parameters.AddWithValue("@courseName", LblCourseSelection.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LblCourseSelection.Tag = Convert.ToInt32(reader["CourseID"].ToString());
            _connection.Close();
        }
        public void ResultList()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("select Results.ResultID AS [ID], StudentNameSurname AS [ADI SOYADI], CourseName AS [DERS] from Results FULL JOIN Students on Results.StudentID = Students.StudentID FULL JOIN Courses on Results.CourseID = Courses.CourseID where Results.StudentID = @studentID;", _connection);
            cmd.Parameters.AddWithValue("@studentID", _getStudentID);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvCourseSelection.DataSource = dt;
            _connection.Close();
        }
        private void CourseSelection_Load(object sender, EventArgs e)
        {
            DepartmentCourseList();
            LblStudentSelection.Text = _getStudentName.ToUpper();
        }

        private void DtgvCourseSelection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DtgvCourseSelection.CurrentRow;
            LblCourseSelection.Text = row.Cells["DERS"].Value.ToString();
            LblStudentSelection.Tag = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            if (e.ColumnIndex == 0)
            {
                CourseID();
            }
        }

        private void BtnCourseSelectionList_Click(object sender, EventArgs e)
        {
            DepartmentCourseList();
        }

        private void BtnSelectionList_Click(object sender, EventArgs e)
        {
            ResultList();
        }

        private void BtnCourseSelectionAdd_Click(object sender, EventArgs e)
        {
            if (CkbxApprove.Checked)
            {
                try
                {
                    _connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Results(StudentID,CourseID) values(@studentID,@courseID)", _connection);
                    cmd.Parameters.AddWithValue("@studentID", _getStudentID);
                    cmd.Parameters.AddWithValue("@courseID", LblCourseSelection.Tag);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                _connection.Close();
                ResultList();
                CkbxApprove.Checked = false;
            }
            else
            {
                MessageBox.Show("Lütfen Yaptığınız Değişiklikleri Onaylayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private void BtnCourseSelectionDelete_Click(object sender, EventArgs e)
        {
            if (CkbxApprove.Checked)
            {
                try
                {
                    _connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Results where ResultID = @resultID", _connection);
                    cmd.Parameters.AddWithValue("@resultID", LblStudentSelection.Tag);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
                _connection.Close();
                ResultList();
                CkbxApprove.Checked = false;
            }
            else
            {
                MessageBox.Show("Lütfen Yaptığınız Değişiklikleri Onaylayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
