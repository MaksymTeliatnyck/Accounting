using System;
using System.Windows.Forms;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using System.Globalization;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Collections;

namespace Accounting
{
    public partial class reportsFm : Form
    {
        private Reports Report;
        //private DataTable Months = new DataTable();
        private string StartDate, EndDate;

        private DataTable contractorDataSource;

        private class Months 
        {
            public int Id { get; set; }
            public string Description { get; set; }
        };
              
        public reportsFm()
        {
            InitializeComponent();
            Report = new Reports();
        }

        private void reportFm_Load(object sender, EventArgs e)
        {
            contractorsEdit.EditValueChanged -= contractorsEdit_EditValueChanged;

            yearBeginCBox.SelectedIndexChanged -= yearBeginCBox_SelectedIndexChanged;
            yearEndCBox.SelectedIndexChanged -= yearEndCBox_SelectedIndexChanged;

            DataTable datatable = DataModule.ExecuteFill
            (
                @"SELECT DISTINCT 
                    ""Year""
                FROM
                    ""Periods"""
            );

//            DataTable datatable = DataModule.ExecuteFill
//            (
//                @"SELECT DISTINCT
//                    EXTRACT(YEAR FROM Periods.Order_Date) AS ""Year""
//                FROM
//                    Orders
//                WHERE
//                    (Orders.""Flag1"" = 1 OR Orders.""Flag2"" = 1)"
//            );

           // //datatable.Rows.Add(new Object[]{
           // //   "2019"
           //});


            yearBeginCBox.DataSource = datatable;
            yearBeginCBox.DisplayMember = "Year";

            yearEndCBox.DataSource = datatable.Copy();
            yearEndCBox.DisplayMember = "Year";


            yearBeginCBox.Text = Properties.Settings.Default.ReportBeginDate.Year.ToString();
            yearEndCBox.Text = Properties.Settings.Default.ReportEndDate.Year.ToString();

            yearBeginCBox.SelectedIndexChanged += yearBeginCBox_SelectedIndexChanged;
            yearEndCBox.SelectedIndexChanged += yearEndCBox_SelectedIndexChanged;

            monthBeginCBox.SelectedIndexChanged -= monthBeginCBox_SelectedIndexChanged;
            monthEndCBox.SelectedIndexChanged -= monthEndCBox_SelectedIndexChanged;

            var monthSource = GetMonthList();

            contractorDataSource = DataModule.ExecuteFill(@"SELECT * FROM ""Contractors"" ORDER BY ""Name""");

            contractorsEdit.EditValue = DBNull.Value;
            contractorsEdit.Properties.DataSource = contractorDataSource;
            contractorsEdit.Properties.ValueMember = "Id";
            contractorsEdit.Properties.DisplayMember = "Name";
            contractorsEdit.Properties.NullText = "Немає даних";

            monthBeginCBox.DataSource = monthSource;
            monthBeginCBox.DisplayMember = "Description";
            monthBeginCBox.ValueMember = "Id";


            monthEndCBox.BindingContext = new BindingContext();
            monthEndCBox.DataSource = monthSource;
            monthEndCBox.DisplayMember = "Description";
            monthEndCBox.ValueMember = "Id";

            monthBeginCBox.SelectedValue = Properties.Settings.Default.ReportBeginDate.Month;
            monthEndCBox.SelectedValue = Properties.Settings.Default.ReportEndDate.Month;

            monthBeginCBox.SelectedIndexChanged += monthBeginCBox_SelectedIndexChanged;
            monthEndCBox.SelectedIndexChanged += monthEndCBox_SelectedIndexChanged;

            BuildDateString();

            typeCBox_SelectedValueChanged(typeCBox, new EventArgs());   

            supplierCBox.DataSource = DataModule.ExecuteFill(@"SELECT EMPLOYEEID AS ID, FULLNAME AS NAME FROM Responsible where EMPLOYEEID in (select distinct(""Supplier_Id"") from ""FixedAssetsOrder""  where ""Supplier_Id"" is not  null)");
            supplierCBox.ValueMember = "Id";
            supplierCBox.DisplayMember = "Name";
            supplierCBox.SelectedIndex = -1;

            contractorsEdit.EditValueChanged += contractorsEdit_EditValueChanged;
        }

        #region Method's
               
        private List<Months> GetMonthList()
        {
            CultureInfo ci = new CultureInfo("uk-UA");
            DateTimeFormatInfo dtfi = ci.DateTimeFormat;
            
            List<Months> items = new List<Months>();
            
            for (int i = 1; i <= 12; i++)
                items.Add(new Months() { Id = i, Description = i.ToString().PadLeft(2, '0') + " " + dtfi.MonthNames[i - 1] });
            return items;
        }

