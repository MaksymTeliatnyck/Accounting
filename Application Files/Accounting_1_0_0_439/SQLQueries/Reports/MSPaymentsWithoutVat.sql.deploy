SELECT
    "Bank_Payments"."Contractor_Id", "Contractors"."Name", "Contractors"."Srn",
    "Bank_Payments"."Payment_Date", "Bank_Payments"."Payment_Document",
    "Bank_Payments"."Payment_Price", Accounts.Num AS "Payment_Purpose_Num"
FROM
    "Bank_Payments", Accounts, "Contractors"
WHERE
    "Bank_Payments"."Purpose_Account_Id" = Accounts.Id AND
    "Bank_Payments"."Contractor_Id" = "Contractors"."Id" AND
    "Bank_Payments"."Purpose_Account_Id" IN (@PFlag3, @PFlag4) AND
    (LOWER("Bank_Payments"."Purpose") CONTAINING 'без ндс' OR LOWER("Bank_Payments"."Purpose") CONTAINING 'без пдв') AND
    "Bank_Payments"."Payment_Date" BETWEEN @Start_Date AND @End_Date AND
	"Bank_Payments"."Direction" = -1
ORDER BY
    "Contractors"."Name",
    "Bank_Payments"."Payment_Date", "Bank_Payments"."Payment_Document"