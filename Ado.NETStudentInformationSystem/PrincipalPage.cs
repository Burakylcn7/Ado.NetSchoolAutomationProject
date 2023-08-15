using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ado.NETStudentInformationSystem
{
    public partial class PrincipalPage : Form
    {
        public PrincipalPage()
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

            //_connection.Open();
            //cmd = new SqlCommand("select * from Courses where CourseID = @courseID", _connection);
            //cmd.Parameters.AddWithValue("@courseID", LblCourse.Tag);
            //reader = cmd.ExecuteReader();
            //reader.Read();
            //LblCourse.Text = reader["CourseName"].ToString();
            //_connection.Close();
        }
        public void TeacherList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select Teachers.TeacherID AS [ID], TeacherNameSurname AS [ADI SOYADI], TeacherTcNo AS [TC NO],TeacherMail AS [MAİL],TeacherPassword AS [ŞİFRE],TeacherNumber AS [TELEFON NO],TeacherBirthday AS [DOĞUM TARİHİ],DepartmentName AS [BÖLÜM], CourseName AS [DERS] , RoleName AS [ROL] , TeacherImage AS [FOTOĞRAF] from Teachers JOIN Departments on Teachers.DepartmentID = Departments.DepartmentID JOIN Courses on Teachers.CourseID = Courses.CourseID JOIN Roles on Teachers.RoleID = Roles.RoleID where Teachers.RoleID = 2", _connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvTeacherList.DataSource = dt;
        }
        public void StudentList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select Students.StudentID AS[ID], StudentNameSurname AS[ADI SOYADI], StudentTcNo AS[TC NO], StudentNo AS[ÖĞRENCİ NO], StudentMail AS[MAİL], StudentPassword AS[ŞİFRE], StudentNumber AS[TELEFON NO], StudentBirthday AS[DOĞUM TARİHİ], DepartmentName AS[BÖLÜM], RoleName AS[ROL], StudentImage AS[FOTOĞRAF] from Students FULL JOIN Departments on Students.DepartmentID = Departments.DepartmentID FULL JOIN Roles on Students.RoleID = Roles.RoleID where Students.RoleID = 3", _connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvStudentList.DataSource = dt;
        }
        public void NotificationList()
        {
            //DtgvNotifications
            SqlDataAdapter adapter = new SqlDataAdapter("select Notifications.NotificationID AS [ID], NotificationTitle AS [BAŞLIK], NotificationContent AS [İÇERİK], RoleName AS [ROL] from Notifications INNER JOIN Roles on Notifications.RoleID = Roles.RoleID", _connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvNotifications.DataSource = dt;
        }
        public void DepartmentList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select DepartmentID AS [ID], DepartmentName AS [BÖLÜM] from Departments", _connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvDepartmentList.DataSource = dt;
        }
        public void CourseList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select CourseID AS [ID], CourseName AS [DERS] from Courses", _connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvCourseList.DataSource = dt;
        }
        public void DepartmentCourseList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select DepartmentCourse.DepartmentCourseID AS [ID], DepartmentName As [BÖLÜM] , CourseName as [DERS], TeacherNameSurname as [ÖGRETMEN] from DepartmentCourse FULL JOIN Departments on DepartmentCourse.DepartmentID = Departments.DepartmentID FULL JOIN Courses on DepartmentCourse.CourseID = Courses.CourseID FULL JOIN Teachers on DepartmentCourse.TeacherID = Teachers.TeacherID", _connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvDepartmentCourseList.DataSource = dt;
        }
        public void CmbxDepartmentList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Departments", _connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CmbxDepartmentCourseDepartment.DataSource = dt;
            CmbxDepartmentCourseDepartment.DisplayMember = "DepartmentName";
            CmbxDepartmentCourseDepartment.ValueMember = "DepartmentID";

            CmbxTeacherDeparment.DataSource = dt;
            CmbxTeacherDeparment.DisplayMember = "DepartmentName";
            CmbxTeacherDeparment.ValueMember = "DepartmentID";

            CmbxStudentDeparment.DataSource = dt;
            CmbxStudentDeparment.DisplayMember = "DepartmentName";
            CmbxStudentDeparment.ValueMember = "DepartmentID";
        }
        public void CmbxCourseList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Courses", _connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CmbxDepartmentCourseCourse.DataSource = dt;
            CmbxDepartmentCourseCourse.DisplayMember = "CourseName";
            CmbxDepartmentCourseCourse.ValueMember = "CourseID";

            CmbxTeacherCourse.DataSource = dt;
            CmbxTeacherCourse.DisplayMember = "CourseName";
            CmbxTeacherCourse.ValueMember = "CourseID";
        }
        public void CmbxTeacherList()
        {
            SqlCommand cmd = new SqlCommand("select * from Teachers where DepartmentID = @DepartmentID and CourseID = @CourseID", _connection);
            cmd.Parameters.AddWithValue("@DepartmentID", CmbxDepartmentCourseDepartment.SelectedValue);
            cmd.Parameters.AddWithValue("@CourseID", CmbxDepartmentCourseCourse.SelectedValue);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CmbxDepartmentCourseTeacher.DataSource = dt;
            CmbxDepartmentCourseTeacher.DisplayMember = "TeacherNameSurname";
            CmbxDepartmentCourseTeacher.ValueMember = "TeacherID";
        }

        //public void CmbxRoleList()
        //{
        //    SqlDataAdapter adapter = new SqlDataAdapter("select * from Roles", _connection);
        //    DataTable dt = new DataTable();
        //    adapter.Fill(dt);
        //    CmbxStudentRole.DataSource = dt;
        //    CmbxStudentRole.DisplayMember = "RoleName";
        //    CmbxStudentRole.ValueMember = "RoleID";
        //}
        public void TeacherSearch(string sqlsearch)
        {
            SqlCommand cmd = new SqlCommand(sqlsearch, _connection);
            cmd.Parameters.AddWithValue("@search", TxtTeacherSearch.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvTeacherList.DataSource = dt;
        }
        public void StudentSearch(string sqlsearch)
        {
            SqlCommand cmd = new SqlCommand(sqlsearch, _connection);
            cmd.Parameters.AddWithValue("@search", TxtStudentSearch.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvStudentList.DataSource = dt;
        }
        public void DepartmentCourseSearch(string sqlsearch)
        {
            SqlCommand cmd = new SqlCommand(sqlsearch, _connection);
            cmd.Parameters.AddWithValue("@search", TxtDepartmentCourseSearch.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvDepartmentCourseList.DataSource = dt;
        }
        public void NotificationSearch(string sqlsearch)
        {
            SqlCommand cmd = new SqlCommand(sqlsearch, _connection);
            cmd.Parameters.AddWithValue("@search", TxtNotificationSearch.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DtgvNotifications.DataSource = dt;
        }
        public void TeacherClear()
        {
            TxtTeacherNameSurname.Clear();
            TxtTeacherTcNo.Clear();
            TxtTeacherMail.Clear();
            TxtTeacherPassword.Clear();
            MTxtTeacherNumber.Clear();
            DtpTeacherBirhtday.Text = string.Empty;
            CmbxTeacherDeparment.Text = string.Empty;
            CmbxTeacherCourse.Text = string.Empty;
            CmbxTeacherRole.Text = string.Empty;
            TxtTeacherImage.Clear();
            PcbxTeacherImage.ImageLocation = null;
            CkbxTeacherApprove.Checked = false;
        }
        public void StudentClear()
        {
            TxtStudentNameSurname.Clear();
            TxtStudentTcNo.Clear();
            TxtStudentMail.Clear();
            TxtStudentPassword.Clear();
            MTxtStudentNumber.Clear();
            DtpStudentBirhtday.Text = string.Empty;
            CmbxStudentDeparment.Text = string.Empty;
            TxtStudentNo.Clear();
            TxtStudentImage.Clear();
            PcbxStudentImage.ImageLocation = null;
            CkbxStudentApprove.Checked = false;
        }

        private void PrincipalPage_Load(object sender, EventArgs e)
        {
            UserLogin();
            UserLoginDepartmentAndCourse();
            TeacherList();
            StudentList();
            DepartmentCourseList();
            DepartmentList();
            CourseList();
            CmbxDepartmentList();
            CmbxCourseList();
            NotificationList();
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
        //-----------------------------ÖĞRETMEN BAŞLANGIÇ-----------------------------------------------
        private void DtgvTeacherList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DtgvTeacherList.CurrentRow;
            TxtTeacherNameSurname.Tag = row.Cells["ID"].Value.ToString();
            TxtTeacherNameSurname.Text = row.Cells["ADI SOYADI"].Value.ToString();
            TxtTeacherTcNo.Text = row.Cells["TC NO"].Value.ToString();
            TxtTeacherMail.Text = row.Cells["MAİL"].Value.ToString();
            TxtTeacherPassword.Text = row.Cells["ŞİFRE"].Value.ToString();
            MTxtTeacherNumber.Text = row.Cells["TELEFON NO"].Value.ToString();
            DtpTeacherBirhtday.Text = row.Cells["DOĞUM TARİHİ"].Value.ToString();
            CmbxTeacherDeparment.Text = row.Cells["BÖLÜM"].Value.ToString();
            CmbxTeacherCourse.Text = row.Cells["DERS"].Value.ToString();
            CmbxTeacherRole.Text = row.Cells["ROL"].Value.ToString();
            TxtTeacherImage.Text = row.Cells["FOTOĞRAF"].Value.ToString();
            PcbxTeacherImage.ImageLocation = row.Cells["FOTOĞRAF"].Value.ToString();
        }

        private void BtnTeacherAdd_Click(object sender, EventArgs e)
        {
            if (CkbxTeacherApprove.Checked)
            {

                try
                {
                    _connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Teachers(TeacherNameSurname, TeacherMail, TeacherPassword, TeacherTcNo, TeacherNumber, TeacherBirthday, TeacherImage, DepartmentID, RoleID, CourseID) values(@TeacherNameSurname, @TeacherMail, @TeacherPassword, @TeacherTcNo, @TeacherNumber, @TeacherBirthday, @TeacherImage, @DepartmentID, @RoleID, @CourseID)", _connection);
                    cmd.Parameters.AddWithValue("@TeacherNameSurname", TxtTeacherNameSurname.Text);
                    cmd.Parameters.AddWithValue("@TeacherMail", TxtTeacherMail.Text);
                    cmd.Parameters.AddWithValue("@TeacherPassword", TxtTeacherPassword.Text);
                    cmd.Parameters.AddWithValue("@TeacherTcNo", TxtTeacherTcNo.Text);
                    cmd.Parameters.AddWithValue("@TeacherNumber", MTxtTeacherNumber.Text);
                    cmd.Parameters.AddWithValue("@TeacherBirthday", Convert.ToDateTime(DtpTeacherBirhtday.Text));
                    cmd.Parameters.AddWithValue("@TeacherImage", TxtTeacherImage.Text);
                    cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(CmbxTeacherDeparment.SelectedValue));
                    if (CmbxTeacherRole.SelectedItem == "Müdür")
                    {
                        cmd.Parameters.AddWithValue("@RoleID", 1);
                    }
                    else if (CmbxTeacherRole.SelectedItem == "Öğretmen")
                    {
                        cmd.Parameters.AddWithValue("@RoleID", 2);
                    }
                    cmd.Parameters.AddWithValue("@CourseID", Convert.ToInt32(CmbxTeacherCourse.SelectedValue));
                    cmd.ExecuteNonQuery();
                    TeacherClear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                _connection.Close();
                TeacherList();
                CkbxTeacherApprove.Checked = false;
            }
            else
            {
                MessageBox.Show("Lütfen Yaptığınız Değişiklikleri Onaylayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnTeacherImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            PcbxTeacherImage.ImageLocation = openFileDialog1.FileName;
            TxtTeacherImage.Text = openFileDialog1.FileName;
        }

        private void BtnTeacherClear_Click(object sender, EventArgs e)
        {
            TeacherClear();
        }

        private void BtnTeacherUpdate_Click(object sender, EventArgs e)
        {
            if (CkbxTeacherApprove.Checked)
            {
                try
                {
                    _connection.Open();
                    SqlCommand cmd = new SqlCommand("Update Teachers set TeacherNameSurname = @TeacherNameSurname, TeacherMail = @TeacherMail, TeacherPassword = @TeacherPassword, TeacherTcNo = @TeacherTcNo, TeacherNumber = @TeacherNumber, TeacherBirthday = @TeacherBirthday, TeacherImage = @TeacherImage, DepartmentID = @DepartmentID, RoleID = @RoleID, CourseID = @CourseID where TeacherID = @TeacherID", _connection);
                    cmd.Parameters.AddWithValue("@TeacherID", Convert.ToInt32(TxtTeacherNameSurname.Tag));
                    cmd.Parameters.AddWithValue("@TeacherNameSurname", TxtTeacherNameSurname.Text);
                    cmd.Parameters.AddWithValue("@TeacherMail", TxtTeacherMail.Text);
                    cmd.Parameters.AddWithValue("@TeacherPassword", TxtTeacherPassword.Text);
                    cmd.Parameters.AddWithValue("@TeacherTcNo", TxtTeacherTcNo.Text);
                    cmd.Parameters.AddWithValue("@TeacherNumber", MTxtTeacherNumber.Text);
                    cmd.Parameters.AddWithValue("@TeacherBirthday", Convert.ToDateTime(DtpTeacherBirhtday.Text));
                    cmd.Parameters.AddWithValue("@TeacherImage", TxtTeacherImage.Text);
                    cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(CmbxTeacherDeparment.SelectedValue));
                    if (CmbxTeacherRole.SelectedItem == "Müdür")
                    {
                        cmd.Parameters.AddWithValue("@RoleID", 1);
                    }
                    else if (CmbxTeacherRole.SelectedItem == "Öğretmen")
                    {
                        cmd.Parameters.AddWithValue("@RoleID", 2);
                    }
                    cmd.Parameters.AddWithValue("@CourseID", Convert.ToInt32(CmbxTeacherCourse.SelectedValue));
                    cmd.ExecuteNonQuery();
                    TeacherClear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                _connection.Close();
                TeacherList();
                CkbxTeacherApprove.Checked = false;

            }
            else
            {
                MessageBox.Show("Lütfen Yaptığınız Değişiklikleri Onaylayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnTeacherDelete_Click(object sender, EventArgs e)
        {
            if (CkbxTeacherApprove.Checked)
            {
                try
                {
                    _connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Teachers where TeacherID = @TeacherID", _connection);
                    cmd.Parameters.AddWithValue("@TeacherID", TxtTeacherNameSurname.Tag);
                    cmd.ExecuteNonQuery();
                    TeacherClear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen Silinecek Kişiyi Seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                _connection.Close();
                TeacherList();
                CkbxTeacherApprove.Checked = false;

            }
            else
            {
                MessageBox.Show("Lütfen Yaptığınız Değişiklikleri Onaylayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnTeacherSearchList_Click(object sender, EventArgs e)
        {
            string search;

            if (string.IsNullOrEmpty(TxtTeacherSearch.Text))
            {
                TeacherList();
            }
            else if (CmbxTeacherSearch.SelectedItem == "AD SOYAD")
            {
                search = "select Teachers.TeacherID AS [ID], TeacherNameSurname AS [ADI SOYADI], TeacherTcNo AS [TC NO],TeacherMail AS [MAİL],TeacherPassword AS [ŞİFRE],TeacherNumber AS [TELEFON NO],TeacherBirthday AS [DOĞUM TARİHİ],DepartmentName AS [BÖLÜM], CourseName AS [DERS] , RoleName AS [ROL] , TeacherImage AS [FOTOĞRAF] from Teachers JOIN Departments on Teachers.DepartmentID = Departments.DepartmentID JOIN Courses on Teachers.CourseID = Courses.CourseID JOIN Roles on Teachers.RoleID = Roles.RoleID where Teachers.RoleID = 2 and TeacherNameSurname like '%'+@search+'%'";
                TeacherSearch(search);
                TxtTeacherSearch.Clear();
            }
            else if (CmbxTeacherSearch.SelectedItem == "BÖLÜM")
            {
                search = "select Teachers.TeacherID AS [ID], TeacherNameSurname AS [ADI SOYADI], TeacherTcNo AS [TC NO],TeacherMail AS [MAİL],TeacherPassword AS [ŞİFRE],TeacherNumber AS [TELEFON NO],TeacherBirthday AS [DOĞUM TARİHİ],DepartmentName AS [BÖLÜM], CourseName AS [DERS] , RoleName AS [ROL] , TeacherImage AS [FOTOĞRAF] from Teachers JOIN Departments on Teachers.DepartmentID = Departments.DepartmentID JOIN Courses on Teachers.CourseID = Courses.CourseID JOIN Roles on Teachers.RoleID = Roles.RoleID where Teachers.RoleID = 2 and DepartmentName like '%'+@search+'%'";
                TeacherSearch(search);
                TxtTeacherSearch.Clear();
            }
            else if (CmbxTeacherSearch.SelectedItem == "DERS")
            {
                search = "select Teachers.TeacherID AS [ID], TeacherNameSurname AS [ADI SOYADI], TeacherTcNo AS [TC NO],TeacherMail AS [MAİL],TeacherPassword AS [ŞİFRE],TeacherNumber AS [TELEFON NO],TeacherBirthday AS [DOĞUM TARİHİ],DepartmentName AS [BÖLÜM], CourseName AS [DERS] , RoleName AS [ROL] , TeacherImage AS [FOTOĞRAF] from Teachers JOIN Departments on Teachers.DepartmentID = Departments.DepartmentID JOIN Courses on Teachers.CourseID = Courses.CourseID JOIN Roles on Teachers.RoleID = Roles.RoleID where Teachers.RoleID = 2 and CourseName like '%'+@search+'%'";
                TeacherSearch(search);
                TxtTeacherSearch.Clear();
            }
        }

        private void BtnTeacherSearchClear_Click(object sender, EventArgs e)
        {
            TxtTeacherSearch.Clear();
        }
        private void TxtTeacherPassword_MouseDown(object sender, MouseEventArgs e)
        {
            TxtTeacherPassword.UseSystemPasswordChar = false;
        }

        private void TxtTeacherPassword_MouseUp(object sender, MouseEventArgs e)
        {
            TxtTeacherPassword.UseSystemPasswordChar = true;
        }
        //---------------------------ÖĞRETMEN BİTİŞ----------------------------------------------------------
        //---------------------------ÖĞRENCİ BAŞLANGIÇ--------------------------------------------------------  
        private void BtnStudentSearchList_Click(object sender, EventArgs e)
        {
            string search;

            if (string.IsNullOrEmpty(TxtStudentSearch.Text))
            {
                StudentList();
            }
            else if (CmbxStudentSearch.SelectedItem == "AD SOYAD")
            {
                search = "select Students.StudentID AS[ID], StudentNameSurname AS[ADI SOYADI], StudentTcNo AS[TC NO], StudentNo AS[ÖĞRENCİ NO], StudentMail AS[MAİL], StudentPassword AS[ŞİFRE], StudentNumber AS[TELEFON NO], StudentBirthday AS[DOĞUM TARİHİ], DepartmentName AS[BÖLÜM], RoleName AS[ROL], StudentImage AS[FOTOĞRAF] from Students FULL JOIN Departments on Students.DepartmentID = Departments.DepartmentID FULL JOIN Roles on Students.RoleID = Roles.RoleID where Students.RoleID = 3 and StudentNameSurname like '%'+@search+'%'";
                StudentSearch(search);
                TxtStudentSearch.Clear();
            }
            else if (CmbxStudentSearch.SelectedItem == "ÖĞRENCİ NO")
            {
                search = "select Students.StudentID AS[ID], StudentNameSurname AS[ADI SOYADI], StudentTcNo AS[TC NO], StudentNo AS[ÖĞRENCİ NO], StudentMail AS[MAİL], StudentPassword AS[ŞİFRE], StudentNumber AS[TELEFON NO], StudentBirthday AS[DOĞUM TARİHİ], DepartmentName AS[BÖLÜM], RoleName AS[ROL], StudentImage AS[FOTOĞRAF] from Students FULL JOIN Departments on Students.DepartmentID = Departments.DepartmentID FULL JOIN Roles on Students.RoleID = Roles.RoleID where Students.RoleID = 3 and StudentNo like '%'+@search+'%'";
                StudentSearch(search);
                TxtStudentSearch.Clear();
            }
            else if (CmbxStudentSearch.SelectedItem == "BÖLÜM")
            {
                search = "select Students.StudentID AS[ID], StudentNameSurname AS[ADI SOYADI], StudentTcNo AS[TC NO], StudentNo AS[ÖĞRENCİ NO], StudentMail AS[MAİL], StudentPassword AS[ŞİFRE], StudentNumber AS[TELEFON NO], StudentBirthday AS[DOĞUM TARİHİ], DepartmentName AS[BÖLÜM], RoleName AS[ROL], StudentImage AS[FOTOĞRAF] from Students FULL JOIN Departments on Students.DepartmentID = Departments.DepartmentID FULL JOIN Roles on Students.RoleID = Roles.RoleID where Students.RoleID = 3 and DepartmentName like '%'+@search+'%'";
                StudentSearch(search);
                TxtStudentSearch.Clear();
            }
        }

        private void BtnStudentSearchClear_Click(object sender, EventArgs e)
        {
            TxtStudentSearch.Clear();
        }

        private void DtgvStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DtgvStudentList.CurrentRow;
            TxtStudentNameSurname.Tag = row.Cells["ID"].Value.ToString();
            TxtStudentNameSurname.Text = row.Cells["ADI SOYADI"].Value.ToString();
            TxtStudentTcNo.Text = row.Cells["TC NO"].Value.ToString();
            TxtStudentMail.Text = row.Cells["MAİL"].Value.ToString();
            TxtStudentPassword.Text = row.Cells["ŞİFRE"].Value.ToString();
            MTxtStudentNumber.Text = row.Cells["TELEFON NO"].Value.ToString();
            DtpStudentBirhtday.Text = row.Cells["DOĞUM TARİHİ"].Value.ToString();
            CmbxStudentDeparment.Text = row.Cells["BÖLÜM"].Value.ToString();
            TxtStudentNo.Text = row.Cells["ÖĞRENCİ NO"].Value.ToString();
            TxtStudentNo.Tag = row.Cells["ROL"].Value.ToString();
            TxtStudentImage.Text = row.Cells["FOTOĞRAF"].Value.ToString();
            PcbxStudentImage.ImageLocation = row.Cells["FOTOĞRAF"].Value.ToString();

            int _setStudentID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            string _setStudentName = row.Cells["ADI SOYADI"].Value.ToString();
            string _setDepartmentName = row.Cells["BÖLÜM"].Value.ToString();

            if (e.ColumnIndex == 0)
            {
                CourseSelection courseSelection = new CourseSelection();
                courseSelection._getStudentID = _setStudentID;
                courseSelection._getStudentName = _setStudentName;
                courseSelection._getDepartmentName = _setDepartmentName;
                courseSelection.Show();
            }
        }

        private void BtnStudentAdd_Click(object sender, EventArgs e)
        {
            if (CkbxStudentApprove.Checked)
            {
                try
                {
                    _connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Students(StudentNameSurname, StudentMail, StudentPassword, StudentNo, StudentTcNo, StudentNumber, StudentBirthday, StudentImage, DepartmentID, RoleID) values(@StudentNameSurname, @StudentMail, @StudentPassword, @StudentNo, @StudentTcNo, @StudentNumber, @StudentBirthday, @StudentImage, @DepartmentID, @RoleID)", _connection);
                    cmd.Parameters.AddWithValue("@StudentNameSurname", TxtStudentNameSurname.Text);
                    cmd.Parameters.AddWithValue("@StudentMail", TxtStudentMail.Text);
                    cmd.Parameters.AddWithValue("@StudentPassword", TxtStudentPassword.Text);
                    cmd.Parameters.AddWithValue("@StudentNo", TxtStudentNo.Text);
                    cmd.Parameters.AddWithValue("@StudentTcNo", TxtStudentTcNo.Text);
                    cmd.Parameters.AddWithValue("@StudentNumber", MTxtStudentNumber.Text);
                    cmd.Parameters.AddWithValue("@StudentBirthday", Convert.ToDateTime(DtpStudentBirhtday.Text));
                    cmd.Parameters.AddWithValue("@StudentImage", TxtStudentImage.Text);
                    cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(CmbxStudentDeparment.SelectedValue));
                    cmd.Parameters.AddWithValue("@RoleID", 3);
                    cmd.ExecuteNonQuery();
                    StudentClear();
                }
                catch (Exception)
                {

                    MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                _connection.Close();
                StudentList();
                CkbxStudentApprove.Checked = false;
            }
            else
            {
                MessageBox.Show("Lütfen Yaptığınız Değişiklikleri Onaylayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnStudentUpdate_Click(object sender, EventArgs e)
        {
            if (CkbxStudentApprove.Checked)
            {
                try
                {
                    _connection.Open();
                    SqlCommand cmd = new SqlCommand("Update Students set StudentNameSurname = @StudentNameSurname, StudentMail = @StudentMail, StudentPassword = @StudentPassword, StudentNo = @StudentNo, StudentTcNo = @StudentTcNo, StudentNumber = @StudentNumber, StudentBirthday = @StudentBirthday, StudentImage = @StudentImage, DepartmentID = @DepartmentID, RoleID = @RoleID where StudentID = @StudentID", _connection);
                    cmd.Parameters.AddWithValue("@StudentID", Convert.ToInt32(TxtStudentNameSurname.Tag));
                    cmd.Parameters.AddWithValue("@StudentNameSurname", TxtStudentNameSurname.Text);
                    cmd.Parameters.AddWithValue("@StudentMail", TxtStudentMail.Text);
                    cmd.Parameters.AddWithValue("@StudentPassword", TxtStudentPassword.Text);
                    cmd.Parameters.AddWithValue("@StudentNo", TxtStudentNo.Text);
                    cmd.Parameters.AddWithValue("@StudentTcNo", TxtStudentTcNo.Text);
                    cmd.Parameters.AddWithValue("@StudentNumber", MTxtStudentNumber.Text);
                    cmd.Parameters.AddWithValue("@StudentBirthday", Convert.ToDateTime(DtpStudentBirhtday.Text));
                    cmd.Parameters.AddWithValue("@StudentImage", TxtStudentImage.Text);
                    cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(CmbxStudentDeparment.SelectedValue));
                    cmd.Parameters.AddWithValue("@RoleID", 3);
                    cmd.ExecuteNonQuery();
                    StudentClear();
                }
                catch (Exception ex)
                {
                    //"Eksik Bilgi Girdiniz!"
                    MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                _connection.Close();
                StudentList();
                CkbxStudentApprove.Checked = false;

            }
            else
            {
                MessageBox.Show("Lütfen Yaptığınız Değişiklikleri Onaylayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnStudentDelete_Click(object sender, EventArgs e)
        {
            if (CkbxStudentApprove.Checked)
            {
                try
                {
                    _connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Students where StudentID = @StudentID", _connection);
                    cmd.Parameters.AddWithValue("@StudentID", Convert.ToInt32(TxtStudentNameSurname.Tag));
                    cmd.ExecuteNonQuery();
                    StudentClear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen Silinecek Kişiyi Seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                _connection.Close();
                StudentList();
                CkbxStudentApprove.Checked = false;
            }
            else
            {
                MessageBox.Show("Lütfen Yaptığınız Değişiklikleri Onaylayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnStudentClear_Click(object sender, EventArgs e)
        {
            StudentClear();
        }
        private void BtnStudentImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            PcbxStudentImage.ImageLocation = openFileDialog1.FileName;
            TxtStudentImage.Text = openFileDialog1.FileName;
        }
        private void TxtStudentPassword_MouseDown(object sender, MouseEventArgs e)
        {
            TxtStudentPassword.UseSystemPasswordChar = false;
        }

        private void TxtStudentPassword_MouseUp(object sender, MouseEventArgs e)
        {
            TxtStudentPassword.UseSystemPasswordChar = true;
        }
        //-----------------------ÖĞRENCİ BİTİŞ---------------------------------------------------------------
        //-----------------------BÖLÜM VE DERSLER BAŞLANGIÇ--------------------------------------------------
        private void DtgvDepartmentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DtgvDepartmentList.CurrentRow;
            TxtDepartmentAdd.Tag = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            TxtDepartmentAdd.Text = row.Cells["BÖLÜM"].Value.ToString();
        }
        private void BtnDepartmentAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Departments(DepartmentName) values(@DepartmentName)", _connection);
                cmd.Parameters.AddWithValue("@DepartmentName", TxtDepartmentAdd.Text);
                cmd.ExecuteNonQuery();
                TxtDepartmentAdd.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            DepartmentList();

        }
        private void BtnDepartmentUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("Update Departments set DepartmentName = @DepartmentName where DepartmentID = @DepartmentID", _connection);
                cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(TxtDepartmentAdd.Tag));
                cmd.Parameters.AddWithValue("@DepartmentName", TxtDepartmentAdd.Text);
                cmd.ExecuteNonQuery();
                TxtDepartmentAdd.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            DepartmentList();

        }
        private void BtnDepartmentAddList_Click(object sender, EventArgs e)
        {
            DepartmentList();
        }
        private void BtnDepartmentClear_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("Delete from Departments where DepartmentID = @departmentID", _connection);
                cmd.Parameters.AddWithValue("@departmentID", TxtDepartmentAdd.Tag);
                cmd.ExecuteNonQuery();
                TxtDepartmentAdd.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Silinecek Bölümü Seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            DepartmentList();

        }
        private void DtgvCourseList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DtgvCourseList.CurrentRow;
            TxtCourseAdd.Tag = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            TxtCourseAdd.Text = row.Cells["DERS"].Value.ToString();
        }
        private void BtnCourseAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Courses(CourseName) values(@CourseName)", _connection);
                cmd.Parameters.AddWithValue("@CourseName", TxtCourseAdd.Text);
                cmd.ExecuteNonQuery();
                TxtCourseAdd.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            CourseList();

        }
        private void BtnCourseUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("Update Courses set CourseName = @CourseName where CourseID = @CourseID", _connection);
                cmd.Parameters.AddWithValue("@CourseID", Convert.ToInt32(TxtCourseAdd.Tag));
                cmd.Parameters.AddWithValue("@CourseName", TxtCourseAdd.Text);
                cmd.ExecuteNonQuery();
                TxtCourseAdd.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            CourseList();

        }
        private void BtnCourseAddList_Click(object sender, EventArgs e)
        {
            CourseList();
        }
        private void BtnCourseClear_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("Delete from Courses where CourseID = @courseID", _connection);
                cmd.Parameters.AddWithValue("@courseID", TxtCourseAdd.Tag);
                cmd.ExecuteNonQuery();
                TxtCourseAdd.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Silinecek Dersi Seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            CourseList();
        }
        private void DtgvDepartmentCourseList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DtgvDepartmentCourseList.CurrentRow;
            try
            {
                CmbxDepartmentCourseDepartment.Tag = Convert.ToInt32(row.Cells["ID"].Value.ToString());

                _connection.Open();
                SqlCommand cmd = new SqlCommand("select * from DepartmentCourse where DepartmentCourseID = @selectedID", _connection);
                cmd.Parameters.AddWithValue("@selectedID", CmbxDepartmentCourseDepartment.Tag);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                CmbxDepartmentCourseDepartment.SelectedValue = Convert.ToInt32(reader["DepartmentID"].ToString());
                CmbxDepartmentCourseCourse.SelectedValue = Convert.ToInt32(reader["CourseID"].ToString());
                if (!(string.IsNullOrEmpty(reader["TeacherID"].ToString())))
                {
                    CmbxDepartmentCourseTeacher.SelectedValue = Convert.ToInt32(reader["TeacherID"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            _connection.Close();
        }
        private void BtnDepartmentCourseAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("insert into DepartmentCourse(DepartmentID,CourseID,TeacherID) values(@departmentID,@courseID,@teacherID)", _connection);
                cmd.Parameters.AddWithValue("@departmentID", CmbxDepartmentCourseDepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@courseID", CmbxDepartmentCourseCourse.SelectedValue);
                cmd.Parameters.AddWithValue("@teacherID", CmbxDepartmentCourseTeacher.SelectedValue);
                cmd.ExecuteNonQuery();
                CmbxDepartmentCourseDepartment.Text = string.Empty;
                CmbxDepartmentCourseCourse.Text = string.Empty;
                CmbxDepartmentCourseTeacher.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            DepartmentCourseList();

        }
        private void BtnDepartmentCourseUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("Update DepartmentCourse set DepartmentID = @departmentID, CourseID = @courseID, TeacherID = @teacherID where DepartmentCourseID = @departmentCourseID", _connection);
                cmd.Parameters.AddWithValue("@departmentCourseID", Convert.ToInt32(CmbxDepartmentCourseDepartment.Tag));
                cmd.Parameters.AddWithValue("@departmentID", CmbxDepartmentCourseDepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@courseID", CmbxDepartmentCourseCourse.SelectedValue);
                cmd.Parameters.AddWithValue("@teacherID", CmbxDepartmentCourseTeacher.SelectedValue);
                cmd.ExecuteNonQuery();
                CmbxDepartmentCourseDepartment.Text = string.Empty;
                CmbxDepartmentCourseCourse.Text = string.Empty;
                CmbxDepartmentCourseTeacher.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            DepartmentCourseList();
        }
        private void BtnDepartmentCourseDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("Delete from DepartmentCourse where DepartmentCourseID = @departmentCourseID", _connection);
                cmd.Parameters.AddWithValue("@departmentCourseID", Convert.ToInt32(CmbxDepartmentCourseDepartment.Tag));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Silinecek Ögeyi Seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            DepartmentCourseList();
        }
        private void CmbxDepartmentCourseCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbxDepartmentCourseDepartment.SelectedIndex != -1 && CmbxDepartmentCourseCourse.SelectedIndex != -1)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from Teachers where DepartmentID = @DepartmentID and CourseID = @CourseID", _connection);
                    cmd.Parameters.AddWithValue("@DepartmentID", CmbxDepartmentCourseDepartment.SelectedValue);
                    cmd.Parameters.AddWithValue("@CourseID", CmbxDepartmentCourseCourse.SelectedValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    CmbxDepartmentCourseTeacher.DataSource = dt;
                    CmbxDepartmentCourseTeacher.DisplayMember = "TeacherNameSurname";
                    CmbxDepartmentCourseTeacher.ValueMember = "TeacherID";
                }
                catch (Exception)
                {
                }
            }
        }
        private void BtnDepartmentCourseSearchList_Click(object sender, EventArgs e)
        {
            string search;

            if (string.IsNullOrEmpty(TxtDepartmentCourseSearch.Text))
            {
                DepartmentCourseList();
            }
            else if (CmbxDepartmentCourseSearch.SelectedItem == "BÖLÜM")
            {
                search = "select DepartmentCourse.DepartmentCourseID AS [ID], DepartmentName As [BÖLÜM] , CourseName as [DERS], TeacherNameSurname as [ÖGRETMEN] from DepartmentCourse FULL JOIN Departments on DepartmentCourse.DepartmentID = Departments.DepartmentID FULL JOIN Courses on DepartmentCourse.CourseID = Courses.CourseID FULL JOIN Teachers on DepartmentCourse.TeacherID = Teachers.TeacherID where DepartmentName like '%'+@search+'%'";
                DepartmentCourseSearch(search);
                TxtDepartmentCourseSearch.Clear();
            }
            else if (CmbxDepartmentCourseSearch.SelectedItem == "DERS")
            {
                search = "select DepartmentCourse.DepartmentCourseID AS [ID], DepartmentName As [BÖLÜM] , CourseName as [DERS], TeacherNameSurname as [ÖGRETMEN] from DepartmentCourse FULL JOIN Departments on DepartmentCourse.DepartmentID = Departments.DepartmentID FULL JOIN Courses on DepartmentCourse.CourseID = Courses.CourseID FULL JOIN Teachers on DepartmentCourse.TeacherID = Teachers.TeacherID where CourseName like '%'+@search+'%'";
                DepartmentCourseSearch(search);
                TxtDepartmentCourseSearch.Clear();
            }
            else if (CmbxDepartmentCourseSearch.SelectedItem == "ÖĞRETMEN")
            {
                search = "select DepartmentCourse.DepartmentCourseID AS [ID], DepartmentName As [BÖLÜM] , CourseName as [DERS], TeacherNameSurname as [ÖGRETMEN] from DepartmentCourse FULL JOIN Departments on DepartmentCourse.DepartmentID = Departments.DepartmentID FULL JOIN Courses on DepartmentCourse.CourseID = Courses.CourseID FULL JOIN Teachers on DepartmentCourse.TeacherID = Teachers.TeacherID where TeacherNameSurname like '%'+@search+'%'";
                DepartmentCourseSearch(search);
                TxtDepartmentCourseSearch.Clear();
            }
            else if (CmbxDepartmentCourseSearch.SelectedItem == "BÖLÜM TABLOSU")
            {


                SqlCommand cmd = new SqlCommand("select DepartmentID AS [ID], DepartmentName AS [BÖLÜM] from Departments where DepartmentName like '%'+@search+'%'", _connection);
                cmd.Parameters.AddWithValue("@search", TxtDepartmentCourseSearch.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DtgvDepartmentList.DataSource = dt;
                TxtDepartmentCourseSearch.Clear();
            }
            else if (CmbxDepartmentCourseSearch.SelectedItem == "DERS TABLOSU")
            {
                SqlCommand cmd = new SqlCommand("select CourseID AS[ID], CourseName AS[DERS] from Courses where CourseName like '%'+@search+'%'", _connection);
                cmd.Parameters.AddWithValue("@search", TxtDepartmentCourseSearch.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DtgvCourseList.DataSource = dt;
                TxtDepartmentCourseSearch.Clear();
            }
        }
        //------------------------- BÖLÜM VE DERSLER BİTİŞ----------------------------------------------
        //-------------------------BİLGİ GÜNCELLEME BAŞLANGIÇ-------------------------------------------
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (CkbxUpdateApprove.Checked)
            {
                try
                {
                    _connection.Open();
                    SqlCommand cmd = new SqlCommand("Update Teachers set TeacherNameSurname = @TeacherNameSurname, TeacherMail = @TeacherMail, TeacherPassword = @TeacherPassword, TeacherTcNo = @TeacherTcNo, TeacherNumber = @TeacherNumber, TeacherBirthday = @TeacherBirthday, TeacherImage = @TeacherImage where TeacherID = @TeacherID", _connection);
                    cmd.Parameters.AddWithValue("@TeacherID", Convert.ToInt32(LblNameSurname.Tag));
                    cmd.Parameters.AddWithValue("@TeacherNameSurname", TxtUpdateNameSurname.Text);
                    cmd.Parameters.AddWithValue("@TeacherMail", TxtUpdateMail.Text);
                    cmd.Parameters.AddWithValue("@TeacherPassword", TxtUpdatePassword.Text);
                    cmd.Parameters.AddWithValue("@TeacherTcNo", TxtUpdateTcNo.Text);
                    cmd.Parameters.AddWithValue("@TeacherNumber", MTxtUpdateNumber.Text);
                    cmd.Parameters.AddWithValue("@TeacherBirthday", Convert.ToDateTime(DtpUpdateBirhtday.Text));
                    cmd.Parameters.AddWithValue("@TeacherImage", TxtUpdateImage.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
        private void TxtUpdatePassword_MouseDown(object sender, MouseEventArgs e)
        {
            TxtUpdatePassword.UseSystemPasswordChar = false;
        }

        private void TxtUpdatePassword_MouseUp(object sender, MouseEventArgs e)
        {
            TxtUpdatePassword.UseSystemPasswordChar = true;
        }

        //-------------------------BİLGİ GÜNCELLEME BİTİŞ----------------------------------------------
        //------------------------- BİLDİRİMLER BAŞLANGIÇ ----------------------------------------------
        private void DtgvNotifications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DtgvNotifications.CurrentRow;
            TxtNotificationTitle.Tag = row.Cells["ID"].Value.ToString();
            TxtNotificationTitle.Text = row.Cells["BAŞLIK"].Value.ToString();
            TxtNotificationContent.Tag = row.Cells["ROL"].Value.ToString();
            TxtNotificationContent.Text = row.Cells["İÇERİK"].Value.ToString();
        }

        private void BtnNotificationAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (RBtnNotificationTeacher.Checked)
                {
                    TxtNotificationContent.Tag = 2;
                }
                else if (RBtnTxtNotificationStudent.Checked)
                {
                    TxtNotificationContent.Tag = 3;
                }
                _connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Notifications(NotificationTitle,NotificationContent,RoleID) values(@NotificationTitle,@NotificationContent,@RoleID)", _connection);
                cmd.Parameters.AddWithValue("@NotificationTitle", TxtNotificationTitle.Text);
                cmd.Parameters.AddWithValue("@NotificationContent", TxtNotificationContent.Text);
                cmd.Parameters.AddWithValue("@RoleID", TxtNotificationContent.Tag);
                cmd.ExecuteNonQuery();
                _connection.Close();
                NotificationList();
                TxtNotificationTitle.Clear();
                TxtNotificationContent.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            NotificationList();
        }

        private void BtnNotificationUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (RBtnNotificationTeacher.Checked)
                {
                    TxtNotificationContent.Tag = 2;
                }
                else if (RBtnTxtNotificationStudent.Checked)
                {
                    TxtNotificationContent.Tag = 3;
                }
                _connection.Open();
                SqlCommand cmd = new SqlCommand("Update Notifications set NotificationTitle = @NotificationTitle,NotificationContent=@NotificationContent,RoleID=@RoleID where NotificationID = @NotificationID", _connection);
                cmd.Parameters.AddWithValue("@NotificationID", TxtNotificationTitle.Tag);
                cmd.Parameters.AddWithValue("@NotificationTitle", TxtNotificationTitle.Text);
                cmd.Parameters.AddWithValue("@NotificationContent", TxtNotificationContent.Text);
                cmd.Parameters.AddWithValue("@RoleID", TxtNotificationContent.Tag);
                cmd.ExecuteNonQuery();
                TxtNotificationTitle.Clear();
                TxtNotificationContent.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            NotificationList();

        }

        private void BtnNotificationDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("delete from Notifications where NotificationID = @NotificationID", _connection);
                cmd.Parameters.AddWithValue("@NotificationID", TxtNotificationTitle.Tag);
                cmd.ExecuteNonQuery();
                TxtNotificationTitle.Clear();
                TxtNotificationContent.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Silinecek Bildiriyi Seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _connection.Close();
            NotificationList();
        }

        private void BtnNotificationClear_Click(object sender, EventArgs e)
        {
            TxtNotificationTitle.Clear();
            TxtNotificationContent.Clear();
        }

        private void BtnNotificationSearchList_Click(object sender, EventArgs e)
        {
            string search;

            if (string.IsNullOrEmpty(TxtNotificationSearch.Text))
            {
                NotificationList();
            }
            else if (CmbxNotificationSearch.SelectedItem == "BAŞLIK")
            {
                search = "select Notifications.NotificationID AS [ID], NotificationTitle AS [BAŞLIK], NotificationContent AS [İÇERİK], RoleName AS [ROL] from Notifications INNER JOIN Roles on Notifications.RoleID = Roles.RoleID where NotificationTitle like '%'+@search+'%'";
                NotificationSearch(search);
                TxtNotificationSearch.Clear();
            }
            else if (CmbxNotificationSearch.SelectedItem == "İÇERİK")
            {
                search = "select Notifications.NotificationID AS [ID], NotificationTitle AS [BAŞLIK], NotificationContent AS [İÇERİK], RoleName AS [ROL] from Notifications INNER JOIN Roles on Notifications.RoleID = Roles.RoleID where NotificationContent like '%'+@search+'%'";
                NotificationSearch(search);
                TxtNotificationSearch.Clear();
            }
        }

        private void BtnNotificationSearchClear_Click(object sender, EventArgs e)
        {
            TxtNotificationSearch.Clear();
        }


        //------------------------- BİLDİRİMLER BİTİŞ ----------------------------------------------
    }
}
