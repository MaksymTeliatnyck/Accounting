using System;
using System.Windows.Forms;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace Accounting
{
    public partial class suppliersRBFm : Form
    {
        private FbDataAdapter suppliersDA = new FbDataAdapter();
        private DataTable suppliersTable = new DataTable();
        private BindingSource suppliersBS = new BindingSource();

        public suppliersRBFm()
        {
            InitializeComponent();

            suppliersGrid.AutoGenerateColumns = false;
            Utils.SetDoubleBuffered(suppliersGrid, true);

            suppliersDA.SelectCommand = DataModule.Connection.CreateCommand();
            suppliersDA.SelectCommand.CommandText = @"SELECT Suppliers.* ,SUPPLIERS_GROUP.NAME AS GRName FROM Suppliers
                                                    LEFT JOIN SUPPLIERS_GROUP ON  SUPPLIERS_GROUP.ID=Suppliers.GROUP_ID
                                                    WHERE Suppliers.ID > 0 ORDER BY NAME";

            suppliersDA.InsertCommand = DataModule.Connection.CreateCommand();
            suppliersDA.InsertCommand.CommandText = "INSERT INTO Suppliers(NAME) VALUES(@NAME) RETURNING ID";
            suppliersDA.InsertCommand.Parameters.Add("ID", FbDbType.SmallInt, 2, "ID").Direction = ParameterDirection.Output;
            suppliersDA.InsertCommand.Parameters.Add("NAME", FbDbType.VarChar, 50, "NAME");
            suppliersDA.InsertCommand.Parameters.Add("ACTIVE", FbDbType.Numeric, 1, "ACTIVE");
            suppliersDA.InsertCommand.Parameters.Add("GROUP_ID", FbDbType.Numeric, 3, "GROUP_ID");
 
            suppliersDA.UpdateCommand = DataModule.Connection.CreateCommand();
            suppliersDA.UpdateCommand.CommandText = "UPDATE Suppliers SET NAME = @NAME, ACTIVE=@ACTIVE, GROUP_ID=@GROUP_ID  WHERE ID = @ID";
            suppliersDA.UpdateCommand.Parameters.Add("ID", FbDbType.SmallInt, 2, "ID");
            suppliersDA.UpdateCommand.Parameters.Add("NAME", FbDbType.VarChar, 50, "NAME");
            suppliersDA.UpdateCommand.Parameters.Add("ACTIVE", FbDbType.Numeric, 255, "ACTIVE");
            suppliersDA.UpdateCommand.Parameters.Add("GROUP_ID", FbDbType.Numeric, 255, "GROUP_ID");

            suppliersDA.DeleteCommand = DataModule.Connection.CreateCommand();
            suppliersDA.DeleteCommand.CommandText = "DELETE FROM Suppliers WHERE ID = @ID";
            suppliersDA.DeleteCommand.Parameters.Add("ID", FbDbType.SmallInt, 2, "Id");

            suppliersBS.DataSource = suppliersTable;
            suppliersGrid.DataSource = suppliersBS;
            suppliersDA.Fill(suppliersTable);

            supplierNameTBox.DataBindings.Add("Text", suppliersBS, "NAME").DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
         
            suppliersgroupCB.DataBindings.Add("SelectedValue", suppliersBS, "GROUP_ID").DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            suppliersgroupCB.DataBindings.Add("Text", suppliersBS, "GRNAME");
            suppliersgroupCB.DataSource = DataModule.ExecuteFill("SELECT * FROM SUPPLIERS_GROUP ORDER BY NAME");
            suppliersgroupCB.DisplayMember = "NAME";
            suppliersgroupCB.ValueMember = "ID";

            suppliersactiveCB.DataBindings.Add("Checked", suppliersBS, "ACTIVE", true).DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
             
            suppliersTable.ColumnChanged += projectsTable_ColumnChanged;
        }

        private void projectsTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            suppliersBS.EndEdit();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (supplierNameTBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Заполните поле имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            suppliersDA.Update(suppliersTable);

            if (((Button)sender).Name == "okBtn")
                this.Close();

            Cursor = Cursors.Default;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            suppliersTable.Rows.Add();
            suppliersBS.MoveLast();
            supplierNameTBox.Focus();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (suppliersTable.Rows[suppliersBS.Position].RowState != DataRowState.Added)
            {
                DataModule.Connection.Open();
                int n = (int)DataModule.ExecuteScalar("SELECT COUNT(Supplier_Id) FROM Orders WHERE Supplier_Id = " + ((DataRowView)suppliersBS.Current)["Id"]);
                DataModule.Connection.Close();
                if (n != 0)
                {
                    MessageBox.Show("Нельзя удалить строку, так как она уже используется!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            
            if (MessageBox.Show("Удалить строку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                suppliersBS.RemoveCurrent();
            }
        }

        private void suppliersGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                supplierNameTBox.Focus();
        }

        private void supplierNameTBox_Validated(object sender, EventArgs e)
        {
            if (supplierNameTBox.Text.Trim().Length == 0)
            {
                if (MessageBox.Show("Не указан снабженец, удалить строку?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    suppliersBS.RemoveCurrent();
                }
                else
                {
                    supplierNameTBox.Focus();
                }
            }

            DataRow Row = ((DataRowView)suppliersBS.Current).Row;

            if
            (
                Row.RowState == DataRowState.Added ||
                (Row.HasVersion(DataRowVersion.Original) && Row.HasVersion(DataRowVersion.Current) && 
                Row["Name", DataRowVersion.Original].ToString().Trim().ToUpper() != Row["Name", DataRowVersion.Current].ToString().Trim().ToUpper())
            )
            {
                DataModule.Connection.Open();
                int n = (int)DataModule.ExecuteScalar("SELECT COUNT(Name) FROM Suppliers WHERE UPPER(Name) = @Name", new FbParameter("Name", supplierNameTBox.Text.Trim().ToUpper()));
                DataModule.Connection.Close();
                if (n != 0)
                {
                    if (MessageBox.Show("Такой снабженец уже есть в базе, продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        supplierNameTBox.Text = "";
                        supplierNameTBox.Focus();
                    }
                }
            }

            supplierNameTBox.Text = supplierNameTBox.Text.Trim();
        }
               
    }
}
