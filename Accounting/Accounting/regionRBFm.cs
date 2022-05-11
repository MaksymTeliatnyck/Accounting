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
    public partial class regionRBFm : Form
    {
        private BindingSource regionBS = new BindingSource();
        private DataTable regionTable = new DataTable();
        private FbDataAdapter regionDA = new FbDataAdapter();

        public regionRBFm()
        {
            InitializeComponent();

            //"Id", "Name", "Type", "Description"
            regionDA.SelectCommand = DataModule.Connection.CreateCommand();
            regionDA.SelectCommand.CommandText =
                @"SELECT * FROM ""Region"" ORDER BY ""Name""";
            //
            regionDA.InsertCommand = DataModule.Connection.CreateCommand();
            regionDA.InsertCommand.CommandText =
                @"INSERT INTO ""Region""(""Name"", ""Type"", ""Description"") VALUES(@Name, @Type, @Description) RETURNING ""Id""";
            regionDA.InsertCommand.Parameters.Add("Name", FbDbType.VarChar, 100, "Name");
            regionDA.InsertCommand.Parameters.Add("Type", FbDbType.SmallInt, 2, "Type");
            regionDA.InsertCommand.Parameters.Add("Description", FbDbType.VarChar, 100, "Description");
            regionDA.InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id").Direction = ParameterDirection.Output;
            //
            regionDA.UpdateCommand = DataModule.Connection.CreateCommand();
            regionDA.UpdateCommand.CommandText =
                @"UPDATE ""Region"" SET ""Name"" = @Name, ""Type"" = @Type, ""Description"" = @Description WHERE ""Id"" = @Id";
            regionDA.UpdateCommand.Parameters.Add("Name", FbDbType.VarChar, 100, "Name");
            regionDA.UpdateCommand.Parameters.Add("Type", FbDbType.SmallInt, 2, "Type");
            regionDA.UpdateCommand.Parameters.Add("Description", FbDbType.VarChar, 100, "Description");
            regionDA.UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            //
            regionDA.DeleteCommand = DataModule.Connection.CreateCommand();
            regionDA.DeleteCommand.CommandText =
                @"DELETE FROM ""Region"" WHERE ""Id"" = @Id";
            regionDA.DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            regionBS.DataSource = regionTable;
            regionGrid.DataSource = regionBS;

            NameTBox.DataBindings.Add("Text", regionBS, "Name");
            TypeTBox.DataBindings.Add("Text", regionBS, "Type");
            DescriptionTBox.DataBindings.Add("Text", regionBS, "Description");
            
            regionDA.Fill(regionTable);

        }

        private Boolean ValueTBox_Validated()
        {
            if (NameTBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Укажите наименование участка", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            regionBS.EndEdit();

            return true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (ValueTBox_Validated())
            {
                regionTable.Rows.Add();
                regionBS.MoveLast();
                NameTBox.Focus();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            
            if (((DataRowView)regionBS.Current).Row.RowState != DataRowState.Added)
            {
                DataModule.Connection.Open();
                int a = (int)DataModule.ExecuteScalar(@"SELECT COUNT(*) FROM ""FixedAssetsOrder"" WHERE  ""Region_Id"" = @Id", new FbParameter("Id", ((DataRowView)regionBS.Current)["Id"]));
                DataModule.Connection.Close();

                if (a != 0)
                {
                    MessageBox.Show("Невозможно удалить строку так как она имеет связанные записи!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
             
            }

            if (MessageBox.Show("Удалить строку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                regionBS.RemoveCurrent();
            }
             
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (ValueTBox_Validated())
            {
                NameTBox.Text = NameTBox.Text.Trim();
                DescriptionTBox.Text = DescriptionTBox.Text.Trim();
                regionDA.Update(regionTable);
                if (((Button)sender).Name == "okBtn")
                    this.Close();
            }
        }


        private void TypeTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.EnterCheck(sender, e, 5, 0, false, false);
        }



  
    
    }
}
