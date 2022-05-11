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
    public partial class businessTripsFm : Form
    {
        private BindingSource businessTripBS = new BindingSource();

        public businessTripsFm()
        {
            InitializeComponent();

            yearBeginCBox.SelectedIndexChanged -= dateCBox_SelectedIndexChanged;
            monthBeginCBox.SelectedIndexChanged -= dateCBox_SelectedIndexChanged;
            yearEndCBox.SelectedIndexChanged -= dateCBox_SelectedIndexChanged;
            monthEndCBox.SelectedIndexChanged -= dateCBox_SelectedIndexChanged;

            yearBeginCBox.Text = DateTime.Today.Year.ToString();
            monthBeginCBox.SelectedIndex = DateTime.Today.Month - 1;
            yearEndCBox.Text = yearBeginCBox.Text;
            monthEndCBox.Text = monthBeginCBox.Text;

            yearBeginCBox.SelectedIndexChanged += dateCBox_SelectedIndexChanged;
            monthBeginCBox.SelectedIndexChanged += dateCBox_SelectedIndexChanged;
            yearEndCBox.SelectedIndexChanged += dateCBox_SelectedIndexChanged;
            monthEndCBox.SelectedIndexChanged += dateCBox_SelectedIndexChanged;


            businessTripBS.DataSource = DataModule.AccountingDS.Tables["BusinessTrip_Payments"];
            businessTripGrid.DataSource = businessTripBS;

            SelectData();

            businessTripView.BeginSummaryUpdate();
            businessTripView.EndSummaryUpdate();
        }

        private void dateCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).Name)
            {
                case "yearCBox":
                    yearEndCBox.Text = yearBeginCBox.Text;
                    break;
                case "monthCBox":
                    monthEndCBox.Text = monthBeginCBox.Text;
                    break;
            }
            SelectData();
            businessTripGrid.Focus();
        }

        private string dateStart, dateEnd;
        private void SelectData()
        {
            dateStart = "01." + (monthBeginCBox.SelectedIndex + 1) + "." + yearBeginCBox.Text;
            dateEnd = DateTime.DaysInMonth(int.Parse(yearEndCBox.Text), monthEndCBox.SelectedIndex + 1) + "." + (monthEndCBox.SelectedIndex + 1) + "." + yearEndCBox.Text;

            DataModule.AccountingDS.Tables["BusinessTrip_Payments"].Rows.Clear();
            DataModule.DataAdapter["BusinessTrip_Payments"].SelectCommand.Parameters["Begin_Date"].Value = dateStart;
            DataModule.DataAdapter["BusinessTrip_Payments"].SelectCommand.Parameters["End_Date"].Value = dateEnd;
            DataModule.DataAdapter["BusinessTrip_Payments"].Fill(DataModule.AccountingDS,"BusinessTrip_Payments");

        }

        private void businessTripsFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFm.businessTripBtn.Enabled = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenBusinessTripAddEditFm(true);
            SelectData();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (businessTripBS.Count > 0)
            {
                OpenBusinessTripAddEditFm(false);

            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DeleteBusinessTripRecord();
        }

        private void DeleteBusinessTripRecord()
        {
            if (businessTripBS.Count != 0 && MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int Pos = businessTripBS.Position;
                try
                {
                    businessTripBS.RemoveCurrent();
                    DataModule.DataAdapter["BusinessTrip_Payments"].Update(DataModule.AccountingDS.Tables["BusinessTrip_Payments"]);
                }
                catch (FbException Excpt)
                {
                    DataModule.AccountingDS.Tables["BusinessTrip_Payments"].RejectChanges();
                    businessTripBS.Position = Pos;
                    MessageBox.Show(DataModule.GetError(Excpt), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private int Position;
        private bool Inserting;
        
        private void OpenBusinessTripAddEditFm(bool inserting)
        {
            Inserting = inserting;

            Cursor = Cursors.WaitCursor;

            businessTripAddEditFm businessTripAddEditFm;
            if (inserting)
            {
                
                Position = DataModule.AccountingDS.Tables["BusinessTrip_Payments"].Rows.Count;
                businessTripAddEditFm = new businessTripAddEditFm(true);
            }
            else
            {
                businessTripAddEditFm = new businessTripAddEditFm(false, businessTripBS.Position);
            }

            //businessTripAddEditFm.businessTripAddEditFm.MdiParent = Program.MainFm;
            businessTripAddEditFm.ShowDialog();
            Cursor = Cursors.Default;           
        }

        private void businessTripView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (businessTripBS.Count > 0 && e.Button == MouseButtons.Left && e.Clicks == 2 && e.RowHandle > -1)
                OpenBusinessTripAddEditFm(false);
        }

   }
}
