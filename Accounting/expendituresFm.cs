using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Drawing;

namespace Accounting
{
    public partial class expendituresFm : Form
    {
        private enum ExpendTypes { ExpendByQuantity, ExpendByPrice };
        private ExpendTypes expendType;

        private DataTable remainsTable = new DataTable();
        private BindingSource remainsBS = new BindingSource();

        private ErrorProvider errorProvider = new ErrorProvider();

        public expendituresFm()
        {
            InitializeComponent();

            remainsGrid.AutoGenerateColumns = false;
            Utils.SetDoubleBuffered(remainsGrid, true);
            
            remainsBS.DataSource = remainsTable;
            remainsGrid.DataSource = remainsBS;

            creditCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            creditCBox.DisplayMember = "Num";
            creditCBox.ValueMember = "Id";
            creditCBox.SelectedIndex = -1;

            expDTPicker.Value = Convert.ToDateTime(Properties.Settings.Default.ExpDate);

            errorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
        }

        private void expenditureBtn_Click(object sender, EventArgs e)
        {
            #region EnterChecking

            DateTime operationDate = expDTPicker.Value;
            if (Periods.CheckPeriodState(operationDate.Year, operationDate.Month) != true)
            {
                MessageBox.Show("Данный период закрыт или не добавлен!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nomenclatureTBox.Text.Length == 0 || quantityTBox.Text.Length == 0 || sumTBox.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToDecimal(sumTBox.Text) == 0.00m)
            {
                if (MessageBox.Show("Указана нулевая сумма, продолжить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    quantityTBox.Text = "";
                    quantityTBox.Focus();
                    return;
                }
            }

            if (Convert.ToDecimal(quantityTBox.Text) == 0.000m)
            {
                if (MessageBox.Show("Указано нулевое количество, продолжить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    quantityTBox.Text = "";
                    quantityTBox.Focus();
                    return;
                }
            }

            if (creditCBox.SelectedValue == null)
            {
                MessageBox.Show("Такого счёта нет в базе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #endregion EnterChecking

            if (expendType == ExpendTypes.ExpendByQuantity)
            {
                if (expQuantity > Convert.ToDecimal(Utils.GetRow(remainsGrid)["Remains_Quantity"]))
                {
                    MessageBox.Show("Недостаточно материала!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    quantityTBox.Text = "";
                    quantityTBox.Focus();
                    return;
                }
            }
            else
            {
                if (expPrice > Convert.ToDecimal(Utils.GetRow(remainsGrid)["Remains_Sum"]))
                {
                    MessageBox.Show("Недостаточная сумма!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sumTBox.Text = "";
                    sumTBox.Focus();
                    return;
                }
            }

            if (projectTBox.Text.Trim().Length == 0)
            {
                if (MessageBox.Show("Не указан проект, продолжить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (creditCBox.Text == "23")
                {
                    MessageBox.Show("Указан 23й счёт при списании без проекта!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (creditCBox.Text != "23")
                {
                    MessageBox.Show("Указан не 23й счёт при списании по проекту!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            FbParameter[] Expenditures_Parameters =
                {
                    new FbParameter("Receipt_Id", (Utils.GetRow(remainsGrid))["Receipt_Id"]),
                    new FbParameter("Quantity", expQuantity),
                    new FbParameter("Price", expPrice),
                    new FbParameter("Exp_Date", expDTPicker.Value),
                    new FbParameter("Project_Num", projectTBox.Text.Length == 0 ? "0" : projectTBox.Text.Trim()),
                    new FbParameter("Credit_Account_Id", creditCBox.SelectedValue) 
                };

            DataModule.Connection.Open();
            
            int expen_id = (int)DataModule.ExecuteScalar
                (
                    @"INSERT INTO
                        Expenditures_Accountant(Receipt_Id, Quantity, Price, Exp_Date, Project_Num, Credit_Account_Id)
                    VALUES
                        (@Receipt_Id, @Quantity, @Price, @Exp_Date, @Project_Num, @Credit_Account_Id) RETURNING ID;", 
                    Expenditures_Parameters
                );

            FbParameter[] Invoice_Parameters =
                {
                    new FbParameter("Receipt_Id", (Utils.GetRow(remainsGrid))["Receipt_Id"]),
                    new FbParameter("Quantity", expQuantity),
                    new FbParameter("Credit_Account_Id", creditCBox.SelectedValue),
                    new FbParameter("Expenditures_Id", expen_id) 
                };

            DataModule.ExecuteNonQuery
                (
                    @"Update ""Invoice_Requirement_Materials""
                    SET ""Invoice_Requirement_Materials"".""Credit_Account_Id"" = @Credit_Account_Id,
                        ""Invoice_Requirement_Materials"".""Expenditures_Id"" = @Expenditures_Id    
                    WHERE 
                          ""Invoice_Requirement_Materials"".""Expenditures_Id"" IS NULL AND
                          ""Invoice_Requirement_Materials"".""Receipt_Id"" = @Receipt_Id AND
                          ""Invoice_Requirement_Materials"".""Required_Quantity"" = @Quantity;",
                    Invoice_Parameters
                );
            Properties.Settings.Default.ExpDate = expDTPicker.Value.ToShortDateString();
            Properties.Settings.Default.Save();

            FbParameter[] Parameters1 =
                {
                    new FbParameter("Nomenclature", nomenclatureTBox.Tag),
                    new FbParameter("StartDate", expDTPicker.Value.ToShortDateString())
                };

            remainsTable = DataModule.ExecuteFill(DataModule.Queries["RemainsAccountant"], Parameters1);
            DataModule.Connection.Close();

            remainsBS.DataSource = remainsTable;
            remainsGrid.DataSource = remainsBS;

            //
            quantityExpSum += expQuantity;
            totalExpPrice += expPrice;
            quantityExpSumTBox.Text = quantityExpSum.ToString("N", Utils.NumFormat(4));
            totalExpPriceTBox.Text = Math.Round(totalExpPrice, 2).ToString("N", Utils.NumFormat(2));
            //

            if (projectTBox.Text.Length == 0)
                creditCBox.SelectedIndex = -1;
            quantityTBox.Text = "";
            sumTBox.Text = "";

            if (remainsTable.Rows.Count != 0)
            {
                if (expendType == ExpendTypes.ExpendByQuantity)
                    quantityTBox.Focus();
                else
                    sumTBox.Focus();
            }
            else
            {
                nomenclatureTBox.Text = "";
                nomenclNameTBox.Text = "";
                measureTBox.Text = "";
                balanceTBox.Text = "";
                quantityTBox.Text = "";
                quantitySumTBox.Text = "";
                priceSumTBox.Text = "";

                quantityTBox.ReadOnly = true;
                sumTBox.ReadOnly = true;

                quantityRButton.Checked = false;
                sumRButton.Checked = false;
                quantityRButton.Enabled = false;
                sumRButton.Enabled = false;

                nomenclatureTBox.Focus();
            }
        }

        private decimal quantityExpSum = 0.000m;
        private decimal totalExpPrice = 0.00m;

        private void CheckRemains()
        {
            errorProvider.Clear();
            remainsTable.Rows.Clear();

            nomenclNameTBox.Text = "";
            measureTBox.Text = "";
            balanceTBox.Text = "";
            quantityTBox.Text = "";
            quantitySumTBox.Text = "";
            priceSumTBox.Text = "";
            sumTBox.Text = "";

            quantityExpSum = 0.000m;
            totalExpPrice = 0.00m;
            quantityExpSumTBox.Text = "";
            totalExpPriceTBox.Text = "";

            DataTable NomenclTable = DataModule.ExecuteFill
                (
                    @"SELECT
                        Nomenclatures.Id, Nomenclatures.Name, Nomenclatures.Measure, Accounts.Num
                    FROM
                        Nomenclatures, Accounts
                    WHERE
                        Nomenclatures.Balance_Account_Id = Accounts.Id AND
                        Nomenclature = @Nomenclature;",
                    new FbParameter("Nomenclature", nomenclatureTBox.Text)
                );
            if (NomenclTable.Rows.Count != 0)
            {
                nomenclatureTBox.Tag = NomenclTable.Rows[0]["Id"].ToString();
                nomenclNameTBox.Text = NomenclTable.Rows[0]["Name"].ToString();
                measureTBox.Text = NomenclTable.Rows[0]["Measure"].ToString();
                balanceTBox.Text = NomenclTable.Rows[0]["Num"].ToString();
            }
            else
            {
                sumRButton.Enabled = false;
                quantityRButton.Enabled = false;
                quantityRButton.Checked = false;
                sumRButton.Checked = false;

                quantityTBox.ReadOnly = true;
                sumTBox.ReadOnly = true;

                MessageBox.Show("Такой номенклатуры нет в базе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nomenclatureTBox.Text = "";
                return;
            }

            FbParameter[] Parameters =
                {
                    new FbParameter("Nomenclature", nomenclatureTBox.Tag),
                    new FbParameter("StartDate", expDTPicker.Value.ToShortDateString())
                };

            remainsTable = DataModule.ExecuteFill(DataModule.Queries["RemainsAccountant"], Parameters);
            remainsBS.DataSource = remainsTable;
            remainsGrid.DataSource = remainsBS;

            if (remainsTable.Rows.Count != 0)
            {
                sumRButton.Enabled = true;
                quantityRButton.Enabled = true;
                if (nomenclatureTBox.Text == "151000" || nomenclatureTBox.Text == "282000")
                {
                    expendType = ExpendTypes.ExpendByPrice;
                    quantityTBox.ReadOnly = true;
                    quantityRButton.Checked = false;
                    sumTBox.ReadOnly = false;
                    sumRButton.Checked = true;
                    sumTBox.Focus();
                }
                else
                {
                    expendType = ExpendTypes.ExpendByQuantity;
                    sumTBox.ReadOnly = true;
                    sumRButton.Checked = false;
                    quantityTBox.ReadOnly = false;
                    quantityRButton.Checked = true;
                    quantityTBox.Focus();
                }
            }
            else
            {
                sumRButton.Enabled = false;
                quantityRButton.Enabled = false;
                quantityRButton.Checked = false;
                sumRButton.Checked = false;

                quantityTBox.ReadOnly = true;
                sumTBox.ReadOnly = true;
                
                MessageBox.Show("Материал полностью израсходован!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nomenclatureTBox.Text = "";
                nomenclNameTBox.Text = "";
                measureTBox.Text = "";
                balanceTBox.Text = "";
                nomenclatureTBox.Focus();
            }
        }

        private decimal expQuantity = 0.000m;
        private decimal expPrice = 0.00m;
        private void Calculate()
        {
            if (remainsTable.Rows.Count != 0)
            {
                decimal Quantity = Convert.ToDecimal(quantityTBox.Text.Length == 0 ? "0,000" : quantityTBox.Text.Replace('.', ','));
                decimal Price = Convert.ToDecimal(sumTBox.Text.Length == 0 ? "0,00" : sumTBox.Text.Replace('.', ','));

                DataRow Row = Utils.GetRow(remainsGrid);

                switch (expendType)
                {
                    case ExpendTypes.ExpendByQuantity:
                        decimal RemainsQuantity = Convert.ToDecimal(Row["Remains_Quantity"]);
                        if (Quantity == RemainsQuantity)
                        {
                            expPrice = Convert.ToDecimal(Row["Remains_Sum"]);
                            sumTBox.Text = Math.Round(expPrice, 2).ToString("N", Utils.NumFormat(2));

                            expQuantity = Quantity;
                        }
                        else
                        {
                            expPrice = Quantity * Convert.ToDecimal(Row["Unit_Price"]);
                            sumTBox.Text = quantityTBox.Text.Length == 0 ? "" : Math.Round(expPrice, 2).ToString("N", Utils.NumFormat(2));

                            expQuantity = Quantity;
                        }

                        if (Quantity > RemainsQuantity)
                            errorProvider.SetError(quantityTBox, "Недостаточное количество!");
                        else
                            errorProvider.Clear();
                    break;
                    case ExpendTypes.ExpendByPrice:
                        decimal RemainsSum = Convert.ToDecimal(Row["Remains_Sum"]); 
                        if (Price == RemainsSum)
                        {
                            expQuantity = Convert.ToDecimal(Row["Remains_Quantity"]);
                            quantityTBox.Text = expQuantity.ToString("N", Utils.NumFormat(4));

                            expPrice = Price;
                        }
                        else
                        {
                            if (Price == 0.00m)
                            {
                                expQuantity = 0.000m;
                                quantityTBox.Text = "";
                            }
                            else
                            {
                                expQuantity = 0.001m;
                                quantityTBox.Text = "0,001";
                            }

                            expPrice = Price;
                        }

                        if (Price > Convert.ToDecimal(Row["Remains_Sum"]))
                            errorProvider.SetError(quantityTBox, "Недостаточная сумма!");
                        else
                            errorProvider.Clear();
                    break;
                }
            }
        }

        private void remainsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (remainsTable.Rows.Count > 0 && e.RowIndex != -1)
            {
                if (expendType == ExpendTypes.ExpendByQuantity)
                    quantityTBox.Text = remainsGrid.CurrentRow.Cells["RemainsQuantityColumn"].Value.ToString().ToString(Utils.NumFormat(4));
                else
                    sumTBox.Text = Math.Round(Convert.ToDecimal(remainsGrid.CurrentRow.Cells["RemainsSumColumn"].Value), 2).ToString(Utils.NumFormat(2));

                Calculate();
                creditCBox.Focus();
            }
        }

        private void remainsGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double quantitySum = 0.000;
            double priceSum = 0.00;
            foreach (DataRow Row in remainsTable.Rows)
            {
                quantitySum += Convert.ToDouble(Row["Remains_Quantity"]);
                priceSum += Convert.ToDouble(Row["Remains_Sum"]);
            }
            quantitySumTBox.Text = quantitySum.ToString("N", Utils.NumFormat(4));
            priceSumTBox.Text = Math.Round(priceSum, 2).ToString("N", Utils.NumFormat(2));
        }

        //------------------------------------------------------------------------------------------------------------------
        #region FocusMoving

        private void projectTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                expDTPicker.Focus();
            }
        }

        private void expDTPicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                nomenclatureTBox.Focus();
            }
        }

        private void nomenclatureTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.OnlyNumbers(e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (quantityTBox.Text.Length != 0 && sumTBox.Text.Length != 0)
                    if (MessageBox.Show("Вы не провели списание, продолжить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                CheckRemains();
            }
        }

        private void quantityTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.EnterCheck(sender, e, 6, 4, true);

            if (e.KeyChar == (char)Keys.Enter)
            {
                creditCBox.Focus();
            }
            a = false;
        }

        private void sumTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.EnterCheck(sender, e, 9, 2);

            if (e.KeyChar == (char)Keys.Enter)
            {
                creditCBox.Focus();
            }
            a = false;
        }

        private bool a;
        private void creditCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (a)
                    expenditureBtn.Focus();
                a = true;
            }
        }

        private void personCBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                expenditureBtn.Focus();
            }
        }

        #endregion FocusMoving

        //------------------------------------------------------------------------------------------------------------------
        #region Dictionaries

        private void openAccountsRBFm_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            accountsRBFm accountsRBFm = new accountsRBFm();
            accountsRBFm.ShowDialog();
            creditCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            creditCBox.SelectedIndex = -1;
            creditCBox.Focus();
            Cursor = Cursors.Default;
        }

        #endregion Dictionaries

        private void quantityTBox_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void sumTBox_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void remainsGrid_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void nomenclNameTBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(nomenclNameTBox, nomenclNameTBox.Text);
        }

        private void projectTBox_TextChanged(object sender, EventArgs e)
        {
            if (projectTBox.Text.Length != 0)
                creditCBox.Text = "23";
            else
                creditCBox.SelectedIndex = -1;
        }

        private void quantityRButton_CheckedChanged(object sender, EventArgs e)
        {
            if (nomenclatureTBox.Tag != null && quantityRButton.Checked)
            {
                expendType = ExpendTypes.ExpendByQuantity;

                sumTBox.ReadOnly = true;
                quantityTBox.Text = "";
                quantityTBox.ReadOnly = false;
                quantityTBox.Focus();
            }
        }

        private void sumRButton_CheckedChanged(object sender, EventArgs e)
        {
            if (nomenclatureTBox.Tag != null && sumRButton.Checked)
            {
                expendType = ExpendTypes.ExpendByPrice;

                quantityTBox.ReadOnly = true;
                sumTBox.Text = "";
                sumTBox.ReadOnly = false;
                sumTBox.Focus();
            }
        }

        private void expEditBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            expendituresEditFm editExpendituresFm = new expendituresEditFm();
            editExpendituresFm.MdiParent = Program.MainFm;
            editExpendituresFm.Show();
            Cursor = Cursors.Default;
        }

        private void expendituresFm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (quantityTBox.Text.Length != 0 && sumTBox.Text.Length != 0)
                if (MessageBox.Show("Вы не провели списание, продолжить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
        }

        private void accountantExpFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFm.expendituresBtn.Enabled = true;
        }

    }
}
