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

namespace TajeranBerenj
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        int sath = 0;
        void DisplayeUser()
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from [tblUser]";
            adp.Fill(ds, "tblUser");
            dgvUser.DataSource = ds;
            dgvUser.DataMember = "tblUser";
            dgvUser.DataSource = ds;
            dgvUser.DataMember = "tblUser";
            dgvUser.Columns["UserID"].HeaderText = "کد";
            dgvUser.Columns["UserID"].Width = 50;
            dgvUser.Columns["UserName"].HeaderText = "نام کاربری";
            dgvUser.Columns["Pass"].HeaderText = "کلمه عبور";
            dgvUser.Columns["Tell"].HeaderText = "شماره همراه";
            dgvUser.Columns["Sath"].HeaderText = "سطح دسترسی";
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            DisplayeUser();
            checkBoxX2.Checked = true;

        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked == true)
                sath = 1;
            if (txtName.Text == "" || txtPass.Text == "")
            {
                labelX4.Text = "فیلد های خالی را پر کنید...";

                if (txtName.Text == "")
                {
                    labelX5.Text = "*";
                }
                if (txtPass.Text == "")
                {
                    labelX6.Text = "*";
                }
            }
            else
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tblUser (UserName,Pass,Tell,Sath) values(@UserName,@Pass,@Tell,@Sath)";
                    cmd.Parameters.AddWithValue("@UserName", txtName.Text);
                    cmd.Parameters.AddWithValue("@Pass", txtPass.Text);
                    cmd.Parameters.AddWithValue("@Tell", txtTel.Text);
                    cmd.Parameters.AddWithValue("@Sath", txtTel.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DisplayeUser();
                    MessageBox.Show("ثبت با موفقیت انجام شد!");
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در ثبت اطلاعات وجود دارد!");
                }               
            }
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxX2.Checked = false;
        }

        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxX1.Checked = false;
        }

        private void checkBoxX1_Click(object sender, EventArgs e)
        {
            checkBoxX2.Checked = false;
        }

        private void checkBoxX2_Click(object sender, EventArgs e)
        {
            checkBoxX1.Checked = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
