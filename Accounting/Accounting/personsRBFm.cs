using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Accounting
{
    public partial class personsRBFm : Form
    {
        private FbDataAdapter personsDA = new FbDataAdapter();
        private DataTable personsTable = new DataTable();
        private BindingSource personsBS = new BindingSource();

        public personsRBFm()
        {
            InitializeComponent();

            personsGrid.AutoGenerateColumns = false;
            Utils.SetDoubleBuffered(personsGrid, true);

            personsDA.SelectCommand = DataModule.Connection.CreateCommand();
            personsDA.SelectCommand.CommandText =
                "SELECT * FROM Persons ORDER BY Name;";

            personsDA.InsertCommand = DataModule.Connection.CreateCommand();
            personsDA.InsertCommand.CommandText =
                "INSERT INTO Persons(Name) VALUES(@Name);";
            personsDA.InsertCommand.Parameters.Add("Name", FbDbType.VarChar, 50, "Name");

            personsDA.UpdateCommand = DataModule.Connection.CreateCommand();
            personsDA.UpdateCommand.CommandText =
                "UPDATE Persons SET Name = @Name WHERE Id = @Id;";
            personsDA.UpdateCommand.Parameters.Add("Name", FbDbType.VarChar, 50, "Name");
            personsDA.UpdateCommand.Parameters.Add("Id", FbDbType.SmallInt, 2, "Id");

            personsDA.DeleteCommand = DataModule.Connection.CreateCommand();
            personsDA.DeleteCommand.CommandText =
                "DELETE FROM Persons WHERE Id = @Id;";
            personsDA.DeleteCommand.Parameters.Add("Id", FbDbType.SmallInt, 2, "Id");

            personsBS.DataSource = personsTable;
            personsGrid.DataSource = personsBS;
            personNameTBox.DataBindings.Add("Text", personsBS, "Name");

            personsDA.Fill(personsTable);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (personNameTBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Заполните поле имя");
                return;
            }
            personNameTBox.Text = personNameTBox.Text.Trim();
            personsBS.Position = -1;

            personsDA.Update(personsTable);

            this.Close();
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            if (personNameTBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Не указано имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            personNameTBox.Text = personNameTBox.Text.Trim();
            personsBS.Position = -1;

            personsDA.Update(personsTable);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            personsTable.Rows.Add();
            personsBS.MoveLast();
            personNameTBox.Focus();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (personsTable.Rows[personsBS.Position].RowState != DataRowState.Added)
            {
                DataModule.Connection.Open();
                int n = (int)DataModule.ExecuteScalar("SELECT COUNT(Person_Id) FROM Expenditures_Accountant WHERE Person_Id = " + ((DataRowView)personsBS.Current)["Id"]);
                DataModule.Connection.Close();
                if (n > 0)
                {
                    MessageBox.Show("Нельзя удалить строку, так как она уже используется!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (MessageBox.Show("Удалить строку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                personsBS.RemoveCurrent();
            }
        }

        private void personsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            personNameTBox.Focus();
        }
    }
}
