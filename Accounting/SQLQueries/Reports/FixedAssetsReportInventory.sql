SELECT 
   s.NAME,a.NUM AS BalansNUM, fao."InventoryNumber", fao."InventoryName", fao."BeginDate", ex.PRICE AS BeginPRICE, --X1,
   n.NOMENCLATURE, n.NAME As NomNAME , o.ORDER_DATE, o.RECEIPT_NUM, o.TOTAL_PRICE,
   ex.EXP_DATE, aea.NUM AS ExNUM,
   afam.NUM AS FaExNUM, fao."UsefulMonth"
FROM 
     "FixedAssetsMaterials" as fam
  LEFT JOIN 
     EXPENDITURES_ACCOUNTANT as ex ON fam."Expenditures_Id" = ex.ID
  LEFT JOIN 
     ACCOUNTS as aea ON ex.CREDIT_ACCOUNT_ID = aea.ID
  LEFT JOIN 
     RECEIPTS as r ON ex.RECEIPT_ID = r.ID
  LEFT JOIN 
     ORDERS as o ON r.ORDER_ID = o.ID
  LEFT JOIN 
     NOMENCLATURES as n ON r.NOMENCLATURE_ID = n.ID
  LEFT JOIN 
     ACCOUNTS as afam ON fam."Fixed_Account_Id" = afam.ID
  LEFT JOIN 
    "FixedAssetsOrder" as fao ON fam."FixedAssetsOrder_Id" = fao."Id"
  LEFT JOIN 
    ACCOUNTS a ON fao."Balance_Account_Id" = a.ID
  LEFT JOIN 
    SUPPLIERS s ON fao."Supplier_Id" = s.ID
WHERE 
  fao."BeginDate" <= @EndDate AND fao."EndRecordDate" IS NULL