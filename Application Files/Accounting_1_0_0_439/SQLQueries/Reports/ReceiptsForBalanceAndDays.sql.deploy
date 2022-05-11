SELECT
    Orders.Order_Date, Orders.Receipt_Num,
    Nomenclatures.Nomenclature, Nomenclatures.Name, Nomenclatures.Measure,
    Receipts.Quantity, Receipts.Unit_Price, Receipts.Total_Price,
    Debit_Accounts.Num AS Debit_Account_Num
FROM
    Orders, Receipts, Nomenclatures,
    Accounts AS Debit_Accounts, Accounts AS Balance_Accounts
WHERE
    Receipts.Order_Id = Orders.Id AND
    Receipts.Nomenclature_Id = Nomenclatures.Id AND
    Orders.Debit_Account_Id = Debit_Accounts.Id AND
    Nomenclatures.Balance_Account_Id = Balance_Accounts.Id AND
    Balance_Accounts.Id = @BalanceNum AND
    Orders.Order_Date BETWEEN @StartDate AND @EndDate AND
	--
    (Orders."Flag1" = 1 OR Orders."Flag2" = 1)
ORDER BY
    Orders.Order_Date,
    CAST(Nomenclatures.Nomenclature AS INTEGER)
