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

namespace Accounting
{
    public partial class customerOrdersAddEditFm : Form

    {
        private bool _inserting;
        private int _recordId;

        private DataTable customerOrdersTable;
        private DataTable contractorDataSource;

        private BindingSource customerOrdersBS = new BindingSource();

        public customerOrdersAddEditFm(bool inserting, int position = -1, int recordId = -1)
        {
            InitializeComponent();

            _inserting = inserting;

            _recordId = recordId;

            orderDatePicker.EditValue = DateTime.Now;
            customerOrdersTable = DataModule.AccountingDS.Tables["CustomerOrders"];
            customerOrdersBS.DataSource = customerOrdersTable;

            contractorDataSource = DataModule.ExecuteFill(@"SELECT * FROM ""Contractors"" ORDER BY ""Name""");
            //contractorsEdit.EditValueChanged -= contractorsEdit_EditValueChanged;

            DataModule.Connection.Open();
            var currencyDataSource = DataModule.ExecuteFillProc("CurrencyProc");
            DataModule.Connection.Close();
            
            if (_inserting)
            {
                DataRow calcRow;
                calcRow = customerOrdersTable.NewRow();
                calcRow["OrderDate"] = orderDatePicker.EditValue;
                calcRow["CurrencyId"] = 1;
                customerOrdersTable.Rows.Add(calcRow);
                customerOrdersBS.MoveLast();
            }
            else
            {
                customerOrdersBS.Position = position;
            }
                        
            orderNumberTBox.DataBindings.Add("Text", customerOrdersBS, "OrderNumber");
            orderPriceTBox.DataBindings.Add("Text", customerOrdersBS, "OrderPrice");
            currencyPriceTBox.DataBindings.Add("Text", customerOrdersBS, "CurrencyPrice");

            detailsTBox.DataBindings.Add("Text", customerOrdersBS, "Details");

            contractorsEdit.EditValue = ((DataRowView)customerOrdersBS.Current)["ContractorId"];
            contractorsEdit.Properties.DataSource = contractorDataSource;
            contractorsEdit.Properties.ValueMember = "Id";
            contractorsEdit.Properties.DisplayMember = "Name";
            contractorsEdit.Properties.NullText = "Немає даних";

            orderDatePicker.DataBindings.Add("EditValue", customerOrdersBS, "OrderDate");
            
            currencyCBox.DataSource = currencyDataSource;
            currencyCBox.ValueMember = "Id";
            currencyCBox.DisplayMember = "Code";
            currencyCBox.DataBindings.Add("SelectedValue", customerOrdersBS, "CurrencyId");

            //contractorsEdit.EditValueChanged += contractorsEdit_EditValueChanged;
        }

        public int Return()
        {
            return _recordId;
        }

        /// <summary>
        /// закрытие формы
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// сохранение
        /// </summary>
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveCustomerOrderRecord()) return;

                this.Close();

                DialogResult = DialogResult.OK;
            }
        }
        
        /// <summary>
        /// сохранение
        /// </summary>
        /// <returns></returns>
        private bool SaveCustomerOrderRecord()
        {
            ((DataRowView)customerOrdersBS.Current)["ContractorId"] = contractorsEdit.EditValue;

            customerOrdersBS.EndEdit();
            
            //валидация данных
            string message = "";

            message += (orderNumberTBox.Text.Length == 0) ? "Номер заказу \n" : "";
            message += (contractorsEdit.Text.Length == 0) ? "Контрагент \n" : "";
           
            if (message.Length != 0)
            {
                MessageBox.Show("Заповнені не всі дані: \n" + message, "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            if (!FindDuplicateRecord())
            {

                DataModule.Connection.Open();
                DataModule.BeginTransaction();

                DataModule.DataAdapter["CustomerOrders"].InsertCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["CustomerOrders"].UpdateCommand.Transaction = DataModule.Transaction;
                
                try
                {
                    if (_inserting)
                    {
                        DataModule.DataAdapter["CustomerOrders"].Update(customerOrdersTable);
                        _recordId = (int)DataModule.DataAdapter["CustomerOrders"].InsertCommand.Parameters["Id"].Value;
                    }
                    else
                    {
                        DataModule.DataAdapter["CustomerOrders"].Update(customerOrdersTable);
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
        
        /// <summary>
        /// проверка на дубликат номера заказа
        /// </summary>
        /// <returns></returns>
        private bool FindDuplicateRecord()
        {
            bool result = false;

            FbParameter[] Parameters =
                {
                    new FbParameter("OrderNumber", ((DataRowView)customerOrdersBS.Current)["OrderNumber"]),
                    new FbParameter("Id", ((DataRowView)customerOrdersBS.Current)["Id"])
                };

            DataModule.Connection.Open();

            string queryString = @"SELECT
                                            COUNT(*)
                                        FROM
                                            ""CustomerOrders""
                                        WHERE
                                            ""CustomerOrders"".""OrderNumber"" = @OrderNumber";
            queryString += (!_inserting) ? @" AND ""CustomerOrders"".""Id"" <> @Id" : "";

            int count = (int)DataModule.ExecuteScalar(queryString, Parameters);
            DataModule.Connection.Close();
            
            if (count != 0)
            {
                MessageBox.Show("Заказ з такими даними вже існує!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = true;
            }

            return result;
        }
        
        private void orderNumberTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.KeyChar = '.';
        }

        private void contractorsEdit_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        private void contractorsEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 1:
                    {
                        contractorsRBFm contractorsFM = new contractorsRBFm();
                        contractorsFM.ShowDialog();
                        contractorDataSource = DataModule.ExecuteFill(@"SELECT * FROM ""Contractors"" ORDER BY ""Name""");
                        contractorsEdit.Properties.DataSource = contractorDataSource;
                        break;
                    }
                case 2:
                    {
                        contractorsEdit.EditValue = DBNull.Value;
                        break;
                    }
            }
        }

   }
}
