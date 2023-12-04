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
    public partial class frmGozareshKol : Form
    {
        public frmGozareshKol()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int bed = 0;
        int bes = 0;
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
                bed += bedbes[0];
                bes += bedbes[1];
            }
        }
        private void frmGozareshKol_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            int talab = mt.Talab();
            con.ConnectionString = @"" + path + "";
            Bedehkaran();
            int Daramd = mt.Daramad();
            Daramd = Daramd - mt.Hazine();
            lblTalab.Text = bed.ToString("N0");
            lblBedehi.Text = bes.ToString("N0");
            lblDaramad.Text = Daramd.ToString("N0");
            lblHazine.Text = mt.Hazine().ToString("N0");
            lblMablaghGharz.Text = mt.Gharz().ToString("N0");
            //Shali////////////////////////////////////////////////////////////
            int VaznKharidShali = mt.VaznKharidShali();
            int VaznFroshShali = mt.VaznForoshShali();
            int VaznTabdilShali = mt.VaznTabdilShali();
            int MablaghForoshShali = mt.MablaghForoshShali();
            int MablaghKharidShali = mt.MablaghKharidShali();

            lblVaznKharidShali.Text= VaznKharidShali.ToString("N0");
            lblVaznFroshShali.Text= VaznFroshShali.ToString("N0");
            lblVaznTabdil.Text = VaznTabdilShali.ToString("N0");
            lblMablaghForoshShali.Text = MablaghForoshShali.ToString("N0");
            lblMablaghKharidShali.Text = MablaghKharidShali.ToString("N0");
            //Done//////////////////////////////////////////////////////////////
            int VaznKharidDone = mt.VaznKharidDone();
            int VaznFroshDone = mt.VaznForoshDone();
            int VaznTabdilDone = mt.VaznTabdilDone();
            int MablaghForoshDone = mt.MablaghForoshDone();
            int MablaghKharidDone = mt.MablaghKharidDone();

            lblWKDone.Text = VaznKharidDone.ToString("N0");
            lblWFDone.Text = VaznFroshDone.ToString("N0");
            lblWTabdilDone.Text = VaznTabdilDone.ToString("N0");
            lblMFDone.Text = MablaghForoshDone.ToString("N0");
            lblMKDone.Text = MablaghKharidDone.ToString("N0");
            //NimDone//////////////////////////////////////////////////////////////
            int VaznKharidNimDone = mt.VaznKharidNimDone();
            int VaznFroshNimDone = mt.VaznForoshNimDone();
            int VaznTabdilNimDone = mt.VaznTabdilNimDone();
            int MablaghForoshNimDone = mt.MablaghForoshNimDone();
            int MablaghKharidNimDone = mt.MablaghKharidNimDone();

            lblWKNDone.Text = VaznKharidNimDone.ToString("N0");
            lblWFNDone.Text = VaznFroshNimDone.ToString("N0");
            lblWTabdilNDone.Text = VaznTabdilNimDone.ToString("N0");
            lblMFNDone.Text = MablaghForoshNimDone.ToString("N0");
            lblMKNDone.Text = MablaghKharidNimDone.ToString("N0");
            //SabosNarm//////////////////////////////////////////////////////////////
            int VaznKharidSabosNarm = mt.VaznKharidSabosNarm();
            int VaznFroshSabosNarm = mt.VaznForoshSabosNarm();
            int MablaghForoshSabosNarm = mt.MablaghForoshSabosNarm();
            int MablaghKharidSabosNarm = mt.MablaghKharidSabosNarm();

            lblWKSabosNarm.Text = VaznKharidSabosNarm.ToString("N0");
            lblWFSabosNarm.Text = VaznFroshSabosNarm.ToString("N0");
            lblMFSabosNarm.Text = MablaghForoshSabosNarm.ToString("N0");
            lblMKSabosNarm.Text = MablaghKharidSabosNarm.ToString("N0");
            //SabosDo//////////////////////////////////////////////////////////////
            int VaznKharidSabosDo = mt.VaznKharidSabosDo();
            int VaznFroshSabosDo = mt.VaznForoshSabosDo();
            int MablaghForoshSabosDo = mt.MablaghForoshSabosDo();
            int MablaghKharidSabosDo = mt.MablaghKharidSabosDo();

            lblWKSabosDo.Text = VaznKharidSabosDo.ToString("N0");
            lblWFSabosDo.Text = VaznFroshSabosDo.ToString("N0");
            lblMFSabosDo.Text = MablaghForoshSabosDo.ToString("N0");
            lblMKSabosDo.Text = MablaghKharidSabosDo.ToString("N0");
        }
    }
}
