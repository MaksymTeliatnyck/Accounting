using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace Accounting
{
    public partial class receiptsFm : Form
    {
        public receiptsFm(string StartDate, object EndDate, object flag1, object flag2, object flag3, object flag4)
        {
            InitializeComponent();

            this.Width = 95 * Program.MainFm.MainFmWidth / 100;
            this.Height = 95 * Program.MainFm.MainFmHeight / 100;

            FbParameter[] Parameters =
            {
                new FbParameter("Start_Date", StartDate),
                new FbParameter("End_Date", EndDate),
                new FbParameter("Flag1", flag1),
                new FbParameter("Flag2", flag2),
                new FbParameter("Flag3", flag3),
                new FbParameter("Flag4", flag4)
            };
            receiptsGrid.DataSource = DataModule.ExecuteFill(DataModule.Queries["Receipts"], Parameters);

            this.Text = "Приходы за период с " + Convert.ToDateTime(StartDate).ToShortDateString().Substring(3, 7) + " по " + Convert.ToDateTime(EndDate).ToShortDateString().Substring(3, 7);
        }

        private void receiptsGridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Name == "correctionColumn")
            {
                string cellValue = receiptsGridView.GetRowCellDisplayText(e.RowHandle, e.Column);
                if (cellValue == "1")
                    e.Appearance.BackColor = Color.Orange;
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                receiptsGridView.ExportToXls(Utils.HomePath + @"\Reports\Gen\Материалы и услуги.xls");

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.Arguments = "\"" + Utils.HomePath + @"\Reports\Gen\Материалы и услуги.xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
