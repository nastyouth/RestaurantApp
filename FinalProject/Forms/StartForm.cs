using System;
using System.Windows.Forms;

namespace Final_project.Forms
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            Program.Db = new Database();
            Program.Db.CreateDbIfNotExist();
            Program.Db.CreateUsersTableIfNotExist();
            Program.Db.CreateProductsTableIfNotExist();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthForm authForm = new AuthForm();
            authForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}
