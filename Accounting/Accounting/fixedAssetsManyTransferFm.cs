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
    public partial class fixedAssetsManyTransferFm : Form
    {
        private BindingSource fixedAssetsOrderBS = new BindingSource();
        private BindingSource fixedAssetsMaterialsBS = new BindingSource();
        private DataTable sourceDataTable;
        private DataTable fixedAssetsMaterialsTable;

        const short TRANSFER = 1;
        
        public fixedAssetsManyTransferFm(DataTable tranferDataTable)
        {
            InitializeComponent();
            
            fixedAssetsOrderBS.DataSource = DataModule.AccountingDS.Tables["FixedAssetsOrder"];
            fixedAssetsMaterialsBS.DataSource = DataModule.AccountingDS.Tables["FixedAssetsMaterials"];

            fixedAssetsMaterialsTable = (DataTable)(fixedAssetsMaterialsBS.DataSource);
            sourceDataTable = tranferDataTable.Copy();
            
            sourceDataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("BALANCE_ACCOUNT_NUM_NEW"),
                new DataColumn("BALANCE_ACCOUNT_ID_NEW"),
                new DataColumn("GROUP_NAME_NEW"),
                new DataColumn("GROUP_ID_NEW"),
                new DataColumn("USEFULMONTH_NEW"),
                new DataColumn("FIXED_ACCOUNT_NUM_NEW"),
                new DataColumn("FIXED_ACCOUNT_ID_NEW"),
                new DataColumn("REGION_NAME_NEW"),
                new DataColumn("REGION_ID_NEW"),
                new DataColumn("SUPPLIER_NAME_NEW"),
                new DataColumn("SUPPLIER_ID_NEW"),
                new DataColumn("OPERATINGPERSON_NAME_NEW"),
                new DataColumn("OPERATINGPERSON_ID_NEW"),
            });

            int recCount = sourceDataTable.Rows.Count;

            for (int i = 0; i < recCount; i++)
            {
                sourceDataTable.Rows[i]["BALANCE_ACCOUNT_NUM_NEW"] = sourceDataTable.Rows[i]["BALANCE_ACCOUNT_NUM"];
                sourceDataTable.Rows[i]["BALANCE_ACCOUNT_ID_NEW"] = sourceDataTable.Rows[i]["BALANCE_ACCOUNT_ID"];
                sourceDataTable.Rows[i]["GROUP_NAME_NEW"] = sourceDataTable.Rows[i]["GROUP_NAME"];
                sourceDataTable.Rows[i]["GROUP_ID_NEW"] = sourceDataTable.Rows[i]["GROUP_ID"];
                sourceDataTable.Rows[i]["USEFULMONTH_NEW"] = sourceDataTable.Rows[i]["USEFULMONTH"];
                sourceDataTable.Rows[i]["FIXED_ACCOUNT_NUM_NEW"] = sourceDataTable.Rows[i]["FIXED_ACCOUNT_NUM"];
                sourceDataTable.Rows[i]["FIXED_ACCOUNT_ID_NEW"] = sourceDataTable.Rows[i]["FIXED_ACCOUNT_ID"];
                sourceDataTable.Rows[i]["REGION_NAME_NEW"] = sourceDataTable.Rows[i]["REGION_NAME"];
                sourceDataTable.Rows[i]["REGION_ID_NEW"] = sourceDataTable.Rows[i]["REGION_ID"];
                sourceDataTable.Rows[i]["SUPPLIER_NAME_NEW"] = sourceDataTable.Rows[i]["SUPPLIER_NAME"];
                sourceDataTable.Rows[i]["SUPPLIER_ID_NEW"] = sourceDataTable.Rows[i]["SUPPLIER_ID"];
                sourceDataTable.Rows[i]["OPERATINGPERSON_NAME_NEW"] = sourceDataTable.Rows[i]["OPERATINGPERSON_NAME"];
                sourceDataTable.Rows[i]["OPERATINGPERSON_ID_NEW"] = sourceDataTable.Rows[i]["OPERATINGPERSON_ID"];
            }

            sourceDataTable.AcceptChanges();

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
            var RegionCBox_DataSource = DataModule.ExecuteFill(@"SELECT ""Id"",Trim(""Name"") as Name FROM ""Region"" ORDER BY ""Name""");

            regionNewCBox.Properties.DataSource = RegionCBox_DataSource;
            regionNewCBox.Properties.ValueMember = "Id";
            regionNewCBox.Properties.DisplayMember = "NAME";

            //**************
            var EmploeesList = DataModule.ExecuteFillProc("GetEmployeesWorking");

            deliveryTTNCBox.Properties.DataSource = EmploeesList;
            deliveryTTNCBox.Properties.ValueMember = "EmployeeID";
            deliveryTTNCBox.Properties.DisplayMember = "FullName";
            //**************

            operatingPersonNewCBox.Properties.DataSource = EmploeesList.Copy();
            operatingPersonNewCBox.Properties.ValueMember = "EmployeeID";
            operatingPersonNewCBox.Properties.DisplayMember = "FullName";
            //**************
            
            dateTransferDatePicker.EditValue = DateTime.Now;

            fixedAssetsManyTransferGrid.DataSource = sourceDataTable;
                        
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool balanceChange = (balanceAccountNewCBox.EditValue != null);
            bool fixedChange = (fixedAccountNewCBox.EditValue != null);
            bool groupChange = (groupNewCBox.EditValue != null);
            bool regionChange = (regionNewCBox.EditValue != null);
            bool supplierChange = (deliveryTTNCBox.EditValue != null);
            bool operatingPersonChange = (operatingPersonNewCBox.EditValue != null);
            bool monthChange = (usefulMonthNewNUD.Value > 0);

            Cursor = Cursors.WaitCursor;

            try
            {

                int orderRowCount = sourceDataTable.Rows.Count;

                for (int i = 0; i < orderRowCount; i++)
                {
                    (DataModule.AccountingDS.Tables["FixedAssetsOrder"]).AsEnumerable()
                        .Where(r => r.Field<int>("ID") == (int)sourceDataTable.Rows[i]["ID"])
                        .ToList<DataRow>()
                        .ForEach(r =>
                        {
                            r["EndRecordDate"] = dateTransferDatePicker.EditValue;
                            r["FixedCardStatus"] = TRANSFER;
                        });

                    DataRow newRow = DataModule.AccountingDS.Tables["FixedAssetsOrder"].NewRow();

                    newRow["Id_Parent"] = sourceDataTable.Rows[i]["Id"];
                    newRow["InventoryNumber"] = sourceDataTable.Rows[i]["InventoryNumber"];
                    newRow["InventoryName"] = sourceDataTable.Rows[i]["InventoryName"];
                    newRow["Balance_Account_Id"] = (balanceChange) ? balanceAccountNewCBox.EditValue : sourceDataTable.Rows[i]["Balance_Account_Id"];
                    newRow["Supplier_Id"] = (supplierChange) ? deliveryTTNCBox.EditValue : sourceDataTable.Rows[i]["Supplier_Id"];
                    newRow["BeginDate"] = sourceDataTable.Rows[i]["BeginDate"];
                    newRow["BeginRecordDate"] = dateTransferDatePicker.DateTime.AddDays(1);
                    newRow["EndRecordDate"] = DBNull.Value;
                    newRow["Group_Id"] = (groupChange) ? groupNewCBox.EditValue : sourceDataTable.Rows[i]["Group_Id"];
                    newRow["UsefulMonth"] = (monthChange) ? usefulMonthNewNUD.Value : sourceDataTable.Rows[i]["UsefulMonth"];
                    newRow["Region_Id"] = (regionChange) ? regionNewCBox.EditValue : sourceDataTable.Rows[i]["Region_Id"];
                    newRow["OperatingPerson_Id"] = (operatingPersonChange) ? operatingPersonNewCBox.EditValue : sourceDataTable.Rows[i]["OperatingPerson_Id"];

                    DataModule.AccountingDS.Tables["FixedAssetsOrder"].Rows.Add(newRow);

                    fixedAssetsOrderBS.MoveLast();
                    fixedAssetsOrderBS.EndEdit();

                    DataModule.Connection.Open();
                    DataModule.BeginTransaction();

                    DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Transaction = DataModule.Transaction;
                    DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Transaction = DataModule.Transaction;
                    DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.Transaction = DataModule.Transaction;
                    DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Transaction = DataModule.Transaction;
                    DataModule.DataAdapter["FixedAssetsMaterials"].DeleteCommand.Transaction = DataModule.Transaction;

                    DataModule.DataAdapter["FixedAssetsOrder"].Update(DataModule.AccountingDS.Tables["FixedAssetsOrder"]);

                    int current_Id = (int)DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters["Id"].Value;

                    ((DataRowView)fixedAssetsOrderBS.Current)["Id"] = current_Id;

                    DataTable fixedAssetMaterialTable = DataModule.ExecuteFill(@"SELECT * FROM ""FixedAssetsMaterials"" WHERE ""FixedAssetsMaterials"".""FixedAssetsOrder_Id"" = " + sourceDataTable.Rows[i]["Id"]);

                    int materialRowCount = fixedAssetMaterialTable.Rows.Count;

                    for (int row = 0; row < materialRowCount; row++)
                    {
                        var newRowMaterial = DataModule.AccountingDS.Tables["FixedAssetsMaterials"].NewRow();

                        newRowMaterial["FixedAssetsOrder_Id"] = current_Id;
                        newRowMaterial["Expenditures_Id"] = fixedAssetMaterialTable.Rows[row]["Expenditures_Id"];
                        newRowMaterial["Fixed_Account_Id"] = (fixedChange) ? fixedAccountNewCBox.EditValue : fixedAssetMaterialTable.Rows[row]["Fixed_Account_Id"];
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
                    DataModule.Connection.Close();
                }
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

            Cursor = Cursors.Default;    
            this.Close();
          
        }

        private void rejectChangesBtn_Click(object sender, EventArgs e)
        {
            sourceDataTable.RejectChanges();
            
            BalanceAccountNumNewColumn.AppearanceCell.BackColor = Color.White;
            FixedAccountNumNewColumn.AppearanceCell.BackColor = Color.White;
            GroupNameNewColumn.AppearanceCell.BackColor = Color.White;
            UsefulMonthNewColumn.AppearanceCell.BackColor = Color.White;
            RegionNewColumn.AppearanceCell.BackColor = Color.White;
            SupplierNewColumn.AppearanceCell.BackColor = Color.White;
            OperatingPersonNewColumn.AppearanceCell.BackColor = Color.White;

            balanceAccountNewCBox.EditValue = null;
            fixedAccountNewCBox.EditValue = null;
            groupNewCBox.EditValue = null;
            deliveryTTNCBox.EditValue = null;
            regionNewCBox.EditValue = null;
            operatingPersonNewCBox.EditValue = null;
            usefulMonthNewNUD.Value = 0;

            saveBtn.Enabled = false;
        }

        private void setChangesBtn_Click(object sender, EventArgs e)
        {
            bool balanceChange = (balanceAccountNewCBox.EditValue != null);
            bool fixedChange = (fixedAccountNewCBox.EditValue != null);
            bool groupChange = (groupNewCBox.EditValue != null);
            bool monthChange = (usefulMonthNewNUD.Value > 0);
            bool regionChange = (regionNewCBox.EditValue != null);
            bool supplierChange = (deliveryTTNCBox.EditValue != null);
            bool operatingPersonChange = (operatingPersonNewCBox.EditValue != null);
            
            if (balanceChange)
                {
                    sourceDataTable.AsEnumerable()
                        .ToList<DataRow>()
                        .ForEach(r =>
                        {
                            r["BALANCE_ACCOUNT_NUM_NEW"] = balanceAccountNewCBox.Text;
                            r["BALANCE_ACCOUNT_ID_NEW"] = balanceAccountNewCBox.EditValue;
                        });
                    BalanceAccountNumNewColumn.AppearanceCell.BackColor = Color.LightGreen;
                    BalanceAccountNumNewColumn.AppearanceCell.BackColor2 = Color.WhiteSmoke;
                }

            if (fixedChange)
                {
                    sourceDataTable.AsEnumerable()
                        .ToList<DataRow>()
                        .ForEach(r =>
                        {
                            r["FIXED_ACCOUNT_NUM_NEW"] = fixedAccountNewCBox.Text;
                            r["FIXED_ACCOUNT_ID_NEW"] = fixedAccountNewCBox.EditValue;
                        });
                    FixedAccountNumNewColumn.AppearanceCell.BackColor = Color.LightGreen;
                    FixedAccountNumNewColumn.AppearanceCell.BackColor2 = Color.WhiteSmoke;
                }

            if (groupChange)
                {
                    sourceDataTable.AsEnumerable()
                        .ToList<DataRow>()
                        .ForEach(r =>
                        {
                            r["GROUP_NAME_NEW"] = groupNewCBox.Text;
                            r["GROUP_ID_NEW"] = groupNewCBox.EditValue;
                        });
                    GroupNameNewColumn.AppearanceCell.BackColor = Color.LightGreen;
                    GroupNameNewColumn.AppearanceCell.BackColor2 = Color.WhiteSmoke;
                }

            if (monthChange)
                {
                    sourceDataTable.AsEnumerable()
                        .ToList<DataRow>()
                        .ForEach(r => r["USEFULMONTH_NEW"] = usefulMonthNewNUD.Value);
                    UsefulMonthNewColumn.AppearanceCell.BackColor = Color.LightGreen;
                    UsefulMonthNewColumn.AppearanceCell.BackColor2 = Color.WhiteSmoke;
                }

            if (regionChange)
            {
                sourceDataTable.AsEnumerable()
                    .ToList<DataRow>()
                    .ForEach(r =>
                    {
                        r["REGION_NAME_NEW"] = regionNewCBox.Text;
                        r["REGION_ID_NEW"] = regionNewCBox.EditValue;
                    });
                RegionNewColumn.AppearanceCell.BackColor = Color.LightGreen;
                RegionNewColumn.AppearanceCell.BackColor2 = Color.WhiteSmoke;
            }

            if (supplierChange)
            {
                sourceDataTable.AsEnumerable()
                    .ToList<DataRow>()
                    .ForEach(r =>
                    {
                        r["SUPPLIER_NAME_NEW"] = deliveryTTNCBox.Text;
                        r["SUPPLIER_ID_NEW"] = deliveryTTNCBox.EditValue;
                    });
                SupplierNewColumn.AppearanceCell.BackColor = Color.LightGreen;
                SupplierNewColumn.AppearanceCell.BackColor2 = Color.WhiteSmoke;
            }

            if (operatingPersonChange)
            {
                sourceDataTable.AsEnumerable()
                    .ToList<DataRow>()
                    .ForEach(r =>
                    {
                        r["OPERATINGPERSON_NAME_NEW"] = operatingPersonNewCBox.Text;
                        r["OPERATINGPERSON_ID_NEW"] = operatingPersonNewCBox.EditValue;
                    });
                OperatingPersonNewColumn.AppearanceCell.BackColor = Color.LightGreen;
                OperatingPersonNewColumn.AppearanceCell.BackColor2 = Color.WhiteSmoke;
            }

            if (balanceChange || fixedChange || groupChange || monthChange || regionChange || supplierChange || operatingPersonChange)
                saveBtn.Enabled = true;
         }

        private void supplierNewCBox_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }
       
    }
}
