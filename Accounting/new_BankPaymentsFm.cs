using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using DevExpress.Data.Filtering;

namespace Accounting
{
    public partial class new_BankPaymentsFm : Form
    {
        private Reports Report = new Reports();
        private BindingSource bankPaymentsBS = new BindingSource();

        public new_BankPaymentsFm()
        {
            InitializeComponent();

            bankPaymentsBS.DataSource = DataModule.AccountingDS.Tables["Bank_Payments"];
            bankPaymentsGrid.DataSource = bankPaymentsBS;

            yearBeginCBox.SelectedValueChanged -= dateCBox_SelectedValueChanged;
            monthBeginCBox.SelectedValueChanged -= dateCBox_SelectedValueChanged;
            yearEndCBox.SelectedValueChanged -= dateCBox_SelectedValueChanged;
            monthEndCBox.SelectedValueChanged -= dateCBox_SelectedValueChanged;

            yearBeginCBox.Text = DateTime.Today.Year.ToString();
            monthBeginCBox.SelectedIndex = DateTime.Today.Month - 1;
            yearEndCBox.Text = yearBeginCBox.Text;
            monthEndCBox.Text = monthBeginCBox.Text;

            yearBeginCBox.SelectedValueChanged += dateCBox_SelectedValueChanged;
            monthBeginCBox.SelectedValueChanged += dateCBox_SelectedValueChanged;
            yearEndCBox.SelectedValueChanged += dateCBox_SelectedValueChanged;
            monthEndCBox.SelectedValueChanged += dateCBox_SelectedValueChanged;
            SelectDate();

            label1.BackColor = Color.PaleTurquoise;
        }

        #region Event's

        private void dateCBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectDate();
            bankPaymentsGrid.Focus();
        }

        private void bankPaymentsGridView_DoubleClick(object sender, EventArgs e)
        {
            if (bankPaymentsBS.Count != 0)
                OpenPayments(false);
        }
        
