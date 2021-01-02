using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_project
{
    internal class TxtHelper: ITxtHelper
    {
        public void SaveRecieptToTxt(string path, DataGridView dataFridView)
        {
            System.IO.StreamWriter txtFile = new System.IO.StreamWriter(@path);
            txtFile.WriteLine("Название блюда " + "Цена ");
            string line = "";
            int rowsCount = dataFridView.Rows.Count - 1;
            int columnsCount = dataFridView.Columns.Count - 1;
            for (int row = 0; row <= rowsCount; row++)
            {
                for (int column = 1; (column <= columnsCount) && (column != 2); column++)
                {
                    line = line + dataFridView.Rows[row].Cells[column].Value;
                    if (column != dataFridView.Columns.Count - 1)
                    {
                        line = line + " ";
                    }
                }
                txtFile.WriteLine(line);
                line = "";
            }
            txtFile.Close();
        }
    }
}
