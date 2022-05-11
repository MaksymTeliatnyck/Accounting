SELECT
    Orders.Order_Date, Orders.Receipt_Num,
    Orders.Invoice_Date, Orders.Invoice_Num,
    IIF(Orders.Total_With_Vat IS NOT NULL, Orders.Total_With_Vat, Receipt.Total_Price) AS Total_Price
FROM
    Orders
INNER JOIN
(
    SELECT
        Order_Id,
        SUM(Total_Price) AS Total_Price
    FROM
        Receipts
    GROUP BY
        Order_Id    
) AS Receipt
ON
    Receipt.Order_Id = Orders.Id
WHERE
    Orders.Vendor_Id = @Vendor AND
    Orders.Order_Date BETWEEN @StartDate AND @EndDate AND
    (Orders."Flag1" = 1 OR Orders."Flag2" = 1)
ORDER BY
    Orders.Order_Date
