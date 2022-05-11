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
    "Region"."Name" AS Region_Name,
    Accounts.Num AS Balance_Account_Num,
    SupplierData.EmployeeId AS Supplier_Id,
    SupplierData.FullName AS Supplier_Name,
    OperatingPersonData.EmployeeId AS OperatingPerson_Id,
    OperatingPersonData.FullName AS OperatingPerson_Name,
    "FixedAssetsGroup"."Id" AS Group_Id,
    "FixedAssetsGroup"."Name" AS Group_Name,
    MaterialsGroup."Fixed_Account_Id" as Fixed_Account_Id,
    AccountsForMaterials.Num AS Fixed_Account_Num,
    MaterialsBeginPrice.BeginPrice,
    MaterialsIncreasePrice.IncreasePrice,
    COALESCE(MaterialsGroup."FixedPrice", 0) as TotalPrice,
    --CurrentPrice--
    COALESCE(MaterialsGroup."CurrentPrice", 0) as CurrentPrice,
    --PeriodAmortization--
    COALESCE(MaterialsGroup."PeriodAmortization", 0) as PeriodAmortization,
    --CurrentAmortization--
    COALESCE(MaterialsGroup."CurrentAmortization", 0) as CurrentAmortization,
    '0' as SelectedCard
  FROM
    "FixedAssetsOrder"
  LEFT JOIN
    Accounts ON "FixedAssetsOrder"."Balance_Account_Id" = Accounts.ID
  LEFT JOIN
    Responsible as SupplierData ON "FixedAssetsOrder"."Supplier_Id" = SupplierData.EmployeeId
  LEFT JOIN
    Responsible as OperatingPersonData ON "FixedAssetsOrder"."OperatingPerson_Id" = OperatingPersonData.EmployeeId
  LEFT JOIN
    "FixedAssetsGroup" ON "FixedAssetsOrder"."Group_Id" = "FixedAssetsGroup"."Id"
  LEFT JOIN
    "Region" ON "FixedAssetsOrder"."Region_Id" = "Region"."Id"
  LEFT JOIN
    (SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
        ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS IncreasePrice
      FROM
        "FixedAssetsMaterials"
      LEFT JOIN
        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
      WHERE "FixedAssetsMaterials"."Flag" = 1 AND
           iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date)  <= @EndDate
      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     ) AS MaterialsIncreasePrice
     ON "FixedAssetsOrder"."Id" = MaterialsIncreasePrice.Order_Id
  LEFT JOIN
    (SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
        MAX("FixedAssetsMaterials"."Fixed_Account_Id") AS Fixed_Account_Id,
        ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS BeginPrice
      FROM
        "FixedAssetsMaterials"
      LEFT JOIN
        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
      WHERE "FixedAssetsMaterials"."Flag" = 0 AND
           iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date)  <= @EndDate
      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     ) AS MaterialsBeginPrice
     ON "FixedAssetsOrder"."Id" = MaterialsBeginPrice.Order_Id 
  LEFT JOIN
    "GetCurrentAmortizationByCardId"("FixedAssetsOrder"."Id", @EndDate) AS MaterialsGroup ON "FixedAssetsOrder"."Id" = MaterialsGroup."OrderId"
  LEFT JOIN
    Accounts as AccountsForMaterials ON MaterialsGroup."Fixed_Account_Id" = AccountsForMaterials.ID

   WHERE
     (1 = 1)


/* SELECT
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
    "Region"."Name" AS Region_Name,
    Accounts.Num AS Balance_Account_Num,
    SupplierData.EmployeeId AS Supplier_Id,
    SupplierData.FullName AS Supplier_Name,
    OperatingPersonData.EmployeeId AS OperatingPerson_Id,
    OperatingPersonData.FullName AS OperatingPerson_Name,
    "FixedAssetsGroup"."Id" AS Group_Id,
    "FixedAssetsGroup"."Name" AS Group_Name,
    MaterialsBeginPrice.Fixed_Account_Id,
    AccountsForMaterials.Num AS Fixed_Account_Num,
    MaterialsBeginPrice.BeginPrice,
    MaterialsIncreasePrice.IncreasePrice,
    MaterialsTotalPrice.TotalPrice,
    MaterialsGroup."CorrectedSum",
    --CurrentPrice--
    IIF((MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum") >= 0,
         (MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum"),
         0) as CurrentPrice,
    --PeriodAmortization--
    IIF((MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum") <= 0, MaterialsTotalPrice.TotalPrice,
         MaterialsGroup."PeriodAmortization") as PeriodAmortization,
    --CurrentAmortization--
    IIF(MaterialsTotalPrice.TotalPrice = (MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") , 0, IIF((MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum") > 0,
         MaterialsGroup."CurrentAmortization",
         IIF( MaterialsGroup."CurrentAmortization" + (MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum") > 0,
              MaterialsGroup."CurrentAmortization" + (MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum"),
              0))) as CurrentAmortization,
    '0' as SelectedCard
  FROM
    "FixedAssetsOrder"
  LEFT JOIN
    Accounts ON "FixedAssetsOrder"."Balance_Account_Id" = Accounts.ID
  LEFT JOIN
    Responsible as SupplierData ON "FixedAssetsOrder"."Supplier_Id" = SupplierData.EmployeeId
  LEFT JOIN
    Responsible as OperatingPersonData ON "FixedAssetsOrder"."OperatingPerson_Id" = OperatingPersonData.EmployeeId
  LEFT JOIN
    "FixedAssetsGroup" ON "FixedAssetsOrder"."Group_Id" = "FixedAssetsGroup"."Id"
  LEFT JOIN
    "Region" ON "FixedAssetsOrder"."Region_Id" = "Region"."Id"
  LEFT JOIN
    (SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
        ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS IncreasePrice
      FROM
        "FixedAssetsMaterials"
      LEFT JOIN
        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
      WHERE "FixedAssetsMaterials"."Flag" = 1 AND
           iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date)  <= @EndDate
      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     ) AS MaterialsIncreasePrice
     ON "FixedAssetsOrder"."Id" = MaterialsIncreasePrice.Order_Id
  LEFT JOIN
    (SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
        MAX("FixedAssetsMaterials"."Fixed_Account_Id") AS Fixed_Account_Id,
        ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS BeginPrice
      FROM
        "FixedAssetsMaterials"
      LEFT JOIN
        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
      WHERE "FixedAssetsMaterials"."Flag" = 0 AND
           iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date)  <= @EndDate
      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     ) AS MaterialsBeginPrice
     ON "FixedAssetsOrder"."Id" = MaterialsBeginPrice.Order_Id 
  LEFT JOIN
    Accounts as AccountsForMaterials ON MaterialsBeginPrice.Fixed_Account_Id = AccountsForMaterials.ID
  LEFT JOIN
    (SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
        ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS TotalPrice
      FROM
        "FixedAssetsMaterials"
      LEFT JOIN
        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
      WHERE "FixedAssetsMaterials"."Flag" < 2  AND
           iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date)  <= @EndDate
      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     ) AS MaterialsTotalPrice
     ON "FixedAssetsOrder"."Id" = MaterialsTotalPrice.Order_Id

   LEFT JOIN
     "GetFixedCardById"(@EndDate, "FixedAssetsOrder"."Id") AS MaterialsGroup ON "FixedAssetsOrder"."Id" = MaterialsGroup."OrderId"

   WHERE
     (1 = 1) */