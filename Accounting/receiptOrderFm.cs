using System;
using System.Windows.Forms;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Drawing;

namespace Accounting
{
    public partial class receiptOrderFm : Form
    {
        private DataTable contractorDataSource;
        
        private bool _inserting;
        private bool _isCurrencyReceipt;
        private long _id = -1;
        private string supplierCBox_Select = @"SELECT * FROM Suppliers WHERE Suppliers.ACTIVE = 1 ORDER BY NAME";

        private BindingSource receiptsBS = new BindingSource();private BindingSource ordersBS = new BindingSource();

        public receiptOrderFm(bool inserting, object Type, bool isCurrencyReceipt, string Date = null, int position = -1)
        {
            InitializeComponent();

            _inserting = inserting;
            _isCurrencyReceipt = isCurrencyReceipt;

            materialGrid.AutoGenerateColumns = false;
            Utils.SetDoubleBuffered(materialGrid, true);
            
            ordersBS.DataSource = DataModule.AccountingDS.Tables["Order"];

            contractorsEdit.EditValueChanged -= contractorsEdit_EditValueChanged;

            contractorDataSource = DataModule.ExecuteFill(@"SELECT * FROM ""Contractors"" ORDER BY ""Name""");

            if (_inserting)
            {
                DataModule.Connection.Open();
                _id = (long)DataModule.ExecuteScalar(@"SELECT NEXT VALUE FOR ""Seq_Order_Id"" FROM RDB$Database");
                DataModule.Connection.Close();

                DataRow Row;

                Row = DataModule.AccountingDS.Tables["Receipt"].NewRow();
                Row["Order_Id"] = _id;
                DataModule.AccountingDS.Tables["Receipt"].Rows.Add(Row);

                //

                Row = DataModule.AccountingDS.Tables["Order"].NewRow();
                Row["Order_Date"] = Convert.ToDateTime(Date);
                Row["Invoice_Date"] = Convert.ToDateTime(Date);
                Row["Id"] = _id;
                Row["Debit_Account_Num"] = (_isCurrencyReceipt) ? "632" : "";
                if (!_isCurrencyReceipt)
                {
                    Row["Currency_Id"] = 1; 
                }
                DataModule.AccountingDS.Tables["Order"].Rows.Add(Row);

                ordersBS.MoveLast();
            }
            else
            {
                ordersBS.Position = position;
                _id = Convert.ToInt64(((DataRowView)ordersBS.Current)["Id"]);
            }

            #region Visibility properties components on form

            if (_isCurrencyReceipt)
            {
                checkBox3.Visible = false;
                checkBox4.Visible = false;
            }
            else
            {
                materialGrid.Columns[8].Visible = false;
                materialGrid.Columns[9].Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label26.Visible = false;
                orderTotalCurrencyTBox.Visible = false;
                rateTBox.Visible = false;
                currencyCBox.Visible = false;
                totalCurrencyTBox.Visible = false;
                unitCurrencyTBox.Visible = false;
            }

            #endregion

            // Receipt Bind------------------------------------------------------------------------
            #region Receipt Bindings

            receiptsBS.DataSource = DataModule.AccountingDS.Tables["Receipt"];
            materialGrid.DataSource = receiptsBS;

            nomenclTBox.DataBindings.Add("Text", receiptsBS, "Nomenclature");
            nomenclNameTBox.DataBindings.Add("Text", receiptsBS, "Nomenclature_Name");

            measureTBox.DataBindings.Add("Text", receiptsBS, "Measure");

            balanceNumTBox.DataBindings.Add("Text", receiptsBS, "Balance_Num");

            quantityTBox.DataBindings.Add("Text", receiptsBS, "Quantity");

            totalPriceTBox.DataBindings.Add("Text", receiptsBS, "Total_Price");
            totalCurrencyTBox.DataBindings.Add("Text", receiptsBS, "Total_Currency");
            
            unitPriceTBox.DataBindings.Add("Text", receiptsBS, "Unit_Price").ControlUpdateMode = ControlUpdateMode.Never;
            unitCurrencyTBox.DataBindings.Add("Text", receiptsBS, "Unit_Currency").ControlUpdateMode = ControlUpdateMode.Never;

            //DataModule.DataAdapter["Nomenclatures"].Fill(DataModule.AccountingDS.Tables["Nomenclatures"]);
            //nomenclatureEdit.Properties.DataSource = DataModule.AccountingDS.Tables["Nomenclatures"];
            //nomenclatureEdit.DataBindings.Add("EditValue", receiptsBS, "Nomenclature_Id");
            //nomenclatureEdit.Properties.ValueMember = "ID";
            //nomenclatureEdit.Properties.DisplayMember = "Nomenclature";
            //nomenclatureEdit.Properties.NullText = "Немає даних";

            #endregion Receipt Bindings

            // Order Bind--------------------------------------------------------------------------
            #region Order Bindings

            invoiceDatePicker.DataBindings.Add("Value", ordersBS, "Invoice_Date");
            invoiceNumTBox.DataBindings.Add("Text", ordersBS, "Invoice_Num");
            orderDatePicker.DataBindings.Add("Value", ordersBS, "Order_Date");
            receiptNumTBox.DataBindings.Add("Text", ordersBS, "Receipt_Num");
            srnTBox.DataBindings.Add("Text", ordersBS, "Vendor_Srn");

            contractorsEdit.EditValue = ((DataRowView)ordersBS.Current)["Vendor_Id"];
            contractorsEdit.Properties.DataSource = contractorDataSource;
            contractorsEdit.Properties.ValueMember = "Id";
            contractorsEdit.Properties.DisplayMember = "Name";
            contractorsEdit.Properties.NullText = "Немає даних";

            supplierCBox.DataSource = DataModule.ExecuteFill(supplierCBox_Select);
            supplierCBox.ValueMember = "Id";
            supplierCBox.DisplayMember = "Name";

            otkCBox.DataSource = DataModule.ExecuteFill(@"SELECT * FROM Suppliers WHERE Suppliers.ACTIVE = 1 AND (Suppliers.GROUP_ID = 4 OR Suppliers.ID = 29) ORDER BY NAME");
            otkCBox.ValueMember = "Id";
            otkCBox.DisplayMember = "Name";
            
            storeKeeperCBox.DataSource = DataModule.ExecuteFill(@"SELECT * FROM Suppliers WHERE Suppliers.ACTIVE = 1 AND (Suppliers.GROUP_ID=3 OR Suppliers.ID = 29) ORDER BY NAME");
            storeKeeperCBox.ValueMember = "Id";
            storeKeeperCBox.DisplayMember = "Name";

            supplierCBox.DataBindings.Add("SelectedValue", ordersBS, "Supplier_Id");
            supplierCBox.DataBindings.Add("Text", ordersBS, "Supplier_Name");
            
            storeKeeperCBox.DataBindings.Add("SelectedValue", ordersBS, "Storekeeper_Id");
            storeKeeperCBox.DataBindings.Add("Text", ordersBS, "Storekeeper_Name");
            otkCBox.DataBindings.Add("SelectedValue", ordersBS, "Otk_Id");
            otkCBox.DataBindings.Add("Text", ordersBS, "Otk_Name");
            
            supplierProxyTBox.DataBindings.Add("Text", ordersBS, "Supplier_Proxy");
            debitCBox.DataBindings.Add("SelectedValue", ordersBS, "Debit_Account_Id");
            debitCBox.DataBindings.Add("Text", ordersBS, "Debit_Account_Num");

            debitCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            debitCBox.ValueMember = "Id";
            debitCBox.DisplayMember = "Num";

            currencyCBox.DataBindings.Add("SelectedValue", ordersBS, "Currency_Id");
            //currencyCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Currency"]);
            DataModule.Connection.Open();
            currencyCBox.DataSource = DataModule.ExecuteFillProc("CurrencyProc");
            DataModule.Connection.Close();
            currencyCBox.ValueMember = "Id";
            currencyCBox.DisplayMember = "Code";

            orderTotalPriceTBox.DataBindings.Add("Text", ordersBS, "Total_Price"); //, true, DataSourceUpdateMode.OnPropertyChanged, 0, "N", Utils.NumFormat(2)
            orderTotalCurrencyTBox.DataBindings.Add("Text", ordersBS, "Total_Currency");
            rateTBox.DataBindings.Add("Text", ordersBS, "Currency_Rate");

            orderVatTBox.DataBindings.Add("Text", ordersBS, "Vat");
            vatAccountChBox.DataSource = DataModule.ExecuteFill("SELECT * FROM Accounts WHERE Num IN('641/2', '644')");
            vatAccountChBox.ValueMember = "Id";
            vatAccountChBox.DisplayMember = "Num";
            vatAccountChBox.DataBindings.Add("SelectedValue", ordersBS, "Vat_Account_Id");
            vatAccountChBox.DataBindings.Add("Text", ordersBS, "Vat_Account_Num");

            orderWithVatTBox.DataBindings.Add("Text", ordersBS, "Total_With_Vat");

            taxInvoiceChBox.DataBindings.Add("Checked", ordersBS, "Tax_Invoice");
            transportInvoiceChBox.DataBindings.Add("Checked", ordersBS, "Transport_Invoice");
            checkedChBox.DataBindings.Add("Checked", ordersBS, "Checked");
            correctionChBox.DataBindings.Add("Checked", ordersBS, "Correction");

            checkBox1.DataBindings.Add("Checked", ordersBS, "Flag1");
            checkBox2.DataBindings.Add("Checked", ordersBS, "Flag2");
            checkBox3.DataBindings.Add("Checked", ordersBS, "Flag3");
            checkBox4.DataBindings.Add("Checked", ordersBS, "Flag4");

            contractorsEdit.EditValueChanged += contractorsEdit_EditValueChanged;

            #endregion Order Bindings
        }
        
