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

namespace WindowsFormsApplication10 sdfas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rZDataSet2.worker". При необходимости она может быть перемещена или удалена.
            this.workerTableAdapter.Fill(this.rZDataSet2.worker);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rZDataSet2.sections". При необходимости она может быть перемещена или удалена.
            this.sectionsTableAdapter.Fill(this.rZDataSet2.sections);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rZDataSet2.factory". При необходимости она может быть перемещена или удалена.
            this.factoryTableAdapter.Fill(this.rZDataSet2.factory);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rZDataSet2.boss". При необходимости она может быть перемещена или удалена.
            this.bossTableAdapter.Fill(this.rZDataSet2.boss);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.workerTableAdapter.Update(this.rZDataSet2);
            this.bossTableAdapter.Update(this.rZDataSet2);
            this.factoryTableAdapter.Update(this.rZDataSet2);
            this.sectionsTableAdapter.Update(this.rZDataSet2);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection sql = new SqlConnection(@"Data Source = VAIO\SQLEXPRESS; Initial Catalog = RZ; Integrated Security = True");
            sql.Open();
            SqlDataReader tip = null;
            var com = new SqlCommand(textBox1.Text,sql);
            tip = com.ExecuteReader();
            using (tip)
            {
                var tabl = new DataTable();
                tabl.Load(tip);
                dataGridView1.AutoGenerateColumns=true;
                dataGridView1.DataSource = tabl;
            }
            sql.Close();
            tip.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "sections") {                 
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = sectionsBindingSource; }
            else if (comboBox1.Text == "factory") {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = factoryBindingSource; }
            else if (comboBox1.Text == "boss") {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = bossBindingSource;            }
            else if (comboBox1.Text == "worker") {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = workerBindingSource;           }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
