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
    public partial class frmPardakhtCheck : Form
    {
        public frmPardakhtCheck()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int MoshtariID = -1;
        string referNo = "چک";
        string no = "";
        string vaziat = "";
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
            adp.SelectCommand.CommandText = "select * from tblCheck";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            TabdilID = (int)dt.Rows[cunt - 1]["CheckID"];
            return TabdilID;
        }
        void DisplayChecki()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblCheck] where MoshtariID=" + MoshtariID;
                adp.Fill(ds, "tblCheck");
                dgvPCheck.DataSource = ds;
                dgvPCheck.DataMember = "tblCheck";
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
                dgvPCheck.Columns["Discription"].Width = 500;
                dgvPCheck.Columns["Vaziat"].Visible = false;
                dgvPCheck.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        #endregion
        #region GettblCheck
        int GetBes()
        {
            int bes = 0;
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblHesab where MoshtariID=" + MoshtariID;
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                //**************************************************************
                for (int i = 0; i <= cunt - 1; i++)
                {
                    bes += (int)dt.Rows[i]["bes"];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات1 رخ داده است");
            }
            return bes;
        }
        int GetBed()
        {
            int bed = 0;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblHesab where MoshtariID=" + MoshtariID;
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                //**************************************************************
                for (int i = 0; i <= cunt - 1; i++)
                {
                    bed += (int)dt.Rows[i]["bed"];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات2 رخ داده است");
            }
            return bed;
        }
        void Mali()
        {
            int bed = GetBed();
            int bes = GetBes();
            int bedehkari = 0;
            int bestankari = 0;
            if (bed - bes > 0)
            {
                bedehkari = bed - bes;
                bestankari = 0;
            }
            else if (bed - bes < 0)
            {
                bestankari = (bed - bes) * -1;
                bedehkari = 0;
            }
            else
            {
                bestankari = 0;
                bedehkari = 0;
            }
            lblBedehkar.Text = bedehkari.ToString("N0");
            lblBestankar.Text = bestankari.ToString("N0");

        }
        #endregion
        #region Insert
        void InsertTotblHesabDaryaft(int id, int MoshtariId, int mablagh)
        {
            try
            {
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblHesab (MoshtariID,ReferNo,ReferID,Date,bes,bed,Tozihat)values(@MoshtariID,@ReferNo,@ReferID,@Date,@bes," + 0 + ",@Tozihat)";
                cmd.Parameters.AddWithValue("@MoshtariID", MoshtariId);
                cmd.Parameters.AddWithValue("@ReferNo", no);
                cmd.Parameters.AddWithValue("@Date", Date.Text);
                cmd.Parameters.AddWithValue("@Tozihat", txtPayCheckDiscription.Text);
                cmd.Parameters.AddWithValue("@bes", mablagh);
                cmd.Parameters.AddWithValue("@ReferID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("ثبت در حساب مشتری با موفقیت انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات جدول حساب رخ داده است.");
            }
        }
        void InsertTotblSandoghDaryaft(int id, int MoshtariId, int mablagh)
        {
            try
            {
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblSandogh (MoshtariID,ReferID,ReferNo,bes,bed)values(@MoshtariID,@ReferID,@ReferNo," + 0 + ",@bed)";
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
        /////////////////////////////////////////////////////////////////////////////////////////////
        void InsertTotblHesabPardakht(int id, int MoshtariId, int mablagh)
        {
            try
            {
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblHesab (MoshtariID,ReferNo,ReferID,Date,bed,bes,Tozihat)values(@MoshtariID,@ReferNo,@ReferID,@Date,@bed," + 0 + ",@Tozihat)";
                cmd.Parameters.AddWithValue("@MoshtariID", MoshtariId);
                cmd.Parameters.AddWithValue("@ReferNo", no);
                cmd.Parameters.AddWithValue("@Date", Date.Text);
                cmd.Parameters.AddWithValue("@Tozihat", txtPayCheckDiscription.Text);
                cmd.Parameters.AddWithValue("@bed", mablagh);
                cmd.Parameters.AddWithValue("@ReferID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("ثبت در حساب مشتری با موفقیت انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات جدول حساب رخ داده است.");
            }
        }
        void InsertTotblSandoghPardakht(int id, int MoshtariId, int mablagh)
        {
            try
            {
                con.Close();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "insert into tblSandogh (MoshtariID,ReferID,ReferNo,bed,bes)values(@MoshtariID,@ReferID,@ReferNo," + 0 + ",@bes)";
            cmd.Parameters.AddWithValue("@MoshtariID", MoshtariId);
            cmd.Parameters.AddWithValue("@ReferID", id);
            cmd.Parameters.AddWithValue("@ReferNo", no);
            cmd.Parameters.AddWithValue("@bes", mablagh);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات جدول صندوق رخ داده است.");
            }
        }
        #endregion
        #region Updates
        void UpdateTotblSandoghDaryaft(int mablagh)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblSandogh] Set bed='" + mablagh + "' where ReferID=" + referID + " AND ReferNo=N'دریافت چک'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات صندوق  رخ دارد!");
            }
        }
        void UpdateTotblHesabDaryaft(int mablagh)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblHesab] Set bes=N'" + mablagh + "' where ReferID=" + referID + "  AND ReferNo=N'دریافت چک'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات حساب  رخ دارد!");
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        void UpdateTotblSandoghPardakht(int mablagh)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblSandogh] Set bes='" + mablagh + "' where ReferID=" + referID + " AND ReferNo=N'پرداخت چک'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات صندوق  رخ دارد!");
            }
        }
        void UpdateTotblHesabPardakht(int mablagh)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblHesab] Set bed=N'" + mablagh + "' where ReferID=" + referID + "  AND ReferNo=N'پرداخت چک'";
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
        void DeletetblSandoghPardakht()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblSandogh] where ReferID=@n and ReferNo=N'پرداخت چک'";
                cmd.Parameters.AddWithValue("@n", referID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات صندوق رخ دارد!");
            }

        }
        void DeletetblHesabPardakht()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblHesab] where ReferID=@n and ReferNo=N'پرداخت چک'";
                cmd.Parameters.AddWithValue("@n", referID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات حساب رخ دارد!");
            }

        }
        //////////////////////////////////////////////////////////////////////////
        void DeletetblSandoghDaryaft()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblSandogh] where ReferID=@n and ReferNo=N'دریافت چک'";
                cmd.Parameters.AddWithValue("@n", referID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات صندوق رخ دارد!");
            }

        }
        void DeletetblHesabDaryaft()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblHesab] where ReferID=@n and ReferNo=N'دریافت چک'";
                cmd.Parameters.AddWithValue("@n", referID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات حساب رخ دارد!");
            }

        }
        #endregion
        private void frmCheck_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            dgvInSearch.Visible = false;
            Date.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            txtChekDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            lnBank.Visible = false;
            lnTarikh.Visible = false;
            lnShobe.Visible = false;
            lnMablaghCheck.Visible = false;
            lnDarvajh.Visible = false;
            lnShomareCheck.Visible = false;
            chkPardakht.Checked = true;
        }
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblMoshtari where Name Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", textBoxX1.Text + "%");
            adp.Fill(ds, "tblMoshtari");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblMoshtari";
            mt.Titr(dgvInSearch);
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
                DisplayChecki();
                Mali();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد. رخ داده است.");
            }
        }
        private void txtMablagh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMablagh.Text != string.Empty || txtMablagh.Text != "0")
                {
                    txtMablagh.Text = string.Format("{0:N0}", double.Parse(txtMablagh.Text.Replace(",", "")));
                    txtMablagh.Select(txtMablagh.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات مبلغ رخ داده است.");
            }
        }
        private void chkPardakht_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPardakht.Checked==true)
            {
                chkDaryaft.Checked = false;
            }
            no = "پرداخت چک";
            vaziat = "پرداختی";
        }
        private void chkDaryaft_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDaryaft.Checked == true)
            {
                chkPardakht.Checked = false;
            }
            no = "دریافت چک";
            vaziat = "دریافتی";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
                if (txtMablagh.Text == "")
                {
                    lnMablaghCheck.Visible = true;
                }
                if (txtNoBank.Text == "")
                {
                    lnBank.Visible = true;
                }
                if (txtDarVajh.Text == "")
                {
                    lnDarvajh.Visible = true;
                }
                if (txtShobe.Text == "")
                {
                    lnShobe.Visible = true;
                }
                if (txtShomareCheck.Text == "")
                {
                    lnShomareCheck.Visible = true;
                }
                if (txtChekDate.Text == "")
                {
                    lnTarikh.Visible = true;
                }
            if (txtMablagh.Text != "" && txtNoBank.Text != "" && txtDarVajh.Text != "" && txtShobe.Text != "" && txtShomareCheck.Text != "" && txtChekDate.Text != "" && lblName.Text != "")
            {
                try
                {
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblCheck] (NoBank,ChkDate,Mablagh,Shomare,Darvajh,FLName,ShomareHesab,Shobe,Date,No,Discription,Vaziat,MoshtariID)values(@NoBank,@ChkDate,@Mablagh,@Shomare,@Darvajh,@FLName,@ShomareHesab,@Shobe,@Date,@No,@Discription,@Vaziat,@MoshtariID)";
                    cmd.Parameters.AddWithValue("@NoBank", txtNoBank.Text);
                    cmd.Parameters.AddWithValue("@ChkDate", txtChekDate.Text);
                    cmd.Parameters.AddWithValue("@Mablagh", Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                    cmd.Parameters.AddWithValue("@Shomare", txtShomareCheck.Text);
                    cmd.Parameters.AddWithValue("@Darvajh", txtDarVajh.Text);
                    cmd.Parameters.AddWithValue("@FLName", txtName.Text);
                    cmd.Parameters.AddWithValue("@ShomareHesab", txtShomareHesab.Text);
                    cmd.Parameters.AddWithValue("@Shobe", txtShobe.Text);
                    cmd.Parameters.AddWithValue("@Date", Date.Text);
                    cmd.Parameters.AddWithValue("@No", no);
                    cmd.Parameters.AddWithValue("@Discription", txtPayCheckDiscription.Text);
                    cmd.Parameters.AddWithValue("@Vaziat", vaziat);
                    cmd.Parameters.AddWithValue("@MoshtariID", MoshtariID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //////////////////////////////////////////////////////////////////////////////////////////////
                    if (no == "دریافت چک")
                    {
                        referID = GetReferID();
                        InsertTotblHesabDaryaft(referID, MoshtariID, Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                        InsertTotblSandoghDaryaft(referID, MoshtariID, Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                    }
                    if (no == "پرداخت چک") 
                    {
                        referID = GetReferID();
                        InsertTotblHesabPardakht(referID, MoshtariID, Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                        InsertTotblSandoghPardakht(referID, MoshtariID, Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                        
                    }
                    //////////////////////////////////////////////////////////////////////////////////////////////
                    MessageBox.Show("ثبت پرداخت چکی با موفقیت انجام شد");
                    lnBank.Visible = false;
                    lnTarikh.Visible = false;
                    lnShobe.Visible = false;
                    lnMablaghCheck.Visible = false;
                    lnDarvajh.Visible = false;
                    lnShomareCheck.Visible = false;

                    txtNoBank.Text = "";
                    txtMablagh.Text = "0";
                    txtShobe.Text = "";
                    txtShomareCheck.Text = "";
                    txtShomareHesab.Text = "";
                    txtName.Text = "";
                    txtDarVajh.Text = "";
                    txtPayCheckDiscription.Text = "";
                    DisplayChecki();
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در ثبت پرداخت چکی وجود دارد");
                }
            }
            txtNoBank.Focus();
        }
        private void dgvPCheck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPCheck.Rows[e.RowIndex].Selected = true;
            try
            {
                referID = (int)dgvPCheck.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCheck where CheckID=" + referID;
                con.Open();
                adp.Fill(dt);
                this.txtNoBank.Text = dt.Rows[0]["NoBank"].ToString();
                this.txtChekDate.Text = dt.Rows[0]["ChkDate"].ToString();
                this.txtMablagh.Text = dt.Rows[0]["Mablagh"].ToString();
                this.txtShomareCheck.Text = dt.Rows[0]["Shomare"].ToString();
                this.txtDarVajh.Text = dt.Rows[0]["Darvajh"].ToString();
                this.txtName.Text = dt.Rows[0]["FLName"].ToString();
                this.txtShomareHesab.Text = dt.Rows[0]["ShomareHesab"].ToString();
                this.txtShobe.Text = dt.Rows[0]["Shobe"].ToString();
                this.Date.Text = dt.Rows[0]["Date"].ToString();
                this.txtPayCheckDiscription.Text = dt.Rows[0]["Discription"].ToString();
                no = dt.Rows[0]["No"].ToString();
                if (dt.Rows[0]["No"].ToString() == "پرداخت چک")
                {
                    chkPardakht.Checked = true;                   
                }
                if (dt.Rows[0]["No"].ToString() == "دریافت چک")
                {
                    chkDaryaft.Checked = true;
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب اطلاعات رخ داده است");
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (referID != -1)
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "Update [tblCheck] Set NoBank=N'" + txtNoBank.Text + "',ChkDate=N'" + txtChekDate.Text + "',Shomare=N'" + txtShomareCheck.Text + "',Mablagh=N'" + txtMablagh.Text.Replace(",", "") + "',Darvajh=N'" + txtDarVajh.Text + "',FLName=N'" + txtName.Text + "',ShomareHesab=N'" + txtShomareHesab.Text + "',Shobe=N'" + txtShobe.Text + "',Date=N'" + Date.Text + "',Discription=N'" + txtPayCheckDiscription.Text + "' where CheckID=" + referID;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //////////////////////////////////////////////////////////////////////////////////////////////////////
                        if (no == "پرداخت چک")
                        {
                            //referID = GetReferID();
                            UpdateTotblHesabPardakht(Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                            UpdateTotblSandoghPardakht(Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                        }
                        if (no == "دریافت چک")
                        {
                            //referID = GetReferID();
                            UpdateTotblHesabDaryaft(Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                            UpdateTotblSandoghDaryaft(Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                        }
                        //////////////////////////////////////////////////////////////////////////////////////////////////////
                        DisplayChecki();
                        MessageBox.Show("ویرایش اطلاعات انجام شد.");
                        txtNoBank.Text = "";
                        txtMablagh.Text = "0";
                        txtShobe.Text = "";
                        txtShomareCheck.Text = "";
                        txtShomareHesab.Text = "";
                        txtName.Text = "";
                        txtDarVajh.Text = "";
                        txtPayCheckDiscription.Text = "";
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (referID != -1)
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "delete from [tblCheck] where CheckID=" + referID;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //////////////////////////////////////////////////////////////////////////////////
                        if (no == "پرداخت چک")
                        {
                            DeletetblHesabPardakht();
                            DeletetblSandoghPardakht();
                        }
                        if (no == "دریافت چک")
                        {
                            DeletetblHesabDaryaft();
                            DeletetblSandoghDaryaft();
                        }
                        //////////////////////////////////////////////////////////////////////////////////
                        MessageBox.Show("حذف اطلاعات انجام شد.");
                        txtNoBank.Text = "";
                        txtMablagh.Text = "0";
                        txtShobe.Text = "";
                        txtShomareCheck.Text = "";
                        txtShomareHesab.Text = "";
                        txtName.Text = "";
                        txtDarVajh.Text = "";
                        txtPayCheckDiscription.Text = "";
                        DisplayChecki();
                        btnSave.Enabled = true;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد  مورد نظر کلیک کنید"); }
            }
        }
    }
}
