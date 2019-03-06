using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace integroMySQL
{
    public partial class Form1 : Form
    {
        MySqlConnection cn = new MySqlConnection("server=localhost;userid=root;password=123654;database=cosmetic");
        MySqlDataAdapter adapmg, adapag;
        MySqlCommandBuilder buildmg, buildag;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                dataGridView2.DataSource = cn.GetSchema(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                adapmg = new MySqlDataAdapter("SELECT * FROM managers", cn);
                buildmg = new MySqlCommandBuilder(adapmg);
                
                DataTable dt = new DataTable();
                adapmg.Fill(dt);
                MySqlSchemaCollection myschema = new MySqlSchemaCollection(dt);
                
                dataGridView1.DataSource = cn.GetSchema();
                //textBox1.Text = myscript.;
                //adapter.Update((DataTable)dataGridView1.DataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapmg.Update((DataTable)dataGridView1.DataSource);
        }
    }
}
