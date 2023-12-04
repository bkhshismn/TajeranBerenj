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
    public partial class frmKarkhane : Form
    {
        public frmKarkhane()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        int id = -1;
        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adb = new SqlDataAdapter();
            adb.SelectCommand = new SqlCommand();
            adb.SelectCommand.Connection = con;
            adb.SelectCommand.CommandText = "select * from tblKarkhane";
            adb.Fill(ds, "tblKarkhane");

            dgvNo.DataSource = ds;
            dgvNo.DataMember = "tblKarkhane";
            dgvNo.Columns[0].HeaderText = "کد";
            dgvNo.Columns[0].Width = 30;
            dgvNo.Columns[1].HeaderText = "نام کارخانه ";
            dgvNo.Columns[1].Width = 200;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNo.Text != "")
            {
                try
                {
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tblKarkhane(Name)values(@a)";
                    cmd.Parameters.AddWithValue("@a", txtNo.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ثبت با موفقیت انجام شد");
                    Display();
                    txtNo.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در ثبت اطلاعات وجود دارد!");

                }
            }
        }

        private void frmKarkhane_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    //int x = Convert.ToInt32(dgvNo.SelectedCells[0].Value);
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from tblKarkhane where KarkhaneID=@n";
                    cmd.Parameters.AddWithValue("@n", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Display();
                    MessageBox.Show("عملیات حذف با موفقیت انجام شد.");
                    id = -1;
                    txtNo.Text = "";
                }
                catch (Exception)
                {

                    MessageBox.Show("مشکلی در حذف رخ داده است.");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    //int x = Convert.ToInt32(dgvNo.SelectedCells[0].Value);
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "update [tblKarkhane] Set Name=N'" + txtNo.Text +
                        "' where KarkhaneID=" + id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Display();
                    MessageBox.Show("عملیات ویرایش با موفقیت انجام شد.");
                    id = -1;
                    txtNo.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در حذف رخ داده است.");
                }
            }
        }

        private void dgvNo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                id = (int)dgvNo.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblKarkhane where KarkhaneID=" + id;
                con.Open();
                adp.Fill(dt);
                this.txtNo.Text = dt.Rows[0]["Name"].ToString();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
