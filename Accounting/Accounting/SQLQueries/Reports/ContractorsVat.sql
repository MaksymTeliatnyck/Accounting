SELECT
    "Contractors"."Id", "Contractors"."Tin", "Contractors"."Name",
    IIF(((COALESCE(DebitVat.DebitStart,0) + COALESCE(BankPayments.BankDebitStart,0)) - (COALESCE(CreditInvoice.CreditStart,0) + COALESCE(BankPayments.BankCreditStart,0))) > 0,
         ((COALESCE(DebitVat.DebitStart,0) + COALESCE(BankPayments.BankDebitStart,0)) - (COALESCE(CreditInvoice.CreditStart,0) + COALESCE(BankPayments.BankCreditStart,0))), 0) AS SaldoDebitStart,
    IIF(((COALESCE(DebitVat.DebitStart,0) + COALESCE(BankPayments.BankDebitStart,0)) - (COALESCE(CreditInvoice.CreditStart,0) + COALESCE(BankPayments.BankCreditStart,0))) < 0,
         ((COALESCE(CreditInvoice.CreditStart,0) + COALESCE(BankPayments.BankCreditStart,0)) - (COALESCE(DebitVat.DebitStart,0) + COALESCE(BankPayments.BankDebitStart,0))), 0) AS SaldoCreditStart,
    COALESCE(DebitVat.DebitVat63,0) + COALESCE(BankPayments.BankDebitPeriod63,0) AS DebitVat63,
    COALESCE(DebitVat.DebitVat631,0)+ COALESCE(BankPayments.BankDebitPeriod631,0) AS DebitVat631,
    COALESCE(DebitVat.DebitVat531,0) + COALESCE(BankPayments.BankDebitPeriod531,0) AS DebitVat531,
    COALESCE(CreditInvoice.CreditPeriod,0) + COALESCE(BankPayments.BankCreditPeriod,0) AS CreditPeriod,
    IIF(((COALESCE(DebitVat.DebitEnd,0) + COALESCE(BankPayments.BankDebitEnd,0)) - (COALESCE(CreditInvoice.CreditEnd,0) + COALESCE(BankPayments.BankCreditEnd,0))) > 0,
         ((COALESCE(DebitVat.DebitEnd,0) + COALESCE(BankPayments.BankDebitEnd,0)) - (COALESCE(CreditInvoice.CreditEnd,0) + COALESCE(BankPayments.BankCreditEnd,0))), 0) AS SaldoDebitEnd,
    IIF(((COALESCE(DebitVat.DebitEnd,0) + COALESCE(BankPayments.BankDebitEnd,0)) - (COALESCE(CreditInvoice.CreditEnd,0) + COALESCE(BankPayments.BankCreditEnd,0))) < 0,
         ((COALESCE(CreditInvoice.CreditEnd,0) + COALESCE(BankPayments.BankCreditEnd,0)) - (COALESCE(DebitVat.DebitEnd,0) + COALESCE(BankPayments.BankDebitEnd,0))), 0) AS SaldoCreditEnd
FROM
    "Contractors"

-- From VAT ----------------------------------------------------------------------------------
LEFT JOIN
    (SELECT
        v.ContractorId, SUM(v.PriceStart) AS DebitStart, SUM(v.PricePeriod631) AS DebitVat631, SUM(v.PricePeriod63) AS DebitVat63, SUM(v.PricePeriod531) AS DebitVat531, SUM(v.PriceEnd) as DebitEnd
     FROM
        (SELECT
            Orders.Vendor_Id AS ContractorId, Orders.ORDER_DATE,
            IIF((Orders.ORDER_DATE < @StartDate), vat.Price, 0) AS PriceStart,
            IIF((Orders.DEBIT_ACCOUNT_ID = 15 AND Orders.ORDER_DATE >= @StartDate), vat.Price, 0) AS PricePeriod631,
            IIF((Orders.DEBIT_ACCOUNT_ID = 16 AND Orders.ORDER_DATE >= @StartDate), vat.Price, 0) AS PricePeriod63,
            IIF((Orders.DEBIT_ACCOUNT_ID = 240 AND Orders.ORDER_DATE >= @StartDate), vat.Price, 0) AS PricePeriod531,
            vat.Price AS PriceEnd
         FROM
            Vat
            INNER JOIN ORDERS ON Vat.Id = Orders.Id
         WHERE
            Vat.Account_Id = 26 AND
            Orders.Order_Date <= @EndDate) AS v
         GROUP BY
            v.ContractorId) AS DebitVat
