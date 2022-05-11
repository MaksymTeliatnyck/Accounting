using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Accounting
{
    public partial class fixedAssetsGroupRGFm : Form
    {
        private BindingSource fixedAssetsGroupBS = new BindingSource();
        private DataTable fixedAssetsGroupTable = new DataTable();
        private FbDataAdapter fixedAssetsGroupDA = new FbDataAdapter();

        public fixedAssetsGroupRGFm()
        {
            InitializeComponent();

            fixedAssetsGroupDA.SelectCommand = DataModule.Connection.CreateCommand();
            fixedAssetsGroupDA.SelectCommand.CommandText =
                @"SELECT * FROM ""FixedAssetsGroup"" ORDER BY ""Name""";
            //
            fixedAssetsGroupDA.InsertCommand = DataModule.Connection.CreateCommand();
            fixedAssetsGroupDA.InsertCommand.CommandText =
                @"INSERT INTO ""FixedAssetsGroup""(""Name"", ""AmortizationFactor"") VALUES(@Name, @AmortizationFactor) RETURNING ""Id""";
            fixedAssetsGroupDA.InsertCommand.Parameters.Add("Name", FbDbType.VarChar, 200, "Name");
            fixedAssetsGroupDA.InsertCommand.Parameters.Add("AmortizationFactor", FbDbType.Decimal, 8, "AmortizationFactor");
            fixedAssetsGroupDA.InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id").Direction = ParameterDirection.Output;
            //
            fixedAssetsGroupDA.UpdateCommand = DataModule.Connection.CreateCommand();
            fixedAssetsGroupDA.UpdateCommand.CommandText =
                @"UPDATE ""FixedAssetsGroup"" SET ""Name"" = @Name, ""AmortizationFactor"" = @AmortizationFactor WHERE ""Id"" = @Id";
            fixedAssetsGroupDA.UpdateCommand.Parameters.Add("Name", FbDbType.VarChar, 200, "Name");
            fixedAssetsGroupDA.UpdateCommand.Parameters.Add("AmortizationFactor", FbDbType.Decimal, 8, "AmortizationFactor");
            fixedAssetsGroupDA.UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            //
            fixedAssetsGroupDA.DeleteCommand = DataModule.Connection.CreateCommand();
            fixedAssetsGroupDA.DeleteCommand.CommandText =
                @"DELETE FROM ""FixedAssetsGroup"" WHERE ""Id"" = @Id";
            fixedAssetsGroupDA.DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            fixedAssetsGroupBS.DataSource = fixedAssetsGroupTable;
            contractorsGrid.DataSource = fixedAssetsGroupBS;

            NameTBox.DataBindings.Add("Text", fixedAssetsGroupBS, "Name");
            AmortizationFactorTBox.DataBindings.Add("Text", fixedAssetsGroupBS, "AmortizationFactor");

            fixedAssetsGroupDA.Fill(fixedAssetsGroupTable);
        }

        private Boolean AmortizationFactorTBox_Validated()
        {
            //if (AmortizationFactorTBox.Text != "")
            //{
            //    return true;
            //}
            //MessageBox.Show("Не указано сумму", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //return false;
            return true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (AmortizationFactorTBox_Validated())
            {
                fixedAssetsGroupTable.Rows.Add();
                fixedAssetsGroupBS.MoveLast();
                NameTBox.Focus();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            
            if (((DataRowView)fixedAssetsGroupBS.Current).Row.RowState != DataRowState.Added)
            {
                DataModule.Connection.Open();
                int a = (int)DataModule.ExecuteScalar(@"SELECT COUNT(*) FROM ""FixedAssetsOrder"" WHERE  ""Group_Id"" = @Id", new FbParameter("Id", ((DataRowView)fixedAssetsGroupBS.Current)["Id"]));
                DataModule.Connection.Close();

                if (a != 0)
                {
                    MessageBox.Show("Невозможно удалить строку так как она имеет связанные записи!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
             
            }

            if (MessageBox.Show("Удалить строку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fixedAssetsGroupBS.RemoveCurrent();
            }
             
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (AmortizationFactorTBox_Validated())
            {
                if (NameTBox.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Не указано название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                NameTBox.Text = NameTBox.Text.Trim();
                AmortizationFactorTBox.Text = AmortizationFactorTBox.Text.Trim();
                fixedAssetsGroupBS.EndEdit();
                fixedAssetsGroupDA.Update(fixedAssetsGroupTable);
                if (((Button)sender).Name == "okBtn")
                    this.Close();
            }
        }

        private void nameTBox_Validated(object sender, KeyPressEventArgs e)
        {
            if (NameTBox.Text.ToString().Length == 0)
                fixedAssetsGroupTable.Rows[fixedAssetsGroupBS.Position]["AmortizationFactor"] = DBNull.Value;
        }


        private void AmortizationFactorTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Utils.EnterCheck(sender, e, 9, 2, false, false);
        }


    }
}
