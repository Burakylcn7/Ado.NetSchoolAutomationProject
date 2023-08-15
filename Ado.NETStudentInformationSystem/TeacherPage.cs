using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Ado.NETStudentInformationSystem
{
    public partial class TeacherPage : Form
    {
        public TeacherPage()
        {
            InitializeComponent();
        }

        SqlConnection _connection = new SqlConnection("Server=DESKTOP-E0RBSNH; Database=ProjeOkulDeneme; integrated security=true;");
        public int _getUserID;

        public void UserLogin()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Teachers where TeacherID = @id ", _connection);
            cmd.Parameters.AddWithValue("@id", _getUserID);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LblNameSurname.Tag = Convert.ToInt32(reader["TeacherID"].ToString());
            LblNameSurname.Text = reader["TeacherNameSurname"].ToString().ToUpper();
            LblTcNo.Text = reader["TeacherTcNo"].ToString();
            LblTcNo.Tag = Convert.ToInt32(reader["RoleID"].ToString());
            LblBirthday.Text = reader["TeacherBirthday"].ToString().Substring(0, reader["TeacherBirthday"].ToString().Substring(0, 12).LastIndexOf(" "));
            LblNumber.Text = reader["TeacherNumber"].ToString();
            LblMail.Text = reader["TeacherMail"].ToString().ToLower();
            LblDeparment.Tag = reader["DepartmentID"].ToString();
            LblCourse.Tag = reader["CourseID"].ToString();
            PcbxImage.ImageLocation = reader["TeacherImage"].ToString();

            TxtUpdateNameSurname.Tag = Convert.ToInt32(reader["TeacherID"].ToString());
            TxtUpdateNameSurname.Text = reader["TeacherNameSurname"].ToString();
            TxtUpdateTcNo.Text = reader["TeacherTcNo"].ToString();
            DtpUpdateBirhtday.Text = reader["TeacherBirthday"].ToString();
            MTxtUpdateNumber.Text = reader["TeacherNumber"].ToString();
            TxtUpdateMail.Text = reader["TeacherMail"].ToString();
            TxtUpdatePassword.Text = reader["TeacherPassword"].ToString();
            TxtUpdateImage.Text = reader["TeacherImage"].ToString();
            PcbxUpdateImage.ImageLocation = reader["TeacherImage"].ToString();

            _connection.Close();
        }

        public void UserLoginDepartmentAndCourse()
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

            _connection.Open();
            cmd = new SqlCommand("select * from Courses where CourseID = @courseID", _connection);
            cmd.Parameters.AddWithValue("@courseID", LblCourse.Tag);
            reader = cmd.ExecuteReader();
            reader.Read();
            LblCourse.Text = reader["CourseName"].ToString();
            _connection.Close();
        }
        public void StudentList()
        {
            SqlCommand cmd = new SqlCommand("select Students.StudentID AS [ID],StudentNo AS [ÖĞRENCİ NO],StudentNameSurname AS [ADI SOYADI],StudentMail AS [MAİL],StudentNumber AS [TELEFON NO],DepartmentName AS [BÖLÜM] from Students JOIN Departments on Students.DepartmentID = Departments.DepartmentID where Students.DepartmentID = @id", _connection);
            cmd.Parameters.AddWithValue("@id", LblDeparment.Tag);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvStudent.DataSource = dt;
        }

        public void NotificationList()
        {
            SqlCommand cmd = new SqlCommand("select NotificationTitle AS [BİLDİRİM BAŞLIĞI],NotificationContent AS [İÇERİK] from Notifications where RoleID = @id", _connection);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(LblTcNo.Tag));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvNotifications.DataSource = dt;
        }

        public void StudentSearch(string sqlsearch)
        {
            SqlCommand cmd = new SqlCommand(sqlsearch, _connection);
            cmd.Parameters.AddWithValue("@search", TxtStudentSearch.Text);
            cmd.Parameters.AddWithValue("@id", LblDeparment.Tag);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvStudent.DataSource = dt;
        }

        public void NotificationSearch(string sqlfind)
        {
            SqlCommand cmd = new SqlCommand(sqlfind, _connection);
            cmd.Parameters.AddWithValue("@find", TxtNotificationSearch.Text);
            cmd.Parameters.AddWithValue("@id", LblTcNo.Tag);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvNotifications.DataSource = dt;
        }

        public void clear()
        {
            TxtStudentSearch.Clear();
            TxtNotificationSearch.Clear();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TeacherPage_Load(object sender, EventArgs e)
        {
            UserLogin();
            UserLoginDepartmentAndCourse();
            StudentList();
            NotificationList();
        }

        private void BtnSearchList_Click(object sender, EventArgs e)
        {
            string search;

            if (string.IsNullOrEmpty(TxtStudentSearch.Text))
            {
                StudentList();
            }
            else if (CmbxStudentSearch.SelectedItem == "ÖĞRENCİ NO")
            {
                search = "select Students.StudentID AS [ID],StudentNo AS [ÖĞRENCİ NO],StudentNameSurname AS [ADI SOYADI],StudentMail AS [MAİL],StudentNumber AS [TELEFON NO],DepartmentName AS [BÖLÜM] from Students JOIN Departments on Students.DepartmentID = Departments.DepartmentID where Students.DepartmentID = @id and StudentNo like '%'+@search+'%'";
                StudentSearch(search);
                clear();
            }
            else if (CmbxStudentSearch.SelectedItem == "AD SOYAD")
            {
                search = "select Students.StudentID AS [ID],StudentNo AS [ÖĞRENCİ NO],StudentNameSurname AS [ADI SOYADI],StudentMail AS [MAİL],StudentNumber AS [TELEFON NO],DepartmentName AS [BÖLÜM] from Students JOIN Departments on Students.DepartmentID = Departments.DepartmentID where Students.DepartmentID = @id and StudentNameSurname like '%'+@search+'%'";
                StudentSearch(search);
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
                SqlCommand cmd = new SqlCommand("update Teachers set TeacherBirthday = @TBirthday ,TeacherNumber = @TNumber, TeacherMail = @TMail,TeacherPassword = @TPassword, TeacherImage = @TImage where TeacherID = @ID", _connection);
                cmd.Parameters.AddWithValue("ID", TxtUpdateNameSurname.Tag);
                cmd.Parameters.AddWithValue("TBirthday", Convert.ToDateTime(DtpUpdateBirhtday.Text));
                cmd.Parameters.AddWithValue("TNumber", MTxtUpdateNumber.Text);
                cmd.Parameters.AddWithValue("TMail", TxtUpdateMail.Text);
                cmd.Parameters.AddWithValue("TPassword", TxtUpdatePassword.Text);
                cmd.Parameters.AddWithValue("TImage", TxtUpdateImage.Text);
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

        private void TxtUpdatePassword_MouseDown(object sender, MouseEventArgs e)
        {
            TxtUpdatePassword.UseSystemPasswordChar = false;
        }

        private void TxtUpdatePassword_MouseUp(object sender, MouseEventArgs e)
        {
            TxtUpdatePassword.UseSystemPasswordChar = true;
        }

        private void BtnUpdateImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            PcbxUpdateImage.ImageLocation = openFileDialog1.FileName;
            TxtUpdateImage.Text = openFileDialog1.FileName;
        }

        private void DtgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DtgvStudent.CurrentRow;
            int _setStudentID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            string _setStudentName = row.Cells["ADI SOYADI"].Value.ToString();
            int _setCourseID = Convert.ToInt32(LblCourse.Tag);
            if (e.ColumnIndex == 0)
            {
                ResultInput resultInput = new ResultInput();
                resultInput._getStudentID = _setStudentID;
                resultInput._getStudentName = _setStudentName;
                resultInput._getCourseID = _setCourseID;
                resultInput.Show();
            }
        }
    }
}
