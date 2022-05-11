using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Data;
using Excel;

namespace Accounting.BankImports
{
    class FIKImport
    {

        public List<PaymentImportModel> Get_FIK_Excel_Import(string ExcelFilePath)
        {

            FileStream stream = File.Open(ExcelFilePath, FileMode.Open, FileAccess.Read);

            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet inDataSourse = excelReader.AsDataSet();

            double tempTryParseLinq;
            return (from dataSourse in inDataSourse.Tables[0].AsEnumerable()

                    where double.TryParse(dataSourse[4].ToString(), out tempTryParseLinq)
                        //select dataSourse;
                    select new PaymentImportModel
                     {
                         // Document info
                         DocumentNum = dataSourse[0].ToString(),
                         BankApplyDate = DateTime.FromOADate(Convert.ToDouble(dataSourse[4].ToString())),//DateTime.ParseExact(dataSourse[4].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture),
                         OperationType = Convert.ToByte(!Convert.ToBoolean(Convert.ToByte(Convert.ToByte(dataSourse[6].ToString())))),
                         DocumentTypeName = dataSourse[2].ToString(),
                         PaymentPurpose = dataSourse[24].ToString(),
                         DocumentApplyDate = DateTime.FromOADate(Convert.ToDouble(dataSourse[1].ToString())),//DateTime.ParseExact(dataSourse[1].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture),
                         Sum = Math.Abs(decimal.Parse(dataSourse[7].ToString())),
                         SumEq = Math.Abs(decimal.Parse(dataSourse[8].ToString())),
                         PaymentCurrencyName = dataSourse[12].ToString(),
                         //Банк info
                         RecipientBankName = dataSourse[23].ToString(),
                         RecipientSrn = "09807856",
                         RecipientName = dataSourse[18].ToString(),
                         RecipientBankCode = uint.Parse(dataSourse[19].ToString()),
                         RecipientBankAccountNum = ulong.Parse(dataSourse[20].ToString()),
                         //Banc info for ТОВ Техвагон маш 
                         PayerBankName = dataSourse[21].ToString(),
                         PayerBankCode = uint.Parse(dataSourse[22].ToString()),
                         //ТОВ Техвагон маш data
                         PayerSrn = dataSourse[17].ToString(),
                         PayerFullName = dataSourse[16].ToString(),
                         PayerName = dataSourse[16].ToString(),
                         PayerInnerCode = int.Parse(dataSourse[13].ToString()),
                         PayerBankAccountNum = ulong.Parse(dataSourse[14].ToString())
                     }).ToList();
        }

    }
}