        private void BuildDateString()
        {
            if (monthEndCBox.Text.Length != 0)
            {
                DateTime _startDate, _endDate;
                
                string strStart = "01." + monthBeginCBox.SelectedValue.ToString() + "." + yearBeginCBox.Text;
                bool parseStart = DateTime.TryParse(strStart, out _startDate);
                StartDate = (parseStart) ? _startDate.ToShortDateString() : DateTime.Now.ToShortDateString();

                int LastDay = DateTime.DaysInMonth(Convert.ToInt32(yearEndCBox.Text), (int)monthEndCBox.SelectedValue);
                string strEnd = LastDay.ToString() + "." + monthEndCBox.SelectedValue + "." + yearEndCBox.Text;
                bool parseEnd = DateTime.TryParse(strEnd, out _endDate);
                EndDate = (parseEnd) ? _endDate.ToShortDateString() : DateTime.Now.ToShortDateString();
            }
        }

        private void SaveLastDate()
        {
            Properties.Settings.Default.ReportBeginDate = Convert.ToDateTime(StartDate);
            Properties.Settings.Default.ReportEndDate = Convert.ToDateTime(EndDate);
            Properties.Settings.Default.Save();
        }

        #endregion Method's

        #region Control event's

        private void yearBeginCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            yearEndCBox.SelectedIndex = yearBeginCBox.SelectedIndex;
            yearEndCBox_SelectedIndexChanged(yearEndCBox, new EventArgs());
        }

