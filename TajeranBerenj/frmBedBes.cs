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
    public partial class frmBedBes : Form
    {
        public frmBedBes()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int set = 0;
        void DisplayBed()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [View_BedehKar]";
                adp.Fill(ds, "View_BedehKaran");
                dgvBed.DataSource = ds;
                dgvBed.DataMember = "View_BedehKaran";
                dgvBed.Columns["MoshtariID"].HeaderText = "کد";
                dgvBed.Columns["MoshtariID"].Width = 70;
                dgvBed.Columns["Name"].HeaderText = " نام";
                dgvBed.Columns["Name"].Width = 150;
                dgvBed.Columns["Mablagh"].HeaderText = "مبلغ بدهکاری";

            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        void DisplayBes()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [View_BestanKar]";
                adp.Fill(ds, "View_BedehKaran");
                dgvBed.DataSource = ds;
                dgvBed.DataMember = "View_BedehKaran";
                dgvBed.Columns["MoshtariID"].HeaderText = "کد";
                dgvBed.Columns["MoshtariID"].Width = 70;
                dgvBed.Columns["Name"].HeaderText = " نام";
                dgvBed.Columns["Name"].Width = 150;
                dgvBed.Columns["Mablagh"].HeaderText = "مبلغ بدهکاری";

            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        void DeleteBed()
        {
            try
            {
                DataSet ds1 = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt1 = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblBedehkar";
                adp.Fill(dt1);
                int cunt1 = dt1.Rows.Count;
                if (cunt1 > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from [tblBedehkar]";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {

            }
          
           
        }
        void DeleteBes()
        {
            try
            {
                DataSet ds1 = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt1 = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblBestankar";
                adp.Fill(dt1);
                int cunt1 = dt1.Rows.Count;
                if (cunt1 > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from [tblBestankar]";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {

            }

        }
        void InsertBed(int MoshtariID, int Mablagh)
        {
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT into [tblBedehkar](MoshtariID,Mablagh)values(@MoshtariID,@Mablagh)";
            cmd.Parameters.AddWithValue("@MoshtariID", MoshtariID);
            cmd.Parameters.AddWithValue("@Mablagh", Mablagh);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void InsertBes(int MoshtariID, int Mablagh)
        {
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT into [tblBestankar](MoshtariID,Mablagh)values(@MoshtariID,@Mablagh)";
            cmd.Parameters.AddWithValue("@MoshtariID", MoshtariID);
            cmd.Parameters.AddWithValue("@Mablagh", Mablagh);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void Bedehkaran()
        {
            DataSet ds1 = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblMoshtari";
            adp.Fill(dt1);
            int cunt1 = dt1.Rows.Count;
            int[] id = new int[cunt1];
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    id[i] += Convert.ToInt32(dt1.Rows[i]["MoshtariID"]);
                }
            }
            else
            {

            }
            con.Close();
            int s = 0;
            for (int i = 0; i <= cunt1 - 1; i++)
            {
                int[] bedbes = mt.BedBesHesab(id[i]);
                if (bedbes[0] > 0)
                {
                    InsertBed(id[i], bedbes[0]);
                }
                else if (bedbes[1] > 0)
                {
                    InsertBes(id[i], bedbes[1]);
                }
            }
        }
        private void frmBedBes_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            DeleteBed();
            DeleteBes();
            Bedehkaran();
        }

        private void btnBedJari_Click(object sender, EventArgs e)
        {
            labelX2.Text = "بدهکاران";
            DisplayBed();
            set = 1;
        }

        private void btnBesJari_Click(object sender, EventArgs e)
        {
            labelX2.Text = "بستانکاران";
            DisplayBes();
            set = 2;
        }

        private void dgvBed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != this.dgvBed.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (set == 1)
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.SelectCommand = new SqlCommand();
                    adp.SelectCommand.Connection = con;
                    adp.SelectCommand.CommandText = "select * from View_BedehKar where Name Like '%' + @s + '%'";
                    adp.SelectCommand.Parameters.AddWithValue("@s", textBoxX1.Text + "%");
                    adp.Fill(ds, "View_BedehKar");
                    dgvBed.DataSource = ds;
                    dgvBed.DataMember = "View_BedehKar";
                    dgvBed.Columns["MoshtariID"].HeaderText = "کد";
                    dgvBed.Columns["MoshtariID"].Width = 70;
                    dgvBed.Columns["Name"].HeaderText = " نام";
                    dgvBed.Columns["Name"].Width = 150;
                    dgvBed.Columns["Mablagh"].HeaderText = "مبلغ بدهکاری";
                }
                else if (set == 2)
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.SelectCommand = new SqlCommand();
                    adp.SelectCommand.Connection = con;
                    adp.SelectCommand.CommandText = "select * from View_Bestankar where Name Like '%' + @s + '%'";
                    adp.SelectCommand.Parameters.AddWithValue("@s", textBoxX1.Text + "%");
                    adp.Fill(ds, "View_Bestankar");
                    dgvBed.DataSource = ds;
                    dgvBed.DataMember = "View_Bestankar";
                    dgvBed.Columns["MoshtariID"].HeaderText = "کد";
                    dgvBed.Columns["MoshtariID"].Width = 70;
                    dgvBed.Columns["Name"].HeaderText = " نام";
                    dgvBed.Columns["Name"].Width = 150;
                    dgvBed.Columns["Mablagh"].HeaderText = "مبلغ بدهکاری";
                }
            }
            catch
            {

            }
        }
    }
}
