using System;
using System.Windows.Forms;

namespace Final_project.Forms
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool auth = Program.Db.Auth(textBox1.Text, textBox2.Text);
                if (auth)
                {
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Ошибка соединения с базой данных");
            }
        }

        // Кнопка назад, возвращает на стартовый экран
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartForm form = new StartForm();
            form.Show();
        }
    }
}