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
    public partial class Searching : UserControl
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
        public Searching()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string kode = textBox1.Text;
            query = new OracleCommand("SELECT * FROM INPUT_PART where KODE_BARANG = '"+kode+"'", conn);
            adapter = new OracleDataAdapter(query);
            dataset = new DataSet();

            adapter.Fill(dataset, "INPUT_PART");

            dataGridView1.DataSource = dataset;
            dataGridView1.DataMember = "INPUT_PART";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadBarang();
        }

        private void Searching_Load(object sender, EventArgs e)
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
            loadBarang();
        }
        void loadBarang()
        {
            query = new OracleCommand("SELECT * FROM INPUT_PART", conn);
            adapter = new OracleDataAdapter(query);
            dataset = new DataSet();

            adapter.Fill(dataset, "INPUT_PART");

            dataGridView1.DataSource = dataset;
            dataGridView1.DataMember = "INPUT_PART";
        }

    }
}
