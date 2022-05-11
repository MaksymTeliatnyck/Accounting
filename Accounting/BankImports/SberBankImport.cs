using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Accounting
{
	static class SberBankImport
	{
		public class iFOBS
		{
			public List<PaymentImportModel> iFOBS_UAH_Xml_Import(string XMLFilePath)
			{
				XDocument xml = XDocument.Load(XMLFilePath);
				return xml.Root.Elements().Select
					(
						c => new PaymentImportModel
						{
							DocumentNum = c.Attribute("DOCUMENTNO").Value, //1
							PayerBankAccountNum = ulong.Parse(c.Attribute("ACCOUNTNO").Value), //2
							PaymentCurrencyCode = ushort.Parse(c.Attribute("CURRENCYID").Value), //3
							PayerBankCode = uint.Parse(c.Attribute("BANKID").Value), //4
							RecipientBankCode = uint.Parse(c.Attribute("CORRBANKID").Value), //5
							RecipientBankAccountNum = ulong.Parse(c.Attribute("CORRACCOUNTNO").Value), //6
							OperationType = byte.Parse(c.Attribute("OPERATIONID").Value), //7
							BankApplyDate = DateTime.ParseExact(c.Attribute("BANKDATE").Value, "yyyyMMdd", CultureInfo.InvariantCulture), //8
							PaymentCurrencyName = c.Attribute("CURRSYMBOLCODE").Value, //9
							DocumentTypeName = c.Attribute("DOCSUBTYPESNAME").Value, //10
							PaymentPurpose = c.Attribute("PLATPURPOSE").Value, //11
							DocumentApplyDate = DateTime.ParseExact(c.Attribute("DOCUMENTDATE").Value, "yyyyMMdd", CultureInfo.InvariantCulture), //12
							RecipientBankName = c.Attribute("CORRBANKNAME").Value, //13
							RecipientSrn = c.Attribute("CORRIDENTIFYCODE").Value, //14
							RecipientName = c.Attribute("CORRCONTRAGENTSNAME").Value, //15
							PayerBankName = c.Attribute("BANKNAME").Value, //16
							PayerSrn = c.Attribute("IDENTIFYCODE").Value, //17
							PayerFullName = c.Attribute("ACCDESCR").Value, //18
							PayerName = c.Attribute("CONTRAGENTSNAME").Value, //19
							PayerInnerCode = int.Parse(c.Attribute("ACCOUNTID").Value), //20
							PaymentTime = DateTime.ParseExact(c.Attribute("BOOKEDDATE").Value, "yyyyMMddTHH:mm:fffff", CultureInfo.InvariantCulture), //21
							DocumentTypeId = ushort.Parse(c.Attribute("DOCUMENTTYPEID").Value), //22
							RecordVersion = uint.Parse(c.Attribute("DATAVERSION").Value), //23
							SumEq = decimal.Parse(c.Attribute("SUMMAEQ").Value) / 100.00m, //24
							Sum = decimal.Parse(c.Attribute("SUMMA").Value) / 100.00m //25
						}
					).ToList();
			}
		}
	}
}
