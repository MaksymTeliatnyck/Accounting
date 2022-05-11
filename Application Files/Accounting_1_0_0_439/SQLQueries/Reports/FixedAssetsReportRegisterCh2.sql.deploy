    SELECT 
        "FixedAssetsGroup"."Id" AS GroupId,
        ROUND(SUM("FixedAssetsMaterials"."FixedPrice"), 2) AS FixedPrice,
        ACCOUNTS.NUM AS FAO_NUM
    FROM
        "FixedAssetsOrder"
    LEFT JOIN
        "FixedAssetsGroup" ON "FixedAssetsOrder"."Group_Id" = "FixedAssetsGroup"."Id"
    LEFT JOIN
        ACCOUNTS ON "FixedAssetsOrder"."Balance_Account_Id" = ACCOUNTS.ID
    LEFT JOIN
        "FixedAssetsMaterials" ON "FixedAssetsOrder"."Id" = "FixedAssetsMaterials"."FixedAssetsOrder_Id"
    LEFT JOIN
        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID


    WHERE
       (iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date) >= @BeginDate AND
        iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date) <= @EndDate) AND
       "FixedAssetsMaterials"."Flag" <> 2 AND
       (
           ("FixedAssetsOrder"."EndRecordDate" IS NULL AND "FixedAssetsOrder"."BeginRecordDate" < @EndDate) OR
           ("FixedAssetsOrder"."EndRecordDate" IS NOT NULL AND "FixedAssetsOrder"."EndRecordDate" >= @EndDate)
       )
    GROUP BY
        "FixedAssetsGroup"."Id", ACCOUNTS.NUM
    ORDER BY
        "FixedAssetsGroup"."Id"