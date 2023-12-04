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
    public partial class frmTabdil : Form
    {
        public frmTabdil()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int referID = -1;
        string referNo = "تبدیل";
        int TabdilId = -1;
        #region display
        void DisplayTabdil()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblTabdil ";
                adp.Fill(ds, "tblTabdil");
                dgvView.DataSource = ds;
                dgvView.DataMember = "tblTabdil";
                //**************************************************************
                dgvView.Columns["TabdilID"].HeaderText = "کد تبدیل";
                dgvView.Columns["TabdilID"].Width = 45;
                dgvView.Columns["Date"].HeaderText = "تاریخ ";
                dgvView.Columns["Date"].Width = 100;
                dgvView.Columns["VaznShali"].HeaderText = "وزن شالی";
                dgvView.Columns["VaznShali"].Width = 50;
                dgvView.Columns["NoShali"].HeaderText = "نوع شالی ";
                dgvView.Columns["NoShali"].Width = 100;
                dgvView.Columns["TedadDone"].HeaderText = "تعداد برنج";
                dgvView.Columns["TedadDone"].Width = 50;
                dgvView.Columns["VaznDone"].HeaderText = "وزن برنج";
                dgvView.Columns["VaznDone"].Width = 50;
                dgvView.Columns["VaznNimdone"].HeaderText = "وزن نیمدونه";
                dgvView.Columns["VaznNimdone"].Width = 70;
                dgvView.Columns["VazneSabos"].HeaderText = "وزن سبوس";
                dgvView.Columns["VazneSabos"].Width = 90;
                dgvView.Columns["KarkhaneName"].HeaderText = "نام کارخانه";
                dgvView.Columns["KarkhaneName"].Width = 110;
                dgvView.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvView.Columns["AnbarName"].Width = 90;
                dgvView.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvView.Columns["Tozihat"].Width = 300;
                dgvView.Columns["ShomareFer"].HeaderText = "شماره فر";
                dgvView.Columns["ShomareFer"].Width = 50;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }

        }
        void DisplayTabdil(string type)
        {            
            try
            {
                type = "'" + type + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblTabdil where NoShali=N" + type;
                adp.Fill(ds, "tblTabdil");
                dgvView.DataSource = ds;
                dgvView.DataMember = "tblTabdil";
                //**************************************************************
                dgvView.Columns["TabdilID"].HeaderText = "کد تبدیل";
                dgvView.Columns["TabdilID"].Width = 45;
                dgvView.Columns["Date"].HeaderText = "تاریخ ";
                dgvView.Columns["Date"].Width = 100;
                dgvView.Columns["VaznShali"].HeaderText = "وزن شالی";
                dgvView.Columns["VaznShali"].Width = 50;
                dgvView.Columns["NoShali"].HeaderText = "نوع شالی ";
                dgvView.Columns["NoShali"].Width = 100;
                dgvView.Columns["TedadDone"].HeaderText = "تعداد برنج";
                dgvView.Columns["TedadDone"].Width = 50;
                dgvView.Columns["VaznDone"].HeaderText = "وزن برنج";
                dgvView.Columns["VaznDone"].Width = 50;
                dgvView.Columns["VaznNimdone"].HeaderText = "وزن نیمدونه";
                dgvView.Columns["VaznNimdone"].Width = 70;
                dgvView.Columns["VazneSabos"].HeaderText = "وزن سبوس";
                dgvView.Columns["VazneSabos"].Width = 90;
                dgvView.Columns["KarkhaneName"].HeaderText = "نام کارخانه";
                dgvView.Columns["KarkhaneName"].Width = 110;
                dgvView.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvView.Columns["AnbarName"].Width = 90;
                dgvView.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvView.Columns["Tozihat"].Width = 300;
                dgvView.Columns["ShomareFer"].HeaderText = "شماره فر";
                dgvView.Columns["ShomareFer"].Width = 50;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }
           
        }
        void DisplayTabdil(string type, string KarkhaneName)
        {
            try
            {
                type = "'" + type + "'";
                KarkhaneName = "'" + KarkhaneName + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblTabdil where NoShali=N" + type + " AND KarkhaneName=N" + KarkhaneName;
                adp.Fill(ds, "tblTabdil");
                dgvView.DataSource = ds;
                dgvView.DataMember = "tblTabdil";
                //**************************************************************
                dgvView.Columns["TabdilID"].HeaderText = "کد تبدیل";
                dgvView.Columns["TabdilID"].Width = 45;
                dgvView.Columns["Date"].HeaderText = "تاریخ ";
                dgvView.Columns["Date"].Width = 100;
                dgvView.Columns["VaznShali"].HeaderText = "وزن شالی";
                dgvView.Columns["VaznShali"].Width = 50;
                dgvView.Columns["NoShali"].HeaderText = "نوع شالی ";
                dgvView.Columns["NoShali"].Width = 100;
                dgvView.Columns["TedadDone"].HeaderText = "تعداد برنج";
                dgvView.Columns["TedadDone"].Width = 50;
                dgvView.Columns["VaznDone"].HeaderText = "وزن برنج";
                dgvView.Columns["VaznDone"].Width = 50;
                dgvView.Columns["VaznNimdone"].HeaderText = "وزن نیمدونه";
                dgvView.Columns["VaznNimdone"].Width = 70;
                dgvView.Columns["VazneSabos"].HeaderText = "وزن سبوس";
                dgvView.Columns["VazneSabos"].Width = 90;
                dgvView.Columns["KarkhaneName"].HeaderText = "نام کارخانه";
                dgvView.Columns["KarkhaneName"].Width = 110;
                dgvView.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvView.Columns["AnbarName"].Width = 90;
                dgvView.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvView.Columns["Tozihat"].Width = 300;
                dgvView.Columns["ShomareFer"].HeaderText = "شماره فر";
                dgvView.Columns["ShomareFer"].Width = 50;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }
           
        }
        void DisplayTabdil(string type, string KarkhaneName, string AnbarName)
        {
            try
            {
                type = "'" + type + "'";
                KarkhaneName = "'" + KarkhaneName + "'";
                AnbarName = "'" + AnbarName + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblTabdil where NoShali=N" + type + " AND KarkhaneName=N" + KarkhaneName + "AND AnbarName=N" + AnbarName;
                adp.Fill(ds, "tblTabdil");
                dgvView.DataSource = ds;
                dgvView.DataMember = "tblTabdil";
                //**************************************************************
                dgvView.Columns["TabdilID"].HeaderText = "کد تبدیل";
                dgvView.Columns["TabdilID"].Width = 45;
                dgvView.Columns["Date"].HeaderText = "تاریخ ";
                dgvView.Columns["Date"].Width = 100;
                dgvView.Columns["VaznShali"].HeaderText = "وزن شالی";
                dgvView.Columns["VaznShali"].Width = 50;
                dgvView.Columns["NoShali"].HeaderText = "نوع شالی ";
                dgvView.Columns["NoShali"].Width = 100;
                dgvView.Columns["TedadDone"].HeaderText = "تعداد برنج";
                dgvView.Columns["TedadDone"].Width = 50;
                dgvView.Columns["VaznDone"].HeaderText = "وزن برنج";
                dgvView.Columns["VaznDone"].Width = 50;
                dgvView.Columns["VaznNimdone"].HeaderText = "وزن نیمدونه";
                dgvView.Columns["VaznNimdone"].Width = 70;
                dgvView.Columns["VazneSabos"].HeaderText = "وزن سبوس";
                dgvView.Columns["VazneSabos"].Width = 90;
                dgvView.Columns["KarkhaneName"].HeaderText = "نام کارخانه";
                dgvView.Columns["KarkhaneName"].Width = 110;
                dgvView.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvView.Columns["AnbarName"].Width = 90;
                dgvView.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvView.Columns["Tozihat"].Width = 300;
                dgvView.Columns["ShomareFer"].HeaderText = "شماره فر";
                dgvView.Columns["ShomareFer"].Width = 50;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }
          
        }
        void Displayanbarha()
        {
            int koledonemojod = 0;
            int kolenimdonemojod = 0;
            int kolesabosnarmmojod = 0;
            koledonemojod = (mt.GetKharidAnbarDone() - mt.GetForoshAnbarDone());
            lblKolDone.Text = koledonemojod.ToString("N0");

            kolenimdonemojod = (mt.GetKharidanbarNimdone() - mt.GetForoshAnbarNimdone());
            lblKolNDone.Text = kolenimdonemojod.ToString("N0");

            kolesabosnarmmojod = (mt.GetKharidAnbarsabosNarm() - mt.GetForoshAnbarSabosNarm());
            lblKolSabosNarm.Text = kolesabosnarmmojod.ToString("N0");
        }
        #endregion
        int GetReferID()
        {  
            int TabdilID = -1;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblTabdil ";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            TabdilID = (int)dt.Rows[cunt - 1]["TabdilID"];
            return TabdilID;
        }
        public void FilterMahsolat()
        {
            con.ConnectionString = mt.DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarSabosNarm where NoVorod= 'out'";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int vazn = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    vazn += Convert.ToInt32(dt.Rows[i]["Vazn"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
        }
        #region Inserts
        void InsertTotblAnbarShali(int id)
        {
            try
            {
                int vaznShali = 0;
                if (txtVaznShali.Text != "")
                {
                    vaznShali = Convert.ToInt32(txtVaznShali.Text.Replace(",", ""));
                }
                string no = "Out-Tabdil";
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblAnbarShali (NoShali,Vazn,NoVorod ,KharidShaliID,TabdilID)values(@NoShali,@Vazn,@NoVorod,@KharidShaliID,@TabdilID)";
                cmd.Parameters.AddWithValue("@NoShali", cmbBerenjNo.Text);
                cmd.Parameters.AddWithValue("@Vazn", vaznShali);
                cmd.Parameters.AddWithValue("@NoVorod", no);
                cmd.Parameters.AddWithValue("@KharidShaliID", 0);
                cmd.Parameters.AddWithValue("@TabdilID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("ثبت در انبار با موفقیت انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات جدول انبار رخ داده است.");
            }
        }
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
        void InsertTotblAnbarNimdone(int id)
        {
            try
            {
                int vazn = 0;
                if (txtWDone.Text != "")
                {
                    vazn = Convert.ToInt32(txtWNimdone.Text.Replace(",", ""));
                }
                string no = "in";
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblAnbarNimdone (Vazn,NoVorod,NoNimdone,ReferID,ReferNo,AnbarName)values(@Vazn,@NoVorod,@NoNimdone,@ReferID,@ReferNo,@AnbarName)";
                cmd.Parameters.AddWithValue("@Vazn", vazn);
                cmd.Parameters.AddWithValue("@NoVorod", no);
                cmd.Parameters.AddWithValue("@ReferID", id);
                cmd.Parameters.AddWithValue("@ReferNo", referNo);
                cmd.Parameters.AddWithValue("@NoNimdone", cmbBerenjNo.Text);
                cmd.Parameters.AddWithValue("@AnbarName", cmbAnbar.Text);
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
        void InsertTotblAnbarSabosNarm(int id)
        {
            try
            {
                int vazn = 0;
                if (txtWDone.Text != "")
                {
                    vazn = Convert.ToInt32(txtWNimdone.Text.Replace(",", ""));
                }
                string no = "in";
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblAnbarSabosNarm (Vazn,NoVorod ,ReferID,ReferNo,AnbarName)values(@Vazn,@NoVorod ,@ReferID,@ReferNo,@AnbarName)";
                cmd.Parameters.AddWithValue("@Vazn", vazn);
                cmd.Parameters.AddWithValue("@NoVorod", no);
                cmd.Parameters.AddWithValue("@ReferID", id);
                cmd.Parameters.AddWithValue("@ReferNo", referNo);
                cmd.Parameters.AddWithValue("@AnbarName", cmbAnbar.Text);
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
        #endregion
        #region Update
        void UpdateTotblTabdil()
        {
            var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (TabdilId != -1)
                {
                    try
                    {
                        #region
                        int vaznDone = 0;
                        if (txtWDone.Text != "")
                        {
                            vaznDone = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                        }
                        int vaznNimDone = 0;
                        if (txtWNimdone.Text != "")
                        {
                            vaznNimDone = Convert.ToInt32(txtWNimdone.Text.Replace(",", ""));
                        }
                        int vaznSabos = 0;
                        if (txtWYekob.Text != "")
                        {
                            vaznSabos = Convert.ToInt32(txtWYekob.Text.Replace(",", ""));
                        }
                        double tedadKise = 0;
                        if (txtTedadDone.Text != "")
                        {
                            tedadKise = Convert.ToDouble(txtTedadDone.Text.Replace(",", ""));
                        }
                        int vaznShali = 0;
                        if (txtVaznShali.Text != "")
                        {
                            vaznShali = Convert.ToInt32(txtTedadDone.Text.Replace(",", ""));
                        }
                        int ShomareFer = 0;
                        if (txtVaznShali.Text != "")
                        {
                            ShomareFer = Convert.ToInt32(txtFer.Text);
                        }
                        #endregion
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "update [tblTabdil] Set NoShali=N'" + cmbBerenjNo.Text +
                            "', VaznShali=N'" + vaznShali +
                            "', Date=N'" + txtDate.Text +
                            "', TedadDone=N'" + tedadKise +
                            "', VaznDone=N'" + vaznDone +
                            "', VaznNimdone=N'" + vaznNimDone +
                            "', VazneSabos=N'" + vaznSabos +
                            "', KarkhaneName=N'" + cmbKarkhane.Text +
                            "', AnbarName=N'" + cmbAnbar.Text +
                            "', ShomareFer=N'" + ShomareFer +
                            "', Tozihat=N'" + txtTozihat.Text +
                            "' where TabdilID=" + TabdilId;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        DisplayTabdil();
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////
                        UpdateTotblAnbarDone();
                        UpdateTotblAnbarNimdone();
                        UpdateTotblAnbarSabos();
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////
                        MessageBox.Show("ویرایش اطلاعات انجام شد.");
                    txtTedadDone.Text = "";
                    txtWYekob.Text = "";
                    txtWNimdone.Text = "";
                    txtWDone.Text = "";
                    txtFer.Text = "";
                    txtTozihat.Text = "";
                    txtVaznShali.Text = "";
                    TabdilId = -1;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("مشکلی در ویرایش اطلاعات انبار شالی  رخ دارد!");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد مورد نظر کلیک کنید"); }
            }
        }
        void UpdateTotblAnbarDone()
        {
            string no = "تبدیل";
            try
            {
                int vazn = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblAnbarDone] Set NoDone=N'" + cmbBerenjNo.Text + "', Vazn=N'" + vazn + "' where ReferNO=N'" + no + "' And ReferID=" + TabdilId;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات انبار برنج رخ دارد!");
            }
        }
        void UpdateTotblAnbarNimdone()
        {
            string no = "تبدیل";
            try
            {
                int vazn = Convert.ToInt32(txtWNimdone.Text.Replace(",", ""));
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblAnbarNimdone] Set NoNimdone=N'" + cmbBerenjNo.Text + "', Vazn=N'" + vazn + "' where ReferNO=N'" + no + "' And ReferID=" + TabdilId;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات انبار نیمدونه رخ دارد!");
            }
        }
        void UpdateTotblAnbarSabos()
        {
            string no = "تبدیل";
            try
            {
                int vazn = Convert.ToInt32(txtWYekob.Text.Replace(",", ""));
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblAnbarSabosNarm] Set  Vazn=N'" + vazn + "' where ReferNO=N'" + no + "' And ReferID=" + TabdilId;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات انبار سبوس نرم رخ دارد!");
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
                cmd.CommandText = "Delete from [tblAnbarDone] where ReferID=@n";
                cmd.Parameters.AddWithValue("@n", TabdilId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات انبار برنج رخ دارد!");
            }

        }
        void DeletetblanbarNimdone()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblAnbarNimdone] where ReferID=@n";
                cmd.Parameters.AddWithValue("@n", TabdilId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات انبار نیمدونه رخ دارد!");
            }

        }
        void DeletetblanbarSabos()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblAnbarSabosNarm] where ReferID=@n";
                cmd.Parameters.AddWithValue("@n", TabdilId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات انبار سبوس نرم رخ دارد!");
            }

        }
        void DeletetblanbarShali()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblAnbarShali] where TabdilID=@n and NoVorod='Out-Tabdil'";
                cmd.Parameters.AddWithValue("@n", TabdilId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات انبار سبوس نرم رخ دارد!");
            }

        }
        #endregion
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
        public void DisplayComboKarkhane()
        {
            try
            {
                con.Close();
                string query = "SELECT  Name FROM [tblKarkhane]";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                cmd.ExecuteScalar();
                con.Close();
                cmbKarkhane.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbKarkhane.Items.Add(dt.Rows[i]["Name"]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات نام کارخانه رخ داده است");
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
        private void frmTabdil_Load(object sender, EventArgs e)
        {
            txtTedadDone.Enabled = false;
            int koledonemojod = 0;
            int kolenimdonemojod = 0;
            int kolesabosnarmmojod = 0;
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            DisplayComboNoShali();
            cmbBerenjNo.Text = cmbBerenjNo.Items[0].ToString();
            DisplayComboKarkhane();
            cmbKarkhane.Text = cmbKarkhane.Items[0].ToString();
            DisplayComboAnbar();
            cmbAnbar.Text = cmbAnbar.Items[0].ToString();
            lblKDone.Visible = false;
            lblWDone.Visible = false;
            lblWNimDone.Visible = false;
            lblWYekob.Visible = false;
            lblVShali.Visible = false;
            DisplayTabdil();
            koledonemojod = (mt.GetKharidAnbarDone()- mt.GetForoshAnbarDone());
            lblKolDone.Text = koledonemojod.ToString("N0");

            kolenimdonemojod = (mt.GetKharidanbarNimdone() - mt.GetForoshAnbarNimdone());
            lblKolNDone.Text = kolenimdonemojod.ToString("N0");

            kolesabosnarmmojod = (mt.GetKharidAnbarsabosNarm() - mt.GetForoshAnbarSabosNarm());
            lblKolSabosNarm.Text = kolesabosnarmmojod.ToString("N0");
            //---------------------------------------------------------------------------------------------------------------------------
        }
        private void btnAddShali_Click(object sender, EventArgs e)
        {
            new frmNoShali().ShowDialog();
        }
        private void btnAddKarkhane_Click(object sender, EventArgs e)
        {
            new frmKarkhane().ShowDialog();
        }
        private void cmbBerenjNo_Click(object sender, EventArgs e)
        {
            //DisplayComboNoShali();
            //cmbBerenjNo.Text = cmbBerenjNo.Items[0].ToString();
            //DisplayTabdil();
        }
        private void cmbKarkhane_Click(object sender, EventArgs e)
        {
            cmbKarkhane.Text = cmbKarkhane.Items[0].ToString();
        }
        private void cmbAnbar_Click(object sender, EventArgs e)
        {
            DisplayComboAnbar();
            cmbAnbar.Text = cmbAnbar.Items[0].ToString();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmTarifAnbar().ShowDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtTedadDone.Text == "" || txtWDone.Text == "" || txtWNimdone.Text == "" || txtWYekob.Text == "" || txtVaznShali.Text == "")
            {
                MessageBox.Show(".لطفا فیلد های مشخص شده را پر کنید");
                if (txtTedadDone.Text == "")
                {
                    lblKDone.Visible = true;
                }
                if (txtWDone.Text == "")
                {
                    lblWDone.Visible = true;
                }
                if (txtWNimdone.Text == "")
                {
                    lblWNimDone.Visible = true;
                }
                if (txtWYekob.Text == "")
                {
                    lblWYekob.Visible = true;
                }
                if (txtVaznShali.Text == "")
                {
                    txtVaznShali.Visible = true;
                }
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
                    int vaznNimDone = 0;
                    if (txtWNimdone.Text != "")
                    {
                        vaznNimDone = Convert.ToInt32(txtWNimdone.Text.Replace(",", ""));
                    }
                    int vaznSabos = 0;
                    if (txtWYekob.Text != "")
                    {
                        vaznSabos = Convert.ToInt32(txtWYekob.Text.Replace(",", ""));
                    }
                    double tedadKise = 0;
                    if (txtTedadDone.Text != "")
                    {
                        tedadKise = Convert.ToInt32(txtTedadDone.Text.Replace(",", ""));
                    }

                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblTabdil](Date,NoShali,VaznShali,TedadDone,VaznDone,VaznNimdone,VazneSabos,KarkhaneName,AnbarName,ShomareFer,Tozihat)values(@Date,@NoShali,@VaznShali,@TedadDone,@VaznDone,@VaznNimdone,@VazneSabos,@KarkhaneName,@AnbarName,@ShomareFer,@Tozihat)";
                    cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                    cmd.Parameters.AddWithValue("@NoShali", cmbBerenjNo.Text);
                    cmd.Parameters.AddWithValue("@VaznShali", txtVaznShali.Text);
                    cmd.Parameters.AddWithValue("@TedadDone", tedadKise);
                    cmd.Parameters.AddWithValue("@VaznDone",vaznDone);
                    cmd.Parameters.AddWithValue("@VaznNimdone", vaznNimDone);
                    cmd.Parameters.AddWithValue("@VazneSabos", vaznSabos);
                    cmd.Parameters.AddWithValue("@KarkhaneName", cmbKarkhane.Text);
                    cmd.Parameters.AddWithValue("@AnbarName", cmbAnbar.Text);
                    cmd.Parameters.AddWithValue("@ShomareFer", txtFer.Text);
                    cmd.Parameters.AddWithValue("@Tozihat", txtTozihat.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////
                    InsertTotblAnbarShali(GetReferID());
                    InsertTotblAnbarDone(GetReferID());
                    InsertTotblAnbarNimdone(GetReferID());
                    InsertTotblAnbarSabosNarm(GetReferID());
                    Displayanbarha();
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////
                    DisplayTabdil();
                    MessageBox.Show("ثبت با موفقیت انجام شد");
                   
                    txtTedadDone.Text = "";
                    txtWYekob.Text = "";
                    txtWNimdone.Text = "";
                    txtWDone.Text = "";
                    txtFer.Text = "";
                    txtTozihat.Text = "";
                    txtVaznShali.Text = "";
                    ///////////////////////////////////////////////////////////////////////////////////////////////
                }
                catch
                {
                    MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
                }

            }
        }
        private void txtTedadDone_TextChanged(object sender, EventArgs e)
        {
            lblKDone.Visible = false;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateTotblTabdil();
            Displayanbarha();
        }
        private void txtWDone_TextChanged(object sender, EventArgs e)
        {
            lblWDone.Visible = false;
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
        private void txtWNimdone_TextChanged(object sender, EventArgs e)
        {
            lblWNimDone.Visible = false;
            try
            {
                if (txtWNimdone.Text != string.Empty)
                {
                    txtWNimdone.Text = string.Format("{0:N0}", double.Parse(txtWNimdone.Text.Replace(",", "")));
                    txtWNimdone.Select(txtWNimdone.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }

        }
        private void txtWYekob_TextChanged(object sender, EventArgs e)
        {
            lblWYekob.Visible = false;
            try
            {
                if (txtWYekob.Text != string.Empty)
                {
                    txtWYekob.Text = string.Format("{0:N0}", double.Parse(txtWYekob.Text.Replace(",", "")));
                    txtWYekob.Select(txtWYekob.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }

        }
        private void txtTedadShali_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtVaznShali_TextChanged(object sender, EventArgs e)
        {
            lblVShali.Visible = false;
        }
        private void dgvView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvView.Rows[e.RowIndex].Selected = true;
            try
            {
                TabdilId = (int)dgvView.Rows[e.RowIndex].Cells["TabdilID"].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblTabdil] where TabdilID =" + TabdilId;
                con.Open();
                adp.Fill(dt);
                this.cmbBerenjNo.Text = dt.Rows[0]["NoShali"].ToString();
                this.cmbKarkhane.Text = dt.Rows[0]["KarkhaneName"].ToString();
                this.cmbAnbar.Text = dt.Rows[0]["AnbarName"].ToString();
                this.txtTedadDone.Text = dt.Rows[0]["TedadDone"].ToString();
                this.txtWDone.Text = dt.Rows[0]["VaznDone"].ToString();
                this.txtWNimdone.Text = dt.Rows[0]["VaznNimdone"].ToString();
                this.txtWYekob.Text = dt.Rows[0]["VazneSabos"].ToString();
                this.txtFer.Text = dt.Rows[0]["ShomareFer"].ToString();
                this.txtVaznShali.Text = dt.Rows[0]["VaznShali"].ToString();
                this.txtDate.Text = dt.Rows[0]["Date"].ToString();
                this.txtTozihat.Text = dt.Rows[0]["Tozihat"].ToString();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است");
            }
        }
        private void cmbBerenjNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTabdil(cmbBerenjNo.Text);
            lblFilterdone.Text = (mt.FilterGetKharidAnbarDone(cmbBerenjNo.Text, cmbAnbar.Text) - mt.FilterGetForoshAnbarDone(cmbBerenjNo.Text, cmbAnbar.Text)).ToString();
        }
        private void cmbKarkhane_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTabdil(cmbBerenjNo.Text, cmbKarkhane.Text);
        }
        private void cmbAnbar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTabdil(cmbBerenjNo.Text, cmbKarkhane.Text,cmbAnbar.Text);
            lblFilterdone.Text = (mt.FilterGetKharidAnbarDone(cmbBerenjNo.Text, cmbAnbar.Text) - mt.FilterGetForoshAnbarDone(cmbBerenjNo.Text, cmbAnbar.Text)).ToString();
            lblFilterNimdone.Text= (mt.FilterGetKharidanbarNimdone(cmbBerenjNo.Text, cmbAnbar.Text) - mt.FilterGetForoshAnbarNimdone(cmbBerenjNo.Text, cmbAnbar.Text)).ToString();
            lblFilterSabos.Text = (mt.FilterGetKharidAnbarsabosNarm( cmbAnbar.Text) - mt.FilterGetForoshAnbarSabosNarm( cmbAnbar.Text)).ToString();
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
                    cmd.CommandText = "Delete from [tblTabdil] where TabdilID=@n";
                    cmd.Parameters.AddWithValue("@n", TabdilId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    /////////////////////////////////////////////////////////////////////
                    DeletetblanbarDone();
                    DeletetblanbarNimdone();
                    DeletetblanbarSabos();
                    DeletetblanbarShali();
                    Displayanbarha();
                    ////////////////////////////////////////////////////////////////////
                    MessageBox.Show("عملیات حذف با موفقیت انجام شد.");
                    TabdilId = -1;
                    DisplayTabdil();
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در حذف اطلاعات تبدیل رخ دارد!");
                }
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            txtTedadDone.Text = "";
            txtWYekob.Text = "";
            txtWNimdone.Text = "";
            txtWDone.Text = "";
            txtFer.Text = "";
            txtTozihat.Text = "";
            txtVaznShali.Text = "";

        }
    }
}
