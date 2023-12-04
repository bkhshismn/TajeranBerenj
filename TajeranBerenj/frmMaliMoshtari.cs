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
    public partial class frmMaliMoshtari : Form
    {
        public frmMaliMoshtari()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int MoshtariID = -1;
        string referNo = "پول";
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
            adp.SelectCommand.CommandText = "select * from tblMaliMoshtari ";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            TabdilID = (int)dt.Rows[cunt - 1]["MaliMoshtariID"];
            return TabdilID;
        }
        void DisplayMali()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblMaliMoshtari where MoshtariID= " + MoshtariID;
                adp.Fill(ds, "tblMaliMoshtari");
                dgvView.DataSource = ds;
                dgvView.DataMember = "tblMaliMoshtari";
                //**************************************************************
                dgvView.Columns["MaliMoshtariID"].HeaderText = "کد ";
                dgvView.Columns["MaliMoshtariID"].Width = 45;
                dgvView.Columns["MablaghCart"].HeaderText = "کارت";
                dgvView.Columns["MablaghCart"].Width = 90;
                dgvView.Columns["MablaghNaghd"].HeaderText = "نقد";
                dgvView.Columns["MablaghNaghd"].Width = 90;
                dgvView.Columns["MablaghKol"].HeaderText = " مجموع";
                dgvView.Columns["MablaghKol"].Width = 100;
                dgvView.Columns["Date"].HeaderText = "تاریخ ";
                dgvView.Columns["No"].HeaderText = "نوع انتقال ";
                dgvView.Columns["Date"].Width = 100;
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
        #region GettblSabos
        int GetBes()
        {
            int bes = 0;
            //try
            //{
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
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("خطایی در نمایش اطلاعات1 رخ داده است");
            //}
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
                adp.SelectCommand.CommandText = "select * from tblHesab where MoshtariID=" + MoshtariID ;
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
        void  Mali()
        {
            int bed = GetBed();
            int bes = GetBes();
            int bedehkari = 0;
            int bestankari = 0;
            if (bed-bes>0)
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
                cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                cmd.Parameters.AddWithValue("@Tozihat", txtTozihat.Text);
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
        //--------------------------------------------------------------------------------------------------------------
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
                cmd.CommandText = "update [tblSandogh] Set bed='" + mablagh + "' where ReferID=" + foroshID + " AND ReferNo=N'دریافت پول'";
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
                cmd.CommandText = "update [tblHesab] Set bes=N'" + mablagh + "' where ReferID=" + foroshID + "  AND ReferNo=N'دریافت پول'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات حساب  رخ دارد!");
            }
        }
        //------------------------------------------------------------------------------
        void UpdateTotblSandoghPardakht(int mablagh)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblSandogh] Set bes='" + mablagh + "' where ReferID=" + foroshID + " AND ReferNo=N'پرداخت پول'";
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
                cmd.CommandText = "update [tblHesab] Set bed=N'" + mablagh + "' where ReferID=" + foroshID + "  AND ReferNo=N'پرداخت پول'";
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
        void DeletetblSandoghDaryaft()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblSandogh] where ReferID=@n and ReferNo=N'دریافت پول'";
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
        void DeletetblHesabDaryaft()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblHesab] where ReferID=@n and ReferNo=N'دریافت پول'";
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
        //-----------------------------------------------------------------
        void DeletetblSandoghPardakht()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblSandogh] where ReferID=@n and ReferNo=N'پرداخت پول'";
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
        void DeletetblHesabPardakht()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblHesab] where ReferID=@n and ReferNo=N'پرداخت پول'";
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
        private void frmMaliMoshtari_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            dgvInSearch.Visible = false;
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            chkDaryaft.Checked = true;
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
                DisplayMali();
                Mali();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد. رخ داده است.");
            }
            txtNaghd.Focus();
        }
        private void txtNaghd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNaghd.Text != string.Empty)
                {
                    txtNaghd.Text = string.Format("{0:N0}", double.Parse(txtNaghd.Text.Replace(",", "")));
                    txtNaghd.Select(txtNaghd.TextLength, 0);
                    lblKol.Text = (Convert.ToInt64(txtCart.Text.Replace(",", "")) + Convert.ToInt64(txtNaghd.Text.Replace(",", ""))).ToString("N0");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
          
        }
        private void txtCart_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCart.Text != string.Empty)
                {
                    txtCart.Text = string.Format("{0:N0}", double.Parse(txtCart.Text.Replace(",", "")));
                    txtCart.Select(txtCart.TextLength, 0);
                    lblKol.Text = (Convert.ToInt64(txtCart.Text.Replace(",", "")) + Convert.ToInt64(txtNaghd.Text.Replace(",", ""))).ToString("N0");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {          
            if (txtCart.Text == "" || txtNaghd.Text == "" || lblName.Text=="")
            {
                MessageBox.Show(".لطفا فیلد های نقد و کارت را پر کنید");

            }

            else
            {
                try
                {
                    int cart = Convert.ToInt32(txtCart.Text.Replace(",", ""));
                    int naghd = Convert.ToInt32(txtNaghd.Text.Replace(",", ""));
                    int mablaghkol = cart + naghd;
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tblMaliMoshtari (MoshtariID,MablaghCart,Date,MablaghNaghd,MablaghKol,Tozihat,No)values(@MoshtariID,@MablaghCart,@Date,@MablaghNaghd,@MablaghKol,@Tozihat,@No)";
                    cmd.Parameters.AddWithValue("@MoshtariID", MoshtariID);
                    cmd.Parameters.AddWithValue("@MablaghCart", cart);
                    cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                    cmd.Parameters.AddWithValue("@Tozihat", txtTozihat.Text);
                    cmd.Parameters.AddWithValue("@MablaghNaghd", naghd);
                    cmd.Parameters.AddWithValue("@MablaghKol", mablaghkol);
                    cmd.Parameters.AddWithValue("@No", no);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    /////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (chkPardakht.Checked==true)
                    {
                        referID = GetReferID();
                        InsertTotblHesabPardakht(referID, MoshtariID, mablaghkol);
                        InsertTotblSandoghPardakht(referID, MoshtariID, mablaghkol);
                    }
                    if (chkDaryaft.Checked == true)
                    {
                        referID = GetReferID();
                        InsertTotblHesabDaryaft(referID, MoshtariID, mablaghkol);
                        InsertTotblSandoghDaryaft(referID, MoshtariID, mablaghkol);
                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////////
                    Mali();
                    MessageBox.Show("ثبت در حساب مشتری با موفقیت انجام شد");
                    txtTozihat.Text = "";
                    txtCart.Text = "0";
                    txtNaghd.Text = "0";
                    DisplayMali();
                }
                catch (Exception)
                {
                    MessageBox.Show("خطایی در درج اطلاعات جدول مالی رخ داده است.");
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtCart.Text == "" || txtNaghd.Text == "")
            {
                MessageBox.Show(".لطفا فیلد های نقد و کارت را خالی نگذارید");
            }
            else
            {
                var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int cart = Convert.ToInt32(txtCart.Text.Replace(",", ""));
                        int naghd = Convert.ToInt32(txtNaghd.Text.Replace(",", ""));
                        int mablaghkol = cart + naghd;
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "update [tblMaliMoshtari] Set MablaghCart=N'" + cart +
                            "', MablaghNaghd=N'" + naghd +
                            "',MablaghKol=N'" + mablaghkol +
                            "',Date=N'" + txtDate.Text +
                            "',Tozihat=N'" + txtTozihat.Text +
                            "' where MaliMoshtariID=" + foroshID;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ///////////////////////////////////////////////////////////////////////////////////////
                        if (no == "پرداخت پول")
                        {
                            //referID = GetReferID();
                            UpdateTotblHesabPardakht(mablaghkol);
                            UpdateTotblSandoghPardakht(mablaghkol);
                        }
                        if (no == "دریافت پول")
                        {
                            //referID = GetReferID();
                            UpdateTotblHesabDaryaft(mablaghkol);
                            UpdateTotblSandoghDaryaft(mablaghkol);
                        }
                        DisplayMali();
                        Mali();
                        //////////////////////////////////////////////////////////////////////////////////////////////
                        MessageBox.Show("ویرایش اطلاعات انجام شد.");
                        cmd.Parameters.Clear();
                        txtTozihat.Text = "";
                        txtCart.Text = "0";
                        txtNaghd.Text = "0";
                        txtTozihat.Text = "";
                        txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
   
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
                foroshID = (int)dgvView.Rows[e.RowIndex].Cells["MaliMoshtariID"].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblMaliMoshtari] where MaliMoshtariID =" + foroshID;
                con.Open();
                adp.Fill(dt);
                this.txtCart.Text = dt.Rows[0]["MablaghCart"].ToString();
                this.txtNaghd.Text = dt.Rows[0]["MablaghNaghd"].ToString();
                this.lblKol.Text = dt.Rows[0]["MablaghKol"].ToString();
                this.txtTozihat.Text = dt.Rows[0]["Tozihat"].ToString();
                this.txtDate.Text = dt.Rows[0]["Date"].ToString();
                MoshtariID = (int)dt.Rows[0]["MoshtariID"];
                no = dt.Rows[0]["No"].ToString();
                if (dt.Rows[0]["No"].ToString() == "پرداخت پول")
                {
                    chkPardakht.Checked = true;
                }
                if (dt.Rows[0]["No"].ToString() == "دریافت پول")
                {
                    chkDaryaft.Checked = true;
                }
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
                    cmd.CommandText = "Delete from [tblMaliMoshtari] where MaliMoshtariID=@n ";
                    cmd.Parameters.AddWithValue("@n", foroshID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ///////////////////////////////////////////////////////////////////
                    if (no == "پرداخت پول")
                    {
                        DeletetblHesabPardakht();
                        DeletetblSandoghPardakht();
                    }
                    if (no == "دریافت پول")
                    {
                        DeletetblHesabDaryaft();
                        DeletetblSandoghDaryaft();
                    }
                    Mali();
                    //////////////////////////////////////////////////////////////////
                    MessageBox.Show("عملیات حذف با موفقیت انجام شد.");
                    txtTozihat.Text = "";
                    txtCart.Text = "0";
                    txtNaghd.Text = "0";
                    txtTozihat.Text = "";
                    DisplayMali();
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در حذف اطلاعات فروش رخ دارد!");
                }
            }
        }
        private void chkPardakht_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPardakht.Checked == true)
            {
                chkDaryaft.Checked = false;
            }
            no = "پرداخت پول";
            vaziat = "پرداختی";
        }
        private void chkDaryaft_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDaryaft.Checked == true)
            {
                chkPardakht.Checked = false;
            }
            no = "دریافت پول";
            vaziat = "دریافتی";
        }
    }
}
