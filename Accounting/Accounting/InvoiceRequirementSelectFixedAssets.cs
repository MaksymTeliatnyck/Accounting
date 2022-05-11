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
    public partial class InvoiceRequirementSelectFixedAssets : Form
    {
        public Boolean? isSetData { get; set; }
        public int SelectId { get; set; }
        public String SelectInventoryNumber { get; set; }
        public String SelectInventoryName { get; set; }

        public InvoiceRequirementSelectFixedAssets()
        {
            InitializeComponent();
            
            gridFixedAssetsOrder.DataSource = DataModule.ExecuteFill(DataModule.Queries["InvoiceRequirementSelectFixedAssets"], new FbParameter());
            //isSetData = false;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }


        private void gridViewFixedAssetsOrder_DoubleClick(object sender, EventArgs e)
        {
           var rowData =  gridViewFixedAssetsOrder.GetDataRow(gridViewFixedAssetsOrder.FocusedRowHandle);
           SelectInventoryNumber = (string)rowData["InventoryNumber"];
           SelectInventoryName = (string)rowData["InventoryName"];
           SelectId = (int)rowData["Id"];
           isSetData = true;
           DialogResult = System.Windows.Forms.DialogResult.OK;
           this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            isSetData = null;
            this.Close();
        }
    }
}
