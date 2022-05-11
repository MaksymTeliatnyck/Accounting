using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using SpreadsheetGear;
namespace Accounting
{
    class DataModule : IDisposable
    {
        public static FbConnection Connection;
        public static FbTransaction Transaction;

        public static DataSet AccountingDS;

        public static Dictionary<string, FbDataAdapter> DataAdapter;

        public static Dictionary<string, string> Queries;
        public static Dictionary<string, string> Errors = new Dictionary<string, string>(15)
        {
            {"08001", "Не можливо встановити з'єднання"},
            {"08003", "Відсутнє з'єднання"},
            {"08004", "Сервер відхилив з'єднання"},
            {"08006", "Помилка з'єднання"},
            {"0B000", "Помилкова ініціалізація транзакції"},
            {"25S02", "Транзакція все ще активна"},
            {"335544466", "Неможливо видалити запис, який має пов'язані записи"},
            {"23000", "Порушення цілісності обмеження"},
            {"3B000", "Невірна точка збереження"},
            {"22003", "Числове значення поза межами діапазону"},
            {"2206", "Порожнє значення в полі посилань"},
            {"2207", "Невірний формат дати або часу"},
            {"2200F", "Запис нульової довжини"},
            {"22012", "Ділення на нуль"},
            {"22004", "Порожні значення неприпустимі"}
        };

        public DataModule(string User, string Password, string Database, string DataSource, int Port = 3050, string CharSet = "Win1251", bool Pooling = true, int ConnectionLifeTime = 300)
        {
            FbConnectionStringBuilder CSB = new FbConnectionStringBuilder();
            CSB.UserID = User;CSB.Password = Password;
            CSB.Database = Database;
            CSB.DataSource = DataSource;
            CSB.Port = Port;
            CSB.Charset = CharSet;
            CSB.Pooling = Pooling;
            CSB.MinPoolSize = 0;
            CSB.MaxPoolSize = 50;
            CSB.PacketSize = 8192;
            CSB.ConnectionLifeTime = ConnectionLifeTime;
            CSB.Dialect = 3;

            Connection = new FbConnection(CSB.ConnectionString);

            AccountingDS = new DataSet("Accounting");
            DataAdapter = new Dictionary<string, FbDataAdapter>(12);

            LoadSqlQueries();
        }

        private void LoadSqlQueries()
        {
            if (Directory.Exists(Utils.HomePath + "\\SQLQueries\\"))
            {
                Queries = new Dictionary<string, string>();
                foreach (string Files in Directory.GetFiles(Utils.HomePath + "\\SQLQueries\\", "*.SQL", SearchOption.AllDirectories))
                {
                    Queries.Add(Path.GetFileNameWithoutExtension(Files), File.ReadAllText(Files));
                }
            }
        }

