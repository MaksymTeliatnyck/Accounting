using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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
	public partial class editInvoiceRequirement : Form
	{
        private static int requirementOrdersBS_Position;
        public static int getRequirementOrdersBSPosition { get { return requirementOrdersBS_Position; } }
        private long _id;

        private BindingSource requirementOrdersBS = new BindingSource();
        private BindingSource materialsBS = new BindingSource();
		
        private string _dateStart, _dateEnd;

        public editInvoiceRequirement(bool inserting, int position, string dateStart, string dateEnd)
		{
			InitializeComponent();

            _dateStart = dateStart;
            _dateEnd = dateEnd;

            invoiceDatePicker.Value = DateTime.Now;
            
            requirementOrdersBS.DataSource = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"];
            materialsBS.DataSource = DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"];
			requirementMaterialGrid.DataSource = materialsBS;

			if (inserting)
			{
				this.Text = "Додати вимогу";

				DataModule.Connection.Open();
				_id = (long)DataModule.ExecuteScalar(@"SELECT NEXT VALUE FOR ""Seq_Requirement_Order_Id"" FROM RDB$Database");
				DataModule.Connection.Close();

				DataRow Row;

                Row = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].NewRow();
				Row["ReqOrderId"] = _id;
				Row["Date"] = invoiceDatePicker.Value.ToShortDateString();

                DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows.Add(Row);

				requirementOrdersBS.MoveLast();
			}
			else 
			{
				this.Text = "Редагувати вимогу";
				requirementOrdersBS.Position = position;
			}

			invoiceDatePicker.DataBindings.Add("Value", requirementOrdersBS, "Date");
			numberTBox.DataBindings.Add("Text", requirementOrdersBS, "Number");
            			
            var EmploeesList = DataModule.ExecuteFillProc("GetEmployeesWorking");

            supplierNewCBox.DataBindings.Add("EditValue", requirementOrdersBS, "SupplierId");
            supplierNewCBox.Properties.DataSource = EmploeesList;
            supplierNewCBox.Properties.ValueMember = "EmployeeID";
            supplierNewCBox.Properties.DisplayMember = "FullName";
            
            requirementOrdersBS_Position = requirementOrdersBS.Position;
		}
        
		private void reportBtn_Click(object sender, EventArgs e)
		{
			string number = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows[requirementOrdersBS.Position]["Number"].ToString();
			string date = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows[requirementOrdersBS.Position]["Date"].ToString();
            string responsiblePerson = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows[requirementOrdersBS.Position]["Responsible_Person"].ToString();
            Reports report = new Reports();
            report.InvoiceRequirement(DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"], number, date.Remove(10), responsiblePerson);
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
            if (numberTBox.Text.Trim().Length <= 0 || supplierNewCBox.EditValue == null)
			{
				MessageBox.Show("Введіть номер документу та виберіть відповідальну особу!");
			}
			else
			{
				requirementOrdersBS.EndEdit();
				materialsBS.EndEdit();

                try
                {
                    DataModule.DataAdapter["Invoice_Requirement_Orders"].Update(DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"]);
                    DataModule.DataAdapter["Invoice_Requirement_Materials"].Update(DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При збереженні виникла помилка. Операцію відмінено.\n\n" + ex.Message, "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].RejectChanges();
                    DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"].RejectChanges();
                }
                
                DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"].Clear();
                DataModule.DataAdapter["Invoice_Requirement_Materials"].Fill(DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"]);

                DataModule.DataAdapter["Invoice_Requirement_Orders"].SelectCommand.Parameters["StartDate"].Value = Convert.ToDateTime(_dateStart);
                DataModule.DataAdapter["Invoice_Requirement_Orders"].SelectCommand.Parameters["EndDate"].Value = Convert.ToDateTime(_dateEnd);
                DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows.Clear();
                DataModule.DataAdapter["Invoice_Requirement_Orders"].Fill(DataModule.AccountingDS, "Invoice_Requirement_Orders");

                this.Close();
			}
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
            DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].RejectChanges();
            DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"].RejectChanges();
            
			this.Close();
		}

		private void addBtn_Click(object sender, EventArgs e)
		{
			invoiceRequirementEditMaterial invoiceRequirementEditMaterial = new invoiceRequirementEditMaterial(requirementOrdersBS.Position);
			invoiceRequirementEditMaterial.ShowDialog();

            requirementMaterialView.BeginSummaryUpdate();
            requirementMaterialView.EndSummaryUpdate();

            requirementOrdersBS_Position = requirementOrdersBS.Position;
		}

		private void editInvoiceRequirement_FormClosed(object sender, FormClosedEventArgs e)
		{
            DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].RejectChanges();
            DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"].RejectChanges();
		}

		private void requirementMaterialView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if (e.FocusedRowHandle < 0)
			{
				deleteBtn.Enabled = false;
			}
			deleteBtn.Enabled = true;
		}

		private void deleteBtn_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Видилити запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
                var focusedDataRow = requirementMaterialView.GetFocusedDataRow();

                if (focusedDataRow["Expenditures_Id"] == DBNull.Value)
                {
                    materialsBS.RemoveCurrent();
                }
                else
                {
                    MessageBox.Show("Операцію відмінено. Матеріал знаходиться у списанні.\n", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
			}
		}

        private void SelectIRButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var focusedDataRow = requirementMaterialView.GetFocusedDataRow();
            var sourseDataForm =  new InvoiceRequirementSelectFixedAssets();
            if (e.Button.Index == 1)
            {
                sourseDataForm.isSetData = false;
            }
            else
            {
                switch (sourseDataForm.isSetData)
                {
                    case true:
                        focusedDataRow["InventoryNumber"] = sourseDataForm.SelectInventoryNumber;
                        focusedDataRow["InventoryName"] = sourseDataForm.SelectInventoryName;
                        focusedDataRow["FixedAssets_Id"] = sourseDataForm.SelectId;
                        break;
                    case false:
                        focusedDataRow["InventoryNumber"] = DBNull.Value;
                        focusedDataRow["InventoryName"] = DBNull.Value;
                        focusedDataRow["FixedAssets_Id"] = DBNull.Value;
                        break;
                    case null:
                    default:
                        break;
                }

                sourseDataForm.ShowDialog();
            }
            switch(sourseDataForm.isSetData)
            {
                case true:
                    focusedDataRow["InventoryNumber"] = sourseDataForm.SelectInventoryNumber;
                    focusedDataRow["InventoryName"] = sourseDataForm.SelectInventoryName;
                    focusedDataRow["FixedAssets_Id"] = sourseDataForm.SelectId;
                    break;
                case false:
                    focusedDataRow["InventoryNumber"] = DBNull.Value;
                    focusedDataRow["InventoryName"] = DBNull.Value;
                    focusedDataRow["FixedAssets_Id"] = DBNull.Value;
                    break;
                case null:
                default:
                    break;
            }

            materialsBS.EndEdit();
            requirementMaterialView.UpdateCurrentRow();

        }

        private void supplierNewCBox_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }
	}
}
