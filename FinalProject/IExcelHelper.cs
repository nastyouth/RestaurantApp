using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_project
{
    interface IExcelHelper
    {
        // Сохранить чек
        void SaveReceiptInExcelWith(DataGridView dataGridView, string path);
    }
}
