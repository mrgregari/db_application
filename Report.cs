using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace db_application
{
    public partial class Report : Form
    {
        MySqlConnection connection;
        String date;
        String result;
        String res;
        int desc;
        string desc_s;
        public Report()
        {
            InitializeComponent();
            
        }
        private void LoadPostTitles()
        {
            listBox1.Items.Clear();

            string query = "SELECT description FROM sociological_research"; // Замените на правильное имя столбца в таблице post
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader.GetString("description"));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
            }
        }
        public bool InsertRow(string values)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO reports (date, results, spentresources, researchid) VALUES (" + values + ")",
                    connection);
                if (command.ExecuteNonQuery() != 1)
                    throw new Exception("Что-то пошло не так при добавлении строки");
                MessageBox.Show("Строка успешно добавлена");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка добавления строки\nПричина: " + e.Message);
            }
            return false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            desc_s = listBox1.SelectedItem.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            date = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            result = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            res = textBox3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT researchid FROM sociological_research WHERE Description = '" + desc_s + "'", connection))
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    desc = Convert.ToInt32(result);
                }
            }
            InsertRow("'" + date + "','" + result + "','" + res + "'," + desc);
            this.Hide();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3307;username=root;password=12345678;database=sociological_research_db");

                connection.Open();
                LoadPostTitles();

            }
            catch
            {

            }
        }
    }
}
