using System;
using System.Windows.Forms;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace Accounting
{
    public partial class nomenclRBFm : Form
    {
        private BindingSource nomenclBS = new BindingSource();
        private DataTable nomenclTable = new DataTable();
        private FbDataAdapter nomenclDA = new FbDataAdapter();

        public nomenclRBFm()
        {
            InitializeComponent();

            nomenclDA.SelectCommand = DataModule.Connection.CreateCommand();
            nomenclDA.SelectCommand.CommandText =
                "SELECT Nomenclatures.*, Accounts.Num FROM Nomenclatures, Accounts WHERE Nomenclatures.Balance_Account_Id = Accounts.Id";
            //
            nomenclDA.InsertCommand = DataModule.Connection.CreateCommand();
            nomenclDA.InsertCommand.CommandText =
                @"INSERT INTO Nomenclatures(Nomenclature, Name, Measure, Balance_Account_Id, ""Nomencl_Group_Id"") VALUES(@Nomenclature, @Name, @Measure, @Balance_Account_Id, 0) RETURNING Id";
            nomenclDA.InsertCommand.Parameters.Add("Nomenclature", FbDbType.VarChar, 12, "Nomenclature");
            nomenclDA.InsertCommand.Parameters.Add("Name", FbDbType.VarChar, 200, "Name");
            nomenclDA.InsertCommand.Parameters.Add("Measure", FbDbType.VarChar, 10, "Measure");
            nomenclDA.InsertCommand.Parameters.Add("Balance_Account_Id", FbDbType.SmallInt, 2, "Balance_Account_Id");
            nomenclDA.InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id").Direction = ParameterDirection.Output;
            //
            nomenclDA.UpdateCommand = DataModule.Connection.CreateCommand();
            nomenclDA.UpdateCommand.CommandText =
                @"UPDATE Nomenclatures SET Nomenclature = @Nomenclature, Name = @Name, Measure = @Measure, Balance_Account_Id = @Balance_Account_Id WHERE Id = @Id";
            nomenclDA.UpdateCommand.Parameters.Add("Nomenclature", FbDbType.VarChar, 12, "Nomenclature");
            nomenclDA.UpdateCommand.Parameters.Add("Name", FbDbType.VarChar, 200, "Name");
            nomenclDA.UpdateCommand.Parameters.Add("Measure", FbDbType.VarChar, 10, "Measure");
            nomenclDA.UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            nomenclDA.UpdateCommand.Parameters.Add("Balance_Account_Id", FbDbType.SmallInt, 2, "Balance_Account_Id");
            //
            nomenclDA.DeleteCommand = DataModule.Connection.CreateCommand();
            nomenclDA.DeleteCommand.CommandText =
                @"DELETE FROM Nomenclatures WHERE Id = @Id";
            nomenclDA.DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            nomenclBS.DataSource = nomenclTable;
            nomenclGrid.DataSource = nomenclBS;

            nomenclatureTBox.DataBindings.Add("Text", nomenclBS, "Nomenclature");
            nomenclNameTBox.DataBindings.Add("Text", nomenclBS, "Name");
            measureTBox.DataBindings.Add("Text", nomenclBS, "Measure");
            balanceTBox.DataBindings.Add("Text", nomenclBS, "Num");

            nomenclDA.Fill(nomenclTable);

            nomenclTable.ColumnChanged += nomenclTable_ColumnChanged;
        }

        private void nomenclTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            nomenclBS.EndEdit();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (nomenclatureTBox.Text.Length == 0 || nomenclNameTBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Не указана номенклатура или название!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            measureTBox.Text = measureTBox.Text.Trim();
            nomenclDA.Update(nomenclTable);
            if (((Button)sender).Name == "okBtn")
                this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (((DataRowView)nomenclBS.Current).Row.RowState != DataRowState.Added)
            {
                DataModule.Connection.Open();
                int n = (int)DataModule.ExecuteScalar("SELECT COUNT(Nomenclature_Id) FROM Receipts WHERE Nomenclature_Id = " + ((DataRowView)nomenclBS.Current)["Id"]);
                DataModule.Connection.Close();
                if (n != 0)
                {
                    MessageBox.Show("Нельзя удалить строку, так как она уже используется!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (MessageBox.Show("Удалить строку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                nomenclBS.RemoveCurrent();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            nomenclTable.Rows.Add();
            nomenclBS.MoveLast();
            nomenclatureTBox.Focus();
        }

        private DataTable BalanceTable = new DataTable();
        private void GetBalance()
        {
            if (nomenclatureTBox.Text.Length != 0)
            {
                DataModule.Connection.Open();
                int n = ((int)DataModule.ExecuteScalar(@"SELECT COUNT(Nomenclature) FROM Nomenclatures WHERE Nomenclature = @nomenclatureParam", new FbParameter("nomenclatureParam", nomenclatureTBox.Text.ToString())));
                DataModule.Connection.Close();
                if (n > 0)
                {
                    MessageBox.Show("Данная номенклатура уже есть в базе!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    balanceTBox.Text = "";
                    nomenclatureTBox.Text = "";
                    nomenclTable.Rows[nomenclBS.Position]["Nomenclature"] = DBNull.Value;
                    nomenclatureTBox.Focus();
                    return;
                }
            }
            else
            {
                return;
            }

            if (BalanceTable.Rows.Count == 0)
                BalanceTable = DataModule.ExecuteFill("SELECT * FROM Accounts ORDER BY CHAR_LENGTH(Num) DESC");
            for (int i = 0; i < BalanceTable.Rows.Count; i++)
            {
                /*
                if (nomenclatureTBox.Text.Length < BalanceTable.Rows[i]["Num"].ToString().Replace("/", "").Length)
                {
                    MessageBox.Show("Такого балансового счёта нет в базе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    balanceTBox.Text = "";
                    nomenclatureTBox.Text = "";
                    nomenclTable.Rows[nomenclBS.Position]["Nomenclature"] = DBNull.Value;
                    nomenclatureTBox.Focus();
                    return;
                }
                 */

                string tempValue = BalanceTable.Rows[i]["Num"].ToString().Replace("/", "");
                if (nomenclatureTBox.Text.Length >= tempValue.Length && nomenclatureTBox.Text.IndexOf(tempValue, 0, tempValue.Length) != -1)
              //  if (nomenclatureTBox.Text.IndexOf(BalanceTable.Rows[i]["Num"].ToString().Replace("/", ""), 0, BalanceTable.Rows[i]["Num"].ToString().Replace("/", "").Length) != -1)
                {
                    nomenclTable.Rows[nomenclBS.Position]["Balance_Account_Id"] = BalanceTable.Rows[i]["Id"];
                    balanceTBox.Text = BalanceTable.Rows[i]["Num"].ToString();
                    break;
                }
                else
                {
                    if (i == BalanceTable.Rows.Count - 1)
                    {
                        MessageBox.Show("Такого балансового счёта нет в базе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        balanceTBox.Text = "";
                        nomenclatureTBox.Text = "";
                        nomenclTable.Rows[nomenclBS.Position]["Nomenclature"] = DBNull.Value;
                        
                        balanceTBox.Text = "";
                        nomenclatureTBox.Text = "";
                        nomenclatureTBox.Focus();
                    }
                }
            }
        }

        private void nomenclatureTBox_Validated(object sender, EventArgs e)
        {
            nomenclNameTBox.Text = nomenclNameTBox.Text.Trim();
            nomenclBS.EndEdit();
            if
            (
                nomenclTable.Rows[nomenclBS.Position].RowState == DataRowState.Added ||
                (
                    nomenclTable.Rows[nomenclBS.Position].RowState == DataRowState.Modified &&
                    nomenclTable.Rows[nomenclBS.Position]["Nomenclature", DataRowVersion.Original].ToString() != nomenclTable.Rows[nomenclBS.Position]["Nomenclature", DataRowVersion.Current].ToString()
                )
            )
            {
                GetBalance();
            }
        }

        private void nomenclatureTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.OnlyNumbers(e);
            if (e.KeyChar == (char)Keys.Enter)
                nomenclNameTBox.Focus();
        }

        private void nomenclNameTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                measureTBox.Focus();
        }

        private void measureTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                applyBtn.Focus();
        }

        private void nomenclGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2 && e.RowHandle > -1)
            {
                if (((DataRowView)nomenclBS.Current)["Id"] != DBNull.Value)
                    this.DialogResult = DialogResult.OK;
            }
        }

        public DataRow Return()
        {
            return ((DataRowView)nomenclBS.Current).Row;
        }

    }
}
