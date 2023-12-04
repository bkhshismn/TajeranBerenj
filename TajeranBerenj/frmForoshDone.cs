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
    public partial class frmForoshDone : Form
    {
        public frmForoshDone()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int MoshtariID = -1;
        string referNo = "فروش";
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
            adp.SelectCommand.CommandText = "select * from tblForoshDone ";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            TabdilID = (int)dt.Rows[cunt - 1]["ForoshDoneID"];
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
                adp.SelectCommand.CommandText = "select * from tblForoshDone where MoshtariID= " + MoshtariID;
                adp.Fill(ds, "tblForoshDone");
                dgvView.DataSource = ds;
                dgvView.DataMember = "tblForoshDone";
                //**************************************************************
                dgvView.Columns["ForoshDoneID"].HeaderText = "کد ";
                dgvView.Columns["ForoshDoneID"].Width = 45;
                dgvView.Columns["NoDone"].HeaderText = "نوع برنج ";
                dgvView.Columns["NoDone"].Width = 100;
                dgvView.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvView.Columns["AnbarName"].Width = 90;
                dgvView.Columns["Vazn"].HeaderText = "وزن برنج";
                dgvView.Columns["Vazn"].Width = 50;
                dgvView.Columns["Fee"].HeaderText = "فی";
                dgvView.Columns["Fee"].Width = 50;
                dgvView.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvView.Columns["Mablagh"].Width = 50;
                dgvView.Columns["Tedad"].HeaderText = "تعداد";
                dgvView.Columns["Tedad"].Width = 50;
                dgvView.Columns["Date"].HeaderText = "تاریخ ";
                dgvView.Columns["Date"].Width = 100;
                dgvView.Columns["Takhfif"].HeaderText = "تخفیف";
                dgvView.Columns["Takhfif"].Width = 50;
                dgvView.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvView.Columns["Tozihat"].Width = 300;

                dgvView.Columns["MoshtariID"].Visible = false;
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
            return (indone);
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
            return indone;// - GetInDoneJabJ(cmbBerenjNo.Text);
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
            return outdone ;
        }
        #endregion
        #region Inserts
        void InsertTotblAnbarDone(int id)
        {
            try
            {
                int vazn = 0;
                if (txtWDone.Text != "")
                {
                    vazn = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                }
                string no = "out";
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblAnbarDone (NoDone,Vazn,NoVorod ,ReferID,ReferNo,AnbarName)values(@NoDone,@Vazn,@NoVorod ,@ReferID,@ReferNo,@AnbarName)";
                cmd.Parameters.AddWithValue("@NoDone", cmbBerenjNo.Text);
                cmd.Parameters.AddWithValue("@AnbarName", cmbAnbar.Text);
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
        void InsertTotblHesab(int id, int MoshtariId, int mablagh)
        {
            try
            {
                string no = "فروش برنج";
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblHesab (MoshtariID,ReferNo,ReferID,Date,bed,bes,Tozihat)values(@MoshtariID,@ReferNo,@ReferID,@Date,@bed," + 0 + ",@Tozihat)";
                cmd.Parameters.AddWithValue("@MoshtariID", MoshtariId);
                cmd.Parameters.AddWithValue("@ReferNo", no);
                cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                cmd.Parameters.AddWithValue("@Tozihat", txtTozihat.Text);
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
        void InsertTotblSandogh(int id, int MoshtariId, int mablagh)
        {
            try
            {
                string no = "فروش برنج";
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
        void UpdateTotblAnbarDone()
        {
            string no = "فروش";
            try
            {
                int vazn = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblAnbarDone] Set NoDone=N'" + cmbBerenjNo.Text + "',AnbarName=N'" + cmbAnbar.Text + "', Vazn=N'" + vazn + "' where ReferNO=N'" + no + "' And ReferID=" + foroshID;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات انبار برنج رخ دارد!");
            }
        }
        void UpdateTotblSandogh(int mablagh)
        {
            try
            {
                int vazn = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblSandogh] Set bes='" + mablagh + "' where ReferID=" + foroshID + " AND ReferNo=N'فروش برنج'";
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
                int vazn = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblHesab] Set bed=N'" + mablagh + "' where ReferID=" + foroshID + "  AND ReferNo=N'فروش برنج'";
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
        void DeletetblanbarDone()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblAnbarDone] where ReferID=@n and ReferNo=N'فروش'";
                cmd.Parameters.AddWithValue("@n", foroshID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات انبار برنج رخ دارد!");
            }

        }
        void DeletetblSandogh()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblSandogh] where ReferID=@n and ReferNo=N'فروش برنج'";
                cmd.Parameters.AddWithValue("@n", foroshID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات صندوق رخ دارد!");
            }

        }
        void DeletetblHesab()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblHesab] where ReferID=@n and ReferNo=N'فروش برنج'";
                cmd.Parameters.AddWithValue("@n", foroshID);
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
        private void frmForoshDone_Load(object sender, EventArgs e)
        {
            txtTedadDone.Enabled = false;
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            dgvInSearch.Visible = false;
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");

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
                DisplayComboNoShali();
                cmbBerenjNo.Text = cmbBerenjNo.Items[0].ToString();
                DisplayComboAnbar();
                cmbAnbar.Text = cmbAnbar.Items[0].ToString();
                DisplayForoshDone();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد. رخ داده است.");
            }
            txtWDone.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if ( txtWDone.Text == "" || txtFeeDone.Text == "" )
            {
                MessageBox.Show(".لطفا فیلد های وزن و فی شده را پر کنید");

            }

            else
            {
                try
                {
                    int vaznDone = 0;
                    if (txtWDone.Text != "")
                    {
                        vaznDone = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                    }
                    int feeDone = 0;
                    if (txtFeeDone.Text != "")
                    {
                        feeDone = Convert.ToInt32(txtFeeDone.Text.Replace(",", ""));
                    }
                    int tedad = 0;
                    if (txtTedadDone.Text != "")
                    {
                        tedad = (Convert.ToInt32(txtWDone.Text.Replace(",", "")) / 70);
                    }
                    else
                    {
                        tedad = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                    }
                    int mablagh = 0;
                    mablagh = (Convert.ToInt32(txtWDone.Text.Replace(",", "")) * (Convert.ToInt32(txtFeeDone.Text.Replace(",", ""))));
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblForoshDone](Date,NoDone,AnbarName,Vazn,Fee,Mablagh,Tedad,Takhfif,Tozihat,MoshtariID)values(@Date,@NoDone,@AnbarName,@Vazn,@Fee,@Mablagh,@Tedad,@Takhfif,@Tozihat,@MoshtariID)";
                    cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                    cmd.Parameters.AddWithValue("@NoDone", cmbBerenjNo.Text);
                    cmd.Parameters.AddWithValue("@AnbarName", cmbAnbar.Text);
                    cmd.Parameters.AddWithValue("@Vazn", vaznDone);
                    cmd.Parameters.AddWithValue("@Tedad", tedad);
                    cmd.Parameters.AddWithValue("@Fee", feeDone);
                    cmd.Parameters.AddWithValue("@Mablagh", mablagh);
                    cmd.Parameters.AddWithValue("@Takhfif", (Convert.ToInt32(txtTakhfif.Text.Replace(",", ""))));
                    cmd.Parameters.AddWithValue("@MoshtariID", MoshtariID);
                    cmd.Parameters.AddWithValue("@Tozihat", txtTozihat.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    /////////////////////////////////////////////////////////////////////////////////////////////////////

                    referID = GetReferID();
                    InsertTotblAnbarDone(referID);
                    InsertTotblHesab(referID, MoshtariID, mablagh);
                    InsertTotblSandogh(referID, MoshtariID, mablagh);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////
                    DisplayForoshDone();
                    MessageBox.Show("ثبت با موفقیت انجام شد");
                    txtFeeDone.Text = "";
                    txtTakhfif.Text = "0";
                    txtWDone.Text = "";
                    txtTozihat.Text = "";
                    /////////////////////////////////////////////////////////////////////////////////////////////
                }
                catch
                {
                    MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
                }

            }
        }
        private void txtWDone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtWDone.Text != string.Empty)
                {
                    txtWDone.Text = string.Format("{0:N0}", double.Parse(txtWDone.Text.Replace(",", "")));
                    txtWDone.Select(txtWDone.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtFeeDone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFeeDone.Text != string.Empty)
                {
                    txtFeeDone.Text = string.Format("{0:N0}", double.Parse(txtFeeDone.Text.Replace(",", "")));
                    txtFeeDone.Select(txtFeeDone.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void cmbBerenjNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = GetInDone(cmbBerenjNo.Text);
            int outd = GetOutDone(cmbBerenjNo.Text);
            lblDoneKol.Text = ind.ToString("N0");
            lblDoneFrosh.Text = outd.ToString("N0");
            lblDoneMojod.Text=(ind-outd).ToString("N0");
        }
        private void cmbAnbar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = GetInDone(cmbBerenjNo.Text,cmbAnbar.Text);
            lblDoneKol.Text = ind.ToString("N0");
            int outd = GetOutDone(cmbBerenjNo.Text, cmbAnbar.Text);
            lblDoneFrosh.Text = outd.ToString("N0");
            lblDoneFrosh.Text = outd.ToString("N0");
            lblDoneMojod.Text = (ind - outd).ToString("N0");
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            txtFeeDone.Text = "";
            txtTakhfif.Text = "0";
            txtWDone.Text = "";
            txtTozihat.Text = "";
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtFeeDone.Text == "" && txtWDone.Text == "" && txtName.Text == "")
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
                        int fee = Convert.ToInt32(txtFeeDone.Text.Replace(",", ""));
                        int vazn = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                        int mablagh = fee * vazn;
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "update [tblForoshDone] Set NoDone=N'" + cmbBerenjNo.Text +
                            "', Tedad=N'" + Convert.ToDouble(txtTedadDone.Text) +
                            "', Vazn=N'" + vazn +
                            "',Fee=N'" + fee +
                            "',Mablagh=N'" + mablagh +
                            "',Date=N'" + txtDate.Text +
                            "',Tozihat=N'" + txtTozihat.Text +
                             "',AnbarName=N'" + cmbAnbar.Text +
                              "',Takhfif='" + txtTakhfif.Text.Replace(",", "") +
                            "' where ForoshDoneID=" + foroshID;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        UpdateTotblAnbarDone();
                        UpdateTotblSandogh(mablagh);
                        UpdateTotblHesab(mablagh);
                        MessageBox.Show("ویرایش اطلاعات انجام شد.");
                        cmd.Parameters.Clear();
                        txtTozihat.Text = "";
                        txtFeeDone.Text = "";
                        txtTakhfif.Text = "0";
                        txtWDone.Text = "";
                        txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
                        DisplayForoshDone();
                        foroshID = -1;
                        MoshtariID = -1;
                        referID = 1;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("مشکلی در ویرایش اطلاعات وجود دارد!");
                    }
                }
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
                adp.SelectCommand.CommandText = "select * from [tblForoshDone] where ForoshDoneID =" + foroshID;
                con.Open();
                adp.Fill(dt);
                this.cmbBerenjNo.Text = dt.Rows[0]["NoDone"].ToString();
                this.cmbAnbar.Text = dt.Rows[0]["AnbarName"].ToString();
                this.txtFeeDone.Text = dt.Rows[0]["Fee"].ToString();
                this.txtTedadDone.Text = dt.Rows[0]["Tedad"].ToString();
                this.txtWDone.Text = dt.Rows[0]["Vazn"].ToString();
                this.txtTozihat.Text = dt.Rows[0]["Tozihat"].ToString();
                this.txtDate.Text = dt.Rows[0]["Date"].ToString();
                this.txtTakhfif.Text = dt.Rows[0]["Takhfif"].ToString();
                MoshtariID = (int)dt.Rows[0]["MoshtariID"];
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است");
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
                    cmd.CommandText = "Delete from [tblForoshDone] where ForoshDoneID=@n";
                    cmd.Parameters.AddWithValue("@n", foroshID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    /////////////////////////////////////////////////////////////////
                    DeletetblanbarDone();
                    DeletetblHesab();
                    DeletetblSandogh();
                    ////////////////////////////////////////////////////////////////
                    MessageBox.Show("عملیات حذف با موفقیت انجام شد.");
                    txtTozihat.Text = "";
                    txtFeeDone.Text = "";
                    txtTakhfif.Text = "0";
                    txtWDone.Text = "";
                    foroshID = -1;
                    DisplayForoshDone();
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در حذف اطلاعات فروش رخ دارد!");
                }
            }
        }
        private void txtTakhfif_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
