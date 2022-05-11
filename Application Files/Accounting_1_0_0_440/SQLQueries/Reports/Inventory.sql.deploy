SELECT
    Accounts.Num AS Balance_Num,
    Nomenclatures.Nomenclature,
    Nomenclatures.Name,
    SUM((Receipt.Quantity - COALESCE(Expenditure.ExpQuantity, 0))) AS Remains_Quantity,
    SUM((Receipt.Total_Price - COALESCE(Expenditure.ExpSum, 0))) AS Remains_Sum
FROM
    Accounts
INNER JOIN
    Nomenclatures
ON
    Nomenclatures.Balance_Account_Id = Accounts.Id
INNER JOIN
(
    SELECT
        Receipts.Id,
        Receipts.Nomenclature_Id,
        Receipts.Quantity, Receipts.Unit_Price, Receipts.Total_Price
    FROM
        Orders, Receipts
    WHERE
        Receipts.Order_Id = Orders.Id AND
        Orders.Order_Date <= @StartDate AND
        --
        ((COALESCE(Orders.Currency_Id, 0) > 1 AND Orders."Flag2" = 0) OR COALESCE(Orders.Currency_Id, 0) < 2) AND
        (Orders."Flag1" = 1 OR Orders."Flag2" = 1)
) AS Receipt
ON
    Receipt.Nomenclature_Id = Nomenclatures.Id
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
    Receipt.Id = Expenditure.Receipt_Id
WHERE
    Accounts.ID not in (19, 21, 23) AND
    ((IIF(Receipt.Total_Price = 0, -1, ABS(Receipt.Total_Price)) - COALESCE(Expenditure.ExpSum, 0)) > 0 OR
        (IIF(Receipt.Quantity = 0, -1, ABS(Receipt.Quantity)) - COALESCE(Expenditure.ExpQuantity, 0)) > 0)
GROUP BY
    Accounts.Num, Nomenclatures.Nomenclature, Nomenclatures.Name
ORDER BY
    Accounts.Num,
    CAST(Nomenclatures.Nomenclature AS INTEGER)
