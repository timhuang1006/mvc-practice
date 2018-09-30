USE TSQL2012;
GO
/*第一題*/	--EMLPLOYEE IS MAIN TABLE   --COUNT *>ORDERDATE
SELECT HR.EmployeeID AS EMPID,FirstName,LastName,YEAR(OrderDate) AS ORDERDATE,COUNT(OrderDate) AS ORDERCENT
FROM Sales.Orders AS SO RIGHT JOIN HR.Employees AS HR ON SO.EmployeeID=HR.EmployeeID
GROUP BY HR.EmployeeID,FirstName,LastName,LastName,YEAR(OrderDate)
ORDER BY HR.EmployeeID,YEAR(OrderDate);
/*放SO 或 HR*/

/*第二題*/
SELECT TOP(5) SD.productid,ProductName,SUM(SD.Qty)AS qty
FROM Sales.Orders AS SO JOIN Sales.OrderDetails AS SD ON SO.OrderID=SD.OrderID 
	JOIN Production.Products AS P ON P.ProductID=SD.ProductID 
GROUP BY SD.productid,ProductName
ORDER BY qty DESC

--第三題   --未來變動性> 將range設為變數	-- MAX 為最大值 若已知長度可改
SELECT CONVERT(varchar(MAX) ,(DATEDIFF(yyyy , BirthDate , GETDATE()) /10 * 10 ) )
+ '~' + CONVERT(varchar(MAX),(DATEDIFF(yyyy , BirthDate , GETDATE()) /10 * 10 + 9)) ,COUNT((DATEDIFF(yyyy , BirthDate , GETDATE()) /10 ))
FROM HR.Employees AS HR 
Group by (DATEDIFF(yyyy , BirthDate , GETDATE()) /10 )

--第四題
select *
from ( select row_number() over( partition by shipcountry order by count(*) desc) as seq,shipcountry,hr.EmployeeID as empid,firstname,lastname,count(*) as cnt
		from Sales.Orders as so join  HR.Employees as hr on so.EmployeeID=hr.EmployeeID
		 group by ShipCountry,hr.EmployeeID,FirstName,LastName) as a
where seq<=3
order by ShipCountry,cnt desc;



/*第5題*/
SELECT EMPID,FirstName,LastName,[2006] as cnt2006,[2007] as cnt2007,[2008] as cnt2008
FROM (SELECT SO.EmployeeID AS EMPID,FirstName,LastName,YEAR(OrderDate) AS ORDERDATE,COUNT(*) AS ORDERCENT
	FROM Sales.Orders AS SO INNER JOIN HR.Employees AS HR ON SO.EmployeeID=HR.EmployeeID
GROUP BY SO.EmployeeID,FirstName,LastName,LastName,YEAR(OrderDate)
) AS D
PIVOT(sum(ORDERCENT) FOR OrderDate			/*此處若使用COUNT則為計數*/  -- IF   *  ?
  	IN([2006],[2007],[2008])
		) AS pvt
GROUP BY EMPID,FirstName,LastName,[2006],[2007],[2008]

--第六題
SELECT so.OrderID AS 訂單代號,
	Convert(Date,OrderDate) AS 訂購日期,
	Convert(Date,RequiredDate) AS 需要日期,
	Convert(varchar(max), so.CustomerID) + '-'+CompanyName AS 公司名稱,FirstName++'  '+LastName as 管理員,
	Convert(varchar(max), p.ProductID) +'-'+ProductName as 商品,sd.UnitPrice as 原價,qty as 數量,(Qty*sd.UnitPrice) as 小計
FROM Sales.Orders as so , Sales.OrderDetails as sd   , Production.Products as p ,Sales.Customers as sc,HR.Employees AS HR
 where so.OrderID='11070'and so.OrderID= sd.OrderID and sd.UnitPrice= p.UnitPrice and 
 sd.ProductID=p.ProductID and sc.CustomerID=so.CustomerID and hr.EmployeeID = so.EmployeeID
/* GROUP BY so.OrderID,Convert(Date,OrderDate),Convert(Date,RequiredDate),
Convert(varchar(max), so.CustomerID) +'-'+ CompanyName,
Convert(varchar(max), so.EmployeeID) +'-'+ContactName,
Convert(varchar(max), p.ProductID) +'-'+ProductName,sd.UnitPrice,qty;
*/
SELECT *FROM Sales.Orders WHERE OrderID='11070';
SELECT *FROM Production.Products;
SELECT *FROM Sales.OrderDetails WHERE OrderID='11070'
SELECT *FROM Sales.Customers WHERE CompanyName='Customer OXFRU';
select(
SELECT *FROM Sales.OrderDetails) as a
from Production.Products
where ProductID='38'

--第七題
insert into Sales.OrderDetails
values (11070,38,263.5,2,0.000);


update Sales.Orders
set RequiredDate= DATEADD(MONTH,0,'2008-10-10')
where OrderID='11070';

SELECT so.OrderID AS 訂單代號,Convert(Date,OrderDate) AS 訂購日期,Convert(Date,RequiredDate) AS 需要日期,
  Convert(varchar(max), so.CustomerID) + '-'+CompanyName AS 公司名稱,
  FirstName++'  '+LastName as 管理員,
  Convert(varchar(max), p.ProductID) +'-'+ProductName as 商品,sd.UnitPrice as 原價,
   qty as 數量,(Qty*sd.UnitPrice) as 小計
FROM Sales.Orders as so , Sales.OrderDetails as sd   , Production.Products as
 p ,Sales.Customers as sc,HR.Employees AS HR
 where so.OrderID='11070'and so.OrderID= sd.OrderID and sd.UnitPrice= p.UnitPrice and 
 sd.ProductID=p.ProductID and sc.CustomerID=so.CustomerID and hr.EmployeeID = so.EmployeeID
 
 
 --第八題
 delete from Sales.OrderDetails
 where OrderID='11070'and ProductID='38';

 SELECT so.OrderID AS 訂單代號,Convert(Date,OrderDate) AS 訂購日期,Convert(Date,RequiredDate) AS 需要日期,
  Convert(varchar(max), so.CustomerID) + '-'+CompanyName AS 公司名稱,
  FirstName++'  '+LastName as 管理員,
  Convert(varchar(max), p.ProductID) +'-'+ProductName as 商品,sd.UnitPrice as 原價,
   qty as 數量,(Qty*sd.UnitPrice) as 小計
FROM Sales.Orders as so , Sales.OrderDetails as sd   , Production.Products as
 p ,Sales.Customers as sc,HR.Employees AS HR
 where so.OrderID='11070'and so.OrderID= sd.OrderID and sd.UnitPrice= p.UnitPrice and 
 sd.ProductID=p.ProductID and sc.CustomerID=so.CustomerID and hr.EmployeeID = so.EmployeeID
 