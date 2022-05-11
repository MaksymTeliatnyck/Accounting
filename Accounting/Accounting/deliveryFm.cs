using DevExpress.XtraGrid.Views.Grid;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Accounting
{
    public partial class deliveryFm : Form
    {

        private BindingSource deliveryOrdersBS = new BindingSource();
        private string dateStart, dateEnd;
        private bool save = true;
        private string messageText = ""; // variable for output validating error list message


        public deliveryFm(string StartDate, string EndDate)
        {
            InitializeComponent();

            this.dateStart = StartDate;
            this.dateEnd = EndDate;

            //this.Width = 95 * Program.MainFm.MainFmWidth / 100;
            //this.Height = 95 * Program.MainFm.MainFmHeight / 100;

            //FbParameter[] Parameters =
            //{
            //    new FbParameter("Start_Date", StartDate),
            //    new FbParameter("End_Date", EndDate),
            //    new FbParameter("Flag1", flag1),
            //    new FbParameter("Flag2", flag2),
            //    new FbParameter("Flag3", flag3),
            //    new FbParameter("Flag4", flag4)
            //};


            //FbParameter[] Parameters =
            //{
            //    new FbParameter("StartDate", StartDate),
            //    new FbParameter("EndDate", EndDate)
            //};
            //deliveryGrid.DataSource = DataModule.ExecuteFill(DataModule.Queries["DeliveryOrders"], Parameters);


            LoadData();

            deliveryGrid.DataSource = deliveryOrdersBS;

            deliveryCBox.DataSource = DataModule.ExecuteFill(@"SELECT ""Id"", ""DeliveryName"" FROM ""Delivery""");
            deliveryCBox.DisplayMember = "DeliveryName";
            deliveryCBox.ValueMember = "Id";

            deliveryPaymentTypeCBox.DataSource = DataModule.ExecuteFill(@"SELECT ""Id"", ""DeliveryPaymentName"" FROM ""DeliveryPaymentType""");
            deliveryPaymentTypeCBox.DisplayMember = "DeliveryPaymentName";
            deliveryPaymentTypeCBox.ValueMember = "Id";

            deliveryCBox.DataBindings.Add("SelectedValue", deliveryOrdersBS, "DeliveryId");
            deliveryCBox.DataBindings.Add("Text", deliveryOrdersBS, "DeliveryName");

            deliveryPaymentTypeCBox.DataBindings.Add("SelectedValue", deliveryOrdersBS, "DeliveryPriceTypeId", true, DataSourceUpdateMode.OnPropertyChanged);
            deliveryPaymentTypeCBox.DataBindings.Add("Text", deliveryOrdersBS, "DeliveryPaymentName", true, DataSourceUpdateMode.OnPropertyChanged);

            ttnTBox.DataBindings.Add("Text", deliveryOrdersBS, "TTN", true, DataSourceUpdateMode.OnPropertyChanged);

            invoiceDeliveryDatePicker.DataBindings.Add("Value", deliveryOrdersBS, "OrderDate", true, DataSourceUpdateMode.OnPropertyChanged);

            orderDeliveryPriceTBox.DataBindings.Add("Text", deliveryOrdersBS, "Price", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N", Utils.NumFormat(2));

            this.Text = "ТТН за период с " + Convert.ToDateTime(StartDate).ToShortDateString().Substring(3, 7) + " по " + Convert.ToDateTime(EndDate).ToShortDateString().Substring(3, 7);
        }

        private void LoadData()
        {
            DataModule.DataAdapter["DeliveryOrders"].SelectCommand.Parameters["StartDate"].Value = dateStart;
            DataModule.DataAdapter["DeliveryOrders"].SelectCommand.Parameters["EndDate"].Value = dateEnd;
            DataModule.AccountingDS.Tables["DeliveryOrders"].Rows.Clear();

            DataModule.DataAdapter["DeliveryOrders"].Fill(DataModule.AccountingDS, "DeliveryOrders");

            deliveryOrdersBS.DataSource = DataModule.AccountingDS.Tables["DeliveryOrders"];
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("uk-UA"); 

                

                //orderDeliveryPriceColumn.For = CultureInfo.CreateSpecificCulture("en-CR");

                deliveryGridView.ExportToXls(Utils.HomePath + @"\Reports\Gen\ТТН за період з " + Convert.ToDateTime(dateStart).ToShortDateString().Substring(3, 7) + " по " + Convert.ToDateTime(dateEnd).ToShortDateString().Substring(3, 7) + ".xls");

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.Arguments = "\"" + Utils.HomePath + @"\Reports\Gen\ТТН за період з " + Convert.ToDateTime(dateStart).ToShortDateString().Substring(3, 7) + " по " + Convert.ToDateTime(dateEnd).ToShortDateString().Substring(3, 7)+".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void deliveryGridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow Row = deliveryGridView.GetDataRow(e.RowHandle);
            if (Row == null) return;

            if (Row["ReceiptCheck"].ToString() != "0")
                e.Appearance.BackColor = Color.PaleGreen;
            else
                e.Appearance.BackColor = Color.Salmon;
        }

        private void addTtnBtn_Click(object sender, EventArgs e)
        {
            DataRow Row = DataModule.AccountingDS.Tables["DeliveryOrders"].NewRow();

            save = false;

            Row["Price"] = 0;
            Row["DeliveryId"] = 77;
            Row["DeliveryName"] = "НВФ Техвагонмаш";
            Row["OrderDate"] = DateTime.Now.Date;
            Row["ReceiptCheck"] = 0;
            Row["DeliveryPriceTypeId"] = 2;
            Row["DeliveryPaymentName"] = "Безготівковий";

            //deliveryCBox.SelectedValue = 77;
            //Row["ReceiptCheck"] = 0;

            DataModule.AccountingDS.Tables["DeliveryOrders"].Rows.Add(Row);
            deliveryOrdersBS.MoveLast();
            ttnTBox.Focus();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        public DataRow Return()
        {
            return ((DataRowView)deliveryOrdersBS.Current).Row;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            #region Validation





            if (deliveryCBox.SelectedValue == null)
                messageText += "Не указан перевозчик. \n";
            if (deliveryPaymentTypeCBox.SelectedValue == null)
                messageText += "Не указан способ расчета. \n";
            if (ttnTBox.Text.Length == 0)
                messageText += "Не указан ТТН. \n";
            if (orderDeliveryPriceTBox.Text.Length == 0)
                messageText += "Не указана стоимость доставки. \n";


            if (messageText.Length != 0)
            {
                MessageBox.Show(messageText, "Не заполнено одно или несколько полей", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                messageText = "";
                return;
            }

            #endregion

            Cursor = Cursors.WaitCursor;

            DataModule.Connection.Open();
            DataModule.BeginTransaction();

            //InsertTTN();
            deliveryOrdersBS.EndEdit();

            int pos = deliveryOrdersBS.Position;
            deliveryOrdersBS.Position = -1;
            deliveryOrdersBS.Position = pos;


            DataModule.DataAdapter["DeliveryOrders"].InsertCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["DeliveryOrders"].UpdateCommand.Transaction = DataModule.Transaction;
            DataModule.DataAdapter["DeliveryOrders"].DeleteCommand.Transaction = DataModule.Transaction;

            try
            {

                DataModule.DataAdapter["DeliveryOrders"].Update(DataModule.AccountingDS.Tables["DeliveryOrders"]);
                DataModule.CommitTransaction();
                save = true;
            }
            catch (FbException FbExcpt)
            {
                if (FbExcpt.SQLSTATE == "08006")
                {
                    if (DataModule.Transaction != null)
                        DataModule.DisposeTransaction();
                }
                else
                {
                    DataModule.RollbackTransaction();
                }

                save = false;

                MessageBox.Show("При збереженні виникла помилка. Операцію відмінено.\n\n" + FbExcpt.Message, "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataModule.AccountingDS.Tables["DeliveryOrders"].RejectChanges();


                //MessageBox.Show(DataModule.GetError(FbExcpt.SQLSTATE), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                DataModule.Connection.Close();
            }
            if (save)
            {
                MessageBox.Show("Данные были сохранены!", "Подтверждение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                MessageBox.Show("Данные не были сохранены!", "Подтверждение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DataModule.AccountingDS.Tables["DeliveryOrders"].RejectChanges();

            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deliveryOrdersBS.RemoveCurrent();

            }
        }

        private void ttnTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                deliveryOrdersBS.EndEdit();
                deliveryCBox.Focus();

            }
        }

        private void deliveryCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                deliveryOrdersBS.EndEdit();
                orderDeliveryPriceTBox.Focus();

            }
        }

        private void orderDeliveryPriceTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                deliveryOrdersBS.EndEdit();
                invoiceDeliveryDatePicker.Focus();
                //this.SelectNextControl((Control)sender, true, true, true, true);

            }
        }

        private void invoiceDeliveryDatePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                deliveryOrdersBS.EndEdit();
                deliveryPaymentTypeCBox.Focus();

            }
        }

        private void deliveryPaymentTypeCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                deliveryOrdersBS.EndEdit();
                okBtn.Focus();

            }
        }

        private void deliveryGridView_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            DataRowView firstRowDataRowView = (DataRowView)view.GetRow(e.RowHandle1);
            DataRowView secondRowDataRowView = (DataRowView)view.GetRow(e.RowHandle2);

            DataRow firstRowDataRow = (DataRow)firstRowDataRowView.Row;
            DataRow secondRowDataRow = (DataRow)secondRowDataRowView.Row;

            if (e.Column.FieldName != "TTN")
            {
                e.Merge = (firstRowDataRow["Id"] == secondRowDataRow["Id"]);
                e.Handled = true;
            }
        }

        private void ttnTBox_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        private bool a, c, s, o;
        private void deliveryCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                s = false;
                if (c)
                    orderDeliveryPriceTBox.Focus();
                c = true;
            }
        }

        



        //private void printBtn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        deliveryGridView.ExportToXls(Utils.HomePath + @"\Reports\Gen\Материалы и услуги.xls");

        //        System.Diagnostics.Process process = new System.Diagnostics.Process();
        //        process.StartInfo.Arguments = "\"" + Utils.HomePath + @"\Reports\Gen\Материалы и услуги.xls" + "\"";
        //        process.StartInfo.FileName = "Excel.exe";
        //        process.Start();
        //    }
        //    catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        //    catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //    catch { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        //}
    }
    

    
}
