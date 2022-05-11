SELECT
    StartEnd.ContractorsId,
    StartEnd.EmployeesId,
    StartEnd.CurrencyId,
    IIF(StartEnd.ContractorsId = 0, emp.Employee_Number, co."Srn") as PartnerSrn,
    IIF(StartEnd.ContractorsId = 0, emp.FullName, co."Name") as PartnerName,
    cur."Code" as CurrencyName,
    --Start
    IIF(StartEnd.DebitStart - StartEnd.CreditStart > 0, StartEnd.DebitStart - StartEnd.CreditStart, 0) as StartDebit,
    IIF(StartEnd.DebitStart - StartEnd.CreditStart < 0, StartEnd.CreditStart- StartEnd.DebitStart, 0) as StartCredit,
    IIF(StartEnd.DebitStartCurrency - StartEnd.CreditStartCurrency > 0, StartEnd.DebitStartCurrency - StartEnd.CreditStartCurrency, 0) as StartDebitCurrency,
    IIF(StartEnd.DebitStartCurrency - StartEnd.CreditStartCurrency < 0, StartEnd.CreditStartCurrency - StartEnd.DebitStartCurrency, 0) as StartCreditCurrency,
    --Period
    StartEnd.DebitPeriod,
    StartEnd.DebitPeriodCurrency,
    StartEnd.CreditPeriod,
    StartEnd.CreditPeriodCurrency,
    --End
    IIF(StartEnd.DebitEnd - StartEnd.CreditEnd > 0, StartEnd.DebitEnd - StartEnd.CreditEnd, 0) as EndDebit,
    IIF(StartEnd.DebitEnd - StartEnd.CreditEnd < 0, StartEnd.CreditEnd - StartEnd.DebitEnd, 0) as EndCredit,
    IIF(StartEnd.DebitEndCurrency - StartEnd.CreditEndCurrency > 0, StartEnd.DebitEndCurrency - StartEnd.CreditEndCurrency, 0) as EndDebitCurrency,
    IIF(StartEnd.DebitEndCurrency - StartEnd.CreditEndCurrency < 0, StartEnd.CreditEndCurrency - StartEnd.DebitEndCurrency, 0) as EndCreditCurrency
