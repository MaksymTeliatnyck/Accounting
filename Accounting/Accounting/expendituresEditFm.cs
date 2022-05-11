using System;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using FirebirdSql.Data.FirebirdClient;
using System.Collections.Generic;
using System.Globalization;
using DevExpress.XtraPrinting;

namespace Accounting
{
    public partial class expendituresEditFm : Form
    {
        private BindingSource expendBS = new BindingSource();
        private string StartDate, EndDate;
        private DataTable expendDT;

        private class Months
        {
            public int Id { get; set; }
            public string Description { get; set; }
        };

        public expendituresEditFm()
        {
            InitializeComponent();

            this.Width = 95 * Program.MainFm.MainFmWidth / 100;
            this.Height = 95 * Program.MainFm.MainFmHeight / 100;
            
            expendBS.DataSource = DataModule.AccountingDS.Tables["Expenditures"];
            expendGrid.DataSource = expendBS;

            yearCBox.SelectedValueChanged -= dateCBox_SelectedValueChanged;
            yearCBox.SelectedValueChanged -= dateCBox_SelectedValueChanged;
            yearEndCBox.SelectedValueChanged -= dateCBox_SelectedValueChanged;
            monthEndCBox.SelectedValueChanged -= dateCBox_SelectedValueChanged;

            yearCBox.DataSource = DataModule.ExecuteFill
            (
                @"SELECT DISTINCT
                    EXTRACT(YEAR FROM Orders.Order_Date) AS ""Year""
                FROM
                    Orders
                WHERE
                    (Orders.""Flag1"" = 1 OR Orders.""Flag2"" = 1)"
            );
            
            yearEndCBox.DataSource = ((DataTable)yearCBox.DataSource).Copy();

            yearCBox.DisplayMember = "Year";
            yearEndCBox.DisplayMember = "Year";

            var monthSource = GetMonthList();

            monthCBox.DataSource = monthSource;
            monthCBox.DisplayMember = "Description";
            monthCBox.ValueMember = "Id";

            monthEndCBox.BindingContext = new BindingContext();
            monthEndCBox.DataSource = monthSource;
            monthEndCBox.DisplayMember = "Description";
            monthEndCBox.ValueMember = "Id";

            monthCBox.SelectedValue = Convert.ToDateTime(Properties.Settings.Default.ExpDate).Month;
            monthEndCBox.SelectedValue = monthCBox.SelectedValue;

            //yearCBox.Text = Convert.ToDateTime(Properties.Settings.Default.ExpDate).Year.ToString();

            yearCBox.Text = "2020";
            yearEndCBox.Text = yearCBox.Text;


            
            yearCBox.SelectedValueChanged += dateCBox_SelectedValueChanged;
            monthCBox.SelectedValueChanged += dateCBox_SelectedValueChanged;
            yearEndCBox.SelectedValueChanged += dateCBox_SelectedValueChanged;
            monthEndCBox.SelectedValueChanged += dateCBox_SelectedValueChanged;
                        
            ShowExpenditures();
        }

        private List<Months> GetMonthList()
        {
            CultureInfo ci = new CultureInfo("uk-UA");
            DateTimeFormatInfo dtfi = ci.DateTimeFormat;
            
            List<Months> items = new List<Months>();
            
            for (int i = 1; i <= 12; i++)
                items.Add(new Months() { Id = i, Description = i.ToString().PadLeft(2, '0') + " " + dtfi.MonthNames[i - 1] });
            return items;
        }
        
