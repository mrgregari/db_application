using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_application
{
    public partial class ER : Form
    {
        MySqlConnection connection;
        int emp;
        string emp_s;
        int res;
        string res_s;
        public ER()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                emp_s = listBox1.SelectedItem.ToString();
            }
            catch
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                res_s = listBox2.SelectedItem.ToString();
            }
            catch
            {

            }
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
                            listBox2.Items.Add(reader.GetString("description"));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
            }
        }

        private void LoadS()
        {
            listBox1.Items.Clear();

            string query = "SELECT employeename FROM employee"; // Замените на правильное имя столбца в таблице post
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader.GetString("employeename"));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
            }
        }

        private void ER_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3307;username=root;password=12345678;database=sociological_research_db");

                connection.Open();
                LoadPostTitles();
                LoadS();

            }
            catch
            {

            }
        }

        public bool InsertRow(string values)
        {
            try
            {
                label1.Text = values;
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO employee_research (employeeid, researchid) VALUES (" + values + ")",
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT employeeid FROM employee WHERE employeename = '" + emp_s + "'", connection))
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    emp = Convert.ToInt32(result);
                }
            }
            using (MySqlCommand cmd = new MySqlCommand("SELECT researchid FROM sociological_research WHERE description = '" + res_s + "'", connection))
            {
                object result2 = cmd.ExecuteScalar();
                if (result2 != null)
                {
                    res = Convert.ToInt32(result2);
                }
            }
    
            InsertRow(emp + "," + res);
            this.Hide();
        }
    }
}
