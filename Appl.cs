﻿using MySql.Data.MySqlClient;
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
    public partial class Appl : Form
    {
        MySqlConnection connection;
        String date;
        String goals;
        String topic;
        int name;
        string name_s;
        public Appl()
        {
            InitializeComponent();
        }

        private void Appl_Load(object sender, EventArgs e)
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
            listBox1.Items.Clear();

            string query = "SELECT clientname FROM client"; // Замените на правильное имя столбца в таблице post
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader.GetString("clientname"));
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

                    "INSERT INTO application (date, goals, topic, clientid) VALUES (" + values + ")",
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            date = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            goals = textBox2.Text;
        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            topic = textBox3.Text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            name_s = listBox1.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT clientid FROM client WHERE clientname = '" + name_s + "'", connection))
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    name = Convert.ToInt32(result);
                }
            }
            InsertRow("'" + date + "','" + goals + "','" + topic + "'," + name);
            this.Hide();

        }
    }
}
