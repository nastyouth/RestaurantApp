using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_project.Forms
{
    public partial class CreateProduct : Form
    {
        public CreateProduct()
        {
            InitializeComponent();
            dataGridView1.DataSource = Program.Db.GetAllProducts();
        }

        // Добавить новый продукт в БД
        private void button1_Click(object sender, EventArgs e)
        {
            InsertProduct();
        }
   
        // Удалить выбранный продукт из БД
        private void button2_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }

        // Назад
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form = new MainForm();
            form.Show();
        }

        private void InsertProduct()
        {
            Program.Db.InsertProduct(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
            dataGridView1.DataSource = Program.Db.GetAllProducts();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void DeleteProduct()
        {
            int currentIndex = dataGridView1.CurrentRow.Index;
            int currentItem = int.Parse(dataGridView1[0, currentIndex].Value.ToString());
            textBox2.Text = dataGridView1[0, currentIndex].Value.ToString();
            dataGridView1.Rows.Remove(dataGridView1.Rows[currentIndex]);
            Program.Db.DeleteProduct(currentItem);
        }
    }
}
