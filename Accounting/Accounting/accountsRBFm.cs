using System;
using System.Windows.Forms;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace Accounting
{
    public partial class accountsRBFm : Form
    {
        private FbDataAdapter accountsDA = new FbDataAdapter();
        private DataTable accountsTable = new DataTable();
        private BindingSource accountsBS = new BindingSource();

        public accountsRBFm()
        {
            InitializeComponent();

            accountsGrid.AutoGenerateColumns = false;
            Utils.SetDoubleBuffered(accountsGrid, true);

            accountsDA.SelectCommand = DataModule.Connection.CreateCommand();
            accountsDA.SelectCommand.CommandText = DataModule.Queries["Accounts"];

            accountsDA.InsertCommand = DataModule.Connection.CreateCommand();
            accountsDA.InsertCommand.CommandText =
                "INSERT INTO Accounts(Num) VALUES(@Num) RETURNING Id";
            accountsDA.InsertCommand.Parameters.Add("Id", FbDbType.SmallInt, 2, "Id").Direction = ParameterDirection.Output;
            accountsDA.InsertCommand.Parameters.Add("Num", FbDbType.VarChar, 8, "Num");

            accountsDA.UpdateCommand = DataModule.Connection.CreateCommand();
            accountsDA.UpdateCommand.CommandText =
                "UPDATE Accounts SET Num = @Num WHERE Id = @Id";
            accountsDA.UpdateCommand.Parameters.Add("Num", FbDbType.VarChar, 8, "Num");
            accountsDA.UpdateCommand.Parameters.Add("Id", FbDbType.SmallInt, 2, "Id");

            accountsDA.DeleteCommand = DataModule.Connection.CreateCommand();
            accountsDA.DeleteCommand.CommandText =
                "DELETE FROM Accounts WHERE Id = @Id";
            accountsDA.DeleteCommand.Parameters.Add("Id", FbDbType.SmallInt, 2, "Id");

            accountsBS.DataSource = accountsTable;
            accountsGrid.DataSource = accountsBS;

            accountNumTBox.DataBindings.Add("Text", accountsBS, "Num");

            accountsDA.Fill(accountsTable);

            accountsTable.ColumnChanged += accountsTable_ColumnChanged;
        }

        private void accountsTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            accountsBS.EndEdit();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (accountNumTBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Не указан счёт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                accountNumTBox.Focus();
                return;
            }
            accountNumTBox.Text = accountNumTBox.Text.Trim();
            accountsDA.Update(accountsTable);
            if (((Button)sender).Name == "okBtn")
                this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            accountsTable.Rows.Add();
            accountsBS.MoveLast();
            accountNumTBox.Focus();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (accountsTable.Rows[accountsBS.Position].RowState != DataRowState.Added)
            {
                DataModule.Connection.Open();
                int a = (int)DataModule.ExecuteScalar("SELECT COUNT(Balance_Account_Id) FROM Nomenclatures WHERE Balance_Account_Id = " + accountsTable.Rows[accountsBS.Position]["Id"]);
                int b = (int)DataModule.ExecuteScalar("SELECT COUNT(Debit_Account_Id) FROM Orders WHERE Debit_Account_Id = " + accountsTable.Rows[accountsBS.Position]["Id"]);
                int c = (int)DataModule.ExecuteScalar("SELECT COUNT(Credit_Account_Id) FROM Expenditures_Accountant WHERE Credit_Account_Id = " + accountsTable.Rows[accountsBS.Position]["Id"]);
                DataModule.Connection.Close();
                if (a > 0 || b > 0 || c > 0)
                {
                    MessageBox.Show("Нельзя удалить счет, так как он уже используется!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (MessageBox.Show("Удалить строку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                accountsBS.RemoveCurrent();
            }
        }

        private void accountsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            accountNumTBox.Focus();
        }

        private void accountNumTBox_Validated(object sender, EventArgs e)
        {
            if (accountNumTBox.Text.Length == 0)
            {
                if (MessageBox.Show("Не указан счёт, удалить строку?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    accountsTable.Rows[accountsBS.Position].Delete();
                }
                else
                {
                    accountNumTBox.Focus();
                }
            }

            if
            (
                accountsTable.Rows[accountsBS.Position].RowState == DataRowState.Added
                ||
                (accountsTable.Rows[accountsBS.Position].HasVersion(DataRowVersion.Original) && accountsTable.Rows[accountsBS.Position].HasVersion(DataRowVersion.Current)
                &&
                accountsTable.Rows[accountsBS.Position]["Num", DataRowVersion.Original].ToString() != accountsTable.Rows[accountsBS.Position]["Num", DataRowVersion.Current].ToString())
            )
            {
                DataModule.Connection.Open();
                int n = (int)DataModule.ExecuteScalar("SELECT COUNT(Num) FROM Accounts WHERE Num = @Num", new FbParameter("Num", accountNumTBox.Text));
                DataModule.Connection.Close();
                if (n != 0)
                {
                    MessageBox.Show("Такой счёт уже есть в базе!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    accountNumTBox.Text = "";
                    accountsTable.Rows[accountsBS.Position]["Num"] = "";
                    accountNumTBox.Focus();
                }
            }
        }

    }
}
