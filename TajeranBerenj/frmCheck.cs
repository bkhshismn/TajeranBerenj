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
    public partial class frmCheck : Form
    {
        public frmCheck()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        void DisplayChecki()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [View_Check]";
                adp.Fill(ds, "View_Check");
                dgvPCheck.DataSource = ds;
                dgvPCheck.DataMember = "View_Check";
                dgvPCheck.Columns["MoshtariID"].HeaderText = "کد مشتری";
                dgvPCheck.Columns["Name"].HeaderText = "نام مشتری";
                dgvPCheck.Columns["CheckID"].HeaderText = "کد";
                dgvPCheck.Columns["CheckID"].Width = 50;
                dgvPCheck.Columns["NoBank"].HeaderText = "نام بانک";
                dgvPCheck.Columns["ChkDate"].HeaderText = "تاریخ وصول";
                dgvPCheck.Columns["ChkDate"].Width = 70;
                dgvPCheck.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvPCheck.Columns["Shomare"].HeaderText = "شماره چک";
                dgvPCheck.Columns["Darvajh"].HeaderText = "در وجه";
                dgvPCheck.Columns["FLName"].HeaderText = "نام صاحب چک";
                dgvPCheck.Columns["ShomareHesab"].HeaderText = "شماره حساب";
                dgvPCheck.Columns["Shobe"].HeaderText = "شعبه";
                dgvPCheck.Columns["No"].HeaderText = "نوع انتقال ";
                dgvPCheck.Columns["Date"].HeaderText = "تاریخ ثبت چک";
                dgvPCheck.Columns["Date"].Width = 70;
                dgvPCheck.Columns["Discription"].HeaderText = "توضیحات";
                dgvPCheck.Columns["Discription"].Width = 200;
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        private void frmCheck_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            DisplayChecki();
        }
    }
}
