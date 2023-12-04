using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TajeranBerenj
{
    public partial class frmMoshtari : Form
    {
        public frmMoshtari()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        int MoshtariID = -1;
        void DisplayMoshtari()
        {
            SqlDataAdapter adb = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adb.SelectCommand = new SqlCommand("select * from tblMoshtari", con);
            adb.Fill(ds,"tblMoshtari");
            dgvCstmr.DataSource = ds;
            dgvCstmr.DataMember = "tblMoshtari";
            dgvCstmr.Columns["MoshtariID"].HeaderText="کدمشتری";
            dgvCstmr.Columns["MoshtariID"].Width = 60;
            dgvCstmr.Columns["Name"].HeaderText = "نام";
            dgvCstmr.Columns["Name"].Width = 120;
            dgvCstmr.Columns["Tell"].HeaderText = "تلفن";
            dgvCstmr.Columns["Address"].HeaderText = "آدرس";
            dgvCstmr.Columns["Address"].Width = 200;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text !="")
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tblMoshtari(Name,Tell,Address)values(@Name,@Tell,@Address)";
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Tell", txtTel.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DisplayMoshtari();
                    MessageBox.Show("ثبت با موفقیت انجام شد");
                    txtName.Text = "";
                    txtAddress.Text = "";
                    txtTel.Text = "";
                }
                catch (Exception)
                {

                }
            }
            else
                MessageBox.Show("لطفا فیلد نام را خالی نگذارید");
        }

        private void frmMoshtari_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            DisplayMoshtari();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result==DialogResult.Yes)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "update tblMoshtari set Name=N'" + txtName.Text + "',Tell=N'" + txtTel.Text + "',Address=N'" + txtAddress.Text + "' where MoshtariID=" + MoshtariID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DisplayMoshtari();
                    MessageBox.Show("ویرایش اطلاعات انجام شد.");
                    txtName.Text = "";
                    txtAddress.Text = "";
                    txtTel.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                }
            }
        }

        private void dgvCstmr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCstmr.Rows[e.RowIndex].Selected = true;
            MoshtariID = (int)dgvCstmr.Rows[e.RowIndex].Cells["MoshtariID"].Value;
            cmd.Parameters.Clear();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand("select * from tblMoshtari where MoshtariID=" + MoshtariID, con);
            con.Open();
            adp.Fill(dt);
            con.Close();
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtTel.Text = dt.Rows[0]["Tell"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtTel.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result==DialogResult.Yes)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from tblMoshtari where MoshtariID=" + MoshtariID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("حذف اطلاعات انجام شد.");
                    MoshtariID = -1;
                    txtName.Text = "";
                    txtAddress.Text = "";
                    txtTel.Text = "";
                    DisplayMoshtari();
                }
                catch (Exception)
                {
                    MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                }
            }
        }
    }
}
