SELECT
    QuarterGroupMaterials.Balance_Account_Id,
    MAX(Accounts.NUM) as Balance_Account_Num,
    QuarterGroupMaterials.Group_Id,
    MAX("FixedAssetsGroup"."Name") as Group_Name,
    SUM(IIF(QuarterGroupMaterials.Quarter_Number = 1, QuarterGroupMaterials.FixedPrice, 0)) as FirstQuarterSum,
    SUM(IIF(QuarterGroupMaterials.Quarter_Number = 1, QuarterGroupMaterials.FixedPrice_Sold, 0)) as FirstQuarterSum_Sold,
    SUM(IIF(QuarterGroupMaterials.Quarter_Number = 2, QuarterGroupMaterials.FixedPrice, 0)) as SecondQuarterSum,
    SUM(IIF(QuarterGroupMaterials.Quarter_Number = 2, QuarterGroupMaterials.FixedPrice_Sold, 0)) as SecondQuarterSum_Sold,
    SUM(IIF(QuarterGroupMaterials.Quarter_Number = 3, QuarterGroupMaterials.FixedPrice, 0)) as ThirdQuarterSum,
    SUM(IIF(QuarterGroupMaterials.Quarter_Number = 3, QuarterGroupMaterials.FixedPrice_Sold, 0)) as ThirdQuarterSum_Sold,
    SUM(IIF(QuarterGroupMaterials.Quarter_Number = 4, QuarterGroupMaterials.FixedPrice, 0)) as FourthQuarterSum,
    SUM(IIF(QuarterGroupMaterials.Quarter_Number = 4, QuarterGroupMaterials.FixedPrice_Sold, 0)) as FourthQuarterSum_Sold
  FROM
  (SELECT
       Fixed_Order."Balance_Account_Id" as Balance_Account_Id,
       Fixed_Order."Group_Id" as Group_Id,
       ROUND("FixedAssetsMaterials"."FixedPrice", 2) as FixedPrice,
       0 as FixedPrice_Sold,
       (EXTRACT(MONTH from iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date)) -1)/3 + 1 as Quarter_Number
     FROM
       "FixedAssetsOrder" AS Fixed_Order
     LEFT JOIN
       "FixedAssetsMaterials" ON Fixed_Order."Id" = "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     LEFT JOIN
       Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
     WHERE
       (iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date) >= @BeginDate AND
        iif("FixedAssetsMaterials"."Expenditures_Id" IS NULL, "FixedAssetsMaterials"."MaterialsDate", Expenditures_Accountant.Exp_Date) <= @EndDate) AND
       "FixedAssetsMaterials"."Flag" <> 2 AND
       (
           (Fixed_Order."EndRecordDate" IS NULL AND Fixed_Order."BeginRecordDate" <= @EndDate) OR
           (Fixed_Order."EndRecordDate" IS NOT NULL AND Fixed_Order."EndRecordDate" >= @EndDate - 1)
       )

   UNION ALL

   SELECT
       Fixed_Order."Balance_Account_Id" as Balance_Account_Id,
       Fixed_Order."Group_Id" as Group_Id,
       0 as FixedPrice,
       COALESCE("FixedAssetsMaterials"."SoldPrice", 0) as FixedPrice_Sold,
       (EXTRACT(MONTH from Fixed_Order."EndRecordDate") -1)/3 + 1 as Quarter_Number
     FROM
       "FixedAssetsOrder" as Fixed_Order
     LEFT JOIN
       "FixedAssetsMaterials" ON Fixed_Order."Id" = "FixedAssetsMaterials"."FixedAssetsOrder_Id"
     WHERE
       (Fixed_Order."EndRecordDate" >= @BeginDate AND Fixed_Order."EndRecordDate" <= @EndDate) AND
       "FixedAssetsMaterials"."Flag" != 2
  ) AS QuarterGroupMaterials

  LEFT JOIN
    Accounts ON QuarterGroupMaterials.Balance_Account_Id = Accounts.ID
  LEFT JOIN
    "FixedAssetsGroup" ON QuarterGroupMaterials.Group_Id = "FixedAssetsGroup"."Id"
  GROUP BY
    QuarterGroupMaterials.Balance_Account_Id,
    QuarterGroupMaterials.Group_Id
  ORDER BY
    QuarterGroupMaterials.Balance_Account_Id,
    QuarterGroupMaterials.Group_Id