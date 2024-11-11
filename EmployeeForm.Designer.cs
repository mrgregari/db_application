namespace db_application
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.employeesDataGridView = new System.Windows.Forms.DataGridView();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.tablesListBox = new System.Windows.Forms.ListBox();
            this.insertButton = new System.Windows.Forms.Button();
            this.insertTextBox = new System.Windows.Forms.TextBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.whereTextBox = new System.Windows.Forms.TextBox();
            this.whereButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.topicTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.searchApplicationButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.selfTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.selfButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.functionTB = new System.Windows.Forms.TextBox();
            this.functionButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.postIdTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.upsertEmployeeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.employeesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // employeesDataGridView
            // 
            this.employeesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.employeesDataGridView.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.employeesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesDataGridView.Location = new System.Drawing.Point(360, 51);
            this.employeesDataGridView.Name = "employeesDataGridView";
            this.employeesDataGridView.RowHeadersWidth = 51;
            this.employeesDataGridView.Size = new System.Drawing.Size(856, 443);
            this.employeesDataGridView.TabIndex = 0;
            this.employeesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionLabel.Location = new System.Drawing.Point(373, 16);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(58, 22);
            this.connectionLabel.TabIndex = 1;
            this.connectionLabel.Text = "label1";
            this.connectionLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // tablesListBox
            // 
            this.tablesListBox.FormattingEnabled = true;
            this.tablesListBox.ItemHeight = 16;
            this.tablesListBox.Items.AddRange(new object[] {
            "Сотрудники",
            "Заявки",
            "Клиенты",
            "Участники",
            "Должности",
            "Отчеты",
            "Стандарты",
            "Планы исследований",
            "Исследования",
            "Работники, исследования",
            "Стандарты, исследования"});
            this.tablesListBox.Location = new System.Drawing.Point(13, 51);
            this.tablesListBox.Name = "tablesListBox";
            this.tablesListBox.Size = new System.Drawing.Size(327, 180);
            this.tablesListBox.TabIndex = 2;
            this.tablesListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(12, 293);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(328, 25);
            this.insertButton.TabIndex = 4;
            this.insertButton.Text = "Добавить";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // insertTextBox
            // 
            this.insertTextBox.Location = new System.Drawing.Point(12, 265);
            this.insertTextBox.Name = "insertTextBox";
            this.insertTextBox.Size = new System.Drawing.Size(328, 22);
            this.insertTextBox.TabIndex = 5;
            // 
            // refreshButton
            // 
            this.refreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshButton.BackgroundImage")));
            this.refreshButton.Location = new System.Drawing.Point(1170, 9);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(46, 40);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // whereTextBox
            // 
            this.whereTextBox.Location = new System.Drawing.Point(12, 349);
            this.whereTextBox.Multiline = true;
            this.whereTextBox.Name = "whereTextBox";
            this.whereTextBox.Size = new System.Drawing.Size(328, 42);
            this.whereTextBox.TabIndex = 8;
            // 
            // whereButton
            // 
            this.whereButton.Location = new System.Drawing.Point(12, 397);
            this.whereButton.Name = "whereButton";
            this.whereButton.Size = new System.Drawing.Size(328, 23);
            this.whereButton.TabIndex = 9;
            this.whereButton.Text = "Искать с помощью WHERE";
            this.whereButton.UseVisualStyleBackColor = true;
            this.whereButton.Click += new System.EventHandler(this.whereButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Текст для поиска с помощью WHERE";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // topicTextBox
            // 
            this.topicTextBox.Location = new System.Drawing.Point(12, 440);
            this.topicTextBox.Name = "topicTextBox";
            this.topicTextBox.Size = new System.Drawing.Size(203, 22);
            this.topicTextBox.TabIndex = 11;
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(263, 440);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(77, 22);
            this.yearTextBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Год заявки:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Тема исследования содержит:\r\n";
            // 
            // searchApplicationButton
            // 
            this.searchApplicationButton.Location = new System.Drawing.Point(12, 468);
            this.searchApplicationButton.Name = "searchApplicationButton";
            this.searchApplicationButton.Size = new System.Drawing.Size(328, 26);
            this.searchApplicationButton.TabIndex = 15;
            this.searchApplicationButton.Text = "Искать заявку с заданными параметрами";
            this.searchApplicationButton.UseVisualStyleBackColor = true;
            this.searchApplicationButton.Click += new System.EventHandler(this.searchApplicationButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Введите параметры строки для добавления\r\n";
            // 
            // selfTB
            // 
            this.selfTB.Location = new System.Drawing.Point(360, 505);
            this.selfTB.Name = "selfTB";
            this.selfTB.Size = new System.Drawing.Size(688, 22);
            this.selfTB.TabIndex = 17;
            this.selfTB.TextChanged += new System.EventHandler(this.selfTB_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(91, 508);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Ввести запрос вручную";
            // 
            // selfButton
            // 
            this.selfButton.Location = new System.Drawing.Point(1068, 500);
            this.selfButton.Name = "selfButton";
            this.selfButton.Size = new System.Drawing.Size(148, 32);
            this.selfButton.TabIndex = 19;
            this.selfButton.Text = "Применить запрос";
            this.selfButton.UseVisualStyleBackColor = true;
            this.selfButton.Click += new System.EventHandler(this.selfButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 547);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(641, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Для поиска сотрудников с заданной должностью введите ID должности (используется ф" +
    "ункция):";
            // 
            // functionTB
            // 
            this.functionTB.Location = new System.Drawing.Point(697, 544);
            this.functionTB.Name = "functionTB";
            this.functionTB.Size = new System.Drawing.Size(180, 22);
            this.functionTB.TabIndex = 21;
            // 
            // functionButton
            // 
            this.functionButton.Location = new System.Drawing.Point(910, 542);
            this.functionButton.Name = "functionButton";
            this.functionButton.Size = new System.Drawing.Size(306, 27);
            this.functionButton.TabIndex = 22;
            this.functionButton.Text = "Искать";
            this.functionButton.UseVisualStyleBackColor = true;
            this.functionButton.Click += new System.EventHandler(this.functionButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 590);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(308, 32);
            this.label9.TabIndex = 23;
            this.label9.Text = "Добавление/обновление данных сотрудника, \r\nиспользуя хранимую процедуру:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(437, 587);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(189, 22);
            this.nameTextBox.TabIndex = 24;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(679, 587);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(222, 22);
            this.emailTextBox.TabIndex = 25;
            // 
            // postIdTextBox
            // 
            this.postIdTextBox.Location = new System.Drawing.Point(1007, 587);
            this.postIdTextBox.Name = "postIdTextBox";
            this.postIdTextBox.Size = new System.Drawing.Size(58, 22);
            this.postIdTextBox.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(398, 590);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 16);
            this.label10.TabIndex = 27;
            this.label10.Text = "Имя";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(632, 590);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "Email";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(907, 590);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 16);
            this.label12.TabIndex = 29;
            this.label12.Text = "ID должности";
            // 
            // upsertEmployeeButton
            // 
            this.upsertEmployeeButton.Location = new System.Drawing.Point(1082, 584);
            this.upsertEmployeeButton.Name = "upsertEmployeeButton";
            this.upsertEmployeeButton.Size = new System.Drawing.Size(134, 28);
            this.upsertEmployeeButton.TabIndex = 30;
            this.upsertEmployeeButton.Text = "Добавить";
            this.upsertEmployeeButton.UseVisualStyleBackColor = true;
            this.upsertEmployeeButton.Click += new System.EventHandler(this.upsertEmployeeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 22);
            this.label2.TabIndex = 31;
            this.label2.Text = "Выберите таблицу для отображения";
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1251, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.upsertEmployeeButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.postIdTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.functionButton);
            this.Controls.Add(this.functionTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.selfButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.selfTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.searchApplicationButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.topicTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.whereButton);
            this.Controls.Add(this.whereTextBox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.insertTextBox);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.tablesListBox);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.employeesDataGridView);
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView employeesDataGridView;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.ListBox tablesListBox;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.TextBox insertTextBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TextBox whereTextBox;
        private System.Windows.Forms.Button whereButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox topicTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button searchApplicationButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox selfTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button selfButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox functionTB;
        private System.Windows.Forms.Button functionButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox postIdTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button upsertEmployeeButton;
        private System.Windows.Forms.Label label2;
    }
}