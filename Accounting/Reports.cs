using System;
using System.Diagnostics;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using SpreadsheetGear;
using FirebirdSql.Data.FirebirdClient;
using System.Text;
using Accounting.Properties;

namespace Accounting
{class Reports
    {
        #region Storehouse

        public void ReceiptOrder(long OrderId)
        {
            var Workbook = Factory.GetWorkbook(TemplatesDir + "ReceiptOrder.xls");
            var Worksheet = Workbook.Worksheets[0];
            var Cells = Worksheet.Cells;

            List<double> BalanceNums = new List<double>();
            SortedList<double, double> BalanceAccounts = new SortedList<double, double>();

            DataRow currentRow = DataModule.AccountingDS.Tables["Order"].AsEnumerable().First(r => Convert.ToInt64(r["Id"]) == OrderId);
            int OrderPos = DataModule.AccountingDS.Tables["Order"].Rows.IndexOf(currentRow);

            Cells["A" + 1].Value += " " + DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Receipt_Num"].ToString();

            Cells["A" + 2].Value = Convert.ToDateTime(DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Order_Date"]).ToShortDateString();
            Cells["A" + 2].HorizontalAlignment = HAlign.Left;

            Cells["A" + 4].Value += " " + DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Vendor_Name"].ToString() + "    " + DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Vendor_Srn"].ToString();
            Cells["A" + 4].HorizontalAlignment = HAlign.Left;

            Cells["A" + 6].Value += " " + DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Supplier_Name"].ToString() + "    " + DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Supplier_Proxy"].ToString();
            Cells["A" + 6].HorizontalAlignment = HAlign.Left;

            Cells["B" + 7].NumberFormat = "@";
            Cells["B" + 7].Value = DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Invoice_Num"].ToString();
            Cells["B" + 7].HorizontalAlignment = HAlign.Left;

            int StartWith = 11;

            for (int i = 0; i < DataModule.AccountingDS.Tables["Receipt"].Rows.Count; i++)
            {
                if (DataModule.AccountingDS.Tables["Receipt"].Rows[i].RowState == DataRowState.Deleted)
                    continue;

                Cells["D" + StartWith].Value = DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Nomenclature"];
                Cells["D" + StartWith].HorizontalAlignment = HAlign.Left;

                Cells["A" + StartWith].Value = DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Nomenclature_Name"];
                Cells["A" + StartWith].HorizontalAlignment = HAlign.Left;

                Cells["E" + StartWith].Value = DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Measure"];
                Cells["E" + StartWith].HorizontalAlignment = HAlign.Center;

                Cells["F" + StartWith].Value = DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Quantity"];
                Cells["F" + StartWith].NumberFormat = "### ##0.000#";
                Cells["F" + StartWith].HorizontalAlignment = HAlign.Right;

                Cells["G" + StartWith].Value = DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Unit_Price"];
                Cells["G" + StartWith].NumberFormat = "### ### ##0.00";
                Cells["G" + StartWith].HorizontalAlignment = HAlign.Right;

                Cells["H" + StartWith].Value = DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Total_Price"];
                Cells["H" + StartWith].NumberFormat = "### ### ##0.00";
                Cells["H" + StartWith].HorizontalAlignment = HAlign.Right;

                Cells["A" + StartWith.ToString() + ":" + "H" + StartWith.ToString()].Borders.LineStyle = LineStyle.Continous;

                StartWith++;

                double AccountNum = Convert.ToDouble(DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Balance_Num"].ToString().Replace('/', ','));
                if (!BalanceAccounts.ContainsKey(AccountNum))
                {
                    BalanceNums.Add(AccountNum);
                    BalanceAccounts.Add(AccountNum, Convert.ToDouble(DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Total_Price"]));
                }
                else
                {
                    BalanceAccounts[AccountNum] += Convert.ToDouble(DataModule.AccountingDS.Tables["Receipt"].Rows[i]["Total_Price"]);
                }
            }

            Cells["G" + StartWith].Value = "Сумма";
            Cells["G" + StartWith].Font.Underline = UnderlineStyle.Single;
            Cells["G" + StartWith].HorizontalAlignment = HAlign.Left;
            Cells["H" + StartWith].Value = DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Total_Price"];
            Cells["H" + StartWith].NumberFormat = "### ### ##0.00";
            Cells["H" + StartWith].Font.Underline = UnderlineStyle.Single;
            Cells["H" + StartWith].HorizontalAlignment = HAlign.Right;
            StartWith++;
            Cells["G" + StartWith].Value = "НДС";
            Cells["G" + StartWith].Font.Underline = UnderlineStyle.Single;
            Cells["G" + StartWith].HorizontalAlignment = HAlign.Left;
            Cells["H" + StartWith].Value = DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Vat"];
            Cells["H" + StartWith].NumberFormat = "### ### ##0.00";
            Cells["H" + StartWith].Font.Underline = UnderlineStyle.Single;
            Cells["H" + StartWith].HorizontalAlignment = HAlign.Right;
            StartWith++;
            Cells["G" + StartWith].Value = "Сумма с НДС";
            Cells["G" + StartWith].Font.Underline = UnderlineStyle.Single;
            Cells["G" + StartWith].HorizontalAlignment = HAlign.Left;
            Cells["H" + StartWith].Value = DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Total_With_Vat"];
            Cells["H" + StartWith].NumberFormat = "### ### ##0.00";
            Cells["H" + StartWith].Font.Underline = UnderlineStyle.Single;
            Cells["H" + StartWith].HorizontalAlignment = HAlign.Right;

            StartWith--;
            BalanceNums.Sort();
            for (int i = 0; i < BalanceAccounts.Count; i++)
            {
                Cells["A" + StartWith].Value = BalanceNums[i].ToString().Replace(',', '/');
                Cells["A" + StartWith].Interior.Color = Color.LightGray;
                Cells["B" + StartWith].Value = BalanceAccounts[BalanceNums[i]];
                Cells["B" + StartWith].NumberFormat = "### ### ##0.00";
                Cells["A" + StartWith.ToString() + ":" + "B" + StartWith.ToString()].HorizontalAlignment = HAlign.Left;
                Cells["A" + StartWith.ToString() + ":" + "B" + StartWith.ToString()].Borders.LineStyle = LineStyle.Continous;
                StartWith++;
            }

            StartWith += 2;

            Cells["B" + StartWith + ":" + "H" + StartWith].WrapText = true;

            Cells["B" + StartWith].Value = "ОТК";
            Cells["B" + StartWith].Font.Bold = true;
            Cells["D" + StartWith].Value = DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Otk_Name"].ToString();
            Cells["E" + StartWith].Value = "Сдал";
            Cells["E" + StartWith].Font.Bold = true;
            Cells["F" + StartWith].Value = DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Supplier_Name"].ToString();
            Cells["G" + StartWith].Value = "Принял";
            Cells["G" + StartWith].Font.Bold = true;
            Cells["H" + StartWith].Value = DataModule.AccountingDS.Tables["Order"].Rows[OrderPos]["Storekeeper_Name"].ToString();

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Приходный ордер.xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Приходный ордер.xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void ExpendituresForProjects(DataTable reportTable, string StartDate, string EndDate)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "ExpendituresForProjects.xls");
            var Worksheet = Workbook.Worksheets[0];
            var Cells = Worksheet.Cells;

            var Worksheet1 = Workbook.Worksheets[1];
            var Cells1 = Worksheet1.Cells;

            int captionPosition = 6;
            int startWith1 = captionPosition + 1;

            int fontSize = 12;

            int startWith = captionPosition + 1;
            int a = 0;

            Cells1["A" + captionPosition].Value += StartDate + " по " + EndDate;
            
            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (i == 0 || reportTable.Rows[i]["Project_Num"].ToString().Trim() != reportTable.Rows[i - 1]["Project_Num"].ToString().Trim())
                {
                    a = 0;
                    startWith++;
                    Cells["D" + startWith + ":" + "F" + startWith].Merge();
                    Cells["D" + startWith].Value = "Cтверджую";
                    Cells["D" + startWith].Font.Size = 14;
                    Cells["D" + startWith].Font.Bold = true;
                    Cells["D" + startWith].HorizontalAlignment = HAlign.Center;
                    //
                    startWith++;
                    Cells["D" + startWith + ":" + "F" + startWith].Merge();
                    Cells["D" + startWith + ":" + "F" + startWith].Value = "_______________________________";
                    Cells["D" + startWith].HorizontalAlignment = HAlign.Center;
                    //
                    startWith++;
                    Cells["D" + startWith + ":" + "F" + startWith].Merge();
                    Cells["D" + startWith + ":" + "F" + startWith].Value = "_______________________________";
                    Cells["D" + startWith].HorizontalAlignment = HAlign.Center;
                    //
                    startWith++;
                    Cells["A" + startWith + ":" + "G" + startWith].Merge();
                    Cells["A" + startWith + ":" + "G" + startWith].Value = "Реєстр";
                    Cells["A" + startWith + ":" + "G" + startWith].Font.Size = 16;
                    Cells["A" + startWith].HorizontalAlignment = HAlign.Center;
                    //
                    startWith++;
                    Cells["A" + startWith + ":" + "G" + startWith].Merge();
                    Cells["A" + startWith + ":" + "G" + startWith].Value = "на списання матеріалів";
                    Cells["A" + startWith].Font.Size = 14;
                    Cells["A" + startWith].HorizontalAlignment = HAlign.Center;
                    //
                    startWith++;
                    Cells["A" + startWith + ":" + "G" + startWith].Merge();
                    Cells["A" + startWith + ":" + "G" + startWith].Value = "за замовленням " + reportTable.Rows[i]["Project_Num"].ToString().Trim() + " за період " + StartDate + "-" + EndDate;
                    Cells["A" + startWith].Font.Size = 14;
                    Cells["A" + startWith].HorizontalAlignment = HAlign.Center;
                    //
                    //
                    startWith++;
                    Cells["A" + startWith].Value = "№ п/п";
                    Cells["A" + startWith].HorizontalAlignment = HAlign.Center;
                    Cells["A" + startWith].Borders.LineStyle = LineStyle.Continous;
                    Cells["A" + startWith].Font.Bold = true;
                    //
                    Cells["B" + startWith].Value = "Ном. номер";
                    Cells["B" + startWith].HorizontalAlignment = HAlign.Center;
                    Cells["B" + startWith].Borders.LineStyle = LineStyle.Continous;
                    Cells["B" + startWith].Font.Bold = true;
                    //
                    Cells["C" + startWith].Value = "Найменування матеріалу";
                    Cells["C" + startWith].HorizontalAlignment = HAlign.Center;
                    Cells["C" + startWith].Borders.LineStyle = LineStyle.Continous;
                    Cells["C" + startWith].Font.Bold = true;
                    //
                    Cells["D" + startWith].Value = "Од. вим.";
                    Cells["D" + startWith].HorizontalAlignment = HAlign.Center;
                    Cells["D" + startWith].Borders.LineStyle = LineStyle.Continous;
                    Cells["D" + startWith].Font.Bold = true;
                    //
                    Cells["E" + startWith].Value = "Кіл-ть";
                    Cells["E" + startWith].HorizontalAlignment = HAlign.Center;
                    Cells["E" + startWith].Borders.LineStyle = LineStyle.Continous;
                    Cells["E" + startWith].Font.Bold = true;
                    //
                    Cells["F" + startWith].Value = "Ціна за од.";
                    Cells["F" + startWith].HorizontalAlignment = HAlign.Center;
                    Cells["F" + startWith].Borders.LineStyle = LineStyle.Continous;
                    Cells["F" + startWith].Font.Bold = true;
                    //
                    Cells["G" + startWith].Value = "Сума";
                    Cells["G" + startWith].HorizontalAlignment = HAlign.Center;
                    Cells["G" + startWith].Borders.LineStyle = LineStyle.Continous;
                    Cells["G" + startWith].Font.Bold = true;
                }

                a++;
                startWith++;
                Cells["A" + startWith].Value = a;
                Cells["A" + startWith].Borders.LineStyle = LineStyle.Continous;
                Cells["A" + startWith].Font.Size = fontSize;

                Cells["B" + startWith].Value = reportTable.Rows[i]["Nomenclature"];
                Cells["B" + startWith].Borders.LineStyle = LineStyle.Continous;
                Cells["B" + startWith].Font.Size = fontSize;

                Cells["C" + startWith].Value = reportTable.Rows[i]["Name"];
                Cells["C" + startWith].Borders.LineStyle = LineStyle.Continous;
                Cells["C" + startWith].Font.Size = fontSize;

                Cells["D" + startWith].Value = reportTable.Rows[i]["Measure"];
                Cells["D" + startWith].HorizontalAlignment = HAlign.Center;
                Cells["D" + startWith].Borders.LineStyle = LineStyle.Continous;
                Cells["D" + startWith].Font.Size = fontSize;

                Cells["E" + startWith].Value = reportTable.Rows[i]["ExpQuantity"];
                Cells["E" + startWith].NumberFormat = "### ##0.0##";
                Cells["E" + startWith].HorizontalAlignment = HAlign.Right;
                Cells["E" + startWith].Borders.LineStyle = LineStyle.Continous;
                Cells["E" + startWith].Font.Size = fontSize;

                Cells["F" + startWith].Value = reportTable.Rows[i]["Unit_Price"];
                Cells["F" + startWith].NumberFormat = "### ### ##0.00";
                Cells["F" + startWith].HorizontalAlignment = HAlign.Right;
                Cells["F" + startWith].Borders.LineStyle = LineStyle.Continous;
                Cells["F" + startWith].Font.Size = fontSize;

                Cells["G" + startWith].Value = reportTable.Rows[i]["ExpSum"];
                Cells["G" + startWith].NumberFormat = "### ### ##0.00";
                Cells["G" + startWith].HorizontalAlignment = HAlign.Right;
                Cells["G" + startWith].Borders.LineStyle = LineStyle.Continous;
                Cells["G" + startWith].Font.Size = fontSize;

                if ((i < reportTable.Rows.Count - 1 && reportTable.Rows[i]["Project_Num"].ToString() != reportTable.Rows[i + 1]["Project_Num"].ToString() || i == reportTable.Rows.Count - 1))
                {
                    startWith++;
                    Cells["E" + startWith + ":" + "F" + startWith].Merge();
                    Cells["E" + startWith].Font.Size = fontSize;

                    Cells["E" + startWith].Value = "Разом по " + reportTable.Rows[i]["Project_Num"].ToString() + ":";
                    Cells["E" + startWith].Font.Bold = true;
                    Cells["E" + startWith].Font.Size = fontSize;

                    Cells["G" + startWith].Formula = SetFormula("G", (startWith - a), "G", (startWith - 1), "SUM");
                    Cells["G" + startWith].NumberFormat = "### ### ##0.00";
                    Cells["G" + startWith].Font.Bold = true;
                    Cells["G" + startWith].Interior.Color = Color.LightGreen;
                    Cells["G" + startWith].Font.Size = fontSize;

                    Cells["E" + startWith + ":" + "G" + startWith].Borders.LineStyle = LineStyle.Continous;
                    Cells["E" + startWith].Font.Size = fontSize;

                    //
                    //
                    startWith1++;
                    Cells1["A" + startWith1].Value = reportTable.Rows[i]["Project_Num"].ToString();
                    Cells1["A" + startWith1].Borders.LineStyle = LineStyle.Continous;
                    Cells1["B" + startWith1].Value = Math.Round(Convert.ToDouble(Cells["G" + startWith].Value.ToString()), 2);
                    Cells1["B" + startWith1].NumberFormat = "### ### ##0.00";
                    Cells1["B" + startWith1].HorizontalAlignment = HAlign.Right;
                    Cells1["B" + startWith1].Borders.LineStyle = LineStyle.Continous;
                    //
                    //

                    startWith++;
                    // Page Break
                    SetPageBreak(Worksheet, startWith, 0);
                }
            }

            //
            startWith1++;
            Cells1["A" + startWith1].Value = "Разом:";
            Cells1["A" + startWith1].Font.Bold = true;
            Cells1["A" + startWith1].Borders.LineStyle = LineStyle.Continous;
            Cells1["B" + startWith1].Formula = SetFormula("B", 3, "B", (startWith1 - 1), "SUM");
            Cells1["B" + startWith1].NumberFormat = "### ### ##0.00";
            Cells1["B" + startWith1].Font.Bold = true;
            Cells1["B" + startWith1].HorizontalAlignment = HAlign.Right;
            Cells1["B" + startWith1].Interior.Color = Color.LightGreen;
            Cells1["B" + startWith1].Borders.LineStyle = LineStyle.Continous;
            //
            startWith1++;
            Cells1["A" + startWith1].Value = "Разом по проектам:";
            Cells1["A" + startWith1].Font.Bold = true;
            Cells1["A" + startWith1].Borders.LineStyle = LineStyle.Continous;
            Cells1["B" + startWith1].Formula = "=B" + (startWith1 - 1) + "-B3";
            Cells1["B" + startWith1].NumberFormat = "### ### ##0.00";
            Cells1["B" + startWith1].Font.Bold = true;
            Cells1["B" + startWith1].HorizontalAlignment = HAlign.Right;
            Cells1["B" + startWith1].Interior.Color = Color.LightGreen;
            Cells1["B" + startWith1].Borders.LineStyle = LineStyle.Continous;
            //

            PrintSignatures(Cells, startWith + 3);
            PrintSignatures(Cells1, startWith1 + 3);

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Реєстр на списання за період з " + StartDate + " по " + EndDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Реєстр на списання за період з " + StartDate + " по " + EndDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдено програму Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void TrialBalance(DataTable reportTable, string StartDate, string EndDate)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "TrialBalance.xls");
            var Worksheet = Workbook.Worksheets[0];
            var Сells = Worksheet.Cells;

            int fontSize = 18;

            int captionPosition = 6;
            int startWith = captionPosition + 4;
            int a = 0;
            decimal sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;

            Сells["A" + captionPosition].Value = "Оборотно-сальдова відомість по складу за період з " + StartDate + " по " + EndDate;
            Сells["I" + captionPosition].Font.Size = 20;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (i == 0 || reportTable.Rows[i]["Balance"].ToString().Trim() != reportTable.Rows[i - 1]["Balance"].ToString().Trim())
                {
                    a = 0;
                    Сells["A" + startWith].Value = "";

                    startWith++;
                    Сells["A" + startWith.ToString() + ":" + "K" + startWith.ToString()].Merge();
                    Сells["A" + startWith].Value = "Балансовий рахунок " + reportTable.Rows[i]["Balance"];
                    Сells["A" + startWith].Font.Bold = true;
                    Сells["A" + startWith].Font.Size = fontSize;
                }

                a++;
                startWith++;
                Сells["A" + startWith].Value = reportTable.Rows[i]["Nomenclature"];
                Сells["A" + startWith].Borders.LineStyle = LineStyle.Continous;
                Сells["A" + startWith].Font.Size = fontSize;

                Сells["B" + startWith].Value = reportTable.Rows[i]["Name"];
                Сells["B" + startWith].Borders.LineStyle = LineStyle.Continous;
                Сells["B" + startWith].Font.Size = fontSize;

                Сells["C" + startWith].Value = reportTable.Rows[i]["Measure"];
                Сells["C" + startWith].Borders.LineStyle = LineStyle.Continous;
                Сells["C" + startWith].HorizontalAlignment = HAlign.Center;
                Сells["C" + startWith].Font.Size = fontSize;
                Сells["C" + startWith].Borders[BordersIndex.EdgeRight].Weight = BorderWeight.Medium;

                Сells["D" + startWith].Value = reportTable.Rows[i]["Remainsq"];
                Сells["D" + startWith].Borders.LineStyle = LineStyle.Continous;
                Сells["D" + startWith].Font.Size = fontSize;

                Сells["E" + startWith].Value = reportTable.Rows[i]["Remainsp"];
                Сells["E" + startWith].NumberFormat = "### ### ##0.00";
                Сells["E" + startWith].Borders.LineStyle = LineStyle.Continous;
                Сells["E" + startWith].Font.Size = fontSize;
                Сells["E" + startWith].Borders[BordersIndex.EdgeRight].Weight = BorderWeight.Medium;

                Сells["F" + startWith].Value = reportTable.Rows[i]["Receipt_total_quantity"];
                Сells["F" + startWith].Borders.LineStyle = LineStyle.Continous;
                Сells["F" + startWith].Font.Size = fontSize;

                Сells["G" + startWith].Value = reportTable.Rows[i]["Receipt_total_price"];
                Сells["G" + startWith].NumberFormat = "### ### ##0.00";
                Сells["G" + startWith].Borders.LineStyle = LineStyle.Continous;
                Сells["G" + startWith].Font.Size = fontSize;
                Сells["G" + startWith].Borders[BordersIndex.EdgeRight].Weight = BorderWeight.Medium;

                Сells["H" + startWith].Value = reportTable.Rows[i]["Exp_total_quantity"];
                Сells["H" + startWith].Borders.LineStyle = LineStyle.Continous;
                Сells["H" + startWith].Font.Size = fontSize;

                Сells["I" + startWith].Value = reportTable.Rows[i]["Exp_total_price"];
                Сells["I" + startWith].NumberFormat = "### ### ##0.00";
                Сells["I" + startWith].Borders.LineStyle = LineStyle.Continous;
                Сells["I" + startWith].Font.Size = fontSize;
                Сells["I" + startWith].Borders[BordersIndex.EdgeRight].Weight = BorderWeight.Medium;

                Сells["J" + startWith].Value = reportTable.Rows[i]["Remainsq1"];
                Сells["J" + startWith].Borders.LineStyle = LineStyle.Continous;
                Сells["J" + startWith].Font.Size = fontSize;

                Сells["K" + startWith].Value = reportTable.Rows[i]["Remainsp1"];
                Сells["K" + startWith].NumberFormat = "### ### ##0.00";
                Сells["K" + startWith].Borders.LineStyle = LineStyle.Continous;
                Сells["K" + startWith].Font.Size = fontSize;
                Сells["K" + startWith].Borders[BordersIndex.EdgeRight].Weight = BorderWeight.Medium;

                if ((decimal)reportTable.Rows[i]["Remainsq1"] < 0 || (decimal)reportTable.Rows[i]["Remainsp1"] < 0)
                    Сells["A" + startWith + ":" + "K" + startWith].Interior.Color = Color.LightCoral;

                if ((i < reportTable.Rows.Count - 1 && reportTable.Rows[i]["Balance"].ToString() != reportTable.Rows[i + 1]["Balance"].ToString()) || i == reportTable.Rows.Count - 1)
                {
                    startWith++;
                    Сells["A" + startWith.ToString() + ":" + "D" + startWith.ToString()].Merge();
                    Сells["A" + startWith.ToString() + ":" + "K" + startWith.ToString()].Borders.LineStyle = LineStyle.Continous;
                    Сells["A" + startWith].Value = "Разом за балансовим рахунком    " + reportTable.Rows[i]["Balance"];
                    Сells["A" + startWith].Font.Bold = true;
                    Сells["A" + startWith].Font.Size = fontSize;

                    Сells["E" + startWith].Formula = "=SUM(E" + (startWith - a) + ":E" + (startWith - 1) + ")";
                    Сells["E" + startWith].NumberFormat = "### ### ##0.00";
                    Сells["E" + startWith].Interior.Color = System.Drawing.Color.LightGreen;
                    sum1 += Convert.ToDecimal(Сells["E" + startWith].Value.ToString());
                    Сells["E" + startWith].Font.Size = fontSize;

                    Сells["G" + startWith].Formula = "=SUM(G" + (startWith - a) + ":G" + (startWith - 1) + ")";
                    Сells["G" + startWith].NumberFormat = "### ### ##0.00";
                    Сells["G" + startWith].Interior.Color = System.Drawing.Color.LightGreen;
                    sum2 += Convert.ToDecimal(Сells["G" + startWith].Value.ToString());
                    Сells["G" + startWith].Font.Size = fontSize;

                    Сells["I" + startWith].Formula = "=SUM(I" + (startWith - a) + ":I" + (startWith - 1) + ")";
                    Сells["I" + startWith].NumberFormat = "### ### ##0.00";
                    Сells["I" + startWith].Interior.Color = System.Drawing.Color.LightGreen;
                    sum3 += Convert.ToDecimal(Сells["I" + startWith].Value.ToString());
                    Сells["I" + startWith].Font.Size = fontSize;

                    Сells["K" + startWith].Formula = "=SUM(K" + (startWith - a) + ":K" + (startWith - 1) + ")";
                    Сells["K" + startWith].NumberFormat = "### ### ##0.00";
                    Сells["K" + startWith].Interior.Color = System.Drawing.Color.LightGreen;

                    Сells["A" + (startWith - a) + ":" + "A" + (startWith - 1)].EntireRow.Group();

                    sum4 += Convert.ToDecimal(Сells["K" + startWith].Value);
                    Сells["K" + startWith].Font.Size = fontSize;
                    startWith++;
                }
            }

            startWith++;
            startWith++;
            Сells["A" + startWith.ToString() + ":" + "D" + startWith.ToString()].Merge();
            Сells["A" + startWith].Value = "Разом:";
            Сells["A" + startWith].Font.Bold = true;
            Сells["A" + startWith].Font.Size = fontSize;

            Сells["E" + startWith].Value = sum1;
            Сells["E" + startWith].NumberFormat = "### ### ##0.00";
            Сells["E" + startWith].Interior.Color = System.Drawing.Color.Green;
            Сells["E" + startWith].Font.Size = fontSize;

            Сells["G" + startWith].Value = sum2;
            Сells["G" + startWith].NumberFormat = "### ### ##0.00";
            Сells["G" + startWith].Interior.Color = System.Drawing.Color.Green;
            Сells["G" + startWith].Font.Size = fontSize;

            Сells["I" + startWith].Value = sum3;
            Сells["I" + startWith].NumberFormat = "### ### ##0.00";
            Сells["I" + startWith].Interior.Color = System.Drawing.Color.Green;
            Сells["I" + startWith].Font.Size = fontSize;

            Сells["K" + startWith].Value = sum4;
            Сells["K" + startWith].NumberFormat = "### ### ##0.00";
            Сells["K" + startWith].Interior.Color = System.Drawing.Color.Green;
            Сells["K" + startWith].Font.Size = fontSize;

            PrintSignatures(Сells, startWith + 3);

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "ОСВ по складу за період з " + StartDate + " по " + EndDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "ОСВ по складу за період з " + StartDate + " по " + EndDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void TrialBalanceAccounts(DataTable reportTable, string StartDate, string EndDate)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var balanceSource = reportTable.AsEnumerable()
                                .OrderBy(s => s["BalanceAccountNum"])
                                .ThenBy(w => w["FlagDebitCredit"])
                                .CopyToDataTable();

            var workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            Dictionary<int, string> DebitAcc = new Dictionary<int, string>();
            Dictionary<int, string> CreditAcc = new Dictionary<int, string>();
            Dictionary<string, byte> HeaderColumn = new Dictionary<string, byte>();

            int startDebitAccount = 0;
            int startCreditAccount = 0;
            int endDebitAccount = 0;
            int endCreditAccount = 0;

            int captionPosition = 6;
            int startPosition = captionPosition + 1;
            int currentPosition = startPosition + 3;
            byte startHeaderPosition = 1;

            #region Generate report header

            var Debit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") == 1).Select(c => new
            {
                AccountNum = c.Field<string>("PeriodAccountNum"),
                AccountId = c.Field<int>("PeriodAccountId")
            }).Distinct().OrderBy(c => c.AccountNum);

            foreach (var dict in Debit_Accounts)
                DebitAcc.Add(dict.AccountId, dict.AccountNum);


            var Credit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") == 2).Select(c => new
            {
                AccountNum = c.Field<string>("PeriodAccountNum"),
                AccountId = c.Field<int>("PeriodAccountId")
            }).Distinct().OrderBy(c => c.AccountNum).ToList();

            foreach (var dict in Credit_Accounts)
                CreditAcc.Add(dict.AccountId, dict.AccountNum);

            HeaderColumn.Add("BalanceAccountNum", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "№ рах.";

            startHeaderPosition++;

            HeaderColumn.Add("BeginRemains", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на початок";

            startHeaderPosition++;

            if (DebitAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("У кредит рахунків");
                HeaderColumn.Add("SumDebit", startHeaderPosition);
                cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
                cells[startPosition, startHeaderPosition - 1].Value = "Разом в дебет рахунку";

                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + (DebitAcc.Count + 1)] + (startPosition)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("У кредит рахунків");
                HeaderColumn.Add("SumDebit", startHeaderPosition);
                cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
                cells[startPosition, startHeaderPosition - 1].Value = "Разом в дебет рахунку";

                startHeaderPosition++;

                startDebitAccount = startHeaderPosition;
                foreach (var debit_account in DebitAcc)
                {
                    HeaderColumn.Add("DebitAccount" + debit_account.Key.ToString(), startHeaderPosition);
                    cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
                    cells[startPosition, startHeaderPosition - 1].Value = debit_account.Value;
                    startHeaderPosition++;
                }
                endDebitAccount = startHeaderPosition;
            }

            if (CreditAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("У дебет рахунків");
                HeaderColumn.Add("SumCredit", startHeaderPosition);
                cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
                cells[startPosition, startHeaderPosition - 1].Value = "Разом в кредит рахунку";

                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + (CreditAcc.Count + 1)] + (startPosition)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("У дебет рахунків");
                HeaderColumn.Add("SumCredit", startHeaderPosition);
                cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
                cells[startPosition, startHeaderPosition - 1].Value = "Разом в кредит рахунку";

                startHeaderPosition++;

                startCreditAccount = startHeaderPosition;
                foreach (var credit_account in CreditAcc)
                {
                    HeaderColumn.Add("CreditAccount" + credit_account.Key.ToString(), startHeaderPosition);
                    cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
                    cells[startPosition, startHeaderPosition - 1].Value = credit_account.Value;
                    startHeaderPosition++;
                }
                endCreditAccount = startHeaderPosition;
            }

            HeaderColumn.Add("EndRemains", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на кінець";

            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].WrapText = true;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].VerticalAlignment = VAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].HorizontalAlignment = HAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Font.Bold = true;
            cells["A" + ":" + vsS[startHeaderPosition - 1]].ColumnWidth = 18;

            #endregion

            #region Loop body

            int balanceAccountId = 0;
            string account = "";
            int sumPosition = 0;

            Action<int, int, int> WriteBalance = (sourceId, currentPos, _balanceAccountId) =>
            {
                var DebitBalance = balanceSource.AsEnumerable()
                                 .Where(s => (int)s["BalanceAccountId"] == _balanceAccountId && (int)s["FlagDebitCredit"] == 1);

                var CreditBalance = balanceSource.AsEnumerable()
                                 .Where(s => (int)s["BalanceAccountId"] == _balanceAccountId && (int)s["FlagDebitCredit"] == 2);

                if (DebitBalance.Count() > 0)
                {
                    foreach (var item in DebitBalance)
                    {
                        if ((int)item["PeriodAccountId"] > 0)
                        {
                            account = "DebitAccount" + item["PeriodAccountId"].ToString();
                            cells[vsS[HeaderColumn[account] - 1] + currentPos].Value = item["PeriodPrice"];
                        }
                    }
                }

                if (CreditBalance.Count() > 0)
                {
                    foreach (var item in CreditBalance)
                    {
                        if ((int)item["PeriodAccountId"] > 0)
                        {
                            account = "CreditAccount" + item["PeriodAccountId"].ToString();
                            cells[vsS[HeaderColumn[account] - 1] + currentPos].Value = item["PeriodPrice"];
                        }
                    }
                }
                
            };

            for (int i = 0; i < balanceSource.Rows.Count; i++)
            {
                if (balanceAccountId != (int)balanceSource.Rows[i]["BalanceAccountId"])
                {
                    balanceAccountId = (int)balanceSource.Rows[i]["BalanceAccountId"];

                    if (i > 0)
                    {
                        cells[vsS[HeaderColumn["BeginRemains"] - 1] + (currentPosition - 1) + ":" + vsS[HeaderColumn["BeginRemains"] - 1] + (currentPosition - 1)].Interior.Color = Color.LightGreen;
                        cells[vsS[HeaderColumn["EndRemains"] - 1] + (currentPosition - 1) + ":" + vsS[HeaderColumn["EndRemains"] - 1] + (currentPosition - 1)].Interior.Color = Color.LightGreen;
                        cells[vsS[HeaderColumn["SumDebit"] - 1] + (currentPosition - 1) + ":" + vsS[HeaderColumn["SumDebit"] - 1] + (currentPosition - 1)].Interior.Color = Color.LightSkyBlue;
                        cells[vsS[HeaderColumn["SumCredit"] - 1] + (currentPosition - 1) + ":" + vsS[HeaderColumn["SumCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.LightSkyBlue;

                        cells[vsS[HeaderColumn["SumDebit"] - 1] + (currentPosition - 1)].Formula = SetFormula(vsS[HeaderColumn["SumDebit"]], currentPosition - 1, vsS[HeaderColumn["SumCredit"] - 2], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["SumCredit"] - 1] + (currentPosition - 1)].Formula = SetFormula(vsS[HeaderColumn["SumCredit"]], currentPosition - 1, vsS[HeaderColumn["EndRemains"] - 2], currentPosition - 1, "SUM");                
                    }

                    cells[vsS[HeaderColumn["BalanceAccountNum"] - 1] + (currentPosition)].HorizontalAlignment = HAlign.Right;
                    cells[vsS[HeaderColumn["BalanceAccountNum"] - 1] + (currentPosition)].Value = balanceSource.Rows[i]["BalanceAccountNum"];
                    cells[vsS[HeaderColumn["BeginRemains"] - 1] + (currentPosition)].Value = balanceSource.Rows[i]["BeginRemains"];
                    cells[vsS[HeaderColumn["EndRemains"] - 1] + (currentPosition)].Value = balanceSource.Rows[i]["EndRemains"];

                    WriteBalance(i, currentPosition, balanceAccountId);
                    currentPosition++;
                }
                
            }

            #endregion

            #region Finally step output

            cells[vsS[HeaderColumn["BeginRemains"] - 1] + (currentPosition - 1) + ":" + vsS[HeaderColumn["BeginRemains"] - 1] + (currentPosition - 1)].Interior.Color = Color.LightGreen;
            cells[vsS[HeaderColumn["EndRemains"] - 1] + (currentPosition - 1) + ":" + vsS[HeaderColumn["EndRemains"] - 1] + (currentPosition - 1)].Interior.Color = Color.LightGreen;
            cells[vsS[HeaderColumn["SumDebit"] - 1] + (currentPosition - 1) + ":" + vsS[HeaderColumn["SumDebit"] - 1] + (currentPosition - 1)].Interior.Color = Color.LightSkyBlue;
            cells[vsS[HeaderColumn["SumCredit"] - 1] + (currentPosition - 1) + ":" + vsS[HeaderColumn["SumCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.LightSkyBlue;
            
            cells[vsS[HeaderColumn["SumDebit"] - 1] + (currentPosition - 1)].Formula = SetFormula(vsS[HeaderColumn["SumDebit"]], currentPosition - 1, vsS[HeaderColumn["SumCredit"] - 2], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["SumCredit"] - 1] + (currentPosition - 1)].Formula = SetFormula(vsS[HeaderColumn["SumCredit"]], currentPosition - 1, vsS[HeaderColumn["EndRemains"] - 2], currentPosition - 1, "SUM");
          
            cells["A" + (startPosition + 3) + ":" + vsS[startHeaderPosition - 1] + currentPosition].Borders.LineStyle = LineStyle.Continous;
            

            #endregion

            #region Result summary

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;
            cells["A" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Font.Bold = true;
            cells["A" + currentPosition].Value = "Всього";
            cells["B" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["BeginRemains"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["EndRemains"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";

            cells[vsS[HeaderColumn["BeginRemains"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["BeginRemains"] - 1], (startPosition + 3), vsS[HeaderColumn["BeginRemains"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndRemains"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndRemains"] - 1], (startPosition + 3), vsS[HeaderColumn["EndRemains"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["SumDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["SumDebit"] - 1], (startPosition + 3), vsS[HeaderColumn["SumDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["SumCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["SumCredit"] - 1], (startPosition + 3), vsS[HeaderColumn["SumCredit"] - 1], currentPosition - 1, "SUM");

            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = SetFormula(vsS[sumPosition - 1], (startPosition + 3), vsS[sumPosition - 1], currentPosition - 1, "SUM");
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = SetFormula(vsS[sumPosition - 1], (startPosition + 3), vsS[sumPosition - 1], currentPosition - 1, "SUM");
                }
            }

            #endregion

            #region Report caption

            cells["A" + captionPosition + ":" + vsS[startHeaderPosition - 1] + captionPosition].Merge();
            cells["A" + captionPosition].Value = "Оборотно-сальдова відомість по складу та рахункам за період з " + StartDate + " по " + EndDate;
            cells["A" + captionPosition].Font.Bold = true;
            cells["A" + captionPosition].VerticalAlignment = VAlign.Center;
            cells["A" + captionPosition].HorizontalAlignment = HAlign.Center;
            
            #endregion

            PrintSignatures(cells, currentPosition + 3);
            
            try
            {
                workbook.SaveAs(GeneratedReportsDir + "ОСВ по складу та рахункам за період з " + StartDate + " по " + EndDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "ОСВ по складу та рахункам за період з " + StartDate + " по " + EndDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void ReceiptsForDaysAndBalance(DataTable reportTable, string PeriodStart, string PeriodEnd, string BalanceNum)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "ReceiptsForBalanceAndDays.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;

            int captionPosition = 7;
            int startWith = captionPosition + 3;
            int a = 0;
            decimal sum = 0.00m;

            cells["A" + captionPosition].Value += PeriodStart + " по " + PeriodEnd;
            cells["A" + captionPosition].HorizontalAlignment = HAlign.Center;
            cells["A" + captionPosition].Font.Bold = true;

            cells["G" + captionPosition].Value += BalanceNum;
            cells["G" + captionPosition].HorizontalAlignment = HAlign.Center;
            cells["G" + captionPosition].Font.Bold = true;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (i == 0 || reportTable.Rows[i - 1]["Order_Date"].ToString().Trim() != reportTable.Rows[i]["Order_Date"].ToString().Trim())
                {
                    a = 0;

                    startWith++;
                    cells["A" + startWith.ToString() + ":" + "H" + startWith.ToString()].Merge();
                    cells["A" + startWith].Value = "Надхождення за " + Convert.ToDateTime(reportTable.Rows[i]["Order_Date"]).ToShortDateString();
                    cells["A" + startWith].HorizontalAlignment = HAlign.Center;
                    cells["A" + startWith].Font.Bold = true;
                }

                a++;
                startWith++;
                cells["A" + startWith].Value = a;
                cells["A" + startWith].Borders.LineStyle = LineStyle.Continous;
                cells["A" + startWith].HorizontalAlignment = HAlign.Center;

                cells["B" + startWith].Value = reportTable.Rows[i]["Receipt_Num"];
                cells["B" + startWith].Borders.LineStyle = LineStyle.Continous;
                cells["B" + startWith].HorizontalAlignment = HAlign.Center;

                cells["C" + startWith].Value = reportTable.Rows[i]["Nomenclature"];
                cells["C" + startWith].Borders.LineStyle = LineStyle.Continous;
                cells["C" + startWith].HorizontalAlignment = HAlign.Left;

                cells["D" + startWith].Value = reportTable.Rows[i]["Name"];
                cells["D" + startWith].Borders.LineStyle = LineStyle.Continous;
                cells["D" + startWith].HorizontalAlignment = HAlign.Left;

                cells["E" + startWith].Value = reportTable.Rows[i]["Measure"];
                cells["E" + startWith].Borders.LineStyle = LineStyle.Continous;
                cells["E" + startWith].HorizontalAlignment = HAlign.Center;

                cells["F" + startWith].Value = reportTable.Rows[i]["Quantity"];
                cells["F" + startWith].Borders.LineStyle = LineStyle.Continous;
                cells["F" + startWith].HorizontalAlignment = HAlign.Right;
                cells["F" + startWith].NumberFormat = "### ##0.000";

                cells["G" + startWith].Value = reportTable.Rows[i]["Unit_Price"];
                cells["G" + startWith].Borders.LineStyle = LineStyle.Continous;
                cells["G" + startWith].HorizontalAlignment = HAlign.Right;
                cells["G" + startWith].NumberFormat = "### ### ##0.00";

                cells["H" + startWith].Value = reportTable.Rows[i]["Total_Price"];
                cells["H" + startWith].Borders.LineStyle = LineStyle.Continous;
                cells["H" + startWith].HorizontalAlignment = HAlign.Right;
                cells["H" + startWith].NumberFormat = "### ### ##0.00";

                cells["I" + startWith].Value = reportTable.Rows[i]["Debit_Account_Num"];
                cells["I" + startWith].Borders.LineStyle = LineStyle.Continous;
                cells["I" + startWith].HorizontalAlignment = HAlign.Center;

                if ((i < reportTable.Rows.Count - 1 && reportTable.Rows[i]["Order_Date"].ToString() != reportTable.Rows[i + 1]["Order_Date"].ToString()) || i == reportTable.Rows.Count - 1)
                {
                    startWith++;
                    cells["A" + startWith.ToString() + ":" + "G" + startWith.ToString()].Merge();
                    cells["A" + startWith.ToString() + ":" + "H" + startWith.ToString()].Borders.LineStyle = LineStyle.Continous;
                    cells["A" + startWith].Value = "Разом по " + Convert.ToDateTime(reportTable.Rows[i]["Order_Date"]).ToShortDateString();
                    cells["A" + startWith].Font.Bold = true;
                    cells["A" + startWith].HorizontalAlignment = HAlign.Center;

                    cells["H" + startWith].Formula = SetFormula("H", (startWith - a), "H", (startWith - 1), "SUM");
                    cells["H" + startWith].NumberFormat = "### ### ##0.00";
                    cells["H" + startWith].Interior.Color = System.Drawing.Color.LightGreen;

                    sum += Convert.ToDecimal(cells["H" + startWith].Value);
                    startWith++;
                }
            }

            startWith++;
            cells["A" + startWith.ToString() + ":" + "G" + startWith.ToString()].Merge();
            cells["A" + startWith].Value = "Всього:";
            cells["A" + startWith].HorizontalAlignment = HAlign.Center;
            cells["A" + startWith].Font.Bold = true;
            cells["A" + startWith + ":" + "G" + startWith.ToString()].Borders.LineStyle = LineStyle.Continous;

            cells["H" + startWith].Value = sum;
            cells["H" + startWith].NumberFormat = "### ### ##0.00";
            cells["H" + startWith].Interior.Color = System.Drawing.Color.Green;
            cells["H" + startWith].Borders.LineStyle = LineStyle.Continous;

            PrintSignatures(cells, startWith + 3);

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Матеріали по балансовому рахунку та дням.xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Матеріали по балансовому рахунку та дням.xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void OrdersForVendor(DataTable reportTable, string Vendor, string StartDate, string EndDate)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            var Worksheet = Workbook.Worksheets[0];
            var Cells = Worksheet.Cells;

            int captionPosition = 6;
            int startWith = captionPosition + 4;

            Cells["A1" + ":" + "E1"].ColumnWidth = 15;

            Cells["A" + captionPosition + ":" + "E" + (captionPosition + 1)].Merge();
            Cells["A" + captionPosition + ":" + "E" + (captionPosition + 1)].Font.Bold = true;
            Cells["A" + captionPosition + ":" + "E" + (captionPosition + 1)].VerticalAlignment = VAlign.Center;
            Cells["A" + captionPosition + ":" + "E" + (captionPosition + 1)].HorizontalAlignment = HAlign.Center;
            Cells["A" + captionPosition + ":" + "E" + (captionPosition + 1)].Value = "Реєстр документів по ТОВ \"НВФ \"Техвагонмаш\" за період з " + StartDate + " по " + EndDate;
            Cells["A" + (captionPosition + 2)].Value = Vendor;
            Cells["A" + (captionPosition + 2)].Font.Bold = true;
            Cells["A" + (captionPosition + 2)].Font.Italic = true;

            double Sum = 0.00;
            int a = 0;
            
            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (i == 0 || reportTable.Rows[i]["Order_Date"].ToString().Substring(3) != reportTable.Rows[i - 1]["Order_Date"].ToString().Substring(3))
                {
                    a = 0;

                    Cells["A" + startWith].Value = "Надходження за " + reportTable.Rows[i]["Order_Date"].ToString().Substring(3, 7);
                    Cells["A" + startWith + ":" + "E" + startWith].Merge();
                    Cells["A" + startWith].HorizontalAlignment = HAlign.Center;
                    Cells["A" + startWith].Font.Bold = true;
                    startWith++;

                    Cells["A" + startWith].Value = "Дата надх.";
                    Cells["B" + startWith].Value = "Номер надх.";
                    Cells["C" + startWith].Value = "Дата накладної";
                    Cells["D" + startWith].Value = "Номер накладної";
                    Cells["E" + startWith].Value = "Сума з ПДВ";

                    Cells["A" + startWith + ":" + "E" + startWith].Font.Bold = true;
                    Cells["A" + startWith + ":" + "E" + startWith].HorizontalAlignment = HAlign.Center;
                    Cells["A" + startWith + ":" + "E" + startWith].Borders.LineStyle = LineStyle.Continous;

                    startWith++;
                }

                Cells["A" + startWith].Value = reportTable.Rows[i]["Order_Date"];
                Cells["A" + startWith].HorizontalAlignment = HAlign.Center;

                Cells["B" + startWith].Value = reportTable.Rows[i]["Receipt_Num"];
                Cells["B" + startWith].HorizontalAlignment = HAlign.Left;

                Cells["C" + startWith].Value = reportTable.Rows[i]["Invoice_Date"];
                Cells["C" + startWith].HorizontalAlignment = HAlign.Center;

                Cells["D" + startWith].Value = reportTable.Rows[i]["Invoice_Num"];
                Cells["D" + startWith].HorizontalAlignment = HAlign.Left;

                Cells["E" + startWith].Value = reportTable.Rows[i]["Total_Price"];
                Cells["E" + startWith].NumberFormat = "### ### ##0.00";
                Cells["E" + startWith].HorizontalAlignment = HAlign.Right;

                Cells["A" + startWith + ":" + "E" + startWith].Borders.LineStyle = LineStyle.Continous;

                if (reportTable.Rows[i]["Order_Date"].ToString().Substring(3) != reportTable.Rows[i]["Invoice_Date"].ToString().Substring(3))
                {
                    Cells["A" + startWith + ":" + "E" + startWith].Interior.Color = Color.Yellow;
                }

                startWith++; a++;

                if ((i < reportTable.Rows.Count - 1 && reportTable.Rows[i]["Order_Date"].ToString().Substring(3) != reportTable.Rows[i + 1]["Order_Date"].ToString().Substring(3)) || i == reportTable.Rows.Count - 1)
                {
                    Cells["A" + startWith + ":" + "D" + startWith].Merge();
                    Cells["A" + startWith].Value = "Всього за " + reportTable.Rows[i]["Order_Date"].ToString().Substring(3, 7);

                    Cells["E" + startWith].Formula = SetFormula("E", startWith - a, "E", startWith - 1, "SUM");
                    Cells["E" + startWith].NumberFormat = "### ### ##0.00";
                    Cells["E" + startWith].Interior.Color = Color.LightGreen;
                    Sum += Convert.ToDouble(Cells["E" + startWith].Value);

                    Cells["A" + startWith + ":" + "E" + startWith].Font.Bold = true;
                    Cells["A" + startWith + ":" + "E" + startWith].HorizontalAlignment = HAlign.Center;
                    Cells["A" + startWith + ":" + "E" + startWith].Borders.LineStyle = LineStyle.Continous;

                    startWith += 2;
                }
            }

            Cells["A" + startWith + ":" + "D" + startWith].Merge();
            Cells["A" + startWith].Value = "Разом";

            Cells["E" + startWith].Value = Sum;
            Cells["E" + startWith].NumberFormat = "### ### ##0.00";
            Cells["E" + startWith].Interior.Color = Color.Green;

            Cells["A" + startWith + ":" + "E" + startWith].Font.Bold = true;
            Cells["A" + startWith + ":" + "E" + startWith].HorizontalAlignment = HAlign.Center;
            Cells["A" + startWith + ":" + "E" + startWith].Borders.LineStyle = LineStyle.Continous;

            startWith += 2;
            Cells["A" + startWith + ":" + "D" + startWith].Merge();
            Cells["A" + startWith].Value = "Відповідальна особа: ______________________________________";
            startWith += 2;
            Cells["A" + startWith + ":" + "D" + startWith].Merge();
            Cells["A" + startWith].Value = "Контактний телефон: ______________________________________";

            PrintSignatures(Cells, startWith + 3);

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Ордера по постачальнику з " + StartDate + " по " + EndDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Ордера по постачальнику з " + StartDate + " по " + EndDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void ExpendituresForVendor(DataTable reportTable, string StartDate, string ExpDate, string Vendor, string Srn)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            int a = 0;
            double sum = 0.00, exp = 0.00, balance = 0.00;
            
            int startWith = 6;

            var Receipts = reportTable.AsEnumerable().Select
                (
                    c => new
                    {
                        receiptNum = c.Field<string>("Receipt_Num"),
                        orderDate = c.Field<DateTime>("Order_Date")
                    }
                ).Distinct();

            foreach (var receipt in Receipts)
            {
                startWith++;
                cells["A" + startWith].Value += Vendor + " обороти з " + StartDate + " по " + ExpDate;

                sum = 0.00;
                exp = 0.00;
                balance = 0.00;

                cells["A1" + ":" + "A1"].ColumnWidth = 15;
                cells["B1" + ":" + "B1"].ColumnWidth = 20;
                cells["C1" + ":" + "K1"].ColumnWidth = 12;

                startWith++;
                cells["A" + startWith + ":" + "K" + startWith].Merge();
                cells["A" + startWith].Value = "Надходження № " + receipt.receiptNum + " за " + receipt.orderDate.ToShortDateString();
                cells["A" + startWith].Font.Bold = true;
                cells["A" + startWith].HorizontalAlignment = HAlign.Center;

                startWith++;
                cells["A" + startWith + ":" + "E" + startWith].Merge();
                cells["A" + startWith].Value = "Надходження";
                cells["F" + startWith + ":" + "I" + startWith].Merge();
                cells["F" + startWith].Value = "Витрата";
                cells["J" + startWith + ":" + "K" + startWith].Merge();
                cells["J" + startWith].Value = "Сальдо";
                cells["A" + startWith + ":" + "K" + startWith].Font.Bold = true;
                cells["A" + startWith + ":" + "K" + startWith].HorizontalAlignment = HAlign.Center;
                cells["A" + startWith + ":" + "K" + startWith].Borders.LineStyle = LineStyle.Continous;

                startWith++;
                cells["A" + startWith].Value = "Ном. номер";
                cells["B" + startWith].Value = "Назва";
                cells["C" + startWith].Value = "Од. вим.";
                cells["D" + startWith].Value = "Кіл. надх.";
                cells["E" + startWith].Value = "Сума надх.";
                cells["F" + startWith].Value = "Дата витр.";
                cells["G" + startWith].Value = "Кіл. витр.";
                cells["H" + startWith].Value = "Сума витр.";
                cells["I" + startWith].Value = "Проект";
                cells["J" + startWith].Value = "Кіл. зал.";
                cells["K" + startWith].Value = "Сума зал.";

                cells["A" + startWith + ":" + "K" + startWith].Font.Bold = true;
                cells["A" + startWith + ":" + "K" + startWith].HorizontalAlignment = HAlign.Center;
                cells["A" + startWith + ":" + "K" + startWith].Borders.LineStyle = LineStyle.Continous;

                var Nomenclatures = reportTable.AsEnumerable().Where(c => c.Field<string>("Receipt_Num") == receipt.receiptNum).Select
                    (
                        c => new
                        {
                            nomenclature = c.Field<string>("Nomenclature"),
                            name = c.Field<string>("Nomenclature_Name"),
                            measure = c.Field<string>("Measure"),
                            quantity = c.Field<decimal>("Receipt_Quantity_Sum"),
                            price = c.Field<decimal>("Receipt_Price_Sum")
                        }
                    ).Distinct();

                foreach (var nomenclature in Nomenclatures)
                {
                    a = 0;
                    startWith++;
                    //
                    cells["A" + startWith].Value = nomenclature.nomenclature;
                    cells["A" + startWith].HorizontalAlignment = HAlign.Left;
                    //
                    
                    cells["B" + startWith].WrapText = true;
                    cells["B" + startWith].VerticalAlignment = VAlign.Center;
                    cells["B" + startWith].HorizontalAlignment = HAlign.Left;
                    cells["B" + startWith].Value = nomenclature.name;
                    //
                    cells["C" + startWith].Value = nomenclature.measure;
                    cells["C" + startWith].HorizontalAlignment = HAlign.Center;
                    //
                    cells["D" + startWith].Value = nomenclature.quantity;
                    cells["D" + startWith].NumberFormat = "# ### ##0.000#";
                    cells["D" + startWith].HorizontalAlignment = HAlign.Right;
                    //
                    cells["E" + startWith].Value = nomenclature.price;
                    cells["E" + startWith].NumberFormat = "### ### ##0.00";
                    cells["E" + startWith].HorizontalAlignment = HAlign.Right;
                    //
                    cells["A" + startWith + ":" + "E" + startWith].Borders.LineStyle = LineStyle.Continous;

                    var Expenditures = reportTable.AsEnumerable().Where(c => c.Field<string>("Nomenclature") == nomenclature.nomenclature && c.Field<string>("Receipt_Num") == receipt.receiptNum).Select
                        (
                            c => new
                            {
                                exp_date = c.Field<DateTime?>("Exp_Date"),
                                exp_quantity = c.Field<decimal?>("Expenditure_Quantity"),
                                exp_price = c.Field<decimal?>("Expenditure_Price"),
                                exp_project = c.Field<string>("Project_Num")
                            }
                        );

                    foreach (var expenditures in Expenditures)
                    {
                        cells["F" + startWith].Value = expenditures.exp_date != null ? expenditures.exp_date.ToString().Substring(0, 10) : "";
                        cells["F" + startWith].HorizontalAlignment = HAlign.Center;
                        cells["F" + startWith].Borders.LineStyle = LineStyle.Continous;
                        //
                        cells["G" + startWith].Value = expenditures.exp_quantity;
                        cells["G" + startWith].NumberFormat = "# ### ##0.000#";
                        cells["G" + startWith].HorizontalAlignment = HAlign.Right;
                        cells["G" + startWith].Borders.LineStyle = LineStyle.Continous;
                        //
                        cells["H" + startWith].Value = expenditures.exp_price;
                        cells["H" + startWith].NumberFormat = "### ### ##0.00";
                        cells["H" + startWith].HorizontalAlignment = HAlign.Right;
                        cells["H" + startWith].Borders.LineStyle = LineStyle.Continous;
                        //
                        cells["I" + startWith].Value = expenditures.exp_project;
                        cells["I" + startWith].Borders.LineStyle = LineStyle.Continous;
                        cells["I" + startWith].HorizontalAlignment = HAlign.Center;
                        //
                        exp += Convert.ToDouble(cells["H" + startWith].Value);
                        //
                        startWith++;
                        a++;
                    }

                    cells["A" + (startWith - a) + ":" + "A" + (startWith - 1)].Merge();
                    cells["B" + (startWith - a) + ":" + "B" + (startWith - 1)].Merge();
                    cells["C" + (startWith - a) + ":" + "C" + (startWith - 1)].Merge();
                    cells["D" + (startWith - a) + ":" + "D" + (startWith - 1)].Merge();
                    cells["E" + (startWith - a) + ":" + "E" + (startWith - 1)].Merge();
                    //
                    cells["J" + (startWith - a) + ":" + "J" + (startWith - 1)].Merge();
                    cells["K" + (startWith - a) + ":" + "K" + (startWith - 1)].Merge();

                    cells["J" + (startWith - a) + ":" + "K" + (startWith - 1)].HorizontalAlignment = HAlign.Right;
                    cells["J" + (startWith - a) + ":" + "K" + (startWith - 1)].Borders.LineStyle = LineStyle.Continous;
                    //
                    cells["J" + (startWith - a)].Formula = "=D" + (startWith - a) + " - " + SetFormula("G", startWith - a, "G", startWith - 1, "SUM", false);
                    cells["J" + (startWith - a)].NumberFormat = "# ### ##0.000#";
                    //
                    cells["K" + (startWith - a)].Formula = "=E" + (startWith - a) + " - " + SetFormula("H", startWith - a, "H", startWith - 1, "SUM", false);
                    cells["K" + (startWith - a)].NumberFormat = "### ### ##0.00";
                    //
                    cells["G" + startWith].Formula = SetFormula("G", startWith - a, "G", startWith - 1, "SUM");
                    cells["G" + startWith].NumberFormat = "# ### ##0.000#";
                    cells["G" + startWith].Font.Bold = true;
                    cells["G" + startWith].HorizontalAlignment = HAlign.Center;
                    cells["G" + startWith].Borders.LineStyle = LineStyle.Continous;
                    cells["G" + startWith].Interior.Color = Color.LightGreen;
                    //
                    cells["H" + startWith].Formula = SetFormula("H", startWith - a, "H", startWith - 1, "SUM");
                    cells["H" + startWith].NumberFormat = "### ### ##0.00";
                    cells["H" + startWith].Font.Bold = true;
                    cells["H" + startWith].HorizontalAlignment = HAlign.Center;
                    cells["H" + startWith].Borders.LineStyle = LineStyle.Continous;
                    cells["H" + startWith].Interior.Color = Color.LightGreen;
                    //
                    sum += Convert.ToDouble(cells["E" + (startWith - a)].Value);
                    balance += Convert.ToDouble(cells["J" + (startWith - a)].Value);
                    //
                    startWith++;
                }

                cells["A" + startWith].Value = "Надходження";
                cells["B" + startWith].Value = sum;
                startWith++;
                cells["A" + startWith].Value = "Витрати";
                cells["B" + startWith].Value = exp;
                startWith++;
                cells["A" + startWith].Value = "Сальдо";
                cells["B" + startWith].Value = balance;

                cells["B" + (startWith - 3) + ":" + "B" + startWith].NumberFormat = "### ### ##0.00";
                cells["A" + (startWith - 3) + ":" + "B" + startWith].Font.Bold = true;
                cells["A" + (startWith - 3) + ":" + "B" + startWith].HorizontalAlignment = HAlign.Left;

                startWith++;
                SetPageBreak(worksheet, startWith, 0);
            }

            PrintSignatures(cells, startWith + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + "Обороты по поставщику " + Srn + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Обороты по поставщику " + Srn + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void Inventory(DataTable reportTable, string reportDate)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За обраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            IWorksheet Worksheet = Workbook.Worksheets[0];
            IRange Cells = Worksheet.Cells;

            string curSheetName = "Лист1";
            ushort StartWith = 1, n = 1;
            //byte WSheet = 0;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (i == 0 || reportTable.Rows[i]["Balance_Num"].ToString().Trim() != reportTable.Rows[i - 1]["Balance_Num"].ToString().Trim())
                {
                    Worksheet = (IWorksheet)Workbook.Worksheets["Лист1"].CopyAfter(Workbook.Worksheets[curSheetName]);
                    Worksheet.PageSetup.RightFooter = "&A - &P";
                    Worksheet.PageSetup.FooterMargin = 0.1;
                    Worksheet.PageSetup.TopMargin = 15; 
                    Worksheet.PageSetup.BottomMargin = 28; 
                    Worksheet.PageSetup.LeftMargin = 15; 
                    Worksheet.PageSetup.RightMargin = 15;
                    
                    curSheetName = reportTable.Rows[i]["Balance_Num"].ToString().Replace('/', '.');
                    Worksheet.Name = curSheetName;
                    Cells = Worksheet.Cells;

                    StartWith = 29;
                    n = 1;

                    Cells["A1"].ColumnWidth = 6;
                    Cells["C1"].ColumnWidth = 23;
                    Cells["D27"].ColumnWidth = 12;
                    Cells["E27"].ColumnWidth = 14.5;
                    Cells["F27"].ColumnWidth = 12;
                    Cells["G27"].ColumnWidth = 14.5;
                    Cells["B26"].ColumnWidth = 12;

                    Cells["A6"].Value = "Цех(Склад)";
                    Cells["A7:G8"].Merge();
                    Cells["A7"].HorizontalAlignment = HAlign.Center;
                    Cells["A7"].Value = "Інвентаризаційна відомість № \n товарно-матеріальних цінностей";

                    Cells["A9:G9"].Merge();
                    Cells["A9"].HorizontalAlignment = HAlign.Center; 
                    Cells["A9"].VerticalAlignment = VAlign.Center;
                    Cells["A9"].Value = "за станом на " + reportDate;//"\"" + Convert.ToDateTime(reportDate).Day + "\"" + Convert.ToDateTime(reportDate).Month + " " + Convert.ToDateTime(reportDate).Year + " г. \n";

                    Cells["A11:G11"].Merge();
                    Cells["A11"].HorizontalAlignment = HAlign.Center;
                    Cells["A11"].Value = "Розписка";
                    Cells["A12:G12"].Merge();
                    Cells["A12"].RowHeight = 50;
                    Cells["A12:G12"].HorizontalAlignment = HAlign.Left; Cells["A10:G10"].VerticalAlignment = VAlign.Center;
                    Cells["A12:G12"].WrapText = true;
                    Cells["A12"].Value =
                        "До початку проведення інвентаризації всі видаткові та прибуткові документи на " +
                        "товарно-матеріальні цінності здані в бухгалтерію і всі товарно-матеріальні " +
                        "цінності надійшли на мою (нашу) відповідальність, оприбутковані, а вибулі " +
                        "списані у витрати.";
                    Cells["A13:G13"].Merge();
                    Cells["A13"].HorizontalAlignment = HAlign.Center; Cells["A13"].VerticalAlignment = VAlign.Center;
                    //Cells["A13"].Value = "                                                                                       ";
                    Cells["A14"].Value = "Посада"; Cells["D14"].Value = "Прізвище І.Б."; Cells["G14"].Value = "Підпис"; Cells["G14"].HorizontalAlignment = HAlign.Right;
                    Cells["A16:G16"].Merge();
                    Cells["A16"].HorizontalAlignment = HAlign.Center; Cells["A16"].VerticalAlignment = VAlign.Center;
                    //Cells["A16"].Value = "                                                                                       ";
                    Cells["A17"].Value = "Посада"; Cells["D17"].Value = "Прізвище І.Б."; Cells["G17"].Value = "Підпис"; Cells["G17"].HorizontalAlignment = HAlign.Right;

                    Cells["A19:G19"].Merge();
                    Cells["A19"].WrapText = true;
                    Cells["A19"].HorizontalAlignment = HAlign.Left; Cells["A19"].VerticalAlignment = VAlign.Center;
                    Cells["A19"].Value =
                        "На підставі наказу (розпорядження) № від року " +
                        "зроблено зняття фактичних залишків цінностей діляться на балансовому рахунку № " + reportTable.Rows[i]["Balance_Num"].ToString().Replace('/', '.') +
                        " станом на " + reportDate;
                    Cells["A19"].RowHeight = 32;

                    Cells["A21:G21"].Merge();
                    Cells["A21"].Value = "Інвентаризація розпочата \"_____\"______________20___р.";
                    Cells["A23:G23"].Merge();
                    Cells["A23"].Value = "Інвентаризація розпочата \"_____\"______________20___р.";
                    Cells["A25:G25"].Merge();
                    Cells["A25"].Value = "При інвентаризації встановлено таке:";


                    Cells["A26:G28"].HorizontalAlignment = HAlign.Center; Cells["A26:G28"].VerticalAlignment = VAlign.Center;
                    Cells["A26:G28"].Font.Bold = true;
                    Cells["A26:G28"].Borders.LineStyle = LineStyle.Continous;

                    Cells["A26:A27"].Merge();
                    Cells["A26"].Value = "№ п/п";
                    Cells["B26:B27"].Merge();
                    Cells["B26"].Value = "Ном. номер";
                    Cells["C26:C27"].Merge();
                    Cells["C26"].Value = "Найменування";
                    Cells["D26:E26"].Merge();
                    Cells["D26"].Value = "Фактична наявність";
                    Cells["D27"].Value = "Кіль-ть";
                    Cells["E27"].Value = "Сума";

                    Cells["F26:G26"].Merge();
                    Cells["F26"].Value = "За даними бухобліку";
                    Cells["F27"].Value = "Кіль-ть";
                    Cells["G27"].Value = "Сума";
                    Cells["A26:G27"].Font.Bold = true;

                    Cells["A28"].Value = "1";
                    Cells["B28"].Value = "2";
                    Cells["C28"].Value = "3";
                    Cells["D28"].Value = "4";
                    Cells["E28"].Value = "5";
                    Cells["F28"].Value = "6";
                    Cells["G28"].Value = "7";
                }

                Cells["A" + StartWith].Value = n.ToString();
                Cells["B" + StartWith].Value = reportTable.Rows[i]["Nomenclature"];
                Cells["C" + StartWith].Value = reportTable.Rows[i]["Name"];
                Cells["D" + StartWith].Value = reportTable.Rows[i]["Remains_Quantity"];
                Cells["D" + StartWith].NumberFormat = "### ##0.000";
                Cells["E" + StartWith].Value = reportTable.Rows[i]["Remains_Sum"];
                Cells["E" + StartWith].NumberFormat = "### ### ##0.00";
                Cells["F" + StartWith].Value = reportTable.Rows[i]["Remains_Quantity"];
                Cells["F" + StartWith].NumberFormat = "### ##0.000";
                Cells["G" + StartWith].Value = reportTable.Rows[i]["Remains_Sum"];
                Cells["G" + StartWith].NumberFormat = "### ### ##0.00";

                Cells["A" + StartWith + ":" + "A" + StartWith].HorizontalAlignment = HAlign.Center;
                Cells["B" + StartWith + ":" + "B" + StartWith].HorizontalAlignment = HAlign.Left;

                Cells["A" + StartWith + ":" + "G" + StartWith].VerticalAlignment = VAlign.Center;
                Cells["A" + StartWith + ":" + "G" + StartWith].Borders.LineStyle = LineStyle.Continous;
                n++;
                StartWith++;

                if ((i < reportTable.Rows.Count - 1 && reportTable.Rows[i]["Balance_Num"].ToString() != reportTable.Rows[i + 1]["Balance_Num"].ToString()) || i == reportTable.Rows.Count - 1)
                {
                    Cells["C" + (StartWith - n + 1) + ":" + "C" + (StartWith - 1)].WrapText = true;
                    //Cells["A" + StartWith + ":" + "D" + StartWith].Merge();
                    Cells["A" + StartWith].Value = "Разом за балансовим рахунком " + reportTable.Rows[i]["Balance_Num"].ToString().Replace('/', '.');
                    Cells["E" + StartWith].Value = SetFormula("E", StartWith - n + 1, "E", StartWith - 1, "SUM");
                    double Sum = Convert.ToDouble(Cells["E" + StartWith].Value);
                    Cells["E" + StartWith].Font.Bold = true;
                    Cells["E" + StartWith].NumberFormat = "### ### ##0.00";
                    Cells["G" + StartWith].Value = SetFormula("G", StartWith - n + 1, "G", StartWith - 1, "SUM");
                    Cells["G" + StartWith].Font.Bold = true;
                    Cells["G" + StartWith].NumberFormat = "### ### ##0.00";
                    //
                    StartWith += 2;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    Cells["A" + StartWith].Value = "Загальна кількість одиниць фактично";
                    StartWith++;
                    Cells["E" + StartWith].Value = "(Прописом)";
                    //
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    Cells["A" + StartWith].Value = "Разом фактично за описом:";
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    Cells["A" + StartWith].Value = RuDateAndMoneyConverter.CurrencyToTxt(Sum, true);
                    StartWith++;
                    Cells["E" + StartWith].Value = "(Прописом)";
                    //
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    Cells["A" + StartWith].Value = "Голова комісії";
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].HorizontalAlignment = HAlign.Center; Cells["A" + StartWith + ":" + "G" + StartWith].VerticalAlignment = VAlign.Center;
                    Cells["C" + StartWith].Value = "Посада"; Cells["E" + StartWith].Value = "Прізвище І.Б."; Cells["G" + StartWith].Value = "Підпис";
                    //
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    Cells["A" + StartWith].Value = "Члени комісії";
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].HorizontalAlignment = HAlign.Center; Cells["A" + StartWith + ":" + "G" + StartWith].VerticalAlignment = VAlign.Center;
                    Cells["C" + StartWith].Value = "Посада"; Cells["E" + StartWith].Value = "Прізвище І.Б."; Cells["G" + StartWith].Value = "Підпис";
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    //Cells["A" + StartWith].Value = "_________________________________________________________________________________________";
                    Cells["A" + StartWith + ":" + "G" + StartWith].HorizontalAlignment = HAlign.Center; Cells["A" + StartWith + ":" + "G" + StartWith].VerticalAlignment = VAlign.Center;
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].HorizontalAlignment = HAlign.Center; Cells["A" + StartWith + ":" + "G" + StartWith].VerticalAlignment = VAlign.Center;
                    Cells["C" + StartWith].Value = "Посада"; Cells["E" + StartWith].Value = "Прізвище І.Б."; Cells["G" + StartWith].Value = "Підпис";
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    //Cells["A" + StartWith].Value = "_________________________________________________________________________________________";
                    Cells["A" + StartWith + ":" + "G" + StartWith].HorizontalAlignment = HAlign.Center; Cells["A" + StartWith + ":" + "G" + StartWith].VerticalAlignment = VAlign.Center;
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].HorizontalAlignment = HAlign.Center; Cells["A" + StartWith + ":" + "G" + StartWith].VerticalAlignment = VAlign.Center;
                    Cells["C" + StartWith].Value = "Посада"; Cells["E" + StartWith].Value = "Прізвище І.Б."; Cells["G" + StartWith].Value = "Підпис";
                    //
                    StartWith += 2;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    Cells["A" + StartWith].Value = "Усі цінності пойменовані в цьому інвентаризаційному описі з № по № ";
                    //
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    //Cells["A" + StartWith].Value = "_______________________________________________________________________________________";
                    //
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    //Cells["A" + StartWith].Value = "_______________________________________________________________________________________";
                    //
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    //Cells["A" + StartWith].Value = "_______________________________________________________________________________________";
                    //
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    Cells["A" + StartWith].HorizontalAlignment = HAlign.Center; Cells["A" + StartWith].VerticalAlignment = VAlign.Center;
                    Cells["A" + StartWith].Value = "Матеріально-відповідальна особа (особи)";
                    //
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    Cells["A" + StartWith].Value = "\"_____\"______________20___р.";;
                    //
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    Cells["A" + StartWith].Value = "Вказані у даному описі дані і підрахунки перевірив";
                    //
                    StartWith++;
                    Cells["A" + StartWith + ":" + "G" + StartWith].Merge();
                    Cells["A" + StartWith].Value = "\"_____\"______________20___р.";
                    StartWith++;
                    Cells["E" + StartWith + ":" + "G" + StartWith].HorizontalAlignment = HAlign.Center; Cells["E" + StartWith + ":" + "G" + StartWith].VerticalAlignment = VAlign.Center;
                    Cells["E" + StartWith].Value = "Посада";
                    Cells["G" + StartWith].Value = "Підпис";

                }
            }
            
            Workbook.Worksheets[0].Delete();
            Workbook.WindowInfo.ActiveSheet = Workbook.Worksheets[0];
           
            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Інвентаризаційна відомість за " + reportDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Інвентаризаційна відомість за " + reportDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдено програму Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void InvoiceRequirement(DataTable reportTable, string number, string date, string responsiblePerson)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За выбранный период нет данных!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "InvoiceRequirement.xlsx");
            var Worksheet = Workbook.Worksheets[0];
            var Сells = Worksheet.Cells;

            int startWith = 25;

            double totalSum = 0;
            double totalQunatity = 0;

            Сells["A" + 16].Value = number;
            Сells["C" + 16].Value = date;
            Сells["B" + 20].Value = responsiblePerson;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                Сells["A" + startWith].Value = reportTable.Rows[i]["Num"];
                Сells["A" + startWith].HorizontalAlignment = HAlign.Center;
                Сells["B" + startWith].Value = reportTable.Rows[i]["Expen_Account"];
                Сells["C" + startWith].Value = reportTable.Rows[i]["Name"];
                Сells["D" + startWith].Value = reportTable.Rows[i]["Nomenclature"];
                Сells["F" + startWith].Value = reportTable.Rows[i]["Measure"];
                Сells["G" + startWith].Value = reportTable.Rows[i]["Required_Quantity"];
                Сells["H" + startWith].Value = reportTable.Rows[i]["Expen_Quantity"];
                Сells["I" + startWith].Value = reportTable.Rows[i]["Unit_Price"];
                Сells["J" + startWith].Value = reportTable.Rows[i]["Total_Price"];
                Сells["K" + startWith].Value = reportTable.Rows[i]["InventoryNumber"];

                Сells["M" + startWith + ":" + ("N" + startWith).ToString()].Merge();

                Сells["M" + startWith].Value = reportTable.Rows[i]["Receipt_Num"].ToString();
                Сells["M" + startWith].HorizontalAlignment = HAlign.Right;
                Сells["M" + startWith].NumberFormat = "@";
                startWith++;

                totalSum += (reportTable.Rows[i]["Total_Price"] is DBNull) ? 0 : Convert.ToDouble(reportTable.Rows[i]["Total_Price"]);
                totalQunatity += (reportTable.Rows[i]["Required_Quantity"] is DBNull) ? 0 : Convert.ToDouble(reportTable.Rows[i]["Required_Quantity"]);
            }

            Сells["A" + 25 + ":" + ("N" + (startWith - 1)).ToString()].Borders.LineStyle = LineStyle.Continous;

            startWith++;
            Сells["A" + startWith].Value = "Всього відпущено";
            Сells["A" + startWith].HorizontalAlignment = HAlign.Left;

            Сells["C" + startWith + ":" + ("G" + startWith).ToString()].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
            Сells["C" + startWith].Value = RuDateAndMoneyConverter.NumeralsDoubleToTxt(totalQunatity, 2, TextCase.Accusative, true);
            Сells["C" + startWith].HorizontalAlignment = HAlign.Left;
            Сells["H" + startWith].Value = "найменувань, на суму  ";
            Сells["K" + startWith + ":" + ("N" + startWith).ToString()].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;

            startWith++;
            startWith++;
            Сells["A" + startWith].Value = RuDateAndMoneyConverter.CurrencyToTxt(totalSum, true);
            Сells["A" + startWith].HorizontalAlignment = HAlign.Left;
            Сells["A" + startWith + ":" + ("M" + startWith).ToString()].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
            Сells["N" + startWith].Value = "грн.";

            startWith++;
            startWith++;
            Сells["A" + startWith].Value = "Відпуск дозволив";
            startWith++;
            Сells["A" + startWith].Value = "Головний інженер";
            Сells["C" + startWith].Value = "__________________________";
            Сells["H" + startWith].Value = "Головний бухгалтер________________________";
            startWith++;
            startWith++;
            Сells["A" + startWith].Value = "Здав (відпустив)";
            Сells["C" + startWith].Value = "_________________________________";
            Сells["D" + startWith].Value = "Прийняв (одержав) ";
            Сells["G" + startWith].Value = responsiblePerson;
            Сells["G" + startWith].Font.Underline = UnderlineStyle.Single;

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Накладна вимога " + Convert.ToDateTime(date).Month + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Накладна вимога " + Convert.ToDateTime(date).Month + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        #endregion Storehouse

        //----------------------------------------------------------------------------------------------------------------------------------------

        #region MutualSettlements

        public class Credit
        {
            public int Column;
            public double Sum;
        }

        public class Debit
        {
            public int Column;
            public double Sum;
        }

        public void MSTrialBalance(DataTable reportTable, string StartDate, string EndDate, string FlagType)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var workbook = Factory.GetWorkbook(TemplatesDir + "MSTrialBalance.xls");
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            string name = string.Format("Оборотно-сальдова відомість по контрагентам за період з {0} по {1} ({2})", StartDate, EndDate, FlagType);
            
            int captionPosition = 6;
            int startPosition = captionPosition + 4; 
            int currentPosition = startPosition;

            cells["A" + captionPosition].Value = name;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                cells["A" + currentPosition].Value = reportTable.Rows[i]["Contractor_Srn"];
                //
                cells["B" + currentPosition].Value = reportTable.Rows[i]["Contractor_Name"];
                //
                cells["C" + currentPosition].Value = reportTable.Rows[i]["Begin_Debit"];
                cells["D" + currentPosition].Value = reportTable.Rows[i]["Begin_Credit"];
                //
                cells["E" + currentPosition].Value = reportTable.Rows[i]["Period_Debit"];
                cells["F" + currentPosition].Value = reportTable.Rows[i]["Period_Credit"];
                //
                cells["G" + currentPosition].Value = reportTable.Rows[i]["End_Debit"];
                cells["H" + currentPosition].Value = reportTable.Rows[i]["End_Credit"];
                //
                currentPosition++;
            }

            cells["A" + startPosition + ":" + "B" + currentPosition].HorizontalAlignment = HAlign.Left;
            //cells["A" + startPosition + ":" + "A" + currentPosition].NumberFormat = "############";
            cells["B" + startPosition + ":" + "B" + currentPosition].WrapText = true;
            cells["C" + startPosition + ":" + "H" + currentPosition].HorizontalAlignment = HAlign.Right;

            cells["A" + currentPosition + ":" + "B" + currentPosition].Merge();
            cells["A" + currentPosition + ":" + "B" + currentPosition].HorizontalAlignment = HAlign.Center;
            cells["A" + currentPosition].Value = "Разом";

            cells["C" + currentPosition].Formula = SetFormula("C", startPosition, "C", currentPosition - 1, "SUM");
            cells["D" + currentPosition].Formula = SetFormula("D", startPosition, "D", currentPosition - 1, "SUM");
            cells["E" + currentPosition].Formula = SetFormula("E", startPosition, "E", currentPosition - 1, "SUM");
            cells["F" + currentPosition].Formula = SetFormula("F", startPosition, "F", currentPosition - 1, "SUM");
            cells["G" + currentPosition].Formula = SetFormula("G", startPosition, "G", currentPosition - 1, "SUM");
            cells["H" + currentPosition].Formula = SetFormula("H", startPosition, "H", currentPosition - 1, "SUM");

            cells["A" + currentPosition + ":" + "H" + currentPosition].Font.Bold = true;
            cells["C" + currentPosition + ":" + "H" + currentPosition].Interior.Color = Color.LightGreen;

            cells["C" + startPosition + ":" + "H" + currentPosition].NumberFormat = "### ### ##0.00";
            cells["A" + startPosition + ":" + "H" + currentPosition].Borders.LineStyle = LineStyle.Continous;

            cells["B" + startPosition + ":" + "B" + currentPosition].Borders[BordersIndex.EdgeRight].Weight = BorderWeight.Medium;
            cells["D" + startPosition + ":" + "D" + currentPosition].Borders[BordersIndex.EdgeRight].Weight = BorderWeight.Medium;
            cells["F" + startPosition + ":" + "F" + currentPosition].Borders[BordersIndex.EdgeRight].Weight = BorderWeight.Medium;

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + string.Format("ОСВ по контрагентам за період з {0} по {1} ({2})", StartDate, EndDate, FlagType) + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + string.Format("ОСВ по контрагентам за період з {0} по {1} ({2})", StartDate, EndDate, FlagType) + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void MSTrialBalanceCurrency(DataTable reportTable, string StartDate, string EndDate, string FlagType)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var workbook = Factory.GetWorkbook(TemplatesDir + "MSTrialBalanceCurrency.xls");
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            string name = string.Format("Оборотно-сальдова відомість по контрагентам за період з {0} по {1} ({2})", StartDate, EndDate, FlagType);

            int captionPosition = 6;
            int startPosition = captionPosition + 5;
            int currentPosition = startPosition;

            cells["A" + captionPosition].Value = name;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                cells["A" + currentPosition].Value = reportTable.Rows[i]["ContractorSrn"];
                //
                cells["B" + currentPosition].Value = reportTable.Rows[i]["ContractorName"];
                //
                cells["C" + currentPosition].Value = (reportTable.Rows[i]["DebitCurrencyName"] == DBNull.Value ? reportTable.Rows[i]["BankCurrencyName"] : reportTable.Rows[i]["DebitCurrencyName"]);
                //
                cells["D" + currentPosition].Value = reportTable.Rows[i]["StartDebitCurrency"];
                cells["E" + currentPosition].Value = reportTable.Rows[i]["StartDebit"];
                cells["F" + currentPosition].Value = reportTable.Rows[i]["StartCreditCurrency"];
                cells["G" + currentPosition].Value = reportTable.Rows[i]["StartCredit"];

                cells["H" + currentPosition].Value = reportTable.Rows[i]["PeriodDebitCurrency"];
                cells["I" + currentPosition].Value = reportTable.Rows[i]["PeriodDebit"];
                cells["J" + currentPosition].Value = reportTable.Rows[i]["PeriodCreditCurrency"];
                cells["K" + currentPosition].Value = reportTable.Rows[i]["PeriodCredit"];

                cells["L" + currentPosition].Value = reportTable.Rows[i]["EndDebitCurrency"];
                cells["M" + currentPosition].Value = reportTable.Rows[i]["EndDebit"];
                cells["N" + currentPosition].Value = reportTable.Rows[i]["EndCreditCurrency"];
                cells["O" + currentPosition].Value = reportTable.Rows[i]["EndCredit"];
                //
                currentPosition++;
            }

            cells["A" + startPosition + ":" + "B" + currentPosition].HorizontalAlignment = HAlign.Left;
            cells["B" + startPosition + ":" + "B" + currentPosition].WrapText = true;
            cells["C" + startPosition + ":" + "H" + currentPosition].HorizontalAlignment = HAlign.Right;

            cells["A" + currentPosition + ":" + "B" + currentPosition].Merge();
            cells["A" + currentPosition + ":" + "B" + currentPosition].HorizontalAlignment = HAlign.Center;
            cells["A" + currentPosition].Value = "Разом";
            
            cells["E" + currentPosition].Formula = SetFormula("E", startPosition, "E", currentPosition - 1, "SUM");
            cells["G" + currentPosition].Formula = SetFormula("G", startPosition, "G", currentPosition - 1, "SUM");
            cells["I" + currentPosition].Formula = SetFormula("I", startPosition, "I", currentPosition - 1, "SUM");
            cells["K" + currentPosition].Formula = SetFormula("K", startPosition, "K", currentPosition - 1, "SUM");
            cells["M" + currentPosition].Formula = SetFormula("M", startPosition, "M", currentPosition - 1, "SUM");
            cells["O" + currentPosition].Formula = SetFormula("O", startPosition, "O", currentPosition - 1, "SUM");

            cells["A" + currentPosition + ":" + "O" + currentPosition].Font.Bold = true;
            cells["C" + currentPosition + ":" + "O" + currentPosition].Interior.Color = Color.LightGreen;

            cells["C" + startPosition + ":" + "O" + currentPosition].NumberFormat = "### ### ##0.00";
            cells["A" + startPosition + ":" + "O" + currentPosition].Borders.LineStyle = LineStyle.Continous;

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + string.Format("ОСВ по контрагентам за період з {0} по {1} ({2})", StartDate, EndDate, FlagType) + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + string.Format("ОСВ по контрагентам за період з {0} по {1} ({2})", StartDate, EndDate, FlagType) + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void MSTrialBalanceCurrency681(DataTable reportTable, string StartDate, string EndDate, string FlagType)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var workbook = Factory.GetWorkbook(TemplatesDir + "MSTrialBalanceCurrency.xls");
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            string subName = "Розрахунки за авансами одержаними";
            string name = string.Format("Рахунок {0} \"{1}\" станом за період з {2} по {3}", FlagType, subName, StartDate, EndDate);

            int captionPosition = 6;
            int startPosition = captionPosition + 5;
            int currentPosition = startPosition;

            cells["A" + captionPosition].Value = name;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                cells["A" + currentPosition].Value = reportTable.Rows[i]["ContractorSrn"];
                //
                cells["B" + currentPosition].Value = reportTable.Rows[i]["ContractorName"];
                //
                cells["C" + currentPosition].Value = (reportTable.Rows[i]["BankCurrencyName"]); // == DBNull.Value ? reportTable.Rows[i]["BankCurrencyName"] : reportTable.Rows[i]["DebitCurrencyName"]);
                //
                cells["D" + currentPosition].Value = reportTable.Rows[i]["StartDebitCurrency"];
                cells["E" + currentPosition].Value = reportTable.Rows[i]["StartDebit"];
                cells["F" + currentPosition].Value = reportTable.Rows[i]["StartCreditCurrency"];
                cells["G" + currentPosition].Value = reportTable.Rows[i]["StartCredit"];

                cells["H" + currentPosition].Value = reportTable.Rows[i]["PeriodDebitCurrency"];
                cells["I" + currentPosition].Value = reportTable.Rows[i]["PeriodDebit"];
                cells["J" + currentPosition].Value = reportTable.Rows[i]["PeriodCreditCurrency"];
                cells["K" + currentPosition].Value = reportTable.Rows[i]["PeriodCredit"];

                cells["L" + currentPosition].Value = reportTable.Rows[i]["EndDebitCurrency"];
                cells["M" + currentPosition].Value = reportTable.Rows[i]["EndDebit"];
                cells["N" + currentPosition].Value = reportTable.Rows[i]["EndCreditCurrency"];
                cells["O" + currentPosition].Value = reportTable.Rows[i]["EndCredit"];
                //
                currentPosition++;
            }

            cells["A" + startPosition + ":" + "B" + currentPosition].HorizontalAlignment = HAlign.Left;
            cells["B" + startPosition + ":" + "B" + currentPosition].WrapText = true;
            cells["C" + startPosition + ":" + "H" + currentPosition].HorizontalAlignment = HAlign.Right;

            cells["A" + currentPosition + ":" + "B" + currentPosition].Merge();
            cells["A" + currentPosition + ":" + "B" + currentPosition].HorizontalAlignment = HAlign.Center;
            cells["A" + currentPosition].Value = "Разом";


            cells["E" + currentPosition].Formula = SetFormula("E", startPosition, "E", currentPosition - 1, "SUM");
            cells["G" + currentPosition].Formula = SetFormula("G", startPosition, "G", currentPosition - 1, "SUM");
            cells["I" + currentPosition].Formula = SetFormula("I", startPosition, "I", currentPosition - 1, "SUM");
            cells["K" + currentPosition].Formula = SetFormula("K", startPosition, "K", currentPosition - 1, "SUM");
            cells["M" + currentPosition].Formula = SetFormula("M", startPosition, "M", currentPosition - 1, "SUM");
            cells["O" + currentPosition].Formula = SetFormula("O", startPosition, "O", currentPosition - 1, "SUM");

            cells["A" + currentPosition + ":" + "O" + currentPosition].Font.Bold = true;
            cells["C" + currentPosition + ":" + "O" + currentPosition].Interior.Color = Color.LightGreen;

            cells["C" + startPosition + ":" + "O" + currentPosition].NumberFormat = "### ### ##0.00";
            cells["A" + startPosition + ":" + "O" + currentPosition].Borders.LineStyle = LineStyle.Continous;

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + "ОСВ за період з " + StartDate + " по " + EndDate + " (" + FlagType + ").xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "ОСВ за період з " + StartDate + " по " + EndDate + " (" + FlagType + ").xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void MSTrialBalanceByAccounts(DataTable reportTable, string StartDate, string EndDate, string FlagType)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var orderSource = reportTable.AsEnumerable()
                                .OrderBy(s => s["Contractor_Id"])
                                .ThenBy(w => w["FlagDebitCredit"])
                                .CopyToDataTable();

            var workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            Dictionary<int, string> DebitAcc = new Dictionary<int, string>();
            Dictionary<int, string> CreditAcc = new Dictionary<int, string>();
            Dictionary<string, byte> HeaderColumn = new Dictionary<string, byte>();
                        
            int startDebitAccount = 0;
            int startCreditAccount = 0;
            int endDebitAccount = 0;
            int endCreditAccount = 0;

            int captionPosition = 6;
            int startPosition = captionPosition + 1;
            int currentPosition = startPosition + 3;
            byte startHeaderPosition = 1;

            #region Generate report header

            var Debit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") == 1).Select(c => new
            {
                AccountNum = c.Field<string>("AccountNum"),
                AccountId = c.Field<int>("AccountId")
            }).Distinct().OrderBy(c => c.AccountNum);

            foreach (var dict in Debit_Accounts)
                DebitAcc.Add(dict.AccountId, dict.AccountNum);


            var Credit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") == 2).Select(c => new
            {
                AccountNum = c.Field<string>("AccountNum"),
                AccountId = c.Field<int>("AccountId")
            }).Distinct().OrderBy(c => c.AccountNum).ToList();

            foreach (var dict in Credit_Accounts)
                CreditAcc.Add(dict.AccountId, dict.AccountNum);

            HeaderColumn.Add("ContractorSrn", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Код";

            startHeaderPosition++;

            HeaderColumn.Add("ContractorName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[vsS[startHeaderPosition] + (startPosition + 1) + ":" + vsS[startHeaderPosition] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на початок періоду";

            HeaderColumn.Add("StartDebit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            startHeaderPosition++;

            HeaderColumn.Add("StartCredit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Кредит";

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            startHeaderPosition++;

            HeaderColumn.Add("Payment_Document", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер платежу";

            startHeaderPosition++;

            HeaderColumn.Add("Payment_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата платежу";

            startHeaderPosition++;

            if (DebitAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("З д-ту рах., в к-т рах.");
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + DebitAcc.Count] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("З д-ту рах., в к-т рах.");
                startDebitAccount = startHeaderPosition;
                foreach (var debit_account in DebitAcc)
                {
                    HeaderColumn.Add("DebitAccount" + debit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition + 1, startHeaderPosition - 1].Value = debit_account.Value;
                    startHeaderPosition++;
                }
                endDebitAccount = startHeaderPosition;
            }

            HeaderColumn.Add("DebitPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Всього по дебету";
            cells[vsS[HeaderColumn["DebitPrice"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["DebitPrice"] - 1] + (startPosition)].Interior.Color = Color.Azure;

            startHeaderPosition++;
                        
            HeaderColumn.Add("Order_Num", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер надходження";

            startHeaderPosition++;

            HeaderColumn.Add("Order_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата надходження";

            startHeaderPosition++;

            HeaderColumn.Add("Invoice_Num", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер накладної";

            startHeaderPosition++;

            HeaderColumn.Add("Invoice_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата накладної";

            startHeaderPosition++;

            if (CreditAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("З к-та рах. в д-т рах.");
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + CreditAcc.Count] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("З к-та рах. в д-т рах.");
                startCreditAccount = startHeaderPosition;
                foreach (var credit_account in CreditAcc)
                {
                    HeaderColumn.Add("CreditAccount" + credit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition + 1, startHeaderPosition - 1].Value = credit_account.Value;
                    startHeaderPosition++;
                }
                endCreditAccount = startHeaderPosition;
            }

            HeaderColumn.Add("CreditPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Всього по кредиту";
            cells[vsS[HeaderColumn["CreditPrice"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["CreditPrice"] - 1] + (startPosition)].Interior.Color = Color.Azure;

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[vsS[startHeaderPosition] + (startPosition + 1) + ":" + vsS[startHeaderPosition] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на кінець періоду";

            HeaderColumn.Add("EndDebit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            startHeaderPosition++;

            HeaderColumn.Add("EndCredit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Кредит";

            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].WrapText = true;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].VerticalAlignment = VAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].HorizontalAlignment = HAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Font.Bold = true;
            cells["A:A"].ColumnWidth = 15;
            cells["B:B"].ColumnWidth = 70;
            cells["C:C"].ColumnWidth = 15;
            cells["C" + ":" + vsS[startHeaderPosition - 1]].ColumnWidth = 15;

            #endregion

            #region Loop body

            int contractorId = 0;
            string account = "";
            int startContractor = currentPosition;
            int sumPosition = 0;

            Func<int, int, int, int> WriteContractor = (sourceId, currentPos, _contractorId) =>
            {
                int insidePos = currentPos;
                int _orderId = 0;
                int creditRecCount = 0;

                cells[vsS[HeaderColumn["ContractorSrn"] - 1] + insidePos].Value = orderSource.Rows[sourceId]["ContractorSrn"];
                cells[vsS[HeaderColumn["ContractorName"] - 1] + insidePos].Value = orderSource.Rows[sourceId]["ContractorName"];
                cells[vsS[HeaderColumn["StartDebit"] - 1] + insidePos].Value = orderSource.Rows[sourceId]["StartDebit"];
                cells[vsS[HeaderColumn["StartCredit"] - 1] + insidePos].Value = orderSource.Rows[sourceId]["StartCredit"];
                cells[vsS[HeaderColumn["EndDebit"] - 1] + insidePos].Value = orderSource.Rows[sourceId]["EndDebit"];
                cells[vsS[HeaderColumn["EndCredit"] - 1] + insidePos].Value = orderSource.Rows[sourceId]["EndCredit"];
                //
                var DebitInfo = orderSource.AsEnumerable()
                                 .Where(s => (int)s["Contractor_Id"] == _contractorId && (int)s["FlagDebitCredit"] == 1)
                                 .OrderBy(o => o["OrderId"]);

                var CreditInfo = orderSource.AsEnumerable()
                                 .Where(s => (int)s["Contractor_Id"] == _contractorId && (int)s["FlagDebitCredit"] == 2)
                                 .OrderBy(o => o["OrderId"]);
                
                if (DebitInfo.Count() > 0)
                {
                    foreach (var item in DebitInfo)
                    {
                        cells[vsS[HeaderColumn["Payment_Document"] - 1] + insidePos].Value = item["Payment_Document"];
                        cells[vsS[HeaderColumn["Payment_Date"] - 1] + insidePos].Value = item["Payment_Date"];
                        cells[vsS[HeaderColumn["DebitPrice"] - 1] + insidePos].Value = item["PeriodPrice"];

                        if ((int)item["AccountId"] > 0)
                        {
                            account = "DebitAccount" + item["AccountId"].ToString();
                            cells[vsS[HeaderColumn[account] - 1] + insidePos].Value = item["PeriodPrice"];
                        }
                        
                        insidePos++;
                    }
                }
                
                if (CreditInfo.Count() > 0)
                {
                    //insidePos = (currentPos - 1);
                    insidePos = currentPos;
                    foreach (var item in CreditInfo)
                    {
                        if (_orderId != (int)item["OrderId"])
                        {
                            _orderId = (int)item["OrderId"];
                            insidePos++;
                            creditRecCount++;
                        }

                        cells[vsS[HeaderColumn["Order_Num"] - 1] + insidePos].Value = item["Payment_Document"];
                        cells[vsS[HeaderColumn["Order_Date"] - 1] + insidePos].Value = item["Payment_Date"];
                        cells[vsS[HeaderColumn["Invoice_Num"] - 1] + insidePos].Value = item["Invoice_Num"];
                        cells[vsS[HeaderColumn["Invoice_Date"] - 1] + insidePos].Value = item["Invoice_Date"];
                        

                        if ((int)item["AccountId"] > 0)
                        {
                            account = "CreditAccount" + item["AccountId"].ToString();
                            cells[vsS[HeaderColumn[account] - 1] + insidePos].Value = item["PeriodPrice"];
                        }
                        
                        cells[vsS[HeaderColumn["CreditPrice"] - 1] + insidePos].Formula = SetFormula(vsS[HeaderColumn["Invoice_Date"]], insidePos, vsS[HeaderColumn["CreditPrice"] - 2], insidePos, "SUM");
                    }
                    
                }

                int recCount = DebitInfo.Count() > creditRecCount  ? DebitInfo.Count() : creditRecCount;
                return (currentPos + (recCount > 0 ? recCount : 1));
            };

            for (int i = 0; i < orderSource.Rows.Count; i++)
            {
                if (contractorId != (int)orderSource.Rows[i]["Contractor_Id"])
                {
                    contractorId = (int)orderSource.Rows[i]["Contractor_Id"];
                    
                    if (i > 0)
                    {
                        cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["DebitPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["CreditPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

                        cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;
                        cells[vsS[HeaderColumn["DebitPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitPrice"] - 1], startContractor, vsS[HeaderColumn["DebitPrice"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CreditPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditPrice"] - 1], startContractor, vsS[HeaderColumn["CreditPrice"] - 1], currentPosition - 1, "SUM");
                        
                        if (DebitAcc.Count > 0)
                        {
                            foreach (var dict in DebitAcc)
                            {
                                sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                            }
                        }
                        if (CreditAcc.Count > 0)
                        {
                            foreach (var dict in CreditAcc)
                            {
                                sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                            }
                        }
                        currentPosition++;
                        startContractor = currentPosition;
                    }

                    currentPosition = WriteContractor(i, currentPosition, contractorId) + 1;
                }
                //currentPosition++;
            }

            #endregion

            #region Finally step output

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["DebitPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["CreditPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;
            cells[vsS[HeaderColumn["DebitPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitPrice"] - 1], startContractor, vsS[HeaderColumn["DebitPrice"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["CreditPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditPrice"] - 1], startContractor, vsS[HeaderColumn["CreditPrice"] - 1], currentPosition - 1, "SUM");

            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                }
            }
            
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                }
            }
            cells["A" + (startPosition + 3) + ":" + vsS[startHeaderPosition - 1] + (currentPosition + 1)].Borders.LineStyle = LineStyle.Continous;
            currentPosition++;

            #endregion

            #region Result summary

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.LightGreen;
            cells["B" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["B" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Font.Bold = true;
            cells["B" + currentPosition].Value = "Всього";
            cells["C" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            
            if (DebitAcc.Count > 0)
                cells[vsS[HeaderColumn["DebitAccount" + DebitAcc.Keys.First()] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["DebitPrice"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            
            if (CreditAcc.Count > 0)
                cells[vsS[HeaderColumn["CreditAccount" + CreditAcc.Keys.First()] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["CreditPrice"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            
            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebit"] - 1], (startPosition + 3), vsS[HeaderColumn["StartDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebit"] - 1], (startPosition + 3), vsS[HeaderColumn["EndDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCredit"] - 1], (startPosition + 3), vsS[HeaderColumn["StartCredit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCredit"] - 1], (startPosition + 3), vsS[HeaderColumn["EndCredit"] - 1], currentPosition - 1, "SUM");

            cells[vsS[HeaderColumn["DebitPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1).Sum(x => x.Field<decimal?>("PeriodPrice"));
            cells[vsS[HeaderColumn["CreditPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2).Sum(x => x.Field<decimal?>("PeriodPrice"));

            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1 && w.Field<int>("AccountId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2 && w.Field<int>("AccountId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }

            #endregion

            #region Report caption and froze row

            cells["A" + captionPosition + ":" + vsS[startHeaderPosition - 1] + captionPosition].Merge();
            string subName = "Розрахунки з постачальниками та підрядниками";
            cells["A" + captionPosition].Value = String.Format("Рахунок {0} \"{1}\" станом за період з {2} по {3}", FlagType, subName, StartDate, EndDate);
            cells["A" + captionPosition].Font.Bold = true;
            cells["A" + captionPosition].VerticalAlignment = VAlign.Center;
            cells["A" + captionPosition].HorizontalAlignment = HAlign.Center;

            worksheet.WindowInfo.ScrollRow = 0;
            worksheet.WindowInfo.SplitRows = startPosition + 2;

            worksheet.WindowInfo.FreezePanes = true;

            #endregion

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + "ОСВ по контрагентам та рахункам за період з " + StartDate + " по " + EndDate + " (" + FlagType + ").xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "ОСВ по контрагентам та рахункам за період з " + StartDate + " по " + EndDate + " (" + FlagType + ").xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }        
        }

        public void MSTrialBalance_631_63(DataTable reportTable, string StartDate, string EndDate)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            Dictionary<string, byte> HeaderColumn = new Dictionary<string, byte>();
            
            int captionPosition = 6;
            int startPosition = captionPosition + 1;
            int currentPosition = startPosition + 3;
            byte startHeaderPosition = 1;

            #region Generate report header

            HeaderColumn.Add("Contractor_Name", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Контрагент";

            startHeaderPosition++;

            HeaderColumn.Add("Contractor_Srn", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Код";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 2] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition] + (startPosition + 1)].Merge();
            cells[vsS[startHeaderPosition + 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 2] + (startPosition + 1)].Merge();
            
            cells[startPosition - 1, startHeaderPosition - 1].Value = "631";
            cells[startPosition, startHeaderPosition - 1].Value = "Сальдо на початок періоду";
            cells[startPosition, startHeaderPosition + 1].Value = "Сальдо на кінець періоду";

            HeaderColumn.Add("Begin_Debit631", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Дебет";
            startHeaderPosition++;

            HeaderColumn.Add("Begin_Credit631", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Кредит";
            startHeaderPosition++;

            HeaderColumn.Add("End_Debit631", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Дебет";
            startHeaderPosition++;

            HeaderColumn.Add("End_Credit631", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Кредит";
            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 2] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition] + (startPosition + 1)].Merge();
            cells[vsS[startHeaderPosition + 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 2] + (startPosition + 1)].Merge();

            cells[startPosition - 1, startHeaderPosition - 1].Value = "63";
            cells[startPosition, startHeaderPosition - 1].Value = "Сальдо на початок періоду";
            cells[startPosition, startHeaderPosition + 1].Value = "Сальдо на кінець періоду";

            HeaderColumn.Add("Begin_Debit63", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Дебет";
            startHeaderPosition++;

            HeaderColumn.Add("Begin_Credit63", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Кредит";
            startHeaderPosition++;

            HeaderColumn.Add("End_Debit63", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Дебет";
            startHeaderPosition++;

            HeaderColumn.Add("End_Credit63", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Кредит";

            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].WrapText = true;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].VerticalAlignment = VAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].HorizontalAlignment = HAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Font.Bold = true;
            cells["A:A"].ColumnWidth = 70;
            cells["B:B"].ColumnWidth = 15;
            cells["C" + ":" + vsS[startHeaderPosition - 1]].ColumnWidth = 15;

            #endregion

            #region Loop body

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                cells[vsS[HeaderColumn["Contractor_Name"] - 1] + currentPosition].Value = reportTable.Rows[i]["Contractor_Name"];
                cells[vsS[HeaderColumn["Contractor_Srn"] - 1]  + currentPosition].Value = reportTable.Rows[i]["Contractor_Srn"];
                cells[vsS[HeaderColumn["Begin_Debit631"] - 1] + currentPosition].Value = reportTable.Rows[i]["Begin_Debit631"];
                cells[vsS[HeaderColumn["Begin_Credit631"] - 1] + currentPosition].Value = reportTable.Rows[i]["Begin_Credit631"];
                cells[vsS[HeaderColumn["End_Debit631"] - 1] + currentPosition].Value = reportTable.Rows[i]["End_Debit631"];
                cells[vsS[HeaderColumn["End_Credit631"] - 1] + currentPosition].Value = reportTable.Rows[i]["End_Credit631"];
                cells[vsS[HeaderColumn["Begin_Debit63"] - 1] + currentPosition].Value = reportTable.Rows[i]["Begin_Debit63"];
                cells[vsS[HeaderColumn["Begin_Credit63"] - 1] + currentPosition].Value = reportTable.Rows[i]["Begin_Credit63"];
                cells[vsS[HeaderColumn["End_Debit63"] - 1] + currentPosition].Value = reportTable.Rows[i]["End_Debit63"];
                cells[vsS[HeaderColumn["End_Credit63"] - 1] + currentPosition].Value = reportTable.Rows[i]["End_Credit63"];

                currentPosition++;
            }

            #endregion

            #region Report caption and froze row

            cells["A" + captionPosition + ":" + vsS[startHeaderPosition - 1] + captionPosition].Merge();
            cells["A" + captionPosition].Value = String.Format("Зведена ОСВ gо рахункам {0} та {1} станом за період з {2} по {3}", 631, 63, StartDate, EndDate);
            cells["A" + captionPosition].Font.Bold = true;
            cells["A" + captionPosition].VerticalAlignment = VAlign.Center;
            cells["A" + captionPosition].HorizontalAlignment = HAlign.Center;

            cells[vsS[HeaderColumn["Begin_Debit631"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["End_Credit63"] - 1] + (currentPosition - 1)].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["Contractor_Name"] - 1] + (startPosition + 3) + ":" + vsS[startHeaderPosition - 1] + (currentPosition - 1)].Borders.LineStyle = LineStyle.Continous;

            worksheet.WindowInfo.ScrollRow = 0;
            worksheet.WindowInfo.SplitRows = startPosition + 2;

            worksheet.WindowInfo.FreezePanes = true;

            #endregion

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + "Зведена ОСВ (631,63) за період з " + StartDate + " по " + EndDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Зведена ОСВ (631,63) за період з " + StartDate + " по " + EndDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void MSTrialBalanceByAccountsCurrency(DataTable reportTable, string StartDate, string EndDate, string FlagType)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var workbook = Factory.GetWorkbook(TemplatesDir + "MSTrialBalanceByAccountsCurrency.xls");
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            Dictionary<int, string> DebitAcc = new Dictionary<int, string>();
            Dictionary<int, string> CreditAcc = new Dictionary<int, string>();
            Dictionary<string, byte> HeaderColumn = new Dictionary<string, byte>();

            string subName = "Розрахунки з іноземними постачальниками та підрядниками";
            string name = string.Format("Рахунок {0} \"{1}\" станом за період з {2} по {3}", FlagType, subName, StartDate, EndDate);

            

            int startDebitAccount = 0;
            int startCreditAccount = 0;
            int endDebitAccount = 0;
            int endCreditAccount = 0;

            int captionPosition = 6;
            int startPosition = captionPosition + 1; 
            int currentPosition = startPosition + 3;
            byte startHeaderPosition = 1;

            cells["E" + captionPosition].Value = name;

            #region Generate report header

            var Debit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") == 1).Select(c => new
            {
                AccountNum = c.Field<string>("Num"),
                AccountId = c.Field<int>("AccountId")
            }).Distinct().OrderBy(c => c.AccountNum);

            foreach (var dict in Debit_Accounts)
                DebitAcc.Add(dict.AccountId, dict.AccountNum);


            var Credit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") == 2).Select(c => new
            {
                AccountNum = c.Field<string>("Num"),
                AccountId = c.Field<int>("AccountId")
            }).Distinct().OrderBy(c => c.AccountNum).ToList();

            foreach (var dict in Credit_Accounts)
                CreditAcc.Add(dict.AccountId, dict.AccountNum);

            HeaderColumn.Add("ContractorSrn", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Код";

            startHeaderPosition++;

            HeaderColumn.Add("ContractorName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування";

            startHeaderPosition++;

            HeaderColumn.Add("CurrencyName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування валюти";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 6] + startPosition].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на початок періоду";
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 2] + (startPosition + 1)].Merge();
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            cells[vsS[startHeaderPosition + 3] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 6] + (startPosition + 1)].Merge();
            cells[startPosition, startHeaderPosition + 3].Value = "Кредит";

            HeaderColumn.Add("StartDebit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;
            HeaderColumn.Add("StartDebitCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("StartDebitCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("StartDebitCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";
            startHeaderPosition++;
            HeaderColumn.Add("StartCredit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;
            HeaderColumn.Add("StartCreditCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("StartCreditCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("StartCreditCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";
            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            startHeaderPosition++;

            HeaderColumn.Add("Payment_Document", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер платежу";

            startHeaderPosition++;

            HeaderColumn.Add("Payment_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата";

            startHeaderPosition++;

            if (DebitAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "З деб., в кред.";
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + DebitAcc.Count] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "З деб., в кред.";
                startDebitAccount = startHeaderPosition;
                foreach (var debit_account in DebitAcc)
                {
                    HeaderColumn.Add("DebitAccount" + debit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition + 1, startHeaderPosition - 1].Value = debit_account.Value;
                    startHeaderPosition++;
                }
                endDebitAccount = startHeaderPosition;
            }

            HeaderColumn.Add("PeriodPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сума в гривні";
            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["PeriodPrice"] - 1] + (startPosition)].Interior.Color = Color.Azure;
            startHeaderPosition++;

            HeaderColumn.Add("Rate", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Курс";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Всього по дебету";
            cells[vsS[startHeaderPosition - 1] + (startPosition) + ":" + vsS[startHeaderPosition + 1] + (startPosition + 2)].Interior.Color = Color.Azure;

            HeaderColumn.Add("DebitSumUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";

            startHeaderPosition++;

            HeaderColumn.Add("DebitSumEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";

            startHeaderPosition++;

            HeaderColumn.Add("DebitSumRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            startHeaderPosition++;

            HeaderColumn.Add("Order_Num", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер надходження";

            startHeaderPosition++;

            HeaderColumn.Add("Order_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата надходження";

            startHeaderPosition++;

            HeaderColumn.Add("Invoice_Num", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер накладної";

            startHeaderPosition++;

            HeaderColumn.Add("Invoice_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата накладної";

            startHeaderPosition++;

            if (CreditAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "З кред., в деб.";
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + CreditAcc.Count] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "З кред., в деб.";
                startCreditAccount = startHeaderPosition;
                foreach (var credit_account in CreditAcc)
                {
                    HeaderColumn.Add("CreditAccount" + credit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition + 1, startHeaderPosition - 1].Value = credit_account.Value;
                    startHeaderPosition++;
                }
                endCreditAccount = startHeaderPosition;
            }

            HeaderColumn.Add("PeriodOrderPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сума в гривні";
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (startPosition)].Interior.Color = Color.Azure;

            startHeaderPosition++;

            HeaderColumn.Add("OrderRate", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Курс";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Всього по кредиту";
            cells[vsS[startHeaderPosition - 1] + (startPosition) + ":" + vsS[startHeaderPosition + 1] + (startPosition + 2)].Interior.Color = Color.Azure;

            HeaderColumn.Add("CreditSumUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;

            HeaderColumn.Add("CreditSumEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";

            startHeaderPosition++;

            HeaderColumn.Add("CreditSumRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 6] + startPosition].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на кінець періоду";
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 2] + (startPosition + 1)].Merge();
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            cells[vsS[startHeaderPosition + 3] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 6] + (startPosition + 1)].Merge();
            cells[startPosition, startHeaderPosition + 3].Value = "Кредит";

            HeaderColumn.Add("EndDebit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("EndDebitCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("EndDebitCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("EndDebitCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";
            startHeaderPosition++;

            HeaderColumn.Add("EndCredit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("EndCreditCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("EndCreditCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("EndCreditCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].WrapText = true;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].VerticalAlignment = VAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].HorizontalAlignment = HAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Font.Bold = true;
            cells["D" + ":" + vsS[startHeaderPosition - 1]].ColumnWidth = 15;

            #endregion

            #region Loop body

            int contractorId = 0;
            string account = "";
            int startContractor = currentPosition;
            int sumPosition = 0;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (contractorId != (int)reportTable.Rows[i]["Contractor_Id"])
                {
                    contractorId = (int)reportTable.Rows[i]["Contractor_Id"];
                    if (i > 0)
                    {
                        cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

                        cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;
                        cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumUSD"] - 1], startContractor, vsS[HeaderColumn["DebitSumUSD"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumEUR"] - 1], startContractor, vsS[HeaderColumn["DebitSumEUR"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumRUB"] - 1], startContractor, vsS[HeaderColumn["DebitSumRUB"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumUSD"] - 1], startContractor, vsS[HeaderColumn["CreditSumUSD"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumEUR"] - 1], startContractor, vsS[HeaderColumn["CreditSumEUR"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumRUB"] - 1], startContractor, vsS[HeaderColumn["CreditSumRUB"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodPrice"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodOrderPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodOrderPrice"] - 1], currentPosition - 1, "SUM");
                        if (DebitAcc.Count > 0)
                        {
                            foreach (var dict in DebitAcc)
                            {
                                sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                            }
                        }
                        if (CreditAcc.Count > 0)
                        {
                            foreach (var dict in CreditAcc)
                            {
                                sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                            }
                        }
                        currentPosition++;
                        startContractor = currentPosition;
                    }
                    cells[vsS[HeaderColumn["ContractorSrn"] - 1] + currentPosition].Value = reportTable.Rows[i]["ContractorSrn"];
                    cells[vsS[HeaderColumn["ContractorName"] - 1] + currentPosition].Value = reportTable.Rows[i]["ContractorName"];
                    cells[vsS[HeaderColumn["CurrencyName"] - 1] + currentPosition].Value = reportTable.Rows[i]["CurrencyName"];
                    //
                    cells[vsS[HeaderColumn["StartDebitCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebitCurrency"];
                    cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebit"];
                    cells[vsS[HeaderColumn["StartCreditCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCreditCurrency"];
                    cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCredit"];
                    //
                    if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                    {
                        cells[vsS[HeaderColumn["Payment_Document"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["Payment_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["Rate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];
                        cells[vsS[HeaderColumn["DebitSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    else if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 2)
                    {
                        cells[vsS[HeaderColumn["Order_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["Order_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["Invoice_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Num"];
                        cells[vsS[HeaderColumn["Invoice_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Date"];
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["OrderRate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];
                        cells[vsS[HeaderColumn["CreditSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    if ((int)reportTable.Rows[i]["AccountId"] > 0)
                    {
                        account = ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                            ? "DebitAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString()
                            : "CreditAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString();
                        cells[vsS[HeaderColumn[account] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    //
                    cells[vsS[HeaderColumn["EndDebitCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebitCurrency"];
                    cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebit"];
                    cells[vsS[HeaderColumn["EndCreditCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCreditCurrency"];
                    cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCredit"];
                }
                else
                {
                    if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                    {
                        cells[vsS[HeaderColumn["Payment_Document"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["Payment_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["Rate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];
                        cells[vsS[HeaderColumn["DebitSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    else if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 2)
                    {
                        cells[vsS[HeaderColumn["Order_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["Order_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["Invoice_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Num"];
                        cells[vsS[HeaderColumn["Invoice_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Date"];
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["OrderRate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];
                        cells[vsS[HeaderColumn["CreditSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    if ((int)reportTable.Rows[i]["AccountId"] > 0)
                    {
                        account = ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                            ? "DebitAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString()
                            : "CreditAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString();
                        cells[vsS[HeaderColumn[account] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                }
                currentPosition++;
            }

            #endregion

            #region Finally step output

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;
            cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumUSD"] - 1], startContractor, vsS[HeaderColumn["DebitSumUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumEUR"] - 1], startContractor, vsS[HeaderColumn["DebitSumEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumRUB"] - 1], startContractor, vsS[HeaderColumn["DebitSumRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumUSD"] - 1], startContractor, vsS[HeaderColumn["CreditSumUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumEUR"] - 1], startContractor, vsS[HeaderColumn["CreditSumEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumRUB"] - 1], startContractor, vsS[HeaderColumn["CreditSumRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodPrice"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodOrderPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodOrderPrice"] - 1], currentPosition - 1, "SUM");
            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                }
            }
            cells["A" + (startPosition + 3) + ":" + vsS[startHeaderPosition - 1] + (currentPosition + 1)].Borders.LineStyle = LineStyle.Continous;
            currentPosition++;

            #endregion

            #region Result summary

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.LightGreen;
            cells["B" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["B" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Font.Bold = true;
            cells["B" + currentPosition].Value = "Всього";
            cells["D" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells["D" + (startPosition + 3) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            if (DebitAcc.Count > 0)
                cells[vsS[HeaderColumn["DebitAccount" + DebitAcc.Keys.First()] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            if (CreditAcc.Count > 0)
                cells[vsS[HeaderColumn["CreditAccount" + CreditAcc.Keys.First()] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1], (startPosition + 3), vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1], (startPosition + 3), vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1], (startPosition + 3), vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebit"] - 1], (startPosition + 3), vsS[HeaderColumn["StartDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1], (startPosition + 3), vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1], (startPosition + 3), vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1], (startPosition + 3), vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebit"] - 1], (startPosition + 3), vsS[HeaderColumn["EndDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1], (startPosition + 3), vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1], (startPosition + 3), vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1], (startPosition + 3), vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCredit"] - 1], (startPosition + 3), vsS[HeaderColumn["StartCredit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1], (startPosition + 3), vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1], (startPosition + 3), vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1], (startPosition + 3), vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCredit"] - 1], (startPosition + 3), vsS[HeaderColumn["EndCredit"] - 1], currentPosition - 1, "SUM");

            cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1 && w.Field<Int16?>("CurrencyId") == 3).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1 && w.Field<Int16?>("CurrencyId") == 2).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1 && w.Field<Int16?>("CurrencyId") == 4).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1).Sum(x => x.Field<decimal?>("PeriodPrice"));
            cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2 && w.Field<Int16?>("CurrencyId") == 3).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2 && w.Field<Int16?>("CurrencyId") == 2).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2 && w.Field<Int16?>("CurrencyId") == 4).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2).Sum(x => x.Field<decimal?>("PeriodPrice"));

            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1 && w.Field<int>("AccountId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2 && w.Field<int>("AccountId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }

            #endregion

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + "ОСВ по контрагентам та рахункам за період з " + StartDate + " по " + EndDate + " (" + FlagType + ").xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "ОСВ по контрагентам та рахункам за період з " + StartDate + " по " + EndDate + " (" + FlagType + ").xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void MSTrialBalanceByAccountsCurrency681(DataTable reportTable, string StartDate, string EndDate, string FlagType)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var workbook = Factory.GetWorkbook(TemplatesDir + "MSTrialBalanceByAccountsCurrency.xls");
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            Dictionary<int, string> DebitAcc = new Dictionary<int, string>();
            Dictionary<int, string> CreditAcc = new Dictionary<int, string>();
            Dictionary<string, byte> HeaderColumn = new Dictionary<string, byte>();

            string subName = "Розрахунки за авансами одержаними";
            string name = string.Format("Рахунок {0} \"{1}\" станом за період з {2} по {3}", FlagType, subName, StartDate, EndDate);

            int startDebitAccount = 0;
            int startCreditAccount = 0;
            int endDebitAccount = 0;
            int endCreditAccount = 0;

            int captionPosition = 6;
            int startPosition = captionPosition + 1;
            int currentPosition = startPosition + 3;
            byte startHeaderPosition = 1;

            cells["E" + captionPosition].Value = name;

            #region Generate report header

            var Debit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") == 1).Select(c => new
            {
                AccountNum = c.Field<string>("Num"),
                AccountId = c.Field<int>("AccountId")
            }).Distinct().OrderBy(c => c.AccountNum);

            foreach (var dict in Debit_Accounts)
                DebitAcc.Add(dict.AccountId, dict.AccountNum);


            var Credit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") == 2).Select(c => new
            {
                AccountNum = c.Field<string>("Num"),
                AccountId = c.Field<int>("AccountId")
            }).Distinct().OrderBy(c => c.AccountNum).ToList();

            foreach (var dict in Credit_Accounts)
                CreditAcc.Add(dict.AccountId, dict.AccountNum);

            HeaderColumn.Add("ContractorSrn", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Код";

            startHeaderPosition++;

            HeaderColumn.Add("ContractorName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування";

            startHeaderPosition++;

            HeaderColumn.Add("CurrencyName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування валюти";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 6] + startPosition].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на початок періоду";
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 2] + (startPosition + 1)].Merge();
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            cells[vsS[startHeaderPosition + 3] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 6] + (startPosition + 1)].Merge();
            cells[startPosition, startHeaderPosition + 3].Value = "Кредит";

            HeaderColumn.Add("StartDebit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;
            HeaderColumn.Add("StartDebitCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("StartDebitCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("StartDebitCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";
            startHeaderPosition++;
            HeaderColumn.Add("StartCredit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;
            HeaderColumn.Add("StartCreditCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("StartCreditCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("StartCreditCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";
            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            startHeaderPosition++;

            HeaderColumn.Add("Payment_Document", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер платежу";

            startHeaderPosition++;

            HeaderColumn.Add("Payment_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата";

            startHeaderPosition++;

            if (DebitAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "С Д-т. рах. 681 в К-т. рахунків";
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + DebitAcc.Count] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "С Д-т. рах. 681 в К-т. рахунків";
                startDebitAccount = startHeaderPosition;
                foreach (var debit_account in DebitAcc)
                {
                    HeaderColumn.Add("DebitAccount" + debit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition + 1, startHeaderPosition - 1].Value = debit_account.Value;
                    startHeaderPosition++;
                }
                endDebitAccount = startHeaderPosition;
            }

            HeaderColumn.Add("PeriodPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сума в гривні";
            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["PeriodPrice"] - 1] + (startPosition)].Interior.Color = Color.Azure;
            startHeaderPosition++;

            HeaderColumn.Add("Rate", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Курс";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Всього по дебету";
            cells[vsS[startHeaderPosition - 1] + (startPosition) + ":" + vsS[startHeaderPosition + 1] + (startPosition + 2)].Interior.Color = Color.Azure;

            HeaderColumn.Add("DebitSumUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";

            startHeaderPosition++;

            HeaderColumn.Add("DebitSumEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";

            startHeaderPosition++;

            HeaderColumn.Add("DebitSumRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            startHeaderPosition++;

            HeaderColumn.Add("Order_Num", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер надходження";

            startHeaderPosition++;

            HeaderColumn.Add("Order_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата надходження";

            startHeaderPosition++;

            HeaderColumn.Add("Invoice_Num", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер накладної";

            startHeaderPosition++;

            HeaderColumn.Add("Invoice_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата накладної";

            startHeaderPosition++;

            if (CreditAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "З к-т. рах. 681 в д-т. рахунків";
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + CreditAcc.Count] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "З к-т. рах. 681 в д-т. рахунків";
                startCreditAccount = startHeaderPosition;
                foreach (var credit_account in CreditAcc)
                {
                    HeaderColumn.Add("CreditAccount" + credit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition + 1, startHeaderPosition - 1].Value = credit_account.Value;
                    startHeaderPosition++;
                }
                endCreditAccount = startHeaderPosition;
            }

            HeaderColumn.Add("PeriodOrderPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сума в гривні";
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (startPosition)].Interior.Color = Color.Azure;

            startHeaderPosition++;

            HeaderColumn.Add("OrderRate", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Курс";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Всього по кредиту";
            cells[vsS[startHeaderPosition - 1] + (startPosition) + ":" + vsS[startHeaderPosition + 1] + (startPosition + 2)].Interior.Color = Color.Azure;

            HeaderColumn.Add("CreditSumUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";

            startHeaderPosition++;

            HeaderColumn.Add("CreditSumEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";

            startHeaderPosition++;

            HeaderColumn.Add("CreditSumRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 6] + startPosition].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на конець періоду";
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 2] + (startPosition + 1)].Merge();
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            cells[vsS[startHeaderPosition + 3] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 6] + (startPosition + 1)].Merge();
            cells[startPosition, startHeaderPosition + 3].Value = "Кредит";

            HeaderColumn.Add("EndDebit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("EndDebitCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("EndDebitCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("EndDebitCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";
            startHeaderPosition++;

            HeaderColumn.Add("EndCredit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("EndCreditCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("EndCreditCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("EndCreditCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].WrapText = true;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].VerticalAlignment = VAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].HorizontalAlignment = HAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Font.Bold = true;
            cells["D" + ":" + vsS[startHeaderPosition - 1]].ColumnWidth = 15;

            #endregion

            #region Loop body

            int contractorId = 0;
            string account = "";
            int startContractor = currentPosition;
            int sumPosition = 0;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (contractorId != (int)reportTable.Rows[i]["Contractor_Id"])
                {
                    contractorId = (int)reportTable.Rows[i]["Contractor_Id"];
                    if (i > 0)
                    {
                        cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

                        cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;
                        cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumUSD"] - 1], startContractor, vsS[HeaderColumn["DebitSumUSD"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumEUR"] - 1], startContractor, vsS[HeaderColumn["DebitSumEUR"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumRUB"] - 1], startContractor, vsS[HeaderColumn["DebitSumRUB"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumUSD"] - 1], startContractor, vsS[HeaderColumn["CreditSumUSD"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumEUR"] - 1], startContractor, vsS[HeaderColumn["CreditSumEUR"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumRUB"] - 1], startContractor, vsS[HeaderColumn["CreditSumRUB"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodPrice"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodOrderPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodOrderPrice"] - 1], currentPosition - 1, "SUM");
                        if (DebitAcc.Count > 0)
                        {
                            foreach (var dict in DebitAcc)
                            {
                                sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                            }
                        }
                        if (CreditAcc.Count > 0)
                        {
                            foreach (var dict in CreditAcc)
                            {
                                sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                            }
                        }
                        currentPosition++;
                        startContractor = currentPosition;
                    }
                    cells[vsS[HeaderColumn["ContractorSrn"] - 1] + currentPosition].Value = reportTable.Rows[i]["ContractorSrn"];
                    cells[vsS[HeaderColumn["ContractorName"] - 1] + currentPosition].Value = reportTable.Rows[i]["ContractorName"];
                    cells[vsS[HeaderColumn["CurrencyName"] - 1] + currentPosition].Value = reportTable.Rows[i]["CurrencyName"];
                    //
                    if ((short)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["StartDebitCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebitCurrency"];
                    cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebit"];
                    if ((short)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["StartCreditCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCreditCurrency"];
                    cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCredit"];
                    //
                    if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                    {
                        cells[vsS[HeaderColumn["Payment_Document"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["Payment_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["Rate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];
                        if ((short)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["DebitSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    else if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 2)
                    {
                        cells[vsS[HeaderColumn["Order_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["Order_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["Invoice_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Num"];
                        cells[vsS[HeaderColumn["Invoice_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Date"];
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["OrderRate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];
                        if ((short)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["CreditSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    if ((int)reportTable.Rows[i]["AccountId"] > 0)
                    {
                        account = ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                            ? "DebitAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString()
                            : "CreditAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString();
                        cells[vsS[HeaderColumn[account] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    //

                    if ((short)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["EndDebitCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebitCurrency"];
                    cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebit"];
                    if ((short)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["EndCreditCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCreditCurrency"];
                    cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCredit"];
                }
                else
                {
                    if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                    {
                        cells[vsS[HeaderColumn["Payment_Document"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["Payment_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["Rate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];
                        if ((short)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["DebitSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    else if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 2)
                    {
                        cells[vsS[HeaderColumn["Order_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["Order_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["Invoice_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Num"];
                        cells[vsS[HeaderColumn["Invoice_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Date"];
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["OrderRate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];
                        if ((short)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["CreditSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    if ((int)reportTable.Rows[i]["AccountId"] > 0)
                    {
                        account = ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                            ? "DebitAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString()
                            : "CreditAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString();
                        cells[vsS[HeaderColumn[account] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                }
                currentPosition++;
            }

            #endregion

            #region Finally step output

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;
            cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumUSD"] - 1], startContractor, vsS[HeaderColumn["DebitSumUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumEUR"] - 1], startContractor, vsS[HeaderColumn["DebitSumEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumRUB"] - 1], startContractor, vsS[HeaderColumn["DebitSumRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumUSD"] - 1], startContractor, vsS[HeaderColumn["CreditSumUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumEUR"] - 1], startContractor, vsS[HeaderColumn["CreditSumEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumRUB"] - 1], startContractor, vsS[HeaderColumn["CreditSumRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodPrice"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodOrderPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodOrderPrice"] - 1], currentPosition - 1, "SUM");
            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                }
            }
            cells["A" + (startPosition + 3) + ":" + vsS[startHeaderPosition - 1] + (currentPosition + 1)].Borders.LineStyle = LineStyle.Continous;
            currentPosition++;

            #endregion

            #region Result summary

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.LightGreen;
            cells["B" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["B" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Font.Bold = true;
            cells["B" + currentPosition].Value = "Всього";
            cells["D" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells["D" + (startPosition + 3) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            if (DebitAcc.Count > 0)
                cells[vsS[HeaderColumn["DebitAccount" + DebitAcc.Keys.First()] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            if (CreditAcc.Count > 0)
                cells[vsS[HeaderColumn["CreditAccount" + CreditAcc.Keys.First()] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1], (startPosition + 3), vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1], (startPosition + 3), vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1], (startPosition + 3), vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebit"] - 1], (startPosition + 3), vsS[HeaderColumn["StartDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1], (startPosition + 3), vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1], (startPosition + 3), vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1], (startPosition + 3), vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebit"] - 1], (startPosition + 3), vsS[HeaderColumn["EndDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1], (startPosition + 3), vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1], (startPosition + 3), vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1], (startPosition + 3), vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCredit"] - 1], (startPosition + 3), vsS[HeaderColumn["StartCredit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1], (startPosition + 3), vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1], (startPosition + 3), vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1], (startPosition + 3), vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCredit"] - 1], (startPosition + 3), vsS[HeaderColumn["EndCredit"] - 1], currentPosition - 1, "SUM");

            cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1 && w.Field<Int16?>("CurrencyId") == 3).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1 && w.Field<Int16?>("CurrencyId") == 2).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1 && w.Field<Int16?>("CurrencyId") == 4).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1).Sum(x => x.Field<decimal?>("PeriodPrice"));
            cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2 && w.Field<Int16?>("CurrencyId") == 3).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2 && w.Field<Int16?>("CurrencyId") == 2).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2 && w.Field<Int16?>("CurrencyId") == 4).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2).Sum(x => x.Field<decimal?>("PeriodPrice"));

            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1 && w.Field<int>("AccountId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2 && w.Field<int>("AccountId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }

            #endregion

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + "ОСВ за період з " + StartDate + " по " + EndDate + " (" + FlagType + ").xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "ОСВ за період з " + StartDate + " по " + EndDate + " (" + FlagType + ").xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void MSTrialBalanceByAccounts39(DataTable reportTable, string StartDate, string EndDate, string FlagType)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SpreadsheetGear.IWorkbook workbook = Factory.GetWorkbook(TemplatesDir + "MSTrialBalanceByAccountsCurrency.xls");
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            Dictionary<int, string> DebitAcc = new Dictionary<int, string>();
            Dictionary<int, string> CreditAcc = new Dictionary<int, string>();
            Dictionary<string, byte> HeaderColumn = new Dictionary<string, byte>();

            string subName = "Витрати майбутніх періодів";
            string name = string.Format("Рахунок {0} \"{1}\" станом за період з {2} по {3}", FlagType, subName, StartDate, EndDate);

            int startDebitAccount = 0;
            int startCreditAccount = 0;
            int endDebitAccount = 0;
            int endCreditAccount = 0;

            int captionPosition = 6;
            int startPosition = captionPosition + 1;
            int currentPosition = startPosition + 3;
            byte startHeaderPosition = 1;

            cells["E" + captionPosition].Value = name;

            #region Generate report header

            var Debit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") == 1).Select(c => new
            {
                AccountNum = c.Field<string>("AccountsNum"),
                AccountId = c.Field<int>("AccountsId")
            }).Distinct().OrderBy(c => c.AccountNum);

            foreach (var dict in Debit_Accounts)
                DebitAcc.Add(dict.AccountId, dict.AccountNum);


            var Credit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") == 2).Select(c => new
            {
                AccountNum = c.Field<string>("AccountsNum"),
                AccountId = c.Field<int>("AccountsId")
            }).Distinct().OrderBy(c => c.AccountNum).ToList();

            foreach (var dict in Credit_Accounts)
                CreditAcc.Add(dict.AccountId, dict.AccountNum);

            HeaderColumn.Add("ContractorSrn", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Код";

            startHeaderPosition++;

            HeaderColumn.Add("ContractorName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition] + startPosition].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на початок періоду";

            HeaderColumn.Add("StartDebit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";

            startHeaderPosition++;

            HeaderColumn.Add("StartCredit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Кредит";

            startHeaderPosition++;

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + (startPosition + 1)].Interior.Color = Color.Beige;

            HeaderColumn.Add("Payment_Document", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер платежу";

            startHeaderPosition++;

            HeaderColumn.Add("Payment_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата";

            startHeaderPosition++;

            if (DebitAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + startPosition].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "З деб., в кред.";
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + DebitAcc.Count] + startPosition].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "З деб., в кред.";
                startDebitAccount = startHeaderPosition;
                foreach (var debit_account in DebitAcc)
                {
                    HeaderColumn.Add("DebitAccount" + debit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition, startHeaderPosition - 1].Value = debit_account.Value;
                    startHeaderPosition++;
                }
                endDebitAccount = startHeaderPosition;
            }

            HeaderColumn.Add("PeriodPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Всього по дебету";
            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + startPosition + ":" + vsS[HeaderColumn["PeriodPrice"] - 1] + startPosition].Interior.Color = Color.Azure;
            
            startHeaderPosition++;

            HeaderColumn.Add("Order_Num", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер надходження";

            startHeaderPosition++;

            HeaderColumn.Add("Order_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата надходження";

            startHeaderPosition++;

            HeaderColumn.Add("Invoice_Num", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер накладної";

            startHeaderPosition++;

            HeaderColumn.Add("Invoice_Date", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата накладної";

            startHeaderPosition++;

            if (CreditAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + startPosition].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "З кред., в деб.";
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + CreditAcc.Count] + startPosition].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = "З кред., в деб.";
                startCreditAccount = startHeaderPosition;
                foreach (var credit_account in CreditAcc)
                {
                    HeaderColumn.Add("CreditAccount" + credit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition, startHeaderPosition - 1].Value = credit_account.Value;
                    startHeaderPosition++;
                }
                endCreditAccount = startHeaderPosition;
            }

            HeaderColumn.Add("PeriodOrderPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Всього по кредиту";
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + startPosition + ":" + vsS[HeaderColumn["PeriodOrderPrice"] - 1] + startPosition].Interior.Color = Color.Azure;

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition] + startPosition].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на кінець періоду";

            HeaderColumn.Add("EndDebit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";

            startHeaderPosition++;

            HeaderColumn.Add("EndCredit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Кредит";

            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + (startPosition + 1)].Interior.Color = Color.Beige;

            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].WrapText = true;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].VerticalAlignment = VAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].HorizontalAlignment = HAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Font.Bold = true;
            cells["A1"].ColumnWidth = 30;
            cells["B1"].ColumnWidth = 50;
            cells["C" + ":" + vsS[startHeaderPosition - 1]].ColumnWidth = 15;

            #endregion

            #region Loop body

            int contractorId = 0;
            string account = "";
            int startContractor = currentPosition;
            int sumPosition = 0;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (contractorId != (int)reportTable.Rows[i]["ContractorId"])
                {
                    contractorId = (int)reportTable.Rows[i]["ContractorId"];
                    if (i > 0)
                    {
                        cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

                        cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodPrice"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodOrderPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodOrderPrice"] - 1], currentPosition - 1, "SUM");
                        if (DebitAcc.Count > 0)
                        {
                            foreach (var dict in DebitAcc)
                            {
                                sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                            }
                        }
                        if (CreditAcc.Count > 0)
                        {
                            foreach (var dict in CreditAcc)
                            {
                                sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                            }
                        }
                        currentPosition++;
                        startContractor = currentPosition;
                    }
                    cells[vsS[HeaderColumn["ContractorSrn"] - 1] + currentPosition].Value = reportTable.Rows[i]["ContractorSrn"];
                    cells[vsS[HeaderColumn["ContractorName"] - 1] + currentPosition].Value = reportTable.Rows[i]["ContractorName"];
                    //
                    cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebit"];
                    cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCredit"];
                    //
                    if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                    {
                        cells[vsS[HeaderColumn["Payment_Document"] - 1] + currentPosition].Value = reportTable.Rows[i]["Receipt_Num"];
                        cells[vsS[HeaderColumn["Payment_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Order_Date"];
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    else if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 2)
                    {
                        cells[vsS[HeaderColumn["Order_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Receipt_Num"];
                        cells[vsS[HeaderColumn["Order_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Order_Date"];
                        cells[vsS[HeaderColumn["Invoice_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Num"];
                        cells[vsS[HeaderColumn["Invoice_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Date"];
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    if ((int)reportTable.Rows[i]["AccountsId"] > 0)
                    {
                        account = ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                            ? "DebitAccount" + ((int)reportTable.Rows[i]["AccountsId"]).ToString()
                            : "CreditAccount" + ((int)reportTable.Rows[i]["AccountsId"]).ToString();
                        cells[vsS[HeaderColumn[account] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    //
                    cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebit"];
                    cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCredit"];
                }
                else
                {
                    if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                    {
                        cells[vsS[HeaderColumn["Payment_Document"] - 1] + currentPosition].Value = reportTable.Rows[i]["Receipt_Num"];
                        cells[vsS[HeaderColumn["Payment_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Order_Date"];
                        cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    else if ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 2)
                    {
                        cells[vsS[HeaderColumn["Order_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Receipt_Num"];
                        cells[vsS[HeaderColumn["Order_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Order_Date"];
                        cells[vsS[HeaderColumn["Invoice_Num"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Num"];
                        cells[vsS[HeaderColumn["Invoice_Date"] - 1] + currentPosition].Value = reportTable.Rows[i]["Invoice_Date"];
                        cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    if ((int)reportTable.Rows[i]["AccountsId"] > 0)
                    {
                        account = ((int?)reportTable.Rows[i]["FlagDebitCredit"] == 1)
                            ? "DebitAccount" + ((int)reportTable.Rows[i]["AccountsId"]).ToString()
                            : "CreditAccount" + ((int)reportTable.Rows[i]["AccountsId"]).ToString();
                        cells[vsS[HeaderColumn[account] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                }
                currentPosition++;
            }

            #endregion

            #region Finally step output

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["PeriodOrderPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;
            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodPrice"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["PeriodOrderPrice"] - 1], startContractor, vsS[HeaderColumn["PeriodOrderPrice"] - 1], currentPosition - 1, "SUM");
            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                }
            }
            cells["A" + (startPosition + 2) + ":" + vsS[startHeaderPosition - 1] + (currentPosition + 1)].Borders.LineStyle = LineStyle.Continous;
            currentPosition++;

            #endregion

            #region Result summary

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.LightGreen;
            cells["B" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["B" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Font.Bold = true;
            cells["B" + currentPosition].Value = "Всього";
            cells["C" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells["C" + (startPosition + 2) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition + 2) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            if (DebitAcc.Count > 0)
                cells[vsS[HeaderColumn["DebitAccount" + DebitAcc.Keys.First()] - 1] + (startPosition + 2) + ":" + vsS[HeaderColumn["Order_Num"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            if (CreditAcc.Count > 0)
                cells[vsS[HeaderColumn["CreditAccount" + CreditAcc.Keys.First()] - 1] + (startPosition + 2) + ":" + vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebit"] - 1], (startPosition + 2), vsS[HeaderColumn["StartDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebit"] - 1], (startPosition + 2), vsS[HeaderColumn["EndDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCredit"] - 1], (startPosition + 2), vsS[HeaderColumn["StartCredit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCredit"] - 1], (startPosition + 2), vsS[HeaderColumn["EndCredit"] - 1], currentPosition - 1, "SUM");

            cells[vsS[HeaderColumn["PeriodPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1).Sum(x => x.Field<decimal?>("PeriodPrice"));
            cells[vsS[HeaderColumn["PeriodOrderPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2).Sum(x => x.Field<decimal?>("PeriodPrice"));

            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 1 && w.Field<int>("AccountsId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") == 2 && w.Field<int>("AccountsId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }
            
            #endregion

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + "ОСВ за період з " + StartDate + " по " + EndDate + " (" + FlagType + ").xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "ОСВ за період з " + StartDate + " по " + EndDate + " (" + FlagType + ").xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void MSDebtorsCreditors(DataTable reportTable, string StartDate, string EndDate, string FlagType)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var workbook = Factory.GetWorkbook(TemplatesDir + "MSDebtorsCreditors.xls");

            int captionPosition = 6;
            int startPosition = captionPosition + 4; 
            int currentPosition;

            string name = string.Format("Дебіторсько-кредиторська заборгованість на кінець {0} ({1})", EndDate, FlagType);

            var DebCred = reportTable.AsEnumerable().Select(c => new { Deb_Cred = c["Deb_Cred"] }).Distinct();
            foreach (var debCred in DebCred)
            {
                currentPosition = startPosition;
                
                var worksheet = workbook.Worksheets[debCred.Deb_Cred.ToString()];
                var cells = worksheet.Cells;

                cells["A" + captionPosition].Value = name;

                var Debit = reportTable.AsEnumerable().Where(c => c["Deb_Cred"].ToString() == debCred.Deb_Cred.ToString()).OrderBy(c => (decimal)c["Price"]);
                foreach (var debit in Debit)
                {
                    cells["A" + currentPosition].Value = debit["Contractor_Srn"];
                    cells["B" + currentPosition].Value = debit["Contractor_Name"];
                    cells["C" + currentPosition].Value = debit["Price"];
                    currentPosition++;
                }

                cells["B" + startPosition + ":" + "B" + currentPosition].WrapText = true;

                cells["A" + startPosition + ":" + "A" + currentPosition].NumberFormat = "############";
                cells["A" + startPosition + ":" + "B" + currentPosition].HorizontalAlignment = HAlign.Left;
                cells["C" + startPosition + ":" + "C" + currentPosition].HorizontalAlignment = HAlign.Right;
                cells["C" + startPosition + ":" + "C" + currentPosition].NumberFormat = "### ### ##0.00";
                cells["A" + startPosition + ":" + "C" + currentPosition].Borders.LineStyle = LineStyle.Continous;

                cells["A" + currentPosition + ":" + "B" + currentPosition].Merge();
                cells["A" + currentPosition + ":" + "B" + currentPosition].HorizontalAlignment = HAlign.Center;
                cells["A" + currentPosition + ":" + "C" + currentPosition].Font.Bold = true;
                cells["A" + currentPosition].Value = "Разом";
                cells["C" + currentPosition].Formula = SetFormula("C", startPosition, "C", currentPosition - 1, "SUM");
                cells["C" + currentPosition].Interior.Color = Color.LightGreen;

                PrintSignatures(cells, currentPosition + 3);
            }

            try
            {
                workbook.SaveAs(GeneratedReportsDir + string.Format("ДКЗ на кінець {0} ({1})", EndDate, FlagType) + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + string.Format("ДКЗ на кінець {0} ({1})", EndDate, FlagType) + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void MSReconciliationReport(DataTable reportTable, string StartDate, string EndDate, string MaterialsServices, string ContractorName, string reportPeriodHeader)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var workbook = Factory.GetWorkbook(TemplatesDir + "MSReconciliationReport.xls");
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            string matServ = "";
            switch (MaterialsServices)
            {
                case "631":
                    matServ = "матеріали";
                    break;
                case "63":
                    matServ = "послуги";
                    break;
                case "631, 63":
                    matServ = "матеріали та послуги";
                    break;
            }

            cells["A7"].Value += "за " + matServ;
            cells["A8"].Value += reportPeriodHeader;
            cells["A11"].Value = ContractorName;
            cells["G14"].Value = ContractorName;

            int currentPosition, startPosition;
            currentPosition = startPosition = 17;

            decimal StartDebit = (decimal)reportTable.Rows[0]["StartDebit"];
            decimal StartCredit = (decimal)reportTable.Rows[0]["StartCredit"];
            decimal EndDebit = (decimal)reportTable.Rows[0]["EndDebit"];
            decimal EndCredit = (decimal)reportTable.Rows[0]["EndCredit"];

            cells["E" + currentPosition].Value = StartDebit;
            cells["F" + currentPosition].Value = StartCredit;
            cells["E" + currentPosition + ":" + "F" + currentPosition].Interior.Color = Color.LightGreen;
            currentPosition++;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                cells["A" + currentPosition].Value = i + 1;
                cells["B" + currentPosition].Value = reportTable.Rows[i]["Order_Date"];
                cells["C" + currentPosition].Value = reportTable.Rows[i]["Invoice_Num"];
                cells["C" + currentPosition].WrapText = true;
                cells["D" + currentPosition].Value = reportTable.Rows[i]["Purpose"];
                cells["E" + currentPosition].Value = reportTable.Rows[i]["Debit_Price"];
                cells["F" + currentPosition].Value = reportTable.Rows[i]["Credit_Price"];

                currentPosition++;
            }

            cells["A" + (startPosition + 1) + ":" + "A" + currentPosition].HorizontalAlignment = HAlign.Left;
            cells["B" + startPosition + ":" + "B" + currentPosition].HorizontalAlignment = HAlign.Center;
            cells["C" + startPosition + ":" + "C" + currentPosition].HorizontalAlignment = HAlign.Left;

            cells["A" + currentPosition + ":" + "C" + currentPosition].Merge();
            cells["A" + currentPosition + ":" + "C" + (currentPosition + 1)].HorizontalAlignment = HAlign.Center;
            cells["A" + currentPosition].Value = "Обороти за період";
            cells["E" + currentPosition].Formula = SetFormula("E", (startPosition + 1), "E", currentPosition - 1, "SUM");
            cells["F" + currentPosition].Formula = SetFormula("F", (startPosition + 1), "F", currentPosition - 1, "SUM");

            currentPosition++;
            cells["A" + currentPosition + ":" + "C" + currentPosition].Merge();
            cells["A" + currentPosition].Value = "Сальдо кінцеве";
            cells["E" + currentPosition].Value = EndDebit;
            cells["F" + currentPosition].Value = EndCredit;

            cells["A" + startPosition + ":" + "H" + currentPosition].Borders.LineStyle = LineStyle.Continous;

            cells["E" + startPosition + ":" + "F" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["E" + startPosition + ":" + "F" + currentPosition].NumberFormat = "### ### ##0.00";

            cells["A" + (currentPosition - 1) + ":" + "H" + currentPosition].Font.Bold = true;
            cells["E" + (currentPosition - 1) + ":" + "F" + currentPosition].Interior.Color = Color.LightGreen;

            cells["F" + startPosition + ":" + "F" + currentPosition].Borders[BordersIndex.EdgeRight].Weight = BorderWeight.Medium;

            currentPosition++;
            cells["A" + currentPosition + ":" + "H" + currentPosition].Merge();
            cells["A" + currentPosition + ":" + "H" + currentPosition].Font.Italic = true;
            
            double Sum = (double)((EndDebit > EndCredit) ? EndDebit : EndCredit);

            cells["A" + currentPosition].Value = RuDateAndMoneyConverter.CurrencyToTxt(Math.Round(Sum, 2), true);

            currentPosition += 2;

            cells["A" + currentPosition + ":" + "G" + (currentPosition + 3)].Merge();
            cells["A" + currentPosition + ":" + "G" + (currentPosition + 3)].Columns.WrapText = true;
            cells["A" + currentPosition].Value = "Один екземпляр завіреного акту звірки просимо повернути протягом 10-ти днів ТОВ " +
                                                 '"' + "НВФ " + '"' + "ТЕХВАГОНМАШ" + '"' + " за адресою: 39627, Полтавська обл., м. Кременчук, проспект Полтавський, 2-Д.\n" +
                                                 "У випадку не повернення акту взаємних розрахунків протягом одного місяця, заборгованість визнається узгодженою.";

            currentPosition += 5;

            cells["A" + currentPosition + ":" + "D" + currentPosition].Merge();
            cells["A" + currentPosition].Value = "Головний бухгалтер";
            cells["E" + currentPosition + ":" + "G" + currentPosition].Merge();
            cells["E" + currentPosition].Value = "Головний бухгалтер";
            currentPosition++;
            cells["A" + currentPosition + ":" + "D" + currentPosition].Merge();
            cells["A" + currentPosition].Value = "ТОВ \"НВФ \"ТЕХВАГОНМАШ\"";
            cells["E" + currentPosition + ":" + "G" + currentPosition].Merge();
            cells["E" + currentPosition + ":" + "G" + currentPosition].Value = ContractorName;
            cells["E" + currentPosition + ":" + "G" + currentPosition].WrapText = true;
            currentPosition++;
            cells["A" + currentPosition + ":" + "D" + currentPosition].Merge();
            cells["A" + currentPosition].Value = "Сергієнко Л.В._______________";
            cells["E" + currentPosition + ":" + "G" + currentPosition].Merge();
            cells["E" + currentPosition].Value = "_______________";
            currentPosition++;
            cells["B" + currentPosition].Value = "М.П.";
            cells["E" + currentPosition].Value = "М.П.";

            cells["A" + (currentPosition - 3) + ":" + "G" + (currentPosition - 1)].HorizontalAlignment = HAlign.Center;

           // PrintSignatures(cells, currentPosition + 3);

            cells["D:D"].Columns.Hidden = ((MessageBox.Show("Відобразити дані про призначення платежу?", "Формування звіту", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes));
            
            try
            {
                workbook.SaveAs(GeneratedReportsDir + "Акт звіряння взаєморозрахунків за період з " + StartDate + " по " + EndDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Акт звіряння взаєморозрахунків за період з " + StartDate + " по " + EndDate +".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void MSPaymentsWithoutVat(DataTable reportTable, string StartDate, string EndDate, string MaterialsServices)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            int currentPosition = 7;
            int a = 0;
            double sum = 0.0;

            cells["A" + currentPosition + ":" + "E" + currentPosition].Merge();
            cells["A" + currentPosition].HorizontalAlignment = HAlign.Center;
            cells["A" + currentPosition].Font.Bold = true;
            cells["A" + currentPosition].Value = "Оплати без ПДВ з " + StartDate + " по " + EndDate + " за " + MaterialsServices;
            currentPosition += 2;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (i == 0 || reportTable.Rows[i]["Contractor_Id"].ToString() != reportTable.Rows[i - 1]["Contractor_Id"].ToString())
                {
                    a = 0;
                    cells["A" + currentPosition + ":" + "E" + currentPosition].Merge();
                    cells["A" + currentPosition + ":" + "E" + currentPosition].HorizontalAlignment = HAlign.Center;
                    cells["A" + currentPosition + ":" + "E" + currentPosition].Font.Bold = true;
                    cells["A" + currentPosition].Value = reportTable.Rows[i]["Name"].ToString() + " " + reportTable.Rows[i]["Srn"].ToString();
                    currentPosition++;
                }

                cells["A" + currentPosition].Value = reportTable.Rows[i]["Payment_Date"].ToString().Substring(0, 10);
                cells["B" + currentPosition + ":" + "C" + currentPosition].Merge();
                cells["B" + currentPosition].Value = reportTable.Rows[i]["Payment_Document"].ToString();
                cells["D" + currentPosition + ":" + "E" + currentPosition].Merge();
                cells["D" + currentPosition].Value = reportTable.Rows[i]["Payment_Price"];

                a++;
                currentPosition++;

                if ((i < reportTable.Rows.Count - 1 && reportTable.Rows[i]["Contractor_Id"].ToString() != reportTable.Rows[i + 1]["Contractor_Id"].ToString()) || i == reportTable.Rows.Count - 1)
                {
                    cells["A" + currentPosition + ":" + "C" + currentPosition].Merge();
                    cells["A" + currentPosition + ":" + "C" + currentPosition].HorizontalAlignment = HAlign.Center;
                    cells["A" + currentPosition].Value = "Всього";

                    cells["D" + currentPosition + ":" + "E" + currentPosition].Merge();
                    cells["D" + currentPosition].Formula = SetFormula("D", currentPosition - a, "D", currentPosition - 1, "SUM");
                    cells["D" + (currentPosition - a) + ":" + "D" + currentPosition].NumberFormat = "### ### ##0.00";
                    cells["D" + (currentPosition - a) + ":" + "D" + currentPosition].HorizontalAlignment = HAlign.Right;

                    cells["A" + currentPosition + ":" + "E" + currentPosition].Font.Bold = true;
                    cells["A" + (currentPosition - a - 1) + ":" + "E" + currentPosition].Borders.LineStyle = LineStyle.Continous;
                    cells["A" + (currentPosition - a) + ":" + "B" + (currentPosition - 1)].HorizontalAlignment = HAlign.Left;

                    sum += Convert.ToDouble(cells["D" + currentPosition].Value);

                    currentPosition += 2;
                }
            }

            cells["A" + currentPosition + ":" + "C" + currentPosition].Merge();
            cells["A" + currentPosition + ":" + "C" + currentPosition].HorizontalAlignment = HAlign.Center;
            cells["A" + currentPosition].Value = "Разом";

            cells["D" + currentPosition + ":" + "E" + currentPosition].Merge();
            cells["D" + currentPosition].Value = sum;
            cells["D" + currentPosition].NumberFormat = "### ### ##0.00";
            cells["D" + currentPosition].HorizontalAlignment = HAlign.Right;

            cells["A" + currentPosition + ":" + "E" + currentPosition].Borders.LineStyle = LineStyle.Continous;
            cells["A" + currentPosition + ":" + "E" + currentPosition].Font.Bold = true;
            
            cells["A" + currentPosition].ColumnWidth = 15;

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + "Оплати без ПДВ з " + StartDate + " по " + EndDate + " за " + MaterialsServices + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Оплати без ПДВ з " + StartDate + " по " + EndDate + " за " + MaterialsServices + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void ContarctorsVat(DataTable reportTable, string startDate, string endDate)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "ContractorsVat.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;

            int captionPosition = 7;
            int startPosition = captionPosition + 1;
            int currentPosition = startPosition + 2;
            int n = 1;

            cells["D" + captionPosition + ":" + "H" + captionPosition].Merge();
            cells["D" + captionPosition].HorizontalAlignment = HAlign.Center;
            cells["D" + captionPosition].VerticalAlignment = VAlign.Center;
            cells["D" + captionPosition].Font.Bold = true;
            cells["D" + captionPosition].Value = "ПДВ з " + startDate + " по " + endDate;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                cells["A" + currentPosition].Value = n;
                cells["B" + currentPosition].Value = reportTable.Rows[i]["Tin"];
                cells["B" + currentPosition].NumberFormat = "### ### ### ###";
                cells["C" + currentPosition].HorizontalAlignment = HAlign.Center;
                cells["C" + currentPosition].WrapText = true;
                cells["C" + currentPosition].Value = reportTable.Rows[i]["Name"];
                cells["C" + currentPosition].Font.Size = 14;
                cells["D" + currentPosition].Value = reportTable.Rows[i]["SaldoDebitStart"];
                cells["E" + currentPosition].Value = reportTable.Rows[i]["SaldoCreditStart"];
                cells["F" + currentPosition].Value = reportTable.Rows[i]["DebitVat63"];
                cells["H" + currentPosition].Value = reportTable.Rows[i]["DebitVat631"];
                cells["J" + currentPosition].Value = reportTable.Rows[i]["CreditPeriod"];
                cells["K" + currentPosition].Value = reportTable.Rows[i]["SaldoDebitEnd"];
                cells["L" + currentPosition].Value = reportTable.Rows[i]["SaldoCreditEnd"];

                currentPosition++;
                n++;
            }

            cells["A" + startPosition + ":" + ("L" + currentPosition)].Borders.LineStyle = LineStyle.Continous;

            cells["C" + currentPosition].Value = "Разом:";
            cells["C" + currentPosition].VerticalAlignment = VAlign.Distributed;
            cells["C" + currentPosition].Font.Bold = true;
            cells["A" + currentPosition + ":" + "L" + currentPosition].Font.Size = 14;
            cells["A" + currentPosition + ":" + "L" + currentPosition].Interior.Color = Color.Bisque;

            cells["D" + currentPosition].Value = "=SUM(D" + 4 + ":" + ("D" + (currentPosition - 1)) + ")";
            cells["E" + currentPosition].Value = "=SUM(E" + 4 + ":" + ("E" + (currentPosition - 1)) + ")";
            cells["F" + currentPosition].Value = "=SUM(F" + 4 + ":" + ("F" + (currentPosition - 1)) + ")";
            cells["H" + currentPosition].Value = "=SUM(H" + 4 + ":" + ("H" + (currentPosition - 1)) + ")";
            cells["I" + currentPosition].Value = "=SUM(I" + 4 + ":" + ("I" + (currentPosition - 1)) + ")";
            cells["J" + currentPosition].Value = "=SUM(J" + 4 + ":" + ("J" + (currentPosition - 1)) + ")";
            cells["K" + currentPosition].Value = "=SUM(K" + 4 + ":" + ("K" + (currentPosition - 1)) + ")";
            cells["L" + currentPosition].Value = "=SUM(L" + 4 + ":" + ("L" + (currentPosition - 1)) + ")";
            //cells["M" + currentPosition].Value = "=SUM(M" + 4 + ":" + ("M" + (currentPosition - 1)) + ")";

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Контрагенти ПДВ 644 " + Convert.ToDateTime(startDate).Month + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Контрагенти ПДВ 644 " + Convert.ToDateTime(startDate).Month + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        #endregion MutualSettlements

        //----------------------------------------------------------------------------------------------------------------------------------------

        #region Bank

        public void BankTrialBalance(DataTable reportTable, string StartDate, string EndDate, string bankAccount, short bankAccountId)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");

            var allDataTable = reportTable.Select().ToList();
            var allPeriods = (from allData in allDataTable
                              group allData by allData.Field<Int16>("Bank_Account_Id") into GroupOutData
                              select new
                              {
                                  DebitControlSumBefore = GroupOutData.Sum(x => x.Field<decimal>("Debit_PrewPeriod")) + GroupOutData.Sum(x => x.Field<decimal>("Debit_FromPeriod")),
                                  DebitEndPeriod = GroupOutData.Sum(x => x.Field<decimal>("Debit_EndPeriod")),
                                  DebitPrewPeriod = GroupOutData.Sum(x => x.Field<decimal>("Debit_PrewPeriod")),

                                  CreditControlSumBefore = GroupOutData.Sum(x => x.Field<decimal>("Credit_PrewPeriod")) + GroupOutData.Sum(x => x.Field<decimal>("Credit_FromPeriod")),
                                  CreditEndPeriod = GroupOutData.Sum(x => x.Field<decimal>("Credit_EndPeriod")),
                                  CreditPrewPeriod = GroupOutData.Sum(x => x.Field<decimal>("Credit_PrewPeriod"))
                              }).ToList().ToList();

            if ((allPeriods.First().CreditEndPeriod != allPeriods.First().CreditControlSumBefore) || (allPeriods.First().DebitEndPeriod != allPeriods.First().DebitControlSumBefore))
            {
                MessageBox.Show("Помилка Е2342. Зверніться до програміста!");
            }

            var debitData = (from iDebitData in allDataTable
                             where iDebitData.Field<decimal>("Debit_FromPeriod") != 0
                             group iDebitData by iDebitData.Field<string>("NUM") into GroupOutData
                             select new { Num = GroupOutData.Key }).ToList();
            var creditData = (from iDebitData in allDataTable
                              where iDebitData.Field<decimal>("Credit_FromPeriod") != 0
                              group iDebitData by iDebitData.Field<string>("NUM") into GroupOutData
                              select new { Num = GroupOutData.Key }).ToList();

            var dataDebitCredit = (from iData in allDataTable
                                   where (iData.Field<decimal>("Debit_FromPeriod") != 0 || iData.Field<decimal>("Credit_FromPeriod") != 0)
                                   select iData).ToList();

            const byte DateCol = 0;
            int startDebitCol = DateCol + 1;
            int startCreditCol = DateCol + 1;

            int startRow = 10;
           
            int currentRow = startRow + 1;
            int currentDebitCol = 1;
            int currentCreditCol = 4;

            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            //  cells[0,0, 0, 1].Merge();//Y1,X1,Y2,X2
            Dictionary<string, string> listNumColDebit = new Dictionary<string, string>();
            Dictionary<string, string> listNumColcCredit = new Dictionary<string, string>();
            string num_name;
            string intervalSelect;
            DateTime activDate = new DateTime(1000, 1, 1);

            //***
            currentDebitCol = startDebitCol;
            foreach (var item in debitData)
            {
                num_name = item.Num;
                try
                {
                    var ColNameFromNum = listNumColDebit.First(x => x.Value == num_name);
                }
                catch (System.InvalidOperationException)
                {
                    cells[vsS[currentDebitCol] + currentRow].Value = num_name;
                    listNumColDebit.Add(vsS[currentDebitCol], num_name);
                    currentDebitCol++;
                }
            }
            cells[vsS[currentDebitCol] + currentRow].Value = "Всього";
            startCreditCol = currentDebitCol + 1;

            //CreditColums
            currentCreditCol = startCreditCol;
            foreach (var item in creditData)
            {
                num_name = item.Num;
                try
                {
                    var ColNameFromNum = listNumColcCredit.First(x => x.Value == num_name);
                }
                catch (System.InvalidOperationException)
                {
                    cells[vsS[currentCreditCol] + currentRow].Value = num_name;
                    listNumColcCredit.Add(vsS[currentCreditCol], num_name);
                    currentCreditCol++;
                }
            }
            cells[vsS[currentCreditCol] + currentRow].Value = "Всього";
            //SetDataTable
            currentRow = startRow + 2;
            currentRow--;
            foreach (var item in dataDebitCredit)
            {
                if (activDate != item.Field<DateTime>("Payment_Date"))
                {
                    activDate = item.Field<DateTime>("Payment_Date");
                    currentRow++;
                    cells[vsS[DateCol] + currentRow.ToString()].Value = (item.Field<DateTime>("Payment_Date")).ToString("dd.MM.yyyy");
                    if (currentDebitCol > startDebitCol)
                    {
                        cells[vsS[currentDebitCol] + currentRow].Formula = SetFormula(vsS[startDebitCol], currentRow, vsS[currentDebitCol - 1], currentRow, "SUM");
                    }
                    else
                    {
                        cells[vsS[currentDebitCol] + currentRow].Value = 0;
                    }

                    if (currentCreditCol > startCreditCol)
                    {
                        cells[vsS[currentCreditCol] + currentRow].Formula = SetFormula(vsS[startCreditCol], currentRow, vsS[currentCreditCol - 1], currentRow, "SUM");
                    }
                    else
                    {
                        cells[vsS[currentCreditCol] + currentRow].Value = 0;
                    }
                }


                //Debit
                if (item.Field<decimal>("Debit_FromPeriod") != 0)
                {
                    var ColNameFromNum = listNumColDebit.First(x => x.Value == item.Field<string>("NUM"));
                    cells[ColNameFromNum.Key + currentRow.ToString()].Value = item.Field<decimal>("Debit_FromPeriod");
                }
                //Credit
                if (item.Field<decimal>("Credit_FromPeriod") != 0)
                {
                    var ColNameFromNum = listNumColcCredit.First(x => x.Value == item.Field<string>("NUM"));
                    cells[ColNameFromNum.Key + currentRow.ToString()].Value = item.Field<decimal>("Credit_FromPeriod");
                }
            }

            //SUM 2
            currentRow++;
            var activIntervalSum = cells[vsS[DateCol] + currentRow.ToString()];
            activIntervalSum.Value = "Сума";
            activIntervalSum.Font.Bold = true;

            for (var i = DateCol + 1; i <= currentCreditCol; i++)
            {
                activIntervalSum = cells[vsS[i] + currentRow.ToString()];
                if (dataDebitCredit.Count > 0)
                    activIntervalSum.Formula = SetFormula(vsS[i], startRow + 2, vsS[i], currentRow - 1, "SUM");
                else
                {
                    activIntervalSum.Value = 0;
                    activIntervalSum.Font.Bold = true;
                }
            }
            //ShapkaTop
            DataModule.Connection.Open();
            string bankName = DataModule.ExecuteScalar(@"SELECT ""Description"" FROM Accounts WHERE Id = " + bankAccountId).ToString();
            DataModule.Connection.Close();

            var activInterval1 = cells[startRow - 3, DateCol, startRow - 3, currentCreditCol];
            activInterval1.Merge();//Y1,X1,Y2,X2
            activInterval1.WrapText = true;
            activInterval1.Value = "Рахунок " + bankAccount + ", " + bankName;
            activInterval1.HorizontalAlignment = HAlign.Center;
            activInterval1.Font.Bold = true;
            activInterval1.Font.Size = 14;

            var activInterval2 = cells[startRow - 2, DateCol, startRow - 2, currentCreditCol];
            activInterval2.Merge();//Y1,X1,Y2,X2
            activInterval2.WrapText = true;
            activInterval2.Value = "За період з " + StartDate + " по " + EndDate;
            activInterval2.HorizontalAlignment = HAlign.Center;
            activInterval2.Font.Bold = true;
            activInterval2.Font.Size = 14;

            //ShapkaTabl

            cells[vsS[DateCol] + startRow].Value = "Дата";
            cells[startRow - 1, DateCol, startRow + 1 - 1, DateCol].Merge();//Y1,X1,Y2,X2
            //*
            cells[startRow - 1, startDebitCol, startRow - 1, startCreditCol - 1].Merge();//Y1,X1,Y2,X2 
            cells[startRow - 1, startDebitCol, startRow - 1, startCreditCol - 1].Value = "З Д-ту в к-т рахунків";
            cells[startRow - 1, startCreditCol, startRow - 1, currentCreditCol].Merge();//Y1,X1,Y2,X2
            cells[startRow - 1, startCreditCol, startRow - 1, currentCreditCol].Value = "З К-ту в д-т рахунків";

            //ShapkaTable_SchetNom
            intervalSelect = vsS[DateCol] + startRow.ToString() + ":" + vsS[currentCreditCol] + (startRow + 1).ToString();
            cells[intervalSelect].WrapText = true;
            cells[intervalSelect].Font.Bold = true;
            cells[intervalSelect].HorizontalAlignment = HAlign.Center;
            cells[intervalSelect].VerticalAlignment = VAlign.Center;
            cells[intervalSelect].Borders.LineStyle = LineStyle.Continous;
            cells[intervalSelect].Columns.AutoFit();
            //worksheet.Cells["7:9"].Rows.AutoFit();

            //Text
            intervalSelect = vsS[DateCol] + (startRow + 2).ToString() + ":" + vsS[currentCreditCol] + currentRow.ToString();
            cells[intervalSelect].NumberFormat = "### ### ##0.00";
            cells[intervalSelect].Borders.LineStyle = LineStyle.Continous;
            cells[intervalSelect].Columns.AutoFit();
            cells[intervalSelect].HorizontalAlignment = HAlign.Right;
            cells[intervalSelect].ColumnWidth = 12.5;

            //Saldo
            //SaldoTableElement_Top
            currentRow = currentRow + 2;
            var activInterval = cells[vsS[DateCol + 2] + currentRow.ToString()];
            activInterval.Value = "Дебет";// "Кредит";
            activInterval.HorizontalAlignment = HAlign.Center;
            /* //04.02.2015
            activInterval = cells[vsS[DateCol + 3] + currentRow.ToString()];
            activInterval.Value = "Дебет";
            activInterval.HorizontalAlignment = HAlign.Center;
             */
            //SaldoTableElement_RightLine2
            currentRow++;
            var saldoStart = cells[currentRow - 1, DateCol, currentRow - 1, DateCol + 1];
            saldoStart.Merge();//Y1,X1,Y2,X2
            saldoStart.WrapText = true;
            saldoStart.Value = "Сальдо на початок періоду";
            saldoStart.HorizontalAlignment = HAlign.Right;
            saldoStart.Font.Bold = true;
            //SaldoTableElement_CenterTextLine1
            decimal saldo = allPeriods.First().DebitPrewPeriod - allPeriods.First().CreditPrewPeriod;
            
            activInterval = cells[vsS[DateCol + 2] + currentRow.ToString()];
            activInterval.Value = String.Format("{0:0,0.00}", saldo);
            activInterval.HorizontalAlignment = HAlign.Right;
            
            //SaldoTableElement_RightLine2
            currentRow++;
            var saldoEnd = cells[currentRow - 1, DateCol, currentRow - 1, DateCol + 1];
            saldoEnd.Merge();//Y1,X1,Y2,X2
            saldoEnd.WrapText = true;
            saldoEnd.Value = "Сальдо на кінець періоду";
            saldoEnd.HorizontalAlignment = HAlign.Right;
            saldoEnd.Font.Bold = true;
            //SaldoTableElement_CenterTextLine2
            saldo = allPeriods.First().DebitEndPeriod - allPeriods.First().CreditEndPeriod;
            
            activInterval = cells[vsS[DateCol + 2] + currentRow.ToString()];
            activInterval.Value = String.Format("{0:0,0.00}", saldo);
            activInterval.HorizontalAlignment = HAlign.Right;

            PrintSignatures(cells, currentRow + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + "ОСВ по банку " + bankAccount + " та рахункам за період з " + StartDate + " по " + EndDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "ОСВ по банку " + bankAccount + " та рахункам за період з " + StartDate + " по " + EndDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
            
        public void BankTrialBalanceQuarter(DataTable reportTable, string StartDate, string EndDate, string bankAccount, short bankAccountId)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;
           
            var allDataTable = reportTable.Select().ToList();
            
            var debitData = (from iDebitData in allDataTable
                             where iDebitData.Field<decimal>("Debit") != 0 && iDebitData.Field<int>("PR") == 0
                             group iDebitData by iDebitData.Field<string>("NUM") into GroupOutData
                             select new { Num = GroupOutData.Key }).ToList();
            var creditData = (from iDebitData in allDataTable
                              where iDebitData.Field<decimal>("Credit") != 0 && iDebitData.Field<int>("PR") == 0
                              group iDebitData by iDebitData.Field<string>("NUM") into GroupOutData
                              select new { Num = GroupOutData.Key }).ToList();

            var dataDebitCredit = (from iData in allDataTable  where (iData.Field<int>("PR") == 0) select iData).ToList();

            var numYear = allDataTable.AsEnumerable().Where(x => x.Field<short?>("Year_number") != null).Select(c => new { Year_Number = c.Field<short>("Year_Number") }).Distinct().OrderBy(c => c.Year_Number).ToList();
            
            const byte DateCol = 0;
            int startDebitCol = DateCol + 1;
            int startCreditCol = DateCol + 1;
            int startRow = 10;

            int currentRow = startRow + 1;
            int currentDebitCol = 1;
            int currentCreditCol = 4;


            //  cells[0,0, 0, 1].Merge();//Y1,X1,Y2,X2
            Dictionary<string, string> listNumColDebit = new Dictionary<string, string>();
            Dictionary<string, string> listNumColcCredit = new Dictionary<string, string>();
            string num_name;
            string intervalSelect;

            //DebitColums
            currentDebitCol = startDebitCol;
            foreach (var item in debitData)
            {
                num_name = item.Num;
                try
                {
                    var ColNameFromNum = listNumColDebit.First(x => x.Value == num_name);
                }
                catch (System.InvalidOperationException)
                {
                    cells[vsS[currentDebitCol] + currentRow].ColumnWidth = 12.5;
                    cells[vsS[currentDebitCol] + currentRow].Value = num_name;
                    listNumColDebit.Add(vsS[currentDebitCol], num_name);
                    currentDebitCol++;
                }
            }
            cells[vsS[currentDebitCol] + currentRow].Value = "Всього";
            cells[vsS[currentDebitCol] + currentRow].ColumnWidth = 15;
            startCreditCol = currentDebitCol + 1;

            //CreditColums
            currentCreditCol = startCreditCol;
            foreach (var item in creditData)
            {
                num_name = item.Num;
                try
                {
                    var ColNameFromNum = listNumColcCredit.First(x => x.Value == num_name);
                }
                catch (System.InvalidOperationException)
                {
                    cells[vsS[currentCreditCol] + currentRow].ColumnWidth = 12.5;
                    cells[vsS[currentCreditCol] + currentRow].Value = num_name;
                    listNumColcCredit.Add(vsS[currentCreditCol], num_name);
                    currentCreditCol++;
                }
            }
            cells[vsS[currentCreditCol] + currentRow].Value = "Всього";
            cells[vsS[currentCreditCol] + currentRow].ColumnWidth = 15;
            //SetDataTable
            int sumRow;
            int currentMonth;
            int currentQuarter;
            int countMonth;
            int countQuarter;
            
            for (int y = 0; y < numYear.Count(); y++)
			{
			
                DataTable currTable = reportTable.AsEnumerable().Where(x => x.Field<int>("PR") == 0 && x.Field<short>("Year_number") == numYear[y].Year_Number).CopyToDataTable();
                var numQuarter = currTable.AsEnumerable().Where(x => x.Field<short>("Year_number") == numYear[y].Year_Number).Select(c => new { Quarter_Number = c.Field<long>("Quarter_Number") }).Distinct().OrderBy(c => c.Quarter_Number).ToList();

                sumRow = currentRow;
                currentMonth = 0;
                currentQuarter = 0;
                countMonth = 0;
                countQuarter = 0;
                int[] TotalRows = new int[numQuarter.Count];

			    for (int i = 0; i < currTable.Rows.Count; i++)
                {
                    if (Convert.ToInt32(currTable.Rows[i]["Month_number"]) == currentMonth)
                    {
                        currentMonth = Convert.ToInt32(currTable.Rows[i]["Month_number"]);
                        currentRow--;
                    }
                    else
                    {
                        currentMonth = Convert.ToInt32(currTable.Rows[i]["Month_number"]);
                    }

                    // Итоговая строка по кварталам
                    if (Convert.ToInt32(currTable.Rows[i]["Quarter_Number"]) != currentQuarter)
                    {
                        currentRow++;
                        sumRow = currentRow;
                        currentQuarter = Convert.ToInt32(currTable.Rows[i]["Quarter_Number"]);
                        countMonth = (int)currTable.AsEnumerable().Where(x => x.Field<long>("Quarter_Number") == currentQuarter).GroupBy(x => x["Month_number"]).Count();
                        currentRow = currentRow + countMonth;

                        cells[vsS[DateCol] + currentRow.ToString()].Value = "Всього за " + currentQuarter.ToString() + "-й квартал " + currTable.Rows[i]["Year_number"].ToString() + " р.";
                        cells[vsS[DateCol] + currentRow.ToString()].HorizontalAlignment = HAlign.Left;
                        cells[vsS[DateCol] + currentRow.ToString()].Font.Bold = true;
                        cells[vsS[DateCol] + currentRow].Interior.Color = Color.LightBlue;

                        TotalRows[countQuarter] = currentRow;
                        countQuarter++;

                        for (var c = DateCol + 1; c <= currentCreditCol; c++)
                        {
                            var activintervalsum = cells[vsS[c] + currentRow.ToString()];
                            if (dataDebitCredit.Count > 0)
                            {
                                activintervalsum.Formula = SetFormula(vsS[c], sumRow, vsS[c], currentRow - 1, "SUM");
                                activintervalsum.Font.Bold = true;
                                activintervalsum.Interior.Color = Color.LightBlue;
                            }
                            else
                            {
                                activintervalsum.Value = 0;
                                activintervalsum.Font.Bold = true;
                                activintervalsum.Interior.Color = Color.LightBlue;
                            }
                        }
                        currentRow = sumRow;
                    }
                    // Месяца
                    cells[vsS[DateCol] + currentRow.ToString()].Value = currTable.Rows[i]["Month_name"].ToString();
                    cells[vsS[DateCol] + currentRow.ToString()].HorizontalAlignment = HAlign.Left;
                    currentQuarter = Convert.ToInt32(currTable.Rows[i]["Quarter_Number"]);

                    cells[vsS[currentDebitCol] + currentRow].Formula = SetFormula(vsS[startDebitCol], currentRow, vsS[currentDebitCol - 1], currentRow, "SUM");
                    cells[vsS[currentDebitCol] + currentRow].Font.Bold = true;
                    cells[vsS[currentDebitCol] + currentRow].Interior.Color = Color.LightBlue;
                    cells[vsS[currentCreditCol] + currentRow].Formula = SetFormula(vsS[startCreditCol], currentRow, vsS[currentCreditCol - 1], currentRow, "SUM");
                    cells[vsS[currentCreditCol] + currentRow].Font.Bold = true;
                    cells[vsS[currentCreditCol] + currentRow].Interior.Color = Color.LightBlue;

                    //Debit
                    if (Convert.ToDecimal(currTable.Rows[i]["Debit"]) != 0)
                    {
                        var ColNameFromNum = listNumColDebit.First(x => x.Value == currTable.Rows[i]["NUM"].ToString());
                        cells[ColNameFromNum.Key + currentRow.ToString()].Value = (decimal)currTable.Rows[i]["Debit"];
                    }
                    //Credit
                    if (Convert.ToDecimal(currTable.Rows[i]["Credit"]) != 0)
                    {
                        var ColNameFromNum = listNumColcCredit.First(x => x.Value == currTable.Rows[i]["NUM"].ToString());
                        cells[ColNameFromNum.Key + currentRow.ToString()].Value = (decimal)currTable.Rows[i]["Credit"];
                    }
                    currentRow++;
                }
            
                currentRow++;
                var activIntervalSum = cells[vsS[DateCol] + currentRow.ToString()];
                activIntervalSum.Value = "Сума за " + numYear[y].Year_Number.ToString() + "р. :";
                activIntervalSum.Font.Bold = true;
                activIntervalSum.Font.Size = 12;
                activIntervalSum.Interior.Color = Color.LightBlue;
                string rangeSUM = "";
                for (var i = DateCol + 1; i <= currentCreditCol; i++)
                  {
                    activIntervalSum = cells[vsS[i] + currentRow.ToString()];
                    activIntervalSum.Interior.Color = Color.LightBlue;
                    activIntervalSum.Font.Bold = true;
                    activIntervalSum.Font.Size = 12;
                    for (int a = 0; a < TotalRows.Length; a++)
                    {
                        rangeSUM = rangeSUM + vsS[i] + TotalRows[a].ToString() + ",";
                    }
                    if (dataDebitCredit.Count > 0)
                    {
                        activIntervalSum.Value = "=SUM" + "(" + rangeSUM.Remove(rangeSUM.Length - 1) + ")";
                    }
                    else
                    {
                        activIntervalSum.Value = 0;
                    }
                    rangeSUM = "";
                  }
            }
           
            //ShapkaTop
            DataModule.Connection.Open();
            string bankName = (string)DataModule.ExecuteScalar(@"SELECT ""Description"" FROM Accounts WHERE Id = " + bankAccountId);
            DataModule.Connection.Close();

            var activInterval1 = cells[startRow - 3, DateCol, startRow - 3, currentCreditCol];
            activInterval1.Merge();//Y1,X1,Y2,X2
            activInterval1.WrapText = true;
            activInterval1.Value = "Рахунок " + bankAccount + ", " + bankName;
            activInterval1.HorizontalAlignment = HAlign.Center;
            activInterval1.Font.Bold = true;
            activInterval1.Font.Size = 14;
           
            var activInterval2 = cells[startRow - 2, DateCol, startRow - 2, currentCreditCol];
            activInterval2.Merge();//Y1,X1,Y2,X2
            activInterval2.WrapText = true;
            activInterval2.Value = "За період з " + StartDate + " по " + EndDate;
            activInterval2.HorizontalAlignment = HAlign.Center;
            activInterval2.Font.Bold = true;
            activInterval2.Font.Size = 14;

            //ShapkaTabl

            cells[vsS[DateCol] + startRow].Value = "Місяць";
            cells[vsS[DateCol] + startRow].ColumnWidth = 24.5;
            cells[startRow - 1, DateCol, startRow + 1 - 1, DateCol].Merge();//Y1,X1,Y2,X2
            //*
            cells[startRow - 1, startDebitCol, startRow - 1, startCreditCol - 1].Merge();//Y1,X1,Y2,X2 
            cells[startRow - 1, startDebitCol, startRow - 1, startCreditCol - 1].Value = "З Д-ту в к-т рахунків";
            cells[startRow - 1, startDebitCol, startRow - 1, startCreditCol - 1].HorizontalAlignment = HAlign.Center;
            cells[startRow - 1, startCreditCol, startRow - 1, currentCreditCol].Merge();//Y1,X1,Y2,X2
            cells[startRow - 1, startCreditCol, startRow - 1, currentCreditCol].Value = "З К-ту в Д-т рахунків";
            cells[startRow - 1, startCreditCol, startRow - 1, currentCreditCol].HorizontalAlignment = HAlign.Center;

            //ShapkaTable_SchetNom
            intervalSelect = vsS[DateCol] + startRow.ToString() + ":" + vsS[currentCreditCol] + (startRow + 1).ToString();
            cells[intervalSelect].WrapText = true;
            cells[intervalSelect].Font.Bold = true;
            cells[intervalSelect].HorizontalAlignment = HAlign.Center;
            cells[intervalSelect].VerticalAlignment = VAlign.Center;
            cells[intervalSelect].Borders.LineStyle = LineStyle.Continous;

            //Text
            intervalSelect = vsS[DateCol] + (startRow + 2).ToString() + ":" + vsS[currentCreditCol] + currentRow.ToString();
            cells[intervalSelect].NumberFormat = "### ### ##0.00";
            cells[intervalSelect].Borders.LineStyle = LineStyle.Continous;
            cells[vsS[DateCol + 1] + startRow.ToString() + ":" + vsS[currentCreditCol] + (startRow + 1).ToString()].HorizontalAlignment = HAlign.Center;
            
            //Saldo
            //SaldoTableElement_Top
            currentRow = currentRow + 2;
            var activInterval = cells[vsS[DateCol + 2] + currentRow.ToString()];
            activInterval.Value = "Дебет";// "Кредит";
            activInterval.HorizontalAlignment = HAlign.Center;
  
             //SaldoTableElement_RightLine2
            currentRow++;
            var saldoStart = cells[currentRow - 1, DateCol, currentRow - 1, DateCol + 1];
            saldoStart.Merge();//Y1,X1,Y2,X2
            saldoStart.WrapText = true;
            saldoStart.Value = "Сальдо на початок періоду";
            saldoStart.HorizontalAlignment = HAlign.Right;
            saldoStart.Font.Bold = true;
            //SaldoTableElement_CenterTextLine1

            int pr = 3;
            var saldoStartPeriod = allDataTable.AsEnumerable().Where(x => x.Field<int>("PR") == pr).Select(c => new { prewPeriod = c.Field<decimal>("Debit") - c.Field<decimal>("Credit")}).ToList();

            activInterval = cells[vsS[DateCol + 2] + currentRow.ToString()];
            activInterval.Value = String.Format("{0:0,0.00}", saldoStartPeriod[0].prewPeriod);
            activInterval.HorizontalAlignment = HAlign.Right;

            //SaldoTableElement_RightLine2
            currentRow++;
            var saldoEnd = cells[currentRow - 1, DateCol, currentRow - 1, DateCol + 1];
            saldoEnd.Merge();//Y1,X1,Y2,X2
            saldoEnd.WrapText = true;
            saldoEnd.Value = "Сальдо на кінець періоду";
            saldoEnd.HorizontalAlignment = HAlign.Right;
            saldoEnd.Font.Bold = true;
            //SaldoTableElement_CenterTextLine2
            pr = 2;
            var saldoEndPeriod = allDataTable.AsEnumerable().Where(x => x.Field<int>("PR") == pr).Select(c => new { endPeriod = c.Field<decimal>("Debit") - c.Field<decimal>("Credit")}).ToList();

            activInterval = cells[vsS[DateCol + 2] + currentRow.ToString()];
            activInterval.Value = String.Format("{0:0,0.00}", saldoEndPeriod[0].endPeriod);
            activInterval.HorizontalAlignment = HAlign.Right;
            worksheet.Name = bankAccount.ToString();

            PrintSignatures(cells, currentRow + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + "ОСВ по банку " + bankAccount + " та рахункам (поквартально).xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "ОСВ по банку " + bankAccount + " та рахункам (поквартально).xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
       
        public void BankTrialBalanceForCustomBill(DataTable reportTable, string StartDate, string EndDate, string bankAccount)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");

            var allDataTable = reportTable.Select().ToList();
            var allPeriods = (from allData in allDataTable
                              group allData by allData.Field<Int16>("Purpose_Account_Id") into GroupOutData
                              select new
                              {
                                  DebitControlSumBefore = GroupOutData.Sum(x => x.Field<decimal>("Debit_PrewPeriod")) + GroupOutData.Sum(x => x.Field<decimal>("Debit_FromPeriod")),
                                  DebitEndPeriod = GroupOutData.Sum(x => x.Field<decimal>("Debit_EndPeriod")),
                                  DebitPrewPeriod = GroupOutData.Sum(x => x.Field<decimal>("Debit_PrewPeriod")),

                                  CreditControlSumBefore = GroupOutData.Sum(x => x.Field<decimal>("Credit_PrewPeriod")) + GroupOutData.Sum(x => x.Field<decimal>("Credit_FromPeriod")),
                                  CreditEndPeriod = GroupOutData.Sum(x => x.Field<decimal>("Credit_EndPeriod")),
                                  CreditPrewPeriod = GroupOutData.Sum(x => x.Field<decimal>("Credit_PrewPeriod"))
                              }).ToList().ToList();

            if ((allPeriods.First().CreditEndPeriod != allPeriods.First().CreditControlSumBefore) || (allPeriods.First().DebitEndPeriod != allPeriods.First().DebitControlSumBefore))
            {
                MessageBox.Show("Помилка Е2342. Зверніться до програміста!");
            }

            var debitData = (from iDebitData in allDataTable
                             where iDebitData.Field<decimal>("Debit_FromPeriod") != 0
                             group iDebitData by iDebitData.Field<string>("NUM") into GroupOutData
                             select new { Num = GroupOutData.Key }).ToList();
            var creditData = (from iDebitData in allDataTable
                              where iDebitData.Field<decimal>("Credit_FromPeriod") != 0
                              group iDebitData by iDebitData.Field<string>("NUM") into GroupOutData
                              select new { Num = GroupOutData.Key }).ToList();

            var dataDebitCredit = (from iData in allDataTable
                                   where (iData.Field<decimal>("Debit_FromPeriod") != 0 || iData.Field<decimal>("Credit_FromPeriod") != 0)
                                   select iData).ToList();

            const byte DateCol = 0;
            int startDebitCol = DateCol + 1;
            int startCreditCol = DateCol + 1;
            int startRow = 10;

            int currentRow = startRow + 1;
            int currentDebitCol = 1;
            int currentCreditCol = 4;

            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;

            //  cells[0,0, 0, 1].Merge();//Y1,X1,Y2,X2
            Dictionary<string, string> listNumColDebit = new Dictionary<string, string>();
            Dictionary<string, string> listNumColcCredit = new Dictionary<string, string>();
            string num_name;
            string intervalSelect;
            DateTime activDate = new DateTime(1000, 1, 1);

            //***
            currentDebitCol = startDebitCol;
            foreach (var item in debitData)
            {
                num_name = item.Num;
                try
                {
                    var ColNameFromNum = listNumColDebit.First(x => x.Value == num_name);
                }
                catch (System.InvalidOperationException)
                {
                    cells[vsS[currentDebitCol] + currentRow].Value = num_name;
                    listNumColDebit.Add(vsS[currentDebitCol], num_name);
                    currentDebitCol++;
                }
            }
            cells[vsS[currentDebitCol] + currentRow].Value = "Всього";
            startCreditCol = currentDebitCol + 1;

            //CreditColums
            currentCreditCol = startCreditCol;
            foreach (var item in creditData)
            {
                num_name = item.Num;
                try
                {
                    var ColNameFromNum = listNumColcCredit.First(x => x.Value == num_name);
                }
                catch (System.InvalidOperationException)
                {
                    cells[vsS[currentCreditCol] + currentRow].Value = num_name;
                    listNumColcCredit.Add(vsS[currentCreditCol], num_name);
                    currentCreditCol++;
                }
            }
            cells[vsS[currentCreditCol] + currentRow].Value = "Всього";
            //SetDataTable
            currentRow = startRow + 2;
            currentRow--;
            foreach (var item in dataDebitCredit)
            {
                if (activDate != item.Field<DateTime>("Payment_Date"))
                {
                    activDate = item.Field<DateTime>("Payment_Date");
                    currentRow++;
                    cells[vsS[DateCol] + currentRow.ToString()].Value = (item.Field<DateTime>("Payment_Date")).ToString("dd.MM.yyyy");
                    if (currentDebitCol > startDebitCol)
                    {
                        cells[vsS[currentDebitCol] + currentRow].Formula = SetFormula(vsS[startDebitCol], currentRow, vsS[currentDebitCol - 1], currentRow, "SUM");
                    }
                    else
                    {
                        cells[vsS[currentDebitCol] + currentRow].Value = 0;
                    }

                    if (currentCreditCol > startCreditCol)
                    {
                        cells[vsS[currentCreditCol] + currentRow].Formula = SetFormula(vsS[startCreditCol], currentRow, vsS[currentCreditCol - 1], currentRow, "SUM");
                    }
                    else
                    {
                        cells[vsS[currentCreditCol] + currentRow].Value = 0;
                    }
                }


                //Debit
                if (item.Field<decimal>("Debit_FromPeriod") != 0)
                {
                    var ColNameFromNum = listNumColDebit.First(x => x.Value == item.Field<string>("NUM"));
                    cells[ColNameFromNum.Key + currentRow.ToString()].Value = item.Field<decimal>("Debit_FromPeriod");
                }
                //Credit
                if (item.Field<decimal>("Credit_FromPeriod") != 0)
                {
                    var ColNameFromNum = listNumColcCredit.First(x => x.Value == item.Field<string>("NUM"));
                    cells[ColNameFromNum.Key + currentRow.ToString()].Value = item.Field<decimal>("Credit_FromPeriod");
                }
            }

            //SUM 2
            currentRow++;
            var activIntervalSum = cells[vsS[DateCol] + currentRow.ToString()];
            activIntervalSum.Value = "Сума";
            activIntervalSum.Font.Bold = true;

            for (var i = DateCol + 1; i <= currentCreditCol; i++)
            {
                activIntervalSum = cells[vsS[i] + currentRow.ToString()];
                if (dataDebitCredit.Count > 0)
                    activIntervalSum.Formula = SetFormula(vsS[i], startRow + 2, vsS[i], currentRow - 1, "SUM");
                else
                {
                    activIntervalSum.Value = 0;
                    activIntervalSum.Font.Bold = true;
                }
            }


            var activInterval1 = cells[startRow - 3, DateCol, startRow - 3, currentCreditCol];
            activInterval1.Merge();//Y1,X1,Y2,X2
            activInterval1.WrapText = true;
            activInterval1.Value = "Рахунок " + bankAccount;
            activInterval1.HorizontalAlignment = HAlign.Center;
            activInterval1.Font.Bold = true;
            activInterval1.Font.Size = 14;

            var activInterval2 = cells[startRow - 2, DateCol, startRow - 2, currentCreditCol];
            activInterval2.Merge();//Y1,X1,Y2,X2
            activInterval2.WrapText = true;
            activInterval2.Value = "За період з " + StartDate + " по " + EndDate;
            activInterval2.HorizontalAlignment = HAlign.Center;
            activInterval2.Font.Bold = true;
            activInterval2.Font.Size = 14;

            //ShapkaTabl

            cells[vsS[DateCol] + startRow].Value = "Дата";
            cells[startRow - 1, DateCol, startRow + 1 - 1, DateCol].Merge();//Y1,X1,Y2,X2
            //*
            cells[startRow - 1, startDebitCol, startRow - 1, startCreditCol - 1].Merge();//Y1,X1,Y2,X2 
            cells[startRow - 1, startDebitCol, startRow - 1, startCreditCol - 1].Value = "Кредит";
            cells[startRow - 1, startCreditCol, startRow - 1, currentCreditCol].Merge();//Y1,X1,Y2,X2
            cells[startRow - 1, startCreditCol, startRow - 1, currentCreditCol].Value = "Дебет";

            //ShapkaTable_SchetNom
            intervalSelect = vsS[DateCol] + startRow.ToString() + ":" + vsS[currentCreditCol] + (startRow + 1).ToString();
            cells[intervalSelect].WrapText = true;
            cells[intervalSelect].Font.Bold = true;
            cells[intervalSelect].HorizontalAlignment = HAlign.Center;
            cells[intervalSelect].VerticalAlignment = VAlign.Center;
            cells[intervalSelect].Borders.LineStyle = LineStyle.Continous;
            cells[intervalSelect].Columns.AutoFit();
            //worksheet.Cells["7:9"].Rows.AutoFit();

            //Text
            intervalSelect = vsS[DateCol] + (startRow + 2).ToString() + ":" + vsS[currentCreditCol] + currentRow.ToString();
            cells[intervalSelect].NumberFormat = "### ### ##0.00";
            cells[intervalSelect].Borders.LineStyle = LineStyle.Continous;
            cells[intervalSelect].Columns.AutoFit();
            cells[intervalSelect].HorizontalAlignment = HAlign.Right;
            cells[intervalSelect].ColumnWidth = 12.5;

            //Saldo
            //SaldoTableElement_Top
            currentRow = currentRow + 2;
            var activInterval = cells[vsS[DateCol + 2] + currentRow.ToString()];
            activInterval.Value = "Кредит";
            activInterval.HorizontalAlignment = HAlign.Center;
            activInterval = cells[vsS[DateCol + 3] + currentRow.ToString()];
            activInterval.Value = "Дебет";
            activInterval.HorizontalAlignment = HAlign.Center;
            //SaldoTableElement_RightLine2
            currentRow++;
            var saldoStart = cells[currentRow - 1, DateCol, currentRow - 1, DateCol + 1];
            saldoStart.Merge();//Y1,X1,Y2,X2
            saldoStart.WrapText = true;
            saldoStart.Value = "Сальдо на початок періоду";
            saldoStart.HorizontalAlignment = HAlign.Right;
            saldoStart.Font.Bold = true;
            //SaldoTableElement_CenterTextLine1
            decimal saldo = allPeriods.First().DebitPrewPeriod - allPeriods.First().CreditPrewPeriod;
            if (saldo > 0)
            {
                activInterval = cells[vsS[DateCol + 2] + currentRow.ToString()];
                activInterval.Value = String.Format("{0:0,0.00}", (Math.Abs(saldo)));
                activInterval.HorizontalAlignment = HAlign.Right;
                activInterval = cells[vsS[DateCol + 3] + currentRow.ToString()];
                activInterval.Value = "0,00";
                activInterval.HorizontalAlignment = HAlign.Right;
            }
            else
            {
                activInterval = cells[vsS[DateCol + 3] + (currentRow).ToString()];
                activInterval.Value = String.Format("{0:0,0.00}", (Math.Abs(saldo)));
                activInterval.HorizontalAlignment = HAlign.Right;
                activInterval = cells[vsS[DateCol + 2] + (currentRow).ToString()];
                activInterval.Value = "0,00";
                activInterval.HorizontalAlignment = HAlign.Right;
            }

            //SaldoTableElement_RightLine2
            currentRow++;
            var saldoEnd = cells[currentRow - 1, DateCol, currentRow - 1, DateCol + 1];
            saldoEnd.Merge();//Y1,X1,Y2,X2
            saldoEnd.WrapText = true;
            saldoEnd.Value = "Сальдо на кінець періоду";
            saldoEnd.HorizontalAlignment = HAlign.Right;
            saldoEnd.Font.Bold = true;
            //SaldoTableElement_CenterTextLine2
            saldo = allPeriods.First().DebitEndPeriod - allPeriods.First().CreditEndPeriod;
            if (saldo > 0)
            {
                activInterval = cells[vsS[DateCol + 2] + currentRow.ToString()];
                activInterval.Value = String.Format("{0:0,0.00}", (Math.Abs(saldo)));
                activInterval.HorizontalAlignment = HAlign.Right;
                activInterval = cells[vsS[DateCol + 3] + currentRow.ToString()];
                activInterval.Value = "0,00";
                activInterval.HorizontalAlignment = HAlign.Right;
            }
            else
            {
                activInterval = cells[vsS[DateCol + 3] + (currentRow).ToString()];
                activInterval.Value = String.Format("{0:0,0.00}", (Math.Abs(saldo)));
                activInterval.HorizontalAlignment = HAlign.Right;
                activInterval = cells[vsS[DateCol + 2] + (currentRow).ToString()];
                activInterval.Value = "0,00";
                activInterval.HorizontalAlignment = HAlign.Right;
            }

            PrintSignatures(cells, currentRow + 3);

            try
            {
                workbook.SaveAs(GeneratedReportsDir + "ОСВ по рахунку " + bankAccount + " з " + StartDate + " по " + EndDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "ОСВ по рахунку " + bankAccount + " з " + StartDate + " по " + EndDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void BankTrialBalanceFull(DataTable reportTable, string StartDate, string EndDate)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SpreadsheetGear.IWorkbook workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            Dictionary<int, string> headerColumn = new Dictionary<int, string>();

            int bankDebetCount = reportTable.AsEnumerable()
                .Where(w => w.Field<short?>("Direction") < 0)    
                .Select(c => new { AccountId = c.Field<short>("Bank_Account_Id") })
                .Distinct()
                .Count();
            
            int bankCreditCount = reportTable.AsEnumerable()
                .Where(w => w.Field<short?>("Direction") > 0) 
                .Select(c => new { AccountId = c.Field<short>("Bank_Account_Id") })
                .Distinct()
                .Count(); ;


            string name = string.Format("Оборотно-сальдова відомість по банкам за період з {0} по {1}", StartDate, EndDate);

            Action<IRange, int, short, short> WriteHeader = (curCell, currentPos, headerStartPos, directionState) =>
            {
                var Accounts = reportTable.AsEnumerable()
                    .Where(c => c.Field<short?>("Direction") == directionState)
                    .Select(c => new
                        {
                            AccountNum = c.Field<string>("PurposeNum")
                        })
                    .Distinct()
                    .OrderBy(c => c.AccountNum);
                
                foreach (var acc in Accounts)
                {
                    headerColumn.Add(headerStartPos, acc.AccountNum);
                    curCell["A" + currentPos].Interior.Color = Color.LightGray;
                    curCell[vsS[headerStartPos] + currentPos].Value = acc.AccountNum;
                    headerStartPos++;
                }
                curCell[vsS[headerStartPos] + currentPos].Value = "Всього по банку";
                curCell[vsS[headerStartPos] + currentPos].Interior.Color = Color.LightBlue;
                curCell["B" + currentPos + ":" + vsS[headerColumn.Count + 1] + currentPos].HorizontalAlignment = HAlign.Center;
                curCell["B" + currentPos + ":" + vsS[headerColumn.Count + 1] + currentPos].Font.Bold = true;

            };

            int captionPosition = 7;
            int currentPosition = 0;
            short startHeaderPosition = 1;
            short debitCreditState = 0;
            int bankAccount = 0;
            int sourceRowCount = reportTable.Rows.Count;
            int bankCount = 0;

            for (int i = 0; i < sourceRowCount; i++)
            {
                if ((short)reportTable.Rows[i]["Direction"] != debitCreditState)
                {
                    if(currentPosition > 0)
                        PrintSignatures(cells, currentPosition + 3);

                    currentPosition = captionPosition + 1;
                    headerColumn.Clear();

                    debitCreditState = (short)reportTable.Rows[i]["Direction"];
                    bankCount = (debitCreditState < 0) ? bankDebetCount : bankCreditCount;
                    
                    //worksheet = workbook.Worksheets.Add();
                    
                    worksheet = (IWorksheet)workbook.Worksheets["Лист1"].CopyAfter(workbook.Worksheets["Лист1"]);
                    worksheet.Name = (debitCreditState < 0) ? "Дебет" : "Кредит";
                    cells = worksheet.Cells;
                    
                    WriteHeader(cells, currentPosition, startHeaderPosition, debitCreditState);

                    cells["A" + captionPosition + ":" + vsS[headerColumn.Count + 1] + captionPosition].Merge();
                    cells["A" + captionPosition].Value = name;
                    cells["A" + captionPosition].Font.Bold = true;

                    cells["A" + captionPosition].HorizontalAlignment = HAlign.Center;
                    cells["A" + currentPosition + ":" + vsS[headerColumn.Count + 1] + (bankCount + 1 + currentPosition)].Borders.LineStyle = LineStyle.Continous;
                    cells["A" + currentPosition + ":" + vsS[headerColumn.Count + 1] + currentPosition].ColumnWidth = 18;
                    cells["B" + (currentPosition + 1) + ":" + vsS[headerColumn.Count + 1] + (bankCount + 1 + currentPosition)].NumberFormat = "### ### ##0.00";

                    cells["A" + ((bankCount + 1) + currentPosition)].Value = "Всього по рахунку";
                    cells["A" + ((bankCount + 1) + currentPosition)].Interior.Color = Color.LightBlue;
                    cells["A" + ((bankCount + 1) + currentPosition)].HorizontalAlignment = HAlign.Left;
                    cells["A" + ((bankCount + 1) + currentPosition)].Font.Bold = true;

                    int headerCount = headerColumn.Count;

                    for (int j = 1; j <= headerCount + 1; j++)
                    {
                        cells[vsS[j] + ((bankCount + 1) + currentPosition)].Formula = SetFormula(vsS[j], currentPosition + 1, vsS[j], (bankCount + currentPosition), "SUM");
                        cells[vsS[j] + ((bankCount + 1) + currentPosition)].Interior.Color = Color.LightBlue;
                        cells[vsS[j] + ((bankCount + 1) + currentPosition)].Font.Bold = true;
                    }

                    
                }

                if ((short)reportTable.Rows[i]["Bank_Account_Id"] != bankAccount)
                {
                    currentPosition++;
                    bankAccount = (short)reportTable.Rows[i]["Bank_Account_Id"];
                    cells["A" + currentPosition].Value = reportTable.Rows[i]["BankNum"];
                    cells["A" + currentPosition].HorizontalAlignment = HAlign.Left;
                    cells["A" + currentPosition].Font.Bold = true;
                }

                int dictHeaderKey = headerColumn.FirstOrDefault(x => x.Value == (string)reportTable.Rows[i]["PurposeNum"]).Key;
                cells[vsS[dictHeaderKey] + currentPosition ].Value = (debitCreditState < 0) ? reportTable.Rows[i]["Credit_FromPeriod"] : reportTable.Rows[i]["Debit_FromPeriod"];
                cells[vsS[headerColumn.Count + 1] + currentPosition ].Formula = SetFormula("B", currentPosition, vsS[headerColumn.Count], currentPosition, "SUM");
                cells[vsS[headerColumn.Count + 1] + currentPosition ].Interior.Color = Color.LightBlue;
                cells[vsS[headerColumn.Count + 1] + currentPosition ].Font.Bold = true;

            }

            PrintSignatures(cells, currentPosition + 3);
            workbook.Worksheets[0].Delete();

            try
            {
                workbook.SaveAs(GeneratedReportsDir + name + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + name + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void ExportPaymentsList(DataTable SourseDataTable, string startDate, string endDate)
        {
            if (SourseDataTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "PaymentsList.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;

            //Var
            int captionPosition = 6;
            int startRowIndex = captionPosition + 1;
            int activRowIndex = startRowIndex + 2;
            int sumColIndex = 14;
            string nameLastCol = vsS[sumColIndex - 1];

            //Head
            cells["A" + captionPosition].Value = "Звіт по платежам за період з " + startDate + " по " + endDate;
            cells["F" + (startRowIndex + 2)].Value = "Рахунок банку";
            cells["N" + (startRowIndex + 2)].Value = "Призначення платежу";
            //Body
            foreach (DataRow line in SourseDataTable.Rows)
            {
                activRowIndex++;

                cells[String.Format("{0}{1}", vsS[0], activRowIndex)].Value = line["PartnerSrn"];
                cells[String.Format("{0}{1}", vsS[1], activRowIndex)].Value = line["PartnerName"];
                cells[String.Format("{0}{1}", vsS[2], activRowIndex)].Value = line["OrderNumber"];
                cells[String.Format("{0}{1}", vsS[3], activRowIndex)].Value = line["Payment_Date"];
                cells[String.Format("{0}{1}", vsS[4], activRowIndex)].Value = line["Payment_Document"];
                cells[String.Format("{0}{1}", vsS[5], activRowIndex)].Value = line["Bank_Account_Num"];
                cells[String.Format("{0}{1}", vsS[6], activRowIndex)].Value = line["Purpose_Account_Num"];
                cells[String.Format("{0}{1}", vsS[7], activRowIndex)].Value = line["Debit_Price"];
                cells[String.Format("{0}{1}", vsS[8], activRowIndex)].Value = line["Debit_PriceCurrency"];
                cells[String.Format("{0}{1}", vsS[9], activRowIndex)].Value = line["Credit_Price"];
                cells[String.Format("{0}{1}", vsS[10], activRowIndex)].Value = line["Credit_PriceCurrency"];
                cells[String.Format("{0}{1}", vsS[11], activRowIndex)].Value = line["CurrencyName"];
                cells[String.Format("{0}{1}", vsS[12], activRowIndex)].Value = line["Rate"];
                cells[String.Format("{0}{1}", vsS[13], activRowIndex)].Value = line["Purpose"];
            }

            activRowIndex++;

            cells[String.Format("{0}{1}", vsS[0], activRowIndex)].Value = "Всього:";
            cells[String.Format("A{0}:{1}{2}", activRowIndex, nameLastCol, activRowIndex)].Interior.Color = Color.LightGreen;
            cells[String.Format("A{0}:{1}{2}", activRowIndex, nameLastCol, activRowIndex)].Font.Bold = true;
            cells[String.Format("B{0}:{1}{2}", activRowIndex, nameLastCol, activRowIndex)].NumberFormat = "### ### ##0.00";
            cells[String.Format("{0}{1}", vsS[7], activRowIndex)].Value = SourseDataTable.AsEnumerable().Where(w => w["Debit_Price"] != DBNull.Value).Sum(s => s.Field<decimal>("Debit_Price"));
            cells[String.Format("{0}{1}", vsS[8], activRowIndex)].Value = SourseDataTable.AsEnumerable().Where(w => w["Debit_PriceCurrency"] != DBNull.Value).Sum(s => s.Field<decimal>("Debit_PriceCurrency"));
            cells[String.Format("{0}{1}", vsS[9], activRowIndex)].Value = SourseDataTable.AsEnumerable().Where(w => w["Credit_Price"] != DBNull.Value).Sum(s => s.Field<decimal>("Credit_Price"));
            cells[String.Format("{0}{1}", vsS[10], activRowIndex)].Value = SourseDataTable.AsEnumerable().Where(w => w["Credit_PriceCurrency"] != DBNull.Value).Sum(s => s.Field<decimal>("Credit_PriceCurrency"));
                

            cells[String.Format("A{0}:{1}{2}", startRowIndex, nameLastCol, activRowIndex)].Borders.LineStyle = LineStyle.Continous;

            PrintSignatures(cells, activRowIndex + 3);

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Звіт по платежам за період з " + startDate + " по " + endDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Звіт по платежам за період з " + startDate + " по " + endDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдено програму Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        #endregion Bank

        //----------------------------------------------------------------------------------------------------------------------------------------

        #region FixedAssetsReport

        public void FixedAssetsReportStrait(DataTable reportFixedAssetsInventoryTable, string startDate, string endDate, Boolean Zero)
        {
            if (reportFixedAssetsInventoryTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "FixedAssetsReportStrait.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;
            StringBuilder SumH = new StringBuilder("=");
            StringBuilder SumJ = new StringBuilder("=");
            StringBuilder SumI = new StringBuilder("=");
            StringBuilder SumK = new StringBuilder("=");
            StringBuilder SumL = new StringBuilder("=");
            StringBuilder SumM = new StringBuilder("=");
            StringBuilder SumN = new StringBuilder("=");

            Dictionary<string, string> ColumNameAsFAM_NUM = new Dictionary<string, string>();
            Dictionary<string, StringBuilder> FAM_NUMAsColumSum = new Dictionary<string, StringBuilder>();

            Func<Int32, string> ColumNameByIndex = (x) => { return vsS[x + 1]; };

            Action<IRange, int, int, int, Dictionary<string, string>> WriteHatSum = (cel, currentPos, rowsStartGr, lastColIndexHat, DColumNameAsFAM_NUM) =>
            {
                cells["A" + currentPos + ":" + "G" + currentPos].Merge();
                cel["A" + currentPos].Value = "Всього";
                string startIndexSum = (rowsStartGr + 1).ToString();
                string endIndexSum = (currentPos - 1).ToString();
                cel["H" + currentPos].Value = "=SUM(H" + startIndexSum + ":H" + endIndexSum + ")";
                SumH.AppendFormat("+H{0}", currentPos.ToString());
                cel["I" + currentPos].Value = "=SUM(I" + startIndexSum + ":I" + endIndexSum + ")";
                SumI.AppendFormat("+I{0}", currentPos.ToString());

                cel["J" + currentPos].Value = "=SUM(J" + startIndexSum + ":J" + endIndexSum + ")";
                SumJ.AppendFormat("+J{0}", currentPos.ToString());
                cel["K" + currentPos].Value = "=SUM(K" + startIndexSum + ":K" + endIndexSum + ")";
                SumK.AppendFormat("+K{0}", currentPos.ToString());
                if (!Zero)
                {
                    cel["L" + currentPos].Value = "=SUM(L" + startIndexSum + ":L" + endIndexSum + ")";
                    SumL.AppendFormat("+L{0}", currentPos.ToString());

                    cel["M" + currentPos].Value = "=SUM(M" + startIndexSum + ":M" + endIndexSum + ")";
                    SumM.AppendFormat("+M{0}", currentPos.ToString());

                    foreach (var item in DColumNameAsFAM_NUM)
                    {
                        cel[item.Key + currentPos].Value = "=SUM(" + item.Key + startIndexSum + ":" + item.Key + endIndexSum + ")";
                        if (FAM_NUMAsColumSum.ContainsKey(item.Value))
                        {
                            FAM_NUMAsColumSum[item.Value].AppendFormat("+{0}{1}", item.Key, currentPos.ToString());
                        }
                    }
                }
                cells["A" + rowsStartGr + ":" + "H" + rowsStartGr].Borders.LineStyle = LineStyle.Continous;
                cells["A" + currentPos + ":" + ColumNameByIndex(lastColIndexHat) + currentPos].Interior.Color = Color.LightGreen;
                cells["A" + currentPos + ":" + ColumNameByIndex(lastColIndexHat) + currentPos].NumberFormat = "### ### ##0.00"; 
            };

            Action<IRange, int, int, int, Dictionary<string, string>> WriteHatGlobalSum = (cel, currentPos, rowsStartGr, lastColIndexHat, DColumNameAsFAM_NUM) =>
            {
                cells["A" + currentPos + ":" + "G" + currentPos].Merge();
                cel["A" + currentPos].Value = "Сума";
                string startIndexSum = (rowsStartGr + 1).ToString();
                string endIndexSum = (currentPos - 1).ToString();
                cel["H" + currentPos].Value = SumH.ToString();
                cel["I" + currentPos].Value = SumI.ToString();
                cel["J" + currentPos].Value = SumJ.ToString();
                cel["K" + currentPos].Value = SumK.ToString();
                if (!Zero)
                {
                    cel["L" + currentPos].Value = SumL.ToString();
                    cel["M" + currentPos].Value = SumM.ToString();
                    
                    foreach (var item in DColumNameAsFAM_NUM)
                    {
                        cel[item.Key + currentPos].Value = FAM_NUMAsColumSum[item.Value].ToString();
                    }
                }

                cells["A" + rowsStartGr + ":" + "G" + rowsStartGr].Borders.LineStyle = LineStyle.Continous;
                cells["A" + currentPos + ":" + ColumNameByIndex(lastColIndexHat) + currentPos].Interior.Color = Color.Silver;
                cells["A" + currentPos + ":" + ColumNameByIndex(lastColIndexHat) + currentPos].Font.Bold = true;
                cells["A" + currentPos + ":" + ColumNameByIndex(lastColIndexHat) + currentPos].NumberFormat = "### ### ##0.00"; 
            };

            int n = 1;
            int captionPosition = 7;
            int startPosition = captionPosition + 2;
            int currentPosition = startPosition + 1;
            string activGroup = "@#$%^@&&";
            int rowsStartGroup = 0;
            int startNumColumIndexHat = 12;
            int lastColumIndexHat = -1;
            /*
                        var ListFAM_NUM = (from data in reportFixedAssetsInventoryTable.AsEnumerable()
                                           group data by data.Field<string>("FAM_NUM") into grdata
                                           select new
                                           {
                                               FAM_NUM = grdata.Key
                                           }).ToList();

                        Dictionary<string, string> ColumNameAsFAM_NUM = new Dictionary<string, string>();
                        foreach (var item in ListFAM_NUM)
                        {
                            ColumNameAsFAM_NUM.Add(ColumNameByIndex(startNumColumIndexHat), item.FAM_NUM);
                            cells[ColumNameByIndex(startNumColumIndexHat) + (startPosition - 1).ToString()].Value = item.FAM_NUM;
                            startNumColumIndexHat++;
                            lastColumIndexHat = startNumColumIndexHat - 1;
                        }
            */
            List<String> listOSNum = new List<String>() { "23", "91", "92", "93" };
            if (!Zero)
            {
                foreach (var item in listOSNum)
                {
                    ColumNameAsFAM_NUM.Add(ColumNameByIndex(startNumColumIndexHat), item);
                    FAM_NUMAsColumSum.Add(item, new StringBuilder("="));
                    cells[ColumNameByIndex(startNumColumIndexHat) + (startPosition).ToString()].Value = item;
                    startNumColumIndexHat++;
                    lastColumIndexHat = startNumColumIndexHat - 1;
                }
            }
            else
            {
                lastColumIndexHat = startNumColumIndexHat - 2;
                cells["M" + startPosition].Value = "";
            }

            cells["A" + (startPosition).ToString() + ":" + ColumNameByIndex(lastColumIndexHat) + (startPosition).ToString()].Borders.LineStyle = LineStyle.Continous;

            cells["A" + captionPosition + ":" + ColumNameByIndex(lastColumIndexHat) + captionPosition].Merge();
            cells["A" + captionPosition].Value = "Відомість основних засобів по групам" + (Zero ? " (замортизовано)" : "");
            cells["A" + (captionPosition + 1) + ":" + ColumNameByIndex(lastColumIndexHat) + (captionPosition + 1)].Merge();
            cells["A" + (captionPosition + 1)].Value = "за період з " + startDate + " по " + endDate;
            cells["A" + (startPosition).ToString() + ":" + ColumNameByIndex(lastColumIndexHat) + (startPosition)].AutoFilter(1, null, AutoFilterOperator.Or, null, true);

            for (int i = 0; i < reportFixedAssetsInventoryTable.Rows.Count; i++)
            {
                if (activGroup != reportFixedAssetsInventoryTable.Rows[i]["GROUPNAME"].ToString())
                {
                    //Sum
                    if (i != 0)
                    {
                        WriteHatSum(cells, currentPosition, rowsStartGroup, lastColumIndexHat, ColumNameAsFAM_NUM);
                        currentPosition++;
                    }
                    activGroup = reportFixedAssetsInventoryTable.Rows[i]["GROUPNAME"].ToString();


                    //Group
                    rowsStartGroup = currentPosition;
                    cells["A" + currentPosition].Value = "Группа: " + reportFixedAssetsInventoryTable.Rows[i]["FAO_NUM"] + " " + reportFixedAssetsInventoryTable.Rows[i]["GROUPNAME"];
                    cells["A" + currentPosition + ":" + "M" + currentPosition].Merge();
                    cells["A" + currentPosition.ToString() + ":" + "H" + currentPosition.ToString()].Font.Bold = true;
                    currentPosition++;
                }
                cells["A" + currentPosition].Value = n;
                cells["B" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["FAO_NUM"];
                cells["C" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["BEGINDATE"];
                cells["D" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["SUPPLIER_NAME"];
                cells["E" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["REGIONNAME"];
                cells["F" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["INVENTORYNUMBER"];
                cells["G" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["INVENTORYNAME"];
                //    SUPPLIER_NAME

                cells["H" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["BEGINPRICE"];
                cells["H" + currentPosition].NumberFormat = "### ### ##0.00";

                cells["I" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["INCREASEPRICE"];
                cells["I" + currentPosition].NumberFormat = "### ### ##0.00";

                cells["J" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["TOTALPRICE"];
                cells["J" + currentPosition].NumberFormat = "### ### ##0.00";

                cells["K" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["CURRENTPRICE"];
                cells["K" + currentPosition].NumberFormat = "### ### ##0.00";
                if (!Zero)
                {
                    cells["L" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["PERIODAMORTIZATION"];
                    cells["L" + currentPosition].NumberFormat = "### ### ##0.00";

                    cells["M" + currentPosition].Value = reportFixedAssetsInventoryTable.Rows[i]["PERIODYEARAMORTIZATION"];
                    cells["M" + currentPosition].NumberFormat = "### ### ##0.00";

                    string columName = ColumNameAsFAM_NUM.First((x) => x.Value == reportFixedAssetsInventoryTable.Rows[i]["FAM_NUM"].ToString()).Key;
                    cells[columName + currentPosition].Value = (!Zero) && (reportFixedAssetsInventoryTable.Rows[i]["PERIODYEARAMORTIZATION"].ToString() != "0") ? reportFixedAssetsInventoryTable.Rows[i]["CURRENTAMORTIZATION"] : "0";//cells["J" + currentPosition].Value;
                    cells[columName + currentPosition].NumberFormat = "### ### ##0.00";
                }
                currentPosition++;
                n++;
            }
            WriteHatSum(cells, currentPosition, rowsStartGroup, lastColumIndexHat, ColumNameAsFAM_NUM);
            currentPosition++;
            WriteHatGlobalSum(cells, currentPosition, rowsStartGroup, lastColumIndexHat, ColumNameAsFAM_NUM);

            cells["A" + startPosition + ":" + ColumNameByIndex(lastColumIndexHat) + (currentPosition).ToString()].Borders.LineStyle = LineStyle.Continous;
            cells["A" + (startPosition - 2) + ":" + ColumNameByIndex(lastColumIndexHat) + (currentPosition).ToString()].Font.Size = 12;
            cells["A" + (startPosition - 2) + ":" + ColumNameByIndex(lastColumIndexHat) + (startPosition).ToString()].Font.Bold = true;
            // cells["A" + startPosition + ":" + "G" + (currentPosition - 1).ToString()].Interior.Color = Color.Bisque;

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Відомість основних засобів по групам" + Convert.ToDateTime(startDate).Month + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Відомість основних засобів по групам" + Convert.ToDateTime(startDate).Month + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void FixedAssetsReportGroupShort(DataTable SourseDataTable, string startDate, string endDate)
        {
            if (SourseDataTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "FixedAssetsByGroupShort.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;
            String activBalance_Account_Num = String.Empty;
            String activGroupName = String.Empty;

            Dictionary<String, String> mumIndex = new Dictionary<String, String>();
            mumIndex.Add(vsS[1],"18");//23
            mumIndex.Add(vsS[2],"19");//91
            mumIndex.Add(vsS[3],"21");//92
            mumIndex.Add(vsS[4],"23");//93

            StringBuilder sumB = new StringBuilder("=SUM(");
            StringBuilder sumC = new StringBuilder("=SUM(");
            StringBuilder sumD = new StringBuilder("=SUM(");
            StringBuilder sumE = new StringBuilder("=SUM(");
            StringBuilder sumF = new StringBuilder("=SUM(");

            int captionPosition = 6;
            int startRow = captionPosition + 3;
            int activRow = startRow;
            String sumColIndex = "F";

            Action<int> WriteSum = (sendActivRow) =>
            {
                cells[String.Format("{0}{1}", sumColIndex, sendActivRow)].NumberFormat = "### ### ##0.00";
                cells[String.Format("{0}{1}", sumColIndex, sendActivRow)].Value = "=SUM(B" + sendActivRow + ":E" + sendActivRow + ")";
            };

            Action<int,int,int,string,Boolean,Boolean> WriteColumSum = (sendActivRow, sendStartActivSumRowIndex, sendEndActivSumRowIndex,numName,isLastSum,isNotGlobalSum) =>
            {
                string activColumName = "B";
                string activAdressName = string.Empty;
                //A
                activColumName = "A";
                cells[String.Format("{0}{1}", activColumName, sendActivRow)].Value = isNotGlobalSum ? String.Format("{0} по рахунку {1}", "Всього", numName) : "Всього";
                cells[String.Format("{1}{0}:{2}{0}", sendActivRow, activColumName, "F")].Interior.Color = isNotGlobalSum ? Color.LightGreen : Color.Silver;
                //cells[String.Format("{1}{0}:{2}{0}", sendActivRow, activColumName, "F")].Font.Bold = true;
                //B
                activColumName = "B";
                activAdressName = String.Format("{0}{1}", activColumName, sendActivRow);
                cells[activAdressName].Value = isNotGlobalSum ? String.Format("=SUM({0}{1}:{0}{2})", activColumName, sendStartActivSumRowIndex, sendEndActivSumRowIndex) : sumB.ToString();
                cells[activAdressName].NumberFormat = "### ### ##0.00";
                //cells[activAdressName].Font.Bold = true;
                sumB.Append(String.Format("{0}{1}", activAdressName,isLastSum?")":"+"));
                //C
                activColumName = "C";
                activAdressName =String.Format("{0}{1}", activColumName, sendActivRow);
                cells[activAdressName].Value =isNotGlobalSum ? String.Format("=SUM({0}{1}:{0}{2})", activColumName, sendStartActivSumRowIndex, sendEndActivSumRowIndex): sumC.ToString();
                cells[activAdressName].NumberFormat = "### ### ##0.00";
                //cells[activAdressName].Font.Bold = true;
                sumC.Append(String.Format("{0}{1}", activAdressName, isLastSum ? ")" : "+"));
                //D
                activColumName = "D";
                activAdressName =String.Format("{0}{1}", activColumName, sendActivRow);
                cells[activAdressName].Value =isNotGlobalSum ? String.Format("=SUM({0}{1}:{0}{2})", activColumName, sendStartActivSumRowIndex, sendEndActivSumRowIndex): sumD.ToString();
                cells[activAdressName].NumberFormat = "### ### ##0.00";
                //cells[activAdressName].Font.Bold = true;
                sumD.Append(String.Format("{0}{1}", activAdressName, isLastSum ? ")" : "+"));
                //E
                activColumName = "E";
                activAdressName =String.Format("{0}{1}", activColumName, sendActivRow);
                cells[activAdressName].Value =isNotGlobalSum ? String.Format("=SUM({0}{1}:{0}{2})", activColumName, sendStartActivSumRowIndex, sendEndActivSumRowIndex): sumE.ToString();
                cells[activAdressName].NumberFormat = "### ### ##0.00";
                //cells[activAdressName].Font.Bold = true;
                sumE.Append(String.Format("{0}{1}", activAdressName, isLastSum ? ")" : "+"));
                //F
                activColumName = "F";
                activAdressName =String.Format("{0}{1}", activColumName, sendActivRow);
                cells[activAdressName].Value = isNotGlobalSum ? String.Format("=SUM({0}{1}:{0}{2})", activColumName, sendStartActivSumRowIndex, sendEndActivSumRowIndex) : sumF.ToString();
                cells[activAdressName].NumberFormat = "### ### ##0.00";
                //cells[activAdressName].Font.Bold = true;
                sumF.Append(String.Format("{0}{1}", activAdressName, isLastSum ? ")" : "+"));
            };

            var activAdressRange = String.Format("A" + captionPosition + ":{0}" + captionPosition, sumColIndex);
            cells[activAdressRange].Merge();
            cells["A" + captionPosition].Value = "Відомість основних засобів по групам (скорочено)";
            cells[activAdressRange].Font.Bold = true;
            cells[activAdressRange].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
            cells[activAdressRange].VerticalAlignment = SpreadsheetGear.VAlign.Center;

            activAdressRange = String.Format("A" + (captionPosition + 1) + ":{0}" + (captionPosition + 1), sumColIndex);
            cells[activAdressRange].Merge();
            cells["A" + (captionPosition + 1)].Value = "за період з " + startDate + " по " + endDate;
            cells[activAdressRange].Font.Bold = true;
            cells[activAdressRange].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
            cells[activAdressRange].VerticalAlignment = SpreadsheetGear.VAlign.Center;

            int startActivSumRowIndex = -1;
            int endActivSumRowIndex = -1;

            activRow--;
            foreach (DataRow line in SourseDataTable.Rows)
            {
                if (String.Compare(activGroupName, line["Name"].ToString(), true) != 0)
                {
                    if (String.Compare(activGroupName, String.Empty, true) != 0)
                    {
                        WriteSum(activRow);
                    }

                    if (String.Compare(activBalance_Account_Num, line["Num"].ToString(), true) != 0)
                    {
                        if (String.Compare(activBalance_Account_Num, String.Empty, true) != 0)
                        {
                            activRow++;
                            endActivSumRowIndex = activRow-1;
                            WriteColumSum(activRow, startActivSumRowIndex, endActivSumRowIndex, activBalance_Account_Num,false,true);
                        }
                        startActivSumRowIndex = activRow+1; 
                        activGroupName = String.Empty;
                        activBalance_Account_Num = line["Num"].ToString();
                       
                    }
                    activRow++;
                    activGroupName = line["Name"].ToString();
                }
                

                cells[String.Format("{0}{1}", "A", activRow)].Value = line["Name"];

                var columName = mumIndex.FirstOrDefault(X => String.Compare(X.Value, line["Fixed_Account_Id"].ToString(), true) == 0).Key;
                if (columName != null)
                {
                    cells[String.Format("{0}{1}", columName, activRow)].Value = line["PeriodAmortization"];
                    cells[String.Format("{0}{1}", columName, activRow)].NumberFormat = "### ### ##0.00";
                }
            }
            WriteSum(activRow);
            endActivSumRowIndex = activRow;
            activRow++;
            WriteColumSum(activRow, startActivSumRowIndex, endActivSumRowIndex, activBalance_Account_Num,true,true);
            //Global ROW sum
            activRow++;
            WriteColumSum(activRow, startActivSumRowIndex, endActivSumRowIndex, activBalance_Account_Num, true, false);

            PrintSignatures(cells, activRow + 3);

            cells["A" + startRow + ":" + sumColIndex + activRow].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startRow + ":" + sumColIndex + activRow].Font.Size = 12;
            //cells["A" + startRow + ":" + "F" + activRow].Font.Bold = true;
            //cells["A" + startRow + ":" + "F" + activRow].Interior.Color = Color.Bisque;
            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Відомість ОЗ по групам (скорочено)" + "за період з " + startDate + " по " + endDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Відомість ОЗ по групам (скорочено)" + "за період з " + startDate + " по " + endDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void InvoicesForFixedAssets(DataTable SourseDataTable, string startDate, string endDate)
        {
            if (SourseDataTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "InvoicesForFixedAssets.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;

            //Var
            int captionPosition = 7;
            int startRowIndex = captionPosition + 2;
            int activRowIndex = startRowIndex + 1;
            int sumColIndex = 16;
            string nameLastCol = vsS[sumColIndex - 1];

            //Head
            var activAdressRange = String.Format("A" + captionPosition + ":{0}" + captionPosition, nameLastCol);
            cells[activAdressRange].Merge();
            cells["A" + captionPosition].Value = "Відомість основних засобів у вимогах";
            cells[activAdressRange].Font.Bold = true;
            cells[activAdressRange].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
            cells[activAdressRange].VerticalAlignment = SpreadsheetGear.VAlign.Center;

            activAdressRange = String.Format("A" + (captionPosition + 1) + ":{0}" + (captionPosition + 1), nameLastCol);
            cells[activAdressRange].Merge();
            cells["A" + (captionPosition + 1)].Value = "за період з " + startDate + " по " + endDate;
            cells[activAdressRange].Font.Bold = true;
            cells[activAdressRange].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
            cells[activAdressRange].VerticalAlignment = SpreadsheetGear.VAlign.Center;

            //Body
            foreach (DataRow line in SourseDataTable.Rows)
            {
                activRowIndex++;

                cells[String.Format("{0}{1}", vsS[0], activRowIndex)].Value = line["InventoryNumber"];
                cells[String.Format("{0}{1}", vsS[1], activRowIndex)].Value = line["InventoryName"];
                cells[String.Format("{0}{1}", vsS[2], activRowIndex)].Value = line["GROUP_NAME"];
                cells[String.Format("{0}{1}", vsS[3], activRowIndex)].Value = line["SUPPLIER_FIA"];
                cells[String.Format("{0}{1}", vsS[4], activRowIndex)].Value = line["Description"];
                cells[String.Format("{0}{1}", vsS[5], activRowIndex)].Value = line["RECEIPT_NUM"];
                cells[String.Format("{0}{1}", vsS[6], activRowIndex)].Value = line["NOMENCLATURE"];
                cells[String.Format("{0}{1}", vsS[7], activRowIndex)].Value = line["NOMENCLATURE_NAME"];
                cells[String.Format("{0}{1}", vsS[8], activRowIndex)].Value = line["BALANCE_ACCOUNT"];
                cells[String.Format("{0}{1}", vsS[9], activRowIndex)].NumberFormat = "@";
                cells[String.Format("{0}{1}", vsS[9], activRowIndex)].Value = line["Number"];
                cells[String.Format("{0}{1}", vsS[10], activRowIndex)].Value = line["Date"];
                cells[String.Format("{0}{1}", vsS[11], activRowIndex)].Value = line["SUPPLIER_IRO"];
                cells[String.Format("{0}{1}", vsS[12], activRowIndex)].Value = line["QUANTITY"];
                cells[String.Format("{0}{1}", vsS[13], activRowIndex)].Value = line["UNIT_PRICE"];
                cells[String.Format("{0}{1}", vsS[13], activRowIndex)].NumberFormat = "### ### ##0.00";
                cells[String.Format("{0}{1}", vsS[14], activRowIndex)].Value = line["TOTAL_PRICE"];
                cells[String.Format("{0}{1}", vsS[14], activRowIndex)].NumberFormat = "### ### ##0.00";
                cells[String.Format("{0}{1}", vsS[15], activRowIndex)].Value = line["CREDIT_ACCOUNT"];
            }

            PrintSignatures(cells, activRowIndex + 3);

            cells[String.Format("A{0}:{1}{2}", startRowIndex, nameLastCol, activRowIndex)].Borders.LineStyle = LineStyle.Continous;
            cells[String.Format("A{0}:{1}{2}", startRowIndex, nameLastCol, activRowIndex)].Font.Size = 12;

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Відомість ОЗ у вимогах за період з " + startDate + " по " + endDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Відомість ОЗ у вимогах за період з " + startDate + " по " + endDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void FixedAssetsOrderAct(DataRowView SourseData)
        {

            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(TemplatesDir + "FixedAssetsOrderAct.xls");
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            int rows = 120;
            int cols = 31;
            DateTime dt = DateTime.Now;

            cells[1, 1, rows, cols].Replace("{currYear}", dt.Year.ToString(), LookAt.Part, SearchOrder.ByRows, false);

            if (DataModule.AccountingDS.Tables["FixedAssetsMaterials"].Rows.Count > 0)
            {
                DataTable currTable = DataModule.AccountingDS.Tables["FixedAssetsMaterials"].AsEnumerable().Where(x => x.Field<short>("Flag") < 2).CopyToDataTable();
                decimal sumPrice = Math.Round(currTable.AsEnumerable().Where(r => r.Field<short>("Flag") < 2).Select(s => s.Field<decimal>("FixedPrice")).Sum(), 2);

                cells["M32"].Value = SourseData["InventoryName"].ToString() + "   ";
                cells["O27"].Value = SourseData["InventoryNumber"];
                cells["D27"].Value = SourseData["Balance_Account_Num"];
                cells["R27"].Value = SourseData["Fixed_Account_Num"];
                cells["N27"].Value = sumPrice;
                cells["N27"].NumberFormat = "### ### ##0.00";
                cells["C27"].Value = SourseData["Region_Name"];
                
                int materialRows = 44;
                int count = currTable.Rows.Count;
                cells[materialRows + ":" + (materialRows + count)].Insert();
                cells["A43:AC43"].Copy(cells["A" + materialRows + ":AC" + (materialRows + count - 1)], PasteType.Formats, PasteOperation.None, false, false);

                foreach (var item in currTable.AsEnumerable())
                {
                    cells["B" + materialRows].Value = item.Field<string>("NAME");
                    cells["G" + materialRows].Value = item.Field<string>("NOMENCLATURE");
                    cells["M" + materialRows].Value = "";
                    cells["Q" + materialRows].NumberFormat = "YYYY";
                    cells["Q" + materialRows].Value = item.Field<DateTime>("EXP_DATE");
                    cells["T" + materialRows].NumberFormat = "MM.YYYY";
                    cells["T" + materialRows].Value = item.Field<DateTime>("EXP_DATE");
                    cells["Y" + materialRows].Value = "";
                    cells["B" + materialRows].RowHeight = 30;
                    materialRows++;
                };

            }
         
            try
            {
                worksheet.SaveAs(GeneratedReportsDir + "Акт приема-передачи инв.№" + SourseData["InventoryNumber"].ToString().Replace("/", "_") + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Акт приема-передачи инв.№" + SourseData["InventoryNumber"].ToString().Replace("/", "_") + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        
        }


        public void FixedAssetsOrderActWriteOff(DataRowView SourseData, Utils.FixedAssetsGroup group)
        {

            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(TemplatesDir + "FixedAssetsAddedPriceTemplate.xls");
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            int rows = 120;
            int cols = 31;
            DateTime dt = DateTime.Now;

            if (DataModule.AccountingDS.Tables["FixedAssetsMaterials"].Rows.Count > 0)
            {
                DataTable currTable = DataModule.AccountingDS.Tables["FixedAssetsMaterials"].AsEnumerable().Where(x => x.Field<short>("Flag") == 1).CopyToDataTable();
                decimal sumPrice = Math.Round(currTable.AsEnumerable().Where(r => r.Field<short>("Flag") == 1).Select(s => s.Field<decimal>("FixedPrice")).Sum(), 2);


                int materialRows = 21;
                

                foreach (var item in currTable.AsEnumerable())
                {
                    cells["" + materialRows + ":" + materialRows].Insert();

                    cells["A" + materialRows].HorizontalAlignment = HAlign.Left;
                    cells["A" + materialRows + ":" + "B" + materialRows].Merge();
                    cells["A" + materialRows].Value = SourseData["Region_Name"];

                    cells["C" + materialRows + ":" + "D" + materialRows].Merge();
                    cells["C" + materialRows].Value = SourseData["Balance_Account_Num"];

                    if(group == Utils.FixedAssetsGroup.General)
                        cells["G" + materialRows].Value = "152";
                    else
                        cells["G" + materialRows].Value = "154";

                    cells["K" + materialRows + ":" + "L" + materialRows].Merge();
                    cells["K" + materialRows].Value = item.Field<decimal>("TOTAL_PRICE");

                    cells["M" + materialRows].Value = SourseData["InventoryNumber"];
                    materialRows++;
                };

            }

            try
            {
                worksheet.SaveAs(GeneratedReportsDir + "Акт списання-здачі відремонтованих, реконструйований та модернізованих об'єктів " + SourseData["InventoryNumber"].ToString().Replace("/", "_") + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Акт списання-здачі відремонтованих, реконструйований та модернізованих об'єктів " + SourseData["InventoryNumber"].ToString().Replace("/", "_") + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        public void FixedAssetsOrderActForSoftWare(DataRowView SourseData)
        {
            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(TemplatesDir + "FixedAssetsOrderActForSoftware.xls");
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            decimal yearAmortization = Math.Round(((decimal)SourseData["BeginPrice"] / (short)SourseData["UsefulMonth"]) * 12, 2);

            int rows = 100;
            int cols = 30;
            DateTime dt = DateTime.Now;

            cells[0, 0, rows, cols].Replace("{currYear}", dt.Year.ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currInventoryName}", SourseData["InventoryName"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currInventoryNumber}", SourseData["InventoryNumber"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currBeginDate}", Convert.ToDateTime(SourseData["BeginDate"]).ToShortDateString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currSupplier_Name}", SourseData["Supplier_Name"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currUsefulMonth}", SourseData["UsefulMonth"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currBalance_Account_Num}", SourseData["Balance_Account_Num"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currBeginPrice}", SourseData["BeginPrice"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currAmortizationYearPrice}", yearAmortization.ToString(), LookAt.Part, SearchOrder.ByRows, false);
            
            try
            {
                worksheet.SaveAs(GeneratedReportsDir + "FixedAssetsOrderActForSoftware.xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "FixedAssetsOrderActForSoftware.xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void FixedAssetsRegisterCh1(DataTable SourseDataTable, string startDate, string endDate)
        {
            if (SourseDataTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "FixedAssetsRegisterCh1.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;

            var containsList = new List<int> { 2, 10 }; // разделяем амортизацию 

            var dataIncludePO = (from data in SourseDataTable.AsEnumerable()
                                 where !containsList.Contains(data.Field<Int16>("ID"))
                                 group data by data.Field<string>("FAM_NUM") into grdata
                                 select new
                                 {
                                     FAM_NUM = grdata.Key,
                                     CURRENTAMORTIZATIONFORPERIOD = grdata.Sum(o => o.Field<Decimal>("CURRENTAMORTIZATIONFORPERIOD"))
                                 }).ToList();

            var dataOnly133 = (from data in SourseDataTable.AsEnumerable()
                               where containsList.Contains(data.Field<Int16>("ID"))
                               group data by data.Field<string>("FAM_NUM") into grdata
                               select new
                               {
                                   FAM_NUM = grdata.Key,
                                   CURRENTAMORTIZATIONFORPERIOD = grdata.Sum(o => o.Field<Decimal>("CURRENTAMORTIZATIONFORPERIOD"))
                               }).ToList();

            //var dataOnly132 = (from data in SourseDataTable.AsEnumerable()
            //                  where data.Field<Int16>("ID") == 10
            //                  select new
            //                  {
            //                      FAM_NUM = data.Field<string>("FAM_NUM"),
            //                      CURRENTAMORTIZATIONFORPERIOD = data.Field<Decimal>("CURRENTAMORTIZATIONFORPERIOD")
            //                  }).ToList();
            
            Dictionary<string, int> listSNumToIIndexRow = new Dictionary<string, int>();
            listSNumToIIndexRow.Add("13", 16);
            listSNumToIIndexRow.Add("14", 17);
            listSNumToIIndexRow.Add("15", 18);
            listSNumToIIndexRow.Add("23", 19);
            listSNumToIIndexRow.Add("37", 20);
            listSNumToIIndexRow.Add("39", 21);
            listSNumToIIndexRow.Add("42", 22);
            listSNumToIIndexRow.Add("68", 23);
            listSNumToIIndexRow.Add("83", 24);
            listSNumToIIndexRow.Add("84", 25);
            listSNumToIIndexRow.Add("85", 26);
            listSNumToIIndexRow.Add("91", 27);
            listSNumToIIndexRow.Add("92", 28);
            listSNumToIIndexRow.Add("93", 29);
            listSNumToIIndexRow.Add("94", 30);
            listSNumToIIndexRow.Add("97", 31);
            listSNumToIIndexRow.Add("99", 32);


            // Dictionary<string, string> listSNumToSIndexColum = new Dictionary<string, string>();
            //listSNumToSIndexColum.Add("10", "C");
            //listSNumToSIndexColum.Add("11", "D");
            //listSNumToSIndexColum.Add("131", "E");
            //listSNumToSIndexColum.Add("132", "F");
            //listSNumToSIndexColum.Add("133", "G");
            
            foreach (var item in dataIncludePO)
            {
                //cells["C27"].Value = SourseDataTable.Rows[i]["FAO_NUM"];//104
                //cells["C27"].Value = SourseDataTable.Rows[i]["FAM_NUM"];//23
                //var indexColum = listSNumToSIndexColum.First(X => SourseDataTable.Rows[i]["FAO_NUM"].ToString().IndexOf(X.Key) == 0).Value;
                try
                {
                    var indexRow = listSNumToIIndexRow.First(X => X.Key == item.FAM_NUM.ToString()).Value;
                    cells["E" + indexRow].NumberFormat = "### ### ##0.00";
                    cells["E" + indexRow].Value = item.CURRENTAMORTIZATIONFORPERIOD;
                }
                catch (InvalidOperationException)
                {
                }
            }

            //foreach (var item in dataOnly132)
            //{
            //    //cells["C27"].Value = SourseDataTable.Rows[i]["FAO_NUM"];//104
            //    //cells["C27"].Value = SourseDataTable.Rows[i]["FAM_NUM"];//23
            //    //var indexColum = listSNumToSIndexColum.First(X => SourseDataTable.Rows[i]["FAO_NUM"].ToString().IndexOf(X.Key) == 0).Value;
            //    try
            //    {
            //        var indexRow = listSNumToIIndexRow.First(X => X.Key == item.FAM_NUM.ToString()).Value;
            //        cells["F" + indexRow].NumberFormat = "### ### ##0.00";
            //        cells["F" + indexRow].Value = item.CURRENTAMORTIZATIONFORPERIOD;
            //    }
            //    catch (InvalidOperationException)
            //    {
            //    }
            //}

            foreach (var item in dataOnly133)
            {
                //cells["C27"].Value = SourseDataTable.Rows[i]["FAO_NUM"];//104
                //cells["C27"].Value = SourseDataTable.Rows[i]["FAM_NUM"];//23
                //var indexColum = listSNumToSIndexColum.First(X => SourseDataTable.Rows[i]["FAO_NUM"].ToString().IndexOf(X.Key) == 0).Value;
                try
                {
                    var indexRow = listSNumToIIndexRow.First(X => X.Key == item.FAM_NUM.ToString()).Value;
                    cells["G" + indexRow].NumberFormat = "### ### ##0.00";
                    cells["G" + indexRow].Value = item.CURRENTAMORTIZATIONFORPERIOD;
                }
                catch (InvalidOperationException)
                {
                }
            }


            try
            {
                Workbook.SaveAs(GeneratedReportsDir + String.Format("Журнал №4 ч.1 з {0} по {1} ", startDate, endDate) + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + String.Format("Журнал №4 ч.1 з {0} по {1} ", startDate, endDate) + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        public void FixedAssetsRegisterCh2(DataTable SourseDataTable, string startDate, string endDate)
        {
            if (SourseDataTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "FixedAssetsRegisterCh2.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;

            Dictionary<int, int> listITableFAGroupIdToIIndexRow = new Dictionary<int, int>();
            //listITableFAGroupIdToIIndexRow.Add(,8);//10
            listITableFAGroupIdToIIndexRow.Add(3,12);//103 "Будівлі"
            listITableFAGroupIdToIIndexRow.Add(8, 13);//103 "Споруди"
            listITableFAGroupIdToIIndexRow.Add(1, 14);//103 "Передавальні пристрої"
            listITableFAGroupIdToIIndexRow.Add(4, 15);//104
            listITableFAGroupIdToIIndexRow.Add(5, 16);//104.1
            listITableFAGroupIdToIIndexRow.Add(6, 17);//105
            listITableFAGroupIdToIIndexRow.Add(7, 18);//106
            listITableFAGroupIdToIIndexRow.Add(9,19);//109
            listITableFAGroupIdToIIndexRow.Add(2,21);//112
            //listITableFAGroupIdToIIndexRow.Add(,17);//11
            //listITableFAGroupIdToIIndexRow.Add(,19);//14
            //listITableFAGroupIdToIIndexRow.Add(,20);//18
            //listITableFAGroupIdToIIndexRow.Add(,21);//28
            //listITableFAGroupIdToIIndexRow.Add(,22);//30
            //listITableFAGroupIdToIIndexRow.Add(,23);//31
            //listITableFAGroupIdToIIndexRow.Add(,24);//35
            //listITableFAGroupIdToIIndexRow.Add(,25);//37
            //listITableFAGroupIdToIIndexRow.Add(,26);//42
            //listITableFAGroupIdToIIndexRow.Add(,27);//48
            //listITableFAGroupIdToIIndexRow.Add(,28);//50
            //listITableFAGroupIdToIIndexRow.Add(,29);//60
            //listITableFAGroupIdToIIndexRow.Add(,30);//64
            //listITableFAGroupIdToIIndexRow.Add(,31);//68
            //listITableFAGroupIdToIIndexRow.Add(,32);//84
            //listITableFAGroupIdToIIndexRow.Add(,33);//85
            //listITableFAGroupIdToIIndexRow.Add(,34);//96
            //listITableFAGroupIdToIIndexRow.Add(,35);//97
            //listITableFAGroupIdToIIndexRow.Add(,36);//99
            //listITableFAGroupIdToIIndexRow.Add(2,X);//127




            //Dictionary<string, string> listSNumToSIndexColum = new Dictionary<string, string>();
            //listSNumToSIndexColum.Add("151", "C");
            //listSNumToSIndexColum.Add("152", "D");
            //listSNumToSIndexColum.Add("153", "E");
            //listSNumToSIndexColum.Add("154", "F");


            for (int i = 0; i < SourseDataTable.Rows.Count; i++)
            {

                //cells["C27"].Value = SourseDataTable.Rows[i]["FAO_NUM"];//104
                //cells["C27"].Value = SourseDataTable.Rows[i]["FAM_NUM"];//23
                try
                {
                    var indexColum = "D";//listSNumToSIndexColum.First(X => SourseDataTable.Rows[i]["FAO_NUM"].ToString().IndexOf(X.Key) == 0).Value;
                    var indexRow = listITableFAGroupIdToIIndexRow.First(X => X.Key.ToString() == SourseDataTable.Rows[i]["GROUPID"].ToString()).Value;
                    cells[indexColum + indexRow].NumberFormat = "### ### ##0.00";
                    cells[indexColum + indexRow].Value = SourseDataTable.Rows[i]["FIXEDPRICE"];//
                }
                catch (InvalidOperationException)
                {
                }
            }
            
            try
            {
                Workbook.SaveAs(GeneratedReportsDir + String.Format("Журнал №4 ч.2 з {0} по {1} ", startDate, endDate) + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + String.Format("Журнал №4 ч.2 з {0} по {1} ", startDate, endDate) + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void FixedAssetsPrintItem(DataTable BaseDataTable, DateTime startDate, DateTime endDate)
        {
            DataTable SourseDataTable = BaseDataTable.AsEnumerable().OrderByDescending(r => r["Id"]).CopyToDataTable();

            if (SourseDataTable.Rows.Count == 0)
            {
                MessageBox.Show("За выбранный период нет данных!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "FixedAssetsPrintItem.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;

            Dictionary<String, DateTime> MonthPosotoin = new Dictionary<string, DateTime>();
            
            int startRow = 3;
            int indexRow = startRow + 1;
            string indexRowStr;
            DateTime _startDate = startDate;
            DateTime _endDate = endDate;

            if (_endDate < _startDate)
            {
                MessageBox.Show("Не верно указан период! Конечная дата не должна быть меньше начальной.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Head document
            cells["B2"].Value = "Карточка основного средства за период: c " + _startDate.ToString("dd.MM.yyyy") + " по " + _endDate.ToString("dd.MM.yyyy");
            cells["B2"].Font.Size = 14;
            cells["B2"].Font.Bold = true;
            cells["B2"].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
            cells["B2"].VerticalAlignment = SpreadsheetGear.VAlign.Center;
            cells["B2:" + "P2"].Merge();

            //Head table1
            indexRowStr = indexRow.ToString();
            //ColumnWidth
            Worksheet.Cells["B:B"].ColumnWidth = 12.47;
            Worksheet.Cells["C:C"].ColumnWidth = 32.9;
            Worksheet.Cells["D:D"].ColumnWidth = 16.19;
            Worksheet.Cells["E:E"].ColumnWidth = 26.19;
            Worksheet.Cells["F:F"].ColumnWidth = 14.86;
            Worksheet.Cells["G:G"].ColumnWidth = 13.04;
            Worksheet.Cells["H:H"].ColumnWidth = 11.43;
            Worksheet.Cells["I:I"].ColumnWidth = 25.43;
           
            Worksheet.Cells["J:J"].ColumnWidth = 16.14;
            Worksheet.Cells["K:K"].ColumnWidth = 12.33;
            Worksheet.Cells["L:L"].ColumnWidth = 13.9;
            Worksheet.Cells["M:M"].ColumnWidth = 14.04;
            Worksheet.Cells["N:N"].ColumnWidth = 24.43;
            Worksheet.Cells["O:O"].ColumnWidth = 24.43;
            Worksheet.Cells["P:P"].ColumnWidth = 12.33;
            int rowcount=SourseDataTable.Rows.Count;

            for (int x = 0; x < rowcount; x++)
			{
                if (x == 1)
                {
                    cells["B" + indexRowStr].Value = "Архив";
                    cells["B" + indexRowStr].Font.Size = 14;
                    cells["B" + indexRowStr].Font.Bold = true;
                }
                    indexRow++;
                    indexRowStr = indexRow.ToString();
           
		    
             //TITLE
            cells["B" + indexRowStr].Value = "Инвентарный номер";
            cells["C" + indexRowStr].Value = "Наименование";
            cells["D" + indexRowStr].Value = "Счет учета";
            cells["E" + indexRowStr].Value = "Ответственное лицо";

            cells["F" + indexRowStr].Value = "Срок использования (мес.)";
            cells["G" + indexRowStr].Value = "Дата принятия к учету";
            cells["H" + indexRowStr].Value = "Дата снятия с учета";
            cells["I" + indexRowStr].Value = "Группа";

            cells["J" + indexRowStr].Value = "Первоначальная стоимость";
            cells["K" + indexRowStr].Value = "Увеличение стоимости";
            cells["L" + indexRowStr].Value = "Текущая стоимость";
            cells["M" + indexRowStr].Value = "Остаточная стоимость";
            cells["N" + indexRowStr].Value = "Сумма амортизации";
            cells["O" + indexRowStr].Value = "Амортизация за месяц";
                       
            //body table 1
            indexRow++;
            indexRowStr = indexRow.ToString();
            cells["B" + indexRowStr].Value = SourseDataTable.Rows[x]["InventoryNumber"];
            cells["C" + indexRowStr].Value = SourseDataTable.Rows[x]["InventoryName"];
            cells["D" + indexRowStr].Value = SourseDataTable.Rows[x]["BALANCE_ACCOUNT_NUM"];
            cells["E" + indexRowStr].Value = SourseDataTable.Rows[x]["SUPPLIER_NAME"];

            cells["F" + indexRowStr].Value = SourseDataTable.Rows[x]["UsefulMonth"];
            cells["G" + indexRowStr].Value = SourseDataTable.Rows[x]["BeginDate"];
            cells["H" + indexRowStr].Value = SourseDataTable.Rows[x]["EndRecordDate"];
            cells["I" + indexRowStr].Value = SourseDataTable.Rows[x]["GROUP_NAME"];

            
            cells["J" + indexRowStr].Value = SourseDataTable.Rows[x]["BEGINPRICE"];
            cells["K" + indexRowStr].Value = SourseDataTable.Rows[x]["INCREASEPRICE"];
            cells["L" + indexRowStr].Value = SourseDataTable.Rows[x]["TOTALPRICE"];
            cells["M" + indexRowStr].Value = SourseDataTable.Rows[x]["CURRENTPRICE"];
            cells["N" + indexRowStr].Value = SourseDataTable.Rows[x]["PERIODAMORTIZATION"];
            cells["O" + indexRowStr].Value = SourseDataTable.Rows[x]["CURRENTAMORTIZATION"];

            cells["I" + indexRowStr + ":" + "J" + indexRowStr].NumberFormat = "### ### ##0.00";
            cells["L" + indexRowStr + ":" + "M" + indexRowStr].NumberFormat = "### ### ##0.00";
            
            DateTime tempDate = default(DateTime);
            int useMonth;
            Decimal beginPrice, monthAmortization;
            try
            {
                tempDate = (DateTime)SourseDataTable.Rows[x]["BeginDate"];
                useMonth = Convert.ToInt32(SourseDataTable.Rows[x]["UsefulMonth"]);
                beginPrice = (Decimal)SourseDataTable.Rows[x]["TOTALPRICE"];
            }
            catch
            {
                MessageBox.Show("Ошибка преобразования данных!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            monthAmortization = beginPrice / useMonth;
            foreach (var item in MonthPosotoin)
            {
                var KolMounth = (((item.Value.Year - tempDate.Year) * 12) + item.Value.Month - tempDate.Month);
                if ((KolMounth > 0) && (KolMounth <= useMonth))
                {
                    //cells[item.Key + indexRowStr].Value = Math.Round(monthAmortization * KolMounth, 2);
                    cells[item.Key + indexRowStr].Value = monthAmortization;
                }


            }

            // first row headtable
            cells["B" + (startRow + 1) + ":" + "P" + (startRow + 1)].WrapText = true;
            cells["B" + (startRow + 1) + ":" + "P" + (startRow + 1)].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
            cells["B" + (startRow + 1) + ":" + "P" + (startRow + 1)].VerticalAlignment = SpreadsheetGear.VAlign.Center;
            cells["B" + (startRow + 1) + ":" + "P" + indexRow].Borders.LineStyle = LineStyle.Continous;

            //table 2 read data
            FbParameter[] Parameters =
                        {
                            new FbParameter("Id", SourseDataTable.Rows[x]["Id"])
                        };

            var table2 = DataModule.ExecuteFill(DataModule.Queries["FixedAssetsPrintItemData"], Parameters);

            //Head table2
            indexRow++;
            startRow = indexRow++;
            indexRowStr = indexRow.ToString();
            cells["B" + indexRowStr].Value = "Ном. номер";
            cells["C" + indexRowStr].Value = "Наименование";
            cells["D" + indexRowStr].Value = "Счет начисления амортизации";
            cells["E" + indexRowStr].Value = "Номер прихода";
            cells["F" + indexRowStr].Value = "Дата прихода";
            cells["G" + indexRowStr].Value = "Балансовый счет";
            cells["H" + indexRowStr].Value = "Количество";
            cells["I" + indexRowStr].Value = "Цена";
            cells["J" + indexRowStr].Value = "Сумма";
            cells["K" + indexRowStr].Value = "Дата списания";
            cells["L" + indexRowStr].Value = "Сумма списания";
            cells["M" + indexRowStr].Value = "Сумма к учету";
            cells["N" + indexRowStr].Value = "Тип";
            
            //body table 2
            for (var i = 0; i < table2.Rows.Count; i++)
            {
                indexRow++;
                indexRowStr = indexRow.ToString();

                cells["B" + indexRowStr].Value = table2.Rows[i]["NOMENCLATURE"];
                cells["C" + indexRowStr].Value = table2.Rows[i]["NAME"];
                cells["D" + indexRowStr].Value = table2.Rows[i]["FIXED_NUM"];
                cells["E" + indexRowStr].Value = table2.Rows[i]["RECEIPT_NUM"];
                cells["F" + indexRowStr].Value = table2.Rows[i]["ORDER_DATE"];
                cells["G" + indexRowStr].Value = table2.Rows[i]["ORDER_NUM"];
                cells["H" + indexRowStr].Value = table2.Rows[i]["QUANTITY"];
                cells["I" + indexRowStr].Value = table2.Rows[i]["UNIT_PRICE"];
                cells["J" + indexRowStr].Value = table2.Rows[i]["TOTAL_PRICE"];
                cells["K" + indexRowStr].Value = table2.Rows[i]["EXP_DATE"];
                cells["L" + indexRowStr].Value = table2.Rows[i]["PRICE"];
                cells["M" + indexRowStr].Value = table2.Rows[i]["FixedPrice"];
                cells["N" + indexRowStr].Value = table2.Rows[i]["FlagNote"];
                               
                //Interval I->J
                cells["I" + indexRowStr + ":" + "J" + indexRowStr].NumberFormat = "### ### ##0.00";
                cells["L" + indexRowStr + ":" + "M" + indexRowStr].NumberFormat = "### ### ##0.00";
            }
            
            cells["B" + (startRow + 1) + ":" + "N" + (startRow + 1)].WrapText = true;
            cells["B" + (startRow + 1) + ":" + "N" + (startRow + 1)].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
            cells["B" + (startRow + 1) + ":" + "N" + (startRow + 1)].VerticalAlignment = SpreadsheetGear.VAlign.Center;
            cells["B" + (startRow + 1) + ":" + "N" + indexRow].Borders.LineStyle = LineStyle.Continous;
            indexRow = indexRow+2;
            startRow = startRow + table2.Rows.Count + 3;
            indexRowStr = indexRow.ToString();
            } 

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Карточка ОС " + SourseDataTable.Rows[0]["InventoryNumber"].ToString().Replace("/", "_") + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Карточка ОС " + SourseDataTable.Rows[0]["InventoryNumber"].ToString().Replace("/", "_") + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        
        public void InputFixedAssetsForGroup(DataTable reportTable, string beginDate, string endDate)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "InputFixedAssetsForGroup.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;

            int captionPosition = 7;
            int startGroupPosition = -100;
            int startPosition = captionPosition + 2;
            int currentPosition = startPosition;
            int n = 1;
            string activGroup = "";
            DateTime beginHeaderDate = Convert.ToDateTime(beginDate).AddDays(-1);
            DateTime endHeaderDate = Convert.ToDateTime(endDate);

            StringBuilder SumG = new StringBuilder("=");
            StringBuilder SumH = new StringBuilder("=");
            StringBuilder SumI = new StringBuilder("=");


            cells["D" + captionPosition + ":" + "H" + captionPosition].Merge();
            cells["D" + captionPosition].HorizontalAlignment = HAlign.Center;
            cells["D" + captionPosition].VerticalAlignment = VAlign.Center;
            cells["D" + captionPosition].Font.Bold = true;
            cells["D" + captionPosition].Value = "Введення основних засобів з " + beginHeaderDate.ToShortDateString() + " по " + endHeaderDate.ToShortDateString() + "(по групам)";
            cells["G" + (captionPosition + 1)].Value = cells["G" + (captionPosition + 1)].Value + beginHeaderDate.ToShortDateString();
            cells["H" + (captionPosition + 1)].Value = cells["H" + (captionPosition + 1)].Value + endHeaderDate.ToShortDateString();

            Action<int, int> EndSumWrite = (currentPos, startGroupPos) =>
            {
                cells["A" + currentPos + ":I" + currentPos].Borders.LineStyle = LineStyle.Continous;
                cells["A" + currentPos + ":I" + currentPos].Interior.Color = Color.LightGreen;
                cells["A" + currentPos + ":I" + currentPos].Font.Bold = true;

                cells["A" + currentPos].Value = "Всього:";
                cells["G" + currentPos].Value = "=SUM(G" + startGroupPos.ToString() + ":G" + (currentPos - 1).ToString() + ")";
                cells["H" + currentPos].Value = "=SUM(H" + startGroupPos.ToString() + ":H" + (currentPos - 1).ToString() + ")";
                cells["I" + currentPos].Value = "=SUM(I" + startGroupPos.ToString() + ":I" + (currentPos - 1).ToString() + ")";


                cells["G" + currentPosition + ":" + "I" + currentPosition].NumberFormat = "### ### ##0.00";

                //global sum add
                SumG.AppendFormat("+G{0}", currentPosition.ToString());
                SumH.AppendFormat("+H{0}", currentPosition.ToString());
                SumI.AppendFormat("+I{0}", currentPosition.ToString());
            };

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (activGroup != reportTable.Rows[i]["GROUP_ID"].ToString())
                {
                    if (startGroupPosition != -100)
                    {
                        EndSumWrite(currentPosition, startGroupPosition);
                        currentPosition++;
                    }
                    activGroup = reportTable.Rows[i]["GROUP_ID"].ToString();
                    //Group
                    cells["A" + currentPosition].Value = "Група: " + reportTable.Rows[i]["GROUPNAME"];
                    cells["A" + currentPosition + ":" + "I" + currentPosition].Merge();
                    cells["A" + currentPosition.ToString() + ":" + "I" + currentPosition.ToString()].Font.Bold = true;
                    currentPosition++;
                    startGroupPosition = currentPosition;
                }

                cells["A" + currentPosition].Value = n;
                cells["B" + currentPosition].Value = reportTable.Rows[i]["NUM"];
                cells["C" + currentPosition].Value = reportTable.Rows[i]["YEARSET"];
                cells["D" + currentPosition].Value = reportTable.Rows[i]["MONTHSET"];
                cells["E" + currentPosition].Value = reportTable.Rows[i]["INVENTORYNUMBER"];
                cells["E" + currentPosition].HorizontalAlignment = HAlign.Right;
                cells["F" + currentPosition].Value = reportTable.Rows[i]["INVENTORYNAME"];
                cells["G" + currentPosition].Value = reportTable.Rows[i]["FYEARPRICE"];
                cells["H" + currentPosition].Value = reportTable.Rows[i]["LYEARPRICE"];
                cells["I" + currentPosition].Value = reportTable.Rows[i]["DIFFERENCE"];
                cells["G" + currentPosition + ":" + "I" + currentPosition].NumberFormat = "### ### ##0.00";
                currentPosition++;
                n++;
            }
            EndSumWrite(currentPosition, startGroupPosition);
            currentPosition++;

            cells["A" + currentPosition].Value = "Сума:";
            cells["A" + currentPosition + ":" + "I" + currentPosition].Font.Bold = true;
            cells["G" + currentPosition].Value = SumG.ToString();
            cells["H" + currentPosition].Value = SumH.ToString();
            cells["I" + currentPosition].Value = SumI.ToString();
            cells["A" + currentPosition + ":" + "I" + currentPosition].NumberFormat = "### ### ##0.00";

            cells["A" + currentPosition + ":I" + currentPosition].Borders.LineStyle = LineStyle.Continous;
            cells["A" + currentPosition + ":I" + currentPosition].Interior.Color = Color.Silver;
            cells["A" + currentPosition + ":I" + currentPosition].Font.Bold = true;

            PrintSignatures(cells, currentPosition + 3);

            cells["A" + startPosition + ":I" + currentPosition].Borders.LineStyle = LineStyle.Continous;

            try
            {
                string documentAddresName = GeneratedReportsDir + "Введення основних засобів з " + beginHeaderDate.ToShortDateString() + " по " + endHeaderDate.ToShortDateString() + "(по групам).xls";
                Workbook.SaveAs(documentAddresName, FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + documentAddresName + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void InputFixedAssetsForQuarter(DataTable reportTable, string reportYear)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "InputFixedAssetsForQuarter.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;

            string headerValue = reportYear;
                                    
            Action<int, int, string> EndSumWrite = (currentRow, starRowFormula, accountValue) =>
            {
                cells["A" + currentRow].Value = "Всього: " + accountValue;
                cells["A" + currentRow].HorizontalAlignment = HAlign.Left;
                cells["A" + currentRow + ":J" + currentRow].Interior.Color = Color.DeepSkyBlue;
                cells["B" + currentRow].Value = "=SUM(B" + starRowFormula + ":B" + (currentRow - 1) + ")";
                cells["C" + currentRow].Value = "=SUM(C" + starRowFormula + ":C" + (currentRow - 1) + ")";
                cells["D" + currentRow].Value = "=SUM(D" + starRowFormula + ":D" + (currentRow - 1) + ")";
                cells["E" + currentRow].Value = "=SUM(E" + starRowFormula + ":E" + (currentRow - 1) + ")";
                cells["F" + currentRow].Value = "=SUM(F" + starRowFormula + ":F" + (currentRow - 1) + ")";
                cells["G" + currentRow].Value = "=SUM(G" + starRowFormula + ":G" + (currentRow - 1) + ")";
                cells["H" + currentRow].Value = "=SUM(H" + starRowFormula + ":H" + (currentRow - 1) + ")";
                cells["I" + currentRow].Value = "=SUM(I" + starRowFormula + ":I" + (currentRow - 1) + ")";

                cells["J" + currentRow].Value = "=SUM(B" + currentRow + ",D" + currentRow + ",F" + currentRow + ",H" + currentRow + ")";
            };

            int captionPosition = 6;
            int startPosition = captionPosition + 2;
            int currentPosition = startPosition;
            int startFormulaPosition = currentPosition;
            short currentAccountId = (short)reportTable.Rows[0]["Balance_Account_Id"];
            string currentAccountNum = (string)reportTable.Rows[0]["Balance_Account_Num"];

            cells["A" + captionPosition].Value = "Введення основних засобів у " + headerValue + "р.";

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (currentAccountId != (short)reportTable.Rows[i]["Balance_Account_Id"])
                {
                    //InsertLines(1);
                    EndSumWrite(currentPosition, startFormulaPosition, currentAccountNum);
                    currentAccountNum = (string)reportTable.Rows[i]["Balance_Account_Num"];
                    currentAccountId = (short)reportTable.Rows[i]["Balance_Account_Id"];
           
                    currentPosition++;
                    startFormulaPosition = currentPosition;
                }
                
                cells["A" + currentPosition].Value = reportTable.Rows[i]["Group_Name"];
                cells["B" + currentPosition].Value = reportTable.Rows[i]["FirstQuarterSum"];
                cells["C" + currentPosition].Value = reportTable.Rows[i]["FirstQuarterSum_Sold"];
                cells["D" + currentPosition].Value = reportTable.Rows[i]["SecondQuarterSum"];
                cells["E" + currentPosition].Value = reportTable.Rows[i]["SecondQuarterSum_Sold"];
                cells["F" + currentPosition].Value = reportTable.Rows[i]["ThirdQuarterSum"];
                cells["G" + currentPosition].Value = reportTable.Rows[i]["ThirdQuarterSum_Sold"];
                cells["H" + currentPosition].Value = reportTable.Rows[i]["FourthQuarterSum"];
                cells["I" + currentPosition].Value = reportTable.Rows[i]["FourthQuarterSum_Sold"];
                cells["J" + currentPosition].Value = "=SUM(B" + currentPosition + ",D" + currentPosition + ",F" + currentPosition + ",H" + currentPosition + ")";

                currentPosition++;
            }
                        
            EndSumWrite(currentPosition, startFormulaPosition, currentAccountNum);
            currentPosition++;

            cells["A" + currentPosition].Value = "Сума: ";
            cells["A" + currentPosition].HorizontalAlignment = HAlign.Left;
            cells["A" + currentPosition + ":J" + currentPosition].Interior.Color = Color.LightGreen;

            cells["B" + currentPosition].Value = reportTable.AsEnumerable().Sum(x => x.Field<decimal?>("FIrstQuarterSum"));
            cells["C" + currentPosition].Value = reportTable.AsEnumerable().Sum(x => x.Field<decimal?>("FIrstQuarterSum_Sold"));
            cells["D" + currentPosition].Value = reportTable.AsEnumerable().Sum(x => x.Field<decimal?>("SecondQuarterSum"));
            cells["E" + currentPosition].Value = reportTable.AsEnumerable().Sum(x => x.Field<decimal?>("SecondQuarterSum_Sold"));
            cells["F" + currentPosition].Value = reportTable.AsEnumerable().Sum(x => x.Field<decimal?>("ThirdQuarterSum"));
            cells["G" + currentPosition].Value = reportTable.AsEnumerable().Sum(x => x.Field<decimal?>("ThirdQuarterSum_Sold"));
            cells["H" + currentPosition].Value = reportTable.AsEnumerable().Sum(x => x.Field<decimal?>("FourthQuarterSum"));
            cells["I" + currentPosition].Value = reportTable.AsEnumerable().Sum(x => x.Field<decimal?>("FourthQuarterSum_Sold"));
            cells["J" + currentPosition].Value = "=SUM(B" + currentPosition + ",D" + currentPosition + ",F" + currentPosition + ",H" + currentPosition + ")";

            cells["A" + startPosition + ":J" + currentPosition].Borders.LineStyle = LineStyle.Continous;
            cells["B" + startPosition + ":J" + currentPosition].NumberFormat = "### ### ##0.00";

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                string documentAddresName = GeneratedReportsDir + "Введення основних засобів у " + headerValue + "р.xls";
                Workbook.SaveAs(documentAddresName, FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + documentAddresName + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void InventoryForFixedAssets(DataTable reportTable, DateTime reportDate)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SpreadsheetGear.IWorkbook workbook = Factory.GetWorkbook();
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            
            int currentPosition = 0;
            int startPosition = 2;

            #region FirstPage func
            Func<int, int> FirstPage = (currentRow) =>
                {
                    cells["A" + currentRow].Value = "ТОВ «Науково-виробнича Фірма «ТЕХВАГОНМАШ»";
                    cells["A" + currentRow + ":E" + currentRow].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["A" + (currentRow + 1) + ":E" + (currentRow + 1)].Merge();
                    cells["A" + (currentRow + 1) + ":E" + (currentRow + 1)].HorizontalAlignment = HAlign.Center;
                    cells["A" + (currentRow + 1)].Value = "(установа, органiзацiя)";
                    cells["A" + (currentRow + 2)].Value = "Iдентифiкацiйний код за ЄДРПОУ:";
                    cells["E" + (currentRow + 2)].Value = "32686844";
                    cells["E" + (currentRow + 2) + ":E" + (currentRow + 2)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["A" + (currentRow + 3) + ":B" + (currentRow + 3)].Merge();
                    cells["A" + (currentRow + 3) + ":B" + (currentRow + 3)].HorizontalAlignment = HAlign.Left;
                    cells["A" + (currentRow + 3)].Value = "м.Кременчук";
                    cells["A" + (currentRow + 4) + ":L" + (currentRow + 4)].Merge();
                    cells["A" + (currentRow + 4)].Value = "Iнвентарiзацiйний опис основних засобiв";
                    cells["A" + (currentRow + 4) + ":L" + (currentRow + 4)].Font.Bold = true;
                    cells["A" + (currentRow + 4) + ":L" + (currentRow + 4)].HorizontalAlignment = HAlign.Center;
                    cells["A" + (currentRow + 6) + ":C" + (currentRow + 6)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["A" + (currentRow + 7) + ":C" + (currentRow + 7)].Merge();
                    cells["A" + (currentRow + 7)].Value = "(дата складання)";
                    cells["A" + (currentRow + 7) + ":C" + (currentRow + 7)].HorizontalAlignment = HAlign.Center;
                    cells["A" + (currentRow + 9) + ":B" + (currentRow + 9)].Merge();
                    cells["A" + (currentRow + 9)].Value = "Основнi засоби";
                    cells["C" + (currentRow + 9) + ":L" + (currentRow + 9)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["A" + (currentRow + 10) + ":B" + (currentRow + 10)].Merge();
                    cells["A" + (currentRow + 10)].Value = "Мiсцезнаходження";
                    cells["C" + (currentRow + 10)].Value = "ТОВ «Науково-виробнича Фірма «ТЕХВАГОНМАШ»";
                    cells["C" + (currentRow + 10) + ":L" + (currentRow + 10)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["F" + (currentRow + 12) + ":H" + (currentRow + 12)].Merge();
                    cells["F" + (currentRow + 12)].Value = "Розписка";
                    cells["F" + (currentRow + 12) + ":H" + (currentRow + 12)].Font.Bold = true;
                    cells["F" + (currentRow + 12) + ":H" + (currentRow + 12)].HorizontalAlignment = HAlign.Center;
                    cells["A" + (currentRow + 14) + ":L" + (currentRow + 16)].Merge();
                    cells["A" + (currentRow + 14) + ":L" + (currentRow + 16)].WrapText = true;
                    cells["A" + (currentRow + 14)].Value = "До початку проведення інвентаризації всі видаткові та прибуткові документі на основні засобі здані в бухгалтерію і всі основні засобі," +
                                                           " що надійшли на мою (нашу) відповідальність, оприбутковані, а ті, що вибули, списані.\n" +
                                                           "Особа(и), відповідально(і) за збереження основніх засобів:";
                    cells["B" + (currentRow + 18) + ":D" + (currentRow + 18)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["F" + (currentRow + 18) + ":H" + (currentRow + 18)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["J" + (currentRow + 18) + ":L" + (currentRow + 18)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["B" + (currentRow + 19) + ":D" + (currentRow + 19)].Merge();
                    cells["F" + (currentRow + 19) + ":H" + (currentRow + 19)].Merge();
                    cells["J" + (currentRow + 19) + ":L" + (currentRow + 19)].Merge();
                    cells["B" + (currentRow + 19) + ":D" + (currentRow + 19)].Value = "(посада, підпис)";
                    cells["F" + (currentRow + 19) + ":H" + (currentRow + 19)].Value = "(посада, підпис)";
                    cells["J" + (currentRow + 19) + ":L" + (currentRow + 19)].Value = "(посада, підпис)";
                    cells["B" + (currentRow + 19) + ":D" + (currentRow + 19)].HorizontalAlignment = HAlign.Center;
                    cells["F" + (currentRow + 19) + ":H" + (currentRow + 19)].HorizontalAlignment = HAlign.Center;
                    cells["J" + (currentRow + 19) + ":L" + (currentRow + 19)].HorizontalAlignment = HAlign.Center;
                    cells["B" + (currentRow + 20) + ":D" + (currentRow + 20)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["F" + (currentRow + 20) + ":H" + (currentRow + 20)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["J" + (currentRow + 20) + ":L" + (currentRow + 20)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["B" + (currentRow + 21) + ":D" + (currentRow + 21)].Merge();
                    cells["F" + (currentRow + 21) + ":H" + (currentRow + 21)].Merge();
                    cells["J" + (currentRow + 21) + ":L" + (currentRow + 21)].Merge();
                    cells["B" + (currentRow + 21) + ":D" + (currentRow + 21)].Value = "(прізв., ім'я, по батькові)";
                    cells["F" + (currentRow + 21) + ":H" + (currentRow + 21)].Value = "(прізв., ім'я, по батькові)";
                    cells["J" + (currentRow + 21) + ":L" + (currentRow + 21)].Value = "(прізв., ім'я, по батькові)";
                    cells["B" + (currentRow + 21) + ":D" + (currentRow + 21)].HorizontalAlignment = HAlign.Center;
                    cells["F" + (currentRow + 21) + ":H" + (currentRow + 21)].HorizontalAlignment = HAlign.Center;
                    cells["J" + (currentRow + 21) + ":L" + (currentRow + 21)].HorizontalAlignment = HAlign.Center;
                    cells["A" + (currentRow + 23)].Value = "На підставі (розпорядження) від '____'  ____________20___р.";
                    cells["A" + (currentRow + 25)].Value = "Виконано знімання фактичних залишків";
                   
                   
                    cells["E" + (currentRow + 25) + ":L" + (currentRow + 25)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["A" + (currentRow + 26)].Value = "що значаться на обліку станом на";
                    cells["E" + (currentRow + 26)].Value = reportDate.ToShortDateString() + " р.";
                    cells["E" + (currentRow + 26) + ":F" + (currentRow + 26)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["A" + (currentRow + 28)].Value = "Інвентаризація: ";
                    cells["C" + (currentRow + 28)].Value = "розпочата '____'  ___________20___р.";
                    cells["C" + (currentRow + 29)].Value = "закінчена '____'  ___________20___р.";

                    cells["A" + (currentRow + 30)].PageBreak = PageBreak.Manual;

                    return (currentRow + 32);
                };
            #endregion

            #region BodyPage func
            Func<int, int> BodyPage = (currentRow) =>
                {
                    cells["A" + currentRow].Value = "При інвентаризації встановлено таке:";
                    cells["A" + (currentRow + 1) + ":A" + (currentRow + 2)].Merge();
                    cells["A" + (currentRow + 1)].Value = "№";
                    cells["B" + (currentRow + 1) + ":D" + (currentRow + 2)].Merge();
                    cells["B" + (currentRow + 1)].Value = "Найменування";
                    cells["E" + (currentRow + 1) + ":E" + (currentRow + 2)].Merge();
                    cells["E" + (currentRow + 1)].Value = "Номер";
                    cells["F" + (currentRow + 1) + ":H" + (currentRow + 1)].Merge();
                    cells["F" + (currentRow + 1)].Value = "Фактична наявність";
                    cells["F" + (currentRow + 2)].Value = "К-сть";
                    cells["G" + (currentRow + 2)].Value = "Перв. вартість";
                    cells["H" + (currentRow + 2)].Value = "Залиш. вартість";
                    cells["I" + (currentRow + 1) + ":K" + (currentRow + 1)].Merge();
                    cells["I" + (currentRow + 1)].Value = "За даними бух. обліку";
                    cells["I" + (currentRow + 2)].Value = "К-сть";
                    cells["J" + (currentRow + 2)].Value = "Перв. вартість";
                    cells["K" + (currentRow + 2)].Value = "Залиш. вартість";
                    cells["L" + (currentRow + 1) + ":L" + (currentRow + 2)].Merge();
                    cells["L" + (currentRow + 1)].Value = "Відм. про виб.";
                    cells["L" + (currentRow + 1) + ":L" + (currentRow + 2)].WrapText = true;

                    cells["A" + (currentRow + 3)].Value = "1";
                    cells["B" + (currentRow + 3) + ":D" + (currentRow + 3)].Merge();
                    cells["B" + (currentRow + 3)].Value = "2";
                    cells["E" + (currentRow + 3)].Value = "3";
                    cells["F" + (currentRow + 3)].Value = "4";
                    cells["G" + (currentRow + 3)].Value = "5";
                    cells["H" + (currentRow + 3)].Value = "6";
                    cells["I" + (currentRow + 3)].Value = "7";
                    cells["J" + (currentRow + 3)].Value = "8";
                    cells["K" + (currentRow + 3)].Value = "9";
                    cells["L" + (currentRow + 3)].Value = "10";
                    
                    cells["A" + (currentRow + 3) + ":L" + (currentRow + 3)].Interior.Color = Color.LightGray;
                    cells["A" + (currentRow + 1) + ":L" + (currentRow + 3)].HorizontalAlignment = HAlign.Center;
                    cells["A" + (currentRow + 1) + ":L" + (currentRow + 3)].VerticalAlignment = VAlign.Center;
                    cells["A" + (currentRow + 1) + ":L" + (currentRow + 3)].Borders.LineStyle = LineStyle.Continous;

                    return (currentRow + 4);
                };
            #endregion

            #region LastPage func
            Func<int, int, double, int> LastPage = (currentRow, itemCount, sumPrice) =>
                {
                    cells["A" + currentRow].Value = "Разом за описом:";
                    cells["D" + currentRow].Value = "а) кількість порядкових номерів";
                    cells["H" + currentRow + ":L" + currentRow].Merge();
                    cells["H" + currentRow].Value = RuDateAndMoneyConverter.NumeralsToTxt(itemCount, TextCase.Nominative, true, false);
                    cells["H" + currentRow + ":L" + currentRow].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["J" + (currentRow + 1)].Value = "(прописом)";
                    cells["D" + (currentRow + 2)].Value = "б) загальна кількість одиниць, фактично";
                    cells["H" + (currentRow + 2) + ":L" + (currentRow + 2)].Merge();
                    cells["H" + (currentRow + 2)].Value = RuDateAndMoneyConverter.NumeralsToTxt(itemCount, TextCase.Nominative, false, false);
                    cells["H" + (currentRow + 2) + ":L" + (currentRow + 2)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["J" + (currentRow + 3)].Value = "(прописом)";
                    cells["D" + (currentRow + 4)].Value = "в) на суму, грн., фактично";
                    cells["G" + (currentRow + 4) + ":L" + (currentRow + 5)].Merge();
                    cells["G" + (currentRow + 4) + ":L" + (currentRow + 5)].WrapText = true;
                    cells["G" + (currentRow + 4) + ":L" + (currentRow + 5)].HorizontalAlignment = HAlign.Left;
                    cells["G" + (currentRow + 4) + ":L" + (currentRow + 5)].VerticalAlignment = VAlign.Top;
                    cells["G" + (currentRow + 4)].Value = RuDateAndMoneyConverter.CurrencyToTxt(sumPrice, false);
                    cells["G" + (currentRow + 5) + ":L" + (currentRow + 5)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["J" + (currentRow + 6)].Value = "(прописом)";
                    
                    cells["A" + (currentRow + 8)].Value = "Голова комісії";
                    cells["D" + (currentRow + 8) + ":F" + (currentRow + 8)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["H" + (currentRow + 8) + ":I" + (currentRow + 8)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["K" + (currentRow + 8) + ":L" + (currentRow + 8)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["D" + (currentRow + 9) + ":F" + (currentRow + 9)].Merge();
                    cells["H" + (currentRow + 9) + ":I" + (currentRow + 9)].Merge();
                    cells["K" + (currentRow + 9) + ":L" + (currentRow + 9)].Merge();
                    cells["D" + (currentRow + 9) + ":F" + (currentRow + 9)].Value = "(посада)";
                    cells["H" + (currentRow + 9) + ":I" + (currentRow + 9)].Value = "(підпис)";
                    cells["K" + (currentRow + 9) + ":L" + (currentRow + 9)].Value = "(прізв., ім'я, по батькові)";
                    cells["D" + (currentRow + 9) + ":F" + (currentRow + 9)].HorizontalAlignment = HAlign.Center;
                    cells["H" + (currentRow + 9) + ":I" + (currentRow + 9)].HorizontalAlignment = HAlign.Center;
                    cells["K" + (currentRow + 9) + ":L" + (currentRow + 9)].HorizontalAlignment = HAlign.Center;

                    cells["A" + (currentRow + 10)].Value = "Члени комісії";
                    cells["D" + (currentRow + 10) + ":F" + (currentRow + 10)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["H" + (currentRow + 10) + ":I" + (currentRow + 10)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["K" + (currentRow + 10) + ":L" + (currentRow + 10)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["D" + (currentRow + 11) + ":F" + (currentRow + 11)].Merge();
                    cells["H" + (currentRow + 11) + ":I" + (currentRow + 11)].Merge();
                    cells["K" + (currentRow + 11) + ":L" + (currentRow + 11)].Merge();
                    cells["D" + (currentRow + 11) + ":F" + (currentRow + 11)].Value = "(посада)";
                    cells["H" + (currentRow + 11) + ":I" + (currentRow + 11)].Value = "(підпис)";
                    cells["K" + (currentRow + 11) + ":L" + (currentRow + 11)].Value = "(прізв., ім'я, по батькові)";
                    cells["D" + (currentRow + 11) + ":F" + (currentRow + 11)].HorizontalAlignment = HAlign.Center;
                    cells["H" + (currentRow + 11) + ":I" + (currentRow + 11)].HorizontalAlignment = HAlign.Center;
                    cells["K" + (currentRow + 11) + ":L" + (currentRow + 11)].HorizontalAlignment = HAlign.Center;

                    cells["D" + (currentRow + 12) + ":F" + (currentRow + 12)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["H" + (currentRow + 12) + ":I" + (currentRow + 12)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["K" + (currentRow + 12) + ":L" + (currentRow + 12)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["D" + (currentRow + 13) + ":F" + (currentRow + 13)].Merge();
                    cells["H" + (currentRow + 13) + ":I" + (currentRow + 13)].Merge();
                    cells["K" + (currentRow + 13) + ":L" + (currentRow + 13)].Merge();
                    cells["D" + (currentRow + 13) + ":F" + (currentRow + 13)].Value = "(посада)";
                    cells["H" + (currentRow + 13) + ":I" + (currentRow + 13)].Value = "(підпис)";
                    cells["K" + (currentRow + 13) + ":L" + (currentRow + 13)].Value = "(прізв., ім'я, по батькові)";
                    cells["D" + (currentRow + 13) + ":F" + (currentRow + 13)].HorizontalAlignment = HAlign.Center;
                    cells["H" + (currentRow + 13) + ":I" + (currentRow + 13)].HorizontalAlignment = HAlign.Center;
                    cells["K" + (currentRow + 13) + ":L" + (currentRow + 13)].HorizontalAlignment = HAlign.Center;

                    cells["D" + (currentRow + 14) + ":F" + (currentRow + 14)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["H" + (currentRow + 14) + ":I" + (currentRow + 14)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["K" + (currentRow + 14) + ":L" + (currentRow + 14)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["D" + (currentRow + 15) + ":F" + (currentRow + 15)].Merge();
                    cells["H" + (currentRow + 15) + ":I" + (currentRow + 15)].Merge();
                    cells["K" + (currentRow + 15) + ":L" + (currentRow + 15)].Merge();
                    cells["D" + (currentRow + 15) + ":F" + (currentRow + 15)].Value = "(посада)";
                    cells["H" + (currentRow + 15) + ":I" + (currentRow + 15)].Value = "(підпис)";
                    cells["K" + (currentRow + 15) + ":L" + (currentRow + 15)].Value = "(прізв., ім'я, по батькові)";
                    cells["D" + (currentRow + 15) + ":F" + (currentRow + 15)].HorizontalAlignment = HAlign.Center;
                    cells["H" + (currentRow + 15) + ":I" + (currentRow + 15)].HorizontalAlignment = HAlign.Center;
                    cells["K" + (currentRow + 15) + ":L" + (currentRow + 15)].HorizontalAlignment = HAlign.Center;

                    cells["A" + (currentRow + 17) + ":L" + (currentRow + 20)].Merge();
                    cells["A" + (currentRow + 17) + ":L" + (currentRow + 20)].WrapText = true;
                    cells["A" + (currentRow + 17)].Value = "Усі цінності, пойменовані в цьому інвентаризаційному описі з № ____ до № ____, перевірені комісією в натурі за моєї (нашої) присутності та внесені в опис," +
                                                           " у зв'язку з чим претензій до інвентариційної комісії не маю (не маємо). Цінності, перелічені в описі, знаходяться на моєму (нашому) відповідальному зберіганні.\n" + 
                                                           "Особа(и), відповідальна(і) за збереження основних засобів:";
                    cells["A" + (currentRow + 21)].Value = " '____'_____________20___р.";
                    cells["A" + (currentRow + 23) + ":L" + (currentRow + 23)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;

                    cells["A" + (currentRow + 25)].Value = "Вказані у даному описі дані перевірив";
                    cells["G" + (currentRow + 25) + ":H" + (currentRow + 25)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["K" + (currentRow + 25) + ":L" + (currentRow + 25)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
                    cells["G" + (currentRow + 26) + ":H" + (currentRow + 26)].Merge();
                    cells["K" + (currentRow + 26) + ":L" + (currentRow + 26)].Merge();
                    cells["G" + (currentRow + 26) + ":H" + (currentRow + 26)].Value = "(посада)";
                    cells["K" + (currentRow + 26) + ":L" + (currentRow + 26)].Value = "(підпис)";
                    cells["G" + (currentRow + 26) + ":H" + (currentRow + 26)].HorizontalAlignment = HAlign.Center;
                    cells["K" + (currentRow + 26) + ":L" + (currentRow + 26)].HorizontalAlignment = HAlign.Center;

                    cells["A" + (currentRow + 28)].Value = " '____'_____________20___р.";
                    return (currentRow + 28);
                };
            #endregion

            int countRow = reportTable.Rows.Count;
            short currentGroupId = 0;
            string group;
            for (int i = 0; i < countRow; i++)
            {
                if((short)reportTable.Rows[i]["GroupId"] != currentGroupId)
                {
                    currentGroupId = (short)reportTable.Rows[i]["GroupId"];
                    
                    worksheet = workbook.Worksheets.Add();
                    worksheet.PageSetup.Orientation = PageOrientation.Landscape;

                    worksheet.PageSetup.RightMargin = 0.25;
                    worksheet.PageSetup.TopMargin = 0.3;
                    worksheet.PageSetup.BottomMargin = 0.3;
                    group = (((string) reportTable.Rows[i]["FAO_NUM"]).Replace("/", ".") + ' ' +(string) reportTable.Rows[i]["GroupName"]);

                    worksheet.Name = (group.Length > 25) ? group.Substring(0, 25) : group;
                    cells = worksheet.Cells;

                    cells["C" + (startPosition + 9)].Value = group;
                    cells["E" + (startPosition + 25)].Value = group;

                    cells["A1"].ColumnWidth = 3;
                    cells["B1"].ColumnWidth = 10;
                    cells["C1"].ColumnWidth = 10;
                    cells["D1"].ColumnWidth = 10;
                    cells["E1"].ColumnWidth = 8;
                    cells["F1"].ColumnWidth = 6;
                    cells["G1"].ColumnWidth = 14;
                    cells["H1"].ColumnWidth = 14;
                    cells["I1"].ColumnWidth = 6;
                    cells["J1"].ColumnWidth = 14;
                    cells["K1"].ColumnWidth = 14;
                    cells["L1"].ColumnWidth = 8;

                    currentPosition = FirstPage(startPosition);
                    currentPosition = BodyPage(currentPosition);

                    int startBorderRow = currentPosition;
                    
                    var currentGroupItems = reportTable.AsEnumerable().Where(r => r.Field<short>("GroupId") == currentGroupId).OrderBy(o => o["InventoryNumber"]).ToList();
                    var sumBeginPrice = currentGroupItems.Sum(s => s.Field<decimal>("TotalPriceFull"));
                    var sumCurrentPrice = currentGroupItems.Sum(s => s.Field<decimal>("CurrentPrice"));

                    for (int j = 0; j < currentGroupItems.Count; j++)
                    {
                        cells["A" + currentPosition + ":A" + (currentPosition + 1)].Merge();
                        cells["A" + currentPosition].Value = j + 1;
                        cells["A" + currentPosition + ":A" + (currentPosition + 1)].HorizontalAlignment = HAlign.Center;
                        cells["A" + currentPosition + ":A" + (currentPosition + 1)].VerticalAlignment = VAlign.Center;
                        cells["B" + currentPosition + ":D" + (currentPosition + 1)].Merge();
                        cells["B" + currentPosition].Value = currentGroupItems[j]["InventoryName"];
                        cells["B" + currentPosition + ":D" + (currentPosition + 1)].WrapText = true;
                        cells["B" + currentPosition + ":D" + (currentPosition + 1)].HorizontalAlignment = HAlign.Left;
                        cells["B" + currentPosition + ":D" + (currentPosition + 1)].VerticalAlignment = VAlign.Center;
                        cells["E" + currentPosition + ":E" + (currentPosition + 1)].Merge();
                        cells["E" + currentPosition].Value = currentGroupItems[j]["InventoryNumber"];
                        cells["F" + currentPosition + ":F" + (currentPosition + 1)].Merge();
                        cells["F" + currentPosition].Value = 1;
                        cells["G" + currentPosition + ":G" + (currentPosition + 1)].Merge();
                        cells["G" + currentPosition].Value = currentGroupItems[j]["TotalPriceFull"];
                        cells["H" + currentPosition + ":H" + (currentPosition + 1)].Merge();
                        cells["H" + currentPosition].Value = currentGroupItems[j]["CurrentPrice"];
                        cells["I" + currentPosition + ":I" + (currentPosition + 1)].Merge();
                        cells["I" + currentPosition].Value = 1;
                        cells["J" + currentPosition + ":J" + (currentPosition + 1)].Merge();
                        cells["J" + currentPosition].Value = currentGroupItems[j]["TotalPriceFull"];
                        cells["K" + currentPosition + ":K" + (currentPosition + 1)].Merge();
                        cells["K" + currentPosition].Value = currentGroupItems[j]["CurrentPrice"];
                        cells["L" + currentPosition + ":L" + (currentPosition + 1)].Merge();
                        cells["L" + currentPosition].Value = "";

                        cells["E" + currentPosition + ":L" + (currentPosition + 1)].HorizontalAlignment = HAlign.Center;
                        cells["E" + currentPosition + ":L" + (currentPosition + 1)].VerticalAlignment = VAlign.Center;
                        
                        currentPosition += 2;
                    }

                    cells["B" + currentPosition + ":D" + currentPosition].Merge();
                    cells["B" + currentPosition].Value = "Разом";
                    cells["B" + currentPosition].HorizontalAlignment = HAlign.Right;
                    cells["F" + currentPosition].Value = currentGroupItems.Count;
                    cells["G" + currentPosition].Value = sumBeginPrice;
                    cells["H" + currentPosition].Value = sumCurrentPrice;
                    cells["I" + currentPosition].Value = currentGroupItems.Count;
                    cells["J" + currentPosition].Value = sumBeginPrice;
                    cells["K" + currentPosition].Value = sumCurrentPrice;
                    cells["F" + currentPosition + ":K" + currentPosition].HorizontalAlignment = HAlign.Center;
                    
                    cells["G" + startBorderRow + ":H" + currentPosition].NumberFormat = "### ### ##0.00";
                    cells["J" + startBorderRow + ":K" + currentPosition].NumberFormat = "### ### ##0.00";
                    cells["A" + startBorderRow + ":L" + currentPosition].Borders.LineStyle = LineStyle.Continous;
                    cells["B" + currentPosition + ":K" + currentPosition].Font.Bold = true;
                    
                    currentPosition += 2;

                    cells["A" + currentPosition].PageBreak = PageBreak.Manual;

                    currentPosition = LastPage(currentPosition, currentGroupItems.Count, (double)sumBeginPrice);
                }
            }
           
            workbook.Worksheets[0].Delete();

            try
            {
                string documentAddresName = GeneratedReportsDir + "Инвентаризационная ведомость " + reportDate.ToShortDateString() + ".xls";
                workbook.SaveAs(documentAddresName, FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + documentAddresName + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void InventoryCardPrintForSoftware(DataRowView SourseData)
        {
            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(TemplatesDir + "InventoryCardPrintForSoftware.xls");
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            decimal yearAmortization = Math.Round(((decimal)SourseData["BeginPrice"] / (short)SourseData["UsefulMonth"]) * 12, 2);

            int rows = 40;
            int cols = 30;

            cells[0, 0, rows, cols].Replace("{currInventoryName}", SourseData["InventoryName"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currInventoryNumber}", SourseData["InventoryNumber"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currBeginDate}", Convert.ToDateTime(SourseData["BeginDate"]).ToShortDateString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currSupplier_Name}", SourseData["Supplier_Name"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currUsefulMonth}", SourseData["UsefulMonth"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currBalance_Account_Num}", SourseData["Balance_Account_Num"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currBeginPrice}", SourseData["BeginPrice"].ToString(), LookAt.Part, SearchOrder.ByRows, false);
            cells[0, 0, rows, cols].Replace("{currAmortizationYearPrice}", yearAmortization.ToString(), LookAt.Part, SearchOrder.ByRows, false);

            try
            {
                worksheet.SaveAs(GeneratedReportsDir + "Инвентарная карточка учета ПО №" + SourseData["InventoryNumber"].ToString().Replace("/", "_") + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Инвентарная карточка учета ПО №" + SourseData["InventoryNumber"].ToString().Replace("/", "_") + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void InventoryGroupsForFixedAssets(DataTable reportTable, DateTime reportDate)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var orderSource = reportTable.AsEnumerable().OrderBy(r => r[3]).ThenByDescending(r => r[6]);

            reportTable = orderSource.AsDataView().ToTable();
            
            var Workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;
            StringBuilder SumH = new StringBuilder("=");
            StringBuilder SumJ = new StringBuilder("=");
            StringBuilder SumI = new StringBuilder("=");
            StringBuilder SumK = new StringBuilder("=");
            StringBuilder SumL = new StringBuilder("=");
            StringBuilder SumM = new StringBuilder("=");

            Dictionary<string, string> ColumNameAsFAM_NUM = new Dictionary<string, string>();
            Dictionary<string, StringBuilder> FAM_NUMAsColumSum = new Dictionary<string, StringBuilder>();

            Func<Int32, string> ColumNameByIndex = (x) => { return vsS[x + 1]; };

            Action<IRange, int, int, int, Dictionary<string, string>> WriteHatSum = (cel, currentPos, rowsStartGr, lastColIndexHat, DColumNameAsFAM_NUM) =>
            {
                cells["A" + currentPos + ":" + "G" + currentPos].Merge();
                cel["A" + currentPos].Value = "Всього";
                string startIndexSum = (rowsStartGr + 1).ToString();
                string endIndexSum = (currentPos - 1).ToString();
                cel["I" + currentPos].Value = "=SUM(I" + startIndexSum + ":I" + endIndexSum + ")";
                SumH.AppendFormat("+I{0}", currentPos.ToString());
                cel["J" + currentPos].Value = "=SUM(J" + startIndexSum + ":J" + endIndexSum + ")";
                SumI.AppendFormat("+J{0}", currentPos.ToString());

                cells["H" + currentPos + ":" + "J" + currentPos].NumberFormat = "### ### ##0.00";
                
                cells["A" + rowsStartGr + ":" + "J" + rowsStartGr].Borders.LineStyle = LineStyle.Continous;
                cells["A" + currentPos + ":" + "J" + currentPos].Interior.Color = Color.LightGreen;
            };

            Action<IRange, int, int, int, Dictionary<string, string>> WriteHatGlobalSum = (cel, currentPos, rowsStartGr, lastColIndexHat, DColumNameAsFAM_NUM) =>
            {
                cells["A" + currentPos + ":" + "G" + currentPos].Merge();
                cel["A" + currentPos].Value = "Сума";
                string startIndexSum = (rowsStartGr + 1).ToString();
                string endIndexSum = (currentPos - 1).ToString();
                cel["I" + currentPos].Value = SumH.ToString();
                cel["J" + currentPos].Value = SumI.ToString();

                cells["I" + currentPos + ":" + "J" + currentPos].NumberFormat = "### ### ##0.00";

                cells["A" + rowsStartGr + ":" + "G" + rowsStartGr].Borders.LineStyle = LineStyle.Continous;
                cells["A" + currentPos + ":" + "J" + currentPos].Interior.Color = Color.Silver;
                cells["A" + currentPos + ":" + "J" + currentPos].Font.Bold = true;
            };

            int captionPosition = 6;
            int n = 1;
            int startPosition = captionPosition + 2;
            int currentPosition = 0;
            string activGroup = "@#$%^@&&";
            int rowsStartGroup = 0;
            int lastColumIndexHat = -1;

            cells["A" + captionPosition + ":" +  "J" + captionPosition].Merge();
            cells["A" + captionPosition].Value = "Інвентаризаційна відомість основных засобів (по групам)";
            cells["A" + (captionPosition + 1) + ":" + "J" + (captionPosition + 1)].Merge();
            cells["A" + (captionPosition + 1)].Value = "станом на " + reportDate.ToShortDateString();

            cells["A" + captionPosition + ":" + "J" + (captionPosition + 1)].HorizontalAlignment = HAlign.Center;
            cells["A" + captionPosition + ":" + "J" + (captionPosition + 1)].VerticalAlignment = VAlign.Center;

            cells["A" + startPosition].Value = "№";
            cells["B" + startPosition].Value = "Балансовый рахунок";
            cells["C" + startPosition].Value = "Дата прийняття до обліку";
            cells["D" + startPosition].Value = "Відповідальна особа";
            cells["E" + startPosition].Value = "Експлуатуюча особа";
            cells["F" + startPosition].Value = "Дільниця";
            cells["G" + startPosition].Value = "Інвентарний номер";
            cells["H" + startPosition].Value = "Найменування";
            cells["I" + startPosition].Value = "Первинна вартість";
            cells["J" + startPosition].Value = "Залишкова вартість";

            cells["A" + startPosition].RowHeight = 30;
            cells["A" + startPosition + ":" + "J" + startPosition].AutoFilter(1, null, AutoFilterOperator.Or, null, true);
            cells["A" + startPosition + ":" + "J" + startPosition].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startPosition + ":" + "J" + startPosition].HorizontalAlignment = HAlign.Center;
            cells["A" + startPosition + ":" + "J" + startPosition].VerticalAlignment = VAlign.Center;
            cells["A" + startPosition + ":" + "J" + startPosition].WrapText = true;

            cells["A1"].ColumnWidth = 15;
            cells["B1"].ColumnWidth = 15;
            cells["C1"].ColumnWidth = 20;
            cells["D1"].ColumnWidth = 70;
            cells["E1"].ColumnWidth = 70;
            cells["F1"].ColumnWidth = 30;
            cells["G1"].ColumnWidth = 15;
            cells["H1"].ColumnWidth = 50;
            cells["I1"].ColumnWidth = 15;
            cells["J1"].ColumnWidth = 15;

            startPosition++;

            currentPosition = startPosition;

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (activGroup != reportTable.Rows[i]["GROUPNAME"].ToString())
                {
                    //Sum
                    if (i != 0)
                    {
                        WriteHatSum(cells, currentPosition, rowsStartGroup, lastColumIndexHat, ColumNameAsFAM_NUM);
                        currentPosition++;
                    }
                    activGroup = reportTable.Rows[i]["GROUPNAME"].ToString();

                    rowsStartGroup = currentPosition;
                    cells["A" + currentPosition].Value = "Группа: " + reportTable.Rows[i]["FAO_NUM"] + " " + reportTable.Rows[i]["GROUPNAME"];
                    cells["A" + currentPosition + ":" + "I" + currentPosition].Merge();
                    cells["A" + currentPosition].Font.Bold = true;
                    currentPosition++;
                }
                cells["A" + currentPosition].Value = n;
                cells["B" + currentPosition].Value = reportTable.Rows[i]["FAO_NUM"];
                cells["C" + currentPosition].Value = reportTable.Rows[i]["BEGINDATE"];
                cells["D" + currentPosition].Value = reportTable.Rows[i]["SUPPLIER_NAME"];
                cells["E" + currentPosition].Value = reportTable.Rows[i]["OPERATINGPERSON_NAME"];
                cells["F" + currentPosition].Value = reportTable.Rows[i]["REGIONNAME"];
                cells["G" + currentPosition].Value = reportTable.Rows[i]["INVENTORYNUMBER"];
                cells["H" + currentPosition].Value = reportTable.Rows[i]["INVENTORYNAME"];
                cells["I" + currentPosition].Value = reportTable.Rows[i]["TOTALPRICEFULL"];
                cells["I" + currentPosition].NumberFormat = "### ### ##0.00";
                cells["J" + currentPosition].Value = reportTable.Rows[i]["CURRENTPRICE"];
                cells["J" + currentPosition].NumberFormat = "### ### ##0.00";

                currentPosition++;
                n++;
            }
            WriteHatSum(cells, currentPosition, rowsStartGroup, lastColumIndexHat, ColumNameAsFAM_NUM);
            currentPosition++;
            WriteHatGlobalSum(cells, currentPosition, rowsStartGroup, lastColumIndexHat, ColumNameAsFAM_NUM);

            cells["A" + startPosition + ":" + "J" + currentPosition].Borders.LineStyle = LineStyle.Continous;
            cells["A" + captionPosition + ":" + "J" + currentPosition].Font.Size = 12;
            cells["A" + captionPosition + ":" + "J" + startPosition].Font.Bold = true;
            cells["A" + startPosition + ":" + "J" + currentPosition].WrapText = true;
            cells["A" + startPosition + ":" + "J" + currentPosition].HorizontalAlignment = HAlign.Left;
            cells["A" + startPosition + ":" + "J" + currentPosition].VerticalAlignment = VAlign.Center;

            PrintSignatures(cells, currentPosition + 3);

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Інвентаризаційна відомість ОЗ (по групам) станом на " + reportDate.ToShortDateString() + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Інвентаризаційна відомість ОЗ (по групам) станом на " + reportDate.ToShortDateString() + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        #endregion

        #region CalcWithBuyers

        public void CalcWithBuyersReport(DataTable reportTable, string StartDate, string EndDate, string calcAccount, short purposeAccountId)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SpreadsheetGear.IWorkbook workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            Dictionary<int, string> DebitAcc = new Dictionary<int, string>();
            Dictionary<int, string> CreditAcc = new Dictionary<int, string>();
            Dictionary<string, byte> HeaderColumn = new Dictionary<string, byte>();

            int startDebitAccount = 0;
            int startCreditAccount = 0;
            int endDebitAccount = 0;
            int endCreditAccount = 0;

            int captionPosition = 6;
            int startPosition = captionPosition + 1;
            int currentPosition = startPosition + 3;
            byte startHeaderPosition = 1;

            #region Generate report header

            var Debit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") > 0).Select(c => new
            {
                AccountNum = c.Field<string>("Num"),
                AccountId = c.Field<int>("AccountId")
            }).Distinct().OrderBy(c => c.AccountNum);

            foreach (var dict in Debit_Accounts)
                DebitAcc.Add(dict.AccountId, dict.AccountNum);


            var Credit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") < 0).Select(c => new
            {
                AccountNum = c.Field<string>("Num"),
                AccountId = c.Field<int>("AccountId")
            }).Distinct().OrderBy(c => c.AccountNum).ToList();

            foreach (var dict in Credit_Accounts)
                CreditAcc.Add(dict.AccountId, dict.AccountNum);

            HeaderColumn.Add("PartnerSrn", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Код/таб.номер";

            startHeaderPosition++;

            HeaderColumn.Add("PartnerName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[vsS[startHeaderPosition] + (startPosition + 1) + ":" + vsS[startHeaderPosition] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на початок періоду";

            HeaderColumn.Add("StartDebit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            startHeaderPosition++;

            HeaderColumn.Add("StartCredit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Кредит";
                   
            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            startHeaderPosition++;

            HeaderColumn.Add("Comment", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Коментар";

            startHeaderPosition++;

            HeaderColumn.Add("CalcDocument", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер документу";

            startHeaderPosition++;

            HeaderColumn.Add("CalcDate", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата";

            startHeaderPosition++;
            
            if (DebitAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("В д-т рах. {0} з к-та рах.", calcAccount);
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + DebitAcc.Count] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("В д-т рах. {0} з к-та рах.", calcAccount);
                startDebitAccount = startHeaderPosition;
                foreach (var debit_account in DebitAcc)
                {
                    HeaderColumn.Add("DebitAccount" + debit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition + 1, startHeaderPosition - 1].Value = debit_account.Value;
                    startHeaderPosition++;
                }
                endDebitAccount = startHeaderPosition;
            }

            HeaderColumn.Add("CalcPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сума в гривні";
            cells[vsS[HeaderColumn["CalcPrice"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["CalcPrice"] - 1] + (startPosition)].Interior.Color = Color.Azure;
            
            startHeaderPosition++;

            HeaderColumn.Add("Purpose", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Призначення платежу";

            startHeaderPosition++;

            HeaderColumn.Add("BankNum", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер платежу";

            startHeaderPosition++;

            HeaderColumn.Add("BankDate", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата";

            startHeaderPosition++;

            if (CreditAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("З к-та рах. {0} в д-т рах.", calcAccount);
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + CreditAcc.Count] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("З к-та рах. {0} в д-т рах.", calcAccount);
                startCreditAccount = startHeaderPosition;
                foreach (var credit_account in CreditAcc)
                {
                    HeaderColumn.Add("CreditAccount" + credit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition + 1, startHeaderPosition - 1].Value = credit_account.Value;
                    startHeaderPosition++;
                }
                endCreditAccount = startHeaderPosition;
            }

            HeaderColumn.Add("BankPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сума в гривні";
            cells[vsS[HeaderColumn["BankPrice"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["BankPrice"] - 1] + (startPosition)].Interior.Color = Color.Azure;

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[vsS[startHeaderPosition] + (startPosition + 1) + ":" + vsS[startHeaderPosition] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на кінець періоду";
            
            HeaderColumn.Add("EndDebit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            startHeaderPosition++;

            HeaderColumn.Add("EndCredit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Кредит";
            
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;
                        
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].WrapText = true;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].VerticalAlignment = VAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].HorizontalAlignment = HAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Font.Bold = true;
            cells["A:A"].ColumnWidth = 15;
            cells["B:B"].ColumnWidth = 70;
            cells["C:C"].ColumnWidth = 15;
            cells["C" + ":" + vsS[startHeaderPosition - 1]].ColumnWidth = 15;

            #endregion

            #region Loop body

            #region Loop variables

            int contractorId = 0;
            int employeesId = 0;
            string account = "";
            int startContractor = currentPosition;
            int sumPosition = 0;

            decimal startDebit = 0, startCredit = 0, endDebit = 0, endCredit = 0;

            #endregion
            

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (contractorId != (int)reportTable.Rows[i]["ContractorsId"] || employeesId != (int)reportTable.Rows[i]["EmployeesId"])
                {
                    contractorId = (int)reportTable.Rows[i]["ContractorsId"];
                    employeesId = (int)reportTable.Rows[i]["EmployeesId"];

                    if (i > 0)
                    {
                        cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["CalcPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CalcPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["BankPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["BankPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

                        cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;

                        cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebit"] - 1], startContractor, vsS[HeaderColumn["StartDebit"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCredit"] - 1], startContractor, vsS[HeaderColumn["StartCredit"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebit"] - 1], startContractor, vsS[HeaderColumn["EndDebit"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCredit"] - 1], startContractor, vsS[HeaderColumn["EndCredit"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CalcPrice"] - 1], startContractor, vsS[HeaderColumn["CalcPrice"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["BankPrice"] - 1], startContractor, vsS[HeaderColumn["BankPrice"] - 1], currentPosition - 1, "SUM");

                        cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Font.Bold = true;

                        if (DebitAcc.Count > 0)
                        {
                            foreach (var dict in DebitAcc)
                            {
                                sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                                cells[vsS[sumPosition - 1] + currentPosition].Font.Bold = true;
                            }
                        }
                        if (CreditAcc.Count > 0)
                        {
                            foreach (var dict in CreditAcc)
                            {
                                sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                                cells[vsS[sumPosition - 1] + currentPosition].Font.Bold = true;
                            }
                        }
                        currentPosition++;
                        startContractor = currentPosition;
                    }
                    cells[vsS[HeaderColumn["PartnerSrn"] - 1] + currentPosition].Value = reportTable.Rows[i]["PartnerSrn"];
                    cells[vsS[HeaderColumn["PartnerName"] - 1] + currentPosition].Value = reportTable.Rows[i]["PartnerName"];
                    //
                    cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebit"];
                    cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCredit"];
                    //
                    if ((int?)reportTable.Rows[i]["FlagDebitCredit"] > 0)
                    {
                        cells[vsS[HeaderColumn["CalcDocument"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["CalcDocument"] - 1] + currentPosition].HorizontalAlignment = HAlign.Right;
                        cells[vsS[HeaderColumn["Comment"] - 1] + currentPosition].Value = reportTable.Rows[i]["Comment"];
                        cells[vsS[HeaderColumn["Comment"] - 1] + currentPosition].WrapText = false;
                        cells[vsS[HeaderColumn["CalcDate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    else if ((int?)reportTable.Rows[i]["FlagDebitCredit"] < 0)
                    {
                        cells[vsS[HeaderColumn["BankNum"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["BankNum"] - 1] + currentPosition].HorizontalAlignment = HAlign.Right;
                        cells[vsS[HeaderColumn["Purpose"] - 1] + currentPosition].Value = reportTable.Rows[i]["Purpose"];
                        cells[vsS[HeaderColumn["Purpose"] - 1] + currentPosition].WrapText = false;
                        cells[vsS[HeaderColumn["BankDate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    if ((int)reportTable.Rows[i]["AccountId"] > 0)
                    {
                        account = ((int?)reportTable.Rows[i]["FlagDebitCredit"] > 0)
                            ? "DebitAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString()
                            : "CreditAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString();
                        cells[vsS[HeaderColumn[account] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    //
                    cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebit"];
                    cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCredit"];

                    startDebit += (decimal)reportTable.Rows[i]["StartDebit"];
                    startCredit += (decimal)reportTable.Rows[i]["StartCredit"];
                    endDebit += (decimal)reportTable.Rows[i]["EndDebit"];
                    endCredit += (decimal)reportTable.Rows[i]["EndCredit"];

                }
                else
                {
                    if ((int?)reportTable.Rows[i]["FlagDebitCredit"] > 0)
                    {
                        cells[vsS[HeaderColumn["CalcDocument"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["CalcDate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["Comment"] - 1] + currentPosition].Value = reportTable.Rows[i]["Comment"];
                        cells[vsS[HeaderColumn["Comment"] - 1] + currentPosition].WrapText = false;
                        cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    else if ((int?)reportTable.Rows[i]["FlagDebitCredit"] < 0)
                    {
                        cells[vsS[HeaderColumn["BankNum"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["BankDate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["Purpose"] - 1] + currentPosition].Value = reportTable.Rows[i]["Purpose"];
                        cells[vsS[HeaderColumn["Purpose"] - 1] + currentPosition].WrapText = false;
                        cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    if ((int)reportTable.Rows[i]["AccountId"] > 0)
                    {
                        account = ((int?)reportTable.Rows[i]["FlagDebitCredit"] > 0)
                            ? "DebitAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString()
                            : "CreditAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString();
                        cells[vsS[HeaderColumn[account] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                }

                

                currentPosition++;
            }

            #endregion

            #region Finally step output

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["CalcPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CalcPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["BankPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["BankPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;

            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebit"] - 1], startContractor, vsS[HeaderColumn["StartDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCredit"] - 1], startContractor, vsS[HeaderColumn["StartCredit"] - 1], currentPosition - 1, "SUM");
            
            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebit"] - 1], startContractor, vsS[HeaderColumn["EndDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCredit"] - 1], startContractor, vsS[HeaderColumn["EndCredit"] - 1], currentPosition - 1, "SUM");
            
            cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CalcPrice"] - 1], startContractor, vsS[HeaderColumn["CalcPrice"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["BankPrice"] - 1], startContractor, vsS[HeaderColumn["BankPrice"] - 1], currentPosition - 1, "SUM");

            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Font.Bold = true;

            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                    cells[vsS[sumPosition - 1] + currentPosition].Font.Bold = true;
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                    cells[vsS[sumPosition - 1] + currentPosition].Font.Bold = true;
                }
            }
            cells["A" + (startPosition + 3) + ":" + vsS[startHeaderPosition - 1] + (currentPosition + 1)].Borders.LineStyle = LineStyle.Continous;
            currentPosition++;

            #endregion

            #region Result summary

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.LightGreen;
            cells["B" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["B" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Font.Bold = true;
            cells["B" + currentPosition].Value = "Всього";
            cells["B" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["C" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells["C" + (startPosition + 3) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";

            if (DebitAcc.Count > 0)
                cells[vsS[HeaderColumn["DebitAccount" + DebitAcc.Keys.First()] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            if (CreditAcc.Count > 0)
                cells[vsS[HeaderColumn["CreditAccount" + CreditAcc.Keys.First()] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";

            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = startDebit;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = endDebit;
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = startCredit;
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = endCredit;
                        
            cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") > 0).Sum(x => x.Field<decimal?>("PeriodPrice"));
            cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") < 0).Sum(x => x.Field<decimal?>("PeriodPrice"));
            
            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") > 0 && w.Field<int>("AccountId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") < 0 && w.Field<int>("AccountId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }

            PrintSignatures(cells, currentPosition + 2);

            #endregion

            #region Report caption and froze row

            cells["A" + captionPosition + ":" + vsS[startHeaderPosition - 1] + captionPosition].Merge();
            cells["A" + captionPosition].Value = String.Format("Відомість аналитичного обліку розрахунків з покупцями та замовниками(до рахунку {0}) з {1} по {2} ", calcAccount, StartDate, EndDate);
            cells["A" + captionPosition].Font.Bold = true;
            cells["A" + captionPosition].VerticalAlignment = VAlign.Center;
            cells["A" + captionPosition].HorizontalAlignment = HAlign.Center;

            worksheet.WindowInfo.ScrollRow = 0;
            worksheet.WindowInfo.SplitRows = startPosition + 2;

            worksheet.WindowInfo.FreezePanes = true;

            #endregion

            try
            {
                string documentAddresName = GeneratedReportsDir +
                                            String.Format("ОСВ по замовникам (до рахунку {0}) з {1} по {2} ", calcAccount, StartDate, EndDate) + ".xls";
                workbook.SaveAs(documentAddresName, FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + documentAddresName + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        public void CalcWithBuyersReportCurrency(DataTable reportTable, string StartDate, string EndDate, string calcAccount, short purposeAccountId)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SpreadsheetGear.IWorkbook workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            Dictionary<int, string> DebitAcc = new Dictionary<int, string>();
            Dictionary<int, string> CreditAcc = new Dictionary<int, string>();
            Dictionary<string, byte> HeaderColumn = new Dictionary<string, byte>();

            int startDebitAccount = 0;
            int startCreditAccount = 0;
            int endDebitAccount = 0;
            int endCreditAccount = 0;

            int captionPosition = 6;
            int startPosition = captionPosition + 1; 
            int currentPosition = startPosition + 3;
            byte startHeaderPosition = 1;

            #region Generate report header

            var Debit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") > 0).Select(c => new
            {
                AccountNum = c.Field<string>("Num"),
                AccountId = c.Field<int>("AccountId")
            }).Distinct().OrderBy(c => c.AccountNum);

            foreach (var dict in Debit_Accounts)
                DebitAcc.Add(dict.AccountId, dict.AccountNum);


            var Credit_Accounts = reportTable.AsEnumerable().Where(c => c.Field<int?>("FlagDebitCredit") < 0).Select(c => new
            {
                AccountNum = c.Field<string>("Num"),
                AccountId = c.Field<int>("AccountId")
            }).Distinct().OrderBy(c => c.AccountNum).ToList();

            foreach (var dict in Credit_Accounts)
                CreditAcc.Add(dict.AccountId, dict.AccountNum);

            HeaderColumn.Add("PartnerSrn", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Код/таб.номер";

            startHeaderPosition++;

            HeaderColumn.Add("PartnerName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування";

            startHeaderPosition++;

            HeaderColumn.Add("CurrencyName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування валюти";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 6] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 2] + (startPosition + 1)].Merge();
            cells[vsS[startHeaderPosition + 3] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 6] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на початок періоду";
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            cells[startPosition, startHeaderPosition + 3].Value = "Кредит";

            HeaderColumn.Add("StartDebit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("StartDebitCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("StartDebitCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("StartDebitCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";
            startHeaderPosition++;

            HeaderColumn.Add("StartCredit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("StartCreditCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("StartCreditCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("StartCreditCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            startHeaderPosition++;

            HeaderColumn.Add("Comment", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Коментар";

            startHeaderPosition++;

            HeaderColumn.Add("CalcDocument", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер документу";

            startHeaderPosition++;

            HeaderColumn.Add("CalcDate", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата";

            startHeaderPosition++;

            if (DebitAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("В д-т рах. {0} з к-та рах", calcAccount);
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + DebitAcc.Count] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("В д-т рах. {0} з к-та рах.", calcAccount);
                startDebitAccount = startHeaderPosition;
                foreach (var debit_account in DebitAcc)
                {
                    HeaderColumn.Add("DebitAccount" + debit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition + 1, startHeaderPosition - 1].Value = debit_account.Value;
                    startHeaderPosition++;
                }
                endDebitAccount = startHeaderPosition;
            }

            HeaderColumn.Add("CalcPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сума в гривні";
            cells[vsS[HeaderColumn["CalcPrice"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["CalcPrice"] - 1] + (startPosition)].Interior.Color = Color.Azure;
            startHeaderPosition++;

            HeaderColumn.Add("CalcRate", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Курс";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Всього по дебету";
            cells[vsS[startHeaderPosition - 1] + (startPosition) + ":" + vsS[startHeaderPosition + 1] + (startPosition + 2)].Interior.Color = Color.Azure;

            HeaderColumn.Add("DebitSumUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";

            startHeaderPosition++;

            HeaderColumn.Add("DebitSumEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";

            startHeaderPosition++;

            HeaderColumn.Add("DebitSumRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            startHeaderPosition++;

            HeaderColumn.Add("Purpose", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Призначення платежу";

            startHeaderPosition++;

            HeaderColumn.Add("BankNum", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Номер платежу";

            startHeaderPosition++;

            HeaderColumn.Add("BankDate", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Дата";

            startHeaderPosition++;

            if (CreditAcc.Count == 0)
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("З к-та рах. {0} в д-т рах.", calcAccount);
                startHeaderPosition++;
            }
            else
            {
                cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 2 + CreditAcc.Count] + (startPosition + 1)].Merge();
                cells[startPosition - 1, startHeaderPosition - 1].Value = String.Format("З к-та рах. {0} в д-т рах.", calcAccount);
                startCreditAccount = startHeaderPosition;
                foreach (var credit_account in CreditAcc)
                {
                    HeaderColumn.Add("CreditAccount" + credit_account.Key.ToString(), startHeaderPosition);
                    cells[startPosition + 1, startHeaderPosition - 1].Value = credit_account.Value;
                    startHeaderPosition++;
                }
                endCreditAccount = startHeaderPosition;
            }

            HeaderColumn.Add("BankPrice", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сума в гривні";
            cells[vsS[HeaderColumn["BankPrice"] - 1] + (startPosition) + ":" + vsS[HeaderColumn["BankPrice"] - 1] + (startPosition)].Interior.Color = Color.Azure;

            startHeaderPosition++;

            HeaderColumn.Add("BankRate", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Курс";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 1] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Всього по кредиту";
            cells[vsS[startHeaderPosition - 1] + (startPosition) + ":" + vsS[startHeaderPosition + 1] + (startPosition + 2)].Interior.Color = Color.Azure;

            HeaderColumn.Add("CreditSumUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";

            startHeaderPosition++;

            HeaderColumn.Add("CreditSumEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";

            startHeaderPosition++;

            HeaderColumn.Add("CreditSumRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 6] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 2] + (startPosition + 1)].Merge();
            cells[vsS[startHeaderPosition + 3] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 6] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на кінець періоду";
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            cells[startPosition, startHeaderPosition + 3].Value = "Кредит";

            HeaderColumn.Add("EndDebit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("EndDebitCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("EndDebitCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("EndDebitCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";
            startHeaderPosition++;

            HeaderColumn.Add("EndCredit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("EndCreditCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("EndCreditCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("EndCreditCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].WrapText = true;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].VerticalAlignment = VAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].HorizontalAlignment = HAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Font.Bold = true;

            cells["A:A"].ColumnWidth = 15;
            cells["B:B"].ColumnWidth = 70;
            cells["C:C"].ColumnWidth = 15;
            cells["D" + ":" + vsS[startHeaderPosition - 1]].ColumnWidth = 15;

            #endregion

            #region Loop body

            #region Loop variables

            int contractorId = 0;
            int employeesId = 0;
            int currencyId = 0;
            string account = "";
            int startContractor = currentPosition;
            int sumPosition = 0;

            decimal startDebit = 0, startDebitCurrencyRUB = 0, startDebitCurrencyEUR = 0, startDebitCurrencyUSD = 0,
                    startCredit = 0, startCreditCurrencyRUB = 0, startCreditCurrencyEUR = 0, startCreditCurrencyUSD = 0,
                    endDebit = 0, endDebitCurrencyRUB = 0, endDebitCurrencyEUR = 0, endDebitCurrencyUSD = 0,
                    endCredit = 0, endCreditCurrencyRUB = 0, endCreditCurrencyEUR = 0, endCreditCurrencyUSD = 0;               
                    
            #endregion
           
            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (contractorId != (int)reportTable.Rows[i]["ContractorsId"] || employeesId != (int)reportTable.Rows[i]["EmployeesId"])
                {
                    contractorId = (int)reportTable.Rows[i]["ContractorsId"];
                    employeesId = (int)reportTable.Rows[i]["EmployeesId"];
                    currencyId = (int)reportTable.Rows[i]["CurrencyId"];

                    if (i > 0)
                    {
                        #region Set style and formul's for current row
                    
                        cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
                        cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["CalcPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CalcPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
                        cells[vsS[HeaderColumn["BankPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["BankPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

                        cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;

                        cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebit"] - 1], startContractor, vsS[HeaderColumn["StartDebit"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1], startContractor, vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1], startContractor, vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1], startContractor, vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCredit"] - 1], startContractor, vsS[HeaderColumn["StartCredit"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1], startContractor, vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1], startContractor, vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1], startContractor, vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1], currentPosition - 1, "SUM");

                        cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebit"] - 1], startContractor, vsS[HeaderColumn["EndDebit"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1], startContractor, vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1], startContractor, vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1], startContractor, vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCredit"] - 1], startContractor, vsS[HeaderColumn["EndCredit"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1], startContractor, vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1], startContractor, vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1], startContractor, vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1], currentPosition - 1, "SUM");

                        cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumUSD"] - 1], startContractor, vsS[HeaderColumn["DebitSumUSD"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumEUR"] - 1], startContractor, vsS[HeaderColumn["DebitSumEUR"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumRUB"] - 1], startContractor, vsS[HeaderColumn["DebitSumRUB"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumUSD"] - 1], startContractor, vsS[HeaderColumn["CreditSumUSD"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumEUR"] - 1], startContractor, vsS[HeaderColumn["CreditSumEUR"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumRUB"] - 1], startContractor, vsS[HeaderColumn["CreditSumRUB"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CalcPrice"] - 1], startContractor, vsS[HeaderColumn["CalcPrice"] - 1], currentPosition - 1, "SUM");
                        cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["BankPrice"] - 1], startContractor, vsS[HeaderColumn["BankPrice"] - 1], currentPosition - 1, "SUM");

                        cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].Font.Bold = true;

                        cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].Font.Bold = true;

                        cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Font.Bold = true;
                        cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Font.Bold = true;
                        
                        if (DebitAcc.Count > 0)
                        {
                            foreach (var dict in DebitAcc)
                            {
                                sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                                cells[vsS[sumPosition - 1] + currentPosition].Font.Bold = true;
                            }
                        }
                        if (CreditAcc.Count > 0)
                        {
                            foreach (var dict in CreditAcc)
                            {
                                sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                                cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                                cells[vsS[sumPosition - 1] + currentPosition].Font.Bold = true;
                            }
                        }
                        currentPosition++;
                        startContractor = currentPosition;

                        #endregion
                    }
                    cells[vsS[HeaderColumn["PartnerSrn"] - 1] + currentPosition].Value = reportTable.Rows[i]["PartnerSrn"];
                    cells[vsS[HeaderColumn["PartnerName"] - 1] + currentPosition].Value = reportTable.Rows[i]["PartnerName"];
                    cells[vsS[HeaderColumn["CurrencyName"] - 1] + currentPosition].Value = reportTable.Rows[i]["CurrencyName"];
                    cells[vsS[HeaderColumn["CurrencyName"] - 1] + currentPosition].HorizontalAlignment = HAlign.Center;
                    //
                    if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["StartDebitCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebitCurrency"];
                    cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebit"];
                    if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["StartCreditCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCreditCurrency"];
                    cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCredit"];
                    //
                    if ((int?)reportTable.Rows[i]["FlagDebitCredit"] > 0)
                    {
                        cells[vsS[HeaderColumn["CalcDocument"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["CalcDocument"] - 1] + currentPosition].HorizontalAlignment = HAlign.Right;
                        cells[vsS[HeaderColumn["Comment"] - 1] + currentPosition].Value = reportTable.Rows[i]["Comment"];
                        cells[vsS[HeaderColumn["Comment"] - 1] + currentPosition].WrapText = false;
                        cells[vsS[HeaderColumn["CalcDate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["CalcRate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];

                        if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["DebitSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    else if ((int?)reportTable.Rows[i]["FlagDebitCredit"] < 0)
                    {
                        cells[vsS[HeaderColumn["BankNum"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["BankNum"] - 1] + currentPosition].HorizontalAlignment = HAlign.Right;
                        cells[vsS[HeaderColumn["Purpose"] - 1] + currentPosition].Value = reportTable.Rows[i]["Purpose"];
                        cells[vsS[HeaderColumn["Purpose"] - 1] + currentPosition].WrapText = false;
                        cells[vsS[HeaderColumn["BankDate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["BankRate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];

                        if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["CreditSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    if ((int)reportTable.Rows[i]["AccountId"] > 0)
                    {
                        account = ((int?)reportTable.Rows[i]["FlagDebitCredit"] > 0)
                            ? "DebitAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString()
                            : "CreditAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString();
                        cells[vsS[HeaderColumn[account] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                    //

                    if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["EndDebitCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebitCurrency"];
                    cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebit"];
                    if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["EndCreditCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCreditCurrency"];
                    cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCredit"];

                    startDebit += (decimal)reportTable.Rows[i]["StartDebit"];
                    startDebitCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["StartDebitCurrency"] : 0;
                    startDebitCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["StartDebitCurrency"] : 0;
                    startDebitCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["StartDebitCurrency"] : 0;
                    
                    startCredit += (decimal)reportTable.Rows[i]["StartCredit"];
                    startCreditCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["StartCreditCurrency"] : 0;
                    startCreditCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["StartCreditCurrency"] : 0;
                    startCreditCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["StartCreditCurrency"] : 0;
                    
                    endDebit += (decimal)reportTable.Rows[i]["EndDebit"];
                    endDebitCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["EndDebitCurrency"] : 0;
                    endDebitCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["EndDebitCurrency"] : 0;
                    endDebitCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["EndDebitCurrency"] : 0;
                    
                    endCredit += (decimal)reportTable.Rows[i]["EndCredit"];
                    endCreditCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["EndCreditCurrency"] : 0;
                    endCreditCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["EndCreditCurrency"] : 0;
                    endCreditCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["EndCreditCurrency"] : 0;
                    
                }
                else
                {
                    if (currencyId != (int)reportTable.Rows[i]["CurrencyId"])
                    {
                        currencyId = (int)reportTable.Rows[i]["CurrencyId"];

                        cells[vsS[HeaderColumn["CurrencyName"] - 1] + currentPosition].Value = reportTable.Rows[i]["CurrencyName"];
                        cells[vsS[HeaderColumn["CurrencyName"] - 1] + currentPosition].HorizontalAlignment = HAlign.Center;
                        //
                        if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["StartDebitCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebitCurrency"];
                        cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebit"];
                        if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["StartCreditCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCreditCurrency"];
                        cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCredit"];

                        if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["EndDebitCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebitCurrency"];
                        cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebit"];
                        if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["EndCreditCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCreditCurrency"];
                        cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCredit"];

                        startDebit += (decimal)reportTable.Rows[i]["StartDebit"];
                        startDebitCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["StartDebitCurrency"] : 0;
                        startDebitCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["StartDebitCurrency"] : 0;
                        startDebitCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["StartDebitCurrency"] : 0;

                        startCredit += (decimal)reportTable.Rows[i]["StartCredit"];
                        startCreditCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["StartCreditCurrency"] : 0;
                        startCreditCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["StartCreditCurrency"] : 0;
                        startCreditCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["StartCreditCurrency"] : 0;

                        endDebit += (decimal)reportTable.Rows[i]["EndDebit"];
                        endDebitCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["EndDebitCurrency"] : 0;
                        endDebitCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["EndDebitCurrency"] : 0;
                        endDebitCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["EndDebitCurrency"] : 0;

                        endCredit += (decimal)reportTable.Rows[i]["EndCredit"];
                        endCreditCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["EndCreditCurrency"] : 0;
                        endCreditCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["EndCreditCurrency"] : 0;
                        endCreditCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["EndCreditCurrency"] : 0;
                    
                    }
                    if ((int?)reportTable.Rows[i]["FlagDebitCredit"] > 0)
                    {
                        cells[vsS[HeaderColumn["CalcDocument"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["Comment"] - 1] + currentPosition].Value = reportTable.Rows[i]["Comment"];
                        cells[vsS[HeaderColumn["Comment"] - 1] + currentPosition].WrapText = false;
                        cells[vsS[HeaderColumn["CalcDate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["CalcRate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];

                        if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["DebitSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    else if ((int?)reportTable.Rows[i]["FlagDebitCredit"] < 0)
                    {
                        cells[vsS[HeaderColumn["BankNum"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Document"];
                        cells[vsS[HeaderColumn["Purpose"] - 1] + currentPosition].Value = reportTable.Rows[i]["Purpose"];
                        cells[vsS[HeaderColumn["Purpose"] - 1] + currentPosition].WrapText = false;
                        cells[vsS[HeaderColumn["BankDate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Payment_Date"];
                        cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                        cells[vsS[HeaderColumn["BankRate"] - 1] + currentPosition].Value = reportTable.Rows[i]["Rate"];

                        if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                            cells[vsS[HeaderColumn["CreditSum" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPriceCurrency"];
                    }
                    if ((int)reportTable.Rows[i]["AccountId"] > 0)
                    {
                        account = ((int?)reportTable.Rows[i]["FlagDebitCredit"] > 0)
                            ? "DebitAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString()
                            : "CreditAccount" + ((int)reportTable.Rows[i]["AccountId"]).ToString();
                        cells[vsS[HeaderColumn[account] - 1] + currentPosition].Value = reportTable.Rows[i]["PeriodPrice"];
                    }
                }
                currentPosition++;
            }

            #endregion

            #region Finally step output

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["DebitSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumUSD"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumEUR"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditSumRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["CalcPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CalcPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;
            cells[vsS[HeaderColumn["BankPrice"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["BankPrice"] - 1] + (currentPosition - 1)].Interior.Color = Color.Azure;

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;

            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebit"] - 1], startContractor, vsS[HeaderColumn["StartDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1], startContractor, vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1], startContractor, vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1], startContractor, vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCredit"] - 1], startContractor, vsS[HeaderColumn["StartCredit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1], startContractor, vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1], startContractor, vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1], startContractor, vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1], currentPosition - 1, "SUM");

            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebit"] - 1], startContractor, vsS[HeaderColumn["EndDebit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1], startContractor, vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1], startContractor, vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1], startContractor, vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCredit"] - 1], startContractor, vsS[HeaderColumn["EndCredit"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1], startContractor, vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1], startContractor, vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1], startContractor, vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1], currentPosition - 1, "SUM");

            cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumUSD"] - 1], startContractor, vsS[HeaderColumn["DebitSumUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumEUR"] - 1], startContractor, vsS[HeaderColumn["DebitSumEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["DebitSumRUB"] - 1], startContractor, vsS[HeaderColumn["DebitSumRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumUSD"] - 1], startContractor, vsS[HeaderColumn["CreditSumUSD"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumEUR"] - 1], startContractor, vsS[HeaderColumn["CreditSumEUR"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CreditSumRUB"] - 1], startContractor, vsS[HeaderColumn["CreditSumRUB"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["CalcPrice"] - 1], startContractor, vsS[HeaderColumn["CalcPrice"] - 1], currentPosition - 1, "SUM");
            cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Formula = SetFormula(vsS[HeaderColumn["BankPrice"] - 1], startContractor, vsS[HeaderColumn["BankPrice"] - 1], currentPosition - 1, "SUM");

            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].Font.Bold = true;

            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].Font.Bold = true;

            cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Font.Bold = true;
            cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Font.Bold = true;

            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                    cells[vsS[sumPosition - 1] + currentPosition].Font.Bold = true;
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Formula = SetFormula(vsS[sumPosition - 1], startContractor, vsS[sumPosition - 1], currentPosition - 1, "SUM");
                    cells[vsS[sumPosition - 1] + currentPosition].Font.Bold = true;
                }
            }
            cells["A" + (startPosition + 3) + ":" + vsS[startHeaderPosition - 1] + (currentPosition + 1)].Borders.LineStyle = LineStyle.Continous;
            currentPosition++;

            #endregion

            #region Result summary

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.LightGreen;
            cells["B" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["B" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Font.Bold = true;
            cells["C" + currentPosition].Value = "Всього";
            cells["C" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["D" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells["D" + (startPosition + 3) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";

            if (DebitAcc.Count > 0)
                cells[vsS[HeaderColumn["DebitAccount" + DebitAcc.Keys.First()] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            if (CreditAcc.Count > 0)
                cells[vsS[HeaderColumn["CreditAccount" + CreditAcc.Keys.First()] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";

            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = startDebit;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = endDebit;
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = startCredit;
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = endCredit;
            cells[vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1] + currentPosition].Value = startDebitCurrencyUSD;
            cells[vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1] + currentPosition].Value = startDebitCurrencyEUR;
            cells[vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1] + currentPosition].Value = startDebitCurrencyRUB;
            cells[vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1] + currentPosition].Value = endDebitCurrencyUSD;
            cells[vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1] + currentPosition].Value = endDebitCurrencyEUR;
            cells[vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1] + currentPosition].Value = endDebitCurrencyRUB;
            cells[vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1] + currentPosition].Value = startCreditCurrencyUSD;
            cells[vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1] + currentPosition].Value = startCreditCurrencyEUR;
            cells[vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].Value = startCreditCurrencyRUB;
            cells[vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1] + currentPosition].Value = endCreditCurrencyUSD;
            cells[vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1] + currentPosition].Value = endCreditCurrencyEUR;
            cells[vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].Value = endCreditCurrencyRUB;

            cells[vsS[HeaderColumn["CalcPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") > 0).Sum(x => x.Field<decimal?>("PeriodPrice"));
            cells[vsS[HeaderColumn["BankPrice"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") < 0).Sum(x => x.Field<decimal?>("PeriodPrice"));
            
            cells[vsS[HeaderColumn["DebitSumUSD"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") > 0 && w.Field<int?>("CurrencyId") == 3).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["DebitSumEUR"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") > 0 && w.Field<int?>("CurrencyId") == 2).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["DebitSumRUB"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") > 0 && w.Field<int?>("CurrencyId") == 4).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["CreditSumUSD"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") < 0 && w.Field<int?>("CurrencyId") == 3).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["CreditSumEUR"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") < 0 && w.Field<int?>("CurrencyId") == 2).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));
            cells[vsS[HeaderColumn["CreditSumRUB"] - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") < 0 && w.Field<int?>("CurrencyId") == 4).Sum(x => x.Field<decimal?>("PeriodPriceCurrency"));

            if (DebitAcc.Count > 0)
            {
                foreach (var dict in DebitAcc)
                {
                    sumPosition = HeaderColumn["DebitAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") > 0 && w.Field<int>("AccountId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }
            if (CreditAcc.Count > 0)
            {
                foreach (var dict in CreditAcc)
                {
                    sumPosition = HeaderColumn["CreditAccount" + dict.Key];
                    cells[vsS[sumPosition - 1] + currentPosition].Value = reportTable.AsEnumerable().Where(w => w.Field<int?>("FlagDebitCredit") < 0 && w.Field<int>("AccountId") == dict.Key).Sum(x => x.Field<decimal?>("PeriodPrice"));
                }
            }

            PrintSignatures(cells, currentPosition + 2);

            #endregion

            #region Report caption and frore rows

            cells["A" + captionPosition + ":" + vsS[startHeaderPosition - 1] + captionPosition].Merge();
            cells["A" + captionPosition].Value = String.Format("Відомість аналитичного обліку розрахунків з покупцями та замовниками(до рахунку {0}) з {1} по {2} ", calcAccount, StartDate, EndDate);
            cells["A" + captionPosition].Font.Bold = true;
            cells["A" + captionPosition].VerticalAlignment = VAlign.Center;
            cells["A" + captionPosition].HorizontalAlignment = HAlign.Center;

            worksheet.WindowInfo.ScrollRow = 0;
            worksheet.WindowInfo.SplitRows = startPosition + 2;

            worksheet.WindowInfo.FreezePanes = true;

            #endregion

            try
            {
                string documentAddresName = GeneratedReportsDir +
                                            String.Format("ОСВ по замовникам (до рахунку {0}) з {1} по {2} ", calcAccount, StartDate, EndDate) + ".xls";
                workbook.SaveAs(documentAddresName, FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + documentAddresName + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        public void CalcWithBuyersReportShort(DataTable reportTable, string StartDate, string EndDate, string calcAccount, short purposeAccountId)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SpreadsheetGear.IWorkbook workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            Dictionary<string, byte> HeaderColumn = new Dictionary<string, byte>();

            int captionPosition = 6;
            int startPosition = captionPosition + 1;
            int currentPosition = startPosition + 3;
            byte startHeaderPosition = 1;

            #region Generate report header

            HeaderColumn.Add("PartnerSrn", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Код/таб.номер";

            startHeaderPosition++;

            HeaderColumn.Add("PartnerName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[vsS[startHeaderPosition] + (startPosition + 1) + ":" + vsS[startHeaderPosition] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на початок періоду";

            HeaderColumn.Add("StartDebit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            startHeaderPosition++;

            HeaderColumn.Add("StartCredit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Кредит";

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[vsS[startHeaderPosition] + (startPosition + 1) + ":" + vsS[startHeaderPosition] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Обороти за період";

            HeaderColumn.Add("DebitPeriod", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            startHeaderPosition++;

            HeaderColumn.Add("CreditPeriod", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Кредит";

            //cells[vsS[HeaderColumn["DebitPeriod"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;
            
            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[vsS[startHeaderPosition] + (startPosition + 1) + ":" + vsS[startHeaderPosition] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на кінець періоду";

            HeaderColumn.Add("EndDebit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            startHeaderPosition++;

            HeaderColumn.Add("EndCredit", startHeaderPosition);
            cells[startPosition, startHeaderPosition - 1].Value = "Кредит";

            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].WrapText = true;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].VerticalAlignment = VAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].HorizontalAlignment = HAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Font.Bold = true;
            cells["A:A"].ColumnWidth = 15;
            cells["B:B"].ColumnWidth = 70;
            cells["C:C"].ColumnWidth = 15;
            cells["C" + ":" + vsS[startHeaderPosition - 1]].ColumnWidth = 15;

            #endregion

            #region Loop body

            #region Loop variables

            int contractorId = 0;
            int employeesId = 0;
            string account = "";
            int startContractor = currentPosition;
            int sumPosition = 0;

            decimal startDebit = 0, startCredit = 0, endDebit = 0, endCredit = 0, debitPeriod=0, creditPeriod=0;

            #endregion


            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (contractorId != (int)reportTable.Rows[i]["ContractorsId"] || employeesId != (int)reportTable.Rows[i]["EmployeesId"])
                {
                    contractorId = (int)reportTable.Rows[i]["ContractorsId"];
                    employeesId = (int)reportTable.Rows[i]["EmployeesId"];
                }

                cells[vsS[HeaderColumn["PartnerSrn"] - 1] + currentPosition].Value = reportTable.Rows[i]["PartnerSrn"];
                cells[vsS[HeaderColumn["PartnerName"] - 1] + currentPosition].Value = reportTable.Rows[i]["PartnerName"];

                cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebit"];
                cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCredit"];

                cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebit"];
                cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCredit"];

                cells[vsS[HeaderColumn["DebitPeriod"] - 1] + currentPosition].Value = reportTable.Rows[i]["DebitPeriod"];
                cells[vsS[HeaderColumn["CreditPeriod"] - 1] + currentPosition].Value = reportTable.Rows[i]["CreditPeriod"];


                startDebit += (decimal)reportTable.Rows[i]["StartDebit"];
                startCredit += (decimal)reportTable.Rows[i]["StartCredit"];
                endDebit += (decimal)reportTable.Rows[i]["EndDebit"];
                endCredit += (decimal)reportTable.Rows[i]["EndCredit"];
                debitPeriod += (decimal)reportTable.Rows[i]["DebitPeriod"];
                creditPeriod += (decimal)reportTable.Rows[i]["CreditPeriod"];

                currentPosition++;
            }

            #endregion

            #region Finally step output

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            //cells[vsS[HeaderColumn["DebitPeriod"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["CreditPeriod"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;

            //cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.Bisque;
            
            cells["A" + (startPosition + 3) + ":" + vsS[startHeaderPosition - 1] + currentPosition].Borders.LineStyle = LineStyle.Continous;

            #endregion

            #region Result summary

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.LightGreen;
            cells["B" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["B" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Font.Bold = true;
            cells["B" + currentPosition].Value = "Всього";
            cells["B" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["C" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells["C" + (startPosition + 3) + ":" + vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["DebitPeriod"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["CreditPeriod"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";

            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = startDebit;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = endDebit;
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = startCredit;
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = endCredit;

            cells[vsS[HeaderColumn["DebitPeriod"] - 1] + currentPosition].Value = debitPeriod; 
            cells[vsS[HeaderColumn["CreditPeriod"] - 1] + currentPosition].Value = creditPeriod;

            PrintSignatures(cells, currentPosition + 2);

            #endregion

            #region Report caption and froze row

            cells["A" + captionPosition + ":" + vsS[startHeaderPosition - 1] + captionPosition].Merge();
            cells["A" + captionPosition].Value = String.Format("Відомість аналитичного обліку розрахунків з покупцями та замовниками (скорочено)(до рахунку {0}) з {1} по {2} ", calcAccount, StartDate, EndDate);
            cells["A" + captionPosition].Font.Bold = true;
            cells["A" + captionPosition].VerticalAlignment = VAlign.Center;
            cells["A" + captionPosition].HorizontalAlignment = HAlign.Center;

            worksheet.WindowInfo.ScrollRow = 0;
            worksheet.WindowInfo.SplitRows = startPosition + 2;

            worksheet.WindowInfo.FreezePanes = true;

            #endregion

            try
            {
                string documentAddresName = GeneratedReportsDir +
                                            String.Format("ОСВ по замовникам (скорочено)(до рахунку {0}) з {1} по {2} ", calcAccount, StartDate, EndDate) + ".xls";
                workbook.SaveAs(documentAddresName, FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + documentAddresName + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        public void CalcWithBuyersReportShortCurrency(DataTable reportTable, string StartDate, string EndDate, string calcAccount, short purposeAccountId)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SpreadsheetGear.IWorkbook workbook = Factory.GetWorkbook(TemplatesDir + "TemplateWithStamp.xls");
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;


            Dictionary<string, byte> HeaderColumn = new Dictionary<string, byte>();

            int captionPosition = 6;
            int startPosition = captionPosition + 1; 
            int currentPosition = startPosition + 3;
            byte startHeaderPosition = 1;

            #region Generate report header
            
            HeaderColumn.Add("PartnerSrn", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Код/таб.номер";

            startHeaderPosition++;

            HeaderColumn.Add("PartnerName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування";

            startHeaderPosition++;

            HeaderColumn.Add("CurrencyName", startHeaderPosition);
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Найменування валюти";

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 6] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 2] + (startPosition + 1)].Merge();
            cells[vsS[startHeaderPosition + 3] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 6] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на початок періоду";
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            cells[startPosition, startHeaderPosition + 3].Value = "Кредит";

            HeaderColumn.Add("StartDebit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("StartDebitCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("StartDebitCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("StartDebitCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";
            startHeaderPosition++;

            HeaderColumn.Add("StartCredit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("StartCreditCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("StartCreditCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("StartCreditCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            startHeaderPosition++;

            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 6] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 2] + (startPosition + 1)].Merge();
            cells[vsS[startHeaderPosition + 3] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 6] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Обороти за період";
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            cells[startPosition, startHeaderPosition + 3].Value = "Кредит";

            HeaderColumn.Add("DebitPeriod", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("DebitPeriodCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("DebitPeriodCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("DebitPeriodCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";
            startHeaderPosition++;

            HeaderColumn.Add("CreditPeriod", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("CreditPeriodCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("CreditPeriodCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("CreditPeriodCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            //cells[vsS[HeaderColumn["DebitPeriod"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            startHeaderPosition++;
            
            cells[vsS[startHeaderPosition - 1] + startPosition + ":" + vsS[startHeaderPosition + 6] + startPosition].Merge();
            cells[vsS[startHeaderPosition - 1] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 2] + (startPosition + 1)].Merge();
            cells[vsS[startHeaderPosition + 3] + (startPosition + 1) + ":" + vsS[startHeaderPosition + 6] + (startPosition + 1)].Merge();
            cells[startPosition - 1, startHeaderPosition - 1].Value = "Сальдо на конець періоду";
            cells[startPosition, startHeaderPosition - 1].Value = "Дебет";
            cells[startPosition, startHeaderPosition + 3].Value = "Кредит";

            HeaderColumn.Add("EndDebit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("EndDebitCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("EndDebitCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("EndDebitCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";
            startHeaderPosition++;

            HeaderColumn.Add("EndCredit", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "Гривня";
            startHeaderPosition++;

            HeaderColumn.Add("EndCreditCurrencyUSD", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "USD";
            startHeaderPosition++;
            HeaderColumn.Add("EndCreditCurrencyEUR", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "EUR";
            startHeaderPosition++;
            HeaderColumn.Add("EndCreditCurrencyRUB", startHeaderPosition);
            cells[startPosition + 1, startHeaderPosition - 1].Value = "RUB";

            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition) + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Interior.Color = Color.Beige;

            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Borders.LineStyle = LineStyle.Continous;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].WrapText = true;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].VerticalAlignment = VAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].HorizontalAlignment = HAlign.Center;
            cells["A" + startPosition + ":" + vsS[startHeaderPosition - 1] + (startPosition + 2)].Font.Bold = true;

            cells["A:A"].ColumnWidth = 15;
            cells["B:B"].ColumnWidth = 70;
            cells["C:C"].ColumnWidth = 15;
            cells["D" + ":" + vsS[startHeaderPosition - 1]].ColumnWidth = 15;

            #endregion

            #region Loop body

            #region Loop variables

            int contractorId = 0;
            int employeesId = 0;
            string account = "";
            int startContractor = currentPosition;
            int sumPosition = 0;

            decimal startDebit = 0, startDebitCurrencyRUB = 0, startDebitCurrencyEUR = 0, startDebitCurrencyUSD = 0,
                    startCredit = 0, startCreditCurrencyRUB = 0, startCreditCurrencyEUR = 0, startCreditCurrencyUSD = 0,
                    endDebit = 0, endDebitCurrencyRUB = 0, endDebitCurrencyEUR = 0, endDebitCurrencyUSD = 0,
                    endCredit = 0, endCreditCurrencyRUB = 0, endCreditCurrencyEUR = 0, endCreditCurrencyUSD = 0,
                    debitPeriod=0, debitPeriodCurrencyRUB = 0, debitPeriodCurrencyEUR = 0, debitPeriodCurrencyUSD = 0,
                    creditPeriod=0,  creditPeriodCurrencyRUB = 0,  creditPeriodCurrencyEUR = 0,  creditPeriodCurrencyUSD = 0;

            #endregion

            for (int i = 0; i < reportTable.Rows.Count; i++)
            {
                if (contractorId != (int)reportTable.Rows[i]["ContractorsId"] || employeesId != (int)reportTable.Rows[i]["EmployeesId"])
                {
                    contractorId = (int)reportTable.Rows[i]["ContractorsId"];
                    employeesId = (int)reportTable.Rows[i]["EmployeesId"];
                }

                    cells[vsS[HeaderColumn["PartnerSrn"] - 1] + currentPosition].Value = reportTable.Rows[i]["PartnerSrn"];
                    cells[vsS[HeaderColumn["PartnerName"] - 1] + currentPosition].Value = reportTable.Rows[i]["PartnerName"];
                    cells[vsS[HeaderColumn["CurrencyName"] - 1] + currentPosition].Value = reportTable.Rows[i]["CurrencyName"];
                    cells[vsS[HeaderColumn["CurrencyName"] - 1] + currentPosition].HorizontalAlignment = HAlign.Center;
                    //
                    if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["StartDebitCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebitCurrency"];
                    cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartDebit"];
                    if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["StartCreditCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCreditCurrency"];
                    cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["StartCredit"];

                    if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["DebitPeriodCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["DebitPeriodCurrency"];
                    cells[vsS[HeaderColumn["DebitPeriod"] - 1] + currentPosition].Value = reportTable.Rows[i]["DebitPeriod"];
                    if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["CreditPeriodCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["CreditPeriodCurrency"];
                    cells[vsS[HeaderColumn["CreditPeriod"] - 1] + currentPosition].Value = reportTable.Rows[i]["CreditPeriod"];
                   

                    if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["EndDebitCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebitCurrency"];
                    cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndDebit"];
                    if ((int)reportTable.Rows[i]["CurrencyId"] > 1)
                        cells[vsS[HeaderColumn["EndCreditCurrency" + (string)reportTable.Rows[i]["CurrencyName"]] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCreditCurrency"];
                    cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = reportTable.Rows[i]["EndCredit"];

                    startDebit += (decimal)reportTable.Rows[i]["StartDebit"];
                    startDebitCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["StartDebitCurrency"] : 0;
                    startDebitCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["StartDebitCurrency"] : 0;
                    startDebitCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["StartDebitCurrency"] : 0;

                    startCredit += (decimal)reportTable.Rows[i]["StartCredit"];
                    startCreditCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["StartCreditCurrency"] : 0;
                    startCreditCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["StartCreditCurrency"] : 0;
                    startCreditCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["StartCreditCurrency"] : 0;

                    debitPeriod += (decimal)reportTable.Rows[i]["DebitPeriod"];
                    debitPeriodCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["DebitPeriodCurrency"] : 0;
                    debitPeriodCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["DebitPeriodCurrency"] : 0;
                    debitPeriodCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["DebitPeriodCurrency"] : 0;

                    creditPeriod += (decimal)reportTable.Rows[i]["CreditPeriod"];
                    creditPeriodCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["CreditPeriodCurrency"] : 0;
                    creditPeriodCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["CreditPeriodCurrency"] : 0;
                    creditPeriodCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["CreditPeriodCurrency"] : 0;

                    endDebit += (decimal)reportTable.Rows[i]["EndDebit"];
                    endDebitCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["EndDebitCurrency"] : 0;
                    endDebitCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["EndDebitCurrency"] : 0;
                    endDebitCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["EndDebitCurrency"] : 0;

                    endCredit += (decimal)reportTable.Rows[i]["EndCredit"];
                    endCreditCurrencyRUB += ((string)reportTable.Rows[i]["CurrencyName"] == "RUB") ? (decimal)reportTable.Rows[i]["EndCreditCurrency"] : 0;
                    endCreditCurrencyEUR += ((string)reportTable.Rows[i]["CurrencyName"] == "EUR") ? (decimal)reportTable.Rows[i]["EndCreditCurrency"] : 0;
                    endCreditCurrencyUSD += ((string)reportTable.Rows[i]["CurrencyName"] == "USD") ? (decimal)reportTable.Rows[i]["EndCreditCurrency"] : 0;

               
                currentPosition++;
            }

            #endregion

            #region Finally step output

            cells[vsS[HeaderColumn["StartDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startContractor) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + (currentPosition - 1)].Interior.Color = Color.Beige;
           
            cells["A" + (startPosition + 3) + ":" + vsS[startHeaderPosition - 1] + currentPosition].Borders.LineStyle = LineStyle.Continous;

            #endregion

            #region Result summary

            cells["A" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Interior.Color = Color.LightGreen;
            cells["B" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["B" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].Font.Bold = true;
            cells["C" + currentPosition].Value = "Всього";
            cells["C" + currentPosition].HorizontalAlignment = HAlign.Right;
            cells["D" + currentPosition + ":" + vsS[startHeaderPosition - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells["D" + (startPosition + 3) + ":" + vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["EndDebit"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";
            cells[vsS[HeaderColumn["DebitPeriod"] - 1] + (startPosition + 3) + ":" + vsS[HeaderColumn["CreditPeriodCurrencyRUB"] - 1] + currentPosition].NumberFormat = "### ### ##0.00";

            cells[vsS[HeaderColumn["StartDebit"] - 1] + currentPosition].Value = startDebit;
            cells[vsS[HeaderColumn["EndDebit"] - 1] + currentPosition].Value = endDebit;
            cells[vsS[HeaderColumn["StartCredit"] - 1] + currentPosition].Value = startCredit;
            cells[vsS[HeaderColumn["EndCredit"] - 1] + currentPosition].Value = endCredit;
            cells[vsS[HeaderColumn["StartDebitCurrencyUSD"] - 1] + currentPosition].Value = startDebitCurrencyUSD;
            cells[vsS[HeaderColumn["StartDebitCurrencyEUR"] - 1] + currentPosition].Value = startDebitCurrencyEUR;
            cells[vsS[HeaderColumn["StartDebitCurrencyRUB"] - 1] + currentPosition].Value = startDebitCurrencyRUB;
            cells[vsS[HeaderColumn["EndDebitCurrencyUSD"] - 1] + currentPosition].Value = endDebitCurrencyUSD;
            cells[vsS[HeaderColumn["EndDebitCurrencyEUR"] - 1] + currentPosition].Value = endDebitCurrencyEUR;
            cells[vsS[HeaderColumn["EndDebitCurrencyRUB"] - 1] + currentPosition].Value = endDebitCurrencyRUB;

            cells[vsS[HeaderColumn["CreditPeriod"] - 1] + currentPosition].Value = creditPeriod;
            cells[vsS[HeaderColumn["DebitPeriod"] - 1] + currentPosition].Value =debitPeriod ;
            cells[vsS[HeaderColumn["DebitPeriodCurrencyUSD"] - 1] + currentPosition].Value = startDebitCurrencyUSD;
            cells[vsS[HeaderColumn["DebitPeriodCurrencyEUR"] - 1] + currentPosition].Value = startDebitCurrencyEUR;
            cells[vsS[HeaderColumn["DebitPeriodCurrencyRUB"] - 1] + currentPosition].Value = startDebitCurrencyRUB;
            cells[vsS[HeaderColumn["CreditPeriodCurrencyUSD"] - 1] + currentPosition].Value = endDebitCurrencyUSD;
            cells[vsS[HeaderColumn["CreditPeriodCurrencyEUR"] - 1] + currentPosition].Value = endDebitCurrencyEUR;
            cells[vsS[HeaderColumn["CreditPeriodCurrencyRUB"] - 1] + currentPosition].Value = endDebitCurrencyRUB;

            cells[vsS[HeaderColumn["StartCreditCurrencyUSD"] - 1] + currentPosition].Value = startCreditCurrencyUSD;
            cells[vsS[HeaderColumn["StartCreditCurrencyEUR"] - 1] + currentPosition].Value = startCreditCurrencyEUR;
            cells[vsS[HeaderColumn["StartCreditCurrencyRUB"] - 1] + currentPosition].Value = startCreditCurrencyRUB;
            cells[vsS[HeaderColumn["EndCreditCurrencyUSD"] - 1] + currentPosition].Value = endCreditCurrencyUSD;
            cells[vsS[HeaderColumn["EndCreditCurrencyEUR"] - 1] + currentPosition].Value = endCreditCurrencyEUR;
            cells[vsS[HeaderColumn["EndCreditCurrencyRUB"] - 1] + currentPosition].Value = endCreditCurrencyRUB;


            PrintSignatures(cells, currentPosition + 2);
           

           #endregion

            #region Report caption and froze rows

            cells["A" + captionPosition + ":" + vsS[startHeaderPosition - 1] + captionPosition].Merge();
            cells["A" + captionPosition].Value = String.Format("Відомість аналитичного обліку розрахунків з покупцями та замовниками (скорочено)(до рахунку {0}) з {1} по {2} ", calcAccount, StartDate, EndDate);
            cells["A" + captionPosition].Font.Bold = true;
            cells["A" + captionPosition].VerticalAlignment = VAlign.Center;
            cells["A" + captionPosition].HorizontalAlignment = HAlign.Center;

            worksheet.WindowInfo.ScrollRow = 0;
            worksheet.WindowInfo.SplitRows = startPosition + 2;

            worksheet.WindowInfo.FreezePanes = true;

            #endregion

            try
            {
                string documentAddresName = GeneratedReportsDir +
                                            String.Format("ОСВ по замовникам (скорочено)(до рахунку {0}) з {1} по {2} ", calcAccount, StartDate, EndDate) + ".xls";
                workbook.SaveAs(documentAddresName, FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + documentAddresName + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдена програма Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        public void ExportCalcWithBuyersList(DataTable SourseDataTable, string startDate, string endDate)
        {
            if (SourseDataTable.Rows.Count == 0)
            {
                MessageBox.Show("За вибраний період немає даних!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Workbook = Factory.GetWorkbook(TemplatesDir + "PaymentsList.xls");
            var Worksheet = Workbook.Worksheets[0];
            var cells = Worksheet.Cells;

            //Var
            int captionPosition = 6;
            int startRowIndex = captionPosition + 1;
            int activRowIndex = startRowIndex + 2;
            int sumColIndex = 14;
            string nameLastCol = vsS[sumColIndex - 1];

            //Head
            cells["A" + captionPosition].Value = "Звіт по розрахункам з покупцями за період з " + startDate + " по " + endDate;
            cells["F" + (startRowIndex + 2)].Value = "Балансовий рахунок";
            cells["N" + (startRowIndex + 2)].Value = "Коментар";
            //Body
            foreach (DataRow line in SourseDataTable.Rows)
            {
                activRowIndex++;

                cells[String.Format("{0}{1}", vsS[0], activRowIndex)].Value = line["Contractor_Srn"];
                cells[String.Format("{0}{1}", vsS[1], activRowIndex)].Value = line["Contractor_Name"];
                cells[String.Format("{0}{1}", vsS[2], activRowIndex)].Value = line["OrderNumber"];
                cells[String.Format("{0}{1}", vsS[3], activRowIndex)].Value = line["DocumentDate"];
                cells[String.Format("{0}{1}", vsS[4], activRowIndex)].Value = line["DocumentName"];
                cells[String.Format("{0}{1}", vsS[5], activRowIndex)].Value = line["BalanceNum"];
                cells[String.Format("{0}{1}", vsS[6], activRowIndex)].Value = line["PurposeNum"];
                cells[String.Format("{0}{1}", vsS[7], activRowIndex)].Value = line["PaymentDebet"];
                cells[String.Format("{0}{1}", vsS[8], activRowIndex)].Value = line["PaymentDebetCurrency"];
                cells[String.Format("{0}{1}", vsS[9], activRowIndex)].Value = line["PaymentCredit"];
                cells[String.Format("{0}{1}", vsS[10], activRowIndex)].Value = line["PaymentCreditCurrency"];
                cells[String.Format("{0}{1}", vsS[11], activRowIndex)].Value = line["CurrencyName"];
                cells[String.Format("{0}{1}", vsS[12], activRowIndex)].Value = line["Rate"];
                cells[String.Format("{0}{1}", vsS[13], activRowIndex)].Value = line["Comment"];
            }

            activRowIndex++;

            cells[String.Format("{0}{1}", vsS[0], activRowIndex)].Value = "Всього:";
            cells[String.Format("A{0}:{1}{2}", activRowIndex, nameLastCol, activRowIndex)].Interior.Color = Color.LightGreen;
            cells[String.Format("A{0}:{1}{2}", activRowIndex, nameLastCol, activRowIndex)].Font.Bold = true;
            cells[String.Format("B{0}:{1}{2}", activRowIndex, nameLastCol, activRowIndex)].NumberFormat = "### ### ##0.00";
            cells[String.Format("{0}{1}", vsS[7], activRowIndex)].Value = SourseDataTable.AsEnumerable().Where(w => w["PaymentDebet"] != DBNull.Value).Sum(s => s.Field<decimal>("PaymentDebet"));
            cells[String.Format("{0}{1}", vsS[8], activRowIndex)].Value = SourseDataTable.AsEnumerable().Where(w => w["PaymentDebetCurrency"] != DBNull.Value).Sum(s => s.Field<decimal>("PaymentDebetCurrency"));
            cells[String.Format("{0}{1}", vsS[9], activRowIndex)].Value = SourseDataTable.AsEnumerable().Where(w => w["PaymentCredit"] != DBNull.Value).Sum(s => s.Field<decimal>("PaymentCredit"));
            cells[String.Format("{0}{1}", vsS[10], activRowIndex)].Value = SourseDataTable.AsEnumerable().Where(w => w["PaymentCreditCurrency"] != DBNull.Value).Sum(s => s.Field<decimal>("PaymentCreditCurrency"));


            cells[String.Format("A{0}:{1}{2}", startRowIndex, nameLastCol, activRowIndex)].Borders.LineStyle = LineStyle.Continous;

            PrintSignatures(cells, activRowIndex + 3);

            try
            {
                Workbook.SaveAs(GeneratedReportsDir + "Звіт по розрахункам з покупцями за період з " + startDate + " по " + endDate + ".xls", FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + GeneratedReportsDir + "Звіт по розрахункам з покупцями за період з " + startDate + " по " + endDate + ".xls" + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ вже відкритий!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдено програму Microsoft Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        #endregion//----------------------------------------------------------------------------------------------------------------------------------------

        #region CustomerOrders

        public void PrintCustomerOrder(DataRowView curRecord)
        {
            SpreadsheetGear.IWorkbook workbook = Factory.GetWorkbook();
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            int startPosition = 1;
            int currentPosition = startPosition;
            
            DateTime orderDate;
            bool isDate = DateTime.TryParse(curRecord["OrderDate"].ToString(), out orderDate);

            cells["F" + currentPosition].Value = "Утверждаю";
            cells["F" + currentPosition].Font.Bold = true;
            currentPosition++;
            cells["F" + currentPosition].Value = "Первый заместитель директора ____________________";
            currentPosition++;
            cells["F" + currentPosition].Value ="\"_____\" __________________ " + ((isDate) ? orderDate.Year.ToString() + "г." : "");
            currentPosition += 2;
            cells["B" + currentPosition + ":" + "E" + currentPosition].Merge();
            cells["B" + currentPosition].Value = "ООО \"НПФ \"Техвагонмаш\"";
            cells["B" + currentPosition].Font.Bold = true;
            cells["B" + currentPosition].Font.Underline = UnderlineStyle.Single;
            currentPosition += 3;
            cells["F" + currentPosition + ":" + "H" + currentPosition].Merge();
            cells["F" + currentPosition].Value = "ЗАКАЗ №" + curRecord["OrderNumber"].ToString();
            cells["F" + currentPosition].Font.Bold = true;
            currentPosition += 2;
            cells["F" + currentPosition + ":" + "H" + currentPosition].Merge();
            cells["F" + currentPosition].Value = "от " + ((isDate) ? orderDate.ToShortDateString() : "");
            cells["F" + currentPosition].Font.Bold = true;
            currentPosition += 2;
            cells["A" + currentPosition + ":" + "C" + currentPosition].Merge();
            cells["A" + currentPosition].Value = "Наименование заказа:";
            cells["D" + currentPosition + ":" + "K" + currentPosition].Merge();
            cells["D" + currentPosition].Value = curRecord["Details"].ToString();
            cells["D" + currentPosition].Font.Underline = UnderlineStyle.Single;
            cells["A" + currentPosition + ":" + "K" + currentPosition].Font.Bold = true;
            cells["A" + currentPosition + ":" + "K" + currentPosition].WrapText = true;
            cells["A" + currentPosition + ":" + "K" + currentPosition].HorizontalAlignment = HAlign.Left;
            cells["A" + currentPosition + ":" + "K" + currentPosition].VerticalAlignment = VAlign.Top;
            cells["A" + currentPosition].RowHeight = 70;
            currentPosition += 3;
            cells["A" + currentPosition + ":" + "C" + currentPosition].Merge();
            cells["A" + currentPosition].Value = "Заказчик:";
            cells["D" + currentPosition + ":" + "K" + currentPosition].Merge();
            cells["D" + currentPosition].Value = curRecord["Name"].ToString();
            cells["D" + currentPosition].Font.Underline = UnderlineStyle.Single;
            cells["A" + currentPosition + ":" + "K" + currentPosition].Font.Bold = true;
            cells["A" + currentPosition + ":" + "K" + currentPosition].WrapText = true;
            cells["A" + currentPosition + ":" + "K" + currentPosition].HorizontalAlignment = HAlign.Left;
            cells["A" + currentPosition + ":" + "K" + currentPosition].VerticalAlignment = VAlign.Top;
            cells["A" + currentPosition].RowHeight = 50;
            currentPosition += 2;
            cells["A" + currentPosition + ":" + "E" + currentPosition].Merge();
            cells["A" + currentPosition].Value = "№ договора (договорного документа)";
            cells["F" + currentPosition + ":" + "K" + currentPosition].Merge();
            cells["F" + currentPosition + ":" + "K" + currentPosition].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
            //cells["F" + currentPosition].Value = curRecord["Name"].ToString();// - agreement name
            cells["F" + currentPosition + ":" + "K" + currentPosition].HorizontalAlignment = HAlign.Center;
            cells["A" + currentPosition + ":" + "K" + currentPosition].Font.Bold = true;
            currentPosition += 2;
            cells["A" + currentPosition + ":" + "E" + currentPosition].Merge();
            cells["A" + currentPosition].Value = "Сумма заказа";
            cells["F" + currentPosition + ":" + "K" + currentPosition].Merge();
            cells["F" + currentPosition + ":" + "K" + currentPosition].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
            cells["F" + currentPosition].Value = ((int)curRecord["CurrencyId"] < 2) ? curRecord["OrderPrice"] : curRecord["CurrencyPrice"];
            cells["F" + currentPosition + ":" + "K" + currentPosition].NumberFormat = "# ##0.00";
            cells["F" + currentPosition + ":" + "K" + currentPosition].HorizontalAlignment = HAlign.Center;
            cells["A" + currentPosition + ":" + "K" + currentPosition].Font.Bold = true;
                        
            cells["A" + startPosition + ":" + "K" + currentPosition].Font.Size = 12;
            
            currentPosition += 2;
            cells["C" + currentPosition + ":" + "E" + currentPosition].Merge();
            cells["C" + currentPosition].Value = "Гл. бухгалтер";
            cells["C" + (currentPosition + 1) + ":" + "E" + (currentPosition + 1)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
            cells["C" + (currentPosition + 2) + ":" + "E" + (currentPosition + 2)].Merge();
            cells["C" + (currentPosition + 2)].Value = "(подпись)";
            cells["C" + currentPosition + ":" + "E" + (currentPosition + 2)].HorizontalAlignment = HAlign.Center;
            cells["C" + currentPosition + ":" + "E" + (currentPosition + 2)].Font.Bold = true;
            cells["C" + currentPosition + ":" + "E" + (currentPosition + 1)].Font.Size = 12;
            cells["C" + (currentPosition + 2) + ":" + "E" + (currentPosition + 2)].Font.Size = 8;
            currentPosition += 4;
            cells["C" + currentPosition + ":" + "E" + currentPosition].Merge();
            cells["C" + currentPosition].Value = "Гл. конструктор";
            cells["C" + (currentPosition + 1) + ":" + "E" + (currentPosition + 1)].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
            cells["C" + (currentPosition + 2) + ":" + "E" + (currentPosition + 2)].Merge();
            cells["C" + (currentPosition + 2)].Value = "(подпись)";
            cells["C" + currentPosition + ":" + "E" + (currentPosition + 2)].HorizontalAlignment = HAlign.Center;
            cells["C" + currentPosition + ":" + "E" + (currentPosition + 2)].Font.Bold = true;
            cells["C" + currentPosition + ":" + "E" + (currentPosition + 1)].Font.Size = 12;
            cells["C" + (currentPosition + 2) + ":" + "E" + (currentPosition + 2)].Font.Size = 8;

            cells["G" + currentPosition + ":" + "H" + currentPosition].Merge();
            cells["G" + currentPosition].Value = "Номер чертежа";
            cells["G" + currentPosition].Font.Bold = true;
            cells["G" + (currentPosition + 1) + ":" + "H" + (currentPosition + 3)].Merge();

            currentPosition += 6;
            cells["A" + currentPosition + ":" + "K" + currentPosition].Merge();
            cells["A" + currentPosition].Value = "Заполняется Бухгалтерией";
            cells["A" + currentPosition].Font.Size = 10;

            currentPosition ++;
            cells["A" + currentPosition].Value = "Месяц";
            cells["B" + currentPosition].Value = "Контрагенты";
            cells["C" + currentPosition].Value = "Материалы";
            cells["D" + currentPosition].Value = "З/плата";
            cells["E" + currentPosition].Value = "Начисления";
            cells["F" + currentPosition].Value = "Общезаводские расходы 91 сч.";
            cells["G" + currentPosition].Value = "Амортизация";
            cells["H" + currentPosition].Value = "Команд.";
            cells["I" + currentPosition].Value = "Производственная себестоимость";

            cells["A" + currentPosition + ":" + "K" + currentPosition].WrapText = true;
            cells["A" + currentPosition + ":" + "K" + currentPosition].VerticalAlignment = VAlign.Center;
            cells["A" + currentPosition + ":" + "K" + currentPosition].HorizontalAlignment = HAlign.Center;
            cells["A" + currentPosition + ":" + "K" + (currentPosition + 14)].Borders.LineStyle = LineStyle.Continous;
            cells["A" + currentPosition + ":" + "K" + (currentPosition + 14)].Font.Size = 10;
            
            currentPosition += 5;
            cells["A" + startPosition + ":" + "K" + currentPosition].Font.Name = "Times New Roman";
            

            try
            {
                string documentAddresName = GeneratedReportsDir +
                                            String.Format("Заказ {0}", curRecord["OrderNumber"].ToString()) + ".xls";
                workbook.SaveAs(documentAddresName, FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + documentAddresName + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        #endregion

        private string TemplatesDir = Utils.HomePath + @"\Reports\Templates\";
        private string GeneratedReportsDir = Utils.HomePath + @"\Reports\Gen\";

        private string[] vsS =
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",

                "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK",
                "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV",
                "AW", "AX", "AY", "AZ",

                "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM",
                "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ",

                "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM",
                "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ"
            };

        private void SetPageBreak(SpreadsheetGear.IWorksheet worksheet, int row, int col)
        {
            worksheet.Cells[row, col].PageBreak = SpreadsheetGear.PageBreak.Manual;
        }

        private string SetFormula(int cell1, int row1, int cell2, int row2, string formula, bool needEq = true)
        {
            return (needEq == true ? "=" : "") + formula + "(" + vsS[cell1] + Convert.ToString(row1) + ":" + vsS[cell2] + Convert.ToString(row2) + ")";
        }

        private string SetFormula(string cell1, int row1, string cell2, int row2, string formula, bool needEq = true)
        {
            return (needEq == true ? "=" : "") + formula + "(" + cell1 + Convert.ToString(row1) + ":" + cell2 + Convert.ToString(row2) + ")";
        }

        private void PrintSignatures(SpreadsheetGear.IRange cells, int startPosition)
        {
            cells["A" + startPosition].Value = "Виконавець:";
            cells["A" + startPosition].HorizontalAlignment = HAlign.Right;
            cells["B" + startPosition + ":C" + startPosition].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
            cells["E" + startPosition + ":F" + startPosition].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
            cells["B" + (startPosition + 1) + ":C" + (startPosition + 1)].Merge();
            cells["E" + (startPosition + 1) + ":F" + (startPosition + 1)].Merge();
            cells["B" + (startPosition + 1) + ":C" + (startPosition + 1)].Value = "(ПІБ, посада)";
            cells["E" + (startPosition + 1) + ":F" + (startPosition + 1)].Value = "(підпис)";
            cells["B" + (startPosition + 1) + ":C" + (startPosition + 1)].HorizontalAlignment = HAlign.Center;
            cells["E" + (startPosition + 1) + ":F" + (startPosition + 1)].HorizontalAlignment = HAlign.Center;
        }


        #region

        public enum TextCase { Nominative/*Кто? Что?*/, Genitive/*Кого? Чего?*/, Dative/*Кому? Чему?*/, Accusative/*Кого? Что?*/, Instrumental/*Кем? Чем?*/, Prepositional/*О ком? О чём?*/ };

        public static class RuDateAndMoneyConverter
        {
            static string[] monthNamesGenitive =
            {
                "", "січня", "лютого", "березня", "кітня", "травня", "червня", "липня", "серпня", "вересня", "жовтня", "листопада", "грудня" 
            };

            static string zero = "нуль";
            static string firstMale = "один";
            static string firstFemale = "одна";
            static string firstFemaleAccusative = "одну";
            static string firstMaleGenetive = "одно";
            static string secondMale = "два";
            static string secondFemale = "дві";
            static string secondMaleGenetive = "двух";
            static string secondFemaleGenetive = "двух";

            static string[] from3till19 = 
            {
                "", "три", "чотири", "п'ять", "шість",
                "сім", "вісім", "дев'ять", "десять", "одинадцать",
                "дванадцять", "тринадцять", "чотирнадцять", "п'ятнадцять",
                "шістнадцять", "сімнадцять", "вісімнадцять", "дев'ятнадцять"
            };
            static string[] from3till19Genetive = 
            {
                "", "трьох", "чотирьох", "п'ятьох", "шістьох",
                "сімох", "вісьмох", "дев'ятьох", "десятьох", "одинадцятьох",
                "дванадцятьох", "тринадцятьох", "чотирнадцятьох", "п'ятнадцятьох",
                "шістнадцятьох", "сімнадцятьох", "вісімнадцятьох", "дев'ятнадцятьох"
            };
            static string[] tens =
            {
                "", "двадцять", "тридцять", "сорок", "п'ятдесят",
                "шістдесят", "сімдесят", "вісімдесят", "дев'яносто"
            };
            static string[] tensGenetive =
            {
                "", "двадцяти", "тридцяти", "сорока", "п'ятдесяти",
                "шістдесяти", "сімдесяти", "вісімдесяти", "дев'яноста"
            };
            static string[] hundreds =
            {
                "", "сто", "двісті", "триста", "чотириста",
                "п'ятсот", "шістсот", "сімсот", "вісімсот", "дев'ятсот"
            };
            static string[] hundredsGenetive =
            {
                "", "ста", "двухсот", "трехсот", "четырехсот",
                "пятисот", "шестисот", "семисот", "восемисот", "девятисот"
            };
            static string[] thousands =
            {
                "", "тисяча", "тисячі", "тисяч"
            };
            static string[] thousandsAccusative =
            {
                "", "тисячу", "тисячі", "тисяч"
            };
            static string[] millions =
            {
                "", "мільйон", "мільйони", "мільйонів"
            };
            static string[] billions =
            {
                "", "миллиард", "миллиарда", "миллиардов"
            };
            static string[] trillions =
            {
                "", "трилион", "трилиона", "триллионов"
            };
            static string[] rubles =
            {
                "", "гривня", "гривні", "гривень"
            };
            static string[] copecks =
            {
                "", "копійка", "копійки", "копійок"
            };
            /// <summary>
            /// «07» января 2004 [+ _year(:года)]
            /// </summary>
            /// <param name="_date"></param>
            /// <param name="_year"></param>
            /// <returns></returns>
            public static string DateToTextLong(DateTime _date, string _year)
            {
                return String.Format("«{0}» {1} {2}",
                                        _date.Day.ToString("D2"),
                                        MonthName(_date.Month, TextCase.Genitive),
                                        _date.Year.ToString()) + ((_year.Length != 0) ? " " : "") + _year;
            }

            /// <summary>
            /// «07» января 2004
            /// </summary>
            /// <param name="_date"></param>
            /// <returns></returns>
            public static string DateToTextLong(DateTime _date)
            {
                return String.Format("«{0}» {1} {2}",
                                        _date.Day.ToString("D2"),
                                        MonthName(_date.Month, TextCase.Genitive),
                                        _date.Year.ToString());
            }
            /// <summary>
            /// II квартал 2004
            /// </summary>
            /// <param name="_date"></param>
            /// <returns></returns>
            public static string DateToTextQuarter(DateTime _date)
            {
                return NumeralsRoman(DateQuarter(_date)) + " квартал " + _date.Year.ToString();
            }
            /// <summary>
            /// 07.01.2004
            /// </summary>
            /// <param name="_date"></param>
            /// <returns></returns>
            public static string DateToTextSimple(DateTime _date)
            {
                return String.Format("{0:dd.MM.yyyy}", _date);
            }
            public static int DateQuarter(DateTime _date)
            {
                return (_date.Month - 1) / 3 + 1;
            }

            static bool IsPluralGenitive(int _digits)
            {
                if (_digits >= 5 || _digits == 0)
                    return true;

                return false;
            }
            static bool IsSingularGenitive(int _digits)
            {
                if (_digits >= 2 && _digits <= 4)
                    return true;

                return false;
            }
            static int lastDigit(long _amount)
            {
                long amount = _amount;

                if (amount >= 100)
                    amount = amount % 100;

                if (amount >= 20)
                    amount = amount % 10;

                return (int)amount;
            }
            /// <summary>
            /// Десять тысяч рублей 67 копеек
            /// </summary>
            /// <param name="_amount"></param>
            /// <param name="_firstCapital"></param>
            /// <returns></returns>
            public static string CurrencyToTxt(double _amount, bool _firstCapital)
            {
                //Десять тысяч рублей 67 копеек
                long rublesAmount = (long)Math.Floor(_amount);
                long copecksAmount = ((long)Math.Round(_amount * 100)) % 100;
                int lastRublesDigit = lastDigit(rublesAmount);
                int lastCopecksDigit = lastDigit(copecksAmount);

                string s = NumeralsToTxt(rublesAmount, TextCase.Nominative, true, _firstCapital) + " ";

                if (IsPluralGenitive(lastRublesDigit))
                {
                    s += rubles[3] + " ";
                }
                else if (IsSingularGenitive(lastRublesDigit))
                {
                    s += rubles[2] + " ";
                }
                else
                {
                    s += rubles[1] + " ";
                }

                s += String.Format("{0:00} ", copecksAmount);

                if (IsPluralGenitive(lastCopecksDigit))
                {
                    s += copecks[3] + " ";
                }
                else if (IsSingularGenitive(lastCopecksDigit))
                {
                    s += copecks[2] + " ";
                }
                else
                {
                    s += copecks[1] + " ";
                }

                return s.Trim();
            }
            /// <summary>
            /// 10 000 (Десять тысяч) рублей 67 копеек
            /// </summary>
            /// <param name="_amount"></param>
            /// <param name="_firstCapital"></param>
            /// <returns></returns>
            public static string CurrencyToTxtFull(double _amount, bool _firstCapital)
            {
                //10 000 (Десять тысяч) рублей 67 копеек
                long rublesAmount = (long)Math.Floor(_amount);
                long copecksAmount = ((long)Math.Round(_amount * 100)) % 100;
                int lastRublesDigit = lastDigit(rublesAmount);
                int lastCopecksDigit = lastDigit(copecksAmount);

                string s = String.Format("{0:N0} ({1}) ", rublesAmount, NumeralsToTxt(rublesAmount, TextCase.Nominative, true, _firstCapital));

                if (IsPluralGenitive(lastRublesDigit))
                {
                    s += rubles[3] + " ";
                }
                else if (IsSingularGenitive(lastRublesDigit))
                {
                    s += rubles[2] + " ";
                }
                else
                {
                    s += rubles[1] + " ";
                }

                s += String.Format("{0:00} ", copecksAmount);

                if (IsPluralGenitive(lastCopecksDigit))
                {
                    s += copecks[3] + " ";
                }
                else if (IsSingularGenitive(lastCopecksDigit))
                {
                    s += copecks[2] + " ";
                }
                else
                {
                    s += copecks[1] + " ";
                }

                return s.Trim();
            }
            /// <summary>
            /// 10 000 рублей 67 копеек  
            /// </summary>
            /// <param name="_amount"></param>
            /// <param name="_firstCapital"></param>
            /// <returns></returns>
            public static string CurrencyToTxtShort(double _amount, bool _firstCapital)
            {
                //10 000 рублей 67 копеек        
                long rublesAmount = (long)Math.Floor(_amount);
                long copecksAmount = ((long)Math.Round(_amount * 100)) % 100;
                int lastRublesDigit = lastDigit(rublesAmount);
                int lastCopecksDigit = lastDigit(copecksAmount);

                string s = String.Format("{0:N0} ", rublesAmount);

                if (IsPluralGenitive(lastRublesDigit))
                {
                    s += rubles[3] + " ";
                }
                else if (IsSingularGenitive(lastRublesDigit))
                {
                    s += rubles[2] + " ";
                }
                else
                {
                    s += rubles[1] + " ";
                }

                s += String.Format("{0:00} ", copecksAmount);

                if (IsPluralGenitive(lastCopecksDigit))
                {
                    s += copecks[3] + " ";
                }
                else if (IsSingularGenitive(lastCopecksDigit))
                {
                    s += copecks[2] + " ";
                }
                else
                {
                    s += copecks[1] + " ";
                }

                return s.Trim();
            }
            static string MakeText(int _digits, string[] _hundreds, string[] _tens, string[] _from3till19, string _second, string _first, string[] _power)
            {
                string s = "";
                int digits = _digits;

                if (digits >= 100)
                {
                    s += _hundreds[digits / 100] + " ";
                    digits = digits % 100;
                }
                if (digits >= 20)
                {
                    s += _tens[digits / 10 - 1] + " ";
                    digits = digits % 10;
                }

                if (digits >= 3)
                {
                    s += _from3till19[digits - 2] + " ";
                }
                else if (digits == 2)
                {
                    s += _second + " ";
                }
                else if (digits == 1)
                {
                    s += _first + " ";
                }

                if (_digits != 0 && _power.Length > 0)
                {
                    digits = lastDigit(_digits);

                    if (IsPluralGenitive(digits))
                    {
                        s += _power[3] + " ";
                    }
                    else if (IsSingularGenitive(digits))
                    {
                        s += _power[2] + " ";
                    }
                    else
                    {
                        s += _power[1] + " ";
                    }
                }

                return s;
            }

            /// <summary>
            /// реализовано для падежей: именительный (nominative), родительный (Genitive),  винительный (accusative)
            /// </summary>
            /// <param name="_sourceNumber"></param>
            /// <param name="_case"></param>
            /// <param name="_isMale"></param>
            /// <param name="_firstCapital"></param>
            /// <returns></returns>
            public static string NumeralsToTxt(long _sourceNumber, TextCase _case, bool _isMale, bool _firstCapital)
            {
                string s = "";
                long number = _sourceNumber;
                int remainder;
                int power = 0;

                if ((number >= (long)Math.Pow(10, 15)) || number < 0)
                {
                    return "";
                }

                while (number > 0)
                {
                    remainder = (int)(number % 1000);
                    number = number / 1000;

                    switch (power)
                    {
                        case 12:
                            s = MakeText(remainder, hundreds, tens, from3till19, secondMale, firstMale, trillions) + s;
                            break;
                        case 9:
                            s = MakeText(remainder, hundreds, tens, from3till19, secondMale, firstMale, billions) + s;
                            break;
                        case 6:
                            s = MakeText(remainder, hundreds, tens, from3till19, secondMale, firstMale, millions) + s;
                            break;
                        case 3:
                            switch (_case)
                            {
                                case TextCase.Accusative:
                                    s = MakeText(remainder, hundreds, tens, from3till19, secondFemale, firstFemaleAccusative, thousandsAccusative) + s;
                                    break;
                                default:
                                    s = MakeText(remainder, hundreds, tens, from3till19, secondFemale, firstFemale, thousands) + s;
                                    break;
                            }
                            break;
                        default:
                            string[] powerArray = { };
                            switch (_case)
                            {
                                case TextCase.Genitive:
                                    s = MakeText(remainder, hundredsGenetive, tensGenetive, from3till19Genetive, _isMale ? secondMaleGenetive : secondFemaleGenetive, _isMale ? firstMaleGenetive : firstFemale, powerArray) + s;
                                    break;
                                case TextCase.Accusative:
                                    s = MakeText(remainder, hundreds, tens, from3till19, _isMale ? secondMale : secondFemale, _isMale ? firstMale : firstFemaleAccusative, powerArray) + s;
                                    break;
                                default:
                                    s = MakeText(remainder, hundreds, tens, from3till19, _isMale ? secondMale : secondFemale, _isMale ? firstMale : firstFemale, powerArray) + s;
                                    break;
                            }
                            break;
                    }

                    power += 3;
                }

                if (_sourceNumber == 0)
                {
                    s = zero + " ";
                }

                if (s != "" && _firstCapital)
                    s = s.Substring(0, 1).ToUpper() + s.Substring(1);

                return s.Trim();
            }
            public static string NumeralsDoubleToTxt(double _sourceNumber, int _decimal, TextCase _case, bool _firstCapital)
            {
                long decNum = (long)Math.Round(_sourceNumber * Math.Pow(10, _decimal)) % (long)(Math.Pow(10, _decimal));

                string s = String.Format(" {0} цiлих {1} сотих", NumeralsToTxt((long)_sourceNumber, _case, true, _firstCapital), (long)decNum);
                                                     // NumeralsToTxt((long)decNum, _case, true, false));
                return s.Trim();
            }
            /// <summary>
            /// название м-ца
            /// </summary>
            /// <param name="_month">с единицы</param>
            /// <param name="_case"></param>
            /// <returns></returns>
            public static string MonthName(int _month, TextCase _case)
            {
                string s = "";

                if (_month > 0 && _month <= 12)
                {
                    switch (_case)
                    {
                        case TextCase.Genitive:
                            s = monthNamesGenitive[_month];
                            break;
                    }
                }

                return s;
            }
            public static string NumeralsRoman(int _number)
            {
                string s = "";

                switch (_number)
                {
                    case 1: s = "I"; break;
                    case 2: s = "II"; break;
                    case 3: s = "III"; break;
                    case 4: s = "IV"; break;
                }

                return s;
            }
        }

        #endregion

    }
}
