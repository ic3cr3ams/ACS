using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace proyekprobis
{
    public partial class Admin : UserControl
    {
        public static string idCabangLogin = "", usernameLogin = "", posisi = "";
        String connStr;
        OracleConnection conn;
        OracleCommand query;
        OracleDataAdapter adapter;
        DataSet dataset;
        OracleCommand stp;
        String mode;
        OracleCommand cmd;
        DataSet datasetDetail;
        OracleCommandBuilder builder;
        OracleDataReader reader;
        Boolean ketemu = false;
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string nama = textBox3.Text;
            string jabatan = comboBox1.Text;
            string alamat = textBox4.Text;
            string notelp = textBox5.Text;

            try
            {
                cmd = new OracleCommand("INSERT INTO Pegawai(USERNAME_USER, PASSWORD, NAMA_USER, POSISI, ALAMAT_USER,KONTAK_USER) VALUES (:puser, :ppass, :pnama, :ppos, :palamat,:pkontak)", conn);
                cmd.Parameters.Add(new OracleParameter(":puser", OracleDbType.Varchar2, 1024, username, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter(":ppass", OracleDbType.Varchar2, 1024, password, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter(":pnama", OracleDbType.Varchar2, 1024, nama, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter(":ppos", OracleDbType.Varchar2, 200, jabatan, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter(":palamat", OracleDbType.Varchar2, 1024, alamat, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter(":pkontak", OracleDbType.Varchar2, 12, notelp, ParameterDirection.Input));

               

                cmd.ExecuteNonQuery();

                MessageBox.Show("Insert Successful");
            }
            catch (Exception)
            {
                MessageBox.Show("Insert Error");
                // throw;
            }
            loadAdmin();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            connStr = "Data Source=XE; User ID=acs; Password=acs";
            conn = new OracleConnection(connStr);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Error");
                // throw;
            }
            loadAdmin();

        }
        void loadAdmin()
        {
            query = new OracleCommand("SELECT username_user,  NAMA_USER,  POSISI, ALAMAT_USER,Kontak_user FROM PEGAWAI", conn);
            adapter = new OracleDataAdapter(query);
            dataset = new DataSet();

            adapter.Fill(dataset, "PEGAWAI");

            dataGridView1.DataSource = dataset;
            dataGridView1.DataMember = "PEGAWAI";
        }
    }
}
