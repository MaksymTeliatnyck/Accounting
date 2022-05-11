using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Accounting.BankImports
{
    class BankCreditDneprImport
    {
        public List<PaymentImportModel> Get_BKD_Excel_Import(string ExcelFilePath)
        {
            List<PaymentImportModel> resultList = new List<PaymentImportModel>();

            HtmlDocument doc = new HtmlDocument();
            doc.Load(ExcelFilePath, Encoding.UTF8);

            var trNodes = doc.DocumentNode.SelectNodes("//tr");

            DateTime parseDate;

            if (trNodes.Count() != 0)
            {
                foreach (var item in trNodes)
                {
                    var tdNodes = item.ChildNodes.Where(x => x.Name == "td").ToArray();

                    if ((tdNodes.Count() != 0) && DateTime.TryParse(tdNodes[0].InnerText, out parseDate))
                    {
                        resultList.Add(new PaymentImportModel
                        {
                            DocumentNum = tdNodes[2].InnerText,
                            Sum = (tdNodes[5].InnerText == "UAH") ?
                                            ((Convert.ToDecimal(tdNodes[10].InnerText.Replace('.', ',')) > 0) ? Convert.ToDecimal(tdNodes[10].InnerText.Replace('.', ',')) : Convert.ToDecimal(tdNodes[11].InnerText.Replace('.', ',')))
                                            : ((Convert.ToDecimal(tdNodes[8].InnerText.Replace('.', ',')) > 0) ? -1 : 1),
                            SumEq = (tdNodes[5].InnerText == "UAH") ?
                                            0
                                            : ((Convert.ToDecimal(tdNodes[10].InnerText.Replace('.', ',')) > 0) ? Convert.ToDecimal(tdNodes[10].InnerText.Replace('.', ',')) : Convert.ToDecimal(tdNodes[11].InnerText.Replace('.', ','))),
                            PaymentCurrencyName = tdNodes[5].InnerText,
                            RecipientSrn = tdNodes[14].InnerText,
                            RecipientBankAccountNum = ulong.Parse(tdNodes[7].InnerText),
                            RecipientBankCode = uint.Parse(tdNodes[15].InnerText),
                            RecipientName = tdNodes[13].InnerText,
                            PaymentPurpose = tdNodes[12].InnerText,
                            DocumentApplyDate = parseDate,
                            OperationType = (byte)((tdNodes[5].InnerText == "UAH") ?
                                            ((Convert.ToDecimal(tdNodes[10].InnerText.Replace('.', ',')) > 0) ? -1 : 1)
                                            : ((Convert.ToDecimal(tdNodes[8].InnerText.Replace('.', ',')) > 0) ? -1 : 1))
                        });
                    }
                }
            }

            return resultList;
        }

    }
}
