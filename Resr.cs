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

namespace db_application
{
    public partial class Resr : Form
    {
        MySqlConnection connection;
        String desc;
        String res;
        int appl;
        string appl_s;
        int part;
        string part_s;
        public Resr()
        {
            InitializeComponent();
        }

        private void Resr_Load(object sender, EventArgs e)
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

        private void LoadPostTitles()
        {
            listBox1.Items.Clear();

            string query = "SELECT topic FROM application"; // Замените на правильное имя столбца в таблице post
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader.GetString("topic"));
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

            string query = "SELECT list FROM participants"; // Замените на правильное имя столбца в таблице post
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader.GetString("list"));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT applicationid FROM application WHERE topic = '" + appl_s + "'", connection))
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    appl = Convert.ToInt32(result);
                }
            }
            using (MySqlCommand cmd = new MySqlCommand("SELECT participantid FROM participants WHERE list = '" + part_s + "'", connection))
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    part = Convert.ToInt32(result);
                }
            }
            InsertRow("'" + desc + "','" + res + "'," + appl + "," + part);
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            desc = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            res = textBox2.Text;
        }

        public bool InsertRow(string values)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO sociological_research (description, result, applicationid, participantid) VALUES (" + values + ")",
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

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            appl_s = listBox2.SelectedItem.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            part_s = listBox1.SelectedItem.ToString();
        }
    }
}
