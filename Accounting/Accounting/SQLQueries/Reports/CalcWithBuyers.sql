SELECT
    StartEnd.ContractorsId,
    StartEnd.EmployeesId,
    StartEnd.CurrencyId,
    IIF(StartEnd.ContractorsId = 0, emp.Employee_Number, co."Srn") as PartnerSrn,
    IIF(StartEnd.ContractorsId = 0, emp.FullName, co."Name") as PartnerName,
    PeriodDebitCredit.Comment,
    PeriodDebitCredit.Purpose,
    cur."Code" as CurrencyName,
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
    COALESCE(PeriodDebitCredit.PeriodPriceCurrency, 0) AS PeriodPriceCurrency,
    COALESCE(PeriodDebitCredit.PeriodPrice, 0) AS PeriodPrice,
    PeriodDebitCredit.Rate,
    COALESCE(PeriodDebitCredit.FlagDebitCredit, 0) AS FlagDebitCredit
FROM
--Start and End Saldo-----------------------------------------------------------------------------------------------------------
(SELECT
    IIF(AllCalcWithBuyers.ContractorsId IS NULL, AllBankPayments.ContractorsId, AllCalcWithBuyers.ContractorsId) as ContractorsId,
    IIF(AllCalcWithBuyers.EmployeesId IS NULL, AllBankPayments.EmployeesId, AllCalcWithBuyers.EmployeesId) as EmployeesId,
    IIF(AllCalcWithBuyers.CurrencyId IS NULL, AllBankPayments.CurrencyId, AllCalcWithBuyers.CurrencyId) as CurrencyId,
    --Start
    IIF((COALESCE(AllCalcWithBuyers.CalcDebitStart ,0) + COALESCE(AllBankPayments.BankDebitStart ,0)) - (COALESCE(AllBankPayments.BankCreditStart ,0) + COALESCE(AllCalcWithBuyers.CalcCreditStart ,0)) > 0,
        (COALESCE(AllCalcWithBuyers.CalcDebitStart ,0) + COALESCE(AllBankPayments.BankDebitStart ,0)) - (COALESCE(AllBankPayments.BankCreditStart ,0) + COALESCE(AllCalcWithBuyers.CalcCreditStart ,0)), 0) as StartDebit,

    IIF((COALESCE(AllCalcWithBuyers.CalcDebitStart ,0) + COALESCE(AllBankPayments.BankDebitStart ,0)) - (COALESCE(AllBankPayments.BankCreditStart ,0) + COALESCE(AllCalcWithBuyers.CalcCreditStart ,0)) < 0,
        (COALESCE(AllBankPayments.BankCreditStart ,0) + COALESCE(AllCalcWithBuyers.CalcCreditStart ,0)) - (COALESCE(AllCalcWithBuyers.CalcDebitStart ,0) + COALESCE(AllBankPayments.BankDebitStart ,0)), 0) as StartCredit,

    IIF((COALESCE(AllCalcWithBuyers.CalcDebitStartCurrency ,0) + COALESCE(AllBankPayments.BankDebitStartCurrency ,0)) - (COALESCE(AllBankPayments.BankCreditStartCurrency ,0) + COALESCE(AllCalcWithBuyers.CalcCreditStartCurrency ,0)) > 0,
        (COALESCE(AllCalcWithBuyers.CalcDebitStartCurrency ,0) + COALESCE(AllBankPayments.BankDebitStartCurrency ,0)) - (COALESCE(AllBankPayments.BankCreditStartCurrency ,0) + COALESCE(AllCalcWithBuyers.CalcCreditStartCurrency ,0)), 0) as StartDebitCurrency,

    IIF((COALESCE(AllCalcWithBuyers.CalcDebitStartCurrency ,0) + COALESCE(AllBankPayments.BankDebitStartCurrency ,0)) - (COALESCE(AllBankPayments.BankCreditStartCurrency ,0) + COALESCE(AllCalcWithBuyers.CalcCreditStartCurrency ,0)) < 0,
        (COALESCE(AllBankPayments.BankCreditStartCurrency ,0) + COALESCE(AllCalcWithBuyers.CalcCreditStartCurrency ,0)) - (COALESCE(AllCalcWithBuyers.CalcDebitStartCurrency ,0) + COALESCE(AllBankPayments.BankDebitStartCurrency ,0)), 0) as StartCreditCurrency,
    --End
    IIF((COALESCE(AllCalcWithBuyers.CalcDebitEnd ,0) + COALESCE(AllBankPayments.BankDebitEnd ,0)) - (COALESCE(AllBankPayments.BankCreditEnd ,0) + COALESCE(AllCalcWithBuyers.CalcCreditEnd ,0)) > 0,
        (COALESCE(AllCalcWithBuyers.CalcDebitEnd ,0) + COALESCE(AllBankPayments.BankDebitEnd ,0)) - (COALESCE(AllBankPayments.BankCreditEnd ,0) + COALESCE(AllCalcWithBuyers.CalcCreditEnd ,0)), 0) as EndDebit,

    IIF((COALESCE(AllCalcWithBuyers.CalcDebitEnd ,0) + COALESCE(AllBankPayments.BankDebitEnd ,0)) - (COALESCE(AllBankPayments.BankCreditEnd ,0) + COALESCE(AllCalcWithBuyers.CalcCreditEnd ,0)) < 0,
        (COALESCE(AllBankPayments.BankCreditEnd ,0) + COALESCE(AllCalcWithBuyers.CalcCreditEnd ,0)) - (COALESCE(AllCalcWithBuyers.CalcDebitEnd ,0) + COALESCE(AllBankPayments.BankDebitEnd ,0)), 0) as EndCredit,

    IIF((COALESCE(AllCalcWithBuyers.CalcDebitEndCurrency ,0) + COALESCE(AllBankPayments.BankDebitEndCurrency ,0)) - (COALESCE(AllBankPayments.BankCreditEndCurrency ,0) + COALESCE(AllCalcWithBuyers.CalcCreditEndCurrency ,0)) > 0,
        (COALESCE(AllCalcWithBuyers.CalcDebitEndCurrency ,0) + COALESCE(AllBankPayments.BankDebitEndCurrency ,0)) - (COALESCE(AllBankPayments.BankCreditEndCurrency ,0) + COALESCE(AllCalcWithBuyers.CalcCreditEndCurrency ,0)), 0) as EndDebitCurrency,

    IIF((COALESCE(AllCalcWithBuyers.CalcDebitEndCurrency ,0) + COALESCE(AllBankPayments.BankDebitEndCurrency ,0)) - (COALESCE(AllBankPayments.BankCreditEndCurrency ,0) + COALESCE(AllCalcWithBuyers.CalcCreditEndCurrency ,0)) < 0,
        (COALESCE(AllBankPayments.BankCreditEndCurrency ,0) + COALESCE(AllCalcWithBuyers.CalcCreditEndCurrency ,0)) - (COALESCE(AllCalcWithBuyers.CalcDebitEndCurrency ,0) + COALESCE(AllBankPayments.BankDebitEndCurrency ,0)), 0) as EndCreditCurrency
  FROM
    --StartEnd From CalcWithBuyers ---------------------------------------------------------------------------
    (SELECT
        c.ContractorsId,
        c.EmployeesId,
        c.CurrencyId,
        --
        SUM(c.CalcDebitStart) AS CalcDebitStart,
        SUM(c.CalcDebitStartCurrency) AS CalcDebitStartCurrency,
        SUM(c.CalcCreditStart) AS CalcCreditStart,
        SUM(c.CalcCreditStartCurrency) AS CalcCreditStartCurrency,
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
    (SELECT
        b.ContractorsId,
        b.EmployeesId,
        b.CurrencyId,
        --
        SUM(b.BankDebitStart) AS BankDebitStart,
        SUM(b.BankDebitStartCurrency) AS BankDebitStartCurrency,
        SUM(b.BankCreditStart) AS BankCreditStart,
        SUM(b.BankCreditStartCurrency) AS BankCreditStartCurrency,
        --
        SUM(b.BankDebitEnd) AS BankDebitEnd,
        SUM(b.BankDebitEndCurrency) AS BankDebitEndCurrency,
        SUM(b.BankCreditEnd) AS BankCreditEnd,
        SUM(b.BankCreditEndCurrency) AS BankCreditEndCurrency

      FROM
        (SELECT
            COALESCE(bp."Contractor_Id", 0) AS ContractorsId,
            COALESCE(bp."EmployeesId", 0) AS EmployeesId,
            IIF(cur_p."Id" IS NOT NULL, cur_p."Currency_Id", bp."CurrencyId") as CurrencyId,
            -- BankDebitStart
            IIF(bp."Direction" = -1 AND  bp."Payment_Date" < @StartDate AND bp."Purpose_Account_Id" = @PurposeAccountId, bp."Payment_Price", 0) AS BankDebitStart,
            IIF(bp."Direction" = -1 AND  bp."Payment_Date" < @StartDate AND bp."Purpose_Account_Id" = @PurposeAccountId,
                IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp."Payment_PriceCurrency"),
                0) AS BankDebitStartCurrency,
            -- BankCreditStart
            IIF(((bp."Purpose_Account_Id" = @PurposeAccountId AND bp."Direction" = 1) OR (bp."Bank_Account_Id" = @PurposeAccountId))
                         AND bp."Payment_Date" < @StartDate, bp."Payment_Price", 0) AS BankCreditStart,
            IIF(((bp."Purpose_Account_Id" = @PurposeAccountId AND bp."Direction" = 1) OR (bp."Bank_Account_Id" = @PurposeAccountId))
                         AND bp."Payment_Date" < @StartDate,
                IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp."Payment_PriceCurrency"),
                0) AS BankCreditStartCurrency,
            -- BankDebitEnd
            IIF(bp."Direction" = -1 AND bp."Purpose_Account_Id" = @PurposeAccountId, bp."Payment_Price", 0) AS BankDebitEnd,
            IIF(bp."Direction" = -1 AND bp."Purpose_Account_Id" = @PurposeAccountId,
                IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp."Payment_PriceCurrency"),
                0) AS BankDebitEndCurrency,
            -- BankCreditEnd
            IIF(((bp."Purpose_Account_Id" = @PurposeAccountId AND bp."Direction" = 1) OR (bp."Bank_Account_Id" = @PurposeAccountId)), bp."Payment_Price", 0) AS BankCreditEnd,
            IIF(((bp."Purpose_Account_Id" = @PurposeAccountId AND bp."Direction" = 1) OR (bp."Bank_Account_Id" = @PurposeAccountId)),
                IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp."Payment_PriceCurrency"),
                0) AS BankCreditEndCurrency
            --
          FROM
            "Bank_Payments" bp
          LEFT JOIN
            "Currency_Rates" as cur_p ON bp."CurrencyRatesConvertId" = cur_p."Id"
          WHERE
           (bp."Bank_Account_Id" = @PurposeAccountId OR bp."Purpose_Account_Id" = @PurposeAccountId) AND
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

