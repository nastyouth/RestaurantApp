using System;
using System.Windows.Forms;

namespace Final_project.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Db.Registration(textBox1.Text, textBox2.Text, textBox3.Text);
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Ошибка соединения с базой данных");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartForm form = new StartForm();
            form.Show();
        }
    }
}
