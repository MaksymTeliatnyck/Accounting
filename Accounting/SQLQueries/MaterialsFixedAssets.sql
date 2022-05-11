SELECT
	"FixedAssetsMaterials"."Id",
	"FixedAssetsMaterials"."FixedAssetsOrder_Id",
	"FixedAssetsMaterials"."Expenditures_Id",
	"FixedAssetsMaterials"."Fixed_Account_Id",
	"FixedAssetsMaterials"."FixedPrice" AS Fixed_Price,
	case "FixedAssetsMaterials"."Flag"
		when 0 then 'Основное средство'
		when 1 then 'Увеличение стоимости'
		when 2 then 'Корректировка'
	end AS FlagNote,
	a.NUM as Fixed_Num,
	Expenditures_Accountant.Exp_Date,
	exp.NUM as Expen_Num,
	Expenditures_Accountant.Price,
	Receipts.ID AS Receipt_Id,
	Receipts.Quantity,
	Receipts.Unit_Price,
	Receipts.Total_Price,
	Receipts.Nomenclature_Id,
	Nomenclatures.Nomenclature,
	Nomenclatures.Name as Nomen,
	Orders.Receipt_Num,
	Orders.Order_Date,
	Orders.Vendor_Id,
	"Contractors"."Name" AS Contractor_Name,
	"Contractors"."Srn",
	Orders.Debit_Account_Id,
	ord.NUM as Order_Num, 
	fio."InventoryNumber",
	fio."InventoryName",
	fio."BeginDate",
	fio."EndRecordDate",
	fio."UsefulMonth",
	afio.Num,
	SupplierData.FullName AS Name,
	fagfio."Id" AS GroupId,
	fagfio."Name" AS GroupName
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
  LEFT JOIN
	"FixedAssetsOrder" fio ON "FixedAssetsMaterials"."FixedAssetsOrder_Id" = fio."Id"
  LEFT JOIN
	Accounts afio ON fio."Balance_Account_Id" = afio.ID
  LEFT JOIN
    Responsible as SupplierData ON fio."Supplier_Id" = SupplierData.EmployeeId
  LEFT JOIN
	"FixedAssetsGroup" fagfio ON fio."Group_Id" = fagfio."Id"
  WHERE 
	"FixedAssetsMaterials"."Flag" <> 3 AND
    fio."BeginDate" <= @End_Date AND 
	fio."EndRecordDate" IS NULL