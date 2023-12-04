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
    public partial class frmForosh : Form
    {
        public frmForosh()
        {
            InitializeComponent();
        }
        clsMethods mt = new clsMethods();
        string path = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        void Disolay()
        {
            int kharidDone = mt.GetKharidAnbarDone();
            int kharidNDone = mt.GetKharidanbarNimdone();
            int kharidSabos = mt.GetKharidAnbarsabosNarm();
            int kharidSabos2 = mt.GetKharidAnbarSabosDo();
            int kharidShali = mt.GetKharidShali();


            lblDoneKol.Text = kharidDone.ToString("N0");
            lblNDoneKol.Text = kharidNDone.ToString("N0");
            lblSabosKol.Text = kharidSabos.ToString("N0");
            lblSabos2Kol.Text = kharidSabos2.ToString("N0");
            lblShalikol.Text = kharidShali.ToString("N0");

            int foroshDone= mt.GetForoshAnbarDone();
            int foroshNDone= mt.GetForoshAnbarNimdone();
            int foroshSabos= mt.GetForoshAnbarSabosNarm();
            int foroshSabos2= mt.GetForoshAnbarSabosDo();
            int foroshShali = mt.GetForoshShali();

            lblDoneMojod.Text = (kharidDone - foroshDone).ToString("N0");
            lblNDoneMojod.Text = (kharidNDone - foroshNDone).ToString("N0");
            lblSabosMojod.Text = (kharidSabos - foroshSabos).ToString("N0");
            lblSabos2Mojod.Text = (kharidSabos2 - foroshSabos2).ToString("N0");
            lblShaliMojod.Text = (kharidShali - foroshShali).ToString("N0");

            lblDoneFrosh.Text = foroshDone.ToString("N0");
            lblNDoneFrosh.Text = foroshNDone.ToString("N0");
            lblSabosFrosh.Text = foroshSabos.ToString("N0");
            lblSabos2Frosh.Text = foroshSabos2.ToString("N0");
            lblForoshShali.Text = foroshShali.ToString("N0");

        }
        private void frmForosh_Load(object sender, EventArgs e)
        {
            path = mt.DataSource();
            con.ConnectionString = @"" + path + "";
            Disolay();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            new frmForoshDone().ShowDialog();
        }

        private void btnNimdone_Click(object sender, EventArgs e)
        {
            new frmForoshNimdone().ShowDialog();
        }

        private void btnSabos_Click(object sender, EventArgs e)
        {
            new frmForoshSabosNarm().ShowDialog();
        }

        private void btnSabos2_Click(object sender, EventArgs e)
        {
            new frmForoshSabosDo().ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmForoshShali().ShowDialog();
        }
    }
}
