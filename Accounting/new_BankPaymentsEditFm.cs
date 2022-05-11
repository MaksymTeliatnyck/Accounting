using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace Accounting
{
    public partial class new_BankPaymentsEditFm : Form
    {
        private int _recordId;
        private bool _inserting;
        
        private DataTable responsibleDataSource;
        private DataTable customerOrdersDataSource;
        private DataTable contractorDataSource;
        private DataTable currencyRatesTable;
        
        private BindingSource bankPaymentsBS = new BindingSource();
        private BindingSource currencyRatesBS = new BindingSource();

        public new_BankPaymentsEditFm(bool inserting, int position = -1, int recordId = -1)
        {
            InitializeComponent();
            
            paymentDatePicker.EditValue = DateTime.Now;
            
            _inserting = inserting;
            _recordId = recordId;

            GetCustomerOrders();

            responsibleDataSource = DataModule.ExecuteFill(@"SELECT EMPLOYEEID AS ""Id"", FULLNAME AS ""Name"", EMPLOYEE_NUMBER AS ""Number"" FROM Responsible");
            contractorDataSource = DataModule.ExecuteFill(@"SELECT * FROM ""Contractors"" ORDER BY ""Name""");
            bankPaymentsBS.DataSource = DataModule.AccountingDS.Tables["Bank_Payments"];

            employeesEdit.EditValueChanged -= employeesEdit_EditValueChanged;
            contractorsEdit.EditValueChanged -= contractorsEdit_EditValueChanged;
            currencyCBox.SelectedValueChanged -= currencyCBox_SelectedValueChanged;

            if (_inserting)
            {
                DataRow Row;
                Row = DataModule.AccountingDS.Tables["Bank_Payments"].NewRow();
                Row["Payment_Date"] = paymentDatePicker.EditValue;
                Row["CurrencyId"] = 1;
                DataModule.AccountingDS.Tables["Bank_Payments"].Rows.Add(Row);
                
                bankPaymentsBS.MoveLast();
            }
            else
            {
                bankPaymentsBS.Position = position;
            }

            var _tempCurrencyRatesId = ((DataRowView)bankPaymentsBS.Current)["CurrencyRatesConvertId"];
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
            
            var debitCreditSource = new Dictionary<sbyte, string>
            {
                {1, "Дебет"},
                {-1, "Кредит"}
            };

            #region Bank_Payments Binding

            paymentDatePicker.DataBindings.Add("EditValue", bankPaymentsBS, "Payment_Date");

            documentNumTBox.DataBindings.Add("Text", bankPaymentsBS, "Payment_Document");
            priceTBox.DataBindings.Add("Text", bankPaymentsBS, "Payment_Price");
            purposeTBox.DataBindings.Add("Text", bankPaymentsBS, "Purpose");
            rateTBox.DataBindings.Add("Text", bankPaymentsBS, "Rate");
            sumCurrencyTBox.DataBindings.Add("Text", bankPaymentsBS, "Payment_PriceCurrency");
            srnTBox.DataBindings.Add("Text", bankPaymentsBS, "Contractor_Srn");
            empNumberTBox.DataBindings.Add("Text", bankPaymentsBS, "Employee_Number");
                                               
            rateConvertTBox.DataBindings.Add("Text", currencyRatesBS, "Rate");
            sumCurrencyConvertTBox.DataBindings.Add("Text", currencyRatesBS, "CurrencyPayment");

            contractorsEdit.EditValue = ((DataRowView)bankPaymentsBS.Current)["Contractor_Id"];
            contractorsEdit.Properties.DataSource = contractorDataSource;
            contractorsEdit.Properties.ValueMember = "Id";
            contractorsEdit.Properties.DisplayMember = "Name";
            contractorsEdit.Properties.NullText = "Немає даних";

            employeesEdit.EditValue = ((DataRowView)bankPaymentsBS.Current)["EmployeesId"];
            employeesEdit.Properties.DataSource = responsibleDataSource;
            employeesEdit.Properties.ValueMember = "Id";
            employeesEdit.Properties.DisplayMember = "Name";
            employeesEdit.Properties.NullText = "Немає даних";

            customerOrdersEdit.EditValue = ((DataRowView)bankPaymentsBS.Current)["CustomerOrderId"];
            customerOrdersEdit.Properties.DataSource = customerOrdersDataSource;
            customerOrdersEdit.Properties.ValueMember = "Id";
            customerOrdersEdit.Properties.DisplayMember = "OrderNumber";
            customerOrdersEdit.Properties.NullText = "Немає даних";

            currencyCBox.DataBindings.Add("SelectedValue", bankPaymentsBS, "CurrencyId");
            DataModule.Connection.Open();
            currencyCBox.DataSource = DataModule.ExecuteFillProc("CurrencyProc");
            DataModule.Connection.Close();
            currencyCBox.ValueMember = "Id";
            currencyCBox.DisplayMember = "Code";

            currencyConvertCBox.DataBindings.Add("SelectedValue", currencyRatesBS, "Currency_Id");
            DataModule.Connection.Open();
            currencyConvertCBox.DataSource = DataModule.ExecuteFillProc("CurrencyProc");
            DataModule.Connection.Close();
            currencyConvertCBox.ValueMember = "Id";
            currencyConvertCBox.DisplayMember = "Code";

            bankAccountCBox.DataBindings.Add("SelectedValue", bankPaymentsBS, "Bank_Account_Id");
            bankAccountCBox.DataBindings.Add("Text", bankPaymentsBS, "Bank_Account_Num");
            bankAccountCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            bankAccountCBox.ValueMember = "Id";
            bankAccountCBox.DisplayMember = "Num";

            purposeAccountCBox.DataBindings.Add("SelectedValue", bankPaymentsBS, "Purpose_Account_Id");
            purposeAccountCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            purposeAccountCBox.ValueMember = "Id";
            purposeAccountCBox.DisplayMember = "Num";

            debitCreditCBox.DataSource = new BindingSource(debitCreditSource, null);
            debitCreditCBox.ValueMember = "Key";
            debitCreditCBox.DisplayMember = "Value";
            
            debitCreditCBox.Text = (_inserting) ? "Дебет" : (int.Parse(((DataRowView)bankPaymentsBS.Current)["Direction"].ToString()) > 0 ? "Дебет" : "Кредит");

            PayerTypeInitialize(_inserting,
                               ((((DataRowView)bankPaymentsBS.Current)["Contractor_Id"] == DBNull.Value) ? false : true),
                               ((((DataRowView)bankPaymentsBS.Current)["EmployeesId"] == DBNull.Value) ? false : true)
                              );

            employeesEdit.EditValueChanged += employeesEdit_EditValueChanged;
            contractorsEdit.EditValueChanged += contractorsEdit_EditValueChanged;
            currencyCBox.SelectedValueChanged += currencyCBox_SelectedValueChanged;
            
            int _tempCurrencyId = (short)((DataRowView)bankPaymentsBS.Current)["CurrencyId"];
            sumCurrencyTBox.Enabled = !(_tempCurrencyId == 1);
            rateTBox.Enabled = !(_tempCurrencyId == 1);

            #endregion
        }

        private void GetCustomerOrders()
        {
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

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            ((DataRowView)bankPaymentsBS.Current)["Direction"] = debitCreditCBox.SelectedValue;
            ((DataRowView)bankPaymentsBS.Current)["EmployeesId"] = (employeesChkBox.Checked) ? employeesEdit.EditValue : DBNull.Value;
            ((DataRowView)bankPaymentsBS.Current)["Contractor_Id"] = (contractorChkBox.Checked) ? contractorsEdit.EditValue : DBNull.Value;
            ((DataRowView)bankPaymentsBS.Current)["CustomerOrderId"] = customerOrdersEdit.EditValue;

            bankPaymentsBS.EndEdit();
            currencyRatesBS.EndEdit();

            DateTime operationDate = Convert.ToDateTime(((DataRowView)bankPaymentsBS.Current)["Payment_Date"]);

            int _paymentCurrencyId = (short)((DataRowView)bankPaymentsBS.Current)["CurrencyId"];
            var _currencyRatesConvertId = ((DataRowView)bankPaymentsBS.Current)["CurrencyRatesConvertId"];
            short _convertCurrencyId = (short)((DataRowView)currencyRatesBS.Current)["Currency_Id"];
            //валидация данных
            string message = "";

            message += (documentNumTBox.Text.Length == 0) ? "Номер платіжного документу \n" : "";
            message += (!contractorChkBox.Checked && !employeesChkBox.Checked) ? "Не зазначено контрагента або працівника \n" : "";
            message += (contractorChkBox.Checked && contractorsEdit.Text.Length == 0) ? "Найменування контрагента \n" : "";
            message += (employeesChkBox.Checked && employeesEdit.Text.Length == 0) ? "Найменування працівника підприємства \n" : "";
            message += (bankAccountCBox.Text.Length == 0) ? "Балансовый рахунок \n" : "";
            message += (purposeAccountCBox.Text.Length == 0) ? "Рахунок призначення \n" : "";
            message += (priceTBox.Text.Length == 0) ? "Сума у гривні\n" : "";
            message += (_paymentCurrencyId > 1 && sumCurrencyTBox.Text.Length == 0) ? "Сума у валюті\n" : "";
            message += ((short?)purposeAccountCBox.SelectedValue == 60 && (short?)currencyCBox.SelectedValue == 1) ? "Для рахунку '632' невірно зазначена валюта!" : "";
            message += (_convertCurrencyId > 1 && sumCurrencyConvertTBox.Text.Length == 0) ? "Сума конвертації валюти\n" : "";

            if (message.Length != 0)
            {
                MessageBox.Show("Заповнені не всі поля: \n" + message, "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
       
            if (!CheckPeriod())
            {
                MessageBox.Show("Період закритий або не існує!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (_inserting)
            {
                FbParameter[] Parameters =
                {
                    new FbParameter("Payment_Date", paymentDatePicker.EditValue),
                    new FbParameter("Bank_Account_Id", bankAccountCBox.SelectedValue),
                    new FbParameter("Payment_Document", documentNumTBox.Text)
                };

                DataModule.Connection.Open();
                int count = (int)DataModule.ExecuteScalar
                (
                    @"SELECT
                         COUNT(*)
                       FROM
                         ""Bank_Payments""
                       WHERE
                         ""Bank_Payments"".""Payment_Date"" = @Payment_Date AND
                         ""Bank_Payments"".""Bank_Account_Id"" = @Bank_Account_Id AND
                         ""Bank_Payments"".""Payment_Document"" = @Payment_Document",
                    Parameters
                );
                DataModule.Connection.Close();
                if (count != 0)
                {
                    MessageBox.Show("Платіж з такими даними вже існує!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
                                   
            DataModule.Connection.Open();
            DataModule.BeginTransaction();

            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["Currency_Rates"].InsertCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["Currency_Rates"].UpdateCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["Currency_Rates"].DeleteCommand.Transaction = DataModule.Transaction;
            
            try
            {
                if (_inserting)
                {
                    if (_convertCurrencyId > 1)
                    {
                        ((DataRowView)currencyRatesBS.Current)["Date"] = paymentDatePicker.EditValue;
                        currencyRatesBS.EndEdit();
                        DataModule.DataAdapter["Currency_Rates"].Update(currencyRatesTable);
                        int _currencyRatesId = (int)DataModule.DataAdapter["Currency_Rates"].InsertCommand.Parameters["Id"].Value;
                        ((DataRowView)bankPaymentsBS.Current)["CurrencyRatesConvertId"] = _currencyRatesId;
                        bankPaymentsBS.EndEdit();
                    }

                    DataModule.DataAdapter["Bank_Payments"].Update(DataModule.AccountingDS.Tables["Bank_Payments"]);
                    _recordId = (int)DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters["Id"].Value;
                }
                else
                {
                    if (_convertCurrencyId > 1)
                    {
                        if (_currencyRatesConvertId == DBNull.Value)
                        {
                            ((DataRowView)currencyRatesBS.Current)["Date"] = paymentDatePicker.EditValue;
                            currencyRatesBS.EndEdit();
                            DataModule.DataAdapter["Currency_Rates"].Update(currencyRatesTable);
                            int _currencyRatesId = (int)DataModule.DataAdapter["Currency_Rates"].InsertCommand.Parameters["Id"].Value;
                            ((DataRowView)bankPaymentsBS.Current)["CurrencyRatesConvertId"] = _currencyRatesId;
                            bankPaymentsBS.EndEdit();
                            DataModule.DataAdapter["Bank_Payments"].Update(DataModule.AccountingDS.Tables["Bank_Payments"]);
                        }
                        else
                        {
                            DataModule.DataAdapter["Bank_Payments"].Update(DataModule.AccountingDS.Tables["Bank_Payments"]);
                            DataModule.DataAdapter["Currency_Rates"].Update(currencyRatesTable);
                        }
                    }
                    else
                    {
                        if (_currencyRatesConvertId != DBNull.Value)
                        {
                            ((DataRowView)bankPaymentsBS.Current)["CurrencyRatesConvertId"] = DBNull.Value;
                            bankPaymentsBS.EndEdit();
                            currencyRatesBS.RemoveCurrent();
                            DataModule.DataAdapter["Bank_Payments"].Update(DataModule.AccountingDS.Tables["Bank_Payments"]);
                            DataModule.DataAdapter["Currency_Rates"].Update(currencyRatesTable);
                        }
                        else
                        {
                            DataModule.DataAdapter["Bank_Payments"].Update(DataModule.AccountingDS.Tables["Bank_Payments"]);
                        }
                    }
                }
                
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

            this.Close();

            DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
               
        #region FocusMove and KeyPress event

        private bool a, b;

        private void paymentDatePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                documentNumTBox.Focus();
        }

        private void documentNumTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                debitCreditCBox.Focus();
            a = false;
        }

        private void debitCreditCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (b)
                    customerOrdersEdit.Focus();
                b = true;
            }
        }

        private void customerOrdersEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (a)
                    bankAccountCBox.Focus();
                a = true;
            }
            b = false;
        }

        private void bankAccountCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (b)
                    purposeAccountCBox.Focus();
                b = true;
            }
            a = false;
        }

        private void purposeAccountCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                priceTBox.Focus();
            }
            b = false;
        }

        private void priceTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                currencyCBox.Focus();
            }
        }

        private void currencyCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (a)
                    currencyConvertCBox.Focus();
                a = true;
            }
        }

        private void currencyConvertCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (b)
                    purposeTBox.Focus();
                b = true;
            }
            a = false;
        }
               
        private void purposeTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                okBtn.Focus();
        }
        
        #endregion FocusMove

        public int Return()
        {
            return _recordId;
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

                sumCurrencyTBox.Text = (!isCurrency) ? "" : sumCurrencyTBox.Text;
                rateTBox.Text = (!isCurrency) ? "" : rateTBox.Text;

                sumCurrencyTBox.Enabled = isCurrency;
                rateTBox.Enabled = isCurrency;
            }
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

        private bool CheckPeriod()
        {
            FbParameter[] Parameters =
            {
                new FbParameter("Month", ((DateTime)paymentDatePicker.EditValue).Month),
                new FbParameter("Year",  ((DateTime)paymentDatePicker.EditValue).Year)    
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
                new FbParameter("Month", ((DateTime)paymentDatePicker.EditValue).Month),
                new FbParameter("Year",  ((DateTime)paymentDatePicker.EditValue).Year)
                };

            DataModule.Connection.Open();
            short? State = (short?)DataModule.ExecuteScalar(@"INSERT INTO ""Periods"" (""State"",""Month"",""Year"" ) VALUES ( 1,@Month,@Year)", Parameters);
            DataModule.Connection.Close();
        }

        private void contractorsEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        private void gridLookUpEdit1_Properties_QueryPopUp_1(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        private void gridLookUpEdit1_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        private void contractorsEdit_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                contractorsRBFm contractorsFM = new contractorsRBFm();
                contractorsFM.ShowDialog();
                contractorDataSource = DataModule.ExecuteFill(@"SELECT * FROM ""Contractors"" ORDER BY ""Name""");
                contractorsEdit.Properties.DataSource = contractorDataSource;
            }
        }

        private void customerOrdersEdit_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch(e.Button.Index)
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

       
   
   }
}