ON "Contractors"."Id" = DebitVat.ContractorId
------------------------------------------------------------------------------------------------

-- From Invoices -------------------------------------------------------------------------------
LEFT JOIN
    (SELECT
       i.ContractorId, SUM(i.CreditStart) as CreditStart, SUM(i.CreditPeriod) as CreditPeriod, SUM(i.CreditEnd) as CreditEnd
     FROM
        (SELECT "Invoices"."Contractor_Id" AS ContractorId,
            IIF("Invoices"."Month_Current" < @StartDate, "Invoices"."Vat", 0) AS CreditStart,
            IIF("Invoices"."Month_Current" >= @StartDate, "Invoices"."Vat", 0) AS CreditPeriod,
            "Invoices"."Vat" AS CreditEnd
         FROM "Invoices"
         WHERE
            "Invoices"."Balance_Account_Id" IN (4,5,6) AND
            "Invoices"."Month_Current" <= @EndDate) AS i
     GROUP BY
         i.ContractorId) AS CreditInvoice
ON  "Contractors"."Id" = CreditInvoice.ContractorId
-------------------------------------------------------------------------------------------------
-- From Bank_Payments ---------------------------------------------------------------------------
LEFT JOIN
     (SELECT
        b.ContractorId, SUM(b.BankDebitStart) AS BankDebitStart, SUM(b.BankCreditStart) AS BankCreditStart,
        SUM(b.BankDebitPeriod63) AS BankDebitPeriod63, SUM(b.BankDebitPeriod631) AS BankDebitPeriod631,SUM(b.BankDebitPeriod531) AS BankDebitPeriod531,
        SUM(b.BankCreditPeriod) AS BankCreditPeriod, SUM(b.BankDebitEnd) AS BankDebitEnd, SUM(b.BankCreditEnd) AS BankCreditEnd
      FROM
        (SELECT "Bank_Payments"."Contractor_Id" AS ContractorId,
            IIF(("Bank_Payments"."Direction" = 1 AND "Bank_Payments"."Payment_Date" < @StartDate), "Bank_Payments"."Payment_Price", 0) AS BankDebitStart,
            IIF(("Bank_Payments"."Direction" = -1 AND "Bank_Payments"."Payment_Date" < @StartDate), "Bank_Payments"."Payment_Price", 0) AS BankCreditStart,
            IIF(("Bank_Payments"."Direction" = 1 AND "Bank_Payments"."Payment_Date" >= @StartDate AND "Bank_Payments"."Purpose_Account_Id" = 16), "Bank_Payments"."Payment_Price", 0) AS BankDebitPeriod63,
            IIF(("Bank_Payments"."Direction" = 1 AND "Bank_Payments"."Payment_Date" >= @StartDate AND "Bank_Payments"."Purpose_Account_Id" = 15), "Bank_Payments"."Payment_Price", 0) AS BankDebitPeriod631,
            IIF(("Bank_Payments"."Direction" = 1 AND "Bank_Payments"."Payment_Date" >= @StartDate AND "Bank_Payments"."Purpose_Account_Id" = 240), "Bank_Payments"."Payment_Price", 0) AS BankDebitPeriod531,
            IIF(("Bank_Payments"."Direction" = -1 AND "Bank_Payments"."Payment_Date" >= @StartDate), "Bank_Payments"."Payment_Price", 0) AS BankCreditPeriod,
            IIF(("Bank_Payments"."Direction" = 1), "Bank_Payments"."Payment_Price", 0) AS BankDebitEnd,
            IIF(("Bank_Payments"."Direction" = -1), "Bank_Payments"."Payment_Price", 0) AS BankCreditEnd
          FROM
            "Bank_Payments"
          WHERE
            "Bank_Payments"."Bank_Account_Id" = 26 AND
            "Bank_Payments"."Payment_Date" <= @EndDate AND "Bank_Payments"."Payment_Date" >= '30.05.2014') AS b
      GROUP BY
        b.ContractorId) AS BankPayments
ON "Contractors"."Id" = BankPayments.ContractorId
--------------------------------------------------------------------------------------------------
WHERE
       ((COALESCE(DebitVat.DebitStart,0) + COALESCE(BankPayments.BankDebitStart,0))
            - (COALESCE(CreditInvoice.CreditStart,0))) <> 0 OR
       (COALESCE(DebitVat.DebitVat63,0) + COALESCE(DebitVat.DebitVat631,0) + COALESCE(DebitVat.DebitVat531,0) + COALESCE(CreditInvoice.CreditPeriod,0)) <> 0