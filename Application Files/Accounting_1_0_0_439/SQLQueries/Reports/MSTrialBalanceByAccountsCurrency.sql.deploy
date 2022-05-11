SELECT 
    StartEnd.Contractor_Id,
    co."Srn" as ContractorSrn,
    co."Name" as ContractorName,
    StartEnd.CurrencyId,
    c."Code" as CurrencyName,
    StartEnd.StartDebit,
    StartEnd.StartDebitCurrency,
    StartEnd.StartCredit,
    StartEnd.StartCreditCurrency,
    StartEnd.EndDebit,
    StartEnd.EndDebitCurrency,
    StartEnd.EndCredit,
    StartEnd.EndCreditCurrency,
    COALESCE(PeriodDebitCredit.AccountId, 0) AS AccountId,
    a.NUM,
    PeriodDebitCredit.Payment_Document,
    PeriodDebitCredit.Payment_Date,
    PeriodDebitCredit.Invoice_Num,
    PeriodDebitCredit.Invoice_Date,
    PeriodDebitCredit.PeriodPriceCurrency,
    PeriodDebitCredit.PeriodPrice,
    PeriodDebitCredit.CurrencyId,
    PeriodDebitCredit.Rate,
    COALESCE(PeriodDebitCredit.FlagDebitCredit, 0) AS FlagDebitCredit
