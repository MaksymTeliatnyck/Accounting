using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace Accounting
{
    public partial class ordersFm : Form
    {
        private BindingSource ordersBS = new BindingSource();
        private bool _isCurrencyOrder;
        public static bool OkBtn;
        public static int Type;

        public Bitmap Rgb2Bitmap(string HtmlRgb)
        {Bitmap bitmap = new Bitmap(16, 16);
            Graphics graphics = Graphics.FromImage(bitmap);
            SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml(HtmlRgb));
            graphics.FillRectangle(brush, 0, 0, 16, 16);
            return bitmap;
        }

        public ordersFm(bool isCurrencyOrder) // Currency flag, true - curency order and 632 account, false - UAN order and 631, 63 accounts
        {
            InitializeComponent();

            _isCurrencyOrder = isCurrencyOrder;

            #region Visibility properties components on form

            if (_isCurrencyOrder)
            {
                checkBox3.Visible = false;
                checkBox4.Visible = false;
            }
            else
            {
                ordersGridView.Columns[4].Visible = false;
                ordersGridView.Columns[5].Visible = false;
                ordersGridView.Columns[6].Visible = false;

                materialsGridView.Columns[6].Visible = false;
                materialsGridView.Columns[7].Visible = false;

            }

            #endregion

            this.Text = (_isCurrencyOrder) ? "Приходные ордеры (валюта)" : "Приходные ордеры";

            this.Width = (int)(Program.MainFm.MainFmWidth * 0.95);
            this.Height = (int)(Program.MainFm.MainFmHeight * 0.95);

            DataTable ColorsTable = DataModule.ExecuteFill(@"SELECT * FROM ""Colors""");
            for (int i = 0; i < ColorsTable.Rows.Count; i++)
            {
                ToolStripMenuItem MenuItem = new ToolStripMenuItem()
                {
                    Text = ColorsTable.Rows[i]["Name_Rus"].ToString(),
                    Image = Rgb2Bitmap(ColorsTable.Rows[i]["Color_Code"].ToString()),
                    ToolTipText = ColorsTable.Rows[i]["Name"].ToString(),
                    Tag = ColorsTable.Rows[i]["Id"]
                };
                colorContextMenu.Items.Add(MenuItem);
            }

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

            // Bindings
            DataModule.AccountingDS.Tables["Order"].Rows.Clear();
            DataModule.AccountingDS.Tables["Receipt"].Rows.Clear();

            ordersBS.DataSource = DataModule.AccountingDS.Tables["Order"];
            
            ordersGrid.DataSource = ordersBS;
            materialsGrid.DataSource = DataModule.AccountingDS.Tables["Receipt"];

            checkBox1.Checked = Properties.Settings.Default.Flag1;
            checkBox2.Checked = Properties.Settings.Default.Flag2;
            if (!_isCurrencyOrder)
            {
                checkBox3.Checked = Properties.Settings.Default.Flag3;
                checkBox4.Checked = Properties.Settings.Default.Flag4;
            }
            else 
            {
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }

            SelectDate();
            
            string filterExpression = (_isCurrencyOrder) ? "=" : "<>";
            ordersBS.Filter = string.Format("Debit_Account_Num " + filterExpression + "'{0}'", "632");

            SelectReceipts();

            DataModule.AccountingDS.Tables["Order"].Columns["Tax_Invoice"].DefaultValue = 0;
            DataModule.AccountingDS.Tables["Order"].Columns["Transport_Invoice"].DefaultValue = 1;
            DataModule.AccountingDS.Tables["Order"].Columns["Correction"].DefaultValue = 0;
            DataModule.AccountingDS.Tables["Order"].Columns["Checked"].DefaultValue = 0;
            DataModule.AccountingDS.Tables["Order"].Columns["Color_Id"].DefaultValue = 1;

            DataModule.AccountingDS.Tables["Order"].Columns["Flag1"].DefaultValue = 0;
            DataModule.AccountingDS.Tables["Order"].Columns["Flag2"].DefaultValue = 0;
            DataModule.AccountingDS.Tables["Order"].Columns["Flag3"].DefaultValue = 0;
            DataModule.AccountingDS.Tables["Order"].Columns["Flag4"].DefaultValue = 0;

        }

        //--------------------------------------------------------------------------------------------------------
        #region Buttons

        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenReceiptOrderFm(true);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (ordersBS.Count != 0)
                OpenReceiptOrderFm(false);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (ordersBS.Count != 0 && MessageBox.Show("Удалить ордер?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTime operationDate = Convert.ToDateTime(((DataRowView)ordersBS.Current)["Order_Date"]);
                if (Periods.CheckPeriodState(operationDate.Year, operationDate.Month) != true)
                {
                    MessageBox.Show("Данный период закрыт или не добавлен!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                int Pos = ordersBS.Position;
                
                try
                {
                    ordersBS.RemoveCurrent();
                    DataModule.DataAdapter["Order"].Update(DataModule.AccountingDS.Tables["Order"]);
                    SelectReceipts();
                }
                catch (FbException Excpt)
                {
                    DataModule.AccountingDS.Tables["Order"].RejectChanges();
                    ordersBS.Position = Pos;
                    MessageBox.Show(DataModule.GetError(Excpt), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion Buttons

        //--------------------------------------------------------------------------------------------------------
        #region SelectDate

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
            ordersGrid.Focus();
            SelectReceipts();
        }

        private string dateStart, dateEnd;
        private void SelectDate()
        {
            dateStart = "01." + (monthBeginCBox.SelectedIndex + 1) + "." + yearBeginCBox.Text;
            dateEnd = DateTime.DaysInMonth(int.Parse(yearEndCBox.Text), monthEndCBox.SelectedIndex + 1) + "." + (monthEndCBox.SelectedIndex + 1) + "." + yearEndCBox.Text;

            DataModule.AccountingDS.Tables["Order"].Rows.Clear();
            DataModule.AccountingDS.Tables["Receipt"].Rows.Clear();
            DataModule.DataAdapter["Order"].SelectCommand.Parameters["Begin_Date"].Value = dateStart;
            DataModule.DataAdapter["Order"].SelectCommand.Parameters["End_Date"].Value = dateEnd;

            DataModule.DataAdapter["Order"].Fill(DataModule.AccountingDS.Tables["Order"]);

            ShowPeriod();
            
            ordersGridView.BeginSummaryUpdate(); ordersGridView.EndSummaryUpdate();
        }

                  
        #endregion SelectDate

        //--------------------------------------------------------------------------------------------------------
        #region OpenReceiptOrderFm

        private int Position;
        private bool Inserting;

        private void OpenReceiptOrderFm(bool inserting)
        {
            Inserting = inserting;

            Cursor = Cursors.WaitCursor;

            receiptOrderFm receiptOrderFm;
            if (inserting)
            {
                Position = DataModule.AccountingDS.Tables["Order"].Rows.Count;
                DataModule.AccountingDS.Tables["Receipt"].Rows.Clear();
                receiptOrderFm = new receiptOrderFm(true, '2', _isCurrencyOrder, dateStart );
            }
            else
            {
                receiptOrderFm = new receiptOrderFm(false, "", _isCurrencyOrder, null, ordersBS.Position);
            }

            receiptOrderFm.MdiParent = Program.MainFm;
            receiptOrderFm.Show();
            this.Hide();
            receiptOrderFm.FormClosed += receiptOrderFm_FormClosed;
            
            Cursor = Cursors.Default;
        }

        private void ordersGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (ordersBS.Count != 0 && e.Button == MouseButtons.Left && e.Clicks == 2 && e.RowHandle > -1 && PeriodIsOpened)
                OpenReceiptOrderFm(false);
        }

        private void ordersGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && ordersGridView.RowCount > 0 && PeriodIsOpened)
                OpenReceiptOrderFm(false);
        }

        #endregion OpenReceiptOrderFm

        private void receiptOrderFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Inserting = false;

            this.Show();
            SelectDate();
            SelectReceipts();
            ordersGrid.Focus();
        }

        private void ordersGridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow Row = ordersGridView.GetDataRow(e.RowHandle);
            if (Row == null) return;

            if (Row["Color_Name"] != DBNull.Value && Row["Color_Name"].ToString() != "White")
            {
                e.Appearance.BackColor = Color.FromName(Row["Color_Name"].ToString());
            }

            if (e.Column.Name == "orderDateColumn" || e.Column.Name == "invoiceDateColumn")
            {
                if (Row["Order_Date"].ToString().Substring(2) != Row["Invoice_Date"].ToString().Substring(2))
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }

            if (e.Column.Name == "totalPriceColumn" || e.Column.Name == "vatColumn" || e.Column.Name == "totalWithVatColumn")
            {
                if (Row["Vat"] != DBNull.Value)
                {
                    double Total_Price = Convert.ToDouble(Row["Total_Price"]);
                    if (Math.Round(Total_Price * 1.2, 2) != Convert.ToDouble(Row["Total_With_VAT"]))
                        e.Appearance.BackColor = Color.SandyBrown;
                }
            }

            if (e.Column.Name == "correctionColumn")
            {
                string cellValue = ordersGridView.GetRowCellDisplayText(e.RowHandle, e.Column);
                if (cellValue == "1")
                    e.Appearance.BackColor = Color.Orange;
            }
        }

        private void colorContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ordersBS.Count == 0 || ordersGridView.FocusedRowHandle < 0)
                e.Cancel = true;
        }

        private void colorContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ((DataRowView)ordersBS.Current)["Color_Name"] = e.ClickedItem.ToolTipText;
            ((DataRowView)ordersBS.Current)["Color_Id"] = e.ClickedItem.Tag;
            ordersBS.EndEdit();
            DataModule.DataAdapter["Order"].Update(DataModule.AccountingDS.Tables["Order"]);
        }

        private void SelectReceipts()
        {
            if (ordersBS.Count != 0 && !Inserting)
            {
                DataModule.AccountingDS.Tables["Receipt"].Rows.Clear();
                DataModule.DataAdapter["Receipt"].SelectCommand.Parameters["Order_Id"].Value = ((DataRowView)ordersBS.Current)["Id"];
                DataModule.DataAdapter["Receipt"].Fill(DataModule.AccountingDS.Tables["Receipt"]);
            }
        }

        private void ordersGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                DataModule.AccountingDS.Tables["Receipt"].Rows.Clear();
            else
                SelectReceipts();
        }

        private void materialsBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            receiptsFm receiptsFm = new receiptsFm
            (
                dateStart, dateEnd,
                DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag1"].Value, 
                DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag2"].Value,
                DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag3"].Value,
                DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag4"].Value
            );
            receiptsFm.MdiParent = Program.MainFm;
            receiptsFm.Show();
            Cursor = Cursors.Default;
        }

        private void receiptFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFm.receiptsBtn.Enabled = true;
        }

        private void checkBoxFlag_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ch = ((CheckBox)sender);
            switch (ch.Name)
            {
                case "checkBox1":
                    if (ch.Checked)
                    {
                        DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag1"].Value = 1;
                        Properties.Settings.Default.Flag1 = true;
                    }
                    else
                    {
                        DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag1"].Value = DBNull.Value;
                        Properties.Settings.Default.Flag1 = false;
                    }
                    break;
                case "checkBox2":
                    if (ch.Checked)
                    {
                        DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag2"].Value = 1;
                        Properties.Settings.Default.Flag2 = true;
                    }
                    else
                    {
                        DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag2"].Value = DBNull.Value;
                        Properties.Settings.Default.Flag2 = false;
                    }
                    break;
                case "checkBox3":
                    if (ch.Checked)
                    {
                        DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag3"].Value = 1;
                        Properties.Settings.Default.Flag3 = true;
                    }
                    else
                    {
                        DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag3"].Value = DBNull.Value;
                        Properties.Settings.Default.Flag3 = false; 
                    }
                    break;
                case "checkBox4":
                    if (ch.Checked)
                    {
                        DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag4"].Value = 1;
                        Properties.Settings.Default.Flag4 = true;
                    }
                    else
                    {
                        DataModule.DataAdapter["Order"].SelectCommand.Parameters["Flag4"].Value = DBNull.Value;
                        Properties.Settings.Default.Flag4 = false;
                    }
                    break;
            }
            if (checkBox3.Checked || checkBox4.Checked)
                balanceNumColumn.Group();
            else
                materialsGridView.GroupCount = 0;

            Properties.Settings.Default.Save();
            SelectDate();
        }

        private void printOrdersBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ordersGridView.ExportToXls(Utils.HomePath + @"\Reports\Gen\Ордеры" + ".xls");

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.Arguments = "\"" + Utils.HomePath + @"\Reports\Gen\Ордеры" + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
        
        private void closeMonthChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (closeMonthChBox.Checked)
            {
                if (MessageBox.Show("Закрыть период \"" + monthBeginCBox.Text + " " + yearBeginCBox.Text + "\" ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetPeriodOpened(true);
                }
            }
            else
            {
                if (MessageBox.Show("Открыть период \"" + monthBeginCBox.Text + " " + yearBeginCBox.Text + "\" ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetPeriodOpened(false);
                }
            }
        }
        /// <summary>
        /// изменение отметки Закрытие периода
        /// </summary>
        private bool PeriodIsOpened;
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
            
            PeriodIsOpened = !_checkState;
            addBtn.Enabled = !_checkState;
            editBtn.Enabled = !_checkState;
            deleteBtn.Enabled = !_checkState;

        }
    }


 }