        private void dateCBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowExpenditures();
        }
                
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DataModule.AccountingDS.Tables["Expenditures"].RejectChanges();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DeleteExpenditureRecord();               
        }

        private void ShowExpenditures()
        {
            StartDate = "01." + (monthCBox.SelectedIndex + 1) + "." + yearCBox.Text;
            
            EndDate = DateTime.DaysInMonth(int.Parse(yearEndCBox.Text), monthEndCBox.SelectedIndex + 1) + "." + (monthEndCBox.SelectedIndex + 1) + "." + yearEndCBox.Text;

            DataModule.AccountingDS.Tables["Expenditures"].Rows.Clear();
            DataModule.DataAdapter["Expenditures"].SelectCommand.Parameters["StartDate"].Value = StartDate;
            DataModule.DataAdapter["Expenditures"].SelectCommand.Parameters["EndDate"].Value = EndDate;

            DataModule.DataAdapter["Expenditures"].Fill(DataModule.AccountingDS.Tables["Expenditures"]);

            ShowPeriod();

            expendView.BeginSummaryUpdate();
            expendView.EndSummaryUpdate();
        }
                
        private void reportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                expendGrid.ExportToXls(Utils.HomePath + @"\Reports\Gen\Списання матеріалів.xls");
                Process process = new Process();
                process.StartInfo.Arguments = "\"" + Utils.HomePath + @"\Reports\Gen\Списання матеріалів.xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже існує!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void closeMonthChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (closeMonthChBox.Checked)
            {
                if (MessageBox.Show("Закрити період \"" + monthCBox.Text + " " + yearCBox.Text + "\" ?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetPeriodOpened(true);
                }
            }
            else
            {
                if (MessageBox.Show("Відкрити період \"" + monthCBox.Text + " " + yearCBox.Text + "\" ?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetPeriodOpened(false);
                }
            }
        }

        private bool _checkState;
        private bool _show;
        private void SetPeriodOpened(bool checkState, bool show = false)
        {
            _show = show;
            _checkState = checkState;

            if (!_show)
            {
                FbParameter[] Parameters =
                {
                    new FbParameter("Month", (monthCBox.SelectedIndex + 1)),
                    new FbParameter("Year", yearCBox.Text),
                    new FbParameter("State", (_checkState) ? 0 : 1)
                };

                DataModule.Connection.Open();
                DataModule.ExecuteNonQuery(
                    @"UPDATE ""Periods"" SET ""State"" = @State WHERE ""Month"" = @Month AND ""Year"" = @Year", Parameters);
                DataModule.Connection.Close();
            }

            closeMonthChBox.CheckedChanged -= closeMonthChBox_CheckedChanged;
            closeMonthChBox.Checked = _checkState;
            closeMonthChBox.CheckedChanged += closeMonthChBox_CheckedChanged;

            editBtn.Enabled = !_checkState;
            deleteBtn.Enabled = !_checkState;

        }

        /// <summary>
        ///проверяет закрытие периода при инициализации
        /// </summary>
        private void ShowPeriod()
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("Month", (monthCBox.SelectedIndex + 1)),
                    new FbParameter("Year", yearCBox.Text)
                };
            DataModule.Connection.Open();
            short? State = (short?)DataModule.ExecuteScalar(@"SELECT ""State"" FROM ""Periods"" WHERE ""Month"" = @Month AND ""Year"" = @Year", Parameters);
            DataModule.Connection.Close();

            SetPeriodOpened(((State == 1) || (State == null)) ? false : true, true);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (expendBS.Count > 0)
            {
                expendituresSingleEditFm expendituresEditFm;

                DataRowView selectRow = (DataRowView)expendBS.Current;
                int currentId = (int)(selectRow["ID"]);

                expendituresEditFm = new expendituresSingleEditFm(expendBS.Position);

                if (expendituresEditFm.ShowDialog() == DialogResult.OK)
                {
                    ShowExpenditures();

                    int currentRowHandle = expendView.LocateByValue("Id", currentId);
                    expendView.FocusedRowHandle = currentRowHandle;
                }
            }
        }

        private void OpenExpenditureSingleEdit()
        {
            if (expendBS.Count > 0)
            {
                expendituresSingleEditFm expendituresEditFm;

                DataRowView selectRow = (DataRowView)expendBS.Current;
                int currentId = (int)(selectRow["ID"]);

                expendituresEditFm = new expendituresSingleEditFm(expendBS.Position);

                if (expendituresEditFm.ShowDialog() == DialogResult.OK)
                {
                    ShowExpenditures();

                    int currentRowHandle = expendView.LocateByValue("Id", currentId);
                    expendView.FocusedRowHandle = currentRowHandle;
                }
            }        
        }

        private void DeleteExpenditureRecord()
        {
            if (expendView.DataRowCount == 0)
                return;
            if (MessageBox.Show("Видалити списання?", "Підтверждення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTime operationDate = Convert.ToDateTime(((DataRowView)expendBS.Current)["Exp_Date"]);
                if (Periods.CheckPeriodState(operationDate.Year, operationDate.Month) != true)
                {
                    MessageBox.Show("Період закритий або не існує!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    #region Find and delete expenditure from "FixedAssets" and "InvoiceRequirement"

                    int idRow = Convert.ToInt32(((DataRowView)expendBS.Current)["ID"]);
                    DataModule.Connection.Open();
                    int countInFixedAssetsMaterials = (int)DataModule.ExecuteScalar("SELECT COUNT(\"Id\") FROM \"FixedAssetsMaterials\" WHERE \"Expenditures_Id\" = " + idRow);
                    int countInInvoice_Requirement_Materials = (int)DataModule.ExecuteScalar("SELECT COUNT(\"Id\") FROM \"Invoice_Requirement_Materials\" WHERE \"Expenditures_Id\" =" + idRow);
                    DataModule.Connection.Close();

                    var isFixedAssetsMaterialsFound = (countInFixedAssetsMaterials != 0);
                    var isInvoice_Requirement_MaterialsFound = (countInInvoice_Requirement_Materials != 0);

                    if (isFixedAssetsMaterialsFound)
                    {
                        MessageBox.Show("Видалення відмінено! \nМатеріал знаходиться на обліку в основних засобах. Спочатку треба видалити матеріал з облікової карточки основного засобу.", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (isInvoice_Requirement_MaterialsFound)
                    {
                        if (MessageBox.Show("Увага! \nМатеріал знаходиться у вимогах. Бажаєте зберегти зміни?", "Збереження", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            try
                            {
                                DataModule.Connection.Open();
                                DataModule.BeginTransaction();

                                DataModule.ExecuteNonQuery("UPDATE \"Invoice_Requirement_Materials\" SET \"Expenditures_Id\" = null, \"Credit_Account_Id\" = null WHERE \"Expenditures_Id\" =" + idRow);

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
                                MessageBox.Show(DataModule.GetError(FbEcpt), "Помилка при збереженні. Дію відмінено.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                return;
                            }
                            finally
                            {
                                Cursor = Cursors.Default;
                                DataModule.Connection.Close();
                            }
                        }
                        else
                            return;
                    }

                #endregion

                    expendBS.RemoveCurrent();
                    expendBS.EndEdit();

                    try
                    {
                        DataModule.Connection.Open();
                        DataModule.BeginTransaction();
                        DataModule.DataAdapter["Expenditures"].DeleteCommand.Transaction = DataModule.Transaction;

                        DataModule.DataAdapter["Expenditures"].Update(DataModule.AccountingDS.Tables["Expenditures"]);

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
                        MessageBox.Show(DataModule.GetError(FbEcpt), "Помилка при збереженні. Дію відмінено.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        DataModule.Connection.Close();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка при роботі з базою даних", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }                    
        }

        private void expendView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && expendBS.Count > 0)
                DeleteExpenditureRecord();
        }

        private void expendView_DoubleClick(object sender, EventArgs e)
        {
            if(expendBS.Count > 0)
                OpenExpenditureSingleEdit();
        }
    }
}
