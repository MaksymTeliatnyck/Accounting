using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
    public partial class nomenclatureEditFm : Form
    {
        private int _nomenclatureId;
        private bool _inserting;

        private BindingSource nomenclaturesBS = new BindingSource();

        public nomenclatureEditFm(bool inserting, int position = -1, int contractor_Id = -1)
        {
            InitializeComponent();

            _inserting = inserting;
            _nomenclatureId = _inserting ? -1 : contractor_Id;

            generateChkBox.Visible = _inserting;

            nomenclaturesBS.DataSource = DataModule.AccountingDS.Tables["Nomenclatures"];

            if (_inserting)
            {
                DataRow Row;
                Row = DataModule.AccountingDS.Tables["Nomenclatures"].NewRow();
                DataModule.AccountingDS.Tables["Nomenclatures"].Rows.Add(Row);
                nomenclaturesBS.MoveLast();
            }
            else
            {
                nomenclaturesBS.Position = position;
            }


            nomenclatureTBox.DataBindings.Add("Text", nomenclaturesBS, "Nomenclature");
            nameTBox.DataBindings.Add("Text", nomenclaturesBS, "Name");
            unitsEdit.DataBindings.Add("EditValue", nomenclaturesBS, "UnitId");
            balanceAccountEdit.DataBindings.Add("EditValue", nomenclaturesBS, "Balance_Account_Id");

            var balanceAccountDataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);

            balanceAccountEdit.Properties.DataSource = balanceAccountDataSource;
            balanceAccountEdit.Properties.ValueMember = "ID";
            balanceAccountEdit.Properties.DisplayMember = "NUM";
            balanceAccountEdit.Properties.NullText = "Немає даних";

            var unitsDataSource = DataModule.ExecuteFill(@"SELECT * FROM ""Units""");

            unitsEdit.Properties.DataSource = unitsDataSource;
            unitsEdit.Properties.ValueMember = "UnitId";
            unitsEdit.Properties.DisplayMember = "UnitLocalName";
            unitsEdit.Properties.NullText = "Немає даних";
        }

        public int Return()
        {
            return _nomenclatureId;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveNomenclature()) return;

                this.Close();

                DialogResult = DialogResult.OK;
            }
            
        }

        private bool SaveNomenclature()
        {
            nomenclaturesBS.EndEdit();

            //валидация данных
            string message = "";

            message += (nomenclatureTBox.Text.Length == 0) ? "Номенклатурний номер \n" : "";
            message += (nameTBox.Text.Length == 0) ? "Найменування \n" : "";
            message += (unitsEdit.Text.Length == 0) ? "Одиниці вимірювання \n" : "";

            if (message.Length != 0)
            {
                MessageBox.Show("Заповнені не всі дані: \n" + message, "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (NomenclatureWrong(balanceAccountEdit.Text, nomenclatureTBox.Text))
            {
                MessageBox.Show("Номенклатурний номер не відповідає балансовому рахунку! \n" + message, "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nomenclatureTBox.Focus();

                return false;            
            }

            if (_inserting && FindDuplicateRecord())
            {
                MessageBox.Show("Такий номенклатурний номер вже існує в базі! \n" + message, "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nomenclatureTBox.Focus();
                return false;
            }
            else
            {
                DataModule.Connection.Open();
                DataModule.BeginTransaction();

                DataModule.DataAdapter["Nomenclatures"].InsertCommand.Transaction = DataModule.Transaction;
                DataModule.DataAdapter["Nomenclatures"].UpdateCommand.Transaction = DataModule.Transaction;
                
                try
                {
                    DataModule.DataAdapter["Nomenclatures"].Update(DataModule.AccountingDS.Tables["Nomenclatures"]);
                    
                    if(_inserting)
                        _nomenclatureId = (int)DataModule.DataAdapter["Nomenclatures"].InsertCommand.Parameters["Id"].Value;
                    
                    DataModule.CommitTransaction();

                    return true;
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
                    return false;
                }
                finally
                {
                    Cursor = Cursors.Default;
                    DataModule.Connection.Close();
                }
            }
            
        }

        private bool NomenclatureWrong(string accountNum, string nomenclature)
        { 
            string replNum = accountNum.Replace("/", "");
            string subNomencl = nomenclature.Substring(0, replNum.Length);
            
            return (replNum != subNomencl);
        }

        private bool FindDuplicateRecord()
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("Nomenclature", ((DataRowView)nomenclaturesBS.Current)["Nomenclature"]),
                    new FbParameter("Id", ((DataRowView)nomenclaturesBS.Current)["Id"])
                };

            DataModule.Connection.Open();

            string queryString = @"SELECT
                                            COUNT(*)
                                        FROM
                                            Nomenclatures n
                                        WHERE
                                            n.Nomenclature = @Nomenclature";
            queryString += (!_inserting) ? @" AND ""CustomerOrders"".""Id"" <> @Id" : "";

            int count = (int)DataModule.ExecuteScalar(queryString, Parameters);
            DataModule.Connection.Close();

            return (count != 0);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void unitsEdit_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        private void balanceAccountEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (generateChkBox.Checked && balanceAccountEdit.EditValue != DBNull.Value)
                nomenclatureTBox.Text = GetNextNumber((short)balanceAccountEdit.EditValue);
        }

        private string GetNextNumber(short accountId)
        {
            DataModule.Connection.Open();

            FbParameter[] Parameters =
                {
                    new FbParameter("AccountId", accountId),
                };

            string queryString = @"SELECT FIRST 1
                                      MAX(CAST(REPLACE(IIF(CHAR_LENGTH(n.NOMENCLATURE) > 0, n.NOMENCLATURE, '0'), '/', '') as INTEGER)) + 1 as NextNumber
                                    FROM
                                     Nomenclatures n
                                    INNER JOIN
                                     Accounts a ON n.BALANCE_ACCOUNT_ID = a.ID
                                    WHERE
                                     a.ID = @AccountId
                                    ORDER BY 1 DESC";
            
            var result = DataModule.ExecuteScalar(queryString, Parameters);
                      
            DataModule.Connection.Close();
            
            string nextNumber = (result != DBNull.Value) ? result.ToString() : balanceAccountEdit.Text.Replace("/", "") + "0000";

            return nextNumber;        
        }
    }
}
