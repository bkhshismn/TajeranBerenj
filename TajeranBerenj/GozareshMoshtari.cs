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
    public partial class GozareshMoshtari : Form
    {
        public GozareshMoshtari()
        {
            InitializeComponent();
        }
        int MoshtariID = -1;
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        #region Display
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
        #region Kharid
        void DisplayKharidShali()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKharidShali where MoshtariID=" + MoshtariID;
            adp.Fill(ds, "tblKharidShali");
            dgvKhShali.DataSource = ds;
            dgvKhShali.DataMember = "tblKharidShali";
            //**************************************************************
            dgvKhShali.Columns["KharidShaliID"].HeaderText = "کد محصول";
            dgvKhShali.Columns["KharidShaliID"].Width = 45;
            dgvKhShali.Columns["MoshtariID"].Visible = false;
            dgvKhShali.Columns["MablaghKol"].HeaderText = "مبلغ ";
            dgvKhShali.Columns["MablaghKol"].Width = 100;
            dgvKhShali.Columns["Fee"].HeaderText = "فی ";
            dgvKhShali.Columns["Fee"].Width = 100;
            dgvKhShali.Columns["No"].HeaderText = "نوع شالی";
            dgvKhShali.Columns["No"].Width = 100;
            dgvKhShali.Columns["Tedad"].HeaderText = "تعداد کیسه شالی";
            dgvKhShali.Columns["Tedad"].Width = 50;
            dgvKhShali.Columns["Vazn"].HeaderText = "وزن";
            dgvKhShali.Columns["Vazn"].Width = 70;
            dgvKhShali.Columns["Date"].HeaderText = " تاریخ ورود";
            dgvKhShali.Columns["Date"].Width = 90;
            dgvKhShali.Columns["Tozihat"].HeaderText = " توضیحات";
            dgvKhShali.Columns["Tozihat"].Width = 300;
        }
        void DisplayKharidDone()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblKharidDone where MoshtariID= " + MoshtariID;
                adp.Fill(ds, "tblKharidDone");
                dgvKhDone.DataSource = ds;
                dgvKhDone.DataMember = "tblKharidDone";
                //**************************************************************
                dgvKhDone.Columns["KharidDoneID"].HeaderText = "کد ";
                dgvKhDone.Columns["KharidDoneID"].Width = 45;
                dgvKhDone.Columns["NoDone"].HeaderText = "نوع برنج ";
                dgvKhDone.Columns["NoDone"].Width = 100;
                dgvKhDone.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvKhDone.Columns["AnbarName"].Width = 90;
                dgvKhDone.Columns["Vazn"].HeaderText = "وزن برنج";
                dgvKhDone.Columns["Vazn"].Width = 50;
                dgvKhDone.Columns["Fee"].HeaderText = "فی";
                dgvKhDone.Columns["Fee"].Width = 50;
                dgvKhDone.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvKhDone.Columns["Mablagh"].Width = 100;
                dgvKhDone.Columns["Tedad"].HeaderText = "تعداد";
                dgvKhDone.Columns["Tedad"].Width = 100;
                dgvKhDone.Columns["Date"].HeaderText = "تاریخ ";
                dgvKhDone.Columns["Date"].Width = 100;
                dgvKhDone.Columns["Takhfif"].HeaderText = "تخفیف";
                dgvKhDone.Columns["Takhfif"].Width = 50;
                dgvKhDone.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvKhDone.Columns["Tozihat"].Width = 300;

                dgvKhDone.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }

        }
        void DisplayyKharidNDone()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblKharidNimdone where MoshtariID= " + MoshtariID;
                adp.Fill(ds, "tblKharidNimdone");
                dgvKhNDone.DataSource = ds;
                dgvKhNDone.DataMember = "tblKharidNimdone";
                //**************************************************************
                dgvKhNDone.Columns["KharidNimdoneID"].HeaderText = "کد ";
                dgvKhNDone.Columns["KharidNimdoneID"].Width = 45;
                dgvKhNDone.Columns["NoDone"].HeaderText = "نوع نیمدونه ";
                dgvKhNDone.Columns["NoDone"].Width = 100;
                dgvKhNDone.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvKhNDone.Columns["AnbarName"].Width = 90;
                dgvKhNDone.Columns["Vazn"].HeaderText = "وزن نیمدونه";
                dgvKhNDone.Columns["Vazn"].Width = 50;
                dgvKhNDone.Columns["Fee"].HeaderText = "فی";
                dgvKhNDone.Columns["Fee"].Width = 50;
                dgvKhNDone.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvKhNDone.Columns["Mablagh"].Width = 100;
                dgvKhNDone.Columns["Date"].HeaderText = "تاریخ ";
                dgvKhNDone.Columns["Date"].Width = 100;
                dgvKhNDone.Columns["Takhfif"].HeaderText = "تخفیف";
                dgvKhNDone.Columns["Takhfif"].Width = 50;
                dgvKhNDone.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvKhNDone.Columns["Tozihat"].Width = 300;
                dgvKhNDone.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }

        }
        void DisplayKharidSabos1()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblKharidSabosNarm where MoshtariID= " + MoshtariID;
                adp.Fill(ds, "tblKharidSabosNarm");
                dgvKhSabos1.DataSource = ds;
                dgvKhSabos1.DataMember = "tblKharidSabosNarm";
                //**************************************************************
                dgvKhSabos1.Columns["KharidSabosNarmID"].HeaderText = "کد ";
                dgvKhSabos1.Columns["KharidSabosNarmID"].Width = 45;
                dgvKhSabos1.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvKhSabos1.Columns["AnbarName"].Width = 90;
                dgvKhSabos1.Columns["Vazn"].HeaderText = "وزن سبوس";
                dgvKhSabos1.Columns["Vazn"].Width = 50;
                dgvKhSabos1.Columns["Fee"].HeaderText = "فی";
                dgvKhSabos1.Columns["Fee"].Width = 50;
                dgvKhSabos1.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvKhSabos1.Columns["Mablagh"].Width = 100;
                dgvKhSabos1.Columns["Date"].HeaderText = "تاریخ ";
                dgvKhSabos1.Columns["Date"].Width = 100;
                dgvKhSabos1.Columns["Takhfif"].HeaderText = "تخفیف";
                dgvKhSabos1.Columns["Takhfif"].Width = 50;
                dgvKhSabos1.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvKhSabos1.Columns["Tozihat"].Width = 300;
                dgvKhSabos1.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }

        }
        void DisplayKharidSabos2()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblKharidSabosDo where MoshtariID= " + MoshtariID;
                adp.Fill(ds, "tblKharidSabosDo");
                dgvKhSabos2.DataSource = ds;
                dgvKhSabos2.DataMember = "tblKharidSabosDo";
                //**************************************************************
                dgvKhSabos2.Columns["KharidSabosDoID"].HeaderText = "کد ";
                dgvKhSabos2.Columns["KharidSabosDoID"].Width = 45;
                dgvKhSabos2.Columns["Vazn"].HeaderText = "وزن سبوس";
                dgvKhSabos2.Columns["Vazn"].Width = 50;
                dgvKhSabos2.Columns["Fee"].HeaderText = "فی";
                dgvKhSabos2.Columns["Fee"].Width = 50;
                dgvKhSabos2.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvKhSabos2.Columns["Mablagh"].Width = 100;
                dgvKhSabos2.Columns["Date"].HeaderText = "تاریخ ";
                dgvKhSabos2.Columns["Date"].Width = 100;
                dgvKhSabos2.Columns["Takhfif"].HeaderText = "تخفیف";
                dgvKhSabos2.Columns["Takhfif"].Width = 50;
                dgvKhSabos2.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvKhSabos2.Columns["Tozihat"].Width = 300;
                dgvKhSabos2.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }
        }
        #endregion
        #region Fororsh
        void DisplayForoshShali()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblForoshShali where MoshtariID= " + MoshtariID;
                adp.Fill(ds, "tblForoshShali");
                dgvFShali.DataSource = ds;
                dgvFShali.DataMember = "tblForoshShali";
                //**************************************************************
                dgvFShali.Columns["ForoshShaliID"].HeaderText = "کد ";
                dgvFShali.Columns["ForoshShaliID"].Width = 45;
                dgvFShali.Columns["NoDone"].HeaderText = "نوع برنج ";
                dgvFShali.Columns["NoDone"].Width = 100;
                dgvFShali.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvFShali.Columns["AnbarName"].Width = 90;
                dgvFShali.Columns["Vazn"].HeaderText = "وزن برنج";
                dgvFShali.Columns["Vazn"].Width = 50;
                dgvFShali.Columns["Fee"].HeaderText = "فی";
                dgvFShali.Columns["Fee"].Width = 50;
                dgvFShali.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvFShali.Columns["Mablagh"].Width = 100;
                dgvFShali.Columns["Tedad"].HeaderText = "تعداد";
                dgvFShali.Columns["Tedad"].Width = 50;
                dgvFShali.Columns["Date"].HeaderText = "تاریخ ";
                dgvFShali.Columns["Date"].Width = 100;
                dgvFShali.Columns["Takhfif"].HeaderText = "تخفیف";
                dgvFShali.Columns["Takhfif"].Width = 50;
                dgvFShali.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvFShali.Columns["Tozihat"].Width = 300;

                dgvFShali.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
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
                dgvFDone.DataSource = ds;
                dgvFDone.DataMember = "tblForoshDone";
                //**************************************************************
                dgvFDone.Columns["ForoshDoneID"].HeaderText = "کد ";
                dgvFDone.Columns["ForoshDoneID"].Width = 45;
                dgvFDone.Columns["NoDone"].HeaderText = "نوع برنج ";
                dgvFDone.Columns["NoDone"].Width = 100;
                dgvFDone.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvFDone.Columns["AnbarName"].Width = 90;
                dgvFDone.Columns["Vazn"].HeaderText = "وزن برنج";
                dgvFDone.Columns["Vazn"].Width = 50;
                dgvFDone.Columns["Fee"].HeaderText = "فی";
                dgvFDone.Columns["Fee"].Width = 50;
                dgvFDone.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvFDone.Columns["Mablagh"].Width = 100;
                dgvFDone.Columns["Tedad"].HeaderText = "تعداد";
                dgvFDone.Columns["Tedad"].Width = 50;
                dgvFDone.Columns["Date"].HeaderText = "تاریخ ";
                dgvFDone.Columns["Date"].Width = 100;
                dgvFDone.Columns["Takhfif"].HeaderText = "تخفیف";
                dgvFDone.Columns["Takhfif"].Width = 50;
                dgvFDone.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvFDone.Columns["Tozihat"].Width = 300;

                dgvFDone.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }

        }
        void DisplayForoshNDone()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblForoshNimdone where MoshtariID= " + MoshtariID;
                adp.Fill(ds, "tblForoshNimdone");
                dgvFNDone.DataSource = ds;
                dgvFNDone.DataMember = "tblForoshNimdone";
                //**************************************************************
                dgvFNDone.Columns["ForoshNimdoneID"].HeaderText = "کد ";
                dgvFNDone.Columns["ForoshNimdoneID"].Width = 45;
                dgvFNDone.Columns["NoDone"].HeaderText = "نوع نیمدونه ";
                dgvFNDone.Columns["NoDone"].Width = 100;
                dgvFNDone.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvFNDone.Columns["AnbarName"].Width = 90;
                dgvFNDone.Columns["Vazn"].HeaderText = "وزن نیمدونه";
                dgvFNDone.Columns["Vazn"].Width = 50;
                dgvFNDone.Columns["Fee"].HeaderText = "فی";
                dgvFNDone.Columns["Fee"].Width = 50;
                dgvFNDone.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvFNDone.Columns["Mablagh"].Width = 100;
                dgvFNDone.Columns["Date"].HeaderText = "تاریخ ";
                dgvFNDone.Columns["Date"].Width = 100;
                dgvFNDone.Columns["Takhfif"].HeaderText = "تخفیف";
                dgvFNDone.Columns["Takhfif"].Width = 50;
                dgvFNDone.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvFNDone.Columns["Tozihat"].Width = 300;

                dgvFNDone.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }

        }
        void DisplayForoshSabos1()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblForoshSabosNarm where MoshtariID= " + MoshtariID;
                adp.Fill(ds, "tblForoshSabosNarm");
                dgvFSabos1.DataSource = ds;
                dgvFSabos1.DataMember = "tblForoshSabosNarm";
                //**************************************************************
                dgvFSabos1.Columns["ForoshSabosNarmID"].HeaderText = "کد ";
                dgvFSabos1.Columns["ForoshSabosNarmID"].Width = 45;
                dgvFSabos1.Columns["AnbarName"].HeaderText = "نام انبار";
                dgvFSabos1.Columns["AnbarName"].Width = 90;
                dgvFSabos1.Columns["Vazn"].HeaderText = "وزن سبوس";
                dgvFSabos1.Columns["Vazn"].Width = 50;
                dgvFSabos1.Columns["Fee"].HeaderText = "فی";
                dgvFSabos1.Columns["Fee"].Width = 50;
                dgvFSabos1.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvFSabos1.Columns["Mablagh"].Width = 100;
                dgvFSabos1.Columns["Date"].HeaderText = "تاریخ ";
                dgvFSabos1.Columns["Date"].Width = 100;
                dgvFSabos1.Columns["Takhfif"].HeaderText = "تخفیف";
                dgvFSabos1.Columns["Takhfif"].Width = 50;
                dgvFSabos1.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvFSabos1.Columns["Tozihat"].Width = 300;
                dgvFSabos1.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }

        }
        void DisplayForoshSabos2()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblForoshSabosDo where MoshtariID= " + MoshtariID;
                adp.Fill(ds, "tblForoshSabosDo");
                dgvFSabos2.DataSource = ds;
                dgvFSabos2.DataMember = "tblForoshSabosDo";
                //**************************************************************
                dgvFSabos2.Columns["ForoshSabosDoID"].HeaderText = "کد ";
                dgvFSabos2.Columns["ForoshSabosDoID"].Width = 45;
                dgvFSabos2.Columns["Vazn"].HeaderText = "وزن سبوس";
                dgvFSabos2.Columns["Vazn"].Width = 50;
                dgvFSabos2.Columns["Fee"].HeaderText = "فی";
                dgvFSabos2.Columns["Fee"].Width = 50;
                dgvFSabos2.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvFSabos2.Columns["Mablagh"].Width = 100;
                dgvFSabos2.Columns["Date"].HeaderText = "تاریخ ";
                dgvFSabos2.Columns["Date"].Width = 100;
                dgvFSabos2.Columns["Takhfif"].HeaderText = "تخفیف";
                dgvFSabos2.Columns["Takhfif"].Width = 50;
                dgvFSabos2.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvFSabos2.Columns["Tozihat"].Width = 300;
                dgvFSabos2.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }

        }
        #endregion
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
                dgvMali.DataSource = ds;
                dgvMali.DataMember = "tblMaliMoshtari";
                //**************************************************************
                dgvMali.Columns["MaliMoshtariID"].HeaderText = "کد ";
                dgvMali.Columns["MaliMoshtariID"].Width = 45;
                dgvMali.Columns["MablaghCart"].HeaderText = "کارت";
                dgvMali.Columns["MablaghCart"].Width = 90;
                dgvMali.Columns["MablaghNaghd"].HeaderText = "نقد";
                dgvMali.Columns["MablaghNaghd"].Width = 90;
                dgvMali.Columns["MablaghKol"].HeaderText = " مجموع";
                dgvMali.Columns["MablaghKol"].Width = 100;
                dgvMali.Columns["Date"].HeaderText = "تاریخ ";
                dgvMali.Columns["No"].HeaderText = "نوع انتقال ";
                dgvMali.Columns["Date"].Width = 100;
                dgvMali.Columns["Tozihat"].HeaderText = " توضیحات";
                dgvMali.Columns["Tozihat"].Width = 300;
                dgvMali.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در نمایش اطلاعات رخ داده است");
            }

        }
        void DisplayGharz()
        {
            string ReferNo = "قرض";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblHesab where MoshtariID=" + MoshtariID + " and ReferNo=N'قرض'";
            adp.Fill(ds, "tblHesab");
            dgvGharz.DataSource = ds;
            dgvGharz.DataMember = "tblHesab";
            //**************************************************************
            dgvGharz.Columns["MoshtariID"].Visible = false;
            dgvGharz.Columns["HesabID"].Visible = false;
            dgvGharz.Columns["bes"].Visible = false;
            dgvGharz.Columns["ReferID"].Visible = false;
            dgvGharz.Columns["Takhfif"].Visible = false;
            dgvGharz.Columns["ReferNo"].Visible = false;
            dgvGharz.Columns["Bed"].HeaderText = "مبلغ ";
            dgvGharz.Columns["Bed"].Width = 100;
            dgvGharz.Columns["Date"].HeaderText = " تاریخ ";
            dgvGharz.Columns["Date"].Width = 90;
            dgvGharz.Columns["Tozihat"].HeaderText = " توضیحات";
            dgvGharz.Columns["Tozihat"].Width = 300;
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
                dgvPCheck.Columns["Mablagh"].Width = 100;
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
        void DisplayHesab()
        {
            string ReferNo = "قرض";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblHesab where MoshtariID=" + MoshtariID ;
            adp.Fill(ds, "tblHesab");
            dgvHesab.DataSource = ds;
            dgvHesab.DataMember = "tblHesab";
            //**************************************************************
            dgvHesab.Columns["MoshtariID"].Visible = false;
            dgvHesab.Columns["HesabID"].Visible = false;
            dgvHesab.Columns["Bes"].HeaderText = "دریافت";
            dgvHesab.Columns["ReferID"].Visible = false;
            dgvHesab.Columns["Takhfif"].Visible = false;
            dgvHesab.Columns["ReferNo"].HeaderText = "نوع";
            dgvHesab.Columns["Bed"].HeaderText = "پرداخت ";
            dgvHesab.Columns["Bed"].Width = 100;
            dgvHesab.Columns["Date"].HeaderText = " تاریخ ";
            dgvHesab.Columns["Date"].Width = 90;
            dgvHesab.Columns["Tozihat"].HeaderText = " توضیحات";
            dgvHesab.Columns["Tozihat"].Width = 300;
        }
        private void GozareshMoshtari_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            dgvInSearch.Visible = false;
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
                DisplayKharidShali();
                DisplayKharidDone();
                DisplayyKharidNDone();
                DisplayKharidSabos1();
                DisplayKharidSabos2();
                //......................................
                DisplayForoshShali();
                DisplayForoshDone();
                DisplayForoshNDone();
                DisplayForoshSabos1();
                DisplayForoshSabos2();
                DisplayHesab();
                Mali();
                DisplayMali();
                DisplayGharz();
                DisplayChecki();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد. رخ داده است.");
            }
        }
    }
}
