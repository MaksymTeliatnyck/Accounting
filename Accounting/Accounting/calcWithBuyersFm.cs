using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using DevExpress.Data.Filtering;

namespace Accounting
{
    public partial class calcWithBuyersFm : Form
    {
        private Reports Report = new Reports();
        private BindingSource calcWithBuyersBS = new BindingSource();
                
        public calcWithBuyersFm()
        {
            InitializeComponent();

            yearBeginCBox.SelectedIndexChanged -= dateCBox_SelectedIndexChanged;
            monthBeginCBox.SelectedIndexChanged -= dateCBox_SelectedIndexChanged;
            yearEndCBox.SelectedIndexChanged -= dateCBox_SelectedIndexChanged;
            monthEndCBox.SelectedIndexChanged -= dateCBox_SelectedIndexChanged;

            yearBeginCBox.Text = DateTime.Today.Year.ToString();
            monthBeginCBox.SelectedIndex = DateTime.Today.Month - 1;
            yearEndCBox.Text = yearBeginCBox.Text;
            monthEndCBox.Text = monthBeginCBox.Text;

            yearBeginCBox.SelectedIndexChanged += dateCBox_SelectedIndexChanged;
            monthBeginCBox.SelectedIndexChanged += dateCBox_SelectedIndexChanged;
            yearEndCBox.SelectedIndexChanged += dateCBox_SelectedIndexChanged;
            monthEndCBox.SelectedIndexChanged += dateCBox_SelectedIndexChanged;


            calcWithBuyersBS.DataSource = DataModule.AccountingDS.Tables["CalcWithBuyers"];
            calcGrid.DataSource = calcWithBuyersBS;

            SelectDate();

            label10.BackColor = Color.PaleTurquoise;
        }

