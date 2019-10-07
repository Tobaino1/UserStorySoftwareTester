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
                MessageBox.Show("user's requirement can't be empty, please enter a value!");
                return;

            }

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=userstory");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO tester (`name`, `date`, `app_name`, `requirements`) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("user story has been succesfully inserted in the database");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Phone number field can't be empty, please enter the customer phone no & click delete button in the order to delete the record!");
                return;

            }

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=userstory");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `tester` WHERE app_name = '" + textBox3.Text + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("record has been successfully deleted");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("name can't be empty, please enter a value!");
                return;

            }

            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("date can't be empty, please enter a value!");
            }

            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("application name can't be empty, please enter a value!");
                return;

            }

            if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("requirements can't be empty, please enter a value!");
                return;

            }


            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=userstory");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `tester` SET `tester`= '" + textBox1.Text + "',`date`= '" + textBox2.Text + "',`app_name`= '" + textBox3.Text + "',`requirements`= '" + textBox4.Text + "' WHERE app_name = '" + textBox3.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("record has been successfully updated");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
