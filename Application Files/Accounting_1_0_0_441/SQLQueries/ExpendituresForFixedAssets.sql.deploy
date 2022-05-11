SELECT
    Expenditures_Accountant.Id, 
    Expenditures_Accountant.Price,
    (Expenditures_Accountant.Price-COALESCE(DataSumFixedPrice.SumFixedPrice,0)) AS SetPrice,
    Expenditures_Accountant.Exp_Date,
    Receipts.Nomenclature_Id, 
    Receipts.Id AS Receipt_Id, 
    Receipts.Unit_Price,
    Accounts.Num AS Credit_Account,
    Orders_Accounts.Num AS Debit_Num,
    Orders.Receipt_Num , 
    Orders.Order_Date,
    Nomenclatures.Name, 
    Nomenclatures.Nomenclature, 
    Nomenclatures.Measure,
    Nomenclatures_Accounts.Num AS Balance_Num,
    Expenditures_Accountant.Credit_Account_Id
FROM 
    Expenditures_Accountant
LEFT JOIN Receipts
    ON Receipts.Id = Expenditures_Accountant.Receipt_Id
LEFT JOIN Accounts
    ON Accounts.Id = Expenditures_Accountant.Credit_Account_Id
LEFT JOIN Orders
    ON Orders.Id = Receipts.Order_Id
LEFT JOIN Nomenclatures
    ON Nomenclatures.Id = Receipts.Nomenclature_Id
LEFT JOIN Accounts AS Orders_Accounts
    ON Orders_Accounts.Id = Orders.Debit_Account_Id
LEFT JOIN Accounts AS Nomenclatures_Accounts
    ON Nomenclatures_Accounts.Id = Nomenclatures.Balance_Account_Id
LEFT JOIN
(
   SELECT
       ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS SumFixedPrice,
       "FixedAssetsMaterials"."Expenditures_Id"
     FROM
       "FixedAssetsMaterials"
     GROUP BY
       "FixedAssetsMaterials"."Expenditures_Id"
) AS DataSumFixedPrice
    ON Expenditures_Accountant.ID = DataSumFixedPrice."Expenditures_Id"
WHERE
    Accounts."Type" = 2 AND
    Expenditures_Accountant.Exp_Date >= @StartDate AND
    Expenditures_Accountant.Exp_Date <= @EndDate AND
    (Expenditures_Accountant.Price-COALESCE(DataSumFixedPrice.SumFixedPrice,0)) > 0