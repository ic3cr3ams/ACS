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
    public partial class InputPart : UserControl
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
        public InputPart()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void InputPart_Load(object sender, EventArgs e)
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string kode = textBox1.Text;
            string nama = textBox2.Text;
            int jumlah = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            int harga = Convert.ToInt32(textBox4.Text);
            string kodeTempat = textBox5.Text;
            

            try
            {
                cmd = new OracleCommand("INSERT INTO INPUT_PART(KODE_BARANG, NAMA_BARANG, SATUAN_BARANG, HARGA_BARANG, KODE_TEMPAT) VALUES (:pkbar, :pnbar, :psbar, :phbar, :pktmpt)", conn);
                cmd.Parameters.Add(new OracleParameter(":pkbar", OracleDbType.Varchar2, 1024, kode, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter(":pnbar", OracleDbType.Varchar2, 1024, nama, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter(":psbar", OracleDbType.Int32, 255, jumlah, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter(":phbar", OracleDbType.Int32, 255, harga, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter(":pktmpt", OracleDbType.Varchar2, 1024, kodeTempat, ParameterDirection.Input));
                



                cmd.ExecuteNonQuery();

                MessageBox.Show("Insert Successful");
            }
            catch (Exception)
            {
                MessageBox.Show("Insert Error");
                // throw;
            }
        }
    }
}
