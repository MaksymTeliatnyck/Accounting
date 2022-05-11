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
    public partial class expendituresSingleEditFm : Form
    {
        private BindingSource expendBS = new BindingSource();
        
        public expendituresSingleEditFm(int position)
        {
            InitializeComponent();

            expDTPicker.EditValue = DateTime.Now;

            expendBS.DataSource = DataModule.AccountingDS.Tables["Expenditures"];
            expendBS.Position = position;

            creditCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            creditCBox.DisplayMember = "Num";
            creditCBox.ValueMember = "Id";
            creditCBox.DataBindings.Add("Text", expendBS, "Credit_Account_Num");
            creditCBox.DataBindings.Add("SelectedValue", expendBS, "Credit_Account_Id");

            projectTBox.DataBindings.Add("Text", expendBS, "Project_Num");
            expDTPicker.DataBindings.Add("EditValue", expendBS, "Exp_Date");
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DataModule.AccountingDS.Tables["Expenditures"].RejectChanges();
            this.Close();
            
            DialogResult = DialogResult.Cancel;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
                if (projectTBox.Text.Trim().Length == 0 || projectTBox.Text == "0")
                {
                    if (MessageBox.Show("Номер проекту не вказаний, продовжити?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    if ((creditCBox.Text == "23")&&(creditCBox.Text != "473"))
                    {
                        MessageBox.Show("Указан " + creditCBox.Text + "счёт при списании без проекта!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    if ((creditCBox.Text != "23")&&(creditCBox.Text != "473"))
                    {
                        MessageBox.Show("Указан не 23й или 943й счёт при списании по проекту!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                expendBS.EndEdit();

                try
                {
                    #region Find and delete expenditure from "FixedAssets" and "InvoiceRequirement"

                    DataRowView selectROW = ((DataRowView)expendBS.Current);
                    int idRow = Convert.ToInt32(selectROW["ID"]);
                    int newCREDIT_ACCOUNT_ID = (short)selectROW["CREDIT_ACCOUNT_ID"];
                    DateTime newEXP_DATE = (DateTime)selectROW["EXP_DATE"];

                    DataModule.Connection.Open();

                    DataTable activRowInTable = DataModule.ExecuteFill("SELECT * FROM EXPENDITURES_ACCOUNTANT WHERE ID =" + idRow);//CREDIT_ACCOUNT_ID, EXP_DATE
                    DataRow activRow = activRowInTable.Rows[0];
                    int activCREDIT_ACCOUNT_ID = (short)activRow["CREDIT_ACCOUNT_ID"];
                    DateTime activEXP_DATE = (DateTime)activRow["EXP_DATE"];

                    int countInFixedAssetsMaterials = (int)DataModule.ExecuteScalar("SELECT COUNT(\"Id\") FROM \"FixedAssetsMaterials\" WHERE \"Expenditures_Id\" = " + idRow);
                    int countInInvoice_Requirement_Materials = (int)DataModule.ExecuteScalar("SELECT COUNT(\"Id\") FROM \"Invoice_Requirement_Materials\" WHERE \"Expenditures_Id\" =" + idRow);

                    DataModule.Connection.Close();

                    var isFixedAssetsMaterialsFound = (countInFixedAssetsMaterials != 0) ? ((activCREDIT_ACCOUNT_ID != newCREDIT_ACCOUNT_ID) || (activEXP_DATE != newEXP_DATE)) : false;
                    var isInvoice_Requirement_MaterialsFound = (countInInvoice_Requirement_Materials != 0) ? ((activCREDIT_ACCOUNT_ID != newCREDIT_ACCOUNT_ID)) : false;

                    if (isFixedAssetsMaterialsFound)
                    {
                        MessageBox.Show("Редагування відмінено! \nМатеріал знаходиться на обліку в основних засобах. Спочатку треба видалити матеріал з облікової карточки основного засобу.", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (isInvoice_Requirement_MaterialsFound)
                    {
                        if (MessageBox.Show("Увага! \nМатеріал знаходиться у вимогах. Бажаєте зберегти зміни?", "Збереження", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            try
                            {
                                DataModule.Connection.Open();
                                DataModule.BeginTransaction();
                                DataModule.ExecuteNonQuery("UPDATE \"Invoice_Requirement_Materials\" SET \"Credit_Account_Id\" = " + newCREDIT_ACCOUNT_ID + " WHERE \"Expenditures_Id\" =" + idRow);
                                DataModule.CommitTransaction();
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
                                MessageBox.Show(DataModule.GetError(FbEcpt), "Помилка при збереженні. Дію відмінено.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            finally
                            {
                                Cursor = Cursors.Default;
                                DataModule.Connection.Close();
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    #endregion

                    DataModule.Connection.Open();
                    DataModule.BeginTransaction();

                    DataModule.DataAdapter["Expenditures"].UpdateCommand.Transaction = DataModule.Transaction;

                    try
                    {
                        DataModule.DataAdapter["Expenditures"].Update(DataModule.AccountingDS.Tables["Expenditures"]);
                        DataModule.CommitTransaction();

                        DialogResult = DialogResult.OK;
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
                        MessageBox.Show(DataModule.GetError(FbEcpt), "Помилка при збереженні. Дію відмінено.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        DataModule.Connection.Close();
                    }

                    if (((Button)sender).Name == "okBtn")
                        this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка при роботі з базою даних", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                    
        }

        #region FocusMoving

        bool a;
        private void projectTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                expDTPicker.Focus();
        }

        private void expDTPicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                a = false;
                creditCBox.Focus();
            }
        }

        private void creditCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (a)
                    okBtn.Focus();
                a = true;
            }
        }

        #endregion FocusMoving

    }
}