        private void receiptOrderFm_Load(object sender, EventArgs e)
        {
            if (_inserting)
            {
                checkBox1.Checked = Properties.Settings.Default.Flag1;
                checkBox2.Checked = Properties.Settings.Default.Flag2;
                checkBox3.Checked = (_isCurrencyReceipt) ? false : Properties.Settings.Default.Flag3;
                checkBox4.Checked = (_isCurrencyReceipt) ? false : Properties.Settings.Default.Flag4;
                vatChBox.Checked = (_isCurrencyReceipt) ? false : true;
                
                if (checkBox4.Checked) debitCBox.Text = "63";
                if ((checkBox1.Checked || checkBox3.Checked) && !_isCurrencyReceipt) debitCBox.Text = "631";
                
                supplierCBox.Text = "Немає"; 
                storeKeeperCBox.Text = "Немає"; 
                otkCBox.Text = "Немає";
            }
            else
            {
                if (((DataRowView)ordersBS.Current)["Vat"] == DBNull.Value)
                    vatChBox.Checked = false;
            }
            			
            debitCBox_SelectedIndexChanged(this, new EventArgs());
        }

        private void contractorsEdit_EditValueChanged(object sender, EventArgs e)
        {

            var view = (DataRowView)contractorsEdit.GetSelectedDataRow();

            if (view != null)
            {
                DataRow dr = view.Row;
                ((DataRowView)ordersBS.Current)["Vendor_Id"] = dr["Id"];
                ((DataRowView)ordersBS.Current)["Vendor_Name"] = dr["Name"];

                srnTBox.Text = dr["Srn"].ToString();
            }
        }

