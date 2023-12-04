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
    public partial class frmGharz : Form
    {
        public frmGharz()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int MoshtariID = -1;
        int HesabId = -1;
        void BedBes()
        {
            int[] bedbes = mt.BedBesHesab(MoshtariID);
            lblBedehkar.Text = bedbes[0].ToString("N0");
            lblBestankar.Text = bedbes[1].ToString("N0");
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
            dgvInput.DataSource = ds;
            dgvInput.DataMember = "tblHesab";
            //**************************************************************
            dgvInput.Columns["MoshtariID"].Visible = false;
            dgvInput.Columns["HesabID"].Visible = false;
            dgvInput.Columns["bes"].Visible = false;
            dgvInput.Columns["ReferID"].Visible = false;
            dgvInput.Columns["ReferNo"].Visible = false;
            dgvInput.Columns["Bed"].HeaderText = "مبلغ ";
            dgvInput.Columns["Bed"].Width = 200;
            dgvInput.Columns["Date"].HeaderText = " تاریخ ";
            dgvInput.Columns["Date"].Width = 90;
            dgvInput.Columns["Tozihat"].HeaderText = " توضیحات";
            dgvInput.Columns["Tozihat"].Width = 300;
            BedBes();

        }
        int HesabID()
        {
            int id = -1;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblHesab ";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            id = (int)dt.Rows[cunt - 1]["HesabID"];
            return id;
        }
        void DeletetblSandogh()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblSandogh] where ReferID=@n and ReferNo=N'قرض'";
                cmd.Parameters.AddWithValue("@n", HesabId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در حذف اطلاعات صندوق  رخ دارد!");

            }

        }
        void UpdateTotblSandogh()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblSandogh] Set bes='" + Convert.ToInt32(txtFee.Text.Replace(",", "")) + "' where ReferID=" + HesabId + " AND ReferNo=N'قرض'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات صندوق  رخ دارد!");
            }
        }
        #region Insert
        void InsertTotblHesab( int MoshtariId, int mablagh)
        {
            try
            {
                string no = "قرض";
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblHesab (MoshtariID,ReferNo,Date,bed,bes,Tozihat)values(@MoshtariID,@ReferNo,@Date,@bed," + 0 + ",@Tozihat)";
                cmd.Parameters.AddWithValue("@MoshtariID", MoshtariId);
                cmd.Parameters.AddWithValue("@ReferNo", no);
                cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                cmd.Parameters.AddWithValue("@Tozihat", txtTozihat.Text);
                cmd.Parameters.AddWithValue("@bed", mablagh);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ثبت در حساب مشتری با موفقیت انجام شد");
                DisplayGharz();
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
                string no = "قرض";
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
        private void frmGharz_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            dgvInSearch.Visible = false;
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
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
                DisplayGharz();

            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد. رخ داده است.");
            }
            txtName.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertTotblHesab(MoshtariID, Convert.ToInt32(txtFee.Text.Replace(",", "")));
            InsertTotblSandogh(HesabID(), MoshtariID, Convert.ToInt32(txtFee.Text.Replace(",", "")));
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
        private void dgvInput_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != dgvInput.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtFee.Text == "")
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
                        try
                        {
                            cmd.Parameters.Clear();
                            cmd.Connection = con;
                            cmd.CommandText = "update [tblHesab] Set bed=N'" + Convert.ToInt32(txtFee.Text.Replace(",", "")) + "',Tozihat=N'"+txtTozihat.Text+ "',Date=N'" + txtDate.Text + "' where HesabID=" + HesabId ;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            DisplayGharz();
                            UpdateTotblSandogh();
                            MessageBox.Show("ویرایش با موفقیت انجام شد!");
                            txtFee.Text = "";
                            txtTozihat.Text = "";
                            HesabId = -1;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("مشکلی در ویرایش اطلاعات حساب  رخ دارد!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("مشکلی در ویرایش اطلاعات وجود دارد!");
                    }
                }
            }
        }
        private void dgvInput_Click(object sender, EventArgs e)
        {
           
        }
        private void dgvInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                HesabId = (int)dgvInput.Rows[e.RowIndex].Cells["HesabID"].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblHesab] where HesabID =" + HesabId;
                con.Open();
                adp.Fill(dt);
                this.txtFee.Text = dt.Rows[0]["bed"].ToString();
                this.txtTozihat.Text = dt.Rows[0]["Tozihat"].ToString();
                this.txtDate.Text = dt.Rows[0]["Date"].ToString();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است");
            }
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            txtFee.Text = "";
            txtTozihat.Text = "";
            HesabId = -1;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from [tblHesab] where HesabID=@n";
                    cmd.Parameters.AddWithValue("@n", HesabId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DeletetblSandogh();
                    DisplayGharz();
                    HesabId = -1;
                    MessageBox.Show("عملیات حذف با موفقیت انجام شد.");
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در حذف اطلاعات حساب  رخ دارد!");
                }
            }

        }          
    }
}
