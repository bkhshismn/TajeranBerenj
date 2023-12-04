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
    public partial class frmNoShali : Form
    {
        public frmNoShali()
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
            adb.SelectCommand.CommandText = "select * from tblBNo";
            adb.Fill(ds, "tblBNo");

            dgvNo.DataSource = ds;
            dgvNo.DataMember = "tblBNo";
            dgvNo.Columns[0].HeaderText = "کد";
            dgvNo.Columns[0].Width = 30;
            dgvNo.Columns[1].HeaderText = "نوع برنج ";
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
                    cmd.CommandText = "insert into tblBNo(No)values(@a)";
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
            else { MessageBox.Show("لطفا فیلد نوع شالی را خالی نگذارید"); }
        }

        private void frmNoShali_Load(object sender, EventArgs e)
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
                if (id != -1)
                {
                    try
                    {

                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "Delete from tblBNo where BNoID=@n";
                        cmd.Parameters.AddWithValue("@n", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Display();
                        id = -1;
                        MessageBox.Show("عملیات حذف با موفقیت انجام شد.");

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("مشکلی در حذف کاربر رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
            }
        }

        private void dgvNo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //id = (int)dgvNo.Rows[e.RowIndex].Cells[0].Value;
            try
            {
                id = (int)dgvNo.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblBNo where BNoID=" + id;
                con.Open();
                adp.Fill(dt);
                this.txtNo.Text = dt.Rows[0]["No"].ToString();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "update [tblBNo] Set No=N'" + txtNo.Text + "' where BNoID=" + id;
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
                    MessageBox.Show("مشکلی در ویرایش رخ داده است.");
                }
            }
        }
    }
}
