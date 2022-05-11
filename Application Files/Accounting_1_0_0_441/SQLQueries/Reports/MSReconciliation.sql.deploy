SELECT
    IIF(Begin_Period.StartDebit - Begin_Period.StartCredit < 0, Begin_Period.StartCredit - Begin_Period.StartDebit, 0) AS StartDebit,
    IIF(Begin_Period.StartDebit - Begin_Period.StartCredit > 0, Begin_Period.StartDebit - Begin_Period.StartCredit, 0) AS StartCredit,
    IIF(Begin_Period.EndDebit - Begin_Period.EndCredit < 0, Begin_Period.EndCredit - Begin_Period.EndDebit, 0) AS EndDebit,
    IIF(Begin_Period.EndDebit - Begin_Period.EndCredit > 0, Begin_Period.EndDebit - Begin_Period.EndCredit, 0) AS EndCredit,
    Period.Order_Date,
    Period.Invoice_Num,
    Period.Purpose,
    Period.Debit_Price,
    Period.Credit_Price
FROM
(
    SELECT
        SUM(se.StartDebit) as StartDebit,
        SUM(se.StartCredit) as StartCredit,
        SUM(se.EndDebit) as EndDebit,
        SUM(se.EndCredit) as EndCredit
      FROM
        (SELECT
            IIF( o.Order_Date < @Start_Date, o.Total_Price + COALESCE(v.Price, 0), 0) AS StartDebit,
            0 as StartCredit,
            (o.Total_Price + COALESCE(v.PRICE, 0)) AS EndDebit,
            0 as EndCredit
         FROM
            Orders o
         LEFT JOIN
            Vat v ON o.ID = v.ID
         WHERE
            o.Vendor_Id = @Contractor
            AND o.Order_Date >= '31.03.2013'
            AND o.Order_Date <= @End_Date
            AND COALESCE(o.Currency_Id,0) <= 1
            AND o.Checked = 1
            AND o.Debit_Account_Id IN (@PFlag3, @PFlag4)

         UNION ALL

         SELECT
            -- DebitStartCredit
            IIF((bp."Direction" = 1 AND bp."Payment_Date" < @Start_Date), bp."Payment_Price", 0) AS StartDebit,
            IIF((bp."Direction" = -1 AND bp."Payment_Date" < @Start_Date), bp."Payment_Price", 0) AS StartCredit,
             -- DebitEndCredit
            IIF((bp."Direction" = 1), bp."Payment_Price", 0) AS EndDebit,
            IIF((bp."Direction" = -1), bp."Payment_Price", 0) AS EndCredit
          FROM
            "Bank_Payments" bp
          WHERE
            bp."Contractor_Id" = @Contractor
            AND(bp."Purpose_Account_Id" = @PFlag3 OR bp."Purpose_Account_Id" = @PFlag4)
            AND bp."Payment_Date" <= @End_Date
         
         ) AS se

) AS Begin_Period,
(
    SELECT
        Orders.Order_Date,
        Orders.Invoice_Num,
        '' as Purpose,
        NULL AS Debit_Price,
        (Orders.Total_Price + COALESCE(Vat.Price, 0)) AS Credit_Price
    FROM
        Orders, Vat
    WHERE
        Vat.Id = Orders.Id AND
        Orders.Order_Date BETWEEN @Start_Date AND @End_Date AND
        Orders.Checked = 1 AND
        Orders.Vendor_Id = @Contractor AND
        --
        Orders.Debit_Account_Id IN (@PFlag3, @PFlag4) AND
        Orders.Order_Date >= '31.03.2013' 
    UNION ALL
    SELECT
        "Bank_Payments"."Payment_Date" as Order_Date,
        "Bank_Payments"."Payment_Document" as Invoice_Num,
        "Bank_Payments"."Purpose" AS Purpose,
        IIF("Bank_Payments"."Direction" = -1, "Bank_Payments"."Payment_Price", NULL) AS Debit_Price,
        IIF("Bank_Payments"."Direction" = 1, "Bank_Payments"."Payment_Price", NULL) AS Credit_Price
    FROM
        "Bank_Payments"
    WHERE
        "Bank_Payments"."Contractor_Id" = @Contractor AND
        "Bank_Payments"."Payment_Date" BETWEEN @Start_Date AND @End_Date AND
        "Bank_Payments"."Purpose_Account_Id" IN (@PFlag3, @PFlag4)
) AS Period
ORDER BY
    Period.Order_Date, Period.Invoice_Num
