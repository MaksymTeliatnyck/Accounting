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
    public partial class customerOrdersFm : Form
    {
        private BindingSource customerOrdersBS = new BindingSource();

        public customerOrdersFm()
        {
            InitializeComponent();

            customerOrdersBS.DataSource = DataModule.AccountingDS.Tables["CustomerOrders"];
            customerOrdersGrid.DataSource = customerOrdersBS;

            SelectDate();
        }

        private void customerOrdersFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFm.calcWithBuyersBtn.Enabled = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenCustomerOrderAddEditFm(true);
            SelectDate();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (customerOrdersBS.Count > 0)
            {
                OpenCustomerOrderAddEditFm(false);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DeleteCustomerOrdersRecord();
        }
        
        private void SelectDate()
        {
            DataModule.AccountingDS.Tables["CustomerOrders"].Rows.Clear();
            DataModule.DataAdapter["CustomerOrders"].Fill(DataModule.AccountingDS, "CustomerOrders");

            customerOrdersGridView.BeginSummaryUpdate();
            customerOrdersGridView.EndSummaryUpdate();
          
        }

        private bool _inserting;
        private void OpenCustomerOrderAddEditFm(bool inserting)
        {
            _inserting = inserting;
            Cursor = Cursors.WaitCursor;

            customerOrdersAddEditFm customerOrdersAddEditFm;

            int current_OrderId = (customerOrdersBS.Count != 0)
                                  ? (int)((DataRowView)customerOrdersBS.Current)["Id"]
                                  : -1;

            customerOrdersAddEditFm = new customerOrdersAddEditFm(_inserting, customerOrdersBS.Position, current_OrderId);

            customerOrdersAddEditFm.ShowDialog();
            int return_CalcId = customerOrdersAddEditFm.Return();

            SelectDate();

            int currentRowHandle = customerOrdersGridView.LocateByValue("Id", ((return_CalcId < 0) ? current_OrderId : return_CalcId));
            customerOrdersGridView.FocusedRowHandle = currentRowHandle;

            customerOrdersGrid.Focus();

            Cursor = Cursors.Default;
        }

        private void DeleteCustomerOrdersRecord()
        {
            if (customerOrdersBS.Count != 0 && MessageBox.Show("Видалити запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int Pos = customerOrdersBS.Position;
                try
                {
                    customerOrdersBS.RemoveCurrent();
                    DataModule.DataAdapter["CustomerOrders"].Update(DataModule.AccountingDS.Tables["CustomerOrders"]);
                }
                catch (FbException Excpt)
                {
                    DataModule.AccountingDS.Tables["CustomerOrders"].RejectChanges();
                    customerOrdersBS.Position = Pos;
                    MessageBox.Show(DataModule.GetError(Excpt), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (customerOrdersBS.Count != 0)
            {
                DataRowView curCustomerOrder = (DataRowView)customerOrdersBS.Current;

                Reports report = new Reports();
                report.PrintCustomerOrder(curCustomerOrder);
            }
        }

        private void customerOrdersGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && customerOrdersBS.Count > 0)
                DeleteCustomerOrdersRecord();

            if (e.KeyCode == Keys.Insert)
                OpenCustomerOrderAddEditFm(true);
        }

        private void customerOrdersGridView_DoubleClick(object sender, EventArgs e)
        {
            if (customerOrdersBS.Count > 0)
                OpenCustomerOrderAddEditFm(false);
        }


    }
}
