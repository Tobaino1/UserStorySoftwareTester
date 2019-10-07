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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
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

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("field can't be empty, please enter a value!");
                return;

            }


            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("field can't be empty, please enter a value!");
                return;

            }

            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("field can't be empty, please enter a value!");
                return;

            }
            if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("field can't be empty, please enter a value!");
                return;

            }

            if (textBox5.Text == string.Empty)
            {
                MessageBox.Show("field can't be empty, please enter a value!");
                return;

            }
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=userstory");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO reports (`tester`, `date`, `app_name`, `reports`, `improvements`) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("record has been succesfully inserted in the database, click refresh button");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("Application name field can't be empty, please enter the application name & click delete button in the order to delete the record!");
                return;

            }

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=userstory");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `reports` WHERE app_name = '" + textBox3.Text + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("record has been successfully deleted, click refresh button");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("field can't be empty, please enter a value!");
                return;

            }


            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("field can't be empty, please enter a value!");
                return;

            }

            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("field can't be empty, please enter a value!");
                return;

            }
            if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("field can't be empty, please enter a value!");
                return;

            }

            if (textBox5.Text == string.Empty)
            {
                MessageBox.Show("field can't be empty, please enter a value!");
                return;

            }


            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=erp_crm");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `reports` SET `testter`= '" + textBox1.Text + "',`date`= '" + textBox2.Text + "',`app_name`= '" + textBox3.Text + "',`reports`= '" + textBox4.Text + "',`improvements`= '" + textBox5.Text + "' WHERE app_name = '" + textBox3.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("record has been successfully updated, click refresh button");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new ReportForm().Show();
            this.Hide();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
