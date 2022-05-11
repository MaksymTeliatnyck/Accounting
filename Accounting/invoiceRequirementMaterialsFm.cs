using DevExpress.Data.Filtering;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class invoiceRequirementMaterialsFm : Form
    {
        private Reports Report; 
        private string _StartDate, _EndDate;
        private BindingSource invoiceRequirementMaterialsBS = new BindingSource();

        public invoiceRequirementMaterialsFm(string StartDate, string EndDate)
        {
            InitializeComponent();
            Report = new Reports();
            _StartDate = StartDate;
            _EndDate = EndDate;
            this.Width = 95 * Program.MainFm.MainFmWidth / 100;
            this.Height = 95 * Program.MainFm.MainFmHeight / 100;
           
            FbParameter[] Parameters =
            {
                new FbParameter("BeginDate", StartDate),
                new FbParameter("EndDate", EndDate),
            };

            invoiceRequirementMaterialsBS.DataSource = DataModule.ExecuteFillProc("GetInvoicesForFixedAssets", Parameters);
            invoiceRequirementMaterialsGrid.DataSource = invoiceRequirementMaterialsBS;
            invoiceRequirementMaterialsGridView.BeginSummaryUpdate();
            invoiceRequirementMaterialsGridView.EndSummaryUpdate();
        }
        
        private void printBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            CriteriaOperator op = invoiceRequirementMaterialsGridView.ActiveFilterCriteria;
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);

            DataView dv = new DataView((DataTable)invoiceRequirementMaterialsBS.DataSource);
            dv.RowFilter = filterString;
            
            Report.InvoicesForFixedAssets(dv.ToTable(), _StartDate, _EndDate);

            Cursor = Cursors.Default;
        }
  }
}

