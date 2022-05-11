SELECT
    AllPeriod.Contractor_Id,
    AllPeriod.ContractorSrn,
    AllPeriod.ContractorName,
    AllPeriod.BankCurrencyName,
    AllPeriod.StartDebit,
    AllPeriod.StartCredit,
    AllPeriod.StartDebitCurrency,
    AllPeriod.StartCreditCurrency,
    AllPeriod.PeriodDebit,
    AllPeriod.PeriodCredit,
    AllPeriod.PeriodDebitCurrency,
    AllPeriod.PeriodCreditCurrency,
    AllPeriod.EndDebit,
    AllPeriod.EndCredit,
    AllPeriod.EndDebitCurrency,
    AllPeriod.EndCreditCurrency
FROM
(SELECT
    BankPayments.Contractor_Id,
    BankPayments.ContractorSrn,
    BankPayments.ContractorName,
    BankPayments.BankCurrencyName,
    --Start
    IIF(COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0) < 0,
        COALESCE(BankPayments.BankCreditStart ,0) - COALESCE(BankPayments.BankDebitStart ,0), 0) as StartDebit,
    IIF(COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0) > 0,
        COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0), 0) as StartCredit,
    IIF(COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0) < 0,
        COALESCE(BankPayments.BankCreditStartCurrency ,0) - COALESCE(BankPayments.BankDebitStartCurrency ,0), 0) as StartDebitCurrency,
    IIF(COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0) > 0,
        COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0), 0) as StartCreditCurrency,
    --Period
    COALESCE(BankPayments.BankCreditPeriod ,0) as PeriodDebit,
    COALESCE(BankPayments.BankDebitPeriod ,0) as PeriodCredit,
    COALESCE(BankPayments.BankCreditPeriodCurrency ,0) as PeriodDebitCurrency,
    COALESCE(BankPayments.BankDebitPeriodCurrency ,0) as PeriodCreditCurrency,
    --End
    IIF(COALESCE(BankPayments.BankDebitEnd ,0) - COALESCE(BankPayments.BankCreditEnd ,0) < 0,
        COALESCE(BankPayments.BankCreditEnd ,0) - COALESCE(BankPayments.BankDebitEnd ,0), 0) as EndDebit,
    IIF(COALESCE(BankPayments.BankDebitEnd ,0) - COALESCE(BankPayments.BankCreditEnd ,0) > 0,
        COALESCE(BankPayments.BankDebitEnd ,0) - COALESCE(BankPayments.BankCreditEnd ,0), 0) as EndCredit,
    IIF(COALESCE(BankPayments.BankDebitEndCurrency ,0) - COALESCE(BankPayments.BankCreditEndCurrency ,0) < 0,
        COALESCE(BankPayments.BankCreditEndCurrency ,0) - COALESCE(BankPayments.BankDebitEndCurrency ,0), 0) as EndDebitCurrency,
    IIF(COALESCE(BankPayments.BankDebitEndCurrency ,0) - COALESCE(BankPayments.BankCreditEndCurrency ,0) > 0,
        COALESCE(BankPayments.BankDebitEndCurrency ,0) - COALESCE(BankPayments.BankCreditEndCurrency ,0), 0) as EndCreditCurrency
FROM

-- From Bank_Payments ---------------------------------------------------------------------------
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
            "Bank_Payments"."Purpose_Account_Id" = 96 AND
            "Bank_Payments"."Payment_Date" <= @EndDate
        ) AS b
        LEFT JOIN "Currency" c ON b.CurrencyId = c."Id"
        LEFT JOIN "Contractors" co ON b.Contractor_Id = co."Id"
      GROUP BY
        b.Contractor_Id, b.CurrencyId) AS BankPayments
) AS AllPeriod

WHERE
    (AllPeriod.StartDebit +
     AllPeriod.StartCredit +
     AllPeriod.StartDebitCurrency +
     AllPeriod.StartCreditCurrency +
     AllPeriod.PeriodDebit +
     AllPeriod.PeriodCredit +
     AllPeriod.PeriodDebitCurrency +
     AllPeriod.PeriodCreditCurrency
     ) > 0
ORDER BY 1