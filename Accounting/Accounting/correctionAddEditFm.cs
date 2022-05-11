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
    public partial class correctionAddEditFm : Form
    {
        private bool _inserting;
        private int _order_id;
                
        private BindingSource fixedCorrectionsBS = new BindingSource();

        public correctionAddEditFm(bool inserting, int position = -1, int order_id = -1, DataTable fixedCorrectionTable = null)
        {
            InitializeComponent();
            
            _inserting = inserting;
            _order_id = order_id;

            fixedCorrectionsBS.DataSource = fixedCorrectionTable;
            fixedCorrectionsBS.Position = position;

            short accountId = (short)((DataRowView)fixedCorrectionsBS.Current)["Fixed_Account_Id"];
            string accountNum = (string)((DataRowView)fixedCorrectionsBS.Current)["Fixed_Num"];

            if (_inserting)
            {
                DataRow Row;
                Row = fixedCorrectionTable.NewRow();
                Row["FixedAssetsOrder_Id"] = _order_id;
                Row["Fixed_Account_Id"] = accountId;
                Row["Fixed_Num"] = accountNum;
                Row["Flag"] = 2;
                Row["FixedPrice"] = 0;
                fixedCorrectionTable.Rows.Add(Row);
                fixedCorrectionsBS.MoveLast();
            }
            else
            {
                IncreaseValueChBox.Checked = (((short)((DataRowView)fixedCorrectionsBS.Current)["Flag"]) == 1) ? true : false;
            }
           
            #region Binding's

            correctionTBox.DataBindings.Add("Text", fixedCorrectionsBS, "Description");
            correctionPriceTBox.DataBindings.Add("Text", fixedCorrectionsBS, "FixedPrice");
            correctionDatePicker.DataBindings.Add("EditValue", fixedCorrectionsBS, "MaterialsDate");

            #endregion

        }

        #region Events

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                 #region Validation

                string outputWarning = "";

                outputWarning += ((correctionDatePicker.EditValue).ToString().Length == 0) ? "Не указана дата корректировки \n" : "";
                outputWarning += (decimal.Parse(correctionPriceTBox.Text) == 0) ? "Не указана сумма \n" : "";
            
                #endregion

                if (outputWarning.Length != 0)
                {
                    MessageBox.Show(outputWarning, "Недостаточно данных для сохранения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DataRowView currentRow = (DataRowView)fixedCorrectionsBS.Current;
                    currentRow["Name"] = currentRow["Description"];
                    currentRow["Exp_Date"] = currentRow["MaterialsDate"];
                    currentRow["Flag"] = IncreaseValueChBox.Checked?1:2;
                    fixedCorrectionsBS.EndEdit();
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (_inserting)
                fixedCorrectionsBS.RemoveCurrent();
            this.Close();
        }

        private void correctionPriceTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.EnterCheck(correctionPriceTBox, e, 12, 2, false, false);
        }

        #endregion
    }
}