        private void dateCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).Name)
            {
                case "yearCBox":
                    yearEndCBox.Text = yearBeginCBox.Text;
                    break;
                case "monthCBox":
                    monthEndCBox.Text = monthBeginCBox.Text;
                    break;
            }
            SelectDate();
            calcGrid.Focus();
        }

        private void calcWithBuyersFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFm.calcWithBuyersBtn.Enabled = true;
        }

        private void calcGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && calcWithBuyersBS.Count > 0)
                DeleteCalcWithBuyersRecord();

            if (e.KeyCode == Keys.Insert)
                OpenCalcWithBuyersAddEditFm(true);

            if (e.KeyCode == Keys.Enter && calcWithBuyersBS.Count > 0)
                OpenCalcWithBuyersAddEditFm(false);
        }

        private void calcGridView_DoubleClick(object sender, EventArgs e)
        {
            if (calcWithBuyersBS.Count != 0)
                OpenCalcWithBuyersAddEditFm(false);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenCalcWithBuyersAddEditFm(true);
            //SelectDate();
        }
        
        private void editBtn_Click(object sender, EventArgs e)
        {
            if (calcWithBuyersBS.Count > 0)
            {
                OpenCalcWithBuyersAddEditFm(false);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DeleteCalcWithBuyersRecord();
        }
        
        private string _dateStart, _dateEnd;
        private void SelectDate()
        {
            _dateStart = "01." + (monthBeginCBox.SelectedIndex + 1) + "." + yearBeginCBox.Text;
            _dateEnd = DateTime.DaysInMonth(int.Parse(yearEndCBox.Text), monthEndCBox.SelectedIndex + 1) + "." + (monthEndCBox.SelectedIndex + 1) + "." + yearEndCBox.Text;

            DataModule.AccountingDS.Tables["CalcWithBuyers"].Rows.Clear();
            DataModule.DataAdapter["CalcWithBuyers"].SelectCommand.Parameters["Begin_Date"].Value = _dateStart;
            DataModule.DataAdapter["CalcWithBuyers"].SelectCommand.Parameters["End_Date"].Value = _dateEnd;
            DataModule.DataAdapter["CalcWithBuyers"].Fill(DataModule.AccountingDS, "CalcWithBuyers");
           
            
            ShowPeriod();

            calcGridView.BeginSummaryUpdate();
            calcGridView.EndSummaryUpdate();
        }

        private bool _inserting;
        private void OpenCalcWithBuyersAddEditFm(bool inserting)
        {
            _inserting = inserting;

            calcWithBuyersAddEditFm calcWithBuyersAddEditFm;

            int current_OrderId = (calcWithBuyersBS.Count != 0) 
                                  ? (int)((DataRowView)calcWithBuyersBS.Current)["Id"] 
                                  : -1;

            calcWithBuyersAddEditFm = new calcWithBuyersAddEditFm(_inserting, calcWithBuyersBS.Position, current_OrderId);

            if (calcWithBuyersAddEditFm.ShowDialog() == DialogResult.OK)
            {

                int return_CalcId = calcWithBuyersAddEditFm.Return();

                SelectDate();

                int currentRowHandle = calcGridView.LocateByValue("Id", ((return_CalcId < 0) ? current_OrderId : return_CalcId));
                calcGridView.FocusedRowHandle = currentRowHandle;
            }
            
            calcGrid.Focus();
        }

        private void DeleteCalcWithBuyersRecord()
        {
            if (calcWithBuyersBS.Count != 0 && MessageBox.Show("Видалити запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTime operationDate = Convert.ToDateTime(((DataRowView)calcWithBuyersBS.Current)["DocumentDate"]);
                if (Periods.CheckPeriodState(operationDate.Year, operationDate.Month) != true)
                {
                    MessageBox.Show("Період закритий або не існує!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                int Pos = calcWithBuyersBS.Position;
                try
                {
                    var _tempCurrencyRatesId = ((DataRowView)calcWithBuyersBS.Current)["CurrencyRatesId"];
                    
                    calcWithBuyersBS.RemoveCurrent();
                    DataModule.DataAdapter["CalcWithBuyers"].Update(DataModule.AccountingDS.Tables["CalcWithBuyers"]);
                    
                    if(_tempCurrencyRatesId != DBNull.Value) 
                    {
                        FbParameter[] Parameters =
                        {
                            new FbParameter("Id", _tempCurrencyRatesId),
                        };

                        DataModule.ExecuteFill(DataModule.DataAdapter["Currency_Rates"].DeleteCommand.CommandText, Parameters);
                    }
                }
                catch (FbException Excpt)
                {
                    DataModule.AccountingDS.Tables["CalcWithBuyers"].RejectChanges();
                    calcWithBuyersBS.Position = Pos;
                    MessageBox.Show(DataModule.GetError(Excpt), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void closeMonthChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (closeMonthChBox.Checked)
            {
                if (MessageBox.Show("Закрити період \"" + monthBeginCBox.Text + " " + yearBeginCBox.Text + "\" ?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetPeriodOpened( true );
                }
            }else
            {
                if (MessageBox.Show("Відкрити період \"" + monthBeginCBox.Text + " " + yearBeginCBox.Text + "\" ?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetPeriodOpened(false);
                }
            }
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

            SetPeriodOpened(((State == 1) || (State == null)) ? false :true,true);
            }

/// <summary>
/// изменение отметки Закрытие периода
/// </summary>
        private bool _checkState;
        private bool _show;
        private void SetPeriodOpened(bool checkState, bool show = false )
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
                    @"UPDATE ""Periods"" SET ""State"" = @State WHERE ""Month"" = @Month AND ""Year"" = @Year",Parameters);
                DataModule.Connection.Close();
            }
            
            closeMonthChBox.CheckedChanged -= closeMonthChBox_CheckedChanged;
            closeMonthChBox.Checked =_checkState;
            closeMonthChBox.CheckedChanged += closeMonthChBox_CheckedChanged;

            addBtn.Enabled =!_checkState;
            editBtn.Enabled =!_checkState;
            deleteBtn.Enabled =!_checkState;
          
        }

        private void toExcelBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            _dateStart = "01." + (monthBeginCBox.SelectedIndex + 1) + "." + yearBeginCBox.Text;
            _dateEnd = DateTime.DaysInMonth(int.Parse(yearEndCBox.Text), monthEndCBox.SelectedIndex + 1) + "." + (monthEndCBox.SelectedIndex + 1) + "." + yearEndCBox.Text;

            CriteriaOperator op = calcGridView.ActiveFilterCriteria;
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);

            DataView dv = new DataView((DataTable)calcWithBuyersBS.DataSource);
            dv.RowFilter = filterString;

            Report.ExportCalcWithBuyersList(dv.ToTable(), _dateStart, _dateEnd);

            Cursor = Cursors.Default;
        }

  

      
 
   }
}
