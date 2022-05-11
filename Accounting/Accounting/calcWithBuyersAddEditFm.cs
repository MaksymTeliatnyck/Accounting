using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FirebirdSql.Data.FirebirdClient;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace Accounting
{
    public partial class calcWithBuyersAddEditFm : Form
    {
        private bool _inserting;
        private int _recordId;

        private DataTable responsibleDataSource;
        private DataTable calcBuyersTable;
        private DataTable currencyRatesTable;
        private DataTable customerOrdersDataSource;
        private DataTable contractorDataSource;

        private BindingSource calcWithBuyersBS = new BindingSource();
        private BindingSource currencyRatesBS = new BindingSource();

        public calcWithBuyersAddEditFm(bool inserting, int position = -1, int recordId = -1)
        {
            InitializeComponent();

            employeesEdit.EditValueChanged -= employeesEdit_EditValueChanged;
            contractorsEdit.EditValueChanged -= contractorsEdit_EditValueChanged;
            currencyCBox.SelectedValueChanged -= currencyCBox_SelectedValueChanged;

            responsibleDataSource = DataModule.ExecuteFill(@"SELECT EMPLOYEEID AS ""Id"", FULLNAME AS ""Name"", EMPLOYEE_NUMBER AS ""Number"" FROM Responsible");
            contractorDataSource = DataModule.ExecuteFill(@"SELECT * FROM ""Contractors"" ORDER BY ""Name""");

            var balanceAccountDataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            var purposeAccountDataSource = DataModule.ExecuteFill(@"SELECT Id, Num FROM Accounts WHERE Num STARTING '36' AND ""Type"" = 1 order by Num");

            //var currencyDataSource = DataModule.ExecuteFill(DataModule.Queries["Currency"]);
            DataModule.Connection.Open();
            var currencyDataSource = DataModule.ExecuteFillProc("CurrencyProc");
            DataModule.Connection.Close();
           
            GetCustomerOrders();

            documentDatePicker.EditValue = DateTime.Now;

            _inserting = inserting;

            _recordId = recordId;//_inserting ? -1 : recordId;

            calcBuyersTable = DataModule.AccountingDS.Tables["CalcWithBuyers"];
            calcWithBuyersBS.DataSource = calcBuyersTable;

            if (_inserting)
            {
                DataRow calcRow;
                calcRow = calcBuyersTable.NewRow();
                calcRow["DocumentDate"] = documentDatePicker.EditValue;
                calcRow["CalcCurrency_Id"] = 1;
                calcRow["AccountingOperationId"] = 1;

                calcBuyersTable.Rows.Add(calcRow);

                calcWithBuyersBS.MoveLast();
            }
            else
            {
                calcWithBuyersBS.Position = position;
            }

            var _tempCurrencyRatesId = ((DataRowView)calcWithBuyersBS.Current)["CurrencyRatesId"];
            LoadCurrencyRates((_tempCurrencyRatesId != DBNull.Value) ? (int)_tempCurrencyRatesId : -1);

            if (currencyRatesBS.Count == 0)
            {
                DataRow currencyRow;
                currencyRow = currencyRatesTable.NewRow();
                currencyRow["Currency_Id"] = 1;
                currencyRow["Multiplicity"] = 1;
                
                currencyRatesTable.Rows.Add(currencyRow);

                currencyRatesBS.MoveLast();
            }

            documentNameTBox.DataBindings.Add("Text", calcWithBuyersBS, "DocumentName");
            paymentTBox.DataBindings.Add("Text", calcWithBuyersBS, "Payment");
            commentTBox.DataBindings.Add("EditValue", calcWithBuyersBS, "Comment");
            paymentCurrencyTBox.DataBindings.Add("Text", currencyRatesBS, "CurrencyPayment");
            paymentRateTBox.DataBindings.Add("Text", currencyRatesBS, "Rate");
            srnTBox.DataBindings.Add("Text", calcWithBuyersBS, "Srn");
            empNumberTBox.DataBindings.Add("Text", calcWithBuyersBS, "Employee_Number");

            documentDatePicker.DataBindings.Add("EditValue", calcWithBuyersBS, "DocumentDate");

            contractorsEdit.EditValue = ((DataRowView)calcWithBuyersBS.Current)["ContractorsId"];
            contractorsEdit.Properties.DataSource = contractorDataSource;
            contractorsEdit.Properties.ValueMember = "Id";
            contractorsEdit.Properties.DisplayMember = "Name";
            contractorsEdit.Properties.NullText = "Немає даних";

            employeesEdit.EditValue = ((DataRowView)calcWithBuyersBS.Current)["EmployeesId"];
            employeesEdit.Properties.DataSource = responsibleDataSource;
            employeesEdit.Properties.ValueMember = "Id";
            employeesEdit.Properties.DisplayMember = "Name";
            employeesEdit.Properties.NullText = "Немає даних";

            customerOrdersEdit.EditValue = ((DataRowView)calcWithBuyersBS.Current)["CustomerOrderId"];
            customerOrdersEdit.Properties.DataSource = customerOrdersDataSource;
            customerOrdersEdit.Properties.ValueMember = "Id";
            customerOrdersEdit.Properties.DisplayMember = "OrderNumber";
            customerOrdersEdit.Properties.NullText = "Немає даних";

            balanceAccountCBox.DataSource = balanceAccountDataSource;
            balanceAccountCBox.ValueMember = "Id";
            balanceAccountCBox.DisplayMember = "Num";
            balanceAccountCBox.DataBindings.Add("SelectedValue", calcWithBuyersBS, "BalanceAccountId");

            purposeAccountCBox.DataSource = purposeAccountDataSource;
            purposeAccountCBox.ValueMember = "Id";
            purposeAccountCBox.DisplayMember = "Num";
            purposeAccountCBox.DataBindings.Add("SelectedValue", calcWithBuyersBS, "PurposeAccountId");

            currencyCBox.DataSource = currencyDataSource;
            currencyCBox.ValueMember = "Id";
            currencyCBox.DisplayMember = "Code";
            currencyCBox.DataBindings.Add("SelectedValue", currencyRatesBS, "Currency_Id");

            debitCreditCBox.DataSource = DataModule.ExecuteFill(@"SELECT * FROM ""AccountingOperation""");
            debitCreditCBox.ValueMember = "Id";
            debitCreditCBox.DisplayMember = "Name";
            debitCreditCBox.DataBindings.Add("SelectedValue", calcWithBuyersBS, "AccountingOperationId");

       
            PayerTypeInitialize(_inserting,
                               ((((DataRowView)calcWithBuyersBS.Current)["ContractorsId"] == DBNull.Value) ? false : true),
                               ((((DataRowView)calcWithBuyersBS.Current)["EmployeesId"] == DBNull.Value) ? false : true)
                              );

            employeesEdit.EditValueChanged += employeesEdit_EditValueChanged;
            contractorsEdit.EditValueChanged += contractorsEdit_EditValueChanged;
            currencyCBox.SelectedValueChanged += currencyCBox_SelectedValueChanged;

            int _tempCurrencyId = (int)((DataRowView)calcWithBuyersBS.Current)["CalcCurrency_Id"];
            paymentCurrencyTBox.Enabled = !(_tempCurrencyId == 1);
            paymentRateTBox.Enabled = !(_tempCurrencyId == 1);
        }

        private void contractorsEdit_EditValueChanged(object sender, EventArgs e)
        {

            var view = (DataRowView)contractorsEdit.GetSelectedDataRow();

            if (view != null)
            {
                DataRow dr = view.Row;
                srnTBox.Text = dr["Srn"].ToString();
            }
        }

        private void employeesEdit_EditValueChanged(object sender, EventArgs e)
        {
            var view = (DataRowView)employeesEdit.GetSelectedDataRow();

            if (view != null)
            {
                DataRow dr = view.Row;
                empNumberTBox.Text = dr["Number"].ToString();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            
            DialogResult = DialogResult.Cancel;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveCalcWithBuyersRecord()) return;

                this.Close();

                DialogResult = DialogResult.OK;
            }
        }

        private void contractorChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                employeesEdit.EditValue = DBNull.Value;
                empNumberTBox.Text = String.Empty;
                employeesChkBox.Checked = false;
                employeesEdit.Enabled = false;
                contractorsEdit.Enabled = true;
            }
            else
            {
                contractorsEdit.EditValue = DBNull.Value;
                contractorsEdit.Enabled = false;
                srnTBox.Text = String.Empty;
            }
        }

        private void employeesChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                contractorsEdit.EditValue = DBNull.Value;
                srnTBox.Text = String.Empty;
                contractorChkBox.Checked = false;
                employeesEdit.Enabled = true;
                contractorsEdit.Enabled = false;
            }
            else
            {
                employeesEdit.EditValue = DBNull.Value;
                employeesEdit.Enabled = false;
                empNumberTBox.Text = String.Empty;
            }
        }

        private void currencyCBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var currencyId = currencyCBox.SelectedValue;

            if (currencyId != null)
            {
                bool isCurrency = ((short)currencyId == 1) ? false : true;

                paymentCurrencyTBox.Text = (!isCurrency) ? "" : paymentCurrencyTBox.Text;
                paymentRateTBox.Text = (!isCurrency) ? "" : paymentRateTBox.Text;

                paymentCurrencyTBox.Enabled = isCurrency;
                paymentRateTBox.Enabled = isCurrency;
            }

        }

        private void customerOrdersEdit_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        private void contractorsEdit_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        private void employeesEdit_Properties_QueryPopUp(object sender, CancelEventArgs e)
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

        private void customerOrdersEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 1:
                    {
                        customerOrdersFm customerOrdersFm = new customerOrdersFm();
                        customerOrdersFm.ShowDialog();
                        GetCustomerOrders();
                        customerOrdersEdit.Properties.DataSource = customerOrdersDataSource;
                        break;
                    }
                case 2:
                    {
                        customerOrdersEdit.EditValue = DBNull.Value;
                        break;
                    }
            }
        }

        private void openRBDebitBtn_Click(object sender, EventArgs e)
        {
            accountsRBFm accountsRBFm = new accountsRBFm();
            accountsRBFm.ShowDialog();
            balanceAccountCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            balanceAccountCBox.SelectedIndex = -1;
            balanceAccountCBox.Focus();
        }

        private void GetCustomerOrders()
        {
            //customerOrdersDataSource = DataModule.ExecuteFill(DataModule.Queries["CustomerOrders"]);

            DataModule.Connection.Open();
            customerOrdersDataSource = DataModule.ExecuteFillProc("CustomerOrdersProc");
            DataModule.Connection.Close();
        }

        private int _currencyRatesId;
        private void LoadCurrencyRates(int currencyRatesId)
        {
            _currencyRatesId = currencyRatesId;
            FbParameter[] Parameters =
                {
                    new FbParameter("Id", _currencyRatesId),
                };
            currencyRatesTable = DataModule.ExecuteFill(DataModule.DataAdapter["Currency_Rates"].SelectCommand.CommandText, Parameters);
            currencyRatesBS.DataSource = currencyRatesTable;

        }

        private bool _checkContractors, _checkEmployee;
        private void PayerTypeInitialize(bool insertingRow, bool checkContractors, bool checkEmployee)
        {
            _checkContractors = checkContractors;
            _checkEmployee = checkEmployee;

            contractorChkBox.Checked = (insertingRow) ? false : _checkContractors;
            employeesChkBox.Checked = (insertingRow) ? false : _checkEmployee;

            contractorsEdit.Enabled = (insertingRow) ? false : _checkContractors;
            employeesEdit.Enabled = (insertingRow) ? false : _checkEmployee;

            buyersTab.SelectedTabPage = (insertingRow)
                                           ? contractorTabPage
                                           : (_checkContractors)
                                                 ? contractorTabPage
                                                 : employeeTabPage;
        }

       

        private bool SaveCalcWithBuyersRecord()
        {
            DateTime documentDate = (DateTime)((DataRowView)calcWithBuyersBS.Current)["DocumentDate"];

            ((DataRowView)calcWithBuyersBS.Current)["EmployeesId"] = (employeesChkBox.Checked) ? employeesEdit.EditValue : DBNull.Value;
            ((DataRowView)calcWithBuyersBS.Current)["ContractorsId"] = (contractorChkBox.Checked) ? contractorsEdit.EditValue : DBNull.Value;
            ((DataRowView)calcWithBuyersBS.Current)["CustomerOrderId"] = customerOrdersEdit.EditValue;

            calcWithBuyersBS.EndEdit();
            currencyRatesBS.EndEdit();


            var _calcCurrencyRatesId = ((DataRowView)calcWithBuyersBS.Current)["CurrencyRatesId"];
            short _calcCurrencyId = (short)((DataRowView)currencyRatesBS.Current)["Currency_Id"];

            //валидация данных
            string message = "";

            message += (documentNameTBox.Text.Length == 0) ? "Номер документу \n" : "";
            message += (!contractorChkBox.Checked && !employeesChkBox.Checked) ? "Не зазначено контрагента або працівника \n" : "";
            message += (contractorChkBox.Checked && contractorsEdit.Text.Length == 0) ? "Найменування контрагента \n" : "";
            message += (employeesChkBox.Checked && employeesEdit.Text.Length == 0) ? "Найменування працівника підприємства \n" : "";;
            message += (balanceAccountCBox.Text.Length == 0 || balanceAccountCBox.SelectedIndex < 0) ? "Балансовий рахунок не вибраний або не існує\n" : "";
            message += (purposeAccountCBox.Text.Length == 0 || purposeAccountCBox.SelectedIndex < 0) ? "Рахунок призначення не вибраний або не існує\n" : "";
            message += (paymentTBox.Text.Length == 0) ? "Сума у гривні\n" : "";
            message += (_calcCurrencyId > 1 && paymentCurrencyTBox.Text.Length == 0) ? "Сума у валюті\n" : "";

            if (message.Length != 0)
            {
                MessageBox.Show("Заповнені не всі поля: \n" + message, "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!CheckPeriod())
            {
                MessageBox.Show("Період закритий або не існує!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!FindDuplicateRecord())
            {

                DataModule.Connection.Open();
                DataModule.BeginTransaction();

                DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["Currency_Rates"].InsertCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["Currency_Rates"].UpdateCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["Currency_Rates"].DeleteCommand.Transaction = DataModule.Transaction;

                try
                {
                    if (_inserting)
                    {
                        if (_calcCurrencyId > 1)
                        {
                            ((DataRowView)currencyRatesBS.Current)["Date"] = documentDatePicker.EditValue;
                            currencyRatesBS.EndEdit();
                            DataModule.DataAdapter["Currency_Rates"].Update(currencyRatesTable);
                            int _currencyRatesId = (int)DataModule.DataAdapter["Currency_Rates"].InsertCommand.Parameters["Id"].Value;
                            ((DataRowView)calcWithBuyersBS.Current)["CurrencyRatesId"] = _currencyRatesId;
                            calcWithBuyersBS.EndEdit();
                        }

                        DataModule.DataAdapter["CalcWithBuyers"].Update(calcBuyersTable);
                        _recordId = (int)DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters["Id"].Value;
                    }
                    else
                    {
                        if (_calcCurrencyId > 1)
                        {
                            if (_calcCurrencyRatesId == DBNull.Value)
                            {
                                ((DataRowView)currencyRatesBS.Current)["Currency_Id"] = _calcCurrencyId;
                                ((DataRowView)currencyRatesBS.Current)["Date"] = documentDatePicker.EditValue;
                                currencyRatesBS.EndEdit();
                                DataModule.DataAdapter["Currency_Rates"].Update(currencyRatesTable);
                                int _currencyRatesId = (int)DataModule.DataAdapter["Currency_Rates"].InsertCommand.Parameters["Id"].Value;
                                ((DataRowView)calcWithBuyersBS.Current)["CurrencyRatesId"] = _currencyRatesId;
                                calcWithBuyersBS.EndEdit();
                                DataModule.DataAdapter["CalcWithBuyers"].Update(calcBuyersTable);
                            }
                            else
                            {
                                DataModule.DataAdapter["CalcWithBuyers"].Update(calcBuyersTable);
                                //((DataRowView)currencyRatesBS.Current)["Currency_Id"] = _calcCurrencyId;
                                DataModule.DataAdapter["Currency_Rates"].Update(currencyRatesTable);
                            }
                        }
                        else
                        {
                            if (_calcCurrencyRatesId != DBNull.Value)
                            {
                                ((DataRowView)calcWithBuyersBS.Current)["CurrencyRatesId"] = DBNull.Value;
                                calcWithBuyersBS.EndEdit();
                                currencyRatesBS.RemoveCurrent();
                                DataModule.DataAdapter["CalcWithBuyers"].Update(calcBuyersTable);
                                DataModule.DataAdapter["Currency_Rates"].Update(currencyRatesTable);
                            }
                            else
                            {
                                DataModule.DataAdapter["CalcWithBuyers"].Update(calcBuyersTable);
                            }
                        }
                    }
                    DataModule.CommitTransaction();

                    return true;
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
                    return false;
                }
                finally
                {
                    Cursor = Cursors.Default;
                    DataModule.Connection.Close();
                }
            }
            else
            {
                return false;
            }

        }

        private bool FindDuplicateRecord()
        {
            bool result = false;

            FbParameter[] Parameters =
                {
                    new FbParameter("DocumentName", ((DataRowView)calcWithBuyersBS.Current)["DocumentName"]),
                    new FbParameter("DocumentDate", ((DataRowView)calcWithBuyersBS.Current)["DocumentDate"]),
                    new FbParameter("Payment", ((DataRowView)calcWithBuyersBS.Current)["Payment"]),
                    new FbParameter("ContractorsId", ((DataRowView)calcWithBuyersBS.Current)["ContractorsId"]),
                    new FbParameter("EmployeesId", ((DataRowView)calcWithBuyersBS.Current)["EmployeesId"]),
                    new FbParameter("Id", ((DataRowView)calcWithBuyersBS.Current)["Id"])
                };

            DataModule.Connection.Open();

            string queryString = @"SELECT
                                            COUNT(*)
                                        FROM
                                            ""CalcWithBuyers""
                                        WHERE
                                            ""CalcWithBuyers"".""DocumentName"" = @DocumentName AND
                                            ""CalcWithBuyers"".""DocumentDate"" = @DocumentDate AND
                                            ""CalcWithBuyers"".""Payment"" = @Payment ";
            queryString += (((DataRowView)calcWithBuyersBS.Current)["ContractorsId"] == DBNull.Value)
                            ? @"AND ""CalcWithBuyers"".""EmployeesId"" = @EmployeesId "
                            : @"AND ""CalcWithBuyers"".""ContractorsId"" = @ContractorsId";

            queryString += (!_inserting) ? @" AND ""CalcWithBuyers"".""Id"" <> @Id" : "";

            int count = (int)DataModule.ExecuteScalar(queryString, Parameters);
            DataModule.Connection.Close();
            if (count != 0)
            {
                MessageBox.Show("Документ з такими даними вже існує!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = true;
            }

            return result;
        }

        public int Return()
        {
            return _recordId;
        }

        private bool CheckPeriod()
        {
            FbParameter[] Parameters =
            {
                new FbParameter("Month", ((DateTime)documentDatePicker.EditValue).Month),
                new FbParameter("Year",  ((DateTime)documentDatePicker.EditValue).Year)    
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
                        (MessageBox.Show("Періоду не існує! Додати період?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
        /// <summary> добавление нового периода
        ///  </summary>

        private void InsertPeriod()
        {
            FbParameter[] Parameters =
                {
                new FbParameter("Month", ((DateTime)documentDatePicker.EditValue).Month),
                new FbParameter("Year",  ((DateTime)documentDatePicker.EditValue).Year)
                };

            DataModule.Connection.Open();
            short? State = (short?)DataModule.ExecuteScalar(@"INSERT INTO ""Periods"" (""State"",""Month"",""Year"" ) VALUES ( 1,@Month,@Year)", Parameters);
            DataModule.Connection.Close();
        }

           
    }
}
