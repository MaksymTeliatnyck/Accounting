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
    BankPayments.Contractor_Id as Contractor_Id,
    BankPayments.CurrencyId as CurrencyId,
    --Start
    IIF(COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0) < 0,
        COALESCE(BankPayments.BankCreditStart ,0) - COALESCE(BankPayments.BankDebitStart ,0), 0) as StartDebit,
    IIF(COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0) > 0,
        COALESCE(BankPayments.BankDebitStart ,0) - COALESCE(BankPayments.BankCreditStart ,0), 0) as StartCredit,
    IIF(COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0) < 0,
        COALESCE(BankPayments.BankCreditStartCurrency ,0) - COALESCE(BankPayments.BankDebitStartCurrency ,0), 0) as StartDebitCurrency,
    IIF(COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0) > 0,
        COALESCE(BankPayments.BankDebitStartCurrency ,0) - COALESCE(BankPayments.BankCreditStartCurrency ,0), 0) as StartCreditCurrency,
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
    --StartEnd From Bank_Payments ---------------------------------------------------------------------------
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
            "Bank_Payments"."Purpose_Account_Id" = 96 AND
            "Bank_Payments"."Payment_Date" <= @EndDate
        ) AS b
      GROUP BY
        b.Contractor_Id, b.CurrencyId
    ) AS BankPayments
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
            b."Purpose_Account_Id" = 96 AND
            (b."Payment_Date" BETWEEN @StartDate AND @EndDate) AND
            b."Direction" = -1
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
            b."Purpose_Account_Id" = 96 AND
            (b."Payment_Date" BETWEEN @StartDate AND @EndDate) AND
            b."Direction" = 1

) AS PeriodDebitCredit
ON  StartEnd.Contractor_Id = PeriodDebitCredit.Contractor_Id AND StartEnd.CurrencyId = PeriodDebitCredit.CurrencyId

LEFT JOIN "Currency" c ON StartEnd.CurrencyId = c."Id"
LEFT JOIN "Contractors" co ON StartEnd.Contractor_Id = co."Id"
LEFT JOIN Accounts a ON PeriodDebitCredit.AccountId = a.ID

WHERE
   (StartEnd.StartDebit + StartEnd.StartDebitCurrency + StartEnd.StartCredit + StartEnd.StartCreditCurrency +
    COALESCE(PeriodDebitCredit.PeriodPriceCurrency, 0) + COALESCE(PeriodDebitCredit.PeriodPrice, 0)) > 0

ORDER BY 1
