                SELECT
                    "FixedAssetsOrder"."Id",
                    "FixedAssetsOrder"."InventoryNumber",
                    "FixedAssetsOrder"."InventoryName",
                    "FixedAssetsOrder"."BeginDate",
                    "FixedAssetsOrder"."EndRegisterDate",
                    "FixedAssetsOrder"."EndDate",
                    "FixedAssetsOrder"."Balance_Account_Id",
                    "FixedAssetsOrder"."UsefulMonth",
                    "FixedAssetsOrder"."Region_Id",
                    "Region"."Name" AS Region_Name,
                    Accounts.Num AS Balance_Account_Num,
                    Suppliers.ID AS Supplier_Id,
                    Suppliers.Name AS Supplier_Name,
                    "FixedAssetsGroup"."Id" AS Group_Id,
                    "FixedAssetsGroup"."Name" AS Group_Name,
                    "FixedAssetsMaterials"."FixedPrice" AS BeginPrice,
                    MaterialsIncreasePrice.IncreasePrice,
                    MaterialsTotalPrice.TotalPrice,
                    MaterialsGroup.CurrentPrice,
                    MaterialsGroup.PeriodAmortization,
                    MaterialsGroup.CurrentAmortization
                  FROM
                    "FixedAssetsOrder"
                  LEFT JOIN
                    Accounts ON "FixedAssetsOrder"."Balance_Account_Id" = Accounts.ID
                  LEFT JOIN
                    Suppliers ON "FixedAssetsOrder"."Supplier_Id" = Suppliers.ID
                  LEFT JOIN
                    "FixedAssetsGroup" ON "FixedAssetsOrder"."Group_Id" = "FixedAssetsGroup"."Id"
                  LEFT JOIN
                    "Region" ON "FixedAssetsOrder"."Region_Id" = "Region"."Id"
                  LEFT JOIN
                    "FixedAssetsMaterials" ON "FixedAssetsOrder"."Id" = "FixedAssetsMaterials"."FixedAssetsOrder_Id"
                  LEFT JOIN
                     Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
                  LEFT JOIN
                    (SELECT
                        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
                        SUM("FixedAssetsMaterials"."FixedPrice") AS IncreasePrice
                      FROM
                        "FixedAssetsMaterials"
                      LEFT JOIN
                        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
                      WHERE "FixedAssetsMaterials"."Flag" = 1 AND
                            Expenditures_Accountant.Exp_Date <= @EndDate
                      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
                     ) AS MaterialsIncreasePrice
                     ON "FixedAssetsOrder"."Id" = MaterialsIncreasePrice.Order_Id
                  LEFT JOIN
                    (SELECT
                        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
                        SUM("FixedAssetsMaterials"."FixedPrice") AS TotalPrice
                      FROM
                        "FixedAssetsMaterials"
                      LEFT JOIN
                        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
                      WHERE Expenditures_Accountant.Exp_Date <= @EndDate
                      GROUP BY "FixedAssetsMaterials"."FixedAssetsOrder_Id"
                     ) AS MaterialsTotalPrice
                     ON "FixedAssetsOrder"."Id" = MaterialsTotalPrice.Order_Id
                  LEFT JOIN
                    (SELECT
                        "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
--new variant
                        round(SUM(
                            IIF(MonthData.MonthLost<="FixedAssetsOrder"."UsefulMonth",
                                IIF(MonthData.MonthLost<1,"FixedAssetsMaterials"."FixedPrice",
                                    "FixedAssetsMaterials"."FixedPrice" -  ( "FixedAssetsMaterials"."FixedPrice" / "FixedAssetsOrder"."UsefulMonth") * MonthData.MonthLost
                                )
                                ,0)
                            ), 2) AS CurrentPrice,

                        round(SUM(
                            IIF(MonthData.MonthLost<="FixedAssetsOrder"."UsefulMonth",
                                IIF(MonthData.MonthLost<1,0,
                                    ( "FixedAssetsMaterials"."FixedPrice" / "FixedAssetsOrder"."UsefulMonth") * MonthData.MonthLost
                                )
                                ,"FixedAssetsMaterials"."FixedPrice")
                            ), 2) AS PeriodAmortization,
--new variant
                        Round(SUM( "FixedAssetsMaterials"."FixedPrice" / "FixedAssetsOrder"."UsefulMonth"), 2) as CurrentAmortization
                      FROM
                        "FixedAssetsMaterials"
--new variant
                    LEFT JOIN
                        (
                        SELECT
                        "FixedAssetsMaterials"."Id" AS FAM_Id,
                        (datediff(
                                                month,
                                                cast('01' || '.' || substring(100 + extract(month from Expenditures_Accountant.Exp_Date) from 2 for 2) || '.' || extract(year from Expenditures_Accountant.Exp_Date) as date),
                                                @EndDate)
                        ) AS MonthLost

                        FROM
                            "FixedAssetsMaterials"
                        LEFT JOIN
                            Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
                        WHERE
                            Expenditures_Accountant.Exp_Date <= @EndDate
                        ) AS MonthData
                    ON "FixedAssetsMaterials"."Id"=MonthData.FAM_Id
--new variant
                      LEFT JOIN
                        Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
                      LEFT JOIN
                        "FixedAssetsOrder" ON "FixedAssetsMaterials"."FixedAssetsOrder_Id" = "FixedAssetsOrder"."Id"
                      WHERE
                        Expenditures_Accountant.Exp_Date <= @EndDate
                      GROUP BY
                        "FixedAssetsMaterials"."FixedAssetsOrder_Id"
                    ) AS MaterialsGroup
                    ON "FixedAssetsOrder"."Id" = MaterialsGroup.Order_Id
                    WHERE
                        "FixedAssetsOrder"."BeginDate" <= @EndDate AND
                        "FixedAssetsMaterials"."Flag" = 0 AND
                        "FixedAssetsOrder"."Id" = @Id