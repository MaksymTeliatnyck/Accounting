using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace Accounting
{
    public partial class fixedAssetsOrderFm : Form
    {
        private BindingSource fixedAssetsOrderBS = new BindingSource();
        private BindingSource fixedAssetsArchiveBS = new BindingSource();

        const short TRANSFER = 1;
        const short SOLD = 2;
        const short PARTIAL_SOLD = 3;

        public fixedAssetsOrderFm()
        {
            InitializeComponent();
            
            #region TabOrders initialize components

            yearEndCBox.SelectedIndexChanged -= dateCBox_SelectedIndexChanged;
            monthEndCBox.SelectedIndexChanged -= dateCBox_SelectedIndexChanged;

            yearEndCBox.Text = DateTime.Today.Year.ToString(); ;
            monthEndCBox.SelectedIndex = DateTime.Today.Month - 1;

            yearEndCBox.SelectedIndexChanged += dateCBox_SelectedIndexChanged;
            monthEndCBox.SelectedIndexChanged += dateCBox_SelectedIndexChanged;

            #endregion

            #region TabArchive initialize components

            yearBeginArchiveCBox.SelectedIndexChanged -= dateArchiveCBox_SelectedIndexChanged;
            monthBeginArchiveCBox.SelectedIndexChanged -= dateArchiveCBox_SelectedIndexChanged;
            yearEndArchiveCBox.SelectedIndexChanged -= dateArchiveCBox_SelectedIndexChanged;
            monthEndArchiveCBox.SelectedIndexChanged -= dateArchiveCBox_SelectedIndexChanged;

            yearBeginArchiveCBox.Text = DateTime.Today.Year.ToString();
            monthBeginArchiveCBox.SelectedIndex = DateTime.Today.Month - 1;
            yearEndArchiveCBox.Text = yearBeginArchiveCBox.Text;
            monthEndArchiveCBox.Text = monthBeginArchiveCBox.Text;

            yearBeginArchiveCBox.SelectedIndexChanged += dateArchiveCBox_SelectedIndexChanged;
            monthBeginArchiveCBox.SelectedIndexChanged += dateArchiveCBox_SelectedIndexChanged;
            yearEndArchiveCBox.SelectedIndexChanged += dateArchiveCBox_SelectedIndexChanged;
            monthEndArchiveCBox.SelectedIndexChanged += dateArchiveCBox_SelectedIndexChanged;

            #endregion
            
            fixedAssetsOrderBS.DataSource = DataModule.AccountingDS.Tables["FixedAssetsOrder"];
            fixedAssetsOrderGrid.DataSource = fixedAssetsOrderBS;

            fixedAssetsMaterialsGrid.DataSource = DataModule.AccountingDS.Tables["FixedAssetsMaterials"];

            fixedAssetsArchiveBS.DataSource = DataModule.AccountingDS.Tables["FixedAssetsArchive"];
            fixedAssetsArchiveGrid.DataSource = fixedAssetsArchiveBS;

            SelectDate();
            SelectArchiveDate();
        }
                                       
        #region Events

        #region Control event

        #region SelectDate

        private void dateCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int current_OrderId = (fixedAssetsOrderBS.Count > 0) ? (int)((DataRowView)fixedAssetsOrderBS.Current)["Id"] : -1;
                        
            SelectDate();
            
            int currentRowHandle = fixedAssetsOrderGridView.LocateByValue("Id", current_OrderId);
            fixedAssetsOrderGridView.FocusedRowHandle = currentRowHandle;
            
            fixedAssetsOrderGrid.Focus();
            SelectMaterials();
        }

        private void dateArchiveCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).Name)
            {
                case "yearArchiveCBox":
                    yearEndArchiveCBox.Text = yearBeginArchiveCBox.Text;
                    break;
                case "monthArchiveCBox":
                    monthEndArchiveCBox.Text = monthBeginArchiveCBox.Text;
                    break;
            }

            int current_OrderId = (fixedAssetsArchiveBS.Count > 0) ? (int)((DataRowView)fixedAssetsArchiveBS.Current)["Id"] : -1;

            SelectArchiveDate();

            int currentRowHandle = fixedAssetsArchiveGridView.LocateByValue("Id", current_OrderId);
            fixedAssetsArchiveGridView.FocusedRowHandle = currentRowHandle;
            fixedAssetsArchiveGrid.Focus();
        }

        #endregion

        private void fixedAssetsOrderGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                DataModule.AccountingDS.Tables["FixedAssetsMaterials"].Rows.Clear();
            else
                SelectMaterials();
        }

        private void fixedAssetsMaterialsGridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == flagNoteColumn && e.IsGetData)
            {
                short flagNote = (short)fixedAssetsMaterialsGridView.GetRowCellValue(e.ListSourceRowIndex, "Flag");
                e.Value = materialsGridImageCollection.Images[flagNote];
            }
        }

        private void transferCardCBox_CheckedChanged(object sender, EventArgs e)
        {
            SetOrderFmSettings(transferCardCBox.Checked);
        }

        private void selectCardCBox_CheckedChanged(object sender, EventArgs e)
        {
            SetArhiveFmSettings(selectCardCBox.Checked);
        }

        private void fixedAssetsArchiveGridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Column.Name == "OperationNameColumn")
            {
                short cellValue = (short)fixedAssetsArchiveGridView.GetRowCellValue(e.RowHandle, OperationStatusColumn);

                switch (cellValue)
                {
                    case TRANSFER:
                        e.Appearance.BackColor = Color.DeepSkyBlue;
                        e.Appearance.BackColor2 = Color.LightCyan;
                        break;
                    case SOLD:
                        e.Appearance.BackColor = Color.LightGreen;
                        e.Appearance.BackColor2 = Color.WhiteSmoke;
                        break;
                    case PARTIAL_SOLD:
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.BackColor2 = Color.LightYellow;
                        break;
                    default:
                        break;
                }

            }
        }

        private void fixedAssetsOrderGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2 && e.RowHandle > -1)
                OpenFixedAssetsCardFm(false);
        }

        #region Resize

        private void panelBody2_Resize(object sender, EventArgs e)
        {
            panelBody2.Top = panelBody1.Top + panelBody1.Height;
        }


        Boolean mouseDownStatus = false;
        int mouseMoveValue = 0;
        private void splitter1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMoveValue = 0;
            mouseDownStatus = true;
        }

        private void splitter1_MouseUp(object sender, MouseEventArgs e)
        {
            Boolean isEditMoveValue = false;
            mouseDownStatus = false;
            int topValue = (panelBody2.Top + mouseMoveValue);
            int heightValue = panelBody2.Height - mouseMoveValue;

            if (topValue < 250)
            {
                mouseMoveValue += (250 - topValue);
                isEditMoveValue = true;
            }
            else
            {
                if (heightValue < 125)
                {
                    mouseMoveValue -= (125 - heightValue);
                    isEditMoveValue = true;
                }
            }

            if (isEditMoveValue)
            {
                topValue = (panelBody2.Top + mouseMoveValue);
                heightValue = panelBody2.Height - mouseMoveValue;
            }

            panelBody2.Height = heightValue;
            panelBody2.Top = topValue;
            panelBody1.Height += mouseMoveValue;
        }

        private void splitter1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownStatus)
            {
                mouseMoveValue = e.Y;

            }
        }
        #endregion Resize

        #endregion

        #region Context menu event's

        private void transferSelectCMenu_Opened(object sender, EventArgs e)
        {
            transferCheckAllGroup.Enabled = (fixedAssetsOrderBS.Count > 0 && transferCardCBox.Checked);
        }
        
        private void transferCheckAllGroup_Click(object sender, EventArgs e)
        {
            var selectGroupId = ((DataRowView)fixedAssetsOrderBS.Current)["Group_Id"];

            var query = (DataModule.AccountingDS.Tables["FixedAssetsOrder"]).Select(string.Format("[Group_Id] = '{0}'", selectGroupId))
                    .ToList<DataRow>();
            (DataModule.AccountingDS.Tables["FixedAssetsOrder"]).Select(string.Format("[Group_Id] = '{0}'", selectGroupId))
                    .ToList<DataRow>()
                    .ForEach(s => s["SelectedCard"] = 1);
        }

        #endregion

        #region Button's click event

        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenFixedAssetsCardFm(true);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (fixedAssetsOrderBS.Count != 0)
            {
                OpenFixedAssetsCardFm(false);
            }
        }
        
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (fixedAssetsOrderBS.Count != 0 && MessageBox.Show("Відалити картку основного засобу?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int Pos = fixedAssetsOrderGridView.FocusedRowHandle;
 
                try
                {
                    fixedAssetsOrderBS.RemoveCurrent();
                    DataModule.DataAdapter["FixedAssetsOrder"].Update(DataModule.AccountingDS.Tables["FixedAssetsOrder"]);
                    SelectMaterials();
                    fixedAssetsOrderGridView.FocusedRowHandle = Pos - 1;
                }
                catch (FbException Excpt)
                {
                    DataModule.AccountingDS.Tables["FixedAssetsOrder"].RejectChanges();
                    fixedAssetsOrderGridView.FocusedRowHandle = Pos;
                    MessageBox.Show(DataModule.GetError(Excpt), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void materialsBtn_Click(object sender, EventArgs e)
        {
            materialsFixedAssetsFm materialsFm = new materialsFixedAssetsFm(dateStart, dateEnd);
            materialsFm.MdiParent = Program.MainFm;
            materialsFm.Show();
        }

        private void actBtn_Click(object sender, EventArgs e)
        {
            Reports Report;
            Report = new Reports();
            DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;

            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("Id", ((DataRowView)fixedAssetsOrderBS.Current)["Id"])
                };

            if (DataModule.AccountingDS.Tables["FixedAssetsMaterials"].Rows.Count > 0)
            {
                short group = (short)((DataRowView)fixedAssetsOrderBS.Current)["Group_Id"];

                switch (group)
                {
                    case 10:
                    case 2:
                        Report.FixedAssetsOrderActForSoftWare((DataRowView)fixedAssetsOrderBS.Current);
                        break;
                    default:
                        Report.FixedAssetsOrderAct((DataRowView)fixedAssetsOrderBS.Current);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Виберіть картку основного засобу", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor = Cursors.Default;
        }
        private void actWriteOffBtn_Click(object sender, EventArgs e)
        {
            Reports Report;
            Report = new Reports();
            DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;

            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("Id", ((DataRowView)fixedAssetsOrderBS.Current)["Id"])
                };

            if (DataModule.AccountingDS.Tables["FixedAssetsMaterials"].Rows.Count > 0)
            {
                decimal currentPrice = (decimal)((DataRowView)fixedAssetsOrderBS.Current)["CURRENTPRICE"];

                if (currentPrice == 0)
                {
                    MessageBox.Show("Залишкова вартість обраної картки не дорівнює нулю", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                short group = (short)((DataRowView)fixedAssetsOrderBS.Current)["Group_Id"];

                switch (group)
                {
                    case 10:
                    case 2:
                        Report.FixedAssetsOrderActWriteOff((DataRowView)fixedAssetsOrderBS.Current, Utils.FixedAssetsGroup.SoftWare);
                        //Report.FixedAssetsOrderActForSoftWare((DataRowView)fixedAssetsOrderBS.Current);
                        break;
                    default:
                        Report.FixedAssetsOrderActWriteOff((DataRowView)fixedAssetsOrderBS.Current, Utils.FixedAssetsGroup.General);
                        //Report.FixedAssetsOrderAct((DataRowView)fixedAssetsOrderBS.Current);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Виберіть картку основного засобу", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor = Cursors.Default;

        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Reports report = new Reports();

            string beginDateForReport = "01." + (monthEndCBox.SelectedIndex + 1) + "." + yearEndCBox.Text;
            string endDateForReport = DateTime.DaysInMonth(int.Parse(yearEndCBox.Text), monthEndCBox.SelectedIndex + 1) + "." + (monthEndCBox.SelectedIndex + 1) + "." + yearEndCBox.Text;

            FbParameter[] QueryParameter = { new FbParameter("Id", ((DataRowView)fixedAssetsOrderBS.Current)["Id"]) };
            DataModule.Connection.Open();
            var query = DataModule.ExecuteScalarProc("FIXEDASSETSORDER_ROOT_BY_ID", QueryParameter[0]);
            DataModule.Connection.Close();
           
            FbParameter[] Parameters =
            {
               new FbParameter("BeginDate", dateStart),
               new FbParameter("EndDate", dateEnd)
             };

            report.FixedAssetsPrintItem(DataModule.ExecuteFill(DataModule.Queries["FixedAssetsOrderPrintHistory"] + " AND  \"FixedAssetsOrder\".\"Id\"  in (" + query.ToString() + ")", Parameters), Convert.ToDateTime(beginDateForReport), Convert.ToDateTime(endDateForReport));
              
            Cursor = Cursors.Default;
        }

        private void transferFixedAssetsBtn_Click(object sender, EventArgs e)
        {
            if (fixedAssetsMaterialsGridView.DataRowCount > 0)
            {
                int rowCount = (DataModule.AccountingDS.Tables["FixedAssetsOrder"]).AsEnumerable().Where(s => (string)s["SelectedCard"] == "1").Count();
                bool manyCardSelected = (rowCount > 1);
            
                OpenTransferFm(manyCardSelected);
            }
            else
            {
                MessageBox.Show("Не відмічена картка ОЗ для переміщення.", "Переміщення картки ОЗ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteFromArchiveBtn_Click(object sender, EventArgs e)
        {
            var query = (DataModule.AccountingDS.Tables["FixedAssetsArchive"]).AsEnumerable()
                            .Where(r => (string)r["SelectedCard"] == "1");
                    
            if (query.Count<DataRow>() > 0)
            {
                if (MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteCardFromArchive(query.CopyToDataTable());
                    SelectArchiveDate();
                    SelectDate();
                }
            }
            else
            {
                MessageBox.Show("Не відмічена картка для відалення", "Видалення з архіву", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void soldFixedAssetsBtn_Click(object sender, EventArgs e)
        {
            if (fixedAssetsMaterialsGridView.DataRowCount > 0)
            {
                SoldFixedCard();
            }
            else
            {
                MessageBox.Show("Не відмічена катрка ОЗ для продажу.", "Продаж ОЗ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            string dateArchiveStart = "01." + (monthBeginArchiveCBox.SelectedIndex + 1) + "." + yearBeginArchiveCBox.Text;
            string dateArchiveEnd = DateTime.DaysInMonth(int.Parse(yearEndArchiveCBox.Text), monthEndArchiveCBox.SelectedIndex + 1) + "." + (monthEndArchiveCBox.SelectedIndex + 1) + "." + yearEndArchiveCBox.Text;

            string exportFilePath = "ОЗ_Архів_" + dateArchiveStart + "-" + dateArchiveEnd + ".xls";
            try
            {
                fixedAssetsArchiveGridView.ExportToXls(exportFilePath);
            }
            catch (Exception)
            {
                MessageBox.Show("Збереження файлу неможливе, документ вже відкритий! \n Закрийте документ і спробуйте ще.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (File.Exists(exportFilePath))
            {
                try
                {
                    //Try to open the file and let windows decide how to open it.
                    System.Diagnostics.Process.Start(exportFilePath);
                }
                catch
                {
                    String msg = "Неможливо відкрити файл." + Environment.NewLine + Environment.NewLine + "Путь: " + exportFilePath;
                    MessageBox.Show(msg, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void printInventoryCardBtn_Click(object sender, EventArgs e)
        {
            Reports Report;
            Report = new Reports();
            DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;

            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("Id", ((DataRowView)fixedAssetsOrderBS.Current)["Id"])
                };

            if ((short)((DataRowView)fixedAssetsOrderBS.Current)["Group_Id"] == 10)
                Report.InventoryCardPrintForSoftware((DataRowView)fixedAssetsOrderBS.Current);
            else
                MessageBox.Show(String.Format("Картка №{0} не є об'єктом права інтелектуальної власності.\nФункція доступна для групи: {1}",
                    ((DataRowView)fixedAssetsOrderBS.Current)["InventoryNumber"], "\"Авторське право та суміжні з ним права\""), "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Cursor = Cursors.Default;
        }


        #endregion

        #endregion

        #region Method's

        private bool _inserting;
        private void OpenFixedAssetsCardFm(bool inserting)
        {
            _inserting = inserting;
            
            fixedAssetsCardFm fixedAssetsEditFm;

            int current_OrderId = (int)((DataRowView)fixedAssetsOrderBS.Current)["Id"];

            fixedAssetsEditFm = new fixedAssetsCardFm(_inserting, fixedAssetsOrderBS.Position, current_OrderId, dateStart, dateEnd);

            if (fixedAssetsEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int return_OrderId = fixedAssetsEditFm.Return();

                SelectDate();

                int currentRowHandle = fixedAssetsOrderGridView.LocateByValue("Id", ((return_OrderId < 0) ? current_OrderId : return_OrderId));
                fixedAssetsOrderGridView.FocusedRowHandle = currentRowHandle;
            }

            fixedAssetsOrderGrid.Focus();
        }

        private void SelectMaterials()
        {
            if (fixedAssetsOrderBS.Count != 0)
            {
                DataModule.AccountingDS.Tables["FixedAssetsMaterials"].Rows.Clear();
                DataModule.DataAdapter["FixedAssetsMaterials"].SelectCommand.Parameters["Id"].Value = ((DataRowView)fixedAssetsOrderBS.Current)["Id"];
                DataModule.DataAdapter["FixedAssetsMaterials"].SelectCommand.Parameters["EndDate"].Value = dateEnd;
                DataModule.DataAdapter["FixedAssetsMaterials"].Fill(DataModule.AccountingDS.Tables["FixedAssetsMaterials"]);
            }
        }

        private string dateStart, dateEnd;
        private void SelectDate()
        {
            dateStart = "01." + (monthEndCBox.SelectedIndex) + "." + yearEndCBox.Text;
            //dateStart = Convert.ToDateTime(dateStart).AddMonths(-1).ToString();
            dateEnd = DateTime.DaysInMonth(int.Parse(yearEndCBox.Text), monthEndCBox.SelectedIndex + 1) + "." + (monthEndCBox.SelectedIndex + 1) + "." + yearEndCBox.Text;

            DataModule.AccountingDS.Tables["FixedAssetsOrder"].Rows.Clear();
            DataModule.AccountingDS.Tables["FixedAssetsMaterials"].Rows.Clear();
            DataModule.DataAdapter["FixedAssetsOrder"].SelectCommand.Parameters["BeginDate"].Value = dateStart;
            DataModule.DataAdapter["FixedAssetsOrder"].SelectCommand.Parameters["EndDate"].Value = dateEnd;

            DataModule.DataAdapter["FixedAssetsOrder"].Fill(DataModule.AccountingDS.Tables["FixedAssetsOrder"]);

            GroupColumn.Group();
            fixedAssetsOrderGrid.Focus();
            fixedAssetsOrderGridView.BeginSummaryUpdate();
            fixedAssetsOrderGridView.EndSummaryUpdate();
        }

        private void SelectArchiveDate()
        {
            dateStart = "01." + (monthBeginArchiveCBox.SelectedIndex + 1) + "." + yearBeginArchiveCBox.Text;
            dateEnd = DateTime.DaysInMonth(int.Parse(yearEndArchiveCBox.Text), monthEndArchiveCBox.SelectedIndex + 1) + "." + (monthEndArchiveCBox.SelectedIndex + 1) + "." + yearEndArchiveCBox.Text;

            DataModule.AccountingDS.Tables["FixedAssetsArchive"].Rows.Clear();
            DataModule.DataAdapter["FixedAssetsArchive"].SelectCommand.Parameters["BeginDate"].Value = dateStart;
            DataModule.DataAdapter["FixedAssetsArchive"].SelectCommand.Parameters["EndDate"].Value = dateEnd;
            DataModule.DataAdapter["FixedAssetsArchive"].Fill(DataModule.AccountingDS.Tables["FixedAssetsArchive"]);

            ArchiveGroupColumn.Group();
            fixedAssetsArchiveGrid.Focus();
            fixedAssetsArchiveGridView.BeginSummaryUpdate(); fixedAssetsArchiveGridView.EndSummaryUpdate();
        }

        private bool _markedCard;
        private void SetOrderFmSettings(bool markedCard) 
        {
            _markedCard = markedCard;
               
            TransferCardCboxColumn.Visible = _markedCard;
            TransferCardCboxColumn.VisibleIndex = (_markedCard) ? 0 : -1;
            transferCardCBox.Text = (_markedCard) ? "відмінити" : "відмитити записи";
            DeleteAllMarks(!_markedCard, true);
        }

        private bool _markedArchiveCard;
        private void SetArhiveFmSettings(bool markedCard)
        {
            _markedArchiveCard = markedCard;

            ArchiveCardSelectColumn.Visible = _markedArchiveCard;
            ArchiveCardSelectColumn.VisibleIndex = (_markedArchiveCard) ? 0 : -1;
            selectCardCBox.Text = (_markedArchiveCard) ? "відмінити" : "відмитити записи";
            DeleteAllMarks(!_markedArchiveCard, false);
        }

        private bool _deletingMark, _isOrderTable;
        private void DeleteAllMarks(bool deletingMark, bool isOrderTable)
        {
            _deletingMark = deletingMark;
            _isOrderTable = isOrderTable;

            DataTable currentTable = (isOrderTable) ? (DataModule.AccountingDS.Tables["FixedAssetsOrder"]) : (DataModule.AccountingDS.Tables["FixedAssetsArchive"]);

            if (_deletingMark)
            {
                currentTable.AsEnumerable()
                    .ToList<DataRow>()
                    .ForEach(s => s["SelectedCard"] = "0");
            }
        }

        private bool _manyCardSelected;
        private void OpenTransferFm(bool manyCardSelected)
        {
            Form formTransfer = null;
            _manyCardSelected = manyCardSelected;
            
            int currentRowHandle = fixedAssetsOrderGridView.FocusedRowHandle;

            if (_manyCardSelected)
            {
                DataTable rowsForTranfer = (DataModule.AccountingDS.Tables["FixedAssetsOrder"]).AsEnumerable()
                    .Where(r => (string)r["SelectedCard"] == "1")
                    .CopyToDataTable();
                
                formTransfer = new fixedAssetsManyTransferFm(rowsForTranfer);
            }
            else
            {
                formTransfer = new fixedAssetTransferFm(fixedAssetsOrderBS.Position);
            }
            formTransfer.ShowDialog();
            SelectDate();
            SelectArchiveDate();
            fixedAssetsOrderGrid.Focus();
            fixedAssetsOrderGridView.FocusedRowHandle = currentRowHandle;
            
        }

        private DataTable _rowsForDelete;
        private void DeleteCardFromArchive(DataTable rowsForDelete)
        {
            DataTable localFixedAssetsMaterials;

            Cursor = Cursors.WaitCursor;

            localFixedAssetsMaterials = DataModule.ExecuteFill(@"SELECT * FROM ""FixedAssetsMaterials""");
            
            _rowsForDelete = rowsForDelete;
            
            int rowCount = _rowsForDelete.Rows.Count;

            for (int i = 0; i < rowCount; i++)
            {
                int operationStatus = (short)_rowsForDelete.Rows[i]["OperationStatus"];
                int order_id = (int)_rowsForDelete.Rows[i]["Id"];
                int countOrderRow;

                switch (operationStatus)
                {
                    case TRANSFER:

                        countOrderRow = (DataModule.AccountingDS.Tables["FixedAssetsOrder"]).Rows.OfType<DataRow>()
                                        .Where(r => r.Field<int>("Id_Parent") == order_id)
                                        .Where(r => r.Field<int>("Id") != order_id)
                                        .Where(r => r.Field<string>("EndRecordDate") == null)
                                        .Count();
                        if (countOrderRow == 1)
                        {
                            (DataModule.AccountingDS.Tables["FixedAssetsOrder"]).Rows.OfType<DataRow>()
                                .Where(r => r.Field<int>("Id_Parent") == order_id)
                                .Where(r => r.Field<int>("Id") != order_id)
                                .Where(r => r.Field<string>("EndRecordDate") == null)
                                .ToList()
                                .ForEach(r => r.Delete());

                            _rowsForDelete.Rows[i]["EndRecordDate"] = DBNull.Value;
                            _rowsForDelete.Rows[i]["FixedCardStatus"] = DBNull.Value;
                        }
                        else
                        {
                            MessageBox.Show(String.Format("Картку № '{0}' неможливо відновити." +
                                                          "Для початку треба видалити всі дій, які виконувалися з нею.", (string)_rowsForDelete.Rows[i]["InventoryNumber"]),
                                                          "Відновлення картки",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case SOLD:

                        _rowsForDelete.Rows[i]["EndRecordDate"] = DBNull.Value;
                        _rowsForDelete.Rows[i]["FixedCardStatus"] = DBNull.Value;

                        localFixedAssetsMaterials.Rows.OfType<DataRow>()
                            .Where(r => r.Field<int>("FixedAssetsOrder_Id") == order_id)
                            .ToList()
                            .ForEach(r => r["SoldPrice"] = DBNull.Value);

                        break;

                    case PARTIAL_SOLD:

                        countOrderRow = (DataModule.AccountingDS.Tables["FixedAssetsOrder"]).Rows.OfType<DataRow>()
                                        .Where(r => r.Field<int>("Id_Parent") == order_id)
                                        .Where(r => r.Field<int>("Id") != order_id)
                                        .Where(r => r.Field<string>("EndRecordDate") == null)
                                        .Count();
                        if (countOrderRow == 1)
                        {
                            (DataModule.AccountingDS.Tables["FixedAssetsOrder"]).Rows.OfType<DataRow>()
                                .Where(r => r.Field<int>("Id_Parent") == order_id)
                                .Where(r => r.Field<int>("Id") != order_id)
                                .Where(r => r.Field<string>("EndRecordDate") == null)
                                .ToList()
                                .ForEach(r => r.Delete());

                            _rowsForDelete.Rows[i]["EndRecordDate"] = DBNull.Value;
                            _rowsForDelete.Rows[i]["FixedCardStatus"] = DBNull.Value;

                            localFixedAssetsMaterials.Rows.OfType<DataRow>()
                                .Where(r => r.Field<int>("FixedAssetsOrder_Id") == order_id)
                                .ToList()
                                .ForEach(r => r["SoldPrice"] = DBNull.Value);
                        }
                        else
                        {
                            MessageBox.Show(String.Format("Картку № '{0}' неможливо відновити." +
                                                          "Для початку треба видалити всі дій, які виконувалися з нею.", (string)_rowsForDelete.Rows[i]["InventoryNumber"]),
                                                          "Відновлення картки",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                }

                fixedAssetsOrderBS.EndEdit();

                DataModule.Connection.Open();
                DataModule.BeginTransaction();

                DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["FixedAssetsOrder"].DeleteCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["FixedAssetsMaterials"].DeleteCommand.Transaction = DataModule.Transaction;

                try
                {
                    DataModule.DataAdapter["FixedAssetsOrder"].Update((DataModule.AccountingDS.Tables["FixedAssetsOrder"]));
                    DataModule.DataAdapter["FixedAssetsOrder"].Update(_rowsForDelete);
                    DataModule.DataAdapter["FixedAssetsMaterials"].Update(localFixedAssetsMaterials);

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
            }
            Cursor = Cursors.Default;
            
        }
        
        private void SoldFixedCard()
        {
            int current_OrderId = (int)((DataRowView)fixedAssetsOrderBS.Current)["Id"];

            soldFixedCardFm soldFixedCardFm = new soldFixedCardFm(fixedAssetsOrderBS.Position);

            soldFixedCardFm.ShowDialog();
            
            SelectDate();

            int currentRowHandle = fixedAssetsOrderGridView.LocateByValue("Id", current_OrderId);
            fixedAssetsOrderGridView.FocusedRowHandle = currentRowHandle;

            fixedAssetsOrderGrid.Focus();
        }

        #endregion

        


    }
}