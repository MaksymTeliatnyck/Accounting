SELECT
    "Contractors"."Srn" AS "Contractor_Srn", "Contractors"."Name" AS "Contractor_Name",
    "Payments"."Payment_Date", "Payments"."Price", "Payments"."Invoice_Num",
    Accounts.Num, "Payments"."Materials_Services"
FROM
    "Payments", "Contractors", Accounts
WHERE
    "Payments"."Contractor_Id" = "Contractors"."Id" AND
    "Payments"."Account_Id" = Accounts.Id AND
    "Payments"."Account_Id" LIKE @Account AND
    "Payments"."Materials_Services" LIKE @Flag AND
    "Payments"."Payment_Date" BETWEEN @Start_Date AND @End_Date
ORDER BY
    "Payments"."Payment_Date"
