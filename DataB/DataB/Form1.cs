using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DataB
{
    public partial class Form1 : Form
    {
        private SqlDataAdapter dataAdapter;
        public Form1()
        {
            InitializeComponent();
           
        }
        MySqlConnection mysqlcnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1");
        DataSet datas = new DataSet();

        
        private void button1_Click(object sender, EventArgs e)
        {
            mysqlcnn.Close();
            MySqlDataAdapter mysqldt = new MySqlDataAdapter("select * from cocktail.Recipes", mysqlcnn);
            mysqlcnn.Open();
            mysqldt.Fill(datas, "Recipes");
            dataGridView1.DataSource = datas.Tables["Recipes"];

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        OleDbDataAdapter adapter;
        DataSet dataSet;
        BindingSource bindingSource;
       
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Validate();
           
           
           
        
        }

        public static void WriteString(string whatToWrite, string whatToWrite2, string whatToWrite3)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=1; database=cocktail";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string commandText = "insert into Recipes (id_Recipes,name_cocktail,description) values (?a,?b,?c)";
                using (MySqlCommand command = new MySqlCommand(commandText, connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("?a", whatToWrite);
                    command.Parameters.Add("?b", whatToWrite2);
                    command.Parameters.Add("?c", whatToWrite3);
                    command.ExecuteNonQuery();

                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            string s3 = textBox3.Text;
            if (s1 == "" || s2 == "" || s3 == "")
            {
                MessageBox.Show("Ошибка, не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            { MessageBox.Show("Запись успешно добавлена", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            WriteString(textBox1.Text, textBox2.Text, textBox3.Text);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            mysqlcnn.Close();
            MySqlDataAdapter mysqldt = new MySqlDataAdapter("select * from cocktail.products", mysqlcnn);
            mysqlcnn.Open();
            mysqldt.Fill(datas, "products");
            dataGridView2.DataSource = datas.Tables["products"];
        }
    }
}