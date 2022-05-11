SELECT
   "FixedAssetsMaterials"."Id",
   "FixedAssetsMaterials"."FixedAssetsOrder_Id",
   "FixedAssetsMaterials"."Expenditures_Id",
   "FixedAssetsMaterials"."Fixed_Account_Id",
   "FixedAssetsMaterials"."Flag",
   "FixedAssetsMaterials"."FixedPrice",                                                      
   a.NUM as Fixed_Num,
   iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date) AS Exp_Date,
   Expenditures_Accountant.Price,
   exp.NUM as Expen_Num,
   "FixedAssetsMaterials"."FixedPrice",
   Receipts.ID AS Receipt_Id,
   Receipts.Quantity,
   Receipts.Unit_Price,
   Receipts.Total_Price,
   Receipts.Nomenclature_Id,
   Nomenclatures.Nomenclature,
   Nomenclatures.Name,
   Orders.Receipt_Num,
   Orders.Order_Date,
   Orders.Vendor_Id,
   "Contractors"."Name" AS Contractor_Name,
   "Contractors"."Srn",
   Orders.Debit_Account_Id,
   ord.NUM as Order_Num,
   case "FixedAssetsMaterials"."Flag"
        when 0 then 'Основное средство'
        when 1 then 'Увеличение стоимости' 
        when 2 then 'Корректировка' 
	end AS FlagNote                    
  FROM
	  "FixedAssetsMaterials"
  LEFT JOIN
	  Accounts a ON "FixedAssetsMaterials"."Fixed_Account_Id" = a.ID
  LEFT JOIN
	  Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
  LEFT JOIN
	  Accounts exp ON Expenditures_Accountant.CREDIT_ACCOUNT_ID = exp.ID
  LEFT JOIN
	  Receipts ON Expenditures_Accountant.RECEIPT_ID = Receipts.ID
  LEFT JOIN
	  Nomenclatures ON Receipts.Nomenclature_Id = Nomenclatures.ID
  LEFT JOIN
	  Orders ON Receipts.Order_Id = Orders.ID
  LEFT JOIN
	  "Contractors" ON Orders.VENDOR_ID = "Contractors"."Id"
  LEFT JOIN
	  Accounts ord ON Orders.DEBIT_ACCOUNT_ID = ord.ID
  WHERE
	 "FixedAssetsMaterials"."FixedAssetsOrder_Id" = @Id
  ORDER BY
	 "FixedAssetsMaterials"."Flag"