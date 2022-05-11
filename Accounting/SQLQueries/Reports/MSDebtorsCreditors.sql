SELECT
    "Contractors"."Name" AS "Contractor_Name",
    "Contractors"."Srn" AS "Contractor_Srn",
    ABS(COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0)) AS "Price",
    TRIM(IIF(COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0) < 0, 'Дебиторы', 'Кредиторы')) AS "Deb_Cred"
FROM
    "Contractors"
LEFT OUTER JOIN
(
    SELECT
        Orders.Vendor_Id AS "Contractor_Id",
        SUM(Orders.Total_Price) + COALESCE(SUM(Vat.Price), 0) AS "Price"
    FROM
        Orders, Vat
    WHERE
        Vat.Id = Orders.Id AND
        Orders.Order_Date <= @End_Date AND
        Orders.Checked = 1 AND
        --
		Orders.DEBIT_ACCOUNT_ID != 60 AND
        (Orders."Flag1" = @Flag1 OR Orders."Flag3" = @Flag3 OR Orders."Flag4" = @Flag4) AND
        Orders.Order_Date >= '31.03.2013'
    GROUP BY
        Orders.Vendor_Id
) AS "R"
ON
    "R"."Contractor_Id" = "Contractors"."Id"
LEFT OUTER JOIN
(
    SELECT
        "Bank_Payments"."Contractor_Id",
        SUM("Bank_Payments"."Payment_Price") AS "Price"
    FROM
        "Bank_Payments"
    WHERE
        "Bank_Payments"."Purpose_Account_Id" != 60 AND
		"Bank_Payments"."Direction" = 1 AND
        "Bank_Payments"."Payment_Date" <= @End_Date AND
        --
        "Bank_Payments"."Purpose_Account_Id" IN (@PFlag3, @PFlag4)
    GROUP BY
        "Bank_Payments"."Contractor_Id"
) AS "Payment_Credit"
ON
    "Payment_Credit"."Contractor_Id" = "Contractors"."Id"
LEFT OUTER JOIN
(
    SELECT
        "Bank_Payments"."Contractor_Id",
        SUM("Bank_Payments"."Payment_Price") AS "Price"
    FROM
        "Bank_Payments"
    WHERE
        "Bank_Payments"."Purpose_Account_Id" != 60 AND
		"Bank_Payments"."Direction" = -1 AND
        "Bank_Payments"."Payment_Date" <= @End_Date AND
        --
        "Bank_Payments"."Purpose_Account_Id" IN (@PFlag3, @PFlag4)
    GROUP BY
        "Bank_Payments"."Contractor_Id"
) AS "P"
ON
    "P"."Contractor_Id" = "Contractors"."Id"
WHERE
    ABS(COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0)) <> 0
ORDER BY
    ABS(COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0)), CAST("Contractors"."Srn" AS BIGINT)
