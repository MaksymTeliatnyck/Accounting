using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Accounting
{
    public partial class contractorsRBFm : Form
    {
        private BindingSource contractorsBS = new BindingSource();
        
        public contractorsRBFm()
        {
            InitializeComponent();
            
            contractorsBS.DataSource = DataModule.AccountingDS.Tables["Contractors"];
            contractorsGrid.DataSource = contractorsBS;

            SelectDate();

        }

        #region Method's

        private void SelectDate()
        {
            DataModule.AccountingDS.Tables["Contractors"].Rows.Clear();
            DataModule.DataAdapter["Contractors"].Fill(DataModule.AccountingDS.Tables["Contractors"]);        
        }

        private bool _inserting;
        private void OpenContractorEditFm(bool inserting)
        {
            _inserting = inserting;

            contractorsEditFm contractorsEditFm;

            int current_ContractorId = (int)((DataRowView)contractorsBS.Current)["Id"];

            contractorsEditFm = new contractorsEditFm(_inserting, contractorsBS.Position, current_ContractorId);

            contractorsEditFm.ShowDialog();

            int return_ContractorId = contractorsEditFm.Return();

            SelectDate();

            int currentRowHandle = contractorsGridView.LocateByValue("Id", ((return_ContractorId < 0) ? current_ContractorId : return_ContractorId));
            contractorsGridView.FocusedRowHandle = currentRowHandle;

            contractorsGrid.Focus();
        }

        private void DeleteContractor()
        {
            if (((DataRowView)contractorsBS.Current).Row.RowState != DataRowState.Added)
            {
                DataModule.Connection.Open();

                int countInOrders = (int)DataModule.ExecuteScalar(@"SELECT COUNT(*) FROM Orders WHERE Vendor_Id = @Id", new FbParameter("Id", ((DataRowView)contractorsBS.Current)["Id"]));
                int countInBankPayments = (int)DataModule.ExecuteScalar(@"SELECT COUNT(*) FROM ""Bank_Payments"" WHERE ""Contractor_Id"" = @Id", new FbParameter("Id", ((DataRowView)contractorsBS.Current)["Id"]));
                int countInInvoices = (int)DataModule.ExecuteScalar(@"SELECT COUNT(*) FROM ""Invoices"" WHERE ""Contractor_Id"" = @Id", new FbParameter("Id", ((DataRowView)contractorsBS.Current)["Id"]));
                int countInCalsWithBuyers = (int)DataModule.ExecuteScalar(@"SELECT COUNT(*) FROM ""CalcWithBuyers"" WHERE ""ContractorsId"" = @Id", new FbParameter("Id", ((DataRowView)contractorsBS.Current)["Id"]));
                int countInBusinessTrips = (int)DataModule.ExecuteScalar(@"SELECT COUNT(*) FROM ""BusinessTrips"" WHERE ""ContractorsID"" = @Id", new FbParameter("Id", ((DataRowView)contractorsBS.Current)["Id"]));

                DataModule.Connection.Close();

                if ((countInOrders + countInBankPayments + countInInvoices + countInCalsWithBuyers + countInBusinessTrips) == 0)
                {
                    if (MessageBox.Show("Видалити запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        int Pos = contractorsGridView.FocusedRowHandle;

                        try
                        {
                            contractorsBS.RemoveCurrent();
                            DataModule.DataAdapter["Contractors"].Update(DataModule.AccountingDS.Tables["Contractors"]);
                            SelectDate();
                            contractorsGridView.FocusedRowHandle = Pos - 1;
                        }
                        catch (FbException Excpt)
                        {
                            DataModule.AccountingDS.Tables["Contractors"].RejectChanges();
                            contractorsGridView.FocusedRowHandle = Pos;
                            MessageBox.Show(DataModule.GetError(Excpt), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неможливо видалити запис. Знайдені пов'язані записи!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        #endregion

        #region Click event's

        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenContractorEditFm(true);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (contractorsBS.Count != 0)
            {
                OpenContractorEditFm(false);
            }
        }
       
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (contractorsBS.Count != 0)
            {
                DeleteContractor();
            }
        }
                
        private void contractorsGridView_DoubleClick(object sender, EventArgs e)
        {
            if (contractorsBS.Count != 0)
            {
                OpenContractorEditFm(false);
            }
        }

        private void contractorsGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && contractorsBS.Count > 0)
                DeleteContractor();

            if (e.KeyCode == Keys.Insert)
                OpenContractorEditFm(true);
        }
       

        #endregion

        
    }
}
