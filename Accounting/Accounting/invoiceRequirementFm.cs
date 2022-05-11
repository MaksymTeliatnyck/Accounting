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
	public partial class invoiceRequirementFm : Form
	{
		private BindingSource requirementOrdersBS = new BindingSource();
		public invoiceRequirementFm()
		{
			InitializeComponent();

            requirementOrdersBS.DataSource = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"];
			requirementOrdersGrid.DataSource = requirementOrdersBS;
            requirementMaterialGrid.DataSource = DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"];
            
			yearCBox.SelectedIndexChanged -= yearCBox_SelectedIndexChanged;
			monthCBox.SelectedIndexChanged -= monthCBox_SelectedIndexChanged;
			yearEndCBox.SelectedIndexChanged -= yearEndCBox_SelectedIndexChanged;
			monthEndCBox.SelectedIndexChanged -= monthEndCBox_SelectedIndexChanged;

			yearCBox.Text = DateTime.Today.Year.ToString();
			monthCBox.SelectedIndex = DateTime.Today.Month - 1;
			yearEndCBox.Text = yearCBox.Text;
			monthEndCBox.Text = monthCBox.Text;

			yearCBox.SelectedIndexChanged += yearCBox_SelectedIndexChanged;
			monthCBox.SelectedIndexChanged += monthCBox_SelectedIndexChanged;
			yearEndCBox.SelectedIndexChanged += yearEndCBox_SelectedIndexChanged;
			monthEndCBox.SelectedIndexChanged += monthEndCBox_SelectedIndexChanged;

			SelectDate();

			requirementMaterialView.BeginSummaryUpdate();
			requirementMaterialView.EndSummaryUpdate();
		}

		private void invoiceRequirementFm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Program.MainFm.invoiceRequirementBtn.Enabled = true;
		}

		private void addBtn_Click(object sender, EventArgs e)
		{
			OpenMaterialsFm(true);
		}

		private void editInvoiceRequirement_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Show();
		}

		private void requirementGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if (e.FocusedRowHandle < 0)
			{
                DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"].Rows.Clear();
				printRequirementBtn.Enabled = false;
				deleteBtn.Enabled = false;
				editBtn.Enabled = false;
				return;
			}

			editBtn.Enabled = true;
			printRequirementBtn.Enabled = true;
			deleteBtn.Enabled = true;
			SelectMaterials();
			requirementMaterialView.BeginSummaryUpdate();
			requirementMaterialView.EndSummaryUpdate();
		}


		#region SelectDate
		private void yearCBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectDate();
			requirementOrdersGrid.Focus();
			SelectMaterials();
			yearEndCBox.Text = yearCBox.Text;
		}

		private void monthCBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectDate();
			requirementOrdersGrid.Focus();
			SelectMaterials();
			monthEndCBox.Text = monthCBox.Text;
		}

		private void yearEndCBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectDate();
			requirementOrdersGrid.Focus();
			SelectMaterials();
		}

		private void monthEndCBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectDate();
			requirementOrdersGrid.Focus();
			SelectMaterials();
		}

		public string dateStart, dateEnd;
		private void SelectDate()
		{
			dateStart = "01." + (monthCBox.SelectedIndex + 1) + "." + yearCBox.Text;
			dateEnd = DateTime.DaysInMonth(int.Parse(yearEndCBox.Text), monthEndCBox.SelectedIndex + 1) + "." + (monthEndCBox.SelectedIndex + 1) + "." + yearEndCBox.Text;

			DataModule.DataAdapter["Invoice_Requirement_Orders"].SelectCommand.Parameters["StartDate"].Value = Convert.ToDateTime(dateStart);
			DataModule.DataAdapter["Invoice_Requirement_Orders"].SelectCommand.Parameters["EndDate"].Value =Convert.ToDateTime(dateEnd);
            DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows.Clear();
            DataModule.DataAdapter["Invoice_Requirement_Orders"].Fill(DataModule.AccountingDS, "Invoice_Requirement_Orders");
		}
		#endregion

		private void SelectMaterials()
		{
			if (requirementGridView.RowCount > 0 && requirementOrdersBS.Position != -1)
			{
                DataModule.DataAdapter["Invoice_Requirement_Materials"].SelectCommand.Parameters["Id"].Value = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows[requirementOrdersBS.Position]["ReqOrderId"];
				DataModule.DataAdapter["Invoice_Requirement_Materials"].SelectCommand.Parameters["StartDate"].Value = Convert.ToDateTime(dateStart);
                DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"].Rows.Clear();
                DataModule.DataAdapter["Invoice_Requirement_Materials"].Fill(DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"]);
			}
		}

		private void requirementGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
		{
			if (requirementGridView.RowCount != 0 && e.Button == MouseButtons.Left && e.Clicks == 2 && e.RowHandle > -1)
				OpenMaterialsFm(false);
		}

		private void OpenMaterialsFm(bool inserting)
		{
			editInvoiceRequirement editInvoiceRequirement;
			
            if (inserting)
			{
                DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"].Rows.Clear();
				editInvoiceRequirement = new editInvoiceRequirement(true, 0, dateStart, dateEnd);
			}
			else
			{
				editInvoiceRequirement = new editInvoiceRequirement(false, requirementOrdersBS.Position, dateStart, dateEnd);
			}

			editInvoiceRequirement.MdiParent = Program.MainFm;
			editInvoiceRequirement.Show();
			editInvoiceRequirement.FormClosed += editInvoiceRequirement_FormClosed;
			this.Hide();
		}

		private void editBtn_Click(object sender, EventArgs e)
		{
			if (requirementGridView.RowCount != 0)
				OpenMaterialsFm(false);
		}

		private void printRequirementBtn_Click(object sender, EventArgs e)
		{
			Reports report = new Reports();
			string number = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows[requirementOrdersBS.Position]["Number"].ToString();
			string date = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows[requirementOrdersBS.Position]["Date"].ToString();
            string responsiblePerson = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows[requirementOrdersBS.Position]["Responsible_Person"].ToString();
            report.InvoiceRequirement(DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"], number, date.Remove(10), responsiblePerson);
		}

		private void deleteBtn_Click(object sender, EventArgs e)
		{
            string number = DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows[requirementOrdersBS.Position]["Number"].ToString();
            string date = ((DateTime)DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"].Rows[requirementOrdersBS.Position]["Date"]).ToShortDateString();
            
            if (MessageBox.Show(String.Format("Видалити повністю вимогу №{0} від {1}?", number, date), "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
                int expenCount = (DataModule.AccountingDS.Tables["Invoice_Requirement_Materials"]).AsEnumerable().Where(s => s.Field<int?>("Expenditures_Id") > 0).Count();
                if (expenCount == 0)
                {
                    requirementOrdersBS.RemoveCurrent();
                    DataModule.DataAdapter["Invoice_Requirement_Orders"].Update(DataModule.AccountingDS.Tables["Invoice_Requirement_Orders"]);
                }
                else
                {
                    MessageBox.Show("Операцію відмінено. Матеріал знаходиться у списанні.\n", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
			}
		}

        private void minvoiceRequirementMaterialsFmBtn_Click(object sender, EventArgs e)
        {
            invoiceRequirementMaterialsFm invoiceRequirementMaterialsFm = new invoiceRequirementMaterialsFm(dateStart, dateEnd);
            invoiceRequirementMaterialsFm.MdiParent = Program.MainFm;
            invoiceRequirementMaterialsFm.Show();
        }   
	}
}
