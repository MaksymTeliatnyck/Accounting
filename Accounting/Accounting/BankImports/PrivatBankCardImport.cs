using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.BankImports
{
    public class PrivatBankCardImport
    {
        public List<PaymentImportModel> GetCardListAccounts(string filePath)
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
                        DateTime docDate;

                        bool result = DateTime.TryParse(tdNodes[1].InnerText, out docDate);

                        if (result)
                        {
                            resultList.Add(new PaymentImportModel
                            {
                                DocumentNum = "б/н",
                                Sum = Math.Abs(decimal.TryParse(tdNodes[4].InnerText.Replace('.', ','), out d) ? d : 0),
                                PaymentCurrencyName = "UAH",
                                RecipientSrn = "32686844",
                                RecipientName = "ТОВ \"НВФ \"ТЕХВАГОНМАШ\"",
                                PaymentPurpose = tdNodes[2].InnerText.Trim(),
                                DocumentApplyDate = docDate,
                                OperationType = (byte)((tdNodes[4].InnerText.Trim().Substring(0, 1) != "-") ? 1 : 0)
                            });
                        }
                    }
                }
            }

            return resultList;
        }
    }
}
