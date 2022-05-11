SELECT
    "FixedAssetsOrder"."Id",
    "FixedAssetsOrder"."Id_Parent",
    "FixedAssetsOrder"."InventoryNumber",
    "FixedAssetsOrder"."InventoryName",
    "FixedAssetsOrder"."BeginDate",
    "FixedAssetsOrder"."BeginRecordDate",
    "FixedAssetsOrder"."EndRecordDate",
    "FixedAssetsOrder"."Balance_Account_Id",
    "FixedAssetsOrder"."UsefulMonth",
    "FixedAssetsOrder"."Region_Id",
    "FixedAssetsOrder"."FixedCardStatus",
    "Region"."Name" AS Region_Name,
    Accounts.Num AS Balance_Account_Num,
    SupplierData.EmployeeId AS Supplier_Id,
    SupplierData.FullName AS Supplier_Name,
    SupplierData.fio AS Fio,
    OperatingPersonData.EmployeeId AS OperatingPerson_Id,
    OperatingPersonData.FullName AS OperatingPerson_Name,
    "FixedAssetsGroup"."Id" AS Group_Id,
    "FixedAssetsGroup"."Name" AS Group_Name,
    IIF("FixedAssetsOrder"."FixedCardStatus" = 1, 0, COALESCE(Materials.SoldPrice, 0)) AS SoldPrice,
    IIF("FixedAssetsOrder"."FixedCardStatus" = 1, COALESCE(MaterialsPrice.FixedPrice, 0), 0) AS TransferPrice,
    "FixedAssetsOrder"."FixedCardStatus" AS OperationStatus, -- Transfer - 1, Sold - 2, Partial sold - 3

    CASE "FixedAssetsOrder"."FixedCardStatus"
        WHEN 1 then 'Перевод'
        WHEN 2 then 'Продажа'
        WHEN 3 then 'Частичная продажа'
    END AS OperationName,

    '0' as SelectedCard,
    "ProfessionsCases"."NameGenitive"
  FROM
    "FixedAssetsOrder"
  LEFT JOIN
    Accounts ON "FixedAssetsOrder"."Balance_Account_Id" = Accounts.ID
  LEFT JOIN
    Responsible as SupplierData ON "FixedAssetsOrder"."Supplier_Id" = SupplierData.EmployeeId
  LEFT JOIN
    "EmployeesDetails" ON SupplierData.EmployeeId = "EmployeesDetails"."EmployeeID"
  LEFT JOIN
    "ProfessionsCases"  ON "EmployeesDetails"."ProfessionID" = "ProfessionsCases"."ProfessionID"
  LEFT JOIN
    Responsible as OperatingPersonData ON "FixedAssetsOrder"."OperatingPerson_Id" = OperatingPersonData.EmployeeId
  LEFT JOIN
    "FixedAssetsGroup" ON "FixedAssetsOrder"."Group_Id" = "FixedAssetsGroup"."Id"
  LEFT JOIN
    "Region" ON "FixedAssetsOrder"."Region_Id" = "Region"."Id"
  LEFT JOIN
    ( SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
        ROUND(SUM("FixedAssetsMaterials"."SoldPrice"), 2) AS SoldPrice
      FROM
        "FixedAssetsMaterials"
      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
    ) AS Materials
    ON "FixedAssetsOrder"."Id" = Materials.Order_Id
     LEFT JOIN
    ( SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
        ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS FixedPrice
      FROM
        "FixedAssetsMaterials"
      WHERE
        "FixedAssetsMaterials"."Flag" = 0
      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
    ) AS MaterialsPrice
    ON "FixedAssetsOrder"."Id" = MaterialsPrice.Order_Id
  WHERE
    (("FixedAssetsOrder"."EndRecordDate" >= @BeginDate) AND ("FixedAssetsOrder"."EndRecordDate" <= @EndDate))