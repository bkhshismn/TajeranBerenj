using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TajeranBerenj
{
    class clsMethods
    {
        
        public string DataSource()
        {
            string Path = "";
            Path = File.ReadAllText(@"C:\Program Files\DataSource\DataSource.txt", Encoding.UTF8);
            return Path;
        }
        SqlConnection con = new SqlConnection();
        
        //--------------------------------------------------------------------------------------------------------------------------------------
        public void Titr(DataGridView dgvInSearch)
        {
            dgvInSearch.Columns[0].HeaderText = "کد مشتری";
            dgvInSearch.Columns[0].Width = 50;
            dgvInSearch.Columns[1].HeaderText = " نام";
            dgvInSearch.Columns[1].Width = 100;
            dgvInSearch.Columns[2].HeaderText = "تلفن";
            dgvInSearch.Columns[3].Visible = false;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        #region AnbarhayeMahsolat
        //Done kharid ya tabdil shode jadval tblAnbarDone
        public int GetKharidAnbarDone()
        {
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarDone where NoVorod= 'in'";
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
            report = vazn;
            return report;
        }
        //Done Forosh rafte jadval tblAnbarDone
        public int GetForoshAnbarDone()
        {
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarDone where NoVorod= 'out'";
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
            report = vazn;
            return report;
        }
        //Nimdone kharid va tabdil shode jadval tblAnbarNimdone
        public int GetKharidanbarNimdone()
        {
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarNimdone where NoVorod= 'in'";
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
            report = vazn;
            return report;
        }
        //Nimdone forosh rafte jaddval tblAnbarNimdone
        public int GetForoshAnbarNimdone()
        {
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarNimdone where NoVorod= 'out'";
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
            report = vazn;
            return report;
        }
        //sabosNarm forosh rafte jaddval tblAnbarSabosNarm
        public int GetKharidAnbarsabosNarm()
        {
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarSabosNarm where NoVorod= 'in'";
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
            report = vazn;
            return report;
        }
        //sabosNarm Kharid shodi jaddval tblAnbarSabosNarm     
        public int GetForoshAnbarSabosNarm()
        {
            int report = 0;
            con.ConnectionString = DataSource();
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
            report = vazn;
            return report;
        }
        public int GetKharidAnbarSabosDo()
        {
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarSabosDo where NoVorod= 'in'";
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
            report = vazn;
            return report;
        }
        public int GetForoshAnbarSabosDo()
        {
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarSabosDo where NoVorod= 'out'";
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
            report = vazn;
            return report;
        }
        //Done kharid jadval tblAnbarShali
        public int GetKharidShali()
        {
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarShali where NoVorod= 'in'";
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
            report = vazn;
            return report;
        }
        //Done Forosh rafte jadval tblAnbarShali
        public int GetForoshShali()
        {
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarShali where NoVorod = 'Out-Tabdil' or  NoVorod= 'Out-Forosh'";
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
            report = vazn;
            return report;
        }
        #region Filter
        public int FilterGetKharidAnbarDone(string type, string AnbarName)
        {
            type = "'" + type + "'";
            AnbarName = "'" + AnbarName + "'";
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarDone where NoVorod= 'in' and NoDone=N" + type + "And AnbarName=N" + AnbarName;
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
            report = vazn;
            return report;
        }
        //FilterDone Forosh rafte jadval tblAnbarDone
        public int FilterGetForoshAnbarDone(string type, string AnbarName)
        {
            type = "'" + type + "'";
            AnbarName = "'" + AnbarName + "'";
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarDone where NoVorod= 'out' and NoDone=N" + type + "And AnbarName=" + AnbarName;
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
            report = vazn;
            return report;
        }
        //FilterNimdone kharid va tabdil shode jadval tblAnbarNimdone
        public int FilterGetKharidanbarNimdone(string type, string AnbarName)
        {
            type = "'" + type + "'";
            AnbarName = "'" + AnbarName + "'";
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarNimdone where NoVorod= 'in' and NoNimdone=N" + type + "And AnbarName=N" + AnbarName;
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
            report = vazn;
            return report;
        }
        //FilterNimdone forosh rafte jaddval tblAnbarNimdone
        public int FilterGetForoshAnbarNimdone(string type, string AnbarName)
        {
            type = "'" + type + "'";
            AnbarName = "'" + AnbarName + "'";
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarNimdone where NoVorod= 'out'and NoNimdone=N" + type + "And AnbarName=N" + AnbarName;
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
            report = vazn;
            return report;
        }
        //FiltersabosNarm forosh rafte jaddval tblAnbarSabosNarm
        public int FilterGetKharidAnbarsabosNarm( string AnbarName)
        {
            AnbarName = "'" + AnbarName + "'";
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarSabosNarm where NoVorod= 'in' And AnbarName=N" + AnbarName;
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
            report = vazn;
            return report;
        }
        //FiltersabosNarm Kharid shodi jaddval tblAnbarSabosNarm
        public int FilterGetForoshAnbarSabosNarm(string AnbarName)
        {
            AnbarName = "'" + AnbarName + "'";
            int report = 0;
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarSabosNarm where NoVorod= 'out' And AnbarName=N" + AnbarName;
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
            report = vazn;
            return report;
        }
        #endregion
        #endregion
        //
       public int [] BedBesHesab(int MoshtariID)
        {
            int[] report = new int[2];
            con.ConnectionString = DataSource();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblHesab where MoshtariID=" + MoshtariID;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int bed = 0;
            int bes = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    bed += Convert.ToInt32(dt.Rows[i]["bed"]);
                    bes += Convert.ToInt32(dt.Rows[i]["bes"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            if ((bed-bes) > 0)
            {
                report[0] = bed-bes;
                report[1] = 0;
            }
            if ((bed - bes) < 0)
            {
                report[1] = (bed - bes)*-1;
                report[0] = 0;
            }
            
            return report;
        }
        public int Daramad()
        {
            int bed = 0;
            int bes = 0;
            try
            {
                int[] report = new int[2];
                con.ConnectionString = DataSource();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblSandogh";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        bed += Convert.ToInt32(dt.Rows[i]["bed"]);
                        bes += Convert.ToInt32(dt.Rows[i]["bes"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            return bes - bed;
        }
        public int Gharz()
        {
            int bes = 0;
            try
            {
                con.ConnectionString = DataSource();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblSandogh where ReferNo=N'قرض'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;
                int bed = 0;

                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        bes += Convert.ToInt32(dt.Rows[i]["bes"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {

                throw;
            }
           
            return bes;
        }
        public int Hazine()
        {
            int hazine = 0;
            try
            {
                con.ConnectionString = DataSource();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblHazine";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;
                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        hazine += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
            }
           
            return hazine;
        }
        public int Talab()
        {
            int talab = 0;
            try
            {
                int[] report = new int[2];
                con.ConnectionString = DataSource();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblSandogh";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;
                int bed = 0;
                int bes = 0;


                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        bed += Convert.ToInt32(dt.Rows[i]["bed"]);
                        bes += Convert.ToInt32(dt.Rows[i]["bes"]);

                        talab = bes - bed;
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
                if (talab < 0)
                {
                    talab = 0;
                }
            }
            catch (Exception)
            {
            }
           
            return talab;
        }
        public int VaznKharidShali()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarShali where NoVorod=N'in' and ReferNo=N'خرید'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;
               
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
            catch (Exception)
            {

            }
           
            return vazn;
        }
        public int VaznForoshShali()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarShali where NoVorod=N'Out-Forosh' and ReferNo=N'فروش'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {
            }
            
            return vazn;
        }
        public int VaznTabdilShali()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarShali where NoVorod=N'Out-Tabdil' ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {

                throw;
            }
           
            return vazn;
        }
        public int MablaghForoshShali()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblForoshShali ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;
               
                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        vazn += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
            }
           
            return vazn;
        }
        public int MablaghKharidShali()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblKharidShali ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;
               
                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        vazn += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
            }
           
            return vazn;
        }
        //Done///////////////////////////////////////////////////////////////////////////
        public int VaznKharidDone()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarDone where NoVorod=N'in' and ReferNo=N'خرید'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {

            }

            return vazn;
        }
        public int VaznForoshDone()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarDone where NoVorod=N'out' and ReferNo=N'فروش'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {
            }

            return vazn;
        }
        public int VaznTabdilDone()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarDone where NoVorod=N'in' and ReferNo=N'تبدیل'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {
            }

            return vazn;
        }
        public int MablaghForoshDone()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblForoshDone ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        vazn += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
            }

            return vazn;
        }
        public int MablaghKharidDone()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblKharidDone ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        vazn += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
            }

            return vazn;
        }
        //NimDone/////////////////////////////////////////////////////////////////////////
        public int VaznKharidNimDone()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarNimDone where NoVorod=N'in' and ReferNo=N'خرید'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {

            }

            return vazn;
        }
        public int VaznForoshNimDone()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarNimDone where NoVorod=N'out' and ReferNo=N'فروش'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {
            }

            return vazn;
        }
        public int VaznTabdilNimDone()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarNimDone where NoVorod=N'in' and ReferNo=N'تبدیل'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {
            }

            return vazn;
        }
        public int MablaghForoshNimDone()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblForoshNimDone ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        vazn += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
            }

            return vazn;
        }
        public int MablaghKharidNimDone()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblKharidNimDone ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        vazn += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
            }

            return vazn;
        }
        //SabosNarm///////////////////////////////////////////////////////////////////////////////
        public int VaznKharidSabosNarm()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarSabosNarm where NoVorod=N'in' and ReferNo=N'خرید'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {

            }

            return vazn;
        }
        public int VaznForoshSabosNarm()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarSabosNarm where NoVorod=N'out' and ReferNo=N'فروش'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {
            }

            return vazn;
        }
        public int VaznTabdilSabosNarm()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarSabosNarm where NoVorod=N'in' and ReferNo=N'تبدیل'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {
            }

            return vazn;
        }
        public int MablaghForoshSabosNarm()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblForoshSabosNarm ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        vazn += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
            }

            return vazn;
        }
        public int MablaghKharidSabosNarm()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblKharidSabosNarm ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        vazn += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
            }

            return vazn;
        }
        //SabosDo///////////////////////////////////////////////////////////////////////////////
        public int VaznKharidSabosDo()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarSabosDo where NoVorod=N'in' and ReferNo=N'خرید'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {

            }

            return vazn;
        }
        public int VaznForoshSabosDo()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblAnbarSabosDo where NoVorod=N'out' and ReferNo=N'فروش'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

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
            catch (Exception)
            {
            }

            return vazn;
        }
        public int MablaghForoshSabosDo()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblForoshSabosDo ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        vazn += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
            }

            return vazn;
        }
        public int MablaghKharidSabosDo()
        {
            int vazn = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblKharidSabosDo ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        vazn += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
            }

            return vazn;
        }

    }
}
