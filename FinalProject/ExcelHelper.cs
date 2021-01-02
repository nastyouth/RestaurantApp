using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace Final_project
{
    internal class ExcelHelper: IExcelHelper
    {
        private Excel.Application excelApplication;
        private Excel.Workbook excelWorkBook;
        private Excel.Worksheet excelWorkSheet;

        public void SaveReceiptInExcelWith(DataGridView dataGridView, string path)
        {
            DateTime currentTime = DateTime.Now;
            int lastRow = dataGridView.Rows.Count + 3;
            int lastColumn = dataGridView.Columns.Count - 1;
            int summary = 0;

            excelApplication = new Excel.Application();
            excelApplication.Visible = false;
            excelWorkBook = excelApplication.Workbooks.Open(@path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);
            excelWorkSheet = excelWorkBook.ActiveSheet;

            for (int row = 0; row < dataGridView.Rows.Count - 1; row++)
            {
                summary += int.Parse(dataGridView[dataGridView.Columns.Count - 1, row].Value.ToString());
                for (int column = 1; column < dataGridView.Columns.Count; column++)
                {
                    excelWorkSheet.Cells[row + 3, column] = dataGridView[column, row].Value.ToString();
                }
            }

            excelWorkSheet.Cells[lastRow, lastColumn] = "Итого:" + summary.ToString();
            excelWorkSheet.Cells[lastRow + 1, lastColumn] = "Продавец: Смирнов С.С.";
            excelWorkSheet.Cells[lastRow + 2, lastColumn] = "Дата и время:" + currentTime.ToString();

            excelWorkBook.Close(true);
            excelApplication.Quit();
        }
    }
}
