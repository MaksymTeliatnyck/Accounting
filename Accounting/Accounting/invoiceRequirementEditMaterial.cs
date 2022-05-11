using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Accounting;

namespace Accounting
{
    public partial class invoiceRequirementEditMaterial : Form
    {
        private DataTable remainsTable = new DataTable();
        private BindingSource remainsBS = new BindingSource();
        private int _orderPosition;

        public invoiceRequirementEditMaterial(int orderPosition)
        {
            InitializeComponent();

            _orderPosition = orderPosition;
            // значение по умолчанию для даты формирования остатков
            expStartDateDTP.Value = Convert.ToDateTime("01." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString());
            expEndDateDTP.Value = DateTime.Now;
            
            LoadRemainsTheDate();
        }

        private void LoadRemainsTheDate()
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("StartDate", expStartDateDTP.Value.ToShortDateString()),
                    new FbParameter("EndDate", expEndDateDTP.Value.ToShortDateString())
                };

            remainsTable = DataModule.ExecuteFill(DataModule.Queries["ExpenditureForInvoiceRequired"], Parameters);
            remainsTable.Columns.Add("ISSELECT", typeof(string));
            //remainsTable.Columns.Add("SETKOL", typeof(float));
            remainsBS.DataSource = remainsTable;
            remainsGrid.DataSource = remainsBS;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
           
            var TableData = remainsTable.Select().ToList();

            var TableDataSelect = (from TD in TableData
                                   where TD.Field<string>("ISSELECT") == "1"
                                   select TD).ToList();
            
            if (TableDataSelect.Count == 0)
            {
                MessageBox.Show("Некорректный ввод данных. \n Введенное количество равно нулю.", "Информация",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                return;
            }
            else
            {
                foreach (var Row_X in TableDataSelect)
                {
                    DataRow row;
                    row = DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"].NewRow();
                    row["EXPEN_ACCOUNT"] = Row_X.Field<string>("CREDIT_ACCOUNT");
                    row["Credit_Account_Id"] = Row_X.Field<Int16>("CREDIT_ACCOUNT_ID");
                    row["Num"] = Row_X.Field<string>("BALANCE_NUM");
                    row["Receipt_Num"] = Row_X.Field<string>("RECEIPT_NUM");
                    row["Receipt_Id"] = Row_X.Field<Int32>("RECEIPT_ID").ToString();
                    row["Invoice_Requirement_Order_Id"] = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows[_orderPosition]["ReqOrderId"];
                    row["Required_Quantity"] = Row_X.Field<decimal>("SETKOL").ToString();
                    row["Name"] = Row_X.Field<string>("NAME");
                    row["Nomenclature"] = Row_X.Field<string>("NOMENCLATURE");
                    row["Measure"] = Row_X.Field<string>("MEASURE");
                    row["Unit_Price"] = Row_X.Field<decimal>("UNIT_PRICE").ToString();
                    row["Total_Price"] = Convert.ToString(Row_X.Field<decimal>("UNIT_PRICE") * Row_X.Field<decimal>("SETKOL"));
                    row["Expenditures_Id"] = Row_X.Field<int>("Id");
                    DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"].Rows.Add(row);
                }
                remainsTable.Clear();
                /*
                nomenclNumberTBox.Text = "";
                nameTBox.Text = "";
                requiredQuantityTBox.Text = "";
                sumTBox.Text = "";
                remainsTable.Clear();
                nomenclNumberTBox.Focus();
                 */

                this.Close();
            }
        }

       
        private void viewSelectDateBtn_Click(object sender, EventArgs e)
        {
            LoadRemainsTheDate();
        }
    }
}
