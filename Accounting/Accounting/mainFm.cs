using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Deployment.Application;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using FirebirdSql.Data.FirebirdClient;

namespace Accounting
{
    public partial class mainFm : Form
    {
        public int MainFmHeight, MainFmWidth;

        private DataModule dataModule;

        public mainFm()
        {
            InitializeComponent();

#if DEBUG
            dataModule = new DataModule("sysdba", "masterkey", "TVM_DB", "10.0.0.50");
#else
            dataModule = new DataModule("sysdba", "masterkey", "TVM_DB", "10.0.0.50");
#endif

            dataModule.InitAdapter();

            DataModule.AccountingDS.Tables.Add(new DataTable("Order"));
            DataModule.AccountingDS.Tables.Add(new DataTable("DeliveryOrders"));
            DataModule.AccountingDS.Tables.Add(new DataTable("DeliveryOrderDetails"));
            DataModule.AccountingDS.Tables.Add(new DataTable("Receipt"));
            DataModule.AccountingDS.Tables.Add(new DataTable("Expenditures"));
            DataModule.AccountingDS.Tables.Add(new DataTable("Invoice_Requirement_Orders"));
            DataModule.AccountingDS.Tables.Add(new DataTable("Invoice_Requirement_Materials"));
            DataModule.AccountingDS.Tables.Add(new DataTable("BusinessTrip_Payments"));
            DataModule.AccountingDS.Tables.Add(new DataTable("Bank_Payments"));
            DataModule.AccountingDS.Tables.Add(new DataTable("FixedAssetsOrder"));
            DataModule.AccountingDS.Tables.Add(new DataTable("FixedAssetsMaterials"));
            DataModule.AccountingDS.Tables.Add(new DataTable("FixedAssetsArchive"));
            DataModule.AccountingDS.Tables.Add(new DataTable("CalcWithBuyers"));
            DataModule.AccountingDS.Tables.Add(new DataTable("CustomerOrders"));
            DataModule.AccountingDS.Tables.Add(new DataTable("Contractors"));
            DataModule.AccountingDS.Tables.Add(new DataTable("Nomenclatures"));

            DataModule.DataAdapter["Receipt"].Fill(DataModule.AccountingDS.Tables["Receipt"]);


            //Utils.SetDoubleBuffered(windowsBarPanel, true);
            //new WindowsPanel(windowsBarPanel, Properties.Resources.Close);

            //if (ApplicationDeployment.IsNetworkDeployed)
            //{
            //    ApplicationDeployment.CurrentDeployment.CheckForUpdateAsync();
            //    updatesTimer.Interval = 60000 * 5;
            //    updatesTimer.Tick += updatesTimer_Tick;
            //    updatesTimer.Enabled = true;
            //}
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo(Properties.Settings.Default.KeybrdLang));
        }

        private void mainFm_Load(object sender, EventArgs e)
        {
            MainFmHeight = this.ClientSize.Height - menuStrip.Height - toolStrip.Height - statusStrip.Height - windowsBarPanel.Height;
            MainFmWidth = this.ClientSize.Width;
            this.Text = this.Text + " /" + DataModule.Connection.DataSource + "/";
        }

        #region Menu

        #region MainMenu

        #region Windows

        private void cascadeTSMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalTSMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalTSMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void closeAllTSMenuItem_Click(object sender, EventArgs e)
        {
            Form[] MdiChildren = this.MdiChildren;
            foreach (Form ChildForm in MdiChildren)
                ChildForm.Close();
        }

        #endregion Windows

        private void optionsTSMenuItem_Click(object sender, EventArgs e)
        {
            optionsFm optionsFm = new optionsFm();
            optionsFm.MdiParent = this;
            optionsFm.Show();
        }

        private void exitTSMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion MainMenu

        #region ToolMenu

