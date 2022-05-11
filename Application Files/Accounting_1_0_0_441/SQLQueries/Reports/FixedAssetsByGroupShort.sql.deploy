SELECT
    SUM(AmortizingDetailed.CurrentAmortization ) AS PeriodAmortization,
    AmortizingDetailed.Group_Id,
    "FixedAssetsGroup"."Name",
    AmortizingDetailed.Fixed_Account_Id,
    AmortizingDetailed.Balance_Account_Id,
    ACCOUNTS.NUM
FROM
    (
    SELECT
        "FixedAssetsOrder"."Group_Id" AS Group_Id,
        "FixedAssetsOrder"."Balance_Account_Id" AS Balance_Account_Id,
        MaterialsGroup."Fixed_Account_Id" AS Fixed_Account_Id,
        --CurrentPrice--
        COALESCE(MaterialsGroup."CurrentPrice", 0) as CurrentPrice,
        --CurrentAmortization--
        COALESCE(MaterialsGroup."CurrentAmortization", 0) as CurrentAmortization
        FROM
            "FixedAssetsOrder"
        LEFT JOIN
           "GetCurrentAmortizationByCardId"("FixedAssetsOrder"."Id", @EndDate) AS MaterialsGroup ON "FixedAssetsOrder"."Id" = MaterialsGroup."OrderId"
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
        ORDER BY "FixedAssetsOrder"."Group_Id", "FixedAssetsOrder"."BeginDate"
        ) AS AmortizingDetailed
    LEFT JOIN
        "FixedAssetsGroup" ON AmortizingDetailed.Group_Id = "FixedAssetsGroup"."Id"
    LEFT JOIN
        ACCOUNTS ON AmortizingDetailed.Balance_Account_Id = ACCOUNTS.ID
    WHERE
        (AmortizingDetailed.CurrentPrice + AmortizingDetailed.CurrentAmortization > 0)
GROUP BY
    AmortizingDetailed.Balance_Account_Id,
    ACCOUNTS.NUM,
    AmortizingDetailed.Group_Id,
    "FixedAssetsGroup"."Name",
    AmortizingDetailed.Fixed_Account_Id
ORDER BY
    AmortizingDetailed.Balance_Account_Id,
    AmortizingDetailed.Group_Id,
    AmortizingDetailed.Fixed_Account_Id



/* SELECT
    SUM(AmortizingDetailed.CurrentAmortization ) AS PeriodAmortization,
    AmortizingDetailed.Group_Id,
    "FixedAssetsGroup"."Name",
    AmortizingDetailed.Fixed_Account_Id,
    AmortizingDetailed.Balance_Account_Id,
    ACCOUNTS.NUM
FROM
    (
    SELECT
        "FixedAssetsOrder"."Group_Id" AS Group_Id,
        "FixedAssetsOrder"."Balance_Account_Id" AS Balance_Account_Id,
        MaterialsGroup."Fixed_Account_Id" AS Fixed_Account_Id,
        --CurrentPrice--
        IIF((MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum") >= 0,
             (MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum"),
             0) as CurrentPrice,
        --CurrentAmortization--
        IIF(MaterialsTotalPrice.TotalPrice = (MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") , 0, IIF((MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum") > 0,
             MaterialsGroup."CurrentAmortization",
             IIF( MaterialsGroup."CurrentAmortization" + (MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum") > 0,
                  MaterialsGroup."CurrentAmortization" + (MaterialsTotalPrice.TotalPrice - MaterialsGroup."PeriodAmortization") + (MaterialsGroup."CorrectedSum"),
                  0))) as CurrentAmortization
        FROM
            "FixedAssetsOrder"
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
        ORDER BY "FixedAssetsOrder"."Group_Id", "FixedAssetsOrder"."BeginDate"
        ) AS AmortizingDetailed
    LEFT JOIN
        "FixedAssetsGroup" ON AmortizingDetailed.Group_Id = "FixedAssetsGroup"."Id"
    LEFT JOIN
        ACCOUNTS ON AmortizingDetailed.Balance_Account_Id = ACCOUNTS.ID
    WHERE
        (AmortizingDetailed.CurrentPrice + AmortizingDetailed.CurrentAmortization > 0)
GROUP BY
    AmortizingDetailed.Balance_Account_Id,
    ACCOUNTS.NUM,
    AmortizingDetailed.Group_Id,
    "FixedAssetsGroup"."Name",
    AmortizingDetailed.Fixed_Account_Id
ORDER BY
    AmortizingDetailed.Balance_Account_Id,
    AmortizingDetailed.Group_Id,
    AmortizingDetailed.Fixed_Account_Id */