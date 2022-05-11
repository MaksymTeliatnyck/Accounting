using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Accounting
{
    public partial class materialsFixedAssetsFm : Form
    {
        public materialsFixedAssetsFm(string StartDate, string EndDate)
        {
            InitializeComponent();

            this.Width = 95 * Program.MainFm.MainFmWidth / 100;
            this.Height = 95 * Program.MainFm.MainFmHeight / 100;

            FbParameter[] Parameters =
            {
                new FbParameter("Start_Date", StartDate),
                new FbParameter("End_Date", EndDate),
            };
            materialsFixedAssetsGrid.DataSource = DataModule.ExecuteFill(DataModule.Queries["MaterialsFixedAssets"], Parameters);
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                materialsFixedAssetsGridView.ExportToXls(Utils.HomePath + @"\Reports\Gen\Основные средства.xls");

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.Arguments = "\"" + Utils.HomePath + @"\Reports\Gen\Основные средства.xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