        public void InitAdapter()
        {
            #region Order

            DataAdapter.Add("Order", new FbDataAdapter());
            // Select Command
            DataAdapter["Order"].SelectCommand = Connection.CreateCommand();
            DataAdapter["Order"].SelectCommand.CommandText = Queries["Orders"];
            DataAdapter["Order"].SelectCommand.Parameters.Add("Begin_Date", FbDbType.Date, 10);
            DataAdapter["Order"].SelectCommand.Parameters.Add("End_Date", FbDbType.Date, 10);
            DataAdapter["Order"].SelectCommand.Parameters.Add("Flag1", FbDbType.SmallInt, 2);
            DataAdapter["Order"].SelectCommand.Parameters.Add("Flag2", FbDbType.SmallInt, 2);
            DataAdapter["Order"].SelectCommand.Parameters.Add("Flag3", FbDbType.SmallInt, 2);
            DataAdapter["Order"].SelectCommand.Parameters.Add("Flag4", FbDbType.SmallInt, 2);
            DataAdapter["Order"].SelectCommand.Parameters.Add("Flag4", FbDbType.SmallInt, 2);
            // Insert Command
            DataAdapter["Order"].InsertCommand = Connection.CreateCommand();
            DataAdapter["Order"].InsertCommand.CommandText =
                @"INSERT INTO
                    Orders(Id, Order_Date, Receipt_Num, Invoice_Date, Invoice_Num, Vendor_Id, Supplier_Id, Supplier_Proxy, Debit_Account_Id, Total_With_Vat, Correction, Tax_Invoice, Transport_Invoice, ""Color_Id"", Checked, ""Flag1"", ""Flag2"", ""Flag3"", ""Flag4"", ""Otk_Id"", ""Storekeeper_Id"", Currency_Id, Currency_Rate, ""SupplierId"", ""OtkId"", ""StorekeeperId"", Account_Num)
                VALUES
                    (@Id, @Order_Date, @Receipt_Num, @Invoice_Date, @Invoice_Num, @Vendor_Id, @Supplier_Id, @Supplier_Proxy, @Debit_Account_Id, @Total_With_Vat, @Correction, @Tax_Invoice, @Transport_Invoice, @Color_Id, @Checked, @Flag1, @Flag2, @Flag3, @Flag4, @Otk_Id, @Storekeeper_Id, @Currency_Id, @Currency_Rate, @SupplierId, @OtkId, @StorekeeperId, @Account_Num)";
            DataAdapter["Order"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Order_Date", FbDbType.Date, 10, "Order_Date");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Receipt_Num", FbDbType.VarChar, 10, "Receipt_Num");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Invoice_Date", FbDbType.Date, 10, "Invoice_Date");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Invoice_Num", FbDbType.VarChar, 50, "Invoice_Num");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Vendor_Id", FbDbType.Integer, 4 , "Vendor_Id");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Supplier_Id", FbDbType.SmallInt, 2, "Supplier_Id");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Supplier_Proxy", FbDbType.VarChar, 50, "Supplier_Proxy");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Total_With_Vat", FbDbType.Numeric, 11, "Total_With_Vat");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Debit_Account_Id", FbDbType.SmallInt, 2, "Debit_Account_Id");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Correction", FbDbType.SmallInt, 2, "Correction");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Tax_Invoice", FbDbType.SmallInt, 2, "Tax_Invoice");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Transport_Invoice", FbDbType.SmallInt, 2, "Transport_Invoice");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Color_Id", FbDbType.SmallInt, 2, "Color_Id");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Checked", FbDbType.SmallInt, 2, "Checked");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Flag1", FbDbType.SmallInt, 2, "Flag1");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Flag2", FbDbType.SmallInt, 2, "Flag2");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Flag3", FbDbType.SmallInt, 2, "Flag3");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Flag4", FbDbType.SmallInt, 2, "Flag4");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Otk_Id", FbDbType.SmallInt, 2, "Otk_Id");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Storekeeper_Id", FbDbType.SmallInt, 2, "Storekeeper_Id");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Currency_Id", FbDbType.SmallInt, 2, "Currency_Id");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Currency_Rate", FbDbType.Numeric, 11, "Currency_Rate");
            DataAdapter["Order"].InsertCommand.Parameters.Add("SupplierId", FbDbType.Integer, 4, "SupplierId");
            DataAdapter["Order"].InsertCommand.Parameters.Add("OtkId", FbDbType.Integer, 4, "OtkId");
            DataAdapter["Order"].InsertCommand.Parameters.Add("StorekeeperId", FbDbType.Integer, 4, "StorekeeperId");
            DataAdapter["Order"].InsertCommand.Parameters.Add("Account_Num", FbDbType.VarChar, 50, "Account_Num");
            // Update Command
            DataAdapter["Order"].UpdateCommand = Connection.CreateCommand();
            DataAdapter["Order"].UpdateCommand.CommandText =
                @"UPDATE
                    Orders
                SET
                    Order_Date = @Order_Date, Receipt_Num = @Receipt_Num,
                    Invoice_Date = @Invoice_Date, Invoice_Num = @Invoice_Num,
                    Vendor_Id = @Vendor_Id,
                    Supplier_Id = @Supplier_Id, Supplier_Proxy = @Supplier_Proxy,
                    Total_With_Vat = @Total_With_Vat,
                    Debit_Account_Id = @Debit_Account_Id,
                    Correction = @Correction,
                    Tax_Invoice = @Tax_Invoice, Transport_Invoice = @Transport_Invoice,
                    ""Flag1"" = @Flag1, ""Flag2"" = @Flag2, ""Flag3"" = @Flag3, ""Flag4"" = @Flag4,
                    ""Color_Id"" = @Color_Id,
                    Checked = @Checked,
                    ""Otk_Id"" = @Otk_Id,
                    ""Storekeeper_Id"" = @Storekeeper_Id,
                    Currency_Id = @Currency_Id,
                    Currency_Rate = @Currency_Rate,
                    ""SupplierId"" = @SupplierId,
                    ""OtkId"" = @OtkId,
                    ""StorekeeperId"" = @StorekeeperId,
                    Account_Num = @Account_Num
                 WHERE
                    Id = @Id";
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Order_Date", FbDbType.Date, 10, "Order_Date");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Receipt_Num", FbDbType.VarChar, 10, "Receipt_Num");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Invoice_Date", FbDbType.Date, 10, "Invoice_Date");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Invoice_Num", FbDbType.VarChar, 50, "Invoice_Num");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Vendor_Id", FbDbType.Integer, 4, "Vendor_Id");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Supplier_Id", FbDbType.SmallInt, 2, "Supplier_Id");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Supplier_Proxy", FbDbType.VarChar, 50, "Supplier_Proxy");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Total_With_Vat", FbDbType.Numeric, 11, "Total_With_Vat");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Debit_Account_Id", FbDbType.SmallInt, 2, "Debit_Account_Id");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Correction", FbDbType.SmallInt, 2, "Correction");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Tax_Invoice", FbDbType.SmallInt, 2, "Tax_Invoice");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Transport_Invoice", FbDbType.SmallInt, 2, "Transport_Invoice");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Color_Id", FbDbType.SmallInt, 2, "Color_Id");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Checked", FbDbType.SmallInt, 2, "Checked");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Flag1", FbDbType.SmallInt, 2, "Flag1");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Flag2", FbDbType.SmallInt, 2, "Flag2");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Flag3", FbDbType.SmallInt, 2, "Flag3");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Flag4", FbDbType.SmallInt, 2, "Flag4");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Otk_Id", FbDbType.SmallInt, 2, "Otk_Id");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Storekeeper_Id", FbDbType.SmallInt, 2, "Storekeeper_Id");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Currency_Id", FbDbType.SmallInt, 2, "Currency_Id");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Currency_Rate", FbDbType.Numeric, 11, "Currency_Rate");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("SupplierId", FbDbType.Integer, 4, "SupplierId");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("OtkId", FbDbType.Integer, 4, "OtkId");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("StorekeeperId", FbDbType.Integer, 4, "StorekeeperId");
            DataAdapter["Order"].UpdateCommand.Parameters.Add("Account_Num", FbDbType.VarChar, 50, "Account_Num");
            // Delete Command
            DataAdapter["Order"].DeleteCommand = Connection.CreateCommand();
            DataAdapter["Order"].DeleteCommand.CommandText = 
                @"DELETE FROM
                    Orders
                WHERE
                    Id = @Id";
            DataAdapter["Order"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            
            #endregion

            #region Contractors

            DataAdapter.Add("Contractors", new FbDataAdapter());
            DataAdapter["Contractors"].SelectCommand = Connection.CreateCommand();
            DataAdapter["Contractors"].SelectCommand.CommandText =
                @"SELECT * FROM ""Contractors"" ORDER BY ""Name""";
            //
            DataAdapter["Contractors"].InsertCommand = Connection.CreateCommand();
            DataAdapter["Contractors"].InsertCommand.CommandText =
                @"INSERT INTO ""Contractors""(""Name"", ""Srn"") VALUES(@Name, @Srn) RETURNING ""Id""";
            DataAdapter["Contractors"].InsertCommand.Parameters.Add("Name", FbDbType.VarChar, 200, "Name");
            DataAdapter["Contractors"].InsertCommand.Parameters.Add("Srn", FbDbType.VarChar, 12, "Srn");
            DataAdapter["Contractors"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id").Direction = ParameterDirection.Output;
            //
            DataAdapter["Contractors"].UpdateCommand = Connection.CreateCommand();
            DataAdapter["Contractors"].UpdateCommand.CommandText =
                @"UPDATE ""Contractors"" SET ""Name"" = @Name, ""Srn"" = @Srn WHERE ""Id"" = @Id";
            DataAdapter["Contractors"].UpdateCommand.Parameters.Add("Name", FbDbType.VarChar, 200, "Name");
            DataAdapter["Contractors"].UpdateCommand.Parameters.Add("Srn", FbDbType.VarChar, 12, "Srn");
            DataAdapter["Contractors"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            //
            DataAdapter["Contractors"].DeleteCommand = Connection.CreateCommand();
            DataAdapter["Contractors"].DeleteCommand.CommandText =
                @"DELETE FROM ""Contractors"" WHERE ""Id"" = @Id";
            DataAdapter["Contractors"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            #endregion

            #region DeliveryOrders

            // DeliveryOrder
            DataAdapter.Add("DeliveryOrders", new FbDataAdapter());
            // Select Command
            DataAdapter["DeliveryOrders"].SelectCommand = Connection.CreateCommand();

            DataAdapter["DeliveryOrders"].SelectCommand.CommandText =
            @"SELECT
                dor.""Id"",
                d.""DeliveryName"",
                dor.""DeliveryId"",
                dor.""DeliveryPriceTypeId"",
                dor.""OrderDate"",
                dor.TTN,
                dor.""Price"",
                dpt.""DeliveryPaymentName"",
                con.""Srn"" AS ""ContractorCode"",
                con.""Name"" AS ""Contractorname"",
                o.""RECEIPT_NUM"" AS ""ReceiptNum"",
                iif(o.""RECEIPT_NUM"" is NULL , 0, 1) as ""ReceiptCheck"",
                o.ORDER_DATE,
                o.INVOICE_DATE AS ""InvoiceDate""
            FROM
                ""DeliveryOrder"" dor
            LEFT JOIN
                ""DeliveryPaymentType"" dpt ON dor.""DeliveryPriceTypeId"" = dpt.""Id""
            LEFT JOIN
                ""Delivery"" d ON dor.""DeliveryId"" = d.""Id""
            LEFT JOIN
                ""DeliveryOrdersDetails"" dod ON dor.""Id"" = dod.""DeliveryOrderId""
            LEFT JOIN
                ORDERS o ON dod.""OrderId"" = o.ID
            LEFT JOIN
                ""Contractors"" con ON o.VENDOR_ID = con.""Id""
            WHERE
                dor.""OrderDate"" BETWEEN @StartDate AND @EndDate
            ORDER BY
                dor.""OrderDate"" DESC";


//            DataAdapter["DeliveryOrders"].SelectCommand.CommandText =
//                    @"SELECT
//                        dor.""Id"",
//                        d.""DeliveryName"",
//                        dor.""DeliveryId"",
//                        dor.""DeliveryPriceTypeId"",
//                        dor.""OrderDate"",
//                        dor.TTN,
//                        dor.""Price"",
//                        dpt.""DeliveryPaymentName"",
//                        o.""RECEIPT_NUM"",
//                        iif(o.""RECEIPT_NUM"" is NULL , 0, 1) as ""ReceiptCheck""
//                    FROM
//                        ""DeliveryOrder"" dor
//                    LEFT JOIN
//                        ""DeliveryPaymentType"" dpt ON dor.""DeliveryPriceTypeId"" = dpt.""Id""
//                    LEFT JOIN
//                        ""Delivery"" d ON dor.""DeliveryId"" = d.""Id""
//                    LEFT JOIN
//                        ""DeliveryOrdersDetails"" dod ON dor.""Id"" = dod.""DeliveryOrderId""
//                    LEFT JOIN
//                        ORDERS o ON dod.""OrderId"" = o.ID
//                    WHERE
//                        dor.""OrderDate"" BETWEEN @StartDate AND @EndDate
//                    ORDER BY
//                        dor.""OrderDate"" DESC";

            /*GROUP BY
                        dor.""Id"", d.""DeliveryName"", dor.""DeliveryId"", dor.""DeliveryPriceTypeId"", dor.""OrderDate"",dor.TTN, dor.""Price"", dpt.""DeliveryPaymentName"", ""ReceiptCheck""*/

            DataAdapter["DeliveryOrders"].SelectCommand.Parameters.Add("StartDate", FbDbType.Date, 10);
            DataAdapter["DeliveryOrders"].SelectCommand.Parameters.Add("EndDate", FbDbType.Date, 10);

            //DataModule.DataAdapter["DeliveryOrders"].SelectCommand.Parameters.Add("StartDate", FbDbType.Date, 4);
            //DataModule.DataAdapter["DeliveryOrders"].SelectCommand.Parameters.Add("EndDate", FbDbType.Date, 4);
            //DataAdapter["DeliveryOrders"].SelectCommand.Parameters.Add("Order_Id", FbDbType.BigInt, 8, "Order_Id");

            //DataAdapter["Receipt"].SelectCommand.Parameters.Add("Order_Id", FbDbType.BigInt, 8, "Order_Id");

            // Insert Command
            DataAdapter["DeliveryOrders"].InsertCommand = Connection.CreateCommand();
            DataAdapter["DeliveryOrders"].InsertCommand.CommandText =
                @"INSERT INTO
                    ""DeliveryOrder""(""DeliveryId"", ""TTN"", ""Price"", ""OrderDate"", ""DeliveryPriceTypeId"")
                VALUES
                    (@DeliveryId, @TTN, @Price, @OrderDate, @DeliveryPriceTypeId)";
            //DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("DeliveryId", FbDbType.Integer, 4, "DeliveryId");
            DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("TTN", FbDbType.VarChar, 50, "TTN");
            DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("Price", FbDbType.Numeric, 11, "Price");
            DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("OrderDate", FbDbType.Date, 10, "OrderDate");
            DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("DeliveryPriceTypeId", FbDbType.SmallInt, 2, "DeliveryPriceTypeId");



            // Update Command
            DataAdapter["DeliveryOrders"].UpdateCommand = Connection.CreateCommand();
            DataAdapter["DeliveryOrders"].UpdateCommand.CommandText =
                @"UPDATE
                    ""DeliveryOrder""
                SET
                    ""DeliveryId"" = @DeliveryId, 
                    TTN = @TTN, 
                    ""Price"" = @Price,
                    ""OrderDate"" = @OrderDate, 
                    ""DeliveryPriceTypeId"" = @DeliveryPriceTypeId
                WHERE
                    ""Id"" = @Id";
            DataAdapter["DeliveryOrders"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            DataAdapter["DeliveryOrders"].UpdateCommand.Parameters.Add("DeliveryId", FbDbType.Integer, 4, "DeliveryId");
            DataAdapter["DeliveryOrders"].UpdateCommand.Parameters.Add("TTN", FbDbType.VarChar, 50, "TTN");
            DataAdapter["DeliveryOrders"].UpdateCommand.Parameters.Add("Price", FbDbType.Numeric, 11, "Price");
            DataAdapter["DeliveryOrders"].UpdateCommand.Parameters.Add("OrderDate", FbDbType.Date, 10, "OrderDate");
            DataAdapter["DeliveryOrders"].UpdateCommand.Parameters.Add("DeliveryPriceTypeId", FbDbType.SmallInt, 2, "DeliveryPriceTypeId");





            // Delete Command
            DataAdapter["DeliveryOrders"].DeleteCommand = Connection.CreateCommand();
            DataAdapter["DeliveryOrders"].DeleteCommand.CommandText =
                @"DELETE FROM
                    ""DeliveryOrder""
                WHERE
                    ""Id"" = @Id";
            DataAdapter["DeliveryOrders"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            #endregion

            #region DeliveryOrderDetails

            // DeliveryOrdersDetails
            DataAdapter.Add("DeliveryOrderDetails", new FbDataAdapter());
            // Select Command
            DataAdapter["DeliveryOrderDetails"].SelectCommand = Connection.CreateCommand();
            DataAdapter["DeliveryOrderDetails"].SelectCommand.CommandText =
                    @"SELECT
                        dod.""Id"",
                        dod.""OrderId"",
                        dod.""DeliveryOrderId"",
                        do.TTN,
                        do.""Price"",
                        do.""OrderDate"",
                        d.""DeliveryName"",
                        dpt.""DeliveryPaymentName"" 
                    FROM
                        ""DeliveryOrdersDetails"" dod
                    LEFT JOIN
                        ""DeliveryOrder"" do ON dod.""DeliveryOrderId"" = do.""Id""
                    LEFT JOIN
                        ""DeliveryPaymentType"" dpt ON do.""DeliveryPriceTypeId"" = dpt.""Id""
                    LEFT JOIN
                        ""Delivery"" d ON do.""DeliveryId"" = d.""Id""
                    WHERE
                        dod.""OrderId"" = @Order_Id";

            DataAdapter["DeliveryOrderDetails"].SelectCommand.Parameters.Add("Order_Id", FbDbType.BigInt, 8, "Order_Id");


            //            DataAdapter["DeliveryOrders"].InsertCommand = Connection.CreateCommand();
            //            DataAdapter["DeliveryOrders"].InsertCommand.CommandText =
            //                @"INSERT INTO
            //                    ""DeliveryOrder""(""DeliveryId"", ""TTN"", ""Price"", ""OrderDate"", ""DeliveryPriceTypeId"")
            //                VALUES
            //                    (@DeliveryId, @TTN, @Price, @OrderDate, @DeliveryPriceTypeId)";
            //            //DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            //            DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("DeliveryId", FbDbType.Integer, 4, "DeliveryId");
            //            DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("TTN", FbDbType.VarChar, 50, "TTN");
            //            DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("Price", FbDbType.Numeric, 11, "Price");
            //            DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("OrderDate", FbDbType.Date, 10, "OrderDate");
            //            DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("DeliveryPriceTypeId", FbDbType.SmallInt, 2, "DeliveryPriceTypeId");


            // Insert Command
            DataAdapter["DeliveryOrderDetails"].InsertCommand = Connection.CreateCommand();
            DataAdapter["DeliveryOrderDetails"].InsertCommand.CommandText =
                @"INSERT INTO
                    ""DeliveryOrdersDetails""(""OrderId"", ""DeliveryOrderId"")
                VALUES
                    (@OrderId, @DeliveryOrderId)";
            //DataAdapter["DeliveryOrders"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            DataAdapter["DeliveryOrderDetails"].InsertCommand.Parameters.Add("OrderId", FbDbType.BigInt, 8, "OrderId");
            DataAdapter["DeliveryOrderDetails"].InsertCommand.Parameters.Add("DeliveryOrderId", FbDbType.Integer, 4, "DeliveryOrderId");



            // Update Command
            DataAdapter["DeliveryOrderDetails"].UpdateCommand = Connection.CreateCommand();
            DataAdapter["DeliveryOrderDetails"].UpdateCommand.CommandText =
                @"UPDATE
                    ""DeliveryOrdersDetails""
                SET
                    ""Id"" = @Id, 
                    ""OrderId"" = @OrderId, 
                    ""DeliveryOrderId"" = @DeliveryOrderId
                WHERE
                    ""Id"" = @Id";
            DataAdapter["DeliveryOrderDetails"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            DataAdapter["DeliveryOrderDetails"].UpdateCommand.Parameters.Add("OrderId", FbDbType.BigInt, 8, "OrderId");
            DataAdapter["DeliveryOrderDetails"].UpdateCommand.Parameters.Add("DeliveryOrderId", FbDbType.Integer, 4, "DeliveryOrderId");





            // Delete Command
            DataAdapter["DeliveryOrderDetails"].DeleteCommand = Connection.CreateCommand();
            DataAdapter["DeliveryOrderDetails"].DeleteCommand.CommandText =
                @"DELETE FROM
                    ""DeliveryOrdersDetails""
                WHERE
                    ""Id"" = @Id";
            DataAdapter["DeliveryOrderDetails"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            #endregion

            #region Nomenclatures

            DataAdapter.Add("Nomenclatures", new FbDataAdapter());
            DataAdapter["Nomenclatures"].SelectCommand = Connection.CreateCommand();
            DataAdapter["Nomenclatures"].SelectCommand.CommandText =
                @"SELECT 
                     n.*, 
                     a.Num,
                     u.""UnitLocalName"" as UnitLocalName 
                   FROM 
                     Nomenclatures n
                   LEFT JOIN
                     Accounts a ON n.Balance_Account_Id = a.ID
                   LEFT JOIN
                     ""Units"" u ON n.""UnitId"" = u.""UnitId""";
            //
            DataAdapter["Nomenclatures"].InsertCommand = Connection.CreateCommand();
            DataAdapter["Nomenclatures"].InsertCommand.CommandText =
                @"INSERT INTO Nomenclatures(Nomenclature, Name, Measure, Balance_Account_Id, ""Nomencl_Group_Id"", ""UnitId"") VALUES(@Nomenclature, @Name, @Measure, @Balance_Account_Id, 0, @UnitId) RETURNING Id";
            DataAdapter["Nomenclatures"].InsertCommand.Parameters.Add("Nomenclature", FbDbType.VarChar, 12, "Nomenclature");
            DataAdapter["Nomenclatures"].InsertCommand.Parameters.Add("Name", FbDbType.VarChar, 200, "Name");
            DataAdapter["Nomenclatures"].InsertCommand.Parameters.Add("Measure", FbDbType.VarChar, 10, "Measure");
            DataAdapter["Nomenclatures"].InsertCommand.Parameters.Add("Balance_Account_Id", FbDbType.SmallInt, 2, "Balance_Account_Id");
            DataAdapter["Nomenclatures"].InsertCommand.Parameters.Add("UnitId", FbDbType.Integer, 4, "UnitId");
            DataAdapter["Nomenclatures"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id").Direction = ParameterDirection.Output;
            //
            DataAdapter["Nomenclatures"].UpdateCommand = Connection.CreateCommand();
            DataAdapter["Nomenclatures"].UpdateCommand.CommandText =
                @"UPDATE Nomenclatures SET Nomenclature = @Nomenclature, Name = @Name, Measure = @Measure, Balance_Account_Id = @Balance_Account_Id, ""UnitId"" = @UnitId WHERE Id = @Id";
            DataAdapter["Nomenclatures"].UpdateCommand.Parameters.Add("Nomenclature", FbDbType.VarChar, 12, "Nomenclature");
            DataAdapter["Nomenclatures"].UpdateCommand.Parameters.Add("Name", FbDbType.VarChar, 200, "Name");
            DataAdapter["Nomenclatures"].UpdateCommand.Parameters.Add("Measure", FbDbType.VarChar, 10, "Measure");
            DataAdapter["Nomenclatures"].UpdateCommand.Parameters.Add("UnitId", FbDbType.Integer, 4, "UnitId");
            DataAdapter["Nomenclatures"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            DataAdapter["Nomenclatures"].UpdateCommand.Parameters.Add("Balance_Account_Id", FbDbType.SmallInt, 2, "Balance_Account_Id");
            //
            DataAdapter["Nomenclatures"].DeleteCommand = DataModule.Connection.CreateCommand();
            DataAdapter["Nomenclatures"].DeleteCommand.CommandText =
                @"DELETE FROM Nomenclatures WHERE Id = @Id";
            DataAdapter["Nomenclatures"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            #endregion

            #region Vat

            DataAdapter.Add("Vat", new FbDataAdapter());
            // Select Command
            DataAdapter["Vat"].SelectCommand = Connection.CreateCommand();
            DataAdapter["Vat"].SelectCommand.CommandText =
                @"SELECT * FROM Vat WHERE Id = @Id";
            DataAdapter["Vat"].SelectCommand.Parameters.Add("Id", FbDbType.Integer);
            // Insert Command
            DataAdapter["Vat"].InsertCommand = Connection.CreateCommand();
            DataAdapter["Vat"].InsertCommand.CommandText =
                @"INSERT INTO Vat(Id, Account_Id, Price) VALUES(@Id, @Account_Id, @Price)";
            DataAdapter["Vat"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            DataAdapter["Vat"].InsertCommand.Parameters.Add("Account_Id", FbDbType.SmallInt, 2, "Vat_Account_Id");
            DataAdapter["Vat"].InsertCommand.Parameters.Add("Price", FbDbType.Numeric, 11, "Vat");
            // Update Command
            DataAdapter["Vat"].UpdateCommand = Connection.CreateCommand();
            DataAdapter["Vat"].UpdateCommand.CommandText =
                @"UPDATE Vat SET Account_Id = @Account_Id, Price = @Price WHERE Id = @Id";
            DataAdapter["Vat"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            DataAdapter["Vat"].UpdateCommand.Parameters.Add("Account_Id", FbDbType.SmallInt, 2, "Vat_Account_Id");
            DataAdapter["Vat"].UpdateCommand.Parameters.Add("Price", FbDbType.Numeric, 11, "Vat");
            // Delete Command
            DataAdapter["Vat"].DeleteCommand = Connection.CreateCommand();
            DataAdapter["Vat"].DeleteCommand.CommandText =
                @"DELETE FROM Vat WHERE Id = @Id";
            DataAdapter["Vat"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            
            #endregion

            #region Receipt

            DataAdapter.Add("Receipt", new FbDataAdapter());
            // Select Command
            DataAdapter["Receipt"].SelectCommand = Connection.CreateCommand();
            DataAdapter["Receipt"].SelectCommand.CommandText =
                @"SELECT
                    Receipts.Id, Receipts.Order_Id,
                    Receipts.Pos,
                    Receipts.Quantity, Receipts.Total_Price, Receipts.Unit_Price, Receipts.Unit_Currency, Receipts.Total_Currency,
                    Receipts.Nomenclature_Id, Nomenclatures.Nomenclature, Nomenclatures.Name AS Nomenclature_Name, Nomenclatures.Measure, Nomenclatures.""Nomencl_Group_Id"",
                    Accounts.Id AS Balance_Account_Id, Accounts.Num AS Balance_Num
                FROM
                    Receipts, Nomenclatures, Accounts
                WHERE
                    Receipts.Nomenclature_Id = Nomenclatures.Id AND
                    Nomenclatures.Balance_Account_Id = Accounts.Id AND
                    Receipts.Order_Id = @Order_Id
                ORDER BY
                    Receipts.Pos";
            DataAdapter["Receipt"].SelectCommand.Parameters.Add("Order_Id", FbDbType.Integer);
            // Insert Command
            DataAdapter["Receipt"].InsertCommand = Connection.CreateCommand();
            DataAdapter["Receipt"].InsertCommand.CommandText =
                @"INSERT INTO
                    Receipts(Order_Id, Pos, Total_Price, Total_Currency, Quantity, Nomenclature_Id)
                VALUES
                    (@Order_Id, @Pos, @Total_Price, @Total_Currency, @Quantity, @Nomenclature_Id)";
            DataAdapter["Receipt"].InsertCommand.Parameters.Add("Order_Id", FbDbType.Integer, 4, "Order_Id");
            DataAdapter["Receipt"].InsertCommand.Parameters.Add("Pos", FbDbType.SmallInt, 2, "Pos");
            DataAdapter["Receipt"].InsertCommand.Parameters.Add("Quantity", FbDbType.Numeric, 9, "Quantity");
            DataAdapter["Receipt"].InsertCommand.Parameters.Add("Total_Price", FbDbType.Numeric, 11, "Total_Price");
            DataAdapter["Receipt"].InsertCommand.Parameters.Add("Total_Currency", FbDbType.Numeric, 11, "Total_Currency");
            DataAdapter["Receipt"].InsertCommand.Parameters.Add("Nomenclature_Id", FbDbType.Integer, 4, "Nomenclature_Id");
            // Update Command
            DataAdapter["Receipt"].UpdateCommand = Connection.CreateCommand();
            DataAdapter["Receipt"].UpdateCommand.CommandText =
                @"UPDATE
                    Receipts
                SET
                    Order_Id = @Order_Id, Pos = @Pos, Quantity = @Quantity, Total_Price = @Total_Price, Total_Currency = @Total_Currency, Nomenclature_Id = @Nomenclature_Id
                WHERE
                    Id = @Id";
            DataAdapter["Receipt"].UpdateCommand.Parameters.Add("Order_Id", FbDbType.Integer, 4, "Order_Id");
            DataAdapter["Receipt"].UpdateCommand.Parameters.Add("Pos", FbDbType.SmallInt, 2, "Pos");
            DataAdapter["Receipt"].UpdateCommand.Parameters.Add("Quantity", FbDbType.Numeric, 9, "Quantity");
            DataAdapter["Receipt"].UpdateCommand.Parameters.Add("Total_Price", FbDbType.Numeric, 11, "Total_Price");
            DataAdapter["Receipt"].UpdateCommand.Parameters.Add("Total_Currency", FbDbType.Numeric, 11, "Total_Currency");
            DataAdapter["Receipt"].UpdateCommand.Parameters.Add("Nomenclature_Id", FbDbType.Integer, 4, "Nomenclature_Id");
            DataAdapter["Receipt"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            // Delete Command
            DataAdapter["Receipt"].DeleteCommand = Connection.CreateCommand();
            DataAdapter["Receipt"].DeleteCommand.CommandText = 
                @"DELETE FROM
                    Receipts
                WHERE
                    Id = @Id";
            DataAdapter["Receipt"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            
            #endregion

            #region Expenditures

            DataAdapter.Add("Expenditures", new FbDataAdapter());
            // Select Command
            DataAdapter["Expenditures"].SelectCommand = Connection.CreateCommand();
            DataAdapter["Expenditures"].SelectCommand.CommandText = Queries["Expenditures"];
            DataAdapter["Expenditures"].SelectCommand.Parameters.Add("StartDate", FbDbType.Date, 10);
            DataAdapter["Expenditures"].SelectCommand.Parameters.Add("EndDate", FbDbType.Date, 10);
            // Update Command
            DataAdapter["Expenditures"].UpdateCommand = Connection.CreateCommand();
            DataAdapter["Expenditures"].UpdateCommand.CommandText =
                @"UPDATE
                    Expenditures_Accountant
                SET
                    Exp_Date = @Exp_Date, Project_Num = @Project_Num, Credit_Account_Id = @Credit_Account_Id
                WHERE
                    Id = @Id";
            DataAdapter["Expenditures"].UpdateCommand.Parameters.Add("Exp_Date", FbDbType.Date, 10, "Exp_Date");
            DataAdapter["Expenditures"].UpdateCommand.Parameters.Add("Project_Num", FbDbType.VarChar, 12, "Project_Num");
            DataAdapter["Expenditures"].UpdateCommand.Parameters.Add("Credit_Account_Id", FbDbType.SmallInt, 2, "Credit_Account_Id");
            DataAdapter["Expenditures"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            // Delete Command
            DataAdapter["Expenditures"].DeleteCommand = Connection.CreateCommand();
            DataAdapter["Expenditures"].DeleteCommand.CommandText =
                @"DELETE FROM
                    Expenditures_Accountant
                WHERE
                    Id = @Id";
            DataAdapter["Expenditures"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            #endregion

            #region Invoice_Requirement_Orders

            DataModule.DataAdapter.Add("Invoice_Requirement_Orders", new FbDataAdapter());
            // Select Command
            DataModule.DataAdapter["Invoice_Requirement_Orders"].SelectCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Invoice_Requirement_Orders"].SelectCommand.CommandText =
                                            @"SELECT 
												 ""Invoice_Requirement_Orders"".""Number"", 
                                                 ""Invoice_Requirement_Orders"".""Date"", 
                                                 ""Invoice_Requirement_Orders"".""Id"" AS ReqOrderId,
												 ""Invoice_Requirement_Orders"".""Responsible_Person_Id"" AS SupplierId,
                                                 (""EmployeesDetails"".""LastName""||' '||substring(""EmployeesDetails"".""FirstName"" from 1 for 1)||'. '||substring(""EmployeesDetails"".""MiddleName"" from 1 for 1)||'.'||' ('||""Professions"".""Name""||')')   AS Responsible_Person
											   FROM 
                                                 ""Invoice_Requirement_Orders""
                                               LEFT JOIN
                                                 ""EmployeesDetails"" ON ""Invoice_Requirement_Orders"".""Responsible_Person_Id"" = ""EmployeesDetails"".""EmployeeID""
                                               INNER JOIN
                                                 ""Professions"" ON ""EmployeesDetails"".""ProfessionID"" = ""Professions"".""ProfessionID""
                                               WHERE
												 ""Date"" >= @StartDate AND ""Date"" <= @EndDate";

            DataModule.DataAdapter["Invoice_Requirement_Orders"].SelectCommand.Parameters.Add("StartDate", FbDbType.Date, 4);
            DataModule.DataAdapter["Invoice_Requirement_Orders"].SelectCommand.Parameters.Add("EndDate", FbDbType.Date, 4);
            // Insert Command
            DataModule.DataAdapter["Invoice_Requirement_Orders"].InsertCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Invoice_Requirement_Orders"].InsertCommand.CommandText =
                                                        @"INSERT INTO ""Invoice_Requirement_Orders""(""Id"",""Responsible_Person_Id"", ""Date"", ""Number"") VALUES(@Id, @Responsible_Person_Id, @Date, @Number)";
            DataModule.DataAdapter["Invoice_Requirement_Orders"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4, "ReqOrderId");
            DataModule.DataAdapter["Invoice_Requirement_Orders"].InsertCommand.Parameters.Add("Responsible_Person_Id", FbDbType.Integer, 4, "SupplierId");
            DataModule.DataAdapter["Invoice_Requirement_Orders"].InsertCommand.Parameters.Add("Date", FbDbType.Date, 6, "Date");
            DataModule.DataAdapter["Invoice_Requirement_Orders"].InsertCommand.Parameters.Add("Number", FbDbType.VarChar, 10, "Number");
            // Update Command
            DataModule.DataAdapter["Invoice_Requirement_Orders"].UpdateCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Invoice_Requirement_Orders"].UpdateCommand.CommandText =
                @"UPDATE ""Invoice_Requirement_Orders"" SET ""Responsible_Person_Id"" = @Responsible_Person_Id, ""Date"" = @Date, ""Number"" = @Number WHERE ""Id"" = @Id";
            DataModule.DataAdapter["Invoice_Requirement_Orders"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "ReqOrderId");
            DataModule.DataAdapter["Invoice_Requirement_Orders"].UpdateCommand.Parameters.Add("Responsible_Person_Id", FbDbType.Integer, 4, "SupplierId");
            DataModule.DataAdapter["Invoice_Requirement_Orders"].UpdateCommand.Parameters.Add("Date", FbDbType.Date, 6, "Date");
            DataModule.DataAdapter["Invoice_Requirement_Orders"].UpdateCommand.Parameters.Add("Number", FbDbType.VarChar, 10, "Number");
            // Delete Command
            DataModule.DataAdapter["Invoice_Requirement_Orders"].DeleteCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Invoice_Requirement_Orders"].DeleteCommand.CommandText =
                @"DELETE FROM ""Invoice_Requirement_Orders"" WHERE ""Id"" = @Id";
			DataModule.DataAdapter["Invoice_Requirement_Orders"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "ReqOrderId");

            #endregion

            #region Invoice_Requirement_Materials

            DataModule.DataAdapter.Add("Invoice_Requirement_Materials", new FbDataAdapter());
            // Select Command
            DataModule.DataAdapter["Invoice_Requirement_Materials"].SelectCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Invoice_Requirement_Materials"].SelectCommand.CommandText =
                                               @"SELECT
                                                        Orders.Receipt_Num,
                                                        ""Invoice_Requirement_Materials"".""Id"",
                                                        ""Invoice_Requirement_Materials"".""Receipt_Id"",
                                                        ""Invoice_Requirement_Materials"".""Invoice_Requirement_Order_Id"",
                                                        Balance_Account.Num,
                                                        Nomenclatures.Name, Nomenclatures.Nomenclature, Nomenclatures.Measure,
                                                        ""Invoice_Requirement_Materials"".""Required_Quantity"",
                                                        IIF(""Invoice_Requirement_Materials"".""Credit_Account_Id"" is NULL, 0, ""Invoice_Requirement_Materials"".""Required_Quantity"") AS Expen_Quantity,
                                                        Receipts.Unit_Price,
                                                        Expen_Account.Num AS Expen_Account,
                                                        ""Invoice_Requirement_Materials"".""Credit_Account_Id"" AS Credit_Account_Id,
                                                        Round(Expenditures_Accountant.Price, 2) AS Total_Price,
                                                        ""Invoice_Requirement_Materials"".""Expenditures_Id"",
                                                        ""Invoice_Requirement_Materials"".""Description"",
                                                        ""Invoice_Requirement_Materials"".""FixedAssets_Id"",
                                                        ""FixedAssetsOrder"".""InventoryNumber"",
                                                        ""FixedAssetsOrder"".""InventoryName""
                                                   FROM
                                                        ""Invoice_Requirement_Materials""
                                                   LEFT JOIN
                                                        Receipts ON ""Invoice_Requirement_Materials"".""Receipt_Id"" = Receipts.Id
                                                   LEFT JOIN
                                                        Accounts AS Expen_Account
                                                        ON ""Invoice_Requirement_Materials"".""Credit_Account_Id"" = Expen_Account.Id
                                                   LEFT JOIN
                                                        Orders ON Receipts.Order_Id = Orders.Id
                                                   LEFT JOIN
                                                        Nomenclatures ON Receipts.Nomenclature_Id = Nomenclatures.Id
                                                   LEFT JOIN
                                                        Accounts AS Balance_Account
                                                        ON Nomenclatures.Balance_Account_Id = Balance_Account.Id
                                                   LEFT JOIN
                                                        Expenditures_Accountant
                                                        ON ""Invoice_Requirement_Materials"".""Expenditures_Id"" = Expenditures_Accountant.Id
                                                   LEFT JOIN
                                                       ""FixedAssetsOrder"" 
                                                        ON ""Invoice_Requirement_Materials"".""FixedAssets_Id"" =  ""FixedAssetsOrder"".""Id""
                                                   WHERE
                                                        ""Invoice_Requirement_Materials"".""Invoice_Requirement_Order_Id"" = @Id 
                                                   ORDER BY Orders.Receipt_Num";
            DataModule.DataAdapter["Invoice_Requirement_Materials"].SelectCommand.Parameters.Add("Id", FbDbType.Integer, 4);
            DataModule.DataAdapter["Invoice_Requirement_Materials"].SelectCommand.Parameters.Add("StartDate", FbDbType.Date, 4);
            // Insert Command
            DataModule.DataAdapter["Invoice_Requirement_Materials"].InsertCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Invoice_Requirement_Materials"].InsertCommand.CommandText =
                                                         @"INSERT INTO ""Invoice_Requirement_Materials""(""Receipt_Id"", ""Invoice_Requirement_Order_Id"", ""Required_Quantity"", ""Credit_Account_Id"", ""Expenditures_Id"",""FixedAssets_Id"",""Description"") VALUES(@Receipt_Id, @Invoice_Requirement_Order_Id, @Required_Quantity, @Credit_Account_Id, @Expenditures_Id, @FixedAssets_Id, @Description)";
            DataModule.DataAdapter["Invoice_Requirement_Materials"].InsertCommand.Parameters.Add("Receipt_Id", FbDbType.Integer, 4, "Receipt_Id");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].InsertCommand.Parameters.Add("Invoice_Requirement_Order_Id", FbDbType.Integer, 4, "Invoice_Requirement_Order_Id");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].InsertCommand.Parameters.Add("Required_Quantity", FbDbType.Numeric, 10, "Required_Quantity");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].InsertCommand.Parameters.Add("Credit_Account_Id", FbDbType.SmallInt, 2, "Credit_Account_Id");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].InsertCommand.Parameters.Add("Expenditures_Id", FbDbType.Integer, 4, "Expenditures_Id");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].InsertCommand.Parameters.Add("FixedAssets_Id", FbDbType.Integer, 4, "FixedAssets_Id");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].InsertCommand.Parameters.Add("Description", FbDbType.VarChar, 200, "Description");
            // Update Command
            DataModule.DataAdapter["Invoice_Requirement_Materials"].UpdateCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Invoice_Requirement_Materials"].UpdateCommand.CommandText =
                                                         @"UPDATE ""Invoice_Requirement_Materials"" SET 
                                                                                            ""Receipt_Id""=@Receipt_Id,
                                                                                            ""Invoice_Requirement_Order_Id""=@Invoice_Requirement_Order_Id,
                                                                                            ""Required_Quantity""= @Required_Quantity,
                                                                                            ""Credit_Account_Id""=@Credit_Account_Id,
                                                                                            ""Expenditures_Id""= @Expenditures_Id,
                                                                                            ""FixedAssets_Id""=@FixedAssets_Id,
                                                                                            ""Description""=@Description
                                                                                            WHERE ""Receipt_Id"" = @Receipt_Id";
            DataModule.DataAdapter["Invoice_Requirement_Materials"].UpdateCommand.Parameters.Add("Receipt_Id", FbDbType.Integer, 4, "Receipt_Id");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].UpdateCommand.Parameters.Add("Invoice_Requirement_Order_Id", FbDbType.Integer, 4, "Invoice_Requirement_Order_Id");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].UpdateCommand.Parameters.Add("Required_Quantity", FbDbType.Numeric, 10, "Required_Quantity");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].UpdateCommand.Parameters.Add("Credit_Account_Id", FbDbType.SmallInt, 2, "Credit_Account_Id");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].UpdateCommand.Parameters.Add("Expenditures_Id", FbDbType.Integer, 4, "Expenditures_Id");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].UpdateCommand.Parameters.Add("FixedAssets_Id", FbDbType.Integer, 4, "FixedAssets_Id");
            DataModule.DataAdapter["Invoice_Requirement_Materials"].UpdateCommand.Parameters.Add("Description", FbDbType.VarChar, 200, "Description");
            // Delete Command
            DataModule.DataAdapter["Invoice_Requirement_Materials"].DeleteCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Invoice_Requirement_Materials"].DeleteCommand.CommandText =
                @"DELETE FROM ""Invoice_Requirement_Materials"" WHERE ""Id"" = @Id";
            DataModule.DataAdapter["Invoice_Requirement_Materials"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            #endregion
            
            #region CalcWithBayers

            DataModule.DataAdapter.Add("CalcWithBuyers", new FbDataAdapter());
            // Select Command
            DataModule.DataAdapter["CalcWithBuyers"].SelectCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["CalcWithBuyers"].SelectCommand.Parameters.Add("Begin_Date", FbDbType.Date, 10);
            DataModule.DataAdapter["CalcWithBuyers"].SelectCommand.Parameters.Add("End_Date", FbDbType.Date, 10);
            DataModule.DataAdapter["CalcWithBuyers"].SelectCommand.CommandText =
                                                 @"SELECT
                                                        c.""Id"",
                                                        c.""DocumentName"",
                                                        c.""DocumentDate"",
                                                        c.""Payment"",
                                                        IIF(cur.""Id"" is NOT NULL, cur.""CurrencyPayment"", NULL) as ""PaymentCurrency"",
                                                        IIF(ac_op.""OperationValue"" > 0, c.""Payment"", NULL) as ""PaymentDebet"",
                                                        IIF(ac_op.""OperationValue"" < 0, c.""Payment"", NULL) as ""PaymentCredit"",
                                                        IIF(cur.""Id"" is NOT NULL AND ac_op.""OperationValue"" > 0, cur.""CurrencyPayment"", NULL) as ""PaymentDebetCurrency"",
                                                        IIF(cur.""Id"" is NOT NULL AND ac_op.""OperationValue"" < 0, cur.""CurrencyPayment"", NULL) as ""PaymentCreditCurrency"",
                                                        c.""BalanceAccountId"",
                                                        ac_b.NUM as ""BalanceNum"",
                                                        c.""PurposeAccountId"",
                                                        ac_p.NUM as ""PurposeNum"",                                                      
                                                        c.""ContractorsId"",
                                                        con.""Name"",
                                                        con.""Srn"",
                                                        c.""EmployeesId"",
                                                        c.""Comment"",
                                                        emp.Employee_Number as ""Employee_Number"",
                                                        IIF(c.""ContractorsId"" is NULL, emp.FullName, con.""Name"") as ""Contractor_Name"",
                                                        IIF(c.""ContractorsId"" is NULL, emp.Employee_Number, con.""Srn"") as ""Contractor_Srn"",
                                                        c.""CurrencyRatesId"",
                                                        iif(c.""CurrencyRatesId"" is NULL , 1, cur.""Currency_Id"") as ""CalcCurrency_Id"",
                                                        iif(c.""CurrencyRatesId"" is NULL , 'UAH', cu.""Code"") as ""CurrencyName"",
                                                        cur.""Rate"",
                                                        c.""AccountingOperationId"",
                                                        coc.""CustomerOrderId"",
                                                        c_o.""OrderNumber""
                                                    FROM ""CalcWithBuyers"" as c
                                                    LEFT JOIN
                                                        ""AccountingOperation"" as ac_op ON c.""AccountingOperationId"" = ac_op.""Id""
                                                    LEFT JOIN
                                                        ""CustomerOrdersForCWB"" as coc ON c.""Id"" = coc.""CalcWithBuyerId""                                                           
                                                    LEFT JOIN
                                                        ""CustomerOrders"" as c_o ON coc.""CustomerOrderId"" = c_o.""Id""
                                                    LEFT JOIN 
                                                        ACCOUNTS as ac_b ON c.""BalanceAccountId"" = ac_b.ID
                                                    LEFT JOIN 
                                                        ACCOUNTS as ac_p ON c.""PurposeAccountId"" = ac_p.ID
                                                    LEFT JOIN
                                                        ""Contractors"" as con on c.""ContractorsId"" = con.""Id""
                                                    LEFT JOIN 
                                                        Responsible as emp ON c.""EmployeesId"" = emp.EMPLOYEEID
                                                    LEFT JOIN
                                                        ""Currency_Rates"" as cur ON c.""CurrencyRatesId"" = cur.""Id""
                                                    LEFT JOIN
                                                        ""Currency"" as cu on cur.""Currency_Id"" = cu.""Id""
                                                    WHERE 
                                                        c.""DocumentDate"" >= @Begin_Date and c.""DocumentDate"" <= @End_Date
                                                    ORDER BY
                                                        c.""DocumentDate""";

            // Insert Command
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.CommandText =
                                        @"INSERT INTO ""CalcWithBuyers""(""DocumentName"", ""DocumentDate"", ""Payment"", ""BalanceAccountId"", ""PurposeAccountId"", 
                                                      ""ContractorsId"", ""EmployeesId"", ""CurrencyRatesId"", ""Comment"", ""AccountingOperationId"") 
                                               VALUES(@DocumentName, @DocumentDate, @Payment, @BalanceAccountId, @PurposeAccountId, @ContractorsId, @EmployeesId, 
                                                      @CurrencyRatesId, @Comment, @AccountingOperationId) RETURNING ""Id""";
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters.Add("DocumentName", FbDbType.VarChar, 50, "DocumentName");
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters.Add("DocumentDate", FbDbType.Date, 6, "DocumentDate");
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters.Add("Payment", FbDbType.Numeric, 15, "Payment");
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters.Add("BalanceAccountId", FbDbType.SmallInt, 2, "BalanceAccountId");
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters.Add("PurposeAccountId", FbDbType.SmallInt, 2, "PurposeAccountId");
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters.Add("ContractorsId", FbDbType.Integer, 4, "ContractorsId");
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters.Add("EmployeesId", FbDbType.Integer, 4, "EmployeesId");
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters.Add("CurrencyRatesId", FbDbType.Integer, 4, "CurrencyRatesId");
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters.Add("Comment", FbDbType.VarChar, 2048, "Comment");
            DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters.Add("AccountingOperationId", FbDbType.SmallInt, 2, "AccountingOperationId");
            
            var returnCalcWithBuyersParam = DataModule.DataAdapter["CalcWithBuyers"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4);
            returnCalcWithBuyersParam.Direction = ParameterDirection.ReturnValue;

            // Update Command
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand = Connection.CreateCommand();
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.CommandText =
                @"UPDATE
                    ""CalcWithBuyers""
                SET
                    ""DocumentName"" = @DocumentName, 
                    ""DocumentDate"" = @DocumentDate, 
                    ""Payment"" = @Payment, 
                    ""BalanceAccountId"" = @BalanceAccountId,
                    ""PurposeAccountId"" = @PurposeAccountId,
                    ""ContractorsId"" = @ContractorsId,
                    ""EmployeesId"" = @EmployeesId,
                    ""CurrencyRatesId"" = @CurrencyRatesId,
                    ""Comment"" = @Comment,
                    ""AccountingOperationId"" = @AccountingOperationId
                WHERE
                    ""Id"" = @Id";
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Parameters.Add("DocumentName", FbDbType.VarChar, 50, "DocumentName");
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Parameters.Add("DocumentDate", FbDbType.Date, 6, "DocumentDate");
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Parameters.Add("Payment", FbDbType.Numeric, 15, "Payment");
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Parameters.Add("BalanceAccountId", FbDbType.SmallInt, 2, "BalanceAccountId");
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Parameters.Add("PurposeAccountId", FbDbType.SmallInt, 2, "PurposeAccountId");
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Parameters.Add("ContractorsId", FbDbType.Integer, 4, "ContractorsId");
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Parameters.Add("EmployeesId", FbDbType.Integer, 4, "EmployeesId");
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Parameters.Add("CurrencyRatesId", FbDbType.Integer, 4, "CurrencyRatesId");
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Parameters.Add("Comment", FbDbType.VarChar, 2048, "Comment");
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Parameters.Add("AccountingOperationId", FbDbType.SmallInt, 2, "AccountingOperationId");
            DataModule.DataAdapter["CalcWithBuyers"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            
            // Delete Command
            DataModule.DataAdapter["CalcWithBuyers"].DeleteCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["CalcWithBuyers"].DeleteCommand.CommandText =
                @"DELETE FROM ""CalcWithBuyers"" WHERE ""Id"" = @Id";
            DataModule.DataAdapter["CalcWithBuyers"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            #endregion

            #region Currency_Rates

            DataModule.DataAdapter.Add("Currency_Rates", new FbDataAdapter());
            // Select Command
            DataModule.DataAdapter["Currency_Rates"].SelectCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Currency_Rates"].SelectCommand.CommandText =
                                               @"SELECT
                                                      *                                                                                                          
                                                  FROM
                                                      ""Currency_Rates""
                                                  WHERE
                                                     ""Currency_Rates"".""Id"" = @Id";
            DataModule.DataAdapter["Currency_Rates"].SelectCommand.Parameters.Add("Id", FbDbType.Integer, 4);
            // Insert Command
            DataModule.DataAdapter["Currency_Rates"].InsertCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Currency_Rates"].InsertCommand.CommandText =
                                                        @"INSERT INTO ""Currency_Rates"" (""Currency_Id"", ""Date"", ""CurrencyPayment"", ""Rate"", ""Multiplicity"") 
                                                                                  VALUES (@Currency_Id, @Date, @CurrencyPayment, @Rate, @Multiplicity) RETURNING ""Id""";
            DataModule.DataAdapter["Currency_Rates"].InsertCommand.Parameters.Add("Currency_Id", FbDbType.Integer, 4, "Currency_Id");
            DataModule.DataAdapter["Currency_Rates"].InsertCommand.Parameters.Add("Date", FbDbType.Date, 6, "Date");
            DataModule.DataAdapter["Currency_Rates"].InsertCommand.Parameters.Add("CurrencyPayment", FbDbType.Numeric, 15, "CurrencyPayment");
            DataModule.DataAdapter["Currency_Rates"].InsertCommand.Parameters.Add("Rate", FbDbType.Numeric, 12, "Rate");
            DataModule.DataAdapter["Currency_Rates"].InsertCommand.Parameters.Add("Multiplicity", FbDbType.SmallInt, 2, "Multiplicity");

            var returnCurrencyRatesParam = DataModule.DataAdapter["Currency_Rates"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4);
            returnCurrencyRatesParam.Direction = ParameterDirection.ReturnValue;

            // Update Command
            DataModule.DataAdapter["Currency_Rates"].UpdateCommand = Connection.CreateCommand();
            DataModule.DataAdapter["Currency_Rates"].UpdateCommand.CommandText =
                @"UPDATE
                    ""Currency_Rates""
                SET
                    ""Currency_Id"" = @Currency_Id, 
                    ""Date"" = @Date,                    
                    ""CurrencyPayment"" = @CurrencyPayment, 
                    ""Rate"" = @Rate,
                    ""Multiplicity"" = @Multiplicity
                 WHERE
                    ""Id"" = @Id";
            DataModule.DataAdapter["Currency_Rates"].UpdateCommand.Parameters.Add("Currency_Id", FbDbType.Integer, 4, "Currency_Id");
            DataModule.DataAdapter["Currency_Rates"].UpdateCommand.Parameters.Add("Date", FbDbType.Date, 6, "Date");
            DataModule.DataAdapter["Currency_Rates"].UpdateCommand.Parameters.Add("CurrencyPayment", FbDbType.Numeric, 15, "CurrencyPayment");
            DataModule.DataAdapter["Currency_Rates"].UpdateCommand.Parameters.Add("Rate", FbDbType.Numeric, 12, "Rate");
            DataModule.DataAdapter["Currency_Rates"].UpdateCommand.Parameters.Add("Multiplicity", FbDbType.SmallInt, 2, "Multiplicity");
            DataModule.DataAdapter["Currency_Rates"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            // Delete Command
            DataModule.DataAdapter["Currency_Rates"].DeleteCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Currency_Rates"].DeleteCommand.CommandText =
                @"DELETE FROM ""Currency_Rates"" WHERE ""Id"" = @Id";
            DataModule.DataAdapter["Currency_Rates"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            #endregion

            #region Bank_Payments
            
            DataModule.DataAdapter.Add("Bank_Payments", new FbDataAdapter());

            // Select Command
            DataModule.DataAdapter["Bank_Payments"].SelectCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Bank_Payments"].SelectCommand.Parameters.Add("Begin_Date", FbDbType.Date, 10);
            DataModule.DataAdapter["Bank_Payments"].SelectCommand.Parameters.Add("End_Date", FbDbType.Date, 10);
            DataModule.DataAdapter["Bank_Payments"].SelectCommand.CommandText =
                                                @"SELECT
                                                    bp.""Id"",
                                                    bp.""Contractor_Id"",
                                                    con.""Name"" as Contractor_Name,
                                                    con.""Srn"" as Contractor_Srn,
                                                    bp.""EmployeesId"",
                                                    emp.Employee_Number as Employee_Number,                                                    
                                                    IIF(bp.""Contractor_Id"" IS NULL, emp.Employee_Number, con.""Srn"") as PartnerSrn,
                                                    IIF(bp.""Contractor_Id"" IS NULL, emp.FullName, con.""Name"") as PartnerName,
                                                    bp.""Payment_Document"",
                                                    bp.""Payment_Date"",
                                                    bp.""Payment_Price"",
                                                    bp.""Payment_PriceCurrency"",
                                                    bp.""Direction"",
                                                    IIF(bp.""Direction"" = 1, bp.""Payment_Price"", NULL) AS Debit_Price,
                                                    IIF(bp.""Direction"" = 1, bp.""Payment_PriceCurrency"", NULL) AS Debit_PriceCurrency,
                                                    IIF(bp.""Direction"" = -1, bp.""Payment_Price"", NULL) AS Credit_Price,
                                                    IIF(bp.""Direction"" = -1, bp.""Payment_PriceCurrency"", NULL) AS Credit_PriceCurrency,
                                                    bp.""Bank_Account_Id"",
                                                    b_ac.Num AS Bank_Account_Num,
                                                    bp.""Purpose_Account_Id"",
                                                    p_ac.Num AS Purpose_Account_Num,
                                                    bp.""Purpose"",
                                                    bp.""Rate"",
                                                    bp.""CurrencyId"",
                                                    cur.""Code"" as CurrencyName,
                                                    bp.""CustomerOrderId"",
                                                    c_o.""OrderNumber"",
                                                    bp.""CurrencyRatesConvertId""
                                                  FROM
                                                    ""Bank_Payments"" as bp
                                                  LEFT JOIN
                                                    ""Contractors"" as con ON bp.""Contractor_Id"" = con.""Id""
                                                  LEFT JOIN
                                                    Responsible as emp ON bp.""EmployeesId"" = emp.EMPLOYEEID
                                                  LEFT JOIN
                                                    ""Currency"" as cur ON bp.""CurrencyId"" = cur.""Id""
                                                  LEFT JOIN
                                                    Accounts as b_ac ON bp.""Bank_Account_Id"" = b_ac.Id
                                                  LEFT JOIN
                                                    Accounts as p_ac ON bp.""Purpose_Account_Id"" = p_ac.Id
                                                  LEFT JOIN
                                                    ""CustomerOrders"" as c_o ON bp.""CustomerOrderId"" = c_o.""Id""
                                                  WHERE
                                                    (bp.""Payment_Date"" BETWEEN @Begin_Date AND @End_Date)
                                                  ORDER BY
                                                    bp.""Payment_Date"",
                                                    bp.""Payment_Document""";

            // Insert Command
            DataModule.DataAdapter["Bank_Payments"].InsertCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.CommandText =
                                                        @"INSERT INTO ""Bank_Payments""(""Payment_Date"", ""Payment_Document"", ""Payment_Price"", ""Bank_Account_Id"",
                                                                                        ""Purpose_Account_Id"", ""Contractor_Id"", ""EmployeesId"", ""Direction"", ""Purpose"",
                                                                                        ""Rate"", ""CurrencyId"", ""Payment_PriceCurrency"", ""CustomerOrderId"", ""CurrencyRatesConvertId"") 
                                                                    VALUES(@Payment_Date, @Payment_Document, @Payment_Price, @Bank_Account_Id,
                                                                                        @Purpose_Account_Id, @Contractor_Id, @EmployeesId, @Direction, @Purpose,
                                                                                        @Rate, @CurrencyId, @Payment_PriceCurrency, @CustomerOrderId, @CurrencyRatesConvertId) RETURNING ""Id""";
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("Payment_Date", FbDbType.Date, 6, "Payment_Date");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("Payment_Document", FbDbType.VarChar, 35, "Payment_Document");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("Payment_Price", FbDbType.Numeric, 11, "Payment_Price");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("Bank_Account_Id", FbDbType.SmallInt, 2, "Bank_Account_Id");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("Purpose_Account_Id", FbDbType.SmallInt, 2, "Purpose_Account_Id");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("Contractor_Id", FbDbType.Integer, 4, "Contractor_Id");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("EmployeesId", FbDbType.Integer, 4, "EmployeesId");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("Direction", FbDbType.SmallInt, 2, "Direction");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("Purpose", FbDbType.VarChar, 500, "Purpose");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("Rate", FbDbType.Numeric, 11, "Rate");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("CurrencyId", FbDbType.SmallInt, 2, "CurrencyId");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("Payment_PriceCurrency", FbDbType.Numeric, 11, "Payment_PriceCurrency");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("CustomerOrderId", FbDbType.Integer, 4, "CustomerOrderId");
            DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("CurrencyRatesConvertId", FbDbType.Integer, 4, "CurrencyRatesConvertId");

            var returnBankPaymentParam = DataModule.DataAdapter["Bank_Payments"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4);
            returnBankPaymentParam.Direction = ParameterDirection.ReturnValue;

            // Update Command
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand = Connection.CreateCommand();
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.CommandText =
                @"UPDATE
                    ""Bank_Payments""
                SET
                    ""Payment_Date"" = @Payment_Date, 
                    ""Payment_Document"" = @Payment_Document, 
                    ""Payment_Price"" = @Payment_Price, 
                    ""Bank_Account_Id"" = @Bank_Account_Id,
                    ""Purpose_Account_Id"" = @Purpose_Account_Id, 
                    ""Contractor_Id"" = @Contractor_Id,
                    ""EmployeesId"" = @EmployeesId,  
                    ""Direction"" = @Direction, 
                    ""Purpose"" = @Purpose,
                    ""Rate"" = @Rate, 
                    ""CurrencyId"" = @CurrencyId, 
                    ""Payment_PriceCurrency"" = @Payment_PriceCurrency,
                    ""CustomerOrderId"" = @CustomerOrderId,
                    ""CurrencyRatesConvertId"" = @CurrencyRatesConvertId
                WHERE
                    ""Id"" = @Id";
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("Payment_Date", FbDbType.Date, 6, "Payment_Date");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("Payment_Document", FbDbType.VarChar, 35, "Payment_Document");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("Payment_Price", FbDbType.Numeric, 11, "Payment_Price");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("Bank_Account_Id", FbDbType.SmallInt, 2, "Bank_Account_Id");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("Purpose_Account_Id", FbDbType.SmallInt, 2, "Purpose_Account_Id");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("Contractor_Id", FbDbType.Integer, 4, "Contractor_Id");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("EmployeesId", FbDbType.Integer, 4, "EmployeesId");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("Direction", FbDbType.SmallInt, 2, "Direction");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("Purpose", FbDbType.VarChar, 500, "Purpose");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("Rate", FbDbType.Numeric, 11, "Rate");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("CurrencyId", FbDbType.SmallInt, 2, "CurrencyId");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("Payment_PriceCurrency", FbDbType.Numeric, 11, "Payment_PriceCurrency");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("CustomerOrderId", FbDbType.Integer, 4, "CustomerOrderId");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("CurrencyRatesConvertId", FbDbType.Integer, 4, "CurrencyRatesConvertId");
            DataModule.DataAdapter["Bank_Payments"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            // Delete Command
            DataModule.DataAdapter["Bank_Payments"].DeleteCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["Bank_Payments"].DeleteCommand.CommandText =
                @"DELETE FROM ""Bank_Payments"" WHERE ""Id"" = @Id";
            DataModule.DataAdapter["Bank_Payments"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            
            #endregion

            #region FixedAssetsOrder

            DataModule.DataAdapter.Add("FixedAssetsOrder", new FbDataAdapter());
            // Select Command
            DataModule.DataAdapter["FixedAssetsOrder"].SelectCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["FixedAssetsOrder"].SelectCommand.CommandText = DataModule.Queries["FixedAssetsOrder_Select"];
            DataModule.DataAdapter["FixedAssetsOrder"].SelectCommand.Parameters.Add("BeginDate", FbDbType.Date, 10);
            DataModule.DataAdapter["FixedAssetsOrder"].SelectCommand.Parameters.Add("EndDate", FbDbType.Date, 10);
            //Insert Command
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.CommandText =
                @"INSERT INTO
                    ""FixedAssetsOrder"" (
                      ""Id_Parent"",
                      ""InventoryNumber"", 
                      ""InventoryName"", 
                      ""Balance_Account_Id"", 
                      ""Supplier_Id"", 
                      ""BeginDate"", 
                      ""BeginRecordDate"", 
                      ""EndRecordDate"", 
                      ""Group_Id"", 
                      ""UsefulMonth"", 
                      ""Region_Id"", 
                      ""OperatingPerson_Id"", 
                      ""FixedCardStatus""
                                         )
                VALUES
                    (
                      @Id_Parent, 
                      @InventoryNumber, 
                      @InventoryName, 
                      @Balance_Account_Id, 
                      @Supplier_Id, 
                      @BeginDate, 
                      @BeginRecordDate, 
                      @EndRecordDate, 
                      @Group_Id, 
                      @UsefulMonth, 
                      @Region_Id, 
                      @OperatingPerson_Id, 
                      @FixedCardStatus
                                           ) RETURNING ""Id""";

            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("Id_Parent", FbDbType.Integer, 4, "Id_Parent");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("InventoryNumber", FbDbType.VarChar, 10, "InventoryNumber");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("InventoryName", FbDbType.VarChar, 100, "InventoryName");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("Balance_Account_Id", FbDbType.SmallInt, 2, "Balance_Account_Id");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("Supplier_Id", FbDbType.SmallInt, 2, "Supplier_Id");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("BeginDate", FbDbType.Date, 10, "BeginDate");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("BeginRecordDate", FbDbType.Date, 10, "BeginRecordDate");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("EndRecordDate", FbDbType.Date, 10, "EndRecordDate");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("Group_Id", FbDbType.SmallInt, 2, "Group_Id");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("UsefulMonth", FbDbType.SmallInt, 2, "UsefulMonth");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("Region_Id", FbDbType.SmallInt, 2, "Region_Id");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("OperatingPerson_Id", FbDbType.SmallInt, 2, "OperatingPerson_Id");
            DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("FixedCardStatus", FbDbType.SmallInt, 2, "FixedCardStatus");

            var returnParam = DataModule.DataAdapter["FixedAssetsOrder"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4);
            returnParam.Direction = ParameterDirection.ReturnValue;

            //Update Command
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.CommandText =
                @"UPDATE
                    ""FixedAssetsOrder""
                 SET
                    ""Id_Parent"" = @Id_Parent,
                    ""InventoryNumber"" = @InventoryNumber, 
                    ""InventoryName"" = @InventoryName, 
                    ""Balance_Account_Id"" = @Balance_Account_Id,
                    ""Supplier_Id"" = @Supplier_Id,
                    ""BeginDate"" = @BeginDate,
                    ""BeginRecordDate"" = @BeginRecordDate, 
                    ""EndRecordDate"" = @EndRecordDate,
                    ""Group_Id"" = @Group_Id,
                    ""UsefulMonth"" = @UsefulMonth,
                    ""Region_Id"" = @Region_Id,
                    ""OperatingPerson_Id"" = @OperatingPerson_Id,
                    ""FixedCardStatus"" = @FixedCardStatus
                 WHERE
                    ""Id"" = @Id";

            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("Id_Parent", FbDbType.Integer, 4, "Id_Parent");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("InventoryNumber", FbDbType.VarChar, 10, "InventoryNumber");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("InventoryName", FbDbType.VarChar, 100, "InventoryName");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("Balance_Account_Id", FbDbType.SmallInt, 2, "Balance_Account_Id");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("Supplier_Id", FbDbType.SmallInt, 2, "Supplier_Id");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("BeginDate", FbDbType.Date, 6, "BeginDate");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("BeginRecordDate", FbDbType.Date, 6, "BeginRecordDate");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("EndRecordDate", FbDbType.Date, 6, "EndRecordDate");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("Group_Id", FbDbType.SmallInt, 2, "Group_Id");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("UsefulMonth", FbDbType.SmallInt, 2, "UsefulMonth");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("Region_Id", FbDbType.SmallInt, 2, "Region_Id");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("OperatingPerson_Id", FbDbType.SmallInt, 2, "OperatingPerson_Id");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("FixedCardStatus", FbDbType.SmallInt, 2, "FixedCardStatus");
            DataModule.DataAdapter["FixedAssetsOrder"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            //Delete Command
            DataModule.DataAdapter["FixedAssetsOrder"].DeleteCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["FixedAssetsOrder"].DeleteCommand.CommandText =
                @"DELETE FROM
                    ""FixedAssetsOrder""
                WHERE
                    ""Id"" = @Id";
            DataModule.DataAdapter["FixedAssetsOrder"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            #endregion

            #region FixedAssetsMaterials

            DataModule.DataAdapter.Add("FixedAssetsMaterials", new FbDataAdapter());
            // Select Command
            DataModule.DataAdapter["FixedAssetsMaterials"].SelectCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["FixedAssetsMaterials"].SelectCommand.CommandText =
                                               @"SELECT
                                                      ""FixedAssetsMaterials"".""Id"",
                                                      ""FixedAssetsMaterials"".""FixedAssetsOrder_Id"",
                                                      ""FixedAssetsMaterials"".""Expenditures_Id"",
                                                      ""FixedAssetsMaterials"".""Fixed_Account_Id"",
                                                      ""FixedAssetsMaterials"".""Flag"",
                                                      ""FixedAssetsMaterials"".""MaterialsDate"",
                                                      ""FixedAssetsMaterials"".""Description"",
                                                      ""FixedAssetsMaterials"".""FixedPrice"",
                                                      ""FixedAssetsMaterials"".""SoldPrice"",                                                        
                                                      a.NUM as Fixed_Num,
                                                      iif(""FixedAssetsMaterials"".""Expenditures_Id"" IS NULL, ""FixedAssetsMaterials"".""MaterialsDate"", Expenditures_Accountant.Exp_Date) AS Exp_Date,
                                                      Expenditures_Accountant.Price,
                                                      exp.NUM as Expen_Num,
                                                      Receipts.ID AS Receipt_Id,
                                                      Receipts.Quantity,
                                                      Receipts.Unit_Price,
                                                      Receipts.Total_Price,
                                                      Receipts.Nomenclature_Id,
                                                      Nomenclatures.Nomenclature,
                                                      iif(""FixedAssetsMaterials"".""Expenditures_Id"" IS NULL, ""FixedAssetsMaterials"".""Description"", Nomenclatures.Name) AS Name,
                                                      Orders.Receipt_Num,
                                                      Orders.Order_Date,
                                                      Orders.Vendor_Id,
                                                      ""Contractors"".""Name"" AS Contractor_Name,
                                                      ""Contractors"".""Srn"",
                                                      Orders.Debit_Account_Id,
                                                      ord.NUM as Order_Num,
                                                      case ""FixedAssetsMaterials"".""Flag""
                                                            when 0 then 'Основное средство'
                                                            when 1 then 'Увеличение стоимости'
                                                            when 2 then 'Корректировка'
                                                            when 3 then 'Корректировка нач. стоимости'
                                                      end AS FlagNote                                                                                                          
                                                  FROM
                                                      ""FixedAssetsMaterials""
                                                  LEFT JOIN
                                                      Accounts a ON ""FixedAssetsMaterials"".""Fixed_Account_Id"" = a.ID
                                                  LEFT JOIN
                                                      Expenditures_Accountant ON ""FixedAssetsMaterials"".""Expenditures_Id"" = Expenditures_Accountant.ID
                                                  LEFT JOIN
                                                      Accounts exp ON Expenditures_Accountant.CREDIT_ACCOUNT_ID = exp.ID
                                                  LEFT JOIN
                                                      Receipts ON Expenditures_Accountant.RECEIPT_ID = Receipts.ID
                                                  LEFT JOIN
                                                      Nomenclatures ON Receipts.Nomenclature_Id = Nomenclatures.ID
                                                  LEFT JOIN
                                                      Orders ON Receipts.Order_Id = Orders.ID
                                                  LEFT JOIN
                                                      ""Contractors"" ON Orders.VENDOR_ID = ""Contractors"".""Id""
                                                  LEFT JOIN
                                                      Accounts ord ON Orders.DEBIT_ACCOUNT_ID = ord.ID
                                                  WHERE
                                                     ""FixedAssetsMaterials"".""FixedAssetsOrder_Id"" = @Id AND
                                                     IIF(""FixedAssetsMaterials"".""Expenditures_Id"" IS NULL, ""FixedAssetsMaterials"".""MaterialsDate"", Expenditures_Accountant.Exp_Date) <= @EndDate
                                                  ORDER BY
                                                     ""FixedAssetsMaterials"".""Flag""";
            DataModule.DataAdapter["FixedAssetsMaterials"].SelectCommand.Parameters.Add("Id", FbDbType.Integer, 4);
            DataModule.DataAdapter["FixedAssetsMaterials"].SelectCommand.Parameters.Add("EndDate", FbDbType.Date, 10);
            // Insert Command
            DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.CommandText =
                @"INSERT INTO
                    ""FixedAssetsMaterials"" (""FixedAssetsOrder_Id"", ""Expenditures_Id"", ""Fixed_Account_Id"", ""Flag"", ""FixedPrice"", ""MaterialsDate"", ""Description"", ""SoldPrice"")
                VALUES
                    (@FixedAssetsOrder_Id, @Expenditures_Id, @Fixed_Account_Id, @Flag, @FixedPrice, @MaterialsDate, @Description, @SoldPrice)";
            DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.Parameters.Add("FixedAssetsOrder_Id", FbDbType.Integer, 4, "FixedAssetsOrder_Id");
            DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.Parameters.Add("Expenditures_Id", FbDbType.Integer, 4, "Expenditures_Id");
            DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.Parameters.Add("Fixed_Account_Id", FbDbType.SmallInt, 2, "Fixed_Account_Id");
            DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.Parameters.Add("Flag", FbDbType.SmallInt, 2, "Flag");
            DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.Parameters.Add("FixedPrice", FbDbType.Numeric, 15, "FixedPrice");
            DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.Parameters.Add("MaterialsDate", FbDbType.Date, 6, "MaterialsDate");
            DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.Parameters.Add("Description", FbDbType.VarChar, 100, "Description");
            DataModule.DataAdapter["FixedAssetsMaterials"].InsertCommand.Parameters.Add("SoldPrice", FbDbType.Numeric, 15, "SoldPrice");
            //Update Comand
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand =DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.CommandText =
                @"UPDATE
                    ""FixedAssetsMaterials""
                 SET
                    ""FixedAssetsOrder_Id"" = @FixedAssetsOrder_Id, 
                    ""Expenditures_Id"" = @Expenditures_Id, 
                    ""Fixed_Account_Id"" = @Fixed_Account_Id,
                    ""Flag"" = @Flag,
                    ""FixedPrice"" = @FixedPrice,
                    ""MaterialsDate"" = @MaterialsDate,
                    ""Description"" = @Description,
                    ""SoldPrice"" = @SoldPrice
                 WHERE
                    ""Id"" = @Id";
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Parameters.Add("FixedAssetsOrder_Id", FbDbType.Integer, 4, "FixedAssetsOrder_Id");
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Parameters.Add("Expenditures_Id", FbDbType.Integer, 4, "Expenditures_Id");
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Parameters.Add("Fixed_Account_Id", FbDbType.SmallInt, 2, "Fixed_Account_Id");
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Parameters.Add("Flag", FbDbType.SmallInt, 2, "Flag");
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Parameters.Add("FixedPrice", FbDbType.Numeric, 15, "FixedPrice");
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Parameters.Add("MaterialsDate", FbDbType.Date, 6, "MaterialsDate");
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Parameters.Add("Description", FbDbType.VarChar, 100, "Description");
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Parameters.Add("SoldPrice", FbDbType.Numeric, 15, "SoldPrice");
            DataModule.DataAdapter["FixedAssetsMaterials"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            // Delete Command
            DataModule.DataAdapter["FixedAssetsMaterials"].DeleteCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["FixedAssetsMaterials"].DeleteCommand.CommandText =
                @"DELETE FROM
                    ""FixedAssetsMaterials""
                WHERE
                    ""Id"" = @Id";
            DataModule.DataAdapter["FixedAssetsMaterials"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");
            #endregion

            #region FixedAssetsArchive

            DataModule.DataAdapter.Add("FixedAssetsArchive", new FbDataAdapter());
            // Select Command
            DataModule.DataAdapter["FixedAssetsArchive"].SelectCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["FixedAssetsArchive"].SelectCommand.CommandText = DataModule.Queries["FixedAssetsArchive_Select"];
            DataModule.DataAdapter["FixedAssetsArchive"].SelectCommand.Parameters.Add("BeginDate", FbDbType.Date, 10);
            DataModule.DataAdapter["FixedAssetsArchive"].SelectCommand.Parameters.Add("EndDate", FbDbType.Date, 10);

            #endregion

            #region CustomerOrders

            DataModule.DataAdapter.Add("CustomerOrders", new FbDataAdapter());
            // Select Command
            DataModule.DataAdapter["CustomerOrders"].SelectCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["CustomerOrders"].SelectCommand.CommandText =
                                                            @"SELECT
                                                                c.""Id"",
                                                                c.""OrderNumber"",
                                                                c.""ContractorId"",
                                                                con.""Name"",
                                                                c.""OrderDate"",
                                                                c.""Details"",
                                                                c.""OrderPrice"",
                                                                c.""CurrencyPrice"",
                                                                c.""CurrencyId"",
                                                                cu.""Code"" as ""CurrencyName""
                                                            FROM 
                                                                ""CustomerOrders"" as c
                                                            LEFT JOIN
                                                                ""Contractors"" as con on c.""ContractorId"" = con.""Id""
                                                            LEFT JOIN
                                                                ""Currency"" as cu on c.""CurrencyId"" = cu.""Id""
                                                            ORDER BY
                                                                c.""OrderNumber"",""OrderDate""";

            // Insert Command
           
            DataModule.DataAdapter["CustomerOrders"].InsertCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["CustomerOrders"].InsertCommand.CommandText =
                                        @"INSERT INTO ""CustomerOrders""(""OrderNumber"", ""ContractorId"", ""OrderDate"", ""Details"", ""OrderPrice"", ""CurrencyPrice"",""CurrencyId"") 
                                                                    VALUES(@OrderNumber, @ContractorId, @OrderDate, @Details, @OrderPrice, @CurrencyPrice, @CurrencyId) RETURNING ""Id""";
            DataModule.DataAdapter["CustomerOrders"].InsertCommand.Parameters.Add("OrderNumber", FbDbType.VarChar, 12, "OrderNumber");
            DataModule.DataAdapter["CustomerOrders"].InsertCommand.Parameters.Add("ContractorId", FbDbType.Integer, 4, "ContractorId");
            DataModule.DataAdapter["CustomerOrders"].InsertCommand.Parameters.Add("OrderDate", FbDbType.Date, 6, "OrderDate");
            DataModule.DataAdapter["CustomerOrders"].InsertCommand.Parameters.Add("Details", FbDbType.VarChar, 500, "Details");
            DataModule.DataAdapter["CustomerOrders"].InsertCommand.Parameters.Add("OrderPrice", FbDbType.Numeric, 15, "OrderPrice");
            DataModule.DataAdapter["CustomerOrders"].InsertCommand.Parameters.Add("CurrencyPrice", FbDbType.Numeric, 15, "CurrencyPrice");
            DataModule.DataAdapter["CustomerOrders"].InsertCommand.Parameters.Add("CurrencyId", FbDbType.Integer, 4, "CurrencyId");


            var returnCustomerOrdersParam = DataModule.DataAdapter["CustomerOrders"].InsertCommand.Parameters.Add("Id", FbDbType.Integer, 4);
            returnCustomerOrdersParam.Direction = ParameterDirection.ReturnValue;

            // Update Command
            DataModule.DataAdapter["CustomerOrders"].UpdateCommand = Connection.CreateCommand();
            DataModule.DataAdapter["CustomerOrders"].UpdateCommand.CommandText =
                @"UPDATE
                    ""CustomerOrders""
                SET
                    ""OrderNumber"" = @OrderNumber, 
                    ""ContractorId"" = @ContractorId, 
                    ""OrderDate"" = @OrderDate, 
                    ""Details"" = @Details,
                    ""OrderPrice"" = @OrderPrice,
                    ""CurrencyPrice"" = @CurrencyPrice,
                    ""CurrencyId"" = @CurrencyId
                WHERE
                    ""Id"" = @Id";
            DataModule.DataAdapter["CustomerOrders"].UpdateCommand.Parameters.Add("OrderNumber", FbDbType.VarChar, 12, "OrderNumber");
            DataModule.DataAdapter["CustomerOrders"].UpdateCommand.Parameters.Add("ContractorId", FbDbType.Integer, 4, "ContractorId");
            DataModule.DataAdapter["CustomerOrders"].UpdateCommand.Parameters.Add("OrderDate", FbDbType.Date, 6, "OrderDate");
            DataModule.DataAdapter["CustomerOrders"].UpdateCommand.Parameters.Add("Details", FbDbType.VarChar, 500, "Details");
            DataModule.DataAdapter["CustomerOrders"].UpdateCommand.Parameters.Add("OrderPrice", FbDbType.Numeric, 15, "OrderPrice");
            DataModule.DataAdapter["CustomerOrders"].UpdateCommand.Parameters.Add("CurrencyPrice", FbDbType.Numeric, 15, "CurrencyPrice");
            DataModule.DataAdapter["CustomerOrders"].UpdateCommand.Parameters.Add("CurrencyId", FbDbType.Integer, 4, "CurrencyId");
            DataModule.DataAdapter["CustomerOrders"].UpdateCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");

            // Delete Command
            DataModule.DataAdapter["CustomerOrders"].DeleteCommand = DataModule.Connection.CreateCommand();
            DataModule.DataAdapter["CustomerOrders"].DeleteCommand.CommandText =
                @"DELETE FROM ""CustomerOrders"" WHERE ""Id"" = @Id";
            DataModule.DataAdapter["CustomerOrders"].DeleteCommand.Parameters.Add("Id", FbDbType.Integer, 4, "Id");


            #endregion

            #region Periods

            DataModule.DataAdapter.Add("Periods", new FbDataAdapter());
            // Select Command
            


            #endregion
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------
        #region Queries

        public static DataTable ExecuteFill(string SQLQuery, params FbParameter[] Parameters)
        {
            FbCommand Command = Connection.CreateCommand();
            Command.CommandText = SQLQuery;
            if (Parameters.Length > 0)
                Command.Parameters.AddRange(Parameters);
            FbDataAdapter DataAdapter = new FbDataAdapter(Command);
            DataTable Table = new DataTable();
            Command.Transaction = Transaction;
            DataAdapter.Fill(Table);
            Command.Dispose();
            DataAdapter.Dispose();
            return Table;
        }

        public static object ExecuteScalar(string SQLQuery, params FbParameter[] Parameters)
        {
            FbCommand Command = Connection.CreateCommand();
            Command.CommandText = SQLQuery;
            if (Parameters.Length > 0)
                Command.Parameters.AddRange(Parameters);
            Command.Transaction = Transaction;
            object Result = Command.ExecuteScalar();
            Command.Dispose();
            return Result;
        }

        public static int ExecuteNonQuery(string SQLQuery, params FbParameter[] Parameters)
        {
            FbCommand Command = Connection.CreateCommand();
            Command.CommandText = SQLQuery;
            if (Parameters.Length > 0)
                Command.Parameters.AddRange(Parameters);
            Command.Transaction = Transaction;
            int Result = Command.ExecuteNonQuery();
            Command.Dispose();
            return Result;
        }

        public static FbDataReader ExecuteReader(string SQLQuery, params FbParameter[] Parameters)
        {
            FbCommand Command = Connection.CreateCommand();
            Command.CommandText = SQLQuery;
            if (Parameters.Length > 0)
                Command.Parameters.AddRange(Parameters);
            return Command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static FbBatchExecution ExecuteBatch(bool AutoCommit = true, params string[] SQLQueries)
        {
            FbBatchExecution BatchExecution = new FbBatchExecution(Connection);
            BatchExecution.SqlStatements.AddRange(SQLQueries);
            BatchExecution.Execute(AutoCommit);
            return BatchExecution;
        }

        #endregion Queries

        //-----------------------------------------------------------------------------------------------------------------------------------------------------
        #region Procedures

        public static DataTable ExecuteFillProc(string SQLQuery, params FbParameter[] Parameters)
        {
            FbCommand Command = Connection.CreateCommand();
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = '"'+SQLQuery+'"';
            if (Parameters.Length > 0)
                Command.Parameters.AddRange(Parameters);
            FbDataAdapter DataAdapter = new FbDataAdapter(Command);
            DataTable Table = new DataTable();
            Command.Transaction = Transaction;
            DataAdapter.Fill(Table);
            Command.Dispose();
            DataAdapter.Dispose();
            return Table;
        }

        public static object ExecuteScalarProc(string SQLQuery, params FbParameter[] Parameters)
        {
            FbCommand Command = Connection.CreateCommand();
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = SQLQuery;
            if (Parameters.Length > 0)
                Command.Parameters.AddRange(Parameters);
            Command.Transaction = Transaction;
            object Result = Command.ExecuteScalar();
            Command.Dispose();
            return Result;
        }

        public static int ExecuteNonQueryProc(string SQLQuery, params FbParameter[] Parameters)
        {
            FbCommand Command = Connection.CreateCommand();
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = SQLQuery;
            if (Parameters.Length > 0)
                Command.Parameters.AddRange(Parameters);
            Command.Transaction = Transaction;
            int Result = Command.ExecuteNonQuery();
            Command.Dispose();
            return Result;
        }

        public static FbDataReader ExecuteReaderProc(string SQLQuery, params FbParameter[] Parameters)
        {
            FbCommand Command = Connection.CreateCommand();
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = SQLQuery;
            if (Parameters.Length > 0)
                Command.Parameters.AddRange(Parameters);
            return Command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #endregion Procedures

        //-----------------------------------------------------------------------------------------------------------------------------------------------------
        #region Transactions

        public static FbTransaction CreateTransaction(IsolationLevel ILevel = IsolationLevel.ReadCommitted)
        {
            FbTransaction Transaction = Connection.BeginTransaction(ILevel);
            return Transaction;
        }

        public static void BeginTransaction(IsolationLevel ILevel = IsolationLevel.ReadCommitted)
        {
            Transaction = Connection.BeginTransaction(ILevel);
        }

        public static void CommitTransaction()
        {
            Transaction.Commit();
            Transaction.Dispose();
        }

        public static void CommitTransaction(string SavePointName)
        {
            Transaction.Commit(SavePointName);
            Transaction.Dispose();
        }

        public static void CommitRetaining()
        {
            Transaction.CommitRetaining();
        }

        public static void RollbackTransaction()
        {
            Transaction.Rollback();
            Transaction.Dispose();
        }

        public static void RollbackTransaction(string SavePointName)
        {
            Transaction.Rollback(SavePointName);
            Transaction.Dispose();
        }

        public static void RollbackRetaining()
        {
            Transaction.RollbackRetaining();
        }

        public static void SavePointTransaction(string SavePointName)
        {
            Transaction.Save(SavePointName);
        }

        public static void DisposeTransaction()
        {
            Transaction.Dispose();
        }

        #endregion Transactions

        //-----------------------------------------------------------------------------------------------------------------------------------------------------
        public static FbRemoteEvent RemoteEvent(FbRemoteEventEventHandler EvHandler, params string[] Events)
        {
            FbRemoteEvent RemEvent = new FbRemoteEvent(Connection);
            RemEvent.AddEvents(Events);
            RemEvent.RemoteEventCounts += EvHandler;
            RemEvent.QueueEvents();

            return RemEvent;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        public static string GetError(FbException Excpt)
        {
            string ErrorText;
            if (Errors.ContainsKey(Excpt.ErrorCode.ToString()))
            {
                ErrorText =
                    "=======================================\n\r" +
                    DateTime.Now.ToString() + "\n\r" +
                    "=======================================\n\r\n\r" +
                    "ErrorCode:\n\r" + Excpt.ErrorCode + "\n\r\n\rMessage:\n\r" + Excpt.Message + "\n\r\n\rSource:\n\r" + Excpt.Source + "\n\r\n\rSQLState:\n\r" + Excpt.SQLSTATE + "\n\r\n\rStackTrace:\n\r" + Excpt.StackTrace +
                    "\n\r\n\r";
                File.AppendAllText(Utils.HomePath + "\\Error.log", ErrorText);
                return Errors[Excpt.ErrorCode.ToString()];
            }
            else
            {
                ErrorText =
                    "=======================================\n\r" +
                    DateTime.Now.ToString() + "\n\r" +
                    "=======================================\n\r\n\r" +
                    "ErrorCode:\n\r" + Excpt.ErrorCode + "\n\r\n\rMessage:\n\r" + Excpt.Message + "\n\r\n\rSource:\n\r" + Excpt.Source + "\n\r\n\rSQLState:\n\r" + Excpt.SQLSTATE + "\n\r\n\rStackTrace:\n\r" + Excpt.StackTrace +
                    "\n\r\n\r";
                File.AppendAllText(Utils.HomePath + "\\Error.log", ErrorText);
                return "Произошла ошибка №:\n\r" + Excpt.ErrorCode + "\n\r\n\rMessage:\n\r" + Excpt.Message + "\n\r\n\rSource:\n\r" + Excpt.Source + "\n\r\n\rSQLState:\n\r" + Excpt.SQLSTATE + "\n\r\n\rStackTrace:\n\r" + Excpt.StackTrace;
            }
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
