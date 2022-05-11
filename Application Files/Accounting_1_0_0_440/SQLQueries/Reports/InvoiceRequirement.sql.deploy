SELECT
    Nomenclatures.Name, Nomenclatures.Nomenclature, Nomenclatures.Measure,
    Accounts.Num AS BalanceAccount, Expenditure.Num AS CreditAccount,
    Receipts.Unit_Price,
    Sum(Expenditure.ExpenPrice) AS ExpenSum,
    Sum(Expenditure.ExpenQuantity) AS ExpenQuantity,
    ExpenditureTotal.TotalSum AS TotalSum,
    ExpenditureTotal.TotalQuantity AS TotalQuantity
FROM
    Accounts, Receipts, Expenditures_Accountant


LEFT OUTER JOIN
(
    SELECT
        Expenditures_Accountant.Id, Expenditures_Accountant.Quantity AS ExpenQuantity, Accounts.Num, ROUND(Expenditures_Accountant.Price, 3) as ExpenPrice
    FROM
        Expenditures_Accountant, Receipts, Nomenclatures, Accounts
    WHERE
        Expenditures_Accountant.Receipt_Id = Receipts.Id AND
        Receipts.Nomenclature_Id = Nomenclatures.Id AND
        Expenditures_Accountant.Credit_Account_Id = Accounts.Id AND
        Accounts.Id != 18 and
        Expenditures_Accountant.Exp_Date  BETWEEN @StartDate AND  @EndDate AND
        Nomenclatures.Id = @NomenclatureId
    GROUP BY
         Expenditures_Accountant.Id, Accounts.Num, Expenditures_Accountant.Quantity, ROUND(Expenditures_Accountant.Price, 3)
) AS Expenditure
ON
    Expenditure.Id = Expenditures_Accountant.Id,

Nomenclatures

LEFT OUTER JOIN
(
    SELECT
        Nomenclatures.Id, Sum(Expenditures_Accountant.Price) AS TotalSum, Sum(Expenditures_Accountant.Quantity) AS TotalQuantity
    FROM
        Expenditures_Accountant, Nomenclatures, Accounts, Receipts
    WHERE
        Receipts.Id = Expenditures_Accountant.Receipt_Id AND
        Receipts.Nomenclature_Id = Nomenclatures.Id AND
        Expenditures_Accountant.credit_account_id = Accounts.Id AND
        Accounts.Id != 18 and
        Expenditures_Accountant.Exp_Date  BETWEEN @StartDate AND  @EndDate AND
        Nomenclatures.Id = @NomenclatureId
    GROUP BY
        Nomenclatures.Id
) AS ExpenditureTotal
ON
    ExpenditureTotal.Id = Nomenclatures.Id



WHERE
    Receipts.Nomenclature_Id = Nomenclatures.Id AND
    Nomenclatures.Balance_Account_Id = Accounts.Id AND 
    Expenditures_Accountant.credit_account_id != 18 and
    Receipts.Id = Expenditures_Accountant.Receipt_Id AND
    Expenditures_Accountant.Exp_Date  BETWEEN @StartDate AND @EndDate AND
    Nomenclatures.Id = @NomenclatureId
GROUP BY
    Nomenclatures.Name, Nomenclatures.Nomenclature, Nomenclatures.Measure, Accounts.Num, Receipts.Unit_Price,
    Expenditure.Num, ExpenditureTotal.TotalSum,ExpenditureTotal.TotalQuantity