SELECT
    "FixedAssetsOrder"."Id",
    "FixedAssetsOrder"."InventoryNumber",
    "FixedAssetsOrder"."InventoryName",
    "FixedAssetsOrder"."BeginDate",
    SupplierData.FullName AS Supplier_Name,
    "FixedAssetsGroup"."Name"  AS GroupName 
FROM "FixedAssetsOrder"
LEFT JOIN
    Responsible as SupplierData 
	    ON "FixedAssetsOrder"."Supplier_Id" = SupplierData.EmployeeId
LEFT JOIN "FixedAssetsGroup"
        ON "FixedAssetsOrder"."Group_Id" = "FixedAssetsGroup"."Id"
WHERE
    "FixedAssetsOrder"."EndRecordDate" IS NULL