FROM 
(SELECT
    IIF(DebitOrder.Contractor_Id IS NULL,  BankPayments.Contractor_Id, DebitOrder.Contractor_Id) as Contractor_Id,
    IIF(DebitOrder.Currency_Id IS NULL, BankPayments.CurrencyId, DebitOrder.Currency_Id) as CurrencyId,
    --Start
    IIF(COALESCE(DebitOrder.StartOrder, 0) + COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0) < 0,
        COALESCE(BankPayments.BankCreditStart ,0) - (COALESCE(DebitOrder.StartOrder, 0) + COALESCE(BankPayments.BankDebitStart ,0)), 0) as StartDebit,
    IIF(COALESCE(DebitOrder.StartOrder, 0) + COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0) > 0,
        COALESCE(DebitOrder.StartOrder, 0) + COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0), 0) as StartCredit,
    IIF(COALESCE(DebitOrder.StartOrderCurrency, 0) + COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0) < 0,
        COALESCE(BankPayments.BankCreditStartCurrency ,0) - (COALESCE(DebitOrder.StartOrderCurrency, 0) + COALESCE(BankPayments.BankDebitStartCurrency ,0)), 0) as StartDebitCurrency,
    IIF(COALESCE(DebitOrder.StartOrderCurrency, 0) + COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0) > 0,
        COALESCE(DebitOrder.StartOrderCurrency, 0) + COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0), 0) as StartCreditCurrency,
    --End
    IIF(COALESCE(DebitOrder.EndOrder, 0) + COALESCE(BankPayments.BankDebitEnd ,0) - COALESCE(BankPayments.BankCreditEnd ,0) < 0,
        COALESCE(BankPayments.BankCreditEnd ,0) - (COALESCE(DebitOrder.EndOrder, 0) + COALESCE(BankPayments.BankDebitEnd ,0)), 0) as EndDebit,
    IIF(COALESCE(DebitOrder.EndOrder, 0) + COALESCE(BankPayments.BankDebitEnd ,0) - COALESCE(BankPayments.BankCreditEnd ,0) > 0,
        COALESCE(DebitOrder.EndOrder, 0) + COALESCE(BankPayments.BankDebitEnd ,0) - COALESCE(BankPayments.BankCreditEnd ,0), 0) as EndCredit,
    IIF(COALESCE(DebitOrder.EndOrderCurrency, 0) + COALESCE(BankPayments.BankDebitEndCurrency ,0) - COALESCE(BankPayments.BankCreditEndCurrency ,0) < 0,
        COALESCE(BankPayments.BankCreditEndCurrency ,0) - (COALESCE(DebitOrder.EndOrderCurrency, 0) + COALESCE(BankPayments.BankDebitEndCurrency ,0)), 0) as EndDebitCurrency,
    IIF(COALESCE(DebitOrder.EndOrderCurrency, 0) + COALESCE(BankPayments.BankDebitEndCurrency ,0) - COALESCE(BankPayments.BankCreditEndCurrency ,0) > 0,
        COALESCE(DebitOrder.EndOrderCurrency, 0) + COALESCE(BankPayments.BankDebitEndCurrency ,0) - COALESCE(BankPayments.BankCreditEndCurrency ,0), 0) as EndCreditCurrency
  FROM
  --StartEnd From Order ----------------------------------------------------------------------------------
    (SELECT
        o.Contractor_Id,
        o.Currency_Id,
        SUM(o.StartOrder) as StartOrder,
        SUM(o.StartOrderCurrency) as StartOrderCurrency,
        SUM(o.EndOrder) as EndOrder,
        SUM(o.EndOrderCurrency) as EndOrderCurrency
      FROM
        (SELECT
            Orders.Vendor_Id AS Contractor_Id,
            IIF( Orders.Order_Date < @StartDate, Orders.Total_Price, 0) AS StartOrder,
            IIF( Orders.Order_Date < @StartDate, Orders.Total_Currency, 0) AS StartOrderCurrency,
            Orders.Total_Price AS EndOrder,
            Orders.Total_Currency AS EndOrderCurrency,
            Orders.Currency_Id
         FROM
            Orders
         WHERE
            Orders.DEBIT_ACCOUNT_ID = 60 AND
            Orders.Checked = 1 AND
            Orders.Order_Date >= '31.03.2013' AND
            Orders.Order_Date <= @EndDate) AS o
         GROUP BY
            o.Contractor_Id, o.Currency_Id
    ) AS DebitOrder

    --StartEnd From Bank_Payments ---------------------------------------------------------------------------
  FULL JOIN
    (SELECT
        b.Contractor_Id,
        b.CurrencyId,
        --
        SUM(b.BankDebitStartCurrency) AS BankDebitStartCurrency,
        SUM(b.BankDebitStart) AS BankDebitStart,
        SUM(b.BankCreditStartCurrency) AS BankCreditStartCurrency,
        SUM(b.BankCreditStart) AS BankCreditStart,
        --
        SUM(b.BankDebitEndCurrency) AS BankDebitEndCurrency,
        SUM(b.BankDebitEnd) AS BankDebitEnd,
        SUM(b.BankCreditEndCurrency) AS BankCreditEndCurrency,
        SUM(b.BankCreditEnd) AS BankCreditEnd
      FROM
        (SELECT "Bank_Payments"."Contractor_Id" AS Contractor_Id,
            -- DebitCreditStart
            IIF(("Bank_Payments"."Direction" = 1 AND "Bank_Payments"."Payment_Date" < @StartDate), "Bank_Payments"."Payment_PriceCurrency", 0) AS BankDebitStartCurrency,
            IIF(("Bank_Payments"."Direction" = 1 AND "Bank_Payments"."Payment_Date" < @StartDate), "Bank_Payments"."Payment_Price", 0) AS BankDebitStart,
            IIF(("Bank_Payments"."Direction" = -1 AND "Bank_Payments"."Payment_Date" < @StartDate), "Bank_Payments"."Payment_PriceCurrency", 0) AS BankCreditStartCurrency,
            IIF(("Bank_Payments"."Direction" = -1 AND "Bank_Payments"."Payment_Date" < @StartDate), "Bank_Payments"."Payment_Price", 0) AS BankCreditStart,
             -- DebitCreditEnd
            IIF(("Bank_Payments"."Direction" = 1), "Bank_Payments"."Payment_PriceCurrency", 0) AS BankDebitEndCurrency,
            IIF(("Bank_Payments"."Direction" = 1), "Bank_Payments"."Payment_Price", 0) AS BankDebitEnd,
            IIF(("Bank_Payments"."Direction" = -1), "Bank_Payments"."Payment_PriceCurrency", 0) AS BankCreditEndCurrency,
            IIF(("Bank_Payments"."Direction" = -1), "Bank_Payments"."Payment_Price", 0) AS BankCreditEnd,
            --
            "Bank_Payments"."CurrencyId" as CurrencyId
          FROM
            "Bank_Payments"
          WHERE
            "Bank_Payments"."Purpose_Account_Id" = 60 AND
            "Bank_Payments"."Payment_Date" <= @EndDate) AS b
      GROUP BY
        b.Contractor_Id, b.CurrencyId
    ) AS BankPayments

    ON DebitOrder.Contractor_Id = BankPayments.Contractor_Id AND DebitOrder.Currency_Id = BankPayments.CurrencyId
) AS StartEnd

