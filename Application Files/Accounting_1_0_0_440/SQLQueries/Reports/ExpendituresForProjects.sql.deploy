SELECT
    Expenditures_Accountant.Id,
    Nomenclatures.Nomenclature, Nomenclatures.Name, Nomenclatures.Measure, Expenditures_Accountant.Project_Num,
    Receipts.Unit_Price,
    SUM(Expenditures_Accountant.Quantity) AS ExpQuantity,
    SUM(Expenditures_Accountant.Price) AS ExpSum
FROM
    Expenditures_Accountant, Receipts, Nomenclatures
WHERE
    Expenditures_Accountant.Receipt_Id = Receipts.Id AND
	Receipts.Nomenclature_Id = Nomenclatures.Id AND
    Expenditures_Accountant.Exp_Date BETWEEN @StartDate AND @EndDate
GROUP BY
	Expenditures_Accountant.Exp_Date,
    Expenditures_Accountant.Id,
    Nomenclatures.Nomenclature, Nomenclatures.Name, Nomenclatures.Measure, Expenditures_Accountant.Project_Num,
    Receipts.Unit_Price, Nomenclatures.Balance_Account_Id
ORDER BY
    Expenditures_Accountant.Project_Num,
    CAST(Nomenclatures.Nomenclature AS BIGINT)
