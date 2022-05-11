SELECT
    "A"."Begin_Debit", "A"."Begin_Credit",
    "B"."Operation_Date", "B"."Document_Num", "B"."Account_Num",
    "B"."Debit_Price", "B"."Credit_Price",
    "D"."End_Debit", "D"."End_Credit"
FROM
    "Contractors"
LEFT OUTER JOIN
(
    SELECT
        "Contractors"."Id" AS "Contractor_Id",
        IIF(COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0) < 0, ABS(COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0)), NULL) AS "Begin_Debit",
        IIF(COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0) > 0, COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0), NULL) AS "Begin_Credit"
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
            Orders.Order_Date < @Start_Date AND
            Orders.Checked = 1 AND
            --
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
            "Bank_Payments"."Direction" = 1 AND
            "Bank_Payments"."Payment_Date" < @Start_Date AND
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
            "Bank_Payments"."Direction" = -1 AND
            "Bank_Payments"."Payment_Date" < @Start_Date AND
            "Bank_Payments"."Purpose_Account_Id" IN (@PFlag3, @PFlag4)
        GROUP BY
            "Bank_Payments"."Contractor_Id"
    ) AS "P"
    ON
        "P"."Contractor_Id" = "Contractors"."Id"
) AS "A"
ON
    "A"."Contractor_Id" = "Contractors"."Id"
LEFT OUTER JOIN
(
    SELECT
        Orders.Vendor_Id AS "Contractor_Id",
        Orders.Order_Date AS "Operation_Date", 
		Orders.Invoice_Num AS "Document_Num", 
		Accounts.Num AS "Account_Num", 
		NULL AS "Debit_Price", 
		Receipts.Total_Price AS "Credit_Price"
    FROM
        Orders, Receipts, Nomenclatures, Accounts
    WHERE
        Receipts.Order_Id = Orders.Id AND
        Receipts.Nomenclature_Id = Nomenclatures.Id AND
        Nomenclatures.Balance_Account_Id = Accounts.Id AND
        Orders.Vendor_Id = @Contractor AND
        Orders.Order_Date BETWEEN @Start_Date AND @End_Date AND
        Orders.Checked = 1 AND
        --
        (Orders."Flag1" = @Flag1 OR Orders."Flag3" = @Flag3 OR Orders."Flag4" = @Flag4) AND
        Orders.Order_Date >= '31.03.2013'
    UNION
    SELECT
        "Bank_Payments"."Contractor_Id" AS "Contractor_Id",
        "Bank_Payments"."Payment_Date" AS "Operation_Date", "Bank_Payments"."Payment_Document", Accounts.Num AS "Account_Num",
        IIF("Bank_Payments"."Direction" = -1, "Bank_Payments"."Payment_Price", NULL) AS "Debit_Price", 
		IIF("Bank_Payments"."Direction" = 1, "Bank_Payments"."Payment_Price", NULL) AS "Credit_Price"
    FROM
        "Bank_Payments", Accounts
    WHERE
        "Bank_Payments"."Bank_Account_Id" = Accounts.Id AND
        "Bank_Payments"."Contractor_Id" = @Contractor AND
        "Bank_Payments"."Payment_Date" BETWEEN @Start_Date AND @End_Date AND
        --
        "Bank_Payments"."Purpose_Account_Id" IN (@PFlag3, @PFlag4)
) AS "B"
ON
    "B"."Contractor_Id" = "Contractors"."Id"
LEFT OUTER JOIN
(
    SELECT
        "Contractors"."Id" AS "Contractor_Id",
        IIF(COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0) < 0, ABS(COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0)), NULL) AS "End_Debit",
        IIF(COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0) > 0, COALESCE("R"."Price", 0) + COALESCE("Payment_Credit"."Price", 0) - COALESCE("P"."Price", 0), NULL) AS "End_Credit"
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
            "Bank_Payments"."Direction" = -1 AND
            "Bank_Payments"."Payment_Date" <= @End_Date AND
            --
            "Bank_Payments"."Purpose_Account_Id" IN (@PFlag3, @PFlag4)
        GROUP BY
            "Bank_Payments"."Contractor_Id"
    ) AS "P"
    ON
        "P"."Contractor_Id" = "Contractors"."Id"
) AS "D"
ON
    "D"."Contractor_Id" = "Contractors"."Id"
WHERE
    "Contractors"."Id" = @Contractor
ORDER BY
    "B"."Operation_Date"
