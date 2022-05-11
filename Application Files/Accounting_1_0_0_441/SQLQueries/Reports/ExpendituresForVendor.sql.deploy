SELECT
    Orders.Order_Date, Orders.Receipt_Num, Orders.Invoice_Num,
    Nomenclatures.Nomenclature, Nomenclatures.Name AS Nomenclature_Name, Nomenclatures.Measure,
    Receipt.Receipt_Quantity_Sum, Receipt.Receipt_Price_Sum,
    Expenditure.Exp_Date,
    Expenditure.Expenditure_Quantity, Expenditure.Expenditure_Price,
    Expenditure.Project_Num
FROM
    Nomenclatures,
    Orders
LEFT OUTER JOIN
(
    SELECT
        Receipts.Order_Id,
        Receipts.Nomenclature_Id,
        SUM(Receipts.Quantity) AS Receipt_Quantity_Sum, SUM(Receipts.Total_Price) AS Receipt_Price_Sum
    FROM
        Receipts
    GROUP BY
        Receipts.Order_Id,
        Receipts.Nomenclature_Id
) AS Receipt
ON
    Receipt.Order_Id = Orders.Id
LEFT OUTER JOIN
(
    SELECT
        Receipts.Order_Id,
        Receipts.Nomenclature_Id,
        Expenditures_Accountant.Exp_Date,
        Expenditures_Accountant.Project_Num,
        SUM(Expenditures_Accountant.Quantity) AS Expenditure_Quantity, SUM(Expenditures_Accountant.Price) AS Expenditure_Price
    FROM
        Expenditures_Accountant, Receipts
    WHERE
        Expenditures_Accountant.Receipt_Id = Receipts.Id AND
        Expenditures_Accountant.Exp_Date <= @Exp_Date
    GROUP BY
        Receipts.Order_Id,
        Receipts.Nomenclature_Id,
        Expenditures_Accountant.Exp_Date,
        Expenditures_Accountant.Project_Num
) AS Expenditure
ON
    Expenditure.Nomenclature_Id = Receipt.Nomenclature_Id AND Expenditure.Order_Id = Receipt.Order_Id
WHERE
    Receipt.Nomenclature_Id = Nomenclatures.Id AND
    Orders.Order_Date BETWEEN @Start_Date AND @End_Date AND
    Orders.Vendor_Id = @Vendor AND
    Orders.Receipt_Num LIKE @Receipt_Num AND
    --
    (Orders."Flag1" = 1 OR Orders."Flag2" = 1)
ORDER BY
    Orders.Receipt_Num,
    CAST(Nomenclatures.Nomenclature AS INTEGER),
    Expenditure.Exp_Date,
    CAST(Expenditure.Project_Num AS INTEGER)
