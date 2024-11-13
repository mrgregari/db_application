using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class AddEm : Form
    {
        MySqlConnection connection;
        String name_s;
        String email_s;
        int post_s;
        string post_t;
        String table = "employee";
        public AddEm()
        {
            InitializeComponent();
        }

        private void AddEm_Load(object sender, EventArgs e)
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

        private void LoadPostTitles()
        {
            // Очищаем ListBox перед добавлением новых данных
            listBoxPosts.Items.Clear();

            // SQL запрос для извлечения всех должностей
            string query = "SELECT PostTitle FROM post"; // Замените на правильное имя столбца в таблице post

            // Создаем подключение к базе данных
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Выполняем команду и получаем результат
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Пока есть строки в результате
                        while (reader.Read())
                        {
                            // Добавляем каждую должность в ListBox
                            listBoxPosts.Items.Add(reader.GetString("PostTitle"));
                        }
                    }
                }

            }
            catch (Exception ex)
                {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
                }
            }

        private void name_TextChanged(object sender, EventArgs e)
        {
            name_s = name.Text;
        }

        private void listBoxPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            post_t = listBoxPosts.SelectedItem.ToString();

        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            email_s = email.Text;
        }

        public bool InsertRow(string values)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO employee (EmployeeName, EmployeeEmail, PostID) VALUES (" + values + ")",
                    connection);
                label2.Text = table + values;
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
            using (MySqlCommand cmd = new MySqlCommand("SELECT PostID FROM post WHERE PostTitle = '" + post_t + "'", connection))
            {
                label2.Text = "SELECT PostID FROM post WHERE PostTitle = '" + post_t + "'";
                object result = cmd.ExecuteScalar();  // Получаем одно значение (PostID)

                // Если результат не пустой, возвращаем PostID
                if (result != null)
                {
                    int postID = Convert.ToInt32(result);  // Преобразуем в int и сохраняем в переменную
                    post_s =  postID;  // Возвращаем значение переменной
                }
            }
            label1.Text = "'" + name_s + "'," + "'" + email_s + "'," + post_s;
            InsertRow("'" + name_s + "'," + "'" + email_s + "'," + post_s);
            this.Hide();

        }
    }
}
