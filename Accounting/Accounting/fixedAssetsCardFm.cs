using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Accounting
{
    public partial class fixedAssetsCardFm : Form
    {
        private bool _inserting;
        private int _order_Id;
        private DateTime _datePeriodStart;
        private DateTime _datePeriodEnd;

        private DataTable FixedAssetsMaterialsTable = new DataTable();

        private BindingSource fixedAssetsOrderBS = new BindingSource();
        private BindingSource fixedAssetsMaterialsBS = new BindingSource();

        public fixedAssetsCardFm(bool inserting, int position = -1, int order_Id = -1, string datePeriodStart = null, string datePeriodEnd = null)
        {
            InitializeComponent();

            _inserting = inserting;
            _order_Id = _inserting ? -1 : order_Id;
            _datePeriodStart = _inserting ? DateTime.Now : DateTime.Parse(datePeriodStart);
            _datePeriodEnd = _inserting ? DateTime.Now : DateTime.Parse(datePeriodEnd);

            fixedAssetsOrderBS.DataSource = DataModule.AccountingDS.Tables["FixedAssetsOrder"];
            //fixedAssetsMaterialsBS.DataSource = DataModule.AccountingDS.Tables["FixedAssetsMaterials"];
            //fixedAssetsMaterialsGrid.DataSource = fixedAssetsMaterialsBS;

            LoadMaterialsDate();
            //fixedAssetsMaterialsBS.DataSource = FixedAssetsMaterialsTable;
            //fixedAssetsMaterialsGrid.DataSource = fixedAssetsMaterialsBS;

            if (_inserting)
            {
                DataRow Row;
                Row = DataModule.AccountingDS.Tables["FixedAssetsOrder"].NewRow();
                Row["Id_Parent"] = 0;
                Row["UsefulMonth"] = 0;
                DataModule.AccountingDS.Tables["FixedAssetsOrder"].Rows.Add(Row);
                fixedAssetsOrderBS.MoveLast();
            }
            else
            {
                fixedAssetsOrderBS.Position = position;
            }

            var responsibleDataSource = DataModule.ExecuteFill(@"SELECT EMPLOYEEID AS ID, FULLNAME AS NAME FROM Responsible");

            #region Binding's

            inventoryNumberTBox.DataBindings.Add("Text", fixedAssetsOrderBS, "InventoryNumber");
            inventoryNameTBox.DataBindings.Add("Text", fixedAssetsOrderBS, "InventoryName");
            usefulMonthTBox.DataBindings.Add("Text", fixedAssetsOrderBS, "UsefulMonth");
            balanceTBox.DataBindings.Add("Text", fixedAssetsOrderBS, "Balance_Account_Num");

            beginDatePicker.DataBindings.Add("EditValue", fixedAssetsOrderBS, "BeginDate");
            endRegisterDatePicker.DataBindings.Add("EditValue", fixedAssetsOrderBS, "EndRecordDate");

            priceTBox.DataBindings.Add("Text", fixedAssetsOrderBS, "BeginPrice");
            increasePriceTBox.DataBindings.Add("Text", fixedAssetsOrderBS, "IncreasePrice");
            totalPriceTBox.DataBindings.Add("Text", fixedAssetsOrderBS, "TotalPrice");
            currentPriceTBox.DataBindings.Add("Text", fixedAssetsOrderBS, "CurrentPrice");
            allAmortizationPriceTBox.DataBindings.Add("Text", fixedAssetsOrderBS, "PeriodAmortization");
            periodAmortizationPriceTBox.DataBindings.Add("Text", fixedAssetsOrderBS, "PeriodYearAmortization");
            currentAmortizationPriceTBox.DataBindings.Add("Text", fixedAssetsOrderBS, "CurrentAmortization");

            supplierCBox.DataSource = responsibleDataSource;
            supplierCBox.ValueMember = "Id";
            supplierCBox.DisplayMember = "Name";
            supplierCBox.DataBindings.Add("SelectedValue", fixedAssetsOrderBS, "Supplier_Id");
            supplierCBox.DataBindings.Add("Text", fixedAssetsOrderBS, "Supplier_Name");

            operatingPersonCBox.DataSource = responsibleDataSource.Copy();
            operatingPersonCBox.ValueMember = "Id";
            operatingPersonCBox.DisplayMember = "Name";
            operatingPersonCBox.DataBindings.Add("SelectedValue", fixedAssetsOrderBS, "OperatingPerson_Id");
            operatingPersonCBox.DataBindings.Add("Text", fixedAssetsOrderBS, "OperatingPerson_Name");

            debitCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            debitCBox.ValueMember = "Id";
            debitCBox.DisplayMember = "Num";
            debitCBox.DataBindings.Add("SelectedValue", fixedAssetsMaterialsBS, "Fixed_Account_Id");
            debitCBox.DataBindings.Add("Text", fixedAssetsMaterialsBS, "Fixed_Num");

            fixedAssetsGroupCBox.DataSource = DataModule.ExecuteFill(@"SELECT * FROM ""FixedAssetsGroup"" ORDER BY ""Name""");
            fixedAssetsGroupCBox.ValueMember = "Id";
            fixedAssetsGroupCBox.DisplayMember = "Name";
            fixedAssetsGroupCBox.DataBindings.Add("SelectedValue", fixedAssetsOrderBS, "Group_Id");
            fixedAssetsGroupCBox.DataBindings.Add("Text", fixedAssetsOrderBS, "Group_Name");

            regionCBox.DataSource = DataModule.ExecuteFill(@"SELECT ""Id"", trim(""Name"") as Name FROM ""Region"" ORDER BY ""Name""");
            regionCBox.ValueMember = "Id";
            regionCBox.DisplayMember = "Name";
            regionCBox.DataBindings.Add("SelectedValue", fixedAssetsOrderBS, "Region_Id");
            regionCBox.DataBindings.Add("Text", fixedAssetsOrderBS, "Region_Name");

            #endregion

            if (_inserting)
            {
                debitCBox.SelectedIndex = -1;
                fixedAssetsGroupCBox.SelectedIndex = -1;
            }

            SetEnablesButton();
            //CalculateAmortization(_datePeriodStart, _datePeriodEnd);
        }
                
        #region Events

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveFixedCard()) return;

                this.Close();

                DialogResult = DialogResult.OK;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addMaterialsBtn_Click(object sender, EventArgs e)
        {
            if (int.Parse(usefulMonthTBox.Text) > 0 && (beginDatePicker.EditValue).ToString().Length > 0)
            {
                expendituresForFixedAssetsFm expendituresAssets = new expendituresForFixedAssetsFm(beginDatePicker.DateTime);

                if (expendituresAssets.ShowDialog() == DialogResult.OK)
                {
                    DataRow expenRow = expendituresAssets.Return();

                    DataRow materialsRow;
                    materialsRow = FixedAssetsMaterialsTable.NewRow();
                    materialsRow["Expenditures_Id"] = expenRow["ID"];
                    materialsRow["Exp_Date"] = expenRow["Exp_Date"];
                    materialsRow["FixedPrice"] = expenRow["SetPrice"];
                    materialsRow["Name"] = expenRow["Name"];
                    materialsRow["Nomenclature"] = expenRow["Nomenclature"];
                    materialsRow["Flag"] = 0;
                    materialsRow["FixedAssetsOrder_Id"] = -1;

                    ((DataRowView)fixedAssetsOrderBS.Current)["Balance_Account_Id"] = expenRow["Credit_Account_Id"];
                    ((DataRowView)fixedAssetsOrderBS.Current)["Balance_Account_Num"] = expenRow["Credit_Account"];

                    balanceTBox.Text = (string)expenRow["Credit_Account"];

                    FixedAssetsMaterialsTable.Rows.Add(materialsRow);

                    fixedAssetsMaterialsGrid.Focus();

                    SetEnablesButton();

                    //CalculateAmortization(_datePeriodStart, _datePeriodEnd);
                }
            }
            else
            {
                MessageBox.Show("Укажите срок полезного использования, дату принятия к учету", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addPriceBtn_Click(object sender, EventArgs e)
        {
            expendituresForFixedAssetsFm expendituresAssets = new expendituresForFixedAssetsFm(beginDatePicker.DateTime);

            if (expendituresAssets.ShowDialog() == DialogResult.OK)
            {
                DataRow expenRow = expendituresAssets.Return();

                DataRow materialsRow;
                materialsRow = FixedAssetsMaterialsTable.NewRow();
                materialsRow["Expenditures_Id"] = expenRow["ID"];
                materialsRow["Exp_Date"] = expenRow["Exp_Date"];
                materialsRow["FixedPrice"] = expenRow["SetPrice"];
                materialsRow["Name"] = expenRow["Name"];
                materialsRow["Nomenclature"] = expenRow["Nomenclature"];
                materialsRow["Flag"] = 1;
                //materialsRow["Fixed_Account_Id"] = debitCBox.SelectedValue;
                //materialsRow["Fixed_Num"] = debitCBox.Text;
                
                FixedAssetsMaterialsTable.Rows.Add(materialsRow);

                fixedAssetsMaterialsGrid.Focus();

                SetEnablesButton();
                //CalculateAmortization(_datePeriodStart, _datePeriodEnd);
            }
        }

        private void сorrectionBtn_Click(object sender, EventArgs e)
        {
            OpenCorrectionFm(true);
        }

        private void editMaterialsBtn_Click(object sender, EventArgs e)
        {
            OpenCorrectionFm(false);
        }

        private void deleteMaterialsBtn_Click(object sender, EventArgs e)
        {
            if (fixedAssetsMaterialsBS.Count != 0 && MessageBox.Show("Удалить материал?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fixedAssetsMaterialsBS.RemoveCurrent();
                fixedAssetsMaterialsGrid.Focus();

                SetEnablesButton();
                //CalculateAmortization(_datePeriodStart, _datePeriodEnd);
            }
        }

        private void fixedAssetsGroup_Click(object sender, EventArgs e)
        {
            fixedAssetsGroupRGFm fixedGroupFm = new fixedAssetsGroupRGFm();
            fixedGroupFm.ShowDialog();
            fixedAssetsGroupCBox.DataSource = DataModule.ExecuteFill(@"SELECT * FROM ""FixedAssetsGroup"" ORDER BY ""Name""");
            fixedAssetsGroupCBox.SelectedIndex = -1;
            fixedAssetsGroupCBox.Focus();
        }

        private void openRBDebitBtn_Click(object sender, EventArgs e)
        {
            accountsRBFm accountsRBFm = new accountsRBFm();
            accountsRBFm.ShowDialog();
            debitCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            debitCBox.SelectedIndex = -1;
            debitCBox.Focus();
        }

        private void regionBtn_Click(object sender, EventArgs e)
        {
            regionRBFm regionRBFrm = new regionRBFm();
            regionRBFrm.ShowDialog();
            regionCBox.DataSource = DataModule.ExecuteFill(@"SELECT ""Id"",Trim(""Name"") as Name FROM ""Region"" ORDER BY ""Name""");
            regionCBox.SelectedIndex = -1;
            regionCBox.Focus();
        }

        private void fixedAssetsMaterialsGridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            
            if (e.Column == flagImageColumn && e.IsGetData)
            {
                short flagNote = (short)fixedAssetsMaterialsGridView.GetRowCellValue(e.ListSourceRowIndex, "Flag");
                e.Value = materialsGridImageCollection.Images[flagNote];                
            }
             
        }

        private void fixedAssetsMaterialsGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
                editMaterialsBtn.Enabled = (
                    ((short)((DataRowView)fixedAssetsMaterialsBS.Current)["Flag"] == 2) ||
                    (((short)((DataRowView)fixedAssetsMaterialsBS.Current)["Flag"] == 1) && (((DataRowView)fixedAssetsMaterialsBS.Current)["Expenditures_Id"] is DBNull))
                                            ) ? true : false;
        }

        private void inventoryNumberTBox_Validating(object sender, CancelEventArgs e)
        {
            if (_inserting)
                ValidateInventoryNumber();
        }

        private bool ValidateInventoryNumber()
        {
            bool validatingStatus = true;
            string inventoryNumber = inventoryNumberTBox.Text;

            if (inventoryNumber.Length > 0)
            {
                DataModule.Connection.Open();
                
                int dublicateCount = (int)DataModule.ExecuteScalar(@"SELECT COUNT(*) FROM ""FixedAssetsOrder"" WHERE ""InventoryNumber"" = '" + inventoryNumber + "'");
                
                DataModule.Connection.Close();
                
                if (dublicateCount > 0)
                {
                    fixedAssetsCardErrorProvider.SetError(inventoryNumberTBox, "Инвентарный номер уже используется!");
                    inventoryNumberTBox.Focus();
                    validatingStatus = false;
                }
                else
                {
                    fixedAssetsCardErrorProvider.SetError(inventoryNumberTBox, "");
                }
            }
            return validatingStatus;
        }

        #endregion 

        #region Method's

        private void LoadMaterialsDate()
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("Id", _order_Id),
                    new FbParameter("EndDate", _datePeriodEnd)
                };
            FixedAssetsMaterialsTable = DataModule.ExecuteFill(DataModule.DataAdapter["FixedAssetsMaterials"].SelectCommand.CommandText, Parameters);

            fixedAssetsMaterialsBS.DataSource = FixedAssetsMaterialsTable;
            fixedAssetsMaterialsGrid.DataSource = fixedAssetsMaterialsBS;
        }

        private void SetEnablesButton()
        {
            addPriceBtn.Enabled = (FixedAssetsMaterialsTable.AsEnumerable().Where(r => r.RowState != DataRowState.Deleted).Count() > 0);
            сorrectionBtn.Enabled = (FixedAssetsMaterialsTable.AsEnumerable().Where(r => r.RowState != DataRowState.Deleted).Count() > 0);
            deleteMaterialsBtn.Enabled = (FixedAssetsMaterialsTable.Rows.Count > 0);
        }

        private void CalculateAmortization(DateTime beginPeriodDate, DateTime endPeriodDate)
        {
            DateTime beginDate;
            DateTime _beginPeriodDate = beginPeriodDate;
            DateTime _endPeriodDate = endPeriodDate;
            decimal currentPrice = 0.00m;
            decimal beginPrice = 0.00m;
            decimal currentMaterialAmortization = 0.00m;
            decimal currentAmortizationPrice = 0.00m;
            decimal allPeriodAmortization = 0.00m;
            decimal currentPeriodAmortization = 0.00m;
            decimal increasePrice = 0.00m;
            decimal totalPrice = 0.00m;
            decimal correctionPrice = 0.00m;

            int countMonth = 0;
            int countPeriodMonth = 0;
            short usefulMonth;

            if ((int)FixedAssetsMaterialsTable.AsEnumerable().Where(r => r.RowState != DataRowState.Deleted).Count() > 0)
            {

                usefulMonth = (short)((DataRowView)fixedAssetsOrderBS.Current)["UsefulMonth"];

                beginPrice = Math.Round(FixedAssetsMaterialsTable.AsEnumerable().Where(r => r.RowState != DataRowState.Deleted && r.Field<short>("Flag") == 0).Select(s => s.Field<decimal>("FixedPrice")).Sum(), 2);
                increasePrice = Math.Round(FixedAssetsMaterialsTable.AsEnumerable().Where(r => r.RowState != DataRowState.Deleted && r.Field<short>("Flag") == 1).Select(s => s.Field<decimal>("FixedPrice")).Sum(), 2);
                correctionPrice = Math.Round(FixedAssetsMaterialsTable.AsEnumerable().Where(r => r.RowState != DataRowState.Deleted && r.Field<short>("Flag") == 2 && r.Field<DateTime>("MaterialsDate") <= _endPeriodDate).Select(s => s.Field<decimal>("FixedPrice")).Sum(), 2);

                totalPrice = beginPrice + increasePrice;

                DataTable materialsTempTable = FixedAssetsMaterialsTable.AsEnumerable().Where(r => r.RowState != DataRowState.Deleted && r.Field<short>("Flag") < 2).CopyToDataTable();
                int tableRowCount = materialsTempTable.Rows.Count;

                for (int i = 0; i < tableRowCount; i++)
                {
                    beginDate = materialsTempTable.Rows[i].Field<DateTime>("Exp_Date");
                    countMonth = (beginDate > _endPeriodDate) ? 0 : (_endPeriodDate.Month - beginDate.Month) + 12 * (_endPeriodDate.Year - beginDate.Year);
                    countPeriodMonth = (beginDate > _beginPeriodDate) ? 0 : (_beginPeriodDate.Month - beginDate.Month) + 12 * (_beginPeriodDate.Year - beginDate.Year);

                    currentMaterialAmortization = (countMonth < 1) ? 0 : Math.Round(materialsTempTable.Rows[i].Field<decimal>("FixedPrice") / usefulMonth, 2, MidpointRounding.AwayFromZero);

                    currentAmortizationPrice += currentMaterialAmortization;
                    allPeriodAmortization += currentMaterialAmortization * countMonth;
                    currentPeriodAmortization += currentMaterialAmortization * countPeriodMonth;

                }

                currentPeriodAmortization = (totalPrice - currentPeriodAmortization) + correctionPrice;
                
                currentPrice = (totalPrice - allPeriodAmortization) + correctionPrice;

                currentAmortizationPrice = (totalPrice == (totalPrice - allPeriodAmortization))
                                                    ? 0
                                                    : (currentPrice) > 0
                                                      ? currentAmortizationPrice
                                                      : (currentAmortizationPrice + currentPrice) > 0
                                                        ? (currentAmortizationPrice + currentPrice)
                                                        : 0;

                allPeriodAmortization = (currentPrice <= 0) ? totalPrice : allPeriodAmortization;


                currentPeriodAmortization = (currentPeriodAmortization < 0)
                                                     ? 0
                                                     : (currentPrice >= 0)
                                                       ? (currentPeriodAmortization - currentPrice)
                                                       : currentPeriodAmortization;
            }

            priceTBox.Text = beginPrice.ToString("N", Utils.NumFormat(2));
            currentPriceTBox.Text = (currentPrice > 0) ? currentPrice.ToString("N", Utils.NumFormat(2)) : "0,00";
            currentAmortizationPriceTBox.Text = currentAmortizationPrice.ToString("N", Utils.NumFormat(2));
            allAmortizationPriceTBox.Text = allPeriodAmortization.ToString("N", Utils.NumFormat(2));
            periodAmortizationPriceTBox.Text = currentPeriodAmortization.ToString("N", Utils.NumFormat(2));
            increasePriceTBox.Text = increasePrice.ToString("N", Utils.NumFormat(2));
            totalPriceTBox.Text = totalPrice.ToString("N", Utils.NumFormat(2));
        }
               
        private bool SaveFixedCard()
        {
            bool result = false;

            #region Validation

            string outputWarning = "";

            outputWarning += (inventoryNumberTBox.Text.Length == 0) ? "Не указан инвентарный номер \n" : "";
            outputWarning += (inventoryNameTBox.Text.Length == 0) ? "Не указано наименование основного средства \n" : "";
            outputWarning += (supplierCBox.SelectedValue == null) ? "Не выбрано ответственное лицо \n" : "";
            outputWarning += (int.Parse(usefulMonthTBox.Text) == 0) ? "Не указан срок полезного использования \n" : "";
            outputWarning += ((beginDatePicker.EditValue).ToString().Length == 0) ? "Не указана дата принятия к учету \n" : "";
            outputWarning += (debitCBox.SelectedValue == null) ? "Не указан счет начисления амортизации \n" : "";
            outputWarning += (fixedAssetsGroupCBox.SelectedValue == null) ? "Не выбрана группа основного средства \n" : "";
            outputWarning += (FixedAssetsMaterialsTable.AsEnumerable().Where(r => r.RowState != DataRowState.Deleted).Count() == 0) ? "Не добавлен материал в карточку \n" : "";

            #endregion

            if (outputWarning.Length != 0)
            {
                MessageBox.Show(outputWarning, "Недостаточно данных для сохранения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = false;
            }
            else
            {
                ((DataRowView)fixedAssetsOrderBS.Current)["BeginRecordDate"] = (_inserting) ? beginDatePicker.EditValue : ((DataRowView)fixedAssetsOrderBS.Current)["BeginRecordDate"];
                
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

                    _order_Id = (_inserting) 
                                ? (int)DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters["Id"].Value
                                : (int)((DataRowView)fixedAssetsOrderBS.Current)["Id"];
                    FixedAssetsMaterialsTable.AsEnumerable()
                        .Where(r => r.RowState != DataRowState.Deleted)
                        .ToList<DataRow>()
                        .ForEach(r => {
                                       r["FixedAssetsOrder_Id"] = _order_Id;
                                       r["Fixed_Account_Id"] = debitCBox.SelectedValue;
                                      }
                                );

                    fixedAssetsMaterialsBS.EndEdit();
                    DataModule.DataAdapter["FixedAssetsMaterials"].Update(FixedAssetsMaterialsTable);

                    DataModule.CommitTransaction();

                    result = true;
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

                    result = false;
                }
                finally
                {
                    Cursor = Cursors.Default;
                    DataModule.Connection.Close();
                }

            }

            return result;

        }

        private bool Inserting;
        private void OpenCorrectionFm(bool inserting)
        {
            Inserting = inserting;

            correctionAddEditFm correctionFm;
            int current_OrderId = (int)((DataRowView)fixedAssetsMaterialsBS.Current)["FixedAssetsOrder_Id"];
            
            if (inserting)
            {
                correctionFm = new correctionAddEditFm(true, fixedAssetsMaterialsBS.Position, current_OrderId, FixedAssetsMaterialsTable);
            }
            else
            {

                correctionFm = new correctionAddEditFm(false, fixedAssetsMaterialsBS.Position, current_OrderId, FixedAssetsMaterialsTable);
            }
            
            if (correctionFm.ShowDialog() == DialogResult.OK)
            {
                fixedAssetsMaterialsGrid.Focus();
                //CalculateAmortization(_datePeriodStart, _datePeriodEnd);
            }
        }

        public int Return()
        {
            return _order_Id;
        }

        #endregion
                                  
    }
}
