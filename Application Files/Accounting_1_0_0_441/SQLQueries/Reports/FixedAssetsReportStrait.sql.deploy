SELECT *
FROM (
SELECT
    "FixedAssetsOrder"."Id",
    "FixedAssetsOrder"."InventoryNumber",
    "FixedAssetsOrder"."InventoryName",
    "FixedAssetsGroup"."Id" AS GroupId,
    "FixedAssetsGroup"."Name" AS GroupName,
    SupplierData.EmployeeId AS Supplier_Id,
    SupplierData.FullName AS Supplier_Name,
    OperatingPersonData.EmployeeId AS OperatingPerson_Id,
    OperatingPersonData.FullName AS OperatingPerson_Name,
    MaterialsBeginPrice.BeginPrice AS BeginPrice,
    MaterialsTotalPriceFull.TotalPriceFull,
    MaterialsIncreasePrice.IncreasePrice,
    "Region"."Name" AS RegionName,
    COALESCE(MaterialsGroup."FixedPrice", 0) as TotalPrice,
    --CurrentPrice--
    COALESCE(MaterialsGroup."CurrentPrice", 0) as CurrentPrice,
    --PeriodAmortization--
    COALESCE(MaterialsGroup."PeriodAmortization", 0) as PeriodAmortization,
	--PeriodYearAmortization--
    COALESCE(MaterialsGroup."PeriodYearAmortization", 0) as PeriodYearAmortization,
    --CurrentAmortization--
    COALESCE(MaterialsGroup."CurrentAmortization", 0) as CurrentAmortization,
    ACCOUNTS.NUM AS FAO_NUM,
    AccountsForMaterials.Num AS FAM_NUM,
    "FixedAssetsOrder"."BeginDate"
     
    FROM
        "FixedAssetsOrder"
    LEFT JOIN
        "Region" ON "FixedAssetsOrder"."Region_Id" = "Region"."Id"

    LEFT JOIN
        "FixedAssetsGroup" ON "FixedAssetsOrder"."Group_Id" = "FixedAssetsGroup"."Id"

    LEFT JOIN
        ACCOUNTS ON "FixedAssetsOrder"."Balance_Account_Id" = ACCOUNTS.ID
    LEFT JOIN
        Responsible as SupplierData ON "FixedAssetsOrder"."Supplier_Id" = SupplierData.EmployeeId
    LEFT JOIN
        Responsible as OperatingPersonData ON "FixedAssetsOrder"."OperatingPerson_Id" = OperatingPersonData.EmployeeId
    LEFT JOIN
    (SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
        ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS IncreasePrice
      FROM
        "FixedAssetsMaterials"
      LEFT JOIN
        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
      WHERE "FixedAssetsMaterials"."Flag" = 1 AND
             iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date) <= @EndDate
      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     ) AS MaterialsIncreasePrice
     ON "FixedAssetsOrder"."Id" = MaterialsIncreasePrice.Order_Id

    LEFT JOIN
    (SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
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
     (SELECT
            "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
            ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS TotalPriceFull
          FROM
             "FixedAssetsMaterials"
          LEFT JOIN
             Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
          WHERE
             "FixedAssetsMaterials"."Flag" <> 2  AND
             iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date)  <= @EndDate
          GROUP BY
             "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     ) AS MaterialsTotalPriceFull
     ON "FixedAssetsOrder"."Id" = MaterialsTotalPriceFull.Order_Id

  LEFT JOIN
    "GetCurrentAmortizationByCardId"("FixedAssetsOrder"."Id", @EndDate) AS MaterialsGroup ON "FixedAssetsOrder"."Id" = MaterialsGroup."OrderId"
  LEFT JOIN
    Accounts as AccountsForMaterials ON MaterialsGroup."Fixed_Account_Id" = AccountsForMaterials.ID

    WHERE
     "FixedAssetsOrder"."BeginDate" <= @EndDate AND
     (
       (
         "FixedAssetsOrder"."EndRecordDate" IS NULL AND
         "FixedAssetsOrder"."BeginRecordDate" <= @EndDate
        ) OR
       (
         "FixedAssetsOrder"."EndRecordDate" >= @EndDate
        )
      )

    ORDER BY "FixedAssetsGroup"."Name", "FixedAssetsOrder"."BeginDate"
)



