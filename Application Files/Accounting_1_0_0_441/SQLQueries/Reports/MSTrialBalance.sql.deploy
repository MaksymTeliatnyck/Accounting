SELECT
    "Contractors"."Name" AS Contractor_Name, "Contractors"."Srn" AS "Contractor_Srn",
    "A"."Begin_Debit", "A"."Begin_Credit",
    "B"."Period_Debit",
    "C"."Period_Credit",
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
            Orders.Order_Date >= '31.03.2013' AND
            COALESCE(Orders.Currency_Id,0) <= 1 AND Orders.DEBIT_ACCOUNT_ID <> 240
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
            "Bank_Payments"."Payment_Date" < @Start_Date AND
            --
            "Bank_Payments"."Purpose_Account_Id" IN (@PFlag3, @PFlag4)
        GROUP BY
            "Bank_Payments"."Contractor_Id"
    ) AS "P"
    ON
        "P"."Contractor_Id" = "Contractors"."Id"
) AS "A"
ON
    "Contractors"."Id" = "A"."Contractor_Id"
LEFT OUTER JOIN
(
    SELECT
        "Bank_Payments"."Contractor_Id",
        SUM("Bank_Payments"."Payment_Price") AS "Period_Debit"
    FROM
        "Bank_Payments"
    WHERE
        "Bank_Payments"."Direction" = -1 AND
        "Bank_Payments"."Payment_Date" BETWEEN @Start_Date AND @End_Date AND
        --
        "Bank_Payments"."Purpose_Account_Id" IN (@PFlag3, @PFlag4)
    GROUP BY
        "Bank_Payments"."Contractor_Id"
) AS B
ON
    "Contractors"."Id" = "B"."Contractor_Id"
LEFT OUTER JOIN
(
    SELECT
        "Contractors"."Id" AS "Contractor_Id",
        IIF(COALESCE("P"."Period_Credit", 0) + COALESCE("Payment_Credit"."Period_Credit", 0) <> 0, COALESCE("P"."Period_Credit", 0) + COALESCE("Payment_Credit"."Period_Credit", 0), NULL) AS "Period_Credit"
    FROM
        "Contractors"
    LEFT OUTER JOIN
    (
        SELECT
            Orders.Vendor_Id AS "Contractor_Id",
            SUM(Orders.Total_Price) + COALESCE(SUM(Vat.Price), 0) AS "Period_Credit"
        FROM
            Orders, Vat
        WHERE
            Vat.Id = Orders.Id AND
            Orders.Order_Date BETWEEN @Start_Date AND @End_Date AND
            Orders.Checked = 1 AND
            --
            (Orders."Flag1" = @Flag1 OR Orders."Flag3" = @Flag3 OR Orders."Flag4" = @Flag4) AND
            Orders.Order_Date >= '31.03.2013' AND
            COALESCE(Orders.Currency_Id,0) <= 1 AND Orders.DEBIT_ACCOUNT_ID <> 240
        GROUP BY
            Orders.Vendor_Id
    ) AS "P"
    ON
        "P"."Contractor_Id" = "Contractors"."Id"
    LEFT OUTER JOIN
    (
        SELECT
            "Bank_Payments"."Contractor_Id",
            SUM("Bank_Payments"."Payment_Price") AS "Period_Credit"
        FROM
            "Bank_Payments"
        WHERE
            "Bank_Payments"."Direction" = 1 AND
            "Bank_Payments"."Payment_Date" BETWEEN @Start_Date AND @End_Date AND
            --
            "Bank_Payments"."Purpose_Account_Id" IN (@PFlag3, @PFlag4)
        GROUP BY
            "Bank_Payments"."Contractor_Id"
    ) AS "Payment_Credit"
    ON
        "Payment_Credit"."Contractor_Id" = "Contractors"."Id"
) AS "C"
ON
    "Contractors"."Id" = "C"."Contractor_Id"
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
            Orders.Order_Date >= '31.03.2013' AND
            COALESCE(Orders.Currency_Id,0) <= 1 AND Orders.DEBIT_ACCOUNT_ID <> 240
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
    "Contractors"."Id" = "D"."Contractor_Id"
WHERE
    "A"."Begin_Debit" IS NOT NULL OR "A"."Begin_Credit" IS NOT NULL OR
    "B"."Period_Debit" IS NOT NULL OR "C"."Period_Credit" IS NOT NULL
ORDER BY
    CAST("Contractors"."Srn" AS VARCHAR(20))