--Period documents----------------------------------------------------------------------------------------------------
FULL JOIN
    --Period from CalcWithBuyers-------------------------------------------------------------------------------------------
(SELECT
      COALESCE(cw_p."ContractorsId", 0) AS ContractorsId,
      COALESCE(cw_p."EmployeesId", 0) AS EmployeesId,
      IIF(cw_p."CurrencyRatesId" is NULL , 1, cur_p."Currency_Id") as CurrencyId,
      cw_p."BalanceAccountId" AS AccountId,
      cw_p."DocumentName" AS Payment_Document,
      cw_p."DocumentDate" AS Payment_Date,
      cw_p."Payment" AS PeriodPrice,
      cur_p."CurrencyPayment" AS PeriodPriceCurrency,
      cur_p."Rate" AS Rate,
      cw_p."Comment" AS Comment,
      '' AS Purpose,
      1 as FlagDebitCredit
      FROM
        "CalcWithBuyers" cw_p
      LEFT JOIN
        "Currency_Rates" as cur_p ON cw_p."CurrencyRatesId" = cur_p."Id"
      WHERE
        cw_p."AccountingOperationId" = 1 AND
        cw_p."PurposeAccountId" = @PurposeAccountId AND
        cw_p."DocumentDate" >= @SelectionDate AND
        (cw_p."DocumentDate" BETWEEN @StartDate AND @EndDate)

   UNION ALL

     SELECT
          COALESCE(cw_p."ContractorsId", 0) AS ContractorsId,
          COALESCE(cw_p."EmployeesId", 0) AS EmployeesId,
          IIF(cw_p."CurrencyRatesId" is NULL , 1, cur_p."Currency_Id") as CurrencyId,
          cw_p."BalanceAccountId" AS AccountId,
          cw_p."DocumentName" AS Payment_Document,
          cw_p."DocumentDate" AS Payment_Date,
          cw_p."Payment" AS PeriodPrice,
          cur_p."CurrencyPayment" AS PeriodPriceCurrency,
          cur_p."Rate" AS Rate,
          cw_p."Comment" AS Comment,
          '' AS Purpose,
          -1 as FlagDebitCredit
          FROM
            "CalcWithBuyers" cw_p
          LEFT JOIN
            "Currency_Rates" as cur_p ON cw_p."CurrencyRatesId" = cur_p."Id"
          WHERE
            cw_p."AccountingOperationId" = 2 AND
            cw_p."PurposeAccountId" = @PurposeAccountId AND
            cw_p."DocumentDate" >= @SelectionDate AND
            (cw_p."DocumentDate" BETWEEN @StartDate AND @EndDate)

   UNION ALL
     --Period from BankPayments-------------------------------------------------------------------------------------------
     SELECT
            COALESCE(bp_p1."Contractor_Id", 0) AS ContractorsId,
            COALESCE(bp_p1."EmployeesId", 0) AS EmployeesId,
            IIF(cur_p."Id" IS NOT NULL, cur_p."Currency_Id", bp_p1."CurrencyId") as CurrencyId,
            bp_p1."Bank_Account_Id" AS AccountId,
            bp_p1."Payment_Document" AS Payment_Document,
            bp_p1."Payment_Date" AS Payment_Date,
            bp_p1."Payment_Price" AS PeriodPrice,
            IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp_p1."Payment_PriceCurrency") AS PeriodPriceCurrency,
            IIF(cur_p."Id" IS NOT NULL, cur_p."Rate", bp_p1."Rate") AS Rate,
            '' AS Comment,
            bp_p1."Purpose" as Purpose,
            -1 as FlagDebitCredit
        FROM
            "Bank_Payments" bp_p1
        LEFT JOIN
            "Currency_Rates" as cur_p ON bp_p1."CurrencyRatesConvertId" = cur_p."Id"
        WHERE
            bp_p1."Purpose_Account_Id" = @PurposeAccountId AND
            bp_p1."Direction" = 1 AND
            bp_p1."Payment_Date" >= @SelectionDate AND
            (bp_p1."Payment_Date" BETWEEN @StartDate AND @EndDate)

    UNION ALL

       SELECT
            COALESCE(bp_p2."Contractor_Id", 0) AS ContractorsId,
            COALESCE(bp_p2."EmployeesId", 0) AS EmployeesId,
            IIF(cur_p."Id" IS NOT NULL, cur_p."Currency_Id", bp_p2."CurrencyId") as CurrencyId,
            bp_p2."Bank_Account_Id" AS AccountId,
            bp_p2."Payment_Document" AS Payment_Document,
            bp_p2."Payment_Date" AS Payment_Date,
            bp_p2."Payment_Price" AS PeriodPrice,
            IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp_p2."Payment_PriceCurrency") AS PeriodPriceCurrency,
            IIF(cur_p."Id" IS NOT NULL, cur_p."Rate", bp_p2."Rate") AS Rate,
            '' AS Comment,
            bp_p2."Purpose" as Purpose,
            1 as FlagDebitCredit
        FROM
            "Bank_Payments" bp_p2
        LEFT JOIN
            "Currency_Rates" as cur_p ON bp_p2."CurrencyRatesConvertId" = cur_p."Id"
        WHERE
            bp_p2."Purpose_Account_Id" = @PurposeAccountId AND
            bp_p2."Direction" = -1 AND
            bp_p2."Payment_Date" >= @SelectionDate AND
            (bp_p2."Payment_Date" BETWEEN @StartDate AND @EndDate)
   UNION ALL
        
      SELECT
            COALESCE(bp_p3."Contractor_Id", 0) AS ContractorsId,
            COALESCE(bp_p3."EmployeesId", 0) AS EmployeesId,
            IIF(cur_p."Id" IS NOT NULL, cur_p."Currency_Id", bp_p3."CurrencyId") as CurrencyId,
            bp_p3."Purpose_Account_Id" AS AccountId,
            bp_p3."Payment_Document" AS Payment_Document,
            bp_p3."Payment_Date" AS Payment_Date,
            bp_p3."Payment_Price" AS PeriodPrice,
            IIF(cur_p."Id" IS NOT NULL, cur_p."CurrencyPayment", bp_p3."Payment_PriceCurrency") AS PeriodPriceCurrency,
            IIF(cur_p."Id" IS NOT NULL, cur_p."Rate", bp_p3."Rate") AS Rate,
            '' AS Comment,
            bp_p3."Purpose" as Purpose,
            -1 as FlagDebitCredit
        FROM
            "Bank_Payments" bp_p3
        LEFT JOIN
            "Currency_Rates" as cur_p ON bp_p3."CurrencyRatesConvertId" = cur_p."Id"
        WHERE
            bp_p3."Bank_Account_Id" = @PurposeAccountId AND
            bp_p3."Payment_Date" >= @SelectionDate AND
            (bp_p3."Payment_Date" BETWEEN @StartDate AND @EndDate)

) AS PeriodDebitCredit

ON  StartEnd.ContractorsId = PeriodDebitCredit.ContractorsId AND
    StartEnd.EmployeesId = PeriodDebitCredit.EmployeesId AND
    StartEnd.CurrencyId = PeriodDebitCredit.CurrencyId

LEFT JOIN
      "Currency" cur ON StartEnd.CurrencyId = cur."Id"
LEFT JOIN
      "Contractors" co ON StartEnd.ContractorsId = co."Id"
LEFT JOIN
      Responsible as emp ON StartEnd.EmployeesId = emp.EMPLOYEEID
LEFT JOIN
      Accounts a ON PeriodDebitCredit.AccountId = a.ID

WHERE 
    (StartEnd.StartDebit + StartEnd.StartDebitCurrency + StartEnd.StartCredit +
     StartEnd.StartCreditCurrency + COALESCE(PeriodDebitCredit.PeriodPriceCurrency, 0) +
     COALESCE(PeriodDebitCredit.PeriodPrice, 0)) > 0

ORDER BY
    StartEnd.ContractorsId,
    StartEnd.EmployeesId,
    StartEnd.CurrencyId,
    PeriodDebitCredit.Payment_Date