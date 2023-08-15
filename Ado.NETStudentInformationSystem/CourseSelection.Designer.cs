namespace Ado.NETStudentInformationSystem
{
    partial class CourseSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DtgvCourseSelection = new System.Windows.Forms.DataGridView();
            this.CourseS = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GrbxCourseSelection = new System.Windows.Forms.GroupBox();
            this.LblCourseSelection = new System.Windows.Forms.Label();
            this.LblStudentSelection = new System.Windows.Forms.Label();
            this.CkbxApprove = new System.Windows.Forms.CheckBox();
            this.BtnCourseSelectionList = new System.Windows.Forms.Button();
            this.BtnSelectionList = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.BtnCourseSelectionDelete = new System.Windows.Forms.Button();
            this.BtnCourseSelectionAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgvCourseSelection)).BeginInit();
            this.GrbxCourseSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgvCourseSelection
            // 
            this.DtgvCourseSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgvCourseSelection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseS});
            this.DtgvCourseSelection.Location = new System.Drawing.Point(12, 12);
            this.DtgvCourseSelection.Name = "DtgvCourseSelection";
            this.DtgvCourseSelection.RowHeadersWidth = 51;
            this.DtgvCourseSelection.RowTemplate.Height = 24;
            this.DtgvCourseSelection.Size = new System.Drawing.Size(676, 250);
            this.DtgvCourseSelection.TabIndex = 0;
            this.DtgvCourseSelection.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgvCourseSelection_CellClick);
            // 
            // CourseS
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.CourseS.DefaultCellStyle = dataGridViewCellStyle1;
            this.CourseS.HeaderText = "";
            this.CourseS.MinimumWidth = 6;
            this.CourseS.Name = "CourseS";
            this.CourseS.Text = "SEÇ";
            this.CourseS.UseColumnTextForButtonValue = true;
            this.CourseS.Width = 125;
            // 
            // GrbxCourseSelection
            // 
            this.GrbxCourseSelection.Controls.Add(this.LblCourseSelection);
            this.GrbxCourseSelection.Controls.Add(this.LblStudentSelection);
            this.GrbxCourseSelection.Controls.Add(this.CkbxApprove);
            this.GrbxCourseSelection.Controls.Add(this.BtnCourseSelectionList);
            this.GrbxCourseSelection.Controls.Add(this.BtnSelectionList);
            this.GrbxCourseSelection.Controls.Add(this.BtnBack);
            this.GrbxCourseSelection.Controls.Add(this.BtnCourseSelectionDelete);
            this.GrbxCourseSelection.Controls.Add(this.BtnCourseSelectionAdd);
            this.GrbxCourseSelection.Location = new System.Drawing.Point(12, 268);
            this.GrbxCourseSelection.Name = "GrbxCourseSelection";
            this.GrbxCourseSelection.Size = new System.Drawing.Size(676, 170);
            this.GrbxCourseSelection.TabIndex = 1;
            this.GrbxCourseSelection.TabStop = false;
            this.GrbxCourseSelection.Text = "DERS SEÇİMİ";
            // 
            // LblCourseSelection
            // 
            this.LblCourseSelection.AutoSize = true;
            this.LblCourseSelection.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCourseSelection.Location = new System.Drawing.Point(17, 73);
            this.LblCourseSelection.Name = "LblCourseSelection";
            this.LblCourseSelection.Size = new System.Drawing.Size(0, 19);
            this.LblCourseSelection.TabIndex = 2;
            // 
            // LblStudentSelection
            // 
            this.LblStudentSelection.AutoSize = true;
            this.LblStudentSelection.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblStudentSelection.Location = new System.Drawing.Point(17, 31);
            this.LblStudentSelection.Name = "LblStudentSelection";
            this.LblStudentSelection.Size = new System.Drawing.Size(0, 22);
            this.LblStudentSelection.TabIndex = 2;
            // 
            // CkbxApprove
            // 
            this.CkbxApprove.AutoSize = true;
            this.CkbxApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CkbxApprove.Location = new System.Drawing.Point(21, 128);
            this.CkbxApprove.Name = "CkbxApprove";
            this.CkbxApprove.Size = new System.Drawing.Size(114, 22);
            this.CkbxApprove.TabIndex = 1;
            this.CkbxApprove.Text = "Seçimi Onay";
            this.CkbxApprove.UseVisualStyleBackColor = true;
            // 
            // BtnCourseSelectionList
            // 
            this.BtnCourseSelectionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCourseSelectionList.Location = new System.Drawing.Point(466, 24);
            this.BtnCourseSelectionList.Name = "BtnCourseSelectionList";
            this.BtnCourseSelectionList.Size = new System.Drawing.Size(200, 35);
            this.BtnCourseSelectionList.TabIndex = 0;
            this.BtnCourseSelectionList.Text = "DERSLERİ LİSTELE";
            this.BtnCourseSelectionList.UseVisualStyleBackColor = true;
            this.BtnCourseSelectionList.Click += new System.EventHandler(this.BtnCourseSelectionList_Click);
            // 
            // BtnSelectionList
            // 
            this.BtnSelectionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSelectionList.Location = new System.Drawing.Point(466, 73);
            this.BtnSelectionList.Name = "BtnSelectionList";
            this.BtnSelectionList.Size = new System.Drawing.Size(200, 35);
            this.BtnSelectionList.TabIndex = 0;
            this.BtnSelectionList.Text = "SEÇİMİ LİSTELE";
            this.BtnSelectionList.UseVisualStyleBackColor = true;
            this.BtnSelectionList.Click += new System.EventHandler(this.BtnSelectionList_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBack.Location = new System.Drawing.Point(354, 128);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(100, 30);
            this.BtnBack.TabIndex = 0;
            this.BtnBack.Text = "İPTAL";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // BtnCourseSelectionDelete
            // 
            this.BtnCourseSelectionDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCourseSelectionDelete.Location = new System.Drawing.Point(460, 128);
            this.BtnCourseSelectionDelete.Name = "BtnCourseSelectionDelete";
            this.BtnCourseSelectionDelete.Size = new System.Drawing.Size(100, 30);
            this.BtnCourseSelectionDelete.TabIndex = 0;
            this.BtnCourseSelectionDelete.Text = "SİL";
            this.BtnCourseSelectionDelete.UseVisualStyleBackColor = true;
            this.BtnCourseSelectionDelete.Click += new System.EventHandler(this.BtnCourseSelectionDelete_Click);
            // 
            // BtnCourseSelectionAdd
            // 
            this.BtnCourseSelectionAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCourseSelectionAdd.Location = new System.Drawing.Point(566, 128);
            this.BtnCourseSelectionAdd.Name = "BtnCourseSelectionAdd";
            this.BtnCourseSelectionAdd.Size = new System.Drawing.Size(100, 30);
            this.BtnCourseSelectionAdd.TabIndex = 0;
            this.BtnCourseSelectionAdd.Text = "EKLE";
            this.BtnCourseSelectionAdd.UseVisualStyleBackColor = true;
            this.BtnCourseSelectionAdd.Click += new System.EventHandler(this.BtnCourseSelectionAdd_Click);
            // 
            // CourseSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.GrbxCourseSelection);
            this.Controls.Add(this.DtgvCourseSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CourseSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CourseSelection";
            this.Load += new System.EventHandler(this.CourseSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgvCourseSelection)).EndInit();
            this.GrbxCourseSelection.ResumeLayout(false);
            this.GrbxCourseSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgvCourseSelection;
        private System.Windows.Forms.GroupBox GrbxCourseSelection;
        private System.Windows.Forms.Button BtnCourseSelectionDelete;
        private System.Windows.Forms.Button BtnCourseSelectionAdd;
        private System.Windows.Forms.Label LblCourseSelection;
        private System.Windows.Forms.Label LblStudentSelection;
        private System.Windows.Forms.CheckBox CkbxApprove;
        private System.Windows.Forms.Button BtnCourseSelectionList;
        private System.Windows.Forms.Button BtnSelectionList;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.DataGridViewButtonColumn CourseS;
    }
}