        private void addBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            receiptsBtn.Enabled = false;
            ordersFm receiptFm = new ordersFm(false);
            receiptFm.MdiParent = this;
            receiptFm.Show();
            Cursor = Cursors.Default;
        }

        private void expendituresBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            expendituresBtn.Enabled = false;
            expendituresFm accountantExpFm = new expendituresFm();
            accountantExpFm.MdiParent = this;
            accountantExpFm.Show();
            Cursor = Cursors.Default;
        }
        
        private void reportsBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            reportsBtn.Enabled = false;
            reportsFm reportFm = new reportsFm();
            reportFm.MdiParent = this;
            reportFm.Show();
            Cursor = Cursors.Default;
        }

        private void calcWithBuyersBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            calcWithBuyersBtn.Enabled = false;
            calcWithBuyersFm calcWithBuyersFm = new calcWithBuyersFm();
            calcWithBuyersFm.MdiParent = this;
            calcWithBuyersFm.Show();
            Cursor = Cursors.Default;
        }

        private void invoiceRequirementBtn_Click(object sender, EventArgs e)
        {
            invoiceRequirementFm invoiceRequirementFm = new invoiceRequirementFm();
            invoiceRequirementFm.MdiParent = this;
            invoiceRequirementBtn.Enabled = false;
            invoiceRequirementFm.Show();
        }

        private void receiptsCurrencyBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            receiptsCurrencyBtn.Enabled = false;
            ordersFm receiptCurrencyFm = new ordersFm(true);
            receiptCurrencyFm.MdiParent = this;
            receiptCurrencyFm.Show();
            receiptsCurrencyBtn.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void newBankPaymentsBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            newBankPaymentsBtn.Enabled = false;
            new_BankPaymentsFm newPaymentsFm = new new_BankPaymentsFm();
            newPaymentsFm.MdiParent = this;
            newPaymentsFm.Show();
            newBankPaymentsBtn.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void fixedAssetsOrderBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            fixedAssetsOrderBtn.Enabled = false;
            fixedAssetsOrderFm fixedOrdersFm = new fixedAssetsOrderFm();
            fixedOrdersFm.MdiParent = this;
            fixedOrdersFm.Show();
            fixedAssetsOrderBtn.Enabled = true;
            Cursor = Cursors.Default;
        }
        private void StockBalanceBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            StockBalanceBtn.Enabled = false;
            StockBalanceFM stockbalanceFm = new StockBalanceFM();
            stockbalanceFm.MdiParent = this;
            stockbalanceFm.Show();
            Cursor = Cursors.Default;
        }

        #region DictionariesMenu

        private void nomenclGroupsTSMenu_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //nomenclRBFm nomenclRBFm = new nomenclRBFm();
            //nomenclRBFm.MdiParent = this;
            //nomenclRBFm.Show();
            //Cursor = Cursors.Default;

            Cursor = Cursors.WaitCursor;
            nomenclatureFm nomenclatureFm = new nomenclatureFm();
            nomenclatureFm.MdiParent = this;
            nomenclatureFm.Show();
            Cursor = Cursors.Default;
        }

        private void suppliersTSMenu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            suppliersRBFm suppliersRBFm = new suppliersRBFm();
            suppliersRBFm.MdiParent = this;
            suppliersRBFm.Show();
            Cursor = Cursors.Default;
        }

        private void contractorsTSMenu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            contractorsRBFm vendorsRBFm = new contractorsRBFm();
            vendorsRBFm.MdiParent = this;
            vendorsRBFm.Show();
            Cursor = Cursors.Default;
        }

        private void accountsTSMenu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            accountsRBFm accountsRBFm = new accountsRBFm();
            accountsRBFm.MdiParent = this;
            accountsRBFm.Show();
            Cursor = Cursors.Default;
        }

        private void periodsTSMenu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            periodsFm periodsFm = new periodsFm();
            periodsFm.MdiParent = this;
            periodsFm.Show();
            Cursor = Cursors.Default;
        }

        private void banksMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            banksRBFm banksRBFm = new banksRBFm();
            banksRBFm.MdiParent = this;
            banksRBFm.Show();
            Cursor = Cursors.Default;
        }

        private void bankAccountsMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            bankAccountsRBFm bankAccountsFm = new bankAccountsRBFm();
            bankAccountsFm.MdiParent = this;
            bankAccountsFm.Show();
            Cursor = Cursors.Default;
        }

        private void fixedAssetsGroupRBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            fixedAssetsGroupRGFm fixedAssetsGroupRGFrm = new fixedAssetsGroupRGFm();
            fixedAssetsGroupRGFrm.MdiParent = this;
            fixedAssetsGroupRGFrm.Show();
            Cursor = Cursors.Default;
        }

        private void regionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            regionRBFm regionRBFrm = new regionRBFm();
            regionRBFrm.MdiParent = this;
            regionRBFrm.Show();
            Cursor = Cursors.Default;
        }

        private void customerOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var customerOrdersFm = new customerOrdersFm();
            customerOrdersFm.MdiParent = this;
            customerOrdersFm.Show();
            Cursor = Cursors.Default;
        }

        private void dictionaryCPVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var dictionaryCPVFm = new dictionaryCPVFm();
            dictionaryCPVFm.MdiParent = this;
            dictionaryCPVFm.Show();
            Cursor = Cursors.Default;
        }


        #endregion DictionariesMenu

        #endregion ToolMenu

        #endregion Menu

        #region ClickOnceUpdate

        private Timer updatesTimer = new Timer();

        private void updatesTimer_Tick(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                try
                {
                    if (ApplicationDeployment.CurrentDeployment.CheckForUpdate())
                    {
                        updatesTimer.Enabled = false;
                        ToolStripItem toolStripItem = statusStrip.Items.Add("Доступно новое обновление", Properties.Resources.Refresh);
                        toolStripItem.Name = "updateToolStripItem";
                        toolStripItem.DoubleClickEnabled = true;
                        toolStripItem.DoubleClick += updatesStripItem_DoubleClick;
                    }
                }
                catch { }
            }
        }

        private void updatesStripItem_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Обновить приложение?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    statusStrip.Items["updateToolStripItem"].Text = "Подождите, идёт обновление...";
                    ApplicationDeployment.CurrentDeployment.Update();
                    statusStrip.Items["updateToolStripItem"].Text = "Обновление выполнено, перезапуск приложения...";
                    Application.Restart();
                }
                catch (DeploymentDownloadException dde)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Произошла ошибка при обновлении\n" + dde, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion ClickOnceUpdate

        private void mainFm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (string FileName in Directory.GetFiles(Utils.HomePath + @"\Reports\Gen\"))
            {
                try
                {
#if DEBUG
                    if (Path.GetFileName(FileName) != "Dummy.txt")
                        File.Delete(FileName);
#else
                        File.Delete(FileName);
#endif
                }
                catch { }
            }
        }

        
    }
}
