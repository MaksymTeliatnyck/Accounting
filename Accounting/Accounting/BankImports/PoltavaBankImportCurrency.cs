using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Accounting.BankImports
{
    class PoltavaBankImportCurrency
    {
        private string[] CurrenciesStrName = { "USD", "EUR", "RUB", "UAH" };

        public List<PaymentImportModel> GetData(string filePath)
        {
            List<string> allData = new List<string>();
            List<PaymentImportModel> payments = new List<PaymentImportModel>();
            string lastFoundPaymentCurrencyName="";
            decimal lastFoundRate=0.00m;

            using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("windows-1251")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    allData.Add(line);
            }

            for (int i = 0; i < allData.Count; i++)
            {
                var paymentRow = new PaymentImportModel();
                var currentRow = allData[i];



                #region currencyName
                if (currentRow.IndexOf("Вал.:") != -1)
                {
                    //PaymentCurrencyName
                    for (int elem = 0; elem < CurrenciesStrName.Length; elem++)
                    {
                        if (currentRow.IndexOf(CurrenciesStrName[elem]) != -1)
                        {
                            lastFoundPaymentCurrencyName = CurrenciesStrName[elem];
                            //System.Windows.Forms.MessageBox.Show(CurrenciesStrName[elem]);
                            break;
                        }
                    }
                    //Rate value
                    int rateStrStartPosition = currentRow.IndexOf("Курс:");
                    if (rateStrStartPosition != -1)
                    { 
                        rateStrStartPosition +="Курс:".Length;
                        int rateStrLength =currentRow.IndexOf("/",rateStrStartPosition)-rateStrStartPosition;

                        lastFoundRate = decimal.Parse(currentRow.Substring(rateStrStartPosition, rateStrLength).Replace('.', ','));

                    }
                }
                paymentRow.PaymentCurrencyName = lastFoundPaymentCurrencyName;
                paymentRow.Rate = lastFoundRate;


                #endregion currencyName

                if (Char.IsDigit(currentRow[0]))
                {
                    int operationLength = 8;
                    int sumPos = currentRow.IndexOf("Списання");
                    byte operationType = 0;
                    if (sumPos < 0)
                    {
                        sumPos = currentRow.IndexOf("Зарахування");
                        operationLength = 11;
                        operationType = 1;
                    }

                    #region documentNumber

                    string documentNumber = "";

                    for (int y = sumPos - 1; y > 0; y--)
                    {
                        if (currentRow[y] != ' ')
                        {
                            documentNumber += currentRow[y];
                            if (currentRow[y - 1] == ' ')
                                break;
                        }
                    }

                    var array = documentNumber.ToCharArray();
                    Array.Reverse(array);
                    paymentRow.DocumentNum = new String(array);
                   
                    #endregion documentNumber

                    #region sum

                    string sum = "";
                    string returnValue = SearchString(sum, sumPos + operationLength, currentRow);
                    paymentRow.Sum = decimal.Parse(returnValue.Replace(',', ' ').Replace('.', ','));

                    #endregion sum

                    #region payment account, srn, contractor, purpose

                    string purpose = "";

                    i += 2;
                    int paymentAccountPos = allData[i].IndexOf("Рах.:");
                    int srnPos = allData[i].IndexOf("Код:");

                    if (paymentAccountPos >= 0 && srnPos >= 0)
                    {
                        string paymentAccount = "";
                        string srn = "";

                        paymentRow.RecipientBankAccountNum = ulong.Parse(SearchString(paymentAccount, paymentAccountPos + 5, allData[i]));
                        paymentRow.RecipientSrn = SearchString(srn, srnPos + 5, allData[i]);
                        paymentRow.RecipientName = allData[++i].Trim();

                        i++;

                        int k = i;
                        while (!Char.IsDigit(allData[k][0]))
                        {
                            purpose += allData[k];

                            if (k + 1 == allData.Count || allData[k + 1].Contains("---------------- ----------------"))
                                break;
                            else
                                k++;
                        }
                    }

                    #endregion payment account, srn, contractor, purpose

                    #region payment date

                    var row = allData.First(c => c.Contains("Дата проведення"));

                    string paymentDate = "";
                    int paymentDatePos = row.IndexOf("Дата проведення");

                    if (paymentDatePos >= 0)
                    {
                        int pPosition = paymentDatePos + 16;

                        if (row[pPosition] != ' ')
                            paymentDate += row.Substring(pPosition, 10);
                    }

                    #endregion payment date

                    paymentRow.OperationType = operationType;
                    paymentRow.PaymentPurpose = purpose.Trim();
                    paymentRow.DocumentApplyDate = DateTime.Parse(paymentDate);
                    payments.Add(paymentRow);
                }
            }

            return payments;
        }

        private string SearchString(string returnValue, int pos, string currentRow)
        {
            for (int y = pos; y < currentRow.Length; y++)
            {
                if (currentRow[y] != ' ')
                {
                    returnValue += currentRow[y];

                    if (y + 1 != currentRow.Length && currentRow[y + 1] == ' ')
                        break;
                }
            }

            return returnValue;
        }
    }
}