FROM
  (
    SELECT 
        IIF(AllCalcWithBuyers.ContractorsId IS NULL, AllBankPayments.ContractorsId, AllCalcWithBuyers.ContractorsId) AS ContractorsId,
        IIF(AllCalcWithBuyers.EmployeesId IS NULL, AllBankPayments.EmployeesId, AllCalcWithBuyers.EmployeesId) AS EmployeesId,
        IIF(AllCalcWithBuyers.CurrencyId IS NULL, AllBankPayments.CurrencyId, AllCalcWithBuyers.CurrencyId) AS CurrencyId,
        --
        COALESCE(AllCalcWithBuyers.CalcDebitStart, 0) + COALESCE(AllBankPayments.BankDebitStart, 0) AS DebitStart,
        COALESCE(AllCalcWithBuyers.CalcDebitStartCurrency, 0) + COALESCE(AllBankPayments.BankDebitStartCurrency, 0) AS DebitStartCurrency,
        COALESCE(AllCalcWithBuyers.CalcCreditStart, 0) + COALESCE(AllBankPayments.BankCreditStart, 0) AS CreditStart,
        COALESCE(AllCalcWithBuyers.CalcCreditStartCurrency, 0) + COALESCE(AllBankPayments.BankCreditStartCurrency, 0) AS CreditStartCurrency,
        --
        COALESCE(AllCalcWithBuyers.CalcDebitPeriod, 0) + COALESCE(AllBankPayments.BankDebitPeriod, 0) AS DebitPeriod,
        COALESCE(AllCalcWithBuyers.CalcDebitPeriodCurrency, 0) + COALESCE(AllBankPayments.BankDebitPeriodCurrency, 0) AS DebitPeriodCurrency,
        COALESCE(AllCalcWithBuyers.CalcCreditPeriod, 0) + COALESCE(AllBankPayments.BankCreditPeriod, 0) AS CreditPeriod,
        COALESCE(AllCalcWithBuyers.CalcCreditPeriodCurrency, 0) + COALESCE(AllBankPayments.BankCreditPeriodCurrency, 0) AS CreditPeriodCurrency,
        --
        COALESCE(AllCalcWithBuyers.CalcDebitEnd, 0) + COALESCE(AllBankPayments.BankDebitEnd, 0) AS DebitEnd,
        COALESCE(AllCalcWithBuyers.CalcDebitEndCurrency, 0) + COALESCE(AllBankPayments.BankDebitEndCurrency, 0) AS DebitEndCurrency,
        COALESCE(AllCalcWithBuyers.CalcCreditEnd, 0) + COALESCE(AllBankPayments.BankCreditEnd, 0) AS CreditEnd,
        COALESCE(AllCalcWithBuyers.CalcCreditEndCurrency, 0) + COALESCE(AllBankPayments.BankCreditEndCurrency, 0) AS CreditEndCurrency

     FROM

    --StartEnd From CalcWithBuyers ---------------------------------------------------------------------------
    (
     SELECT
        c.ContractorsId,
        c.EmployeesId,
        c.CurrencyId,
        --
        SUM(c.CalcDebitStart) AS CalcDebitStart,
        SUM(c.CalcDebitStartCurrency) AS CalcDebitStartCurrency,
        SUM(c.CalcCreditStart) AS CalcCreditStart,
        SUM(c.CalcCreditStartCurrency) AS CalcCreditStartCurrency,
        --
        SUM(c.CalcDebitPeriod) AS CalcDebitPeriod,
        SUM(c.CalcDebitPeriodCurrency) AS CalcDebitPeriodCurrency,
        SUM(c.CalcCreditPeriod) AS CalcCreditPeriod,
        SUM(c.CalcCreditPeriodCurrency) AS CalcCreditPeriodCurrency,
        --
        SUM(c.CalcDebitEnd) AS CalcDebitEnd,
        SUM(c.CalcDebitEndCurrency) AS CalcDebitEndCurrency,
        SUM(c.CalcCreditEnd) AS CalcCreditEnd,
        SUM(c.CalcCreditEndCurrency) AS CalcCreditEndCurrency
        --
      FROM
        (SELECT
            COALESCE(cw."ContractorsId", 0) AS ContractorsId,
            COALESCE(cw."EmployeesId", 0) as EmployeesId,
            IIF(cw."CurrencyRatesId" is NULL , 1, cur."Currency_Id") as CurrencyId,
            -- CalcDebitStart
            IIF(cw."AccountingOperationId" = 1 AND cw."DocumentDate" < @StartDate, cw."Payment", 0) AS CalcDebitStart,
            IIF(cw."AccountingOperationId" = 1 AND cw."DocumentDate" < @StartDate, COALESCE(cur."CurrencyPayment", 0), 0) AS CalcDebitStartCurrency,
            -- CalcCreditStart
            IIF(cw."AccountingOperationId" = 2 AND cw."DocumentDate" < @StartDate, cw."Payment", 0) AS CalcCreditStart,
            IIF(cw."AccountingOperationId" = 2 AND cw."DocumentDate" < @StartDate, COALESCE(cur."CurrencyPayment", 0), 0) AS CalcCreditStartCurrency,
            -- CalcDebitPeriod
            IIF(cw."AccountingOperationId" = 1 AND cw."DocumentDate" >= @StartDate, cw."Payment", 0) AS CalcDebitPeriod,
            IIF(cw."AccountingOperationId" = 1 AND cw."DocumentDate" >= @StartDate, COALESCE(cur."CurrencyPayment", 0), 0) AS CalcDebitPeriodCurrency,
            -- CalcCreditPeriod
            IIF(cw."AccountingOperationId" = 2 AND cw."DocumentDate" >= @StartDate, cw."Payment", 0) AS CalcCreditPeriod,
            IIF(cw."AccountingOperationId" = 2 AND cw."DocumentDate" >= @StartDate, COALESCE(cur."CurrencyPayment", 0), 0) AS CalcCreditPeriodCurrency,
            -- CalcDebitEnd
            IIF(cw."AccountingOperationId" = 1, cw."Payment", 0) AS CalcDebitEnd,
            IIF(cw."AccountingOperationId" = 1, COALESCE(cur."CurrencyPayment", 0), 0) AS CalcDebitEndCurrency,
            -- CalcCreditEnd
            IIF(cw."AccountingOperationId" = 2, cw."Payment", 0) AS CalcCreditEnd,
            IIF(cw."AccountingOperationId" = 2, COALESCE(cur."CurrencyPayment", 0), 0) AS CalcCreditEndCurrency
            --
          FROM
            "CalcWithBuyers" cw
          LEFT JOIN
            "Currency_Rates" as cur ON cw."CurrencyRatesId" = cur."Id"
          WHERE
            cw."PurposeAccountId" = @PurposeAccountId AND
            cw."DocumentDate" <= @EndDate AND
            cw."DocumentDate" >= @SelectionDate) AS c
      GROUP BY
        c.ContractorsId,
        c.EmployeesId,
        c.CurrencyId
     ) AS AllCalcWithBuyers

     --StartEnd From Bank_Payments ---------------------------------------------------------------------------
     FULL JOIN
     (
       SELECT
        b.ContractorsId,
        b.EmployeesId,
        b.CurrencyId,
        -- BankDebitStart
        SUM(b.BankDebitStartCurrency) AS BankDebitStartCurrency,
        SUM(b.BankDebitStart) AS BankDebitStart,
        -- BankCreditStart
        SUM(b.BankCreditStartCurrency) AS BankCreditStartCurrency,
        SUM(b.BankCreditStart) AS BankCreditStart,
        -- BankDebitPeriod
        SUM(b.BankDebitPeriodCurrency) AS BankDebitPeriodCurrency,
        SUM(b.BankDebitPeriod) AS BankDebitPeriod,
        -- BankCreditPeriod
        SUM(b.BankCreditPeriodCurrency) AS BankCreditPeriodCurrency,
        SUM(b.BankCreditPeriod) AS BankCreditPeriod,
        -- BankDebitEnd
        SUM(b.BankDebitEndCurrency) AS BankDebitEndCurrency,
        SUM(b.BankDebitEnd) AS BankDebitEnd,
        -- BankCreditEnd
        SUM(b.BankCreditEndCurrency) AS BankCreditEndCurrency,
        SUM(b.BankCreditEnd) AS BankCreditEnd
      FROM
        (SELECT
            COALESCE(bp."Contractor_Id", 0) AS ContractorsId,
            COALESCE(bp."EmployeesId", 0) AS EmployeesId,
            IIF(cur_p."Id" IS NOT NULL, cur_p."Currency_Id", bp."CurrencyId") as CurrencyId,
            -- BankDebitStart
            IIF(bp."Direction" = -1 AND  bp."Payment_Date" < @StartDate AND bp."Purpose_Account_Id" = @PurposeAccountId,
                IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp."Payment_PriceCurrency"),
                0) AS BankDebitStartCurrency,
            IIF(bp."Direction" = -1 AND  bp."Payment_Date" < @StartDate AND bp."Purpose_Account_Id" = @PurposeAccountId, bp."Payment_Price", 0)
                   AS BankDebitStart,
            -- BankCreditStart          
            IIF(((bp."Purpose_Account_Id" = @PurposeAccountId AND bp."Direction" = 1) OR (bp."Bank_Account_Id" = @PurposeAccountId))
                         AND bp."Payment_Date" < @StartDate,
                IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp."Payment_PriceCurrency"),
                0) AS BankCreditStartCurrency,
            IIF(((bp."Purpose_Account_Id" = @PurposeAccountId AND bp."Direction" = 1) OR (bp."Bank_Account_Id" = @PurposeAccountId))
                         AND bp."Payment_Date" < @StartDate, bp."Payment_Price", 0)
                   AS BankCreditStart,
            -- BankDebitPeriod
           IIF(bp."Direction" = -1 AND bp."Payment_Date" >= @StartDate AND bp."Purpose_Account_Id" = @PurposeAccountId,
                IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp."Payment_PriceCurrency"),
                0) AS BankDebitPeriodCurrency,
            IIF(bp."Direction" = -1 AND  bp."Payment_Date" >= @StartDate AND bp."Purpose_Account_Id" = @PurposeAccountId, bp."Payment_Price", 0)
                   AS BankDebitPeriod,
            -- BankCreditPeriod
            IIF(((bp."Purpose_Account_Id" = @PurposeAccountId AND bp."Direction" = 1) OR (bp."Bank_Account_Id" = @PurposeAccountId))
                         AND bp."Payment_Date" >= @StartDate,
                IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp."Payment_PriceCurrency"),
                0) AS BankCreditPeriodCurrency,
            IIF(((bp."Purpose_Account_Id" = @PurposeAccountId AND bp."Direction" = 1) OR (bp."Bank_Account_Id" = @PurposeAccountId))
                         AND bp."Payment_Date" >= @StartDate, bp."Payment_Price", 0)
                   AS BankCreditPeriod,
            -- BankDebitEnd
            IIF(bp."Direction" = -1 AND bp."Purpose_Account_Id" = @PurposeAccountId,
                IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp."Payment_PriceCurrency"),
                0) AS BankDebitEndCurrency,
            IIF(bp."Direction" = -1 AND bp."Purpose_Account_Id" = @PurposeAccountId, bp."Payment_Price", 0) AS BankDebitEnd,
            -- BankCreditEnd
            IIF(((bp."Purpose_Account_Id" = @PurposeAccountId AND bp."Direction" = 1) OR (bp."Bank_Account_Id" = @PurposeAccountId)),
                IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp."Payment_PriceCurrency"),
                0) AS BankCreditEndCurrency,
            IIF(((bp."Purpose_Account_Id" = @PurposeAccountId AND bp."Direction" = 1) OR (bp."Bank_Account_Id" = @PurposeAccountId)), bp."Payment_Price", 0) AS BankCreditEnd
            --
          FROM
            "Bank_Payments" bp
          LEFT JOIN
            "Currency_Rates" as cur_p ON bp."CurrencyRatesConvertId" = cur_p."Id"
          WHERE
            (bp."Purpose_Account_Id" = @PurposeAccountId OR bp."Bank_Account_Id" = @PurposeAccountId) AND
            bp."Payment_Date" <= @EndDate AND
            bp."Payment_Date" >= @SelectionDate) AS b
      GROUP BY
        b.ContractorsId,
        b.EmployeesId,
        b.CurrencyId
     ) AS AllBankPayments

    ON AllCalcWithBuyers.ContractorsId = AllBankPayments.ContractorsId AND
       AllCalcWithBuyers.EmployeesId = AllBankPayments.EmployeesId AND
       AllCalcWithBuyers.CurrencyId = AllBankPayments.CurrencyId

   ) AS StartEnd

