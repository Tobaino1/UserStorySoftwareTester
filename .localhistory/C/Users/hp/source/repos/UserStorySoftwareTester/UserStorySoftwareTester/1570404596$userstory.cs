using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace UserStorySoftwareTester
{
    public partial class userstory : Form
    {
        public userstory()
        {
            InitializeComponent();
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=userstory");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tester ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["tester"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["date"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["app_name"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["requirements"].ToString();


            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void userstory_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