        private void monthBeginCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthEndCBox.SelectedIndex = monthBeginCBox.SelectedIndex;
            monthEndCBox_SelectedIndexChanged(monthEndCBox, new EventArgs());
        }

        private void yearEndCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildDateString();
        }

        private void monthEndCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildDateString();
        }

        private bool p1, p2, p3;
        private void reportsTControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "storehouseTabPage1":
                    yearEndCBox.Text = yearBeginCBox.Text;
                    monthEndCBox.Text = monthBeginCBox.Text;
                    break;
                case "storehouseTabPage2":
                    yearEndCBox.Enabled = true;
                    monthEndCBox.Enabled = true;
                    if (!p2)
                    {
                        balanceCBox.DataSource = DataModule.ExecuteFill
                        (
                            @"SELECT DISTINCT
                                Accounts.Id, Accounts.Num
                            FROM
                                Nomenclatures, Accounts
                            WHERE
                                Nomenclatures.Balance_Account_Id = Accounts.Id
                            ORDER BY
                                Accounts.Num;"
                        );
                        balanceCBox.ValueMember = "Id";
                        balanceCBox.DisplayMember = "Num";
                        balanceCBox.SelectedIndex = -1;
                        p2 = true;
                    }
                    break;
                case "tabPage3":
                    yearEndCBox.Enabled = true;
                    monthEndCBox.Enabled = true;
                    break;
            }
        }

        private void modulesTabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //balanceAccountCBox.DataSource = DataModule.ExecuteFill(DataModule.Queries["Accounts"]);
            //balanceAccountCBox.ValueMember = "Id";
            //balanceAccountCBox.DisplayMember = "Num";
            //balanceAccountCBox.SelectedIndex = -1;

            switch (((TabControl)sender).SelectedTab.Name)
            {
                case "bankTabPage":
                    bankAccountCBox.DataSource = DataModule.ExecuteFill(@"SELECT Id, Num FROM Accounts WHERE (Num STARTING '31' OR Num STARTING '60') AND ""Type"" = 1 order by Num");
                    bankAccountCBox.ValueMember = "Id";
                    bankAccountCBox.DisplayMember = "Num";
                    bankAccountCBox.SelectedIndex = -1;
                    break;
                case "calcWithBuyersPage":
                    calcAccountCBox.DataSource = DataModule.ExecuteFill(@"SELECT Id, Num FROM Accounts WHERE Num STARTING '36' AND ""Type"" = 1 order by Num");
                    calcAccountCBox.ValueMember = "Id";
                    calcAccountCBox.DisplayMember = "Num";
                    calcAccountCBox.SelectedIndex = -1;
                    break;
            }
        }

        string Flag1, Flag3, Flag4;
        string PFlag3, PFlag4;
        private void typeCBox_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (typeCBox.Text)
            {
                case "631":
                    Flag1 = "1"; Flag3 = "1"; Flag4 = "-1";
                    PFlag3 = "15"; PFlag4 = "15";
                    break;
                case "63":
                    Flag1 = "-1"; Flag3 = "-1"; Flag4 = "1";
                    PFlag3 = "16"; PFlag4 = "16";
                    break;
                case "631, 63":
                    Flag1 = "1"; Flag3 = "1"; Flag4 = "1";
                    PFlag3 = "15"; PFlag4 = "16";
                    break;
                case "632":
                    Flag1 = "1"; Flag3 = "1"; Flag4 = "1";
                    PFlag3 = "60"; PFlag4 = "60";
                    break;
                case "681":
                    Flag1 = "1"; Flag3 = "1"; Flag4 = "1";
                    PFlag3 = "96"; PFlag4 = "96";
                    break;
                case "39":
                    Flag1 = "1"; Flag3 = "1"; Flag4 = "-1";
                    PFlag3 = "128"; PFlag4 = "128";
                    break;
                case "531":
                    Flag1 = "-1"; Flag3 = "-1"; Flag4 = "-1";
                    PFlag3 = "240"; PFlag4 = "240";
                    break;
            }

            debtorsCreditorsBtn.Enabled = (typeCBox.Text != "681" && typeCBox.Text != "39" && typeCBox.Text != "531");
            paymentsWithoutVatBtn.Enabled = (typeCBox.Text != "632" && typeCBox.Text != "681" && typeCBox.Text != "39" && typeCBox.Text != "531");
            contractorsVatBtn.Enabled = (typeCBox.Text != "632" && typeCBox.Text != "681" && typeCBox.Text != "39" && typeCBox.Text != "531");
            reconciliationBtn.Enabled = (typeCBox.Text != "39" && typeCBox.Text != "531");
            msTrialBalanceBtn.Enabled = (typeCBox.Text != "39" && typeCBox.Text != "531");

            Properties.Settings.Default.Save();

        }

        private void vendorTLBox_TextUpdated(object sender, EventArgs e)
        {
            vendorTLBox.ValueMember = "Id";
            vendorTLBox.DisplayMember = "Name";
            vendorTLBox.DataSource = DataModule.ExecuteFill(@"SELECT * FROM ""Contractors"" WHERE UPPER(""Name"") LIKE '%@Name%'".Replace("@Name", vendorTLBox.Text.Trim().ToUpper()));
        }

        #endregion Control event's

        #region Button click event's

        #region Contractor's tab

        private void msTrialBalanceBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            switch (typeCBox.Text)
            {
                case "632":
                    FbParameter[] Parameters632 =
                    {
                        new FbParameter("StartDate", StartDate),
                        new FbParameter("EndDate", EndDate)
                    };
                    Report.MSTrialBalanceCurrency(DataModule.ExecuteFill(DataModule.Queries["MSTrialBalanceCurrency"], Parameters632), StartDate.Substring(3), EndDate.Substring(3), typeCBox.Text);
                    break;
                case "681":
                    FbParameter[] Parameters681 =
                    {
                        new FbParameter("StartDate", StartDate),
                        new FbParameter("EndDate", EndDate)
                    };
                    Report.MSTrialBalanceCurrency681(DataModule.ExecuteFill(DataModule.Queries["MSTrialBalanceCurrency681"], Parameters681), StartDate.Substring(3), EndDate.Substring(3), typeCBox.Text);
                    break;
                default:
                    FbParameter[] Parameters =
                    {new FbParameter("Start_Date", StartDate),
                        new FbParameter("End_Date", EndDate),
                        new FbParameter("Flag1", Flag1),
                        new FbParameter("Flag3", Flag3),
                        new FbParameter("Flag4", Flag4),
                        new FbParameter("PFlag3", PFlag3),
                        new FbParameter("PFlag4", PFlag4)
                    };
                    Report.MSTrialBalance(DataModule.ExecuteFill(DataModule.Queries["MSTrialBalance"], Parameters), StartDate.Substring(3), EndDate.Substring(3), typeCBox.Text);
                    break;
            }

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void msTrialBalanceByAccountsBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            switch (typeCBox.Text)
            {
                case "632":
                    FbParameter[] Parameters632 =
                    {
                        new FbParameter("StartDate", StartDate),
                        new FbParameter("EndDate", EndDate)
                    };
                    Report.MSTrialBalanceByAccountsCurrency(DataModule.ExecuteFill(DataModule.Queries["MSTrialBalanceByAccountsCurrency"], Parameters632), StartDate.Substring(3), EndDate.Substring(3), typeCBox.Text);
                    break;
                case "681":
                    FbParameter[] Parameters681 =
                    {
                        new FbParameter("StartDate", StartDate),
                        new FbParameter("EndDate", EndDate)
                    };
                    Report.MSTrialBalanceByAccountsCurrency681(DataModule.ExecuteFill(DataModule.Queries["MSTrialBalanceByAccountsCurrency681"], Parameters681), StartDate.Substring(3), EndDate.Substring(3), typeCBox.Text);
                    break;
                case "39":
                    FbParameter[] Parameters39 =
                    {
                        new FbParameter("Start_Date", StartDate),
                        new FbParameter("End_Date", EndDate),
                    };

                    DataTable reportTable = DataModule.ExecuteFillProc("ReportTrialBalanceByAccount39", Parameters39);

                    Report.MSTrialBalanceByAccounts39(reportTable, StartDate.Substring(3), EndDate.Substring(3), typeCBox.Text);
                    break;
                case "531":
                    FbParameter[] Parameters531 =
                    {
                        new FbParameter("Start_Date", StartDate),
                        new FbParameter("End_Date", EndDate),
                        new FbParameter("Flag1", Flag1),
                        new FbParameter("Flag3", Flag3),
                        new FbParameter("Flag4", Flag4),
                        new FbParameter("PFlag3", PFlag3),
                        new FbParameter("PFlag4", PFlag4)
                    };
                    Report.MSTrialBalanceByAccounts(DataModule.ExecuteFillProc("ReportMSTrialBalance531", Parameters531), StartDate.Substring(3), EndDate.Substring(3), typeCBox.Text);
                    break;
                default:
                    FbParameter[] Parameters =
                    {
                        new FbParameter("Start_Date", StartDate),
                        new FbParameter("End_Date", EndDate),
                        new FbParameter("Flag1", Flag1),
                        new FbParameter("Flag3", Flag3),
                        new FbParameter("Flag4", Flag4),
                        new FbParameter("PFlag3", PFlag3),
                        new FbParameter("PFlag4", PFlag4)
                    };
                    Report.MSTrialBalanceByAccounts(DataModule.ExecuteFillProc("ReportMSTrialBalanceByAccounts", Parameters), StartDate.Substring(3), EndDate.Substring(3), typeCBox.Text);
                    break;
            }

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void msTrialBalance_631_63Btn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string iFlag1_631 = "1";
            string iFlag3_631 = "1";
            string iFlag4_631 = "-1";
            string iPFlag3_631 = "15";
            string iPFlag4_631 = "15";

            string iFlag1_63 = "-1";
            string iFlag3_63 = "-1";
            string iFlag4_63 = "1";
            string iPFlag3_63 = "16";
            string iPFlag4_63 = "16";


            FbParameter[] Parameters =
                    {
                        new FbParameter("Start_Date", StartDate),
                        new FbParameter("Flag1_631", iFlag1_631),
                        new FbParameter("Flag3_631", iFlag3_631),
                        new FbParameter("Flag4_631",iFlag4_631),
                        new FbParameter("PFlag3_631", iPFlag3_631),
                        new FbParameter("PFlag4_631", iPFlag4_631),
                        new FbParameter("End_Date", EndDate),
                        new FbParameter("Flag1_63", iFlag1_63),
                        new FbParameter("Flag3_63", iFlag3_63),
                        new FbParameter("Flag4_63", iFlag4_63),
                        new FbParameter("PFlag3_63", iPFlag3_63),
                        new FbParameter("PFlag4_63", iPFlag4_63)
                    };

            Report.MSTrialBalance_631_63(DataModule.ExecuteFillProc("ReportMSTrialBalanceJoin_631_63", Parameters), StartDate.Substring(3), EndDate.Substring(3));

            Cursor = Cursors.Default;

            SaveLastDate();
        }


        private void msDebtorsCreditorsBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            switch (typeCBox.Text)
            {
                case "632":
                    FbParameter[] Parameters632 =
                    {
                        new FbParameter("End_Date", EndDate),
                        new FbParameter("Flag1", Flag1),
                        new FbParameter("Flag3", Flag3),
                        new FbParameter("Flag4", Flag4)
                    };
                    Report.MSDebtorsCreditors(DataModule.ExecuteFill(DataModule.Queries["MSDebtorsCreditorsCurrency"], Parameters632), StartDate.Substring(3), EndDate.Substring(3), typeCBox.Text);
                    break;
                default:
                    FbParameter[] Parameters =
                    {
                        new FbParameter("End_Date", EndDate),
                        new FbParameter("Flag1", Flag1),
                        new FbParameter("Flag3", Flag3),
                        new FbParameter("Flag4", Flag4),
                        new FbParameter("PFlag3", PFlag3),
                        new FbParameter("PFlag4", PFlag4)
                    };
                    Report.MSDebtorsCreditors(DataModule.ExecuteFill(DataModule.Queries["MSDebtorsCreditors"], Parameters), StartDate.Substring(3), EndDate.Substring(3), typeCBox.Text);
                    break;
            }
            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void reconciliationBtn_Click(object sender, EventArgs e)
        {
            if (_contractorId == null)
            {
                MessageBox.Show("Контрагент не обраний!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            FbParameter[] Parameters =
            {
                new FbParameter("Start_Date", StartDate),
                new FbParameter("End_Date", EndDate),
                new FbParameter("Contractor", _contractorId),
                new FbParameter("Flag1", Flag1),
                new FbParameter("Flag3", Flag3),
                new FbParameter("Flag4", Flag4),
                new FbParameter("PFlag3", PFlag3),
                new FbParameter("PFlag4", PFlag4)
            };

            string reportPeriodHeader = string.Empty;

            if (yearBeginCBox.Text == yearEndCBox.Text && monthBeginCBox.Text == monthEndCBox.Text)
                reportPeriodHeader = (monthEndCBox.Text).Substring(3).ToLower() + " " + yearEndCBox.Text;
            else
                reportPeriodHeader = (monthBeginCBox.Text).Substring(3).ToLower() + " " + yearBeginCBox.Text + " - " + (monthEndCBox.Text).Substring(3).ToLower() + " " + yearEndCBox.Text;

            Report.MSReconciliationReport
            (
                DataModule.ExecuteFill(DataModule.Queries["MSReconciliation"], Parameters),
                StartDate.Substring(3), EndDate.Substring(3),
                typeCBox.Text,
                _contractorName,
                reportPeriodHeader
            );
            Cursor = Cursors.Default;
            SaveLastDate();
        }
        
        private void paymentsWithoutVatBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            FbParameter[] Parameters =
            {
                new FbParameter("Start_Date", StartDate),
                new FbParameter("End_Date", EndDate),
                new FbParameter("PFlag3", PFlag3),
                new FbParameter("PFlag4", PFlag4)
            };
            Report.MSPaymentsWithoutVat(DataModule.ExecuteFill(DataModule.Queries["MSPaymentsWithoutVat"], Parameters), StartDate.Substring(3), EndDate.Substring(3), typeCBox.Text);
            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private int? _contractorId;
        private string _contractorName; 
        private void contractorsEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (contractorsEdit.EditValue != DBNull.Value)
            {
                _contractorId = (int?)contractorsEdit.EditValue;

                var view = (DataRowView)contractorsEdit.GetSelectedDataRow();

                if (view != null)
                {
                    DataRow dr = view.Row;
                    _contractorName = dr["Name"].ToString() + " " + dr["Srn"].ToString();
                }
            }
        }

        private void contractorsVatBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("StartDate", StartDate),
                    new FbParameter("EndDate", EndDate)
                };

            Report.ContarctorsVat(DataModule.ExecuteFill(DataModule.Queries["ContractorsVat"], Parameters), StartDate, EndDate);

            Cursor = Cursors.Default;
        }

        #endregion Contractor's tab

        #region Storehouse tab

        private void trialBalanceBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
            {
                new FbParameter("StartDate", StartDate),
                new FbParameter("EndDate", EndDate)
            };
            Report.TrialBalance(DataModule.ExecuteFill(DataModule.Queries["TrialBalance"], Parameters), StartDate.Substring(3), EndDate.Substring(3));
            Cursor = Cursors.Default;

            SaveLastDate();
        }

        private void trialBalanceAccountsBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string Month;
            Month = monthBeginCBox.Text.Substring(3, monthBeginCBox.Text.Length - 3) + " " + yearBeginCBox.Text + " года";
            FbParameter[] Parameters =
            {
                new FbParameter("StartDate", StartDate),
                new FbParameter("EndDate", EndDate)
            };

            Report.TrialBalanceAccounts(DataModule.ExecuteFillProc("ReportTrialBalanceByAccounts", Parameters), StartDate.Substring(3), EndDate.Substring(3));

            Cursor = Cursors.Default;

            SaveLastDate();
        }

        private void expForPrjBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string Month = monthBeginCBox.Text.Substring(3, monthBeginCBox.Text.Length - 3) + " " + yearBeginCBox.Text + " года";

            FbParameter[] Parameters =
            {
                new FbParameter("StartDate", StartDate),
                new FbParameter("EndDate", EndDate)
            };
            Report.ExpendituresForProjects(DataModule.ExecuteFill(DataModule.Queries["ExpendituresForProjects"], Parameters), StartDate.Substring(3), EndDate.Substring(3));
            SaveLastDate();

            Cursor = Cursors.Default;
        }

        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Report.Inventory(DataModule.ExecuteFill(DataModule.Queries["Inventory"], new FbParameter("StartDate", EndDate)), EndDate);
            
            Cursor = Cursors.Default;
        }

        private void receiptsForDaysAndBalanceBtn_Click(object sender, EventArgs e)
        {
            if (balanceCBox.SelectedValue == null)
            {
                MessageBox.Show("Не выбран балансовый счёт!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
            {
                new FbParameter("StartDate", StartDate),
                new FbParameter("EndDate", EndDate),
                new FbParameter("BalanceNum", balanceCBox.SelectedValue)
            };
            Report.ReceiptsForDaysAndBalance
            (
                DataModule.ExecuteFill(DataModule.Queries["ReceiptsForBalanceAndDays"], Parameters),
                StartDate.Substring(3, 7), EndDate.Substring(3, 7),
                balanceCBox.Text
            );
            SaveLastDate();

            Cursor = Cursors.Default;
        }

        private void ordersForVendorBtn_Click(object sender, EventArgs e)
        {
            if (vendorTLBox.SelectedValue == null)
            {
                MessageBox.Show("Вкажіть постачальника!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
            {
                new FbParameter("StartDate", StartDate),
                new FbParameter("EndDate", EndDate),
                new FbParameter("Vendor", vendorTLBox.SelectedValue)
            };
            Report.OrdersForVendor
            (
                DataModule.ExecuteFill(DataModule.Queries["OrdersForVendor"], Parameters),
                vendorTLBox.SelectedText + "    " + ((DataRow)vendorTLBox.SelectedInfo)["Srn"],
                StartDate.Substring(3, 7), EndDate.Substring(3, 7)
            );
            SaveLastDate();

            Cursor = Cursors.Default;
        }

        private void expendituresForVendorBtn_Click(object sender, EventArgs e)
        {
            if (vendorTLBox.SelectedValue == null)
            {
                MessageBox.Show("Вкажіть постачальника!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
            {
                new FbParameter("Start_Date", StartDate),
                new FbParameter("End_Date", EndDate),
                new FbParameter("Exp_Date", lastDTPicker.Value),
                new FbParameter("Vendor", vendorTLBox.SelectedValue),
                new FbParameter("Receipt_Num", receiptNumTBox.Text.Trim().Length == 0 ? "%" : receiptNumTBox.Text.Trim())
            };
            
            Report.ExpendituresForVendor
            (
                DataModule.ExecuteFill(DataModule.Queries["ExpendituresForVendor"], Parameters),
                StartDate, lastDTPicker.Value.ToShortDateString(),
                vendorTLBox.SelectedText + " " + ((DataRow)vendorTLBox.SelectedInfo)["Srn"],
                ((DataRow)vendorTLBox.SelectedInfo)["Srn"].ToString()
            );
            
            SaveLastDate();

            Cursor = Cursors.Default;
        }

        #endregion Storehouse tab

        #region Bank tab

        private void bankTrialBalanceBtn_Click(object sender, EventArgs e)
        {
            if (bankAccountCBox.SelectedValue == null)
            {
                MessageBox.Show("Не выбран: \"Счёт банка\"!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("Start_Date", StartDate),
                    new FbParameter("End_Date", EndDate),
                    new FbParameter("Bank_Account", bankAccountCBox.SelectedValue),
                };
            Report.BankTrialBalance(DataModule.ExecuteFill(DataModule.Queries["BankTrialBalance"], Parameters), StartDate.Substring(3), EndDate.Substring(3), bankAccountCBox.Text.Replace('/', '.'), (short)bankAccountCBox.SelectedValue);

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void bankTrialBalance334Btn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("Start_Date", StartDate),
                    new FbParameter("End_Date", EndDate),
                    new FbParameter("Purpose_Account", 79),
                };
            Report.BankTrialBalanceForCustomBill(DataModule.ExecuteFill(DataModule.Queries["BankTrialBalanceForCustomBill"], Parameters), StartDate.Substring(3), EndDate.Substring(3), "334");

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void bankTrialBalance373Btn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("Start_Date", StartDate),
                    new FbParameter("End_Date", EndDate),
                    new FbParameter("Purpose_Account", 125),
                };
            Report.BankTrialBalanceForCustomBill(DataModule.ExecuteFill(DataModule.Queries["BankTrialBalanceForCustomBill"], Parameters), StartDate.Substring(3), EndDate.Substring(3), "373");

            Cursor = Cursors.Default;
            SaveLastDate();
        }
       
        private void bankTrialBalanceFull_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("Start_Date", StartDate),
                    new FbParameter("End_Date", EndDate)
                };
            Report.BankTrialBalanceFull(DataModule.ExecuteFill(DataModule.Queries["BankTrialBalanceFull"], Parameters), StartDate.Substring(3), EndDate.Substring(3));

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void bankTrialBalanceQuarterBtn_Click(object sender, EventArgs e)
        {
            if (bankAccountCBox.SelectedValue == null)
            {
                MessageBox.Show("Не выбран: \"Счёт банка\"!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("Start_Date", StartDate),
                    new FbParameter("End_Date", EndDate),
                    new FbParameter("Bank_Account", bankAccountCBox.SelectedValue),
                };
            Report.BankTrialBalanceQuarter(DataModule.ExecuteFill(DataModule.Queries["BankTrialBalanceQuarter"], Parameters), StartDate.Substring(3), EndDate.Substring(3), bankAccountCBox.Text.Replace('/', '.'), (short)bankAccountCBox.SelectedValue);

            Cursor = Cursors.Default;
            SaveLastDate();
        }        

        #endregion Bank tab

        #region FixedAssets tab

        private void fixedAssetsReportGroupBtn_Click(object sender, EventArgs e)
        {
            if (yearBeginCBox.SelectedIndex != yearEndCBox.SelectedIndex || monthBeginCBox.SelectedIndex != monthEndCBox.SelectedIndex)
            {
                MessageBox.Show("Выбран неверный период. \n Выберите только один месяц.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor = Cursors.WaitCursor;
            DateTime startDateDT = new DateTime();
            if (DateTime.TryParse(StartDate, out startDateDT))
            {
                startDateDT = startDateDT.AddMonths(-1);
                FbParameter[] Parameters =
                {
                    new FbParameter("StartDate", startDateDT.ToString()),
                    new FbParameter("EndDate", EndDate)
                };

                Report.FixedAssetsReportStrait(DataModule.ExecuteFill(DataModule.Queries["FixedAssetsReportStrait"] + "WHERE (CurrentPrice + CurrentAmortization > 0)", Parameters), StartDate, EndDate, false);
            }
            else
            { MessageBox.Show("Ошибка конвертирование даты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void fixedAssetsReportGroupZeroBtn_Click(object sender, EventArgs e)
        {
            if (yearBeginCBox.SelectedIndex != yearEndCBox.SelectedIndex || monthBeginCBox.SelectedIndex != monthEndCBox.SelectedIndex)
            {
                MessageBox.Show("Выбран неверный период. \n Выберите только один месяц.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            Cursor = Cursors.WaitCursor;
            DateTime startDateDT = new DateTime();
            if (DateTime.TryParse(StartDate, out startDateDT))
            {
                startDateDT = startDateDT.AddMonths(-1);
                FbParameter[] Parameters =
                {
                    new FbParameter("StartDate", startDateDT.ToString()),
                    new FbParameter("EndDate", EndDate)
                };
                Report.FixedAssetsReportStrait(DataModule.ExecuteFill(DataModule.Queries["FixedAssetsReportStrait"] + "WHERE (CurrentPrice<=0) AND (CurrentAmortization<=0)", Parameters), StartDate.ToString(), EndDate.ToString(), true);
            }
            else
            { MessageBox.Show("Ошибка конвертирование даты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void fixedAssetsReportJournal1Btn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("StartDate", StartDate),
                    new FbParameter("EndDate", EndDate)
                };

            Report.FixedAssetsRegisterCh1(DataModule.ExecuteFill(DataModule.Queries["FixedAssetsReportRegisterCh1"], Parameters), StartDate.ToString(), EndDate.ToString());

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void fixedAssetsReportJournal2Btn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            FbParameter[] Parameters =
                {
                     new FbParameter("BeginDate", StartDate),
                     new FbParameter("EndDate", EndDate)
                };

            Report.FixedAssetsRegisterCh2(DataModule.ExecuteFill(DataModule.Queries["FixedAssetsReportRegisterCh2"], Parameters), StartDate.ToString(), EndDate.ToString());

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void InputFixedForGroup_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //string beginReportDate = "01." + monthBeginCBox.Text.Substring(0, 2) + "." + yearBeginCBox.Text;
            //string endReportDate = "01." + monthEndCBox.Text.Substring(0, 2) + "." + yearEndCBox.Text;

            FbParameter[] Parameters =
            {
               new FbParameter("StartDateFYear", StartDate),
               new FbParameter("StartDateLYear", EndDate)
            };

            Report.InputFixedAssetsForGroup(DataModule.ExecuteFill(DataModule.Queries["InputFixedAssetsForGroup"], Parameters), StartDate, EndDate);

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void InputFixedForQuarter_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string currentReportYear = yearBeginCBox.Text;
            //string beginReportDate = "01." + monthBeginCBox.Text.Substring(0, 2) + "." + yearBeginCBox.Text;
            //string endReportDate = "01." + monthEndCBox.Text.Substring(0, 2) + "." + yearEndCBox.Text;

            FbParameter[] Parameters =
            {
               new FbParameter("BeginDate", StartDate),
               new FbParameter("EndDate", EndDate)
            };

            Report.InputFixedAssetsForQuarter(DataModule.ExecuteFill(DataModule.Queries["InputFixedAssetsForQuarter"], Parameters), currentReportYear);

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void fixedAssetsReportGroupShortBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("BeginDate", StartDate),
                    new FbParameter("EndDate", EndDate)
                };

            Report.FixedAssetsReportGroupShort(DataModule.ExecuteFillProc("GetFixedAssetsByGroupShort", Parameters), StartDate.ToString(), EndDate.ToString());

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void InvoicesForFixedAssetsBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            FbParameter[] Parameters =
                {
                    new FbParameter("BeginDate", StartDate),
                    new FbParameter("EndDate", EndDate)
                };
            Report.InvoicesForFixedAssets(DataModule.ExecuteFill(DataModule.Queries["InvoicesForFixedAssets"], Parameters), StartDate.ToString(), EndDate.ToString());

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void InventoryFixedAssetsBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            FbParameter[] Parameters =
                {
                    new FbParameter("StartDate", StartDate),
                    new FbParameter("EndDate", EndDate)
                };
            Report.InventoryForFixedAssets(DataModule.ExecuteFill(DataModule.Queries["FixedAssetsReportStrait"] + " WHERE Supplier_Id = " + supplierCBox.SelectedValue.ToString(), Parameters), DateTime.Parse(EndDate));

            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void InventoryFixedAssetsForGroupsBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            FbParameter[] Parameters =
                {
                    new FbParameter("StartDate", StartDate),
                    new FbParameter("EndDate", EndDate)
                };
            Report.InventoryGroupsForFixedAssets(DataModule.ExecuteFill(DataModule.Queries["FixedAssetsReportStrait"], Parameters), DateTime.Parse(EndDate));

            Cursor = Cursors.Default;
            SaveLastDate();
        }
        
        #endregion FixedAssets tab

        #region CalcWithBuyers tab

        private void calcWithBuyersByAccountBtn_Click(object sender, EventArgs e)
        {
            string defaultDate = "31.12.2014";
            
            if (calcAccountCBox.SelectedValue == null)
            {
                MessageBox.Show("Не выбран: \"Балансовый счет\"!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("StartDate", StartDate),
                    new FbParameter("EndDate", EndDate),
                    new FbParameter("SelectionDate", defaultDate),
                    new FbParameter("PurposeAccountId", calcAccountCBox.SelectedValue)
                };

            bool currencyStatus = (calcAccountCBox.Text == "362") ? true : false;
            
            if (currencyStatus)
                Report.CalcWithBuyersReportCurrency(DataModule.ExecuteFill(DataModule.Queries["CalcWithBuyers"], Parameters), (DateTime.Parse(StartDate)).ToShortDateString(), (DateTime.Parse(EndDate)).ToShortDateString(), calcAccountCBox.Text.Replace('/', '.'), (short)calcAccountCBox.SelectedValue);
            else
                Report.CalcWithBuyersReport(DataModule.ExecuteFill(DataModule.Queries["CalcWithBuyers"], Parameters), (DateTime.Parse(StartDate)).ToShortDateString(), (DateTime.Parse(EndDate)).ToShortDateString(), calcAccountCBox.Text.Replace('/', '.'), (short)calcAccountCBox.SelectedValue);
            Cursor = Cursors.Default;
            SaveLastDate();
        }

        private void calcWithBuyersBtn_Click(object sender, EventArgs e)
        {
            string defaultDate = "31.12.2014";
           
            if (calcAccountCBox.SelectedValue == null)
            {
                MessageBox.Show("Не вибраний балансовий рахунок!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor = Cursors.WaitCursor;

            FbParameter[] Parameters =
                {
                    new FbParameter("StartDate", StartDate),
                    new FbParameter("EndDate", EndDate),
                    new FbParameter("SelectionDate", defaultDate),
                    new FbParameter("PurposeAccountId", calcAccountCBox.SelectedValue)
                };

            bool currencyStatus = (calcAccountCBox.Text == "362") ? true : false;

            if (currencyStatus)
                Report.CalcWithBuyersReportShortCurrency(DataModule.ExecuteFill(DataModule.Queries["CalcWithBuyersShort"], Parameters), (DateTime.Parse(StartDate)).ToShortDateString(), (DateTime.Parse(EndDate)).ToShortDateString(), calcAccountCBox.Text.Replace('/', '.'), (short)calcAccountCBox.SelectedValue);
            else
                Report.CalcWithBuyersReportShort(DataModule.ExecuteFill(DataModule.Queries["CalcWithBuyersShort"], Parameters), (DateTime.Parse(StartDate)).ToShortDateString(), (DateTime.Parse(EndDate)).ToShortDateString(), calcAccountCBox.Text.Replace('/', '.'), (short)calcAccountCBox.SelectedValue);
            Cursor = Cursors.Default;
            SaveLastDate();
        }

        #endregion CalcWithBuyers tab

        #endregion Button click event's
        
        private void reportFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFm.reportsBtn.Enabled = true;
        }

        private void contractorsEdit_Properties_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width + 200, properties.PopupFormSize.Height);
        }

        private void contractorsEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                contractorsRBFm contractorsFM = new contractorsRBFm();
                contractorsFM.ShowDialog();
                contractorDataSource = DataModule.ExecuteFill(@"SELECT * FROM ""Contractors"" ORDER BY ""Name""");
                contractorsEdit.Properties.DataSource = contractorDataSource;
            }
        }

        
      
    }
}
