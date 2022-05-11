SELECT 
     "FixedAssetsGroup"."Id" AS GroupId,
     /*
     SUM(MaterialsPrice.Price) AS BeginPrice,
     SUM(MaterialsGroup.CurrentPrice) AS CurrentPrice,
     SUM(MaterialsGroup.CurrentAmortization) AS CurrentAmortization,
     */
     SUM(MaterialsGroup.CurrentAmortization-MaterialsGroup.CurrentAmortizationToStart) AS CurrentAmortizationForPeriod,
     ACCOUNTS.NUM AS FAO_NUM,
     MaterialsPrice.FAM_NUM
   FROM
     "FixedAssetsOrder"

    LEFT JOIN
        "FixedAssetsGroup" ON "FixedAssetsOrder"."Group_Id" = "FixedAssetsGroup"."Id"

   LEFT JOIN
        ACCOUNTS ON "FixedAssetsOrder"."Balance_Account_Id" = ACCOUNTS.ID

     LEFT JOIN
     (SELECT
            "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
            Expenditures_Accountant.Price,
            ACCOUNTS.NUM AS FAM_NUM
          FROM
             "FixedAssetsMaterials"
          LEFT JOIN
             Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
          LEFT JOIN
             ACCOUNTS ON "FixedAssetsMaterials"."Fixed_Account_Id" = ACCOUNTS.ID
          WHERE
             "FixedAssetsMaterials"."Flag" = 0
     ) AS MaterialsPrice
    ON "FixedAssetsOrder"."Id" = MaterialsPrice.Order_Id




   LEFT JOIN
        (SELECT
            "FixedAssetsMaterials"."FixedAssetsOrder_Id" AS Order_Id,
            /*
             SUM(
                IIF(MonthData.MonthLost<="FixedAssetsOrder"."UsefulMonth",
                    IIF(MonthData.MonthLost<1,MonthData.Price,round(MonthData.Price -(MonthData.Price / "FixedAssetsOrder"."UsefulMonth")*MonthData.MonthLost,2))
                    ,0)
             ) AS CurrentPrice,
            */
             round(SUM(
                IIF(MonthData.MonthLost<="FixedAssetsOrder"."UsefulMonth",
                    IIF(MonthData.MonthLost<1,0,("FixedAssetsMaterials"."FixedPrice" / "FixedAssetsOrder"."UsefulMonth")*MonthData.MonthLost)
                    ,0)
             ),2) AS CurrentAmortization,

             round(SUM(
                IIF(MonthData.MonthLostToStartDate<="FixedAssetsOrder"."UsefulMonth",
                    IIF(MonthData.MonthLostToStartDate<1,0,("FixedAssetsMaterials"."FixedPrice" / "FixedAssetsOrder"."UsefulMonth")*MonthData.MonthLostToStartDate)
                    ,0)
             ),2) AS CurrentAmortizationToStart
          FROM
            "FixedAssetsMaterials"

          LEFT JOIN
          "FixedAssetsOrder" ON "FixedAssetsMaterials"."FixedAssetsOrder_Id" = "FixedAssetsOrder"."Id"



            LEFT JOIN
                (
                SELECT
                "FixedAssetsMaterials"."Id" AS FAM_Id,
                Expenditures_Accountant.Exp_Date AS Exp_Date,
                (datediff(
                                        month,
                                        cast('01' || '.' || substring(100 + extract(month from Expenditures_Accountant.Exp_Date) from 2 for 2) || '.' || extract(year from Expenditures_Accountant.Exp_Date) as date),
                                        @EndDate)
                ) AS MonthLost,

                (datediff(
                                        month,
                                        cast('01' || '.' || substring(100 + extract(month from Expenditures_Accountant.Exp_Date) from 2 for 2) || '.' || extract(year from Expenditures_Accountant.Exp_Date) as date),
                                        @StartDate)
                -1) AS MonthLostToStartDate
                FROM
                    "FixedAssetsMaterials"
                LEFT JOIN
                    Expenditures_Accountant ON "FixedAssetsMaterials"."Expenditures_Id" = Expenditures_Accountant.ID
                WHERE
                    Expenditures_Accountant.Exp_Date <= @EndDate
                ) AS MonthData
            ON "FixedAssetsMaterials"."Id"=MonthData.FAM_Id



            WHERE
                MonthData.Exp_Date <= @EndDate
            GROUP BY
                "FixedAssetsMaterials"."FixedAssetsOrder_Id"
        ) AS MaterialsGroup
    ON "FixedAssetsOrder"."Id" = MaterialsGroup.Order_Id


    WHERE
        "FixedAssetsOrder"."BeginDate" <= @EndDate AND
		"FixedAssetsOrder"."EndRecordDate" IS NULL

    GROUP BY
        "FixedAssetsGroup"."Id", ACCOUNTS.NUM, MaterialsPrice.FAM_NUM
    ORDER BY
        "FixedAssetsGroup"."Id"