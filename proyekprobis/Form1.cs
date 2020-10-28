using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace proyekprobis
{
    public partial class Login : Form
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

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connStr = "Data Source=orcl; User ID=nus; Password=nus";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
       
        string pass;
        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox2.Text;

            MessageBox.Show("Test");
            //usernameLogin = textBox1.Text;
            //pass = textBox2.Text;
            if (ketemu == false)
            {
                conn.Close();
                conn.Open();

                cmd = new OracleCommand("select USERNAME_USER, password from pegawai where USERNAME_USER = '" + a + "' and password = '" + b + "'", conn);

                //cmd = new OracleCommand("SELECT * " +
                //"FROM Pegawai " +
                //"WHERE USERNAME_USER='" + usernameLogin + "'" +
                //"AND password = '" + pass + "' " +
                //"AND posisi = 'Admin'", conn);
                //cmd = new OracleCommand("select * from pegawai where USERNAME_USER = :user AND password = :pass", conn);
                //cmd.Parameters.Add(":user",textBox1.Text);
                //cmd.Parameters.Add(":pass", textBox2.Text);
                OracleDataReader reader = cmd.ExecuteReader();


                

                if (a =="admin" && b =="admin")
                {

                    MessageBox.Show("Berhasil login sebagai Manager");


                    Form2 r = new Form2();
                    r.Show();

                    this.Hide();
                    conn.Close();
                    ketemu = true;
                }


                //try
                //{
                    
                    
                    
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("tidak ada");
                //}
                
            }
            


            //cekLogin(usernameLogin,pass);

            //Form2 r = new Form2();
            //r.Show();

            //this.Hide();

        }
        
        void cekLogin(string usernam,string passw)
        {
            if (ketemu == false)
            {
                try
                {
                    conn.Close();
                    conn.Open();

                    cmd = new OracleCommand("SELECT  USERNAME_USER, password " +
                    "FROM Pegawai " +
                    "WHERE USERNAME_USER='" + usernam + "'" +
                    "AND password = '" + passw + "' " +
                    "AND posisi = 'Admin'", conn);
                    reader = cmd.ExecuteReader();

                    
                    posisi = "Admin";

                    if (reader.HasRows)
                    {
                        MessageBox.Show("Berhasil login sebagai Manager");
                       

                        Form2 r = new Form2();
                        r.Show();

                        this.Hide();
                        
                        ketemu = true;
                    }
                }
                catch (Exception ex)
                {

                }
                conn.Close();
            }
        }
    }
}
