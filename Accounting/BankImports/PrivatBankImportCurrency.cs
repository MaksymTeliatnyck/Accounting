using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Accounting.BankImports
{
    class PrivatBankImportCurrency
    {
        public List<PaymentImportModel> GetListAccounts(string filePath)
        {

            List<PaymentImportModel> resultList = new List<PaymentImportModel>();

            HtmlDocument doc = new HtmlDocument();
            doc.Load(filePath, Encoding.UTF8);

            var trNodes = doc.DocumentNode.SelectNodes("//tr");

            if (trNodes.Count() != 0)
            {
                foreach (var item in trNodes)
                {
                    var tdNodes = item.ChildNodes.Where(x => x.Name == "td").ToArray();

                    if (tdNodes.Count() != 0)
                    {
                        decimal d;
                        byte operationType = 0;

                        if (tdNodes[3].InnerText.Substring(0, 1) != "-")
                        {
                            operationType = 1;
                        }
              
                        resultList.Add(new PaymentImportModel
                        {
                            DocumentNum = tdNodes[0].InnerText,
                            Sum = Math.Abs(decimal.TryParse(tdNodes[3].InnerText.Replace('.', ','), out d) ? d : 0),
                            PaymentCurrencyName = tdNodes[4].InnerText,
                            RecipientSrn = tdNodes[5].InnerText,
                            RecipientBankAccountNum = ulong.Parse(tdNodes[7].InnerText),
                            RecipientBankCode = uint.Parse(tdNodes[8].InnerText),
                            RecipientName = tdNodes[6].InnerText,
                            PaymentPurpose = tdNodes[9].InnerText,
                            DocumentApplyDate = Convert.ToDateTime(tdNodes[1].InnerText),
                            OperationType = operationType
                        });
                    }
                }
            }

            return resultList;
        }
    }
}
