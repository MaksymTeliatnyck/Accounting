SELECT
    c."Id",
    c."OrderNumber" || ' ' || COALESCE(con."Name", '') AS OrderNumber
  FROM
    "CustomerOrders" c
  LEFT JOIN
    "Contractors" con ON c."ContractorId" = con."Id"