        private void bankPaymentsGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && bankPaymentsBS.Count > 0)
                DeleteCurrentPayment();

            if (e.KeyCode == Keys.Insert)
                OpenPayments(true);

            if (e.KeyCode == Keys.Enter && bankPaymentsBS.Count > 0)
                OpenPayments(false);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenPayments(true);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (bankPaymentsBS.Count > 0)
            {
                OpenPayments(false);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DeleteCurrentPayment();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            ImportPayments();
        }
        private void new_importPaymentsFm_FormClosing(object sender, FormClosingEventArgs e)
        {
            importBtn.Enabled = true;
            SelectDate();
            bankPaymentsGrid.Focus();
        }
               
        private void toExcelBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            dateStart = "01." + (monthBeginCBox.SelectedIndex + 1) + "." + yearBeginCBox.Text;
            dateEnd = DateTime.DaysInMonth(int.Parse(yearEndCBox.Text), monthEndCBox.SelectedIndex + 1) + "." + (monthEndCBox.SelectedIndex + 1) + "." + yearEndCBox.Text;

            CriteriaOperator op = bankPaymentsGridView.ActiveFilterCriteria;
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);

            DataView dv = new DataView((DataTable)bankPaymentsBS.DataSource);
            dv.RowFilter = filterString;

            Report.ExportPaymentsList(dv.ToTable(), dateStart, dateEnd);

            Cursor = Cursors.Default;

        }

        private void bankPaymentsGridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                DataRow Row = bankPaymentsGridView.GetDataRow(e.RowHandle);
                if (Row["CurrencyRatesConvertId"] != DBNull.Value)
                    e.Appearance.BackColor = Color.PaleTurquoise;
            }
        }

        private void closeMonthChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (closeMonthChBox.Checked)
            {
                if (MessageBox.Show("Закрити період \"" + monthBeginCBox.Text + " " + yearBeginCBox.Text + "\" ?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetPeriodOpened(true);
                }
            }
            else
            {
                if (MessageBox.Show("Відкрити період \"" + monthBeginCBox.Text + " " + yearBeginCBox.Text + "\" ?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetPeriodOpened(false);
                }
            }
        }

        #endregion

        #region Method's

        /// <summary>
        /// изменение отметки Закрытие периода
        /// </summary>
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
                    new FbParameter("Month", (monthBeginCBox.SelectedIndex + 1)),
                    new FbParameter("Year", yearBeginCBox.Text),
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

            addBtn.Enabled = !_checkState;
            editBtn.Enabled = !_checkState;
            deleteBtn.Enabled = !_checkState;

        }

        private void ImportPayments()
        {
            new_importBankPaymentsFm importPaymentsFm = new new_importBankPaymentsFm();
            importPaymentsFm.MdiParent = Program.MainFm;
            importPaymentsFm.FormClosing += new_importPaymentsFm_FormClosing;
            importPaymentsFm.Show();
            importBtn.Enabled = false;
            
        }

        private string dateStart, dateEnd;
        private void SelectDate()
        {
            dateStart = "01." + (monthBeginCBox.SelectedIndex + 1) + "." + yearBeginCBox.Text;
            dateEnd = DateTime.DaysInMonth(int.Parse(yearEndCBox.Text), monthEndCBox.SelectedIndex + 1) + "." + (monthEndCBox.SelectedIndex + 1) + "." + yearEndCBox.Text;

            DataModule.AccountingDS.Tables["Bank_Payments"].Rows.Clear();

            DataModule.DataAdapter["Bank_Payments"].SelectCommand.Parameters["Begin_Date"].Value = dateStart;
            DataModule.DataAdapter["Bank_Payments"].SelectCommand.Parameters["End_Date"].Value = dateEnd;

            DataModule.DataAdapter["Bank_Payments"].Fill(DataModule.AccountingDS.Tables["Bank_Payments"]);

            ShowPeriod();

            bankPaymentsGridView.BeginSummaryUpdate();
            bankPaymentsGridView.EndSummaryUpdate();
        }

        private bool _inserting;
        private void OpenPayments(bool inserting)
        {
            _inserting = inserting;

            new_BankPaymentsEditFm paymentsEditFm;

            int current_PaymentId = (bankPaymentsBS.Count != 0)
                                  ? (int)((DataRowView)bankPaymentsBS.Current)["Id"]
                                  : -1;

            paymentsEditFm = new new_BankPaymentsEditFm(_inserting, bankPaymentsBS.Position, current_PaymentId);
            
            paymentsEditFm.ShowDialog();

            int return_PaymentId = paymentsEditFm.Return();

            SelectDate();

            int currentRowHandle = bankPaymentsGridView.LocateByValue("Id", ((return_PaymentId < 0) ? current_PaymentId : return_PaymentId));
            bankPaymentsGridView.FocusedRowHandle = currentRowHandle;
            
            bankPaymentsGrid.Focus();
        }

        /// <summary>
        ///проверяет закрытие периода при инициализации
        /// </summary>
        private void ShowPeriod()
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("Month", (monthBeginCBox.SelectedIndex + 1)),
                    new FbParameter("Year", yearBeginCBox.Text)
                };
            DataModule.Connection.Open();
            short? State = (short?)DataModule.ExecuteScalar(@"SELECT ""State"" FROM ""Periods"" WHERE ""Month"" = @Month AND ""Year"" = @Year", Parameters);
            DataModule.Connection.Close();

            SetPeriodOpened(((State == 1) || (State == null)) ? false : true, true);
        }

        private void DeleteCurrentPayment()
        {
            if (bankPaymentsBS.Count != 0 && MessageBox.Show("Видалити платіж?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTime operationDate = Convert.ToDateTime(((DataRowView)bankPaymentsBS.Current)["Payment_Date"]);
                if (Periods.CheckPeriodState(operationDate.Year, operationDate.Month) != true)
                {
                    MessageBox.Show("Період закритий або не існує!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int Pos = bankPaymentsGridView.FocusedRowHandle;

                try
                {
                    bankPaymentsBS.RemoveCurrent();
                    DataModule.DataAdapter["Bank_Payments"].Update(DataModule.AccountingDS.Tables["Bank_Payments"]);
                    bankPaymentsGridView.FocusedRowHandle = Pos - 1;
                }
                catch (FbException Excpt)
                {
                    DataModule.AccountingDS.Tables["Bank_payments"].RejectChanges();
                    bankPaymentsBS.Position = Pos;
                    MessageBox.Show(DataModule.GetError(Excpt), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

      
    }
}
