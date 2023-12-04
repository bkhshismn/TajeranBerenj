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
    public partial class frmKharidShali : Form
    {
        public frmKharidShali()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int MoshtariID = -1;
        int KharidId = -1;
        int KharidShaliID()
        {
            int KharidShaliId = -1;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKharidShali ";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            KharidShaliId = (int)dt.Rows[cunt - 1]["KharidShaliID"];
            return KharidShaliId;
        }
        public void DisplayCombo()
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
            }
        }
        void DisplayKharidShali()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKharidShali where MoshtariID=" + MoshtariID;
            adp.Fill(ds, "tblKharidShali");
            dgvInput.DataSource = ds;
            dgvInput.DataMember = "tblKharidShali";
            //**************************************************************
            dgvInput.Columns["KharidShaliID"].HeaderText = "کد محصول";
            dgvInput.Columns["KharidShaliID"].Width = 45;
            dgvInput.Columns["MoshtariID"].Visible = false;
            dgvInput.Columns["MablaghKol"].HeaderText = "مبلغ ";
            dgvInput.Columns["MablaghKol"].Width = 100;
            dgvInput.Columns["Fee"].HeaderText = "فی ";
            dgvInput.Columns["Fee"].Width = 100;
            dgvInput.Columns["No"].HeaderText = "نوع شالی";
            dgvInput.Columns["No"].Width = 100;
            dgvInput.Columns["Tedad"].HeaderText = "تعداد کیسه شالی";
            dgvInput.Columns["Tedad"].Width = 50;
            dgvInput.Columns["Vazn"].HeaderText = "وزن";
            dgvInput.Columns["Vazn"].Width = 70;
            dgvInput.Columns["Date"].HeaderText = " تاریخ ورود";
            dgvInput.Columns["Date"].Width = 90;
            dgvInput.Columns["Tozihat"].HeaderText = " توضیحات";
            dgvInput.Columns["Tozihat"].Width = 300;
        }
        #region Inserts
        void InsertTotblAnbar(int id)
        {
            string referNo = "خرید";
            try
            {
                int vazn = Convert.ToInt32(txtVazn.Text.Replace(",", ""));
                string no = "in";
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblAnbarShali (NoShali,Vazn,NoVorod ,KharidShaliID,ReferNo)values(@NoShali,@Vazn,@NoVorod,@KharidShaliID,@ReferNo)";
                cmd.Parameters.AddWithValue("@NoShali", cmbBerenjNo.Text);
                cmd.Parameters.AddWithValue("@Vazn", vazn);
                cmd.Parameters.AddWithValue("@NoVorod", no);
                cmd.Parameters.AddWithValue("@KharidShaliID", id);
                cmd.Parameters.AddWithValue("@ReferNo", referNo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //    MessageBox.Show("ثبت در انبار با موفقیت انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات جدول انبار رخ داده است.");
            }
        }
        void InsertTotblSandogh(int id, int MoshtariId, int mablagh)
        {
            try
            {
                int vazn = Convert.ToInt32(txtVazn.Text.Replace(",", ""));
                string no = "خریدشالی";
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblSandogh (MoshtariID,ReferID,ReferNo,bed,bes)values(@MoshtariID,@ReferID,@ReferNo,@bed," + 0 + ")";
                cmd.Parameters.AddWithValue("@MoshtariID", MoshtariId);
                cmd.Parameters.AddWithValue("@ReferID", id);
                cmd.Parameters.AddWithValue("@ReferNo", no);
                cmd.Parameters.AddWithValue("@bed", mablagh);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات جدول صندوق رخ داده است.");
            }
        }
        void InsertTotblHesab(int id, int MoshtariId, int mablagh)
        {
            try
            {
                string no = "خریدشالی";
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblHesab (MoshtariID,ReferID,ReferNo,bed,bes,Date,Tozihat)values(@MoshtariID,@ReferID,@ReferNo," + 0 + ",@bes,@Date,@Tozihat)";
                cmd.Parameters.AddWithValue("@MoshtariID", MoshtariId);
                cmd.Parameters.AddWithValue("@ReferID", id);
                cmd.Parameters.AddWithValue("@ReferNo", no);
                cmd.Parameters.AddWithValue("@bes", mablagh);
                cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                cmd.Parameters.AddWithValue("@Tozihat", txtTozihat.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات جدول حساب رخ داده است.");
            }
        }
        #endregion
        #region Updates
        void UpdateTotblAnbar()
        {
            try
            {
                int vazn = Convert.ToInt32(txtVazn.Text.Replace(",", ""));
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblAnbarShali] Set NoShali=N'" + cmbBerenjNo.Text + "', Vazn=N'" + vazn + "' where KharidShaliID=" + KharidId;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات انبار شالی  رخ دارد!");
            }
        }
        void UpdateTotblSandogh(int mablagh)
        {
            try
            {
                int vazn = Convert.ToInt32(txtVazn.Text.Replace(",", ""));
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblSandogh] Set bed='" + mablagh + "' where ReferID=" + KharidId + " AND ReferNo=N'خریدشالی'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات صندوق  رخ دارد!");
            }
        }
        void UpdateTotblHesab(int mablagh)
        {
            try
            {
                int vazn = Convert.ToInt32(txtVazn.Text.Replace(",", ""));
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblHesab] Set bes=N'" + mablagh + "' where ReferID=" + KharidId + "  AND ReferNo=N'خریدشالی'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات حساب  رخ دارد!");
            }
        }
        #endregion
        #region Delete
        void DeletetblanbarShali()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblAnbarShali] where KharidShaliID=@n and NoVorod=N'in'";
                cmd.Parameters.AddWithValue("@n", KharidId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات انبار شالی رخ دارد!");
            }
          
        }
        void DeletetblSandogh()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblSandogh] where ReferID=@n and ReferNo=N'خریدشالی'";
                cmd.Parameters.AddWithValue("@n", KharidId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات صندوق  رخ دارد!");

            }
           
        }
        void DeletetblHesab()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblHesab] where ReferID=@n and ReferNo=N'خریدشالی'";
                cmd.Parameters.AddWithValue("@n", KharidId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات حساب  رخ دارد!");
            }
           
        }
        #endregion
        private void frmKharidShali_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            dgvInSearch.Visible = false;      
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            DisplayCombo();
            txtTedadShali.Enabled = false;


        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            new frmNoShali().ShowDialog();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblMoshtari where Name Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtName.Text + "%");
            adp.Fill(ds, "tblMoshtari");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblMoshtari";
            mt.Titr(dgvInSearch);
        }
        private void dgvInSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MoshtariID = (int)dgvInSearch.Rows[e.RowIndex].Cells["MoshtariID"].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblMoshtari where MoshtariID=" + MoshtariID;
                con.Open();
                adp.Fill(dt);
                this.lblName.Text = dt.Rows[0]["Name"].ToString();
                lblID.Text = dt.Rows[0]["MoshtariID"].ToString();
                txtName.Text = "";
                txtID.Text = "";
                txtName.WatermarkText = dt.Rows[0]["Name"].ToString();
                txtID.WatermarkText = dt.Rows[0]["MoshtariID"].ToString();
                con.Close();
                dgvInSearch.Visible = false;
                DisplayKharidShali();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است.");
            }
            cmbBerenjNo.Focus();
        }
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblMoshtari where MoshtariID Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtID.Text + "%");
            adp.Fill(ds, "tblMoshtari");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblMoshtari";
            mt.Titr(dgvInSearch);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            double tedad = 0;
           if (txtTedadShali.Text != "")
            {
                tedad = Convert.ToDouble(txtTedadShali.Text);
            }
            try
            {
                if (txtVazn.Text != "" && txtFee.Text != "" && lblName.Text != "")
                {
                    int fee = Convert.ToInt32(txtFee.Text.Replace(",", ""));
                    int vazn = Convert.ToInt32(txtVazn.Text.Replace(",", ""));
                    int mablagh = fee * vazn;
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tblKharidShali (No,MoshtariID,Tedad,Vazn,Fee,MablaghKol,Date,Tozihat)values(@No,@MoshtariID,@Tedad,@Vazn,@Fee,@MablaghKol,@Date,@Tozihat)";
                    cmd.Parameters.AddWithValue("@No", cmbBerenjNo.Text);
                    cmd.Parameters.AddWithValue("@Tedad",tedad );
                    cmd.Parameters.AddWithValue("@Vazn", vazn);
                    cmd.Parameters.AddWithValue("@MoshtariID", MoshtariID);
                    cmd.Parameters.AddWithValue("@Fee", fee);
                    cmd.Parameters.AddWithValue("@MablaghKol", mablagh);
                    cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                    cmd.Parameters.AddWithValue("@Tozihat", txtTozihat.Text);
                   
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DisplayKharidShali();
                    InsertTotblAnbar(KharidShaliID());
                    InsertTotblSandogh(KharidShaliID(), MoshtariID, mablagh);
                    InsertTotblHesab(KharidShaliID(), MoshtariID, mablagh);
                    MessageBox.Show("ثبت  با موفقیت انجام شد");
                }
                else
                {
                    MessageBox.Show("لطفا فیلد نام، وزن و فی را خالی نگذارید");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtFee.Text == "" && txtVazn.Text == "" && txtName.Text == "")
            {
                MessageBox.Show(".لطفا فیلد ها را خالی نگذارید");
            }
            else
            {
                var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int fee = Convert.ToInt32(txtFee.Text.Replace(",", ""));
                        int vazn = Convert.ToInt32(txtVazn.Text.Replace(",", ""));
                        int mablagh = fee * vazn;
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "update [tblKharidShali] Set No=N'" + cmbBerenjNo.Text +
                            "', Tedad=N'" + Convert.ToDouble(txtTedadShali.Text) +
                            "', Vazn=N'" + vazn +
                            "',Fee=N'" + fee +
                            "',MablaghKol=N'" + mablagh +
                            "',Date=N'" + txtDate.Text +
                            "',Tozihat='" + txtTozihat.Text +
                            "' where KharidShaliID=" + KharidId;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        UpdateTotblAnbar();
                        UpdateTotblSandogh(mablagh);
                        UpdateTotblHesab(mablagh);
                        MessageBox.Show("ویرایش اطلاعات انجام شد.");
                        cmd.Parameters.Clear();
                        txtTozihat.Text = "";
                        txtVazn.Text = "";
                        txtFee.Text = "";
                        txtTedadShali.Text = "";
                        txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
                        DisplayCombo();
                        DisplayKharidShali();
                        KharidId = -1;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("مشکلی در ویرایش اطلاعات وجود دارد!");
                    }
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                con.Close();
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from [tblKharidShali] where KharidShaliID=@n";
                    cmd.Parameters.AddWithValue("@n", KharidId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    /////////////////////////////////////////////////////////////////
                    DeletetblanbarShali();
                    DeletetblSandogh();
                    DeletetblHesab();
                    ////////////////////////////////////////////////////////////
                    KharidId = -1;
                    MessageBox.Show("عملیات حذف با موفقیت انجام شد.");
                    DisplayKharidShali();
                }
                catch (Exception)
                {

                    MessageBox.Show("مشکلی در حذف کاربر رخ داده است.");
                }
            }
        }
        private void txtFee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFee.Text != string.Empty)
                {
                    txtFee.Text = string.Format("{0:N0}", double.Parse(txtFee.Text.Replace(",", "")));
                    txtFee.Select(txtFee.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtVazn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVazn.Text != string.Empty)
                {
                    txtVazn.Text = string.Format("{0:N0}", double.Parse(txtVazn.Text.Replace(",", "")));
                    txtVazn.Select(txtVazn.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void dgvInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvInput.Rows[e.RowIndex].Selected = true;
            try
            {
                KharidId = (int)dgvInput.Rows[e.RowIndex].Cells["KharidShaliID"].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblKharidShali] where KharidShaliID =" + KharidId;
                con.Open();
                adp.Fill(dt);
                this.cmbBerenjNo.Text = dt.Rows[0]["No"].ToString();
                this.txtFee.Text = dt.Rows[0]["Fee"].ToString();
                this.txtTedadShali.Text = dt.Rows[0]["Tedad"].ToString();
                this.txtVazn.Text = dt.Rows[0]["Vazn"].ToString();
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
