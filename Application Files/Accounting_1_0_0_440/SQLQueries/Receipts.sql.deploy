SELECT
    "Contractors"."Srn" AS "Vendor_Srn", 
	"Contractors"."Name" AS "Vendor_Name",
    Orders.Receipt_Num,
    Orders.Order_Date, Orders.Invoice_Date,
    Nomenclatures.Nomenclature, 
	Nomenclatures.Name AS Nomenclature_Name, 
	Nomenclatures.Measure,
    Nomenclatures."Nomencl_Group_Id",
    Receipts.Quantity, 
	Receipts.Total_Price, 
	Receipts.Unit_Price,
	Receipts.TOTAL_CURRENCY,
    Receipts.UNIT_CURRENCY,
    Debit_Accounts.Num AS Debit_Account_Num, 
	Balance_Accounts.Num AS Balance_Account_Num,
    Orders.Correction
FROM
    "Contractors", Orders, Receipts, Nomenclatures,
    Accounts AS Debit_Accounts, Accounts AS Balance_Accounts
WHERE
    Orders.Vendor_Id = "Contractors"."Id" AND
    Receipts.Order_Id = Orders.Id AND
    Receipts.Nomenclature_Id = Nomenclatures.Id AND
    Orders.Debit_Account_Id = Debit_Accounts.Id AND
    Nomenclatures.Balance_Account_Id = Balance_Accounts.Id AND
    Orders.Order_Date BETWEEN @Start_Date AND @End_Date AND
	--
    (Orders."Flag1" = @Flag1 OR Orders."Flag2" = @Flag2 OR Orders."Flag3" = @Flag3 OR Orders."Flag4" = @Flag4)
ORDER BY
    Orders.Order_Date, Orders.Id, Receipts.Pos
