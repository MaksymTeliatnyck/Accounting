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
    public partial class soldFixedCardFm : Form
    {
        private DataTable fixedAssetsMaterialTableCopy = null;

        private DataRow fixedAssetsOrderCurrentRow = null;

        private BindingSource fixedAssetsOrderBS = new BindingSource();
        private BindingSource fixedAssetsMaterialsBS = new BindingSource();

        const short SOLD = 2;
        const short PARTIAL_SOLD = 3;

        public soldFixedCardFm(int position)
        {
            InitializeComponent();

            (DataModule.AccountingDS.Tables["FixedAssetsMaterials"]).AsEnumerable()
                .ToList<DataRow>()
                .ForEach(r => r["SoldPrice"] = r["FixedPrice"]);
            
            fixedAssetsOrderBS.DataSource = DataModule.AccountingDS.Tables["FixedAssetsOrder"];
            fixedAssetsOrderBS.Position = position;
            fixedAssetsMaterialsBS.DataSource = DataModule.AccountingDS.Tables["FixedAssetsMaterials"];

            fixedAssetsMaterialTableCopy = ((DataTable)fixedAssetsMaterialsBS.DataSource).Copy();

            fixedAssetsOrderCurrentRow = ((DataRowView)fixedAssetsOrderBS.Current).Row;

            dateSoldDatePicker.EditValue = DateTime.Now;

            fixedCardNumberLbl.Text = String.Format("{0} {1}", fixedAssetsOrderCurrentRow["InventoryNumber"], fixedAssetsOrderCurrentRow["InventoryName"]);

            materialsGrid.DataSource = fixedAssetsMaterialsBS.DataSource;

            materialsGridView.BeginSummaryUpdate(); materialsGridView.EndSummaryUpdate();
        }
        
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }
        
        private void partialSoldStatusChk_CheckedChanged(object sender, EventArgs e)
        {
            SetDataSourceColumnValue(partialSoldStatusChk.Checked);
        }

        private bool _isChecked;
        private void SetDataSourceColumnValue(bool isCHecked)
        {
            _isChecked = isCHecked;
            
            (DataModule.AccountingDS.Tables["FixedAssetsMaterials"]).AsEnumerable()
                .ToList<DataRow>()
                .ForEach(r => r["SoldPrice"] = ((_isChecked) ? 0 : r["FixedPrice"]));
        }

        private void SaveChanges()
        {
            Cursor = Cursors.WaitCursor;

            ((DataRowView)fixedAssetsOrderBS.Current)["EndRecordDate"] = dateSoldDatePicker.EditValue;
            ((DataRowView)fixedAssetsOrderBS.Current)["FixedCardStatus"] = (partialSoldStatusChk.Checked) ? PARTIAL_SOLD : SOLD;

            if (partialSoldStatusChk.Checked)
            {
                DataRow newRow = DataModule.AccountingDS.Tables["FixedAssetsOrder"].NewRow();

                newRow["Id_Parent"] = fixedAssetsOrderCurrentRow["Id"];
                newRow["InventoryNumber"] = fixedAssetsOrderCurrentRow["InventoryNumber"];
                newRow["InventoryName"] = fixedAssetsOrderCurrentRow["InventoryName"];
                newRow["Balance_Account_Id"] = fixedAssetsOrderCurrentRow["Balance_Account_Id"];
                newRow["Supplier_Id"] = fixedAssetsOrderCurrentRow["Supplier_Id"];
                newRow["BeginDate"] = fixedAssetsOrderCurrentRow["BeginDate"];
                newRow["BeginRecordDate"] = dateSoldDatePicker.DateTime.AddDays(1);
                newRow["EndRecordDate"] = DBNull.Value;
                newRow["Group_Id"] = fixedAssetsOrderCurrentRow["Group_Id"];
                newRow["UsefulMonth"] = fixedAssetsOrderCurrentRow["UsefulMonth"];
                newRow["Region_Id"] = fixedAssetsOrderCurrentRow["Region_Id"];

                DataModule.AccountingDS.Tables["FixedAssetsOrder"].Rows.Add(newRow);
            }

            fixedAssetsOrderBS.EndEdit();

            DataModule.Connection.Open();
            DataModule.BeginTransaction();

            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["FixedAssetsMaterials"].DeleteCommand.Transaction = DataModule.Transaction;

            try
            {
                if (!partialSoldStatusChk.Checked)
                {
                    DataModule.DataAdapter["FixedAssetsOrder"].Update(DataModule.AccountingDS.Tables["FixedAssetsOrder"]);
                }
                else
                {
                    int current_Id = (int)DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters["Id"].Value;
                    for (int row = 0; row < fixedAssetsMaterialTableCopy.Rows.Count; row++)
                    {
                        var newRowMaterial = DataModule.AccountingDS.Tables["FixedAssetsMaterials"].NewRow();

                        newRowMaterial["FixedAssetsOrder_Id"] = current_Id;
                        newRowMaterial["Expenditures_Id"] = fixedAssetsMaterialTableCopy.Rows[row]["Expenditures_Id"];
                        newRowMaterial["Fixed_Account_Id"] = fixedAssetsMaterialTableCopy.Rows[row]["Fixed_Account_Id"];
                        newRowMaterial["Flag"] = fixedAssetsMaterialTableCopy.Rows[row]["Flag"];
                        newRowMaterial["FixedPrice"] = fixedAssetsMaterialTableCopy.Rows[row]["FixedPrice"];
                        newRowMaterial["MaterialsDate"] = fixedAssetsMaterialTableCopy.Rows[row]["MaterialsDate"];
                        newRowMaterial["Description"] = fixedAssetsMaterialTableCopy.Rows[row]["Description"];
                        newRowMaterial["SoldPrice"] = fixedAssetsMaterialTableCopy.Rows[row]["SoldPrice"];

                        DataModule.AccountingDS.Tables["FixedAssetsMaterials"].Rows.Add(newRowMaterial);
                    }
                }
                fixedAssetsMaterialsBS.EndEdit();
                DataModule.DataAdapter["FixedAssetsMaterials"].Update(DataModule.AccountingDS.Tables["FixedAssetsMaterials"]);

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
                MessageBox.Show(DataModule.GetError(FbEcpt), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                DataModule.Connection.Close();
            }
            this.Close();
        }
   }
}
