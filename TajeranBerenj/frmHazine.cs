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
    public partial class frmHazine : Form
    {
        public frmHazine()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int MoshtariID = -1;
        string referNo = "هزینه";
        string no = "";
        string vaziat = "";
        int foroshID = -1;
        int referID = -1;
        #region
        void DisplayHazine()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblHazine]";
                adp.Fill(ds, "tblHazine");
                dgvHazine.DataSource = ds;
                dgvHazine.DataMember = "tblHazine";
                dgvHazine.Columns["HazineID"].HeaderText = "کد";
                dgvHazine.Columns["HazineID"].Width = 70;
                dgvHazine.Columns["Mablagh"].HeaderText = " مبلغ";
                dgvHazine.Columns["Mablagh"].Width = 70;
                dgvHazine.Columns["Sharh"].HeaderText = "شرح هزینه";
                dgvHazine.Columns["Sharh"].Width = 300;
                dgvHazine.Columns["Nahve"].HeaderText = "نحوه پرداخت";
                dgvHazine.Columns["Nahve"].Width = 70;
                dgvHazine.Columns["Tavasot"].HeaderText = "توسط";
                dgvHazine.Columns["Date"].HeaderText = "تاریخ هزینه";
                dgvHazine.Columns["Date"].Width = 70;
                dgvHazine.Columns["Discription"].HeaderText = "توضیحات";
                dgvHazine.Columns["Discription"].Width =300;
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        int GetReferID()
        {
            int TabdilID = -1;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblHazine";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            TabdilID = (int)dt.Rows[cunt - 1]["HazineID"];
            return TabdilID;
        }
        void InsertTotblSandoghPardakht(int id, int MoshtariId, int mablagh)
        {
            MoshtariID = -1;
            try
            {
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblSandogh (MoshtariID,ReferID,ReferNo,bes,bed)values(@MoshtariID,@ReferID,@ReferNo," + 0 + ",@bed)";
                cmd.Parameters.AddWithValue("@MoshtariID", MoshtariId);
                cmd.Parameters.AddWithValue("@ReferID", id);
                cmd.Parameters.AddWithValue("@ReferNo", referNo);
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
        void UpdateTotblSandoghPardakht(int mablagh)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update [tblSandogh] Set bes='" + mablagh + "' where ReferID=" + referID + " AND ReferNo=N'هزینه'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ویرایش اطلاعات صندوق  رخ دارد!");
            }
        }
        void DeletetblSandoghPardakht()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblSandogh] where ReferID=@n and ReferNo=N'هزینه'";
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
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            string nahve = "";
            if (chkNaghd.Checked == true)
            {
                nahve += chkNaghd.Text;
            }
            if (chkCard.Checked == true)
            {
                nahve += chkCard.Text;
            }
            if (chkCheck.Checked == true)
            {
                nahve += chkCheck.Text;
            }
            if (nahve == "")
            {
                MessageBox.Show(".لطفا نوع پردهخت را انتخاب کنین");
            }
            else
            {
                try
                {
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblHazine](Mablagh,Sharh,Tavasot,Date,Discription,Nahve)values(@Mablagh,@Sharh,@Tavasot,@Date,@Discription,@Nahve)";
                    cmd.Parameters.AddWithValue("@Mablagh", Convert.ToInt64(txtMablagh.Text.Replace(",", "")));
                    cmd.Parameters.AddWithValue("@Sharh", cmbSharh.Text);
                    cmd.Parameters.AddWithValue("@Tavasot", txtTavasot.Text);
                    cmd.Parameters.AddWithValue("@Nahve", nahve);
                    cmd.Parameters.AddWithValue("@Date", txtHazineDate.Text);
                    cmd.Parameters.AddWithValue("@Discription", txtCostDis.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ////////////////////////////////////////////////////////////////////////
                    //referID = GetReferID();
                    //InsertTotblSandoghPardakht(referID, MoshtariID, Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                    ////////////////////////////////////////////////////////////////////////
                    MessageBox.Show("ثبت با موفقیت انجام شد");
                    txtMablagh.Text = "0";
                    cmbSharh.Text = "";
                    txtCostDis.Text = "";
                    txtTavasot.Text = "";
                    DisplayHazine();
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در ثبت پرداخت نقدی وجود دارد");
                }
                cmbSharh.Focus();
            }
        }
        private void frmHazine_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            txtHazineDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            DisplayHazine();
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
        private void chkNaghd_CheckedChanged(object sender, EventArgs e)
        {
            chkCard.Checked = false;
            chkCheck.Checked = false;
        }
        private void chkCard_CheckedChanged(object sender, EventArgs e)
        {
            chkNaghd.Checked = false;
            chkCheck.Checked = false;
        }
        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            chkCard.Checked = false;
            chkNaghd.Checked = false;
        }
        private void dgvHazine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
                referID = (int)dgvHazine.Rows[e.RowIndex].Cells[0].Value;
                string ckk = "";
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblHazine where HazineID=" + referID;
                con.Open();
                adp.Fill(dt);
                this.txtMablagh.Text = dt.Rows[0]["Mablagh"].ToString();
                this.cmbSharh.Text = dt.Rows[0]["Sharh"].ToString();
                this.txtTavasot.Text = dt.Rows[0]["Tavasot"].ToString();
                ckk = dt.Rows[0]["Nahve"].ToString();
                if (ckk == "نقدی")
                {
                    chkNaghd.Checked = true;
                }
                else if (ckk == "کارت به کارت")
                {
                    chkCard.Checked = true;
                }
                else if (ckk == "چک")
                {
                    chkCheck.Checked = true;
                }
                this.txtHazineDate.Text = dt.Rows[0]["Date"].ToString();
                this.txtCostDis.Text = dt.Rows[0]["Discription"].ToString();
                con.Close();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید");
            //}
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string nahve = "";
            if (chkNaghd.Checked == true)
            {
                nahve += chkNaghd.Text;
            }
            if (chkCard.Checked == true)
            {
                nahve += chkCard.Text;
            }
            if (chkCheck.Checked == true)
            {
                nahve += chkCheck.Text;
            }
            if (referID != -1)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Update tblHazine Set Mablagh=N'" + Convert.ToInt32(txtMablagh.Text.Replace(",", "")) + "',Sharh=N'" + cmbSharh.Text + "',Tavasot=N'" + txtTavasot.Text + "',Date=N'" + txtHazineDate.Text + "',Discription=N'" + txtCostDis.Text + "',Nahve=N'" + nahve + "' where HazineID=" + referID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ////////////////////////////////////////////////////////////
                    //UpdateTotblSandoghPardakht(Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                    //////////////////////////////////////////////////////////
                    MessageBox.Show("ویرایش اطلاعات انجام شد.");
                    txtMablagh.Text = "0";
                    cmbSharh.Text = "";
                    txtCostDis.Text = "";
                    txtTavasot.Text = "";
                    DisplayHazine();
                }
                catch (Exception)
                {

                    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                }
            }
            else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (referID != -1)
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "delete from tblHazine where HazineID=" + referID;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        /////////////////////////////////////////////////////
                        //DeletetblSandoghPardakht();
                        ///////////////////////////////////////////////////
                        MessageBox.Show("حذف اطلاعات انجام شد.");
                        txtMablagh.Text = "0";
                        cmbSharh.Text = "";
                        txtCostDis.Text = "";
                        txtTavasot.Text = "";
                        DisplayHazine();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
            }
        }
    }
}