FULL JOIN

(SELECT b."Contractor_Id" AS Contractor_Id,
            b."Bank_Account_Id" AS AccountId,
            b."Payment_Document" AS Payment_Document,
            b."Payment_Date" AS Payment_Date,
            NULL as Invoice_Num,
            NULL as Invoice_Date,
            b."Payment_PriceCurrency" AS PeriodPriceCurrency,
            b."Payment_Price" AS PeriodPrice,
            b."CurrencyId" as CurrencyId,
            b."Rate" AS Rate,
            1 as FlagDebitCredit
        FROM
            "Bank_Payments" b
        WHERE
            b."Purpose_Account_Id" = 60 AND
            (b."Payment_Date" BETWEEN @StartDate AND @EndDate) AND
            b."Direction" = -1

        UNION ALL
            SELECT
                Orders.Vendor_Id AS Contractor_Id,
                Nomenclatures.Balance_Account_Id AS AccountId,
                Orders.Receipt_Num,
                Orders.Order_Date,
                Orders.Invoice_Num,
                Orders.Invoice_Date,
                SUM(Receipts.Total_Currency) AS PeriodPriceCurrency,
                SUM(Receipts.Total_Price) AS PeriodPrice,
                Orders.Currency_Id as CurrencyId,
                Orders.Currency_Rate as Rate,
                2 as FlagDebitCredit
              FROM
                Orders, Receipts, Nomenclatures
              WHERE
                Orders.Debit_Account_Id = 60 AND
                Receipts.Order_Id = Orders.Id AND
                Receipts.Nomenclature_Id = Nomenclatures.Id AND
                Orders.Order_Date BETWEEN @StartDate AND @EndDate AND
                Orders.Checked = 1 AND
                Orders.Order_Date >= '31.03.2013'
              GROUP BY
                Orders.Id, Orders.Vendor_Id, Orders.Receipt_Num, Orders.Invoice_Num, Orders.Order_Date, Orders.Invoice_Date, Orders.Currency_Id,
                Orders.Currency_Rate, Nomenclatures.Balance_Account_Id
        UNION ALL
            SELECT
                b."Contractor_Id" AS Contractor_Id,
                b."Bank_Account_Id" AS AccountId,
                b."Payment_Document" AS Payment_Document,
                b."Payment_Date" AS Payment_Date,
                NULL as Invoice_Num,
                NULL as Invoice_Date,
                b."Payment_PriceCurrency" AS PeriodPriceCurrency,
                b."Payment_Price" AS PeriodPrice,
                b."CurrencyId" as CurrencyId,
                b."Rate" AS Rate,
                2 as FlagDebitCredit
              FROM
                "Bank_Payments" b
              WHERE
                b."Purpose_Account_Id" = 60 AND
                (b."Payment_Date" BETWEEN @StartDate AND @EndDate) AND
                b."Direction" = 1
) AS PeriodDebitCredit
ON  StartEnd.Contractor_Id = PeriodDebitCredit.Contractor_Id AND StartEnd.CurrencyId = PeriodDebitCredit.CurrencyId

LEFT JOIN "Currency" c ON StartEnd.CurrencyId = c."Id"
LEFT JOIN "Contractors" co ON StartEnd.Contractor_Id = co."Id"
LEFT JOIN Accounts a ON PeriodDebitCredit.AccountId = a.ID

WHERE NOT(
        (StartEnd.StartDebit = 0) AND
        (StartEnd.StartDebitCurrency = 0) AND
        (StartEnd.StartCredit = 0) AND
        (StartEnd.StartCreditCurrency = 0) AND
        (StartEnd.EndDebit = 0) AND
        (StartEnd.EndDebitCurrency = 0) AND
        (StartEnd.EndCredit = 0) AND
        (StartEnd.EndCreditCurrency = 0) AND
        (COALESCE(PeriodDebitCredit.AccountId, 0) = 0)
      )

ORDER BY 1