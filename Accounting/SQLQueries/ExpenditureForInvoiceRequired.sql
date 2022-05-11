SELECT
    Expenditures_Accountant.Id,
    Expenditures_Accountant.Quantity AS Setkol, Expenditures_Accountant.Price, Expenditures_Accountant.Exp_Date,
    Receipts.Nomenclature_Id, Receipts.Id AS Receipt_Id, Receipts.Unit_Price,
    Accounts.Num AS Credit_Account,
    Orders_Accounts.Num AS Debit_Num,
    Orders.Receipt_Num , Orders.Order_Date,
    Nomenclatures.Name, Nomenclatures.Nomenclature, Nomenclatures.Measure,
    Nomenclatures_Accounts.Num AS Balance_Num,
    Expenditures_Accountant.Credit_Account_Id
FROM Expenditures_Accountant
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
LEFT JOIN "Invoice_Requirement_Materials"
    ON Expenditures_Accountant.Id = "Invoice_Requirement_Materials"."Expenditures_Id"
LEFT JOIN "Invoice_Requirement_Orders"
    ON "Invoice_Requirement_Materials"."Invoice_Requirement_Order_Id" = "Invoice_Requirement_Orders"."Id"
WHERE
    Expenditures_Accountant.Exp_Date >= @StartDate AND
    Expenditures_Accountant.Exp_Date <= @EndDate AND
    Expenditures_Accountant.Quantity > 0 AND
    (("Invoice_Requirement_Materials"."Expenditures_Id" IS NULL) or  ("Invoice_Requirement_Materials"."Expenditures_Id" IS NOT NULL AND "Invoice_Requirement_Orders"."Type" = 1))