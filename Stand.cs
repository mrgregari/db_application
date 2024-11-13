using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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
    public partial class Stand : Form
    {
        MySqlConnection connection;
        String date;
        String req;
        public Stand()
        {
            InitializeComponent();
            
        }

        public bool InsertRow(string values)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO standarts (ValidityPeriod, Requirements) VALUES (" + values + ")",
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

        private void Stand_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3307;username=root;password=12345678;database=sociological_research_db");

                connection.Open();

            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertRow("'" + date + "','" + req + "'");
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            date = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            req = textBox2.Text;
        }
    }
}
