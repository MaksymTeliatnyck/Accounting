using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Accounting.BankImports;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace Accounting
{
    public partial class new_importBankPaymentsFm : Form
    {
        private OpenFileDialog openDialog = new OpenFileDialog();
        private BindingSource paymentsBS = new BindingSource();
        private DataTable importDataTable = new DataTable();

        public new_importBankPaymentsFm()
        {
            InitializeComponent();

            this.Width = (int)(Program.MainFm.MainFmWidth * 0.95);
            this.Height = (int)(Program.MainFm.MainFmHeight * 0.95);

            importDataTable = DataModule.AccountingDS.Tables["Bank_Payments"].Clone();
            paymentsBS.DataSource = importDataTable;
            paymentsGrid.DataSource = paymentsBS;
            
            //currencyLookUpEdit.DataSource = DataModule.ExecuteFill(DataModule.Queries["Currency"]);
            DataModule.Connection.Open();
            currencyLookUpEdit.DataSource = DataModule.ExecuteFill(@"SELECT ""Code"" FROM ""Currency"" WHERE ""Id"" < 5");
            currencyLookUpEdit.ValueMember = "Code";
            currencyLookUpEdit.DisplayMember = "Code";
            DataModule.Connection.Close();   
            accountsLookUpEdit.DataSource = DataModule.ExecuteFill(@"SELECT Id, Num FROM Accounts WHERE ""Type"" = 1 ORDER BY Num");

            //bankAccountCBox.DataBindings.Add("SelectedValue", paymentsBS, "Bank_Account_Id");
            bankAccountCBox.DataSource = DataModule.ExecuteFill(@"SELECT Id, Num FROM Accounts WHERE ""Type"" = 1 ORDER BY Num");
            bankAccountCBox.ValueMember = "Id";
            bankAccountCBox.DisplayMember = "Num";

            bankAccountCBox.SelectedIndex = -1;
        }

        #region ClientBank menu events

        // UAH PrivatBank
        private void PrivatBankItem_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "Все файлы(*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                PrivatBankImport privatImport = new PrivatBankImport();
                try
                {
                    Load2DataTable(privatImport.GetListAccounts(openDialog.FileName), 49);
                }
                catch
                {
                    MessageBox.Show("Не можливо прочитати документ!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Default;
            }
        }

        //UAH PrivatBank card
        private void privatBankCardItem_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "Все файлы(*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                PrivatBankCardImport privatCardImport = new PrivatBankCardImport();
                try
                {
                    Load2DataTable(privatCardImport.GetCardListAccounts(openDialog.FileName), 49);
                }
                catch
                {
                    MessageBox.Show("Не можливо прочитати документ!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Default;
            }
        }

        //Currency Privat Bank
        private void PrivatBankCurrency_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "Все файлы(*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                PrivatBankImportCurrency privatImport = new PrivatBankImportCurrency();
                try
                {
                    Load2DataTable(privatImport.GetListAccounts(openDialog.FileName), 49);
                }
                catch
                {
                    MessageBox.Show("Не можливо прочитати документ!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Default;
            }
        }
        // UAH & Currency SberBank
        private void SberBankItem_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "Файл XML(*.xml)|*.xml";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                SberBankImport.iFOBS sberBank = new SberBankImport.iFOBS();
                try
                {
                    Load2DataTable(sberBank.iFOBS_UAH_Xml_Import(openDialog.FileName), 39);
                }
                catch
                {
                    MessageBox.Show("Не можливо прочитати документ!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Default;
            }
        }
        //UAH Poltava Bank
        private void PoltavaBankItem_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "Текстовые файлы(*.txt)|*.txt";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                PoltavaBankImport poltavaImport = new PoltavaBankImport();
                try
                {
                    Load2DataTable(poltavaImport.GetData(openDialog.FileName), 37);
                }
                catch
                {
                    MessageBox.Show("Не можливо прочитати документ!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Default;
            }
        }
        // Currency Polatava Bank
        private void PoltavaBankImportCurrency_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "Текстовые файлы(*.txt)|*.txt";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                PoltavaBankImportCurrency poltavaImport = new PoltavaBankImportCurrency();
                try
                {
                    Load2DataTable(poltavaImport.GetData(openDialog.FileName), 37);
                }
                catch
                {
                    MessageBox.Show("Не можливо прочитати документ!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Default;
            }
        }
        // UAH & Currency Finansy i Credit Bank
        private void FIKBankItem_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "Все файлы(*.xlsx)|*.xlsx";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                FIKImport ficBancImport = new FIKImport();
                try
                {
                    Load2DataTable(ficBancImport.Get_FIK_Excel_Import(openDialog.FileName), 45);
                }
                catch
                {
                    MessageBox.Show("Не можливо прочитати документ!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Default;
            }
        }

        // UAH & Currency "Bank Credit Dnepr"
        private void BankCreditDneprItem_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "Все файлы(*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                BankCreditDneprImport BKDImport = new BankCreditDneprImport();
                try
                {
                    Load2DataTable(BKDImport.Get_BKD_Excel_Import(openDialog.FileName), 109);
                }
                catch
                {
                    MessageBox.Show("Не можливо прочитати документ!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Default;
            }
        }

        #endregion

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            paymentsBS.EndEdit();
            paymentsBS.Position = -1;
            
            if (importDataTable.AsEnumerable().Where(r => r.Field<String>("Purpose_Account_Num") == "").Count() != 0)
            {
                MessageBox.Show("Не вказаний рахунок призначення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (importDataTable.AsEnumerable().Where(r => r.Field<Boolean>("Payment_Exists")).Count() != 0)
            {
                if (MessageBox.Show("Деякі платежі вже існують, додати тількі нові?", "Увага", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    DeleteExisting();
                else
                    return;
            }

            Periods periods = new Periods();
            DataTable openedPeriods = periods.GetOpenedPeriods();
            bool asd = false;
            
            for (int i = 0; i < importDataTable.Rows.Count; i++)
            {
                foreach (var periodRow in openedPeriods.AsEnumerable())
                {
                    if (importDataTable.Rows[i].Field<DateTime>("Payment_Date").Year == Convert.ToInt32(periodRow["Year"].ToString()) &&
                        importDataTable.Rows[i].Field<DateTime>("Payment_Date").Month == Convert.ToInt32(periodRow["Month"].ToString()))
                    {
                        asd = false;
                        break;
                    }
                    else
                    {
                        asd = true;
                    }
                }

                if (asd)
                {
                    MessageBox.Show("Період " + 
                                    importDataTable.Rows[i].Field<DateTime>("Payment_Date").ToShortDateString() +
                                    " закритий або не існує!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Cursor = Cursors.WaitCursor;
            Import();
            Cursor = Cursors.Default;
            this.Close();
        }

        private void Load2DataTable(List<PaymentImportModel> payments, short bankAccountId)
        {
            bankAccountCBox.SelectedValue = bankAccountId;
            switch (bankAccountId)
            {
                case 37:
                    bankNameLabel.Text = "Полтавабанк";
                    break;
                case 45:
                    bankNameLabel.Text = "Финансы и Кредит";
                    break;
                case 39:
                    bankNameLabel.Text = "Сбербанк";
                    break;
                case 49:
                    bankNameLabel.Text = "Приватбанк";
                    break;
                case 109:
                    bankNameLabel.Text = "Банк Кредит Днепр";
                    break;
                default:
                    bankNameLabel.Text = "";
                    break;
            }

            importDataTable.Rows.Clear();
            if (importDataTable.Columns.IndexOf("Payment_Exists") < 0)
                importDataTable.Columns.Add("Payment_Exists", typeof(bool));
            if (importDataTable.Columns.IndexOf("Recipient_Bank_Mfo") < 0)
                importDataTable.Columns.Add("Recipient_Bank_Mfo", typeof(Int32));
            if (importDataTable.Columns.IndexOf("Recipient_Bank_Name") < 0)
                importDataTable.Columns.Add("Recipient_Bank_Name", typeof(String));
            if (importDataTable.Columns.IndexOf("Recipient_Account_Num") < 0)
                importDataTable.Columns.Add("Recipient_Account_Num", typeof(Int64));
            
            DataModule.Connection.Open();

            decimal price = 0, priceCurrency = 0;

            for (int i = 0; i < payments.Count; i++)
            {
                price = (payments[i].PaymentCurrencyName == "UAH") ? payments[i].Sum : payments[i].SumEq;
                priceCurrency = (payments[i].PaymentCurrencyName == "UAH") ? 0 : payments[i].Sum;
                
                DataRow Row;
                Row = importDataTable.NewRow();

                Row["Contractor_Srn"] = payments[i].RecipientSrn;
                Row["Contractor_Name"] = payments[i].RecipientName;
                Row["Recipient_Account_Num"] = payments[i].RecipientBankAccountNum;
                Row["Payment_Document"] = payments[i].DocumentNum.ToString();
                Row["Recipient_Bank_Mfo"] = payments[i].RecipientBankCode;
                Row["Recipient_Bank_Name"] = payments[i].RecipientBankName;
                Row["Payment_Date"] = payments[i].DocumentApplyDate;
                Row["Purpose"] = payments[i].PaymentPurpose;
                Row["Payment_Price"] = price;
                Row["Payment_PriceCurrency"] = priceCurrency;
                Row["Bank_Account_Id"] = bankAccountId;
                Row["CurrencyName"] = payments[i].PaymentCurrencyName;
                Row["Rate"] = payments[i].Rate;
                
                Row["Purpose_Account_Num"] = ""; // Default value

                if (payments[i].OperationType == 1)
                {
                    Row["Debit_Price"] = price;
                    Row["Debit_PriceCurrency"] = priceCurrency;
                    Row["Direction"] = 1;
                }
                else
                {
                    Row["Credit_Price"] = price;
                    Row["Credit_PriceCurrency"] = priceCurrency;
                    Row["Direction"] = -1;
                }
                
                string purpose = payments[i].PaymentPurpose;
                
                if (purpose.Contains("товар"))
                    Row["Purpose_Account_Num"] = "631";
                if (purpose.Contains("послуг") || purpose.Contains("услуг"))
                    Row["Purpose_Account_Num"] = "63";
                //if (payments[i].PaymentCurrencyName != "UAH")
                //    Row["Purpose_Account_Num"] = "632";

                int PaymentExists = (int)DataModule.ExecuteScalar
                    (
                        @"SELECT
                            COUNT(*)
                        FROM
                            ""Bank_Payments""
                        WHERE
                            ""Bank_Payments"".""Payment_Date"" = @Payment_Date AND ""Bank_Payments"".""Payment_Document"" = @Payment_Document AND ""Bank_Payments"".""Bank_Account_Id"" = @Bank_Account_Id",
                        new FbParameter("Payment_Date", payments[i].DocumentApplyDate), new FbParameter("Payment_Document", payments[i].DocumentNum.ToString()), new FbParameter("Bank_Account_Id", bankAccountId)
                    );
                
                Row["Payment_Exists"] = (PaymentExists == 1) ? true : false;

                importDataTable.Rows.Add(Row);
            }
            
            DataModule.Connection.Close();
        }

        private void Import()
        {
            try
            {
                DataModule.Connection.Open();
                DataModule.BeginTransaction();
                paymentsBS.EndEdit();

                for (int i = 0; i < importDataTable.Rows.Count; i++)
                {
                    if (importDataTable.Rows[i].RowState == DataRowState.Deleted) continue;
                    //
                    int? contractor_id = (int?)DataModule.ExecuteScalar(@"SELECT ""Id"" FROM ""Contractors"" WHERE ""Srn"" = @Srn", new FbParameter("Srn", FbDbType.VarChar, 12) { Value = importDataTable.Rows[i].Field<String>("Contractor_Srn") });
                    if (contractor_id == null)
                    {
                        contractor_id = (int)DataModule.ExecuteScalar
                            (
                                @"INSERT INTO ""Contractors""(""Srn"", ""Name"") VALUES(@Srn, @Name) RETURNING ""Id""",
                                new FbParameter("Srn", FbDbType.VarChar, 12) { Value = importDataTable.Rows[i].Field<String>("Contractor_Srn") },
                                new FbParameter("Name", importDataTable.Rows[i].Field<String>("Contractor_Name"))
                            );
                    }
                    
                    importDataTable.Rows[i].SetField("Contractor_Id", contractor_id);
                    
                    FbParameter[] currencyParam =
                    {
                        new FbParameter("Code", FbDbType.VarChar, 3) {Value = importDataTable.Rows[i].Field<String>("CurrencyName")}
                    };
                    var currency_id = DataModule.ExecuteScalar(@"SELECT ""Id"" FROM ""Currency"" WHERE ""Code"" = @Code", currencyParam);

                    importDataTable.Rows[i].SetField("CurrencyId", currency_id);

                    var account_id = DataModule.ExecuteScalar(@"SELECT Id FROM Accounts WHERE Num = @Num", new FbParameter("Num", FbDbType.VarChar, 8) { Value = importDataTable.Rows[i].Field<String>("Purpose_Account_Num") });

                    importDataTable.Rows[i].SetField("Purpose_Account_Id", account_id);
                    //
                    //short? bank_id = (short?)DataModule.ExecuteScalar(@"SELECT ""Id"" FROM ""Banks"" WHERE ""Mfo"" = @Mfo", new FbParameter("Mfo", accountingDS.Bank_Payments[i].Recipient_Bank_Mfo));
                    //if (bank_id == null)
                    //{
                    //	bank_id = (short)DataModule.ExecuteScalar
                    //		(
                    //			@"INSERT INTO ""Banks""(""Mfo"", ""Name"") VALUES(@Mfo, @Name) RETURNING ""Id""",
                    //			new FbParameter("Mfo", accountingDS.Bank_Payments[i].Recipient_Bank_Mfo),
                    //			new FbParameter("Name", accountingDS.Bank_Payments[i].Recipient_Bank_Name)
                    //		);
                    //}
                    //
                    //short? account_id = (short?)DataModule.ExecuteScalar(@"SELECT ""Id"" FROM ""Bank_Accounts"" WHERE ""Current_Account"" = @Current_Account", new FbParameter("Current_Account", accountingDS.Bank_Payments[i].Recipient_Account_Num));
                    //if (account_id == null)
                    //{
                    //	account_id = (short)DataModule.ExecuteScalar
                    //		(
                    //			@"INSERT INTO ""Bank_Accounts""(""Contractor_Id"", ""Bank_Id"", ""Current_Account"") VALUES(@Contractor_Id, @Bank_Id, @Current_Account) RETURNING ""Id""",
                    //			new FbParameter("Contractor_Id", contractor_id),
                    //			new FbParameter("Bank_Id", bank_id),
                    //			new FbParameter("Current_Account", accountingDS.Bank_Payments[i].Recipient_Account_Num)
                    //		);
                    //}
                    //accountingDS.Bank_Payments[i].Payment_Bank_Account_Id = account_id.Value;
                }
                
                DataModule.DataAdapter["Bank_Payments"].InsertCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Transaction = DataModule.Transaction;

                DataModule.DataAdapter["Bank_Payments"].Update(importDataTable);
                DataModule.CommitTransaction();
            }
            catch (FbException FbEcpt)
            {
                if (FbEcpt.SQLSTATE == "08006")
                {
                    if (DataModule.Transaction != null)
                        DataModule.DisposeTransaction();
                }
                else
                {
                    DataModule.RollbackTransaction();
                }
                MessageBox.Show(DataModule.GetError(FbEcpt), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                DataModule.Connection.Close();
            }
        }

        private void DeleteExisting()
        {
            for (int i = importDataTable.Rows.Count - 1; i >= 0; i--)
            {
                if (importDataTable.Rows[i].Field<Boolean>("Payment_Exists"))
                    importDataTable.Rows[i].Delete();
            }
        }

        private void importCMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (importDataTable.Rows.Count == 0)
                saveMenuItem.Enabled = false;
            else
                saveMenuItem.Enabled = true;
        }

        private void paymentsGridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                if (importDataTable.Rows[e.RowHandle].Field<String>("Purpose_Account_Num") == "")
                    e.Appearance.BackColor = Color.Beige;
                if (importDataTable.Rows[e.RowHandle].Field<Boolean>("Payment_Exists"))
                    e.Appearance.BackColor = Color.Azure;
            }
        }

        private void paymentsGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                paymentsGridView.DeleteRow(paymentsGridView.FocusedRowHandle);
        }

        private void bankAccountCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bankAccountCBox.SelectedIndex > -1)
            {
                short bankId;
                bool parceBankId = Int16.TryParse(bankAccountCBox.SelectedValue.ToString(), out bankId);
                if (parceBankId && (importDataTable.Rows.Count > 0))
                {
                    DataModule.Connection.Open();

                    for (int i = 0; i < importDataTable.Rows.Count; i++)
                    {
                        importDataTable.Rows[i].SetField("Bank_Account_Id", bankId);

                        int PaymentExists = (int)DataModule.ExecuteScalar
                        (
                            @"SELECT
                                COUNT(*)
                            FROM
                                ""Bank_Payments""
                            WHERE
                                ""Bank_Payments"".""Payment_Date"" = @Payment_Date AND ""Bank_Payments"".""Payment_Document"" = @Payment_Document AND ""Bank_Payments"".""Bank_Account_Id"" = @Bank_Account_Id",
                            new FbParameter("Payment_Date", importDataTable.Rows[i]["Payment_Date"]),
                            new FbParameter("Payment_Document", importDataTable.Rows[i]["Payment_Document"]), 
                            new FbParameter("Bank_Account_Id", bankId)
                        );

                        importDataTable.Rows[i].SetField("Payment_Exists", (PaymentExists == 1) ? true : false);
                    }

                    DataModule.Connection.Close();
                }
            }
        }

   }
}
