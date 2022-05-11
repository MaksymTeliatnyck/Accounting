    SELECT
        SourseB."Payment_Date",
        ACCOUNTS.NUM,
        SourseB."Bank_Account_Id",
    -- PrewPeriod
        SourseB.Debit_PrewPeriod,
        SourseB.Credit_PrewPeriod,
    -- FromPeriod
        SourseB.Debit_FromPeriod,
        SourseB.Credit_FromPeriod,
    --EndPeriod
        SourseB.Debit_EndPeriod,
        SourseB.Credit_EndPeriod
    FROM
    (
      SELECT
       SourseA."Payment_Date",
       SourseA."Purpose_Account_Id",
       SourseA."Bank_Account_Id",
    -- PrewPeriod
        SUM(COALESCE(SourseA.BankDebitPrewPeriod,0)) AS Debit_PrewPeriod,
        SUM(COALESCE(SourseA.BankCreditPrewPeriod,0)) AS Credit_PrewPeriod,
    -- FromPeriod
        SUM(COALESCE(SourseA.BankDebitFromPeriod,0)) AS Debit_FromPeriod,
        SUM(COALESCE(SourseA.BankCreditFromPeriod,0)) AS Credit_FromPeriod,
    --EndPeriod
        SUM(COALESCE(SourseA.BankDebitEndPeriod,0)) AS Debit_EndPeriod,
        SUM(COALESCE(SourseA.BankCreditEndPeriod,0)) AS Credit_EndPeriod
      FROM
        (
        SELECT
            "Bank_Payments"."Payment_Date",
            "Bank_Payments"."Purpose_Account_Id",
            "Bank_Payments"."Bank_Account_Id",
        -- PrewPeriod
            -- DebitPrewPeriod
            IIF(("Bank_Payments"."Direction" = 1 AND "Bank_Payments"."Payment_Date" < @Start_Date), "Bank_Payments"."Payment_Price", 0) AS BankDebitPrewPeriod,
            -- CreditPrewPeriod
            IIF(("Bank_Payments"."Direction" = -1 AND "Bank_Payments"."Payment_Date" < @Start_Date), "Bank_Payments"."Payment_Price", 0) AS BankCreditPrewPeriod,
        -- FromPeriod
            -- DebitFromPeriod
            IIF(("Bank_Payments"."Direction" = 1 AND "Bank_Payments"."Payment_Date" >= @Start_Date AND "Bank_Payments"."Payment_Date" <= @End_Date),
                    "Bank_Payments"."Payment_Price", 0) AS BankDebitFromPeriod,
            -- CreditFromPeriod
            IIF(("Bank_Payments"."Direction" = -1 AND "Bank_Payments"."Payment_Date" >= @Start_Date AND "Bank_Payments"."Payment_Date" <= @End_Date),
                    "Bank_Payments"."Payment_Price", 0) AS BankCreditFromPeriod,
        --EndPeriod
            -- DebittEndPeriod
            IIF(("Bank_Payments"."Direction" = 1 AND "Bank_Payments"."Payment_Date" <= @End_Date), "Bank_Payments"."Payment_Price", 0) AS BankDebitEndPeriod,
            -- CreditEndPeriod
            IIF(("Bank_Payments"."Direction" = -1 AND "Bank_Payments"."Payment_Date" <= @End_Date), "Bank_Payments"."Payment_Price", 0) AS BankCreditEndPeriod
          FROM
            "Bank_Payments"
          WHERE  "Bank_Payments"."Bank_Account_Id"=@Bank_Account AND "Bank_Payments"."Payment_Date" <= @End_Date
        ) AS SourseA
        GROUP BY SourseA."Payment_Date",SourseA."Purpose_Account_Id" , SourseA."Bank_Account_Id"
    ) SourseB
    LEFT JOIN ACCOUNTS ON ACCOUNTS.ID=SourseB."Purpose_Account_Id"
    ORDER BY SourseB."Payment_Date", ACCOUNTS.NUM