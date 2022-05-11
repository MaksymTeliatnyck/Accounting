SELECT
    Nomenclatures.Nomenclature,
    Nomenclatures.Name,
    Nomenclatures.Measure,
    
    Remains_Begin.remainsQ,
    Remains_Begin.remainsP,
    
    Debit.receipt_total_quantity,
    Debit.receipt_total_Price,
    
    Credit.exp_total_quantity, 
    Credit.exp_total_price,
    
    (coalesce(Remains_Begin.remainsQ, 0) + coalesce(Debit.receipt_total_quantity, 0) - coalesce(Credit.exp_total_quantity, 0)) as remainsQ,
    (coalesce(Remains_Begin.remainsP, 0) + coalesce(Debit.receipt_total_Price, 0) - coalesce(Credit.exp_total_price, 0)) as remainsP,

    Balance.Num AS Balance
FROM
    Nomenclatures
LEFT JOIN
    Accounts as Balance on Nomenclatures.Balance_Account_Id = Balance.Id

-- Begin Month
LEFT OUTER JOIN
(
    SELECT
        Receipt.Nomenclature_Id,
        SUM((Receipt.Quantity - COALESCE(Expenditure.ExpQuantity, 0))) AS RemainsQ,
        SUM(Receipt.Total_Price - COALESCE(Expenditure.ExpSum, 0)) AS RemainsP
    FROM
    (
        SELECT
            Receipts.Id,
            Receipts.Nomenclature_Id,
            Receipts.Total_Price, Receipts.Unit_Price, Receipts.Quantity
        FROM
            Receipts, Orders
        WHERE
            Receipts.Order_Id = Orders.Id AND
            Orders.Order_Date < @StartDate AND
            ((COALESCE(Orders.Currency_Id, 0) > 1 AND Orders."Flag2" = 0) OR COALESCE(Orders.Currency_Id, 0) < 2) AND
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
            Expenditures_Accountant.Exp_Date < @StartDate
        GROUP BY
            Expenditures_Accountant.Receipt_Id
    ) AS Expenditure
    ON
        Receipt.Id = Expenditure.Receipt_Id
    WHERE
        (IIF(Receipt.Total_Price = 0, -1, ABS(Receipt.Total_Price)) - COALESCE(Expenditure.ExpSum, 0)) > 0 OR
        (IIF(Receipt.Quantity = 0, -1, ABS(Receipt.Quantity)) - COALESCE(Expenditure.ExpQuantity, 0)) > 0
    GROUP BY
        Receipt.Nomenclature_Id
) AS Remains_Begin
ON
    Nomenclatures.Id = Remains_Begin.Nomenclature_Id
-- Debit
LEFT OUTER JOIN
(
    SELECT
        Receipts.Nomenclature_Id,
        SUM(Receipts.Quantity) AS Receipt_Total_Quantity,
        SUM(Receipts.Total_Price) AS Receipt_Total_Price
    FROM
        Orders, Receipts
    WHERE
        Receipts.Order_Id = Orders.Id AND
        Orders.Order_Date BETWEEN @StartDate AND @EndDate AND
        ((COALESCE(Orders.Currency_Id, 0) > 1 AND Orders."Flag2" = 0) OR COALESCE(Orders.Currency_Id, 0) < 2) AND
        --
        (Orders."Flag1" = 1 OR Orders."Flag2" = 1) 
    GROUP BY
        Receipts.Nomenclature_Id
) AS Debit
ON
    Nomenclatures.Id = Debit.Nomenclature_Id
-- Credit
LEFT OUTER JOIN
(
  SELECT
        Receipts.Nomenclature_Id,
        SUM(Expenditures_Accountant.Quantity) AS Exp_Total_Quantity,
        SUM(Expenditures_Accountant.Price) AS Exp_Total_Price
    FROM
        Expenditures_Accountant, Receipts
    WHERE
        Expenditures_Accountant.Receipt_Id = Receipts.Id AND
        Expenditures_Accountant.Exp_Date BETWEEN @StartDate AND @EndDate
    GROUP BY
        Receipts.Nomenclature_Id
) AS Credit
ON
    Nomenclatures.Id = Credit.Nomenclature_Id

WHERE
    Remains_Begin.remainsQ IS NOT NULL OR Debit.receipt_total_quantity IS NOT NULL
ORDER BY 
    Balance.Num,
    CAST(Nomenclatures.Nomenclature AS BIGINT)
