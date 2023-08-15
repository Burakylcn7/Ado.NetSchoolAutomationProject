using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ado.NETStudentInformationSystem
{
    public partial class StudentPage : Form
    {
        public StudentPage()
        {
            InitializeComponent();
        }

        //dataGridView1.Columns[0].Width = 100;

        SqlConnection _connection = new SqlConnection("Server=DESKTOP-E0RBSNH; Database=ProjeOkulDeneme; integrated security=true;");
        public int _getUserID;

        public void UserLogin()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Students where StudentID = @id ", _connection);
            cmd.Parameters.AddWithValue("@id", _getUserID);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LblNameSurname.Tag = Convert.ToInt32(reader["StudentID"].ToString());
            LblNameSurname.Text = reader["StudentNameSurname"].ToString().ToUpper();
            LblTcNo.Text = reader["StudentTcNo"].ToString();
            LblStudentNo.Tag = Convert.ToInt32(reader["RoleID"].ToString());
            LblStudentNo.Text = reader["StudentNo"].ToString();
            LblBirthday.Text = reader["StudentBirthday"].ToString().Substring(0, reader["StudentBirthday"].ToString().Substring(0, 12).LastIndexOf(" "));
            LblNumber.Text = reader["StudentNumber"].ToString();
            LblMail.Text = reader["StudentMail"].ToString().ToLower();
            LblDeparment.Tag = reader["DepartmentID"].ToString();
            PcbxImage.ImageLocation = reader["StudentImage"].ToString();

            TxtUpdateNameSurname.Tag = Convert.ToInt32(reader["StudentID"].ToString());
            TxtUpdateNameSurname.Text = reader["StudentNameSurname"].ToString();
            TxtUpdateTcNo.Text = reader["StudentTcNo"].ToString();
            TxtUpdateStudentNo.Text = reader["StudentNo"].ToString();
            DtpUpdateBirhtday.Text = reader["StudentBirthday"].ToString();
            MTxtUpdateNumber.Text = reader["StudentNumber"].ToString();
            TxtUpdateMail.Text = reader["StudentMail"].ToString();
            TxtUpdatePassword.Text = reader["StudentPassword"].ToString();
            TxtUpdateImage.Text = reader["StudentImage"].ToString();
            PcbxUpdateImage.ImageLocation = reader["StudentImage"].ToString();

            _connection.Close();
        }

        public void UserLoginDepartment()
        {
            SqlCommand cmd;
            SqlDataReader reader;

            _connection.Open();
            cmd = new SqlCommand("select * from Departments where DepartmentID = @departmentID", _connection);
            cmd.Parameters.AddWithValue("@departmentID", LblDeparment.Tag);
            reader = cmd.ExecuteReader();
            reader.Read();
            LblDeparment.Text = reader["DepartmentName"].ToString();
            _connection.Close();
        }

        public void CourseList()
        {
            //select  DepartmentCourse.DepartmentCourseID AS [ID], DepartmentName As [BÖLÜM] , CourseName as [DERS], TeacherNameSurname as [ÖGRETMEN] from DepartmentCourse FULL JOIN Departments on DepartmentCourse.DepartmentID = Departments.DepartmentID FULL JOIN Courses on DepartmentCourse.CourseID = Courses.CourseID FULL JOIN Teachers on DepartmentCourse.TeacherID = Teachers.TeacherID where DepartmentCourse.DepartmentID = 2;
            //select DepartmentID AS [BÖLÜM],CourseID AS [DERS],TeacherID AS [ÖĞRETMEN] from DepartmentCourse where DepartmentID = @id
            SqlCommand cmd = new SqlCommand("select DepartmentCourse.DepartmentCourseID AS [ID], DepartmentName As [BÖLÜM] , CourseName as [DERS], TeacherNameSurname as [ÖĞRETMEN] from DepartmentCourse FULL JOIN Departments on DepartmentCourse.DepartmentID = Departments.DepartmentID FULL JOIN Courses on DepartmentCourse.CourseID = Courses.CourseID FULL JOIN Teachers on DepartmentCourse.TeacherID = Teachers.TeacherID where DepartmentCourse.DepartmentID = @id", _connection);
            cmd.Parameters.AddWithValue("@id", LblDeparment.Tag);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvCourse.DataSource = dt;
        }

        public void NotificationList()
        {
            SqlCommand cmd = new SqlCommand("select NotificationTitle AS [BİLDİRİM BAŞLIĞI],NotificationContent AS [İÇERİK] from Notifications where RoleID = @id", _connection);
            cmd.Parameters.AddWithValue("@id", LblStudentNo.Tag);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvNotifications.DataSource = dt;
        }

        public void CourseSearch(string sqlsearch)
        {
            SqlCommand cmd = new SqlCommand(sqlsearch, _connection);
            cmd.Parameters.AddWithValue("@search", TxtCourseSearch.Text);
            cmd.Parameters.AddWithValue("@id", LblDeparment.Tag);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvCourse.DataSource = dt;
        }

        public void NotificationSearch(string sqlfind)
        {
            SqlCommand cmd = new SqlCommand(sqlfind, _connection);
            cmd.Parameters.AddWithValue("@find", TxtNotificationSearch.Text);
            cmd.Parameters.AddWithValue("@id", LblStudentNo.Tag);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvNotifications.DataSource = dt;
        }

        public void clear()
        {
            TxtCourseSearch.Clear();
            TxtNotificationSearch.Clear();
        }


        private void TxtUpdatePassword_MouseDown(object sender, MouseEventArgs e)
        {
            TxtUpdatePassword.UseSystemPasswordChar = false;
        }

        private void TxtUpdatePassword_MouseUp(object sender, MouseEventArgs e)
        {
            TxtUpdatePassword.UseSystemPasswordChar = true;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void StudentPage_Load(object sender, EventArgs e)
        {
            UserLogin();
            UserLoginDepartment();
            CourseList();
            NotificationList();
        }

        private void BtnSearchList_Click(object sender, EventArgs e)
        {
            string search;

            if (string.IsNullOrEmpty(TxtCourseSearch.Text))
            {
                CourseList();
            }
            else if (CmbxCourseSearch.SelectedItem == "DERS ADI")
            {
                //select DepartmentCourse.DepartmentCourseID AS [ID], DepartmentName As [BÖLÜM] , CourseName as [DERS], TeacherNameSurname as [ÖGRETMEN] from DepartmentCourse FULL JOIN Departments on DepartmentCourse.DepartmentID = Departments.DepartmentID FULL JOIN Courses on DepartmentCourse.CourseID = Courses.CourseID FULL JOIN Teachers on DepartmentCourse.TeacherID = Teachers.TeacherID where DepartmentCourse.DepartmentID = @id
                search = "select DepartmentCourse.DepartmentCourseID AS [ID], DepartmentName As [BÖLÜM] , CourseName as [DERS], TeacherNameSurname as [ÖĞRETMEN] from DepartmentCourse FULL JOIN Departments on DepartmentCourse.DepartmentID = Departments.DepartmentID FULL JOIN Courses on DepartmentCourse.CourseID = Courses.CourseID FULL JOIN Teachers on DepartmentCourse.TeacherID = Teachers.TeacherID where DepartmentCourse.DepartmentID = @id and CourseName like '%'+@search+'%'";
                CourseSearch(search);
                clear();
            }
            else if (CmbxCourseSearch.SelectedItem == "ÖĞRETMEN ADI")
            {
                //select DepartmentID AS [BÖLÜM],CourseID AS [DERS],TeacherID AS [ÖĞRETMEN] from DepartmentCourse where DepartmentID = @id and TeacherID like '%'+@search+'%'"
                search = "select DepartmentCourse.DepartmentCourseID AS [ID], DepartmentName As [BÖLÜM] , CourseName as [DERS], TeacherNameSurname as [ÖĞRETMEN] from DepartmentCourse FULL JOIN Departments on DepartmentCourse.DepartmentID = Departments.DepartmentID FULL JOIN Courses on DepartmentCourse.CourseID = Courses.CourseID FULL JOIN Teachers on DepartmentCourse.TeacherID = Teachers.TeacherID where DepartmentCourse.DepartmentID = @id and TeacherNameSurname like '%'+@search+'%'";
                CourseSearch(search);
                clear();
            }
        }

        private void BtnNotificationSearchList_Click(object sender, EventArgs e)
        {
            string find;

            if (string.IsNullOrEmpty(TxtNotificationSearch.Text))
            {
                NotificationList();
            }
            else if (CmbxNotificationSearch.SelectedItem == "BAŞLIK")
            {
                find = "select NotificationTitle AS [BİLDİRİM BAŞLIĞI],NotificationContent AS [İÇERİK] from Notifications where RoleID = @id and NotificationTitle like '%'+@find+'%'";
                NotificationSearch(find);
                clear();
            }
            else if (CmbxNotificationSearch.SelectedItem == "İÇERİK")
            {
                find = "select NotificationTitle AS [BİLDİRİM BAŞLIĞI],NotificationContent AS [İÇERİK] from Notifications where RoleID = @id and NotificationContent like '%'+@find+'%'";
                NotificationSearch(find);
                clear();
            }
        }

        private void BtnNotificationSearchClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void BtnSearchClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (CkbxUpdateApprove.Checked)
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("update Students set StudentBirthday = @SBirthday ,StudentNumber = @SNumber, StudentMail = @SMail,StudentPassword = @SPassword, StudentImage = @SImage where StudentID = @ID", _connection);
                cmd.Parameters.AddWithValue("ID", TxtUpdateNameSurname.Tag);
                cmd.Parameters.AddWithValue("SBirthday", Convert.ToDateTime(DtpUpdateBirhtday.Text));
                cmd.Parameters.AddWithValue("SNumber", MTxtUpdateNumber.Text);
                cmd.Parameters.AddWithValue("SMail", TxtUpdateMail.Text);
                cmd.Parameters.AddWithValue("SPassword", TxtUpdatePassword.Text);
                cmd.Parameters.AddWithValue("SImage", TxtUpdateImage.Text);
                cmd.ExecuteNonQuery();
                _connection.Close();
                UserLogin();
                CkbxUpdateApprove.Checked = false;
            }
            else
            {
                MessageBox.Show("Lütfen Yaptığınız Değişiklikleri Onaylayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnUpdateImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            PcbxUpdateImage.ImageLocation = openFileDialog1.FileName;
            TxtUpdateImage.Text = openFileDialog1.FileName;
        }

        private void DtgvCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DtgvCourse.CurrentRow;
            int _setStudentID = Convert.ToInt32(LblNameSurname.Tag);
            string _setCourseName = row.Cells["DERS"].Value.ToString();
            if (e.ColumnIndex == 0)
            {
                ResultShow resultShow = new ResultShow();
                resultShow._getStudentID = _setStudentID;
                resultShow._getCourseName = _setCourseName;
                resultShow.Show();
            }
        }
    }
}
