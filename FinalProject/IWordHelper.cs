using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_project
{
    interface IWordHelper
    {
        // Сохранить чек
        void SaveRevieptToDoc(DataGridView dataGridView, string filename);
    }
}
