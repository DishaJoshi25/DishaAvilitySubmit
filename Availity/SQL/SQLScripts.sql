
--Write a SQL query that will produce a reverse-sorted list (alphabetically by name) of customers(first and last names) whose last name begins with the letter ‘S.’

SELECT FirstName, LastName
FROM Customer
WHERE LastName LIKE 'S%'
ORDER BY LastName DESC, FirstName DESC;

--Write a SQL query that will show the total value of all orders each customer has placed in the past six months. Any customer without any orders should show a $0 value.

SELECT c.FirstName, c.LastName, COALESCE(SUM(ol.Cost * ol.Quantity), 0) AS TotalOrderValue
FROM Customer c
LEFT JOIN `Order` o ON c.PKCustID = o.FK1CustomerID
LEFT JOIN OrderLine ol ON o.PKOrderID = ol.FK1OrdID
WHERE o.OrderDate >= DATE_SUB(CURRENT_DATE(), INTERVAL 6 MONTH)
GROUP BY c.PKCustID;


--Amend the query from the previous question to only show those customers who have a total order value of more than $100 and less than $500 in the past six months.

SELECT c.FirstName, c.LastName, COALESCE(SUM(ol.Cost * ol.Quantity), 0) AS TotalOrderValue
FROM Customer c
LEFT JOIN `Order` o ON c.PKCustID = o.FK1CustomerID
LEFT JOIN OrderLine ol ON o.PKOrderID = ol.FK1OrdID
WHERE o.OrderDate >= DATE_SUB(CURRENT_DATE(), INTERVAL 6 MONTH)
GROUP BY c.PKCustID
HAVING TotalOrderValue > 100 AND TotalOrderValue < 500;


--Improved same query

SELECT c.FirstName, c.LastName, COALESCE(SUM(ol.Cost * ol.Quantity), 0) AS TotalOrderValue
FROM Customer c
INNER JOIN `Order` o ON c.PKCustID = o.FK1CustomerID
INNER JOIN OrderLine ol ON o.PKOrderID = ol.FK1OrdID
WHERE o.OrderDate >= DATE_SUB(CURRENT_DATE(), INTERVAL 6 MONTH)
GROUP BY c.PKCustID
HAVING TotalOrderValue > 100 AND TotalOrderValue < 500;