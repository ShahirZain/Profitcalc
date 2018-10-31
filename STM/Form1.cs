using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace STM
{
    public partial class Form1 : Form
    {
        conn conn = new conn();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }


        public void loadData() {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select * from SM",conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            this.dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into SM(Product_Name,Cost,Sell,Profit,DateTime) values(@Product_Name,@Cost,@Sell,@Profit,@DateTime)", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@Product_Name", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@Cost", Convert.ToInt32(this.textBox2.Text));
                cmd.Parameters.AddWithValue("@Sell", Convert.ToInt32(this.textBox3.Text));
                cmd.Parameters.AddWithValue("@Profit", (-1)*(Convert.ToInt32(this.textBox2.Text)- Convert.ToInt32(this.textBox3.Text)));
                cmd.Parameters.AddWithValue("@DateTime", dateTimePicker1.Value.ToString());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.sqlConnection1.Close();
            MessageBox.Show("Data submitted");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
