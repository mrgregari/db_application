﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace db_application
{
    public partial class EmployeeForm : Form
    {
        string[] tableOldNames = new string[]
        {
            "Employee",
            "application",
            "client",
            "participants",
            "post",
            "reports",
            "standarts",
            "research_plan",
            "sociological_research",
            "employee_research",
            "standarts_research"
        };
        string[] tableNames = new string[]
        {
            "sociological_research_db.view_employee_with_post",
            "sociological_research_db.view_application_with_client",
            "sociological_research_db.view_client",
            "sociological_research_db.view_participants",
            "sociological_research_db.view_posts",
            "sociological_research_db.view_reports_with_research_description",
            "sociological_research_db.view_standarts",
            "sociological_research_db.view_plans_with_research_description",
            "sociological_research_db.view_sociological_research_with_topic_and_participants_list",
            "sociological_research_db.view_research_employee",
            "sociological_research_db.view_research_standarts"
        };

        MySqlConnection connection;
        MySqlDataAdapter adapter;
        DataSet ds;
        string currentTable;
        private int userRoleId;

        public EmployeeForm(int roleid)
        {
            
            InitializeComponent();
            userRoleId = roleid;

            // Вывод сообщения о роли пользователя
            if (userRoleId == 1)
            {
                MessageBox.Show("Роль пользователя: Администратор");
            }
            else if (userRoleId == 2)
            {
                MessageBox.Show("Роль пользователя: Пользователь");
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                connection = new MySqlConnection("server=localhost;port=3307;username=root;password=12345678;database=sociological_research_db");
                
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    connectionLabel.Text = "Соединение с базой данных установлено";
                }
                else
                {
                    connectionLabel.Text = "Нет соединения с базой данных";
                }
                employeesDataGridView.CellValueChanged += employeesDataGridView_CellValueChanged;
                employeesDataGridView.UserDeletingRow += employeesDataGridView_UserDeletingRow;

            }
            catch
            {

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void employeesDataGridView_UserDeletingRow(object sender,
    DataGridViewRowCancelEventArgs e)
        {
            if (userRoleId == 2)
            {
                MessageBox.Show("Недостаточно прав. Требуется роль Администратора");
            }
            else
            {
                DataGridViewRow changedRow = e.Row;
                //label2.Text = e.Row.ToString();
                string primaryKey = GetPrimaryKeyNames(currentTable)[0];
                string id = changedRow.Cells[primaryKey].Value.ToString();



                if (currentTable != "employee_research" && currentTable != "standarts_research")
                {
                    DeleteRow(currentTable, primaryKey, id);
                }
                else
                {
                    string value1 = changedRow.Cells[GetPrimaryKeyNames(currentTable)[0]].Value.ToString();
                    string value2 = changedRow.Cells[GetPrimaryKeyNames(currentTable)[1]].Value.ToString();


                    string st1 = GetPrimaryKeyNames(currentTable)[0] + " = " + value1;
                    string st2 = GetPrimaryKeyNames(currentTable)[1] + " = " + value2;

                    DeleteRow2keys(currentTable, st1, st2);
                }
            }
            
        }


        private void employeesDataGridView_CellValueChanged(
            object sender, DataGridViewCellEventArgs e)
        {
            if (userRoleId == 2)
            {
                MessageBox.Show("Недостаточно прав. Требуется роль Администратора");
            }
            else
            {
                DataGridViewRow changedRow = employeesDataGridView.Rows[e.RowIndex];
                string primaryKey = GetPrimaryKeyNames(currentTable)[0];
                string id = changedRow.Cells[primaryKey].Value.ToString();
                string changedColumnName = employeesDataGridView.Columns[e.ColumnIndex].Name.ToString();
                var newValue = changedRow.Cells[e.ColumnIndex].Value.ToString();


                if (currentTable != "employee_research" && currentTable != "standarts_research")
                {
                    UpdateRow(currentTable, primaryKey, changedColumnName, id, newValue);
                }
                else
                {
                    string value1 = changedRow.Cells[GetPrimaryKeyNames(currentTable)[0]].Value.ToString();
                    string value2 = changedRow.Cells[GetPrimaryKeyNames(currentTable)[1]].Value.ToString();
                    string st1;
                    if (changedColumnName == GetPrimaryKeyNames(currentTable)[0])
                    {
                        st1 = GetPrimaryKeyNames(currentTable)[1] + " = " + value2;
                    }
                    else
                    {
                        st1 = GetPrimaryKeyNames(currentTable)[0] + " = " + value1;
                    }

                    //label2.Text = st1;
                    UpdateRow2keys(currentTable, st1, changedColumnName, newValue);
                }

            }
            
            
        }
        private string[] GetPrimaryKeyNames(string tableName)
        {
            List<string> primaryKeys = new List<string>();

            try
            {
                using (MySqlCommand command = new MySqlCommand(
                    "SELECT COLUMN_NAME " +
                    "FROM information_schema.KEY_COLUMN_USAGE " +
                    "WHERE TABLE_SCHEMA = @dbName AND TABLE_NAME = @tableName AND CONSTRAINT_NAME = 'PRIMARY'", connection))
                {
                    command.Parameters.AddWithValue("@dbName", "sociological_research_db");
                    command.Parameters.AddWithValue("@tableName", tableName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            primaryKeys.Add(reader.GetString("COLUMN_NAME"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении названия первичных ключей: " + ex.Message);
            }

            return primaryKeys.ToArray();
        }



        public bool UpdateRow(string table, string primarykey, string column, string id, string value)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(
                    "UPDATE " + table + " SET " + column + "=\"" + value + "\" WHERE " + primarykey + "=" + id,
                    connection);

                if (command.ExecuteNonQuery() != 1)
                    throw new Exception("Строки не существует в базе данных");

                MessageBox.Show("Данные успешно изменены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Incorrect date value: \'") &&
                    e.Message.Contains("\' for column \'") &&
                    e.Message.Contains("\' at row "))
                {
                    try
                    {
                        MySqlCommand command = new MySqlCommand(
                        "UPDATE " + table + " SET " + column + "=STR_TO_DATE(\"" + value + "\",\"%d.%m.%Y 0:%i:%s\") WHERE " + primarykey + "=" + id,
                        connection);

                        if (command.ExecuteNonQuery() != 1)
                            throw new Exception("Строки не существует в базе данных");
                        MessageBox.Show("Данные успешно изменены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("Ошибка изменения строки\nПричина: " + e1.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка изменения строки\nПричина: " + e.Message);
                }
            }
            return false;
        }

        public bool UpdateRow2keys(string table, string st1, string column, string value)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("UPDATE " + table + " SET " + column + "=" + value + " WHERE " + st1, connection);
                if (command.ExecuteNonQuery() != 1)
                    throw new Exception("Строки не существует в базе данных");
                MessageBox.Show("Данные успешно изменены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка изменения строки\nПричина: " + e.Message);
            }
            return false;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                employeesDataGridView.AllowUserToDeleteRows = true;
                employeesDataGridView.ReadOnly = false;
                currentTable = tableOldNames[tablesListBox.SelectedIndex];
                PrintTable(tableOldNames[tablesListBox.SelectedIndex]);

            }
            else
            {
                employeesDataGridView.AllowUserToDeleteRows = false;
                employeesDataGridView.ReadOnly = true;
                currentTable = tableNames[tablesListBox.SelectedIndex];
                PrintTable(tableNames[tablesListBox.SelectedIndex]);
            }

            switch (tablesListBox.SelectedIndex)
            {
                case 0:
                    label1.Text = "Введите имя сотрудника";
                    break;
                case 1:
                    label1.Text = "Введите название компании клиента";
                    break;
                case 2:
                    label1.Text = "Введите название компании клиента";
                    break;
                case 3:
                    label1.Text = "Введите имя участника";
                    break;
                case 4:
                    label1.Text = "Введите название должности";
                    break;
                case 5:
                    label1.Text = "Введите год отчета";
                    break;
                case 6:
                    label1.Text = "Введите год, до которого действует стандарт";
                    break;
                case 7:
                    label1.Text = "Введите этап исследования";
                    break;
                case 8:
                    label1.Text = "Введите результат исследования";
                    break;
                case 9:
                    label1.Text = "Введите название исследования";
                    break;
                case 10:
                    label1.Text = "Введите название стандарта";
                    break;

            }

        }

        public bool PrintTable(string tablename)
        {
            try
            {
                ds = new DataSet();
                adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM " + tablename,connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds, tablename);
                currentTable = tablename;
                employeesDataGridView.DataSource = ds.Tables[tablename];
                //label2.Text = GetPrimaryKeyNames(currentTable)[0];
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Данные не заполнены\nПричина: " + e.Message);
            }
            Close();
            return false;
        }

        public bool DeleteRow(string table, string column, string id)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM " + table + " WHERE " + column + "=" + id, connection);
                if (command.ExecuteNonQuery() != 1)
                    throw new Exception("Строки не существует в базе данных");
                MessageBox.Show("Строка успешно удалена");
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка удаления строки\nПричина: " + e.Message);
            }
            return false;
        }

        public bool DeleteRow2keys(string table, string st1, string st2)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM " + table + " WHERE " + st1 + " AND " + st2, connection);
                if (command.ExecuteNonQuery() != 1)
                    throw new Exception("Строки не существует в базе данных");
                MessageBox.Show("Данные успешно удалены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка изменения строки\nПричина: " + e.Message);
            }
            return false;
        }

        public DataTable SearchRow(string table, string where)
        {
            DataTable resultTable = new DataTable(); // Для хранения результатов

            try
            {
                // Создаем SQL запрос
                MySqlCommand command = new MySqlCommand("SELECT * FROM " + table + " WHERE " + where, connection);

                // Используем MySqlDataAdapter для заполнения DataTable
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(resultTable); // Заполняем результат
                }

                // Проверяем, найдены ли строки
                if (resultTable.Rows.Count == 0)
                {
                    MessageBox.Show("По вашему запросу ничего не найдено.");
                }
                else
                {
                    MessageBox.Show("Найдено строк: " + resultTable.Rows.Count);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка поиска строки\nПричина: " + e.Message);
            }

            return resultTable; // Возвращаем результаты поиска
        }

        /*
        public bool InsertRow(string table, string values)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(
        
                    "INSERT INTO " + table + " VALUES (" + values + ")",
                    connection);
                label2.Text = table + values;
                if (command.ExecuteNonQuery() != 1)
                    throw new Exception("Что-то пошло не так при добавлении строки");
                MessageBox.Show("Строка успешно добавлена");
                insertTextBox.Text = "";
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка добавления строки\nПричина: " + e.Message);
            }
            return false;
        }
        */

        private void insertButton_Click(object sender, EventArgs e)
        {
            //label2.Text = insertTextBox.Text;
            if (userRoleId == 2)
            {
                MessageBox.Show("Недостаточно прав. Требуется роль Администратора");
            }
            else
            {
                //InsertRow(currentTable, insertTextBox.Text);
                switch (tablesListBox.SelectedIndex)
                {
                    case 0:
                        AddEm addEm = new AddEm();
                        addEm.Show();
                        break;
                    case 1:
                        Appl appl = new Appl();
                        appl.Show();
                        break;
                    case 2:
                        client client = new client();
                        client.Show();
                        break;
                    case 3:
                        Participants part = new Participants();
                        part.Show();
                        break;
                    case 4:
                        Post post = new Post();
                        post.Show();
                        break;
                    case 5:
                        Report rep = new Report();
                        rep.Show();
                        break;
                    case 6:
                        Stand stand = new Stand();
                        stand.Show();
                        break;
                    case 7:
                        Plans plans = new Plans();
                        plans.Show();
                        break;
                    case 8:
                        Resr res = new Resr();
                        res.Show();
                        break;
                    case 9:
                        ER er = new ER();
                        er.Show();
                        break;
                    case 10:
                        SR sr = new SR();
                        sr.Show();
                        break;
                }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentTable != null)
            {
                PrintTable(currentTable);
            }
           
        }

        private void whereButton_Click(object sender, EventArgs e)
        {
            string tableName = currentTable;
            string whereClause = whereTextBox.Text;

            switch (tablesListBox.SelectedIndex)
            {
                case 0:
                    whereClause = "`Employee Name` like '%" + whereClause + "%'";
                    //label1.Text = whereClause;
                    break;
                case 1:
                    whereClause = "`Client Name` like '%" + whereClause + "%'";
                    break;
                case 2:
                    whereClause = "`Client Name` like '%" + whereClause + "%'";
                    break;
                case 3:
                    whereClause = "`Participants List` like '%" + whereClause + "%'";
                    break;
                case 4:
                    whereClause = "`Post Title` like '%" + whereClause + "%'";
                    break;
                case 5:
                    whereClause = "`Report Date` like '__.__." + whereClause + "'";
                    break;
                case 6:
                    whereClause = "`Validity Period` like '__.__." + whereClause + "'";
                    break;
                case 7:
                    whereClause = "`Stage` like '%" + whereClause + "%'";
                    break;
                case 8:
                    whereClause = "`Research Result` like '%" + whereClause + "%'";
                    break;
                case 9:
                    whereClause = "`Research Description` like '%" + whereClause + "%'";
                    break;
                case 10:
                    whereClause = "`Standart Requirements` like '%" + whereClause + "%'";
                    break;
            }

            

            // Выполняем поиск
            if (radioButton2.Checked)
            {
                MessageBox.Show("Недоступно в режиме изменения");
            }
            else
            {
                DataTable searchResults = SearchRow(tableName, whereClause);

                // Если результаты не пустые, привязываем их к DataGridView
                if (searchResults != null && searchResults.Rows.Count > 0)
                {
                    employeesDataGridView.DataSource = searchResults;
                }
            }
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        public DataTable SearchApplication(string year, string topic)
        {
            DataTable resultTable = new DataTable(); // Для хранения результатов

            try
            {
                // Создаем SQL запрос
                MySqlCommand command = new MySqlCommand("SELECT * FROM Application WHERE Date like(\"" + year + "%\") AND topic like(\"%" + topic + "%\")", connection);

                // Используем MySqlDataAdapter для заполнения DataTable
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(resultTable); // Заполняем результат
                }

                // Проверяем, найдены ли строки
                if (resultTable.Rows.Count == 0)
                {
                    MessageBox.Show("По вашему запросу ничего не найдено.");
                }
                else
                {
                    MessageBox.Show("Найдено строк: " + resultTable.Rows.Count);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка поиска строки\nПричина: " + e.Message);
            }

            return resultTable; // Возвращаем результаты поиска
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void searchApplicationButton_Click(object sender, EventArgs e)
        {

            // Выполняем поиск
            DataTable searchResults = SearchApplication(yearTextBox.Text, topicTextBox.Text);

            // Если результаты не пустые, привязываем их к DataGridView
            if (searchResults != null && searchResults.Rows.Count > 0)
            {
                employeesDataGridView.DataSource = searchResults;
            }
        }
        private void EmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void selfButton_Click(object sender, EventArgs e)
        {
            if (userRoleId == 2)
            {
                MessageBox.Show("Недостаточно прав. Требуется роль Администратора");
            }
            else
            {
                // Получаем текст запроса, введенного пользователем
                string userQuery = selfTB.Text.Trim();

                // Проверка на допустимость команды (примитивная, но дает базовую защиту)
                if (string.IsNullOrWhiteSpace(userQuery) ||
                    userQuery.StartsWith("DROP", StringComparison.OrdinalIgnoreCase) ||
                    userQuery.StartsWith("ALTER", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Запрос не может быть выполнен. Недопустимая команда.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    MySqlCommand command = new MySqlCommand(userQuery, connection);

                    // Определяем тип запроса по ключевому слову
                    if (userQuery.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                    {
                        // Запрос на получение данных
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        // Отображаем результат в DataGridView
                        employeesDataGridView.DataSource = resultTable;
                        MessageBox.Show("Запрос успешно выполнен и данные отображены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Запрос на изменение данных (INSERT, UPDATE, DELETE)
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"Запрос выполнен. Затронуто строк: {rowsAffected}.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Обновляем таблицу после изменения
                        if (!string.IsNullOrEmpty(currentTable))
                        {
                            PrintTable(currentTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void selfTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void functionButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(functionTB.Text, out int postId))
            {
                string employeeNames = GetEmployeeNamesByPostId(postId);
                MessageBox.Show("Сотрудники с PostID " + postId + ": " + employeeNames);
            }
            else
            {
                MessageBox.Show("Введите корректный ID должности.");
            }
        }

        private string GetEmployeeNamesByPostId(int postId)
        {
            string result = "";
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT count_employee(@postId)", connection);
                command.Parameters.AddWithValue("@postId", postId);
                result = command.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка вызова функции count_employee\nПричина: " + e.Message);
            }
            return result;
        }

        private void UpsertEmployee(string name, string email, int postId)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("CALL UpsertEmployee2(@name, @email, @postId)", connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@postId", postId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string resultMessage = reader["Result"].ToString();
                        MessageBox.Show(resultMessage, "Результат операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка вызова процедуры UpsertEmployee2\nПричина: " + e.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void upsertEmployeeButton_Click(object sender, EventArgs e)
        {
            if (userRoleId == 2)
            {
                MessageBox.Show("Недостаточно прав. Требуется роль Администратора");
            }
            else
            {
                string name = nameTextBox.Text;
                string email = emailTextBox.Text;

                if (int.TryParse(postIdTextBox.Text, out int postId))
                {
                    UpsertEmployee(name, email, postId);
                }
                else
                {
                    MessageBox.Show("Введите корректный ID должности.");
                }
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
