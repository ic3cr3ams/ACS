using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyekprobis
{
    public partial class BookingSparePart : UserControl
    {
        public BookingSparePart()
        {
            InitializeComponent();
        }

        private void BookingSparePart_Load(object sender, EventArgs e)
        {
            textBox12.Visible = false;
            panel12.Visible = false;
            textBox11.Visible = false;
            panel11.Visible = false;
            dateTimePicker1.Visible = false;
            richTextBox1.Visible = false;
            button6.Visible = false;
            dataGridView2.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            bookservice(false);
           
            
            bookspare(true);


        }
        private void bookspare(bool x)
        {
            textBox1.Visible = x;
            textBox2.Visible = x;
            textBox3.Visible = x;
            textBox4.Visible = x;
            textBox5.Visible = x;
            textBox6.Visible = x;
            textBox7.Visible = x;
            textBox8.Visible = x;
            panel1.Visible = x;
            panel2.Visible = x;
            panel3.Visible = x;
            panel4.Visible = x;
            panel5.Visible = x;
            panel6.Visible = x;
            panel7.Visible = x;
            panel8.Visible = x;
            button4.Visible = x;
            button5.Visible = x;
            dataGridView1.Visible = x;
        }
        private void hist(bool a) {
            dataGridView2.Visible = a;
        }
        private void bookservice(bool j) {
            textBox12.Visible = j;
            panel12.Visible = j;
            textBox11.Visible = j;
            panel11.Visible = j;
            dateTimePicker1.Visible = j;
            richTextBox1.Visible = j;
            button6.Visible = j;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            bookservice(true);
            bookspare(false);
            hist(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bookservice(false);
            bookspare(false);
            hist(true);
        }
    }
}
