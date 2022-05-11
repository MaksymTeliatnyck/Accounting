SELECT
    IIF(DebitOrder.Contractor_Id IS NULL,  BankPayments.Contractor_Id, DebitOrder.Contractor_Id) as Contractor_Id,
    IIF(DebitOrder.ContractorSrn IS NULL,  BankPayments.ContractorSrn, DebitOrder.ContractorSrn) as ContractorSrn,
    IIF(DebitOrder.ContractorName IS NULL,  BankPayments.ContractorName, DebitOrder.ContractorName) as ContractorName,
    DebitOrder.DebitCurrencyName, BankPayments.BankCurrencyName,
    --Start
    IIF(COALESCE(DebitOrder.StartOrder, 0) + COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0) < 0,
        COALESCE(BankPayments.BankCreditStart ,0) - (COALESCE(DebitOrder.StartOrder, 0) + COALESCE(BankPayments.BankDebitStart ,0)), 0) as StartDebit,
    IIF(COALESCE(DebitOrder.StartOrder, 0) + COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0) > 0,
        COALESCE(DebitOrder.StartOrder, 0) + COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0), 0) as StartCredit,
    IIF(COALESCE(DebitOrder.StartOrderCurrency, 0) + COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0) < 0,
        COALESCE(BankPayments.BankCreditStartCurrency ,0) - (COALESCE(DebitOrder.StartOrderCurrency, 0) + COALESCE(BankPayments.BankDebitStartCurrency ,0)), 0) as StartDebitCurrency,
    IIF(COALESCE(DebitOrder.StartOrderCurrency, 0) + COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0) > 0,
        COALESCE(DebitOrder.StartOrderCurrency, 0) + COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0), 0) as StartCreditCurrency,
    --Period
    COALESCE(BankPayments.BankCreditPeriod ,0) as PeriodDebit,
    (COALESCE(DebitOrder.PeriodOrder, 0) + COALESCE(BankPayments.BankDebitPeriod ,0)) as PeriodCredit,
    COALESCE(BankPayments.BankCreditPeriodCurrency ,0) as PeriodDebitCurrency,
    (COALESCE(DebitOrder.PeriodOrderCurrency, 0) + COALESCE(BankPayments.BankDebitPeriodCurrency ,0)) as PeriodCreditCurrency,
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
-- From Order ----------------------------------------------------------------------------------
(SELECT
        o.Contractor_Id,
        MAX(co."Srn") as ContractorSrn, MAX(co."Name") as ContractorName,
        o.Currency_Id, MAX(c."Code") as DebitCurrencyName,
        SUM(o.StartOrder) as StartOrder,
        SUM(o.StartOrderCurrency) as StartOrderCurrency,
        SUM(o.PeriodOrder) as PeriodOrder,
        SUM(o.PeriodOrderCurrency) as PeriodOrderCurrency,
        SUM(o.EndOrder) as EndOrder,
        SUM(o.EndOrderCurrency) as EndOrderCurrency
      FROM
        (SELECT
            Orders.Vendor_Id AS Contractor_Id,
            IIF( Orders.Order_Date < @StartDate, Orders.Total_Price, 0) AS StartOrder,
            IIF( Orders.Order_Date < @StartDate, Orders.Total_Currency, 0) AS StartOrderCurrency,
            IIF( Orders.Order_Date >= @StartDate , Orders.Total_Price, 0) AS PeriodOrder,
            IIF( Orders.Order_Date >= @StartDate , Orders.Total_Currency, 0) AS PeriodOrderCurrency,
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
         LEFT JOIN "Currency" c ON o.Currency_Id = c."Id"
         LEFT JOIN "Contractors" co ON o.Contractor_Id = co."Id"
        GROUP BY
            o.Contractor_Id, o.Currency_Id) AS DebitOrder

-- From Bank_Payments ---------------------------------------------------------------------------
FULL JOIN
     (SELECT
        b.Contractor_Id,
        MAX(co."Srn") as ContractorSrn, MAX(co."Name") as ContractorName,
        b.CurrencyId,
        MAX(c."Code") as BankCurrencyName,
        --
        SUM(b.BankDebitStartCurrency) AS BankDebitStartCurrency,
        SUM(b.BankDebitStart) AS BankDebitStart,
        SUM(b.BankCreditStartCurrency) AS BankCreditStartCurrency,
        SUM(b.BankCreditStart) AS BankCreditStart,
        --
        SUM(b.BankDebitPeriodCurrency) AS BankDebitPeriodCurrency,
        SUM(b.BankDebitPeriod) AS BankDebitPeriod,
        SUM(b.BankCreditPeriodCurrency) AS BankCreditPeriodCurrency,
        SUM(b.BankCreditPeriod) AS BankCreditPeriod,
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
            -- DebitCreditPeriod
            IIF(("Bank_Payments"."Direction" = 1 AND "Bank_Payments"."Payment_Date" >= @StartDate), "Bank_Payments"."Payment_PriceCurrency", 0) AS BankDebitPeriodCurrency,
            IIF(("Bank_Payments"."Direction" = 1 AND "Bank_Payments"."Payment_Date" >= @StartDate), "Bank_Payments"."Payment_Price", 0) AS BankDebitPeriod,
            IIF(("Bank_Payments"."Direction" = -1 AND "Bank_Payments"."Payment_Date" >= @StartDate), "Bank_Payments"."Payment_PriceCurrency", 0) AS BankCreditPeriodCurrency,
            IIF(("Bank_Payments"."Direction" = -1 AND "Bank_Payments"."Payment_Date" >= @StartDate), "Bank_Payments"."Payment_Price", 0) AS BankCreditPeriod,
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
         LEFT JOIN "Currency" c ON b.CurrencyId = c."Id"
         LEFT JOIN "Contractors" co ON b.Contractor_Id = co."Id"
      GROUP BY
        b.Contractor_Id, b.CurrencyId) AS BankPayments
ON DebitOrder.Contractor_Id = BankPayments.Contractor_Id AND DebitOrder.Currency_Id = BankPayments.CurrencyId

ORDER BY 1