LEFT JOIN
      "Currency" cur ON StartEnd.CurrencyId = cur."Id"
LEFT JOIN
      "Contractors" co ON StartEnd.ContractorsId = co."Id"
LEFT JOIN
      Responsible as emp ON StartEnd.EmployeesId = emp.EMPLOYEEID

WHERE
    (IIF(StartEnd.DebitStart - StartEnd.CreditStart < 0, StartEnd.CreditStart- StartEnd.DebitStart, 0) +
    IIF(StartEnd.DebitStart - StartEnd.CreditStart > 0, StartEnd.DebitStart - StartEnd.CreditStart, 0) +
    IIF(StartEnd.DebitStartCurrency - StartEnd.CreditStartCurrency < 0, StartEnd.CreditStartCurrency - StartEnd.DebitStartCurrency, 0) +
    IIF(StartEnd.DebitStartCurrency - StartEnd.CreditStartCurrency > 0, StartEnd.DebitStartCurrency - StartEnd.CreditStartCurrency, 0) +
    StartEnd.DebitPeriod +
    StartEnd.DebitPeriodCurrency +
    StartEnd.CreditPeriod +
    StartEnd.CreditPeriodCurrency) > 0

ORDER BY
    StartEnd.ContractorsId,
    StartEnd.EmployeesId,
    StartEnd.CurrencyId