/* SELECT *
FROM (
SELECT
    "FixedAssetsOrder"."Id",
    "FixedAssetsOrder"."InventoryNumber",
    "FixedAssetsOrder"."InventoryName",
    "FixedAssetsGroup"."Id" AS GroupId,
    "FixedAssetsGroup"."Name" AS GroupName,
    SupplierData.EmployeeId AS Supplier_Id,
    SupplierData.FullName AS Supplier_Name,
    OperatingPersonData.EmployeeId AS OperatingPerson_Id,
    OperatingPersonData.FullName AS OperatingPerson_Name,
    MaterialsBeginPrice.BeginPrice AS BeginPrice,
    MaterialsTotalPrice.TotalPrice,
    MaterialsTotalPriceFull.TotalPriceFull,
    MaterialsIncreasePrice.IncreasePrice,
    "Region"."Name" AS RegionName,
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
    ACCOUNTS.NUM AS FAO_NUM,
    AccountsForMaterials.Num AS FAM_NUM,
    "FixedAssetsOrder"."BeginDate"
     
    FROM
        "FixedAssetsOrder"
    LEFT JOIN
        "Region" ON "FixedAssetsOrder"."Region_Id" = "Region"."Id"

    LEFT JOIN
        "FixedAssetsGroup" ON "FixedAssetsOrder"."Group_Id" = "FixedAssetsGroup"."Id"

    LEFT JOIN
        ACCOUNTS ON "FixedAssetsOrder"."Balance_Account_Id" = ACCOUNTS.ID
    LEFT JOIN
        Responsible as SupplierData ON "FixedAssetsOrder"."Supplier_Id" = SupplierData.EmployeeId
    LEFT JOIN
        Responsible as OperatingPersonData ON "FixedAssetsOrder"."OperatingPerson_Id" = OperatingPersonData.EmployeeId
    LEFT JOIN
    (SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
        ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS IncreasePrice
      FROM
        "FixedAssetsMaterials"
      LEFT JOIN
        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
      WHERE "FixedAssetsMaterials"."Flag" = 1 AND
             iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date) <= @EndDate
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
          WHERE
             "FixedAssetsMaterials"."Flag" < 2  AND
             iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date)  <= @EndDate
          GROUP BY
             "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     ) AS MaterialsTotalPrice
     ON "FixedAssetsOrder"."Id" = MaterialsTotalPrice.Order_Id

     LEFT JOIN
     (SELECT
            "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
            ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS TotalPriceFull
          FROM
             "FixedAssetsMaterials"
          LEFT JOIN
             Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
          WHERE
             "FixedAssetsMaterials"."Flag" <> 2  AND
             iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date)  <= @EndDate
          GROUP BY
             "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     ) AS MaterialsTotalPriceFull
     ON "FixedAssetsOrder"."Id" = MaterialsTotalPriceFull.Order_Id

    LEFT JOIN
      "GetFixedCardById"(@EndDate, "FixedAssetsOrder"."Id") AS MaterialsGroup ON "FixedAssetsOrder"."Id" = MaterialsGroup."OrderId"

    WHERE
     "FixedAssetsOrder"."BeginDate" <= @EndDate AND
     (
       (
         "FixedAssetsOrder"."EndRecordDate" IS NULL AND
         "FixedAssetsOrder"."BeginRecordDate" <= @EndDate
        ) OR
       (
         "FixedAssetsOrder"."EndRecordDate" >= @EndDate
        )
      )

    ORDER BY "FixedAssetsGroup"."Name", "FixedAssetsOrder"."BeginDate"
) */