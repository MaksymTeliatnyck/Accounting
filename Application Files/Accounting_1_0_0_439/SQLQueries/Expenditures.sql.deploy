SELECT
    Expenditures_Accountant.Id,
    Orders.Order_Date,
    Orders.Receipt_Num,
    Nomenclatures.Nomenclature,
    Nomenclatures.Name,
    Nomenclatures.Measure,
    Receipts.Unit_Price,
    Receipts.Total_Price,
    Receipts.Quantity AS Receipt_Quantity,
    (Receipts.Quantity - Exp_Sum_Quantity.Exp_Sum_Quantity) AS Remains,
    Expenditures_Accountant.Price AS Exp_Price,
    Expenditures_Accountant.Quantity,
    Expenditures_Accountant.Exp_Date,
    Expenditures_Accountant.Project_Num,
    Exp_Sum_Quantity.Exp_Sum_Quantity,
    Debit_Accounts.Num AS Debit_Account_Num,
    Balance_Accounts.Num AS Balance_Account_Num,
    Credit_Accounts.Num AS Credit_Account_Num,
    Expenditures_Accountant.Credit_Account_Id,
    "Currency"."Code" as Currency_Name
FROM
    Expenditures_Accountant
LEFT JOIN
    Accounts AS Credit_Accounts ON Expenditures_Accountant.Credit_Account_Id = Credit_Accounts.Id
LEFT JOIN
    Receipts ON Expenditures_Accountant.Receipt_Id = Receipts.Id
LEFT JOIN
    Nomenclatures ON Receipts.Nomenclature_Id = Nomenclatures.Id
LEFT JOIN
    Accounts AS Balance_Accounts ON Nomenclatures.Balance_Account_Id = Balance_Accounts.Id

LEFT OUTER JOIN
(
    SELECT
        Expenditures_Accountant.Receipt_Id, SUM(Expenditures_Accountant.Quantity) AS Exp_Sum_Quantity
    FROM
        Expenditures_Accountant    
    GROUP BY
        Expenditures_Accountant.Receipt_Id    
) AS Exp_Sum_Quantity
ON
    Receipts.Id = Exp_Sum_Quantity.Receipt_Id

LEFT JOIN
    Orders ON Receipts.Order_Id = Orders.Id
LEFT JOIN
    Accounts AS Debit_Accounts ON Orders.Debit_Account_Id = Debit_Accounts.Id
LEFT JOIN
    "Currency" ON Orders.Currency_Id = "Currency"."Id"
WHERE
    (Orders."Flag1" = 1 OR Orders."Flag2" = 1) AND
    Expenditures_Accountant.Exp_Date BETWEEN @StartDate AND @EndDate