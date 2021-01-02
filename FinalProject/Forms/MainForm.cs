using System.Windows.Forms;

namespace Final_project.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Открыть создание чека заказа
        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            CreateOrderForm createOrderForm = new CreateOrderForm();
            createOrderForm.Show();
        }

        // Открыть изменение меню
        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            CreateProduct createProduct = new CreateProduct();
            createProduct.Show();
        }

        // Выйти
        private void button4_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            StartForm startForm = new StartForm();
            startForm.Show();
        }
    }
}
