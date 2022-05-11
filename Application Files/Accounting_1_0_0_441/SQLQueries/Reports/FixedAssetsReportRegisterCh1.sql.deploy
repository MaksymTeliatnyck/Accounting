SELECT 
   "FixedAssetsGroup"."Id"  ,
   Sum(COALESCE(MaterialsGroup."CurrentAmortization", 0)) as CurrentAmortizationForPeriod,
   AccountsForMaterials.NUM as FAM_NUM

   FROM
     "FixedAssetsOrder"

    LEFT JOIN
        "FixedAssetsGroup" ON "FixedAssetsOrder"."Group_Id" = "FixedAssetsGroup"."Id"

   LEFT JOIN
        ACCOUNTS ON "FixedAssetsOrder"."Balance_Account_Id" = ACCOUNTS.ID
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

    GROUP BY
       "FixedAssetsGroup"."Id",
       AccountsForMaterials.NUM


/* SELECT 
   "FixedAssetsGroup"."Id"  ,
   Sum(IIF(MaterialsTotalPrice.TotalPrice = (MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") , 0, IIF((MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum") > 0,
        MaterialsGroup."CurrentAmortization",
        IIF( MaterialsGroup."CurrentAmortization" + (MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum") > 0,
             MaterialsGroup."CurrentAmortization" + (MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum"),
   0)))) as CurrentAmortizationForPeriod,
   AccountsForMaterials.NUM as FAM_NUM

   FROM
     "FixedAssetsOrder"

    LEFT JOIN
        "FixedAssetsGroup" ON "FixedAssetsOrder"."Group_Id" = "FixedAssetsGroup"."Id"

   LEFT JOIN
        ACCOUNTS ON "FixedAssetsOrder"."Balance_Account_Id" = ACCOUNTS.ID

    LEFT JOIN
    (SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
        MAX("FixedAssetsMaterials"."Fixed_Account_Id") AS Fixed_Account_Id
      FROM
        "FixedAssetsMaterials"
      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     ) AS MaterialsPrice
     ON "FixedAssetsOrder"."Id" = MaterialsPrice.Order_Id 
    LEFT JOIN
        Accounts as AccountsForMaterials ON MaterialsPrice.Fixed_Account_Id = AccountsForMaterials.ID

    LEFT JOIN
        "GetFixedCardById"(@EndDate, "FixedAssetsOrder"."Id") AS MaterialsGroup ON "FixedAssetsOrder"."Id" = MaterialsGroup."OrderId"

    LEFT JOIN
    (SELECT
        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
        ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS TotalPrice
      FROM
        "FixedAssetsMaterials"
      LEFT JOIN
        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
      WHERE "FixedAssetsMaterials"."Flag" < 2  AND
            iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date) <= @EndDate
      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     ) AS MaterialsTotalPrice
     ON "FixedAssetsOrder"."Id" = MaterialsTotalPrice.Order_Id


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

    GROUP BY
       "FixedAssetsGroup"."Id", AccountsForMaterials.NUM */