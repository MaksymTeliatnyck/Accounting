SELECT
    Orders.Id,
    Orders.Order_Date, Orders.Receipt_Num,
    Orders.Invoice_Date, Orders.Invoice_Num,
    Orders.Supplier_Id, Suppliers_Sup.Name AS Supplier_Name, Orders.Supplier_Proxy,
    Orders.Vendor_Id, "Contractors"."Name" AS "Vendor_Name", "Contractors"."Srn" AS "Vendor_Srn",
    Orders."Otk_Id", Suppliers_Otk.Name AS Otk_Name,
    Orders."Storekeeper_Id", Suppliers_Storekeeper.Name as Storekeeper_Name,
    Orders.Debit_Account_Id, Debit_Account.Num AS Debit_Account_Num,
    Orders.Total_Price,
    Orders.Total_Currency,
    Orders.Currency_Rate,
    Order_Vat.Account_Id AS Vat_Account_Id, Order_Vat.Price AS Vat, Order_Vat.Num AS Vat_Account_Num,
    IIF(Orders.Total_With_Vat IS NOT NULL, Orders.Total_With_Vat, Orders.Total_Price) AS Total_With_Vat,
    Orders.Correction,
    Orders.Tax_Invoice, Orders.Transport_Invoice,
    Orders.Checked,
    Orders."Color_Id", "Colors"."Name" AS Color_Name,
    Orders.Currency_Id,
    Currency."Code" as Code,
    Orders."Flag1", Orders."Flag2", Orders."Flag3", Orders."Flag4",
    REPLACE(IIF (Orders."Flag1" = 1, 'Склад', '') || ';' || IIF (Orders."Flag2" = 1, 'Склад бух.', '') || ';' || IIF (Orders."Flag3" = 1, '631', '') || ';' || IIF (Orders."Flag4" = 1, '63', ''), ' ', '') AS "Flag",
	Orders."SupplierId",
	Orders."OtkId",
	Orders."StorekeeperId",
	Orders.Account_Num	 	
FROM
    Accounts AS Debit_Account, "Colors",
    "Contractors",
    Orders
    LEFT OUTER JOIN
    (
        SELECT
            Vat.ID,
            Vat.Account_Id,
            Vat.Price,
            Accounts.Num
        FROM
            Vat LEFT OUTER JOIN Accounts
            ON
                Vat.ACCOUNT_ID = Accounts.Id
    ) AS Order_Vat
    ON
        Order_Vat.Id = Orders.Id

    LEFT JOIN Suppliers AS Suppliers_Sup
    ON Orders.Supplier_Id = Suppliers_Sup.Id

    LEFT JOIN Suppliers AS Suppliers_Otk
    ON Orders."Otk_Id" = Suppliers_Otk.Id

    LEFT JOIN Suppliers AS Suppliers_Storekeeper
    ON Orders."Storekeeper_Id" = Suppliers_Storekeeper.Id
    
    LEFT JOIN "Currency" as Currency
    ON Orders.Currency_Id = Currency."Id"

WHERE
    Orders.Vendor_Id = "Contractors"."Id" AND
    Orders.Debit_Account_Id = Debit_Account.Id AND
    Orders."Color_Id" = "Colors"."Id" AND
    Orders.Order_Date BETWEEN @Begin_Date AND @End_Date AND
    --
    (Orders."Flag1" = @Flag1 OR Orders."Flag2" = @Flag2 OR Orders."Flag3" = @Flag3 OR Orders."Flag4" = @Flag4)
ORDER BY
    Orders.Order_Date, Orders.Id
