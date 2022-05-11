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
    public partial class contractorsEditFm : Form
    {
        private bool _inserting;
        private int _contractor_Id;
        
        private BindingSource contractorsBS = new BindingSource();
        
        public contractorsEditFm(bool inserting, int position = -1, int contractor_Id = -1)
        {
            InitializeComponent();

            _inserting = inserting;
            _contractor_Id = _inserting ? -1 : contractor_Id;

            contractorsBS.DataSource = DataModule.AccountingDS.Tables["Contractors"];
            
            if (_inserting)
            {
                DataRow Row;
                Row = DataModule.AccountingDS.Tables["Contractors"].NewRow();
                DataModule.AccountingDS.Tables["Contractors"].Rows.Add(Row);
                contractorsBS.MoveLast();
            }
            else
            {
                contractorsBS.Position = position;
            }

            contractorNameTBox.DataBindings.Add("Text", contractorsBS, "Name");
            contractorSrnTBox.DataBindings.Add("Text", contractorsBS, "Srn");
            contractorTinTBox.DataBindings.Add("Text", contractorsBS, "Tin");
        
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (contractorNameTBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Введіть найменування постачальника.", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveContractor()) return;

                this.Close();
            }
            else
            {
                return;
            }
            this.Close();
        }

        private bool SaveContractor()
        {
            bool result = false;

            #region Validation

            string outputWarning = "";

            outputWarning += (contractorNameTBox.Text.Trim().Length == 0) ? "Не указано наименование контрагента r \n" : "";
           
            #endregion

            if (outputWarning.Length != 0)
            {
                MessageBox.Show(outputWarning, "Недостатньо данних для виконання операції", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = false;
            }
            else
            {
                contractorsBS.EndEdit();

                DataModule.Connection.Open();
                DataModule.BeginTransaction();

                DataModule.DataAdapter["Contractors"].InsertCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["Contractors"].UpdateCommand.Transaction = DataModule.Transaction;
                
                try
                {
                    DataModule.DataAdapter["Contractors"].Update(DataModule.AccountingDS.Tables["Contractors"]);

                    _contractor_Id = (_inserting)
                                ? (int)DataModule.DataAdapter["Contractors"].InsertCommand.Parameters["Id"].Value
                                : (int)((DataRowView)contractorsBS.Current)["Id"];
                    
                    DataModule.CommitTransaction();

                    result = true;
                }
                catch (FbException FbEcpt)
                {
                    if (FbEcpt.SQLSTATE == "08006")
                    {
                        if (DataModule.Transaction != null)
                            DataModule.DisposeTransaction();
                    }
                    else
                    {
                        DataModule.RollbackTransaction();
                    }
                    MessageBox.Show(DataModule.GetError(FbEcpt), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    result = false;
                }
                finally
                {
                    Cursor = Cursors.Default;
                    DataModule.Connection.Close();
                }

            }

            return result;

        }

        public int Return()
        {
            return _contractor_Id;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contractorNameTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                contractorSrnTBox.Focus();
        }

        private void contractorSrnTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.OnlyNumbers(e);
            if (e.KeyChar == (char)Keys.Enter)
                contractorTinTBox.Focus();
        }

        private void contractorTinTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.OnlyNumbers(e);
            if (e.KeyChar == (char)Keys.Enter)
                okBtn.Focus();
        }

        

    }
}
