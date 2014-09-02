-- This query returns the TotalPurchases for every ProductType
-- It can be used for generating additional reports.
-- for Yana Yankova

SELECT pd.Type as ProductType, SUM(Quantity) as TotalPurchases, pd.Description
FROM Purchases pur
INNER JOIN Products pro
ON pro.Id = pur.ProductId
INNER JOIN ProductDetails pd
ON pd.Id = pro.DetailsId
GROUP BY  pd.Type, pd.Description
ORDER BY totalPurchases DESC