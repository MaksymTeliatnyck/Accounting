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
    public partial class expendituresForFixedAssetsFm : Form
    {
        private DataTable ExpendituresForFixedAssetsTable = new DataTable();
        private BindingSource ExpendituresForFixedAssetsBS = new BindingSource();
    
        public static int SelectId { private set; get; }

        public expendituresForFixedAssetsFm(DateTime startDate)
        {
            InitializeComponent();

            // значение по умолчанию для даты формирования остатков
            if (startDate==default(DateTime)){
                startDate = DateTime.Now;
            }
            expStartDateDTP.Value = Convert.ToDateTime("01." + startDate.Month.ToString() + "." + startDate.Year.ToString());
            expEndDateDTP.Value = DateTime.Now;

            LoadRemainsTheDate();
        }

        private void LoadRemainsTheDate()
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("StartDate", expStartDateDTP.Value.ToShortDateString()),
                    new FbParameter("EndDate", expEndDateDTP.Value.ToShortDateString())
                };

            ExpendituresForFixedAssetsTable = DataModule.ExecuteFill(DataModule.Queries["ExpendituresForFixedAssets"], Parameters);
            ExpendituresForFixedAssetsBS.DataSource = ExpendituresForFixedAssetsTable;
            ExpendituresForFixedAssetsGrid.DataSource = ExpendituresForFixedAssetsBS;
        }

        private void viewSelectDateBtn_Click(object sender, EventArgs e)
        {
            LoadRemainsTheDate();
        }

        private void ExpendituresForFixedAssetsView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2 && e.RowHandle > -1)
            {
                if (((DataRowView)ExpendituresForFixedAssetsBS.Current)["Id"] != DBNull.Value)
                    this.DialogResult = DialogResult.OK;
            }
            
        }

        public DataRow Return()
        {
            return ((DataRowView)ExpendituresForFixedAssetsBS.Current).Row;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
