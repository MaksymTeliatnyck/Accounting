SELECT
    Receipt.Receipt_Id,
    Receipt.Order_Date,
    Receipt.Receipt_Num,
    (Receipt.Quantity - COALESCE(Expenditure.ExpQuantity, 0)) AS Remains_Quantity,
    (Receipt.Total_Price - COALESCE(Expenditure.ExpSum, 0)) AS Remains_Sum,
    Receipt.Total_Price,
    Receipt.Unit_Price,
    Receipt.Debit_Num,
	IIF(Receipt.Correction = 1, 'К', '') as Correction
FROM
(
    SELECT
        Receipts.Quantity, Receipts.Unit_Price, Receipts.Total_Price,
        Receipts.Id AS Receipt_Id,
        Orders.Order_Date,
        Orders.Receipt_Num,
        Accounts.Num AS Debit_Num,
        Orders.CORRECTION as Correction
    FROM
        Receipts, Orders, Accounts
    WHERE
        Receipts.Order_Id = Orders.Id AND
        Orders.Debit_Account_Id = Accounts.Id AND
        Receipts.Nomenclature_Id = @Nomenclature AND
        Orders.Order_Date <= @StartDate AND
        --
        (Orders."Flag1" = 1 OR Orders."Flag2" = 1)
) AS Receipt
LEFT OUTER JOIN
(
    SELECT
        Expenditures_Accountant.Receipt_Id,
        SUM(Expenditures_Accountant.Quantity) AS ExpQuantity,
        SUM(Expenditures_Accountant.Price) AS ExpSum
    FROM
        Expenditures_Accountant
    WHERE
        Expenditures_Accountant.Exp_Date <= @StartDate
    GROUP BY
        Expenditures_Accountant.Receipt_Id
) AS Expenditure
ON
    Receipt.Receipt_Id = Expenditure.Receipt_Id
WHERE
    (IIF(Receipt.Total_Price = 0, -1, Receipt.Total_Price) - COALESCE(Expenditure.ExpSum, 0)) > 0 OR
    (IIF(Receipt.Quantity = 0, -1, Receipt.Quantity) - COALESCE(Expenditure.ExpQuantity, 0)) > 0 OR
    Receipt.Correction = 1
ORDER BY
    Receipt.Order_Date
