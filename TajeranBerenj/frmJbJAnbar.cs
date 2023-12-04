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
    public partial class frmJbJAnbar : Form
    {
        public frmJbJAnbar()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int MoshtariID = -1;
        string referNo = "جابجایی";
        int foroshID = -1;
        int referID = -1;
        #region Display
        int GetReferID()
        {
            int TabdilID = -1;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblEnteghalDone ";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            TabdilID = (int)dt.Rows[cunt - 1]["EnteghalDoneID"];
            return TabdilID;
        }
        public void DisplayComboNoShali()
        {
            try
            {
                con.Close();
                string query = "SELECT  No FROM [tblBNo]";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                cmd.ExecuteScalar();
                con.Close();
                cmbBerenjNo.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbBerenjNo.Items.Add(dt.Rows[i]["No"]);
                    cmbNo.Items.Add(dt.Rows[i]["No"]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات نوع شالی رخ داده است");
            }
        }
        public void DisplayComboAnbar()
        {
            try
            {
                con.Close();
                string query = "SELECT  Name FROM [tblAnbarBerenjOnvan]";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                cmd.ExecuteScalar();
                con.Close();
                cmbAnbar.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbAnbar.Items.Add(dt.Rows[i]["Name"]);
                    cmbAnbar2.Items.Add(dt.Rows[i]["Name"]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات نام انبار رخ داده است");
            }

        }
        void DisplayForoshDone()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblEnteghalDone ";
                adp.Fill(ds, "tblEnteghalDone");
                dgvView.DataSource = ds;
                dgvView.DataMember = "tblEnteghalDone";
                //**************************************************************
                dgvView.Columns["EnteghalDoneID"].HeaderText = "کد ";
                dgvView.Columns["EnteghalDoneID"].Width = 45;
                dgvView.Columns["NoDone"].HeaderText = "نوع برنج ";
                dgvView.Columns["NoDone"].Width = 100;
                dgvView.Columns["AnbarName"].HeaderText = "نام مبدا";
                dgvView.Columns["AnbarName"].Width = 90;
                dgvView.Columns["AnbarName2"].HeaderText = " انبار مقصد";
                dgvView.Columns["AnbarName2"].Width = 90;
                dgvView.Columns["Vazn"].HeaderText = "وزن برنج";
                dgvView.Columns["Vazn"].Width = 50;
                dgvView.Columns["Date"].HeaderText = "تاریخ ";
                dgvView.Columns["Date"].Width = 100;
                dgvView.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvView.Columns["Tozihat"].Width = 300;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }

        }
        #endregion
        #region Gettbldone
        int GetInDone(string type)
        {
            int indone = 0;
            try
            {
                type = "'" + type + "'";
                string no = "'in'";
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarDone where NoDone=N" + type + "And NoVorod=" + no;
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                //**************************************************************
                for (int i = 0; i <= cunt - 1; i++)
                {
                    indone += (int)dt.Rows[i]["Vazn"];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }
            return (indone);// - GetInDoneJabJ(cmbBerenjNo.Text));
        }
        int GetInDone(string type, string anbar)
        {
            int indone = 0;
            try
            {
                type = "'" + type + "'";
                anbar = "'" + anbar + "'";
                string no = "'in'";
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarDone where NoDone=N" + type + "And AnbarName=N" + anbar + "And NoVorod=" + no;
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                //**************************************************************
                for (int i = 0; i <= cunt - 1; i++)
                {
                    indone += (int)dt.Rows[i]["Vazn"];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }
            return indone;
        }
        int GetOutDone(string type)
        {
            int outdone = 0;

            try
            {
                type = "'" + type + "'";
                string no = "'out'";
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarDone where NoDone=N" + type + "And NoVorod=" + no;
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                //**************************************************************
                for (int i = 0; i <= cunt - 1; i++)
                {
                    outdone += (int)dt.Rows[i]["Vazn"];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }
            return (outdone);// - GetOutJbJ(cmbBerenjNo.Text));
        }
        int GetOutDone(string type, string anbar)
        {
            int outdone = 0;

            try
            {
                type = "'" + type + "'";
                anbar = "'" + anbar + "'";
                string no = "'out'";
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarDone where NoDone=N" + type + "And AnbarName=N" + anbar + "And NoVorod=N" + no;
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                //**************************************************************
                for (int i = 0; i <= cunt - 1; i++)
                {
                    outdone += (int)dt.Rows[i]["Vazn"];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }
            return outdone;
        }
        #endregion
        void InsertTotblAnbarDone(int id)
        {
            try
            {
                int vazn = 0;
                if (txtWDone.Text != "")
                {
                    vazn = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                }
                string no = "in";
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblAnbarDone (NoDone,Vazn,NoVorod ,ReferID,ReferNo,AnbarName)values(@NoDone,@Vazn,@NoVorod ,@ReferID,@ReferNo,@AnbarName)";
                cmd.Parameters.AddWithValue("@NoDone", cmbBerenjNo.Text);
                cmd.Parameters.AddWithValue("@AnbarName", cmbAnbar.Text);
                cmd.Parameters.AddWithValue("@Vazn", vazn*-1);
                cmd.Parameters.AddWithValue("@NoVorod", no);
                cmd.Parameters.AddWithValue("@ReferID", id);
                cmd.Parameters.AddWithValue("@ReferNo", referNo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //    MessageBox.Show("ثبت در انبار با موفقیت انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات جدول برنج رخ داده است.");
            }
        }
        void InsertTotblAnbarDone2(int id)
        {
            try
            {
                int vazn = 0;
                if (txtWDone.Text != "")
                {
                    vazn = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                }
                string no = "in";
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblAnbarDone (NoDone,Vazn,NoVorod ,ReferID,ReferNo,AnbarName)values(@NoDone,@Vazn,@NoVorod ,@ReferID,@ReferNo,@AnbarName)";
                cmd.Parameters.AddWithValue("@NoDone", cmbBerenjNo.Text);
                cmd.Parameters.AddWithValue("@AnbarName", cmbAnbar2.Text);
                cmd.Parameters.AddWithValue("@Vazn", vazn);
                cmd.Parameters.AddWithValue("@NoVorod", no);
                cmd.Parameters.AddWithValue("@ReferID", id);
                cmd.Parameters.AddWithValue("@ReferNo", referNo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //    MessageBox.Show("ثبت در انبار با موفقیت انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات جدول برنج رخ داده است.");
            }
        }
        private void cmbBerenjNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = GetInDone(cmbBerenjNo.Text);
            int outd = GetOutDone(cmbBerenjNo.Text);
            lblDoneKol.Text = ind.ToString("N0");
            lblDoneFrosh.Text = outd.ToString("N0");
            lblDoneMojod.Text = (ind - outd).ToString("N0");
            cmbNo.Text = cmbBerenjNo.Text;

        }
        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void frmJbJAnbar_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            DisplayComboAnbar();
            DisplayComboNoShali();
            DisplayForoshDone();
            cmbNo.Enabled = false;
            txtVazn2.Enabled = false;
        }
        private void cmbAnbar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = GetInDone(cmbBerenjNo.Text, cmbAnbar.Text);
            lblDoneKol.Text = ind.ToString("N0");
            int outd = GetOutDone(cmbBerenjNo.Text, cmbAnbar.Text);
            lblDoneFrosh.Text = outd.ToString("N0");
            lblDoneFrosh.Text = outd.ToString("N0");
            lblDoneMojod.Text = (ind - outd).ToString("N0");
        }
        private void txtWDone_TextChanged(object sender, EventArgs e)
        {
            txtVazn2.Text = txtWDone.Text;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbAnbar2.Text != "" && cmbAnbar.Text != "" && cmbBerenjNo.Text != "" && txtWDone.Text != "")
            {
                try
                {
                    int vazn = 0;
                    if (txtWDone.Text != "")
                    {
                        vazn = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                    }
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tblEnteghalDone (NoDone,Vazn,AnbarName,AnbarName2,Date,Tozihat)values(@NoDone,@Vazn,@AnbarName,@AnbarName2,@Date,@Tozihat)";
                    cmd.Parameters.AddWithValue("@NoDone", cmbBerenjNo.Text);
                    cmd.Parameters.AddWithValue("@AnbarName", cmbAnbar.Text);
                    cmd.Parameters.AddWithValue("@AnbarName2", cmbAnbar2.Text);
                    cmd.Parameters.AddWithValue("@Vazn", vazn);
                    cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                    cmd.Parameters.AddWithValue("@Tozihat", txtTozihat.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    InsertTotblAnbarDone(GetReferID());
                    InsertTotblAnbarDone2(GetReferID());
                    DisplayForoshDone();
                    int ind = GetInDone(cmbBerenjNo.Text);
                    int outd = GetOutDone(cmbBerenjNo.Text);
                    lblDoneKol.Text = ind.ToString("N0");
                    lblDoneFrosh.Text = outd.ToString("N0");
                    lblDoneMojod.Text = (ind - outd).ToString("N0");
                    cmbNo.Text = cmbBerenjNo.Text;
                    MessageBox.Show("ثبت در انبار با موفقیت انجام شد");
                }
                catch (Exception)
                {
                    MessageBox.Show("خطایی در درج اطلاعات جدول برنج رخ داده است.");
                }
            }
            else
            {
                MessageBox.Show("لطفا نوع برنج و انبار و وزن را خالی نگذارید.");
            }
        }
        private void dgvView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvView.Rows[e.RowIndex].Selected = true;
            try
            {
                foroshID = (int)dgvView.Rows[e.RowIndex].Cells["ForoshDoneID"].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblEnteghalDone] where EnteghalDoneID =" + foroshID;
                con.Open();
                adp.Fill(dt);
                this.cmbBerenjNo.Text = dt.Rows[0]["NoDone"].ToString();
                this.cmbAnbar.Text = dt.Rows[0]["AnbarName"].ToString();
                this.txtWDone.Text = dt.Rows[0]["Vazn"].ToString();
                this.txtTozihat.Text = dt.Rows[0]["Tozihat"].ToString();
                this.txtDate.Text = dt.Rows[0]["Date"].ToString();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است");
            }
        }
    }
}

