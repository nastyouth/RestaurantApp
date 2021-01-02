using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

namespace Final_project
{
    internal class WordHelper: IWordHelper
    {

        public void SaveRevieptToDoc(DataGridView dataGridView, string filename)
        {
            if (dataGridView.Rows.Count != 0)
            {
                int rowCount = dataGridView.Rows.Count;
                int columnCount = dataGridView.Columns.Count;
                Object[,] DataArray = new object[rowCount + 1, columnCount + 1];

                // Добавление строк
                int row = 0;
                for (int column = 0; column <= columnCount - 1; column++)
                {
                    for (row = 0; row <= rowCount - 1; row++)
                    {
                        DataArray[row, column] = dataGridView.Rows[row].Cells[column].Value;
                    }
                }

                Word.Document wordDocument = new Word.Document();
                wordDocument.Application.Visible = true;

                // Ориентация страницы
                wordDocument.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                dynamic range = wordDocument.Content.Application.Selection.Range;

                // Это элемент строки, т.е., например, "Шашлык куриный" или "1" (id) или "350" (цена)
                string line = "";
                for (row = 0; row <= rowCount - 1; row++)
                {
                    for (int column = 0; column <= columnCount - 1; column++)
                    {
                        line = line + DataArray[row, column] + "\t";

                    }
                }

                // Формат таблицы
                range.Text = line;
                object missing = Missing.Value;
                object separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object applyBorders = true;
                object autoFit = true;
                object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                range.ConvertToTable(ref separator, ref rowCount, ref columnCount,
                                      Type.Missing, Type.Missing, ref applyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref autoFit, ref autoFitBehavior, Type.Missing);
                range.Select();

                wordDocument.Application.Selection.Tables[1].Select();
                wordDocument.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                wordDocument.Application.Selection.Tables[1].Rows.Alignment = 0;
                wordDocument.Application.Selection.Tables[1].Rows[1].Select();
                wordDocument.Application.Selection.InsertRowsAbove(1);
                wordDocument.Application.Selection.Tables[1].Rows[1].Select();

                // Настройки header'a
                wordDocument.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                wordDocument.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                wordDocument.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                // Добавление header'a
                for (int column = 0; column <= columnCount - 1; column++)
                {
                    wordDocument.Application.Selection.Tables[1].Cell(1, column + 1).Range.Text = dataGridView.Columns[column].HeaderText;
                }

                // Стиль таблицы
                wordDocument.Application.Selection.Tables[1].Rows[1].Select();
                wordDocument.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                // Текст header'a
                foreach (Word.Section section in wordDocument.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Чек";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                // Сохранение файла
                wordDocument.SaveAs(filename, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing);
                System.Windows.Forms.MessageBox.Show("Чек сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
