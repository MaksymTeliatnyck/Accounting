using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
    public partial class fixedAssetTransferFm : Form
    {
        private DataTable fixedAssetMaterialTable = null;
        
        private DataRow fixedAssetsOrderCurrentRow = null;
        
        private BindingSource fixedAssetsOrderBS = new BindingSource();
        private BindingSource fixedAssetsMaterialsBS = new BindingSource();

        const short TRANSFER = 1;

        public fixedAssetTransferFm(int position)
        {
            InitializeComponent();

            fixedAssetsOrderBS.DataSource = DataModule.AccountingDS.Tables["FixedAssetsOrder"];
            fixedAssetsOrderBS.Position = position;
            fixedAssetsMaterialsBS.DataSource = DataModule.AccountingDS.Tables["FixedAssetsMaterials"];
            //**************
            var accountCBox_DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
                        
            balanceAccountNewCBox.Properties.DataSource = accountCBox_DataSource;
            balanceAccountNewCBox.Properties.ValueMember = "ID";
            balanceAccountNewCBox.Properties.DisplayMember = "NUM";

            fixedAccountNewCBox.Properties.DataSource = accountCBox_DataSource.Copy();
            fixedAccountNewCBox.Properties.ValueMember = "ID";
            fixedAccountNewCBox.Properties.DisplayMember = "NUM";

            //**************
            var GroupCBox_DataSource = DataModule.ExecuteFill(@"SELECT * FROM ""FixedAssetsGroup"" ORDER BY ""Name""");

            groupNewCBox.Properties.DataSource = GroupCBox_DataSource;
            groupNewCBox.Properties.ValueMember = "Id";
            groupNewCBox.Properties.DisplayMember = "Name";

            //**************
            var RegionCBox_DataSource = DataModule.ExecuteFill(@"SELECT ""Id"",""Name"" FROM ""Region"" ORDER BY ""Name""");

            regionNewCBox.Properties.DataSource = RegionCBox_DataSource;
            regionNewCBox.Properties.ValueMember = "Id";
            regionNewCBox.Properties.DisplayMember = "Name";
            
            //**************
            //var EmploeesList = DataModule.ExecuteFillProc("GetEmployeesWorking");
            var EmploeesList = DataModule.ExecuteFill(@"SELECT EMPLOYEEID AS ""EmployeeID"", FULLNAME AS ""FullName"" FROM Responsible");

            supplierNewCBox.Properties.DataSource = EmploeesList;
            supplierNewCBox.Properties.ValueMember = "EmployeeID";
            supplierNewCBox.Properties.DisplayMember = "FullName";
            //**************
            
            operatingPersonNewCBox.Properties.DataSource = EmploeesList.Copy();
            operatingPersonNewCBox.Properties.ValueMember = "EmployeeID";
            operatingPersonNewCBox.Properties.DisplayMember = "FullName";
            //**************
            
            fixedAssetMaterialTable = ((DataTable)fixedAssetsMaterialsBS.DataSource).Copy();

            fixedAssetsOrderCurrentRow = ((DataRowView)fixedAssetsOrderBS.Current).Row;
                       
            //**************
            balanceAccountTBox.DataBindings.Add("EditValue", fixedAssetsOrderBS, "Balance_Account_Num");
            balanceAccountNewCBox.EditValue = fixedAssetsOrderCurrentRow["Balance_Account_Id"];

            fixedAccountTBox.DataBindings.Add("EditValue", fixedAssetsMaterialsBS, "Fixed_Num");
            fixedAccountNewCBox.EditValue = fixedAssetMaterialTable.Rows[0]["Fixed_Account_Id"];

            groupTBox.DataBindings.Add("EditValue", fixedAssetsOrderBS,"Group_Name");
            groupNewCBox.EditValue = fixedAssetsOrderCurrentRow["Group_Id"];

            usefulMonthTBox.DataBindings.Add("EditValue", fixedAssetsOrderBS, "UsefulMonth");
            usefulMonthNewNUD.Value = (short)fixedAssetsOrderCurrentRow["UsefulMonth"];

            regionTBox.DataBindings.Add("EditValue", fixedAssetsOrderBS, "Region_Name");
            regionNewCBox.EditValue = fixedAssetsOrderCurrentRow["Region_Id"];


            supplierTBox.DataBindings.Add("EditValue", fixedAssetsOrderBS, "Supplier_Name");
            supplierNewCBox.EditValue = fixedAssetsOrderCurrentRow["Supplier_Id"];

            operatingPersonTBox.DataBindings.Add("EditValue", fixedAssetsOrderBS, "OperatingPerson_Name");
            operatingPersonNewCBox.EditValue = fixedAssetsOrderCurrentRow["OperatingPerson_Id"];
            
            dateTransferDatePicker.EditValue = DateTime.Now;
            
            fixedAssetInventory.Text = String.Format("{0} {1}", fixedAssetsOrderCurrentRow["InventoryNumber"], fixedAssetsOrderCurrentRow["InventoryName"]);
        }
       
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            #region Validation

            int amountOfChange = 0;

            amountOfChange += (balanceAccountTBox.Text == balanceAccountNewCBox.Text) ? 0 : 1;
            amountOfChange += (groupTBox.Text == groupNewCBox.Text) ? 0 : 1;
            amountOfChange += (usefulMonthTBox.Text == usefulMonthNewNUD.Value.ToString()) ? 0 : 1;
            amountOfChange += (fixedAccountTBox.Text == fixedAccountNewCBox.Text) ? 0 : 1;
            amountOfChange += (regionTBox.Text == regionNewCBox.Text) ? 0 : 1;
            amountOfChange += (supplierTBox.Text == supplierNewCBox.Text) ? 0 : 1;
            amountOfChange += (operatingPersonTBox.Text == operatingPersonNewCBox.Text) ? 0 : 1;
            
            #endregion

            if (amountOfChange > 0)
            {
                ((DataRowView)fixedAssetsOrderBS.Current)["EndRecordDate"] = dateTransferDatePicker.EditValue;
                ((DataRowView)fixedAssetsOrderBS.Current)["FixedCardStatus"] = TRANSFER;

                DataRow newRow = DataModule.AccountingDS.Tables["FixedAssetsOrder"].NewRow();

                newRow["Id_Parent"] = fixedAssetsOrderCurrentRow["Id"];
                newRow["InventoryNumber"] = fixedAssetsOrderCurrentRow["InventoryNumber"];
                newRow["InventoryName"] = fixedAssetsOrderCurrentRow["InventoryName"];
                newRow["Balance_Account_Id"] = balanceAccountNewCBox.EditValue;
                newRow["Supplier_Id"] = supplierNewCBox.EditValue;
                newRow["BeginDate"] = fixedAssetsOrderCurrentRow["BeginDate"];
                newRow["BeginRecordDate"] = dateTransferDatePicker.DateTime.AddDays(1);
                newRow["EndRecordDate"] = DBNull.Value;
                newRow["Group_Id"] = groupNewCBox.EditValue;
                newRow["UsefulMonth"] = usefulMonthNewNUD.Value;
                newRow["Region_Id"] = regionNewCBox.EditValue;
                newRow["OperatingPerson_Id"] = operatingPersonNewCBox.EditValue;

                DataModule.AccountingDS.Tables["FixedAssetsOrder"].Rows.Add(newRow);

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
                    DataModule.DataAdapter["FixedAssetsOrder"].Update(DataModule.AccountingDS.Tables["FixedAssetsOrder"]);

                    int current_Id = (int)DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters["Id"].Value;
                    for (int row = 0; row < fixedAssetMaterialTable.Rows.Count; row++)
                    {
                        var newRowMaterial = DataModule.AccountingDS.Tables["FixedAssetsMaterials"].NewRow();

                        newRowMaterial["FixedAssetsOrder_Id"] = current_Id;
                        newRowMaterial["Expenditures_Id"] = fixedAssetMaterialTable.Rows[row]["Expenditures_Id"];
                        newRowMaterial["Fixed_Account_Id"] = fixedAccountNewCBox.EditValue;
                        newRowMaterial["Flag"] = fixedAssetMaterialTable.Rows[row]["Flag"];
                        newRowMaterial["FixedPrice"] = fixedAssetMaterialTable.Rows[row]["FixedPrice"];
                        newRowMaterial["MaterialsDate"] = fixedAssetMaterialTable.Rows[row]["MaterialsDate"];
                        newRowMaterial["Description"] = fixedAssetMaterialTable.Rows[row]["Description"];
                        newRowMaterial["SoldPrice"] = fixedAssetMaterialTable.Rows[row]["SoldPrice"];
                        
                        DataModule.AccountingDS.Tables["FixedAssetsMaterials"].Rows.Add(newRowMaterial);
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
                    MessageBox.Show(DataModule.GetError(FbEcpt), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    DataModule.Connection.Close();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Змініть інформацію для переміщення картки основного засобу!", "Переміщення основного засобу", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void balanceAccountNewCBox_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                accountsRBFm accountsRBFm = new accountsRBFm();
                accountsRBFm.ShowDialog();
                balanceAccountNewCBox.Properties.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            }
        }

        private void groupNewCBox_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                regionRBFm regionRBFrm = new regionRBFm();
                regionRBFrm.ShowDialog();
                groupNewCBox.Properties.DataSource = DataModule.ExecuteFill(@"SELECT * FROM ""FixedAssetsGroup"" ORDER BY ""Name""");
                groupNewCBox.Focus();
            }
        }

        private void fixedAccountNewCBox_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                accountsRBFm accountsRBFm = new accountsRBFm();
                accountsRBFm.ShowDialog();
                fixedAccountNewCBox.Properties.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
                fixedAccountNewCBox.Focus();
            }
        }

        private void regionNewCBox_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                regionRBFm regionRBFm = new regionRBFm();
                regionRBFm.ShowDialog();
                regionNewCBox.Properties.DataSource = DataModule.ExecuteFill(@"SELECT ""Id"",Trim(""Name"") as Name FROM ""Region"" ORDER BY ""Name""");
                regionNewCBox.Focus();
            }
        }

        private void supplierNewCBox_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        private void operatingPersonNewCBox_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                operatingPersonNewCBox.EditValue = DBNull.Value;
            }
        }
    }
}
