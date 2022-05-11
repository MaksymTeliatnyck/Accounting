using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FirebirdSql.Data.FirebirdClient;
using System.Threading;
using System.Globalization;

namespace Accounting
{
    public partial class StockBalanceFM : DevExpress.XtraEditors.XtraForm 
    {
        private BindingSource stockbalanceBS = new BindingSource();
        public string StartDate;
        public StockBalanceFM()
        {
            InitializeComponent();
            Cursor = Cursors.WaitCursor;
            gridStockBalance.DataSource = stockbalanceBS;
            dateStockBalance.EditValue = DateTime.Now;
            StartDate = dateStockBalance.DateTime.ToShortDateString();
            loaddata(StartDate);
        }

        private void StockBalanceFM_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFm.StockBalanceBtn.Enabled = true;
        }

        public void loaddata (string startDate)
        {
           FbParameter[] Parameters =
            {
                new FbParameter("StartDate", StartDate),
            };
            stockbalanceBS.DataSource = DataModule.ExecuteFill(DataModule.Queries["StockBalance"], Parameters);
            Cursor = Cursors.Default;

        }

        private void showStockBalancBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            StartDate = dateStockBalance.DateTime.ToShortDateString();
            loaddata(StartDate);
        }
        private void tofileBtn_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("uk-UA"); 
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridStockBalance.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridStockBalance.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridStockBalance.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridStockBalance.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridStockBalance.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridStockBalance.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = " Файл не открываеться." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "Файл невозможно сохранить" + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}