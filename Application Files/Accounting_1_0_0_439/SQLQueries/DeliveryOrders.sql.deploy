SELECT
    dor."Id",
    d."DeliveryName",
    dor."DeliveryId",
    dor."DeliveryPriceTypeId",
    dor."OrderDate" AS "DeliveryTTNDate",
    dor.TTN,
    dor."Price" AS "DeliveryPrice",
    dpt."DeliveryPaymentName",
    con."Srn" AS "ContractorCode",
    con."Name" AS "Contractorname",
    o."RECEIPT_NUM" AS "ReceiptNum",
    o.ORDER_DATE AS "OrderDate",
    o.INVOICE_DATE AS "InvoiceDate"
FROM
    "DeliveryOrder" dor
LEFT JOIN
    "DeliveryPaymentType" dpt ON dor."DeliveryPriceTypeId" = dpt."Id"
LEFT JOIN
    "Delivery" d ON dor."DeliveryId" = d."Id"
LEFT JOIN
    "DeliveryOrdersDetails" dod ON dor."Id" = dod."DeliveryOrderId"
LEFT JOIN
    ORDERS o ON dod."OrderId" = o.ID
LEFT JOIN
    "Contractors" con ON o.VENDOR_ID = con."Id"
WHERE
    dor."OrderDate" BETWEEN @StartDate AND @EndDate
ORDER BY
    dor."OrderDate" DESC
    /*(o."Flag1" = @Flag1 OR o."Flag2" = @Flag2 OR o."Flag3" = @Flag3 OR o."Flag4" = @Flag4) */
