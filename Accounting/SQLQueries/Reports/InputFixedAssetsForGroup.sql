SELECT
    FAOMain."Id",
    FAOMain."InventoryNumber",
    FAOMain."InventoryName",
    FAOMain."Group_Id",
    FAG."Name" AS GroupName,
    ACC.NUM,
    extract(month from FAOMain."BeginDate") AS MonthSet,
    extract(year from FAOMain."BeginDate") AS YearSet,
    COALESCE(FirstYear.FYearPrice,0) AS FYearPrice,
    COALESCE(LastYear.LYearPrice,0) AS LYearPrice,
    (COALESCE(LastYear.LYearPrice,0) - COALESCE(FirstYear.FYearPrice,0)) AS Difference
FROM
    "FixedAssetsOrder" AS FAOMain
LEFT JOIN
    ACCOUNTS AS ACC ON FAOMain."Balance_Account_Id" = ACC.ID
LEFT JOIN
    "FixedAssetsGroup" AS FAG ON FAOMain."Group_Id" = FAG."Id"
LEFT JOIN
    (
    SELECT
        FAO."Id",
        Round(Sum(FAM."FixedPrice"), 2) AS FYearPrice
    FROM
        "FixedAssetsOrder" AS FAO
    LEFT JOIN
        "FixedAssetsMaterials" AS FAM ON FAO."Id"=FAM."FixedAssetsOrder_Id"
    LEFT JOIN
        Expenditures_Accountant AS EA ON FAM."Expenditures_Id" = EA.ID
    WHERE
        (FAM."Flag" <> 2) AND iif(EA.Exp_Date IS NULL, FAM."MaterialsDate", EA.Exp_Date) < @StartDateFYear AND
        (FAO."BeginRecordDate" < @StartDateFYear AND (FAO."EndRecordDate" is null or FAO."EndRecordDate" >= (@StartDateFYear - 1)))
    GROUP BY
        FAO."Id"
    ) AS FirstYear
        ON FAOMain."Id" = FirstYear."Id"
LEFT JOIN
    (
    SELECT
        FAO."Id",
        Round(Sum(FAM."FixedPrice"), 2) AS LYearPrice
    FROM
        "FixedAssetsOrder" AS FAO
    LEFT JOIN
        "FixedAssetsMaterials" AS FAM ON FAO."Id"=FAM."FixedAssetsOrder_Id"
    LEFT JOIN
        Expenditures_Accountant AS EA ON FAM."Expenditures_Id" = EA.ID
    WHERE
        (FAM."Flag" <> 2) AND iif(EA.Exp_Date IS NULL, FAM."MaterialsDate", EA.Exp_Date) <= @StartDateLYear AND
        (FAO."BeginRecordDate" <= @StartDateLYear AND (FAO."EndRecordDate" is null or FAO."EndRecordDate" >= @StartDateLYear))
    GROUP BY
        FAO."Id"
    ) AS LastYear
        ON FAOMain."Id" = LastYear."Id"
WHERE
    COALESCE(LastYear.LYearPrice, 0) > 0 OR
    COALESCE(FirstYear.FYearPrice, 0) > 0
ORDER BY
    FAOMain."Group_Id", FAOMain."InventoryNumber"
