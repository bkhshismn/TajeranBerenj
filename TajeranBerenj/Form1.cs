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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        #region h
        private void Backup(string filename)
        {
            SqlConnection oconnection = null;
            try
            {
                string command = @"Backup DataBase [DBTajeranBerenj] To Disk='" + filename + "'";
                this.Cursor = Cursors.WaitCursor;
                SqlCommand ocommand = null;
                oconnection = new SqlConnection("Data source =.;initial catalog=DBTajeranBerenj;integrated security = true");
                if (oconnection.State != ConnectionState.Open)
                    oconnection.Open();
                ocommand = new SqlCommand(command, oconnection);
                ocommand.ExecuteNonQuery();
                this.Cursor = Cursors.Default;
                MessageBox.Show("پشتیبان گیری انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                oconnection.Close();
            }
        }
        private void Restore(string filename)
        {
            SqlConnection oconnection = null;
            try
            {
                string command = @"ALTER DATABASE [DBTajeranBerenj] SET SINGLE_USER with ROLLBACK IMMEDIATE " + " USE master " + " RESTORE DATABASE [DBTajeranBerenj] FROM DISK= N'" + filename + "'WITH RECOVERY, REPLACE";
                this.Cursor = Cursors.WaitCursor;
                SqlCommand ocommand = null;
                oconnection = new SqlConnection("Data Source=.;Initial Catalog=DBTajeranBerenj;Integrated Security=True");
                if (oconnection.State != ConnectionState.Open)
                    oconnection.Open();
                ocommand = new SqlCommand(command, oconnection);
                ocommand.ExecuteNonQuery();
                this.Cursor = Cursors.Default;
                MessageBox.Show("باز نشانی پشتیبان  انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : ", ex.Message);
            }
            finally
            {
                oconnection.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
           
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmUser().ShowDialog();
        }
        private void btnAddCostomer_Click(object sender, EventArgs e)
        {
            new frmMoshtari().ShowDialog();
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            new frmKharidShali().ShowDialog();
        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            new frmTabdil().ShowDialog();
        }
        private void btnMahsol_Click(object sender, EventArgs e)
        {
            new frmAnbar().ShowDialog();
        }
        private void btnGharz_Click(object sender, EventArgs e)
        {
            new frmGharz().ShowDialog();
        }
        private void buttonX10_Click(object sender, EventArgs e)
        {
            new frmForosh().ShowDialog();
        }
        private void btnKharid_Click(object sender, EventArgs e)
        {
            new frmKharid().ShowDialog();
        }
        private void buttonX8_Click(object sender, EventArgs e)
        {
            new frmMaliMoshtari().ShowDialog();
        }
        private void btnPardakhtChk_Click(object sender, EventArgs e)
        {
            new frmPardakhtCheck().ShowDialog();
        }
        private void btnBackUp_Click(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            SaveFileDialog SaveBackUp = new SaveFileDialog();
            string filename = string.Empty;
            SaveBackUp.OverwritePrompt = true;
            SaveBackUp.Filter = @"SQL Backup Files ALL Files (*.*) |*.*| (*.Bak)|*.Bak";
            SaveBackUp.DefaultExt = "Bak";
            SaveBackUp.FilterIndex = 1;
            SaveBackUp.FileName = DateTime.Now.ToString("TajeranBerenj dd-MM-yyyy_HH-mm-ss");
            SaveBackUp.Title = "Backup SQL File";
            if (SaveBackUp.ShowDialog() == DialogResult.OK)
            {
                filename = SaveBackUp.FileName;
                Backup(filename);
            }
        }
        private void btbRestor_Click(object sender, EventArgs e)
        {
            string filename = string.Empty;
            OpenFileDialog OpenBackUp = new OpenFileDialog();
            OpenBackUp.Filter = @"SQL Backup Files ALL Files (*.*) |*.*| (*.Bak)|*.Bak";
            OpenBackUp.FilterIndex = 1;
            OpenBackUp.Filter = @"SQL Backup Files (*.*)|";

            OpenBackUp.FileName = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            if (OpenBackUp.ShowDialog() == DialogResult.OK)
            {
                filename = OpenBackUp.FileName;
                Restore(filename);
            }
        }
        private void buttonX7_Click(object sender, EventArgs e)
        {
            new frmHazine().ShowDialog();
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            new frmJbJAnbar().ShowDialog();
        }
        private void btnKol_Click(object sender, EventArgs e)
        {
            new frmGozareshKol().ShowDialog();
        }
        private void btnReportCstmr_Click(object sender, EventArgs e)
        {
            new GozareshMoshtari().ShowDialog();
        }
        private void btnBedehkar_Click(object sender, EventArgs e)
        {
            new frmBedBes().ShowDialog();
        }
        #endregion
        void InsertBedHesab(int MoshtariID, int Mablagh)
        {
            string no = "بدهی سال پیش";
            con.Close();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "insert into tblHesab (MoshtariID,ReferNo,bed,bes,Tozihat)values(@MoshtariID,@ReferNo,@bed," + 0 + ",@Tozihat)";
            cmd.Parameters.AddWithValue("@MoshtariID", MoshtariID);
            cmd.Parameters.AddWithValue("@ReferNo", no);
            cmd.Parameters.AddWithValue("@Tozihat", "بدهی از سال پیش");
            cmd.Parameters.AddWithValue("@bed", Mablagh);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void InsertBedSandogh(int MoshtariID, int Mablagh)
        {
            string no = "بدهی سال پیش";
            con.Close();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "insert into tblSandogh (MoshtariID,ReferNo,bed,bes)values(@MoshtariID,@ReferNo," + 0 + ",@bes)";
            cmd.Parameters.AddWithValue("@MoshtariID", MoshtariID);
            cmd.Parameters.AddWithValue("@ReferNo", no);
            cmd.Parameters.AddWithValue("@bes", Mablagh);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void InsertBesHesab(int MoshtariID, int Mablagh)
        {
            string no = "طلب سال پیش";
            con.Close();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "insert into tblHesab (MoshtariID,ReferNo,bes,bed,Tozihat)values(@MoshtariID,@ReferNo,@bes," + 0 + ",@Tozihat)";
            cmd.Parameters.AddWithValue("@MoshtariID", MoshtariID);
            cmd.Parameters.AddWithValue("@ReferNo", no);
            cmd.Parameters.AddWithValue("@Tozihat", "طلب از سال پیش");
            cmd.Parameters.AddWithValue("@bes", Mablagh);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }    
        void InsertBesSandogh(int MoshtariID, int Mablagh)
        {
            string no = "طلب سال پیش";
            con.Close();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "insert into tblSandogh (MoshtariID,ReferNo,bes,bed)values(@MoshtariID,@ReferNo," + 0 + ",@bed)";
            cmd.Parameters.AddWithValue("@MoshtariID", MoshtariID);
            cmd.Parameters.AddWithValue("@ReferNo", no);
            cmd.Parameters.AddWithValue("@bed",Mablagh);
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
                    InsertBedHesab(id[i], bedbes[0]);
                    InsertBedSandogh(id[i], bedbes[0]);
                }
                else if (bedbes[1] > 0)
                {
                    InsertBesHesab(id[i], bedbes[1]);
                    InsertBesSandogh(id[i], bedbes[1]);
                }
            }
            CrearTables1("tblHesab");
            CrearTables1("tblSandogh");
        }
        void CrearTables1(string tblName)
        {
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Delete from " + tblName + " where ReferNo != N'بدهی سال پیش' and ReferNo != N'طلب سال پیش'";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void CrearTables(string tblName)
        {
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Delete from " + tblName;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void btnBastanHesab_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به بستن حساب سال جاری هستید؟ ", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var result1 = MessageBox.Show(".در صورت موافقت دیگر قادر به برگشت به حساب سال پیش نیستید\n آیا موافقید؟ ", "هشدار", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    Backup("d:\\Backup\\" + DateTime.Now.ToString("TajeranBerenj dd-MM-yyyy_HH-mm-ss"));
                    //Clear Tabals//////////////////////////////////////////////////////////////
                    Bedehkaran();
                    CrearTables("tblAnbarDone");
                    CrearTables("tblAnbarDone");
                    CrearTables("tblAnbarNimdone");
                    CrearTables("tblAnbarSabosDo");
                    CrearTables("tblAnbarSabosNarm");
                    CrearTables("tblEnteghalDone");
                    CrearTables("tblForoshDone");
                    CrearTables("tblForoshNimdone");
                    CrearTables("tblForoshSabosDo");
                    CrearTables("tblForoshSabosNarm");
                    CrearTables("tblForoshShali");
                    CrearTables("tblHazine");
                    CrearTables("tblKharidDone");
                    CrearTables("tblKharidNimdone");
                    CrearTables("tblKharidSabosDo");
                    CrearTables("tblKharidSabosNarm");
                    CrearTables("tblKharidShali");
                    CrearTables("tblMaliMoshtari");
                    CrearTables("tblTabdil");
                    CrearTables("tblCheck");
                    CrearTables("tblAnbarShali");
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            new frmCheck().ShowDialog();
        }
    }
}
