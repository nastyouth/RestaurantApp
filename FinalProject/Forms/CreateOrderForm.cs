using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Final_project.Forms
{
    public partial class CreateOrderForm : Form
    {

        public CreateOrderForm()
        {
            InitializeComponent();

            // Добавление продуктов из БД
            List<string> list = Program.Db.GetProductsList();
            foreach (string product in list)
            {
                comboBox1.Items.Add(product);
            }
        }

        private void CreateOrderForm_Load(object sender, EventArgs e) {}

        // Добавить к заказу
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = Program.Db.GetProduct(comboBox1.Text.ToString());
            foreach (DataRow tableRow in table.Rows)
            {
                var cell = tableRow.ItemArray;
                dataGridView1.Rows.Add(cell);
            }
        }

        // Удалить выбранный
        private void button3_Click(object sender, EventArgs e)
        {
            int currentIndex = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.Remove(dataGridView1.Rows[currentIndex]);
        }

        // Сохранить чек в txt
        private void button2_Click(object sender, EventArgs e)
        {
            TxtHelper txtHelper = new TxtHelper();
            try
            {
                txtHelper.SaveRecieptToTxt("W:\\reciept.txt", dataGridView1);
                System.Windows.Forms.MessageBox.Show("Чек в txt сохранен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Сохранить чек в Excel
        private void button4_Click(object sender, EventArgs e)
        {
            ExcelHelper excelHelper = new ExcelHelper();
            try
            {
                excelHelper.SaveReceiptInExcelWith(dataGridView1, "W:\\recieptik.xlsx");
                System.Windows.Forms.MessageBox.Show("Чек в Excel сохранен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Сохранить чек в Word
        private void button5_Click(object sender, EventArgs e)
        {
            WordHelper wordHelper = new WordHelper();
            try
            {
                wordHelper.SaveRevieptToDoc(dataGridView1, "reciept.docx");
                System.Windows.Forms.MessageBox.Show("Чек в Word сохранен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Назад
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form = new MainForm();
            form.Show();
        }
    }
}