		private void debitCBox_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (debitCBox.Text == "63")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = true;
            }
           
		}

        private void receiptOrderFm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_inserting && !ordersFm.OkBtn)
            {
                if (MessageBox.Show("Дані не були збережені! Закрити вікно без змін?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            DataModule.AccountingDS.Tables["Order"].RejectChanges();
            DataModule.AccountingDS.Tables["Receipt"].RejectChanges();
        }

        private string messageText = ""; // variable for output validating error list message

        private void okBtn_Click(object sender, EventArgs e)
        {

            ((DataRowView)ordersBS.Current)["Vendor_Id"] = contractorsEdit.EditValue;

            #region Validation

            if (!_isCurrencyReceipt)
            {
                decimal vat = (orderVatTBox.Text.Length == 0) ? 0.00m : Convert.ToDecimal(orderVatTBox.Text);
                decimal totalPrice = (orderTotalPriceTBox.Text.Length == 0) ? 0.00m : Convert.ToDecimal(orderTotalPriceTBox.Text);
                decimal totalPriceWithVat = (orderWithVatTBox.Text.Length == 0) ? 0.00m : Convert.ToDecimal(orderWithVatTBox.Text);

                if(totalPriceWithVat != (totalPrice  + vat))
                    messageText += "Помилка при введені суми ПДВ та загальної суми. \n";
            }

            if (contractorsEdit.EditValue == DBNull.Value)
            {
                messageText += "Не вибрано контрагента. \n";
            }

            if (nomenclTBox.Text.Length == 0 || quantityTBox.Text.Length == 0 || totalPriceTBox.Text.Length == 0)
            {
                messageText += "Не вибрана номенклатура, не вказана кількість або вартість. \n";
            }
            
            if (supplierCBox.SelectedValue == null)
            {
                messageText += "Не вказаний постачальник. \n";
            }

            if (debitCBox.SelectedValue == null)
            {
                messageText += "Не вказаний рахунок по дебету. \n";
            }

            if (vatChBox.Checked)
            {
                if (orderVatTBox.Text.Length == 0 || orderWithVatTBox.Text.Length == 0)
                {
                    messageText += "Не вказаний ПДВ або сума з ПДВ. \n";
                }

                if (vatAccountChBox.SelectedValue == null)
                {
                    messageText += "Не вказаний рахунок ПДВ. \n";                    
                }
            }

            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
            {
                messageText += "Не обрана відмітка. \n";
            }

            if (_isCurrencyReceipt)
            {
                if (currencyCBox.SelectedValue == null)
                {
                    messageText += "Не вказана валюта. \n";
                }

                if (rateTBox.Text.Length == 0)
                {
                    messageText += "Не вказаний курс валюти. \n";
                }
            }

            if (messageText.Length != 0)
            {
                MessageBox.Show(messageText, "Не заповнено одне або декілька полів", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                messageText = "";
                return;
            }
            
            #endregion

            ordersBS.EndEdit();
            if (FindRepetition())
            {
                MessageBox.Show("Увага! Такий документ вже існує!", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!_inserting)
            {
                receiptsBS.EndEdit();
                string expNom = FindExp();
                if (expNom.Length != 0)
                {
                    if (MessageBox.Show("Матеріали знаходяться у списанні!\n" + FindExp(), "Увага", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
            }

            DateTime receiptDate = Convert.ToDateTime(((DataRowView)ordersBS.Current)["Order_Date"]);
            DateTime invoiceDate = Convert.ToDateTime(((DataRowView)ordersBS.Current)["Invoice_Date"]);
           

            if (!CheckPeriod())
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Період закритий або не існує!!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor = Cursors.WaitCursor;

            DataModule.Connection.Open();
            DataModule.BeginTransaction();

            InsertMaterials();

            receiptsBS.EndEdit();
            ordersBS.EndEdit();

            DataModule.DataAdapter["Order"].InsertCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["Order"].UpdateCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["Vat"].InsertCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["Vat"].UpdateCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["Receipt"].InsertCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["Receipt"].UpdateCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["Receipt"].DeleteCommand.Transaction = DataModule.Transaction;

            try
            {
                DataModule.DataAdapter["Order"].Update(DataModule.AccountingDS.Tables["Order"].GetChanges());
                DataModule.DataAdapter["Vat"].Update(DataModule.AccountingDS.Tables["Order"]);
                DataModule.DataAdapter["Receipt"].Update(DataModule.AccountingDS.Tables["Receipt"]);
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

            ordersFm.OkBtn = true;

            this.Close();
        }

        private bool FindRepetition()
        {
            string query =
                @"SELECT
                    COUNT(*)
                FROM
                    Orders
                WHERE
                    Orders.Id <> @Order_Id AND
                    Orders.Vendor_Id = @Contractor_Id AND
                    Orders.Invoice_Date = @Invoice_Date AND
                    UPPER(Orders.Invoice_Num) = UPPER(@Invoice_Num) AND
                    IIF(Orders.Total_With_Vat IS NOT NULL, Orders.Total_With_Vat, Orders.Total_Price) = @Price";

            FbParameter[] queryParams =
            {
                new FbParameter("Order_Id", ((DataRowView)ordersBS.Current)["Id"].ToString()),
                new FbParameter("Contractor_Id", ((DataRowView)ordersBS.Current)["Vendor_Id"].ToString()),
                new FbParameter("Invoice_Date", ((DataRowView)ordersBS.Current)["Invoice_Date"].ToString()),
                new FbParameter("Invoice_Num", ((DataRowView)ordersBS.Current)["Invoice_Num"].ToString()),
                new FbParameter("Price", orderWithVatTBox.Text.Length != 0 ? Convert.ToDecimal(orderWithVatTBox.Text) : Convert.ToDecimal(orderTotalPriceTBox.Text))
            };

            DataModule.Connection.Open();
            bool result = (int)DataModule.ExecuteScalar(query, queryParams) != 0 ? true : false;
            DataModule.Connection.Close();

            return result;
        }

        private string FindExp()
        {
            string query =
                @"SELECT
                    Receipts.Nomenclature_Id
                FROM
                    Orders, Receipts, Expenditures_Accountant
                WHERE
                    Receipts.Order_Id = Orders.Id AND
                    Expenditures_Accountant.Receipt_Id = Receipts.Id AND
                    Orders.Id = @Order_Id
                GROUP BY
                    Receipts.Nomenclature_Id";

            DataModule.Connection.Open();
            DataTable expTable = DataModule.ExecuteFill(query, new FbParameter("Order_Id", ((DataRowView)ordersBS.Current)["Id"].ToString()));
            DataModule.Connection.Close();

            DataTable receiptTable = DataModule.AccountingDS.Tables["Receipt"];//.GetChanges();

            string nomenclatures = "";
            if (receiptTable != null)
            {
                for (int i = 0; i < receiptTable.Rows.Count; i++)
                {
                    for (int j = 0; j < expTable.Rows.Count; j++)
                    {
                        if (expTable.Rows[j]["Nomenclature_Id"].ToString() == receiptTable.Rows[i]["Nomenclature_Id"].ToString())
                        {
                            nomenclatures += receiptTable.Rows[i]["Nomenclature"].ToString() + "; ";
                        }
                    }
                }
            }
            return nomenclatures;
        }

        //------------------------------------------------------------------------------------------------------------------
        #region DictionariesInsert

        private void InsertMaterials()
        {
            FbParameter[] Parameters = 
                {
                    new FbParameter("Nomenclature", null),
                    new FbParameter("Name", null),
                    new FbParameter("Measure", null),
                    new FbParameter("Balance_Account_Id", null)
                };

            for (int i = 0; i < DataModule.AccountingDS.Tables["Receipt"].Rows.Count; i++)
            {
                if (DataModule.AccountingDS.Tables["Receipt"].Rows[i].RowState == DataRowState.Deleted)
                    continue;
                if ((int)DataModule.ExecuteScalar("SELECT COUNT(Nomenclature) FROM Nomenclatures WHERE Nomenclature = '" + DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Nomenclature"] + "'") > 0)
                    continue;
                
                Parameters[0].Value = DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Nomenclature"];
                Parameters[1].Value = DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Nomenclature_Name"].ToString().Trim();
                Parameters[2].Value = DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Measure"].ToString().Trim();
                Parameters[3].Value = DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Balance_Account_Id"];

                DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Nomenclature_Id"] = DataModule.ExecuteScalar
                    (
                        @"INSERT INTO
                            Nomenclatures(Nomenclature, Name, Measure, Balance_Account_Id)
                        VALUES
                            (@Nomenclature, @Name, @Measure, @Balance_Account_Id)
                        RETURNING
                            Id",
                        Parameters
                    );
            }
        }

        #endregion DictionariesInsert

        //------------------------------------------------------------------------------------------------------------------
        #region Buttons

        private void AddMaterial(int pos)
        {
            if
                (
                    nomenclTBox.Text.Length == 0 || nomenclNameTBox.Text.Length == 0 || measureTBox.Text.Length == 0 ||
                    quantityTBox.Text.Length == 0 || totalPriceTBox.Text.Length == 0
                )
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            nomenclEP.Clear();

            DataRow Row = DataModule.AccountingDS.Tables["Receipt"].NewRow();
            Row["Order_Id"] = _id;

            switch (pos)
            {
                case 0:
                    DataModule.AccountingDS.Tables["Receipt"].Rows.Add(Row);
                    receiptsBS.MoveLast();
                    break;
                case 1:
                    DataModule.AccountingDS.Tables["Receipt"].Rows.InsertAt(Row, receiptsBS.Position);
                    receiptsBS.MovePrevious();
                    break;
                case 2:
                    DataModule.AccountingDS.Tables["Receipt"].Rows.InsertAt(Row, receiptsBS.Position + 1);
                    receiptsBS.MoveNext();
                    break;
            }

            nomenclTBox.Focus();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddMaterial(0);
        }

        private void addDropBtn_Click(object sender, EventArgs e)
        {
            addMenuStrip.Show(addDropBtn, 1, addDropBtn.Height - 1);
        }

        private void addBeforeTSMenu_Click(object sender, EventArgs e)
        {
            AddMaterial(1);
        }

        private void addAfterTSMenu_Click(object sender, EventArgs e)
        {
            AddMaterial(2);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалили запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                receiptsBS.RemoveCurrent();
                CalculateSum();
                nomenclEP.Clear();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Buttons

        //------------------------------------------------------------------------------------------------------------------
        #region Calculations

        private void vatChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vatChBox.Checked)
            {
                orderVatTBox.ReadOnly = false;
                //orderWithVatTBox.ReadOnly = false;
                vatAccountChBox.Enabled = true;

                CalculateSum();
            }
            else
            {
                ordersBS.EndEdit();
                
                ((DataRowView)ordersBS.Current)["Vat"] = DBNull.Value;
                ((DataRowView)ordersBS.Current)["Total_With_Vat"] = ((DataRowView)ordersBS.Current)["Total_Price"];
                ((DataRowView)ordersBS.Current)["Vat_Account_Num"] = DBNull.Value;
                ((DataRowView)ordersBS.Current)["Vat_Account_Id"] = DBNull.Value;

                orderVatTBox.Text = "";
                orderVatTBox.ReadOnly = true;
                //orderWithVatTBox.ReadOnly = true;
                vatAccountChBox.Enabled = false;
            }
        }

        private void UnitPrice()
        {
            decimal Quantity = quantityTBox.Text.Length == 0 ? 0.000m : Convert.ToDecimal(quantityTBox.Text);
            decimal TotalPrice = totalPriceTBox.Text.Length == 0 ? 0.00m : Convert.ToDecimal(totalPriceTBox.Text);
                        
            if (Quantity > 0)
            {
                decimal UnitPrice = TotalPrice / Quantity;
                unitPriceTBox.Text = Math.Round(UnitPrice, 2).ToString("N", Utils.NumFormat(2));
            }
            else
            {
                unitPriceTBox.Text = "";
            }
        }

        private void UnitCurrency()
        {
            decimal Quantity = quantityTBox.Text.Length == 0 ? 0.000m : Convert.ToDecimal(quantityTBox.Text);
            decimal TotalCurrency = totalCurrencyTBox.Text.Length == 0 ? 0.00m : Convert.ToDecimal(totalCurrencyTBox.Text);

            if (Quantity > 0 && TotalCurrency > 0)
            {
                decimal UnitCurrency = TotalCurrency / Quantity;
                unitCurrencyTBox.Text = Math.Round(UnitCurrency, 2).ToString("N", Utils.NumFormat(2));
            }
            else
            {
                unitCurrencyTBox.Text = "";
            }
        }

        private decimal CalcTotalPrice()
        {
            decimal Sum = 0.00m;
            for (int i = 0; i < DataModule.AccountingDS.Tables["Receipt"].Rows.Count; i++)
            {
                if (DataModule.AccountingDS.Tables["Receipt"].Rows[i].RowState != DataRowState.Deleted && DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Total_Price"] != DBNull.Value)
                    Sum += Convert.ToDecimal(DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Total_Price"]);
            }
            return Sum;
        }

        private decimal CalcTotalCurrency() // Сумма в валюте
        {
            decimal Sum = 0.00m;
            for (int i = 0; i < DataModule.AccountingDS.Tables["Receipt"].Rows.Count; i++)
            {
                if (DataModule.AccountingDS.Tables["Receipt"].Rows[i].RowState != DataRowState.Deleted && DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Total_Currency"] != DBNull.Value)
                    Sum += Convert.ToDecimal(DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Total_Currency"]);
            }
            return Sum;
        }

        private void CalculateSum()
        {
            decimal TotalPrice = 0.00m;
            decimal TotalCurrency = 0.00m;
            
            TotalPrice = CalcTotalPrice();
            TotalCurrency = CalcTotalCurrency();
            
            orderTotalPriceTBox.Text = TotalPrice.ToString("N", Utils.NumFormat(2));
            orderTotalCurrencyTBox.Text = TotalCurrency.ToString("N", Utils.NumFormat(2));

            if (vatChBox.Checked)
            {
                decimal Vat = 0.00m;
                decimal TotalPriceWithVat = 0.00m;

                Vat = TotalPrice * 0.2m;
                TotalPriceWithVat = TotalPrice + Vat;

                orderVatTBox.Text = Math.Round(Vat, 2).ToString("N", Utils.NumFormat(2));
                orderWithVatTBox.Text = Math.Round(TotalPriceWithVat, 2).ToString("N", Utils.NumFormat(2));
            }
            else
            {
                orderWithVatTBox.Text = orderTotalPriceTBox.Text;
            }
        }

        private void quantityTBox_TextChanged(object sender, EventArgs e)
        {
            if (quantityTBox.Text.Length == 1 && quantityTBox.Text == "-")
                return;
            UnitPrice();
            UnitCurrency();

        }

        private void totalPriceTBox_TextChanged(object sender, EventArgs e)
        {
            if (totalPriceTBox.Text.Length == 1 && totalPriceTBox.Text == "-")
                return;
            UnitPrice();
        }

        private void totalCurrencyTBox_TextChanged(object sender, EventArgs e)
        {
            if (totalCurrencyTBox.Text.Length == 1 && totalCurrencyTBox.Text == "-")
                return;
            UnitCurrency();

        }

        private void orderVatTBox_TextChanged(object sender, EventArgs e)
        {
            if (orderVatTBox.Text.Length == 1 && orderVatTBox.Text == "-")
                return;

            decimal vat = (orderVatTBox.Text.Length == 0) ? 0.00m : Convert.ToDecimal(orderVatTBox.Text);
            decimal totalPrice = (orderTotalPriceTBox.Text.Length == 0) ? 0.00m : Convert.ToDecimal(orderTotalPriceTBox.Text);
            decimal totalPriceWithVat = totalPrice + vat;

            orderWithVatTBox.Text = totalPriceWithVat.ToString("N", Utils.NumFormat(2));
        }


        #endregion Calculations

        //------------------------------------------------------------------------------------------------------------------
        #region Dictionaries

        private void openSuppliersRBFm_Click(object sender, EventArgs e)
        {
            suppliersRBFm suppliersRBFm = new suppliersRBFm();
            suppliersRBFm.ShowDialog();
            supplierCBox.DataSource = DataModule.ExecuteFill(supplierCBox_Select);
            supplierCBox.SelectedIndex = -1;
            supplierCBox.Focus();
        }

        private void openRBNomenclBtn_Click(object sender, EventArgs e)
        {
            nomenclRBFm nomenclRBFm = new nomenclRBFm();
            if (nomenclRBFm.ShowDialog() == DialogResult.OK)
            {
                DataRow Row = nomenclRBFm.Return();
                nomenclTBox.Text = Row["Nomenclature"].ToString();
                CheckNomenclature(Row["Nomenclature"].ToString());
                receiptsBS.EndEdit();

                quantityTBox.Focus();
            }
        }

        private void openRBDebitBtn_Click(object sender, EventArgs e)
        {
            accountsRBFm accountsRBFm = new accountsRBFm();
            accountsRBFm.ShowDialog();
            debitCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            debitCBox.SelectedIndex = -1;
            debitCBox.Focus();
        }

        #endregion Dictionaries

        //------------------------------------------------------------------------------------------------------------------
        #region EnterChecking

        private void quantityTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (correctionChBox.Checked)
                Utils.EnterCheck(sender, e, 6, 4, true, false);
            else
                Utils.EnterCheck(sender, e, 6, 4, true);

            
            if (e.KeyChar == (char)Keys.Enter)
            {
                receiptsBS.EndEdit();

                if (e.KeyChar != '-')
                    CalculateSum();

                totalPriceTBox.Focus();
            }
        }

        private void totalPriceTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (correctionChBox.Checked)
                Utils.EnterCheck(sender, e, 9, 2, false, false);
            else
                Utils.EnterCheck(sender, e, 9, 2);

            if (e.KeyChar == (char)Keys.Enter)
            {
                receiptsBS.EndEdit();

                if (e.KeyChar != '-')
                    CalculateSum();

                a = false;

                if (_isCurrencyReceipt)
                {
                    totalCurrencyTBox.Focus();
                }
                else
                {
                    addBtn.Focus();
                }

            }
        }

        private void totalCurrencyTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (correctionChBox.Checked)
                Utils.EnterCheck(sender, e, 9, 2, false, false);
            else
                Utils.EnterCheck(sender, e, 9, 2);

            if (e.KeyChar == (char)Keys.Enter)
            {
                receiptsBS.EndEdit();

                if (e.KeyChar != '-')
                    CalculateSum();
                decimal totalCurrency = (totalCurrencyTBox.Text.Length > 0) ? decimal.Parse(totalCurrencyTBox.Text) : 0.00m;
                decimal rate = (rateTBox.Text.Length > 0) ? decimal.Parse(rateTBox.Text) : 0.00m;
                totalPriceTBox.Text = Math.Round(totalCurrency * rate, 2).ToString();
                a = false;
                addBtn.Focus();
            }
        }

        private void orderNDSTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (correctionChBox.Checked)
                Utils.EnterCheck(sender, e, 9, 2, false, false);
            else
                Utils.EnterCheck(sender, e, 9, 2);
        }

        private void orderWithNDSTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (correctionChBox.Checked)
                Utils.EnterCheck(sender, e, 9, 2, false, false);
            else
                Utils.EnterCheck(sender, e, 9, 2);
        }

        private void rateTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (correctionChBox.Checked)
                Utils.EnterCheck(sender, e, 9, 6, false, false);
            else
                Utils.EnterCheck(sender, e, 9, 6);
            if (e.KeyChar == (char)Keys.Enter)
            {
                receiptsBS.EndEdit();
                decimal totalCurrency = (totalCurrencyTBox.Text.Length > 0) ? decimal.Parse(totalCurrencyTBox.Text) : 0.00m;
                decimal rate = (rateTBox.Text.Length > 0) ? decimal.Parse(rateTBox.Text) : 0.00m;
                totalPriceTBox.Text = Math.Round(totalCurrency * rate, 2).ToString();
                nomenclTBox.Focus();
            }
        }

        #endregion EnterChecking

        //------------------------------------------------------------------------------------------------------------------
        #region InsertIntoDictionaries

        private void nomenclTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.OnlyNumbers(e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                CheckNomenclature(nomenclTBox.Text);
                receiptsBS.EndEdit();
            }
        }

        private void nomenclCBox_Leave(object sender, EventArgs e)
        {
            CheckNomenclature(nomenclTBox.Text);
        }

        ErrorProvider nomenclEP = new ErrorProvider();
        DataTable BalanceTable = new DataTable();


        private void CheckNomenclature(string Nomenclature)
        {
            receiptsBS.EndEdit();
            nomenclEP.Clear();
            if (Nomenclature.Length == 0)
            {
                ((DataRowView)receiptsBS.Current)["Nomenclature"] = DBNull.Value;
                ((DataRowView)receiptsBS.Current)["Nomenclature_Name"] = DBNull.Value;
                ((DataRowView)receiptsBS.Current)["Measure"] = DBNull.Value;
                ((DataRowView)receiptsBS.Current)["Balance_Num"] = DBNull.Value;
                return;
            }

            DataTable NomenclatureTable = DataModule.ExecuteFill
                (
                    @"SELECT
                        Nomenclatures.Id, Nomenclatures.Name, Nomenclatures.Measure, Nomenclatures.""Nomencl_Group_Id"", Nomenclatures.Balance_Account_Id, Accounts.Num
                    FROM
                        Nomenclatures, Accounts
                    WHERE
                        Nomenclatures.Balance_Account_Id = Accounts.Id AND
                        Nomenclature = @Nomenclature",
                    new FbParameter("Nomenclature", Nomenclature)
                );

            if (NomenclatureTable.Rows.Count != 0)
            {
                ((DataRowView)receiptsBS.Current)["Nomenclature_Name"] = NomenclatureTable.Rows[0]["Name"];
                ((DataRowView)receiptsBS.Current)["Measure"] = NomenclatureTable.Rows[0]["Measure"];
                ((DataRowView)receiptsBS.Current)["Balance_Num"] = NomenclatureTable.Rows[0]["Num"];

                ((DataRowView)receiptsBS.Current)["Nomenclature_Id"] = NomenclatureTable.Rows[0]["Id"];
                ((DataRowView)receiptsBS.Current)["Balance_Account_Id"] = NomenclatureTable.Rows[0]["Balance_Account_Id"];
                ((DataRowView)receiptsBS.Current)["Nomencl_Group_Id"] = NomenclatureTable.Rows[0]["Nomencl_Group_Id"];

                quantityTBox.Focus();
            }
            else
            {
                ((DataRowView)receiptsBS.Current)["Nomenclature_Name"] = DBNull.Value;
                ((DataRowView)receiptsBS.Current)["Measure"] = DBNull.Value;
                ((DataRowView)receiptsBS.Current)["Balance_Num"] = DBNull.Value;
                ((DataRowView)receiptsBS.Current)["Nomencl_Group_Id"] = 0;

                if (BalanceTable.Rows.Count == 0)
                    BalanceTable = DataModule.ExecuteFill("SELECT * FROM Accounts ORDER BY CHAR_LENGTH(Num) DESC");
                for (int i = 0; i < BalanceTable.Rows.Count; i++)
                {
                    /*
                    if (Nomenclature.Length < BalanceTable.Rows[i]["Num"].ToString().Replace("/", "").Length)
                    {
                        MessageBox.Show("Такого балансового счёта нет в базе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ((DataRowView)receiptsBS.Current)["Balance_Account_Id"] = DBNull.Value;
                        ((DataRowView)receiptsBS.Current)["Nomencl_Group_Id"] = DBNull.Value;
                        ((DataRowView)receiptsBS.Current)["Nomenclature"] = DBNull.Value;
  
                        return;
                    }
                     */
                    string tempValue = BalanceTable.Rows[i]["Num"].ToString().Replace("/", "");
                    if (Nomenclature.Length >= tempValue.Length && Nomenclature.IndexOf(tempValue, 0, tempValue.Length) != -1)
                    {
                        DataModule.AccountingDS.Tables["Receipt"].Rows[receiptsBS.Position]["Balance_Account_Id"] = BalanceTable.Rows[i]["Id"];
                        balanceNumTBox.Text = BalanceTable.Rows[i]["Num"].ToString();
                        break;
                    }
                    else
                    {
                        if (i == BalanceTable.Rows.Count - 1)
                        {
                            MessageBox.Show("Балансового рахунку не існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ((DataRowView)receiptsBS.Current)["Balance_Account_Id"] = DBNull.Value;
                            ((DataRowView)receiptsBS.Current)["Nomencl_Group_Id"] = DBNull.Value;
                            ((DataRowView)receiptsBS.Current)["Nomenclature"] = DBNull.Value;
                            nomenclTBox.Text = "";
                            nomenclTBox.Focus();
                            return;
                        }
                    }
                }

                nomenclEP.Icon = Properties.Resources.Plus_Grey;
                nomenclEP.SetError(balanceNumTBox, "Номенклатура буде додана до бази");
                nomenclNameTBox.Focus();
            }
        }
        

        #endregion InsertIntoDictionaries

        //------------------------------------------------------------------------------------------------------------------
        #region FoucusMoving

        private void invoiceDatePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                orderDatePicker.Focus();
        }

        private void orderDatePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                receiptNumTBox.Focus();
        }

        private void receiptNumTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                contractorsEdit.Focus();
        }

        private bool a, c, s, o;
        private void contractorsEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (c)
                    invoiceNumTBox.Focus();
                c = true;
            }
        }

        private void invoiceNumTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                c = false;
                supplierCBox.Focus();
            }
        }

        private void supplierProxyTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                a = false;
                debitCBox.Focus();
            }
        }

        private void measureTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                quantityTBox.Focus();
            }
        }

        private void supplierCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                s = false;
                if (c)
                    storeKeeperCBox.Focus();
                c = true;
            }
        }

        private void storeKeeperCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                o = false;
                if (s)
                    otkCBox.Focus();
                s = true;
            }
        }

        private void otkCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (o)
                    supplierProxyTBox.Focus();
                o = true;
            }
        }

        private void nomenclNameTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                measureTBox.Focus();
            }
        }

        private void debitCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (a)
                    nomenclTBox.Focus();
                a = true;
            }
        }

        #endregion FoucusMoving

        //------------------------------------------------------------------------------------------------------------------
        #region ToolTip

        private void nomenclNameTBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(nomenclNameTBox, nomenclNameTBox.Text);
        }
                
        #endregion ToolTip

        //------------------------------------------------------------------------------------------------------------------

        private void totalPriceTBox_Leave(object sender, EventArgs e)
        {
            receiptsBS.EndEdit();
            CalculateSum();
        }

        private void totalCurrencyTBox_Leave(object sender, EventArgs e)
        {
            receiptsBS.EndEdit();
            CalculateSum();
        }

        private void quantityTBox_Leave(object sender, EventArgs e)
        {
            receiptsBS.EndEdit();
        }

        private void invoiceDatePicker_ValueChanged(object sender, EventArgs e)
        {
            orderDatePicker.Value = invoiceDatePicker.Value;
        }

        private void printOrderBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            ordersBS.EndEdit();
            receiptsBS.EndEdit();

            try
            {
                Reports Report = new Reports();
                //Report.ReceiptOrder(ordersBS.Position);
                Report.ReceiptOrder(_id);
            }
            catch
            {
                MessageBox.Show("Перевірте дані!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Cursor = Cursors.Default;
        }

        private void orderVatTBox_Leave(object sender, EventArgs e)
        {
            ordersBS.EndEdit();
        }

        private bool CheckPeriod()
        {
            FbParameter[] Parameters =
            {
                new FbParameter("Month",orderDatePicker.Value.Month),
                new FbParameter("Year", orderDatePicker.Value.Year)
   
            };

            DataModule.Connection.Open();
            short? State =
                (short?)
                    DataModule.ExecuteScalar(
                        @"SELECT ""State"" FROM ""Periods"" WHERE ""Month"" = @Month AND ""Year"" = @Year", Parameters);
            DataModule.Connection.Close();

            if ((State == 1))
            {
                return true;
            }
            else
                if (State == null)
                {
                    if
                        (MessageBox.Show("Даний період не доданий! Додати період?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        InsertPeriod();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
        }

        private void InsertPeriod()
        {
            FbParameter[] Parameters =
                {
                new FbParameter("Month",orderDatePicker.Value.Month),
                new FbParameter("Year", orderDatePicker.Value.Year)
                };

            DataModule.Connection.Open();
            short? State = (short?)DataModule.ExecuteScalar(@"INSERT INTO ""Periods"" (""State"",""Month"",""Year"" ) VALUES ( 1,@Month,@Year)", Parameters);
            DataModule.Connection.Close();
        }

        private void contractorsEdit_Properties_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        private void contractorsEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                contractorsRBFm contractorsFM = new contractorsRBFm();
                contractorsFM.ShowDialog();
                contractorDataSource = DataModule.ExecuteFill(@"SELECT * FROM ""Contractors"" ORDER BY ""Name""");
                contractorsEdit.Properties.DataSource = contractorDataSource;
            }
        }

        
    }
}
