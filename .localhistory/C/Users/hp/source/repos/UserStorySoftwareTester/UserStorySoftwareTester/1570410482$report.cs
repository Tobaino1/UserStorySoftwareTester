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
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
            InitializeComponent();
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=userstory");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from reports ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["tester"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["date"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["app_name"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["reports"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["improvements"].ToString();


            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void report_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new report().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("name can't be empty, please enter a value!");
                return;

            }
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("date can't be empty, please enter a value!");
                return;

            }

            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("application name can't be empty, please enter a value!");
                return;

            }
            if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("reports can't be empty, please enter a value!");
                return;

            }
            if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("module / function to be improved field can't be empty, please enter a value!");
                return;

            }

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=userstory");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO reports (`tester`, `date`, `app_name`, `reports`, `improvements`) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("user story has been succesfully inserted in the database, click refresh button");
            con.Close();
        }
    }
}