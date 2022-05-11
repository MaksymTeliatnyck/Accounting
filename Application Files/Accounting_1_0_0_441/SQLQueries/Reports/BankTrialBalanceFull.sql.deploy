SELECT
    SourseB."Bank_Account_Id",
    SourseB."Purpose_Account_Id",
    Bank_Accounts.NUM as BankNum,
    Purpose_Accounts.NUM as PurposeNum,
-- FromPeriod
    SourseB.Debit_FromPeriod,
    SourseB.Credit_FromPeriod,
    SourseB."Direction"
FROM
(
  SELECT
   SourseA."Purpose_Account_Id",
   SourseA."Bank_Account_Id",
   SourseA."Direction",
-- FromPeriod
    SUM(COALESCE(SourseA.BankDebitFromPeriod,0)) AS Debit_FromPeriod,
    SUM(COALESCE(SourseA.BankCreditFromPeriod,0)) AS Credit_FromPeriod
  FROM
    (
    SELECT
        "Bank_Payments"."Purpose_Account_Id",
        "Bank_Payments"."Bank_Account_Id",
        "Bank_Payments"."Direction",
    -- FromPeriod
        -- DebitFromPeriod
        IIF("Bank_Payments"."Direction" = 1, "Bank_Payments"."Payment_Price", 0) AS BankDebitFromPeriod,
        -- CreditFromPeriod
        IIF("Bank_Payments"."Direction" = -1, "Bank_Payments"."Payment_Price", 0) AS BankCreditFromPeriod
	  FROM
        "Bank_Payments"
      WHERE
        ("Bank_Payments"."Payment_Date" >= @Start_Date AND "Bank_Payments"."Payment_Date" <= @End_Date)
    ) AS SourseA
    GROUP BY SourseA."Direction",SourseA."Bank_Account_Id",SourseA."Purpose_Account_Id"
) SourseB

LEFT JOIN
    ACCOUNTS as Purpose_Accounts ON SourseB."Purpose_Account_Id" = Purpose_Accounts.ID
LEFT JOIN
    ACCOUNTS as Bank_Accounts ON SourseB."Bank_Account_Id" = Bank_Accounts.ID

WHERE
    (Bank_Accounts.NUM STARTING '31' AND Bank_Accounts."Type" = 1)

ORDER BY
    SourseB."Direction",
    Bank_Accounts.NUM,
    Purpose_Accounts.NUM
	
